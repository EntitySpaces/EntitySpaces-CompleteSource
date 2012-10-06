'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:26 PM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server
Imports System.Text.RegularExpressions

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports Silverlight_RiaServices.BusinessObjects

Namespace esDomainServices

	<EnableClientAccess> _
	Public Partial Class esDomainService
	Inherits DomainService

#Region "Categories"	
	
		Public Function Categories_LoadAll() As CategoriesCollection
			Dim coll As New CategoriesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Categories_LoadByDynamic(serializedQuery As String) As CategoriesCollection
		
			Dim query As CategoriesQuery = _
				TryCast(CategoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(CategoriesQuery), AllKnownTypes), CategoriesQuery)

			Dim coll As New CategoriesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Categories_GetCount(serializedQuery As String) As Integer

			Dim query As CategoriesQuery = _
				TryCast(CategoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(CategoriesQuery), AllKnownTypes), CategoriesQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertCategories(obj As Silverlight_RiaServices.BusinessObjects.Categories)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateCategories(obj As Silverlight_RiaServices.BusinessObjects.Categories)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteCategories(obj As Silverlight_RiaServices.BusinessObjects.Categories) 
			Silverlight_RiaServices.BusinessObjects.Categories.Delete(obj.CategoryID.Value)
		End Sub		

#End Region

#Region "CustomerCustomerDemo"	
	
		Public Function CustomerCustomerDemo_LoadAll() As CustomerCustomerDemoCollection
			Dim coll As New CustomerCustomerDemoCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function CustomerCustomerDemo_LoadByDynamic(serializedQuery As String) As CustomerCustomerDemoCollection
		
			Dim query As CustomerCustomerDemoQuery = _
				TryCast(CustomerCustomerDemoQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerCustomerDemoQuery), AllKnownTypes), CustomerCustomerDemoQuery)

			Dim coll As New CustomerCustomerDemoCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function CustomerCustomerDemo_GetCount(serializedQuery As String) As Integer

			Dim query As CustomerCustomerDemoQuery = _
				TryCast(CustomerCustomerDemoQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerCustomerDemoQuery), AllKnownTypes), CustomerCustomerDemoQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertCustomerCustomerDemo(obj As Silverlight_RiaServices.BusinessObjects.CustomerCustomerDemo)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateCustomerCustomerDemo(obj As Silverlight_RiaServices.BusinessObjects.CustomerCustomerDemo)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteCustomerCustomerDemo(obj As Silverlight_RiaServices.BusinessObjects.CustomerCustomerDemo) 
			Silverlight_RiaServices.BusinessObjects.CustomerCustomerDemo.Delete(obj.CustomerID, obj.CustomerTypeID)
		End Sub		

#End Region

#Region "CustomerDemographics"	
	
		Public Function CustomerDemographics_LoadAll() As CustomerDemographicsCollection
			Dim coll As New CustomerDemographicsCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function CustomerDemographics_LoadByDynamic(serializedQuery As String) As CustomerDemographicsCollection
		
			Dim query As CustomerDemographicsQuery = _
				TryCast(CustomerDemographicsQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerDemographicsQuery), AllKnownTypes), CustomerDemographicsQuery)

			Dim coll As New CustomerDemographicsCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function CustomerDemographics_GetCount(serializedQuery As String) As Integer

			Dim query As CustomerDemographicsQuery = _
				TryCast(CustomerDemographicsQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomerDemographicsQuery), AllKnownTypes), CustomerDemographicsQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertCustomerDemographics(obj As Silverlight_RiaServices.BusinessObjects.CustomerDemographics)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateCustomerDemographics(obj As Silverlight_RiaServices.BusinessObjects.CustomerDemographics)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteCustomerDemographics(obj As Silverlight_RiaServices.BusinessObjects.CustomerDemographics) 
			Silverlight_RiaServices.BusinessObjects.CustomerDemographics.Delete(obj.CustomerTypeID)
		End Sub		

#End Region

