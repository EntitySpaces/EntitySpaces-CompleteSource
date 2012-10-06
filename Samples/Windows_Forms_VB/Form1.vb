Imports WindowsFormsVB.BusinessObjects

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Loader
Imports EntitySpaces.Profiler

Public Class Form1

    Private coll As New EmployeesCollection
    Private acending As Boolean
    Private filtered As Boolean


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' This only needs to be done once per the entire application
        esProviderFactory.Factory = New esDataProviderFactory()

        Try
            dataGridView1.AutoGenerateColumns = True
            coll.LoadAll()

            ' Bind to our EntitySpaces Collection
            _bindingSource.DataSource = coll

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            coll.Save()
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSort.Click

        If acending Then
            acending = False
            coll.Filter = coll.AsQueryable().OrderByDescending(Function(d) d.LastName)
        Else
            acending = True
            coll.Filter = coll.AsQueryable().OrderBy(Function(d) d.LastName)
        End If

    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        If filtered Then
            filtered = False
            coll.Filter = Nothing
        Else
            filtered = True
            coll.Filter = coll.AsQueryable().Where(Function(d) d.FirstName.Contains("a"))
        End If

    End Sub

    Private Sub btnFilterSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterSort.Click

        If acending Then
            acending = False
            coll.Filter = coll.AsQueryable().Where(Function(d) d.FirstName.Contains("a"))
        Else
            acending = True
            coll.Filter = coll.AsQueryable().Where(Function(d) d.FirstName.Contains("a")).OrderBy(Function(d) d.LastName)
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim emp = coll.AddNew()
        emp.FirstName = "Joe"
        emp.LastName = "Smith"

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim selectedRows = dataGridView1.SelectedRows

        Dim list As New List(Of Employees)()

        For Each item As DataGridViewRow In selectedRows
            Dim emp As Employees = TryCast(item.DataBoundItem, Employees)

            If emp IsNot Nothing Then
                list.Add(emp)
            End If
        Next

        For Each emp As Employees In list
            emp.MarkAsDeleted()
        Next

    End Sub

    Private Sub btnChangeFirstName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeFirstName.Click

        For Each emp As Employees In coll
            emp.FirstName = "Sally"
        Next

    End Sub

    Private Sub btnDynamicQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDynamicQuery.Click

        btnAdd.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False

        Dim eq As New EmployeesQuery("eq")
        Dim oq As New OrdersQuery("oq")

        eq.[Select](eq.EmployeeID, eq.LastName, eq.FirstName, oq.OrderID, oq.ShipCity)
        eq.InnerJoin(oq).[On](eq.EmployeeID = oq.EmployeeID)

        coll = New EmployeesCollection()
        coll.Load(eq)

        _bindingSource.DataSource = coll

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        btnAdd.Enabled = True
        btnDelete.Enabled = True
        btnSave.Enabled = True

        coll = New EmployeesCollection()
        coll.LoadAll()

        _bindingSource.DataSource = coll

    End Sub

    Private Sub btnBeginProfiling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeginProfiling.Click

        ProfilerListener.BeginProfiling("EntitySpaces.SqlClientProvider", ProfilerListener.Channels.Channel_1)

    End Sub

    Private Sub btnEndProfiling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndProfiling.Click

        ProfilerListener.EndProfiling("EntitySpaces.SqlClientProvider")

    End Sub

End Class
