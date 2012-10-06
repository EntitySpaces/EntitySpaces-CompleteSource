<%@ Page Language="VB" AutoEventWireup="false" Inherits="Join" Codebehind="Join.aspx.vb" %>

<%@ Register Assembly="EntitySpaces.Web" Namespace="EntitySpaces.Web" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This page shows binding to data obtained via a <strong>Join</strong> using the DynamicQuery API, of course, using a view and generating your EntitySpaces classes from the view
        is the most straight forward way.<br />
        <ul>
            <li>We have AutoSorting and AutoPaging set to "True"</li>
            <li>The Category field shown below is brought back via a join, it's an extra column</li>
            <li>Because Category is not a column in our Products table we set it's SortExpression
                to &lt;CategoryName&gt; notice the &lt; &gt; brackets.</li>
            <li>We didn't want to add the CategoryName field to our Products object as a virtual
                column so we set the esDataSource to LowLevelBind = True</li>
        </ul>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3"
            DataKeyNames="ProductID" DataSourceID="EsDataSource1" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="96%" ShowFooter="True">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" ButtonType="Button" InsertVisible="False" >
                    <ItemStyle Width="1%" />
                </asp:CommandField>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="&lt;CategoryName&gt;" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <br />
    
    </div>
        <cc1:esdatasource id="EsDataSource1" runat="server" 
            onescreateentity="EsDataSource1_esCreateEntity" onesselect="EsDataSource1_esSelect" AutoPaging="True" AutoSorting="True"></cc1:esdatasource>
    </form>
</body>
</html>
