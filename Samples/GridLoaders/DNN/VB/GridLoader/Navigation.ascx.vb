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
Imports DotNetNuke
Imports DotNetNuke.Common
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Entities.Modules.Actions
Imports DotNetNuke.Entities.Users
Imports DotNetNuke.Security
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.Localization

Namespace EntitySpaces.Modules.GridLoader
    Partial Public Class Navigation
        Inherits PortalModuleBase
        ''' <summary>
        ''' Overide the page init event 
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)

            Dim ModuleBase As PortalModuleBase = DirectCast((Parent.Parent), PortalModuleBase)
            If Not (ModuleBase Is Nothing) Then
                ModuleConfiguration = ModuleBase.ModuleConfiguration
            End If

            'LocalResourceFile = String.Concat(TemplateSourceDirectory, "/App_LocalResources/Index.ascx.resx")
        End Sub

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

                Exceptions.ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
    End Class
End Namespace
