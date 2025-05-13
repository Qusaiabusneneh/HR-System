<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_AddUpdateEmployees
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_AddUpdateEmployees))
        Me.grbBasicInfo = New System.Windows.Forms.GroupBox()
        Me.dateTimePickerLastPromation = New System.Windows.Forms.DateTimePicker()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.cmbJobTitle = New System.Windows.Forms.ComboBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControlForEmployees = New System.Windows.Forms.TabControl()
        Me.PageBounsAndPromotion = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NUDNextStage = New System.Windows.Forms.NumericUpDown()
        Me.NUDNextDegree = New System.Windows.Forms.NumericUpDown()
        Me.DateTimePickerNextDate = New System.Windows.Forms.DateTimePicker()
        Me.txtNextSalary = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NUDCurrentStage = New System.Windows.Forms.NumericUpDown()
        Me.NUDCurrentDegree = New System.Windows.Forms.NumericUpDown()
        Me.DateTimePickerCurrentDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCurrentSalary = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PageThanks = New System.Windows.Forms.TabPage()
        Me.PageHolidays = New System.Windows.Forms.TabPage()
        Me.PageAbsences = New System.Windows.Forms.TabPage()
        Me.PageBonusRecord = New System.Windows.Forms.TabPage()
        Me.btnUpgrade = New System.Windows.Forms.Button()
        Me.btnAutoCalculation = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grbBasicInfo.SuspendLayout()
        Me.TabControlForEmployees.SuspendLayout()
        Me.PageBounsAndPromotion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NUDNextStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDNextDegree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NUDCurrentStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDCurrentDegree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbBasicInfo
        '
        Me.grbBasicInfo.Controls.Add(Me.dateTimePickerLastPromation)
        Me.grbBasicInfo.Controls.Add(Me.cmbStatus)
        Me.grbBasicInfo.Controls.Add(Me.cmbJobTitle)
        Me.grbBasicInfo.Controls.Add(Me.txtFullName)
        Me.grbBasicInfo.Controls.Add(Me.Label4)
        Me.grbBasicInfo.Controls.Add(Me.Label3)
        Me.grbBasicInfo.Controls.Add(Me.Label2)
        Me.grbBasicInfo.Controls.Add(Me.Label1)
        Me.grbBasicInfo.ForeColor = System.Drawing.Color.Navy
        Me.grbBasicInfo.Location = New System.Drawing.Point(9, 10)
        Me.grbBasicInfo.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.Name = "grbBasicInfo"
        Me.grbBasicInfo.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grbBasicInfo.Size = New System.Drawing.Size(921, 126)
        Me.grbBasicInfo.TabIndex = 0
        Me.grbBasicInfo.TabStop = False
        Me.grbBasicInfo.Text = "معلومات الاساسية"
        '
        'dateTimePickerLastPromation
        '
        Me.dateTimePickerLastPromation.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimePickerLastPromation.Location = New System.Drawing.Point(26, 66)
        Me.dateTimePickerLastPromation.Name = "dateTimePickerLastPromation"
        Me.dateTimePickerLastPromation.Size = New System.Drawing.Size(170, 37)
        Me.dateTimePickerLastPromation.TabIndex = 3
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"علاوة", "ترفيع"})
        Me.cmbStatus.Location = New System.Drawing.Point(232, 68)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(174, 38)
        Me.cmbStatus.TabIndex = 2
        '
        'cmbJobTitle
        '
        Me.cmbJobTitle.FormattingEnabled = True
        Me.cmbJobTitle.Location = New System.Drawing.Point(468, 69)
        Me.cmbJobTitle.Name = "cmbJobTitle"
        Me.cmbJobTitle.Size = New System.Drawing.Size(174, 38)
        Me.cmbJobTitle.TabIndex = 1
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(682, 69)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(232, 37)
        Me.txtFullName.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(84, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 30)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "تاريخ اخر ترفيع:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(354, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 30)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "الحالة:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(508, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "العنوان الوظيفي:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(800, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "الاسم الكامل: "
        '
        'TabControlForEmployees
        '
        Me.TabControlForEmployees.Controls.Add(Me.PageBounsAndPromotion)
        Me.TabControlForEmployees.Controls.Add(Me.PageThanks)
        Me.TabControlForEmployees.Controls.Add(Me.PageHolidays)
        Me.TabControlForEmployees.Controls.Add(Me.PageAbsences)
        Me.TabControlForEmployees.Controls.Add(Me.PageBonusRecord)
        Me.TabControlForEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlForEmployees.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlForEmployees.Location = New System.Drawing.Point(0, 0)
        Me.TabControlForEmployees.Name = "TabControlForEmployees"
        Me.TabControlForEmployees.RightToLeftLayout = True
        Me.TabControlForEmployees.SelectedIndex = 0
        Me.TabControlForEmployees.Size = New System.Drawing.Size(947, 679)
        Me.TabControlForEmployees.TabIndex = 25
        '
        'PageBounsAndPromotion
        '
        Me.PageBounsAndPromotion.Controls.Add(Me.Panel1)
        Me.PageBounsAndPromotion.Controls.Add(Me.GroupBox3)
        Me.PageBounsAndPromotion.Controls.Add(Me.GroupBox2)
        Me.PageBounsAndPromotion.Controls.Add(Me.GroupBox1)
        Me.PageBounsAndPromotion.Controls.Add(Me.grbBasicInfo)
        Me.PageBounsAndPromotion.Location = New System.Drawing.Point(4, 39)
        Me.PageBounsAndPromotion.Name = "PageBounsAndPromotion"
        Me.PageBounsAndPromotion.Padding = New System.Windows.Forms.Padding(3)
        Me.PageBounsAndPromotion.Size = New System.Drawing.Size(939, 636)
        Me.PageBounsAndPromotion.TabIndex = 0
        Me.PageBounsAndPromotion.Text = "العلاوة و الترفيع"
        Me.PageBounsAndPromotion.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnUpgrade)
        Me.Panel1.Controls.Add(Me.btnAutoCalculation)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 573)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel1.Size = New System.Drawing.Size(933, 60)
        Me.Panel1.TabIndex = 25
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RichTextBox1)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox3.Location = New System.Drawing.Point(7, 414)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(921, 152)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "الملاحظات"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(4, 37)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(913, 108)
        Me.RichTextBox1.TabIndex = 12
        Me.RichTextBox1.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NUDNextStage)
        Me.GroupBox2.Controls.Add(Me.NUDNextDegree)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerNextDate)
        Me.GroupBox2.Controls.Add(Me.txtNextSalary)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(9, 282)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(921, 126)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "العلاوة القادمة"
        '
        'NUDNextStage
        '
        Me.NUDNextStage.Location = New System.Drawing.Point(537, 65)
        Me.NUDNextStage.Name = "NUDNextStage"
        Me.NUDNextStage.Size = New System.Drawing.Size(145, 37)
        Me.NUDNextStage.TabIndex = 9
        Me.NUDNextStage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NUDNextStage.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'NUDNextDegree
        '
        Me.NUDNextDegree.Location = New System.Drawing.Point(764, 65)
        Me.NUDNextDegree.Name = "NUDNextDegree"
        Me.NUDNextDegree.Size = New System.Drawing.Size(145, 37)
        Me.NUDNextDegree.TabIndex = 8
        Me.NUDNextDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NUDNextDegree.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'DateTimePickerNextDate
        '
        Me.DateTimePickerNextDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerNextDate.Location = New System.Drawing.Point(26, 66)
        Me.DateTimePickerNextDate.Name = "DateTimePickerNextDate"
        Me.DateTimePickerNextDate.Size = New System.Drawing.Size(170, 37)
        Me.DateTimePickerNextDate.TabIndex = 11
        '
        'txtNextSalary
        '
        Me.txtNextSalary.Location = New System.Drawing.Point(245, 65)
        Me.txtNextSalary.Name = "txtNextSalary"
        Me.txtNextSalary.Size = New System.Drawing.Size(222, 37)
        Me.txtNextSalary.TabIndex = 10
        Me.txtNextSalary.Text = "0"
        Me.txtNextSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(139, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 30)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "التاريخ:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Gray
        Me.Label11.Location = New System.Drawing.Point(320, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 30)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "JD"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(354, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 30)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "الراتب الاسمي:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(618, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 30)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "المرحلة:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(854, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 30)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "الدرجة:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NUDCurrentStage)
        Me.GroupBox1.Controls.Add(Me.NUDCurrentDegree)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerCurrentDate)
        Me.GroupBox1.Controls.Add(Me.txtCurrentSalary)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(9, 144)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(921, 126)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "العلاوة الحالية"
        '
        'NUDCurrentStage
        '
        Me.NUDCurrentStage.Location = New System.Drawing.Point(537, 65)
        Me.NUDCurrentStage.Name = "NUDCurrentStage"
        Me.NUDCurrentStage.Size = New System.Drawing.Size(145, 37)
        Me.NUDCurrentStage.TabIndex = 5
        Me.NUDCurrentStage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NUDCurrentStage.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NUDCurrentDegree
        '
        Me.NUDCurrentDegree.Location = New System.Drawing.Point(764, 65)
        Me.NUDCurrentDegree.Name = "NUDCurrentDegree"
        Me.NUDCurrentDegree.Size = New System.Drawing.Size(145, 37)
        Me.NUDCurrentDegree.TabIndex = 4
        Me.NUDCurrentDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NUDCurrentDegree.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'DateTimePickerCurrentDate
        '
        Me.DateTimePickerCurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerCurrentDate.Location = New System.Drawing.Point(26, 66)
        Me.DateTimePickerCurrentDate.Name = "DateTimePickerCurrentDate"
        Me.DateTimePickerCurrentDate.Size = New System.Drawing.Size(170, 37)
        Me.DateTimePickerCurrentDate.TabIndex = 7
        '
        'txtCurrentSalary
        '
        Me.txtCurrentSalary.Location = New System.Drawing.Point(245, 65)
        Me.txtCurrentSalary.Name = "txtCurrentSalary"
        Me.txtCurrentSalary.Size = New System.Drawing.Size(222, 37)
        Me.txtCurrentSalary.TabIndex = 6
        Me.txtCurrentSalary.Text = "0"
        Me.txtCurrentSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(139, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "التاريخ:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(320, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 30)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "JD"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(354, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 30)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "الراتب الاسمي:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(618, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 30)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "المرحلة:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(854, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 30)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "الدرجة:"
        '
        'PageThanks
        '
        Me.PageThanks.Location = New System.Drawing.Point(4, 39)
        Me.PageThanks.Name = "PageThanks"
        Me.PageThanks.Padding = New System.Windows.Forms.Padding(3)
        Me.PageThanks.Size = New System.Drawing.Size(939, 636)
        Me.PageThanks.TabIndex = 1
        Me.PageThanks.Text = "التشكرات   "
        Me.PageThanks.UseVisualStyleBackColor = True
        '
        'PageHolidays
        '
        Me.PageHolidays.Location = New System.Drawing.Point(4, 39)
        Me.PageHolidays.Name = "PageHolidays"
        Me.PageHolidays.Padding = New System.Windows.Forms.Padding(3)
        Me.PageHolidays.Size = New System.Drawing.Size(939, 636)
        Me.PageHolidays.TabIndex = 2
        Me.PageHolidays.Text = "الاجازات"
        Me.PageHolidays.UseVisualStyleBackColor = True
        '
        'PageAbsences
        '
        Me.PageAbsences.Location = New System.Drawing.Point(4, 39)
        Me.PageAbsences.Name = "PageAbsences"
        Me.PageAbsences.Padding = New System.Windows.Forms.Padding(3)
        Me.PageAbsences.Size = New System.Drawing.Size(939, 636)
        Me.PageAbsences.TabIndex = 3
        Me.PageAbsences.Text = "الغيابات"
        Me.PageAbsences.UseVisualStyleBackColor = True
        '
        'PageBonusRecord
        '
        Me.PageBonusRecord.Location = New System.Drawing.Point(4, 39)
        Me.PageBonusRecord.Name = "PageBonusRecord"
        Me.PageBonusRecord.Padding = New System.Windows.Forms.Padding(3)
        Me.PageBonusRecord.Size = New System.Drawing.Size(939, 636)
        Me.PageBonusRecord.TabIndex = 4
        Me.PageBonusRecord.Text = "سجل العلاوات"
        Me.PageBonusRecord.UseVisualStyleBackColor = True
        '
        'btnUpgrade
        '
        Me.btnUpgrade.Image = CType(resources.GetObject("btnUpgrade.Image"), System.Drawing.Image)
        Me.btnUpgrade.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpgrade.Location = New System.Drawing.Point(32, 8)
        Me.btnUpgrade.Name = "btnUpgrade"
        Me.btnUpgrade.Size = New System.Drawing.Size(285, 49)
        Me.btnUpgrade.TabIndex = 16
        Me.btnUpgrade.Text = "أجراء العلاوة و الترفيع"
        Me.btnUpgrade.UseVisualStyleBackColor = True
        '
        'btnAutoCalculation
        '
        Me.btnAutoCalculation.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.calculator
        Me.btnAutoCalculation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAutoCalculation.Location = New System.Drawing.Point(326, 8)
        Me.btnAutoCalculation.Name = "btnAutoCalculation"
        Me.btnAutoCalculation.Size = New System.Drawing.Size(235, 49)
        Me.btnAutoCalculation.TabIndex = 15
        Me.btnAutoCalculation.Text = "الحساب التلقائي" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnAutoCalculation.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.Location = New System.Drawing.Point(567, 6)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(177, 49)
        Me.btnNew.TabIndex = 14
        Me.btnNew.Text = "جديد"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.diskette
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(750, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(177, 49)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "حفظ"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FRM_AddUpdateEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 679)
        Me.Controls.Add(Me.TabControlForEmployees)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_AddUpdateEmployees"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أضافة / تعديل مستخدم   "
        Me.grbBasicInfo.ResumeLayout(False)
        Me.grbBasicInfo.PerformLayout()
        Me.TabControlForEmployees.ResumeLayout(False)
        Me.PageBounsAndPromotion.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NUDNextStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDNextDegree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NUDCurrentStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDCurrentDegree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbBasicInfo As GroupBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbJobTitle As ComboBox
    Friend WithEvents TabControlForEmployees As TabControl
    Friend WithEvents PageBounsAndPromotion As TabPage
    Friend WithEvents PageThanks As TabPage
    Friend WithEvents dateTimePickerLastPromation As DateTimePicker
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DateTimePickerCurrentDate As DateTimePicker
    Friend WithEvents txtCurrentSalary As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents NUDNextStage As NumericUpDown
    Friend WithEvents NUDNextDegree As NumericUpDown
    Friend WithEvents DateTimePickerNextDate As DateTimePicker
    Friend WithEvents txtNextSalary As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents NUDCurrentStage As NumericUpDown
    Friend WithEvents NUDCurrentDegree As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents btnUpgrade As Button
    Friend WithEvents btnAutoCalculation As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents PageHolidays As TabPage
    Friend WithEvents PageAbsences As TabPage
    Friend WithEvents PageBonusRecord As TabPage
End Class
