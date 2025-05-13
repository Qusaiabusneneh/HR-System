Imports DataAccessTier
Imports System.Data.SqlClient

Public Class clsConnectionHelper
    Public Shared Sub SetConnectionString()
        Dim Server As String = My.Settings.Server
        Dim Database As String = My.Settings.DataBase
        Dim UserID As String = My.Settings.Username
        Dim Password As String = My.Settings.Password
        Dim Duration As String = My.Settings.ConnectionDuration.ToString()

        If My.Settings.ConnectionType = "Local" Then
            clsConnectionString.Connection = $"Server={Server};Database={Database};Encrypt=false;Trusted_Connection=True"
        Else
            clsConnectionString.Connection = $"Server={Server};Database={Database};User Id={UserID};Password={Password};Encrypt=false;Timeout={Duration}"
        End If
    End Sub
    Public Shared Function TestConnection(connectionString As String) As Boolean
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Connection failed: " & ex.Message, "Database Test", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class
