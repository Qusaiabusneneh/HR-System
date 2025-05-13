<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_Main))
        Me.FLPNavPar = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnMain = New System.Windows.Forms.Button()
        Me.btnSalary = New System.Windows.Forms.Button()
        Me.btnEmployees = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnSystemRecord = New System.Windows.Forms.Button()
        Me.btnRetirements = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.panContainer = New System.Windows.Forms.Panel()
        Me.FLPNavPar.SuspendLayout()
        Me.SuspendLayout()
        '
        'FLPNavPar
        '
        Me.FLPNavPar.Controls.Add(Me.btnMain)
        Me.FLPNavPar.Controls.Add(Me.btnSalary)
        Me.FLPNavPar.Controls.Add(Me.btnEmployees)
        Me.FLPNavPar.Controls.Add(Me.btnUsers)
        Me.FLPNavPar.Controls.Add(Me.btnSetting)
        Me.FLPNavPar.Controls.Add(Me.btnSystemRecord)
        Me.FLPNavPar.Controls.Add(Me.btnRetirements)
        Me.FLPNavPar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FLPNavPar.Location = New System.Drawing.Point(0, 621)
        Me.FLPNavPar.Name = "FLPNavPar"
        Me.FLPNavPar.Size = New System.Drawing.Size(1014, 60)
        Me.FLPNavPar.TabIndex = 0
        '
        'btnMain
        '
        Me.btnMain.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.house
        Me.btnMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMain.Location = New System.Drawing.Point(842, 5)
        Me.btnMain.Margin = New System.Windows.Forms.Padding(5)
        Me.btnMain.Name = "btnMain"
        Me.btnMain.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMain.Size = New System.Drawing.Size(167, 52)
        Me.btnMain.TabIndex = 0
        Me.btnMain.Text = "الرئيسة"
        Me.ToolTip1.SetToolTip(Me.btnMain, "ادارة الصفحة الرئيسة")
        Me.btnMain.UseVisualStyleBackColor = True
        '
        'btnSalary
        '
        Me.btnSalary.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.salary
        Me.btnSalary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalary.Location = New System.Drawing.Point(665, 5)
        Me.btnSalary.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSalary.Name = "btnSalary"
        Me.btnSalary.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSalary.Size = New System.Drawing.Size(167, 52)
        Me.btnSalary.TabIndex = 0
        Me.btnSalary.Text = "الرواتب"
        Me.ToolTip1.SetToolTip(Me.btnSalary, "ادارة الصفحة الرواتب")
        Me.btnSalary.UseVisualStyleBackColor = True
        '
        'btnEmployees
        '
        Me.btnEmployees.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.division
        Me.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmployees.Location = New System.Drawing.Point(488, 5)
        Me.btnEmployees.Margin = New System.Windows.Forms.Padding(5)
        Me.btnEmployees.Name = "btnEmployees"
        Me.btnEmployees.Padding = New System.Windows.Forms.Padding(5)
        Me.btnEmployees.Size = New System.Drawing.Size(167, 52)
        Me.btnEmployees.TabIndex = 0
        Me.btnEmployees.Text = "الموظفين"
        Me.ToolTip1.SetToolTip(Me.btnEmployees, "ادارة الصفحة الموظفين")
        Me.btnEmployees.UseVisualStyleBackColor = True
        '
        'btnUsers
        '
        Me.btnUsers.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.man__2_
        Me.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsers.Location = New System.Drawing.Point(311, 5)
        Me.btnUsers.Margin = New System.Windows.Forms.Padding(5)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Padding = New System.Windows.Forms.Padding(5)
        Me.btnUsers.Size = New System.Drawing.Size(167, 52)
        Me.btnUsers.TabIndex = 0
        Me.btnUsers.Text = "المستخدمين"
        Me.btnUsers.UseVisualStyleBackColor = True
        '
        'btnSetting
        '
        Me.btnSetting.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.gear1
        Me.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetting.Location = New System.Drawing.Point(134, 5)
        Me.btnSetting.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSetting.Size = New System.Drawing.Size(167, 52)
        Me.btnSetting.TabIndex = 0
        Me.btnSetting.Text = "الاعدادات"
        Me.ToolTip1.SetToolTip(Me.btnSetting, "ادارة الصفحة الاعدادات")
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'btnSystemRecord
        '
        Me.btnSystemRecord.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.folder
        Me.btnSystemRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSystemRecord.Location = New System.Drawing.Point(842, 67)
        Me.btnSystemRecord.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSystemRecord.Name = "btnSystemRecord"
        Me.btnSystemRecord.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSystemRecord.Size = New System.Drawing.Size(167, 52)
        Me.btnSystemRecord.TabIndex = 1
        Me.btnSystemRecord.Text = "الحركة"
        Me.ToolTip1.SetToolTip(Me.btnSystemRecord, "ادارة الصفحة الاعدادات")
        Me.btnSystemRecord.UseVisualStyleBackColor = True
        '
        'btnRetirements
        '
        Me.btnRetirements.Image = CType(resources.GetObject("btnRetirements.Image"), System.Drawing.Image)
        Me.btnRetirements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRetirements.Location = New System.Drawing.Point(665, 67)
        Me.btnRetirements.Margin = New System.Windows.Forms.Padding(5)
        Me.btnRetirements.Name = "btnRetirements"
        Me.btnRetirements.Padding = New System.Windows.Forms.Padding(5)
        Me.btnRetirements.Size = New System.Drawing.Size(167, 52)
        Me.btnRetirements.TabIndex = 0
        Me.btnRetirements.Text = "المتقاعدين"
        Me.btnRetirements.UseVisualStyleBackColor = True
        '
        'panContainer
        '
        Me.panContainer.BackColor = System.Drawing.Color.Transparent
        Me.panContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panContainer.Location = New System.Drawing.Point(0, 0)
        Me.panContainer.Name = "panContainer"
        Me.panContainer.Size = New System.Drawing.Size(1014, 621)
        Me.panContainer.TabIndex = 1
        '
        'FRM_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 681)
        Me.Controls.Add(Me.panContainer)
        Me.Controls.Add(Me.FLPNavPar)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.Name = "FRM_Main"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "الرئيسة"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.FLPNavPar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FLPNavPar As FlowLayoutPanel
    Friend WithEvents btnMain As Button
    Friend WithEvents btnSalary As Button
    Friend WithEvents btnEmployees As Button
    Friend WithEvents btnUsers As Button
    Friend WithEvents btnSetting As Button
    Friend WithEvents ToolTip1 As ToolTip
    Public WithEvents panContainer As Panel
    Friend WithEvents btnSystemRecord As Button
    Friend WithEvents btnRetirements As Button
End Class
