Imports Confluent.Kafka
Imports DataAccessTier

Public Class clsSalaryRates
    Public Enum enMode
        enAdd
        enUpdate
    End Enum
    Public Property Mode As enMode = enMode.enAdd
    Public Property ID As Integer
    Public Property Degree As Integer
    Public Property Salary As Double
    Public Property BounsYearRate As Double
    Public Property PromationYear As Integer
    Public Property UserID As String
    Private Property salartRateDAL As clsSalaryRatesDataAcess = New clsSalaryRatesDataAcess
    Public Property salaryDTO As New clsSalaRateDTO(Me.ID, Me.Degree, Me.Salary, Me.BounsYearRate, Me.PromationYear, Me.UserID)
    Public Sub New()
        Me.ID = -1
        Me.Degree = 0
        Me.Salary = 0
        Me.BounsYearRate = 0
        Me.PromationYear = 0
        Me.UserID = String.Empty
        Mode = enMode.enAdd
    End Sub
    Public Sub New(ID As Integer, Degree As Integer, Salary As Integer, BounsYearRate As Double, PromationYear As Integer, UserID As String)
        Me.ID = ID
        Me.Salary = Salary
        Me.Degree = Degree
        Me.BounsYearRate = BounsYearRate
        Me.PromationYear = PromationYear
        Me.UserID = UserID
        Mode = enMode.enUpdate
    End Sub
    Public Sub New(SDTO As clsSalaRateDTO, cMode As enMode)
        Me.ID = SDTO.ID
        Me.Salary = SDTO.Salary
        Me.Degree = SDTO.Degree
        Me.BounsYearRate = SDTO.BounsYearRate
        Me.PromationYear = SDTO.PromationYear
        Me.UserID = SDTO.UserID
        Me.Mode = cMode
    End Sub
    Public Function GetAllSalaryRates() As List(Of clsSalaRateDTO)
        Try
            Return salartRateDAL.GetAllData()
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in GetAllSalaryRates: {ex.Message}", EventLogEntryType.Error)
            Throw New Exception("An error occurred while retrieving salary rates.")
        End Try
    End Function
    Public Function GetDataByUser(UserID As String) As List(Of clsSalaRateDTO)
        Return salartRateDAL.GetDataByUser(UserID)
    End Function
    Public Function Find(ID As Integer) As clsSalaryRates
        Try
            Dim SDTO = salartRateDAL.GetSalayRateByID(ID)
            If SDTO IsNot Nothing Then
                Return New clsSalaryRates(SDTO.ID, SDTO.Degree, SDTO.Salary, SDTO.BounsYearRate, SDTO.PromationYear, SDTO.UserID)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in FindSalaryRateByID: {ex.Message}", EventLogEntryType.Error)
            Throw New Exception("An error occurred while retrieving the salary rate by ID.")
        End Try
    End Function
    Private Function _AddNewSalaryRates() As Boolean
        Me.ID = salartRateDAL.Add(salaryDTO)
        Return (Me.ID <> -1)
    End Function
    Private Function _UpdateSalaryRate() As Boolean
        Return salartRateDAL.Edit(salaryDTO)
    End Function
    Public Function Save() As Boolean
        Select Case Mode
            Case enMode.enAdd
                If _AddNewSalaryRates() Then
                    Mode = enMode.enUpdate
                    Return True
                Else
                    Return False
                End If

            Case enMode.enUpdate
                Return _UpdateSalaryRate()
        End Select

        Return False
    End Function
    Public Function DeleteSalaryRates(ID As Integer)
        Return salartRateDAL.Delete(ID)
    End Function
End Class
