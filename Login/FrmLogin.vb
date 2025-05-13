Imports System.GenericUriParser
Imports System.Linq
Imports BussinesTier
Imports BussinesTier.HR_System.Core
Imports DataAccessTier
Public Class FrmLogin
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Function _isValid() As Boolean
        If txtUsername.Text.Length < 4 OrElse String.IsNullOrEmpty(txtUsername.Text) OrElse
           txtPassword.Text.Length < 4 OrElse String.IsNullOrEmpty(txtPassword.Text) Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub _Login()
        Dim Username As String = txtUsername.Text.Trim()
        Dim Password As String = txtPassword.Text.Trim()
        Dim hashedPassword As String = clsHashing.ComputeHashing(Password)

        Dim usersList As List(Of clsUserDTO) = clsUsers.GetAllUser()

        Dim currentUser As clsUserDTO = usersList.
        FirstOrDefault(Function(x) x IsNot Nothing AndAlso
                                  x.Username = Username AndAlso
                                  x.Password = hashedPassword)

        If currentUser IsNot Nothing Then
            clsLocalUsers.ID = currentUser.ID
            clsLocalUsers.FullName = currentUser.FullName
            clsLocalUsers.Username = currentUser.Username
            clsLocalUsers.Password = currentUser.Password
            clsLocalUsers.Phone = currentUser.Phone
            clsLocalUsers.Email = currentUser.Email
            clsLocalUsers.Address = currentUser.Address
            clsLocalUsers.Role = currentUser.Role
            clsLocalUsers.CreatedDate = currentUser.CreatedDate
            clsLocalUsers.EditedDate = currentUser.EditedDate
            clsLocalUsers.UserID = currentUser.UserID
            clsLocalUsers.IsSecondaryUser = currentUser.IsSecondaryUser

            clsSystemRecord.AddSystemRecord("أضافة تسجيل دخول", $"تم تسجيل دخول مستخدم {currentUser.FullName}")

            Dim mainForm As New FRM_Main()
            mainForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid username or password.")
        End If
    End Sub



    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If _isValid() Then
            _Login()
            SaveLoginInfo
        Else
            MessageBox.Show("Please enter a valid username and password.")
        End If
    End Sub
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Focus()
        txtUsername.Select()
        If My.Settings.RememberMe Then
            txtUsername.Text = My.Settings.SavedUsername
            txtPassword.Text = My.Settings.SavedPassword
            chkRemeberMe.Checked = True
        End If
        SaveLoginInfo()
    End Sub
    Private Sub SaveLoginInfo()
        If chkRemeberMe.Checked Then
            My.Settings.SavedUsername = txtUsername.Text
            My.Settings.RememberMe = True
        Else
            My.Settings.SavedUsername = ""
            My.Settings.RememberMe = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub FrmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub

    Private Sub txtUsername_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtUsername.MaskInputRejected

    End Sub
End Class