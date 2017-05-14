<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm2
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
        Me.odb_btn = New System.Windows.Forms.Button()
        Me.func_panel = New System.Windows.Forms.Panel()
        Me.cont_btn = New System.Windows.Forms.Button()
        Me.exit_btn = New System.Windows.Forms.Button()
        Me.db_container = New System.Windows.Forms.SplitContainer()
        Me.chng_db = New System.Windows.Forms.Button()
        Me.train_view = New System.Windows.Forms.DataGridView()
        Me.train_label = New System.Windows.Forms.Label()
        Me.chng_db2 = New System.Windows.Forms.Button()
        Me.test_view = New System.Windows.Forms.DataGridView()
        Me.test_label = New System.Windows.Forms.Label()
        Me.func_panel.SuspendLayout()
        CType(Me.db_container, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.db_container.Panel1.SuspendLayout()
        Me.db_container.Panel2.SuspendLayout()
        Me.db_container.SuspendLayout()
        CType(Me.train_view, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.test_view, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'odb_btn
        '
        Me.odb_btn.Font = New System.Drawing.Font("Segoe UI", 32.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.odb_btn.Location = New System.Drawing.Point(192, 304)
        Me.odb_btn.Name = "odb_btn"
        Me.odb_btn.Size = New System.Drawing.Size(640, 96)
        Me.odb_btn.TabIndex = 0
        Me.odb_btn.Text = "SELECT DATABASE"
        Me.odb_btn.UseVisualStyleBackColor = True
        '
        'func_panel
        '
        Me.func_panel.Controls.Add(Me.cont_btn)
        Me.func_panel.Controls.Add(Me.exit_btn)
        Me.func_panel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.func_panel.Location = New System.Drawing.Point(0, 665)
        Me.func_panel.Name = "func_panel"
        Me.func_panel.Size = New System.Drawing.Size(1008, 64)
        Me.func_panel.TabIndex = 1
        '
        'cont_btn
        '
        Me.cont_btn.Location = New System.Drawing.Point(824, 15)
        Me.cont_btn.Name = "cont_btn"
        Me.cont_btn.Size = New System.Drawing.Size(172, 37)
        Me.cont_btn.TabIndex = 1
        Me.cont_btn.Text = "CONTINUE"
        Me.cont_btn.UseVisualStyleBackColor = True
        '
        'exit_btn
        '
        Me.exit_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.exit_btn.Location = New System.Drawing.Point(12, 15)
        Me.exit_btn.Name = "exit_btn"
        Me.exit_btn.Size = New System.Drawing.Size(172, 37)
        Me.exit_btn.TabIndex = 99
        Me.exit_btn.TabStop = False
        Me.exit_btn.Text = "EXIT"
        Me.exit_btn.UseVisualStyleBackColor = True
        '
        'db_container
        '
        Me.db_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.db_container.Location = New System.Drawing.Point(0, 0)
        Me.db_container.Name = "db_container"
        Me.db_container.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'db_container.Panel1
        '
        Me.db_container.Panel1.Controls.Add(Me.chng_db)
        Me.db_container.Panel1.Controls.Add(Me.train_view)
        Me.db_container.Panel1.Controls.Add(Me.train_label)
        '
        'db_container.Panel2
        '
        Me.db_container.Panel2.Controls.Add(Me.chng_db2)
        Me.db_container.Panel2.Controls.Add(Me.test_view)
        Me.db_container.Panel2.Controls.Add(Me.test_label)
        Me.db_container.Size = New System.Drawing.Size(1008, 665)
        Me.db_container.SplitterDistance = 335
        Me.db_container.SplitterWidth = 2
        Me.db_container.TabIndex = 2
        '
        'chng_db
        '
        Me.chng_db.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chng_db.Location = New System.Drawing.Point(880, 0)
        Me.chng_db.Name = "chng_db"
        Me.chng_db.Size = New System.Drawing.Size(128, 32)
        Me.chng_db.TabIndex = 3
        Me.chng_db.Text = "CHANGE"
        Me.chng_db.UseVisualStyleBackColor = True
        Me.chng_db.Visible = False
        '
        'train_view
        '
        Me.train_view.AllowUserToAddRows = False
        Me.train_view.AllowUserToDeleteRows = False
        Me.train_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.train_view.Dock = System.Windows.Forms.DockStyle.Fill
        Me.train_view.Location = New System.Drawing.Point(0, 32)
        Me.train_view.Name = "train_view"
        Me.train_view.ReadOnly = True
        Me.train_view.Size = New System.Drawing.Size(1008, 303)
        Me.train_view.TabIndex = 1
        '
        'train_label
        '
        Me.train_label.Dock = System.Windows.Forms.DockStyle.Top
        Me.train_label.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.train_label.Location = New System.Drawing.Point(0, 0)
        Me.train_label.Name = "train_label"
        Me.train_label.Padding = New System.Windows.Forms.Padding(100, 0, 0, 0)
        Me.train_label.Size = New System.Drawing.Size(1008, 32)
        Me.train_label.TabIndex = 0
        Me.train_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chng_db2
        '
        Me.chng_db2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chng_db2.Location = New System.Drawing.Point(0, -1)
        Me.chng_db2.Name = "chng_db2"
        Me.chng_db2.Size = New System.Drawing.Size(128, 32)
        Me.chng_db2.TabIndex = 4
        Me.chng_db2.Text = "CHANGE"
        Me.chng_db2.UseVisualStyleBackColor = True
        Me.chng_db2.Visible = False
        '
        'test_view
        '
        Me.test_view.AllowUserToAddRows = False
        Me.test_view.AllowUserToDeleteRows = False
        Me.test_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.test_view.Dock = System.Windows.Forms.DockStyle.Fill
        Me.test_view.Location = New System.Drawing.Point(0, 32)
        Me.test_view.Name = "test_view"
        Me.test_view.ReadOnly = True
        Me.test_view.Size = New System.Drawing.Size(1008, 296)
        Me.test_view.TabIndex = 2
        '
        'test_label
        '
        Me.test_label.Dock = System.Windows.Forms.DockStyle.Top
        Me.test_label.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.test_label.Location = New System.Drawing.Point(0, 0)
        Me.test_label.Name = "test_label"
        Me.test_label.Padding = New System.Windows.Forms.Padding(0, 0, 100, 0)
        Me.test_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.test_label.Size = New System.Drawing.Size(1008, 32)
        Me.test_label.TabIndex = 1
        Me.test_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MainForm2
        '
        Me.AcceptButton = Me.cont_btn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.exit_btn
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.odb_btn)
        Me.Controls.Add(Me.db_container)
        Me.Controls.Add(Me.func_panel)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "MainForm2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Minimization using SIDE Algorithm"
        Me.func_panel.ResumeLayout(False)
        Me.db_container.Panel1.ResumeLayout(False)
        Me.db_container.Panel2.ResumeLayout(False)
        CType(Me.db_container, System.ComponentModel.ISupportInitialize).EndInit()
        Me.db_container.ResumeLayout(False)
        CType(Me.train_view, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.test_view, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents odb_btn As Button
    Friend WithEvents func_panel As Panel
    Friend WithEvents db_container As SplitContainer
    Friend WithEvents train_label As Label
    Friend WithEvents test_label As Label
    Friend WithEvents chng_db As Button
    Friend WithEvents train_view As DataGridView
    Friend WithEvents test_view As DataGridView
    Friend WithEvents chng_db2 As Button
    Friend WithEvents exit_btn As Button
    Friend WithEvents cont_btn As Button
End Class
