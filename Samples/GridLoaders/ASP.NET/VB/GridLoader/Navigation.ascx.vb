Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace EntitySpaces.Websites.GridLoader
    Partial Public Class Navigation
        Inherits System.Web.UI.UserControl
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            CreateIndex()
        End Sub

        Private Sub CreateIndex()
            Try
                Dim di As New DirectoryInfo(Server.MapPath(Constants.GeneratedControlsDirectory))
                Dim files As FileInfo() = di.GetFiles(String.Concat("*", Constants.ControlFileExtenstion), SearchOption.TopDirectoryOnly)

                For Each file As FileInfo In files
                    Dim link As New HyperLink()
                    link.NavigateUrl = Utilities.ConstructUrl(Constants.ControlKey, file.Name.Replace(String.Concat(Constants.ControlPostfix, Constants.ControlFileExtenstion), String.Empty))

                    link.Text = file.Name.Replace(String.Concat(Constants.ControlPostfix, Constants.ControlFileExtenstion), String.Empty)

                    NavigationMenuStripPlaceHolder.Controls.Add(link)
                    NavigationMenuStripPlaceHolder.Controls.Add(New LiteralControl("&nbsp;&nbsp;&nbsp;"))
                Next
            Catch exc As Exception
                'Exceptions.ProcessModuleLoadException(this, exc);

            End Try
        End Sub
    End Class
End Namespace
