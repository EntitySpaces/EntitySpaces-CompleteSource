Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.IO
Imports System.Text
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

Imports BusinessObjects
Imports EntitySpaces.Interfaces

Namespace EntitySpaces.Modules.GridLoader

    Partial Public Class Index
        Inherits PortalModuleBase

#Region "Private Members"

        Private _pageName As String

#End Region

#Region "Event Handlers"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Try
                If Not String.IsNullOrEmpty(Request.QueryString(Constants.ControlKey)) Then
                    _pageName = Request.QueryString(Constants.ControlKey)
                End If

                SetConnection()
                LoadUserControl(_pageName)
            Catch exc As Exception

                Exceptions.ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

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

                Exceptions.ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

#End Region

#Region "EntitySpaces Connection Logic"

        Private Sub SetConnection()
            If esConfigSettings.ConnectionInfo.[Default] <> "SiteSqlServer" Then
                Dim ConnectionInfoSettings As esConfigSettings = esConfigSettings.ConnectionInfo
                For Each connection As esConnectionElement In ConnectionInfoSettings.Connections
                    'if there is a SiteSqlServer in es connections set it default
                    If connection.Name = "SiteSqlServer" Then
                        esConfigSettings.ConnectionInfo.[Default] = connection.Name
                        Return
                    End If
                Next

                'no SiteSqlServer found grab dnn cnn string and create
                Dim dnnConnection As String = ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString
                
                ' Manually register a connection (DO THIS ONE TIME ONLY)
                Dim conn As New esConnectionElement()
                conn.ConnectionString = dnnConnection
                conn.Name = "SiteSqlServer"
                conn.Provider = "EntitySpaces.SqlClientProvider"
                conn.ProviderClass = "DataProvider"
                conn.SqlAccessType = esSqlAccessType.DynamicSQL
                conn.ProviderMetadataKey = "esDefault"
                conn.DatabaseVersion = "2005"
                esConfigSettings.ConnectionInfo.Connections.Add(conn)

                ' Assign the Default Connection
                esConfigSettings.ConnectionInfo.[Default] = "SiteSqlServer"

                ' Register the Loader
                esProviderFactory.Factory = New LoaderMT.esDataProviderFactory()
            End If
        End Sub

#End Region

    End Class

End Namespace

