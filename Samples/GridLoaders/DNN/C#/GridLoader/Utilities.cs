using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Exceptions;

namespace EntitySpaces.Modules.GridLoader
{

	/// <summary>
	/// Summary description for Utilities
	/// </summary>
	public class Utilities
	{
		// private ctor all functions are static
		private Utilities() {}

		public static string ConstructUrl(params string[] args)
		{
			PortalSettings ps = PortalController.GetCurrentPortalSettings();
			return Globals.NavigateURL(ps.ActiveTab.TabID, string.Empty, args);
		}

		public static string ConstructUrl(int tabId, params string[] args)
		{
			return Globals.NavigateURL(tabId, string.Empty, args);
		}
	}

}
