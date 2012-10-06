/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:28 PM
===============================================================================
*/

using System.ServiceModel;
using BusinessObjects;

namespace WCFService
{
	[ServiceContract]
	public partial interface IService1
	{
	
		#region Categories
		
		[OperationContract]
		CategoriesCollectionProxyStub Categories_LoadAll();		

		[OperationContract]
		CategoriesCollectionProxyStub Categories_QueryForCollection(string serializedQuery);

		[OperationContract]
		CategoriesProxyStub Categories_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		CategoriesProxyStub Categories_GetByPrimaryKey(System.Int32 categoryID);

		[OperationContract]
		CategoriesCollectionProxyStub Categories_SaveCollection(CategoriesCollectionProxyStub collection);

		[OperationContract]
		CategoriesProxyStub Categories_SaveEntity(CategoriesProxyStub entity);		

		#endregion
	
		#region CustomerCustomerDemo
		
		[OperationContract]
		CustomerCustomerDemoCollectionProxyStub CustomerCustomerDemo_LoadAll();		

		[OperationContract]
		CustomerCustomerDemoCollectionProxyStub CustomerCustomerDemo_QueryForCollection(string serializedQuery);

		[OperationContract]
		CustomerCustomerDemoProxyStub CustomerCustomerDemo_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		CustomerCustomerDemoProxyStub CustomerCustomerDemo_GetByPrimaryKey(System.String customerID, System.String customerTypeID);

		[OperationContract]
		CustomerCustomerDemoCollectionProxyStub CustomerCustomerDemo_SaveCollection(CustomerCustomerDemoCollectionProxyStub collection);

		[OperationContract]
		CustomerCustomerDemoProxyStub CustomerCustomerDemo_SaveEntity(CustomerCustomerDemoProxyStub entity);		

		#endregion
	
		#region CustomerDemographics
		
		[OperationContract]
		CustomerDemographicsCollectionProxyStub CustomerDemographics_LoadAll();		

		[OperationContract]
		CustomerDemographicsCollectionProxyStub CustomerDemographics_QueryForCollection(string serializedQuery);

		[OperationContract]
		CustomerDemographicsProxyStub CustomerDemographics_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		CustomerDemographicsProxyStub CustomerDemographics_GetByPrimaryKey(System.String customerTypeID);

		[OperationContract]
		CustomerDemographicsCollectionProxyStub CustomerDemographics_SaveCollection(CustomerDemographicsCollectionProxyStub collection);

		[OperationContract]
		CustomerDemographicsProxyStub CustomerDemographics_SaveEntity(CustomerDemographicsProxyStub entity);		

		#endregion
	
		#region Customers
		
		[OperationContract]
		CustomersCollectionProxyStub Customers_LoadAll();		

		[OperationContract]
		CustomersCollectionProxyStub Customers_QueryForCollection(string serializedQuery);

		[OperationContract]
		CustomersProxyStub Customers_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		CustomersProxyStub Customers_GetByPrimaryKey(System.String customerID);

		[OperationContract]
		CustomersCollectionProxyStub Customers_SaveCollection(CustomersCollectionProxyStub collection);

		[OperationContract]
		CustomersProxyStub Customers_SaveEntity(CustomersProxyStub entity);		

		#endregion
	
		#region Employees
		
		[OperationContract]
		EmployeesCollectionProxyStub Employees_LoadAll();		

		[OperationContract]
		EmployeesCollectionProxyStub Employees_QueryForCollection(string serializedQuery);

		[OperationContract]
		EmployeesProxyStub Employees_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		EmployeesProxyStub Employees_GetByPrimaryKey(System.Int32 employeeID);

		[OperationContract]
		EmployeesCollectionProxyStub Employees_SaveCollection(EmployeesCollectionProxyStub collection);

		[OperationContract]
		EmployeesProxyStub Employees_SaveEntity(EmployeesProxyStub entity);		

		#endregion
	
		#region EmployeeTerritories
		
		[OperationContract]
		EmployeeTerritoriesCollectionProxyStub EmployeeTerritories_LoadAll();		

		[OperationContract]
		EmployeeTerritoriesCollectionProxyStub EmployeeTerritories_QueryForCollection(string serializedQuery);

		[OperationContract]
		EmployeeTerritoriesProxyStub EmployeeTerritories_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		EmployeeTerritoriesProxyStub EmployeeTerritories_GetByPrimaryKey(System.Int32 employeeID, System.String territoryID);

		[OperationContract]
		EmployeeTerritoriesCollectionProxyStub EmployeeTerritories_SaveCollection(EmployeeTerritoriesCollectionProxyStub collection);

		[OperationContract]
		EmployeeTerritoriesProxyStub EmployeeTerritories_SaveEntity(EmployeeTerritoriesProxyStub entity);		

