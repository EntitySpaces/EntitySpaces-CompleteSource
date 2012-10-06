
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
	/// Encapsulates the 'Order' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Order))]	
	[XmlType("Order")]
	[Table(Name="Order")]
	public partial class Order : esOrder
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
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

		#region Implicit Casts

		public static implicit operator OrderProxyStub(Order entity)
		{
			return new OrderProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? OrderID
		{
			get { return base.OrderID;  }
			set { base.OrderID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String CustID
		{
			get { return base.CustID;  }
			set { base.CustID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String CustSub
		{
			get { return base.CustSub;  }
			set { base.CustSub = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String PlacedBy
		{
			get { return base.PlacedBy;  }
			set { base.PlacedBy = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.DateTime? OrderDate
		{
			get { return base.OrderDate;  }
			set { base.OrderDate = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Byte[] ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? EmployeeID
		{
			get { return base.EmployeeID;  }
			set { base.EmployeeID = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("OrderCollection")]
	public partial class OrderCollection : esOrderCollection, IEnumerable<Order>
	{
		public Order FindByPrimaryKey(System.Int32 orderID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID);
		}

		#region Implicit Casts
		
		public static implicit operator OrderCollectionProxyStub(OrderCollection coll)
		{
			return new OrderCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Order))]
		public class OrderCollectionWCFPacket : esCollectionWCFPacket<OrderCollection>
		{
			public static implicit operator OrderCollection(OrderCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator OrderCollectionWCFPacket(OrderCollection collection)
			{
				return new OrderCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "OrderQuery", Namespace = "http://www.entityspaces.net")]	
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
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OrderQuery query)
		{
			return OrderQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OrderQuery(string query)
		{
			return (OrderQuery)OrderQuery.SerializeHelper.FromXml(query, typeof(OrderQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte[] ConcurrencyCheck
		{
			get
			{
				return base.GetSystemByteArray(OrderMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemByteArray(OrderMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(OrderMetadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Order.EmployeeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
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
						case "CustID": this.str().CustID = (string)value; break;							
						case "CustSub": this.str().CustSub = (string)value; break;							
						case "PlacedBy": this.str().PlacedBy = (string)value; break;							
						case "OrderDate": this.str().OrderDate = (string)value; break;							
						case "EmployeeID": this.str().EmployeeID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "OrderID":
						
							if (value == null || value is System.Int32)
								this.OrderID = (System.Int32?)value;
								OnPropertyChanged(OrderMetadata.PropertyNames.OrderID);
							break;
						
						case "OrderDate":
						
							if (value == null || value is System.DateTime)
								this.OrderDate = (System.DateTime?)value;
								OnPropertyChanged(OrderMetadata.PropertyNames.OrderDate);
							break;
						
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Byte[])
								this.ConcurrencyCheck = (System.Byte[])value;
								OnPropertyChanged(OrderMetadata.PropertyNames.ConcurrencyCheck);
							break;
						
						case "EmployeeID":
						
							if (value == null || value is System.Int32)
								this.EmployeeID = (System.Int32?)value;
								OnPropertyChanged(OrderMetadata.PropertyNames.EmployeeID);
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
			public esStrings(esOrder entity)
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
				
			public System.String CustID
			{
				get
				{
					System.String data = entity.CustID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustID = null;
					else entity.CustID = Convert.ToString(value);
				}
			}
				
			public System.String CustSub
			{
				get
				{
					System.String data = entity.CustSub;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustSub = null;
					else entity.CustSub = Convert.ToString(value);
				}
			}
				
			public System.String PlacedBy
			{
				get
				{
					System.String data = entity.PlacedBy;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PlacedBy = null;
					else entity.PlacedBy = Convert.ToString(value);
				}
			}
				
			public System.String OrderDate
			{
				get
				{
					System.DateTime? data = entity.OrderDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.OrderDate = null;
					else entity.OrderDate = Convert.ToDateTime(value);
				}
			}
				
			public System.String EmployeeID
			{
				get
				{
					System.Int32? data = entity.EmployeeID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EmployeeID = null;
					else entity.EmployeeID = Convert.ToInt32(value);
				}
			}
			

			private esOrder entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
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
		
        [IgnoreDataMember]
		private OrderQuery query;		
	}



	[Serializable]
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



	[Serializable]
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
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray); }
		} 
		
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, OrderMetadata.ColumnNames.EmployeeID, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Order : esOrder
	{

		#region UpToProductCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_OrderItem_Order
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_OrderItem_Order
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
		/// Foreign Key Name - FK_OrderItem_Order
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
		/// Foreign Key Name - FK_OrderItem_Order
		/// </summary>

		[XmlIgnore]
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

				
		#region UpToCustomerByCustID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Orders_Customers
		/// </summary>

		[XmlIgnore]
					
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
		/// Foreign Key Name - FK_Order_Employee
		/// </summary>

		[XmlIgnore]
					
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
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Order")]
	[XmlType(TypeName="OrderProxyStub")]	
	[Serializable]
	public partial class OrderProxyStub
	{
		public OrderProxyStub() 
		{
			theEntity = this.entity = new Order();
		}

		public OrderProxyStub(Order obj)
		{
			theEntity = this.entity = obj;
		}

		public OrderProxyStub(Order obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Order(OrderProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Order);
		}

		[DataMember(Name="OrderID", Order=1, EmitDefaultValue=false)]
		public System.Int32? OrderID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(OrderMetadata.ColumnNames.OrderID);
				else
					return this.Entity.OrderID;
			}
			set { this.Entity.OrderID = value; }
		}

		[DataMember(Name="CustID", Order=2, EmitDefaultValue=false)]
		public System.String CustID
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderMetadata.ColumnNames.CustID))
					return this.Entity.CustID;
				else
					return null;
			}
			set { this.Entity.CustID = value; }
		}

		[DataMember(Name="CustSub", Order=3, EmitDefaultValue=false)]
		public System.String CustSub
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderMetadata.ColumnNames.CustSub))
					return this.Entity.CustSub;
				else
					return null;
			}
			set { this.Entity.CustSub = value; }
		}

		[DataMember(Name="PlacedBy", Order=4, EmitDefaultValue=false)]
		public System.String PlacedBy
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderMetadata.ColumnNames.PlacedBy))
					return this.Entity.PlacedBy;
				else
					return null;
			}
			set { this.Entity.PlacedBy = value; }
		}

		[DataMember(Name="OrderDate", Order=5, EmitDefaultValue=false)]
		public System.DateTime? OrderDate
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderMetadata.ColumnNames.OrderDate))
					return this.Entity.OrderDate;
				else
					return null;
			}
			set { this.Entity.OrderDate = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=6, EmitDefaultValue=false)]
		public System.Byte[] ConcurrencyCheck
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderMetadata.ColumnNames.ConcurrencyCheck))
					return this.Entity.ConcurrencyCheck;
				else
					return null;
			}
			set { this.Entity.ConcurrencyCheck = value; }
		}

		[DataMember(Name="EmployeeID", Order=7, EmitDefaultValue=false)]
		public System.Int32? EmployeeID
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrderMetadata.ColumnNames.EmployeeID))
					return this.Entity.EmployeeID;
				else
					return null;
			}
			set { this.Entity.EmployeeID = value; }
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
		public Order Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Order();
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
		public Order entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OrderCollection")]
	[XmlType(TypeName="OrderCollectionProxyStub")]	
	[Serializable]
	public partial class OrderCollectionProxyStub 
	{
		protected OrderCollectionProxyStub() {}
		
		public OrderCollectionProxyStub(esEntityCollection<Order> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public OrderCollectionProxyStub(esEntityCollection<Order> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator OrderCollection(OrderCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Order);
		}
		
		public OrderCollectionProxyStub(esEntityCollection<Order> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Order entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new OrderProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new OrderProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Order entity in coll.es.DeletedEntities)
				{
					Collection.Add(new OrderProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<OrderProxyStub> Collection = new List<OrderProxyStub>();

		public OrderCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new OrderCollection();

				foreach (OrderProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private OrderCollection _coll;
	}



	[Serializable]
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
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrderMetadata.ColumnNames.ConcurrencyCheck, 5, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = OrderMetadata.PropertyNames.ConcurrencyCheck;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
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
				meta.AddTypeMap("CustID", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("CustSub", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("PlacedBy", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("OrderDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("varbinary", "System.Byte[]"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Order";
				meta.Destination = "Order";
				
				meta.spInsert = "proc_OrderInsert";				
				meta.spUpdate = "proc_OrderUpdate";		
				meta.spDelete = "proc_OrderDelete";
				meta.spLoadAll = "proc_OrderLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrderLoadByPrimaryKey";
				
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
