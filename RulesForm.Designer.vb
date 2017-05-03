<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RulesForm
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
        Me.rlist = New System.Windows.Forms.ListView()
        Me.colid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rulcol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'rlist
        '
        Me.rlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colid, Me.rulcol})
        Me.rlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rlist.GridLines = True
        Me.rlist.Location = New System.Drawing.Point(0, 0)
        Me.rlist.Name = "rlist"
        Me.rlist.Size = New System.Drawing.Size(845, 526)
        Me.rlist.TabIndex = 0
        Me.rlist.UseCompatibleStateImageBehavior = False
        Me.rlist.View = System.Windows.Forms.View.Details
        '
        'colid
        '
        Me.colid.Text = "ID"
        Me.colid.Width = 32
        '
        'rulcol
        '
        Me.rulcol.Text = "RULES"
        Me.rulcol.Width = 1890
        '
        'RulesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 526)
        Me.Controls.Add(Me.rlist)
        Me.Name = "RulesForm"
        Me.Text = "RulesForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rlist As ListView
    Friend WithEvents colid As ColumnHeader
    Friend WithEvents rulcol As ColumnHeader
End Class
