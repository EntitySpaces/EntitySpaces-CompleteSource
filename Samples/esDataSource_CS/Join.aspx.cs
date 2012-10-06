using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BusinessObjects;

public partial class Join : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // NOTE: That we don't have to set the esDataSource.TotalRowCount as of ES2008 in most cases.
        //       By leaving it with the default of -1 this indicates that we want it to set the count
        //       for us, however, the sample code below is an easy way to get the count.

        /*
        if (!this.Page.IsPostBack)
        {
            ProductsQuery p = new ProductsQuery("p");
            CategoriesQuery c = new CategoriesQuery("c");

            p.es.CountAll = true;
            p.es.CountAllAlias = "Count";
            p.InnerJoin(c).On(p.CategoryID == c.CategoryID);

            Products prd = new Products();
            if(prd.Load(p))
            {
                this.EsDataSource1.TotalRowCount = (int)prd.GetColumn("Count");
            }

            this.GridView1.Sort(ProductsMetadata.PropertyNames.ProductID, SortDirection.Ascending);
        }
        */
    }

    protected void EsDataSource1_esSelect(object sender, EntitySpaces.Web.esDataSourceSelectEventArgs e)
    {
        ProductsQuery p = new ProductsQuery("P");
        CategoriesQuery c = new CategoriesQuery("c");

        // All columns from our products table and the CategoryName from the Category table, we really do not
        // display all of the product fields so I could have selected individual fields out of the products
        // table
        p.Select(p, c.CategoryName);
        p.InnerJoin(c).On(p.CategoryID == c.CategoryID);

        // We supply the Collection and the Query, because we're letting the grid to auto paging and
        // auto sorting. Otherwise, we could just load the collection ourselves and only supply the
        // collection
        e.Collection = new ProductsCollection();
        e.Query = p;
    }

    protected void EsDataSource1_esCreateEntity(object sender, EntitySpaces.Web.esDataSourceCreateEntityEventArgs e)
    {
        ProductsQuery p = new ProductsQuery("p");
        CategoriesQuery c = new CategoriesQuery("c");

        p.Select(p, c.CategoryName);
        p.InnerJoin(c).On(p.CategoryID == c.CategoryID);

        if (e.PrimaryKeys != null)
        {
            p.Where(p.ProductID == (int)e.PrimaryKeys[0]);
        }
        else
        {
            // They want to add a new one, lets do a select that brings back
            // no records so that our CategoryName column (virutal) will be
            // present in the underlying record format
            p.Where(1 == 0);
        }

        Products prd = new Products();
        prd.Load(p);  // load the data (if any)

        // Assign the Entity
        e.Entity = prd;
    }

    protected void EsDataSource1_esException(object sender, EntitySpaces.Web.esDataSourceExceptionEventArgs e)
    {
        this.Response.Write("ERROR");
        this.Response.Write("<BR><hr>");
        this.Response.Write(e.TheException.Message);
        this.Response.Write(e.SelectArgs.Query.es.LastQuery);
        this.Response.Write("<hr><br><br>");

        e.ExceptionWasHandled = true;
    }
}
