Imports BussinesTier
Imports BussinesTier.HR_System
Imports BussinesTier.HR_System.Core

Public Class FRM_AddUpdateUsers
    Private _User As clsUsers
    Private Enum enMode
        enAddNew
        enUpdate
    End Enum
    Private _Mode As enMode = enMode.enAddNew
    Private _ID As Integer
    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            _ID = value
        End Set
    End Property
    Public Sub New(main As FRM_Main)
        InitializeComponent()
        _Mode = enMode.enAddNew
        Me.Owner = main
    End Sub
    Public Sub New(ID As Integer)
        InitializeComponent()
        _Mode = enMode.enUpdate
        Me._ID = ID
    End Sub
    Public Sub New()
        InitializeComponent()
        _User = New clsUsers()
        _Mode = enMode.enAddNew
        _setRoles()
        _addSecondaryUser()
    End Sub
    Private Sub _ResetDefaultValue()
        txtAddress.Text = ""
        txtEmail.Text = ""
        txtFullName.Text = ""
        txtPassword.Text = ""
        txtPhone.Text = ""
        txtUsername.Text = ""
    End Sub
    Private Sub _LoadData()
        _User = clsUsers.Find(_ID)
        If _User Is Nothing Then
            _ResetDefaultValue()
            MessageBox.Show($"There is no info about this User with {_ID}")
            Return
        End If
        txtFullName.Text = _User.FullName
        txtAddress.Text = _User.Address
        txtEmail.Text = _User.Email
        txtPassword.Text = _User.Password
        txtPhone.Text = _User.Phone
        txtUsername.Text = _User.Username
        cmbRoles.FindString(_User.Role)
        cmbUserID.FindString(_setUserID) 'wanna update' 
    End Sub
    Private Function _checkItemIsFill() As Boolean
        If txtAddress.Text = "" AndAlso txtEmail.Text = "" AndAlso txtFullName.Text = "" AndAlso txtPassword.Text = "" AndAlso txtPhone.Text = "" AndAlso txtUsername.Text = "" Then
            MessageBox.Show("Please fill the items ")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If _User Is Nothing Then
            _User = New clsUsers()
        End If
        If _checkItemIsFill() Then
            _User.FullName = txtFullName.Text
            _User.Username = txtUsername.Text
            _User.Password = txtPassword.Text
            _User.Address = txtAddress.Text
            _User.Email = txtEmail.Text
            _User.Phone = txtPhone.Text
            _User.CreatedDate = DateTime.Now.Date
            _User.EditedDate = DateTime.Now.Date
            _User.Role = cmbRoles.SelectedItem 'wanna udpated'
            _User.UserID = _setUserID()
            If _User.Save() Then
                clsSystemRecord.AddSystemRecord($"اضافة/تعديل مستخدم", $"تم اضافة/تعديل معلومات مستخدم يحمل الرقم التعريفي {ID.ToString()}")
                _Mode = enMode.enUpdate
                btnSave.Text = "تعديل"
                MessageBox.Show("Data saved successfully")
            Else
                MessageBox.Show("Error in Saved Data")
            End If
        End If
    End Sub
    Private Function _setUserID() As String
        If chkIsSecondryUser.Checked Then
            Return If(cmbUserID.SelectedItem?.ToString(), _User.UserID)
        Else
            Return Guid.NewGuid().ToString()
        End If
    End Function
    Private Sub FRM_AddUpdateUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _ResetDefaultValue()
        If _Mode = enMode.enUpdate Then
            _LoadData()
        End If
    End Sub
    Private Sub _setRoles()
        If _User.Role = "Admin" Then
            ' Add Roles
            cmbRoles.Items.Clear()
            cmbRoles.Items.Add("Admin")
            cmbRoles.Items.Add("User")
            cmbRoles.Items.Add("Read")

            chkIsSecondryUser.Enabled = True
            cmbUserID.Enabled = False
            cmbRoles.SelectedIndex = 1
        Else
            ' Add Roles
            cmbRoles.Items.Clear()
            cmbRoles.Items.Add("User")
            cmbRoles.Items.Add("Read")

            chkIsSecondryUser.Enabled = False
            cmbUserID.Enabled = False
            chkIsSecondryUser.Checked = True
            cmbRoles.SelectedIndex = 0
        End If
    End Sub
    Private Sub chkIsSecondryUser_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsSecondryUser.CheckedChanged
        _User = clsUsers.Find(_ID)

        ' Check if _User is Nothing before accessing properties
        If _User IsNot Nothing Then
            If _User.Role = "Admin" Then
                cmbUserID.Enabled = chkIsSecondryUser.Checked
            Else
                cmbUserID.Enabled = False
            End If
        Else
            ' Handle the case where _User is Nothing
            cmbUserID.Enabled = False
            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub _setRolesByMainRoles()

        If cmbRoles.SelectedItem.ToString() = "Admin" OrElse cmbRoles.SelectedItem.ToString() = "User" Then
            chkAbout.Checked = True
            chkAdd.Checked = True
            chkUpdate.Checked = True
            chkEmployee.Checked = True
            chkExport.Checked = True
            chkHelp.Checked = True
            chkMain.Checked = True
            chkPrint.Checked = True
            chkRecords.Checked = True
            chkDelete.Checked = True
            chkReport.Checked = True
            chkRetirment.Checked = True
            chkSalary.Checked = True
            chkSearch.Checked = True
            chkSearchInMain.Checked = True
            chkSetting.Checked = True
            chkUser.Checked = True
        Else
            chkAbout.Checked = True
            chkAdd.Checked = False
            chkUpdate.Checked = False
            chkEmployee.Checked = True
            chkExport.Checked = True
            chkHelp.Checked = True
            chkMain.Checked = True
            chkPrint.Checked = True
            chkRecords.Checked = True
            chkDelete.Checked = False
            chkReport.Checked = True
            chkRetirment.Checked = True
            chkSalary.Checked = True
            chkSearch.Checked = True
            chkSearchInMain.Checked = True
            chkSetting.Checked = True
            chkUser.Checked = True
        End If
    End Sub
    Private Sub cmbRoles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRoles.SelectedIndexChanged
        _setRolesByMainRoles()
    End Sub
    Private Sub _addSecondaryUser()
        cmbUserID.Items.Clear()
        cmbUserID.Items.Add(_User.UserID)
        cmbRoles.SelectedIndex = 0
    End Sub
End Class