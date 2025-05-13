Imports NPOI.SS.Formula.Functions
Imports NPOI.SS.UserModel
Namespace DataAccessTier.DataAccessTools
    Public Interface IDataHelper(Of Table)
        Inherits ISystemRecordHelper(Of Table)
        Function Edit(table As Table) As Boolean
    End Interface
End Namespace
