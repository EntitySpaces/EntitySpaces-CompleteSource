Imports BusinessObjects

Partial Class Join
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' NOTE: That we don't have to set the esDataSource.TotalRowCount as of ES2008 in most cases.
        '       By leaving it with the default of -1 this indicates that we want it to set the count
        '       for us, however, the sample code below is an easy way to get the count.

        'If Not Me.Page.IsPostBack Then

        '    Dim p As New ProductsQuery("p")
        '    Dim c As New CategoriesQuery("c")

        '    p.es.CountAll = True
        '    p.es.CountAllAlias = "Count"
        '    p.InnerJoin(c).On(p.CategoryID = c.CategoryID)

        '    Dim prd = New Products()
        '    If (prd.Load(p)) Then
        '        Me.EsDataSource1.TotalRowCount = CType(prd.GetColumn("Count"), Integer)
        '    End If

        '    Me.GridView1.Sort(ProductsMetadata.PropertyNames.ProductID, SortDirection.Ascending)

        'End If

    End Sub

    Protected Sub EsDataSource1_esSelect(ByVal sender As Object, ByVal e As EntitySpaces.Web.esDataSourceSelectEventArgs) Handles EsDataSource1.esSelect

        Dim p As New ProductsQuery("p")
        Dim c As New CategoriesQuery("c")

        ' All columns from our products table and the CategoryName from the Category table, we really do not
        ' display all of the product fields so I could have selected individual fields out of the products
        ' table
        p.Select(p, c.CategoryName)
        p.InnerJoin(c).On(p.CategoryID = c.CategoryID)

        ' We supply the Collection and the Query, because we're letting the grid to auto paging and
        ' auto sorting. Otherwise, we could just load the collection ourselves and only supply the
        ' collection
        e.Collection = New ProductsCollection()
        e.Query = p

    End Sub

    Protected Sub EsDataSource1_esCreateEntity(ByVal sender As Object, ByVal e As EntitySpaces.Web.esDataSourceCreateEntityEventArgs) Handles EsDataSource1.esCreateEntity

        Dim p As New ProductsQuery("p")
        Dim c As New CategoriesQuery("c")

        p.Select(p, c.CategoryName)
        p.InnerJoin(c).On(p.CategoryID = c.CategoryID)

        If Not e.PrimaryKeys Is Nothing Then
            p.Where(p.ProductID = CType(e.PrimaryKeys(0), Integer))
        Else
            ' They want to add a new one, lets do a select that brings back
            ' no records so that our CategoryName column (virutal) will be
            ' present in the underlying record format
            p.Where(1 = 0)
        End If

        Dim prd As New Products()
        prd.Load(p)  ' load the data (if any)

        ' Assign the Entity
        e.Entity = prd

    End Sub

End Class
