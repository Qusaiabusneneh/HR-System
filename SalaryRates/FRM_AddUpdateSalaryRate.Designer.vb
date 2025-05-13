<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_AddUpdateSalaryRate
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
        Me.NUDPromationYear = New System.Windows.Forms.NumericUpDown()
        Me.NUDDegree = New System.Windows.Forms.NumericUpDown()
        Me.txtBounsYear = New System.Windows.Forms.TextBox()
        Me.txtSalary = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grbBasicInfo.SuspendLayout()
        CType(Me.NUDPromationYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDDegree, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbBasicInfo
        '
        Me.grbBasicInfo.Controls.Add(Me.NUDPromationYear)
        Me.grbBasicInfo.Controls.Add(Me.NUDDegree)
        Me.grbBasicInfo.Controls.Add(Me.txtBounsYear)
        Me.grbBasicInfo.Controls.Add(Me.txtSalary)
        Me.grbBasicInfo.Controls.Add(Me.Label7)
        Me.grbBasicInfo.Controls.Add(Me.Label3)
        Me.grbBasicInfo.Controls.Add(Me.Label5)
        Me.grbBasicInfo.Controls.Add(Me.Label4)
        Me.grbBasicInfo.Controls.Add(Me.Label2)
        Me.grbBasicInfo.Controls.Add(Me.Label1)
        Me.grbBasicInfo.ForeColor = System.Drawing.Color.Black
        Me.grbBasicInfo.Location = New System.Drawing.Point(13, 9)
        Me.grbBasicInfo.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.Name = "grbBasicInfo"
        Me.grbBasicInfo.Padding = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.grbBasicInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.grbBasicInfo.Size = New System.Drawing.Size(295, 380)
        Me.grbBasicInfo.TabIndex = 0
        Me.grbBasicInfo.TabStop = False
        Me.grbBasicInfo.Text = "معلومات الدخول"
        '
        'NUDPromationYear
        '
        Me.NUDPromationYear.Location = New System.Drawing.Point(7, 320)
        Me.NUDPromationYear.Name = "NUDPromationYear"
        Me.NUDPromationYear.Size = New System.Drawing.Size(270, 37)
        Me.NUDPromationYear.TabIndex = 3
        Me.NUDPromationYear.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NUDDegree
        '
        Me.NUDDegree.Location = New System.Drawing.Point(7, 72)
        Me.NUDDegree.Name = "NUDDegree"
        Me.NUDDegree.Size = New System.Drawing.Size(270, 37)
        Me.NUDDegree.TabIndex = 0
        Me.NUDDegree.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtBounsYear
        '
        Me.txtBounsYear.Location = New System.Drawing.Point(7, 234)
        Me.txtBounsYear.Name = "txtBounsYear"
        Me.txtBounsYear.Size = New System.Drawing.Size(270, 37)
        Me.txtBounsYear.TabIndex = 2
        Me.txtBounsYear.Text = "0"
        Me.txtBounsYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSalary
        '
        Me.txtSalary.Location = New System.Drawing.Point(7, 155)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.Size = New System.Drawing.Size(270, 37)
        Me.txtSalary.TabIndex = 1
        Me.txtSalary.Text = "0"
        Me.txtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(134, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 30)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "عدد سنوات الترفيع:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(154, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 30)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "العلاوة السنوية:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cairo", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(7, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "دينار اردني"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cairo", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(7, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 24)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "دينار اردني"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "الراتب الاساسي:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(151, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "الدرجة الوظيفية:"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.diskette
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.Location = New System.Drawing.Point(12, 392)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(296, 56)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "حفظ"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FRM_AddUpdateSalaryRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 453)
        Me.Controls.Add(Me.grbBasicInfo)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_AddUpdateSalaryRate"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أضافة / تعديل مستخدم   "
        Me.grbBasicInfo.ResumeLayout(False)
        Me.grbBasicInfo.PerformLayout()
        CType(Me.NUDPromationYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDDegree, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grbBasicInfo As GroupBox
    Friend WithEvents txtBounsYear As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents NUDDegree As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NUDPromationYear As NumericUpDown
End Class
