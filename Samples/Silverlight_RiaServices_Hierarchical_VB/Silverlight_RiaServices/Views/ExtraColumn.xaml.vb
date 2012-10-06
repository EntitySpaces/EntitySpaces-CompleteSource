Partial Public Class ExtraColumn
    Inherits Page

    Public Sub New()
        InitializeComponent()
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub

    Private Sub ProductsDomainDataSource_LoadedData(ByVal sender As System.Object, ByVal e As System.Windows.Controls.LoadedDataEventArgs) Handles ProductsDomainDataSource.LoadedData

        If e.HasError Then
            System.Windows.MessageBox.Show(e.Error.ToString, "Load Error", System.Windows.MessageBoxButton.OK)
            e.MarkErrorAsHandled()
        End If
    End Sub
End Class