#Region "Customers"	
	
		Public Function Customers_LoadAll() As CustomersCollection
			Dim coll As New CustomersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Customers_LoadByDynamic(serializedQuery As String) As CustomersCollection
		
			Dim query As CustomersQuery = _
				TryCast(CustomersQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomersQuery), AllKnownTypes), CustomersQuery)

			Dim coll As New CustomersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Customers_GetCount(serializedQuery As String) As Integer

			Dim query As CustomersQuery = _
				TryCast(CustomersQuery.SerializeHelper.FromXml(serializedQuery, GetType(CustomersQuery), AllKnownTypes), CustomersQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertCustomers(obj As Silverlight_RiaServices.BusinessObjects.Customers)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateCustomers(obj As Silverlight_RiaServices.BusinessObjects.Customers)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteCustomers(obj As Silverlight_RiaServices.BusinessObjects.Customers) 
			Silverlight_RiaServices.BusinessObjects.Customers.Delete(obj.CustomerID)
		End Sub		

#End Region

#Region "Employees"	
	
		Public Function Employees_LoadAll() As EmployeesCollection
			Dim coll As New EmployeesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Employees_LoadByDynamic(serializedQuery As String) As EmployeesCollection
		
			Dim query As EmployeesQuery = _
				TryCast(EmployeesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeesQuery), AllKnownTypes), EmployeesQuery)

			Dim coll As New EmployeesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Employees_GetCount(serializedQuery As String) As Integer

			Dim query As EmployeesQuery = _
				TryCast(EmployeesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeesQuery), AllKnownTypes), EmployeesQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertEmployees(obj As Silverlight_RiaServices.BusinessObjects.Employees)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateEmployees(obj As Silverlight_RiaServices.BusinessObjects.Employees)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteEmployees(obj As Silverlight_RiaServices.BusinessObjects.Employees) 
			Silverlight_RiaServices.BusinessObjects.Employees.Delete(obj.EmployeeID.Value)
		End Sub		

#End Region

#Region "EmployeeTerritories"	
	
		Public Function EmployeeTerritories_LoadAll() As EmployeeTerritoriesCollection
			Dim coll As New EmployeeTerritoriesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function EmployeeTerritories_LoadByDynamic(serializedQuery As String) As EmployeeTerritoriesCollection
		
			Dim query As EmployeeTerritoriesQuery = _
				TryCast(EmployeeTerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeeTerritoriesQuery), AllKnownTypes), EmployeeTerritoriesQuery)

			Dim coll As New EmployeeTerritoriesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function EmployeeTerritories_GetCount(serializedQuery As String) As Integer

			Dim query As EmployeeTerritoriesQuery = _
				TryCast(EmployeeTerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(EmployeeTerritoriesQuery), AllKnownTypes), EmployeeTerritoriesQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertEmployeeTerritories(obj As Silverlight_RiaServices.BusinessObjects.EmployeeTerritories)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateEmployeeTerritories(obj As Silverlight_RiaServices.BusinessObjects.EmployeeTerritories)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteEmployeeTerritories(obj As Silverlight_RiaServices.BusinessObjects.EmployeeTerritories) 
			Silverlight_RiaServices.BusinessObjects.EmployeeTerritories.Delete(obj.EmployeeID.Value, obj.TerritoryID)
		End Sub		

#End Region

#Region "OrderDetails"	
	
		Public Function OrderDetails_LoadAll() As OrderDetailsCollection
			Dim coll As New OrderDetailsCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function OrderDetails_LoadByDynamic(serializedQuery As String) As OrderDetailsCollection
		
			Dim query As OrderDetailsQuery = _
				TryCast(OrderDetailsQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrderDetailsQuery), AllKnownTypes), OrderDetailsQuery)

			Dim coll As New OrderDetailsCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function OrderDetails_GetCount(serializedQuery As String) As Integer

			Dim query As OrderDetailsQuery = _
				TryCast(OrderDetailsQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrderDetailsQuery), AllKnownTypes), OrderDetailsQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertOrderDetails(obj As Silverlight_RiaServices.BusinessObjects.OrderDetails)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateOrderDetails(obj As Silverlight_RiaServices.BusinessObjects.OrderDetails)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteOrderDetails(obj As Silverlight_RiaServices.BusinessObjects.OrderDetails) 
			Silverlight_RiaServices.BusinessObjects.OrderDetails.Delete(obj.OrderID.Value, obj.ProductID.Value)
		End Sub		

