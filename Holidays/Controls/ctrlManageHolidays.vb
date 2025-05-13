Imports System.Net.Security
Imports BussinesTier
Imports BussinesTier.HR_System.Core
Imports DataAccessTier
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class ctrlManageHolidays
    Private Shared _bookThanksControl As ctrlManageHolidays
    Private Shared _main As FRM_Main
    Private addBookThanksForm As FRM_AddUpdateHolidays
    Private HolidaysBL As clsHoliday = New clsHoliday()
    Private ReadOnly _employees As clsEmployees
    Public Sub New(Employees As clsEmployees)
        InitializeComponent()
        DGVHolidays.RowTemplate.Height = 30
        HolidaysBL = New clsHoliday()
        Me._employees = Employees
        _LoadHolidays()
    End Sub
    'Public Shared Function Instance(main As FRM_Main) As ctrlManageBookThanks
    '    If _bookThanksControl Is Nothing OrElse _bookThanksControl.IsDisposed Then
    '        _bookThanksControl = New ctrlManageBookThanks()
    '        _main = main
    '        _bookThanksControl._LoadEmployees() ' Load data only when instance is created
    '    End If
    '    Return _bookThanksControl
    'End Function
    Private Sub ctrlManageEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadHolidays()
        _SetColumns()
    End Sub
    Public Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open Add/Update form only if not already open
        If addBookThanksForm Is Nothing OrElse addBookThanksForm.IsDisposed Then
            addBookThanksForm = New FRM_AddUpdateHolidays(_main, 0, Me, _employees)
            addBookThanksForm.Show()
            ctrlManageEmployees_Load(Nothing, Nothing)
        Else
            addBookThanksForm.Focus()
        End If
    End Sub
    Private Sub brnUpdate_Click(sender As Object, e As EventArgs) Handles brnUpdate.Click
        If DGVHolidays.CurrentRow IsNot Nothing AndAlso DGVHolidays.CurrentRow.Cells(0).Value IsNot Nothing Then
            Dim frm As New FRM_AddUpdateHolidays(_main, CType(DGVHolidays.CurrentRow.Cells(0).Value, Integer), Me, _employees)
            ctrlManageEmployees_Load(Nothing, Nothing)
            frm.Show()
        Else
            MessageBox.Show("No row selected or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Ensure that a row is selected before proceeding
        If DGVHolidays.CurrentRow Is Nothing OrElse DGVHolidays.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a Employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVHolidays.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If HolidaysBL.DeleteHolidays(ID) Then
                    MessageBox.Show($"Employee with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlManageEmployees_Load(Nothing, Nothing)
                    clsSystemRecord.AddSystemRecord($"حذف اجازة", $"تم حذف معلومات اجازة  يحمل الرقم التعريفي {ID.ToString()}")
                Else
                    MessageBox.Show($"Error deleting Holidays with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid Holidays ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = HolidaysBL.GetAllHolidays()
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
                _LoadHolidays() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVHolidays.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)

                ' Use square brackets around column names
                dv.RowFilter = $" CONVERT([ID], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([HolidayDate], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([Reason], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([Duration], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([Note], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([AddedDate], 'System.String') LIKE '%{searchText}%'"


                DGVHolidays.DataSource = dv
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

            If dataTable.Columns.Contains("EmployeeID") Then
                dataTable.Columns("EmployeeID").SetOrdinal(1)
                dataTable.Columns("EmployeeID").ColumnName = "رقم الموظف"
            End If

            If dataTable.Columns.Contains("HolidayDate") Then
                dataTable.Columns("HolidayDate").SetOrdinal(2)
                dataTable.Columns("HolidayDate").ColumnName = "تاريخ الاجازة"
            End If

            If dataTable.Columns.Contains("Reason") Then
                dataTable.Columns("Reason").SetOrdinal(3)
                dataTable.Columns("Reason").ColumnName = "السبب"
            End If

            If dataTable.Columns.Contains("Duration") Then
                dataTable.Columns("Duration").SetOrdinal(4)
                dataTable.Columns("Duration").ColumnName = "المدة"
            End If

            If dataTable.Columns.Contains("Note") Then
                dataTable.Columns("Note").SetOrdinal(5)
                dataTable.Columns("Note").ColumnName = "الملاحظات"
            End If

            If dataTable.Columns.Contains("AddedDate") Then
                dataTable.Columns("AddedDate").SetOrdinal(6)
                dataTable.Columns("AddedDate").ColumnName = "تاريخ الاضافة"
            End If

            ' Check before removing columns to avoid runtime errors
            If dataTable.Columns.Contains("UserID") Then
                dataTable.Columns.Remove("UserID")
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

            ExcelHelper.Export(data, "Book Thanks")
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub _LoadHolidays()
        Dim ID As Integer = _employees.ID
        Dim holidayList As List(Of clsHolidayDTO) = HolidaysBL.GetAllHolidays().Where(Function(x) x.EmployeeID = ID).ToList()
        DGVHolidays.DataSource = holidayList
    End Sub
    Private Sub _SetColumns()
        If DGVHolidays Is Nothing OrElse DGVHolidays.Columns.Count = 0 Then Exit Sub
        DGVHolidays.Columns(0).HeaderCell.Value = "المعرف"
        DGVHolidays.Columns(1).HeaderCell.Value = "السبب"
        DGVHolidays.Columns(2).HeaderCell.Value = "المدة"
        DGVHolidays.Columns(3).HeaderCell.Value = "الملاحظات"
        DGVHolidays.Columns(4).HeaderCell.Value = "تاريخ الاجازة"
        DGVHolidays.Columns(5).HeaderCell.Value = "تاريخ الاضافة"

        ' Hide sensitive columns
        DGVHolidays.Columns(5).Visible = False
        DGVHolidays.Columns(6).Visible = False
        DGVHolidays.Columns(7).Visible = False
    End Sub
End Class
