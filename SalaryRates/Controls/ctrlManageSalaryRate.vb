Imports BussinesTier
Imports BussinesTier.HR_System.Core
Public Class ctrlManageSalaryRate
    Private Shared _salaryRateControl As ctrlManageSalaryRate
    Private Shared _main As FRM_Main
    Private addSalaryRateForm As FRM_AddUpdateSalaryRate
    'Private _dtUser As New DataTable()
    Private _bindingSource As BindingSource
    Private SalaryRate As clsSalaryRates = New clsSalaryRates()
    Private Sub New()
        InitializeComponent()
        DGVSalaryRate.RowTemplate.Height = 30
    End Sub
    Public Shared Function Instance(main As FRM_Main) As ctrlManageSalaryRate
        If _salaryRateControl Is Nothing OrElse _salaryRateControl.IsDisposed Then
            _salaryRateControl = New ctrlManageSalaryRate()
            _main = main
            _salaryRateControl._LoadSalaryRates() ' Load data only when instance is created
        End If
        Return _salaryRateControl
    End Function
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open Add/Update form only if not already open
        If addSalaryRateForm Is Nothing OrElse addSalaryRateForm.IsDisposed Then
            addSalaryRateForm = New FRM_AddUpdateSalaryRate(_main)
            addSalaryRateForm.Show()
            ctrlManageSalaryRate_Load(Nothing, Nothing)
        Else
            addSalaryRateForm.Focus()
        End If
    End Sub
    Private Sub brnUpdate_Click(sender As Object, e As EventArgs) Handles brnUpdate.Click
        If DGVSalaryRate.CurrentRow IsNot Nothing AndAlso DGVSalaryRate.CurrentRow.Cells(0).Value IsNot Nothing Then
            Dim frm As New FRM_AddUpdateSalaryRate(CType(DGVSalaryRate.CurrentRow.Cells(0).Value, Integer))
            frm.Show()
        Else
            MessageBox.Show("No row selected or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If DGVSalaryRate.CurrentRow Is Nothing OrElse DGVSalaryRate.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVSalaryRate.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If SalaryRate.DeleteSalaryRates(ID) Then
                    MessageBox.Show($"Salary Rate with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlManageSalaryRate_Load(Nothing, Nothing)
                    clsSystemRecord.AddSystemRecord($"حذف راتب", $"تم حذف معلومات راتب يحمل الرقم التعريفي {ID.ToString()}")
                Else
                    MessageBox.Show($"Error deleting Salary Rate with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid Salary ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = SalaryRate.GetAllSalaryRates()
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
                _LoadSalaryRates() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVSalaryRate.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)

                ' Use square brackets around column names
                dv.RowFilter = $"[FullName] LIKE '%{searchText}%' OR 
                            [Username] LIKE '%{searchText}%' OR
                            [Email] LIKE '%{searchText}%' OR 
                            [Role] LIKE '%{searchText}%' OR
                            [Phone] LIKE '%{searchText}%'"

                DGVSalaryRate.DataSource = dv
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

            If dataTable.Columns.Contains("Degree") Then
                dataTable.Columns("Degree").SetOrdinal(1)
                dataTable.Columns("Degree").ColumnName = "الدرجة "
            End If

            If dataTable.Columns.Contains("Salary") Then
                dataTable.Columns("Salary").SetOrdinal(2)
                dataTable.Columns("Salary").ColumnName = "الراتب"
            End If

            If dataTable.Columns.Contains("BounsYearRate") Then
                dataTable.Columns("BounsYearRate").SetOrdinal(3)
                dataTable.Columns("BounsYearRate").ColumnName = "العلاوة السنوية"
            End If

            If dataTable.Columns.Contains("PromationYear") Then
                dataTable.Columns("PromationYear").SetOrdinal(4)
                dataTable.Columns("PromationYear").ColumnName = "سنوات الترفيع"
            End If

            If dataTable.Columns.Contains("UserID") Then
                dataTable.Columns("UserID").SetOrdinal(5)
                dataTable.Columns("UserID").ColumnName = "المعرف المستخدم"
            End If
            dataTable.Columns.Remove("UsersID")
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

            ExcelHelper.Export(data, "User")
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub _LoadSalaryRates()
        Try
            Dim dt As DataTable = clsHelper.ConvertListToDataTable(SalaryRate.GetAllSalaryRates())
            If DGVSalaryRate IsNot Nothing Then
                DGVSalaryRate.DataSource = dt
            Else
                MessageBox.Show("DGVUsers is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Set Columns After DataGridView Exists
    Private Sub _SetColumns()
        If DGVSalaryRate Is Nothing OrElse DGVSalaryRate.Columns.Count = 0 Then Exit Sub
        DGVSalaryRate.Columns(0).HeaderCell.Value = "المعرف"
        DGVSalaryRate.Columns(1).HeaderCell.Value = "الدرجة"
        DGVSalaryRate.Columns(2).HeaderCell.Value = "الراتب الاساسي"
        DGVSalaryRate.Columns(3).HeaderCell.Value = "العلاوة السنوية"
        DGVSalaryRate.Columns(4).HeaderCell.Value = "سنوات الترفيع"
        ' Hide sensitive columns
        DGVSalaryRate.Columns(5).Visible = False
    End Sub

    Private Sub ctrlManageSalaryRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadSalaryRates()
        _SetColumns()
    End Sub
End Class
