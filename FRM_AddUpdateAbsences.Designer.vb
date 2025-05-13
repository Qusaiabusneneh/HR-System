<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_AddUpdateAbsences
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
        Me.cmbAbsenceType = New System.Windows.Forms.ComboBox()
        Me.cmbDuration = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.dateTimePickerAbsenceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grbBasicInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbBasicInfo
        '
        Me.grbBasicInfo.Controls.Add(Me.cmbAbsenceType)
        Me.grbBasicInfo.Controls.Add(Me.cmbDuration)
        Me.grbBasicInfo.Controls.Add(Me.Label3)
        Me.grbBasicInfo.Controls.Add(Me.btnSave)
        Me.grbBasicInfo.Controls.Add(Me.RichTextBox1)
        Me.grbBasicInfo.Controls.Add(Me.dateTimePickerAbsenceDate)
        Me.grbBasicInfo.Controls.Add(Me.Label4)
        Me.grbBasicInfo.Controls.Add(Me.Label2)
        Me.grbBasicInfo.Controls.Add(Me.Label1)
        Me.grbBasicInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbBasicInfo.ForeColor = System.Drawing.Color.Navy
        Me.grbBasicInfo.Location = New System.Drawing.Point(0, 0)
        Me.grbBasicInfo.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.Name = "grbBasicInfo"
        Me.grbBasicInfo.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grbBasicInfo.Size = New System.Drawing.Size(380, 536)
        Me.grbBasicInfo.TabIndex = 1
        Me.grbBasicInfo.TabStop = False
        Me.grbBasicInfo.Text = "معلومات الغياب"
        '
        'cmbAbsenceType
        '
        Me.cmbAbsenceType.FormattingEnabled = True
        Me.cmbAbsenceType.Items.AddRange(New Object() {"إجازة مرضية", "إجازة شخصية", "إجازة سنوية", "إجازة غير مدفوعة", "إجازة مدفوعة", "إجازة طارئة", "إجازة أمومة", "إجازة أبوة", "إجازة وفاة", "تأخر في الحضور", "مغادرة مبكرة", "دورة تدريبية / ورشة عمل", "إجازة إدارية", "إجازة حجر صحي"})
        Me.cmbAbsenceType.Location = New System.Drawing.Point(30, 249)
        Me.cmbAbsenceType.Name = "cmbAbsenceType"
        Me.cmbAbsenceType.Size = New System.Drawing.Size(309, 38)
        Me.cmbAbsenceType.TabIndex = 18
        '
        'cmbDuration
        '
        Me.cmbDuration.FormattingEnabled = True
        Me.cmbDuration.Items.AddRange(New Object() {"يوم كامل", "نصف يوم", "ساعتين"})
        Me.cmbDuration.Location = New System.Drawing.Point(30, 159)
        Me.cmbDuration.Name = "cmbDuration"
        Me.cmbDuration.Size = New System.Drawing.Size(310, 38)
        Me.cmbDuration.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(287, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 30)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "المدة:"
        '
        'btnSave
        '
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.diskette
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(28, 450)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(312, 49)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "حفظ"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(30, 337)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(312, 96)
        Me.RichTextBox1.TabIndex = 4
        Me.RichTextBox1.Text = ""
        '
        'dateTimePickerAbsenceDate
        '
        Me.dateTimePickerAbsenceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimePickerAbsenceDate.Location = New System.Drawing.Point(30, 73)
        Me.dateTimePickerAbsenceDate.Name = "dateTimePickerAbsenceDate"
        Me.dateTimePickerAbsenceDate.Size = New System.Drawing.Size(314, 37)
        Me.dateTimePickerAbsenceDate.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(282, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 30)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "التاريخ:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(253, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "الملاحظات:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(254, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "نوع الغياب:"
        '
        'FRM_AddUpdateAbsences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 536)
        Me.Controls.Add(Me.grbBasicInfo)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_AddUpdateAbsences"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أضافة / تعديل كتاب شكر   "
        Me.grbBasicInfo.ResumeLayout(False)
        Me.grbBasicInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbBasicInfo As GroupBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents dateTimePickerAbsenceDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbAbsenceType As ComboBox
    Friend WithEvents cmbDuration As ComboBox
    Friend WithEvents Label3 As Label
End Class
