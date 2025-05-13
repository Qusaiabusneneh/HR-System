Imports BussinesTier
Imports BussinesTier.HR_System.Core
Public Class FRM_AddUpdateRetirements
    Private currentRetirement As clsRetirements
    Private RetirementsBL As clsRetirements
    Private _employees As clsEmployees
    Private ReadOnly PageUserCtrl As ctrlManageRetirements
    Private ReadOnly _main As FRM_Main
    Private UserCreatedDate As DateTime
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

    Public Sub New(main As FRM_Main, ID As Integer, pageUserCtrl As ctrlManageRetirements, Employee As clsEmployees)
        InitializeComponent()
        RetirementsBL = New clsRetirements()
        Me.PageUserCtrl = pageUserCtrl
        Me._ID = ID
        Me.Owner = main
        Me._employees = Employee

        If ID > 0 Then
            _Mode = enMode.enUpdate
        Else
            _Mode = enMode.enAddNew
        End If

    End Sub

    Public Sub New(ID As Integer)
        InitializeComponent()
        _Mode = enMode.enUpdate
        Me._ID = ID
        Me.Owner = _main
    End Sub

    Public Sub New()
        InitializeComponent()
        currentRetirement = New clsRetirements()
        RetirementsBL = New clsRetirements()
        _Mode = enMode.enAddNew
    End Sub

    Private Sub _LoadEmployeesNameInCombBox()
        Dim employeesList = clsEmployees.GetAllEmployeesNames()
        cmbEmployees.DisplayMember = "FullName"
        cmbEmployees.ValueMember = "ID"
        cmbEmployees.DataSource = employeesList
        cmbEmployees.SelectedIndex = -1
    End Sub

    Private Sub _LoadUsersnameInCombBox()
        Dim usersList = clsUsers.GetAllUsernames()
        cmbUsers.DisplayMember = "Username"
        cmbUsers.ValueMember = "ID"
        cmbUsers.DataSource = usersList
        cmbUsers.SelectedIndex = -1
    End Sub

    Private Sub _ResetDefaultValue()
        _LoadEmployeesNameInCombBox()
        _LoadUsersnameInCombBox()
        If _Mode = enMode.enAddNew Then
            btnSave.Text = "أضافة"
            currentRetirement = New clsRetirements()
        Else
            btnSave.Text = "تعديل"
        End If
        RichTextBox1.Text = ""
        cmbEmployees.SelectedIndex = 0
        cmbUsers.SelectedIndex = 0
        dateTimePickerRetirementDate.Value = DateTime.Now.Date
    End Sub

    Private Sub _LoadData()
        currentRetirement = RetirementsBL.Find(_ID)
        RichTextBox1.Text = currentRetirement.Reason
        dateTimePickerRetirementDate.Value = currentRetirement.RetirementDate.Date
        cmbEmployees.SelectedValue = currentRetirement.EmployeeID
        cmbUsers.SelectedIndex = currentRetirement.UserID
        If currentRetirement Is Nothing Then
            _ResetDefaultValue()
            MessageBox.Show($"There is no info about this BookThanks with {_ID}")
            Exit Sub
        End If
    End Sub

    Private Function _checkItemIsFill() As Boolean
        If RichTextBox1.Text = "" Then
            MessageBox.Show("Please fill the items ")
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If currentRetirement Is Nothing Then
            currentRetirement = New clsRetirements()
        End If
        If _checkItemIsFill() Then
            currentRetirement.RDTO.ID = Me.ID
            currentRetirement.RDTO.Reason = RichTextBox1.Text
            currentRetirement.RDTO.RetirementDate = dateTimePickerRetirementDate.Value
            currentRetirement.RDTO.EmployeeID = cmbEmployees.SelectedItem.ID
            currentRetirement.RDTO.CreatedDate = DateTime.Now
            currentRetirement.RDTO.UserID = cmbUsers.SelectedValue.ToString()

            If currentRetirement.Save() Then
                clsSystemRecord.AddSystemRecord($"أضافة تقاعد ", $"تم اضافة/تعديل معلومات تقاعد  يحمل الرقم التعريفي {ID.ToString()}")
                _Mode = enMode.enUpdate
                btnSave.Text = "تعديل"
                MessageBox.Show("Data saved successfully")

            Else
                MessageBox.Show("Error in Saved Data")
            End If
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        Me.Close()
        PageUserCtrl.btnAdd_Click(sender, e)
    End Sub

    Private Sub FRM_AddUpdateUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _ResetDefaultValue()
        If _Mode = enMode.enUpdate Then
            _LoadData()
        End If
    End Sub
End Class