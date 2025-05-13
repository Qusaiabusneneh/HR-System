Imports System.IO
Imports ClosedXML.Excel

Public Class ExcelHelper
    Public Shared Sub Export(ByVal dataTable As DataTable, ByVal sheetName As String)
        ' Save Dialog
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.RestoreDirectory = True
        saveFileDialog.DefaultExt = "xlsx"
        saveFileDialog.AddExtension = True
        saveFileDialog.Filter = "Excel File(Xlsx)|*.xlsx"
        saveFileDialog.Title = "Export Excel File"

        Dim result As DialogResult = saveFileDialog.ShowDialog()

        If result = DialogResult.OK Then
            Try
                ' Export
                Using xLWorkbook As New XLWorkbook()
                    xLWorkbook.AddWorksheet(dataTable, sheetName)
                    Using ma As New MemoryStream()
                        xLWorkbook.SaveAs(ma)
                        File.WriteAllBytes(saveFileDialog.FileName, ma.ToArray())
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

End Class
