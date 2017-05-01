Public Class FunctionsForm

    Private RULES As New List(Of String)
    Private Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Function minimize(ByVal tbl As DataTable, ByVal excel As Boolean) As DataTable
        Dim min As New DataTable()
        If excel Then tbl.AddIDColumn
        Dim distincts As New List(Of HashSet(Of String))
        Dim IND As New List(Of HashSet(Of HashSet(Of Integer)))

        For i = 1 To tbl.Columns.Count
            Dim distinct As New HashSet(Of String)
            Dim INDi = tbl.AsEnumerable.Select(Function(x) x(i).ToString).ToList.Indiscernable(distinct)
            distincts.Add(distinct)
            IND.Add(INDi)
        Next

        Dim INDD = IND.Last
        Dim Ks As New Dictionary(Of Integer, Double)
        For i = 0 To IND.Count
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
                                        For i = 0 To orderedK.Count
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
                .Select(Function(x) tbl.Columns(x).ColumnName).ToArray()), tbl)))
    End Function
End Class