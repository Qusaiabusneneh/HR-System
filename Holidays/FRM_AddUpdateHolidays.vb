Imports BussinesTier
Public Class FRM_AddUpdateHolidays
    Private currentHolidays As clsHoliday
    Private HolidaysBL As clsHoliday
    Private _employees As clsEmployees
    Private ReadOnly PageUserCtrl As ctrlManageHolidays
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
    Public Sub New(main As FRM_Main, ID As Integer, pageUserCtrl As ctrlManageHolidays, Employee As clsEmployees)
        InitializeComponent()
        HolidaysBL = New clsHoliday()
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
        currentHolidays = New clsHoliday()
        HolidaysBL = New clsHoliday()
        _Mode = enMode.enAddNew
    End Sub
    Private Sub _ResetDefaultValue()
        If _Mode = enMode.enAddNew Then
            btnSave.Text = "أضافة"
            currentHolidays = New clsHoliday()
        Else
            btnSave.Text = "تعديل"
        End If
        txtReason.Text = ""
        RichTextBox1.Text = ""
        NUDDuration.Value = 1
        dateTimePickerHolidayDate.Value = DateTime.Now.Date
    End Sub
    Private Sub _LoadData()
        currentHolidays = HolidaysBL.Find(_ID)
        txtReason.Text = currentHolidays.Reason
        NUDDuration.Value = currentHolidays.Duration
        RichTextBox1.Text = currentHolidays.Note
        dateTimePickerHolidayDate.Value = currentHolidays.HolidayDate.Date

        If currentHolidays Is Nothing Then
            _ResetDefaultValue()
            MessageBox.Show($"There is no info about this BookThanks with {_ID}")
            Exit Sub
        End If
    End Sub
    Private Function _checkItemIsFill() As Boolean
        If txtReason.Text = "" AndAlso RichTextBox1.Text = "" AndAlso NUDDuration.Value = 0 Then
            MessageBox.Show("Please fill the items ")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If currentHolidays Is Nothing Then
            currentHolidays = New clsHoliday()
        End If
        If _checkItemIsFill() Then
            currentHolidays.HDTO.ID = Me.ID
            currentHolidays.HDTO.Duration = NUDDuration.Value
            currentHolidays.HDTO.Reason = txtReason.Text
            currentHolidays.HDTO.HolidayDate = dateTimePickerHolidayDate.Value
            currentHolidays.HDTO.EmployeeID = _employees.ID
            currentHolidays.HDTO.Note = RichTextBox1.Text
            currentHolidays.HDTO.AddedDate = DateTime.Now.Date
            currentHolidays.HDTO.UserID = clsLocalUsers.UserID

            If currentHolidays.Save() Then
                clsSystemRecord.AddSystemRecord($"أضافة اجازة ", $"تم اضافة/تعديل معلومات اجازة  يحمل الرقم التعريفي {ID.ToString()}")
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