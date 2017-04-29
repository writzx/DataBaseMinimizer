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
        If GetListSubItemFromPoint(DirectCast(sender, ListView), e.X, e.Y, row, col) Then
            If col = 1 Then
                Dim si = DirectCast(sender, ListView).Items(row).SubItems(col)
                If String.IsNullOrWhiteSpace(si.Text) Then
                    si.Text = "Train"
                ElseIf si.Text = "Train" Then
                    si.Text = "Test"
                ElseIf si.Text = "Test" Then
                    si.Text = " "
                End If
            End If
        End If
    End Sub

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
        ' minimize code
    End Sub
End Class
