Imports Silverlight_RiaServices.BusinessObjects

Partial Public Class Editing
    Inherits Page

    Public Sub New()
        InitializeComponent()
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub

    Private Sub EmployeesDomainDataSource_LoadedData(ByVal sender As System.Object, ByVal e As System.Windows.Controls.LoadedDataEventArgs) Handles EmployeesDomainDataSource.LoadedData

        If e.HasError Then
            System.Windows.MessageBox.Show(e.Error.ToString, "Load Error", System.Windows.MessageBoxButton.OK)
            e.MarkErrorAsHandled()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSave.Click

        Try
            AddHandler EmployeesDomainDataSource.SubmittedChanges, AddressOf OnSubmittedChanges
            EmployeesDomainDataSource.SubmitChanges()
        Catch
        End Try

    End Sub

    Private Sub OnSubmittedChanges(ByVal sender As Object, ByVal e As SubmittedChangesEventArgs)
        If e.HasError Then
            ' Prevents the application from throwing an exception
            e.MarkErrorAsHandled()
        End If
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnAdd.Click

        ' Create a new Employee
        Dim emp As New Employees()
        emp.FirstName = "David"
        emp.LastName = "Parsons"

        ' Add it to the context so RIA knows about it
        EmployeesDomainDataSource.DataView.Add(emp)

    End Sub

    Private Sub btnMarkAsDeleted_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnMarkAsDeleted.Click

        Dim emp As Employees = TryCast(EmployeesDataGrid.SelectedItem, Employees)

        If emp IsNot Nothing Then
            EmployeesDomainDataSource.DataView.Remove(emp)
        End If

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnRefresh.Click

        EmployeesDomainDataSource.Clear()
        EmployeesDomainDataSource.RejectChanges()
        EmployeesDomainDataSource.Load()

    End Sub
End Class
