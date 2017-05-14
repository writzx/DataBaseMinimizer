Public Class FunctionsForm

    Public rules_count As Integer

    Public tables As (train As DataTable, test As DataTable)

    Public RULES As New List(Of Dictionary(Of String, String))

    Private mintable As DataTable

    Public dependencies As Dictionary(Of String, Double)

    Public accuracy As List(Of Double)

    Public mf As MainForm2

    Private Sub back_btn_Click(sender As Object, e As EventArgs)
        Me.Hide()
        MainForm.Show()
    End Sub

    Public Function minimize(ByVal tbl As DataTable, max As Integer) As DataTable
        Dim min As New DataTable()
        Dim distincts As New List(Of HashSet(Of String))
        Dim IND As New List(Of HashSet(Of HashSet(Of Integer)))

        For i = 1 To tbl.Columns.Count - 1
            Dim distinct As New HashSet(Of String)
            Dim r = i
            Dim INDi = tbl.AsEnumerable.Select(Function(x) x(r).ToString).ToList.Indiscernable(distinct)
            distincts.Add(distinct)
            IND.Add(INDi)
        Next

        Dim INDD = IND.Last
        Dim Ks As New Dictionary(Of Integer, Double)
        For i = 0 To IND.Count - 1
            Dim k = 0.0D
            k = IND(i).DependencyOn(INDD)
            Ks.Add(i, k)
        Next

        Dim orderedKs As List(Of (index As Integer, K As Double, IND As HashSet(Of HashSet(Of Integer)))) = Ks _
            .OrderByDescending(Function(x) x.Value) _
            .Where(Function(x) x.Value > 0 AndAlso x.Value < 1) _
            .Select(Function(x) (x.Key, x.Value, IND(x.Key))).ToList

        Dim csets As New List(Of (K As Double, indices As List(Of Integer), IND As HashSet(Of HashSet(Of Integer))))
        orderedKs.PowerSets.ForEach(Sub(orderedK)
                                        Dim combined As (K As Double, indices As List(Of Integer), IND As HashSet(Of HashSet(Of Integer))) = (0.0D, New List(Of Integer), Nothing)
                                        For i = 0 To orderedK.Count - 1
                                            Dim thisK = orderedK(i)
                                            If combined.K = 1 Then
                                                If thisK.K = orderedK(i - 1).K Then
                                                    combined.indices.Add(thisK.index)
                                                    Continue For
                                                Else
                                                    Exit For
                                                End If
                                            End If
                                            If IsNothing(combined.IND) Then
                                                combined.IND = thisK.IND
                                            Else
                                                combined.IND.SymtricIntersectionWith(thisK.IND)
                                            End If
                                            combined.indices.Add(thisK.index)
                                            combined.K = combined.IND.DependencyOn(INDD)
                                        Next
                                        If combined.K >= 0.9 Then
                                            csets.Add(combined)
                                        End If
                                    End Sub)
        If (csets.Count = 0) Then
            Throw New ReductException()
        End If
        csets = csets.OrderByDescending(Function(x) x.indices.Count).ToList
        min = tbl.DefaultView.ToTable(tbl.TableName, False, csets.First().indices.Select(Function(x) x + 1) _
                .Concat(New Integer() {0, tbl.Columns.Count - 1}).OrderBy(Function(x) x) _
                .Select(Function(x) tbl.Columns(x).ColumnName).ToArray())

        csets.ForEach(Sub(y)
                          If RULES.Count < max Then
                              RULES.AddRange(PostProcessor.getRules(tbl.DefaultView.ToTable(tbl.TableName, False, y.indices.Select(Function(x) x + 1) _
                                                                                        .Concat(New Integer() {0, tbl.Columns.Count - 1}).OrderBy(Function(x) x) _
                                                                                        .Select(Function(x) tbl.Columns(x).ColumnName).ToArray())))
                          End If
                      End Sub)

        Return min
    End Function
    Private Class ReductException
        Inherits Exception
    End Class
    Private Sub FunctionsForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        tabs_funcs.Visible = False
        progress_panel.Visible = True
        worker.RunWorkerAsync()
    End Sub

    Private Sub SetVals()
        dGView.DataSource = mintable
        Dim erx As New List(Of ListViewItem)
        If Not RULES Is Nothing Then
            For i = 0 To RULES.Count - 1
                Dim s = New ListViewItem(New String() {i + 1, PostProcessor.ConvertRule(RULES(i)), FormatNumber(CDbl(accuracy(i) * 100), 2), FormatNumber(CDbl((RULES(i).Count - 1) * 100 / (tables.train.Columns.Count - 2)), 2)})
                erx.Add(s)
            Next
            erx = erx.OrderByDescending(Function(x) Val(x.SubItems(2).Text)).ToList
            Dim r = 1
            erx.ForEach(Sub(e)
                            e.SubItems(0).Text = r
                            r = r + 1
                        End Sub)
            rlist.Items.AddRange(erx.ToArray)
        End If
        Dim rr = 1D
        For Each s In dependencies
            If (s.Value > 0 AndAlso Not (s.Key = "-1")) Then
                Dim x = dep_chart.Series.Add(s.Key)
                x.Points.AddXY(rr, s.Value)
                rr = rr + 0.1
            End If
        Next
        progress_panel.Visible = False
        tabs_funcs.Visible = True
    End Sub

    Public Function columnDependencies(rules As IEnumerable(Of Dictionary(Of String, String))) As Dictionary(Of String, Double)
        Dim total = rules.Sum(Function(x) x.Count())
        Return rules.SelectMany(Function(x) x.Select(Function(y) y.Key)).GroupBy(Function(i) i).OrderByDescending(Function(x) x.Count).ToDictionary(Function(x) x.Key, Function(x) x.Count / total)
    End Function


    Public Shared Function getAccuracy(Rules As List(Of Dictionary(Of String, String)), Test As DataTable) As List(Of Double)
        Dim accuracy = New List(Of Double)()
        Dim diName = New HashSet(Of String)()
        For Each row As DataRow In Test.Rows
            diName.Add(row(Test.Columns.Count - 1).ToString())
        Next
        Dim diIndex = New Dictionary(Of String, List(Of Integer))()
        For Each ele As String In diName
            Dim tList = New List(Of Integer)()
            For Each row As DataRow In Test.Rows
                If row(Test.Columns.Count - 1).ToString().Equals(ele) Then
                    tList.Add(CInt(row(0)))
                End If
            Next
            diIndex.Add(ele, tList)
        Next
        For Each dict As Dictionary(Of String, String) In Rules
            Dim acc As Double = 0, total As Double = 0
            Dim diseaseName As String = dict.Values.Last()
            For Each di As KeyValuePair(Of String, List(Of Integer)) In diIndex
                Dim rowIndex = di.Value
                total = rowIndex.Count
                acc = 0
                If di.Key.Equals(diseaseName) Then
                    Dim isCorrect As New List(Of Boolean)()
                    For Each row As Integer In rowIndex
                        For Each colName As String In dict.Values
                            For Each col As DataColumn In Test.Columns
                                If col.ColumnName.Equals(colName) Then
                                    If Test.Rows(row)(col).ToString().Equals(dict(colName)) Then
                                        isCorrect.Add(True)
                                    End If
                                End If
                            Next
                        Next
                    Next
                    If isAccurate(isCorrect) Then
                        acc += 1
                    End If
                End If
                Try
                    Dim percentageAccuracy As Double = (acc / total)
                    accuracy.Add(percentageAccuracy)
                Catch e As Exception
                End Try
            Next
        Next
        Return accuracy
    End Function

    Private Shared Function isAccurate(list As List(Of Boolean)) As [Boolean]
        For Each ele As Boolean In list
            If Not ele Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub FunctionsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        mf.Show()
    End Sub

    Private Sub worker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles worker.DoWork
        worker.ReportProgress(0, "Minimizing Train Set...")
        Try
            mintable = minimize(tables.train, rules_count)
        Catch r As ReductException
            Throw r
        End Try
        worker.ReportProgress(40, "Calculating accuracy...")
        accuracy = getAccuracy(RULES, tables.test)
        worker.ReportProgress(80, "Calculating dependencies...")
        dependencies = columnDependencies(RULES)
        worker.ReportProgress(100, "Testing Complete...")
    End Sub

    Private Sub worker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles worker.RunWorkerCompleted
        If (TypeOf (e.Error) Is ReductException) Then
            MsgBox("None of the combined Reducts have complete dependency! Unable to minimize table.", vbCritical And vbOKOnly, "Invalid Table")
            Me.Hide()
            Exit Sub
        End If
        SetVals()
    End Sub

    Private Sub worker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles worker.ProgressChanged
        label_progress.Text = e.UserState
    End Sub
End Class