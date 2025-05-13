Imports System.Net.Security
Imports BussinesTier
Imports BussinesTier.HR_System.Core
Imports DataAccessTier
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class ctrlManageAbsences
    Private Shared _bookThanksControl As ctrlManageAbsences
    Private Shared _main As FRM_Main
    Private addAbsencesForm As FRM_AddUpdateAbsences
    Private AbsencesBL As clsAbsences = New clsAbsences()
    Private ReadOnly _employees As clsEmployees
    Public Sub New(Employees As clsEmployees)
        InitializeComponent()
        DGVAbsences.RowTemplate.Height = 30
        AbsencesBL = New clsAbsences()
        Me._employees = Employees
        _LoadAbsences()
    End Sub
    Private Sub ctrlManageEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadAbsences()
        _SetColumns()
    End Sub
    Public Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open Add/Update form only if not already open
        If addAbsencesForm Is Nothing OrElse addAbsencesForm.IsDisposed Then
            addAbsencesForm = New FRM_AddUpdateAbsences(_main, 0, Me, _employees)
            addAbsencesForm.Show()
            ctrlManageEmployees_Load(Nothing, Nothing)
        Else
            addAbsencesForm.Focus()
        End If
    End Sub
    Private Sub brnUpdate_Click(sender As Object, e As EventArgs) Handles brnUpdate.Click
        If DGVAbsences.CurrentRow IsNot Nothing AndAlso DGVAbsences.CurrentRow.Cells(0).Value IsNot Nothing Then
            Dim frm As New FRM_AddUpdateAbsences(_main, CType(DGVAbsences.CurrentRow.Cells(0).Value, Integer), Me, _employees)
            ctrlManageEmployees_Load(Nothing, Nothing)
            frm.Show()
        Else
            MessageBox.Show("No row selected or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Ensure that a row is selected before proceeding
        If DGVAbsences.CurrentRow Is Nothing OrElse DGVAbsences.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a Employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVAbsences.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If AbsencesBL.Delete(ID) Then
                    MessageBox.Show($"Absence with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlManageEmployees_Load(Nothing, Nothing)
                    clsSystemRecord.AddSystemRecord($"حذف غياب", $"تم حذف معلومات غياب يحمل الرقم التعريفي {ID.ToString()}")
                Else
                    MessageBox.Show($"Error deleting Abseces with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid Abseces ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = AbsencesBL.GetAllData()
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
                _LoadAbsences() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVAbsences.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)

                ' Use square brackets around column names
                dv.RowFilter = $"[Duration] LIKE '%{searchText}%' OR 
                [AbsenceType] LIKE '%{searchText}%' OR
                [Note] LIKE '%{searchText}%' OR 
                CONVERT([ID], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([AbsenceDate], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([AddedDate], 'System.String') LIKE '%{searchText}%'"

                DGVAbsences.DataSource = dv
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
                dataTable.Columns("EmployeeID").ColumnName = "رقم المعرف "
            End If

            If dataTable.Columns.Contains("AbsenceDate") Then
                dataTable.Columns("AbsenceDate").SetOrdinal(2)
                dataTable.Columns("AbsenceDate").ColumnName = " تاريخ الغياب"
            End If

            If dataTable.Columns.Contains("Duration") Then
                dataTable.Columns("Duration").SetOrdinal(3)
                dataTable.Columns("Duration").ColumnName = "المدة"
            End If

            If dataTable.Columns.Contains("AbsenceType") Then
                dataTable.Columns("AbsenceType").SetOrdinal(4)
                dataTable.Columns("AbsenceType").ColumnName = "نوع الغياب"
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
    Private Sub _LoadAbsences()
        Dim ID As Integer = _employees.ID
        Dim absenceList As List(Of clsAbsencesDTO) = AbsencesBL.GetAllData().Where(Function(x) x.EmployeeID = ID).ToList()
        DGVAbsences.DataSource = absenceList
    End Sub
    Private Sub _SetColumns()
        If DGVAbsences Is Nothing OrElse DGVAbsences.Columns.Count = 0 Then Exit Sub
        DGVAbsences.Columns(0).HeaderCell.Value = "المعرف"
        DGVAbsences.Columns(2).HeaderCell.Value = "تاريخ الغياب"
        DGVAbsences.Columns(3).HeaderCell.Value = "المدة"
        DGVAbsences.Columns(4).HeaderCell.Value = "نوع الغياب"
        DGVAbsences.Columns(5).HeaderCell.Value = " الملاحظات"
        DGVAbsences.Columns(6).HeaderCell.Value = " تاريخ الاضافة"

        ' Hide sensitive columns
        DGVAbsences.Columns(1).Visible = False
        DGVAbsences.Columns(7).Visible = False
    End Sub
End Class
