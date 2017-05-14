
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.browse_btn = New System.Windows.Forms.Button()
        Me.table_view = New System.Windows.Forms.DataGridView()
        Me.dbOpener = New System.Windows.Forms.OpenFileDialog()
        Me.tname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ttype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.table_list = New System.Windows.Forms.ListView()
        Me.main_panel = New System.Windows.Forms.Panel()
        Me.cont_button = New System.Windows.Forms.Button()
        Me.cancel_btn = New System.Windows.Forms.Button()
        CType(Me.table_view, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.main_panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'browse_btn
        '
        Me.browse_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.browse_btn.Location = New System.Drawing.Point(12, 520)
        Me.browse_btn.Name = "browse_btn"
        Me.browse_btn.Size = New System.Drawing.Size(200, 29)
        Me.browse_btn.TabIndex = 1
        Me.browse_btn.Text = "Browse"
        Me.browse_btn.UseVisualStyleBackColor = True
        '
        'table_view
        '
        Me.table_view.AllowUserToAddRows = False
        Me.table_view.AllowUserToDeleteRows = False
        Me.table_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.table_view.Dock = System.Windows.Forms.DockStyle.Fill
        Me.table_view.Location = New System.Drawing.Point(200, 0)
        Me.table_view.Name = "table_view"
        Me.table_view.ReadOnly = True
        Me.table_view.Size = New System.Drawing.Size(560, 502)
        Me.table_view.TabIndex = 0
        '
        'dbOpener
        '
        Me.dbOpener.Filter = "Microsoft Access Databases (*.mdb;*.accdb) and Microsof Excel Workbooks (*.xlsx;*" &
    ".xls)|*.accdb;*.mdb;*.xlsx;*.xls"
        Me.dbOpener.Multiselect = True
        Me.dbOpener.SupportMultiDottedExtensions = True
        Me.dbOpener.Title = "Select Database(s)"
        '
        'tname
        '
        Me.tname.Text = "Table Name"
        Me.tname.Width = 110
        '
        'ttype
        '
        Me.ttype.Text = "Type"
        Me.ttype.Width = 83
        '
        'table_list
        '
        Me.table_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.tname, Me.ttype})
        Me.table_list.Dock = System.Windows.Forms.DockStyle.Left
        Me.table_list.FullRowSelect = True
        Me.table_list.GridLines = True
        Me.table_list.Location = New System.Drawing.Point(0, 0)
        Me.table_list.MultiSelect = False
        Me.table_list.Name = "table_list"
        Me.table_list.Size = New System.Drawing.Size(200, 502)
        Me.table_list.TabIndex = 0
        Me.table_list.UseCompatibleStateImageBehavior = False
        Me.table_list.View = System.Windows.Forms.View.Details
        '
        'main_panel
        '
        Me.main_panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.main_panel.Controls.Add(Me.table_view)
        Me.main_panel.Controls.Add(Me.table_list)
        Me.main_panel.Location = New System.Drawing.Point(12, 12)
        Me.main_panel.Name = "main_panel"
        Me.main_panel.Size = New System.Drawing.Size(760, 502)
        Me.main_panel.TabIndex = 3
        '
        'cont_button
        '
        Me.cont_button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cont_button.Location = New System.Drawing.Point(498, 520)
        Me.cont_button.Name = "cont_button"
        Me.cont_button.Size = New System.Drawing.Size(274, 29)
        Me.cont_button.TabIndex = 4
        Me.cont_button.Text = "Continue"
        Me.cont_button.UseVisualStyleBackColor = True
        '
        'cancel_btn
        '
        Me.cancel_btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel_btn.Location = New System.Drawing.Point(218, 520)
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.Size = New System.Drawing.Size(274, 29)
        Me.cancel_btn.TabIndex = 5
        Me.cancel_btn.Text = "Cancel"
        Me.cancel_btn.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AcceptButton = Me.cont_button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cancel_btn
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.cancel_btn)
        Me.Controls.Add(Me.cont_button)
        Me.Controls.Add(Me.main_panel)
        Me.Controls.Add(Me.browse_btn)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Open Database"
        CType(Me.table_view, System.ComponentModel.ISupportInitialize).EndInit()
        Me.main_panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents browse_btn As Button
    Friend WithEvents table_view As DataGridView
    Private WithEvents dbOpener As OpenFileDialog
    Friend WithEvents table_list As ListView
    Private WithEvents tname As ColumnHeader
    Private WithEvents ttype As ColumnHeader
    Friend WithEvents main_panel As Panel
    Friend WithEvents cont_button As Button
    Friend WithEvents cancel_btn As Button
End Class
