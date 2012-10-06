
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
	/// Encapsulates the 'Product' table
	/// </summary>

	public partial class Product : esProduct
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Product();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 productID)
		{
			var obj = new Product();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 productID, esSqlAccessType sqlAccessType)
		{
			var obj = new Product();
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class ProductCollection : esProductCollection, IEnumerable<Product>
	{
		public Product FindByPrimaryKey(System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.ProductID == productID);
		}

		
		
		
				
	}


	
	public partial class ProductQuery : esProductQuery
	{
		public ProductQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ProductQuery";
		}
		
					
		
	}

	abstract public partial class esProduct : esEntity
	{
		public esProduct()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 productID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 productID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(productID);
			else
				return LoadByPrimaryKeyStoredProcedure(productID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 productID)
		{
			ProductQuery query = new ProductQuery();
			query.Where(query.ProductID == productID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 productID)
		{
			esParameters parms = new esParameters();
			parms.Add("ProductID", productID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Product.ProductID
		/// </summary>
		virtual public System.Int32? ProductID
		{
			get
			{
				return base.GetSystemInt32(ProductMetadata.ColumnNames.ProductID);
			}
			
			set
			{
				if(base.SetSystemInt32(ProductMetadata.ColumnNames.ProductID, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.ProductID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.ProductName
		/// </summary>
		virtual public System.String ProductName
		{
			get
			{
				return base.GetSystemString(ProductMetadata.ColumnNames.ProductName);
			}
			
			set
			{
				if(base.SetSystemString(ProductMetadata.ColumnNames.ProductName, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.ProductName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.UnitPrice
		/// </summary>
		virtual public System.Decimal? UnitPrice
		{
			get
			{
				return base.GetSystemDecimal(ProductMetadata.ColumnNames.UnitPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(ProductMetadata.ColumnNames.UnitPrice, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.UnitPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Product.Discontinued
		/// </summary>
		virtual public System.Boolean? Discontinued
		{
			get
			{
				return base.GetSystemBoolean(ProductMetadata.ColumnNames.Discontinued);
			}
			
			set
			{
				if(base.SetSystemBoolean(ProductMetadata.ColumnNames.Discontinued, value))
				{
					OnPropertyChanged(ProductMetadata.PropertyNames.Discontinued);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ProductMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private ProductQuery query;		
	}



	abstract public partial class esProductCollection : esEntityCollection<Product>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ProductMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ProductCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ProductQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ProductQuery)query);
		}

		#endregion
		
		private ProductQuery query;
	}



	abstract public partial class esProductQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ProductMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "ProductID": return this.ProductID;
				case "ProductName": return this.ProductName;
				case "UnitPrice": return this.UnitPrice;
				case "Discontinued": return this.Discontinued;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.ProductID, esSystemType.Int32); }
		} 
		
		public esQueryItem ProductName
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.ProductName, esSystemType.String); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.UnitPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Discontinued
		{
			get { return new esQueryItem(this, ProductMetadata.ColumnNames.Discontinued, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}


	
	public partial class Product : esProduct
	{

		#region UpToOrderCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - ProductOrderItem
		/// </summary>

		public OrderCollection UpToOrderCollection
		{
			get
			{
				if(this._UpToOrderCollection == null)
				{
					this._UpToOrderCollection = new OrderCollection();
					this._UpToOrderCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToOrderCollection", this._UpToOrderCollection);
					if (!this.es.IsLazyLoadDisabled && this.ProductID != null)
					{
						OrderQuery m = new OrderQuery("m");
						OrderItemQuery j = new OrderItemQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.OrderID == j.OrderID);
                        m.Where(j.ProductID == this.ProductID);

						this._UpToOrderCollection.Load(m);
					}
				}

				return this._UpToOrderCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToOrderCollection != null) 
				{ 
					this.RemovePostSave("UpToOrderCollection"); 
					this._UpToOrderCollection = null;
					this.OnPropertyChanged("UpToOrderCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - ProductOrderItem
		/// </summary>
		public void AssociateOrderCollection(Order entity)
		{
			if (this._OrderItemCollection == null)
			{
				this._OrderItemCollection = new OrderItemCollection();
				this._OrderItemCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderItemCollection", this._OrderItemCollection);
			}

			OrderItem obj = this._OrderItemCollection.AddNew();
			obj.ProductID = this.ProductID;
			obj.OrderID = entity.OrderID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - ProductOrderItem
		/// </summary>
		public void DissociateOrderCollection(Order entity)
		{
			if (this._OrderItemCollection == null)
			{
				this._OrderItemCollection = new OrderItemCollection();
				this._OrderItemCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderItemCollection", this._OrderItemCollection);
			}

			OrderItem obj = this._OrderItemCollection.AddNew();
			obj.ProductID = this.ProductID;
            obj.OrderID = entity.OrderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private OrderCollection _UpToOrderCollection;
		private OrderItemCollection _OrderItemCollection;
		#endregion

		#region OrderItemCollectionByProductID - Zero To Many
		
		static public esPrefetchMap Prefetch_OrderItemCollectionByProductID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Product.OrderItemCollectionByProductID_Delegate;
				map.PropertyName = "OrderItemCollectionByProductID";
				map.MyColumnName = "ProductID";
				map.ParentColumnName = "ProductID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void OrderItemCollectionByProductID_Delegate(esPrefetchParameters data)
		{
			ProductQuery parent = new ProductQuery(data.NextAlias());

			OrderItemQuery me = data.You != null ? data.You as OrderItemQuery : new OrderItemQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.ProductID == me.ProductID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - ProductOrderItem
		/// </summary>

		public OrderItemCollection OrderItemCollectionByProductID
		{
			get
			{
				if(this._OrderItemCollectionByProductID == null)
				{
					this._OrderItemCollectionByProductID = new OrderItemCollection();
					this._OrderItemCollectionByProductID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("OrderItemCollectionByProductID", this._OrderItemCollectionByProductID);
				
					if (this.ProductID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._OrderItemCollectionByProductID.Query.Where(this._OrderItemCollectionByProductID.Query.ProductID == this.ProductID);
							this._OrderItemCollectionByProductID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._OrderItemCollectionByProductID.fks.Add(OrderItemMetadata.ColumnNames.ProductID, this.ProductID);
					}
				}

				return this._OrderItemCollectionByProductID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._OrderItemCollectionByProductID != null) 
				{ 
					this.RemovePostSave("OrderItemCollectionByProductID"); 
					this._OrderItemCollectionByProductID = null;
					this.OnPropertyChanged("OrderItemCollectionByProductID");
				} 
			} 			
		}
			
		
		private OrderItemCollection _OrderItemCollectionByProductID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrderItemCollectionByProductID":
					coll = this.OrderItemCollectionByProductID;
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
			
			props.Add(new esPropertyDescriptor(this, "OrderItemCollectionByProductID", typeof(OrderItemCollection), new OrderItem()));
		
			return props;
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
				Apply(this._OrderItemCollection, "ProductID", this.ProductID);
			}
			if(this._OrderItemCollectionByProductID != null)
			{
				Apply(this._OrderItemCollectionByProductID, "ProductID", this.ProductID);
			}
		}
		
	}
	



	public partial class ProductMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ProductMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ProductMetadata.ColumnNames.ProductID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductMetadata.PropertyNames.ProductID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.ProductName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductMetadata.PropertyNames.ProductName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.UnitPrice, 2, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = ProductMetadata.PropertyNames.UnitPrice;
			c.NumericPrecision = 19;
			c.NumericScale = 4;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.Discontinued, 3, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = ProductMetadata.PropertyNames.Discontinued;
			c.NumericPrecision = 1;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ProductMetadata Meta()
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
			 public const string ProductID = "ProductID";
			 public const string ProductName = "ProductName";
			 public const string UnitPrice = "UnitPrice";
			 public const string Discontinued = "Discontinued";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ProductID = "ProductID";
			 public const string ProductName = "ProductName";
			 public const string UnitPrice = "UnitPrice";
			 public const string Discontinued = "Discontinued";
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
			lock (typeof(ProductMetadata))
			{
				if(ProductMetadata.mapDelegates == null)
				{
					ProductMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductMetadata.meta == null)
				{
					ProductMetadata.meta = new ProductMetadata();
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


				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ProductName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Discontinued", new esTypeMap("bit", "System.Boolean"));			
				
				
				
				meta.Source = "Product";
				meta.Destination = "Product";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ProductMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
