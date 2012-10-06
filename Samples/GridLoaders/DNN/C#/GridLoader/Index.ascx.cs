using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Entities.Users;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;

using BusinessObjects;
using EntitySpaces.Interfaces;

namespace EntitySpaces.Modules.GridLoader
{ 

	partial class Index : PortalModuleBase, IActionable
	{

		#region Private Members
		
		private string _pageName;
	
		#endregion

		#region Event Handlers

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(Request.QueryString[Constants.ControlKey]))
				{
					_pageName = Request.QueryString[Constants.ControlKey];
				}

                SetConnection();
				LoadUserControl(_pageName);
			}

			catch (Exception exc)
			{
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		#endregion

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
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		#endregion

        #region EntitySpaces Connection Logic

        private void SetConnection()
        {
            if (esConfigSettings.ConnectionInfo.Default != "SiteSqlServer")
            {
                esConfigSettings ConnectionInfoSettings = esConfigSettings.ConnectionInfo;
                foreach (esConnectionElement connection in ConnectionInfoSettings.Connections)
                {
                    //if there is a SiteSqlServer in es connections set it default
                    if (connection.Name == "SiteSqlServer")
                    {
                        esConfigSettings.ConnectionInfo.Default = connection.Name;
                        return;
                    }
                }

                //no SiteSqlServer found grab dnn cnn string and create
                string dnnConnection = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
                
                // Manually register a connection (DO THIS ONE TIME ONLY)
                esConnectionElement conn = new esConnectionElement();
                conn.ConnectionString = dnnConnection;
                conn.Name = "SiteSqlServer";
                conn.Provider = "EntitySpaces.SqlClientProvider";
                conn.ProviderClass = "DataProvider";
                conn.SqlAccessType = esSqlAccessType.DynamicSQL;
                conn.ProviderMetadataKey = "esDefault";
                conn.DatabaseVersion = "2005";
                esConfigSettings.ConnectionInfo.Connections.Add(conn);

                // Assign the Default Connection
                esConfigSettings.ConnectionInfo.Default = "SiteSqlServer";

                // Register the Loader
                esProviderFactory.Factory = new LoaderMT.esDataProviderFactory();
            }
        }

        #endregion

		#region Optional Interfaces

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// Registers the module actions required for interfacing with the portal framework
		/// </summary>
		/// <value></value>
		/// <returns></returns>
		/// <remarks></remarks>
		/// <history>
		/// </history>
		/// -----------------------------------------------------------------------------
		public ModuleActionCollection ModuleActions
		{
			get
			{
				ModuleActionCollection Actions = new ModuleActionCollection();
				//Actions.Add(this.GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, this.LocalResourceFile), ModuleActionType.AddContent, "", "", this.EditUrl(), false, SecurityAccessLevel.Edit, true, false);
				return Actions;
			}
		}

		#endregion

	}

}

