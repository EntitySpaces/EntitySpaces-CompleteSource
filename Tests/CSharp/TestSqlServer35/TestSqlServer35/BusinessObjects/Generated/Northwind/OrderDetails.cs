
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:40 AM
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
	/// Encapsulates the 'Order Details' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(OrderDetails))]	
	[XmlType("OrderDetails")]
	[Table(Name="OrderDetails")]
	public partial class OrderDetails : esOrderDetails
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new OrderDetails();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 orderID, System.Int32 productID)
		{
			var obj = new OrderDetails();
			obj.OrderID = orderID;
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 orderID, System.Int32 productID, esSqlAccessType sqlAccessType)
		{
			var obj = new OrderDetails();
			obj.OrderID = orderID;
			obj.ProductID = productID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator OrderDetailsProxyStub(OrderDetails entity)
		{
			return new OrderDetailsProxyStub(entity);
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

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Single? Discount
		{
			get { return base.Discount;  }
			set { base.Discount = value; }
		}


		#endregion
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[DebuggerVisualizer(typeof(EntitySpaces.DebuggerVisualizer.esVisualizer))]
	[Serializable]
	[CollectionDataContract]
	[XmlType("OrderDetailsCollection")]
	public partial class OrderDetailsCollection : esOrderDetailsCollection, IEnumerable<OrderDetails>
	{
		public OrderDetails FindByPrimaryKey(System.Int32 orderID, System.Int32 productID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID && e.ProductID == productID);
		}

		#region Implicit Casts
		
		public static implicit operator OrderDetailsCollectionProxyStub(OrderDetailsCollection coll)
		{
			return new OrderDetailsCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(OrderDetails))]
		public class OrderDetailsCollectionWCFPacket : esCollectionWCFPacket<OrderDetailsCollection>
		{
			public static implicit operator OrderDetailsCollection(OrderDetailsCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator OrderDetailsCollectionWCFPacket(OrderDetailsCollection collection)
			{
				return new OrderDetailsCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]
	[DataContract(Name = "OrderDetailsQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class OrderDetailsQuery : esOrderDetailsQuery
	{
		public OrderDetailsQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "OrderDetailsQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OrderDetailsQuery query)
		{
			return OrderDetailsQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OrderDetailsQuery(string query)
		{
			return (OrderDetailsQuery)OrderDetailsQuery.SerializeHelper.FromXml(query, typeof(OrderDetailsQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esOrderDetails : EntityBase
	{
		public esOrderDetails()
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
			OrderDetailsQuery query = new OrderDetailsQuery();
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
		/// Maps to Order Details.OrderID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? OrderID
		{
			get
			{
				return base.GetSystemInt32(OrderDetailsMetadata.ColumnNames.OrderID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrderDetailsMetadata.ColumnNames.OrderID, value))
				{
					this._UpToOrdersByOrderID = null;
					this.OnPropertyChanged("UpToOrdersByOrderID");
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.OrderID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order Details.ProductID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ProductID
		{
			get
			{
				return base.GetSystemInt32(OrderDetailsMetadata.ColumnNames.ProductID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrderDetailsMetadata.ColumnNames.ProductID, value))
				{
					this._UpToProductsByProductID = null;
					this.OnPropertyChanged("UpToProductsByProductID");
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.ProductID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order Details.UnitPrice
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? UnitPrice
		{
			get
			{
				return base.GetSystemDecimal(OrderDetailsMetadata.ColumnNames.UnitPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(OrderDetailsMetadata.ColumnNames.UnitPrice, value))
				{
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.UnitPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order Details.Quantity
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int16? Quantity
		{
			get
			{
				return base.GetSystemInt16(OrderDetailsMetadata.ColumnNames.Quantity);
			}
			
			set
			{
				if(base.SetSystemInt16(OrderDetailsMetadata.ColumnNames.Quantity, value))
				{
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Quantity);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order Details.Discount
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Single? Discount
		{
			get
			{
				return base.GetSystemSingle(OrderDetailsMetadata.ColumnNames.Discount);
			}
			
			set
			{
				if(base.SetSystemSingle(OrderDetailsMetadata.ColumnNames.Discount, value))
				{
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Discount);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Orders _UpToOrdersByOrderID;
		[CLSCompliant(false)]
		internal protected Products _UpToProductsByProductID;
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
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.OrderID);
							break;
						
						case "ProductID":
						
							if (value == null || value is System.Int32)
								this.ProductID = (System.Int32?)value;
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.ProductID);
							break;
						
						case "UnitPrice":
						
							if (value == null || value is System.Decimal)
								this.UnitPrice = (System.Decimal?)value;
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.UnitPrice);
							break;
						
						case "Quantity":
						
							if (value == null || value is System.Int16)
								this.Quantity = (System.Int16?)value;
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Quantity);
							break;
						
						case "Discount":
						
							if (value == null || value is System.Single)
								this.Discount = (System.Single?)value;
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Discount);
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
			public esStrings(esOrderDetails entity)
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
			

			private esOrderDetails entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return OrderDetailsMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public OrderDetailsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrderDetailsQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrderDetailsQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(OrderDetailsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private OrderDetailsQuery query;		
	}



	[Serializable]
	abstract public partial class esOrderDetailsCollection : CollectionBase<OrderDetails>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return OrderDetailsMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "OrderDetailsCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public OrderDetailsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrderDetailsQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrderDetailsQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new OrderDetailsQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(OrderDetailsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((OrderDetailsQuery)query);
		}

		#endregion
		
		private OrderDetailsQuery query;
	}



	[Serializable]
	abstract public partial class esOrderDetailsQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return OrderDetailsMetadata.Meta();
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
			get { return new esQueryItem(this, OrderDetailsMetadata.ColumnNames.OrderID, esSystemType.Int32); }
		} 
		
		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, OrderDetailsMetadata.ColumnNames.ProductID, esSystemType.Int32); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, OrderDetailsMetadata.ColumnNames.UnitPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Quantity
		{
			get { return new esQueryItem(this, OrderDetailsMetadata.ColumnNames.Quantity, esSystemType.Int16); }
		} 
		
		public esQueryItem Discount
		{
			get { return new esQueryItem(this, OrderDetailsMetadata.ColumnNames.Discount, esSystemType.Single); }
		} 
		
		#endregion
		
	}


	
	public partial class OrderDetails : esOrderDetails
	{

				
		#region UpToOrdersByOrderID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>

		[XmlIgnore]
					
		public Orders UpToOrdersByOrderID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToOrdersByOrderID == null && OrderID != null)
				{
					this._UpToOrdersByOrderID = new Orders();
					this._UpToOrdersByOrderID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToOrdersByOrderID", this._UpToOrdersByOrderID);
					this._UpToOrdersByOrderID.Query.Where(this._UpToOrdersByOrderID.Query.OrderID == this.OrderID);
					this._UpToOrdersByOrderID.Query.Load();
				}	
				return this._UpToOrdersByOrderID;
			}
			
			set
			{
				this.RemovePreSave("UpToOrdersByOrderID");
				
				bool changed = this._UpToOrdersByOrderID != value;

				if(value == null)
				{
					this.OrderID = null;
					this._UpToOrdersByOrderID = null;
				}
				else
				{
					this.OrderID = value.OrderID;
					this._UpToOrdersByOrderID = value;
					this.SetPreSave("UpToOrdersByOrderID", this._UpToOrdersByOrderID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToOrdersByOrderID");
				}
			}
		}
		#endregion
		

				
		#region UpToProductsByProductID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Order_Details_Products
		/// </summary>

		[XmlIgnore]
					
		public Products UpToProductsByProductID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToProductsByProductID == null && ProductID != null)
				{
					this._UpToProductsByProductID = new Products();
					this._UpToProductsByProductID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToProductsByProductID", this._UpToProductsByProductID);
					this._UpToProductsByProductID.Query.Where(this._UpToProductsByProductID.Query.ProductID == this.ProductID);
					this._UpToProductsByProductID.Query.Load();
				}	
				return this._UpToProductsByProductID;
			}
			
			set
			{
				this.RemovePreSave("UpToProductsByProductID");
				
				bool changed = this._UpToProductsByProductID != value;

				if(value == null)
				{
					this.ProductID = null;
					this._UpToProductsByProductID = null;
				}
				else
				{
					this.ProductID = value.ProductID;
					this._UpToProductsByProductID = value;
					this.SetPreSave("UpToProductsByProductID", this._UpToProductsByProductID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToProductsByProductID");
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
			if(!this.es.IsDeleted && this._UpToOrdersByOrderID != null)
			{
				this.OrderID = this._UpToOrdersByOrderID.OrderID;
			}
			if(!this.es.IsDeleted && this._UpToProductsByProductID != null)
			{
				this.ProductID = this._UpToProductsByProductID.ProductID;
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "OrderDetails")]
	[XmlType(TypeName="OrderDetailsProxyStub")]	
	[Serializable]
	public partial class OrderDetailsProxyStub
	{
		public OrderDetailsProxyStub() 
		{
			theEntity = this.entity = new OrderDetails();
		}

		public OrderDetailsProxyStub(OrderDetails obj)
		{
			theEntity = this.entity = obj;
		}

		public OrderDetailsProxyStub(OrderDetails obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator OrderDetails(OrderDetailsProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(OrderDetails);
		}

		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
		public System.Int32? OrderID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(OrderDetailsMetadata.ColumnNames.OrderID);
				else
					return this.Entity.OrderID;
			}
			set { this.Entity.OrderID = value; }
		}

		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.Int32? ProductID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(OrderDetailsMetadata.ColumnNames.ProductID);
				else
					return this.Entity.ProductID;
			}
			set { this.Entity.ProductID = value; }
		}

		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
		public System.Decimal? UnitPrice
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderDetailsMetadata.ColumnNames.UnitPrice))
					return this.Entity.UnitPrice;
				else
					return null;
			}
			set { this.Entity.UnitPrice = value; }
		}

		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
		public System.Int16? Quantity
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderDetailsMetadata.ColumnNames.Quantity))
					return this.Entity.Quantity;
				else
					return null;
			}
			set { this.Entity.Quantity = value; }
		}

		[DataMember(Name="a4", Order=5, EmitDefaultValue=false)]
		public System.Single? Discount
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderDetailsMetadata.ColumnNames.Discount))
					return this.Entity.Discount;
				else
					return null;
			}
			set { this.Entity.Discount = value; }
		}


		[DataMember(Name="a10000", Order=10000)]
		public string esRowState
		{
			get { return TheRowState;  }
			set { TheRowState = value; }
		}
		
		[DataMember(Name="a10001", Order=10001, EmitDefaultValue=false)]
		private List<string> ModifiedColumns
		{
			get { return Entity.es.ModifiedColumns; }
			set 
			{ 
				Entity.es.ModifiedColumns.AddRange(value); 
			}
		}
		
		[DataMember(Name="a10002", Order=10002, EmitDefaultValue=false)]
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
		public OrderDetails Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new OrderDetails();
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
		public OrderDetails entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OrderDetailsCollection")]
	[XmlType(TypeName="OrderDetailsCollectionProxyStub")]	
	[Serializable]
	public partial class OrderDetailsCollectionProxyStub 
	{
		protected OrderDetailsCollectionProxyStub() {}
		
		public OrderDetailsCollectionProxyStub(esEntityCollection<OrderDetails> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public OrderDetailsCollectionProxyStub(esEntityCollection<OrderDetails> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator OrderDetailsCollection(OrderDetailsCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(OrderDetails);
		}
		
		public OrderDetailsCollectionProxyStub(esEntityCollection<OrderDetails> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (OrderDetails entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new OrderDetailsProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new OrderDetailsProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (OrderDetails entity in coll.es.DeletedEntities)
				{
					Collection.Add(new OrderDetailsProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<OrderDetailsProxyStub> Collection = new List<OrderDetailsProxyStub>();

		public OrderDetailsCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new OrderDetailsCollection();

				foreach (OrderDetailsProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private OrderDetailsCollection _coll;
	}



	[Serializable]
	public partial class OrderDetailsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OrderDetailsMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(OrderDetailsMetadata.ColumnNames.OrderID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrderDetailsMetadata.PropertyNames.OrderID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderDetailsMetadata.ColumnNames.ProductID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrderDetailsMetadata.PropertyNames.ProductID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderDetailsMetadata.ColumnNames.UnitPrice, 2, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OrderDetailsMetadata.PropertyNames.UnitPrice;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"(0)";
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderDetailsMetadata.ColumnNames.Quantity, 3, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = OrderDetailsMetadata.PropertyNames.Quantity;
			c.NumericPrecision = 5;
			c.HasDefault = true;
			c.Default = @"(1)";
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderDetailsMetadata.ColumnNames.Discount, 4, typeof(System.Single), esSystemType.Single);
			c.PropertyName = OrderDetailsMetadata.PropertyNames.Discount;
			c.NumericPrecision = 7;
			c.HasDefault = true;
			c.Default = @"(0)";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public OrderDetailsMetadata Meta()
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
			lock (typeof(OrderDetailsMetadata))
			{
				if(OrderDetailsMetadata.mapDelegates == null)
				{
					OrderDetailsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrderDetailsMetadata.meta == null)
				{
					OrderDetailsMetadata.meta = new OrderDetailsMetadata();
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
				meta.Catalog = "Northwind";
				meta.Schema = "dbo";
				
				meta.Source = "Order Details";
				meta.Destination = "Order Details";
				
				meta.spInsert = "proc_Order DetailsInsert";				
				meta.spUpdate = "proc_Order DetailsUpdate";		
				meta.spDelete = "proc_Order DetailsDelete";
				meta.spLoadAll = "proc_Order DetailsLoadAll";
				meta.spLoadByPrimaryKey = "proc_Order DetailsLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private OrderDetailsMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
