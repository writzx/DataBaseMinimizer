Imports System.IO
Imports System.Data.OleDb

Public Class MainForm
    Private tbl_list As New List(Of DataTable)
    Private Sub browse_btn_Click(sender As Object, e As EventArgs) Handles browse_btn.Click
        If dbOpener.ShowDialog() = DialogResult.OK Then
            table_list.Items.Clear()
            tbl_list.Clear()
            For Each fname As String In dbOpener.FileNames
                Dim excel As Boolean = Path.GetExtension(fname).Contains("xls")
                Dim constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fname & If(excel, ";Extended Properties=""Excel 12.0 Xml; HDR = YES""", String.Empty)
                Using con As New OleDbConnection(constr)
                    con.Open()
                    Dim range = con.GetSchema("Tables").Select("TABLE_TYPE = 'TABLE'").Select(Function(x) New ListViewItem(New String() {x("TABLE_NAME").ToString(), " "})).ToArray()
                    table_list.Items.AddRange(range)
                    For Each litem In range
                        Dim tbl As New DataTable
                        Dim cmd As New OleDbCommand("SELECT * FROM [" & litem.Text & "]", con)
                        Dim dta As New OleDbDataAdapter(cmd)
                        dta.Fill(tbl)
                        tbl_list.Add(tbl)
                    Next
                End Using
            Next
        End If
    End Sub

    Private Sub table_list_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles table_list.MouseDown
        Dim col = 0, row = 0
        Dim s = DirectCast(sender, ListView)
        If GetListSubItemFromPoint(s, e.X, e.Y, row, col) Then
            If col = 1 Then
                Dim si = s.Items(row).SubItems(col)
                si.Text = GetSType(s, si.Text, row)
            End If
        End If
    End Sub

    Function GetSType(ByVal lv As ListView, ByVal currentT As String, ByVal si As Integer)
        Dim current = GetNextType(currentT)
        If (Not String.IsNullOrWhiteSpace(current)) AndAlso
            (lv.Items.Cast(Of ListViewItem).Any(Function(x) x.SubItems(1).Text = current) OrElse
            (current = "Test" OrElse current = "Train") AndAlso lv.Items.Cast(Of ListViewItem).Any(Function(x) x.Index <> si AndAlso x.SubItems(1).Text = "Train and Test") OrElse
            (current = "Train and Test" AndAlso (lv.Items.Cast(Of ListViewItem).Any(Function(x) x.Index <> si AndAlso x.SubItems(1).Text = "Train") OrElse lv.Items.Cast(Of ListViewItem).Any(Function(x) x.Index <> si AndAlso x.SubItems(1).Text = "Test")))) Then
            Return GetSType(lv, current, si)
        End If
        Return current
    End Function

    Private Function GetNextType(current As String) As String
        If String.IsNullOrWhiteSpace(current) Then
            Return "Train"
        ElseIf current = "Train" Then
            Return "Test"
        ElseIf current = "Test" Then
            Return "Train and Test"
        ElseIf current = "Train and Test" Then
            Return " "
        End If
    End Function

    Function GetListSubItemFromPoint(ByVal lv As ListView,
      ByVal X As Integer,
      ByVal Y As Integer,
      Optional ByRef retRow As Integer = 0,
      Optional ByRef retCol As Integer = 0) As Boolean

        Dim flag As Boolean
        Dim Item As ListViewItem
        Dim col, row As Integer

        Try
            flag = lv.FullRowSelect

            '//FullRow select must be true in order to use GetItemAt properly
            If flag = False Then lv.FullRowSelect = True '//temperory make it true
            If lv.Items.Count <= 0 And lv.Columns.Count > 0 Then
                '//if no item then to get subitem add dummy 
                '//listitem/subitems and then very last delete it 

                lv.BeginUpdate() '//no update to listview until we are done

                With lv.Items.Add(".")
                    For col = 0 To lv.Columns.Count - 1
                        .SubItems.Add("..")
                    Next
                    '//Y cordinate can be any where in the list view but
                    '//shift it on first item so GetItemAt return item
                    Y = .GetBounds(ItemBoundsPortion.Label).Y
                End With
                Item = lv.GetItemAt(X, Y)
                row = -1
            Else
                Item = lv.GetItemAt(X, Y)
            End If

            lv.FullRowSelect = flag '//switch back to old value

            If Not Item Is Nothing Then
                Dim I As Integer = 0
                Dim R As Rectangle = Item.GetBounds(ItemBoundsPortion.Label)
                Do While I < Item.SubItems.Count
                    If R.Contains(X, Y) Then
                        retRow = IIf(row = -1, -1, Item.Index)
                        retCol = I

                        GetListSubItemFromPoint = True
                        Exit Do
                    End If
                    R.X = R.X + lv.Columns(I).Width
                    R.Width = lv.Columns(I + 1).Width
                    I = I + 1
                Loop
            End If

        Catch ex As Exception
        Finally
            If row = -1 Then
                lv.Items.Clear()
                lv.EndUpdate()
                GetListSubItemFromPoint = False
            End If
        End Try
    End Function

    Private Sub table_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles table_list.SelectedIndexChanged
        Application.DoEvents()
        If (table_list.SelectedIndices.Count > 0) Then table_view.DataSource = tbl_list(table_list.SelectedIndices(0))
    End Sub

    Private Sub cont_button_Click(sender As Object, e As EventArgs) Handles cont_button.Click
        Dim f = New FunctionsForm
        For Each t As ListViewItem In table_list.Items
            If t.SubItems(1).Text = "Train and Test" Then
                Dim trc = tbl_list(t.Index).Rows.Count
                Dim p As Double, UPPER = Math.Floor((trc - 1) * 100 / trc), LOWER = Math.Ceiling(1 * 100 / trc)
                While (Not (Double.TryParse(InputBox("Enter the percentage of train set (" & LOWER & "-" & UPPER & "): ", "Set Division", "70"), p) AndAlso
                    (p > LOWER) AndAlso (p < UPPER)))
                    If MsgBox("Enter a valid percentage value! Value should be between " & LOWER & " and " & UPPER, MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, "Invalid percentage.") = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                End While
                p /= 100
                f.tables = DivideList(tbl_list(t.Index), p)
                Exit For
            End If
        Next
        Me.Hide()
        f.Show()
    End Sub

    Function DivideList(ByVal t As DataTable, trainRatio As Double) As (train As DataTable, test As DataTable)
        Dim train = t.Clone
        Dim test = t.Clone
        Dim s As DataRow() = t.Select.Clone
        Shuffle(s)
        For i = 0 To s.Length - 1
            If (i / s.Length) <= trainRatio Then
                train.Rows.Add(s(i).ItemArray)
            Else
                test.Rows.Add(s(i).ItemArray)
            End If
        Next
        Return (train, test)
    End Function

    Private rng As New Random()

    Public Sub Shuffle(Of T)(items As T())
        Dim temp As T
        Dim j As Int32

        For i As Int32 = items.Count - 1 To 0 Step -1
            ' Pick an item for position i.
            j = rng.Next(i + 1)
            ' Swap 
            temp = items(i)
            items(i) = items(j)
            items(j) = temp
        Next i
    End Sub

