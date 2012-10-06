Imports BusinessObjects

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' NOTE: That we don't have to set the esDataSource.TotalRowCount as of ES2008 in most cases.
        '       By leaving it with the default of -1 this indicates that we want it to set the count
        '       for us, however, the sample code below is an easy way to get the count.

        'If Not Me.Page.IsPostBack Then

        '    Dim query As New EmployeesQuery()
        '    query.es.CountAll = True
        '    Dim count As Integer = CInt(query.ExecuteScalar())

        '    Me.EsDataSource1.TotalRowCount = count
        '    Me.GridView1.Sort(EmployeesMetadata.PropertyNames.EmployeeID, SortDirection.Ascending)

        'End If

    End Sub

    Protected Sub EsDataSource1_esSelect(ByVal sender As Object, ByVal e As EntitySpaces.Web.esDataSourceSelectEventArgs) Handles EsDataSource1.esSelect

        Dim coll As New EmployeesCollection()

        ' Assign the esDataSourcSelectEvenArgs Collection property
        e.Collection = coll

    End Sub

    Protected Sub EsDataSource1_esCreateEntity(ByVal sender As Object, ByVal e As EntitySpaces.Web.esDataSourceCreateEntityEventArgs) Handles EsDataSource1.esCreateEntity

        Dim entity As New Employees()

        If Not e.PrimaryKeys Is Nothing Then
            entity.LoadByPrimaryKey(CType(e.PrimaryKeys(0), Integer))
        End If

        ' Assign the Entity
        e.Entity = entity

    End Sub



End Class
