Public Interface ISystemRecordHelper(Of table)
    Function Add(table As table) As Integer
    Function Delete(ID As Integer) As Boolean
    Function GetAllData() As List(Of table)
    Function Find(ID As Integer) As table
    Function GetDataByUser(UserID As String) As List(Of table)
End Interface
