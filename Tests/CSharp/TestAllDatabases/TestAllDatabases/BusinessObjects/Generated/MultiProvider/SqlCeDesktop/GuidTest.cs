
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:51 AM
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
	/// Encapsulates the 'GuidTest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(GuidTest))]	
	[XmlType("GuidTest")]
	[Table(Name="GuidTest")]
	public partial class GuidTest : esGuidTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new GuidTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid guidKey)
		{
			var obj = new GuidTest();
			obj.GuidKey = guidKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid guidKey, esSqlAccessType sqlAccessType)
		{
			var obj = new GuidTest();
			obj.GuidKey = guidKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator GuidTestProxyStub(GuidTest entity)
		{
			return new GuidTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Guid? GuidKey
		{
			get { return base.GuidKey;  }
			set { base.GuidKey = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Guid? GuidNonKey
		{
			get { return base.GuidNonKey;  }
			set { base.GuidNonKey = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Guid? GuidRowGuid
		{
			get { return base.GuidRowGuid;  }
			set { base.GuidRowGuid = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("GuidTestCollection")]
	public partial class GuidTestCollection : esGuidTestCollection, IEnumerable<GuidTest>
	{
		public GuidTest FindByPrimaryKey(System.Guid guidKey)
		{
			return this.SingleOrDefault(e => e.GuidKey == guidKey);
		}

		#region Implicit Casts
		
		public static implicit operator GuidTestCollectionProxyStub(GuidTestCollection coll)
		{
			return new GuidTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(GuidTest))]
		public class GuidTestCollectionWCFPacket : esCollectionWCFPacket<GuidTestCollection>
		{
			public static implicit operator GuidTestCollection(GuidTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator GuidTestCollectionWCFPacket(GuidTestCollection collection)
			{
				return new GuidTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "GuidTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class GuidTestQuery : esGuidTestQuery
	{
		public GuidTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "GuidTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(GuidTestQuery query)
		{
			return GuidTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator GuidTestQuery(string query)
		{
			return (GuidTestQuery)GuidTestQuery.SerializeHelper.FromXml(query, typeof(GuidTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esGuidTest : esEntity
	{
		public esGuidTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid guidKey)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(guidKey);
			else
				return LoadByPrimaryKeyStoredProcedure(guidKey);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid guidKey)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(guidKey);
			else
				return LoadByPrimaryKeyStoredProcedure(guidKey);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid guidKey)
		{
			GuidTestQuery query = new GuidTestQuery();
			query.Where(query.GuidKey == guidKey);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid guidKey)
		{
			esParameters parms = new esParameters();
			parms.Add("GuidKey", guidKey);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to GuidTest.GuidKey
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? GuidKey
		{
			get
			{
				return base.GetSystemGuid(GuidTestMetadata.ColumnNames.GuidKey);
			}
			
			set
			{
				if(base.SetSystemGuid(GuidTestMetadata.ColumnNames.GuidKey, value))
				{
					OnPropertyChanged(GuidTestMetadata.PropertyNames.GuidKey);
				}
			}
		}		
		
		/// <summary>
		/// Maps to GuidTest.GuidNonKey
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? GuidNonKey
		{
			get
			{
				return base.GetSystemGuid(GuidTestMetadata.ColumnNames.GuidNonKey);
			}
			
			set
			{
				if(base.SetSystemGuid(GuidTestMetadata.ColumnNames.GuidNonKey, value))
				{
					OnPropertyChanged(GuidTestMetadata.PropertyNames.GuidNonKey);
				}
			}
		}		
		
		/// <summary>
		/// Maps to GuidTest.GuidRowGuid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? GuidRowGuid
		{
			get
			{
				return base.GetSystemGuid(GuidTestMetadata.ColumnNames.GuidRowGuid);
			}
			
			set
			{
				if(base.SetSystemGuid(GuidTestMetadata.ColumnNames.GuidRowGuid, value))
				{
					OnPropertyChanged(GuidTestMetadata.PropertyNames.GuidRowGuid);
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
						case "GuidKey": this.str().GuidKey = (string)value; break;							
						case "GuidNonKey": this.str().GuidNonKey = (string)value; break;							
						case "GuidRowGuid": this.str().GuidRowGuid = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "GuidKey":
						
							if (value == null || value is System.Guid)
								this.GuidKey = (System.Guid?)value;
								OnPropertyChanged(GuidTestMetadata.PropertyNames.GuidKey);
							break;
						
						case "GuidNonKey":
						
							if (value == null || value is System.Guid)
								this.GuidNonKey = (System.Guid?)value;
								OnPropertyChanged(GuidTestMetadata.PropertyNames.GuidNonKey);
							break;
						
						case "GuidRowGuid":
						
							if (value == null || value is System.Guid)
								this.GuidRowGuid = (System.Guid?)value;
								OnPropertyChanged(GuidTestMetadata.PropertyNames.GuidRowGuid);
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
			public esStrings(esGuidTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String GuidKey
			{
				get
				{
					System.Guid? data = entity.GuidKey;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GuidKey = null;
					else entity.GuidKey = new Guid(value);
				}
			}
				
			public System.String GuidNonKey
			{
				get
				{
					System.Guid? data = entity.GuidNonKey;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GuidNonKey = null;
					else entity.GuidNonKey = new Guid(value);
				}
			}
				
			public System.String GuidRowGuid
			{
				get
				{
					System.Guid? data = entity.GuidRowGuid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GuidRowGuid = null;
					else entity.GuidRowGuid = new Guid(value);
				}
			}
			

			private esGuidTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return GuidTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public GuidTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GuidTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GuidTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(GuidTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private GuidTestQuery query;		
	}



	[Serializable]
	abstract public partial class esGuidTestCollection : esEntityCollection<GuidTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return GuidTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "GuidTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public GuidTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GuidTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GuidTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GuidTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(GuidTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((GuidTestQuery)query);
		}

		#endregion
		
		private GuidTestQuery query;
	}



	[Serializable]
	abstract public partial class esGuidTestQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return GuidTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "GuidKey": return this.GuidKey;
				case "GuidNonKey": return this.GuidNonKey;
				case "GuidRowGuid": return this.GuidRowGuid;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem GuidKey
		{
			get { return new esQueryItem(this, GuidTestMetadata.ColumnNames.GuidKey, esSystemType.Guid); }
		} 
		
		public esQueryItem GuidNonKey
		{
			get { return new esQueryItem(this, GuidTestMetadata.ColumnNames.GuidNonKey, esSystemType.Guid); }
		} 
		
		public esQueryItem GuidRowGuid
		{
			get { return new esQueryItem(this, GuidTestMetadata.ColumnNames.GuidRowGuid, esSystemType.Guid); }
		} 
		
		#endregion
		
	}


	
	public partial class GuidTest : esGuidTest
	{

		
		
	}
	



	
	[XmlType(TypeName="GuidTestProxyStub")]	
	[Serializable]
	public partial class GuidTestProxyStub
	{
		public GuidTestProxyStub() 
		{
			theEntity = this.entity = new GuidTest();
		}

		public GuidTestProxyStub(GuidTest obj)
		{
			theEntity = this.entity = obj;
		}

		public GuidTestProxyStub(GuidTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator GuidTest(GuidTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(GuidTest);
		}

		
		public System.Guid? GuidKey
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Guid?)this.Entity.
						GetOriginalColumnValue(GuidTestMetadata.ColumnNames.GuidKey);
				else
					return this.Entity.GuidKey;
			}
			set { this.Entity.GuidKey = value; }
		}

		
		public System.Guid? GuidNonKey
		{
			get 
			{ 
				
				if (this.IncludeColumn(GuidTestMetadata.ColumnNames.GuidNonKey))
					return this.Entity.GuidNonKey;
				else
					return null;
			}
			set { this.Entity.GuidNonKey = value; }
		}

		
		public System.Guid? GuidRowGuid
		{
			get 
			{ 
				
				if (this.IncludeColumn(GuidTestMetadata.ColumnNames.GuidRowGuid))
					return this.Entity.GuidRowGuid;
				else
					return null;
			}
			set { this.Entity.GuidRowGuid = value; }
		}


		
		public string esRowState
		{
			get { return TheRowState;  }
			set { TheRowState = value; }
		}
		
		
		private List<string> ModifiedColumns
		{
			get { return Entity.es.ModifiedColumns; }
			set 
			{ 
				Entity.es.ModifiedColumns.AddRange(value); 
			}
		}
		
		
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
		public GuidTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new GuidTest();
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
		public GuidTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	
	[XmlType(TypeName="GuidTestCollectionProxyStub")]	
	[Serializable]
	public partial class GuidTestCollectionProxyStub 
	{
		protected GuidTestCollectionProxyStub() {}
		
		public GuidTestCollectionProxyStub(esEntityCollection<GuidTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public GuidTestCollectionProxyStub(esEntityCollection<GuidTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator GuidTestCollection(GuidTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(GuidTest);
		}
		
		public GuidTestCollectionProxyStub(esEntityCollection<GuidTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (GuidTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new GuidTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new GuidTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (GuidTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new GuidTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		
		public List<GuidTestProxyStub> Collection = new List<GuidTestProxyStub>();

		public GuidTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new GuidTestCollection();

				foreach (GuidTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private GuidTestCollection _coll;
	}



	[Serializable]
	public partial class GuidTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected GuidTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(GuidTestMetadata.ColumnNames.GuidKey, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = GuidTestMetadata.PropertyNames.GuidKey;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"newid()";
			m_columns.Add(c);
				
			c = new esColumnMetadata(GuidTestMetadata.ColumnNames.GuidNonKey, 1, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = GuidTestMetadata.PropertyNames.GuidNonKey;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GuidTestMetadata.ColumnNames.GuidRowGuid, 2, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = GuidTestMetadata.PropertyNames.GuidRowGuid;
			c.HasDefault = true;
			c.Default = @"newid()";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public GuidTestMetadata Meta()
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
			 public const string GuidKey = "GuidKey";
			 public const string GuidNonKey = "GuidNonKey";
			 public const string GuidRowGuid = "GuidRowGuid";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GuidKey = "GuidKey";
			 public const string GuidNonKey = "GuidNonKey";
			 public const string GuidRowGuid = "GuidRowGuid";
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
			lock (typeof(GuidTestMetadata))
			{
				if(GuidTestMetadata.mapDelegates == null)
				{
					GuidTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GuidTestMetadata.meta == null)
				{
					GuidTestMetadata.meta = new GuidTestMetadata();
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


				meta.AddTypeMap("GuidKey", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("GuidNonKey", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("GuidRowGuid", new esTypeMap("uniqueidentifier", "System.Guid"));			
				meta.Catalog = "GuidTestDb.sdf";
				
				
				meta.Source = "GuidTest";
				meta.Destination = "GuidTest";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private GuidTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
