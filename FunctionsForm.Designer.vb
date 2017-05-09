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
        Me.min_btn = New System.Windows.Forms.Button()
        Me.showrules_btn = New System.Windows.Forms.Button()
        Me.calcdep_btn = New System.Windows.Forms.Button()
        Me.test_btn = New System.Windows.Forms.Button()
        Me.back_btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'min_btn
        '
        Me.min_btn.Location = New System.Drawing.Point(12, 12)
        Me.min_btn.Name = "min_btn"
        Me.min_btn.Size = New System.Drawing.Size(207, 32)
        Me.min_btn.TabIndex = 0
        Me.min_btn.Text = "Minimize Database"
        Me.min_btn.UseVisualStyleBackColor = True
        '
        'showrules_btn
        '
        Me.showrules_btn.Location = New System.Drawing.Point(12, 50)
        Me.showrules_btn.Name = "showrules_btn"
        Me.showrules_btn.Size = New System.Drawing.Size(207, 32)
        Me.showrules_btn.TabIndex = 1
        Me.showrules_btn.Text = "Show Rules"
        Me.showrules_btn.UseVisualStyleBackColor = True
        '
        'calcdep_btn
        '
        Me.calcdep_btn.Location = New System.Drawing.Point(12, 88)
        Me.calcdep_btn.Name = "calcdep_btn"
        Me.calcdep_btn.Size = New System.Drawing.Size(207, 32)
        Me.calcdep_btn.TabIndex = 2
        Me.calcdep_btn.Text = "Dependencies (Chart)"
        Me.calcdep_btn.UseVisualStyleBackColor = True
        '
        'test_btn
        '
        Me.test_btn.Location = New System.Drawing.Point(12, 126)
        Me.test_btn.Name = "test_btn"
        Me.test_btn.Size = New System.Drawing.Size(207, 32)
        Me.test_btn.TabIndex = 3
        Me.test_btn.Text = "Test (using test set)"
        Me.test_btn.UseVisualStyleBackColor = True
        '
        'back_btn
        '
        Me.back_btn.Location = New System.Drawing.Point(12, 164)
        Me.back_btn.Name = "back_btn"
        Me.back_btn.Size = New System.Drawing.Size(207, 32)
        Me.back_btn.TabIndex = 4
        Me.back_btn.Text = "Back"
        Me.back_btn.UseVisualStyleBackColor = True
        '
        'FunctionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(231, 208)
        Me.Controls.Add(Me.back_btn)
        Me.Controls.Add(Me.test_btn)
        Me.Controls.Add(Me.calcdep_btn)
        Me.Controls.Add(Me.showrules_btn)
        Me.Controls.Add(Me.min_btn)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(100, 100)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FunctionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FunctionsForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents min_btn As Button
    Friend WithEvents showrules_btn As Button
    Friend WithEvents calcdep_btn As Button
    Friend WithEvents test_btn As Button
    Friend WithEvents back_btn As Button
End Class
