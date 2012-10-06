using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace EntitySpaces.Websites.GridLoader
{

	/// <summary>
	/// Summary description for Utilities
	/// </summary>
	public class Utilities
	{
		// private ctor all functions are static
		private Utilities() {}

		public static string ConstructUrl(string controlKey, string pageName)
		{
		    return string.Format("~/Index.aspx?{0}={1}", controlKey, pageName);
		}

        public static string ConstructUrl(params string[] args)
        {
            string theUrl = "~/Index.aspx?";

            foreach (string parameter in args)
            {
                theUrl = theUrl + parameter;
            }

            return theUrl;
        }
	}

}
