<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_AddUpdateUsers
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
        Me.grbBasicInfo = New System.Windows.Forms.GroupBox()
        Me.cmbRoles = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grbAnotherInfo = New System.Windows.Forms.GroupBox()
        Me.cmbUserID = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkIsSecondryUser = New System.Windows.Forms.CheckBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grbPermission = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.chkEmployee = New System.Windows.Forms.CheckBox()
        Me.chkSalary = New System.Windows.Forms.CheckBox()
        Me.chkHelp = New System.Windows.Forms.CheckBox()
        Me.chkAbout = New System.Windows.Forms.CheckBox()
        Me.chkUser = New System.Windows.Forms.CheckBox()
        Me.chkSetting = New System.Windows.Forms.CheckBox()
        Me.chkReport = New System.Windows.Forms.CheckBox()
        Me.chkSearch = New System.Windows.Forms.CheckBox()
        Me.chkExport = New System.Windows.Forms.CheckBox()
        Me.chkUpdate = New System.Windows.Forms.CheckBox()
        Me.chkDelete = New System.Windows.Forms.CheckBox()
        Me.chkSearchInMain = New System.Windows.Forms.CheckBox()
        Me.chkMain = New System.Windows.Forms.CheckBox()
        Me.chkAdd = New System.Windows.Forms.CheckBox()
        Me.chkPrint = New System.Windows.Forms.CheckBox()
        Me.chkRecords = New System.Windows.Forms.CheckBox()
        Me.chkRetirment = New System.Windows.Forms.CheckBox()
        Me.grbBasicInfo.SuspendLayout()
        Me.grbAnotherInfo.SuspendLayout()
        Me.grbPermission.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbBasicInfo
        '
        Me.grbBasicInfo.Controls.Add(Me.cmbRoles)
        Me.grbBasicInfo.Controls.Add(Me.txtPassword)
        Me.grbBasicInfo.Controls.Add(Me.txtUsername)
        Me.grbBasicInfo.Controls.Add(Me.txtFullName)
        Me.grbBasicInfo.Controls.Add(Me.Label7)
        Me.grbBasicInfo.Controls.Add(Me.Label3)
        Me.grbBasicInfo.Controls.Add(Me.Label2)
        Me.grbBasicInfo.Controls.Add(Me.Label1)
        Me.grbBasicInfo.Location = New System.Drawing.Point(20, 8)
        Me.grbBasicInfo.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.Name = "grbBasicInfo"
        Me.grbBasicInfo.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grbBasicInfo.Size = New System.Drawing.Size(295, 412)
        Me.grbBasicInfo.TabIndex = 0
        Me.grbBasicInfo.TabStop = False
        Me.grbBasicInfo.Text = "معلومات الدخول"
        '
        'cmbRoles
        '
        Me.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoles.FormattingEnabled = True
        Me.cmbRoles.Items.AddRange(New Object() {"Admin", "User", "Read"})
        Me.cmbRoles.Location = New System.Drawing.Point(7, 301)
        Me.cmbRoles.Name = "cmbRoles"
        Me.cmbRoles.Size = New System.Drawing.Size(270, 38)
        Me.cmbRoles.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(7, 221)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(270, 37)
        Me.txtPassword.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(7, 146)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(270, 37)
        Me.txtUsername.TabIndex = 2
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(7, 70)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(270, 37)
        Me.txtFullName.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(145, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 30)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "الصلاحيات العامة:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(194, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 30)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "كلمة السر:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "اسم المستخدم:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(168, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "الاسم الكامل: "
        '
        'grbAnotherInfo
        '
        Me.grbAnotherInfo.Controls.Add(Me.cmbUserID)
        Me.grbAnotherInfo.Controls.Add(Me.btnSave)
        Me.grbAnotherInfo.Controls.Add(Me.chkIsSecondryUser)
        Me.grbAnotherInfo.Controls.Add(Me.txtAddress)
        Me.grbAnotherInfo.Controls.Add(Me.txtEmail)
        Me.grbAnotherInfo.Controls.Add(Me.txtPhone)
        Me.grbAnotherInfo.Controls.Add(Me.Label4)
        Me.grbAnotherInfo.Controls.Add(Me.Label5)
        Me.grbAnotherInfo.Controls.Add(Me.Label6)
        Me.grbAnotherInfo.Location = New System.Drawing.Point(354, 8)
        Me.grbAnotherInfo.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbAnotherInfo.Name = "grbAnotherInfo"
        Me.grbAnotherInfo.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbAnotherInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grbAnotherInfo.Size = New System.Drawing.Size(307, 412)
        Me.grbAnotherInfo.TabIndex = 0
        Me.grbAnotherInfo.TabStop = False
        Me.grbAnotherInfo.Text = "معلومات اخرى"
        '
        'cmbUserID
        '
        Me.cmbUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserID.FormattingEnabled = True
        Me.cmbUserID.Location = New System.Drawing.Point(11, 73)
        Me.cmbUserID.Name = "cmbUserID"
        Me.cmbUserID.Size = New System.Drawing.Size(270, 38)
        Me.cmbUserID.TabIndex = 6
        '
        'btnSave
        '
        Me.btnSave.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.diskette
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(20, 344)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(255, 56)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "حفظ"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkIsSecondryUser
        '
        Me.chkIsSecondryUser.AutoSize = True
        Me.chkIsSecondryUser.Location = New System.Drawing.Point(104, 33)
        Me.chkIsSecondryUser.Name = "chkIsSecondryUser"
        Me.chkIsSecondryUser.Size = New System.Drawing.Size(177, 34)
        Me.chkIsSecondryUser.TabIndex = 5
        Me.chkIsSecondryUser.Text = "هل المستخدم ثانوي"
        Me.chkIsSecondryUser.UseVisualStyleBackColor = True
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(20, 301)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(255, 37)
        Me.txtAddress.TabIndex = 9
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(20, 228)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(255, 37)
        Me.txtEmail.TabIndex = 8
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(20, 146)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(255, 37)
        Me.txtPhone.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(215, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 30)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "السكن:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(150, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "البريد الالكتروني:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(185, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 30)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "رقم الهاتف:"
        '
        'grbPermission
        '
        Me.grbPermission.Controls.Add(Me.FlowLayoutPanel1)
        Me.grbPermission.ForeColor = System.Drawing.Color.Red
        Me.grbPermission.Location = New System.Drawing.Point(13, 423)
        Me.grbPermission.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbPermission.Name = "grbPermission"
        Me.grbPermission.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbPermission.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grbPermission.Size = New System.Drawing.Size(648, 206)
        Me.grbPermission.TabIndex = 1
        Me.grbPermission.TabStop = False
        Me.grbPermission.Text = "الصلاحيات"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.chkEmployee)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkSalary)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkHelp)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkAbout)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkUser)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkSetting)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkReport)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkSearch)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkExport)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkUpdate)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkDelete)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkSearchInMain)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkMain)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkAdd)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkPrint)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkRecords)
        Me.FlowLayoutPanel1.Controls.Add(Me.chkRetirment)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 37)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(640, 162)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'chkEmployee
        '
        Me.chkEmployee.AutoSize = True
        Me.chkEmployee.Checked = True
        Me.chkEmployee.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEmployee.Location = New System.Drawing.Point(532, 3)
        Me.chkEmployee.Name = "chkEmployee"
        Me.chkEmployee.Size = New System.Drawing.Size(105, 34)
        Me.chkEmployee.TabIndex = 29
        Me.chkEmployee.Text = "الموظفين"
        Me.chkEmployee.UseVisualStyleBackColor = True
        '
        'chkSalary
        '
        Me.chkSalary.AutoSize = True
        Me.chkSalary.Checked = True
        Me.chkSalary.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSalary.Location = New System.Drawing.Point(409, 3)
        Me.chkSalary.Name = "chkSalary"
        Me.chkSalary.Size = New System.Drawing.Size(117, 34)
        Me.chkSalary.TabIndex = 28
        Me.chkSalary.Text = "سلم الرواتب"
        Me.chkSalary.UseVisualStyleBackColor = True
        '
        'chkHelp
        '
        Me.chkHelp.AutoSize = True
        Me.chkHelp.Checked = True
        Me.chkHelp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHelp.Location = New System.Drawing.Point(302, 3)
        Me.chkHelp.Name = "chkHelp"
        Me.chkHelp.Size = New System.Drawing.Size(101, 34)
        Me.chkHelp.TabIndex = 37
        Me.chkHelp.Text = "المساعدة"
        Me.chkHelp.UseVisualStyleBackColor = True
        '
        'chkAbout
        '
        Me.chkAbout.AutoSize = True
        Me.chkAbout.Checked = True
        Me.chkAbout.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAbout.Location = New System.Drawing.Point(186, 3)
        Me.chkAbout.Name = "chkAbout"
        Me.chkAbout.Size = New System.Drawing.Size(110, 34)
        Me.chkAbout.TabIndex = 36
        Me.chkAbout.Text = "حول النظام"
        Me.chkAbout.UseVisualStyleBackColor = True
        '
        'chkUser
        '
        Me.chkUser.AutoSize = True
        Me.chkUser.Checked = True
        Me.chkUser.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUser.Location = New System.Drawing.Point(57, 3)
        Me.chkUser.Name = "chkUser"
        Me.chkUser.Size = New System.Drawing.Size(123, 34)
        Me.chkUser.TabIndex = 35
        Me.chkUser.Text = "المستخدمين"
        Me.chkUser.UseVisualStyleBackColor = True
        '
        'chkSetting
        '
        Me.chkSetting.AutoSize = True
        Me.chkSetting.Checked = True
        Me.chkSetting.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSetting.Location = New System.Drawing.Point(540, 43)
        Me.chkSetting.Name = "chkSetting"
        Me.chkSetting.Size = New System.Drawing.Size(97, 34)
        Me.chkSetting.TabIndex = 34
        Me.chkSetting.Text = "الاعدادات"
        Me.chkSetting.UseVisualStyleBackColor = True
        '
        'chkReport
        '
        Me.chkReport.AutoSize = True
        Me.chkReport.Checked = True
        Me.chkReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReport.Location = New System.Drawing.Point(451, 43)
        Me.chkReport.Name = "chkReport"
        Me.chkReport.Size = New System.Drawing.Size(83, 34)
        Me.chkReport.TabIndex = 33
        Me.chkReport.Text = "التقارير"
        Me.chkReport.UseVisualStyleBackColor = True
        '
        'chkSearch
        '
        Me.chkSearch.AutoSize = True
        Me.chkSearch.Checked = True
        Me.chkSearch.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearch.Location = New System.Drawing.Point(373, 43)
        Me.chkSearch.Name = "chkSearch"
        Me.chkSearch.Size = New System.Drawing.Size(72, 34)
        Me.chkSearch.TabIndex = 32
        Me.chkSearch.Text = "البحث"
        Me.chkSearch.UseVisualStyleBackColor = True
        '
        'chkExport
        '
        Me.chkExport.AutoSize = True
        Me.chkExport.Checked = True
        Me.chkExport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExport.Location = New System.Drawing.Point(294, 43)
        Me.chkExport.Name = "chkExport"
        Me.chkExport.Size = New System.Drawing.Size(73, 34)
        Me.chkExport.TabIndex = 27
        Me.chkExport.Text = "تصدير"
        Me.chkExport.UseVisualStyleBackColor = True
        '
        'chkUpdate
        '
        Me.chkUpdate.AutoSize = True
        Me.chkUpdate.Checked = True
        Me.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpdate.Location = New System.Drawing.Point(212, 43)
        Me.chkUpdate.Name = "chkUpdate"
        Me.chkUpdate.Size = New System.Drawing.Size(76, 34)
        Me.chkUpdate.TabIndex = 26
        Me.chkUpdate.Text = "تعديل"
        Me.chkUpdate.UseVisualStyleBackColor = True
        '
        'chkDelete
        '
        Me.chkDelete.AutoSize = True
        Me.chkDelete.Checked = True
        Me.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDelete.Location = New System.Drawing.Point(139, 43)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(67, 34)
        Me.chkDelete.TabIndex = 25
        Me.chkDelete.Text = "حذف"
        Me.chkDelete.UseVisualStyleBackColor = True
        '
        'chkSearchInMain
        '
        Me.chkSearchInMain.AutoSize = True
        Me.chkSearchInMain.Checked = True
        Me.chkSearchInMain.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearchInMain.Location = New System.Drawing.Point(420, 83)
        Me.chkSearchInMain.Name = "chkSearchInMain"
        Me.chkSearchInMain.Size = New System.Drawing.Size(217, 34)
        Me.chkSearchInMain.TabIndex = 31
        Me.chkSearchInMain.Text = "البحث في الصفحة الرئيسية"
        Me.chkSearchInMain.UseVisualStyleBackColor = True
        '
        'chkMain
        '
        Me.chkMain.AutoSize = True
        Me.chkMain.Checked = True
        Me.chkMain.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMain.Location = New System.Drawing.Point(322, 83)
        Me.chkMain.Name = "chkMain"
        Me.chkMain.Size = New System.Drawing.Size(92, 34)
        Me.chkMain.TabIndex = 30
        Me.chkMain.Text = "الرئيسية"
        Me.chkMain.UseVisualStyleBackColor = True
        '
        'chkAdd
        '
        Me.chkAdd.AutoSize = True
        Me.chkAdd.Checked = True
        Me.chkAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAdd.Location = New System.Drawing.Point(240, 83)
        Me.chkAdd.Name = "chkAdd"
        Me.chkAdd.Size = New System.Drawing.Size(76, 34)
        Me.chkAdd.TabIndex = 24
        Me.chkAdd.Text = "أضافة"
        Me.chkAdd.UseVisualStyleBackColor = True
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Checked = True
        Me.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrint.Location = New System.Drawing.Point(159, 83)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(75, 34)
        Me.chkPrint.TabIndex = 24
        Me.chkPrint.Text = "طباعة"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'chkRecords
        '
        Me.chkRecords.AutoSize = True
        Me.chkRecords.Checked = True
        Me.chkRecords.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecords.Location = New System.Drawing.Point(84, 83)
        Me.chkRecords.Name = "chkRecords"
        Me.chkRecords.Size = New System.Drawing.Size(69, 34)
        Me.chkRecords.TabIndex = 24
        Me.chkRecords.Text = "سجل"
        Me.chkRecords.UseVisualStyleBackColor = True
        '
        'chkRetirment
        '
        Me.chkRetirment.AutoSize = True
        Me.chkRetirment.Checked = True
        Me.chkRetirment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRetirment.Location = New System.Drawing.Point(525, 123)
        Me.chkRetirment.Name = "chkRetirment"
        Me.chkRetirment.Size = New System.Drawing.Size(112, 34)
        Me.chkRetirment.TabIndex = 24
        Me.chkRetirment.Text = "المتقاعدين"
        Me.chkRetirment.UseVisualStyleBackColor = True
        '
        'FRM_AddUpdateUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 606)
        Me.Controls.Add(Me.grbPermission)
        Me.Controls.Add(Me.grbAnotherInfo)
        Me.Controls.Add(Me.grbBasicInfo)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_AddUpdateUsers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أضافة / تعديل مستخدم   "
        Me.grbBasicInfo.ResumeLayout(False)
        Me.grbBasicInfo.PerformLayout()
        Me.grbAnotherInfo.ResumeLayout(False)
        Me.grbAnotherInfo.PerformLayout()
        Me.grbPermission.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbBasicInfo As GroupBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents grbAnotherInfo As GroupBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents grbPermission As GroupBox
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbUserID As ComboBox
    Friend WithEvents chkIsSecondryUser As CheckBox
    Friend WithEvents cmbRoles As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents chkEmployee As CheckBox
    Friend WithEvents chkSalary As CheckBox
    Friend WithEvents chkHelp As CheckBox
    Friend WithEvents chkAbout As CheckBox
    Friend WithEvents chkUser As CheckBox
    Friend WithEvents chkSetting As CheckBox
    Friend WithEvents chkReport As CheckBox
    Friend WithEvents chkSearch As CheckBox
    Friend WithEvents chkExport As CheckBox
    Friend WithEvents chkUpdate As CheckBox
    Friend WithEvents chkDelete As CheckBox
    Friend WithEvents chkSearchInMain As CheckBox
    Friend WithEvents chkMain As CheckBox
    Friend WithEvents chkAdd As CheckBox
    Friend WithEvents chkPrint As CheckBox
    Friend WithEvents chkRecords As CheckBox
    Friend WithEvents chkRetirment As CheckBox
End Class
