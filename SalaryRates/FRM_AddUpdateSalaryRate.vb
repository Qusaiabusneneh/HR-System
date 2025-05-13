Imports BussinesTier
Imports BussinesTier.HR_System
Imports BussinesTier.HR_System.Core

Public Class FRM_AddUpdateSalaryRate
    Private _salaryRate As clsSalaryRates
    Private SalaryRate As clsSalaryRates = New clsSalaryRates()
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
        _salaryRate = New clsSalaryRates()
        _Mode = enMode.enAddNew
    End Sub
    Private Sub _ResetDefaultValue()
        txtSalary.Text = ""
        txtBounsYear.Text = ""
        NUDDegree.Value = 0
        NUDPromationYear.Value = 0
    End Sub
    Private Sub _LoadData()
        _salaryRate = SalaryRate.Find(_ID)
        If _salaryRate Is Nothing Then
            _ResetDefaultValue()
            MessageBox.Show($"There is no info about this SalaryRate with {_ID}")
            Return
        End If
        txtSalary.Text = _salaryRate.Salary
        txtBounsYear.Text = _salaryRate.BounsYearRate
        NUDDegree.Value = _salaryRate.Degree
        NUDPromationYear.Value = _salaryRate.PromationYear
    End Sub
    Private Function _checkItemIsFill() As Boolean
        If txtBounsYear.Text = "" AndAlso txtSalary.Text = "" Then
            MessageBox.Show("Please fill the items ")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If _salaryRate Is Nothing Then
            _salaryRate = New clsSalaryRates()
        End If
        If _checkItemIsFill() Then
            _salaryRate.salaryDTO.ID = Me.ID
            _salaryRate.salaryDTO.Salary = Convert.ToDecimal(txtSalary.Text)
            _salaryRate.salaryDTO.Degree = Convert.ToInt32(NUDDegree.Value)
            _salaryRate.salaryDTO.PromationYear = Convert.ToInt32(NUDPromationYear.Value)
            _salaryRate.salaryDTO.BounsYearRate = Convert.ToInt32(txtBounsYear.Text)
            _salaryRate.salaryDTO.UserID = clsLocalUsers.UserID

            If _salaryRate.Save() Then
                clsSystemRecord.AddSystemRecord($"اضافة/تعديل سلم رواتب", $"تم اضافة/تعديل سلم رواتب يحمل الرقم التعريفي {_salaryRate.ID}")
                _Mode = enMode.enUpdate
                btnSave.Text = "تعديل"
                MessageBox.Show("Data saved successfully")
            Else
                MessageBox.Show("Error in Saved Data")
            End If
        End If
    End Sub
    Private Sub FRM_AddUpdateSalaryRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _ResetDefaultValue()
        If _Mode = enMode.enUpdate Then
            _LoadData()
        End If
    End Sub
End Class