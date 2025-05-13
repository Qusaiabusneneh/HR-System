Imports BussinesTier
Imports DataAccessTier
Public Class ctrlManageRetirements
    Private Shared _retirementsControl As ctrlManageRetirements
    Private Shared _main As FRM_Main
    Private addRetirementForm As FRM_AddUpdateRetirements
    Private RetirementsBL As clsRetirements = New clsRetirements()
    Private ReadOnly _employees As clsEmployees
    Public Sub New(Employees As clsEmployees)
        InitializeComponent()
        DGVRetirements.RowTemplate.Height = 30
        RetirementsBL = New clsRetirements()
        Me._employees = Employees
        _LoadRetirements()
    End Sub

    Public Sub New()
        InitializeComponent()
        DGVRetirements.RowTemplate.Height = 30
    End Sub

    Public Shared Function Instance(main As FRM_Main) As ctrlManageRetirements
        If _retirementsControl Is Nothing OrElse _retirementsControl.IsDisposed Then
            _retirementsControl = New ctrlManageRetirements()
            _main = main
            _retirementsControl._LoadRetirements() ' Load data only when instance is created
        End If
        Return _retirementsControl
    End Function

    Private Sub ctrlManageEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadRetirements()
        _SetColumns()
    End Sub

    Public Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open Add/Update form only if not already open
        If addRetirementForm Is Nothing OrElse addRetirementForm.IsDisposed Then
            addRetirementForm = New FRM_AddUpdateRetirements(_main, 0, Me, _employees)
            addRetirementForm.Show()
            ctrlManageEmployees_Load(Nothing, Nothing)
        Else
            addRetirementForm.Focus()
        End If
    End Sub

    Private Sub brnUpdate_Click(sender As Object, e As EventArgs) Handles brnUpdate.Click
        If DGVRetirements.CurrentRow IsNot Nothing AndAlso DGVRetirements.CurrentRow.Cells(0).Value IsNot Nothing Then
            Dim frm As New FRM_AddUpdateRetirements(_main, CType(DGVRetirements.CurrentRow.Cells(0).Value, Integer), Me, _employees)
            ctrlManageEmployees_Load(Nothing, Nothing)
            frm.Show()
        Else
            MessageBox.Show("No row selected or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Ensure that a row is selected before proceeding
        If DGVRetirements.CurrentRow Is Nothing OrElse DGVRetirements.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a Employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVRetirements.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete Retriement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If RetirementsBL.DeleteRetirement(ID) Then
                    MessageBox.Show($"Retriement with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlManageEmployees_Load(Nothing, Nothing)
                    clsSystemRecord.AddSystemRecord($"حذف تقاعد", $"تم حذف معلومات تقاعد  يحمل الرقم التعريفي {ID.ToString()}")
                Else
                    MessageBox.Show($"Error deleting Retriement with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid Retriement ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = RetirementsBL.GetAllRetirements()
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
                _LoadRetirements() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVRetirements.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)

                ' Use square brackets around column names
                dv.RowFilter = $" CONVERT([ID], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([HolidayDate], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([Reason], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([Duration], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([Note], 'System.String') LIKE '%{searchText}%' OR
                CONVERT([AddedDate], 'System.String') LIKE '%{searchText}%'"


                DGVRetirements.DataSource = dv
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

            If dataTable.Columns.Contains("RetirementDate") Then
                dataTable.Columns("RetirementDate").SetOrdinal(2)
                dataTable.Columns("RetirementDate").ColumnName = "تاريخ التقاعد"
            End If

            If dataTable.Columns.Contains("Reason") Then
                dataTable.Columns("Reason").SetOrdinal(3)
                dataTable.Columns("Reason").ColumnName = "السبب"
            End If

            If dataTable.Columns.Contains("AddedDate") Then
                dataTable.Columns("AddedDate").SetOrdinal(4)
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

    Private Sub _LoadRetirements()
        Dim retirementList As List(Of clsRetirementDTO) = RetirementsBL.GetAllRetirements()
        DGVRetirements.DataSource = retirementList
    End Sub

    Private Sub _SetColumns()
        If DGVRetirements Is Nothing OrElse DGVRetirements.Columns.Count = 0 Then Exit Sub
        DGVRetirements.Columns(0).HeaderCell.Value = "المعرف"
        DGVRetirements.Columns(2).HeaderCell.Value = "تاريخ الاجازة"
        DGVRetirements.Columns(3).HeaderCell.Value = "السبب"
        DGVRetirements.Columns(4).HeaderCell.Value = "تاريخ الاضافة"

        ' Hide sensitive columns
        DGVRetirements.Columns(1).Visible = False
        DGVRetirements.Columns(5).Visible = False
    End Sub
End Class
