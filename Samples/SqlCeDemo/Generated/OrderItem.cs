
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQLCE
Date Generated       : 9/23/2012 6:16:20 PM
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
	/// Encapsulates the 'OrderItem' table
	/// </summary>

	public partial class OrderItem : esOrderItem
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new OrderItem();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 orderID, System.Int32 productID)
		{
			var obj = new OrderItem();
			obj.OrderID = orderID;
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 orderID, System.Int32 productID, esSqlAccessType sqlAccessType)
		{
			var obj = new OrderItem();
			obj.OrderID = orderID;
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class OrderItemCollection : esOrderItemCollection, IEnumerable<OrderItem>
	{
		public OrderItem FindByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID && e.ProductID == productID);
		}

		
		
		
				
	}


	
	public partial class OrderItemQuery : esOrderItemQuery
	{
		public OrderItemQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "OrderItemQuery";
		}
		
					
		
	}

	abstract public partial class esOrderItem : esEntity
	{
		public esOrderItem()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID, productID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID, productID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 orderID, System.Int32 productID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID, productID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID, productID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 orderID, System.Int32 productID)
		{
			OrderItemQuery query = new OrderItemQuery();
			query.Where(query.OrderID == orderID, query.ProductID == productID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 orderID, System.Int32 productID)
		{
			esParameters parms = new esParameters();
			parms.Add("OrderID", orderID);			parms.Add("ProductID", productID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to OrderItem.OrderID
		/// </summary>
		virtual public System.Int32? OrderID
		{
			get
			{
				return base.GetSystemInt32(OrderItemMetadata.ColumnNames.OrderID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrderItemMetadata.ColumnNames.OrderID, value))
				{
					this._UpToOrderByOrderID = null;
					this.OnPropertyChanged("UpToOrderByOrderID");
					OnPropertyChanged(OrderItemMetadata.PropertyNames.OrderID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OrderItem.ProductID
		/// </summary>
		virtual public System.Int32? ProductID
		{
			get
			{
				return base.GetSystemInt32(OrderItemMetadata.ColumnNames.ProductID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrderItemMetadata.ColumnNames.ProductID, value))
				{
					this._UpToProductByProductID = null;
					this.OnPropertyChanged("UpToProductByProductID");
					OnPropertyChanged(OrderItemMetadata.PropertyNames.ProductID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OrderItem.UnitPrice
		/// </summary>
		virtual public System.Decimal? UnitPrice
		{
			get
			{
				return base.GetSystemDecimal(OrderItemMetadata.ColumnNames.UnitPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(OrderItemMetadata.ColumnNames.UnitPrice, value))
				{
					OnPropertyChanged(OrderItemMetadata.PropertyNames.UnitPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OrderItem.Quantity
		/// </summary>
		virtual public System.Int16? Quantity
		{
			get
			{
				return base.GetSystemInt16(OrderItemMetadata.ColumnNames.Quantity);
			}
			
			set
			{
				if(base.SetSystemInt16(OrderItemMetadata.ColumnNames.Quantity, value))
				{
					OnPropertyChanged(OrderItemMetadata.PropertyNames.Quantity);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OrderItem.Discount
		/// </summary>
		virtual public System.Single? Discount
		{
			get
			{
				return base.GetSystemSingle(OrderItemMetadata.ColumnNames.Discount);
			}
			
			set
			{
				if(base.SetSystemSingle(OrderItemMetadata.ColumnNames.Discount, value))
				{
					OnPropertyChanged(OrderItemMetadata.PropertyNames.Discount);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Order _UpToOrderByOrderID;
		[CLSCompliant(false)]
		internal protected Product _UpToProductByProductID;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return OrderItemMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public OrderItemQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrderItemQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrderItemQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(OrderItemQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private OrderItemQuery query;		
	}



	abstract public partial class esOrderItemCollection : esEntityCollection<OrderItem>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return OrderItemMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "OrderItemCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public OrderItemQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrderItemQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrderItemQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new OrderItemQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(OrderItemQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((OrderItemQuery)query);
		}

		#endregion
		
		private OrderItemQuery query;
	}



	abstract public partial class esOrderItemQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return OrderItemMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "OrderID": return this.OrderID;
				case "ProductID": return this.ProductID;
				case "UnitPrice": return this.UnitPrice;
				case "Quantity": return this.Quantity;
				case "Discount": return this.Discount;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem OrderID
		{
			get { return new esQueryItem(this, OrderItemMetadata.ColumnNames.OrderID, esSystemType.Int32); }
		} 
		
		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, OrderItemMetadata.ColumnNames.ProductID, esSystemType.Int32); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, OrderItemMetadata.ColumnNames.UnitPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Quantity
		{
			get { return new esQueryItem(this, OrderItemMetadata.ColumnNames.Quantity, esSystemType.Int16); }
		} 
		
		public esQueryItem Discount
		{
			get { return new esQueryItem(this, OrderItemMetadata.ColumnNames.Discount, esSystemType.Single); }
		} 
		
		#endregion
		
	}


	
	public partial class OrderItem : esOrderItem
	{

				
		#region UpToOrderByOrderID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - OrderOrderItem
		/// </summary>

					
		public Order UpToOrderByOrderID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToOrderByOrderID == null && OrderID != null)
				{
					this._UpToOrderByOrderID = new Order();
					this._UpToOrderByOrderID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToOrderByOrderID", this._UpToOrderByOrderID);
					this._UpToOrderByOrderID.Query.Where(this._UpToOrderByOrderID.Query.OrderID == this.OrderID);
					this._UpToOrderByOrderID.Query.Load();
				}	
				return this._UpToOrderByOrderID;
			}
			
			set
			{
				this.RemovePreSave("UpToOrderByOrderID");
				
				bool changed = this._UpToOrderByOrderID != value;

				if(value == null)
				{
					this.OrderID = null;
					this._UpToOrderByOrderID = null;
				}
				else
				{
					this.OrderID = value.OrderID;
					this._UpToOrderByOrderID = value;
					this.SetPreSave("UpToOrderByOrderID", this._UpToOrderByOrderID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToOrderByOrderID");
				}
			}
		}
		#endregion
		

				
		#region UpToProductByProductID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - ProductOrderItem
		/// </summary>

					
		public Product UpToProductByProductID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToProductByProductID == null && ProductID != null)
				{
					this._UpToProductByProductID = new Product();
					this._UpToProductByProductID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToProductByProductID", this._UpToProductByProductID);
					this._UpToProductByProductID.Query.Where(this._UpToProductByProductID.Query.ProductID == this.ProductID);
					this._UpToProductByProductID.Query.Load();
				}	
				return this._UpToProductByProductID;
			}
			
			set
			{
				this.RemovePreSave("UpToProductByProductID");
				
				bool changed = this._UpToProductByProductID != value;

				if(value == null)
				{
					this.ProductID = null;
					this._UpToProductByProductID = null;
				}
				else
				{
					this.ProductID = value.ProductID;
					this._UpToProductByProductID = value;
					this.SetPreSave("UpToProductByProductID", this._UpToProductByProductID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToProductByProductID");
				}
			}
		}
		#endregion
		

		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToOrderByOrderID != null)
			{
				this.OrderID = this._UpToOrderByOrderID.OrderID;
			}
			if(!this.es.IsDeleted && this._UpToProductByProductID != null)
			{
				this.ProductID = this._UpToProductByProductID.ProductID;
			}
		}
		
	}
	



	public partial class OrderItemMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OrderItemMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(OrderItemMetadata.ColumnNames.OrderID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrderItemMetadata.PropertyNames.OrderID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderItemMetadata.ColumnNames.ProductID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrderItemMetadata.PropertyNames.ProductID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderItemMetadata.ColumnNames.UnitPrice, 2, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OrderItemMetadata.PropertyNames.UnitPrice;
			c.NumericPrecision = 19;
			c.NumericScale = 4;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderItemMetadata.ColumnNames.Quantity, 3, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = OrderItemMetadata.PropertyNames.Quantity;
			c.NumericPrecision = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderItemMetadata.ColumnNames.Discount, 4, typeof(System.Single), esSystemType.Single);
			c.PropertyName = OrderItemMetadata.PropertyNames.Discount;
			c.NumericPrecision = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public OrderItemMetadata Meta()
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
			 public const string ProductID = "ProductID";
			 public const string UnitPrice = "UnitPrice";
			 public const string Quantity = "Quantity";
			 public const string Discount = "Discount";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string ProductID = "ProductID";
			 public const string UnitPrice = "UnitPrice";
			 public const string Quantity = "Quantity";
			 public const string Discount = "Discount";
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
			lock (typeof(OrderItemMetadata))
			{
				if(OrderItemMetadata.mapDelegates == null)
				{
					OrderItemMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrderItemMetadata.meta == null)
				{
					OrderItemMetadata.meta = new OrderItemMetadata();
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
				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Quantity", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("Discount", new esTypeMap("real", "System.Single"));			
				
				
				
				meta.Source = "OrderItem";
				meta.Destination = "OrderItem";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private OrderItemMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
