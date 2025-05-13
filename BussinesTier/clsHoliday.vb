Imports DataAccessTier
Public Class clsHoliday
    Public Enum enMode
        enAdd
        enUpdate
    End Enum
    Public Property Mode As enMode
    Public Property ID As Integer
    Public Property EmployeeID As Integer
    Public Property HolidayDate As DateTime
    Public Property Reason As String
    Public Property Duration As Integer ' In days
    Public Property Note As String
    Public Property AddedDate As DateTime
    Public Property UserID As String
    Public Property HDTO As New clsHolidayDTO(Me.ID, Me.EmployeeID, Me.HolidayDate, Me.Reason, Me.Duration, Me.Note, Me.AddedDate, Me.UserID)
    Public Property HolidayDAL As New clsHoldidayDAL()
    Public Sub New()
        ID = -1
        EmployeeID = -1
        HolidayDate = DateTime.Now
        Reason = String.Empty
        Duration = 0
        Note = String.Empty
        AddedDate = DateTime.Now
        UserID = String.Empty
        Mode = enMode.enAdd
    End Sub
    Public Sub New(ID As Integer, EmployeeID As Integer, HolidayDate As String, Reason As String,
                   Duration As Integer, Note As String, AddedDate As DateTime, UserID As String)
        Me.ID = ID
        Me.EmployeeID = EmployeeID
        Me.HolidayDate = HolidayDate
        Me.Reason = Reason
        Me.Duration = Duration
        Me.Note = Note
        Me.AddedDate = AddedDate
        Me.UserID = UserID
        Mode = enMode.enUpdate
    End Sub
    Public Sub New(HDTO As clsHolidayDTO, cMode As enMode)
        Me.ID = HDTO.ID
        Me.EmployeeID = HDTO.EmployeeID
        Me.Reason = HDTO.Reason
        Me.HolidayDate = HDTO.HolidayDate
        Me.Reason = HDTO.Reason
        Me.Duration = HDTO.Duration
        Me.Note = HDTO.Note
        Me.AddedDate = HDTO.AddedDate
        Me.UserID = HDTO.UserID
        Me.Mode = cMode
    End Sub
    Public Function GetAllHolidays() As List(Of clsHolidayDTO)
        Return HolidayDAL.GetAllData()
    End Function
    Public Function Find(ID As Integer) As clsHoliday
        Dim HDTO = HolidayDAL.Find(ID)
        If HDTO IsNot Nothing Then
            Return New clsHoliday(HDTO.ID, HDTO.EmployeeID, HDTO.HolidayDate, HDTO.Reason, HDTO.Duration, HDTO.Note, HDTO.AddedDate, HDTO.UserID)
        Else
            Return Nothing
        End If
    End Function
    Private Function _AddNewHolidays() As Boolean
        Me.ID = HolidayDAL.Add(HDTO)
        Return (ID <> -1)
    End Function
    Private Function _EditHolidays() As Boolean
        Return HolidayDAL.Edit(HDTO)
    End Function
    Public Function Save() As Boolean
        Select Case Mode
            Case enMode.enAdd
                If _AddNewHolidays() Then
                    Mode = enMode.enUpdate
                    Return True
                Else
                    Return False
                End If
            Case enMode.enUpdate
                Return _EditHolidays()
        End Select
        Return False
    End Function
    Public Function DeleteHolidays(ID As Integer)
        Return HolidayDAL.Delete(ID)
    End Function
    Public Function GetAllHolidaysByUserID(UserID As String)
        Return HolidayDAL.GetDataByUser(UserID)
    End Function

End Class
