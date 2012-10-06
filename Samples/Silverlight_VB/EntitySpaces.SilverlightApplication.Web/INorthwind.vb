'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:23 PM
'===============================================================================

Imports System.ServiceModel
Imports EntitySpaces.SilverlightApplication.Web.BusinessObjects

<ServiceContract()> _
Public Interface INorthwind
	
#Region "Categories"

	<OperationContract()> _
	Function Categories_LoadAll() As CategoriesCollectionProxyStub

	<OperationContract()> _
	Function Categories_QueryForCollection(ByVal serializedQuery As String) As CategoriesCollectionProxyStub

	<OperationContract()> _
	Function Categories_QueryForEntity(ByVal serializedQuery As String) As CategoriesProxyStub
	
	<OperationContract()> _
	Function Categories_GetByPrimaryKey(ByVal categoryID As System.Int32) As CategoriesProxyStub

	<OperationContract()> _
	Function Categories_SaveCollection(ByVal collection As CategoriesCollectionProxyStub) As CategoriesCollectionProxyStub

	<OperationContract()> _
	Function Categories_SaveEntity(ByVal entity As CategoriesProxyStub) As CategoriesProxyStub

#End Region
	
#Region "CustomerCustomerDemo"

	<OperationContract()> _
	Function CustomerCustomerDemo_LoadAll() As CustomerCustomerDemoCollectionProxyStub

	<OperationContract()> _
	Function CustomerCustomerDemo_QueryForCollection(ByVal serializedQuery As String) As CustomerCustomerDemoCollectionProxyStub

	<OperationContract()> _
	Function CustomerCustomerDemo_QueryForEntity(ByVal serializedQuery As String) As CustomerCustomerDemoProxyStub
	
	<OperationContract()> _
	Function CustomerCustomerDemo_GetByPrimaryKey(ByVal customerID As System.String, ByVal customerTypeID As System.String) As CustomerCustomerDemoProxyStub

	<OperationContract()> _
	Function CustomerCustomerDemo_SaveCollection(ByVal collection As CustomerCustomerDemoCollectionProxyStub) As CustomerCustomerDemoCollectionProxyStub

	<OperationContract()> _
	Function CustomerCustomerDemo_SaveEntity(ByVal entity As CustomerCustomerDemoProxyStub) As CustomerCustomerDemoProxyStub

#End Region
	
#Region "CustomerDemographics"

	<OperationContract()> _
	Function CustomerDemographics_LoadAll() As CustomerDemographicsCollectionProxyStub

	<OperationContract()> _
	Function CustomerDemographics_QueryForCollection(ByVal serializedQuery As String) As CustomerDemographicsCollectionProxyStub

	<OperationContract()> _
	Function CustomerDemographics_QueryForEntity(ByVal serializedQuery As String) As CustomerDemographicsProxyStub
	
	<OperationContract()> _
	Function CustomerDemographics_GetByPrimaryKey(ByVal customerTypeID As System.String) As CustomerDemographicsProxyStub

	<OperationContract()> _
	Function CustomerDemographics_SaveCollection(ByVal collection As CustomerDemographicsCollectionProxyStub) As CustomerDemographicsCollectionProxyStub

	<OperationContract()> _
	Function CustomerDemographics_SaveEntity(ByVal entity As CustomerDemographicsProxyStub) As CustomerDemographicsProxyStub

#End Region
	
#Region "Customers"

	<OperationContract()> _
	Function Customers_LoadAll() As CustomersCollectionProxyStub

	<OperationContract()> _
	Function Customers_QueryForCollection(ByVal serializedQuery As String) As CustomersCollectionProxyStub

	<OperationContract()> _
	Function Customers_QueryForEntity(ByVal serializedQuery As String) As CustomersProxyStub
	
	<OperationContract()> _
	Function Customers_GetByPrimaryKey(ByVal customerID As System.String) As CustomersProxyStub

	<OperationContract()> _
	Function Customers_SaveCollection(ByVal collection As CustomersCollectionProxyStub) As CustomersCollectionProxyStub

	<OperationContract()> _
	Function Customers_SaveEntity(ByVal entity As CustomersProxyStub) As CustomersProxyStub

