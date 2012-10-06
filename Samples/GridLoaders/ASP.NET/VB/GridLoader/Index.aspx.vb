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
    Partial Public Class Index
        Inherits System.Web.UI.Page
#Region "Private Members"

        Private _pageName As String

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Try
                If Not String.IsNullOrEmpty(Request.QueryString(Constants.ControlKey)) Then
                    _pageName = Request.QueryString(Constants.ControlKey)
                End If

                LoadUserControl(_pageName)
            Catch exc As Exception
                'Exceptions.ProcessModuleLoadException(this, exc);

            End Try
        End Sub

#Region "Generated User Control Load Logic"

        Private Sub LoadUserControl(ByVal pageName As String)
            Try
                If Not String.IsNullOrEmpty(pageName) Then
                    Dim control As Control = LoadControl(String.Concat(Constants.GeneratedControlsDirectory, pageName, Constants.ControlPostfix, Constants.ControlFileExtenstion))

                    ContentPlaceHolder.Controls.Add(control)
                Else
                    Dim di As New DirectoryInfo(Server.MapPath(Constants.GeneratedControlsDirectory))
                    Dim files As FileInfo() = di.GetFiles(String.Concat("*", Constants.ControlFileExtenstion), SearchOption.TopDirectoryOnly)

                    For Each file As FileInfo In files
                        Dim control As Control = LoadControl(String.Concat(Constants.GeneratedControlsDirectory, file.Name))
                        ContentPlaceHolder.Controls.Add(control)
                        Return
                    Next

                    Dim warning As New Label()
                    warning.ID = "WarningLabel"
                    warning.CssClass = "es_error_label"
                    warning.Text = "No user controls found to load"

                    ContentPlaceHolder.Controls.Add(warning)
                End If
            Catch exc As Exception
                'Exceptions.ProcessModuleLoadException(this, exc);

            End Try
        End Sub

#End Region
    End Class
End Namespace
