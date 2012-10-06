using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using BusinessObjects;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // NOTE: That we don't have to set the esDataSource.TotalRowCount as of ES2008 in most cases.
        //       By leaving it with the default of -1 this indicates that we want it to set the count
        //       for us, however, the sample code below is an easy way to get the count.

        /*
        if (!this.Page.IsPostBack)
        {
            EmployeesQuery query = new EmployeesQuery();   
            query.es.CountAll = true;   
            int count = (int)query.ExecuteScalar();   

            this.EsDataSource1.TotalRowCount = count;
            this.GridView1.Sort(EmployeesMetadata.PropertyNames.EmployeeID, SortDirection.Ascending);
        }
        */
    }

    protected void EsDataSource1_esSelect(object sender, EntitySpaces.Web.esDataSourceSelectEventArgs e)
    {
        EmployeesCollection coll = new EmployeesCollection();

        // Assign the esDataSourcSelectEvenArgs Collection property
        e.Collection = coll;
    }

    protected void EsDataSource1_esCreateEntity(object sender, EntitySpaces.Web.esDataSourceCreateEntityEventArgs e)
    {
        Employees entity = new Employees();

        if (e.PrimaryKeys != null)
        {
            entity.LoadByPrimaryKey((int)e.PrimaryKeys[0]);
        }

        // Assign the Entity
        e.Entity = entity;
    }
}
