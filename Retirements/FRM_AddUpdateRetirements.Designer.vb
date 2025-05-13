<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_AddUpdateRetirements
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
        Me.grbBasicInfo = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.dateTimePickerRetirementDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbEmployees = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUsers = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grbBasicInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbBasicInfo
        '
        Me.grbBasicInfo.Controls.Add(Me.cmbUsers)
        Me.grbBasicInfo.Controls.Add(Me.Label2)
        Me.grbBasicInfo.Controls.Add(Me.Label1)
        Me.grbBasicInfo.Controls.Add(Me.cmbEmployees)
        Me.grbBasicInfo.Controls.Add(Me.btnSave)
        Me.grbBasicInfo.Controls.Add(Me.RichTextBox1)
        Me.grbBasicInfo.Controls.Add(Me.dateTimePickerRetirementDate)
        Me.grbBasicInfo.Controls.Add(Me.Label4)
        Me.grbBasicInfo.Controls.Add(Me.Label3)
        Me.grbBasicInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbBasicInfo.ForeColor = System.Drawing.Color.Navy
        Me.grbBasicInfo.Location = New System.Drawing.Point(0, 0)
        Me.grbBasicInfo.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.Name = "grbBasicInfo"
        Me.grbBasicInfo.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grbBasicInfo.Size = New System.Drawing.Size(380, 492)
        Me.grbBasicInfo.TabIndex = 1
        Me.grbBasicInfo.TabStop = False
        Me.grbBasicInfo.Text = "معلومات التقاعد:"
        '
        'btnSave
        '
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.diskette
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(51, 437)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(312, 49)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "حفظ"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(51, 333)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(312, 96)
        Me.RichTextBox1.TabIndex = 4
        Me.RichTextBox1.Text = ""
        '
        'dateTimePickerRetirementDate
        '
        Me.dateTimePickerRetirementDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimePickerRetirementDate.Location = New System.Drawing.Point(51, 164)
        Me.dateTimePickerRetirementDate.Name = "dateTimePickerRetirementDate"
        Me.dateTimePickerRetirementDate.Size = New System.Drawing.Size(310, 37)
        Me.dateTimePickerRetirementDate.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(256, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 30)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "اسم الموظف:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(261, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 30)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "تاريخ التقاعد:"
        '
        'cmbEmployees
        '
        Me.cmbEmployees.FormattingEnabled = True
        Me.cmbEmployees.Location = New System.Drawing.Point(51, 72)
        Me.cmbEmployees.Name = "cmbEmployees"
        Me.cmbEmployees.Size = New System.Drawing.Size(310, 38)
        Me.cmbEmployees.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(304, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 30)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "السبب:"
        '
        'cmbUsers
        '
        Me.cmbUsers.FormattingEnabled = True
        Me.cmbUsers.Location = New System.Drawing.Point(51, 248)
        Me.cmbUsers.Name = "cmbUsers"
        Me.cmbUsers.Size = New System.Drawing.Size(310, 38)
        Me.cmbUsers.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(242, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 30)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "اسم المستخدم:"
        '
        'FRM_AddUpdateRetirements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 492)
        Me.Controls.Add(Me.grbBasicInfo)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_AddUpdateRetirements"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أضافة / تعديل تقاعد  "
        Me.grbBasicInfo.ResumeLayout(False)
        Me.grbBasicInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbBasicInfo As GroupBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents dateTimePickerRetirementDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbEmployees As ComboBox
    Friend WithEvents cmbUsers As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
