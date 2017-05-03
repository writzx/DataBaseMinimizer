Public Class TableViewForm
    Public table As DataTable

    Private Sub TableViewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not table Is Nothing Then
            dGView.DataSource = table
        End If
    End Sub
End Class