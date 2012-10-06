Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Imports EntitySpaces.DynamicQuery
Imports EntitySpaces.Interfaces

Imports DotNetNuke.Common
Imports DotNetNuke.Entities.Modules

Namespace BusinessObjects

    Public MustInherit Class GridBase
        Inherits PortalModuleBase

        Protected Const BrowseView As Integer = 0
        Protected Const DetailView As Integer = 1
        Protected Const EditView As Integer = 2
        Protected Const SearchView As Integer = 3

        Protected MustOverride Sub DisplayAddView()
        Protected MustOverride Sub DisplayDetailView()
        Protected MustOverride Sub DisplayEditView()
        Protected MustOverride Sub DisplaySearchView()

        Protected MustOverride Sub Save()
        Protected MustOverride Sub LoadGrid()
        Protected MustOverride Sub Delete()
        Protected MustOverride Sub ResetEditFields()
        Protected MustOverride Sub ClearSelectedKeys()
        Protected MustOverride Function HasSelectedKeys() As Boolean

        Protected MustOverride ReadOnly Property BrowseGrid() As GridView
        Protected MustOverride ReadOnly Property MultiView() As MultiView
        Protected MustOverride ReadOnly Property ShowAllButton() As Button
        Protected MustOverride ReadOnly Property ClearSearchCriteriaButton() As Button
        Protected MustOverride ReadOnly Property DeleteErrorLabel() As Label
        Protected MustOverride ReadOnly Property EditHeaderLabel() As Label
        Protected MustOverride ReadOnly Property SaveErrorLabel() As Label

        Protected MustOverride ReadOnly Property PageTitle() As String

#Region "Viewstate Properties"
        Protected Property IsNew() As Boolean
            Get
                Dim o As Object = Me.ViewState("IsNew")

                If Not o Is Nothing Then
                    Return CType(o, Boolean)
                Else
                    Return False
                End If
            End Get
            Set(ByVal value As Boolean)
                Me.ViewState("IsNew") = value
            End Set
        End Property

        Protected Property SearchHasBeenLoaded() As Boolean
            Get
                Dim o As Object = Me.ViewState("Search")

                If Not o Is Nothing Then
                    Return CType(o, Boolean)
                Else
                    Return False
                End If
            End Get
            Set(ByVal value As Boolean)
                Me.ViewState("Search") = value
            End Set
        End Property

#End Region

#Region "Button Handlers"

        Protected Sub bnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.MultiView.ActiveViewIndex = EditView
            Me.DisplayAddView()
        End Sub

        Protected Sub bnShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If (Me.BrowseGrid.AllowPaging) Then
                Me.BrowseGrid.AllowPaging = False
                Me.ShowAllButton.Text = Me.BrowseGrid.PageSize.ToString() + " Rows"
            Else
                Me.BrowseGrid.AllowPaging = True
                Me.ShowAllButton.Text = "Show All"
            End If

            Me.LoadGrid()
        End Sub

        Protected Sub bnBrowse_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Response.Redirect(String.concat(Globals.ApplicationPath, "/tabid/", TabId, "/pagename/", PageTitle, "/default.aspx"))
        End Sub

        Protected Sub bnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.MultiView.ActiveViewIndex = EditView
            DisplayEditView()
        End Sub

        Protected Sub bnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)

            Try
                Delete()
                Me.MultiView.ActiveViewIndex = BrowseView
                LoadGrid()
            Catch ex As Exception
                Me.DeleteErrorLabel.Text = "Unable to Delete this Record"
            End Try

        End Sub

        Protected Sub bnSaveNew_Click(ByVal sender As Object, ByVal e As System.EventArgs)

            Try
                Me.MultiView.ActiveViewIndex = EditView
                Save()
                Me.EditHeaderLabel.Text = "New " + Me.PageTitle
                Me.ClearSelectedKeys()
                Me.IsNew = True
                Me.ResetEditFields()
            Catch ex As Exception
                Me.SaveErrorLabel.Text = ex.Message
            End Try

        End Sub

        Protected Sub bnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not Request.QueryString("return") = Nothing Then
                Response.Redirect(Request.QueryString("return"))
            Else
                If Me.HasSelectedKeys() Then
                    Me.MultiView.ActiveViewIndex = DetailView
                Else
                    Me.MultiView.ActiveViewIndex = BrowseView
                End If
            End If
        End Sub

        Protected Sub SelectedIndexChanged(ByVal grid As GridView, ByVal pageName As String)

            Dim selectedRow As Integer = grid.SelectedIndex
            Dim key As DataKey = grid.DataKeys(selectedRow)

            Dim seperator As String = ""
            Dim urlParams As String = ""
            Dim keyName As String

            For Each keyName In grid.DataKeyNames
                urlParams += seperator
                urlParams += keyName + "/"
                urlParams += Convert.ToString(key(keyName))
                seperator = "/"
            Next

            Response.Redirect(String.Concat(Globals.ApplicationPath, "/tabid/", TabId, "/pagename/", pageName, "/", urlParams, "/default.aspx"))
        End Sub

        Protected Sub gvBrowse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.SelectedIndexChanged(Me.BrowseGrid, Me.PageTitle)
        End Sub

        Protected Sub gvBrowse_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
            Me.BrowseGrid.PageIndex = e.NewPageIndex
            LoadGrid()
        End Sub

        Protected Sub gvBrowse_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
            Me.SetSortInformation("gvBrowse", e.SortExpression)
            Me.LoadGrid()
        End Sub

        Protected Sub bnSearchPage_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.MultiView.ActiveViewIndex = SearchView
            DisplaySearchView()
            Me.SearchHasBeenLoaded = True
        End Sub

        Protected Sub bnSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.MultiView.ActiveViewIndex = BrowseView
            Me.LoadGrid()
            Me.ClearSearchCriteriaButton.Visible = True
        End Sub