End Class
Public Class PostProcessor

    Public Shared Function getPercentageMinimized(ByVal minimized As DataTable, ByVal table As DataTable) As Double
        Return ((minimized.Columns.Count / table.Columns.Count) * 100)
    End Function

    Public Shared Function getRules(ByVal minimized As DataTable) As HashSet(Of Dictionary(Of Integer, String))
        Dim RULES1 = New HashSet(Of Dictionary(Of Integer, String))
        Dim di = New HashSet(Of String)
        For Each row As DataRow In minimized.Rows
            di.Add(row((minimized.Columns.Count - 1)).ToString)
        Next
        Dim diIndex = New List(Of List(Of Integer))
        For Each ele As String In di
            Dim ind = New List(Of Integer)
            For Each row As DataRow In minimized.Rows
                If row((minimized.Columns.Count - 1)).ToString.Equals(ele) Then
                    ind.Add(CType(row(0), Integer))
                End If

            Next
            diIndex.Add(ind)
        Next
        For Each list As List(Of Integer) In diIndex
            Dim rul = New HashSet(Of List(Of String))
            For Each i As Integer In list
                Dim rulList = New List(Of String)
                Dim col As Integer = 1
                Do While (col _
                            < (minimized.Columns.Count - 1))
                    rulList.Add(minimized.Rows((i - 1))(col).ToString)
                    col = (col + 1)
                Loop

                If isUnique(rul, rulList) Then
                    rul.Add(rulList)
                End If

            Next
            For Each dList As List(Of String) In rul
                Dim teDrul = New Dictionary(Of Integer, String)
                Dim colI As Integer = 0
                For Each ele As String In dList
                    teDrul.Add(colI, ele)
                    colI = (colI + 1)
                Next
                RULES1.Add(teDrul)
            Next
        Next
        Return RULES1
    End Function

    Public Shared Function isUnique(ByVal set1 As HashSet(Of List(Of String)), ByVal list As List(Of String)) As Boolean
        For Each ls As List(Of String) In set1
            For Each ele As String In ls
                If list.Contains(ele) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function
End Class
