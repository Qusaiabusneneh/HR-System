Imports System.Data.SqlClient
Imports DataAccessTier.DataAccessTier.DataAccessTools

Public Class clsAbsencesDTO
    Public Property ID As Integer
    Public Property EmployeeID As Integer
    Public Property AbsenceDate As DateTime
    Public Property Duration As String ' Duration in hours -- e.g., "Full Day", "Half Day", "2 hours"
    Public Property AbsenceType As String
    Public Property Note As String
    Public Property AddedDate As DateTime
    Public Property UserID As String
    Public Sub New()
        ID = -1
        EmployeeID = -1
        AbsenceDate = DateTime.Now
        Duration = ""
        AbsenceType = ""
        Note = ""
        AddedDate = DateTime.Now
        UserID = ""
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
    End Sub
End Class
Public Class clsAbsencesDataAccess
    Implements IDataHelper(Of clsAbsencesDTO)

    Public Function Edit(table As clsAbsencesDTO) As Boolean Implements IDataHelper(Of clsAbsencesDTO).Edit
        Dim RowsAffected As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_EditAbsences", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", table.ID)
                    command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    command.Parameters.AddWithValue("@AbsenceDate", table.AbsenceDate)
                    command.Parameters.AddWithValue("@Duration", table.Duration)
                    command.Parameters.AddWithValue("@AbsenceType", table.AbsenceType)
                    command.Parameters.AddWithValue("@Note", table.Note)
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UserID", If(table.UserID, DBNull.Value))
                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database error in : SP_EditAbsences {ex.Message}", EventLogEntryType.Error)
        End Try
        Return RowsAffected > 0
    End Function

    Public Function Add(table As clsAbsencesDTO) As Integer Implements ISystemRecordHelper(Of clsAbsencesDTO).Add
        Dim NewID As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_AddNewAbsence", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    command.Parameters.AddWithValue("@AbsenceDate", table.AbsenceDate)
                    command.Parameters.AddWithValue("@Duration", table.Duration)
                    command.Parameters.AddWithValue("@AbsenceType", table.AbsenceType)
                    command.Parameters.AddWithValue("@Note", table.Note)
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UserID", If(table.UserID, DBNull.Value))
                    Dim ReturnParameter As SqlParameter = New SqlParameter("@NewID", SqlDbType.Int)
                    ReturnParameter.Direction = ParameterDirection.Output
                    command.Parameters.Add(ReturnParameter)
                    command.ExecuteNonQuery()
                    NewID = Convert.ToInt32(ReturnParameter.Value)
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database error in : SP_AddNewAbsences {ex.Message}", EventLogEntryType.Error)

        End Try
        Return NewID
    End Function

    Public Function Delete(ID As Integer) As Boolean Implements ISystemRecordHelper(Of clsAbsencesDTO).Delete
        Dim RowsAffected As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_DeleteAbsence", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database error in : SP_DeleteAbsences {ex.Message}", EventLogEntryType.Error)
        End Try
        Return RowsAffected > 0
    End Function

    Public Function GetAllData() As List(Of clsAbsencesDTO) Implements ISystemRecordHelper(Of clsAbsencesDTO).GetAllData
        Dim absencesList As List(Of clsAbsencesDTO) = New List(Of clsAbsencesDTO)
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetAllAbsences", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim absence As New clsAbsencesDTO()
                            absence.ID = reader.GetInt32(reader.GetOrdinal("ID"))
                            absence.EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID"))
                            absence.AbsenceDate = reader.GetDateTime(reader.GetOrdinal("AbsenceDate"))
                            absence.Duration = reader.GetString(reader.GetOrdinal("Duration"))
                            absence.AbsenceType = reader.GetString(reader.GetOrdinal("AbsenceType"))
                            absence.Note = reader.GetString(reader.GetOrdinal("Note"))
                            absence.AddedDate = reader.GetDateTime(reader.GetOrdinal("AddedDate"))
                            absence.UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            absencesList.Add(absence)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database error in : SP_GetAllAbsences {ex.Message}", EventLogEntryType.Error)
        End Try
        Return absencesList
    End Function

    Public Function Find(ID As Integer) As clsAbsencesDTO Implements ISystemRecordHelper(Of clsAbsencesDTO).Find
        Dim absence As New clsAbsencesDTO()
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using Command As New SqlCommand("Sp_GetAbsenceInfoByID", connection)
                    Command.CommandType = CommandType.StoredProcedure
                    Command.Parameters.AddWithValue("@ID", ID)
                    Using reader As SqlDataReader = Command.ExecuteReader()
                        While reader.Read()
                            absence.ID = reader.GetInt32(reader.GetOrdinal("ID"))
                            absence.EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID"))
                            absence.AbsenceDate = reader.GetDateTime(reader.GetOrdinal("AbsenceDate"))
                            absence.Duration = reader.GetString(reader.GetOrdinal("Duration"))
                            absence.AbsenceType = reader.GetString(reader.GetOrdinal("AbsenceType"))
                            absence.Note = reader.GetString(reader.GetOrdinal("Note"))
                            absence.AddedDate = reader.GetDateTime(reader.GetOrdinal("AddedDate"))
                            absence.UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            Return absence
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database error in : Sp_GetAbsencesInfoByID {ex.Message}", EventLogEntryType.Error)
        End Try
        Return absence
    End Function

    Public Function GetDataByUser(UserID As String) As List(Of clsAbsencesDTO) Implements ISystemRecordHelper(Of clsAbsencesDTO).GetDataByUser
        Dim AbsencesList As List(Of clsAbsencesDTO) = New List(Of clsAbsencesDTO)
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_GetAllAbsencesByUserID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim absence As New clsAbsencesDTO()
                            absence.ID = reader.GetInt32(reader.GetOrdinal("ID"))
                            absence.EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID"))
                            absence.AbsenceDate = reader.GetDateTime(reader.GetOrdinal("AbsenceDate"))
                            absence.Duration = reader.GetString(reader.GetOrdinal("Duration"))
                            absence.AbsenceType = reader.GetString(reader.GetOrdinal("AbsenceType"))
                            absence.Note = reader.GetString(reader.GetOrdinal("Note"))
                            absence.AddedDate = reader.GetDateTime(reader.GetOrdinal("AddedDate"))
                            absence.UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            AbsencesList.Add(absence)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Database error in : SP_GetAllDataByUserID {ex.Message}", EventLogEntryType.Error)
        End Try
        Return AbsencesList
    End Function
End Class