		#endregion
	
		#region OrderDetails
		
		[OperationContract]
		OrderDetailsCollectionProxyStub OrderDetails_LoadAll();		

		[OperationContract]
		OrderDetailsCollectionProxyStub OrderDetails_QueryForCollection(string serializedQuery);

		[OperationContract]
		OrderDetailsProxyStub OrderDetails_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		OrderDetailsProxyStub OrderDetails_GetByPrimaryKey(System.Int32 orderID, System.Int32 productID);

		[OperationContract]
		OrderDetailsCollectionProxyStub OrderDetails_SaveCollection(OrderDetailsCollectionProxyStub collection);

		[OperationContract]
		OrderDetailsProxyStub OrderDetails_SaveEntity(OrderDetailsProxyStub entity);		

		#endregion
	
		#region Orders
		
		[OperationContract]
		OrdersCollectionProxyStub Orders_LoadAll();		

		[OperationContract]
		OrdersCollectionProxyStub Orders_QueryForCollection(string serializedQuery);

		[OperationContract]
		OrdersProxyStub Orders_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		OrdersProxyStub Orders_GetByPrimaryKey(System.Int32 orderID);

		[OperationContract]
		OrdersCollectionProxyStub Orders_SaveCollection(OrdersCollectionProxyStub collection);

		[OperationContract]
		OrdersProxyStub Orders_SaveEntity(OrdersProxyStub entity);		

		#endregion
	
		#region Products
		
		[OperationContract]
		ProductsCollectionProxyStub Products_LoadAll();		

		[OperationContract]
		ProductsCollectionProxyStub Products_QueryForCollection(string serializedQuery);

		[OperationContract]
		ProductsProxyStub Products_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		ProductsProxyStub Products_GetByPrimaryKey(System.Int32 productID);

		[OperationContract]
		ProductsCollectionProxyStub Products_SaveCollection(ProductsCollectionProxyStub collection);

		[OperationContract]
		ProductsProxyStub Products_SaveEntity(ProductsProxyStub entity);		

		#endregion
	
		#region Region
		
		[OperationContract]
		RegionCollectionProxyStub Region_LoadAll();		

		[OperationContract]
		RegionCollectionProxyStub Region_QueryForCollection(string serializedQuery);

		[OperationContract]
		RegionProxyStub Region_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		RegionProxyStub Region_GetByPrimaryKey(System.Int32 regionID);

		[OperationContract]
		RegionCollectionProxyStub Region_SaveCollection(RegionCollectionProxyStub collection);

		[OperationContract]
		RegionProxyStub Region_SaveEntity(RegionProxyStub entity);		

		#endregion
	
		#region Shippers
		
		[OperationContract]
		ShippersCollectionProxyStub Shippers_LoadAll();		

		[OperationContract]
		ShippersCollectionProxyStub Shippers_QueryForCollection(string serializedQuery);

		[OperationContract]
		ShippersProxyStub Shippers_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		ShippersProxyStub Shippers_GetByPrimaryKey(System.Int32 shipperID);

		[OperationContract]
		ShippersCollectionProxyStub Shippers_SaveCollection(ShippersCollectionProxyStub collection);

		[OperationContract]
		ShippersProxyStub Shippers_SaveEntity(ShippersProxyStub entity);		

		#endregion
	
		#region Suppliers
		
		[OperationContract]
		SuppliersCollectionProxyStub Suppliers_LoadAll();		

		[OperationContract]
		SuppliersCollectionProxyStub Suppliers_QueryForCollection(string serializedQuery);

		[OperationContract]
		SuppliersProxyStub Suppliers_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		SuppliersProxyStub Suppliers_GetByPrimaryKey(System.Int32 supplierID);

		[OperationContract]
		SuppliersCollectionProxyStub Suppliers_SaveCollection(SuppliersCollectionProxyStub collection);

		[OperationContract]
		SuppliersProxyStub Suppliers_SaveEntity(SuppliersProxyStub entity);		

		#endregion
	
		#region Territories
		
		[OperationContract]
		TerritoriesCollectionProxyStub Territories_LoadAll();		

		[OperationContract]
		TerritoriesCollectionProxyStub Territories_QueryForCollection(string serializedQuery);

		[OperationContract]
		TerritoriesProxyStub Territories_QueryForEntity(string serializedQuery);
		
		[OperationContract]
		TerritoriesProxyStub Territories_GetByPrimaryKey(System.String territoryID);

		[OperationContract]
		TerritoriesCollectionProxyStub Territories_SaveCollection(TerritoriesCollectionProxyStub collection);

		[OperationContract]
		TerritoriesProxyStub Territories_SaveEntity(TerritoriesProxyStub entity);		

		#endregion

    }
}