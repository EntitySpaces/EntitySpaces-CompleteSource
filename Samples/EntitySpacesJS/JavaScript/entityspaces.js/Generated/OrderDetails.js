//===============================================================================
//                    EntitySpaces Studio by EntitySpaces, LLC
//             Persistence Layer and Business Objects for Microsoft .NET
//             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
//                          http://www.entityspaces.net
//===============================================================================
// EntitySpaces Version : 2012.1.0319.0
// EntitySpaces Driver  : SQL
// Date Generated       : 3/18/2012 8:05:02 AM
//===============================================================================

(function (es) { //myNS = "myNameSpace" ... for example purposes

	if (typeof (es) === undefined) {
		throw "Please Load EntitySpaces.Core First";
	}

	es.objects.OrderDetails = es.defineEntity(function () {

		// core columns
		this.OrderID = ko.observable();
		this.ProductID = ko.observable();
		this.UnitPrice = ko.observable();
		this.Quantity = ko.observable();
		this.Discount = ko.observable();

		this.esPrimaryKeys = function() {
			var val = {data: {}};
			val.data.orderID = this.OrderID();
			val.data.productID = this.ProductID();
			return val;
		};

		// extended columns
		this.esExtendedData = undefined;

		// Hierarchical Properties
		this.UpToOrdersByOrderID = es.defineLazyLoader(this, 'UpToOrdersByOrderID');
		this.UpToProductsByProductID = es.defineLazyLoader(this, 'UpToProductsByProductID');
	});

	//#region Prototype Level Information

	es.objects.OrderDetails.prototype.esTypeDefs = {
		UpToOrdersByOrderID: "Orders",
		UpToProductsByProductID: "Products"
	};

	es.objects.OrderDetails.prototype.esRoutes = {
		commit: { method: 'PUT', url: 'OrderDetails_Save', response: 'entity' },
		loadByPrimaryKey: { method: 'GET', url: 'OrderDetails_LoadByPrimaryKey', response: 'entity' },
		UpToOrdersByOrderID: { method: 'GET', url: 'OrderDetails_UpToOrdersByOrderID', response: 'entity'},
		UpToProductsByProductID: { method: 'GET', url: 'OrderDetails_UpToProductsByProductID', response: 'entity'}
	};

	es.objects.OrderDetails.prototype.esColumnMap = {
		'OrderID': 1,
		'ProductID': 1,
		'UnitPrice': 1,
		'Quantity': 1,
		'Discount': 1
	};

	//#endregion

}(window.es, window.myNS));

(function (es) {

	es.objects.OrderDetailsCollection = es.defineCollection('OrderDetailsCollection', 'OrderDetails');

	//#region Prototype Level Information

	es.objects.OrderDetailsCollection.prototype.esRoutes = {
		commit: { method: 'PUT', url: 'OrderDetailsCollection_Save', response: 'collection' },
		loadAll: { method: 'GET', url: 'OrderDetailsCollection_LoadAll', response: 'collection' }
	};

	//#endregion

}(window.es, window.myNS));