#End Region
	
#Region "Employees"

	<OperationContract()> _
	Function Employees_LoadAll() As EmployeesCollectionProxyStub

	<OperationContract()> _
	Function Employees_QueryForCollection(ByVal serializedQuery As String) As EmployeesCollectionProxyStub

	<OperationContract()> _
	Function Employees_QueryForEntity(ByVal serializedQuery As String) As EmployeesProxyStub
	
	<OperationContract()> _
	Function Employees_GetByPrimaryKey(ByVal employeeID As System.Int32) As EmployeesProxyStub

	<OperationContract()> _
	Function Employees_SaveCollection(ByVal collection As EmployeesCollectionProxyStub) As EmployeesCollectionProxyStub

	<OperationContract()> _
	Function Employees_SaveEntity(ByVal entity As EmployeesProxyStub) As EmployeesProxyStub

#End Region
	
#Region "EmployeeTerritories"

	<OperationContract()> _
	Function EmployeeTerritories_LoadAll() As EmployeeTerritoriesCollectionProxyStub

	<OperationContract()> _
	Function EmployeeTerritories_QueryForCollection(ByVal serializedQuery As String) As EmployeeTerritoriesCollectionProxyStub

	<OperationContract()> _
	Function EmployeeTerritories_QueryForEntity(ByVal serializedQuery As String) As EmployeeTerritoriesProxyStub
	
	<OperationContract()> _
	Function EmployeeTerritories_GetByPrimaryKey(ByVal employeeID As System.Int32, ByVal territoryID As System.String) As EmployeeTerritoriesProxyStub

	<OperationContract()> _
	Function EmployeeTerritories_SaveCollection(ByVal collection As EmployeeTerritoriesCollectionProxyStub) As EmployeeTerritoriesCollectionProxyStub

	<OperationContract()> _
	Function EmployeeTerritories_SaveEntity(ByVal entity As EmployeeTerritoriesProxyStub) As EmployeeTerritoriesProxyStub

#End Region
	
#Region "OrderDetails"

	<OperationContract()> _
	Function OrderDetails_LoadAll() As OrderDetailsCollectionProxyStub

	<OperationContract()> _
	Function OrderDetails_QueryForCollection(ByVal serializedQuery As String) As OrderDetailsCollectionProxyStub

	<OperationContract()> _
	Function OrderDetails_QueryForEntity(ByVal serializedQuery As String) As OrderDetailsProxyStub
	
	<OperationContract()> _
	Function OrderDetails_GetByPrimaryKey(ByVal orderID As System.Int32, ByVal productID As System.Int32) As OrderDetailsProxyStub

	<OperationContract()> _
	Function OrderDetails_SaveCollection(ByVal collection As OrderDetailsCollectionProxyStub) As OrderDetailsCollectionProxyStub

	<OperationContract()> _
	Function OrderDetails_SaveEntity(ByVal entity As OrderDetailsProxyStub) As OrderDetailsProxyStub

#End Region
	
#Region "Orders"

	<OperationContract()> _
	Function Orders_LoadAll() As OrdersCollectionProxyStub

	<OperationContract()> _
	Function Orders_QueryForCollection(ByVal serializedQuery As String) As OrdersCollectionProxyStub

	<OperationContract()> _
	Function Orders_QueryForEntity(ByVal serializedQuery As String) As OrdersProxyStub
	
	<OperationContract()> _
	Function Orders_GetByPrimaryKey(ByVal orderID As System.Int32) As OrdersProxyStub

	<OperationContract()> _
	Function Orders_SaveCollection(ByVal collection As OrdersCollectionProxyStub) As OrdersCollectionProxyStub

	<OperationContract()> _
	Function Orders_SaveEntity(ByVal entity As OrdersProxyStub) As OrdersProxyStub

#End Region
	
