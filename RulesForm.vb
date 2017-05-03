Public Class RulesForm
    Public RULES As List(Of Dictionary(Of String, String))
    Private Sub RulesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not RULES Is Nothing Then
            Dim i = 1
            For Each r In RULES
                Dim s = New ListViewItem(New String() {i, ConvertRule(r)})
                rlist.Items.Add(s)
                i = i + 1
            Next
        End If
    End Sub

    Public Function ConvertRule(rule As Dictionary(Of String, String)) As String
        Dim s = ""
        For Each x In rule
            If (x.Key = rule.Last.Key) Then
                s = s & "=> D=" & x.Value
            Else
                s = s & " & " & x.Key & "=" & x.Value
            End If
        Next
        Return s.Substring(3)
    End Function
End Class