Imports DataAccessTier.DataAccessTier.DataAccessTools
Imports System.Data.SqlClient
Public Class clsSalaRateDTO
    Public Property ID As Integer
    Public Property Degree As Integer
    Public Property Salary As Double
    Public Property BounsYearRate As Double
    Public Property PromationYear As Integer
    Public Property UserID As String
    Public Sub New()
        Me.ID = -1
        Me.Degree = 0
        Me.Salary = 0
        Me.BounsYearRate = 0
        Me.PromationYear = 0
        Me.UserID = String.Empty
    End Sub
    Public Sub New(id As Integer, degree As Integer, salary As Double, bounsYearRate As Double, promationYear As Integer, userId As String)
        Me.ID = id
        Me.Degree = degree
        Me.Salary = salary
        Me.BounsYearRate = bounsYearRate
        Me.PromationYear = promationYear
        Me.UserID = userId
    End Sub
End Class
Public Class clsSalaryRatesDataAcess
    Implements IDataHelper(Of clsSalaRateDTO)
    Public Function Add(table As clsSalaRateDTO) As Integer Implements IDataHelper(Of clsSalaRateDTO).Add
        Dim newID As Integer = -1

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_AddSalaryRate", connection)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@Degree", table.Degree)
                    command.Parameters.AddWithValue("@Salary", table.Salary)
                    command.Parameters.AddWithValue("@BounsYearRate", table.BounsYearRate)
                    command.Parameters.AddWithValue("@PromationYear", table.PromationYear)
                    command.Parameters.AddWithValue("@UserID", If(table.UserID, DBNull.Value)) ' <- Updated

                    Dim outputParam As New SqlParameter("@NewID", SqlDbType.Int)
                    outputParam.Direction = ParameterDirection.Output
                    command.Parameters.Add(outputParam)
                    command.ExecuteNonQuery()
                    newID = If(outputParam.Value IsNot DBNull.Value, CInt(outputParam.Value), Nothing)
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_AddSalaryRate: {ex.Message}", EventLogEntryType.Error)
        End Try

        Return newID
    End Function
    Public Function Edit(table As clsSalaRateDTO) As Boolean Implements IDataHelper(Of clsSalaRateDTO).Edit
        Dim RowsAffected As Integer = -1
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_EditSalaryRate", connection)
                    command.CommandType = CommandType.StoredProcedure

                    command.Parameters.AddWithValue("@ID", table.ID)
                    command.Parameters.AddWithValue("@Degree", table.Degree)
                    command.Parameters.AddWithValue("@Salary", table.Salary)
                    command.Parameters.AddWithValue("@BounsYearRate", table.BounsYearRate)
                    command.Parameters.AddWithValue("@PromationYear", table.PromationYear)
                    command.Parameters.AddWithValue("@UserID", If(table.UserID IsNot Nothing, table.UserID, DBNull.Value))

                    RowsAffected = command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_EditSalaryRate: {ex.Message}", EventLogEntryType.Error)
        End Try

        Return (RowsAffected > 0)
    End Function
    Public Function GetAllData() As List(Of clsSalaRateDTO) Implements IDataHelper(Of clsSalaRateDTO).GetAllData
        Dim salaryRates As New List(Of clsSalaRateDTO)

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetAllSalaryRates", connection)
                    command.CommandType = CommandType.StoredProcedure

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim id As Integer = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0)
                            Dim degree As Integer = If(Not reader.IsDBNull(reader.GetOrdinal("Degree")), reader.GetInt32(reader.GetOrdinal("Degree")), 0)
                            Dim salary As Double = If(Not reader.IsDBNull(reader.GetOrdinal("Salary")), reader.GetDouble(reader.GetOrdinal("Salary")), 0.0)
                            Dim bounsYearRate As Double = If(Not reader.IsDBNull(reader.GetOrdinal("BounsYearRate")), reader.GetDouble(reader.GetOrdinal("BounsYearRate")), 0.0)
                            Dim promationYear As Integer = If(Not reader.IsDBNull(reader.GetOrdinal("PromationYear")), reader.GetInt32(reader.GetOrdinal("PromationYear")), 0)
                            Dim userId As String = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)

                            salaryRates.Add(New clsSalaRateDTO(id, degree, salary, bounsYearRate, promationYear, userId))
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in GetAllSalaryRates {ex.Message}", EventLogEntryType.Error)
        End Try

        Return salaryRates
    End Function
    Public Function GetSalayRateByID(ID As Integer) As clsSalaRateDTO Implements IDataHelper(Of clsSalaRateDTO).Find
        Dim result As clsSalaRateDTO = Nothing

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetSalaryRateByID", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Dim idValue As Integer = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0)
                            Dim degree As Integer = If(Not reader.IsDBNull(reader.GetOrdinal("Degree")), reader.GetInt32(reader.GetOrdinal("Degree")), 0)
                            Dim salary As Double = If(Not reader.IsDBNull(reader.GetOrdinal("Salary")), reader.GetDouble(reader.GetOrdinal("Salary")), 0.0)
                            Dim bounsYearRate As Double = If(Not reader.IsDBNull(reader.GetOrdinal("BounsYearRate")), reader.GetDouble(reader.GetOrdinal("BounsYearRate")), 0.0)
                            Dim promationYear As Integer = If(Not reader.IsDBNull(reader.GetOrdinal("PromationYear")), reader.GetInt32(reader.GetOrdinal("PromationYear")), 0)
                            Dim userID As String = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            result = New clsSalaRateDTO(idValue, degree, salary, bounsYearRate, promationYear, userID)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in Find: {ex.Message}", EventLogEntryType.Error)
        End Try

        Return result
    End Function
    Public Function Delete(ID As Integer) As Boolean Implements IDataHelper(Of clsSalaRateDTO).Delete
        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("SP_DeleteSalaryRate", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID", ID)
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in SP_DeleteSalaryRate: {ex.Message}", EventLogEntryType.Error)
            Return False
        End Try
    End Function
    Public Function GetDataByUser(UserID As String) As List(Of clsSalaRateDTO) Implements ISystemRecordHelper(Of clsSalaRateDTO).GetDataByUser
        Dim salaryRates As New List(Of clsSalaRateDTO)()

        Try
            Using connection As New SqlConnection(clsConnectionString.ConnectionString)
                connection.Open()

                Using command As New SqlCommand("SP_GetSalaryRatesByUser", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@UserID", UserID)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim salaryRate As New clsSalaRateDTO() With {
                                .ID = If(Not reader.IsDBNull(reader.GetOrdinal("ID")), reader.GetInt32(reader.GetOrdinal("ID")), 0),
                                .Degree = If(Not reader.IsDBNull(reader.GetOrdinal("Degree")), reader.GetInt32(reader.GetOrdinal("Degree")), 0),
                                .Salary = If(Not reader.IsDBNull(reader.GetOrdinal("Salary")), reader.GetDouble(reader.GetOrdinal("Salary")), 0),
                                .BounsYearRate = If(Not reader.IsDBNull(reader.GetOrdinal("BounsYearRate")), reader.GetDouble(reader.GetOrdinal("BounsYearRate")), 0),
                                .PromationYear = If(Not reader.IsDBNull(reader.GetOrdinal("PromationYear")), reader.GetInt32(reader.GetOrdinal("PromationYear")), 0),
                                .UserID = If(Not reader.IsDBNull(reader.GetOrdinal("UserID")), reader.GetString(reader.GetOrdinal("UserID")), String.Empty)
                            }
                            salaryRates.Add(salaryRate)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer("Error in GetSalaryRateByUserID: " & ex.Message, EventLogEntryType.Error)
        End Try

        Return salaryRates
    End Function

End Class
