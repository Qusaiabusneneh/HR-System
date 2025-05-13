Public Class PageHelper
    Private ReadOnly main As FRM_Main

    Public Sub New(main As FRM_Main)
        Me.main = main
    End Sub

    Public Sub SetPage(pageUserControl As UserControl)
        ' get the Current Page
        Dim oldPage As UserControl = main.panContainer.Controls.OfType(Of UserControl)().FirstOrDefault()

        ' Remove old page if it's different from the new one
        If oldPage IsNot Nothing AndAlso oldPage IsNot pageUserControl Then
            main.panContainer.Controls.Remove(oldPage)
        End If

        ' Add the new page if it's not already present
        If oldPage IsNot pageUserControl Then
            pageUserControl.Dock = DockStyle.Fill
            main.panContainer.Controls.Add(pageUserControl)
        End If
    End Sub


End Class

