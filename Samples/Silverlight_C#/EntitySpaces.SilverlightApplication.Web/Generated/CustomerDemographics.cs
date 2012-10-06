
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
	/// Encapsulates the 'CustomerDemographics' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(CustomerDemographics))]	
	[XmlType("CustomerDemographics")]
	public partial class CustomerDemographics : esCustomerDemographics
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new CustomerDemographics();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String customerTypeID)
		{
			var obj = new CustomerDemographics();
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String customerTypeID, esSqlAccessType sqlAccessType)
		{
			var obj = new CustomerDemographics();
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator CustomerDemographicsProxyStub(CustomerDemographics entity)
		{
			return new CustomerDemographicsProxyStub(entity);
		}

		#endregion
		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomerDemographicsCollection")]
	public partial class CustomerDemographicsCollection : esCustomerDemographicsCollection, IEnumerable<CustomerDemographics>
	{
		public CustomerDemographics FindByPrimaryKey(System.String customerTypeID)
		{
			return this.SingleOrDefault(e => e.CustomerTypeID == customerTypeID);
		}

		#region Implicit Casts
		
		public static implicit operator CustomerDemographicsCollectionProxyStub(CustomerDemographicsCollection coll)
		{
			return new CustomerDemographicsCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(CustomerDemographics))]
		public class CustomerDemographicsCollectionWCFPacket : esCollectionWCFPacket<CustomerDemographicsCollection>
		{
			public static implicit operator CustomerDemographicsCollection(CustomerDemographicsCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomerDemographicsCollectionWCFPacket(CustomerDemographicsCollection collection)
			{
				return new CustomerDemographicsCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]
	[DataContract(Name = "CustomerDemographicsQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CustomerDemographicsQuery : esCustomerDemographicsQuery
	{
		public CustomerDemographicsQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomerDemographicsQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomerDemographicsQuery query)
		{
			return CustomerDemographicsQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomerDemographicsQuery(string query)
		{
			return (CustomerDemographicsQuery)CustomerDemographicsQuery.SerializeHelper.FromXml(query, typeof(CustomerDemographicsQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomerDemographics : esEntity
	{
		public esCustomerDemographics()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String customerTypeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerTypeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String customerTypeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerTypeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String customerTypeID)
		{
			CustomerDemographicsQuery query = new CustomerDemographicsQuery();
			query.Where(query.CustomerTypeID == customerTypeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String customerTypeID)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerTypeID", customerTypeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to CustomerDemographics.CustomerTypeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomerTypeID
		{
			get
			{
				return base.GetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerTypeID);
			}
			
			set
			{
				if(base.SetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerTypeID, value))
				{
					OnPropertyChanged(CustomerDemographicsMetadata.PropertyNames.CustomerTypeID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomerDemographics.CustomerDesc
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomerDesc
		{
			get
			{
				return base.GetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerDesc);
			}
			
			set
			{
				if(base.SetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerDesc, value))
				{
					OnPropertyChanged(CustomerDemographicsMetadata.PropertyNames.CustomerDesc);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomerDemographicsMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomerDemographicsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerDemographicsQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerDemographicsQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomerDemographicsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomerDemographicsQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomerDemographicsCollection : esEntityCollection<CustomerDemographics>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomerDemographicsMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomerDemographicsCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomerDemographicsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerDemographicsQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerDemographicsQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomerDemographicsQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomerDemographicsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomerDemographicsQuery)query);
		}

		#endregion
		
		private CustomerDemographicsQuery query;
	}



	[Serializable]
	abstract public partial class esCustomerDemographicsQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomerDemographicsMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CustomerTypeID": return this.CustomerTypeID;
				case "CustomerDesc": return this.CustomerDesc;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerTypeID
		{
			get { return new esQueryItem(this, CustomerDemographicsMetadata.ColumnNames.CustomerTypeID, esSystemType.String); }
		} 
		
		public esQueryItem CustomerDesc
		{
			get { return new esQueryItem(this, CustomerDemographicsMetadata.ColumnNames.CustomerDesc, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class CustomerDemographics : esCustomerDemographics
	{

		#region UpToCustomersCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>

		[XmlIgnore]
		public CustomersCollection UpToCustomersCollection
		{
			get
			{
				if(this._UpToCustomersCollection == null)
				{
					this._UpToCustomersCollection = new CustomersCollection();
					this._UpToCustomersCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToCustomersCollection", this._UpToCustomersCollection);
					if (!this.es.IsLazyLoadDisabled && this.CustomerTypeID != null)
					{
						CustomersQuery m = new CustomersQuery("m");
						CustomerCustomerDemoQuery j = new CustomerCustomerDemoQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.CustomerID == j.CustomerID);
                        m.Where(j.CustomerTypeID == this.CustomerTypeID);

						this._UpToCustomersCollection.Load(m);
					}
				}

				return this._UpToCustomersCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToCustomersCollection != null) 
				{ 
					this.RemovePostSave("UpToCustomersCollection"); 
					this._UpToCustomersCollection = null;
					this.OnPropertyChanged("UpToCustomersCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>
		public void AssociateCustomersCollection(Customers entity)
		{
			if (this._CustomerCustomerDemoCollection == null)
			{
				this._CustomerCustomerDemoCollection = new CustomerCustomerDemoCollection();
				this._CustomerCustomerDemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomerCustomerDemoCollection", this._CustomerCustomerDemoCollection);
			}

			CustomerCustomerDemo obj = this._CustomerCustomerDemoCollection.AddNew();
			obj.CustomerTypeID = this.CustomerTypeID;
			obj.CustomerID = entity.CustomerID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>
		public void DissociateCustomersCollection(Customers entity)
		{
			if (this._CustomerCustomerDemoCollection == null)
			{
				this._CustomerCustomerDemoCollection = new CustomerCustomerDemoCollection();
				this._CustomerCustomerDemoCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("CustomerCustomerDemoCollection", this._CustomerCustomerDemoCollection);
			}

			CustomerCustomerDemo obj = this._CustomerCustomerDemoCollection.AddNew();
			obj.CustomerTypeID = this.CustomerTypeID;
            obj.CustomerID = entity.CustomerID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private CustomersCollection _UpToCustomersCollection;
		private CustomerCustomerDemoCollection _CustomerCustomerDemoCollection;
		#endregion

		#region CustomerCustomerDemoCollectionByCustomerTypeID - Zero To Many
		
		static public esPrefetchMap Prefetch_CustomerCustomerDemoCollectionByCustomerTypeID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.CustomerDemographics.CustomerCustomerDemoCollectionByCustomerTypeID_Delegate;
				map.PropertyName = "CustomerCustomerDemoCollectionByCustomerTypeID";
				map.MyColumnName = "CustomerTypeID";
				map.ParentColumnName = "CustomerTypeID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CustomerCustomerDemoCollectionByCustomerTypeID_Delegate(esPrefetchParameters data)
		{
			CustomerDemographicsQuery parent = new CustomerDemographicsQuery(data.NextAlias());

			CustomerCustomerDemoQuery me = data.You != null ? data.You as CustomerCustomerDemoQuery : new CustomerCustomerDemoQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CustomerTypeID == me.CustomerTypeID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>

		[XmlIgnore]
		public CustomerCustomerDemoCollection CustomerCustomerDemoCollectionByCustomerTypeID
		{
			get
			{
				if(this._CustomerCustomerDemoCollectionByCustomerTypeID == null)
				{
					this._CustomerCustomerDemoCollectionByCustomerTypeID = new CustomerCustomerDemoCollection();
					this._CustomerCustomerDemoCollectionByCustomerTypeID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CustomerCustomerDemoCollectionByCustomerTypeID", this._CustomerCustomerDemoCollectionByCustomerTypeID);
				
					if (this.CustomerTypeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CustomerCustomerDemoCollectionByCustomerTypeID.Query.Where(this._CustomerCustomerDemoCollectionByCustomerTypeID.Query.CustomerTypeID == this.CustomerTypeID);
							this._CustomerCustomerDemoCollectionByCustomerTypeID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CustomerCustomerDemoCollectionByCustomerTypeID.fks.Add(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, this.CustomerTypeID);
					}
				}

				return this._CustomerCustomerDemoCollectionByCustomerTypeID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CustomerCustomerDemoCollectionByCustomerTypeID != null) 
				{ 
					this.RemovePostSave("CustomerCustomerDemoCollectionByCustomerTypeID"); 
					this._CustomerCustomerDemoCollectionByCustomerTypeID = null;
					this.OnPropertyChanged("CustomerCustomerDemoCollectionByCustomerTypeID");
				} 
			} 			
		}
			
		
		private CustomerCustomerDemoCollection _CustomerCustomerDemoCollectionByCustomerTypeID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "CustomerCustomerDemoCollectionByCustomerTypeID":
					coll = this.CustomerCustomerDemoCollectionByCustomerTypeID;
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
			
			props.Add(new esPropertyDescriptor(this, "CustomerCustomerDemoCollectionByCustomerTypeID", typeof(CustomerCustomerDemoCollection), new CustomerCustomerDemo()));
		
			return props;
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerDemographics")]
	[XmlType(TypeName="CustomerDemographicsProxyStub")]	
	[Serializable]
	public partial class CustomerDemographicsProxyStub
	{
		public CustomerDemographicsProxyStub() 
		{
			theEntity = this.entity = new CustomerDemographics();
		}

		public CustomerDemographicsProxyStub(CustomerDemographics obj)
		{
			theEntity = this.entity = obj;
		}

		public CustomerDemographicsProxyStub(CustomerDemographics obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator CustomerDemographics(CustomerDemographicsProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(CustomerDemographics);
		}

		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
		public System.String CustomerTypeID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CustomerDemographicsMetadata.ColumnNames.CustomerTypeID);
				else
					return this.Entity.CustomerTypeID;
			}
			set { this.Entity.CustomerTypeID = value; }
		}

		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String CustomerDesc
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerDemographicsMetadata.ColumnNames.CustomerDesc))
					return this.Entity.CustomerDesc;
				else
					return null;
			}
			set { this.Entity.CustomerDesc = value; }
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
		public CustomerDemographics Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new CustomerDemographics();
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
		public CustomerDemographics entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerDemographicsCollection")]
	[XmlType(TypeName="CustomerDemographicsCollectionProxyStub")]	
	[Serializable]
	public partial class CustomerDemographicsCollectionProxyStub 
	{
		protected CustomerDemographicsCollectionProxyStub() {}
		
		public CustomerDemographicsCollectionProxyStub(esEntityCollection<CustomerDemographics> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public CustomerDemographicsCollectionProxyStub(esEntityCollection<CustomerDemographics> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator CustomerDemographicsCollection(CustomerDemographicsCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(CustomerDemographics);
		}
		
		public CustomerDemographicsCollectionProxyStub(esEntityCollection<CustomerDemographics> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (CustomerDemographics entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new CustomerDemographicsProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new CustomerDemographicsProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (CustomerDemographics entity in coll.es.DeletedEntities)
				{
					Collection.Add(new CustomerDemographicsProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<CustomerDemographicsProxyStub> Collection = new List<CustomerDemographicsProxyStub>();

		public CustomerDemographicsCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new CustomerDemographicsCollection();

				foreach (CustomerDemographicsProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private CustomerDemographicsCollection _coll;
	}



	[Serializable]
	public partial class CustomerDemographicsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomerDemographicsMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomerDemographicsMetadata.ColumnNames.CustomerTypeID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerDemographicsMetadata.PropertyNames.CustomerTypeID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerDemographicsMetadata.ColumnNames.CustomerDesc, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerDemographicsMetadata.PropertyNames.CustomerDesc;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CustomerDemographicsMetadata Meta()
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
			 public const string CustomerTypeID = "CustomerTypeID";
			 public const string CustomerDesc = "CustomerDesc";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerTypeID = "CustomerTypeID";
			 public const string CustomerDesc = "CustomerDesc";
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
			lock (typeof(CustomerDemographicsMetadata))
			{
				if(CustomerDemographicsMetadata.mapDelegates == null)
				{
					CustomerDemographicsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerDemographicsMetadata.meta == null)
				{
					CustomerDemographicsMetadata.meta = new CustomerDemographicsMetadata();
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


				meta.AddTypeMap("CustomerTypeID", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("CustomerDesc", new esTypeMap("ntext", "System.String"));			
				
				
				
				meta.Source = "CustomerDemographics";
				meta.Destination = "CustomerDemographics";
				
				meta.spInsert = "proc_CustomerDemographicsInsert";				
				meta.spUpdate = "proc_CustomerDemographicsUpdate";		
				meta.spDelete = "proc_CustomerDemographicsDelete";
				meta.spLoadAll = "proc_CustomerDemographicsLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerDemographicsLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomerDemographicsMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
