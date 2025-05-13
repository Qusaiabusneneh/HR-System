Imports System.Data.SqlClient
Public Class clsSystemRecordDTO
    Public Property ID As Integer
    Public Property UserFullName As String
    Public Property DeviceName As String
    Public Property Roles As String
    Public Property MachineID As String
    Public Property Title As String
    Public Property Description As String
    Public Property CreatedDate As DateTime
    Public Property UserID As String
    Public Sub New()
        ID = -1
        UserFullName = String.Empty
        DeviceName = String.Empty
        DeviceName = String.Empty
        Roles = String.Empty
        MachineID = String.Empty
        Title = String.Empty
        Description = String.Empty
        CreatedDate = DateTime.Now
        UserID = String.Empty
    End Sub
    Public Sub New(ID As Integer, UserFullName As String, DeviceName As String, Roles As String,
               MachineID As String, Title As String, Description As String,
               CreatedDate As DateTime, UserID As String)
        Me.ID = ID
        Me.UserFullName = UserFullName
        Me.DeviceName = DeviceName
        Me.Roles = Roles
        Me.MachineID = MachineID
        Me.Title = Title
        Me.Description = Description
        Me.CreatedDate = CreatedDate
        Me.UserID = UserID
    End Sub
End Class

Public Class SystemRecordDAL

    Implements ISystemRecordHelper(Of clsSystemRecordDTO)
    Public Function Add(systemRecord As clsSystemRecordDTO) As Integer Implements ISystemRecordHelper(Of clsSystemRecordDTO).Add
        Dim newID As Integer = -1
        Try
            Using connection As SqlConnection = clsConnectionString.GetConnection()
                connection.Open()

                Using command As New SqlCommand("SP_AddSystemRecord", connection)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@Title", If(systemRecord.Title, DBNull.Value))
                    command.Parameters.AddWithValue("@Description", If(systemRecord.Description, DBNull.Value))
                    command.Parameters.AddWithValue("@CreatedDate", systemRecord.CreatedDate)
                    command.Parameters.AddWithValue("@DeviceName", If(systemRecord.DeviceName, DBNull.Value))
                    command.Parameters.AddWithValue("@UserFullName", If(systemRecord.UserFullName, DBNull.Value))
                    command.Parameters.AddWithValue("@Roles", If(systemRecord.Roles, DBNull.Value))
                    command.Parameters.AddWithValue("@UserID", If(systemRecord.UserID, DBNull.Value))
                    command.Parameters.AddWithValue("@MachineID", If(systemRecord.MachineID, DBNull.Value))

                    Dim returnVal As New SqlParameter("@NewID", SqlDbType.Int)
                    returnVal.Direction = ParameterDirection.Output
                    command.Parameters.Add(returnVal)

                    command.ExecuteNonQuery()
                    newID = If(returnVal.Value IsNot DBNull.Value, CInt(returnVal.Value), -1)
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database Error in AddSystemRecord: {ex.Message}", EventLogEntryType.Error)
        End Try
        Return newID
    End Function
    Public Function Delete(ID As Integer) As Boolean Implements ISystemRecordHelper(Of clsSystemRecordDTO).Delete
        Dim rowsAffected As Boolean = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_DeleteSystemRecord", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Delete System Record ", EventLogEntryType.Error)
        End Try
        Return rowsAffected > 0
    End Function
    Public Function GetAllData() As List(Of clsSystemRecordDTO) Implements ISystemRecordHelper(Of clsSystemRecordDTO).GetAllData
        Dim Records As New List(Of clsSystemRecordDTO)
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_GetAllSystemRecords", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim ID As Integer = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0)
                            Dim UserFullName As String = If(Not reader.IsDBNull(reader.GetOrdinal("UserFullName")), reader.GetString(reader.GetOrdinal("UserFullName")), String.Empty)
                            Dim DeviceName As String = If(Not reader.IsDBNull(reader.GetOrdinal("DeviceName")), reader.GetString(reader.GetOrdinal("DeviceName")), String.Empty)
                            Dim Roles As String = If(Not reader.IsDBNull(reader.GetOrdinal("Roles")), reader.GetString(reader.GetOrdinal("Roles")), String.Empty)
                            Dim MachineID As String = If(Not reader.IsDBNull(reader.GetOrdinal("MachineID")), reader.GetString(reader.GetOrdinal("MachineID")), String.Empty)
                            Dim Title As String = If(Not reader.IsDBNull(reader.GetOrdinal("Title")), reader.GetString(reader.GetOrdinal("Title")), String.Empty)
                            Dim Description As String = If(Not reader.IsDBNull(reader.GetOrdinal("Description")), reader.GetString(reader.GetOrdinal("Description")), String.Empty)
                            Dim UserID As String = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            Dim CreatedDate As DateTime = If(Not reader.IsDBNull(reader.GetOrdinal("CreatedDate")), reader.GetDateTime(reader.GetOrdinal("CreatedDate")), DateTime.Now.Date)

                            Records.Add(New clsSystemRecordDTO(ID, UserFullName, DeviceName, Roles, MachineID, Title, Description, CreatedDate, UserID))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Get All System Record ", EventLogEntryType.Error)
        End Try

        Return Records
    End Function
    Public Function Find(ID As Integer) As clsSystemRecordDTO Implements ISystemRecordHelper(Of clsSystemRecordDTO).Find
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetSystemRecordByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Return New clsSystemRecordDTO(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("UserFullName")),
                            reader.GetString(reader.GetOrdinal("DeviceName")),
                            reader.GetString(reader.GetOrdinal("Roles")),
                            reader.GetString(reader.GetOrdinal("MachineID")),
                            reader.GetString(reader.GetOrdinal("Title")),
                            reader.GetString(reader.GetOrdinal("Description")),
                            reader.GetDateTime(reader.GetOrdinal("CreateadDate")),
                            reader.GetString(reader.GetOrdinal("UserID")))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Get System Record By ID ", EventLogEntryType.Error)
            Return Nothing
        End Try
    End Function

    Public Function GetDataByUser(UserID As String) As List(Of clsSystemRecordDTO) Implements ISystemRecordHelper(Of clsSystemRecordDTO).GetDataByUser
        Dim records As New List(Of clsSystemRecordDTO)()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetSystemRecordsByUserID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim record As New clsSystemRecordDTO() With {
                                .ID = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0),
                                .UserFullName = If(Not reader.IsDBNull(reader.GetOrdinal("UserFullName")), reader.GetString(reader.GetOrdinal("UserFullName")), ""),
                                .DeviceName = If(Not reader.IsDBNull(reader.GetOrdinal("DeviceName")), reader.GetString(reader.GetOrdinal("DeviceName")), ""),
                                .Roles = If(Not reader.IsDBNull(reader.GetOrdinal("Roles")), reader.GetString(reader.GetOrdinal("Roles")), ""),
                                .MachineID = If(Not reader.IsDBNull(reader.GetOrdinal("MachineID")), reader.GetString(reader.GetOrdinal("MachineID")), ""),
                                .Title = If(Not reader.IsDBNull(reader.GetOrdinal("Title")), reader.GetString(reader.GetOrdinal("Title")), ""),
                                .Description = If(Not reader.IsDBNull(reader.GetOrdinal("Description")), reader.GetString(reader.GetOrdinal("Description")), ""),
                                .CreatedDate = If(Not reader.IsDBNull(reader.GetOrdinal("CreatedDate")), reader.GetDateTime(reader.GetOrdinal("CreatedDate")), DateTime.MinValue),
                                .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), "")
                            }
                            records.Add(record)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in GetSystemRecordsByUserID: {ex.Message}", EventLogEntryType.Error)
        End Try

        Return records
    End Function

End Class

