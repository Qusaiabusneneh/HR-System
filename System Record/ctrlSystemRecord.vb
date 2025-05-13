Imports BussinesTier
Imports BussinesTier.HR_System.Core
Imports DataAccessTier
Public Class ctrlSystemRecord
    Private Shared _systemRecordControl As ctrlSystemRecord
    Private Shared _main As FRM_Main
    'Private _dtSystemRecords As New DataTable()
    Private _bindingSource As BindingSource
    Private localUser As clsLocalUsers()
    Private SystemRecord As clsSystemRecord = New clsSystemRecord()
    Private SystemRecordDAL As clsSalaryRatesDataAcess = New clsSalaryRatesDataAcess()
    Private Sub New()
        InitializeComponent()
        DGVSystemRecords.RowTemplate.Height = 30
    End Sub
    Public Shared Function Instance(main As FRM_Main) As ctrlSystemRecord
        If _systemRecordControl Is Nothing OrElse _systemRecordControl.IsDisposed Then
            _systemRecordControl = New ctrlSystemRecord()
            _main = main
            _systemRecordControl._LoadSystemRecord() ' Load data only when instance is created
        End If
        Return _systemRecordControl
    End Function
    Private Sub ctrlSystemRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadSystemRecord()
        _SetColumns()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Ensure that a row is selected before proceeding
        If DGVSystemRecords.CurrentRow Is Nothing OrElse DGVSystemRecords.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVSystemRecords.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If SystemRecordDAL.Delete(ID) Then
                    clsSystemRecord.AddSystemRecord($"حذف مستخدم", $"تم حذف مستخدم جديد يحمل الرقم التعريفي {ID}")
                    MessageBox.Show($"SystemRecord with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlSystemRecord_Load(Nothing, Nothing)

                Else
                    MessageBox.Show($"Error deleting SystemRecord with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid SystemRecord ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = clsHelper.ConvertListToDataTable(SystemRecordDAL.GetAllData())
        _exportExcel(Data)
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
                _LoadSystemRecord() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVSystemRecords.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)

                ' Use square brackets around column names
                dv.RowFilter = $"[UserFullName] LIKE '%{searchText}%' OR 
                            [ID] LIKE '%{searchText}%' OR
                            [DeviceName] LIKE '%{searchText}%' OR 
                            [UserID] LIKE '%{searchText}%'"

                DGVSystemRecords.DataSource = dv
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

            If dataTable.Columns.Contains("UserFullName") Then
                dataTable.Columns("UserFullName").SetOrdinal(1)
                dataTable.Columns("UserFullName").ColumnName = "الاسم الكامل"
            End If

            If dataTable.Columns.Contains("DeviceName") Then
                dataTable.Columns("DeviceName").SetOrdinal(2)
                dataTable.Columns("DeviceName").ColumnName = "اسم الجهاز"
            End If

            If dataTable.Columns.Contains("MachineID") Then
                dataTable.Columns("MachineID").SetOrdinal(3)
                dataTable.Columns("MachineID").ColumnName = "MAC-Address"
            End If

            If dataTable.Columns.Contains("Title") Then
                dataTable.Columns("Title").SetOrdinal(4)
                dataTable.Columns("Title").ColumnName = "العنوان"
            End If

            If dataTable.Columns.Contains("UserID") Then
                dataTable.Columns("UserID").SetOrdinal(5)
                dataTable.Columns("UserID").ColumnName = "المعرف المستخدم"
            End If

            If dataTable.Columns.Contains("Description") Then
                dataTable.Columns("Description").SetOrdinal(6)
                dataTable.Columns("Description").ColumnName = "وصف الحركة"
            End If

            If dataTable.Columns.Contains("CreatedDate") Then
                dataTable.Columns("CreatedDate").SetOrdinal(7)
                dataTable.Columns("CreatedDate").ColumnName = "تاريخ الحركة"
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

            ExcelHelper.Export(data, "User")
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub _LoadSystemRecord()
        Try
            Dim dt As DataTable = clsHelper.ConvertListToDataTable(SystemRecord.GetAllRecords())
            If DGVSystemRecords IsNot Nothing Then
                DGVSystemRecords.DataSource = dt
            Else
                MessageBox.Show("DGVSystemRecords is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading System Record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub _SetColumns()
        If DGVSystemRecords IsNot Nothing AndAlso DGVSystemRecords.Columns.Count >= 8 Then
            DGVSystemRecords.Columns(0).HeaderCell.Value = "المعرف"
            DGVSystemRecords.Columns(1).HeaderCell.Value = "الاسم الكامل"
            DGVSystemRecords.Columns(2).HeaderCell.Value = "اسم الجهاز"
            DGVSystemRecords.Columns(3).HeaderCell.Value = "الصلاحية"
            DGVSystemRecords.Columns(4).HeaderCell.Value = "MAC-Address"
            DGVSystemRecords.Columns(5).HeaderCell.Value = "العنوان"
            DGVSystemRecords.Columns(6).HeaderCell.Value = "الوصف"
            DGVSystemRecords.Columns(7).HeaderCell.Value = "تاريخ الحركة"
            'DGVUsers.Columns(8).HeaderCell.Value = "معرف المستخدم"
        Else
            MessageBox.Show("DataGridView is not initialized or has insufficient columns.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
