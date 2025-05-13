Imports System.Data.SqlClient
Imports DataAccessTier.DataAccessTier.DataAccessTools

Public Class clsBookThanksDTO
    Public Property ID As Integer
    Public Property EffectValue As Integer
    Public Property Reference As String
    Public Property AppreciationDate As DateTime
    Public Property Description As String
    Public Property AddedDate As DateTime
    Public Property EmployeeID As String
    Public Property UserID As String
    Public Sub New()
        Me.ID = -1
        Me.EffectValue = 0
        Me.Reference = String.Empty
        Me.AppreciationDate = DateTime.Now
        Me.Description = String.Empty
        Me.AddedDate = DateTime.Now
        Me.EmployeeID = String.Empty
        Me.UserID = String.Empty
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
    End Sub
End Class
Public Class clsBookThanksDAL
    Implements IDataHelper(Of clsBookThanksDTO)
    Public Function Edit(table As clsBookThanksDTO) As Boolean Implements IDataHelper(Of clsBookThanksDTO).Edit
        Dim rowsAffected As Integer = 0

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_EditBookThanks", connection)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@ID", table.ID)
                    command.Parameters.AddWithValue("@EffectValue", table.EffectValue)
                    command.Parameters.AddWithValue("@Reference", If(String.IsNullOrEmpty(table.Reference), DBNull.Value, table.Reference))
                    command.Parameters.AddWithValue("@AppreciationDate", table.AppreciationDate)
                    command.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(table.Description), DBNull.Value, table.Description))
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@EmployeeID", If(String.IsNullOrEmpty(table.EmployeeID), DBNull.Value, table.EmployeeID))
                    command.Parameters.AddWithValue("@UserID", If(String.IsNullOrEmpty(table.UserID), DBNull.Value, table.UserID))
                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in SP_EditBookThanks: " & ex.Message, EventLogEntryType.Error)
        End Try
        Return rowsAffected > 0
    End Function
    Public Function Add(table As clsBookThanksDTO) As Integer Implements ISystemRecordHelper(Of clsBookThanksDTO).Add
        Dim NewID As Integer = 0

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_AddBookThanks", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@EffectValue", table.EffectValue)
                    command.Parameters.AddWithValue("@Reference", If(String.IsNullOrEmpty(table.Reference), DBNull.Value, table.Reference))
                    command.Parameters.AddWithValue("@AppreciationDate", table.AppreciationDate)
                    command.Parameters.AddWithValue("@Description", If(String.IsNullOrEmpty(table.Description), DBNull.Value, table.Description))
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@EmployeeID", If(String.IsNullOrEmpty(table.EmployeeID), DBNull.Value, table.EmployeeID))
                    command.Parameters.AddWithValue("@UserID", If(String.IsNullOrEmpty(table.UserID), DBNull.Value, table.UserID))

                    Dim returnParam As New SqlParameter("@NewID", SqlDbType.Int)
                    returnParam.Direction = ParameterDirection.Output
                    command.Parameters.Add(returnParam)
                    command.ExecuteNonQuery()

                    NewID = Convert.ToInt32(returnParam.Value)
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in SP_AddBookThanks: " & ex.Message, EventLogEntryType.Error)
        End Try

        Return NewID
    End Function
    Public Function Delete(ID As Integer) As Boolean Implements ISystemRecordHelper(Of clsBookThanksDTO).Delete
        Dim rowsAffected As Integer = 0

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_DeleteBookThanks", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in SP_DeleteBookThanks: " & ex.Message, EventLogEntryType.Error)
        End Try
        Return (rowsAffected > 0)
    End Function
    Public Function GetAllData() As List(Of clsBookThanksDTO) Implements ISystemRecordHelper(Of clsBookThanksDTO).GetAllData
        Dim result As New List(Of clsBookThanksDTO)()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetAllBookThanks", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim bookThanks As New clsBookThanksDTO() With {
                            .ID = Convert.ToInt32(reader("ID")),
                            .EffectValue = Convert.ToInt32(reader("EffectValue")),
                            .Reference = Convert.ToString(reader("Reference")),
                            .AppreciationDate = Convert.ToDateTime(reader("AppreciationDate")),
                            .Description = Convert.ToString(reader("Description")),
                            .AddedDate = Convert.ToDateTime(reader("AddedDate")),
                            .EmployeeID = Convert.ToString(reader("EmployeeID")),
                            .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                        }
                            result.Add(bookThanks)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in SP_GetAllBookThanks: " & ex.Message, EventLogEntryType.Error)
        End Try
        Return result
    End Function
    Public Function Find(ID As Integer) As clsBookThanksDTO Implements ISystemRecordHelper(Of clsBookThanksDTO).Find
        Dim result As clsBookThanksDTO = Nothing

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetBookThanksByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            result = New clsBookThanksDTO() With {
                            .ID = Convert.ToInt32(reader("ID")),
                            .EffectValue = Convert.ToInt32(reader("EffectValue")),
                            .Reference = Convert.ToString(reader("Reference")),
                            .AppreciationDate = Convert.ToDateTime(reader("AppreciationDate")),
                            .Description = Convert.ToString(reader("Description")),
                            .AddedDate = Convert.ToDateTime(reader("AddedDate")),
                            .EmployeeID = Convert.ToString(reader("EmployeeID")),
                            .UserID = Convert.ToString(reader("UserID"))
                        }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in SP_FindBookThanksByID: " & ex.Message, EventLogEntryType.Error)
        End Try
        Return result
    End Function
    Public Function GetDataByUser(UserID As String) As List(Of clsBookThanksDTO) Implements ISystemRecordHelper(Of clsBookThanksDTO).GetDataByUser
        Dim result As New List(Of clsBookThanksDTO)()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetBookThanksByUserID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim item As New clsBookThanksDTO() With {
                                .ID = Convert.ToInt32(reader("ID")),
                                .EffectValue = Convert.ToInt32(reader("EffectValue")),
                                .Reference = Convert.ToString(reader("Reference")),
                                .AppreciationDate = Convert.ToDateTime(reader("AppreciationDate")),
                                .Description = Convert.ToString(reader("Description")),
                                .AddedDate = Convert.ToDateTime(reader("AddedDate")),
                                .EmployeeID = Convert.ToString(reader("EmployeeID")),
                                .UserID = Convert.ToString(reader("UserID"))
                            }
                            result.Add(item)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in SP_GetBookThanksByUserID: " & ex.Message, EventLogEntryType.Error)
        End Try
        Return result
    End Function

End Class
