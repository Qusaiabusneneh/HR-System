Imports DataAccessTier

Public Class clsBookThanks
    Public Enum enMode
        enAdd
        enUpdate
    End Enum
    Public Property Mode As enMode
    Public Property ID As Integer
    Public Property EffectValue As Integer
    Public Property Reference As String
    Public Property AppreciationDate As DateTime
    Public Property Description As String
    Public Property AddedDate As DateTime
    Public Property EmployeeID As String
    Public Property UserID As String
    Public Property bookThanksDTO As New clsBookThanksDTO(Me.ID, Me.EffectValue, Me.Reference, Me.AppreciationDate,
                                                          Me.Description, Me.AddedDate, Me.EmployeeID, Me.UserID)
    Public Property BookThanksDAL As New clsBookThanksDAL
    Public Sub New()
        Me.ID = -1
        Me.EffectValue = 0
        Me.Reference = String.Empty
        Me.AppreciationDate = DateTime.Now
        Me.Description = String.Empty
        Me.AddedDate = DateTime.Now
        Me.EmployeeID = String.Empty
        Me.UserID = String.Empty
        Me.Mode = enMode.enAdd
    End Sub
    Public Sub New(ID As Integer, EffectValue As Integer, Reference As String, AppreciationDate As DateTime,
               Description As String, AddedDate As DateTime, EmployeeID As String, UserID As String)
        Me.ID = ID
        Me.EffectValue = EffectValue
        Me.Reference = Reference
        Me.AppreciationDate = AppreciationDate
        Me.Description = Description
        Me.AddedDate = AddedDate
        Me.EmployeeID = EmployeeID
        Me.UserID = UserID
        Me.Mode = enMode.enUpdate
    End Sub
    Public Sub New(BTDTO As clsBookThanksDTO, cMode As enMode)
        Me.ID = BTDTO.ID
        Me.EffectValue = BTDTO.EffectValue
        Me.Reference = BTDTO.Reference
        Me.AppreciationDate = BTDTO.AppreciationDate
        Me.Description = BTDTO.Description
        Me.AddedDate = BTDTO.AddedDate
        Me.EmployeeID = BTDTO.EmployeeID
        Me.UserID = BTDTO.UserID
        Me.Mode = cMode
    End Sub
    Public Function GetAllData() As List(Of clsBookThanksDTO)
        Return BookThanksDAL.GetAllData()
    End Function
    Public Function Find(ID As Integer) As clsBookThanks
        Dim currentBookDTO = BookThanksDAL.Find(ID)
        If currentBookDTO IsNot Nothing Then
            Return New clsBookThanks(currentBookDTO.ID, currentBookDTO.EffectValue, currentBookDTO.Reference, currentBookDTO.AppreciationDate,
                                     currentBookDTO.Description, currentBookDTO.AddedDate, currentBookDTO.EmployeeID, currentBookDTO.UserID)
        Else
            Return New clsBookThanks()
        End If
    End Function
    Public Function GetDataByUserID(UserID As String) As List(Of clsBookThanksDTO)
        Return BookThanksDAL.GetDataByUser(UserID)
    End Function
    Private Function _AddBookThanks() As Boolean
        Me.ID = BookThanksDAL.Add(bookThanksDTO)
        Return (Me.ID <> -1)
    End Function
    Private Function _UpdateBookThanks() As Boolean
        Return BookThanksDAL.Edit(bookThanksDTO)
    End Function
    Public Function Save() As Boolean
        Select Case Mode
            Case enMode.enAdd

                If _AddBookThanks() Then
                    Mode = enMode.enUpdate
                    Return True
                Else
                    Return False
                End If

            Case enMode.enUpdate
                Return _UpdateBookThanks()
        End Select

        Return False
    End Function
    Public Function DeleteBookThanks(ID As Integer) As Boolean
        Return BookThanksDAL.Delete(ID)
    End Function
End Class
