
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:38 AM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Product' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Product))]	
	[XmlType("Product")]
	[Table(Name="Product")]
	public partial class Product : esProduct
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
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

		#region Implicit Casts

		public static implicit operator ProductProxyStub(Product entity)
		{
			return new ProductProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? ProductID
		{
			get { return base.ProductID;  }
			set { base.ProductID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String ProductName
		{
			get { return base.ProductName;  }
			set { base.ProductName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Decimal? UnitPrice
		{
			get { return base.UnitPrice;  }
			set { base.UnitPrice = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Boolean? Discontinued
		{
			get { return base.Discontinued;  }
			set { base.Discontinued = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ProductCollection")]
	public partial class ProductCollection : esProductCollection, IEnumerable<Product>
	{
		public Product FindByPrimaryKey(System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.ProductID == productID);
		}

		#region Implicit Casts
		
		public static implicit operator ProductCollectionProxyStub(ProductCollection coll)
		{
			return new ProductCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Product))]
		public class ProductCollectionWCFPacket : esCollectionWCFPacket<ProductCollection>
		{
			public static implicit operator ProductCollection(ProductCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ProductCollectionWCFPacket(ProductCollection collection)
			{
				return new ProductCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ProductQuery", Namespace = "http://www.entityspaces.net")]	
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
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ProductQuery query)
		{
			return ProductQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ProductQuery(string query)
		{
			return (ProductQuery)ProductQuery.SerializeHelper.FromXml(query, typeof(ProductQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "ProductID": this.str().ProductID = (string)value; break;							
						case "ProductName": this.str().ProductName = (string)value; break;							
						case "UnitPrice": this.str().UnitPrice = (string)value; break;							
						case "Discontinued": this.str().Discontinued = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ProductID":
						
							if (value == null || value is System.Int32)
								this.ProductID = (System.Int32?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.ProductID);
							break;
						
						case "UnitPrice":
						
							if (value == null || value is System.Decimal)
								this.UnitPrice = (System.Decimal?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.UnitPrice);
							break;
						
						case "Discontinued":
						
							if (value == null || value is System.Boolean)
								this.Discontinued = (System.Boolean?)value;
								OnPropertyChanged(ProductMetadata.PropertyNames.Discontinued);
							break;
					

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esProduct entity)
			{
				this.entity = entity;
			}
			
	
			public System.String ProductID
			{
				get
				{
					System.Int32? data = entity.ProductID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ProductID = null;
					else entity.ProductID = Convert.ToInt32(value);
				}
			}
				
			public System.String ProductName
			{
				get
				{
					System.String data = entity.ProductName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ProductName = null;
					else entity.ProductName = Convert.ToString(value);
				}
			}
				
			public System.String UnitPrice
			{
				get
				{
					System.Decimal? data = entity.UnitPrice;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UnitPrice = null;
					else entity.UnitPrice = Convert.ToDecimal(value);
				}
			}
				
			public System.String Discontinued
			{
				get
				{
					System.Boolean? data = entity.Discontinued;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Discontinued = null;
					else entity.Discontinued = Convert.ToBoolean(value);
				}
			}
			

			private esProduct entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
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
		
        [IgnoreDataMember]
		private ProductQuery query;		
	}



	[Serializable]
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



	[Serializable]
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
		/// Foreign Key Name - FK_OrderItem_Product
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_OrderItem_Product
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
		/// Foreign Key Name - FK_OrderItem_Product
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
		/// Foreign Key Name - FK_OrderItem_Product
		/// </summary>

		[XmlIgnore]
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
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Product")]
	[XmlType(TypeName="ProductProxyStub")]	
	[Serializable]
	public partial class ProductProxyStub
	{
		public ProductProxyStub() 
		{
			theEntity = this.entity = new Product();
		}

		public ProductProxyStub(Product obj)
		{
			theEntity = this.entity = obj;
		}

		public ProductProxyStub(Product obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Product(ProductProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Product);
		}

		[DataMember(Name="ProductID", Order=1, EmitDefaultValue=false)]
		public System.Int32? ProductID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ProductMetadata.ColumnNames.ProductID);
				else
					return this.Entity.ProductID;
			}
			set { this.Entity.ProductID = value; }
		}

		[DataMember(Name="ProductName", Order=2, EmitDefaultValue=false)]
		public System.String ProductName
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductMetadata.ColumnNames.ProductName))
					return this.Entity.ProductName;
				else
					return null;
			}
			set { this.Entity.ProductName = value; }
		}

		[DataMember(Name="UnitPrice", Order=3, EmitDefaultValue=false)]
		public System.Decimal? UnitPrice
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductMetadata.ColumnNames.UnitPrice))
					return this.Entity.UnitPrice;
				else
					return null;
			}
			set { this.Entity.UnitPrice = value; }
		}

		[DataMember(Name="Discontinued", Order=4, EmitDefaultValue=false)]
		public System.Boolean? Discontinued
		{
			get 
			{ 
				
				if (this.IncludeColumn(ProductMetadata.ColumnNames.Discontinued))
					return this.Entity.Discontinued;
				else
					return null;
			}
			set { this.Entity.Discontinued = value; }
		}


		[DataMember(Name="esRowState", Order=10000)]
		public string esRowState
		{
			get { return TheRowState;  }
			set { TheRowState = value; }
		}
		
		[DataMember(Name="ModifiedColumns", Order=10001, EmitDefaultValue=false)]
		private List<string> ModifiedColumns
		{
			get { return Entity.es.ModifiedColumns; }
			set 
			{ 
				Entity.es.ModifiedColumns.AddRange(value); 
			}
		}
		
		[DataMember(Name="ExtraColumns", Order=10002, EmitDefaultValue=false)]
		[XmlIgnore]		
		public Dictionary<string, object> esExtraColumns
		{
			get { return Entity.GetExtraColumns(); }
			set { Entity.SetExtraColumns(value);   }
		}
		
		[XmlArray("_x_ExtraColumns")]
		[XmlArrayItem("_x_ExtraColumns", Type = typeof(DictionaryEntry))]
		public DictionaryEntry[] _x_ExtraColumns
		{
			get
			{
				Dictionary<string, object> extra = Entity.GetExtraColumns();

				// Make an array of DictionaryEntries to return   
				DictionaryEntry[] ret = new DictionaryEntry[extra.Count];
				int i = 0;
				DictionaryEntry de;

				// Iterate through the extra columns to load items into the array.   
				foreach (KeyValuePair<string, object> kv in extra)
				{
					de = new DictionaryEntry();
					de.Key = kv.Key;
					de.Value = kv.Value;
					ret[i] = de;
					i++;
				}
				return ret;
			}
			set
			{
				Dictionary<string, object> extra = new Dictionary<string, object>();
				for (int i = 0; i < value.Length; i++)
				{
					extra.Add((string)value[i].Key, (int)value[i].Value);
				}
				Entity.SetExtraColumns(extra);
			}
		}	

		[XmlIgnore]
		public Product Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Product();
				}

				return this.entity;
			}

			set
			{
				this.entity = value;
			}
		}
		
		protected string TheRowState
		{
			get
			{
				return theEntity.es.RowState.ToString();
			}

			set
			{
				switch (value)
				{
					case "Unchanged":
						theEntity.AcceptChanges();
						break;

					case "Added":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Added;
						break;

					case "Modified":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Modified;
						break;

					case "Deleted":
						theEntity.AcceptChanges();
						theEntity.MarkAsDeleted();
						break;
				}
			}
		}		
		
		protected bool IncludeColumn(string columnName)
		{
			bool include = false;

			if (dirtyColumnsOnly)
			{
				if (theEntity.es.ModifiedColumns != null &&
					theEntity.es.ModifiedColumns.Contains(columnName))
				{
					include = true;
				}
			}
			else if (!theEntity.es.IsDeleted)
			{
				include = true;
			}

			return include;
		}		

		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		public Product entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ProductCollection")]
	[XmlType(TypeName="ProductCollectionProxyStub")]	
	[Serializable]
	public partial class ProductCollectionProxyStub 
	{
		protected ProductCollectionProxyStub() {}
		
		public ProductCollectionProxyStub(esEntityCollection<Product> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ProductCollectionProxyStub(esEntityCollection<Product> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ProductCollection(ProductCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Product);
		}
		
		public ProductCollectionProxyStub(esEntityCollection<Product> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Product entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ProductProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ProductProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Product entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ProductProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ProductProxyStub> Collection = new List<ProductProxyStub>();

		public ProductCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ProductCollection();

				foreach (ProductProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ProductCollection _coll;
	}



	[Serializable]
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
			m_columns.Add(c);
				
			c = new esColumnMetadata(ProductMetadata.ColumnNames.Discontinued, 3, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = ProductMetadata.PropertyNames.Discontinued;
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
			get { return true; }
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
				meta.AddTypeMap("ProductName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Discontinued", new esTypeMap("bit", "System.Boolean"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Product";
				meta.Destination = "Product";
				
				meta.spInsert = "proc_ProductInsert";				
				meta.spUpdate = "proc_ProductUpdate";		
				meta.spDelete = "proc_ProductDelete";
				meta.spLoadAll = "proc_ProductLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductLoadByPrimaryKey";
				
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
