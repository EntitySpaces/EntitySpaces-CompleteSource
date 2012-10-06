<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paging.aspx.cs" Inherits="WebSiteDemo.Paging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript" ></script>
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
        <div id="body" class="row scroll-y">
            
                <script type="text/javascript">

                    es.dataProvider.baseURL = "esJson.svc/";

                    $(document).ready(function () {

                        var myVM = function () {
                            var self = this;

                            this.employees = new es.objects.EmployeesCollection();
                            this.currentPage = ko.observable(1);
                            this.pageSize = ko.observable(25);
                            this.totalRows = ko.observable(0);
                            this.selectedItem = ko.observable();
                            this.sortInfo = ko.observable();
                            this.filterInfo = ko.observable();

                            var getTotalRows = true;

                            var filter = function (data, filterInfo) {

                                var mgr = new kg.FilterManager({
                                    data: ko.observableArray(data)
                                });

                                mgr.filterInfo(filterInfo);

                                return mgr.filteredData();
                            };

                            var sort = function (data, sortInfo) {

                                var mgr = new kg.SortManager({
                                    data: ko.observableArray(data)
                                });

                                mgr.sortInfo(sortInfo);

                                return mgr.sortedData();
                            };

                            this.getPagedDataAsync = function (pageSize, page, filterInfo, sortInfo) {

                                setTimeout(function () {

                                    var i, esFilter, filter, filterCriteria, esSortCriteria, pagerRequest;

                                    pagerRequest = new es.PagerRequest();
                                    pagerRequest.getTotalRows = getTotalRows;
                                    pagerRequest.pageSize = self.pageSize;
                                    pagerRequest.pageNumber = self.currentPage;

                                    if (filterInfo) {

                                        pagerRequest.filterCriteria = [];

                                        for (filter in filterInfo) {

                                            filterCriteria = filterInfo[filter];

                                            esFilter = new es.PagerFilterCriteria();
                                            esFilter.column = filter;
                                            esFilter.criteria1 = '%' + filterCriteria + '%';
                                            esFilter.operation = "LIKE";
                                            esFilter.conjuction = "AND";

                                            pagerRequest.filterCriteria.push(esFilter);
                                        }
                                    }

                                    if (sortInfo) {

                                        pagerRequest.sortCriteria = [];

                                        esSortCriteria = new es.PagerSortCriteria();
                                        esSortCriteria.column = sortInfo.column.field;
                                        esSortCriteria.direction = sortInfo.column.sortDirection();

                                        pagerRequest.sortCriteria.push(esSortCriteria);
                                    }

                                    self.employees.Employees_Pager(pagerRequest);

                                    if (getTotalRows === true) {
                                        self.totalRows(78); //pagerRequest.totalRows);
                                    }

                                    getTotalRows = false;

                                }, 0);
                            };


                            this.dataChangedTrigger = ko.computed(function () {
                                var page = self.currentPage(),
                                pageSize = self.pageSize(),
                                filterInfo = self.filterInfo(),
                                sortInfo = self.sortInfo();

                                if (page && pageSize) {
                                    self.getPagedDataAsync(pageSize, page, filterInfo, sortInfo);
                                }
                                return null;
                            });
                        };

                        window.viewModel = new myVM();

                        ko.applyBindings(viewModel);

                        viewModel.getPagedDataAsync(50, 1, viewModel.filterInfo(), viewModel.sortInfo());
                    });
</script>
	<div id="sandBox" class="example" style="height: 600px; max-width: 610px;" 
			data-bind="koGrid: { data: employees,
								columnDefs: [ { field: 'EmployeeID', width: 140 },
										{ field: 'FirstName', displayName: 'First Name', width: 100 },
										{ field: 'LastName', displayName: 'Last Name', width: 100 },
										{ field: 'Title', width: 200 }],
								autogenerateColumns: false,
								isMultiSelect: false,
								enablePaging: true,
								useExternalFiltering: true,
								useExternalSorting: true,
								filterInfo: filterInfo,
								sortInfo: sortInfo,
								pageSize: pageSize,
								pageSizes: [25, 50, 75],
								currentPage: currentPage,
								totalServerItems: totalRows,
								selectedItem: selectedItem }">

    </div>
</asp:Content>
