<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Index.aspx.cs" Inherits="EntitySpaces.Websites.GridLoader.Index" %>
<%@ Register TagPrefix="es" TagName="NavigationControl" Src="~/Navigation.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EntitySpaces Admin Grids</title>
    <link href="es_stylesheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="NavigationPlaceHolder" runat="server">
                <es:NavigationControl id="NavigationLinks" runat="server">
                </es:NavigationControl>
            </asp:PlaceHolder>
            <br />
            <asp:PlaceHolder ID="ContentPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
