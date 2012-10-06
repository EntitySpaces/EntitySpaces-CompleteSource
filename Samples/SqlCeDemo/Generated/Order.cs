
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQLCE
Date Generated       : 9/23/2012 6:16:19 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Order' table
	/// </summary>

	public partial class Order : esOrder
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Order();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 orderID)
		{
			var obj = new Order();
			obj.OrderID = orderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 orderID, esSqlAccessType sqlAccessType)
		{
			var obj = new Order();
			obj.OrderID = orderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class OrderCollection : esOrderCollection, IEnumerable<Order>
	{
		public Order FindByPrimaryKey(System.Int32 orderID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID);
		}

		
		
		
				
	}


	
	public partial class OrderQuery : esOrderQuery
	{
		public OrderQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "OrderQuery";
		}
		
					
		
	}

	abstract public partial class esOrder : esEntity
	{
		public esOrder()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 orderID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 orderID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 orderID)
		{
			OrderQuery query = new OrderQuery();
			query.Where(query.OrderID == orderID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 orderID)
		{
			esParameters parms = new esParameters();
			parms.Add("OrderID", orderID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Order.OrderID
		/// </summary>
		virtual public System.Int32? OrderID
		{
			get
			{
				return base.GetSystemInt32(OrderMetadata.ColumnNames.OrderID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrderMetadata.ColumnNames.OrderID, value))
				{
					OnPropertyChanged(OrderMetadata.PropertyNames.OrderID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order.CustID
		/// </summary>
		virtual public System.String CustID
		{
			get
			{
				return base.GetSystemString(OrderMetadata.ColumnNames.CustID);
			}
			
			set
			{
				if(base.SetSystemString(OrderMetadata.ColumnNames.CustID, value))
				{
					this._UpToCustomerByCustID = null;
					this.OnPropertyChanged("UpToCustomerByCustID");
					OnPropertyChanged(OrderMetadata.PropertyNames.CustID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order.CustSub
		/// </summary>
		virtual public System.String CustSub
		{
			get
			{
				return base.GetSystemString(OrderMetadata.ColumnNames.CustSub);
			}
			
			set
			{
				if(base.SetSystemString(OrderMetadata.ColumnNames.CustSub, value))
				{
					this._UpToCustomerByCustID = null;
					this.OnPropertyChanged("UpToCustomerByCustID");
					OnPropertyChanged(OrderMetadata.PropertyNames.CustSub);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order.PlacedBy
		/// </summary>
		virtual public System.String PlacedBy
		{
			get
			{
				return base.GetSystemString(OrderMetadata.ColumnNames.PlacedBy);
			}
			
			set
			{
				if(base.SetSystemString(OrderMetadata.ColumnNames.PlacedBy, value))
				{
					OnPropertyChanged(OrderMetadata.PropertyNames.PlacedBy);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order.OrderDate
		/// </summary>
		virtual public System.DateTime? OrderDate
		{
			get
			{
				return base.GetSystemDateTime(OrderMetadata.ColumnNames.OrderDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(OrderMetadata.ColumnNames.OrderDate, value))
				{
					OnPropertyChanged(OrderMetadata.PropertyNames.OrderDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order.ConcurrencyCheck
		/// </summary>
		virtual public System.Int32? ConcurrencyCheck
		{
			get
			{
				return base.GetSystemInt32(OrderMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemInt32(OrderMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(OrderMetadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order.EmployeeID
		/// </summary>
		virtual public System.Int32? EmployeeID
		{
			get
			{
				return base.GetSystemInt32(OrderMetadata.ColumnNames.EmployeeID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrderMetadata.ColumnNames.EmployeeID, value))
				{
					this._UpToEmployeeByEmployeeID = null;
					this.OnPropertyChanged("UpToEmployeeByEmployeeID");
					OnPropertyChanged(OrderMetadata.PropertyNames.EmployeeID);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Customer _UpToCustomerByCustID;
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeByEmployeeID;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return OrderMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public OrderQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrderQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrderQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(OrderQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private OrderQuery query;		
	}



	abstract public partial class esOrderCollection : esEntityCollection<Order>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return OrderMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "OrderCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public OrderQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrderQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrderQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new OrderQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(OrderQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((OrderQuery)query);
		}

		#endregion
		
		private OrderQuery query;
	}



	abstract public partial class esOrderQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return OrderMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "OrderID": return this.OrderID;
				case "CustID": return this.CustID;
				case "CustSub": return this.CustSub;
				case "PlacedBy": return this.PlacedBy;
				case "OrderDate": return this.OrderDate;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;
				case "EmployeeID": return this.EmployeeID;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem OrderID
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.OrderID, esSystemType.Int32); }
		} 
		
		public esQueryItem CustID
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.CustID, esSystemType.String); }
		} 
		
		public esQueryItem CustSub
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.CustSub, esSystemType.String); }
		} 
		
		public esQueryItem PlacedBy
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.PlacedBy, esSystemType.String); }
		} 
		
		public esQueryItem OrderDate
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.OrderDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int32); }
		} 
		
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.EmployeeID, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Order : esOrder
	{

				
		#region UpToCustomerByCustID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - CustomerOrder
		/// </summary>

					
		public Customer UpToCustomerByCustID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCustomerByCustID == null && CustID != null && CustSub != null)
				{
					this._UpToCustomerByCustID = new Customer();
					this._UpToCustomerByCustID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomerByCustID", this._UpToCustomerByCustID);
					this._UpToCustomerByCustID.Query.Where(this._UpToCustomerByCustID.Query.CustomerID == this.CustID);
					this._UpToCustomerByCustID.Query.Where(this._UpToCustomerByCustID.Query.CustomerSub == this.CustSub);
					this._UpToCustomerByCustID.Query.Load();
				}	
				return this._UpToCustomerByCustID;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomerByCustID");
				
				bool changed = this._UpToCustomerByCustID != value;

				if(value == null)
				{
					this.CustID = null;
					this.CustSub = null;
					this._UpToCustomerByCustID = null;
				}
				else
				{
					this.CustID = value.CustomerID;
					this.CustSub = value.CustomerSub;
					this._UpToCustomerByCustID = value;
					this.SetPreSave("UpToCustomerByCustID", this._UpToCustomerByCustID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCustomerByCustID");
				}
			}
		}
		#endregion
		

				
		#region UpToEmployeeByEmployeeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - EmployeeOrder
		/// </summary>

					
		public Employee UpToEmployeeByEmployeeID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeeByEmployeeID == null && EmployeeID != null)
				{
					this._UpToEmployeeByEmployeeID = new Employee();
					this._UpToEmployeeByEmployeeID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeeByEmployeeID", this._UpToEmployeeByEmployeeID);
					this._UpToEmployeeByEmployeeID.Query.Where(this._UpToEmployeeByEmployeeID.Query.EmployeeID == this.EmployeeID);
					this._UpToEmployeeByEmployeeID.Query.Load();
				}	
				return this._UpToEmployeeByEmployeeID;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeeByEmployeeID");
				
				bool changed = this._UpToEmployeeByEmployeeID != value;

				if(value == null)
				{
					this.EmployeeID = null;
					this._UpToEmployeeByEmployeeID = null;
				}
				else
				{
					this.EmployeeID = value.EmployeeID;
					this._UpToEmployeeByEmployeeID = value;
					this.SetPreSave("UpToEmployeeByEmployeeID", this._UpToEmployeeByEmployeeID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeeByEmployeeID");
				}
			}
		}
		#endregion
		

		#region UpToProductCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - OrderOrderItem
		/// </summary>

		public ProductCollection UpToProductCollection
		{
			get
			{
				if(this._UpToProductCollection == null)
				{
					this._UpToProductCollection = new ProductCollection();
					this._UpToProductCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToProductCollection", this._UpToProductCollection);
					if (!this.es.IsLazyLoadDisabled && this.OrderID != null)
					{
						ProductQuery m = new ProductQuery("m");
						OrderItemQuery j = new OrderItemQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.ProductID == j.ProductID);
                        m.Where(j.OrderID == this.OrderID);

						this._UpToProductCollection.Load(m);
					}
				}

				return this._UpToProductCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToProductCollection != null) 
				{ 
					this.RemovePostSave("UpToProductCollection"); 
					this._UpToProductCollection = null;
					this.OnPropertyChanged("UpToProductCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - OrderOrderItem
		/// </summary>
		public void AssociateProductCollection(Product entity)
		{
			if (this._OrderItemCollection == null)
			{
				this._OrderItemCollection = new OrderItemCollection();
				this._OrderItemCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderItemCollection", this._OrderItemCollection);
			}

			OrderItem obj = this._OrderItemCollection.AddNew();
			obj.OrderID = this.OrderID;
			obj.ProductID = entity.ProductID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - OrderOrderItem
		/// </summary>
		public void DissociateProductCollection(Product entity)
		{
			if (this._OrderItemCollection == null)
			{
				this._OrderItemCollection = new OrderItemCollection();
				this._OrderItemCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderItemCollection", this._OrderItemCollection);
			}

			OrderItem obj = this._OrderItemCollection.AddNew();
			obj.OrderID = this.OrderID;
            obj.ProductID = entity.ProductID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private ProductCollection _UpToProductCollection;
		private OrderItemCollection _OrderItemCollection;
		#endregion

		#region OrderItemCollectionByOrderID - Zero To Many
		
		static public esPrefetchMap Prefetch_OrderItemCollectionByOrderID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Order.OrderItemCollectionByOrderID_Delegate;
				map.PropertyName = "OrderItemCollectionByOrderID";
				map.MyColumnName = "OrderID";
				map.ParentColumnName = "OrderID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void OrderItemCollectionByOrderID_Delegate(esPrefetchParameters data)
		{
			OrderQuery parent = new OrderQuery(data.NextAlias());

			OrderItemQuery me = data.You != null ? data.You as OrderItemQuery : new OrderItemQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.OrderID == me.OrderID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - OrderOrderItem
		/// </summary>

		public OrderItemCollection OrderItemCollectionByOrderID
		{
			get
			{
				if(this._OrderItemCollectionByOrderID == null)
				{
					this._OrderItemCollectionByOrderID = new OrderItemCollection();
					this._OrderItemCollectionByOrderID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("OrderItemCollectionByOrderID", this._OrderItemCollectionByOrderID);
				
					if (this.OrderID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._OrderItemCollectionByOrderID.Query.Where(this._OrderItemCollectionByOrderID.Query.OrderID == this.OrderID);
							this._OrderItemCollectionByOrderID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._OrderItemCollectionByOrderID.fks.Add(OrderItemMetadata.ColumnNames.OrderID, this.OrderID);
					}
				}

				return this._OrderItemCollectionByOrderID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._OrderItemCollectionByOrderID != null) 
				{ 
					this.RemovePostSave("OrderItemCollectionByOrderID"); 
					this._OrderItemCollectionByOrderID = null;
					this.OnPropertyChanged("OrderItemCollectionByOrderID");
				} 
			} 			
		}
			
		
		private OrderItemCollection _OrderItemCollectionByOrderID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrderItemCollectionByOrderID":
					coll = this.OrderItemCollectionByOrderID;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "OrderItemCollectionByOrderID", typeof(OrderItemCollection), new OrderItem()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToEmployeeByEmployeeID != null)
			{
				this.EmployeeID = this._UpToEmployeeByEmployeeID.EmployeeID;
			}
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetProperty(key, value);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._OrderItemCollection != null)
			{
				Apply(this._OrderItemCollection, "OrderID", this.OrderID);
			}
			if(this._OrderItemCollectionByOrderID != null)
			{
				Apply(this._OrderItemCollectionByOrderID, "OrderID", this.OrderID);
			}
		}
		
	}
	



	public partial class OrderMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OrderMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(OrderMetadata.ColumnNames.OrderID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrderMetadata.PropertyNames.OrderID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderMetadata.ColumnNames.CustID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = OrderMetadata.PropertyNames.CustID;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderMetadata.ColumnNames.CustSub, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = OrderMetadata.PropertyNames.CustSub;
			c.CharacterMaxLength = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderMetadata.ColumnNames.PlacedBy, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = OrderMetadata.PropertyNames.PlacedBy;
			c.CharacterMaxLength = 25;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderMetadata.ColumnNames.OrderDate, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = OrderMetadata.PropertyNames.OrderDate;
			c.NumericPrecision = 23;
			c.NumericScale = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderMetadata.ColumnNames.ConcurrencyCheck, 5, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrderMetadata.PropertyNames.ConcurrencyCheck;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"0";
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderMetadata.ColumnNames.EmployeeID, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrderMetadata.PropertyNames.EmployeeID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public OrderMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string CustID = "CustID";
			 public const string CustSub = "CustSub";
			 public const string PlacedBy = "PlacedBy";
			 public const string OrderDate = "OrderDate";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string EmployeeID = "EmployeeID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string CustID = "CustID";
			 public const string CustSub = "CustSub";
			 public const string PlacedBy = "PlacedBy";
			 public const string OrderDate = "OrderDate";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string EmployeeID = "EmployeeID";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(OrderMetadata))
			{
				if(OrderMetadata.mapDelegates == null)
				{
					OrderMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrderMetadata.meta == null)
				{
					OrderMetadata.meta = new OrderMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("OrderID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("CustID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CustSub", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PlacedBy", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("OrderDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "Order";
				meta.Destination = "Order";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private OrderMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
