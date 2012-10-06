<%@ Control Language="C#" AutoEventWireup="true" Inherits="EntitySpaces.Modules.GridLoader.Index"
    Codebehind="Index.ascx.cs" %>
<%@ Register TagPrefix="es" TagName="NavigationControl" Src="~/DesktopModules/GridLoader/Navigation.ascx" %>
<asp:PlaceHolder ID="NavigationPlaceHolder" runat="server">
    <es:NavigationControl ID="NavigationLinks" runat="server">
    </es:NavigationControl>
</asp:PlaceHolder>
<br />
<asp:PlaceHolder ID="ContentPlaceHolder" runat="server"></asp:PlaceHolder>
