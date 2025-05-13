Imports System.Data.Entity
Imports System.Data.Linq.Mapping
Imports DataAccessTier

Public Class FRM_Start
    Public Sub New()
        InitializeComponent()
        clsConnectionHelper.SetConnectionString()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            lblStatus.Text = "جاري الاتصال..."
            If clsConnectionHelper.TestConnection(clsConnectionString.Connection) Then
                Timer1.Enabled = False
                Dim frm = New FrmLogin()
                frm.Show()
                Me.Hide()
            Else
                panSetting.Visible = True
                lblStatus.Text = "فشل الاتصال...سنعود للاتصال بعد لحظات"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub linkExist_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkExist.LinkClicked
        Application.Exit()
    End Sub

    Private Sub linkSetServer_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSetServer.LinkClicked
        Dim frm = New FRM_Settings()
        frm.Show()

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
        For i As Integer = 0 To 100
            ProgressBar1.Value = i
            Threading.Thread.Sleep(50) ' Simulate work
            Application.DoEvents() ' Refresh UI (avoid in real apps, use async instead)
        Next
    End Sub
End Class