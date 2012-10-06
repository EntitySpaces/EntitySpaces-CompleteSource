
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:54 AM
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
	/// Encapsulates the 'OracleXmlTest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(OracleXmlTest))]	
	[XmlType("OracleXmlTest")]
	[Table(Name="OracleXmlTest")]
	public partial class OracleXmlTest : esOracleXmlTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new OracleXmlTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String id)
		{
			var obj = new OracleXmlTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String id, esSqlAccessType sqlAccessType)
		{
			var obj = new OracleXmlTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator OracleXmlTestProxyStub(OracleXmlTest entity)
		{
			return new OracleXmlTestProxyStub(entity);
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
		public override System.String XmlColumn
		{
			get { return base.XmlColumn;  }
			set { base.XmlColumn = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("OracleXmlTestCollection")]
	public partial class OracleXmlTestCollection : esOracleXmlTestCollection, IEnumerable<OracleXmlTest>
	{
		public OracleXmlTest FindByPrimaryKey(System.String id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator OracleXmlTestCollectionProxyStub(OracleXmlTestCollection coll)
		{
			return new OracleXmlTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(OracleXmlTest))]
		public class OracleXmlTestCollectionWCFPacket : esCollectionWCFPacket<OracleXmlTestCollection>
		{
			public static implicit operator OracleXmlTestCollection(OracleXmlTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator OracleXmlTestCollectionWCFPacket(OracleXmlTestCollection collection)
			{
				return new OracleXmlTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "OracleXmlTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class OracleXmlTestQuery : esOracleXmlTestQuery
	{
		public OracleXmlTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "OracleXmlTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OracleXmlTestQuery query)
		{
			return OracleXmlTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OracleXmlTestQuery(string query)
		{
			return (OracleXmlTestQuery)OracleXmlTestQuery.SerializeHelper.FromXml(query, typeof(OracleXmlTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esOracleXmlTest : EntityBase
	{
		public esOracleXmlTest()
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
			OracleXmlTestQuery query = new OracleXmlTestQuery();
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
		/// Maps to OracleXmlTest.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Id
		{
			get
			{
				return base.GetSystemString(OracleXmlTestMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemString(OracleXmlTestMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(OracleXmlTestMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleXmlTest.XmlColumn
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String XmlColumn
		{
			get
			{
				return base.GetSystemString(OracleXmlTestMetadata.ColumnNames.XmlColumn);
			}
			
			set
			{
				if(base.SetSystemString(OracleXmlTestMetadata.ColumnNames.XmlColumn, value))
				{
					OnPropertyChanged(OracleXmlTestMetadata.PropertyNames.XmlColumn);
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
						case "XmlColumn": this.str().XmlColumn = (string)value; break;
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
			public esStrings(esOracleXmlTest entity)
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
				
			public System.String XmlColumn
			{
				get
				{
					System.String data = entity.XmlColumn;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.XmlColumn = null;
					else entity.XmlColumn = Convert.ToString(value);
				}
			}
			

			private esOracleXmlTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return OracleXmlTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public OracleXmlTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OracleXmlTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OracleXmlTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(OracleXmlTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private OracleXmlTestQuery query;		
	}



	[Serializable]
	abstract public partial class esOracleXmlTestCollection : CollectionBase<OracleXmlTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return OracleXmlTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "OracleXmlTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public OracleXmlTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OracleXmlTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OracleXmlTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new OracleXmlTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(OracleXmlTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((OracleXmlTestQuery)query);
		}

		#endregion
		
		private OracleXmlTestQuery query;
	}



	[Serializable]
	abstract public partial class esOracleXmlTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return OracleXmlTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "XmlColumn": return this.XmlColumn;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, OracleXmlTestMetadata.ColumnNames.Id, esSystemType.String); }
		} 
		
		public esQueryItem XmlColumn
		{
			get { return new esQueryItem(this, OracleXmlTestMetadata.ColumnNames.XmlColumn, esSystemType.String); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OracleXmlTest")]
	[XmlType(TypeName="OracleXmlTestProxyStub")]	
	[Serializable]
	public partial class OracleXmlTestProxyStub
	{
		public OracleXmlTestProxyStub() 
		{
			theEntity = this.entity = new OracleXmlTest();
		}

		public OracleXmlTestProxyStub(OracleXmlTest obj)
		{
			theEntity = this.entity = obj;
		}

		public OracleXmlTestProxyStub(OracleXmlTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator OracleXmlTest(OracleXmlTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(OracleXmlTest);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.String Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(OracleXmlTestMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="XmlColumn", Order=2, EmitDefaultValue=false)]
		public System.String XmlColumn
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleXmlTestMetadata.ColumnNames.XmlColumn))
					return this.Entity.XmlColumn;
				else
					return null;
			}
			set { this.Entity.XmlColumn = value; }
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
		public OracleXmlTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new OracleXmlTest();
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
		public OracleXmlTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OracleXmlTestCollection")]
	[XmlType(TypeName="OracleXmlTestCollectionProxyStub")]	
	[Serializable]
	public partial class OracleXmlTestCollectionProxyStub 
	{
		protected OracleXmlTestCollectionProxyStub() {}
		
		public OracleXmlTestCollectionProxyStub(esEntityCollection<OracleXmlTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public OracleXmlTestCollectionProxyStub(esEntityCollection<OracleXmlTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator OracleXmlTestCollection(OracleXmlTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(OracleXmlTest);
		}
		
		public OracleXmlTestCollectionProxyStub(esEntityCollection<OracleXmlTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (OracleXmlTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new OracleXmlTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new OracleXmlTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (OracleXmlTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new OracleXmlTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<OracleXmlTestProxyStub> Collection = new List<OracleXmlTestProxyStub>();

		public OracleXmlTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new OracleXmlTestCollection();

				foreach (OracleXmlTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private OracleXmlTestCollection _coll;
	}



	[Serializable]
	public partial class OracleXmlTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OracleXmlTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(OracleXmlTestMetadata.ColumnNames.Id, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = OracleXmlTestMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleXmlTestMetadata.ColumnNames.XmlColumn, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = OracleXmlTestMetadata.PropertyNames.XmlColumn;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public OracleXmlTestMetadata Meta()
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
			 public const string Id = "Id";
			 public const string XmlColumn = "XmlColumn";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string XmlColumn = "XmlColumn";
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
			lock (typeof(OracleXmlTestMetadata))
			{
				if(OracleXmlTestMetadata.mapDelegates == null)
				{
					OracleXmlTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OracleXmlTestMetadata.meta == null)
				{
					OracleXmlTestMetadata.meta = new OracleXmlTestMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("XmlColumn", new esTypeMap("XMLTYPE", "System.String"));			
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				
				meta.Source = "OracleXmlTest";
				meta.Destination = "OracleXmlTest";
				
				meta.spInsert = "esOracleXmlTestInsert";				
				meta.spUpdate = "esOracleXmlTestUpdate";		
				meta.spDelete = "esOracleXmlTestDelete";
				meta.spLoadAll = "esOracleXmlTestLoadAll";
				meta.spLoadByPrimaryKey = "esOracleXmlTestLoadByPK";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private OracleXmlTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
