Imports BussinesTier
Imports DataAccessTier
Imports DevExpress.Schedule.Serializing
Public Class ctrlManageEmployeesRecords
    Private Shared _employeesRecordsControl As ctrlManageEmployeesRecords
    Private Shared _main As FRM_Main
    Private EmployeesRecordsBL As clsEmployeesRecords = New clsEmployeesRecords()
    Private ReadOnly _employees As clsEmployees
    Public Sub New(Employees As clsEmployees)
        InitializeComponent()
        DGVEmployees.RowTemplate.Height = 30
        Me._employees = Employees
        _LoadEmployeeRecords()
    End Sub
    'Public Shared Function Instance(main As FRM_Main) As ctrlManageEmployeesRecords
    '    If _employeesRecordsControl Is Nothing OrElse _employeesRecordsControl.IsDisposed Then
    '        _employeesRecordsControl = New ctrlManageEmployeesRecords()
    '        _main = main
    '        _employeesRecordsControl._LoadEmployees() ' Load data only when instance is created
    '    End If
    '    Return _employeesRecordsControl
    'End Function
    Private Sub ctrlManageEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadEmployeeRecords()
        _SetColumns()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Ensure that a row is selected before proceeding
        If DGVEmployees.CurrentRow Is Nothing OrElse DGVEmployees.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a Employee Record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVEmployees.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If EmployeesRecordsBL.Delete(ID) Then
                    MessageBox.Show($"Employee Record with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlManageEmployees_Load(Nothing, Nothing)
                    clsSystemRecord.AddSystemRecord($"حذف سجل موظف", $"تم حذف معلومات سجل موظف يحمل الرقم التعريفي {ID.ToString()}")
                Else
                    MessageBox.Show($"Error deleting Employee Record with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid Employee Record ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = EmployeesRecordsBL.GetAllEmployees()
        _exportExcel(clsHelper.ConvertListToDataTable(Data))
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Search()
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Search()
        End If
    End Sub
    Public Sub Search()
        Try
            Dim searchText As String = txtSearch.Text.Trim()

            If String.IsNullOrWhiteSpace(searchText) Then
                _LoadEmployeeRecords() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVEmployees.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)

                ' Use square brackets around column names
                dv.RowFilter = $"[FullName] LIKE '%{searchText}%' OR 
                [JobTitle] LIKE '%{searchText}%' OR
                [Status] LIKE '%{searchText}%' OR 
                CONVERT([CurrentDegree], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([CurrentStage], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([CurrentSalary], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([CurrentDate], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([NextDegree], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([NextStage], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([NextSalary], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([NextDate], 'System.String') LIKE '%{searchText}%'"


                DGVEmployees.DataSource = dv
            Else
                MessageBox.Show("No data available to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Search failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function _arrangedDataTable(ByVal dataTable As DataTable) As DataTable
        If dataTable Is Nothing OrElse dataTable.Columns.Count = 0 Then
            Return dataTable ' Return if the DataTable is empty
        End If

        Try
            ' Check if columns exist before modifying them
            If dataTable.Columns.Contains("ID") Then
                dataTable.Columns("ID").SetOrdinal(0)
                dataTable.Columns("ID").ColumnName = "تسلسل"
            End If

            If dataTable.Columns.Contains("FullName") Then
                dataTable.Columns("FullName").SetOrdinal(1)
                dataTable.Columns("FullName").ColumnName = "الاسم الكامل"
            End If

            If dataTable.Columns.Contains("JobTitle") Then
                dataTable.Columns("JobTitle").SetOrdinal(2)
                dataTable.Columns("JobTitle").ColumnName = "العنوان الوظيفي"
            End If

            If dataTable.Columns.Contains("Status") Then
                dataTable.Columns("Status").SetOrdinal(3)
                dataTable.Columns("Status").ColumnName = "الحالة"
            End If

            If dataTable.Columns.Contains("LastPromationDate") Then
                dataTable.Columns("LastPromationDate").SetOrdinal(4)
                dataTable.Columns("LastPromationDate").ColumnName = "تاريخ اخر ترفيع"
            End If

            If dataTable.Columns.Contains("CurrentDegree") Then
                dataTable.Columns("CurrentDegree").SetOrdinal(5)
                dataTable.Columns("CurrentDegree").ColumnName = "الدرجة الحالية"
            End If

            If dataTable.Columns.Contains("CurrentStage") Then
                dataTable.Columns("CurrentStage").SetOrdinal(6)
                dataTable.Columns("CurrentStage").ColumnName = "الحالة الحالية"
            End If

            If dataTable.Columns.Contains("CurrentSalary") Then
                dataTable.Columns("CurrentSalary").SetOrdinal(7)
                dataTable.Columns("CurrentSalary").ColumnName = "الراتب الحالي"
            End If

            If dataTable.Columns.Contains("CurrentDate") Then
                dataTable.Columns("CurrentDate").SetOrdinal(8)
                dataTable.Columns("CurrentDate").ColumnName = " التاريخ"
            End If

            If dataTable.Columns.Contains("NextDegree") Then
                dataTable.Columns("NextDegree").SetOrdinal(9)
                dataTable.Columns("NextDegree").ColumnName = "الدرجة التالي"
            End If

            If dataTable.Columns.Contains("NextStage") Then
                dataTable.Columns("NextStage").SetOrdinal(10)
                dataTable.Columns("NextStage").ColumnName = "الحالة التالية"
            End If

            If dataTable.Columns.Contains("NextSalary") Then
                dataTable.Columns("NextSalary").SetOrdinal(11)
                dataTable.Columns("NextSalary").ColumnName = "الراتب التالي"
            End If

            If dataTable.Columns.Contains("NextDate") Then
                dataTable.Columns("NextDate").SetOrdinal(12)
                dataTable.Columns("NextDate").ColumnName = "التاريخ"
            End If

            If dataTable.Columns.Contains("Note") Then
                dataTable.Columns("Note").SetOrdinal(13)
                dataTable.Columns("Note").ColumnName = "الملاحظات"
            End If

            If dataTable.Columns.Contains("AddedDate") Then
                dataTable.Columns("AddedDate").SetOrdinal(14)
                dataTable.Columns("AddedDate").ColumnName = "تاريخ الاضافة"
            End If

            If dataTable.Columns.Contains("UpdatedDate") Then
                dataTable.Columns("UpdatedDate").SetOrdinal(15)
                dataTable.Columns("UpdatedDate").ColumnName = "تاريخ التعديل"
            End If

            ' Check before removing columns to avoid runtime errors
            If dataTable.Columns.Contains("UserID") Then
                dataTable.Columns.Remove("UserID")
            End If

            If dataTable.Columns.Contains("EDTO") Then
                dataTable.Columns.Remove("EDTO")
            End If

        Catch ex As Exception
            Console.WriteLine("Error arranging DataTable: " & ex.Message)
        End Try

        Return dataTable
    End Function
    Private Sub _exportExcel(ByVal data As DataTable)
        Try
            If data Is Nothing OrElse data.Rows.Count = 0 Then
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            data = _arrangedDataTable(data)

            ExcelHelper.Export(data, "Employee")
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub _LoadEmployeeRecords()
        Dim ID As Integer = _employees.ID
        Dim employeesRecordsList As List(Of clsEmployeesRecrodsDTO) = EmployeesRecordsBL.GetAllEmployees().Where(Function(x) x.EmployeeID = ID).ToList()
        DGVEmployees.DataSource = employeesRecordsList
    End Sub
    Private Sub _SetColumns()
        If DGVEmployees Is Nothing OrElse DGVEmployees.Columns.Count = 0 Then Exit Sub
        DGVEmployees.Columns(0).HeaderCell.Value = "المعرف"
        DGVEmployees.Columns(1).HeaderCell.Value = "الاسم الكامل"
        DGVEmployees.Columns(2).HeaderCell.Value = "العنوان الوظيفي"
        DGVEmployees.Columns(3).HeaderCell.Value = "الحالة"
        DGVEmployees.Columns(5).HeaderCell.Value = "الدرجة الحالية"
        DGVEmployees.Columns(6).HeaderCell.Value = "الحالة الحالية"
        DGVEmployees.Columns(7).HeaderCell.Value = "الراتب الحالي"
        DGVEmployees.Columns(8).HeaderCell.Value = "التاريخ"
        DGVEmployees.Columns(9).HeaderCell.Value = "الدرجة التالي"
        DGVEmployees.Columns(10).HeaderCell.Value = "الحالة التالية"
        DGVEmployees.Columns(11).HeaderCell.Value = "الراتب التالي"
        DGVEmployees.Columns(12).HeaderCell.Value = "التاريخ"
        DGVEmployees.Columns(12).HeaderCell.Value = "التاريخ"

        ' Hide sensitive columns
        DGVEmployees.Columns(4).Visible = False
        DGVEmployees.Columns(13).Visible = False
        DGVEmployees.Columns(14).Visible = False
        DGVEmployees.Columns(15).Visible = False
        DGVEmployees.Columns(16).Visible = False
        DGVEmployees.Columns(17).Visible = False
    End Sub
End Class
