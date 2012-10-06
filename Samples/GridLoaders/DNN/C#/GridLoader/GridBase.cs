using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntitySpaces.DynamicQuery;
using EntitySpaces.Interfaces;

using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;

namespace BusinessObjects
{
	abstract public class GridBase : PortalModuleBase
	{
		public GridBase() {}

		protected const int BrowseView = 0;
		protected const int DetailView = 1;
		protected const int EditView   = 2;
		protected const int SearchView = 3;

		abstract protected void DisplayAddView();
		abstract protected void DisplayDetailView();
		abstract protected void DisplayEditView();
		abstract protected void DisplaySearchView();

		abstract protected void Save();
		abstract protected void LoadGrid();
		abstract protected void Delete();
		abstract protected void ResetEditFields();
		abstract protected void ClearSelectedKeys();
		abstract protected bool HasSelectedKeys();

		abstract protected GridView BrowseGrid { get; }
		abstract protected MultiView MultiView { get; }
		abstract protected Button ShowAllButton { get; }
		abstract protected Button ClearSearchCriteriaButton { get; }
		abstract protected Label DeleteErrorLabel { get; }
		abstract protected Label EditHeaderLabel { get; }
		abstract protected Label SaveErrorLabel { get; }

		abstract protected string PageTitle { get; }

		#region Viewstate Properties
		protected bool IsNew
		{
			get
			{
				object o = this.ViewState["IsNew"];

				if (o != null)
					return (bool)o;
				else
					return false;
			}

			set
			{
				this.ViewState["IsNew"] = value;
			}
		}

		protected bool SearchHasBeenLoaded
		{
			get
			{
				object o = this.ViewState["Search"];

				if (o != null)
					return (bool)o;
				else
					return false;
			}

			set
			{
				this.ViewState["Search"] = value;
			}
		}

		#endregion

		#region Button Handlers

		protected void bnNew_Click(object sender, EventArgs e)
		{
			this.MultiView.ActiveViewIndex = EditView;
			this.DisplayAddView();
		}

		protected void bnShowAll_Click(object sender, EventArgs e)
		{
			if (this.BrowseGrid.AllowPaging)
			{
				this.BrowseGrid.AllowPaging = false;
				this.ShowAllButton.Text = this.BrowseGrid.PageSize.ToString() + " Rows";
			}
			else
			{
				this.BrowseGrid.AllowPaging = true;
				this.ShowAllButton.Text = "Show All";
			}
			this.LoadGrid();
		}

		protected void bnBrowse_Click(object sender, EventArgs e)
		{
			Response.Redirect(string.Concat(Globals.ApplicationPath, "/tabid/", TabId, 
				"/pagename/", PageTitle, "/default.aspx")); 
		}

		protected void bnEdit_Click(object sender, EventArgs e)
		{
			this.MultiView.ActiveViewIndex = EditView;
			DisplayEditView();
		}

