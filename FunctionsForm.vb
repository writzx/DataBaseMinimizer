Public Class FunctionsForm

    Public tables As (train As DataTable, test As DataTable)

    Private RULES As New List(Of Dictionary(Of String, String))

    Private mintable As DataTable

    Private Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Function minimize(ByVal tbl As DataTable) As DataTable
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

        csets.ForEach(Sub(y) RULES.AddRange(PostProcessor.getRules(tbl.DefaultView.ToTable(tbl.TableName, False, y.indices.Select(Function(x) x + 1) _
                .Concat(New Integer() {0, tbl.Columns.Count - 1}).OrderBy(Function(x) x) _
                .Select(Function(x) tbl.Columns(x).ColumnName).ToArray()))))

        Return min
    End Function

    Private Sub FunctionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mintable = minimize(tables.train)
    End Sub

    Private Sub min_btn_Click(sender As Object, e As EventArgs) Handles min_btn.Click
        Dim t = New TableViewForm
        t.table = mintable
        t.Show()
    End Sub

    Private Sub genrules_btn_Click(sender As Object, e As EventArgs) Handles genrules_btn.Click
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
End Class