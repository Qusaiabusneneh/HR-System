Imports System.Reflection
Imports System.Data
Public Class clsHelper
    Public Shared Function ConvertListToDataTable(Of T)(ByVal list As List(Of T)) As DataTable
        ' Create a new DataTable
        Dim dt As New DataTable()

        ' Get the properties of the type T (the class type)
        Dim properties As PropertyInfo() = GetType(T).GetProperties()

        ' Add columns to the DataTable based on the properties of T
        For Each prop As PropertyInfo In properties
            dt.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
        Next

        ' Add rows to the DataTable based on the properties of each object in the list
        For Each item As T In list
            Dim row As DataRow = dt.NewRow()
            For Each prop As PropertyInfo In properties
                row(prop.Name) = prop.GetValue(item, Nothing)
            Next
            dt.Rows.Add(row)
        Next

        Return dt
    End Function

End Class
