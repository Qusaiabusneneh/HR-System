Imports DataAccessTier.DataAccessTier.DataAccessTools
Imports NPOI.SS.UserModel

Public Interface IEmployeeHelper(Of Table)
    Inherits IDataHelper(Of Table)
    Function GetAllJobTitles() As List(Of Table)
End Interface
