Imports DataAccessTier

Public Class clsRetirements
    Public Enum enMode
        enAdd
        enUpdate
    End Enum
    Public Property Mode As enMode
    Public Property ID As Integer
    Public Property EmployeeID As Integer
    Public Property RetirementDate As Date
    Public Property Reason As String
    Public Property CreatedDate As DateTime
    Public Property UserID As String
    Public Property RDTO As New clsRetirementDTO(Me.ID, Me.EmployeeID, Me.RetirementDate, Me.Reason, Me.CreatedDate, Me.UserID)
    Public Property RetirementDAL As New clsRetirementDAL
    Public Sub New()
        Me.ID = -1
        Me.EmployeeID = -1
        Me.RetirementDate = Date.MinValue
        Me.Reason = String.Empty
        Me.CreatedDate = DateTime.MinValue
        Me.UserID = String.Empty
    End Sub

    Public Sub New(ID As Integer, EmployeeID As Integer, RetirementDate As Date, Reason As String, CreatedDate As DateTime, UserID As String)
        Me.ID = ID
        Me.EmployeeID = EmployeeID
        Me.RetirementDate = RetirementDate
        Me.Reason = Reason
        Me.CreatedDate = CreatedDate
        Me.UserID = UserID
    End Sub

    Public Function GetAllRetirements() As List(Of clsRetirementDTO)
        Return RetirementDAL.GetAllData()
    End Function

    Public Function Find(ID As Integer) As clsRetirements
        Dim RDTO = RetirementDAL.Find(ID)
        If RDTO IsNot Nothing Then
            Return New clsRetirements(RDTO.ID, RDTO.EmployeeID, RDTO.RetirementDate, RDTO.Reason, RDTO.CreatedDate, RDTO.UserID)
        Else
            Return Nothing
        End If
    End Function

    Public Function DeleteRetirement(ID As Integer) As Boolean
        Return RetirementDAL.Delete(ID)
    End Function

    Private Function _AddNewRetirement() As Integer
        Me.ID = RetirementDAL.Add(RDTO)
        Return (Me.ID <> -1)
    End Function

    Private Function _EditRetirement() As Boolean

        Return RetirementDAL.Edit(RDTO)
    End Function

    Public Function Save() As Boolean
        Select Case Mode
            Case enMode.enAdd
                If _AddNewRetirement() Then
                    Mode = enMode.enUpdate
                    Return True
                Else
                    Return False
                End If
            Case enMode.enUpdate
                Return _EditRetirement()
        End Select
        Return False
    End Function

    Public Function GetAllRetirementsByUserID(UserID As String) As List(Of clsRetirementDTO)
        Return RetirementDAL.GetDataByUser(UserID)
    End Function
End Class
