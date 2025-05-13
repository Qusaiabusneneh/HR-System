Imports BussinesTier
Public Class FRM_AddUpdateAbsences
    Private currentAbsence As clsAbsences
    Private AbsencesBL As clsAbsences
    Private _employees As clsEmployees
    Private ReadOnly PageUserCtrl As ctrlManageAbsences
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
    Public Sub New(main As FRM_Main, ID As Integer, pageUserCtrl As ctrlManageAbsences, Employee As clsEmployees)
        InitializeComponent()
        AbsencesBL = New clsAbsences()
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
        currentAbsence = New clsAbsences()
        AbsencesBL = New clsAbsences()
        '_salartList = New List(Of clsSalaryRates)
        _Mode = enMode.enAddNew
    End Sub
    Private Sub _ResetDefaultValue()
        If _Mode = enMode.enAddNew Then
            btnSave.Text = "أضافة"
            currentAbsence = New clsAbsences()
        Else
            btnSave.Text = "تعديل"
        End If
        RichTextBox1.Text = ""
        cmbDuration.SelectedIndex = 0
        cmbAbsenceType.SelectedIndex = 0
        dateTimePickerAbsenceDate.Value = DateTime.Now
    End Sub
    Private Sub _LoadData()
        currentAbsence = AbsencesBL.Find(_ID)
        RichTextBox1.Text = currentAbsence.Note
        dateTimePickerAbsenceDate.Value = currentAbsence.AbsenceDate
        cmbDuration.SelectedIndex = cmbDuration.Items.IndexOf(currentAbsence.Duration)
        cmbAbsenceType.SelectedIndex = cmbAbsenceType.Items.IndexOf(currentAbsence.AbsenceType)

        If currentAbsence Is Nothing Then
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
        If currentAbsence Is Nothing Then
            currentAbsence = New clsAbsences()
        End If
        If _checkItemIsFill() Then
            currentAbsence.ADTO.ID = Me.ID
            currentAbsence.ADTO.AbsenceDate = dateTimePickerAbsenceDate.Value
            currentAbsence.ADTO.Duration = cmbDuration.SelectedItem.ToString()
            currentAbsence.ADTO.EmployeeID = _employees.ID
            currentAbsence.ADTO.Note = RichTextBox1.Text
            currentAbsence.ADTO.AddedDate = DateTime.Now.Date
            currentAbsence.ADTO.UserID = clsLocalUsers.UserID
            currentAbsence.ADTO.AbsenceType = cmbAbsenceType.SelectedItem.ToString()

            If currentAbsence.Save() Then
                clsSystemRecord.AddSystemRecord($"أضافة غياب ", $"تم اضافة/تعديل معلومات غياب  يحمل الرقم التعريفي {ID.ToString()}")
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