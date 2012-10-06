Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Imports DotNetNuke.Common
Imports DotNetNuke.Entities.Portals
Imports DotNetNuke.Services.Exceptions

Namespace EntitySpaces.Modules.GridLoader

    ''' <summary>
    ''' Summary description for Utilities
    ''' </summary>
    Public Class Utilities
        ' private ctor all functions are static
        Private Sub New()
        End Sub

        Public Shared Function ConstructUrl(ByVal ParamArray args As String()) As String
            Dim ps As PortalSettings = PortalController.GetCurrentPortalSettings()
            Return Globals.NavigateURL(ps.ActiveTab.TabID, String.Empty, args)
        End Function

        Public Shared Function ConstructUrl(ByVal tabId As Integer, ByVal ParamArray args As String()) As String
            Return Globals.NavigateURL(tabId, String.Empty, args)
        End Function
    End Class

End Namespace
