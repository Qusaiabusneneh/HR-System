Imports BussinesTier
Imports DataAccessTier
Imports DocumentFormat.OpenXml.Drawing.Diagrams
Public Class FRM_AddUpdateEmployees
    'using Delegation when you added jobTitle , fill it in combox
    Public Delegate Sub RefreshComboBoxEventHandler()
    Public Shared Event OnEmployeesAdd As RefreshComboBoxEventHandler
    Public Event EmployeesHandle As EventHandler
    Protected Overridable Sub OnEmployessUpdated()
        RaiseEvent EmployeesHandle(Me, EventArgs.Empty)
    End Sub

    Private currentEmployee As clsEmployees
    Private EmployeesBL As clsEmployees
    Private SalaryRateBL As clsSalaryRates
    Private EmployeesRecordsBL As clsEmployeesRecords
    Private ReadOnly PageUserCtrl As ctrlManageEmployees
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
    Public Sub New(main As FRM_Main, ID As Integer, pageUserCtrl As ctrlManageEmployees)
        InitializeComponent()
        EmployeesBL = New clsEmployees()
        SalaryRateBL = New clsSalaryRates()
        EmployeesRecordsBL = New clsEmployeesRecords()
        Me.PageUserCtrl = pageUserCtrl
        Me._ID = ID
        Me._salartList = New List(Of clsSalaryRates)()
        Me.Owner = main

        If ID > 0 Then
            _Mode = enMode.enUpdate
        Else
            _Mode = enMode.enAddNew
        End If

        _GetSalaryRates()
        _AutoFillDataInComboBox()
        _setRoleOfTabs()
    End Sub
    Public Sub New(ID As Integer)
        InitializeComponent()
        _Mode = enMode.enUpdate
        Me._ID = ID
        Me.Owner = _main
    End Sub
    Public Sub New()
        InitializeComponent()
        currentEmployee = New clsEmployees()
        EmployeesBL = New clsEmployees()
        SalaryRateBL = New clsSalaryRates()
        '_salartList = New List(Of clsSalaryRates)
        _Mode = enMode.enAddNew
        AddHandler FRM_AddUpdateEmployees.OnEmployeesAdd, AddressOf _RefreshJobTitleComboBox  'Subscribe to the JobTitle added event
        _FillJobTitlesInCombox()
        _GetSalaryRates()
        _AutoFillDataInComboBox()
    End Sub
    Private Sub _FillJobTitlesInCombox()
        cmbJobTitle.Items.Clear()
        Dim dtJobTitles As DataTable = clsHelper.ConvertListToDataTable(EmployeesBL.GetJobTitles())
        For Each row As DataRow In dtJobTitles.Rows
            cmbJobTitle.Items.Add(row("JobTitle"))
        Next
    End Sub
    Private Sub _RefreshJobTitleComboBox()
        Dim currentSelection As String = cmbJobTitle.Text
        _FillJobTitlesInCombox()
        If Not String.IsNullOrEmpty(currentSelection) Then
            Dim index As Integer = cmbJobTitle.FindString(currentSelection)
            If index <> -1 Then
                cmbJobTitle.SelectedIndex = index
            End If

        End If
    End Sub
    Private Sub _ResetDefaultValue()
        _FillJobTitlesInCombox()
        If _Mode = enMode.enAddNew Then
            btnSave.Text = "أضافة"
            currentEmployee = New clsEmployees()
        Else
            btnSave.Text = "تعديل"
        End If
        txtFullName.Text = ""
        cmbJobTitle.Text = ""
        cmbStatus.Text = ""
        txtCurrentSalary.Text = "0"
        NUDCurrentStage.Value = 1
        NUDCurrentDegree.Value = 1

        txtNextSalary.Text = "0"
        NUDNextStage.Value = 2
        NUDNextDegree.Value = 1

        RichTextBox1.Text = ""
    End Sub
    Private Sub _AutoFillDataInComboBox()
        Dim dataList As List(Of String) = New List(Of String)()
        Try
            dataList.Add("علاوة")
            dataList.Add("ترفيع")
            cmbStatus.DataSource = dataList.Distinct().ToList()
            cmbStatus.AutoCompleteCustomSource = _convertAutoComleteStringCollection(dataList)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _GetSalaryRates()
        Dim dtoList As List(Of clsSalaRateDTO) = SalaryRateBL.GetDataByUser("1")

        _salartList = dtoList.Select(Function(dto) New clsSalaryRates With {
            .ID = dto.ID,
            .Degree = dto.Degree,
            .Salary = dto.Salary,
            .BounsYearRate = dto.BounsYearRate,
            .PromationYear = dto.PromationYear,
            .UserID = dto.UserID
        }).ToList()
        _AutoComplete(_salartList)
    End Sub
    Private Sub _LoadData()
        currentEmployee = EmployeesBL.Find(_ID)
        If currentEmployee Is Nothing Then
            _ResetDefaultValue()
            MessageBox.Show($"There is no info about this User with {_ID}")
            Exit Sub
        End If

        txtFullName.Text = currentEmployee.FullName
        cmbJobTitle.SelectedText = currentEmployee.JobTitle
        cmbStatus.SelectedItem = currentEmployee.Status
        dateTimePickerLastPromation.Value = currentEmployee.LastPromationDate
        NUDCurrentDegree.Value = currentEmployee.CurrentDegree
        NUDCurrentStage.Value = currentEmployee.CurrentStage
        txtCurrentSalary.Text = currentEmployee.CurrentSalary.ToString()
        DateTimePickerCurrentDate.Value = currentEmployee.CurrentDate
        NUDNextDegree.Value = currentEmployee.NextDegree
        NUDNextStage.Value = currentEmployee.NextStage
        txtNextSalary.Text = currentEmployee.NextSalary.ToString()
        DateTimePickerNextDate.Value = currentEmployee.NextDate
        RichTextBox1.Text = currentEmployee.Note
    End Sub
    Private Function _checkItemIsFill() As Boolean
        If txtFullName.Text = "" AndAlso cmbJobTitle.Text.Length < 3 AndAlso cmbStatus.Text.Length < 3 Then
            MessageBox.Show("Please fill the items ")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If currentEmployee Is Nothing Then
            currentEmployee = New clsEmployees()
        End If
        If _checkItemIsFill() Then
            currentEmployee.EDTO.ID = Me.ID
            currentEmployee.EDTO.FullName = txtFullName.Text
            currentEmployee.EDTO.JobTitle = cmbJobTitle.Text
            currentEmployee.EDTO.Status = cmbStatus.Text
            currentEmployee.EDTO.LastPromationDate = dateTimePickerLastPromation.Value

            currentEmployee.EDTO.CurrentDegree = NUDCurrentDegree.Value
            currentEmployee.EDTO.CurrentStage = NUDCurrentStage.Value
            currentEmployee.EDTO.CurrentSalary = Convert.ToInt32(txtCurrentSalary.Text)
            currentEmployee.EDTO.CurrentDate = DateTimePickerCurrentDate.Value

            currentEmployee.EDTO.NextDegree = NUDNextDegree.Value
            currentEmployee.EDTO.NextStage = NUDNextStage.Value
            currentEmployee.EDTO.NextSalary = Convert.ToInt32(txtNextSalary.Text)
            currentEmployee.EDTO.NextDate = DateTimePickerNextDate.Value

            currentEmployee.EDTO.Note = RichTextBox1.Text
            currentEmployee.EDTO.AddedDate = DateTime.Now.Date
            currentEmployee.EDTO.UpdatedDate = DateTime.Now.Date
            currentEmployee.EDTO.UserID = clsLocalUsers.UserID

            If currentEmployee.Save() Then
                RaiseEvent OnEmployeesAdd()
                clsSystemRecord.AddSystemRecord($"اضافة/تعديل موظف", $"تم اضافة/تعديل معلومات موظف يحمل الرقم التعريفي {ID.ToString()}")
                _Mode = enMode.enUpdate
                btnSave.Text = "تعديل"
                MessageBox.Show("Data saved successfully")
                _setRoleOfTabs()
            Else
                MessageBox.Show("Error in Saved Data")
            End If
        End If
    End Sub
    Private Sub _AddEmployeesRecords()
        Try
            Dim newEmployeesRecord As New clsEmployeesRecords()
            newEmployeesRecord.ERDTO.ID = Me.ID
            newEmployeesRecord.ERDTO.EmployeeID = currentEmployee.ID
            newEmployeesRecord.ERDTO.FullName = txtFullName.Text
            newEmployeesRecord.ERDTO.JobTitle = cmbJobTitle.Text
            newEmployeesRecord.ERDTO.Status = cmbStatus.Text
            newEmployeesRecord.ERDTO.LastPromationDate = dateTimePickerLastPromation.Value
            newEmployeesRecord.ERDTO.CurrentDegree = CInt(NUDCurrentDegree.Value)
            newEmployeesRecord.ERDTO.CurrentStage = CInt(NUDCurrentStage.Value)
            newEmployeesRecord.ERDTO.CurrentSalary = CInt(Convert.ToDecimal(txtCurrentSalary.Text))
            newEmployeesRecord.ERDTO.CurrentDate = DateTimePickerCurrentDate.Value.Date
            newEmployeesRecord.ERDTO.NextDegree = CInt(NUDNextDegree.Value)
            newEmployeesRecord.ERDTO.NextStage = CInt(NUDNextStage.Value)
            newEmployeesRecord.ERDTO.NextSalary = CInt(Convert.ToDecimal(txtNextSalary.Text))
            newEmployeesRecord.ERDTO.NextDate = DateTimePickerNextDate.Value.Date
            newEmployeesRecord.ERDTO.Note = RichTextBox1.Text
            newEmployeesRecord.ERDTO.AddedDate = DateTime.Now.Date
            newEmployeesRecord.ERDTO.UpdatedDate = DateTime.Now.Date
            newEmployeesRecord.ERDTO.UserID = clsLocalUsers.UserID
            If newEmployeesRecord._AddNewEmployee() Then
                clsSystemRecord.AddSystemRecord($"أضافة سجل موظف", $"تم اضافة سجل موظف جديد يحمل الرقم التعريفي {newEmployeesRecord.ID}")
                PageUserCtrl._LoadEmployees()
                MessageBox.Show("Add Employee Record is successfully")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub _AutoComplete(salaryRatesList As List(Of clsSalaryRates))

        If salaryRatesList Is Nothing Then
            Exit Sub
        End If

        Dim currentDegree = Convert.ToInt32(NUDCurrentDegree.Value)
        Dim currentStage = Convert.ToInt32(NUDCurrentStage.Value)

        ' Get the salary rate based on the current degree
        Dim currentSalaryRate As clsSalaryRates = salaryRatesList.Where(Function(x) x.Degree = currentDegree).FirstOrDefault()  ' LINQ Expression 

        If currentSalaryRate IsNot Nothing Then

            If currentSalaryRate.PromationYear = currentStage Then

                'ترفيع
                If currentDegree > 1 Then
                    NUDNextDegree.Value = currentDegree - 1
                Else
                    NUDNextDegree.Value = currentDegree
                End If
                NUDNextStage.Value = 1
                cmbStatus.SelectedItem = "ترفيع"

            Else
                'علاوة
                NUDNextDegree.Value = currentDegree
                NUDNextStage.Value = currentStage + 1
                cmbStatus.SelectedItem = "علاوة"
            End If

            ' Update the next date and salary based on the current stage and degree
            DateTimePickerNextDate.Value = DateTimePickerCurrentDate.Value.AddYears(1)
            txtCurrentSalary.Text = _CalculateSalary(currentStage, currentSalaryRate).ToString()
            txtNextSalary.Text = _CalculateSalary(Convert.ToInt32(NUDNextStage.Value), currentSalaryRate).ToString()
        End If
    End Sub
    Private Function _CalculateSalary(currentStage As Integer, currentSalaryRate As clsSalaryRates) As Double
        If (currentStage = 1) Then
            Return currentSalaryRate.Salary
        Else
            Return ((currentStage - 1) * currentSalaryRate.BounsYearRate) + currentSalaryRate.Salary
        End If
    End Function
    Private Function _convertAutoComleteStringCollection(jobTitleList As List(Of String)) As AutoCompleteStringCollection
        Dim collection As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        collection.Clear()
        For Each item In jobTitleList
            collection.Add(item)
        Next
        Return collection
    End Function
    Private Sub btnAutoCalculation_Click(sender As Object, e As EventArgs) Handles btnAutoCalculation.Click
        _LoadData()
        _AutoComplete(_salartList)
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me.Close()
        PageUserCtrl.btnAdd_Click(sender, e)
    End Sub
    Private Sub _UpdateBeforeSaveRecord()
        NUDCurrentDegree.Value = NUDNextDegree.Value
        NUDCurrentStage.Value = NUDNextStage.Value
        txtCurrentSalary.Text = txtNextSalary.Text
        DateTimePickerCurrentDate.Value = DateTimePickerNextDate.Value
        RichTextBox1.Text = String.Empty
        _AutoComplete(_salartList)
    End Sub
    Private Sub NUDNextDegree_ValueChanged(sender As Object, e As EventArgs) Handles NUDNextDegree.ValueChanged
        _AutoComplete(_salartList)
    End Sub
    Private Sub NUDCurrentStage_ValueChanged(sender As Object, e As EventArgs) Handles NUDCurrentStage.ValueChanged
        _AutoComplete(_salartList)
    End Sub
    Private Sub NUDNextStage_ValueChanged(sender As Object, e As EventArgs) Handles NUDNextStage.ValueChanged
        _AutoComplete(_salartList)
    End Sub
    Private Sub NUDCurrentDegree_ValueChanged(sender As Object, e As EventArgs) Handles NUDCurrentDegree.ValueChanged
        _AutoComplete(_salartList)
    End Sub
    Private Sub FRM_AddUpdateUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _ResetDefaultValue()
        If _Mode = enMode.enUpdate Then
            _LoadData()
        End If
    End Sub
    Private Sub txtCurrentSalary_MouseLeave(sender As Object, e As EventArgs) Handles txtCurrentSalary.MouseLeave
        Dim CurrentSalary As Single 'Single = float
        If Not Single.TryParse(txtCurrentSalary.Text, CurrentSalary) OrElse CurrentSalary < 0 Then
            txtCurrentSalary.Text = "0"
            MessageBox.Show("Please input the number value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub txtNextSalary_MouseLeave(sender As Object, e As EventArgs) Handles txtNextSalary.MouseLeave
        Dim NextSalary As Single 'Single = float
        If Not Single.TryParse(txtNextSalary.Text, NextSalary) OrElse NextSalary < 0 Then
            txtNextSalary.Text = "0"
            MessageBox.Show("Please input the number value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub _setRoleOfTabs()
        Try
            If ID = 0 Then
                btnAutoCalculation.Enabled = False
                btnNew.Enabled = False
                btnUpgrade.Enabled = False

                For Each item As TabPage In TabControlForEmployees.TabPages
                    If item.Name <> "PageBonusAndPromotion" Then
                        item.Enabled = False
                    End If
                Next
            Else
                btnAutoCalculation.Enabled = True
                btnNew.Enabled = True
                btnUpgrade.Enabled = True

                For Each item As TabPage In TabControlForEmployees.TabPages
                    If item.Name <> "PageBonusAndPromotion" Then
                        item.Enabled = True
                    End If
                Next

                ' Add Appreciate Data in Appreciate Page
                _userControlEffectAppreciateTab()

                ' Add Bonus Record for BounsRecords Page 
                _userControlEffectForBounsRecords()

                ' Add Holidays for Holidays Page
                _userControlEffectForHolidays()

                ' Add Absence for Absences Page
                _userControlEffectForAbsences()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub _userControlEffectAppreciateTab()
        Try
            TabControlForEmployees.TabPages(1).Controls.Clear()
            Dim appreciateEmployee As clsEmployees = EmployeesBL.Find(Me.ID)
            Dim bookThanksCtrl As New ctrlManageBookThanks(appreciateEmployee)
            bookThanksCtrl.Dock = DockStyle.Fill
            TabControlForEmployees.TabPages(1).Controls.Add(bookThanksCtrl)
        Catch ex As Exception
            MessageBox.Show("Error in Load Book Thanks Control")
        End Try
    End Sub
    Private Sub _userControlEffectForBounsRecords()
        Try
            TabControlForEmployees.TabPages(4).Controls.Clear()
            Dim bounsRecordForEmployee As clsEmployees = EmployeesBL.Find(Me._ID)
            Dim employeesRecordsCtrl As New ctrlManageEmployeesRecords(bounsRecordForEmployee)
            TabControlForEmployees.TabPages(4).Controls.Add(employeesRecordsCtrl)
        Catch ex As Exception
            MessageBox.Show("Error in Load Employees Records Control")
        End Try
    End Sub
    Private Sub _userControlEffectForHolidays()
        Try
            TabControlForEmployees.TabPages(2).Controls.Clear()
            Dim HolidaysForEmployees As clsEmployees = EmployeesBL.Find(Me.ID)
            Dim employeesHolidaysCtrl As New ctrlManageHolidays(HolidaysForEmployees)
            TabControlForEmployees.TabPages(2).Controls.Add(employeesHolidaysCtrl)
        Catch ex As Exception
            MessageBox.Show("Error in Load Holidays Control")
        End Try
    End Sub
    Private Sub _userControlEffectForAbsences()
        Try
            TabControlForEmployees.TabPages(3).Controls.Clear()
            Dim AbsencesForEmployees As clsEmployees = EmployeesBL.Find(Me.ID)
            Dim employeesAbsencesCtrl As New ctrlManageAbsences(AbsencesForEmployees)
            TabControlForEmployees.TabPages(3).Controls.Add(employeesAbsencesCtrl)
        Catch ex As Exception
            MessageBox.Show("Error in Load Absences Control")
        End Try
    End Sub
    Private Sub btnUpgrade_Click(sender As Object, e As EventArgs) Handles btnUpgrade.Click
        If MessageBox.Show("Are you sure you wanna do this ? ", "Bouns Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _AddEmployeesRecords()
            _UpdateBeforeSaveRecord()
            btnSave_Click(sender, e)
        End If
    End Sub
End Class