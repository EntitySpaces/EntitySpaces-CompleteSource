
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:14 PM
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
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Customers' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Customers))]	
	[XmlType("Customers")]
	public partial class Customers : esCustomers
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Customers();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String customerID)
		{
			var obj = new Customers();
			obj.CustomerID = customerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String customerID, esSqlAccessType sqlAccessType)
		{
			var obj = new Customers();
			obj.CustomerID = customerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator CustomersProxyStub(Customers entity)
		{
			return new CustomersProxyStub(entity);
		}

		#endregion
		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomersCollection")]
	public partial class CustomersCollection : esCustomersCollection, IEnumerable<Customers>
	{
		public Customers FindByPrimaryKey(System.String customerID)
		{
			return this.SingleOrDefault(e => e.CustomerID == customerID);
		}

		#region Implicit Casts
		
		public static implicit operator CustomersCollectionProxyStub(CustomersCollection coll)
		{
			return new CustomersCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Customers))]
		public class CustomersCollectionWCFPacket : esCollectionWCFPacket<CustomersCollection>
		{
			public static implicit operator CustomersCollection(CustomersCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomersCollectionWCFPacket(CustomersCollection collection)
			{
				return new CustomersCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]
	[DataContract(Name = "CustomersQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CustomersQuery : esCustomersQuery
	{
		public CustomersQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomersQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomersQuery query)
		{
			return CustomersQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomersQuery(string query)
		{
			return (CustomersQuery)CustomersQuery.SerializeHelper.FromXml(query, typeof(CustomersQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomers : esEntity
	{
		public esCustomers()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String customerID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String customerID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String customerID)
		{
			CustomersQuery query = new CustomersQuery();
			query.Where(query.CustomerID == customerID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String customerID)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerID", customerID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Customers.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomerID
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.CustomerID);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.CustomerID, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.CustomerID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.CompanyName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CompanyName
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.CompanyName);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.CompanyName, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.CompanyName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.ContactName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ContactName
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.ContactName);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.ContactName, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.ContactName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.ContactTitle
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ContactTitle
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.ContactTitle);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.ContactTitle, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.ContactTitle);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.Address
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Address
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Address);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.Address, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.Address);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.City
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String City
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.City);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.City, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.City);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.Region
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Region
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Region);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.Region, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.Region);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.PostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String PostalCode
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.PostalCode);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.PostalCode, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.PostalCode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.Country
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Country
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Country);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.Country, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.Country);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.Phone
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Phone
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Phone);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.Phone, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.Phone);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customers.Fax
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Fax
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Fax);
			}
			
			set
			{
				if(base.SetSystemString(CustomersMetadata.ColumnNames.Fax, value))
				{
					OnPropertyChanged(CustomersMetadata.PropertyNames.Fax);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomersMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomersQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomersQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomersQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomersQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomersQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomersCollection : esEntityCollection<Customers>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomersMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomersCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomersQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomersQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomersQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomersQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomersQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomersQuery)query);
		}

		#endregion
		
		private CustomersQuery query;
	}



	[Serializable]
	abstract public partial class esCustomersQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomersMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CustomerID": return this.CustomerID;
				case "CompanyName": return this.CompanyName;
				case "ContactName": return this.ContactName;
				case "ContactTitle": return this.ContactTitle;
				case "Address": return this.Address;
				case "City": return this.City;
				case "Region": return this.Region;
				case "PostalCode": return this.PostalCode;
				case "Country": return this.Country;
				case "Phone": return this.Phone;
				case "Fax": return this.Fax;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.CustomerID, esSystemType.String); }
		} 
		
		public esQueryItem CompanyName
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.CompanyName, esSystemType.String); }
		} 
		
		public esQueryItem ContactName
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.ContactName, esSystemType.String); }
		} 
		
		public esQueryItem ContactTitle
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.ContactTitle, esSystemType.String); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.Address, esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.City, esSystemType.String); }
		} 
		
		public esQueryItem Region
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.Region, esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.PostalCode, esSystemType.String); }
		} 
		
		public esQueryItem Country
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.Country, esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.Phone, esSystemType.String); }
		} 
		
		public esQueryItem Fax
		{
			get { return new esQueryItem(this, CustomersMetadata.ColumnNames.Fax, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Customers : esCustomers
	{

		#region UpToCustomerDemographicsCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>

		[XmlIgnore]
		public CustomerDemographicsCollection UpToCustomerDemographicsCollection
		{
			get
			{
				if(this._UpToCustomerDemographicsCollection == null)
				{
					this._UpToCustomerDemographicsCollection = new CustomerDemographicsCollection();
					this._UpToCustomerDemographicsCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToCustomerDemographicsCollection", this._UpToCustomerDemographicsCollection);
					if (!this.es.IsLazyLoadDisabled && this.CustomerID != null)
					{
						CustomerDemographicsQuery m = new CustomerDemographicsQuery("m");
						CustomerCustomerDemoQuery j = new CustomerCustomerDemoQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.CustomerTypeID == j.CustomerTypeID);
                        m.Where(j.CustomerID == this.CustomerID);

						this._UpToCustomerDemographicsCollection.Load(m);
					}
				}

				return this._UpToCustomerDemographicsCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToCustomerDemographicsCollection != null) 
				{ 
					this.RemovePostSave("UpToCustomerDemographicsCollection"); 
					this._UpToCustomerDemographicsCollection = null;
					this.OnPropertyChanged("UpToCustomerDemographicsCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>
		public void AssociateCustomerDemographicsCollection(CustomerDemographics entity)
		{
			if (this._CustomerCustomerDemoCollection == null)
			{
				this._CustomerCustomerDemoCollection = new CustomerCustomerDemoCollection();
				this._CustomerCustomerDemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomerCustomerDemoCollection", this._CustomerCustomerDemoCollection);
			}

			CustomerCustomerDemo obj = this._CustomerCustomerDemoCollection.AddNew();
			obj.CustomerID = this.CustomerID;
			obj.CustomerTypeID = entity.CustomerTypeID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>
		public void DissociateCustomerDemographicsCollection(CustomerDemographics entity)
		{
			if (this._CustomerCustomerDemoCollection == null)
			{
				this._CustomerCustomerDemoCollection = new CustomerCustomerDemoCollection();
				this._CustomerCustomerDemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomerCustomerDemoCollection", this._CustomerCustomerDemoCollection);
			}

			CustomerCustomerDemo obj = this._CustomerCustomerDemoCollection.AddNew();
			obj.CustomerID = this.CustomerID;
            obj.CustomerTypeID = entity.CustomerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private CustomerDemographicsCollection _UpToCustomerDemographicsCollection;
		private CustomerCustomerDemoCollection _CustomerCustomerDemoCollection;
		#endregion

		#region CustomerCustomerDemoCollectionByCustomerID - Zero To Many
		
		static public esPrefetchMap Prefetch_CustomerCustomerDemoCollectionByCustomerID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Customers.CustomerCustomerDemoCollectionByCustomerID_Delegate;
				map.PropertyName = "CustomerCustomerDemoCollectionByCustomerID";
				map.MyColumnName = "CustomerID";
				map.ParentColumnName = "CustomerID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CustomerCustomerDemoCollectionByCustomerID_Delegate(esPrefetchParameters data)
		{
			CustomersQuery parent = new CustomersQuery(data.NextAlias());

			CustomerCustomerDemoQuery me = data.You != null ? data.You as CustomerCustomerDemoQuery : new CustomerCustomerDemoQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CustomerID == me.CustomerID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>

		[XmlIgnore]
		public CustomerCustomerDemoCollection CustomerCustomerDemoCollectionByCustomerID
		{
			get
			{
				if(this._CustomerCustomerDemoCollectionByCustomerID == null)
				{
					this._CustomerCustomerDemoCollectionByCustomerID = new CustomerCustomerDemoCollection();
					this._CustomerCustomerDemoCollectionByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CustomerCustomerDemoCollectionByCustomerID", this._CustomerCustomerDemoCollectionByCustomerID);
				
					if (this.CustomerID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CustomerCustomerDemoCollectionByCustomerID.Query.Where(this._CustomerCustomerDemoCollectionByCustomerID.Query.CustomerID == this.CustomerID);
							this._CustomerCustomerDemoCollectionByCustomerID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CustomerCustomerDemoCollectionByCustomerID.fks.Add(CustomerCustomerDemoMetadata.ColumnNames.CustomerID, this.CustomerID);
					}
				}

				return this._CustomerCustomerDemoCollectionByCustomerID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CustomerCustomerDemoCollectionByCustomerID != null) 
				{ 
					this.RemovePostSave("CustomerCustomerDemoCollectionByCustomerID"); 
					this._CustomerCustomerDemoCollectionByCustomerID = null;
					this.OnPropertyChanged("CustomerCustomerDemoCollectionByCustomerID");
				} 
			} 			
		}
			
		
		private CustomerCustomerDemoCollection _CustomerCustomerDemoCollectionByCustomerID;
		#endregion

		#region OrdersCollectionByCustomerID - Zero To Many
		
		static public esPrefetchMap Prefetch_OrdersCollectionByCustomerID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Customers.OrdersCollectionByCustomerID_Delegate;
				map.PropertyName = "OrdersCollectionByCustomerID";
				map.MyColumnName = "CustomerID";
				map.ParentColumnName = "CustomerID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void OrdersCollectionByCustomerID_Delegate(esPrefetchParameters data)
		{
			CustomersQuery parent = new CustomersQuery(data.NextAlias());

			OrdersQuery me = data.You != null ? data.You as OrdersQuery : new OrdersQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CustomerID == me.CustomerID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Orders_Customers
		/// </summary>

		[XmlIgnore]
		public OrdersCollection OrdersCollectionByCustomerID
		{
			get
			{
				if(this._OrdersCollectionByCustomerID == null)
				{
					this._OrdersCollectionByCustomerID = new OrdersCollection();
					this._OrdersCollectionByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("OrdersCollectionByCustomerID", this._OrdersCollectionByCustomerID);
				
					if (this.CustomerID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._OrdersCollectionByCustomerID.Query.Where(this._OrdersCollectionByCustomerID.Query.CustomerID == this.CustomerID);
							this._OrdersCollectionByCustomerID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._OrdersCollectionByCustomerID.fks.Add(OrdersMetadata.ColumnNames.CustomerID, this.CustomerID);
					}
				}

				return this._OrdersCollectionByCustomerID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._OrdersCollectionByCustomerID != null) 
				{ 
					this.RemovePostSave("OrdersCollectionByCustomerID"); 
					this._OrdersCollectionByCustomerID = null;
					this.OnPropertyChanged("OrdersCollectionByCustomerID");
				} 
			} 			
		}
			
		
		private OrdersCollection _OrdersCollectionByCustomerID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "CustomerCustomerDemoCollectionByCustomerID":
					coll = this.CustomerCustomerDemoCollectionByCustomerID;
					break;
				case "OrdersCollectionByCustomerID":
					coll = this.OrdersCollectionByCustomerID;
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
			
			props.Add(new esPropertyDescriptor(this, "CustomerCustomerDemoCollectionByCustomerID", typeof(CustomerCustomerDemoCollection), new CustomerCustomerDemo()));
			props.Add(new esPropertyDescriptor(this, "OrdersCollectionByCustomerID", typeof(OrdersCollection), new Orders()));
		
			return props;
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Customers")]
	[XmlType(TypeName="CustomersProxyStub")]	
	[Serializable]
	public partial class CustomersProxyStub
	{
		public CustomersProxyStub() 
		{
			theEntity = this.entity = new Customers();
		}

		public CustomersProxyStub(Customers obj)
		{
			theEntity = this.entity = obj;
		}

		public CustomersProxyStub(Customers obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Customers(CustomersProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Customers);
		}

		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
		public System.String CustomerID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CustomersMetadata.ColumnNames.CustomerID);
				else
					return this.Entity.CustomerID;
			}
			set { this.Entity.CustomerID = value; }
		}

		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String CompanyName
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.CompanyName))
					return this.Entity.CompanyName;
				else
					return null;
			}
			set { this.Entity.CompanyName = value; }
		}

		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
		public System.String ContactName
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.ContactName))
					return this.Entity.ContactName;
				else
					return null;
			}
			set { this.Entity.ContactName = value; }
		}

		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
		public System.String ContactTitle
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.ContactTitle))
					return this.Entity.ContactTitle;
				else
					return null;
			}
			set { this.Entity.ContactTitle = value; }
		}

		[DataMember(Name="a4", Order=5, EmitDefaultValue=false)]
		public System.String Address
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.Address))
					return this.Entity.Address;
				else
					return null;
			}
			set { this.Entity.Address = value; }
		}

		[DataMember(Name="a5", Order=6, EmitDefaultValue=false)]
		public System.String City
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.City))
					return this.Entity.City;
				else
					return null;
			}
			set { this.Entity.City = value; }
		}

		[DataMember(Name="a6", Order=7, EmitDefaultValue=false)]
		public System.String Region
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.Region))
					return this.Entity.Region;
				else
					return null;
			}
			set { this.Entity.Region = value; }
		}

		[DataMember(Name="a7", Order=8, EmitDefaultValue=false)]
		public System.String PostalCode
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.PostalCode))
					return this.Entity.PostalCode;
				else
					return null;
			}
			set { this.Entity.PostalCode = value; }
		}

		[DataMember(Name="a8", Order=9, EmitDefaultValue=false)]
		public System.String Country
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.Country))
					return this.Entity.Country;
				else
					return null;
			}
			set { this.Entity.Country = value; }
		}

		[DataMember(Name="a9", Order=10, EmitDefaultValue=false)]
		public System.String Phone
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.Phone))
					return this.Entity.Phone;
				else
					return null;
			}
			set { this.Entity.Phone = value; }
		}

		[DataMember(Name="a10", Order=11, EmitDefaultValue=false)]
		public System.String Fax
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomersMetadata.ColumnNames.Fax))
					return this.Entity.Fax;
				else
					return null;
			}
			set { this.Entity.Fax = value; }
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
		public Customers Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Customers();
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
		public Customers entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomersCollection")]
	[XmlType(TypeName="CustomersCollectionProxyStub")]	
	[Serializable]
	public partial class CustomersCollectionProxyStub 
	{
		protected CustomersCollectionProxyStub() {}
		
		public CustomersCollectionProxyStub(esEntityCollection<Customers> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public CustomersCollectionProxyStub(esEntityCollection<Customers> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator CustomersCollection(CustomersCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Customers);
		}
		
		public CustomersCollectionProxyStub(esEntityCollection<Customers> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Customers entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new CustomersProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new CustomersProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Customers entity in coll.es.DeletedEntities)
				{
					Collection.Add(new CustomersProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<CustomersProxyStub> Collection = new List<CustomersProxyStub>();

		public CustomersCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new CustomersCollection();

				foreach (CustomersProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private CustomersCollection _coll;
	}



	[Serializable]
	public partial class CustomersMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomersMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomersMetadata.ColumnNames.CustomerID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.CustomerID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.CompanyName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.CompanyName;
			c.CharacterMaxLength = 40;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.ContactName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.ContactName;
			c.CharacterMaxLength = 30;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.ContactTitle, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.ContactTitle;
			c.CharacterMaxLength = 30;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Address, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Address;
			c.CharacterMaxLength = 60;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.City, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.City;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Region, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Region;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.PostalCode, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.PostalCode;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Country, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Country;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Phone, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Phone;
			c.CharacterMaxLength = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Fax, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Fax;
			c.CharacterMaxLength = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CustomersMetadata Meta()
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
			 public const string CustomerID = "CustomerID";
			 public const string CompanyName = "CompanyName";
			 public const string ContactName = "ContactName";
			 public const string ContactTitle = "ContactTitle";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string Region = "Region";
			 public const string PostalCode = "PostalCode";
			 public const string Country = "Country";
			 public const string Phone = "Phone";
			 public const string Fax = "Fax";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerID = "CustomerID";
			 public const string CompanyName = "CompanyName";
			 public const string ContactName = "ContactName";
			 public const string ContactTitle = "ContactTitle";
			 public const string Address = "Address";
			 public const string City = "City";
			 public const string Region = "Region";
			 public const string PostalCode = "PostalCode";
			 public const string Country = "Country";
			 public const string Phone = "Phone";
			 public const string Fax = "Fax";
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
			lock (typeof(CustomersMetadata))
			{
				if(CustomersMetadata.mapDelegates == null)
				{
					CustomersMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomersMetadata.meta == null)
				{
					CustomersMetadata.meta = new CustomersMetadata();
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


				meta.AddTypeMap("CustomerID", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("CompanyName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ContactName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ContactTitle", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Region", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Country", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Fax", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Customers";
				meta.Destination = "Customers";
				
				meta.spInsert = "proc_CustomersInsert";				
				meta.spUpdate = "proc_CustomersUpdate";		
				meta.spDelete = "proc_CustomersDelete";
				meta.spLoadAll = "proc_CustomersLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomersLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomersMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
