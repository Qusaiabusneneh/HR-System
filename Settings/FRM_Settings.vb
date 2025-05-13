Imports DocumentFormat.OpenXml.VariantTypes

Public Class FRM_Settings
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub SaveGeneralSetting()
        My.Settings.CompanyName = txtCompanyName.Text
        My.Settings.Currency = txtCurrency.Text
        My.Settings.Save()
        MessageBox.Show("تم حفظ الاعدادات")
    End Sub
    Private Sub LoadDataSetting()
        txtCompanyName.Text = My.Settings.CompanyName
        txtCurrency.Text = My.Settings.Currency

        If My.Settings.ConnectionType = "Local" Then
            radLocal.Checked = True
        Else
            radNetwork.Checked = True
        End If

        txtServer.Text = My.Settings.Server
        txtDatabase.Text = My.Settings.DataBase
        txtUsername.Text = My.Settings.Username
        txtPassword.Text = My.Settings.Password
        NUDDuration.Value = My.Settings.ConnectionDuration
    End Sub

    Private Sub radLocal_CheckedChanged(sender As Object, e As EventArgs) Handles radLocal.CheckedChanged
        If radLocal.Checked Then
            txtServer.Enabled = True
            txtPassword.Enabled = False
            txtUsername.Enabled = False
            NUDDuration.Enabled = False
        End If
    End Sub

    Private Sub radNetwork_CheckedChanged(sender As Object, e As EventArgs) Handles radNetwork.CheckedChanged
        If radNetwork.Checked Then
            txtServer.Enabled = False
            txtPassword.Enabled = True
            txtUsername.Enabled = True
            NUDDuration.Enabled = True
        End If
    End Sub

    Private Sub Button1btnGeneralSaveSetting_Click(sender As Object, e As EventArgs) Handles Button1btnGeneralSaveSetting.Click
        SaveGeneralSetting()
    End Sub
    Private Sub btnSaveConnection_Click(sender As Object, e As EventArgs) Handles btnSaveConnection.Click
        Dim isLocal As Boolean = radLocal.Checked

        If isLocal Then
            My.Settings.ConnectionType = "Local"
            txtPassword.Enabled = False
            txtUsername.Enabled = False
            NUDDuration.Enabled = False
        Else
            My.Settings.ConnectionType = "Network"
            txtPassword.Enabled = True
            txtUsername.Enabled = True
            NUDDuration.Enabled = True
        End If

        My.Settings.Server = txtServer.Text
        My.Settings.DataBase = txtDatabase.Text
        My.Settings.Username = txtUsername.Text
        My.Settings.Password = txtPassword.Text
        My.Settings.ConnectionDuration = CInt(NUDDuration.Value)
        My.Settings.Save()
        MessageBox.Show("تم حفظ الاعدادات")
        Application.Restart()
    End Sub

End Class