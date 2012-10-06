/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.0.0331.0
EntitySpaces Driver  : SQL
Date Generated       : 4/16/2011 9:03:01 PM
===============================================================================
*/

using System.ServiceModel;
using BusinessObjects;

namespace WCFService
{
	[ServiceContract]
	public partial interface INonProxyService
	{
	
		#region Categories
		
		[OperationContract]
		CategoriesCollection.CategoriesCollectionWCFPacket Categories_LoadAll();		

		[OperationContract]
		CategoriesCollection.CategoriesCollectionWCFPacket Categories_QueryForCollection(string serializedQuery);

		[OperationContract]
		Categories Categories_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Categories Categories_GetByPrimaryKey(System.Int32 categoryID);

		[OperationContract]
		CategoriesCollection.CategoriesCollectionWCFPacket Categories_SaveCollection(CategoriesCollection.CategoriesCollectionWCFPacket collection);

		[OperationContract]
		Categories Categories_SaveEntity(Categories entity);		

		#endregion
	
		#region CustomerCustomerDemo
		
		[OperationContract]
		CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket CustomerCustomerDemo_LoadAll();		

		[OperationContract]
		CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket CustomerCustomerDemo_QueryForCollection(string serializedQuery);

		[OperationContract]
		CustomerCustomerDemo CustomerCustomerDemo_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		CustomerCustomerDemo CustomerCustomerDemo_GetByPrimaryKey(System.String customerID, System.String customerTypeID);

		[OperationContract]
		CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket CustomerCustomerDemo_SaveCollection(CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket collection);

		[OperationContract]
		CustomerCustomerDemo CustomerCustomerDemo_SaveEntity(CustomerCustomerDemo entity);		

		#endregion
	
		#region CustomerDemographics
		
		[OperationContract]
		CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket CustomerDemographics_LoadAll();		

		[OperationContract]
		CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket CustomerDemographics_QueryForCollection(string serializedQuery);

		[OperationContract]
		CustomerDemographics CustomerDemographics_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		CustomerDemographics CustomerDemographics_GetByPrimaryKey(System.String customerTypeID);

		[OperationContract]
		CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket CustomerDemographics_SaveCollection(CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket collection);

		[OperationContract]
		CustomerDemographics CustomerDemographics_SaveEntity(CustomerDemographics entity);		

		#endregion
	
		#region Customers
		
		[OperationContract]
		CustomersCollection.CustomersCollectionWCFPacket Customers_LoadAll();		

		[OperationContract]
		CustomersCollection.CustomersCollectionWCFPacket Customers_QueryForCollection(string serializedQuery);

		[OperationContract]
		Customers Customers_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Customers Customers_GetByPrimaryKey(System.String customerID);

		[OperationContract]
		CustomersCollection.CustomersCollectionWCFPacket Customers_SaveCollection(CustomersCollection.CustomersCollectionWCFPacket collection);

		[OperationContract]
		Customers Customers_SaveEntity(Customers entity);		

		#endregion
	
		#region Employees
		
		[OperationContract]
		EmployeesCollection.EmployeesCollectionWCFPacket Employees_LoadAll();		

		[OperationContract]
		EmployeesCollection.EmployeesCollectionWCFPacket Employees_QueryForCollection(string serializedQuery);

		[OperationContract]
		Employees Employees_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Employees Employees_GetByPrimaryKey(System.Int32 employeeID);

		[OperationContract]
		EmployeesCollection.EmployeesCollectionWCFPacket Employees_SaveCollection(EmployeesCollection.EmployeesCollectionWCFPacket collection);

		[OperationContract]
		Employees Employees_SaveEntity(Employees entity);		

		#endregion
	
		#region EmployeeTerritories
		
		[OperationContract]
		EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket EmployeeTerritories_LoadAll();		

		[OperationContract]
		EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket EmployeeTerritories_QueryForCollection(string serializedQuery);

		[OperationContract]
		EmployeeTerritories EmployeeTerritories_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		EmployeeTerritories EmployeeTerritories_GetByPrimaryKey(System.Int32 employeeID, System.String territoryID);

		[OperationContract]
		EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket EmployeeTerritories_SaveCollection(EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket collection);

		[OperationContract]
		EmployeeTerritories EmployeeTerritories_SaveEntity(EmployeeTerritories entity);		

		#endregion
	
		#region OrderDetails
		
		[OperationContract]
		OrderDetailsCollection.OrderDetailsCollectionWCFPacket OrderDetails_LoadAll();		

		[OperationContract]
		OrderDetailsCollection.OrderDetailsCollectionWCFPacket OrderDetails_QueryForCollection(string serializedQuery);

