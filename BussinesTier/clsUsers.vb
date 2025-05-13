Imports System
Imports DataAccessTier

Namespace HR_System.Core
    Public Class clsUsers
        Public Enum enMode
            enAdd
            enUpdate
        End Enum
        Public Mode As enMode = enMode.enAdd

        Public Property ID As Integer
        Public Property FullName As String
        Public Property Username As String
        Public Property Password As String
        Public Property Phone As String
        Public Property IsSecondaryUser As Boolean
        Public Property UserID As String
        Public Property Email As String
        Public Property Address As String
        Public Property Role As String
        Public Property CreatedDate As DateTime
        Public Property EditedDate As DateTime
        Public Function GetUserDTO() As clsUserDTO
            Dim hashedPassword As String = clsHashing.ComputeHashing(Me.Password)
            Return New clsUserDTO(Me.ID, Me.FullName, Me.Username, hashedPassword, Me.Phone, Me.Email,
                          Me.Address, Me.Role, Me.CreatedDate, Me.EditedDate, Me.UserID, Me.IsSecondaryUser)
        End Function

        Public Sub New()
            ID = Nothing
            FullName = String.Empty
            Username = String.Empty
            Password = String.Empty
            Phone = String.Empty
            Email = String.Empty
            Address = String.Empty
            Role = String.Empty
            UserID = String.Empty
            IsSecondaryUser = False
            CreatedDate = DateTime.MinValue
            EditedDate = DateTime.MinValue
            Mode = enMode.enAdd
        End Sub

        Public Sub New(iD As Integer, fullName As String, username As String, password As String, phone As String, email As String, role As String, createdDate As Date, editedDate As Date, userID As String, isSecondaryUser As Boolean)
            Me.ID = iD
            Me.FullName = fullName
            Me.Username = username
            Me.Password = password
            Me.Phone = phone
            Me.Email = email
            Me.Role = role
            Me.CreatedDate = createdDate
            Me.EditedDate = editedDate
            Me.UserID = userID
            Me.IsSecondaryUser = isSecondaryUser
            Mode = enMode.enUpdate
        End Sub

        Public Sub New(UDTO As clsUserDTO, cMode As enMode)
            Me.ID = UDTO.ID
            Me.FullName = UDTO.FullName
            Me.Username = UDTO.Username
            Me.Password = UDTO.Password
            Me.Phone = UDTO.Phone
            Me.Email = UDTO.Email
            Me.Address = UDTO.Address
            Me.Role = UDTO.Role
            Me.CreatedDate = UDTO.CreatedDate
            Me.EditedDate = UDTO.EditedDate
            Me.UserID = UDTO.UserID
            Me.IsSecondaryUser = UDTO.IsSecondaryUser
            Mode = cMode

        End Sub

        Public Shared Function GetAllUser() As List(Of clsUserDTO)
            Return clsUsersDAL.GetAllUsers()
        End Function

        Public Shared Function Find(ID As Integer) As clsUsers
            Dim UDTO As clsUserDTO = clsUsersDAL.GetUserInfoByID(ID)
            If UDTO IsNot Nothing Then
                Dim user As New clsUsers(UDTO, cMode:=enMode.enUpdate)
                Return user
            Else
                Return Nothing
            End If

        End Function

        Public Shared Function GetAllUsernames() As List(Of clsUserDTO)
            Return clsUsersDAL.GetAllUsernames()
        End Function

        Private Function _AddNewUser() As Boolean
            Me.ID = clsUsersDAL.AddNewUsers(Me.GetUserDTO)
            Return Me.ID <> -1
        End Function

        Private Function _UpdateUser() As Boolean
            Return clsUsersDAL.UpdateUser(Me.GetUserDTO)
        End Function

        Public Shared Function Delete(ID As Integer) As Boolean
            Return clsUsersDAL.DeleteUser(ID)
        End Function

        Public Function Save() As Boolean
            Select Case Mode
                Case enMode.enAdd
                    If _AddNewUser() Then
                        Mode = enMode.enUpdate
                        Return True
                    Else
                        Return False
                    End If
                Case enMode.enUpdate
                    Return _UpdateUser()
            End Select
            Return False
        End Function
    End Class
End Namespace
