Public Module Extensions

    <Runtime.CompilerServices.Extension>
    Public Sub AddIDColumn(table As DataTable)
        Dim dc As New DataColumn("ID")
        dc.AutoIncrement = True
        dc.AutoIncrementSeed = 1
        dc.AutoIncrementStep = 1
        dc.DataType = GetType(Integer)
        table.Columns.Add(dc)
        table.Columns("ID").SetOrdinal(0)
        For i As Integer = 0 To table.Rows.Count - 1
            table.Rows(i)("ID") = i + 1
        Next
    End Sub

    <Runtime.CompilerServices.Extension>
    Public Sub SymtricIntersectionWith(set1 As HashSet(Of HashSet(Of Integer)), set2 As HashSet(Of HashSet(Of Integer)))
        Dim result = set1.ToList()
        set1.Clear()
        For Each s1 As HashSet(Of Integer) In result
            For Each s2 As HashSet(Of Integer) In set2
                Dim hs = New HashSet(Of Integer)(s1.Intersect(s2))
                If hs.Count > 0 Then
                    set1.Add(hs)
                End If
            Next
        Next
    End Sub

    <Runtime.CompilerServices.Extension>
    Public Function DependencyOn([set] As HashSet(Of HashSet(Of Integer)), otherSet As HashSet(Of HashSet(Of Integer))) As Double
        Dim d As Double = 0.0
        Dim total As Double = 0.0
        For Each cset As HashSet(Of Integer) In [set]
            total = 0.0
            For Each dset As HashSet(Of Integer) In otherSet
                If cset.IsSubsetOf(dset) Then
                    d += cset.Count
                End If
                total += dset.Count
            Next
        Next
        Return d / total
    End Function

    <Runtime.CompilerServices.Extension>
    Public Function Indiscernable([set] As List(Of String), Optional distinctElements As HashSet(Of String) = Nothing) As HashSet(Of HashSet(Of Integer))
        Dim result = New HashSet(Of HashSet(Of Integer))()
        If distinctElements IsNot Nothing Then
            distinctElements.Clear()
        Else
            distinctElements = New HashSet(Of String)()
        End If
        For i As Integer = 0 To [set].Count - 1
            Dim ele = [set](i)
            distinctElements.Add(ele)
            Dim index As Integer = distinctElements.ToList().IndexOf(ele)
            If result.Count <= index Then
                result.Add(New HashSet(Of Integer)())
            End If
            result.ElementAt(index).Add(i + 1)
        Next
        Return result
    End Function

    <Runtime.CompilerServices.Extension>
    Public Function PowerSets(Of T)(list As List(Of T)) As List(Of List(Of T))
        Return (From m In Enumerable.Range(0, 1 << list.Count)(From i In Enumerable.Range(0, list.Count) Where (m And (1 << i)) <> 0List(i)).ToList()).OrderByDescending(Function(x) x.Count).ToList()
	End Function
End Module
