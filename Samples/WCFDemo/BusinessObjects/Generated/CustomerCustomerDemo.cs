
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:27 PM
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
	/// Encapsulates the 'CustomerCustomerDemo' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(CustomerCustomerDemo))]	
	[XmlType("CustomerCustomerDemo")]
	public partial class CustomerCustomerDemo : esCustomerCustomerDemo
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new CustomerCustomerDemo();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String customerID, System.String customerTypeID)
		{
			var obj = new CustomerCustomerDemo();
			obj.CustomerID = customerID;
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String customerID, System.String customerTypeID, esSqlAccessType sqlAccessType)
		{
			var obj = new CustomerCustomerDemo();
			obj.CustomerID = customerID;
			obj.CustomerTypeID = customerTypeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator CustomerCustomerDemoProxyStub(CustomerCustomerDemo entity)
		{
			return new CustomerCustomerDemoProxyStub(entity);
		}

		#endregion
		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomerCustomerDemoCollection")]
	public partial class CustomerCustomerDemoCollection : esCustomerCustomerDemoCollection, IEnumerable<CustomerCustomerDemo>
	{
		public CustomerCustomerDemo FindByPrimaryKey(System.String customerID, System.String customerTypeID)
		{
			return this.SingleOrDefault(e => e.CustomerID == customerID && e.CustomerTypeID == customerTypeID);
		}

		#region Implicit Casts
		
		public static implicit operator CustomerCustomerDemoCollectionProxyStub(CustomerCustomerDemoCollection coll)
		{
			return new CustomerCustomerDemoCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(CustomerCustomerDemo))]
		public class CustomerCustomerDemoCollectionWCFPacket : esCollectionWCFPacket<CustomerCustomerDemoCollection>
		{
			public static implicit operator CustomerCustomerDemoCollection(CustomerCustomerDemoCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomerCustomerDemoCollectionWCFPacket(CustomerCustomerDemoCollection collection)
			{
				return new CustomerCustomerDemoCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]
	[DataContract(Name = "CustomerCustomerDemoQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CustomerCustomerDemoQuery : esCustomerCustomerDemoQuery
	{
		public CustomerCustomerDemoQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomerCustomerDemoQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomerCustomerDemoQuery query)
		{
			return CustomerCustomerDemoQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomerCustomerDemoQuery(string query)
		{
			return (CustomerCustomerDemoQuery)CustomerCustomerDemoQuery.SerializeHelper.FromXml(query, typeof(CustomerCustomerDemoQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomerCustomerDemo : esEntity
	{
		public esCustomerCustomerDemo()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String customerID, System.String customerTypeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID, customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String customerID, System.String customerTypeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID, customerTypeID);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String customerID, System.String customerTypeID)
		{
			CustomerCustomerDemoQuery query = new CustomerCustomerDemoQuery();
			query.Where(query.CustomerID == customerID, query.CustomerTypeID == customerTypeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String customerID, System.String customerTypeID)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerID", customerID);			parms.Add("CustomerTypeID", customerTypeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to CustomerCustomerDemo.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomerID
		{
			get
			{
				return base.GetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerID);
			}
			
			set
			{
				if(base.SetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerID, value))
				{
					this._UpToCustomersByCustomerID = null;
					this.OnPropertyChanged("UpToCustomersByCustomerID");
					OnPropertyChanged(CustomerCustomerDemoMetadata.PropertyNames.CustomerID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomerCustomerDemo.CustomerTypeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomerTypeID
		{
			get
			{
				return base.GetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID);
			}
			
			set
			{
				if(base.SetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, value))
				{
					this._UpToCustomerDemographicsByCustomerTypeID = null;
					this.OnPropertyChanged("UpToCustomerDemographicsByCustomerTypeID");
					OnPropertyChanged(CustomerCustomerDemoMetadata.PropertyNames.CustomerTypeID);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected CustomerDemographics _UpToCustomerDemographicsByCustomerTypeID;
		[CLSCompliant(false)]
		internal protected Customers _UpToCustomersByCustomerID;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomerCustomerDemoMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomerCustomerDemoQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerCustomerDemoQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerCustomerDemoQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomerCustomerDemoQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomerCustomerDemoQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomerCustomerDemoCollection : esEntityCollection<CustomerCustomerDemo>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomerCustomerDemoMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomerCustomerDemoCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomerCustomerDemoQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerCustomerDemoQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerCustomerDemoQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomerCustomerDemoQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomerCustomerDemoQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomerCustomerDemoQuery)query);
		}

		#endregion
		
		private CustomerCustomerDemoQuery query;
	}



	[Serializable]
	abstract public partial class esCustomerCustomerDemoQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomerCustomerDemoMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CustomerID": return this.CustomerID;
				case "CustomerTypeID": return this.CustomerTypeID;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, CustomerCustomerDemoMetadata.ColumnNames.CustomerID, esSystemType.String); }
		} 
		
		public esQueryItem CustomerTypeID
		{
			get { return new esQueryItem(this, CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class CustomerCustomerDemo : esCustomerCustomerDemo
	{

				
		#region UpToCustomerDemographicsByCustomerTypeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_CustomerCustomerDemo
		/// </summary>

		[XmlIgnore]
					
		public CustomerDemographics UpToCustomerDemographicsByCustomerTypeID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCustomerDemographicsByCustomerTypeID == null && CustomerTypeID != null)
				{
					this._UpToCustomerDemographicsByCustomerTypeID = new CustomerDemographics();
					this._UpToCustomerDemographicsByCustomerTypeID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomerDemographicsByCustomerTypeID", this._UpToCustomerDemographicsByCustomerTypeID);
					this._UpToCustomerDemographicsByCustomerTypeID.Query.Where(this._UpToCustomerDemographicsByCustomerTypeID.Query.CustomerTypeID == this.CustomerTypeID);
					this._UpToCustomerDemographicsByCustomerTypeID.Query.Load();
				}	
				return this._UpToCustomerDemographicsByCustomerTypeID;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomerDemographicsByCustomerTypeID");
				
				bool changed = this._UpToCustomerDemographicsByCustomerTypeID != value;

				if(value == null)
				{
					this.CustomerTypeID = null;
					this._UpToCustomerDemographicsByCustomerTypeID = null;
				}
				else
				{
					this.CustomerTypeID = value.CustomerTypeID;
					this._UpToCustomerDemographicsByCustomerTypeID = value;
					this.SetPreSave("UpToCustomerDemographicsByCustomerTypeID", this._UpToCustomerDemographicsByCustomerTypeID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCustomerDemographicsByCustomerTypeID");
				}
			}
		}
		#endregion
		

				
		#region UpToCustomersByCustomerID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_CustomerCustomerDemo_Customers
		/// </summary>

		[XmlIgnore]
					
		public Customers UpToCustomersByCustomerID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCustomersByCustomerID == null && CustomerID != null)
				{
					this._UpToCustomersByCustomerID = new Customers();
					this._UpToCustomersByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomersByCustomerID", this._UpToCustomersByCustomerID);
					this._UpToCustomersByCustomerID.Query.Where(this._UpToCustomersByCustomerID.Query.CustomerID == this.CustomerID);
					this._UpToCustomersByCustomerID.Query.Load();
				}	
				return this._UpToCustomersByCustomerID;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomersByCustomerID");
				
				bool changed = this._UpToCustomersByCustomerID != value;

				if(value == null)
				{
					this.CustomerID = null;
					this._UpToCustomersByCustomerID = null;
				}
				else
				{
					this.CustomerID = value.CustomerID;
					this._UpToCustomersByCustomerID = value;
					this.SetPreSave("UpToCustomersByCustomerID", this._UpToCustomersByCustomerID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCustomersByCustomerID");
				}
			}
		}
		#endregion
		

		
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerCustomerDemo")]
	[XmlType(TypeName="CustomerCustomerDemoProxyStub")]	
	[Serializable]
	public partial class CustomerCustomerDemoProxyStub
	{
		public CustomerCustomerDemoProxyStub() 
		{
			theEntity = this.entity = new CustomerCustomerDemo();
		}

		public CustomerCustomerDemoProxyStub(CustomerCustomerDemo obj)
		{
			theEntity = this.entity = obj;
		}

		public CustomerCustomerDemoProxyStub(CustomerCustomerDemo obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator CustomerCustomerDemo(CustomerCustomerDemoProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(CustomerCustomerDemo);
		}

		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
		public System.String CustomerID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CustomerCustomerDemoMetadata.ColumnNames.CustomerID);
				else
					return this.Entity.CustomerID;
			}
			set { this.Entity.CustomerID = value; }
		}

		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String CustomerTypeID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID);
				else
					return this.Entity.CustomerTypeID;
			}
			set { this.Entity.CustomerTypeID = value; }
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
		public CustomerCustomerDemo Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new CustomerCustomerDemo();
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
		public CustomerCustomerDemo entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerCustomerDemoCollection")]
	[XmlType(TypeName="CustomerCustomerDemoCollectionProxyStub")]	
	[Serializable]
	public partial class CustomerCustomerDemoCollectionProxyStub 
	{
		protected CustomerCustomerDemoCollectionProxyStub() {}
		
		public CustomerCustomerDemoCollectionProxyStub(esEntityCollection<CustomerCustomerDemo> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public CustomerCustomerDemoCollectionProxyStub(esEntityCollection<CustomerCustomerDemo> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator CustomerCustomerDemoCollection(CustomerCustomerDemoCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(CustomerCustomerDemo);
		}
		
		public CustomerCustomerDemoCollectionProxyStub(esEntityCollection<CustomerCustomerDemo> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (CustomerCustomerDemo entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new CustomerCustomerDemoProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new CustomerCustomerDemoProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (CustomerCustomerDemo entity in coll.es.DeletedEntities)
				{
					Collection.Add(new CustomerCustomerDemoProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<CustomerCustomerDemoProxyStub> Collection = new List<CustomerCustomerDemoProxyStub>();

		public CustomerCustomerDemoCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new CustomerCustomerDemoCollection();

				foreach (CustomerCustomerDemoProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private CustomerCustomerDemoCollection _coll;
	}



	[Serializable]
	public partial class CustomerCustomerDemoMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomerCustomerDemoMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomerCustomerDemoMetadata.ColumnNames.CustomerID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerCustomerDemoMetadata.PropertyNames.CustomerID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerCustomerDemoMetadata.PropertyNames.CustomerTypeID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CustomerCustomerDemoMetadata Meta()
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
			 public const string CustomerTypeID = "CustomerTypeID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerID = "CustomerID";
			 public const string CustomerTypeID = "CustomerTypeID";
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
			lock (typeof(CustomerCustomerDemoMetadata))
			{
				if(CustomerCustomerDemoMetadata.mapDelegates == null)
				{
					CustomerCustomerDemoMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerCustomerDemoMetadata.meta == null)
				{
					CustomerCustomerDemoMetadata.meta = new CustomerCustomerDemoMetadata();
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
				meta.AddTypeMap("CustomerTypeID", new esTypeMap("nchar", "System.String"));			
				
				
				
				meta.Source = "CustomerCustomerDemo";
				meta.Destination = "CustomerCustomerDemo";
				
				meta.spInsert = "proc_CustomerCustomerDemoInsert";				
				meta.spUpdate = "proc_CustomerCustomerDemoUpdate";		
				meta.spDelete = "proc_CustomerCustomerDemoDelete";
				meta.spLoadAll = "proc_CustomerCustomerDemoLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerCustomerDemoLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomerCustomerDemoMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
