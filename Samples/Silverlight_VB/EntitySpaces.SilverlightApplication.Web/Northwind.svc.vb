'===============================================================================
'                   EntitySpaces 2009 by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:23 PM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.ServiceModel.Activation
Imports System.Text.RegularExpressions

Imports EntitySpaces.SilverlightApplication.Web.BusinessObjects

Imports EntitySpaces.Interfaces

<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
Public Partial Class Northwind
    Implements INorthwind

#Region "Categories"

	Public Function Categories_LoadAll() As CategoriesCollectionProxyStub Implements INorthwind.Categories_LoadAll
	
		Dim coll As New CategoriesCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Categories_QueryForCollection(ByVal serializedQuery As String) As CategoriesCollectionProxyStub Implements INorthwind.Categories_QueryForCollection

		Dim _query As CategoriesQuery = TryCast(CategoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(CategoriesQuery), AllKnownTypes), CategoriesQuery)

		Dim coll As New CategoriesCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Categories_QueryForEntity(ByVal serializedQuery As String) As CategoriesProxyStub Implements INorthwind.Categories_QueryForEntity

		Dim _query As CategoriesQuery = TryCast(CategoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(CategoriesQuery), AllKnownTypes), CategoriesQuery)

		Dim obj As New Categories()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Categories_GetByPrimaryKey(ByVal categoryID As System.Int32) As CategoriesProxyStub Implements INorthwind.Categories_GetByPrimaryKey

        Dim obj As New Categories()
        If obj.LoadByPrimaryKey(categoryID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Categories_SaveCollection(ByVal collection As CategoriesCollectionProxyStub) As CategoriesCollectionProxyStub Implements INorthwind.Categories_SaveCollection

		If collection IsNot Nothing Then
			Dim c As CategoriesCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Categories_SaveEntity(ByVal entity As CategoriesProxyStub) As CategoriesProxyStub Implements INorthwind.Categories_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "CustomerCustomerDemo"

	Public Function CustomerCustomerDemo_LoadAll() As CustomerCustomerDemoCollectionProxyStub Implements INorthwind.CustomerCustomerDemo_LoadAll
	
		Dim coll As New CustomerCustomerDemoCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function CustomerCustomerDemo_QueryForCollection(ByVal serializedQuery As String) As CustomerCustomerDemoCollectionProxyStub Implements INorthwind.CustomerCustomerDemo_QueryForCollection

		Dim _query As CustomerCustomerDemoQuery = TryCast(CustomerCustomerDemoQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerCustomerDemoQuery), AllKnownTypes), CustomerCustomerDemoQuery)

		Dim coll As New CustomerCustomerDemoCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function CustomerCustomerDemo_QueryForEntity(ByVal serializedQuery As String) As CustomerCustomerDemoProxyStub Implements INorthwind.CustomerCustomerDemo_QueryForEntity

		Dim _query As CustomerCustomerDemoQuery = TryCast(CustomerCustomerDemoQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerCustomerDemoQuery), AllKnownTypes), CustomerCustomerDemoQuery)

		Dim obj As New CustomerCustomerDemo()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function CustomerCustomerDemo_GetByPrimaryKey(ByVal customerID As System.String, ByVal customerTypeID As System.String) As CustomerCustomerDemoProxyStub Implements INorthwind.CustomerCustomerDemo_GetByPrimaryKey

        Dim obj As New CustomerCustomerDemo()
        If obj.LoadByPrimaryKey(customerID, customerTypeID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function CustomerCustomerDemo_SaveCollection(ByVal collection As CustomerCustomerDemoCollectionProxyStub) As CustomerCustomerDemoCollectionProxyStub Implements INorthwind.CustomerCustomerDemo_SaveCollection

		If collection IsNot Nothing Then
			Dim c As CustomerCustomerDemoCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function CustomerCustomerDemo_SaveEntity(ByVal entity As CustomerCustomerDemoProxyStub) As CustomerCustomerDemoProxyStub Implements INorthwind.CustomerCustomerDemo_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "CustomerDemographics"

	Public Function CustomerDemographics_LoadAll() As CustomerDemographicsCollectionProxyStub Implements INorthwind.CustomerDemographics_LoadAll
	
		Dim coll As New CustomerDemographicsCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function CustomerDemographics_QueryForCollection(ByVal serializedQuery As String) As CustomerDemographicsCollectionProxyStub Implements INorthwind.CustomerDemographics_QueryForCollection

		Dim _query As CustomerDemographicsQuery = TryCast(CustomerDemographicsQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerDemographicsQuery), AllKnownTypes), CustomerDemographicsQuery)

		Dim coll As New CustomerDemographicsCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function CustomerDemographics_QueryForEntity(ByVal serializedQuery As String) As CustomerDemographicsProxyStub Implements INorthwind.CustomerDemographics_QueryForEntity

		Dim _query As CustomerDemographicsQuery = TryCast(CustomerDemographicsQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerDemographicsQuery), AllKnownTypes), CustomerDemographicsQuery)

		Dim obj As New CustomerDemographics()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function CustomerDemographics_GetByPrimaryKey(ByVal customerTypeID As System.String) As CustomerDemographicsProxyStub Implements INorthwind.CustomerDemographics_GetByPrimaryKey

        Dim obj As New CustomerDemographics()
        If obj.LoadByPrimaryKey(customerTypeID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function CustomerDemographics_SaveCollection(ByVal collection As CustomerDemographicsCollectionProxyStub) As CustomerDemographicsCollectionProxyStub Implements INorthwind.CustomerDemographics_SaveCollection

		If collection IsNot Nothing Then
			Dim c As CustomerDemographicsCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function CustomerDemographics_SaveEntity(ByVal entity As CustomerDemographicsProxyStub) As CustomerDemographicsProxyStub Implements INorthwind.CustomerDemographics_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Customers"

	Public Function Customers_LoadAll() As CustomersCollectionProxyStub Implements INorthwind.Customers_LoadAll
	
		Dim coll As New CustomersCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Customers_QueryForCollection(ByVal serializedQuery As String) As CustomersCollectionProxyStub Implements INorthwind.Customers_QueryForCollection

		Dim _query As CustomersQuery = TryCast(CustomersQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomersQuery), AllKnownTypes), CustomersQuery)

		Dim coll As New CustomersCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Customers_QueryForEntity(ByVal serializedQuery As String) As CustomersProxyStub Implements INorthwind.Customers_QueryForEntity

		Dim _query As CustomersQuery = TryCast(CustomersQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomersQuery), AllKnownTypes), CustomersQuery)

		Dim obj As New Customers()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Customers_GetByPrimaryKey(ByVal customerID As System.String) As CustomersProxyStub Implements INorthwind.Customers_GetByPrimaryKey

        Dim obj As New Customers()
        If obj.LoadByPrimaryKey(customerID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Customers_SaveCollection(ByVal collection As CustomersCollectionProxyStub) As CustomersCollectionProxyStub Implements INorthwind.Customers_SaveCollection

		If collection IsNot Nothing Then
			Dim c As CustomersCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Customers_SaveEntity(ByVal entity As CustomersProxyStub) As CustomersProxyStub Implements INorthwind.Customers_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Employees"

	Public Function Employees_LoadAll() As EmployeesCollectionProxyStub Implements INorthwind.Employees_LoadAll
	
		Dim coll As New EmployeesCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Employees_QueryForCollection(ByVal serializedQuery As String) As EmployeesCollectionProxyStub Implements INorthwind.Employees_QueryForCollection

		Dim _query As EmployeesQuery = TryCast(EmployeesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeesQuery), AllKnownTypes), EmployeesQuery)

		Dim coll As New EmployeesCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Employees_QueryForEntity(ByVal serializedQuery As String) As EmployeesProxyStub Implements INorthwind.Employees_QueryForEntity

		Dim _query As EmployeesQuery = TryCast(EmployeesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeesQuery), AllKnownTypes), EmployeesQuery)

		Dim obj As New Employees()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Employees_GetByPrimaryKey(ByVal employeeID As System.Int32) As EmployeesProxyStub Implements INorthwind.Employees_GetByPrimaryKey

        Dim obj As New Employees()
        If obj.LoadByPrimaryKey(employeeID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Employees_SaveCollection(ByVal collection As EmployeesCollectionProxyStub) As EmployeesCollectionProxyStub Implements INorthwind.Employees_SaveCollection

		If collection IsNot Nothing Then
			Dim c As EmployeesCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Employees_SaveEntity(ByVal entity As EmployeesProxyStub) As EmployeesProxyStub Implements INorthwind.Employees_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "EmployeeTerritories"

	Public Function EmployeeTerritories_LoadAll() As EmployeeTerritoriesCollectionProxyStub Implements INorthwind.EmployeeTerritories_LoadAll
	
		Dim coll As New EmployeeTerritoriesCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function EmployeeTerritories_QueryForCollection(ByVal serializedQuery As String) As EmployeeTerritoriesCollectionProxyStub Implements INorthwind.EmployeeTerritories_QueryForCollection

		Dim _query As EmployeeTerritoriesQuery = TryCast(EmployeeTerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeeTerritoriesQuery), AllKnownTypes), EmployeeTerritoriesQuery)

		Dim coll As New EmployeeTerritoriesCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function EmployeeTerritories_QueryForEntity(ByVal serializedQuery As String) As EmployeeTerritoriesProxyStub Implements INorthwind.EmployeeTerritories_QueryForEntity

		Dim _query As EmployeeTerritoriesQuery = TryCast(EmployeeTerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeeTerritoriesQuery), AllKnownTypes), EmployeeTerritoriesQuery)

		Dim obj As New EmployeeTerritories()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function EmployeeTerritories_GetByPrimaryKey(ByVal employeeID As System.Int32, ByVal territoryID As System.String) As EmployeeTerritoriesProxyStub Implements INorthwind.EmployeeTerritories_GetByPrimaryKey

        Dim obj As New EmployeeTerritories()
        If obj.LoadByPrimaryKey(employeeID, territoryID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function EmployeeTerritories_SaveCollection(ByVal collection As EmployeeTerritoriesCollectionProxyStub) As EmployeeTerritoriesCollectionProxyStub Implements INorthwind.EmployeeTerritories_SaveCollection

		If collection IsNot Nothing Then
			Dim c As EmployeeTerritoriesCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function EmployeeTerritories_SaveEntity(ByVal entity As EmployeeTerritoriesProxyStub) As EmployeeTerritoriesProxyStub Implements INorthwind.EmployeeTerritories_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "OrderDetails"

	Public Function OrderDetails_LoadAll() As OrderDetailsCollectionProxyStub Implements INorthwind.OrderDetails_LoadAll
	
		Dim coll As New OrderDetailsCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function OrderDetails_QueryForCollection(ByVal serializedQuery As String) As OrderDetailsCollectionProxyStub Implements INorthwind.OrderDetails_QueryForCollection

		Dim _query As OrderDetailsQuery = TryCast(OrderDetailsQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrderDetailsQuery), AllKnownTypes), OrderDetailsQuery)

		Dim coll As New OrderDetailsCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function OrderDetails_QueryForEntity(ByVal serializedQuery As String) As OrderDetailsProxyStub Implements INorthwind.OrderDetails_QueryForEntity

		Dim _query As OrderDetailsQuery = TryCast(OrderDetailsQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrderDetailsQuery), AllKnownTypes), OrderDetailsQuery)

		Dim obj As New OrderDetails()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function OrderDetails_GetByPrimaryKey(ByVal orderID As System.Int32, ByVal productID As System.Int32) As OrderDetailsProxyStub Implements INorthwind.OrderDetails_GetByPrimaryKey

        Dim obj As New OrderDetails()
        If obj.LoadByPrimaryKey(orderID, productID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function OrderDetails_SaveCollection(ByVal collection As OrderDetailsCollectionProxyStub) As OrderDetailsCollectionProxyStub Implements INorthwind.OrderDetails_SaveCollection

		If collection IsNot Nothing Then
			Dim c As OrderDetailsCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function OrderDetails_SaveEntity(ByVal entity As OrderDetailsProxyStub) As OrderDetailsProxyStub Implements INorthwind.OrderDetails_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Orders"

	Public Function Orders_LoadAll() As OrdersCollectionProxyStub Implements INorthwind.Orders_LoadAll
	
		Dim coll As New OrdersCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Orders_QueryForCollection(ByVal serializedQuery As String) As OrdersCollectionProxyStub Implements INorthwind.Orders_QueryForCollection

		Dim _query As OrdersQuery = TryCast(OrdersQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrdersQuery), AllKnownTypes), OrdersQuery)

		Dim coll As New OrdersCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Orders_QueryForEntity(ByVal serializedQuery As String) As OrdersProxyStub Implements INorthwind.Orders_QueryForEntity

		Dim _query As OrdersQuery = TryCast(OrdersQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrdersQuery), AllKnownTypes), OrdersQuery)

		Dim obj As New Orders()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Orders_GetByPrimaryKey(ByVal orderID As System.Int32) As OrdersProxyStub Implements INorthwind.Orders_GetByPrimaryKey

        Dim obj As New Orders()
        If obj.LoadByPrimaryKey(orderID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Orders_SaveCollection(ByVal collection As OrdersCollectionProxyStub) As OrdersCollectionProxyStub Implements INorthwind.Orders_SaveCollection

		If collection IsNot Nothing Then
			Dim c As OrdersCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Orders_SaveEntity(ByVal entity As OrdersProxyStub) As OrdersProxyStub Implements INorthwind.Orders_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Products"

	Public Function Products_LoadAll() As ProductsCollectionProxyStub Implements INorthwind.Products_LoadAll
	
		Dim coll As New ProductsCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Products_QueryForCollection(ByVal serializedQuery As String) As ProductsCollectionProxyStub Implements INorthwind.Products_QueryForCollection

		Dim _query As ProductsQuery = TryCast(ProductsQuery.SerializeHelper.FromXml(serializedQuery, GetType(ProductsQuery), AllKnownTypes), ProductsQuery)

		Dim coll As New ProductsCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Products_QueryForEntity(ByVal serializedQuery As String) As ProductsProxyStub Implements INorthwind.Products_QueryForEntity

		Dim _query As ProductsQuery = TryCast(ProductsQuery.SerializeHelper.FromXml(serializedQuery, GetType(ProductsQuery), AllKnownTypes), ProductsQuery)

		Dim obj As New Products()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Products_GetByPrimaryKey(ByVal productID As System.Int32) As ProductsProxyStub Implements INorthwind.Products_GetByPrimaryKey

        Dim obj As New Products()
        If obj.LoadByPrimaryKey(productID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Products_SaveCollection(ByVal collection As ProductsCollectionProxyStub) As ProductsCollectionProxyStub Implements INorthwind.Products_SaveCollection

		If collection IsNot Nothing Then
			Dim c As ProductsCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Products_SaveEntity(ByVal entity As ProductsProxyStub) As ProductsProxyStub Implements INorthwind.Products_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Region"

	Public Function Region_LoadAll() As RegionCollectionProxyStub Implements INorthwind.Region_LoadAll
	
		Dim coll As New RegionCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Region_QueryForCollection(ByVal serializedQuery As String) As RegionCollectionProxyStub Implements INorthwind.Region_QueryForCollection

		Dim _query As RegionQuery = TryCast(RegionQuery.SerializeHelper.FromXml(serializedQuery, GetType(RegionQuery), AllKnownTypes), RegionQuery)

		Dim coll As New RegionCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Region_QueryForEntity(ByVal serializedQuery As String) As RegionProxyStub Implements INorthwind.Region_QueryForEntity

		Dim _query As RegionQuery = TryCast(RegionQuery.SerializeHelper.FromXml(serializedQuery, GetType(RegionQuery), AllKnownTypes), RegionQuery)

		Dim obj As New Region()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Region_GetByPrimaryKey(ByVal regionID As System.Int32) As RegionProxyStub Implements INorthwind.Region_GetByPrimaryKey

        Dim obj As New Region()
        If obj.LoadByPrimaryKey(regionID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Region_SaveCollection(ByVal collection As RegionCollectionProxyStub) As RegionCollectionProxyStub Implements INorthwind.Region_SaveCollection

		If collection IsNot Nothing Then
			Dim c As RegionCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Region_SaveEntity(ByVal entity As RegionProxyStub) As RegionProxyStub Implements INorthwind.Region_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Shippers"

	Public Function Shippers_LoadAll() As ShippersCollectionProxyStub Implements INorthwind.Shippers_LoadAll
	
		Dim coll As New ShippersCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Shippers_QueryForCollection(ByVal serializedQuery As String) As ShippersCollectionProxyStub Implements INorthwind.Shippers_QueryForCollection

		Dim _query As ShippersQuery = TryCast(ShippersQuery.SerializeHelper.FromXml(serializedQuery, GetType(ShippersQuery), AllKnownTypes), ShippersQuery)

		Dim coll As New ShippersCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Shippers_QueryForEntity(ByVal serializedQuery As String) As ShippersProxyStub Implements INorthwind.Shippers_QueryForEntity

		Dim _query As ShippersQuery = TryCast(ShippersQuery.SerializeHelper.FromXml(serializedQuery, GetType(ShippersQuery), AllKnownTypes), ShippersQuery)

		Dim obj As New Shippers()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Shippers_GetByPrimaryKey(ByVal shipperID As System.Int32) As ShippersProxyStub Implements INorthwind.Shippers_GetByPrimaryKey

        Dim obj As New Shippers()
        If obj.LoadByPrimaryKey(shipperID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Shippers_SaveCollection(ByVal collection As ShippersCollectionProxyStub) As ShippersCollectionProxyStub Implements INorthwind.Shippers_SaveCollection

		If collection IsNot Nothing Then
			Dim c As ShippersCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Shippers_SaveEntity(ByVal entity As ShippersProxyStub) As ShippersProxyStub Implements INorthwind.Shippers_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Suppliers"

	Public Function Suppliers_LoadAll() As SuppliersCollectionProxyStub Implements INorthwind.Suppliers_LoadAll
	
		Dim coll As New SuppliersCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Suppliers_QueryForCollection(ByVal serializedQuery As String) As SuppliersCollectionProxyStub Implements INorthwind.Suppliers_QueryForCollection

		Dim _query As SuppliersQuery = TryCast(SuppliersQuery.SerializeHelper.FromXml(serializedQuery, GetType(SuppliersQuery), AllKnownTypes), SuppliersQuery)

		Dim coll As New SuppliersCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Suppliers_QueryForEntity(ByVal serializedQuery As String) As SuppliersProxyStub Implements INorthwind.Suppliers_QueryForEntity

		Dim _query As SuppliersQuery = TryCast(SuppliersQuery.SerializeHelper.FromXml(serializedQuery, GetType(SuppliersQuery), AllKnownTypes), SuppliersQuery)

		Dim obj As New Suppliers()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Suppliers_GetByPrimaryKey(ByVal supplierID As System.Int32) As SuppliersProxyStub Implements INorthwind.Suppliers_GetByPrimaryKey

        Dim obj As New Suppliers()
        If obj.LoadByPrimaryKey(supplierID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Suppliers_SaveCollection(ByVal collection As SuppliersCollectionProxyStub) As SuppliersCollectionProxyStub Implements INorthwind.Suppliers_SaveCollection

		If collection IsNot Nothing Then
			Dim c As SuppliersCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Suppliers_SaveEntity(ByVal entity As SuppliersProxyStub) As SuppliersProxyStub Implements INorthwind.Suppliers_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "Territories"

	Public Function Territories_LoadAll() As TerritoriesCollectionProxyStub Implements INorthwind.Territories_LoadAll
	
		Dim coll As New TerritoriesCollection()
		If coll.LoadAll() Then
			Return coll
		End If

		Return Nothing
		
	End Function	

	Public Function Territories_QueryForCollection(ByVal serializedQuery As String) As TerritoriesCollectionProxyStub Implements INorthwind.Territories_QueryForCollection

		Dim _query As TerritoriesQuery = TryCast(TerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(TerritoriesQuery), AllKnownTypes), TerritoriesQuery)

		Dim coll As New TerritoriesCollection()
		If coll.Load(_query) Then
			Return coll
		End If

		Return Nothing
	End Function

	Public Function Territories_QueryForEntity(ByVal serializedQuery As String) As TerritoriesProxyStub Implements INorthwind.Territories_QueryForEntity

		Dim _query As TerritoriesQuery = TryCast(TerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(TerritoriesQuery), AllKnownTypes), TerritoriesQuery)

		Dim obj As New Territories()
		If obj.Load(_query) Then
			Return obj
		End If

		Return Nothing
	End Function

	Public Function Territories_GetByPrimaryKey(ByVal territoryID As System.String) As TerritoriesProxyStub Implements INorthwind.Territories_GetByPrimaryKey

        Dim obj As New Territories()
        If obj.LoadByPrimaryKey(territoryID) Then
			Return obj
		End If
		
		Return Nothing

	End Function

	Public Function Territories_SaveCollection(ByVal collection As TerritoriesCollectionProxyStub) As TerritoriesCollectionProxyStub Implements INorthwind.Territories_SaveCollection

		If collection IsNot Nothing Then
			Dim c As TerritoriesCollection = collection.GetCollection()
			c.Save()
			Return c
		End If

		Return Nothing

	End Function

	Public Function Territories_SaveEntity(ByVal entity As TerritoriesProxyStub) As TerritoriesProxyStub Implements INorthwind.Territories_SaveEntity

		If entity IsNot Nothing Then
			entity.Entity.Save()

			If entity.Entity.RowState <> esDataRowState.Deleted AndAlso entity.Entity.RowState <> esDataRowState.Invalid Then
				Return entity
			End If
		End If

		Return Nothing

	End Function

#End Region

#Region "EntitySpaces Support Routines"

		Private Shared AllKnownTypes As List(Of Type) = GetAllKnownTypes()

		Private Shared Function GetAllKnownTypes() As List(Of Type)
			Dim types As New List(Of Type)()
			
			types.Add(GetType(CategoriesQuery))
			types.Add(GetType(CustomerCustomerDemoQuery))
			types.Add(GetType(CustomerDemographicsQuery))
			types.Add(GetType(CustomersQuery))
			types.Add(GetType(EmployeesQuery))
			types.Add(GetType(EmployeeTerritoriesQuery))
			types.Add(GetType(OrderDetailsQuery))
			types.Add(GetType(OrdersQuery))
			types.Add(GetType(ProductsQuery))
			types.Add(GetType(RegionQuery))
			types.Add(GetType(ShippersQuery))
			types.Add(GetType(SuppliersQuery))
			types.Add(GetType(TerritoriesQuery))

			Return types
		End Function
		
#End Region

End Class
