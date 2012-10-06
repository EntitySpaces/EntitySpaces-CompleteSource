Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Navigation

Imports Silverlight_RiaServices.Web

Imports Silverlight_RiaServices.BusinessObjects
Imports System.ServiceModel.DomainServices.Client

Partial Public Class DynamicQuery
    Inherits Page

    Public Sub New()
        InitializeComponent()
    End Sub

    'Executes when the user navigates to this page.
    Protected Overrides Sub OnNavigatedTo(ByVal e As System.Windows.Navigation.NavigationEventArgs)

    End Sub

    Private Sub CustomersDomainDataSource_LoadedData(ByVal sender As System.Object, ByVal e As System.Windows.Controls.LoadedDataEventArgs) Handles CustomersDomainDataSource.LoadedData

        If e.HasError Then
            System.Windows.MessageBox.Show(e.Error.ToString, "Load Error", System.Windows.MessageBoxButton.OK)
            e.MarkErrorAsHandled()
        End If
    End Sub

    Private Sub CustomersDomainDataSourceLoadButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CustomersDomainDataSourceLoadButton.Click

        Dim searchText As String = txtCompanyName.Text

        If searchText.Length = 0 Then
            ' everybody
            searchText = "%"
        End If

        Dim c As New CustomersQueryProxyStub()
        c.Where(c.CompanyName.Like(searchText))

        Dim context As esDomainServices.esDomainContext = TryCast(Me.CustomersDomainDataSource.DomainContext, esDomainServices.esDomainContext)

        context.Load(context.Customers_LoadByDynamicQuery(c), LoadBehavior.RefreshCurrent, AddressOf MyOtherCallback, Nothing)

    End Sub

    Private Sub MyOtherCallback(ByVal loadOperation As LoadOperation(Of Customers))
        CustomersDataGrid.ItemsSource = loadOperation.Entities
    End Sub


End Class
