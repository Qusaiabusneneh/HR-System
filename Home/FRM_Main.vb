Public Class FRM_Main

    Private pageHelper As PageHelper
    Public Sub New()
        InitializeComponent()
        pageHelper = New PageHelper(Me)
    End Sub
    Private Sub SetRoles()
        clsLocalUsers.Role = "Admin"
        clsLocalUsers.FullName = "قصي ابو سنينه"
        clsLocalUsers.Username = "Qsneneh"
        clsLocalUsers.UserID = "1211"
        clsLocalUsers.ID = 1
    End Sub

    Private Sub btnMain_Click(sender As Object, e As EventArgs) Handles btnMain.Click
        pageHelper.SetPage(ctrlHome.Instance)
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        Try
            pageHelper.SetPage(ctrlUsers.Instance(Me))
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnSystemRecord_Click(sender As Object, e As EventArgs) Handles btnSystemRecord.Click
        pageHelper.SetPage(ctrlSystemRecord.Instance(Me))

    End Sub

    Private Sub btnSalary_Click(sender As Object, e As EventArgs) Handles btnSalary.Click
        pageHelper.SetPage(ctrlManageSalaryRate.Instance(Me))
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        pageHelper.SetPage(ctrlManageEmployees.Instance(Me))
    End Sub

    Private Sub panContainer_Paint(sender As Object, e As PaintEventArgs) Handles panContainer.Paint

    End Sub

    Private Sub FRM_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pageHelper.SetPage(ctrlHome.Instance)
    End Sub

    Private Sub btnRetirements_Click(sender As Object, e As EventArgs) Handles btnRetirements.Click
        pageHelper.SetPage(ctrlManageRetirements.Instance(Me))
    End Sub

    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        Dim frm = New FRM_Settings()
        frm.Show()
    End Sub
End Class