#End Region

#Region "Sorting Logic"

        Protected Function SetSortInformation(ByVal gridName As String, ByVal expression As String) As Boolean

            Dim changed As Boolean = False

            Dim o As Object = Me.ViewState(gridName + "EXP")
            If Not o Is Nothing Then
                If Not CType(o, String) = expression Then
                    changed = True
                End If
            Else
                changed = True
            End If

            Me.ViewState(gridName + "EXP") = expression

            If changed = True Then
                Me.ViewState(gridName + "DIR") = "Ascending"
            Else
                Select Case CType(Me.ViewState(gridName + "DIR"), String)
                    Case "Ascending"
                        Me.ViewState(gridName + "DIR") = "Descending"
                    Case "Descending"
                        Me.ViewState(gridName + "DIR") = "Ascending"
                    Case Else
                        Me.ViewState(gridName + "DIR") = "Ascending"
                End Select
            End If

            Return changed

        End Function

        Protected Function GetSortExpression(ByVal gridName As String) As String
            Dim o As Object = Me.ViewState(gridName + "EXP")
            Return CStr(IIf(Not o Is Nothing, CType(o, String), ""))
        End Function

        Protected Sub SetSortExpression(ByVal gridName As String, ByVal expression As String)
            Me.ViewState(gridName + "EXP") = expression
        End Sub

        Protected Function GetSortDirection(ByVal gridName As String) As String
            Dim o As Object = Me.ViewState(gridName + "DIR")
            Return CStr(IIf(Not o Is Nothing, CType(o, String), ""))
        End Function

        Protected Function GetSortDirectionEnum(ByVal gridName As String) As esOrderByDirection

            Dim dir As esOrderByDirection = esOrderByDirection.Ascending

            Dim direction As String = CType(Me.ViewState(gridName + "DIR"), String)
            If Not direction = "" Then
                Select Case direction
                    Case "Ascending"
                        dir = esOrderByDirection.Ascending
                    Case "Descending"
                        dir = esOrderByDirection.Descending
                End Select
            End If

            Return dir

        End Function

        Protected Sub SetSortDirection(ByVal gridName As String, ByVal expression As String)
            Me.ViewState(gridName + "DIR") = expression
        End Sub

#End Region

        Protected Function PopulateSearchItemList() As ListItem()

            Dim items As ListItem() = { _
                New ListItem("", ""), _
                New ListItem("Equal", "Equal"), _
                New ListItem("Not Equal", "NotEqual"), _
                New ListItem("Greater Than", "GreaterThan"), _
                New ListItem("Greater Than Or Equal", "GreaterThanOrEqual"), _
                New ListItem("Less Than", "LessThan"), _
                New ListItem("Less Than Or Equal", "LessThanOrEqual"), _
                New ListItem("Like", "Like"), _
                New ListItem("Is Null", "IsNull"), _
                New ListItem("Is Not Null", "IsNotNull"), _
                New ListItem("Not Like", "NotLike")}

            Return items

        End Function

    End Class

End Namespace