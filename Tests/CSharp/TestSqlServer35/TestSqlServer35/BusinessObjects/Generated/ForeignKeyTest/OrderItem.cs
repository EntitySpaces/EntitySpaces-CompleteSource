
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
	/// Encapsulates the 'OrderItem' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(OrderItem))]	
	[XmlType("OrderItem")]
	[Table(Name="OrderItem")]
	public partial class OrderItem : esOrderItem
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
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

		#region Implicit Casts

		public static implicit operator OrderItemProxyStub(OrderItem entity)
		{
			return new OrderItemProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? OrderID
		{
			get { return base.OrderID;  }
			set { base.OrderID = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? ProductID
		{
			get { return base.ProductID;  }
			set { base.ProductID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Decimal? UnitPrice
		{
			get { return base.UnitPrice;  }
			set { base.UnitPrice = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int16? Quantity
		{
			get { return base.Quantity;  }
			set { base.Quantity = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Single? Discount
		{
			get { return base.Discount;  }
			set { base.Discount = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("OrderItemCollection")]
	public partial class OrderItemCollection : esOrderItemCollection, IEnumerable<OrderItem>
	{
		public OrderItem FindByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID && e.ProductID == productID);
		}

		#region Implicit Casts
		
		public static implicit operator OrderItemCollectionProxyStub(OrderItemCollection coll)
		{
			return new OrderItemCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(OrderItem))]
		public class OrderItemCollectionWCFPacket : esCollectionWCFPacket<OrderItemCollection>
		{
			public static implicit operator OrderItemCollection(OrderItemCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator OrderItemCollectionWCFPacket(OrderItemCollection collection)
			{
				return new OrderItemCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "OrderItemQuery", Namespace = "http://www.entityspaces.net")]	
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
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OrderItemQuery query)
		{
			return OrderItemQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OrderItemQuery(string query)
		{
			return (OrderItemQuery)OrderItemQuery.SerializeHelper.FromXml(query, typeof(OrderItemQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
						case "OrderID": this.str().OrderID = (string)value; break;							
						case "ProductID": this.str().ProductID = (string)value; break;							
						case "UnitPrice": this.str().UnitPrice = (string)value; break;							
						case "Quantity": this.str().Quantity = (string)value; break;							
						case "Discount": this.str().Discount = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "OrderID":
						
							if (value == null || value is System.Int32)
								this.OrderID = (System.Int32?)value;
								OnPropertyChanged(OrderItemMetadata.PropertyNames.OrderID);
							break;
						
						case "ProductID":
						
							if (value == null || value is System.Int32)
								this.ProductID = (System.Int32?)value;
								OnPropertyChanged(OrderItemMetadata.PropertyNames.ProductID);
							break;
						
						case "UnitPrice":
						
							if (value == null || value is System.Decimal)
								this.UnitPrice = (System.Decimal?)value;
								OnPropertyChanged(OrderItemMetadata.PropertyNames.UnitPrice);
							break;
						
						case "Quantity":
						
							if (value == null || value is System.Int16)
								this.Quantity = (System.Int16?)value;
								OnPropertyChanged(OrderItemMetadata.PropertyNames.Quantity);
							break;
						
						case "Discount":
						
							if (value == null || value is System.Single)
								this.Discount = (System.Single?)value;
								OnPropertyChanged(OrderItemMetadata.PropertyNames.Discount);
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
			public esStrings(esOrderItem entity)
			{
				this.entity = entity;
			}
			
	
			public System.String OrderID
			{
				get
				{
					System.Int32? data = entity.OrderID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.OrderID = null;
					else entity.OrderID = Convert.ToInt32(value);
				}
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
				
			public System.String Quantity
			{
				get
				{
					System.Int16? data = entity.Quantity;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Quantity = null;
					else entity.Quantity = Convert.ToInt16(value);
				}
			}
				
			public System.String Discount
			{
				get
				{
					System.Single? data = entity.Discount;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Discount = null;
					else entity.Discount = Convert.ToSingle(value);
				}
			}
			

			private esOrderItem entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
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
		
        [IgnoreDataMember]
		private OrderItemQuery query;		
	}



	[Serializable]
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



	[Serializable]
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
		/// Foreign Key Name - FK_OrderItem_Order
		/// </summary>

		[XmlIgnore]
					
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
		/// Foreign Key Name - FK_OrderItem_Product
		/// </summary>

		[XmlIgnore]
					
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
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "OrderItem")]
	[XmlType(TypeName="OrderItemProxyStub")]	
	[Serializable]
	public partial class OrderItemProxyStub
	{
		public OrderItemProxyStub() 
		{
			theEntity = this.entity = new OrderItem();
		}

		public OrderItemProxyStub(OrderItem obj)
		{
			theEntity = this.entity = obj;
		}

		public OrderItemProxyStub(OrderItem obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator OrderItem(OrderItemProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(OrderItem);
		}

		[DataMember(Name="OrderID", Order=1, EmitDefaultValue=false)]
		public System.Int32? OrderID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(OrderItemMetadata.ColumnNames.OrderID);
				else
					return this.Entity.OrderID;
			}
			set { this.Entity.OrderID = value; }
		}

		[DataMember(Name="ProductID", Order=2, EmitDefaultValue=false)]
		public System.Int32? ProductID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(OrderItemMetadata.ColumnNames.ProductID);
				else
					return this.Entity.ProductID;
			}
			set { this.Entity.ProductID = value; }
		}

		[DataMember(Name="UnitPrice", Order=3, EmitDefaultValue=false)]
		public System.Decimal? UnitPrice
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderItemMetadata.ColumnNames.UnitPrice))
					return this.Entity.UnitPrice;
				else
					return null;
			}
			set { this.Entity.UnitPrice = value; }
		}

		[DataMember(Name="Quantity", Order=4, EmitDefaultValue=false)]
		public System.Int16? Quantity
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderItemMetadata.ColumnNames.Quantity))
					return this.Entity.Quantity;
				else
					return null;
			}
			set { this.Entity.Quantity = value; }
		}

		[DataMember(Name="Discount", Order=5, EmitDefaultValue=false)]
		public System.Single? Discount
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderItemMetadata.ColumnNames.Discount))
					return this.Entity.Discount;
				else
					return null;
			}
			set { this.Entity.Discount = value; }
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
		public OrderItem Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new OrderItem();
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
		public OrderItem entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OrderItemCollection")]
	[XmlType(TypeName="OrderItemCollectionProxyStub")]	
	[Serializable]
	public partial class OrderItemCollectionProxyStub 
	{
		protected OrderItemCollectionProxyStub() {}
		
		public OrderItemCollectionProxyStub(esEntityCollection<OrderItem> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public OrderItemCollectionProxyStub(esEntityCollection<OrderItem> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator OrderItemCollection(OrderItemCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(OrderItem);
		}
		
		public OrderItemCollectionProxyStub(esEntityCollection<OrderItem> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (OrderItem entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new OrderItemProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new OrderItemProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (OrderItem entity in coll.es.DeletedEntities)
				{
					Collection.Add(new OrderItemProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<OrderItemProxyStub> Collection = new List<OrderItemProxyStub>();

		public OrderItemCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new OrderItemCollection();

				foreach (OrderItemProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private OrderItemCollection _coll;
	}



	[Serializable]
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
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderItemMetadata.ColumnNames.Quantity, 3, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = OrderItemMetadata.PropertyNames.Quantity;
			c.NumericPrecision = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderItemMetadata.ColumnNames.Discount, 4, typeof(System.Single), esSystemType.Single);
			c.PropertyName = OrderItemMetadata.PropertyNames.Discount;
			c.NumericPrecision = 7;
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
			get { return true; }
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
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "OrderItem";
				meta.Destination = "OrderItem";
				
				meta.spInsert = "proc_OrderItemInsert";				
				meta.spUpdate = "proc_OrderItemUpdate";		
				meta.spDelete = "proc_OrderItemDelete";
				meta.spLoadAll = "proc_OrderItemLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrderItemLoadByPrimaryKey";
				
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
