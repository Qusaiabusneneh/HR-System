Imports DataAccessTier
Public Class clsEmployees
    Public Enum enMode
        enAddNew
        enUpdate
    End Enum
    Public Property Mode As enMode
    Public Property ID As Integer
    Public Property FullName As String
    Public Property JobTitle As String
    Public Property Status As String
    Public Property LastPromationDate As DateTime
    Public Property CurrentDegree As Integer
    Public Property CurrentStage As Integer
    Public Property CurrentSalary As Single
    Public Property CurrentDate As DateTime
    Public Property NextDegree As Integer
    Public Property NextStage As Integer
    Public Property NextSalary As Single
    Public Property NextDate As DateTime
    Public Property Note As String
    Public Property AddedDate As DateTime
    Public Property UpdatedDate As DateTime
    Public Property UserID As String
    Public Property EmployeeDAL As New clsEmployeesDataAccess
    Public Property EDTO As New clsEmployeeDTO(Me.ID, Me.FullName, Me.JobTitle, Me.Status, Me.LastPromationDate, Me.CurrentDegree, Me.CurrentStage,
                                               Me.CurrentSalary, Me.CurrentDate, Me.NextDegree, Me.NextStage, Me.NextSalary, Me.NextDate,
                                                Me.Note, Me.AddedDate, Me.UpdatedDate, Me.UserID)
    Public Sub New()
        Me.ID = -1
        Me.FullName = String.Empty
        Me.JobTitle = String.Empty
        Me.Status = String.Empty
        Me.LastPromationDate = DateTime.Now.Date
        Me.CurrentDegree = 0
        Me.CurrentStage = 0
        Me.CurrentSalary = 0.0
        Me.CurrentDate = DateTime.Now.Date
        Me.NextDegree = 0
        Me.NextStage = 0
        Me.NextSalary = 0.0
        Me.NextDate = DateTime.Now.Date
        Me.Note = String.Empty
        Me.AddedDate = DateTime.Now.Date
        Me.UpdatedDate = DateTime.Now.Date
        Me.UserID = String.Empty
        Mode = enMode.enAddNew
    End Sub

    Public Sub New(id As Integer, fullName As String, jobTitle As String, status As String,
               lastPromationDate As DateTime, currentDegree As Integer, currentStage As Integer,
               currentSalary As Single, currentDate As DateTime, nextDegree As Integer,
               nextStage As Integer, nextSalary As Single, nextDate As DateTime, note As String,
               addedDate As DateTime, updatedDate As DateTime, userID As String)
        Me.ID = id
        Me.FullName = fullName
        Me.JobTitle = jobTitle
        Me.Status = status
        Me.LastPromationDate = lastPromationDate
        Me.CurrentDegree = currentDegree
        Me.CurrentStage = currentStage
        Me.CurrentSalary = currentSalary
        Me.CurrentDate = currentDate
        Me.NextDegree = nextDegree
        Me.NextStage = nextStage
        Me.NextSalary = nextSalary
        Me.NextDate = nextDate
        Me.Note = note
        Me.AddedDate = addedDate
        Me.UpdatedDate = updatedDate
        Me.UserID = userID
        Mode = enMode.enUpdate
    End Sub
    Public Sub New(EDTO As clsEmployeeDTO, cMode As enMode)
        Me.ID = EDTO.ID
        Me.FullName = EDTO.FullName
        Me.JobTitle = EDTO.JobTitle
        Me.Status = EDTO.Status
        Me.LastPromationDate = EDTO.LastPromationDate
        Me.CurrentDegree = EDTO.CurrentDegree
        Me.CurrentStage = EDTO.CurrentStage
        Me.CurrentSalary = EDTO.CurrentSalary
        Me.CurrentDate = EDTO.CurrentDate
        Me.NextDegree = EDTO.NextDegree
        Me.NextStage = EDTO.NextStage
        Me.NextSalary = EDTO.NextSalary
        Me.NextDate = EDTO.NextDate
        Me.Note = EDTO.Note
        Me.AddedDate = EDTO.AddedDate
        Me.UpdatedDate = EDTO.UpdatedDate
        Me.UserID = EDTO.UserID
        cMode = Mode
    End Sub

    Public Function GetAllEmployees() As List(Of clsEmployeeDTO)
        Return EmployeeDAL.GetAllData()
    End Function

    Public Shared Function GetAllEmployeesNames() As List(Of clsEmployeeDTO)
        Return clsEmployeesDataAccess.GetAllEmployeesName()
    End Function

    Public Function GetJobTitles() As List(Of clsEmployeeDTO)
        Return EmployeeDAL.GetAllJobTitles()
    End Function

    Public Function GetDataByUser(UserID As Integer) As List(Of clsEmployeeDTO)
        Return EmployeeDAL.GetDataByUser(UserID)
    End Function

    Public Function Find(ID As Integer) As clsEmployees
        Dim EDTO = EmployeeDAL.GetEmployeeByID(ID)
        If EDTO IsNot Nothing Then
            Return New clsEmployees(EDTO.ID, EDTO.FullName, EDTO.JobTitle, EDTO.Status, EDTO.LastPromationDate, EDTO.CurrentDegree, EDTO.CurrentStage,
                                    EDTO.CurrentSalary, EDTO.CurrentDate, EDTO.NextDegree, EDTO.NextStage, EDTO.NextSalary, EDTO.NextDate,
                                    EDTO.Note, EDTO.AddedDate, EDTO.UpdatedDate, EDTO.UserID)
        Else
            Return New clsEmployees()
        End If
    End Function

    Private Function _AddNewEmployee() As Boolean
        Me.ID = EmployeeDAL.Add(EDTO)
        Return (Me.ID <> -1)
    End Function

    Private Function _UpdateEmployee() As Boolean
        Return EmployeeDAL.Edit(EDTO)
    End Function

    Public Function Save() As Boolean
        Select Case Mode
            Case enMode.enAddNew
                If _AddNewEmployee() Then
                    Mode = enMode.enUpdate
                    Return True
                Else
                    Return False
                End If

            Case enMode.enUpdate
                Return _UpdateEmployee()
        End Select

        Return False
    End Function

    Public Function Delete(ID As Integer) As Boolean
        Return EmployeeDAL.Delete(ID)
    End Function
End Class
