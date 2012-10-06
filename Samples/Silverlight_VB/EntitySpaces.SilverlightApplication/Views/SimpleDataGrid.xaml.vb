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
Imports EntitySpaces.SilverlightApplication.NorthwindClient

Imports Proxies

Partial Public Class SimpleDataGrid
    Inherits Page

    Private service As New NorthwindClient.NorthwindClient()
    Private employees As Proxies.EmployeesCollectionProxyStub
    Private Timer As New System.Windows.Media.Animation.Storyboard()
    Private RecordsAdded As Integer

    Public Sub New()
        InitializeComponent()

        AddHandler Timer.Completed, AddressOf Timer_Completed
        Timer.Duration = TimeSpan.FromMilliseconds(2)

        AddHandler service.Employees_QueryForCollectionCompleted, AddressOf Employees_QueryForCollectionCompleted
        AddHandler service.Employees_SaveCollectionCompleted, AddressOf Employees_SaveCollectionCompleted

    End Sub

    ' Executes when the user navigates to this page.
    Protected Overloads Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
    End Sub

    Private Sub SearchButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            Dim q As New Proxies.EmployeesQueryProxyStub("emp")
            q.Select(q.EmployeeID, q.FirstName, q.LastName, q.HireDate, q.BirthDate, ((q.LastName + ", ") + q.FirstName).[As]("Fullname"))
            q.Where(q.FirstName.Like("%" + SearchTextBox.Text + "%") Or q.LastName.Like("%" + SearchTextBox.Text + "%"))

            service.Employees_QueryForCollectionAsync(q)

            WorkingBar.Value = 0
            Timer.Begin()

        Catch exc As Exception
            Console.WriteLine(exc.StackTrace)
        End Try
    End Sub

    Private Sub Employees_QueryForCollectionCompleted(ByVal sender As Object, ByVal e As Employees_QueryForCollectionCompletedEventArgs)
        WorkingBar.Value = 100
        Timer.[Stop]()

        If e.Result IsNot Nothing Then
            employees = e.Result
            EmployeesDataGrid.ItemsSource = employees.Collection
        Else
            EmployeesDataGrid.ItemsSource = Nothing
        End If

    End Sub

    Private Sub ClearButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        SearchTextBox.Text = ""
        employees = Nothing
        EmployeesDataGrid.ItemsSource = Nothing
    End Sub

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            If employees Is Nothing Then
                Exit Sub
            End If

            WorkingBar.Value = 0
            Timer.Begin()

            service.Employees_SaveCollectionAsync(employees)
        Catch exc As Exception
            Console.WriteLine(exc.StackTrace)
        End Try
    End Sub

    Private Sub AddButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If employees Is Nothing Then
            employees = New EmployeesCollectionProxyStub()
            EmployeesDataGrid.ItemsSource = employees.Collection
        End If

        RecordsAdded += 1

        If RecordsAdded < 5 Then
            Dim newEmp As New EmployeesProxyStub()
            newEmp.FirstName = "Scott"
            newEmp.LastName = "Schecter"

            employees.Collection.Add(newEmp)
        End If

    End Sub

    Private Sub DeleteButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim emp As EmployeesProxyStub = TryCast(EmployeesDataGrid.SelectedItem, EmployeesProxyStub)

        employees.Collection.Remove(emp)

        emp.MarkAsDeleted()
        service.Employees_SaveEntityAsync(emp)
    End Sub

    Private Sub Employees_SaveCollectionCompleted(ByVal sender As Object, ByVal e As Employees_SaveCollectionCompletedEventArgs)
        Try
            WorkingBar.Value = 100
            Timer.[Stop]()

            RecordsAdded = 0

            employees = e.Result
            EmployeesDataGrid.ItemsSource = employees.Collection
        Catch exc As Exception
            Console.WriteLine(exc.StackTrace)
        End Try
    End Sub

    Private Sub SearchTextBox_GotFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If SearchTextBox.Text = "Enter Criteria Here" Then
            SearchTextBox.Text = ""
        End If
    End Sub

    Private Sub Timer_Completed(ByVal sender As Object, ByVal e As EventArgs)
        WorkingBar.Value += 1
        Timer.Begin()

        If WorkingBar.Value >= 100 Then
            WorkingBar.UpdateLayout()
            WorkingBar.Value = 1
        End If
    End Sub
End Class
