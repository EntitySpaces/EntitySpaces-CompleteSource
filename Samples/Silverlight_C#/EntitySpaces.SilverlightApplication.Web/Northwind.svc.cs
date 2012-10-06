/*
===============================================================================
                    EntitySpaces 2010 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:15 PM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Text.RegularExpressions;

using BusinessObjects;

using EntitySpaces.Interfaces;

namespace EntitySpaces.SilverlightApplication.Web
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public partial class Northwind : INorthwind
	{
		
		#region ICategories Members
		
		public CategoriesCollectionProxyStub Categories_LoadAll()
		{
			CategoriesCollection coll = new CategoriesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CategoriesCollectionProxyStub Categories_QueryForCollection(string serializedQuery)
		{
			CategoriesQuery query = CategoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CategoriesQuery), AllKnownTypes) as CategoriesQuery;

			CategoriesCollection coll = new CategoriesCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public CategoriesProxyStub Categories_QueryForEntity(string serializedQuery)
		{
			CategoriesQuery query = CategoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CategoriesQuery), AllKnownTypes) as CategoriesQuery;

			Categories obj = new Categories();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public CategoriesProxyStub Categories_GetByPrimaryKey(System.Int32 categoryID)
		{
			Categories obj = new Categories();
			if (obj.LoadByPrimaryKey(categoryID))
			{
				return obj;
			}
			return null;
		}

		public CategoriesCollectionProxyStub Categories_SaveCollection(CategoriesCollectionProxyStub collection)
		{
			if (collection != null)
			{
				CategoriesCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public CategoriesProxyStub Categories_SaveEntity(CategoriesProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ICustomerCustomerDemo Members
		
		public CustomerCustomerDemoCollectionProxyStub CustomerCustomerDemo_LoadAll()
		{
			CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CustomerCustomerDemoCollectionProxyStub CustomerCustomerDemo_QueryForCollection(string serializedQuery)
		{
			CustomerCustomerDemoQuery query = CustomerCustomerDemoQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerCustomerDemoQuery), AllKnownTypes) as CustomerCustomerDemoQuery;

			CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public CustomerCustomerDemoProxyStub CustomerCustomerDemo_QueryForEntity(string serializedQuery)
		{
			CustomerCustomerDemoQuery query = CustomerCustomerDemoQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerCustomerDemoQuery), AllKnownTypes) as CustomerCustomerDemoQuery;

			CustomerCustomerDemo obj = new CustomerCustomerDemo();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public CustomerCustomerDemoProxyStub CustomerCustomerDemo_GetByPrimaryKey(System.String customerID, System.String customerTypeID)
		{
			CustomerCustomerDemo obj = new CustomerCustomerDemo();
			if (obj.LoadByPrimaryKey(customerID, customerTypeID))
			{
				return obj;
			}
			return null;
		}

		public CustomerCustomerDemoCollectionProxyStub CustomerCustomerDemo_SaveCollection(CustomerCustomerDemoCollectionProxyStub collection)
		{
			if (collection != null)
			{
				CustomerCustomerDemoCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public CustomerCustomerDemoProxyStub CustomerCustomerDemo_SaveEntity(CustomerCustomerDemoProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ICustomerDemographics Members
		
		public CustomerDemographicsCollectionProxyStub CustomerDemographics_LoadAll()
		{
			CustomerDemographicsCollection coll = new CustomerDemographicsCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CustomerDemographicsCollectionProxyStub CustomerDemographics_QueryForCollection(string serializedQuery)
		{
			CustomerDemographicsQuery query = CustomerDemographicsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerDemographicsQuery), AllKnownTypes) as CustomerDemographicsQuery;

			CustomerDemographicsCollection coll = new CustomerDemographicsCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public CustomerDemographicsProxyStub CustomerDemographics_QueryForEntity(string serializedQuery)
		{
			CustomerDemographicsQuery query = CustomerDemographicsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomerDemographicsQuery), AllKnownTypes) as CustomerDemographicsQuery;

			CustomerDemographics obj = new CustomerDemographics();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public CustomerDemographicsProxyStub CustomerDemographics_GetByPrimaryKey(System.String customerTypeID)
		{
			CustomerDemographics obj = new CustomerDemographics();
			if (obj.LoadByPrimaryKey(customerTypeID))
			{
				return obj;
			}
			return null;
		}

		public CustomerDemographicsCollectionProxyStub CustomerDemographics_SaveCollection(CustomerDemographicsCollectionProxyStub collection)
		{
			if (collection != null)
			{
				CustomerDemographicsCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public CustomerDemographicsProxyStub CustomerDemographics_SaveEntity(CustomerDemographicsProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ICustomers Members
		
		public CustomersCollectionProxyStub Customers_LoadAll()
		{
			CustomersCollection coll = new CustomersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CustomersCollectionProxyStub Customers_QueryForCollection(string serializedQuery)
		{
			CustomersQuery query = CustomersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomersQuery), AllKnownTypes) as CustomersQuery;

			CustomersCollection coll = new CustomersCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public CustomersProxyStub Customers_QueryForEntity(string serializedQuery)
		{
			CustomersQuery query = CustomersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(CustomersQuery), AllKnownTypes) as CustomersQuery;

			Customers obj = new Customers();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public CustomersProxyStub Customers_GetByPrimaryKey(System.String customerID)
		{
			Customers obj = new Customers();
			if (obj.LoadByPrimaryKey(customerID))
			{
				return obj;
			}
			return null;
		}

		public CustomersCollectionProxyStub Customers_SaveCollection(CustomersCollectionProxyStub collection)
		{
			if (collection != null)
			{
				CustomersCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public CustomersProxyStub Customers_SaveEntity(CustomersProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IEmployees Members
		
		public EmployeesCollectionProxyStub Employees_LoadAll()
		{
			EmployeesCollection coll = new EmployeesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public EmployeesCollectionProxyStub Employees_QueryForCollection(string serializedQuery)
		{
			EmployeesQuery query = EmployeesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeesQuery), AllKnownTypes) as EmployeesQuery;

			EmployeesCollection coll = new EmployeesCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public EmployeesProxyStub Employees_QueryForEntity(string serializedQuery)
		{
			EmployeesQuery query = EmployeesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeesQuery), AllKnownTypes) as EmployeesQuery;

			Employees obj = new Employees();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public EmployeesProxyStub Employees_GetByPrimaryKey(System.Int32 employeeID)
		{
			Employees obj = new Employees();
			if (obj.LoadByPrimaryKey(employeeID))
			{
				return obj;
			}
			return null;
		}

		public EmployeesCollectionProxyStub Employees_SaveCollection(EmployeesCollectionProxyStub collection)
		{
			if (collection != null)
			{
				EmployeesCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public EmployeesProxyStub Employees_SaveEntity(EmployeesProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IEmployeeTerritories Members
		
		public EmployeeTerritoriesCollectionProxyStub EmployeeTerritories_LoadAll()
		{
			EmployeeTerritoriesCollection coll = new EmployeeTerritoriesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public EmployeeTerritoriesCollectionProxyStub EmployeeTerritories_QueryForCollection(string serializedQuery)
		{
			EmployeeTerritoriesQuery query = EmployeeTerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeeTerritoriesQuery), AllKnownTypes) as EmployeeTerritoriesQuery;

			EmployeeTerritoriesCollection coll = new EmployeeTerritoriesCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public EmployeeTerritoriesProxyStub EmployeeTerritories_QueryForEntity(string serializedQuery)
		{
			EmployeeTerritoriesQuery query = EmployeeTerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(EmployeeTerritoriesQuery), AllKnownTypes) as EmployeeTerritoriesQuery;

			EmployeeTerritories obj = new EmployeeTerritories();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public EmployeeTerritoriesProxyStub EmployeeTerritories_GetByPrimaryKey(System.Int32 employeeID, System.String territoryID)
		{
			EmployeeTerritories obj = new EmployeeTerritories();
			if (obj.LoadByPrimaryKey(employeeID, territoryID))
			{
				return obj;
			}
			return null;
		}

		public EmployeeTerritoriesCollectionProxyStub EmployeeTerritories_SaveCollection(EmployeeTerritoriesCollectionProxyStub collection)
		{
			if (collection != null)
			{
				EmployeeTerritoriesCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public EmployeeTerritoriesProxyStub EmployeeTerritories_SaveEntity(EmployeeTerritoriesProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IOrderDetails Members
		
		public OrderDetailsCollectionProxyStub OrderDetails_LoadAll()
		{
			OrderDetailsCollection coll = new OrderDetailsCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public OrderDetailsCollectionProxyStub OrderDetails_QueryForCollection(string serializedQuery)
		{
			OrderDetailsQuery query = OrderDetailsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrderDetailsQuery), AllKnownTypes) as OrderDetailsQuery;

			OrderDetailsCollection coll = new OrderDetailsCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public OrderDetailsProxyStub OrderDetails_QueryForEntity(string serializedQuery)
		{
			OrderDetailsQuery query = OrderDetailsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrderDetailsQuery), AllKnownTypes) as OrderDetailsQuery;

			OrderDetails obj = new OrderDetails();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public OrderDetailsProxyStub OrderDetails_GetByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			OrderDetails obj = new OrderDetails();
			if (obj.LoadByPrimaryKey(orderID, productID))
			{
				return obj;
			}
			return null;
		}

		public OrderDetailsCollectionProxyStub OrderDetails_SaveCollection(OrderDetailsCollectionProxyStub collection)
		{
			if (collection != null)
			{
				OrderDetailsCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public OrderDetailsProxyStub OrderDetails_SaveEntity(OrderDetailsProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IOrders Members
		
		public OrdersCollectionProxyStub Orders_LoadAll()
		{
			OrdersCollection coll = new OrdersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public OrdersCollectionProxyStub Orders_QueryForCollection(string serializedQuery)
		{
			OrdersQuery query = OrdersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrdersQuery), AllKnownTypes) as OrdersQuery;

			OrdersCollection coll = new OrdersCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public OrdersProxyStub Orders_QueryForEntity(string serializedQuery)
		{
			OrdersQuery query = OrdersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(OrdersQuery), AllKnownTypes) as OrdersQuery;

			Orders obj = new Orders();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public OrdersProxyStub Orders_GetByPrimaryKey(System.Int32 orderID)
		{
			Orders obj = new Orders();
			if (obj.LoadByPrimaryKey(orderID))
			{
				return obj;
			}
			return null;
		}

		public OrdersCollectionProxyStub Orders_SaveCollection(OrdersCollectionProxyStub collection)
		{
			if (collection != null)
			{
				OrdersCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public OrdersProxyStub Orders_SaveEntity(OrdersProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IProducts Members
		
		public ProductsCollectionProxyStub Products_LoadAll()
		{
			ProductsCollection coll = new ProductsCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public ProductsCollectionProxyStub Products_QueryForCollection(string serializedQuery)
		{
			ProductsQuery query = ProductsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ProductsQuery), AllKnownTypes) as ProductsQuery;

			ProductsCollection coll = new ProductsCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public ProductsProxyStub Products_QueryForEntity(string serializedQuery)
		{
			ProductsQuery query = ProductsQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ProductsQuery), AllKnownTypes) as ProductsQuery;

			Products obj = new Products();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public ProductsProxyStub Products_GetByPrimaryKey(System.Int32 productID)
		{
			Products obj = new Products();
			if (obj.LoadByPrimaryKey(productID))
			{
				return obj;
			}
			return null;
		}

		public ProductsCollectionProxyStub Products_SaveCollection(ProductsCollectionProxyStub collection)
		{
			if (collection != null)
			{
				ProductsCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public ProductsProxyStub Products_SaveEntity(ProductsProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IRegion Members
		
		public RegionCollectionProxyStub Region_LoadAll()
		{
			RegionCollection coll = new RegionCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public RegionCollectionProxyStub Region_QueryForCollection(string serializedQuery)
		{
			RegionQuery query = RegionQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(RegionQuery), AllKnownTypes) as RegionQuery;

			RegionCollection coll = new RegionCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public RegionProxyStub Region_QueryForEntity(string serializedQuery)
		{
			RegionQuery query = RegionQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(RegionQuery), AllKnownTypes) as RegionQuery;

			Region obj = new Region();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public RegionProxyStub Region_GetByPrimaryKey(System.Int32 regionID)
		{
			Region obj = new Region();
			if (obj.LoadByPrimaryKey(regionID))
			{
				return obj;
			}
			return null;
		}

		public RegionCollectionProxyStub Region_SaveCollection(RegionCollectionProxyStub collection)
		{
			if (collection != null)
			{
				RegionCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public RegionProxyStub Region_SaveEntity(RegionProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IShippers Members
		
		public ShippersCollectionProxyStub Shippers_LoadAll()
		{
			ShippersCollection coll = new ShippersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public ShippersCollectionProxyStub Shippers_QueryForCollection(string serializedQuery)
		{
			ShippersQuery query = ShippersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ShippersQuery), AllKnownTypes) as ShippersQuery;

			ShippersCollection coll = new ShippersCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public ShippersProxyStub Shippers_QueryForEntity(string serializedQuery)
		{
			ShippersQuery query = ShippersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(ShippersQuery), AllKnownTypes) as ShippersQuery;

			Shippers obj = new Shippers();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public ShippersProxyStub Shippers_GetByPrimaryKey(System.Int32 shipperID)
		{
			Shippers obj = new Shippers();
			if (obj.LoadByPrimaryKey(shipperID))
			{
				return obj;
			}
			return null;
		}

		public ShippersCollectionProxyStub Shippers_SaveCollection(ShippersCollectionProxyStub collection)
		{
			if (collection != null)
			{
				ShippersCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public ShippersProxyStub Shippers_SaveEntity(ShippersProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ISuppliers Members
		
		public SuppliersCollectionProxyStub Suppliers_LoadAll()
		{
			SuppliersCollection coll = new SuppliersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public SuppliersCollectionProxyStub Suppliers_QueryForCollection(string serializedQuery)
		{
			SuppliersQuery query = SuppliersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(SuppliersQuery), AllKnownTypes) as SuppliersQuery;

			SuppliersCollection coll = new SuppliersCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public SuppliersProxyStub Suppliers_QueryForEntity(string serializedQuery)
		{
			SuppliersQuery query = SuppliersQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(SuppliersQuery), AllKnownTypes) as SuppliersQuery;

			Suppliers obj = new Suppliers();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public SuppliersProxyStub Suppliers_GetByPrimaryKey(System.Int32 supplierID)
		{
			Suppliers obj = new Suppliers();
			if (obj.LoadByPrimaryKey(supplierID))
			{
				return obj;
			}
			return null;
		}

		public SuppliersCollectionProxyStub Suppliers_SaveCollection(SuppliersCollectionProxyStub collection)
		{
			if (collection != null)
			{
				SuppliersCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public SuppliersProxyStub Suppliers_SaveEntity(SuppliersProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ITerritories Members
		
		public TerritoriesCollectionProxyStub Territories_LoadAll()
		{
			TerritoriesCollection coll = new TerritoriesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public TerritoriesCollectionProxyStub Territories_QueryForCollection(string serializedQuery)
		{
			TerritoriesQuery query = TerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(TerritoriesQuery), AllKnownTypes) as TerritoriesQuery;

			TerritoriesCollection coll = new TerritoriesCollection();
			if (coll.Load(query))
			{
				return coll;
			}

			return null;
		}

		public TerritoriesProxyStub Territories_QueryForEntity(string serializedQuery)
		{
			TerritoriesQuery query = TerritoriesQuery.SerializeHelper.FromXml(
				serializedQuery, typeof(TerritoriesQuery), AllKnownTypes) as TerritoriesQuery;

			Territories obj = new Territories();
			if (obj.Load(query))
			{
				return obj;
			}

			return null;
		}
		
		public TerritoriesProxyStub Territories_GetByPrimaryKey(System.String territoryID)
		{
			Territories obj = new Territories();
			if (obj.LoadByPrimaryKey(territoryID))
			{
				return obj;
			}
			return null;
		}

		public TerritoriesCollectionProxyStub Territories_SaveCollection(TerritoriesCollectionProxyStub collection)
		{
			if (collection != null)
			{
				TerritoriesCollection c = collection.GetCollection();
				c.Save();
				return c;
			}

			return null;
		}

		public TerritoriesProxyStub Territories_SaveEntity(TerritoriesProxyStub entity)
		{
			if (entity != null)
			{
				entity.Entity.Save();

				if (entity.Entity.RowState != esDataRowState.Deleted && entity.Entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion

		#region EntitySpaces Support Routines
		
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
