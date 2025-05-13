Imports System.Data.SqlClient

Public Class clsConnectionString
    Private Shared _connectionString As String = "Server=.;Database=HR_System;User Id=sa;Password=sa123456;"
    Public Shared Connection As String = "Server=.;Database=HR_System;User Id=sa;Password=sa123456;"
    Public Shared ReadOnly Property ConnectionString As String
        Get
            Return _connectionString
        End Get
    End Property
    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(_connectionString)
    End Function
End Class
