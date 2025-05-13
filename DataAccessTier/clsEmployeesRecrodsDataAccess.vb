Imports System.Data.SqlClient
Imports DataAccessTier.DataAccessTier.DataAccessTools

Public Class clsEmployeesRecrodsDTO
    Public Property ID As Integer
    Public Property FullName As String
    Public Property JobTitle As String
    Public Property Status As String
    Public Property LastPromationDate As DateTime
    Public Property CurrentDegree As Integer
    Public Property CurrentStage As Integer
    Public Property CurrentSalary As Integer
    Public Property CurrentDate As DateTime
    Public Property NextDegree As Integer
    Public Property NextStage As Integer
    Public Property NextSalary As Integer
    Public Property NextDate As DateTime
    Public Property Note As String
    Public Property AddedDate As DateTime
    Public Property UpdatedDate As DateTime
    Public Property UserID As String
    Public Property EmployeeID As Integer
    Public Sub New()
        Me.ID = -1
        Me.EmployeeID = -1
        Me.FullName = String.Empty
        Me.JobTitle = String.Empty
        Me.Status = String.Empty
        Me.LastPromationDate = DateTime.Now
        Me.CurrentDegree = 0
        Me.CurrentStage = 0
        Me.CurrentSalary = 0
        Me.CurrentDate = DateTime.Now
        Me.NextDegree = 0
        Me.NextStage = 0
        Me.NextSalary = 0
        Me.NextDate = DateTime.Now
        Me.Note = String.Empty
        Me.AddedDate = DateTime.Now
        Me.UpdatedDate = DateTime.Now
        Me.UserID = String.Empty
    End Sub
    Public Sub New(ID As Integer, EmployeeID As Integer, FullName As String, JobTitle As String, Status As String,
                   LastPromationDate As DateTime, CurrentDegree As Integer, CurrentStage As Integer,
                   CurrentSalary As Integer, CurrentDate As DateTime, NextDegree As Integer,
                   NextStage As Integer, NextSalary As Integer, NextDate As DateTime, Note As String,
                   AddedDate As DateTime, UpdatedDate As DateTime, UserID As String)

        Me.ID = ID
        Me.EmployeeID = EmployeeID
        Me.FullName = FullName
        Me.JobTitle = JobTitle
        Me.Status = Status
        Me.LastPromationDate = LastPromationDate
        Me.CurrentDegree = CurrentDegree
        Me.CurrentStage = CurrentStage
        Me.CurrentSalary = CurrentSalary
        Me.CurrentDate = CurrentDate
        Me.NextDegree = NextDegree
        Me.NextStage = NextStage
        Me.NextSalary = NextSalary
        Me.NextDate = NextDate
        Me.Note = Note
        Me.AddedDate = AddedDate
        Me.UpdatedDate = UpdatedDate
        Me.UserID = UserID

    End Sub
