using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace EntitySpaces.Websites.GridLoader
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //---------------------------------------------------------------
            // Assign the Medium Trust Loader
            //---------------------------------------------------------------        
            EntitySpaces.Interfaces.esProviderFactory.Factory =
                new EntitySpaces.LoaderMT.esDataProviderFactory();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}