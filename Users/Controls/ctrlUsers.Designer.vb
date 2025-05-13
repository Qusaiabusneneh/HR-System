<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlUsers
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.FLPNavPar = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.brnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DGVUsers = New System.Windows.Forms.DataGridView()
        Me.FLPNavPar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVUsers, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DGVUsers
        '
        Me.DGVUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVUsers.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVUsers.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGVUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVUsers.Location = New System.Drawing.Point(0, 62)
        Me.DGVUsers.Name = "DGVUsers"
        Me.DGVUsers.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVUsers.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGVUsers.Size = New System.Drawing.Size(1030, 658)
        Me.DGVUsers.TabIndex = 2
        '
        'ctrlUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DGVUsers)
        Me.Controls.Add(Me.FLPNavPar)
        Me.Font = New System.Drawing.Font("Cairo", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.Name = "ctrlUsers"
        Me.Size = New System.Drawing.Size(1030, 720)
        Me.FLPNavPar.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVUsers, System.ComponentModel.ISupportInitialize).EndInit()
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
    Public WithEvents DGVUsers As DataGridView
End Class
