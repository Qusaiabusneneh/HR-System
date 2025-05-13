Imports DataAccessTier

Public Class clsEmployeesRecords
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
    Public Property CurrentSalary As Integer
    Public Property CurrentDate As DateTime
    Public Property NextDegree As Integer
    Public Property NextStage As Integer
    Public Property NextSalary As Integer
    Public Property NextDate As DateTime
    Public Property Note As String
    Public Property AddedDate As DateTime
    Public Property UpdatedDate As DateTime
    Public Property UserID As String
    Public Property EmployeeID As Integer
    Public Property EmployeeRecrodsDAL As New clsEmployeesRecrodsDAL
    Public Property ERDTO As New clsEmployeesRecrodsDTO(Me.ID, Me.EmployeeID, Me.FullName, Me.JobTitle, Me.Status, Me.LastPromationDate, Me.CurrentDegree, Me.CurrentStage,
                                           Me.CurrentSalary, Me.CurrentDate, Me.NextDegree, Me.NextStage, Me.NextSalary, Me.NextDate,
                                            Me.Note, Me.AddedDate, Me.UpdatedDate, Me.UserID)
    Public Sub New()
        Me.ID = -1
        Me.EmployeeID = -1
        Me.FullName = String.Empty
        Me.JobTitle = String.Empty
        Me.Status = String.Empty
        Me.LastPromationDate = DateTime.Now.Date
        Me.CurrentDegree = 0
        Me.CurrentStage = 0
        Me.CurrentSalary = 0
        Me.CurrentDate = DateTime.Now.Date
        Me.NextDegree = 0
        Me.NextStage = 0
        Me.NextSalary = 0
        Me.NextDate = DateTime.Now.Date
        Me.Note = String.Empty
        Me.AddedDate = DateTime.Now.Date
        Me.UpdatedDate = DateTime.Now.Date
        Me.UserID = String.Empty
        Mode = enMode.enAddNew
    End Sub
    Public Sub New(id As Integer, EmployeeID As Integer, fullName As String, jobTitle As String, status As String,
               lastPromationDate As DateTime, currentDegree As Integer, currentStage As Integer,
               currentSalary As Integer, currentDate As DateTime, nextDegree As Integer,
               nextStage As Integer, nextSalary As Integer, nextDate As DateTime, note As String,
               addedDate As DateTime, updatedDate As DateTime, userID As String)
        Me.ID = id
        Me.EmployeeID = EmployeeID
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
    Public Sub New(EDTO As clsEmployeesRecrodsDTO, cMode As enMode)
        Me.ID = EDTO.ID
        Me.EmployeeID = EDTO.EmployeeID
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
    Public Function GetAllEmployees() As List(Of clsEmployeesRecrodsDTO)
        Return EmployeeRecrodsDAL.GetAllData()
    End Function
    Public Function GetDataByUser(UserID As Integer) As List(Of clsEmployeesRecrodsDTO)
        Return EmployeeRecrodsDAL.GetDataByUser(UserID)
    End Function
    Public Function Find(ID As Integer) As clsEmployeesRecords
        Dim EDTO = EmployeeRecrodsDAL.Find(ID)
        If EDTO IsNot Nothing Then
            Return New clsEmployeesRecords(EDTO.ID, EDTO.EmployeeID, EDTO.FullName, EDTO.JobTitle, EDTO.Status, EDTO.LastPromationDate, EDTO.CurrentDegree, EDTO.CurrentStage,
                                    EDTO.CurrentSalary, EDTO.CurrentDate, EDTO.NextDegree, EDTO.NextStage, EDTO.NextSalary, EDTO.NextDate,
                                    EDTO.Note, EDTO.AddedDate, EDTO.UpdatedDate, EDTO.UserID)
        Else
            Return New clsEmployeesRecords()
        End If
    End Function
    'Public Function GetAllDataByID(ID As Integer) As List(Of clsEmployeesRecrodsDTO)
    '    Return clsEmployeesRecrodsDAL.GetDataByID(ID)
    'End Function
    Public Function _AddNewEmployee() As Boolean
        Me.ID = EmployeeRecrodsDAL.Add(ERDTO)
        Return (Me.ID <> -1)
    End Function
    Private Function _UpdateEmployee() As Boolean
        Return EmployeeRecrodsDAL.Edit(ERDTO)
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
        Return EmployeeRecrodsDAL.Delete(ID)
    End Function
End Class
