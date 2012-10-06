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
    public partial class Index : System.Web.UI.Page
    {
        #region Private Members

        private string _pageName;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString[Constants.ControlKey]))
                {
                    _pageName = Request.QueryString[Constants.ControlKey];
                }

                LoadUserControl(_pageName);
            }

            catch (Exception exc)
            {
                //Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #region Generated User Control Load Logic

        private void LoadUserControl(string pageName)
        {
            try
            {
                if (!string.IsNullOrEmpty(pageName))
                {
                    Control control =
                        LoadControl(string.Concat(Constants.GeneratedControlsDirectory, pageName,
                        Constants.ControlPostfix, Constants.ControlFileExtenstion));

                    ContentPlaceHolder.Controls.Add(control);
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath(Constants.GeneratedControlsDirectory));
                    FileInfo[] files = di.GetFiles(string.Concat("*", Constants.ControlFileExtenstion), SearchOption.TopDirectoryOnly);

                    foreach (FileInfo file in files)
                    {
                        Control control = LoadControl(string.Concat(Constants.GeneratedControlsDirectory, file.Name));
                        ContentPlaceHolder.Controls.Add(control);
                        return;
                    }

                    Label warning = new Label();
                    warning.ID = "WarningLabel";
                    warning.CssClass = "es_error_label";
                    warning.Text = "No user controls found to load";

                    ContentPlaceHolder.Controls.Add(warning);
                }
            }

            catch (Exception exc)
            {
                //Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}
