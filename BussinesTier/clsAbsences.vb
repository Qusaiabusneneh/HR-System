Imports DataAccessTier

Public Class clsAbsences
    Public Enum enMode
        enAdd
        enUpdate
    End Enum
    Public Property Mode As enMode
    Public Property ID As Integer
    Public Property EmployeeID As Integer
    Public Property AbsenceDate As DateTime
    Public Property Duration As String ' Duration in hours -- e.g., "Full Day", "Half Day", "2 hours"
    Public Property AbsenceType As String
    Public Property Note As String
    Public Property AddedDate As DateTime
    Public Property UserID As String
    Public Property AbsencesDAL As clsAbsencesDataAccess = New clsAbsencesDataAccess()
    Public Property ADTO As New clsAbsencesDTO(Me.ID, Me.EmployeeID, Me.AbsenceDate, Me.Duration, Me.AbsenceType, Me.Note, Me.AddedDate, Me.UserID)
    Public Sub New()
        ID = -1
        EmployeeID = -1
        AbsenceDate = DateTime.Now
        Duration = ""
        AbsenceType = ""
        Note = ""
        AddedDate = DateTime.Now
        UserID = ""
        Mode = enMode.enAdd
    End Sub
    Public Sub New(ID As Integer, EmployeeID As Integer, AbsenceDate As DateTime, Duration As String, AbsenceType As String, Note As String, AddedDate As DateTime, UserID As String)
        Me.ID = ID
        Me.EmployeeID = EmployeeID
        Me.AbsenceDate = AbsenceDate
        Me.Duration = Duration
        Me.AbsenceType = AbsenceType
        Me.Note = Note
        Me.AddedDate = AddedDate
        Me.UserID = UserID
        Mode = enMode.enUpdate
    End Sub
    Public Sub New(AbsenceDTO As clsAbsencesDTO, cMode As enMode)
        Me.ID = AbsenceDTO.ID
        Me.EmployeeID = AbsenceDTO.EmployeeID
        Me.AbsenceDate = AbsenceDTO.AbsenceDate
        Me.Duration = AbsenceDTO.Duration
        Me.AbsenceType = AbsenceDTO.AbsenceType
        Me.Note = AbsenceDTO.Note
        Me.AddedDate = AbsenceDTO.AddedDate
        Me.UserID = AbsenceDTO.UserID
        Me.Mode = cMode
    End Sub
    Public Function GetAllData() As List(Of clsAbsencesDTO)
        Return AbsencesDAL.GetAllData()
    End Function
    Public Function Find(ID As Integer) As clsAbsences
        Dim ADTO = AbsencesDAL.Find(ID)
        If ADTO IsNot Nothing Then
            Return New clsAbsences(ADTO.ID, ADTO.EmployeeID, ADTO.AbsenceDate, ADTO.Duration, ADTO.AbsenceType, ADTO.Note, ADTO.AddedDate, ADTO.UserID)
        Else
            Return Nothing
        End If
    End Function
    Private Function _AddNewAbsence() As Boolean
        Me.ID = AbsencesDAL.Add(Me.ADTO)
        Return Me.ID <> -1
    End Function
    Private Function _EditAbsence() As Boolean
        Return AbsencesDAL.Edit(Me.ADTO)
    End Function
    Public Function Save() As Boolean
        Select Case Mode

            Case enMode.enAdd
                If _AddNewAbsence() Then
                    Mode = enMode.enUpdate
                    Return True
                Else
                    Return False
                End If

            Case enMode.enUpdate
                Return _EditAbsence()
        End Select
        Return False
    End Function
    Public Function Delete(ID As Integer) As Boolean
        Return AbsencesDAL.Delete(ID)
    End Function
End Class
