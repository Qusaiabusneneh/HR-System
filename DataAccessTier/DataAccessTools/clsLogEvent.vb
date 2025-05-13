Imports System.Diagnostics

Public Class clsLogEvent
    Private Shared _sourceName As String = "Hr_SystemApp"

    ''' <summary>
    ''' This Method Logs Exceptions from the Data Access Layer
    ''' </summary>
    ''' <param name="Message">The error message to log</param>
    ''' <param name="Type">The type of event log entry</param>
    Public Shared Sub LogExceptionToLogViwer(Message As String, Type As EventLogEntryType)
        ' Create the event source if it does not exist
        If Not EventLog.SourceExists(_sourceName) Then
            EventLog.CreateEventSource(_sourceName, "Application")
        End If
        EventLog.WriteEntry(_sourceName, Message, Type)
    End Sub
End Class