#Region "Products"

	<OperationContract()> _
	Function Products_LoadAll() As ProductsCollectionProxyStub

	<OperationContract()> _
	Function Products_QueryForCollection(ByVal serializedQuery As String) As ProductsCollectionProxyStub

	<OperationContract()> _
	Function Products_QueryForEntity(ByVal serializedQuery As String) As ProductsProxyStub
	
	<OperationContract()> _
	Function Products_GetByPrimaryKey(ByVal productID As System.Int32) As ProductsProxyStub

	<OperationContract()> _
	Function Products_SaveCollection(ByVal collection As ProductsCollectionProxyStub) As ProductsCollectionProxyStub

	<OperationContract()> _
	Function Products_SaveEntity(ByVal entity As ProductsProxyStub) As ProductsProxyStub

#End Region
	
#Region "Region"

	<OperationContract()> _
	Function Region_LoadAll() As RegionCollectionProxyStub

	<OperationContract()> _
	Function Region_QueryForCollection(ByVal serializedQuery As String) As RegionCollectionProxyStub

	<OperationContract()> _
	Function Region_QueryForEntity(ByVal serializedQuery As String) As RegionProxyStub
	
	<OperationContract()> _
	Function Region_GetByPrimaryKey(ByVal regionID As System.Int32) As RegionProxyStub

	<OperationContract()> _
	Function Region_SaveCollection(ByVal collection As RegionCollectionProxyStub) As RegionCollectionProxyStub

	<OperationContract()> _
	Function Region_SaveEntity(ByVal entity As RegionProxyStub) As RegionProxyStub

#End Region
	
#Region "Shippers"

	<OperationContract()> _
	Function Shippers_LoadAll() As ShippersCollectionProxyStub

	<OperationContract()> _
	Function Shippers_QueryForCollection(ByVal serializedQuery As String) As ShippersCollectionProxyStub

	<OperationContract()> _
	Function Shippers_QueryForEntity(ByVal serializedQuery As String) As ShippersProxyStub
	
	<OperationContract()> _
	Function Shippers_GetByPrimaryKey(ByVal shipperID As System.Int32) As ShippersProxyStub

	<OperationContract()> _
	Function Shippers_SaveCollection(ByVal collection As ShippersCollectionProxyStub) As ShippersCollectionProxyStub

	<OperationContract()> _
	Function Shippers_SaveEntity(ByVal entity As ShippersProxyStub) As ShippersProxyStub

#End Region
	
#Region "Suppliers"

	<OperationContract()> _
	Function Suppliers_LoadAll() As SuppliersCollectionProxyStub

	<OperationContract()> _
	Function Suppliers_QueryForCollection(ByVal serializedQuery As String) As SuppliersCollectionProxyStub

	<OperationContract()> _
	Function Suppliers_QueryForEntity(ByVal serializedQuery As String) As SuppliersProxyStub
	
	<OperationContract()> _
	Function Suppliers_GetByPrimaryKey(ByVal supplierID As System.Int32) As SuppliersProxyStub

	<OperationContract()> _
	Function Suppliers_SaveCollection(ByVal collection As SuppliersCollectionProxyStub) As SuppliersCollectionProxyStub

	<OperationContract()> _
	Function Suppliers_SaveEntity(ByVal entity As SuppliersProxyStub) As SuppliersProxyStub

#End Region
	
#Region "Territories"

	<OperationContract()> _
	Function Territories_LoadAll() As TerritoriesCollectionProxyStub

	<OperationContract()> _
	Function Territories_QueryForCollection(ByVal serializedQuery As String) As TerritoriesCollectionProxyStub

	<OperationContract()> _
	Function Territories_QueryForEntity(ByVal serializedQuery As String) As TerritoriesProxyStub
	
	<OperationContract()> _
	Function Territories_GetByPrimaryKey(ByVal territoryID As System.String) As TerritoriesProxyStub

	<OperationContract()> _
	Function Territories_SaveCollection(ByVal collection As TerritoriesCollectionProxyStub) As TerritoriesCollectionProxyStub

	<OperationContract()> _
	Function Territories_SaveEntity(ByVal entity As TerritoriesProxyStub) As TerritoriesProxyStub

#End Region

End Interface