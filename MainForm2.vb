Public Class MainForm2
    Private fForm As FunctionsForm
    Private Sub odb_btn_Click(sender As Object, e As EventArgs) Handles odb_btn.Click, chng_db.Click, chng_db2.Click
        Dim mf As New MainForm
        If mf.ShowDialog = DialogResult.OK Then
            fForm = mf.fForm
            chng_db.Visible = True
            chng_db2.Visible = True
            odb_btn.Visible = False
            train_label.Text = "TRAIN SET"
            test_label.Text = "TEST SET"
            train_view.DataSource = fForm.tables.train
            test_view.DataSource = fForm.tables.test
            train_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            test_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
    End Sub

    Private Sub cont_btn_Click(sender As Object, e As EventArgs) Handles cont_btn.Click
        Me.Hide()
        fForm.mf = Me
        fForm.Show()
    End Sub

    Private Sub exit_btn_Click(sender As Object, e As EventArgs) Handles exit_btn.Click
        Me.Close()
    End Sub
End Class