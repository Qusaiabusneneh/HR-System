Imports System.Data.SqlClient
Imports DataAccessTier.DataAccessTier.DataAccessTools
Public Class clsEmployeeDTO
    Public Property ID As Integer
    Public Property FullName As String
    Public Property JobTitle As String
    Public Property Status As String
    Public Property LastPromationDate As DateTime
    Public Property CurrentDegree As Integer
    Public Property CurrentStage As Integer
    Public Property CurrentSalary As Single
    Public Property CurrentDate As DateTime
    Public Property NextDegree As Integer
    Public Property NextStage As Integer
    Public Property NextSalary As Single
    Public Property NextDate As DateTime
    Public Property Note As String
    Public Property AddedDate As DateTime
    Public Property UpdatedDate As DateTime
    Public Property UserID As String
    Public Sub New()
        Me.ID = -1
        Me.FullName = String.Empty
        Me.JobTitle = String.Empty
        Me.Status = String.Empty
        Me.LastPromationDate = DateTime.Now
        Me.CurrentDegree = 0
        Me.CurrentStage = 0
        Me.CurrentSalary = 0.0
        Me.CurrentDate = DateTime.Now
        Me.NextDegree = 0
        Me.NextStage = 0
        Me.NextSalary = 0.0
        Me.NextDate = DateTime.Now
        Me.Note = String.Empty
        Me.AddedDate = DateTime.Now
        Me.UpdatedDate = DateTime.Now
        Me.UserID = String.Empty
    End Sub
    'Public Sub New(ID As Integer, FullName As String)
    '    Me.ID = ID
    '    Me.FullName = FullName
    'End Sub
    Public Sub New(ID As Integer, FullName As String, JobTitle As String, Status As String,
                   LastPromationDate As DateTime, CurrentDegree As Integer, CurrentStage As Integer,
                   CurrentSalary As Single, CurrentDate As DateTime, NextDegree As Integer,
                   NextStage As Integer, NextSalary As Single, NextDate As DateTime, Note As String,
                   AddedDate As DateTime, UpdatedDate As DateTime, UserID As String)

        Me.ID = ID
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
Public Class clsEmployeesDataAccess
    Implements IEmployeeHelper(Of clsEmployeeDTO)

    Public Function Edit(table As clsEmployeeDTO) As Boolean Implements IDataHelper(Of clsEmployeeDTO).Edit
        Dim rowsAffected As Integer = -1

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_EditEmployee", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", table.ID)
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
                    command.Parameters.AddWithValue("@Note", If(table.Note, DBNull.Value))
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UpdatedDate", table.UpdatedDate)
                    command.Parameters.AddWithValue("@UserID", If(table.UserID, DBNull.Value))

                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_EditEmployee: {ex.Message}", EventLogEntryType.Error)
        End Try

        Return (rowsAffected > 0)
    End Function

    Public Function Add(table As clsEmployeeDTO) As Integer Implements ISystemRecordHelper(Of clsEmployeeDTO).Add
        Dim newID As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_AddEmployee", connection)
                    command.CommandType = CommandType.StoredProcedure

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
                    command.Parameters.AddWithValue("@Note", If(table.Note, DBNull.Value))
                    command.Parameters.AddWithValue("@AddedDate", table.AddedDate)
                    command.Parameters.AddWithValue("@UpdatedDate", table.UpdatedDate)
                    command.Parameters.AddWithValue("@UserID", If(table.UserID, DBNull.Value))

                    Dim outputParam As New SqlParameter("@NewID", SqlDbType.Int)
                    outputParam.Direction = ParameterDirection.Output
                    command.Parameters.Add(outputParam)

                    command.ExecuteNonQuery()
                    newID = If(outputParam.Value IsNot DBNull.Value, CInt(outputParam.Value), -1)
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_AddEmployee: {ex.Message}", EventLogEntryType.Error)
        End Try

        Return newID
    End Function

    Public Function Delete(ID As Integer) As Boolean Implements ISystemRecordHelper(Of clsEmployeeDTO).Delete
        Dim rowsAffected As Integer = 0
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_DeleteEmployee", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    rowsAffected = command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Delete Employee: " & ex.Message, EventLogEntryType.Error)
        End Try

        Return (rowsAffected > 0)
    End Function

    Public Function GetAllData() As List(Of clsEmployeeDTO) Implements ISystemRecordHelper(Of clsEmployeeDTO).GetAllData
        Dim employees As New List(Of clsEmployeeDTO)()
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetAllEmployees", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim emp As New clsEmployeeDTO With {
                                .ID = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0),
                                .FullName = If(Not reader.IsDBNull(reader.GetOrdinal("FullName")), reader.GetString(reader.GetOrdinal("FullName")), String.Empty),
                                .JobTitle = If(Not reader.IsDBNull(reader.GetOrdinal("JobTitle")), reader.GetString(reader.GetOrdinal("JobTitle")), String.Empty),
                                .Status = If(Not reader.IsDBNull(reader.GetOrdinal("Status")), reader.GetString(reader.GetOrdinal("Status")), String.Empty),
                                .LastPromationDate = If(Not reader.IsDBNull(reader.GetOrdinal("LastPromationDate")), reader.GetDateTime(reader.GetOrdinal("LastPromationDate")), DateTime.MinValue),
                                .CurrentDegree = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentDegree")), reader.GetInt32(reader.GetOrdinal("CurrentDegree")), 0),
                                .CurrentStage = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentStage")), reader.GetInt32(reader.GetOrdinal("CurrentStage")), 0),
                                .CurrentSalary = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentSalary")), reader.GetDouble(reader.GetOrdinal("CurrentSalary")), 0.0),
                                .CurrentDate = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentDate")), reader.GetDateTime(reader.GetOrdinal("CurrentDate")), DateTime.MinValue),
                                .NextDegree = If(Not reader.IsDBNull(reader.GetOrdinal("NextDegree")), reader.GetInt32(reader.GetOrdinal("NextDegree")), 0),
                                .NextStage = If(Not reader.IsDBNull(reader.GetOrdinal("NextStage")), reader.GetInt32(reader.GetOrdinal("NextStage")), 0),
                                .NextSalary = If(Not reader.IsDBNull(reader.GetOrdinal("NextSalary")), reader.GetDouble(reader.GetOrdinal("NextSalary")), 0.0),
                                .NextDate = If(Not reader.IsDBNull(reader.GetOrdinal("NextDate")), reader.GetDateTime(reader.GetOrdinal("NextDate")), DateTime.MinValue),
                                .Note = If(Not reader.IsDBNull(reader.GetOrdinal("Note")), reader.GetString(reader.GetOrdinal("Note")), String.Empty),
                                .AddedDate = If(Not reader.IsDBNull(reader.GetOrdinal("AddedDate")), reader.GetDateTime(reader.GetOrdinal("AddedDate")), DateTime.MinValue),
                                .UpdatedDate = If(Not reader.IsDBNull(reader.GetOrdinal("UpdatedDate")), reader.GetDateTime(reader.GetOrdinal("UpdatedDate")), DateTime.MinValue),
                                .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            }
                            employees.Add(emp)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in GetAllEmployees: " & ex.Message, EventLogEntryType.Error)
        End Try

        Return employees
    End Function

    Public Function GetEmployeeByID(ID As Integer) As clsEmployeeDTO Implements ISystemRecordHelper(Of clsEmployeeDTO).Find
        Dim employee As clsEmployeeDTO = Nothing
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetEmployeeByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            employee = New clsEmployeeDTO With {
                                .ID = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0),
                                .FullName = If(Not reader.IsDBNull(reader.GetOrdinal("FullName")), reader.GetString(reader.GetOrdinal("FullName")), String.Empty),
                                .JobTitle = If(Not reader.IsDBNull(reader.GetOrdinal("JobTitle")), reader.GetString(reader.GetOrdinal("JobTitle")), String.Empty),
                                .Status = If(Not reader.IsDBNull(reader.GetOrdinal("Status")), reader.GetString(reader.GetOrdinal("Status")), String.Empty),
                                .LastPromationDate = If(Not reader.IsDBNull(reader.GetOrdinal("LastPromationDate")), reader.GetDateTime(reader.GetOrdinal("LastPromationDate")), DateTime.Now),
                                .CurrentDegree = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentDegree")), reader.GetInt32(reader.GetOrdinal("CurrentDegree")), 0),
                                .CurrentStage = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentStage")), reader.GetInt32(reader.GetOrdinal("CurrentStage")), 0),
                                .CurrentSalary = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentSalary")), reader.GetDouble(reader.GetOrdinal("CurrentSalary")), 0.0),
                                .CurrentDate = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentDate")), reader.GetDateTime(reader.GetOrdinal("CurrentDate")), DateTime.Now),
                                .NextDegree = If(Not reader.IsDBNull(reader.GetOrdinal("NextDegree")), reader.GetInt32(reader.GetOrdinal("NextDegree")), 0),
                                .NextStage = If(Not reader.IsDBNull(reader.GetOrdinal("NextStage")), reader.GetInt32(reader.GetOrdinal("NextStage")), 0),
                                .NextSalary = If(Not reader.IsDBNull(reader.GetOrdinal("NextSalary")), reader.GetDouble(reader.GetOrdinal("NextSalary")), 0.0),
                                .NextDate = If(Not reader.IsDBNull(reader.GetOrdinal("NextDate")), reader.GetDateTime(reader.GetOrdinal("NextDate")), DateTime.Now),
                                .Note = If(Not reader.IsDBNull(reader.GetOrdinal("Note")), reader.GetString(reader.GetOrdinal("Note")), String.Empty),
                                .AddedDate = If(Not reader.IsDBNull(reader.GetOrdinal("AddedDate")), reader.GetDateTime(reader.GetOrdinal("AddedDate")), DateTime.Now),
                                .UpdatedDate = If(Not reader.IsDBNull(reader.GetOrdinal("UpdatedDate")), reader.GetDateTime(reader.GetOrdinal("UpdatedDate")), DateTime.Now),
                                .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in Find Employee: " & ex.Message, EventLogEntryType.Error)
        End Try
        Return employee
    End Function

    Public Function GetAllJobTitles() As List(Of clsEmployeeDTO) Implements IEmployeeHelper(Of clsEmployeeDTO).GetAllJobTitles
        Dim jobTitles As New List(Of clsEmployeeDTO)()
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetJobTitles", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read
                            Dim jobTitleDTO As New clsEmployeeDTO()
                            If Not reader.IsDBNull(reader.GetOrdinal("JobTitle")) Then
                                jobTitleDTO.JobTitle = reader.GetString(reader.GetOrdinal("JobTitle"))
                            End If

                            If Not reader.IsDBNull(reader.GetOrdinal("ID")) Then
                                jobTitleDTO.ID = reader.GetInt32(reader.GetOrdinal("ID"))
                            End If

                            jobTitles.Add(jobTitleDTO)

                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in GetAllJobTitles: " & ex.Message, EventLogEntryType.Error)
        End Try
        Return jobTitles
    End Function

    Public Function GetDataByUser(UserID As String) As List(Of clsEmployeeDTO) Implements ISystemRecordHelper(Of clsEmployeeDTO).GetDataByUser
        Dim result As New List(Of clsEmployeeDTO)()
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetEmployeeByUserID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim employee As New clsEmployeeDTO() With {
                                .ID = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0),
                                .FullName = If(Not reader.IsDBNull(reader.GetOrdinal("FullName")), reader.GetString(reader.GetOrdinal("FullName")), ""),
                                .JobTitle = If(Not reader.IsDBNull(reader.GetOrdinal("JobTitle")), reader.GetString(reader.GetOrdinal("JobTitle")), ""),
                                .Status = If(Not reader.IsDBNull(reader.GetOrdinal("Status")), reader.GetString(reader.GetOrdinal("Status")), ""),
                                .LastPromationDate = If(Not reader.IsDBNull(reader.GetOrdinal("LastPromationDate")), reader.GetDateTime(reader.GetOrdinal("LastPromationDate")), DateTime.MinValue),
                                .CurrentDegree = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentDegree")), reader.GetInt32(reader.GetOrdinal("CurrentDegree")), 0),
                                .CurrentStage = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentStage")), reader.GetInt32(reader.GetOrdinal("CurrentStage")), 0),
                                .CurrentSalary = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentSalary")), reader.GetInt32(reader.GetOrdinal("CurrentSalary")), 0),
                                .CurrentDate = If(Not reader.IsDBNull(reader.GetOrdinal("CurrentDate")), reader.GetDateTime(reader.GetOrdinal("CurrentDate")), DateTime.MinValue),
                                .NextDegree = If(Not reader.IsDBNull(reader.GetOrdinal("NextDegree")), reader.GetInt32(reader.GetOrdinal("NextDegree")), 0),
                                .NextStage = If(Not reader.IsDBNull(reader.GetOrdinal("NextStage")), reader.GetInt32(reader.GetOrdinal("NextStage")), 0),
                                .NextSalary = If(Not reader.IsDBNull(reader.GetOrdinal("NextSalary")), reader.GetInt32(reader.GetOrdinal("NextSalary")), 0),
                                .NextDate = If(Not reader.IsDBNull(reader.GetOrdinal("NextDate")), reader.GetDateTime(reader.GetOrdinal("NextDate")), DateTime.MinValue),
                                .Note = If(Not reader.IsDBNull(reader.GetOrdinal("Note")), reader.GetString(reader.GetOrdinal("Note")), ""),
                                .AddedDate = If(Not reader.IsDBNull(reader.GetOrdinal("AddedDate")), reader.GetDateTime(reader.GetOrdinal("AddedDate")), DateTime.MinValue),
                                .UpdatedDate = If(Not reader.IsDBNull(reader.GetOrdinal("UpdatedDate")), reader.GetDateTime(reader.GetOrdinal("UpdatedDate")), DateTime.MinValue),
                                .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), "")
                            }
                            result.Add(employee)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in GetDataByUser: " & ex.Message, EventLogEntryType.Error)
        End Try

        Return Result
    End Function

    Public Shared Function GetAllEmployeesName() As List(Of clsEmployeeDTO)
        Dim employees As New List(Of clsEmployeeDTO)()
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetAllEmployeesName", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim emp As New clsEmployeeDTO With {
                                .ID = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0),
                                .FullName = If(Not reader.IsDBNull(reader.GetOrdinal("FullName")), reader.GetString(reader.GetOrdinal("FullName")), String.Empty)
                            }
                            employees.Add(emp)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in GetAllEmployees: " & ex.Message, EventLogEntryType.Error)
        End Try

        Return employees
    End Function
End Class
