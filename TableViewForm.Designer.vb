<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TableViewForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dGView = New System.Windows.Forms.DataGridView()
        CType(Me.dGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dGView
        '
        Me.dGView.AllowUserToAddRows = False
        Me.dGView.AllowUserToDeleteRows = False
        Me.dGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGView.Location = New System.Drawing.Point(0, 0)
        Me.dGView.Name = "dGView"
        Me.dGView.ReadOnly = True
        Me.dGView.Size = New System.Drawing.Size(784, 501)
        Me.dGView.TabIndex = 0
        '
        'TableViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 501)
        Me.Controls.Add(Me.dGView)
        Me.Name = "TableViewForm"
        Me.Text = "TableViewForm"
        CType(Me.dGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents dGView As DataGridView
End Class
