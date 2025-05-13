Imports BussinesTier
Public Class FRM_AddUpdateBookThanks
    Private currentBookThanks As clsBookThanks
    Private BookThanksBL As clsBookThanks
    Private _employees As clsEmployees
    Private ReadOnly PageUserCtrl As ctrlManageBookThanks
    Private ReadOnly _main As FRM_Main
    Private UserCreatedDate As DateTime
    Private _salartList As List(Of clsSalaryRates)
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
    Public Sub New(main As FRM_Main, ID As Integer, pageUserCtrl As ctrlManageBookThanks, Employee As clsEmployees)
        InitializeComponent()
        BookThanksBL = New clsBookThanks()
        Me.PageUserCtrl = pageUserCtrl
        Me._ID = ID
        Me._salartList = New List(Of clsSalaryRates)()
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
        currentBookThanks = New clsBookThanks()
        BookThanksBL = New clsBookThanks()
        '_salartList = New List(Of clsSalaryRates)
        _Mode = enMode.enAddNew
    End Sub
    Private Sub _ResetDefaultValue()
        If _Mode = enMode.enAddNew Then
            btnSave.Text = "أضافة"
            currentBookThanks = New clsBookThanks()
        Else
            btnSave.Text = "تعديل"
        End If
        txtReferences.Text = ""
        RichTextBox1.Text = ""
    End Sub
    Private Sub _LoadData()
        currentBookThanks = BookThanksBL.Find(_ID)
        txtReferences.Text = currentBookThanks.Reference
        NUDEffectValue.Value = currentBookThanks.EffectValue
        RichTextBox1.Text = currentBookThanks.Description
        dateTimePickerBookThank.Value = currentBookThanks.AppreciationDate.Date

        If currentBookThanks Is Nothing Then
            _ResetDefaultValue()
            MessageBox.Show($"There is no info about this BookThanks with {_ID}")
            Exit Sub
        End If
    End Sub
    Private Function _checkItemIsFill() As Boolean
        If txtReferences.Text = "" AndAlso RichTextBox1.Text = "" Then
            MessageBox.Show("Please fill the items ")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If currentBookThanks Is Nothing Then
            currentBookThanks = New clsBookThanks()
        End If
        If _checkItemIsFill() Then
            currentBookThanks.bookThanksDTO.ID = Me.ID
            currentBookThanks.bookThanksDTO.EffectValue = NUDEffectValue.Value
            currentBookThanks.bookThanksDTO.Reference = txtReferences.Text
            currentBookThanks.bookThanksDTO.AppreciationDate = dateTimePickerBookThank.Value
            currentBookThanks.bookThanksDTO.EmployeeID = _employees.ID
            currentBookThanks.bookThanksDTO.Description = RichTextBox1.Text
            currentBookThanks.bookThanksDTO.AddedDate = DateTime.Now.Date
            currentBookThanks.bookThanksDTO.UserID = clsLocalUsers.UserID

            If currentBookThanks.Save() Then
                clsSystemRecord.AddSystemRecord($"أضافة كتاب شكر", $"تم اضافة/تعديل معلومات كتاب شكر يحمل الرقم التعريفي {ID.ToString()}")
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