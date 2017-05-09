Public Class FunctionsForm

    Public tables As (train As DataTable, test As DataTable)

    Public RULES As New List(Of Dictionary(Of String, String))

    Private mintable As DataTable

    Private Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Function minimize(ByVal tbl As DataTable, max As Integer) As DataTable
        Dim min As New DataTable()
        Dim distincts As New List(Of HashSet(Of String))
        Dim IND As New List(Of HashSet(Of HashSet(Of Integer)))

        For i = 1 To tbl.Columns.Count - 1
            Dim distinct As New HashSet(Of String)
            Dim INDi = tbl.AsEnumerable.Select(Function(x) x(i).ToString).ToList.Indiscernable(distinct)
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
                                        If combined.K = 1 Then
                                            csets.Add(combined)
                                        End If
                                    End Sub)
        'Dim p = csets.Select(Function(y) y.indices.Select(Function(z) >= z + 1).GetRules(table))
        'Dim v = p.columnDependencies()

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

    Private Sub FunctionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim p As Integer
        While (Not (Integer.TryParse(InputBox("Enter the number of rules to generate: (1-500): ", "Number of Rules", "100"), p) AndAlso
                    (p > 1) AndAlso (p < 500)))
            If MsgBox("Enter a valid value for number of rules! Value should be between 1 and 500", MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, "Invalid number of rules.") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End While
        mintable = minimize(tables.train, p)
    End Sub

    Private Sub min_btn_Click(sender As Object, e As EventArgs) Handles min_btn.Click
        Dim t = New TableViewForm
        t.table = mintable
        t.Show()
    End Sub

    Private Sub genrules_btn_Click(sender As Object, e As EventArgs) Handles showrules_btn.Click
        Dim rf = New RulesForm
        rf.RULES = RULES
        rf.Show()
    End Sub

    Public Function columnDependencies(rules As IEnumerable(Of Dictionary(Of String, String))) As Dictionary(Of String, Double)
        Dim total = rules.Sum(Function(x) x.Count())
        Return rules.SelectMany(Function(x) x.Select(Function(y) y.Key)).GroupBy(Function(i) i).OrderByDescending(Function(x) x.Count).ToDictionary(Function(x) x.Key, Function(x) x.Count / total)
    End Function

    Private Sub calcdep_btn_Click(sender As Object, e As EventArgs) Handles calcdep_btn.Click
        Dim cf = New ChartForm
        cf.dependencies = columnDependencies(RULES)
        cf.Show()
    End Sub
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
            Dim acc As Integer = 0, total As Integer = 0
            Dim diseaseName As String = dict.Values.Last
            For Each di As KeyValuePair(Of String, List(Of Integer)) In diIndex
                If di.Key.Equals(diseaseName) Then
                    Dim rowIndex = di.Value
                    For Each row As Integer In rowIndex
                        total = total + 1
                        For Each colName As String In dict.Values
                            For Each col As DataColumn In Test.Columns
                                If col.ColumnName.Equals(col) Then
                                    If Test.Rows(row)(col).ToString().Equals(dict(colName)) Then
                                        acc = acc + 1
                                    End If
                                End If
                            Next
                        Next
                    Next
                End If
            Next
            Dim percentageAccuracy As Double = (acc \ total) * 100
            accuracy.Add(percentageAccuracy)
        Next
        Return accuracy
    End Function

    Private Sub test_btn_Click(sender As Object, e As EventArgs) Handles test_btn.Click
        Dim accuracy = getAccuracy(RULES, tables.test)
    End Sub
End Class