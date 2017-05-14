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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.tabs_funcs = New System.Windows.Forms.TabControl()
        Me.mindb_tab = New System.Windows.Forms.TabPage()
        Me.dGView = New System.Windows.Forms.DataGridView()
        Me.rules_tab = New System.Windows.Forms.TabPage()
        Me.rlist = New System.Windows.Forms.ListView()
        Me.colid = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rulcol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.acccol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mincol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.depchart_tab = New System.Windows.Forms.TabPage()
        Me.dep_chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.worker = New System.ComponentModel.BackgroundWorker()
        Me.resp_progress = New System.Windows.Forms.ProgressBar()
        Me.label_progress = New System.Windows.Forms.Label()
        Me.progress_panel = New System.Windows.Forms.Panel()
        Me.tabs_funcs.SuspendLayout()
        Me.mindb_tab.SuspendLayout()
        CType(Me.dGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rules_tab.SuspendLayout()
        Me.depchart_tab.SuspendLayout()
        CType(Me.dep_chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.progress_panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabs_funcs
        '
        Me.tabs_funcs.Controls.Add(Me.mindb_tab)
        Me.tabs_funcs.Controls.Add(Me.rules_tab)
        Me.tabs_funcs.Controls.Add(Me.depchart_tab)
        Me.tabs_funcs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs_funcs.Location = New System.Drawing.Point(0, 0)
        Me.tabs_funcs.Name = "tabs_funcs"
        Me.tabs_funcs.SelectedIndex = 0
        Me.tabs_funcs.Size = New System.Drawing.Size(1008, 729)
        Me.tabs_funcs.TabIndex = 5
        Me.tabs_funcs.Visible = False
        '
        'mindb_tab
        '
        Me.mindb_tab.Controls.Add(Me.dGView)
        Me.mindb_tab.Location = New System.Drawing.Point(4, 30)
        Me.mindb_tab.Name = "mindb_tab"
        Me.mindb_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.mindb_tab.Size = New System.Drawing.Size(1000, 695)
        Me.mindb_tab.TabIndex = 0
        Me.mindb_tab.Text = "Miniminzed Database"
        Me.mindb_tab.UseVisualStyleBackColor = True
        '
        'dGView
        '
        Me.dGView.AllowUserToAddRows = False
        Me.dGView.AllowUserToDeleteRows = False
        Me.dGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dGView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGView.Location = New System.Drawing.Point(3, 3)
        Me.dGView.Name = "dGView"
        Me.dGView.ReadOnly = True
        Me.dGView.Size = New System.Drawing.Size(994, 689)
        Me.dGView.TabIndex = 5
        '
        'rules_tab
        '
        Me.rules_tab.Controls.Add(Me.rlist)
        Me.rules_tab.Location = New System.Drawing.Point(4, 30)
        Me.rules_tab.Name = "rules_tab"
        Me.rules_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.rules_tab.Size = New System.Drawing.Size(1000, 695)
        Me.rules_tab.TabIndex = 1
        Me.rules_tab.Text = "Rules"
        Me.rules_tab.UseVisualStyleBackColor = True
        '
        'rlist
        '
        Me.rlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colid, Me.rulcol, Me.acccol, Me.mincol})
        Me.rlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rlist.FullRowSelect = True
        Me.rlist.GridLines = True
        Me.rlist.Location = New System.Drawing.Point(3, 3)
        Me.rlist.Name = "rlist"
        Me.rlist.Size = New System.Drawing.Size(994, 689)
        Me.rlist.TabIndex = 1
        Me.rlist.UseCompatibleStateImageBehavior = False
        Me.rlist.View = System.Windows.Forms.View.Details
        '
        'colid
        '
        Me.colid.Text = "ID"
        Me.colid.Width = 50
        '
        'rulcol
        '
        Me.rulcol.Text = "RULES"
        Me.rulcol.Width = 604
        '
        'acccol
        '
        Me.acccol.Text = "ACCURACY (TEST)"
        Me.acccol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.acccol.Width = 150
        '
        'mincol
        '
        Me.mincol.Text = "% MINIMIZATION"
        Me.mincol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.mincol.Width = 150
        '
        'depchart_tab
        '
        Me.depchart_tab.Controls.Add(Me.dep_chart)
        Me.depchart_tab.Location = New System.Drawing.Point(4, 30)
        Me.depchart_tab.Name = "depchart_tab"
        Me.depchart_tab.Padding = New System.Windows.Forms.Padding(3)
        Me.depchart_tab.Size = New System.Drawing.Size(1000, 695)
        Me.depchart_tab.TabIndex = 2
        Me.depchart_tab.Text = "Dependency Chart"
        Me.depchart_tab.UseVisualStyleBackColor = True
        '
        'dep_chart
        '
        ChartArea2.AxisX.LabelStyle.Enabled = False
        ChartArea2.Name = "ChartArea1"
        Me.dep_chart.ChartAreas.Add(ChartArea2)
        Me.dep_chart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.dep_chart.Legends.Add(Legend2)
        Me.dep_chart.Location = New System.Drawing.Point(3, 3)
        Me.dep_chart.Name = "dep_chart"
        Me.dep_chart.Size = New System.Drawing.Size(994, 689)
        Me.dep_chart.TabIndex = 0
        Me.dep_chart.Text = "Dependency Chart"
        '
        'worker
        '
        Me.worker.WorkerReportsProgress = True
        '
        'resp_progress
        '
        Me.resp_progress.Location = New System.Drawing.Point(5, 15)
        Me.resp_progress.Name = "resp_progress"
        Me.resp_progress.Size = New System.Drawing.Size(386, 23)
        Me.resp_progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.resp_progress.TabIndex = 7
        '
        'label_progress
        '
        Me.label_progress.Location = New System.Drawing.Point(5, 47)
        Me.label_progress.Name = "label_progress"
        Me.label_progress.Size = New System.Drawing.Size(386, 33)
        Me.label_progress.TabIndex = 8
        Me.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'progress_panel
        '
        Me.progress_panel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.progress_panel.Controls.Add(Me.label_progress)
        Me.progress_panel.Controls.Add(Me.resp_progress)
        Me.progress_panel.Location = New System.Drawing.Point(300, 300)
        Me.progress_panel.Name = "progress_panel"
        Me.progress_panel.Size = New System.Drawing.Size(396, 106)
        Me.progress_panel.TabIndex = 9
        '
        'FunctionsForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.progress_panel)
        Me.Controls.Add(Me.tabs_funcs)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FunctionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Results View"
        Me.tabs_funcs.ResumeLayout(False)
        Me.mindb_tab.ResumeLayout(False)
        CType(Me.dGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rules_tab.ResumeLayout(False)
        Me.depchart_tab.ResumeLayout(False)
        CType(Me.dep_chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.progress_panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabs_funcs As TabControl
    Friend WithEvents mindb_tab As TabPage
    Friend WithEvents rules_tab As TabPage
    Friend WithEvents depchart_tab As TabPage
    Public WithEvents dGView As DataGridView
    Friend WithEvents rlist As ListView
    Friend WithEvents colid As ColumnHeader
    Friend WithEvents rulcol As ColumnHeader
    Friend WithEvents dep_chart As DataVisualization.Charting.Chart
    Friend WithEvents acccol As ColumnHeader
    Friend WithEvents mincol As ColumnHeader
    Friend WithEvents worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents label_progress As Label
    Friend WithEvents resp_progress As ProgressBar
    Friend WithEvents progress_panel As Panel
End Class
