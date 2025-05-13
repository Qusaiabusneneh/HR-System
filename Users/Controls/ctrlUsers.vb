Imports System.Net.Security
Imports BussinesTier
Imports BussinesTier.HR_System.Core
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class ctrlUsers
    Private Shared _userControl As ctrlUsers
    Private Shared _main As FRM_Main
    Private addUserForm As FRM_AddUpdateUsers
    Private _dtUser As New DataTable()
    Private _bindingSource As BindingSource
    Private Sub New()
        InitializeComponent()
        DGVUsers.RowTemplate.Height = 30
    End Sub
    Public Shared Function Instance(main As FRM_Main) As ctrlUsers
        If _userControl Is Nothing OrElse _userControl.IsDisposed Then
            _userControl = New ctrlUsers()
            _main = main
            _userControl._LoadUser() ' Load data only when instance is created
        End If
        Return _userControl
    End Function
    Private Sub ctrlUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadUser()
        _SetColumns()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open Add/Update form only if not already open
        If addUserForm Is Nothing OrElse addUserForm.IsDisposed Then
            addUserForm = New FRM_AddUpdateUsers(_main)
            addUserForm.Show()
            ctrlUsers_Load(Nothing, Nothing)
        Else
            addUserForm.Focus()
        End If
    End Sub
    Private Sub brnUpdate_Click(sender As Object, e As EventArgs) Handles brnUpdate.Click
        If DGVUsers.CurrentRow IsNot Nothing AndAlso DGVUsers.CurrentRow.Cells(0).Value IsNot Nothing Then
            Dim frm As New FRM_AddUpdateUsers(CType(DGVUsers.CurrentRow.Cells(0).Value, Integer))
            ctrlUsers_Load(Nothing, Nothing)
            frm.Show()
        Else
            MessageBox.Show("No row selected or invalid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Ensure that a row is selected before proceeding
        If DGVUsers.CurrentRow Is Nothing OrElse DGVUsers.CurrentRow.Cells.Count = 0 Then
            MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ID As Integer
        If Integer.TryParse(DGVUsers.CurrentRow.Cells(0).Value.ToString(), ID) Then
            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this item {ID}?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If Not clsUsers.Delete(ID) Then
                    MessageBox.Show($"User with ID: {ID} was deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ctrlUsers_Load(Nothing, Nothing)
                    clsSystemRecord.AddSystemRecord($"حذف مستخدم", $"تم حذف معلومات مستخدم يحمل الرقم التعريفي {ID.ToString()}")
                Else
                    MessageBox.Show($"Error deleting user with ID: {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Invalid User ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim Data = clsHelper.ConvertListToDataTable(clsUsers.GetAllUser())
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
                _LoadUser() ' Reload all data if search box is empty
                Exit Sub
            End If

            ' Escape special characters in search text
            searchText = searchText.Replace("'", "''")

            Dim dt As DataTable = TryCast(DGVUsers.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As New DataView(dt)

                ' Use square brackets around column names
                dv.RowFilter = $"[FullName] LIKE '%{searchText}%' OR 
                            [Username] LIKE '%{searchText}%' OR
                            [Email] LIKE '%{searchText}%' OR 
                            [Role] LIKE '%{searchText}%' OR
                            [Phone] LIKE '%{searchText}%'"

                DGVUsers.DataSource = dv
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

            If dataTable.Columns.Contains("Username") Then
                dataTable.Columns("Username").SetOrdinal(2)
                dataTable.Columns("Username").ColumnName = "اسم المستخدم"
            End If

            If dataTable.Columns.Contains("Password") Then
                dataTable.Columns("Password").SetOrdinal(3)
                dataTable.Columns("Password").ColumnName = "كلمة السر"
            End If

            If dataTable.Columns.Contains("Role") Then
                dataTable.Columns("Role").SetOrdinal(4)
                dataTable.Columns("Role").ColumnName = "الصلاحيات"
            End If

            If dataTable.Columns.Contains("IsSecondaryUser") Then
                dataTable.Columns("IsSecondaryUser").SetOrdinal(5)
                dataTable.Columns("IsSecondaryUser").ColumnName = "هل المستخدم ثانوي"
            End If

            If dataTable.Columns.Contains("UserID") Then
                dataTable.Columns("UserID").SetOrdinal(6)
                dataTable.Columns("UserID").ColumnName = "المعرف المستخدم"
            End If

            If dataTable.Columns.Contains("Phone") Then
                dataTable.Columns("Phone").SetOrdinal(7)
                dataTable.Columns("Phone").ColumnName = "رقم الهاتف"
            End If

            If dataTable.Columns.Contains("Email") Then
                dataTable.Columns("Email").SetOrdinal(8)
                dataTable.Columns("Email").ColumnName = "البريد الالكتروني"
            End If

            If dataTable.Columns.Contains("Address") Then
                dataTable.Columns("Address").SetOrdinal(9)
                dataTable.Columns("Address").ColumnName = "العنوان"
            End If

            If dataTable.Columns.Contains("CreatedDate") Then
                dataTable.Columns("CreatedDate").SetOrdinal(10)
                dataTable.Columns("CreatedDate").ColumnName = "تاريخ الانشاء"
            End If

            If dataTable.Columns.Contains("EditedDate") Then
                dataTable.Columns("EditedDate").SetOrdinal(11)
                dataTable.Columns("EditedDate").ColumnName = "تاريخ التحديث"
            End If

            ' Check before removing columns to avoid runtime errors
            If dataTable.Columns.Contains("Roles") Then
                dataTable.Columns.Remove("Roles")
            End If

            If dataTable.Columns.Contains("systemRecords") Then
                dataTable.Columns.Remove("systemRecords")
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
    Private Sub _LoadUser()
        Try
            Dim dt As DataTable = clsHelper.ConvertListToDataTable(clsUsers.GetAllUser())
            If DGVUsers IsNot Nothing Then
                DGVUsers.DataSource = dt
            Else
                MessageBox.Show("DGVUsers is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Set Columns After DataGridView Exists
    Private Sub _SetColumns()
        If DGVUsers Is Nothing OrElse DGVUsers.Columns.Count = 0 Then Exit Sub
        DGVUsers.Columns(0).HeaderCell.Value = "المعرف"
        DGVUsers.Columns(1).HeaderCell.Value = "الاسم الكامل"
        DGVUsers.Columns(2).HeaderCell.Value = "اسم المستخدم"
        DGVUsers.Columns(4).HeaderCell.Value = "رقم الهاتف"
        DGVUsers.Columns(5).HeaderCell.Value = "البريد الالكتروني"
        DGVUsers.Columns(6).HeaderCell.Value = "السكن"
        DGVUsers.Columns(7).HeaderCell.Value = "الصلاحية"
        DGVUsers.Columns(8).HeaderCell.Value = "تاريخ الانشاء"
        DGVUsers.Columns(9).HeaderCell.Value = "تاريخ التعديل"
        'DGVUsers.Columns(9).HeaderCell.Value = "كلمة السر"
        'DGVUsers.Columns(10).HeaderCell.Value = "هل المستخدم ثانوي"
        'DGVUsers.Columns(11).HeaderCell.Value = "المعرف الاساس"

        ' Hide sensitive columns
        DGVUsers.Columns(3).Visible = False
        DGVUsers.Columns(10).Visible = False
        DGVUsers.Columns(11).Visible = False
        'DGVUsers.Columns(9).Visible = False
        'DGVUsers.Columns(10).Visible = False
        'DGVUsers.Columns(11).Visible = False
    End Sub
End Class