		protected void bnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				Delete();
				this.MultiView.ActiveViewIndex = BrowseView;
				LoadGrid();
			}
			catch (Exception ex)
			{
				this.DeleteErrorLabel.Text = "Unable to Delete this Record";
			}
		}

		protected void bnSaveNew_Click(object sender, EventArgs e)
		{
			try
			{
				this.MultiView.ActiveViewIndex = EditView;
				Save();
				this.EditHeaderLabel.Text = "New " + this.PageTitle;
				this.ClearSelectedKeys();
				this.IsNew = true;
				this.ResetEditFields();
			}
			catch (Exception ex)
			{
				this.SaveErrorLabel.Text = ex.Message;
			}
		}

		protected void bnCancel_Click(object sender, EventArgs e)
		{
			if (Request.QueryString["return"] != null)
			{
				Response.Redirect(Request.QueryString["return"]);
			}
			else
			{
				if (this.HasSelectedKeys())
					this.MultiView.ActiveViewIndex = DetailView;
				else
					this.MultiView.ActiveViewIndex = BrowseView;
			}
		}

		protected void SelectedIndexChanged(GridView grid, string pageName)
		{
			int selectedRow = grid.SelectedIndex;
			DataKey key = grid.DataKeys[selectedRow];

			string seperator = "";
			string urlParams = "";

			foreach (string keyName in grid.DataKeyNames)
			{
				urlParams += seperator;
				urlParams += keyName + "/";
				urlParams += Convert.ToString(key[keyName]);
				seperator = "/";
			}

			Response.Redirect(string.Concat(Globals.ApplicationPath, "/tabid/", TabId,
				"/pagename/", pageName, "/", urlParams, "/default.aspx"));
		}

		protected void gvBrowse_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedIndexChanged(this.BrowseGrid, this.PageTitle);
		}

		protected void gvBrowse_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.BrowseGrid.PageIndex = e.NewPageIndex;
			LoadGrid();
		}

		protected void gvBrowse_Sorting(object sender, GridViewSortEventArgs e)
		{
			this.SetSortInformation("gvBrowse", e.SortExpression);
			this.LoadGrid();
		}

		protected void bnSearchPage_Click(object sender, EventArgs e)
		{
			this.MultiView.ActiveViewIndex = SearchView;
			DisplaySearchView();
			this.SearchHasBeenLoaded = true;
		}

		protected void bnSearch_Click(object sender, EventArgs e)
		{
			this.MultiView.ActiveViewIndex = BrowseView;
			this.LoadGrid();
			this.ClearSearchCriteriaButton.Visible = true;
		}

		#endregion

		#region Sorting Logic
		protected bool SetSortInformation(string gridName, string expression)
		{
			bool changed = false;

			object o = this.ViewState[gridName + "EXP"];
			if (o != null)
			{
				if (o as string != expression)
				{
					changed = true;
				}
			}
			else
			{
				changed = true;
			}

			this.ViewState[gridName + "EXP"] = expression;

			if (changed)
			{
				this.ViewState[gridName + "DIR"] = "Ascending";
			}
			else
			{
				switch (this.ViewState[gridName + "DIR"] as string)
				{
					case "Ascending":
						this.ViewState[gridName + "DIR"] = "Descending";
						break;

					case "Descending":
						this.ViewState[gridName + "DIR"] = "Ascending";
						break;

					default:
						this.ViewState[gridName + "DIR"] = "Ascending";
						break;
				}
			}

			return changed;
		}

		protected string GetSortExpression(string gridName)
		{
			object o = this.ViewState[gridName + "EXP"];
			return (o != null) ? o as string : "";
		}

		protected void SetSortExpression(string gridName, string expression)
		{
			this.ViewState[gridName + "EXP"] = expression;
		}

		protected string GetSortDirection(string gridName)
		{
			object o = this.ViewState[gridName + "DIR"];
			return (o != null) ? o as string : "";
		}

		protected esOrderByDirection GetSortDirectionEnum(string gridName)
		{
			string direction = this.ViewState[gridName + "DIR"] as string;
			if (direction != "")
			{
				switch (direction)
				{
					case "Ascending": return esOrderByDirection.Ascending;
					case "Descending": return esOrderByDirection.Descending;
				}
			}

			return esOrderByDirection.Ascending;
		}

		protected void SetSortDirection(string gridName, string expression)
		{
			this.ViewState[gridName + "DIR"] = expression;
		}
		#endregion

		protected ListItem[] PopulateSearchItemList()
		{
			ListItem[] items = new ListItem[11];
			items[0] = new ListItem("", "");
			items[1] = new ListItem("Equal", "Equal");
			items[2] = new ListItem("Not Equal", "NotEqual");
			items[3] = new ListItem("Greater Than", "GreaterThan");
			items[4] = new ListItem("Greater Than Or Equal", "GreaterThanOrEqual");
			items[5] = new ListItem("Less Than", "LessThan");
			items[6] = new ListItem("Less Than Or Equal", "LessThanOrEqual");
			items[7] = new ListItem("Like", "Like");
			items[8] = new ListItem("Is Null", "IsNull");
			items[9] = new ListItem("Is Not Null", "IsNotNull");
			items[10] = new ListItem("Not Like", "NotLike");
			return items;
		}
	}
}