<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LazyLoad.aspx.cs" Inherits="WebSiteDemo.LazyLoad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="JavaScript/Libs/jquery-1.7.1.js" type="text/javascript"></script>
    <script src="JavaScript/Libs/json2.js" type="text/javascript"></script>
    <script src="JavaScript/Libs/knockout-2.0.0.debug.js" type="text/javascript"></script>
    <link href="JavaScript/KoGrid/KoGrid.css" rel="stylesheet" type="text/css" />
    <script src="JavaScript/KoGrid/koGrid.debug.js" type="text/javascript"></script>
    <script src="JavaScript/entityspaces.js/entityspaces.XHR.debug.js" type="text/javascript"></script>
    <script src="JavaScript/entityspaces.js/Generated/Employees.js" type="text/javascript"></script>
    <script src="JavaScript/entityspaces.js/Generated/Orders.js" type="text/javascript"></script>
    <script src="JavaScript/entityspaces.js/Generated/OrderDetails.js" type="text/javascript"></script>
    <script src="JavaScript/entityspaces.js/Custom/Employees.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <br />
     <h4>Lazy Loading <a href="https://github.com/EntitySpaces/entityspaces.js" target="new">entityspaces.js</a> demonstration. Only the first 10 or so rows have Orders. Click around in the grids and the data will be automatically lazy loaded. Do a view source to see how simple this page really is. The WCF JSON Service and the <a href="https://github.com/EntitySpaces/entityspaces.js/tree/master/Examples/EntitySpaces/Generated" target="new">entitityspaces.js JavaScript classes</a> were generated from the Northwind database schema.<br /></h4>
     <hr />
     <table>
        <tr>
            <td valign="top" align="left" colspan="3">
                <b>Employees:</b><br />
                <div id="myEmployees" style="height: 200px; max-width: 800px; float: left; margin-left: 100px; border: 1px solid #666666; margin: 10px auto;"
                    data-bind="koGrid:{ 
                        data: employees, 
                        selectedItem: selectedEmployee,
                        isMultiSelect: false,
                        autogenerateColumns: false,
                        enablePaging: false,
                        columnDefs: [
                            {field: 'EmployeeID', displayName: 'Employee ID', width: 120}, 
                            {field: 'FirstName', displayName: 'First Name', width: 120}, 
                            {field: 'LastName', displayName: 'Last Name', width: 160},
                            {field: 'Address', displayName: 'Address', width: 160},
                            {field: 'City', displayName: 'City', width: 160}
                        ],
                        displaySelectionCheckbox: false,
                        displayRowIndex: false }">
                </div>
            </td>
        </tr>
        <tr style="width="1%;">
            <td valign="top" align="left">
                <b>Orders:</b><br />
                <div id="myOrders" style="height: 200px; max-width: 700px; float: left; margin-left: 100px; border: 1px solid #666666; margin: 10px auto;"
                    data-bind="koGrid:{ 
                        data: orders, 
                        selectedItem: selectedOrder,
                        isMultiSelect: false,
                        autogenerateColumns: false,
                        enablePaging: false,
                        columnDefs: [
                            {field: 'OrderID', displayName: 'Order ID', width: 120}, 
                            {field: 'EmployeeID', displayName: 'Employee ID', width: 120},
                            {field: 'CustomerID', displayName: 'Customer ID', width: 120}, 
                            {field: 'Freight', displayName: 'Freight', width: 120}
                        ],
                        displaySelectionCheckbox: false,
                        displayRowIndex: false }">
                </div>
            </td>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td valign="top" align="left">
                <b>Order Details:</b><br />
                <div id="myOrderDetails" style="height: 200px; max-width: 960px; float: left; margin-left: 100px; border: 1px solid #666666; margin: 10px auto;"
                    data-bind="koGrid:{ 
                        data: orderDetails,
                        selectedItem: selectedOrderDetail,
                        isMultiSelect: false,
                        autogenerateColumns: false,
                        enablePaging: false,
                        columnDefs: [
                            {field: 'OrderID', displayName: 'Order ID', width: 120}, 
                            {field: 'ProductID', displayName: 'Product ID', width: 120}, 
                            {field: 'UnitPrice', displayName: 'Unit Price', width: 120}, 
                            {field: 'Quantity', displayName: 'Quantity', width: 120}
                        ],
                        displaySelectionCheckbox: false,
                        displayRowIndex: false }">
                </div>
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">

        es.dataProvider.baseURL = "esJson.svc/";

        $(document).ready(function () {

            var vm = function () {
                var self = this;

                this.employees = new es.objects.EmployeesCollection();

                this.selectedEmployee = ko.observable(new es.objects.Employees());
                this.selectedOrder = ko.observable(new es.objects.Orders());
                this.selectedOrderDetail = ko.observable(new es.objects.OrderDetails());

                // Called when an employee is selected in the myEmployees
                this.orders = ko.computed(function () {

                    // Set the myOrders grid to this employees 'Orders'
                    return self.selectedEmployee().OrdersCollectionByEmployeeID();
                });

                // Called when an order is selected in the myOrders grid
                this.orderDetails = ko.computed(function () {

                    // here just to make sure we change when a new employee is selected
                    var employee = self.selectedEmployee();

                    // Set the order myOrderDetails grid to the selected orders OrderDetails data
                    if (self.selectedOrder() !== null) {
                        return self.selectedOrder().OrderDetailsCollectionByOrderID();
                    } else {
                        return [];
                    }
                });
            };

            //'OrderDetailsCollectionByOrderID': 

            var vmModel = new vm();

            // Hit our service ...
            vmModel.employees.loadAll();
            vmModel.selectedEmployee(vmModel.employees()[1]);
            vmModel.selectedOrder(vmModel.employees()[0].OrdersCollectionByEmployeeID()[0]);

            ko.applyBindings(vmModel);
        });

    </script>

</asp:Content>
