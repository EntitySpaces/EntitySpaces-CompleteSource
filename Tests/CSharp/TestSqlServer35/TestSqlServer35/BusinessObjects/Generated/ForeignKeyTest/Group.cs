
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
	/// Encapsulates the 'Group' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Group))]	
	[XmlType("Group")]
	[Table(Name="Group")]
	public partial class Group : esGroup
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Group();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String id)
		{
			var obj = new Group();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String id, esSqlAccessType sqlAccessType)
		{
			var obj = new Group();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator GroupProxyStub(Group entity)
		{
			return new GroupProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String Notes
		{
			get { return base.Notes;  }
			set { base.Notes = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("GroupCollection")]
	public partial class GroupCollection : esGroupCollection, IEnumerable<Group>
	{
		public Group FindByPrimaryKey(System.String id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator GroupCollectionProxyStub(GroupCollection coll)
		{
			return new GroupCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Group))]
		public class GroupCollectionWCFPacket : esCollectionWCFPacket<GroupCollection>
		{
			public static implicit operator GroupCollection(GroupCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator GroupCollectionWCFPacket(GroupCollection collection)
			{
				return new GroupCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "GroupQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class GroupQuery : esGroupQuery
	{
		public GroupQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "GroupQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(GroupQuery query)
		{
			return GroupQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator GroupQuery(string query)
		{
			return (GroupQuery)GroupQuery.SerializeHelper.FromXml(query, typeof(GroupQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esGroup : esEntity
	{
		public esGroup()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.String id)
		{
			GroupQuery query = new GroupQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Group.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Id
		{
			get
			{
				return base.GetSystemString(GroupMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemString(GroupMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(GroupMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Group.Notes
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Notes
		{
			get
			{
				return base.GetSystemString(GroupMetadata.ColumnNames.Notes);
			}
			
			set
			{
				if(base.SetSystemString(GroupMetadata.ColumnNames.Notes, value))
				{
					OnPropertyChanged(GroupMetadata.PropertyNames.Notes);
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
						case "Id": this.str().Id = (string)value; break;							
						case "Notes": this.str().Notes = (string)value; break;
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
			public esStrings(esGroup entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.String data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToString(value);
				}
			}
				
			public System.String Notes
			{
				get
				{
					System.String data = entity.Notes;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Notes = null;
					else entity.Notes = Convert.ToString(value);
				}
			}
			

			private esGroup entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return GroupMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public GroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(GroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private GroupQuery query;		
	}



	[Serializable]
	abstract public partial class esGroupCollection : esEntityCollection<Group>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return GroupMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "GroupCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public GroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(GroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((GroupQuery)query);
		}

		#endregion
		
		private GroupQuery query;
	}



	[Serializable]
	abstract public partial class esGroupQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return GroupMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "Notes": return this.Notes;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, GroupMetadata.ColumnNames.Id, esSystemType.String); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, GroupMetadata.ColumnNames.Notes, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Group : esGroup
	{

		#region UpToCustomerGroup - One To One
		/// <summary>
		/// One to One
		/// Foreign Key Name - FK_Group_CustGroup
		/// </summary>

		[XmlIgnore]
		public CustomerGroup UpToCustomerGroup
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
			
				if(this._UpToCustomerGroup == null && Id != null)
				{
					this._UpToCustomerGroup = new CustomerGroup();
					this._UpToCustomerGroup.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomerGroup", this._UpToCustomerGroup);
					this._UpToCustomerGroup.Query.Where(this._UpToCustomerGroup.Query.GroupID == this.Id);
					this._UpToCustomerGroup.Query.Load();
				}

				return this._UpToCustomerGroup;
			}
			
			set 
			{ 
				this.RemovePreSave("UpToCustomerGroup");

				if(value == null)
				{
					this._UpToCustomerGroup = null;
				}
				else
				{
					this._UpToCustomerGroup = value;
					this.SetPreSave("UpToCustomerGroup", this._UpToCustomerGroup);
				}
				
				this.OnPropertyChanged("UpToCustomerGroup");
			} 
		}
				
		
		private CustomerGroup _UpToCustomerGroup;
		#endregion

		
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Group")]
	[XmlType(TypeName="GroupProxyStub")]	
	[Serializable]
	public partial class GroupProxyStub
	{
		public GroupProxyStub() 
		{
			theEntity = this.entity = new Group();
		}

		public GroupProxyStub(Group obj)
		{
			theEntity = this.entity = obj;
		}

		public GroupProxyStub(Group obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Group(GroupProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Group);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.String Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(GroupMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="Notes", Order=2, EmitDefaultValue=false)]
		public System.String Notes
		{
			get 
			{ 
				
				if (this.IncludeColumn(GroupMetadata.ColumnNames.Notes))
					return this.Entity.Notes;
				else
					return null;
			}
			set { this.Entity.Notes = value; }
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
		public Group Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Group();
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
		public Group entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "GroupCollection")]
	[XmlType(TypeName="GroupCollectionProxyStub")]	
	[Serializable]
	public partial class GroupCollectionProxyStub 
	{
		protected GroupCollectionProxyStub() {}
		
		public GroupCollectionProxyStub(esEntityCollection<Group> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public GroupCollectionProxyStub(esEntityCollection<Group> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator GroupCollection(GroupCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Group);
		}
		
		public GroupCollectionProxyStub(esEntityCollection<Group> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Group entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new GroupProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new GroupProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Group entity in coll.es.DeletedEntities)
				{
					Collection.Add(new GroupProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<GroupProxyStub> Collection = new List<GroupProxyStub>();

		public GroupCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new GroupCollection();

				foreach (GroupProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private GroupCollection _coll;
	}



	[Serializable]
	public partial class GroupMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected GroupMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(GroupMetadata.ColumnNames.Id, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GroupMetadata.ColumnNames.Notes, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 2147483647;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public GroupMetadata Meta()
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
			 public const string Id = "ID";
			 public const string Notes = "Notes";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Notes = "Notes";
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
			lock (typeof(GroupMetadata))
			{
				if(GroupMetadata.mapDelegates == null)
				{
					GroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GroupMetadata.meta == null)
				{
					GroupMetadata.meta = new GroupMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("text", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Group";
				meta.Destination = "Group";
				
				meta.spInsert = "proc_GroupInsert";				
				meta.spUpdate = "proc_GroupUpdate";		
				meta.spDelete = "proc_GroupDelete";
				meta.spLoadAll = "proc_GroupLoadAll";
				meta.spLoadByPrimaryKey = "proc_GroupLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private GroupMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
