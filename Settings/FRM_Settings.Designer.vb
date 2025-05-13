<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_Settings
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSaveConnection = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.MaskedTextBox()
        Me.txtUsername = New System.Windows.Forms.MaskedTextBox()
        Me.txtDatabase = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radLocal = New System.Windows.Forms.RadioButton()
        Me.radNetwork = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NUDDuration = New System.Windows.Forms.NumericUpDown()
        Me.Button1btnGeneralSaveSetting = New System.Windows.Forms.Button()
        Me.txtCurrency = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NUDDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSaveConnection)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Controls.Add(Me.txtDatabase)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtServer)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.radLocal)
        Me.GroupBox1.Controls.Add(Me.radNetwork)
        Me.GroupBox1.Font = New System.Drawing.Font("Cairo Medium", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(35, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 479)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "اعدادات الاتصال"
        '
        'btnSaveConnection
        '
        Me.btnSaveConnection.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.diskette
        Me.btnSaveConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveConnection.Location = New System.Drawing.Point(52, 391)
        Me.btnSaveConnection.Name = "btnSaveConnection"
        Me.btnSaveConnection.Size = New System.Drawing.Size(266, 47)
        Me.btnSaveConnection.TabIndex = 3
        Me.btnSaveConnection.Text = "حفظ"
        Me.btnSaveConnection.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(52, 339)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(266, 36)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = "sa123456"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(52, 267)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(266, 36)
        Me.txtUsername.TabIndex = 2
        Me.txtUsername.Text = "sa"
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(52, 195)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(266, 36)
        Me.txtDatabase.TabIndex = 2
        Me.txtDatabase.Text = "HR_System"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 306)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 29)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "كلمة السر:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 29)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "اسم المستخدم:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(205, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "قاعدة البيانات:"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(52, 123)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(266, 36)
        Me.txtServer.TabIndex = 2
        Me.txtServer.Text = "QUSAIABUSNENEH"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(248, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "السيرفر:"
        '
        'radLocal
        '
        Me.radLocal.AutoSize = True
        Me.radLocal.Location = New System.Drawing.Point(237, 43)
        Me.radLocal.Name = "radLocal"
        Me.radLocal.Size = New System.Drawing.Size(66, 33)
        Me.radLocal.TabIndex = 0
        Me.radLocal.TabStop = True
        Me.radLocal.Text = "محلي"
        Me.radLocal.UseVisualStyleBackColor = True
        '
        'radNetwork
        '
        Me.radNetwork.AutoSize = True
        Me.radNetwork.Location = New System.Drawing.Point(95, 43)
        Me.radNetwork.Name = "radNetwork"
        Me.radNetwork.Size = New System.Drawing.Size(72, 33)
        Me.radNetwork.TabIndex = 0
        Me.radNetwork.TabStop = True
        Me.radNetwork.Text = "شبكي"
        Me.radNetwork.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NUDDuration)
        Me.GroupBox2.Controls.Add(Me.Button1btnGeneralSaveSetting)
        Me.GroupBox2.Controls.Add(Me.txtCurrency)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtCompanyName)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Font = New System.Drawing.Font("Cairo Medium", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(426, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(331, 479)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "اعدادات العامة"
        '
        'NUDDuration
        '
        Me.NUDDuration.Location = New System.Drawing.Point(52, 321)
        Me.NUDDuration.Name = "NUDDuration"
        Me.NUDDuration.Size = New System.Drawing.Size(266, 36)
        Me.NUDDuration.TabIndex = 4
        Me.NUDDuration.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Button1btnGeneralSaveSetting
        '
        Me.Button1btnGeneralSaveSetting.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.diskette
        Me.Button1btnGeneralSaveSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1btnGeneralSaveSetting.Location = New System.Drawing.Point(52, 397)
        Me.Button1btnGeneralSaveSetting.Name = "Button1btnGeneralSaveSetting"
        Me.Button1btnGeneralSaveSetting.Size = New System.Drawing.Size(266, 47)
        Me.Button1btnGeneralSaveSetting.TabIndex = 3
        Me.Button1btnGeneralSaveSetting.Text = "حفظ"
        Me.Button1btnGeneralSaveSetting.UseVisualStyleBackColor = True
        '
        'txtCurrency
        '
        Me.txtCurrency.Location = New System.Drawing.Point(52, 179)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(266, 36)
        Me.txtCurrency.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(180, 274)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 29)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "فترة الاتصال (دقيقة):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(265, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 29)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "العملة:"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(52, 88)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(266, 36)
        Me.txtCompanyName.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(215, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 29)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "اسم المؤسسة:"
        '
        'FRM_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 506)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FRM_Settings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اعدادات البرنامج"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NUDDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents radLocal As RadioButton
    Friend WithEvents radNetwork As RadioButton
    Friend WithEvents txtUsername As MaskedTextBox
    Friend WithEvents txtDatabase As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtServer As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassword As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtCurrency As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCompanyName As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1btnGeneralSaveSetting As Button
    Friend WithEvents btnSaveConnection As Button
    Friend WithEvents NUDDuration As NumericUpDown
    Friend WithEvents Label5 As Label
End Class
