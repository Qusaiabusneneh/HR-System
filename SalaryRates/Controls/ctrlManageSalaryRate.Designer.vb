<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlManageSalaryRate
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FLPNavPar = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.brnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DGVSalaryRate = New System.Windows.Forms.DataGridView()
        Me.FLPNavPar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVSalaryRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FLPNavPar
        '
        Me.FLPNavPar.Controls.Add(Me.btnAdd)
        Me.FLPNavPar.Controls.Add(Me.brnUpdate)
        Me.FLPNavPar.Controls.Add(Me.btnDelete)
        Me.FLPNavPar.Controls.Add(Me.btnExport)
        Me.FLPNavPar.Controls.Add(Me.Panel1)
        Me.FLPNavPar.Dock = System.Windows.Forms.DockStyle.Top
        Me.FLPNavPar.Location = New System.Drawing.Point(0, 0)
        Me.FLPNavPar.Name = "FLPNavPar"
        Me.FLPNavPar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FLPNavPar.Size = New System.Drawing.Size(1030, 62)
        Me.FLPNavPar.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.plus
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(898, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(5)
        Me.btnAdd.Size = New System.Drawing.Size(129, 52)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "أضافة"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'brnUpdate
        '
        Me.brnUpdate.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.edit__1_
        Me.brnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.brnUpdate.Location = New System.Drawing.Point(763, 3)
        Me.brnUpdate.Name = "brnUpdate"
        Me.brnUpdate.Padding = New System.Windows.Forms.Padding(5)
        Me.brnUpdate.Size = New System.Drawing.Size(129, 52)
        Me.brnUpdate.TabIndex = 0
        Me.brnUpdate.Text = "تعديل"
        Me.brnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.bin
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(642, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5)
        Me.btnDelete.Size = New System.Drawing.Size(115, 52)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "حذف"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.logo
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(507, 3)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Padding = New System.Windows.Forms.Padding(5)
        Me.btnExport.Size = New System.Drawing.Size(129, 52)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "تصدير"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Location = New System.Drawing.Point(190, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 52)
        Me.Panel1.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSearch.Image = Global.HR_SystemUsing_VB.net_.My.Resources.Resources.loupe
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(0, 0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(5)
        Me.btnSearch.Size = New System.Drawing.Size(50, 52)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(56, 3)
        Me.txtSearch.Multiline = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(252, 46)
        Me.txtSearch.TabIndex = 3
        '
        'DGVSalaryRate
        '
        Me.DGVSalaryRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVSalaryRate.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSalaryRate.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVSalaryRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSalaryRate.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVSalaryRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVSalaryRate.Location = New System.Drawing.Point(0, 62)
        Me.DGVSalaryRate.Name = "DGVSalaryRate"
        Me.DGVSalaryRate.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVSalaryRate.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVSalaryRate.Size = New System.Drawing.Size(1030, 658)
        Me.DGVSalaryRate.TabIndex = 2
        '
        'ctrlManageSalaryRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DGVSalaryRate)
        Me.Controls.Add(Me.FLPNavPar)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.Name = "ctrlManageSalaryRate"
        Me.Size = New System.Drawing.Size(1030, 720)
        Me.FLPNavPar.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVSalaryRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FLPNavPar As FlowLayoutPanel
    Friend WithEvents btnAdd As Button
    Friend WithEvents brnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Public WithEvents DGVSalaryRate As DataGridView
End Class
