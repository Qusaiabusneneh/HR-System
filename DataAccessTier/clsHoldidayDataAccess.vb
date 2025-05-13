Imports System.Data.SqlClient
Imports DataAccessTier.DataAccessTier.DataAccessTools
Public Class clsHolidayDTO
    Public Property ID As Integer
    Public Property Reason As String
    Public Property Duration As Integer ' In days
    Public Property Note As String
    Public Property HolidayDate As DateTime
    Public Property AddedDate As DateTime
    Public Property EmployeeID As Integer
    Public Property UserID As String
    Public Sub New()
        Me.ID = -1
        Me.EmployeeID = -1
        Me.HolidayDate = DateTime.Now
        Me.Reason = String.Empty
        Me.Duration = 0
        Me.Note = String.Empty
        Me.AddedDate = DateTime.Now
        Me.UserID = String.Empty
    End Sub
    Public Sub New(ID As Integer, EmployeeID As Integer, HolidayDate As DateTime, Reason As String,
                   Duration As Integer, Note As String, AddedDate As DateTime, UserID As String)
        Me.ID = ID
        Me.EmployeeID = EmployeeID
        Me.HolidayDate = HolidayDate
        Me.Reason = Reason
        Me.Duration = Duration
        Me.Note = Note
        Me.AddedDate = AddedDate
        Me.UserID = UserID
    End Sub

End Class
Public Class clsHoldidayDAL
    Implements IDataHelper(Of clsHolidayDTO)
    Public Function Edit(table As clsHolidayDTO) As Boolean Implements IDataHelper(Of clsHolidayDTO).Edit
        Dim RowsAffected = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_EditHolidays", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", table.ID)
                    command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    command.Parameters.AddWithValue("@HolidayDate", table.HolidayDate)
                    command.Parameters.AddWithValue("@Reason", table.Reason)
                    command.Parameters.AddWithValue("@Duration", table.Duration)
                    command.Parameters.AddWithValue("@Note", table.Note)
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UserID", If(String.IsNullOrEmpty(table.UserID), DBNull.Value, table.UserID))
                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Database in SP_EditHolidays : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return (RowsAffected > 0)
    End Function
    Public Function Add(table As clsHolidayDTO) As Integer Implements ISystemRecordHelper(Of clsHolidayDTO).Add
        Dim NewID As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_AddNewHolidays", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    command.Parameters.AddWithValue("@HolidayDate", table.HolidayDate)
                    command.Parameters.AddWithValue("@Reason", table.Reason)
                    command.Parameters.AddWithValue("@Duration", table.Duration)
                    command.Parameters.AddWithValue("@Note", table.Note)
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UserID", If(String.IsNullOrEmpty(table.UserID), DBNull.Value, table.UserID))

                    Dim ReturnParam As New SqlParameter("@NewID", SqlDbType.Int)
                    ReturnParam.Direction = ParameterDirection.Output
                    command.Parameters.Add(ReturnParam)
                    command.ExecuteNonQuery()
                    NewID = Convert.ToInt32(ReturnParam.Value)
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Database in SP_AddNewHolidays : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return NewID
    End Function
    Public Function Delete(ID As Integer) As Boolean Implements ISystemRecordHelper(Of clsHolidayDTO).Delete
        Dim RowsAffected = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_DeleteHolidays", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Database in SP_DeleteHolidays : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return (RowsAffected > 0)
    End Function
    Public Function GetAllData() As List(Of clsHolidayDTO) Implements ISystemRecordHelper(Of clsHolidayDTO).GetAllData
        Dim holidaysList As New List(Of clsHolidayDTO)
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetAllHolidays", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim HolidaysDTO As New clsHolidayDTO With {
                                .ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                .EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                .HolidayDate = reader.GetDateTime(reader.GetOrdinal("HolidayDate")),
                                .Reason = If(Not reader.IsDBNull(reader.GetOrdinal("Reason")), reader.GetString(reader.GetOrdinal("Reason")), String.Empty),
                                .Duration = If(Not reader.IsDBNull(reader.GetOrdinal("Duration")), reader.GetInt32(reader.GetOrdinal("Duration")), 0),
                                .Note = If(Not reader.IsDBNull(reader.GetOrdinal("Note")), reader.GetString(reader.GetOrdinal("Note")), String.Empty),
                                .AddedDate = reader.GetDateTime(reader.GetOrdinal("AddedDate")),
                                .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            }
                            holidaysList.Add(HolidaysDTO)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Database in SP_GetAllHolidays : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return holidaysList
    End Function
    Public Function Find(ID As Integer) As clsHolidayDTO Implements ISystemRecordHelper(Of clsHolidayDTO).Find
        Dim holidayDTO As New clsHolidayDTO()
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetHolidaysInfoByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If (reader.Read()) Then
                            holidayDTO = New clsHolidayDTO With {
                                .ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                .EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                                .HolidayDate = reader.GetDateTime(reader.GetOrdinal("HolidayDate")),
                                .Reason = If(Not reader.IsDBNull(reader.GetOrdinal("Reason")), reader.GetString(reader.GetOrdinal("Reason")), String.Empty),
                                .Duration = If(Not reader.IsDBNull(reader.GetOrdinal("Duration")), reader.GetInt32(reader.GetOrdinal("Duration")), 0),
                                .Note = If(Not reader.IsDBNull(reader.GetOrdinal("Note")), reader.GetString(reader.GetOrdinal("Note")), String.Empty),
                                .AddedDate = reader.GetDateTime(reader.GetOrdinal("AddedDate")),
                                .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                                }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Database in SP_GetHolidaysInfoByID : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return holidayDTO
    End Function
    Public Function GetDataByUser(UserID As String) As List(Of clsHolidayDTO) Implements ISystemRecordHelper(Of clsHolidayDTO).GetDataByUser
        Dim holidayList As New List(Of clsHolidayDTO)
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetHolidaysByUserID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While (reader.Read())
                            Dim HolidaysDTO As New clsHolidayDTO With {
                             .ID = reader.GetInt32(reader.GetOrdinal("ID")),
                             .EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                             .HolidayDate = reader.GetDateTime(reader.GetOrdinal("HolidayDate")),
                             .Reason = If(Not reader.IsDBNull(reader.GetOrdinal("Reason")), reader.GetString(reader.GetOrdinal("Reason")), String.Empty),
                             .Duration = If(Not reader.IsDBNull(reader.GetOrdinal("Duration")), reader.GetInt32(reader.GetOrdinal("Duration")), 0),
                             .Note = If(Not reader.IsDBNull(reader.GetOrdinal("Note")), reader.GetString(reader.GetOrdinal("Note")), String.Empty),
                             .AddedDate = reader.GetDateTime(reader.GetOrdinal("AddedDate")),
                             .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            }
                            holidayList.Add(HolidaysDTO)
                        End While
                    End Using

                End Using

            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Database in SP_GetDataByUserID : {ex.Message}", EventLogEntryType.Error)
        End Try
        Return holidayList
    End Function
End Class
