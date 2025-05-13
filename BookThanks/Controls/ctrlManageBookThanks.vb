Imports System.Net.Security
Imports BussinesTier
Imports BussinesTier.HR_System.Core
Imports DataAccessTier
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class ctrlManageBookThanks
    Private Shared _bookThanksControl As ctrlManageBookThanks
    Private Shared _main As FRM_Main
    Private addBookThanksForm As FRM_AddUpdateBookThanks
    Private BookThanksBL As clsBookThanks = New clsBookThanks()
    Private ReadOnly _employees As clsEmployees
    Public Sub New(Employees As clsEmployees)
        InitializeComponent()
        DGVBookThanks.RowTemplate.Height = 30
        BookThanksBL = New clsBookThanks()
        Me._employees = Employees
        _LoadEmployees()
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
        _LoadEmployees()
        _SetColumns()
    End Sub
    Public Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open Add/Update form only if not already open
        If addBookThanksForm Is Nothing OrElse addBookThanksForm.IsDisposed Then
            addBookThanksForm = New FRM_AddUpdateBookThanks(_main, 0, Me, _employees)
            addBookThanksForm.Show()
            ctrlManageEmployees_Load(Nothing, Nothing)
        Else
            addBookThanksForm.Focus()
        End If
    End Sub
    Private Sub brnUpdate_Click(sender As Object, e As EventArgs) Handles brnUpdate.Click
        If DGVBookThanks.CurrentRow IsNot Nothing AndAlso DGVBookThanks.CurrentRow.Cells(0).Value IsNot Nothing Then
            Dim frm As New FRM_AddUpdateBookThanks(_main, CType(DGVBookThanks.CurrentRow.Cells(0).Value, Integer), Me, _employees)
            ctrlManageEmployees_Load(Nothing, Nothing)
            frm.Show()
        Else
            MessageBox.Show("No row selected or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Ensure that a row is selected before proceeding
        If DGVBookThanks.CurrentRow Is Nothing OrElse DGVBookThanks.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a Employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVBookThanks.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If BookThanksBL.DeleteBookThanks(ID) Then
                    MessageBox.Show($"Employee with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlManageEmployees_Load(Nothing, Nothing)
                    clsSystemRecord.AddSystemRecord($"حذف كتاب شكر", $"تم حذف معلومات كتاب شكر يحمل الرقم التعريفي {ID.ToString()}")
                Else
                    MessageBox.Show($"Error deleting BookThanks with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid BookThanks ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = BookThanksBL.GetAllData()
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
                _LoadEmployees() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVBookThanks.DataSource, DataTable)

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


                DGVBookThanks.DataSource = dv
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

            ExcelHelper.Export(data, "Book Thanks")
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub _LoadEmployees()
        Dim ID As Integer = _employees.ID
        Dim bookThanksList As List(Of clsBookThanksDTO) = BookThanksBL.GetAllData().Where(Function(x) x.EmployeeID = ID).ToList()
        DGVBookThanks.DataSource = bookThanksList
    End Sub
    Private Sub _SetColumns()
        If DGVBookThanks Is Nothing OrElse DGVBookThanks.Columns.Count = 0 Then Exit Sub
        DGVBookThanks.Columns(0).HeaderCell.Value = "المعرف"
        DGVBookThanks.Columns(1).HeaderCell.Value = "التأثير"
        DGVBookThanks.Columns(2).HeaderCell.Value = "العدد"
        DGVBookThanks.Columns(3).HeaderCell.Value = "التاريخ "
        DGVBookThanks.Columns(4).HeaderCell.Value = "الملاحظات"
        DGVBookThanks.Columns(5).HeaderCell.Value = "تاريخ الاضافة"

        ' Hide sensitive columns
        DGVBookThanks.Columns(6).Visible = False
        DGVBookThanks.Columns(7).Visible = False
    End Sub
End Class
