Public NotInheritable Class clsLocalUsers
    Public Shared Property ID As Integer
    Public Shared Property FullName As String
    Public Shared Property Username As String
    Public Shared Property Password As String
    Public Shared Property Phone As String
    Public Shared Property Email As String
    Public Shared Property Address As String
    Public Shared Property Role As String
    Public Shared Property CreatedDate As DateTime
    Public Shared Property EditedDate As DateTime
    Public Shared Property UserID As String
    Public Shared Property IsSecondaryUser As Boolean
    Public Shared Sub setRole()
        clsLocalUsers.Role = "Admin"
        clsLocalUsers.FullName = "قصي ابو سنينه"
        clsLocalUsers.Username = "Qsneneh"
        clsLocalUsers.UserID = "1211"
        clsLocalUsers.ID = 1
    End Sub
End Class
