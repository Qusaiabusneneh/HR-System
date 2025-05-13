Imports BussinesTier.HR_System.Core

Public Class clsRoles
    Public Property ID As Integer
    Public Property Key As String
    Public Property Value As Boolean

    'Navigation
    Public Property UserID As Integer
    Public Property Users As clsUsers


End Class
