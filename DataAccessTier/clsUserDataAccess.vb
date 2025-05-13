Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class clsUserDTO
    Public Property ID As Integer
    Public Property FullName As String
    Public Property Username As String
    Public Property Password As String
    Public Property Phone As String
    Public Property Email As String
    Public Property Address As String
    Public Property Role As String
    Public Property CreatedDate As DateTime
    Public Property EditedDate As DateTime
    Public Property UserID As String
    Public Property IsSecondaryUser As Boolean
    Public Sub New()
        ID = 0
        FullName = String.Empty
        Username = String.Empty
        Password = String.Empty
        Phone = String.Empty
        Email = String.Empty
        Address = String.Empty
        Role = String.Empty
        CreatedDate = DateTime.MinValue
        EditedDate = DateTime.MinValue
        UserID = String.Empty
        IsSecondaryUser = False
    End Sub
    Public Sub New(id As Integer, fullName As String, username As String, password As String, phone As String, email As String,
               address As String, role As String, createdDate As DateTime, editedDate As DateTime,
               userID As String, isSecondaryUser As Boolean)
        Me.ID = id
        Me.FullName = fullName
        Me.Username = username
        Me.Password = password
        Me.Phone = phone
        Me.Email = email
        Me.Address = address
        Me.Role = role
        Me.CreatedDate = createdDate
        Me.EditedDate = editedDate
        Me.UserID = userID
        Me.IsSecondaryUser = isSecondaryUser
    End Sub
End Class

Public Class clsUsersDAL
    Public Shared Function AddNewUsers(user As clsUserDTO) As Integer?
        Dim newID As Integer? = Nothing

        Try
            Using connection As SqlConnection = clsConnectionString.GetConnection()
                connection.Open()

                Using command As New SqlCommand("SP_AddNewUser", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@FullName", If(user.FullName, String.Empty))
                    command.Parameters.AddWithValue("@Username", If(user.Username, String.Empty))
                    command.Parameters.AddWithValue("@Password", If(user.Password, String.Empty))
                    command.Parameters.AddWithValue("@Phone", user.Phone)
                    command.Parameters.AddWithValue("@Email", user.Email)
                    command.Parameters.AddWithValue("@Address", user.Address)
                    command.Parameters.AddWithValue("@Role", user.Role)
                    command.Parameters.AddWithValue("@createdDate", user.CreatedDate)
                    command.Parameters.AddWithValue("@editedDate", user.EditedDate)
                    command.Parameters.AddWithValue("@UserID", user.UserID)
                    command.Parameters.AddWithValue("@IsSecondaryUser", user.IsSecondaryUser)

                    Dim returnVal As New SqlParameter("@NewID", SqlDbType.Int)
                    returnVal.Direction = ParameterDirection.Output
                    command.Parameters.Add(returnVal)

                    command.ExecuteNonQuery()
                    newID = If(returnVal.Value IsNot DBNull.Value, CInt(returnVal.Value), Nothing)
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database Error in AddNewUsers: {ex.Message}", EventLogEntryType.Error)
        End Try

        Return newID
    End Function

    Public Shared Function GetAllUsers() As List(Of clsUserDTO)
        Dim users As New List(Of clsUserDTO)()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_GetAllUsers", connection)
                    command.CommandType = CommandType.StoredProcedure
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim user As New clsUserDTO With {
                                .ID = Convert.ToInt32(reader("ID")),
                                .FullName = reader("FullName").ToString(),
                                .Username = reader("Username").ToString(),
                                .Password = reader("Password").ToString(),
                                .Phone = reader("Phone").ToString(),
                                .Email = reader("Email").ToString(),
                                .Address = reader("Address").ToString(),
                                .Role = reader("Role").ToString(),
                                .CreatedDate = If(IsDBNull(reader("CreatedDate")), DateTime.MinValue, Convert.ToDateTime(reader("CreatedDate"))),
                                .EditedDate = If(IsDBNull(reader("EditedDate")), DateTime.MinValue, Convert.ToDateTime(reader("EditedDate"))),
                                .UserID = reader("UserID").ToString(),
                                .IsSecondaryUser = Convert.ToBoolean(reader("IsSecondaryUser"))
                            }
                            users.Add(user)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return users
    End Function

    Public Shared Function UpdateUser(user As clsUserDTO) As Boolean
        Dim RowsAffected As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_UpdateUser", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", user.ID)
                    command.Parameters.AddWithValue("@FullName", user.FullName)
                    command.Parameters.AddWithValue("@Username", user.Username)
                    command.Parameters.AddWithValue("@Password", user.Password)
                    command.Parameters.AddWithValue("@Email", user.Email)
                    command.Parameters.AddWithValue("@Phone", user.Phone)
                    command.Parameters.AddWithValue("@Address", user.Address)
                    command.Parameters.AddWithValue("@Role", user.Role)
                    command.Parameters.AddWithValue("@EditedDate", user.EditedDate)
                    command.Parameters.AddWithValue("@CreatedDate", user.CreatedDate)
                    command.Parameters.AddWithValue("@UserID", user.UserID)
                    command.Parameters.AddWithValue("@IsSecondaryUser", user.IsSecondaryUser)
                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error : " + ex.Message)
        End Try
        Return RowsAffected > 0
    End Function

    Public Shared Function GetUserInfoByID(ID As Integer) As clsUserDTO
        Dim user As clsUserDTO = Nothing

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetUserInfoByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            user = New clsUserDTO With {
                                .ID = ID,
                                .FullName = reader("FullName").ToString(),
                                .Username = reader("Username").ToString(),
                                .Phone = reader("Phone").ToString(),
                                .Email = reader("Email").ToString(),
                                .Address = reader("Address").ToString(),
                                .Role = reader("Role").ToString(),
                                .CreatedDate = If(IsDBNull(reader("CreatedDate")), DateTime.MinValue, Convert.ToDateTime(reader("CreatedDate"))),
                                .EditedDate = If(IsDBNull(reader("EditedDate")), DateTime.MinValue, Convert.ToDateTime(reader("EditedDate"))),
                                .UserID = reader("UserID").ToString(),
                                .IsSecondaryUser = Convert.ToBoolean(reader("IsSecondaryUser"))
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
        Return user
    End Function

    Public Shared Function DeleteUser(ID As Integer) As Boolean
        Dim RowsAffected As Boolean = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_DeleteUser", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    RowsAffected = command.ExecuteNonQuery()
                End Using

            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Delete User ", EventLogEntryType.Error)
        End Try

        Return RowsAffected > 0
    End Function

    Public Shared Function GetAllUsernames() As List(Of clsUserDTO)
        Dim users As New List(Of clsUserDTO)()
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_GetAllUsernamesFromUser", connection)
                    command.CommandType = CommandType.StoredProcedure
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim user As New clsUserDTO With {
                                .ID = Convert.ToInt32(reader("ID")),
                                .Username = reader("Username").ToString()
                                }
                            users.Add(user)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in GetAllUsers: {ex.Message}", EventLogEntryType.Error)
        End Try
        Return users
    End Function
End Class

