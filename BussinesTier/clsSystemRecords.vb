Imports DataAccessTier
Imports System.Data.Linq
Imports System.Net.NetworkInformation
Imports System.Text

Public Class clsSystemRecord
    Public Enum enMode
        enAdd
        enUpdate
    End Enum
    Public Mode As enMode = enMode.enAdd
    Public Property ID As Integer
    Public Property UserFullName As String
    Public Property DeviceName As String
    Public Property Roles As String
    Public Property MachineID As String
    Public Property Title As String
    Public Property Description As String
    Public Property CreatedDate As DateTime
    Public Property UserID As String
    Public Property SystemRecordsDAL As SystemRecordDAL = New SystemRecordDAL()
    Public Property SystemRecordDTO As New clsSystemRecordDTO(Me.ID, Me.UserFullName, Me.DeviceName, Me.Roles,
                                                              Me.MachineID, Me.Title, Me.Description, Me.CreatedDate, Me.UserID)
    Public Sub New()
        ID = -1
        CreatedDate = DateTime.Now.Date
        Description = String.Empty
        Title = String.Empty
        DeviceName = String.Empty
        UserFullName = String.Empty
        UserID = String.Empty
        MachineID = String.Empty
        Mode = enMode.enAdd
    End Sub
    Public Sub New(ID As Integer, CreatedDate As DateTime, Description As String, Title As String,
                   DeviceName As String, UserFullName As String, UserID As String, MachineID As String)
        Me.ID = ID
        Me.CreatedDate = CreatedDate
        Me.Description = Description
        Me.Title = Title
        Me.DeviceName = DeviceName
        Me.UserFullName = UserFullName
        Me.UserID = UserID
        Me.MachineID = MachineID
        Mode = enMode.enUpdate
    End Sub
    Public Sub New(RDTO As clsSystemRecordDTO, cMode As enMode)
        Me.ID = RDTO.ID
        Me.CreatedDate = RDTO.CreatedDate
        Me.Description = RDTO.Description
        Me.Title = RDTO.Title
        Me.DeviceName = RDTO.DeviceName
        Me.UserFullName = RDTO.UserFullName
        Me.UserID = RDTO.UserID
        Me.MachineID = RDTO.MachineID
        Me.Mode = cMode
    End Sub
    Public Function GetAllRecords() As List(Of clsSystemRecordDTO)
        Try
            Return SystemRecordsDAL.GetAllData()
        Catch ex As Exception
            clsLogEvent.LogExceptionToLogViwer($"Error in GetAllSystemRecord: {ex.Message}", EventLogEntryType.Error)
            Throw New Exception("An error occurred while retrieving salary rates.")
        End Try
    End Function
    Public Function GetDataByUser(UserID As String) As List(Of clsSystemRecordDTO)
        Return SystemRecordsDAL.GetDataByUser(UserID)
    End Function
    Public Function Find(ID As Integer) As clsSystemRecord
        Dim RDTO = SystemRecordsDAL.Find(ID)
        If RDTO IsNot Nothing Then
            Return New clsSystemRecord(RDTO.ID, RDTO.CreatedDate, RDTO.Description,
                                       RDTO.Title, RDTO.DeviceName, RDTO.UserFullName, RDTO.UserID, RDTO.MachineID)
        Else
            Return Nothing
        End If
    End Function
    Private Shared Function _getMacAddress() As String
        Dim networkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim machineID As String = String.Empty

        For Each item As NetworkInterface In networkInterfaces
            If item.OperationalStatus = OperationalStatus.Up AndAlso
           item.NetworkInterfaceType <> NetworkInterfaceType.Tunnel AndAlso
           item.NetworkInterfaceType <> NetworkInterfaceType.Loopback Then

                machineID = item.GetPhysicalAddress().ToString()
            End If
        Next

        If String.IsNullOrEmpty(machineID) Then
            machineID = "NULL"
        End If

        Return machineID
    End Function
    Public Shared Function AddSystemRecord(Title As String, Description As String) As String
        Dim helper As New SystemRecordDAL()
        clsLocalUsers.setRole()
        Dim systemRecord As New clsSystemRecordDTO With {
        .CreatedDate = DateTime.Now,
        .Description = Description,
        .Title = Title,
        .DeviceName = Environment.UserName,
        .UserFullName = clsLocalUsers.FullName,
        .UserID = clsLocalUsers.UserID,
        .MachineID = _getMacAddress()
    }

        ' Call Add method from SystemRecordDAL (passing DTO) and return the result (success or error message)
        Return helper.Add(systemRecord) ' Pass DTO instead of clsSystemRecord
    End Function
    Public Function Delete(ID As Integer) As Boolean
        Return SystemRecordsDAL.Delete(ID)
    End Function
End Class
