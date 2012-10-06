/*
===============================================================================
                    EntitySpaces 2010 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.0.0331.0
EntitySpaces Driver  : SQL
Date Generated       : 4/16/2011 9:03:02 PM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Text.RegularExpressions;

using BusinessObjects;

using EntitySpaces.Interfaces;

namespace WCFService
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public partial class NonProxyService : INonProxyService
	{
		
		#region ICategories Members
		
		public CategoriesCollection.CategoriesCollectionWCFPacket Categories_LoadAll()
		{
			CategoriesCollection coll = new CategoriesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CategoriesCollection.CategoriesCollectionWCFPacket Categories_QueryForCollection(string serializedQuery)
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

		public Categories Categories_QueryForEntity(string serializedQuery)
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
		
		public Categories Categories_GetByPrimaryKey(System.Int32 categoryID)
		{
			Categories obj = new Categories();
			if (obj.LoadByPrimaryKey(categoryID))
			{
				return obj;
			}
			return null;
		}

		public CategoriesCollection.CategoriesCollectionWCFPacket Categories_SaveCollection(CategoriesCollection.CategoriesCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Categories Categories_SaveEntity(Categories entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ICustomerCustomerDemo Members
		
		public CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket CustomerCustomerDemo_LoadAll()
		{
			CustomerCustomerDemoCollection coll = new CustomerCustomerDemoCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket CustomerCustomerDemo_QueryForCollection(string serializedQuery)
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

		public CustomerCustomerDemo CustomerCustomerDemo_QueryForEntity(string serializedQuery)
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
		
		public CustomerCustomerDemo CustomerCustomerDemo_GetByPrimaryKey(System.String customerID, System.String customerTypeID)
		{
			CustomerCustomerDemo obj = new CustomerCustomerDemo();
			if (obj.LoadByPrimaryKey(customerID, customerTypeID))
			{
				return obj;
			}
			return null;
		}

		public CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket CustomerCustomerDemo_SaveCollection(CustomerCustomerDemoCollection.CustomerCustomerDemoCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public CustomerCustomerDemo CustomerCustomerDemo_SaveEntity(CustomerCustomerDemo entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ICustomerDemographics Members
		
		public CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket CustomerDemographics_LoadAll()
		{
			CustomerDemographicsCollection coll = new CustomerDemographicsCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket CustomerDemographics_QueryForCollection(string serializedQuery)
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

		public CustomerDemographics CustomerDemographics_QueryForEntity(string serializedQuery)
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
		
		public CustomerDemographics CustomerDemographics_GetByPrimaryKey(System.String customerTypeID)
		{
			CustomerDemographics obj = new CustomerDemographics();
			if (obj.LoadByPrimaryKey(customerTypeID))
			{
				return obj;
			}
			return null;
		}

		public CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket CustomerDemographics_SaveCollection(CustomerDemographicsCollection.CustomerDemographicsCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public CustomerDemographics CustomerDemographics_SaveEntity(CustomerDemographics entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ICustomers Members
		
		public CustomersCollection.CustomersCollectionWCFPacket Customers_LoadAll()
		{
			CustomersCollection coll = new CustomersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public CustomersCollection.CustomersCollectionWCFPacket Customers_QueryForCollection(string serializedQuery)
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

		public Customers Customers_QueryForEntity(string serializedQuery)
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
		
		public Customers Customers_GetByPrimaryKey(System.String customerID)
		{
			Customers obj = new Customers();
			if (obj.LoadByPrimaryKey(customerID))
			{
				return obj;
			}
			return null;
		}

		public CustomersCollection.CustomersCollectionWCFPacket Customers_SaveCollection(CustomersCollection.CustomersCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Customers Customers_SaveEntity(Customers entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IEmployees Members
		
		public EmployeesCollection.EmployeesCollectionWCFPacket Employees_LoadAll()
		{
			EmployeesCollection coll = new EmployeesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public EmployeesCollection.EmployeesCollectionWCFPacket Employees_QueryForCollection(string serializedQuery)
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

		public Employees Employees_QueryForEntity(string serializedQuery)
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
		
		public Employees Employees_GetByPrimaryKey(System.Int32 employeeID)
		{
			Employees obj = new Employees();
			if (obj.LoadByPrimaryKey(employeeID))
			{
				return obj;
			}
			return null;
		}

		public EmployeesCollection.EmployeesCollectionWCFPacket Employees_SaveCollection(EmployeesCollection.EmployeesCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Employees Employees_SaveEntity(Employees entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IEmployeeTerritories Members
		
		public EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket EmployeeTerritories_LoadAll()
		{
			EmployeeTerritoriesCollection coll = new EmployeeTerritoriesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket EmployeeTerritories_QueryForCollection(string serializedQuery)
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

		public EmployeeTerritories EmployeeTerritories_QueryForEntity(string serializedQuery)
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
		
		public EmployeeTerritories EmployeeTerritories_GetByPrimaryKey(System.Int32 employeeID, System.String territoryID)
		{
			EmployeeTerritories obj = new EmployeeTerritories();
			if (obj.LoadByPrimaryKey(employeeID, territoryID))
			{
				return obj;
			}
			return null;
		}

		public EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket EmployeeTerritories_SaveCollection(EmployeeTerritoriesCollection.EmployeeTerritoriesCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public EmployeeTerritories EmployeeTerritories_SaveEntity(EmployeeTerritories entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IOrderDetails Members
		
		public OrderDetailsCollection.OrderDetailsCollectionWCFPacket OrderDetails_LoadAll()
		{
			OrderDetailsCollection coll = new OrderDetailsCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public OrderDetailsCollection.OrderDetailsCollectionWCFPacket OrderDetails_QueryForCollection(string serializedQuery)
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

		public OrderDetails OrderDetails_QueryForEntity(string serializedQuery)
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
		
		public OrderDetails OrderDetails_GetByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			OrderDetails obj = new OrderDetails();
			if (obj.LoadByPrimaryKey(orderID, productID))
			{
				return obj;
			}
			return null;
		}

		public OrderDetailsCollection.OrderDetailsCollectionWCFPacket OrderDetails_SaveCollection(OrderDetailsCollection.OrderDetailsCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public OrderDetails OrderDetails_SaveEntity(OrderDetails entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IOrders Members
		
		public OrdersCollection.OrdersCollectionWCFPacket Orders_LoadAll()
		{
			OrdersCollection coll = new OrdersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public OrdersCollection.OrdersCollectionWCFPacket Orders_QueryForCollection(string serializedQuery)
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

		public Orders Orders_QueryForEntity(string serializedQuery)
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
		
		public Orders Orders_GetByPrimaryKey(System.Int32 orderID)
		{
			Orders obj = new Orders();
			if (obj.LoadByPrimaryKey(orderID))
			{
				return obj;
			}
			return null;
		}

		public OrdersCollection.OrdersCollectionWCFPacket Orders_SaveCollection(OrdersCollection.OrdersCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Orders Orders_SaveEntity(Orders entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IProducts Members
		
		public ProductsCollection.ProductsCollectionWCFPacket Products_LoadAll()
		{
			ProductsCollection coll = new ProductsCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public ProductsCollection.ProductsCollectionWCFPacket Products_QueryForCollection(string serializedQuery)
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

		public Products Products_QueryForEntity(string serializedQuery)
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
		
		public Products Products_GetByPrimaryKey(System.Int32 productID)
		{
			Products obj = new Products();
			if (obj.LoadByPrimaryKey(productID))
			{
				return obj;
			}
			return null;
		}

		public ProductsCollection.ProductsCollectionWCFPacket Products_SaveCollection(ProductsCollection.ProductsCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Products Products_SaveEntity(Products entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IRegion Members
		
		public RegionCollection.RegionCollectionWCFPacket Region_LoadAll()
		{
			RegionCollection coll = new RegionCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public RegionCollection.RegionCollectionWCFPacket Region_QueryForCollection(string serializedQuery)
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

		public Region Region_QueryForEntity(string serializedQuery)
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
		
		public Region Region_GetByPrimaryKey(System.Int32 regionID)
		{
			Region obj = new Region();
			if (obj.LoadByPrimaryKey(regionID))
			{
				return obj;
			}
			return null;
		}

		public RegionCollection.RegionCollectionWCFPacket Region_SaveCollection(RegionCollection.RegionCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Region Region_SaveEntity(Region entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region IShippers Members
		
		public ShippersCollection.ShippersCollectionWCFPacket Shippers_LoadAll()
		{
			ShippersCollection coll = new ShippersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public ShippersCollection.ShippersCollectionWCFPacket Shippers_QueryForCollection(string serializedQuery)
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

		public Shippers Shippers_QueryForEntity(string serializedQuery)
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
		
		public Shippers Shippers_GetByPrimaryKey(System.Int32 shipperID)
		{
			Shippers obj = new Shippers();
			if (obj.LoadByPrimaryKey(shipperID))
			{
				return obj;
			}
			return null;
		}

		public ShippersCollection.ShippersCollectionWCFPacket Shippers_SaveCollection(ShippersCollection.ShippersCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Shippers Shippers_SaveEntity(Shippers entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ISuppliers Members
		
		public SuppliersCollection.SuppliersCollectionWCFPacket Suppliers_LoadAll()
		{
			SuppliersCollection coll = new SuppliersCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public SuppliersCollection.SuppliersCollectionWCFPacket Suppliers_QueryForCollection(string serializedQuery)
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

		public Suppliers Suppliers_QueryForEntity(string serializedQuery)
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
		
		public Suppliers Suppliers_GetByPrimaryKey(System.Int32 supplierID)
		{
			Suppliers obj = new Suppliers();
			if (obj.LoadByPrimaryKey(supplierID))
			{
				return obj;
			}
			return null;
		}

		public SuppliersCollection.SuppliersCollectionWCFPacket Suppliers_SaveCollection(SuppliersCollection.SuppliersCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Suppliers Suppliers_SaveEntity(Suppliers entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
				{
					return entity;
				}
			}

			return null;
		}

		#endregion
		
		#region ITerritories Members
		
		public TerritoriesCollection.TerritoriesCollectionWCFPacket Territories_LoadAll()
		{
			TerritoriesCollection coll = new TerritoriesCollection();
			if (coll.LoadAll())
			{
				return coll;
			}

			return null;
		}		

		public TerritoriesCollection.TerritoriesCollectionWCFPacket Territories_QueryForCollection(string serializedQuery)
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

		public Territories Territories_QueryForEntity(string serializedQuery)
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
		
		public Territories Territories_GetByPrimaryKey(System.String territoryID)
		{
			Territories obj = new Territories();
			if (obj.LoadByPrimaryKey(territoryID))
			{
				return obj;
			}
			return null;
		}

		public TerritoriesCollection.TerritoriesCollectionWCFPacket Territories_SaveCollection(TerritoriesCollection.TerritoriesCollectionWCFPacket collection)
		{
			if (collection != null)
			{
				collection.Collection.Save();
				return collection;
			}

			return null;
		}

		public Territories Territories_SaveEntity(Territories entity)
		{
			if (entity != null)
			{
				entity.Save();

				if (entity.RowState != esDataRowState.Deleted && entity.RowState != esDataRowState.Invalid)
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
