
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:43:27 AM
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
	/// Encapsulates the 'CustomerGroup' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(CustomerGroup))]	
	[XmlType("CustomerGroup")]
	[Table(Name="CustomerGroup")]
	public partial class CustomerGroup : esCustomerGroup
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new CustomerGroup();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String groupID)
		{
			var obj = new CustomerGroup();
			obj.GroupID = groupID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String groupID, esSqlAccessType sqlAccessType)
		{
			var obj = new CustomerGroup();
			obj.GroupID = groupID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator CustomerGroupProxyStub(CustomerGroup entity)
		{
			return new CustomerGroupProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String GroupID
		{
			get { return base.GroupID;  }
			set { base.GroupID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String GroupName
		{
			get { return base.GroupName;  }
			set { base.GroupName = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomerGroupCollection")]
	public partial class CustomerGroupCollection : esCustomerGroupCollection, IEnumerable<CustomerGroup>
	{
		public CustomerGroup FindByPrimaryKey(System.String groupID)
		{
			return this.SingleOrDefault(e => e.GroupID == groupID);
		}

		#region Implicit Casts
		
		public static implicit operator CustomerGroupCollectionProxyStub(CustomerGroupCollection coll)
		{
			return new CustomerGroupCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(CustomerGroup))]
		public class CustomerGroupCollectionWCFPacket : esCollectionWCFPacket<CustomerGroupCollection>
		{
			public static implicit operator CustomerGroupCollection(CustomerGroupCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomerGroupCollectionWCFPacket(CustomerGroupCollection collection)
			{
				return new CustomerGroupCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "CustomerGroupQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CustomerGroupQuery : esCustomerGroupQuery
	{
		public CustomerGroupQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomerGroupQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomerGroupQuery query)
		{
			return CustomerGroupQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomerGroupQuery(string query)
		{
			return (CustomerGroupQuery)CustomerGroupQuery.SerializeHelper.FromXml(query, typeof(CustomerGroupQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomerGroup : esEntity
	{
		public esCustomerGroup()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String groupID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(groupID);
			else
				return LoadByPrimaryKeyStoredProcedure(groupID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String groupID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(groupID);
			else
				return LoadByPrimaryKeyStoredProcedure(groupID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String groupID)
		{
			CustomerGroupQuery query = new CustomerGroupQuery();
			query.Where(query.GroupID == groupID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String groupID)
		{
			esParameters parms = new esParameters();
			parms.Add("GroupID", groupID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to CustomerGroup.GroupID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String GroupID
		{
			get
			{
				return base.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupID);
			}
			
			set
			{
				if(base.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupID, value))
				{
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomerGroup.GroupName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String GroupName
		{
			get
			{
				return base.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupName);
			}
			
			set
			{
				if(base.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupName, value))
				{
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupName);
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
						case "GroupID": this.str().GroupID = (string)value; break;							
						case "GroupName": this.str().GroupName = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{

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
			public esStrings(esCustomerGroup entity)
			{
				this.entity = entity;
			}
			
	
			public System.String GroupID
			{
				get
				{
					System.String data = entity.GroupID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GroupID = null;
					else entity.GroupID = Convert.ToString(value);
				}
			}
				
			public System.String GroupName
			{
				get
				{
					System.String data = entity.GroupName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GroupName = null;
					else entity.GroupName = Convert.ToString(value);
				}
			}
			

			private esCustomerGroup entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomerGroupMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomerGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerGroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerGroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomerGroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomerGroupQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomerGroupCollection : esEntityCollection<CustomerGroup>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomerGroupMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomerGroupCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomerGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerGroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerGroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomerGroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomerGroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomerGroupQuery)query);
		}

		#endregion
		
		private CustomerGroupQuery query;
	}



	[Serializable]
	abstract public partial class esCustomerGroupQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomerGroupMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "GroupID": return this.GroupID;
				case "GroupName": return this.GroupName;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem GroupID
		{
			get { return new esQueryItem(this, CustomerGroupMetadata.ColumnNames.GroupID, esSystemType.String); }
		} 
		
		public esQueryItem GroupName
		{
			get { return new esQueryItem(this, CustomerGroupMetadata.ColumnNames.GroupName, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class CustomerGroup : esCustomerGroup
	{

		#region CustomerCollectionByCustomerID - Zero To Many
		
		static public esPrefetchMap Prefetch_CustomerCollectionByCustomerID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.CustomerGroup.CustomerCollectionByCustomerID_Delegate;
				map.PropertyName = "CustomerCollectionByCustomerID";
				map.MyColumnName = "CustomerID";
				map.ParentColumnName = "GroupID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CustomerCollectionByCustomerID_Delegate(esPrefetchParameters data)
		{
			CustomerGroupQuery parent = new CustomerGroupQuery(data.NextAlias());

			CustomerQuery me = data.You != null ? data.You as CustomerQuery : new CustomerQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.GroupID == me.CustomerID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Customer_CustomerGroup
		/// </summary>

		[XmlIgnore]
		public CustomerCollection CustomerCollectionByCustomerID
		{
			get
			{
				if(this._CustomerCollectionByCustomerID == null)
				{
					this._CustomerCollectionByCustomerID = new CustomerCollection();
					this._CustomerCollectionByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CustomerCollectionByCustomerID", this._CustomerCollectionByCustomerID);
				
					if (this.GroupID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CustomerCollectionByCustomerID.Query.Where(this._CustomerCollectionByCustomerID.Query.CustomerID == this.GroupID);
							this._CustomerCollectionByCustomerID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CustomerCollectionByCustomerID.fks.Add(CustomerMetadata.ColumnNames.CustomerID, this.GroupID);
					}
				}

				return this._CustomerCollectionByCustomerID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CustomerCollectionByCustomerID != null) 
				{ 
					this.RemovePostSave("CustomerCollectionByCustomerID"); 
					this._CustomerCollectionByCustomerID = null;
					this.OnPropertyChanged("CustomerCollectionByCustomerID");
				} 
			} 			
		}
			
		
		private CustomerCollection _CustomerCollectionByCustomerID;
		#endregion

				
		#region Group - One To One
		/// <summary>
		/// One to One
		/// Foreign Key Name - FK_Group_CustGroup
		/// </summary>

		[XmlIgnore]
		public Group Group
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._Group == null)
				{
					this._Group = new Group();
					this._Group.es.Connection.Name = this.es.Connection.Name;
					this.SetPostOneSave("Group", this._Group);
				
					if(this.GroupID != null)
					{
						this._Group.Query.Where(this._Group.Query.Id == this.GroupID);
						this._Group.Query.Load();
					}
				}

				return this._Group;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._Group != null) 
				{ 
					this.RemovePostOneSave("Group"); 
					this._Group = null;
					this.OnPropertyChanged("Group");
				} 
			}          			
		}
		
		
		private Group _Group;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "CustomerCollectionByCustomerID":
					coll = this.CustomerCollectionByCustomerID;
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
			
			props.Add(new esPropertyDescriptor(this, "CustomerCollectionByCustomerID", typeof(CustomerCollection), new Customer()));
		
			return props;
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerGroup")]
	[XmlType(TypeName="CustomerGroupProxyStub")]	
	[Serializable]
	public partial class CustomerGroupProxyStub
	{
		public CustomerGroupProxyStub() 
		{
			theEntity = this.entity = new CustomerGroup();
		}

		public CustomerGroupProxyStub(CustomerGroup obj)
		{
			theEntity = this.entity = obj;
		}

		public CustomerGroupProxyStub(CustomerGroup obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator CustomerGroup(CustomerGroupProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(CustomerGroup);
		}

		[DataMember(Name="GroupID", Order=1, EmitDefaultValue=false)]
		public System.String GroupID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CustomerGroupMetadata.ColumnNames.GroupID);
				else
					return this.Entity.GroupID;
			}
			set { this.Entity.GroupID = value; }
		}

		[DataMember(Name="GroupName", Order=2, EmitDefaultValue=false)]
		public System.String GroupName
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerGroupMetadata.ColumnNames.GroupName))
					return this.Entity.GroupName;
				else
					return null;
			}
			set { this.Entity.GroupName = value; }
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
		public CustomerGroup Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new CustomerGroup();
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
		public CustomerGroup entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerGroupCollection")]
	[XmlType(TypeName="CustomerGroupCollectionProxyStub")]	
	[Serializable]
	public partial class CustomerGroupCollectionProxyStub 
	{
		protected CustomerGroupCollectionProxyStub() {}
		
		public CustomerGroupCollectionProxyStub(esEntityCollection<CustomerGroup> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public CustomerGroupCollectionProxyStub(esEntityCollection<CustomerGroup> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator CustomerGroupCollection(CustomerGroupCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(CustomerGroup);
		}
		
		public CustomerGroupCollectionProxyStub(esEntityCollection<CustomerGroup> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (CustomerGroup entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new CustomerGroupProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new CustomerGroupProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (CustomerGroup entity in coll.es.DeletedEntities)
				{
					Collection.Add(new CustomerGroupProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<CustomerGroupProxyStub> Collection = new List<CustomerGroupProxyStub>();

		public CustomerGroupCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new CustomerGroupCollection();

				foreach (CustomerGroupProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private CustomerGroupCollection _coll;
	}



	[Serializable]
	public partial class CustomerGroupMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomerGroupMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CustomerGroupMetadata Meta()
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
			 public const string GroupID = "GroupID";
			 public const string GroupName = "GroupName";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GroupID = "GroupID";
			 public const string GroupName = "GroupName";
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
			lock (typeof(CustomerGroupMetadata))
			{
				if(CustomerGroupMetadata.mapDelegates == null)
				{
					CustomerGroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerGroupMetadata.meta == null)
				{
					CustomerGroupMetadata.meta = new CustomerGroupMetadata();
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


				meta.AddTypeMap("GroupID", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("GroupName", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "CustomerGroup";
				meta.Destination = "CustomerGroup";
				
				meta.spInsert = "proc_CustomerGroupInsert";				
				meta.spUpdate = "proc_CustomerGroupUpdate";		
				meta.spDelete = "proc_CustomerGroupDelete";
				meta.spLoadAll = "proc_CustomerGroupLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerGroupLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomerGroupMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