End Class
Public Class clsEmployeesRecrodsDAL
    Implements IDataHelper(Of clsEmployeesRecrodsDTO)
    Public Function Edit(table As clsEmployeesRecrodsDTO) As Boolean Implements IDataHelper(Of clsEmployeesRecrodsDTO).Edit
        Dim rowsAffected As Integer = -1

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_EditEmployeeRecords", connection)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@ID", table.ID)
                    command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    command.Parameters.AddWithValue("@FullName", table.FullName)
                    command.Parameters.AddWithValue("@JobTitle", table.JobTitle)
                    command.Parameters.AddWithValue("@Status", table.Status)
                    command.Parameters.AddWithValue("@LastPromationDate", table.LastPromationDate)
                    command.Parameters.AddWithValue("@CurrentDegree", table.CurrentDegree)
                    command.Parameters.AddWithValue("@CurrentStage", table.CurrentStage)
                    command.Parameters.AddWithValue("@CurrentSalary", table.CurrentSalary)
                    command.Parameters.AddWithValue("@CurrentDate", table.CurrentDate)
                    command.Parameters.AddWithValue("@NextDegree", table.NextDegree)
                    command.Parameters.AddWithValue("@NextStage", table.NextStage)
                    command.Parameters.AddWithValue("@NextSalary", table.NextSalary)
                    command.Parameters.AddWithValue("@NextDate", table.NextDate)
                    command.Parameters.AddWithValue("@Note", If(String.IsNullOrWhiteSpace(table.Note), DBNull.Value, table.Note))
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UpdatedDate", table.UpdatedDate)

                    ' Fallback to system username if UserID is missing
                    Dim userId As String = If(String.IsNullOrWhiteSpace(table.UserID), Environment.UserName, table.UserID)
                    command.Parameters.AddWithValue("@UserID", userId)

                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Edit (clsEmployeesRecrodsDAL): " & ex.Message, EventLogEntryType.Error)
        End Try

        Return (rowsAffected > 0)
    End Function
    Public Function Add(table As clsEmployeesRecrodsDTO) As Integer Implements ISystemRecordHelper(Of clsEmployeesRecrodsDTO).Add
        Dim NewID As Integer = -1

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_AddEmployeesRecord", connection)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@EmployeeID", table.EmployeeID)
                    command.Parameters.AddWithValue("@FullName", table.FullName)
                    command.Parameters.AddWithValue("@JobTitle", table.JobTitle)
                    command.Parameters.AddWithValue("@Status", table.Status)
                    command.Parameters.AddWithValue("@LastPromationDate", table.LastPromationDate)
                    command.Parameters.AddWithValue("@CurrentDegree", table.CurrentDegree)
                    command.Parameters.AddWithValue("@CurrentStage", table.CurrentStage)
                    command.Parameters.AddWithValue("@CurrentSalary", table.CurrentSalary)
                    command.Parameters.AddWithValue("@CurrentDate", table.CurrentDate)
                    command.Parameters.AddWithValue("@NextDegree", table.NextDegree)
                    command.Parameters.AddWithValue("@NextStage", table.NextStage)
                    command.Parameters.AddWithValue("@NextSalary", table.NextSalary)
                    command.Parameters.AddWithValue("@NextDate", table.NextDate)
                    command.Parameters.AddWithValue("@Note", If(String.IsNullOrWhiteSpace(table.Note), DBNull.Value, table.Note))
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UpdatedDate", table.UpdatedDate)
                    Dim userId As String = If(String.IsNullOrWhiteSpace(table.UserID), Environment.UserName, table.UserID)
                    command.Parameters.AddWithValue("@UserID", userId)
                    ' Add output parameter for NewID
                    Dim outputParam As New SqlParameter("@NewID", SqlDbType.Int)
                    outputParam.Direction = ParameterDirection.Output
                    command.Parameters.Add(outputParam)
                    command.ExecuteNonQuery()
                    NewID = Convert.ToInt32(outputParam.Value)
                End Using

            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Add (clsEmployeesRecrodsDAL): " & ex.Message, EventLogEntryType.Error)
        End Try
        Return NewID
    End Function
    Public Function Delete(ID As Integer) As Boolean Implements ISystemRecordHelper(Of clsEmployeesRecrodsDTO).Delete
        Dim rowsAffected As Integer = 0

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_DeleteEmployeeRecord", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Delete (clsEmployeesRecrodsDAL): {ex.Message}", EventLogEntryType.Error)
        End Try

        Return (rowsAffected > 0)
    End Function
    Public Function GetAllData() As List(Of clsEmployeesRecrodsDTO) Implements ISystemRecordHelper(Of clsEmployeesRecrodsDTO).GetAllData
        Dim list As New List(Of clsEmployeesRecrodsDTO)()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetAllEmployeesRecords", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim record As New clsEmployeesRecrodsDTO() With {
                            .ID = Convert.ToInt32(reader("ID")),
                            .EmployeeID = Convert.ToInt32(reader("EmployeeID")),
                            .FullName = reader("FullName").ToString(),
                            .JobTitle = reader("JobTitle").ToString(),
                            .Status = reader("Status").ToString(),
                            .LastPromationDate = Convert.ToDateTime(reader("LastPromationDate")),
                            .CurrentDegree = Convert.ToInt32(reader("CurrentDegree")),
                            .CurrentStage = Convert.ToInt32(reader("CurrentStage")),
                            .CurrentSalary = Convert.ToInt32(reader("CurrentSalary")),
                            .CurrentDate = Convert.ToDateTime(reader("CurrentDate")),
                            .NextDegree = Convert.ToInt32(reader("NextDegree")),
                            .NextStage = Convert.ToInt32(reader("NextStage")),
                            .NextSalary = Convert.ToInt32(reader("NextSalary")),
                            .NextDate = Convert.ToDateTime(reader("NextDate")),
                            .Note = If(reader("Note") IsNot DBNull.Value, reader("Note").ToString(), String.Empty),
                            .AddedDate = Convert.ToDateTime(reader("AddedDate")),
                            .UpdatedDate = Convert.ToDateTime(reader("UpdatedDate")),
                            .UserID = If(reader("UserID") IsNot DBNull.Value, reader("UserID").ToString(), Environment.UserName)
                        }
                            list.Add(record)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in GetAllData (clsEmployeesRecrodsDAL): {ex.Message}", EventLogEntryType.Error)
        End Try

        Return list
    End Function
    Public Function Find(ID As Integer) As clsEmployeesRecrodsDTO Implements ISystemRecordHelper(Of clsEmployeesRecrodsDTO).Find
        Dim record As New clsEmployeesRecrodsDTO()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetEmployeeRecordByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            record.ID = Convert.ToInt32(reader("ID"))
                            record.EmployeeID = Convert.ToInt32(reader("EmployeeID"))
                            record.FullName = reader("FullName").ToString()
                            record.JobTitle = reader("JobTitle").ToString()
                            record.Status = reader("Status").ToString()
                            record.LastPromationDate = Convert.ToDateTime(reader("LastPromationDate"))
                            record.CurrentDegree = Convert.ToInt32(reader("CurrentDegree"))
                            record.CurrentStage = Convert.ToInt32(reader("CurrentStage"))
                            record.CurrentSalary = Convert.ToInt32(reader("CurrentSalary"))
                            record.CurrentDate = Convert.ToDateTime(reader("CurrentDate"))
                            record.NextDegree = Convert.ToInt32(reader("NextDegree"))
                            record.NextStage = Convert.ToInt32(reader("NextStage"))
                            record.NextSalary = Convert.ToInt32(reader("NextSalary"))
                            record.NextDate = Convert.ToDateTime(reader("NextDate"))
                            record.Note = If(reader("Note") IsNot DBNull.Value, reader("Note").ToString(), String.Empty)
                            record.AddedDate = Convert.ToDateTime(reader("AddedDate"))
                            record.UpdatedDate = Convert.ToDateTime(reader("UpdatedDate"))
                            record.UserID = If(reader("UserID") IsNot DBNull.Value, reader("UserID").ToString(), Environment.UserName)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Find (clsEmployeesRecrodsDAL): {ex.Message}", EventLogEntryType.Error)
        End Try

        Return record
    End Function
    Public Function GetDataByUser(UserID As String) As List(Of clsEmployeesRecrodsDTO) Implements ISystemRecordHelper(Of clsEmployeesRecrodsDTO).GetDataByUser
        Dim result As New List(Of clsEmployeesRecrodsDTO)()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetEmployeeRecordsByUserID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim record As New clsEmployeesRecrodsDTO() With {
                                .ID = Convert.ToInt32(reader("ID")),
                                .EmployeeID = Convert.ToInt32(reader("EmployeeID")),
                                .FullName = reader("FullName").ToString(),
                                .JobTitle = reader("JobTitle").ToString(),
                                .Status = reader("Status").ToString(),
                                .LastPromationDate = Convert.ToDateTime(reader("LastPromationDate")),
                                .CurrentDegree = Convert.ToInt32(reader("CurrentDegree")),
                                .CurrentStage = Convert.ToInt32(reader("CurrentStage")),
                                .CurrentSalary = Convert.ToInt32(reader("CurrentSalary")),
                                .CurrentDate = Convert.ToDateTime(reader("CurrentDate")),
                                .NextDegree = Convert.ToInt32(reader("NextDegree")),
                                .NextStage = Convert.ToInt32(reader("NextStage")),
                                .NextSalary = Convert.ToInt32(reader("NextSalary")),
                                .NextDate = Convert.ToDateTime(reader("NextDate")),
                                .Note = If(reader("Note") IsNot DBNull.Value, reader("Note").ToString(), String.Empty),
                                .AddedDate = Convert.ToDateTime(reader("AddedDate")),
                                .UpdatedDate = Convert.ToDateTime(reader("UpdatedDate")),
                                .UserID = If(reader("UserID") IsNot DBNull.Value, reader("UserID").ToString(), Environment.UserName)
                            }
                            result.Add(record)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in GetDataByUser (clsEmployeesRecrodsDAL): {ex.Message}", EventLogEntryType.Error)
        End Try

        Return result
    End Function

    'Public Shared Function GetDataByID(ID As Integer) As List(Of clsEmployeesRecrodsDTO)
    '    Dim result As New List(Of clsEmployeesRecrodsDTO)()

    '    Try
    '        Using connection As New SqlConnection(clsConnectionString.ConnectionString)
    '            connection.Open()

    '            Using command As New SqlCommand("SP_GetAllEmployeesRecordsByID", connection)
    '                command.CommandType = CommandType.StoredProcedure
    '                command.Parameters.AddWithValue("@ID", ID)

    '                Using reader As SqlDataReader = command.ExecuteReader()
    '                    While reader.Read()
    '                        Dim record As New clsEmployeesRecrodsDTO() With {
    '                            .ID = Convert.ToInt32(reader("ID")),
    '                            .FullName = reader("FullName").ToString(),
    '                            .JobTitle = reader("JobTitle").ToString(),
    '                            .Status = reader("Status").ToString(),
    '                            .LastPromationDate = Convert.ToDateTime(reader("LastPromationDate")),
    '                            .CurrentDegree = Convert.ToInt32(reader("CurrentDegree")),
    '                            .CurrentStage = Convert.ToInt32(reader("CurrentStage")),
    '                            .CurrentSalary = Convert.ToInt32(reader("CurrentSalary")),
    '                            .CurrentDate = Convert.ToDateTime(reader("CurrentDate")),
    '                            .NextDegree = Convert.ToInt32(reader("NextDegree")),
    '                            .NextStage = Convert.ToInt32(reader("NextStage")),
    '                            .NextSalary = Convert.ToInt32(reader("NextSalary")),
    '                            .NextDate = Convert.ToDateTime(reader("NextDate")),
    '                            .Note = If(reader("Note") IsNot DBNull.Value, reader("Note").ToString(), String.Empty),
    '                            .AddedDate = Convert.ToDateTime(reader("AddedDate")),
    '                            .UpdatedDate = Convert.ToDateTime(reader("UpdatedDate")),
    '                            .UserID = If(reader("UserID") IsNot DBNull.Value, reader("UserID").ToString(), Environment.UserName)
    '                        }
    '                        result.Add(record)
    '                    End While
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        clsLogEvent.LogExceptionToLogViwer($"Error in GetDataByUser (clsEmployeesRecrodsDAL): {ex.Message}", EventLogEntryType.Error)
    '    End Try

    '    Return result
    'End Function

End Class
