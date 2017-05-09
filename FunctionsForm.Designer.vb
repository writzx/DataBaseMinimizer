<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FunctionsForm
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
        Me.tabs_funcs = New System.Windows.Forms.TabControl()
        Me.mindb_tab = New System.Windows.Forms.TabPage()
        Me.dGView = New System.Windows.Forms.DataGridView()
        Me.rules_tab = New System.Windows.Forms.TabPage()
        Me.rlist = New System.Windows.Forms.ListView()
        Me.colid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rulcol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.depchart_tab = New System.Windows.Forms.TabPage()
        Me.testacc_chart = New System.Windows.Forms.TabPage()
        Me.tabs_funcs.SuspendLayout()
        Me.mindb_tab.SuspendLayout()
        CType(Me.dGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rules_tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabs_funcs
        '
        Me.tabs_funcs.Controls.Add(Me.mindb_tab)
        Me.tabs_funcs.Controls.Add(Me.rules_tab)
        Me.tabs_funcs.Controls.Add(Me.depchart_tab)
        Me.tabs_funcs.Controls.Add(Me.testacc_chart)
        Me.tabs_funcs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs_funcs.Location = New System.Drawing.Point(0, 0)
        Me.tabs_funcs.Name = "tabs_funcs"
        Me.tabs_funcs.SelectedIndex = 0
        Me.tabs_funcs.Size = New System.Drawing.Size(1174, 814)
        Me.tabs_funcs.TabIndex = 5
        '
        'mindb_tab
        '
        Me.mindb_tab.Controls.Add(Me.dGView)
        Me.mindb_tab.Location = New System.Drawing.Point(4, 30)
        Me.mindb_tab.Name = "mindb_tab"
        Me.mindb_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.mindb_tab.Size = New System.Drawing.Size(1166, 780)
        Me.mindb_tab.TabIndex = 0
        Me.mindb_tab.Text = "Miniminzed Database"
        Me.mindb_tab.UseVisualStyleBackColor = True
        '
        'dGView
        '
        Me.dGView.AllowUserToAddRows = False
        Me.dGView.AllowUserToDeleteRows = False
        Me.dGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGView.Location = New System.Drawing.Point(3, 3)
        Me.dGView.Name = "dGView"
        Me.dGView.ReadOnly = True
        Me.dGView.Size = New System.Drawing.Size(1160, 774)
        Me.dGView.TabIndex = 5
        '
        'rules_tab
        '
        Me.rules_tab.Controls.Add(Me.rlist)
        Me.rules_tab.Location = New System.Drawing.Point(4, 30)
        Me.rules_tab.Name = "rules_tab"
        Me.rules_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.rules_tab.Size = New System.Drawing.Size(498, 420)
        Me.rules_tab.TabIndex = 1
        Me.rules_tab.Text = "Rules"
        Me.rules_tab.UseVisualStyleBackColor = True
        '
        'rlist
        '
        Me.rlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colid, Me.rulcol})
        Me.rlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rlist.GridLines = True
        Me.rlist.Location = New System.Drawing.Point(3, 3)
        Me.rlist.Name = "rlist"
        Me.rlist.Size = New System.Drawing.Size(492, 414)
        Me.rlist.TabIndex = 1
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
        'depchart_tab
        '
        Me.depchart_tab.Location = New System.Drawing.Point(4, 30)
        Me.depchart_tab.Name = "depchart_tab"
        Me.depchart_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.depchart_tab.Size = New System.Drawing.Size(498, 420)
        Me.depchart_tab.TabIndex = 2
        Me.depchart_tab.Text = "Dependency Chart"
        Me.depchart_tab.UseVisualStyleBackColor = True
        '
        'testacc_chart
        '
        Me.testacc_chart.Location = New System.Drawing.Point(4, 30)
        Me.testacc_chart.Name = "testacc_chart"
        Me.testacc_chart.Padding = New System.Windows.Forms.Padding(3)
        Me.testacc_chart.Size = New System.Drawing.Size(498, 420)
        Me.testacc_chart.TabIndex = 3
        Me.testacc_chart.Text = "Test and Accuracy"
        Me.testacc_chart.UseVisualStyleBackColor = True
        '
        'FunctionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 814)
        Me.Controls.Add(Me.tabs_funcs)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(100, 100)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FunctionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FunctionsForm"
        Me.tabs_funcs.ResumeLayout(False)
        Me.mindb_tab.ResumeLayout(False)
        CType(Me.dGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rules_tab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabs_funcs As TabControl
    Friend WithEvents mindb_tab As TabPage
    Friend WithEvents rules_tab As TabPage
    Friend WithEvents depchart_tab As TabPage
    Friend WithEvents testacc_chart As TabPage
    Public WithEvents dGView As DataGridView
    Friend WithEvents rlist As ListView
    Friend WithEvents colid As ColumnHeader
    Friend WithEvents rulcol As ColumnHeader
End Class
