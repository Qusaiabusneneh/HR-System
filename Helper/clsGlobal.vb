Imports BussinesTier.HR_System.Core

Public Class clsGlobal
    Public Shared CurrentUser As clsUsers

    Public Shared Function RememberUsernameAndPassword(username As String, password As String) As Boolean
        Try
            ' Get the current directory of the application
            Dim currentDirectory As String = System.IO.Directory.GetCurrentDirectory()

            ' Define the path to the file to save the credentials
            Dim filePath As String = System.IO.Path.Combine(currentDirectory, "data.txt")

            ' If username is empty and the file exists, delete the file
            If String.IsNullOrEmpty(username) AndAlso System.IO.File.Exists(filePath) Then
                System.IO.File.Delete(filePath)
                Return True
            End If

            ' Prepare the data to save
            Dim dataToSave As String = username & "#//#" & password

            ' Write the data to the file
            Using writer As New System.IO.StreamWriter(filePath)
                writer.WriteLine(dataToSave)
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}")
            Return False
        End Try
    End Function

    Public Shared Function GetSortedCredential(ByRef username As String, ByRef password As String) As Boolean
        Try
            Dim currentDirectory As String = System.IO.Directory.GetCurrentDirectory()
            Dim filePath As String = System.IO.Path.Combine(currentDirectory, "data.txt")

            If System.IO.File.Exists(filePath) Then
                Using reader As New System.IO.StreamReader(filePath)
                    Dim line As String
                    Do While (InlineAssignHelper(line, reader.ReadLine())) IsNot Nothing
                        Console.WriteLine(line)
                        Dim result As String() = line.Split(New String() {"#//#"}, StringSplitOptions.None)
                        username = result(0)
                        password = result(1)
                    Loop
                    Return True
                End Using
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}")
            Return False
        End Try
    End Function

    ' Helper method for inline assignment in VB.NET (since it's not built-in)
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

End Class
