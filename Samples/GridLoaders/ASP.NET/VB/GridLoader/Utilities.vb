Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace EntitySpaces.Websites.GridLoader

    ''' <summary>
    ''' Summary description for Utilities
    ''' </summary>
    Public Class Utilities
        ' private ctor all functions are static
        Private Sub New()
        End Sub

        Public Shared Function ConstructUrl(ByVal controlKey As String, ByVal pageName As String) As String
            Return String.Format("~/Index.aspx?{0}={1}", controlKey, pageName)
        End Function

        Public Shared Function ConstructUrl(ByVal ParamArray args As String()) As String
            Dim theUrl As String = "~/Index.aspx?"

            For Each parameter As String In args
                theUrl = theUrl + parameter
            Next

            Return theUrl
        End Function
    End Class

End Namespace
