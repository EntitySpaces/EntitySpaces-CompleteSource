/*===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:18 PM
===============================================================================
*/

namespace Silverlight_RiaServices.Web
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.ServiceModel.DomainServices.Hosting;
	using System.ServiceModel.DomainServices.Server;
	using System.Text.RegularExpressions;

	using EntitySpaces.Core;
	using EntitySpaces.Interfaces;
	using EntitySpaces.DynamicQuery;
	using BusinessObjects;
	
	[EnableClientAccess()]
	public partial class esDomainService : DomainService
	{
		#region Categories
		public CategoriesCollection Categories_LoadAll()
		{
			CategoriesCollection coll = new CategoriesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public CategoriesCollection Categories_LoadByDynamic(string serializedQuery)
		{
			CategoriesQuery query = CategoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CategoriesQuery), AllKnownTypes) as CategoriesQuery;

			CategoriesCollection coll = new CategoriesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Categories_GetCount(string serializedQuery)
		{
			CategoriesQuery query = CategoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CategoriesQuery), AllKnownTypes) as CategoriesQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertCategories(BusinessObjects.Categories obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateCategories(BusinessObjects.Categories obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteCategories(BusinessObjects.Categories obj) 
		{
			BusinessObjects.Categories.Delete(obj.CategoryID.Value);
		}
		#endregion

		#region CustomerCustomerDemo
		public CustomerCustomerDemoCollection CustomerCustomerDemo_LoadAll()
		{
			CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public CustomerCustomerDemoCollection CustomerCustomerDemo_LoadByDynamic(string serializedQuery)
		{
			CustomerCustomerDemoQuery query = CustomerCustomerDemoQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerCustomerDemoQuery), AllKnownTypes) as CustomerCustomerDemoQuery;

			CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int CustomerCustomerDemo_GetCount(string serializedQuery)
		{
			CustomerCustomerDemoQuery query = CustomerCustomerDemoQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerCustomerDemoQuery), AllKnownTypes) as CustomerCustomerDemoQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertCustomerCustomerDemo(BusinessObjects.CustomerCustomerDemo obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateCustomerCustomerDemo(BusinessObjects.CustomerCustomerDemo obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteCustomerCustomerDemo(BusinessObjects.CustomerCustomerDemo obj) 
		{
			BusinessObjects.CustomerCustomerDemo.Delete(obj.CustomerID, obj.CustomerTypeID);
		}
		#endregion

		#region CustomerDemographics
		public CustomerDemographicsCollection CustomerDemographics_LoadAll()
		{
			CustomerDemographicsCollection coll = new CustomerDemographicsCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public CustomerDemographicsCollection CustomerDemographics_LoadByDynamic(string serializedQuery)
		{
			CustomerDemographicsQuery query = CustomerDemographicsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerDemographicsQuery), AllKnownTypes) as CustomerDemographicsQuery;

			CustomerDemographicsCollection coll = new CustomerDemographicsCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int CustomerDemographics_GetCount(string serializedQuery)
		{
			CustomerDemographicsQuery query = CustomerDemographicsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerDemographicsQuery), AllKnownTypes) as CustomerDemographicsQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertCustomerDemographics(BusinessObjects.CustomerDemographics obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateCustomerDemographics(BusinessObjects.CustomerDemographics obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteCustomerDemographics(BusinessObjects.CustomerDemographics obj) 
		{
			BusinessObjects.CustomerDemographics.Delete(obj.CustomerTypeID);
		}
		#endregion

		#region Customers
		public CustomersCollection Customers_LoadAll()
		{
			CustomersCollection coll = new CustomersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public CustomersCollection Customers_LoadByDynamic(string serializedQuery)
		{
			CustomersQuery query = CustomersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomersQuery), AllKnownTypes) as CustomersQuery;

			CustomersCollection coll = new CustomersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Customers_GetCount(string serializedQuery)
		{
			CustomersQuery query = CustomersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomersQuery), AllKnownTypes) as CustomersQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertCustomers(BusinessObjects.Customers obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateCustomers(BusinessObjects.Customers obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteCustomers(BusinessObjects.Customers obj) 
		{
			BusinessObjects.Customers.Delete(obj.CustomerID);
		}
		#endregion

		#region Employees
		public EmployeesCollection Employees_LoadAll()
		{
			EmployeesCollection coll = new EmployeesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public EmployeesCollection Employees_LoadByDynamic(string serializedQuery)
		{
			EmployeesQuery query = EmployeesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeesQuery), AllKnownTypes) as EmployeesQuery;

			EmployeesCollection coll = new EmployeesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Employees_GetCount(string serializedQuery)
		{
			EmployeesQuery query = EmployeesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeesQuery), AllKnownTypes) as EmployeesQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertEmployees(BusinessObjects.Employees obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateEmployees(BusinessObjects.Employees obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteEmployees(BusinessObjects.Employees obj) 
		{
			BusinessObjects.Employees.Delete(obj.EmployeeID.Value);
		}
		#endregion

		#region EmployeeTerritories
		public EmployeeTerritoriesCollection EmployeeTerritories_LoadAll()
		{
			EmployeeTerritoriesCollection coll = new EmployeeTerritoriesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public EmployeeTerritoriesCollection EmployeeTerritories_LoadByDynamic(string serializedQuery)
		{
			EmployeeTerritoriesQuery query = EmployeeTerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeeTerritoriesQuery), AllKnownTypes) as EmployeeTerritoriesQuery;

			EmployeeTerritoriesCollection coll = new EmployeeTerritoriesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int EmployeeTerritories_GetCount(string serializedQuery)
		{
			EmployeeTerritoriesQuery query = EmployeeTerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeeTerritoriesQuery), AllKnownTypes) as EmployeeTerritoriesQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertEmployeeTerritories(BusinessObjects.EmployeeTerritories obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateEmployeeTerritories(BusinessObjects.EmployeeTerritories obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteEmployeeTerritories(BusinessObjects.EmployeeTerritories obj) 
		{
			BusinessObjects.EmployeeTerritories.Delete(obj.EmployeeID.Value, obj.TerritoryID);
		}
		#endregion

		#region OrderDetails
		public OrderDetailsCollection OrderDetails_LoadAll()
		{
			OrderDetailsCollection coll = new OrderDetailsCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public OrderDetailsCollection OrderDetails_LoadByDynamic(string serializedQuery)
		{
			OrderDetailsQuery query = OrderDetailsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrderDetailsQuery), AllKnownTypes) as OrderDetailsQuery;

			OrderDetailsCollection coll = new OrderDetailsCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int OrderDetails_GetCount(string serializedQuery)
		{
			OrderDetailsQuery query = OrderDetailsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrderDetailsQuery), AllKnownTypes) as OrderDetailsQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertOrderDetails(BusinessObjects.OrderDetails obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateOrderDetails(BusinessObjects.OrderDetails obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteOrderDetails(BusinessObjects.OrderDetails obj) 
		{
			BusinessObjects.OrderDetails.Delete(obj.OrderID.Value, obj.ProductID.Value);
		}
		#endregion

		#region Orders
		public OrdersCollection Orders_LoadAll()
		{
			OrdersCollection coll = new OrdersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public OrdersCollection Orders_LoadByDynamic(string serializedQuery)
		{
			OrdersQuery query = OrdersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrdersQuery), AllKnownTypes) as OrdersQuery;

			OrdersCollection coll = new OrdersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Orders_GetCount(string serializedQuery)
		{
			OrdersQuery query = OrdersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrdersQuery), AllKnownTypes) as OrdersQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertOrders(BusinessObjects.Orders obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateOrders(BusinessObjects.Orders obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteOrders(BusinessObjects.Orders obj) 
		{
			BusinessObjects.Orders.Delete(obj.OrderID.Value);
		}
		#endregion

		#region Products
		public ProductsCollection Products_LoadAll()
		{
			ProductsCollection coll = new ProductsCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public ProductsCollection Products_LoadByDynamic(string serializedQuery)
		{
			ProductsQuery query = ProductsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ProductsQuery), AllKnownTypes) as ProductsQuery;

			ProductsCollection coll = new ProductsCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Products_GetCount(string serializedQuery)
		{
			ProductsQuery query = ProductsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ProductsQuery), AllKnownTypes) as ProductsQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertProducts(BusinessObjects.Products obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateProducts(BusinessObjects.Products obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteProducts(BusinessObjects.Products obj) 
		{
			BusinessObjects.Products.Delete(obj.ProductID.Value);
		}
		#endregion

		#region Region
		public RegionCollection Region_LoadAll()
		{
			RegionCollection coll = new RegionCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public RegionCollection Region_LoadByDynamic(string serializedQuery)
		{
			RegionQuery query = RegionQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(RegionQuery), AllKnownTypes) as RegionQuery;

			RegionCollection coll = new RegionCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Region_GetCount(string serializedQuery)
		{
			RegionQuery query = RegionQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(RegionQuery), AllKnownTypes) as RegionQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertRegion(BusinessObjects.Region obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateRegion(BusinessObjects.Region obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteRegion(BusinessObjects.Region obj) 
		{
			BusinessObjects.Region.Delete(obj.RegionID.Value);
		}
		#endregion

		#region Shippers
		public ShippersCollection Shippers_LoadAll()
		{
			ShippersCollection coll = new ShippersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public ShippersCollection Shippers_LoadByDynamic(string serializedQuery)
		{
			ShippersQuery query = ShippersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ShippersQuery), AllKnownTypes) as ShippersQuery;

			ShippersCollection coll = new ShippersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Shippers_GetCount(string serializedQuery)
		{
			ShippersQuery query = ShippersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ShippersQuery), AllKnownTypes) as ShippersQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertShippers(BusinessObjects.Shippers obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateShippers(BusinessObjects.Shippers obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteShippers(BusinessObjects.Shippers obj) 
		{
			BusinessObjects.Shippers.Delete(obj.ShipperID.Value);
		}
		#endregion

		#region Suppliers
		public SuppliersCollection Suppliers_LoadAll()
		{
			SuppliersCollection coll = new SuppliersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public SuppliersCollection Suppliers_LoadByDynamic(string serializedQuery)
		{
			SuppliersQuery query = SuppliersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(SuppliersQuery), AllKnownTypes) as SuppliersQuery;

			SuppliersCollection coll = new SuppliersCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Suppliers_GetCount(string serializedQuery)
		{
			SuppliersQuery query = SuppliersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(SuppliersQuery), AllKnownTypes) as SuppliersQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertSuppliers(BusinessObjects.Suppliers obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateSuppliers(BusinessObjects.Suppliers obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteSuppliers(BusinessObjects.Suppliers obj) 
		{
			BusinessObjects.Suppliers.Delete(obj.SupplierID.Value);
		}
		#endregion

		#region Territories
		public TerritoriesCollection Territories_LoadAll()
		{
			TerritoriesCollection coll = new TerritoriesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.LoadAll();
			return coll;
		}
		
		[Query(HasSideEffects = true)] 
		public TerritoriesCollection Territories_LoadByDynamic(string serializedQuery)
		{
			TerritoriesQuery query = TerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(TerritoriesQuery), AllKnownTypes) as TerritoriesQuery;

			TerritoriesCollection coll = new TerritoriesCollection();
			coll.es.IsLazyLoadDisabled = true;
			coll.Load(query);
			return coll;
		}
		
		[Invoke(HasSideEffects = true)]
		public int Territories_GetCount(string serializedQuery)
		{
			TerritoriesQuery query = TerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(TerritoriesQuery), AllKnownTypes) as TerritoriesQuery;

			return query.ExecuteScalar<int>();
		}
		
        [Insert]
		public void InsertTerritories(BusinessObjects.Territories obj)
		{
			obj.RowState = EntitySpaces.Interfaces.esDataRowState.Added;
            obj.Save();
		}
		
        [Update]
		public void UpdateTerritories(BusinessObjects.Territories obj) 
		{
			obj.AcceptChanges();
			obj.MarkAllColumnsAsDirty(EntitySpaces.Interfaces.esDataRowState.Modified);
			obj.Save();
		}
		
        [Delete]
		public void DeleteTerritories(BusinessObjects.Territories obj) 
		{
			BusinessObjects.Territories.Delete(obj.TerritoryID);
		}
		#endregion
	
		#region EntitySpaces Support Routines
		
		/// <summary>
		/// Used to Save the data to the database
		/// </summary>
		/// <returns>True if Successful</returns>
        public override bool Submit(ChangeSet changeSet)
        {
            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    bool success= base.Submit(changeSet);

                    if (success)
                    {
                        scope.Complete();
                    }

                    return success;
                }
            }
            catch (Exception ex)
            {
                if (!HandleError(ex))
                {
                    throw;
                }

                return true;
            }
        }
		
		static private List<Type> AllKnownTypes = GetAllKnownTypes();

		static List<Type> GetAllKnownTypes()
		{
			List<Type> types = new List<Type>();
					
			types.Add(typeof(CategoriesQuery));		
			types.Add(typeof(CustomerCustomerDemoQuery));		
			types.Add(typeof(CustomerDemographicsQuery));		
			types.Add(typeof(CustomersQuery));		
			types.Add(typeof(EmployeesQuery));		
			types.Add(typeof(EmployeeTerritoriesQuery));		
			types.Add(typeof(OrderDetailsQuery));		
			types.Add(typeof(OrdersQuery));		
			types.Add(typeof(ProductsQuery));		
			types.Add(typeof(RegionQuery));		
			types.Add(typeof(ShippersQuery));		
			types.Add(typeof(SuppliersQuery));		
			types.Add(typeof(TerritoriesQuery));

			return types;
		}
		
		#endregion
	}
}