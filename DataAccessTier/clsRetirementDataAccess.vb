Imports System.Data.SqlClient
Imports DataAccessTier.DataAccessTier.DataAccessTools
Public Class clsRetirementDTO
    Public Property ID As Integer
    Public Property EmployeeID As Integer
    Public Property RetirementDate As Date
    Public Property Reason As String
    Public Property CreatedDate As DateTime
    Public Property UserID As String
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
End Class

Public Class clsRetirementDAL
    Implements IDataHelper(Of clsRetirementDTO)
    Public Function Edit(table As clsRetirementDTO) As Boolean Implements IDataHelper(Of clsRetirementDTO).Edit
        Dim RowsAffected As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_EditRetirements", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", table.ID)
                    command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    command.Parameters.AddWithValue("@RetirementDate", table.RetirementDate)
                    command.Parameters.AddWithValue("@Reason", table.Reason)
                    command.Parameters.AddWithValue("@CreatedDate", table.CreatedDate)
                    command.Parameters.AddWithValue("@UserID", table.UserID)
                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_EditRetirements  : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return (RowsAffected > 0)
    End Function

    Public Function Add(table As clsRetirementDTO) As Integer Implements ISystemRecordHelper(Of clsRetirementDTO).Add
        Dim NewID As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using Command As New SqlCommand("SP_AddRetirements", connection)
                    Command.CommandType = CommandType.StoredProcedure

                    Command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    Command.Parameters.AddWithValue("@RetirementDate", table.RetirementDate)
                    Command.Parameters.AddWithValue("@Reason", table.Reason)
                    Command.Parameters.AddWithValue("@CreatedDate", table.CreatedDate)
                    Command.Parameters.AddWithValue("@UserID", table.UserID)
                    Dim ReturnParameter As SqlParameter = Command.Parameters.Add("@NewID", SqlDbType.Int)
                    ReturnParameter.Direction = ParameterDirection.Output
                    Command.ExecuteNonQuery()
                    NewID = Convert.ToInt32(ReturnParameter.Value)
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_AddRetirements  : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return NewID
    End Function

    Public Function Delete(ID As Integer) As Boolean Implements ISystemRecordHelper(Of clsRetirementDTO).Delete
        Dim RowsAffected As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_DeleteRetirements", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_DeleteRetirements  : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return (RowsAffected > 0)
    End Function

    Public Function GetAllData() As List(Of clsRetirementDTO) Implements ISystemRecordHelper(Of clsRetirementDTO).GetAllData
        Dim retirementList As New List(Of clsRetirementDTO)
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_GetAllRetirements", connection)
                    command.CommandType = CommandType.StoredProcedure
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim RDTO As New clsRetirementDTO(
                                reader.GetInt32(reader.GetOrdinal("ID")),
                                reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                reader.GetDateTime(reader.GetOrdinal("RetirementDate")),
                                reader.GetString(reader.GetOrdinal("Reason")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                reader.GetString(reader.GetOrdinal("UserID"))
                                )
                            retirementList.Add(RDTO)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_GetAllRetirements  : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return retirementList
    End Function

    Public Function Find(ID As Integer) As clsRetirementDTO Implements ISystemRecordHelper(Of clsRetirementDTO).Find
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_GetRetirementsInfoByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If (reader.Read()) Then
                            Return New clsRetirementDTO(reader.GetInt32(reader.GetOrdinal("ID")),
                                        reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                        reader.GetDateTime(reader.GetOrdinal("RetirementDate")),
                                        reader.GetString(reader.GetOrdinal("Reason")),
                                        reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                        reader.GetString(reader.GetOrdinal("UserID"))
                                        )
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_GetRetirementsInfoByID  : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return Nothing
    End Function

    Public Function GetDataByUser(UserID As String) As List(Of clsRetirementDTO) Implements ISystemRecordHelper(Of clsRetirementDTO).GetDataByUser
        Dim retirementList As New List(Of clsRetirementDTO)
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_GetAllRetirementsByUserID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim RDTO As New clsRetirementDTO(
                                reader.GetInt32(reader.GetOrdinal("ID")),
                                reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                reader.GetDateTime(reader.GetOrdinal("RetirementDate")),
                                reader.GetString(reader.GetOrdinal("Reason")),
                                reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                reader.GetString(reader.GetOrdinal("UserID"))
                                )
                            retirementList.Add(RDTO)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_GetAllRetirementsByUserID  : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return retirementList
    End Function
End Class