#End Region

#Region "Orders"	
	
		Public Function Orders_LoadAll() As OrdersCollection
			Dim coll As New OrdersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Orders_LoadByDynamic(serializedQuery As String) As OrdersCollection
		
			Dim query As OrdersQuery = _
				TryCast(OrdersQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrdersQuery), AllKnownTypes), OrdersQuery)

			Dim coll As New OrdersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Orders_GetCount(serializedQuery As String) As Integer

			Dim query As OrdersQuery = _
				TryCast(OrdersQuery.SerializeHelper.FromXml(serializedQuery, GetType(OrdersQuery), AllKnownTypes), OrdersQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertOrders(obj As Silverlight_RiaServices.BusinessObjects.Orders)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateOrders(obj As Silverlight_RiaServices.BusinessObjects.Orders)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteOrders(obj As Silverlight_RiaServices.BusinessObjects.Orders) 
			Silverlight_RiaServices.BusinessObjects.Orders.Delete(obj.OrderID.Value)
		End Sub		

#End Region

#Region "Products"	
	
		Public Function Products_LoadAll() As ProductsCollection
			Dim coll As New ProductsCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Products_LoadByDynamic(serializedQuery As String) As ProductsCollection
		
			Dim query As ProductsQuery = _
				TryCast(ProductsQuery.SerializeHelper.FromXml(serializedQuery, GetType(ProductsQuery), AllKnownTypes), ProductsQuery)

			Dim coll As New ProductsCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Products_GetCount(serializedQuery As String) As Integer

			Dim query As ProductsQuery = _
				TryCast(ProductsQuery.SerializeHelper.FromXml(serializedQuery, GetType(ProductsQuery), AllKnownTypes), ProductsQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertProducts(obj As Silverlight_RiaServices.BusinessObjects.Products)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateProducts(obj As Silverlight_RiaServices.BusinessObjects.Products)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteProducts(obj As Silverlight_RiaServices.BusinessObjects.Products) 
			Silverlight_RiaServices.BusinessObjects.Products.Delete(obj.ProductID.Value)
		End Sub		

#End Region

#Region "Region"	
	
		Public Function Region_LoadAll() As RegionCollection
			Dim coll As New RegionCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Region_LoadByDynamic(serializedQuery As String) As RegionCollection
		
			Dim query As RegionQuery = _
				TryCast(RegionQuery.SerializeHelper.FromXml(serializedQuery, GetType(RegionQuery), AllKnownTypes), RegionQuery)

			Dim coll As New RegionCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Region_GetCount(serializedQuery As String) As Integer

			Dim query As RegionQuery = _
				TryCast(RegionQuery.SerializeHelper.FromXml(serializedQuery, GetType(RegionQuery), AllKnownTypes), RegionQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertRegion(obj As Silverlight_RiaServices.BusinessObjects.Region)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateRegion(obj As Silverlight_RiaServices.BusinessObjects.Region)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteRegion(obj As Silverlight_RiaServices.BusinessObjects.Region) 
			Silverlight_RiaServices.BusinessObjects.Region.Delete(obj.RegionID.Value)
		End Sub		

#End Region

#Region "Shippers"	
	
		Public Function Shippers_LoadAll() As ShippersCollection
			Dim coll As New ShippersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Shippers_LoadByDynamic(serializedQuery As String) As ShippersCollection
		
			Dim query As ShippersQuery = _
				TryCast(ShippersQuery.SerializeHelper.FromXml(serializedQuery, GetType(ShippersQuery), AllKnownTypes), ShippersQuery)

			Dim coll As New ShippersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Shippers_GetCount(serializedQuery As String) As Integer

			Dim query As ShippersQuery = _
				TryCast(ShippersQuery.SerializeHelper.FromXml(serializedQuery, GetType(ShippersQuery), AllKnownTypes), ShippersQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertShippers(obj As Silverlight_RiaServices.BusinessObjects.Shippers)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateShippers(obj As Silverlight_RiaServices.BusinessObjects.Shippers)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteShippers(obj As Silverlight_RiaServices.BusinessObjects.Shippers) 
			Silverlight_RiaServices.BusinessObjects.Shippers.Delete(obj.ShipperID.Value)
		End Sub		

#End Region

#Region "Suppliers"	
	
		Public Function Suppliers_LoadAll() As SuppliersCollection
			Dim coll As New SuppliersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Suppliers_LoadByDynamic(serializedQuery As String) As SuppliersCollection
		
			Dim query As SuppliersQuery = _
				TryCast(SuppliersQuery.SerializeHelper.FromXml(serializedQuery, GetType(SuppliersQuery), AllKnownTypes), SuppliersQuery)

			Dim coll As New SuppliersCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Suppliers_GetCount(serializedQuery As String) As Integer

			Dim query As SuppliersQuery = _
				TryCast(SuppliersQuery.SerializeHelper.FromXml(serializedQuery, GetType(SuppliersQuery), AllKnownTypes), SuppliersQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertSuppliers(obj As Silverlight_RiaServices.BusinessObjects.Suppliers)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateSuppliers(obj As Silverlight_RiaServices.BusinessObjects.Suppliers)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteSuppliers(obj As Silverlight_RiaServices.BusinessObjects.Suppliers) 
			Silverlight_RiaServices.BusinessObjects.Suppliers.Delete(obj.SupplierID.Value)
		End Sub		

#End Region

#Region "Territories"	
	
		Public Function Territories_LoadAll() As TerritoriesCollection
			Dim coll As New TerritoriesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.LoadAll()
			Return coll
		End Function
        
		<Query(HasSideEffects:=True)> _ 
		Public Function Territories_LoadByDynamic(serializedQuery As String) As TerritoriesCollection
		
			Dim query As TerritoriesQuery = _
				TryCast(TerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(TerritoriesQuery), AllKnownTypes), TerritoriesQuery)

			Dim coll As New TerritoriesCollection()
			coll.es.IsLazyLoadDisabled = True
			coll.Load(query)
			Return coll
			
		End Function
		
		<Invoke(HasSideEffects := True)> _
		Public Function Territories_GetCount(serializedQuery As String) As Integer

			Dim query As TerritoriesQuery = _
				TryCast(TerritoriesQuery.SerializeHelper.FromXml(serializedQuery, GetType(TerritoriesQuery), AllKnownTypes), TerritoriesQuery)

			Return query.ExecuteScalar(Of Integer)()
		End Function
		
		
		<Insert()> _
		Public Sub InsertTerritories(obj As Silverlight_RiaServices.BusinessObjects.Territories)
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added
			obj.Save()
		End Sub	
		
		<Update()> _
		Public Sub UpdateTerritories(obj As Silverlight_RiaServices.BusinessObjects.Territories)
			obj.AcceptChanges()
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified)
			obj.Save()
		End Sub
		
		<Delete()> _
		Public Sub DeleteTerritories(obj As Silverlight_RiaServices.BusinessObjects.Territories) 
			Silverlight_RiaServices.BusinessObjects.Territories.Delete(obj.TerritoryID)
		End Sub		

#End Region
	
#Region "EntitySpaces Support Routines"

		Public Overrides Function Submit(changeSet As ChangeSet) As Boolean
			Try
				Using scope As New esTransactionScope()
					Dim success As Boolean = MyBase.Submit(changeSet)

					If success Then
						scope.Complete()
					End If

					Return success
				End Using
			Catch ex As Exception
				If Not HandleError(ex) Then
					Throw
				End If

				Return True
			End Try
		End Function
		
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
End Namespace