Public Class ctrlHome
    Private Shared ReadOnly _homeControl As New ctrlHome()
    Private Sub New()
        InitializeComponent()
        lblCompanyName.Text = My.Settings.CompanyName
        lblUsername.Text = $"مرحبا بك {clsLocalUsers.FullName}"
    End Sub
    Public Shared ReadOnly Property Instance As ctrlHome
        Get
            Return _homeControl
        End Get
    End Property
End Class