		[OperationContract]
		OrderDetails OrderDetails_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		OrderDetails OrderDetails_GetByPrimaryKey(System.Int32 orderID, System.Int32 productID);

		[OperationContract]
		OrderDetailsCollection.OrderDetailsCollectionWCFPacket OrderDetails_SaveCollection(OrderDetailsCollection.OrderDetailsCollectionWCFPacket collection);

		[OperationContract]
		OrderDetails OrderDetails_SaveEntity(OrderDetails entity);		

		#endregion
	
		#region Orders
		
		[OperationContract]
		OrdersCollection.OrdersCollectionWCFPacket Orders_LoadAll();		

		[OperationContract]
		OrdersCollection.OrdersCollectionWCFPacket Orders_QueryForCollection(string serializedQuery);

		[OperationContract]
		Orders Orders_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Orders Orders_GetByPrimaryKey(System.Int32 orderID);

		[OperationContract]
		OrdersCollection.OrdersCollectionWCFPacket Orders_SaveCollection(OrdersCollection.OrdersCollectionWCFPacket collection);

		[OperationContract]
		Orders Orders_SaveEntity(Orders entity);		

		#endregion
	
		#region Products
		
		[OperationContract]
		ProductsCollection.ProductsCollectionWCFPacket Products_LoadAll();		

		[OperationContract]
		ProductsCollection.ProductsCollectionWCFPacket Products_QueryForCollection(string serializedQuery);

		[OperationContract]
		Products Products_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Products Products_GetByPrimaryKey(System.Int32 productID);

		[OperationContract]
		ProductsCollection.ProductsCollectionWCFPacket Products_SaveCollection(ProductsCollection.ProductsCollectionWCFPacket collection);

		[OperationContract]
		Products Products_SaveEntity(Products entity);		

		#endregion
	
		#region Region
		
		[OperationContract]
		RegionCollection.RegionCollectionWCFPacket Region_LoadAll();		

		[OperationContract]
		RegionCollection.RegionCollectionWCFPacket Region_QueryForCollection(string serializedQuery);

		[OperationContract]
		Region Region_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Region Region_GetByPrimaryKey(System.Int32 regionID);

		[OperationContract]
		RegionCollection.RegionCollectionWCFPacket Region_SaveCollection(RegionCollection.RegionCollectionWCFPacket collection);

		[OperationContract]
		Region Region_SaveEntity(Region entity);		

		#endregion
	
		#region Shippers
		
		[OperationContract]
		ShippersCollection.ShippersCollectionWCFPacket Shippers_LoadAll();		

		[OperationContract]
		ShippersCollection.ShippersCollectionWCFPacket Shippers_QueryForCollection(string serializedQuery);

		[OperationContract]
		Shippers Shippers_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Shippers Shippers_GetByPrimaryKey(System.Int32 shipperID);

		[OperationContract]
		ShippersCollection.ShippersCollectionWCFPacket Shippers_SaveCollection(ShippersCollection.ShippersCollectionWCFPacket collection);

		[OperationContract]
		Shippers Shippers_SaveEntity(Shippers entity);		

		#endregion
	
		#region Suppliers
		
		[OperationContract]
		SuppliersCollection.SuppliersCollectionWCFPacket Suppliers_LoadAll();		

		[OperationContract]
		SuppliersCollection.SuppliersCollectionWCFPacket Suppliers_QueryForCollection(string serializedQuery);

		[OperationContract]
		Suppliers Suppliers_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Suppliers Suppliers_GetByPrimaryKey(System.Int32 supplierID);

		[OperationContract]
		SuppliersCollection.SuppliersCollectionWCFPacket Suppliers_SaveCollection(SuppliersCollection.SuppliersCollectionWCFPacket collection);

		[OperationContract]
		Suppliers Suppliers_SaveEntity(Suppliers entity);		

		#endregion
	
		#region Territories
		
		[OperationContract]
		TerritoriesCollection.TerritoriesCollectionWCFPacket Territories_LoadAll();		

		[OperationContract]
		TerritoriesCollection.TerritoriesCollectionWCFPacket Territories_QueryForCollection(string serializedQuery);

		[OperationContract]
		Territories Territories_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		Territories Territories_GetByPrimaryKey(System.String territoryID);

		[OperationContract]
		TerritoriesCollection.TerritoriesCollectionWCFPacket Territories_SaveCollection(TerritoriesCollection.TerritoriesCollectionWCFPacket collection);

		[OperationContract]
		Territories Territories_SaveEntity(Territories entity);		

		#endregion

    }
}