using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace EntitySpaces.Websites.GridLoader
{
    public partial class Navigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateIndex();
        }

        private void CreateIndex()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(Server.MapPath(Constants.GeneratedControlsDirectory));
                FileInfo[] files = di.GetFiles(string.Concat("*", Constants.ControlFileExtenstion), SearchOption.TopDirectoryOnly);

                foreach (FileInfo file in files)
                {
                    HyperLink link = new HyperLink();
                    link.NavigateUrl = Utilities.ConstructUrl(Constants.ControlKey,
                      file.Name.Replace(string.Concat(Constants.ControlPostfix, Constants.ControlFileExtenstion), string.Empty));

                    link.Text = file.Name.Replace(
                        string.Concat(Constants.ControlPostfix, Constants.ControlFileExtenstion), string.Empty);

                    NavigationMenuStripPlaceHolder.Controls.Add(link);
                    NavigationMenuStripPlaceHolder.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                }
            }

            catch (Exception exc)
            {
                //Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
    }
}