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

	es.objects.Shippers = es.defineEntity(function () {

		// core columns
		this.ShipperID = ko.observable();
		this.CompanyName = ko.observable();
		this.Phone = ko.observable();

		// Primary Key(s)
		this.esPrimaryKeys = function() {
			return this.ShipperID();
		}

		// extended columns
		this.esExtendedData = undefined;

		// Hierarchical Properties
		this.OrdersCollectionByShipVia = es.defineLazyLoader(this, 'OrdersCollectionByShipVia');
	});

	//#region Prototype Level Information

	es.objects.Shippers.prototype.esTypeDefs = {
		OrdersCollectionByShipVia: "OrdersCollection"
	};

	es.objects.Shippers.prototype.esRoutes = {
		commit: { method: 'PUT', url: 'Shippers_Save', response: 'entity' },
		loadByPrimaryKey: { method: 'GET', url: 'Shippers_LoadByPrimaryKey', response: 'entity' },
		OrdersCollectionByShipVia: { method: 'GET', url: 'Shippers_OrdersCollectionByShipVia', response: 'collection'}
	};

	es.objects.Shippers.prototype.esColumnMap = {
		'ShipperID': 1,
		'CompanyName': 1,
		'Phone': 1
	};

	//#endregion

}(window.es, window.myNS));

(function (es) {

	es.objects.ShippersCollection = es.defineCollection('ShippersCollection', 'Shippers');

	//#region Prototype Level Information

	es.objects.ShippersCollection.prototype.esRoutes = {
		commit: { method: 'PUT', url: 'ShippersCollection_Save', response: 'collection' },
		loadAll: { method: 'GET', url: 'ShippersCollection_LoadAll', response: 'collection' }
	};

	//#endregion

}(window.es, window.myNS));