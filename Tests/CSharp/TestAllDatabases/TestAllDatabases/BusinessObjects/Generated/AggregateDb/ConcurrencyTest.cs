
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
	/// Encapsulates the 'ConcurrencyTest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(ConcurrencyTest))]	
	[XmlType("ConcurrencyTest")]
	[Table(Name="ConcurrencyTest")]
	public partial class ConcurrencyTest : esConcurrencyTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ConcurrencyTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String id)
		{
			var obj = new ConcurrencyTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String id, esSqlAccessType sqlAccessType)
		{
			var obj = new ConcurrencyTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ConcurrencyTestProxyStub(ConcurrencyTest entity)
		{
			return new ConcurrencyTestProxyStub(entity);
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
		public override System.String Name
		{
			get { return base.Name;  }
			set { base.Name = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int64? ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ConcurrencyTestCollection")]
	public partial class ConcurrencyTestCollection : esConcurrencyTestCollection, IEnumerable<ConcurrencyTest>
	{
		public ConcurrencyTest FindByPrimaryKey(System.String id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator ConcurrencyTestCollectionProxyStub(ConcurrencyTestCollection coll)
		{
			return new ConcurrencyTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ConcurrencyTest))]
		public class ConcurrencyTestCollectionWCFPacket : esCollectionWCFPacket<ConcurrencyTestCollection>
		{
			public static implicit operator ConcurrencyTestCollection(ConcurrencyTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ConcurrencyTestCollectionWCFPacket(ConcurrencyTestCollection collection)
			{
				return new ConcurrencyTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ConcurrencyTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ConcurrencyTestQuery : esConcurrencyTestQuery
	{
		public ConcurrencyTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ConcurrencyTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ConcurrencyTestQuery query)
		{
			return ConcurrencyTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ConcurrencyTestQuery(string query)
		{
			return (ConcurrencyTestQuery)ConcurrencyTestQuery.SerializeHelper.FromXml(query, typeof(ConcurrencyTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esConcurrencyTest : EntityBase
	{
		public esConcurrencyTest()
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
			ConcurrencyTestQuery query = new ConcurrencyTestQuery();
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
		/// Maps to ConcurrencyTest.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Id
		{
			get
			{
				return base.GetSystemString(ConcurrencyTestMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemString(ConcurrencyTestMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTest.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(ConcurrencyTestMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(ConcurrencyTestMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTest.ConcurrencyCheck
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? ConcurrencyCheck
		{
			get
			{
				return base.GetSystemInt64(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemInt64(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.ConcurrencyCheck);
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
						case "Name": this.str().Name = (string)value; break;							
						case "ConcurrencyCheck": this.str().ConcurrencyCheck = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Int64)
								this.ConcurrencyCheck = (System.Int64?)value;
								OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.ConcurrencyCheck);
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
			public esStrings(esConcurrencyTest entity)
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
				
			public System.String Name
			{
				get
				{
					System.String data = entity.Name;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Name = null;
					else entity.Name = Convert.ToString(value);
				}
			}
				
			public System.String ConcurrencyCheck
			{
				get
				{
					System.Int64? data = entity.ConcurrencyCheck;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ConcurrencyCheck = null;
					else entity.ConcurrencyCheck = Convert.ToInt64(value);
				}
			}
			

			private esConcurrencyTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ConcurrencyTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ConcurrencyTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ConcurrencyTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ConcurrencyTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ConcurrencyTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ConcurrencyTestQuery query;		
	}



	[Serializable]
	abstract public partial class esConcurrencyTestCollection : CollectionBase<ConcurrencyTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ConcurrencyTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ConcurrencyTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ConcurrencyTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ConcurrencyTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ConcurrencyTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ConcurrencyTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ConcurrencyTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ConcurrencyTestQuery)query);
		}

		#endregion
		
		private ConcurrencyTestQuery query;
	}



	[Serializable]
	abstract public partial class esConcurrencyTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ConcurrencyTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "Name": return this.Name;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, ConcurrencyTestMetadata.ColumnNames.Id, esSystemType.String); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, ConcurrencyTestMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int64); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTest")]
	[XmlType(TypeName="ConcurrencyTestProxyStub")]	
	[Serializable]
	public partial class ConcurrencyTestProxyStub
	{
		public ConcurrencyTestProxyStub() 
		{
			theEntity = this.entity = new ConcurrencyTest();
		}

		public ConcurrencyTestProxyStub(ConcurrencyTest obj)
		{
			theEntity = this.entity = obj;
		}

		public ConcurrencyTestProxyStub(ConcurrencyTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator ConcurrencyTest(ConcurrencyTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(ConcurrencyTest);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.String Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(ConcurrencyTestMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="Name", Order=2, EmitDefaultValue=false)]
		public System.String Name
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestMetadata.ColumnNames.Name))
					return this.Entity.Name;
				else
					return null;
			}
			set { this.Entity.Name = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=3, EmitDefaultValue=false)]
		public System.Int64? ConcurrencyCheck
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck))
					return this.Entity.ConcurrencyCheck;
				else
					return null;
			}
			set { this.Entity.ConcurrencyCheck = value; }
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
		public ConcurrencyTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new ConcurrencyTest();
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
		public ConcurrencyTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTestCollection")]
	[XmlType(TypeName="ConcurrencyTestCollectionProxyStub")]	
	[Serializable]
	public partial class ConcurrencyTestCollectionProxyStub 
	{
		protected ConcurrencyTestCollectionProxyStub() {}
		
		public ConcurrencyTestCollectionProxyStub(esEntityCollection<ConcurrencyTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ConcurrencyTestCollectionProxyStub(esEntityCollection<ConcurrencyTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ConcurrencyTestCollection(ConcurrencyTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(ConcurrencyTest);
		}
		
		public ConcurrencyTestCollectionProxyStub(esEntityCollection<ConcurrencyTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (ConcurrencyTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ConcurrencyTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ConcurrencyTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (ConcurrencyTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ConcurrencyTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ConcurrencyTestProxyStub> Collection = new List<ConcurrencyTestProxyStub>();

		public ConcurrencyTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ConcurrencyTestCollection();

				foreach (ConcurrencyTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ConcurrencyTestCollection _coll;
	}



	[Serializable]
	public partial class ConcurrencyTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ConcurrencyTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ConcurrencyTestMetadata.ColumnNames.Id, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = ConcurrencyTestMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestMetadata.ColumnNames.Name, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ConcurrencyTestMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 20;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck, 2, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = ConcurrencyTestMetadata.PropertyNames.ConcurrencyCheck;
			c.NumericPrecision = 19;
			c.IsEntitySpacesConcurrency = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ConcurrencyTestMetadata Meta()
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
			 public const string Name = "Name";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Name = "Name";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
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
			lock (typeof(ConcurrencyTestMetadata))
			{
				if(ConcurrencyTestMetadata.mapDelegates == null)
				{
					ConcurrencyTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ConcurrencyTestMetadata.meta == null)
				{
					ConcurrencyTestMetadata.meta = new ConcurrencyTestMetadata();
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
				meta.AddTypeMap("Name", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("bigint", "System.Int64"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "ConcurrencyTest";
				meta.Destination = "ConcurrencyTest";
				
				meta.spInsert = "proc_ConcurrencyTestInsert";				
				meta.spUpdate = "proc_ConcurrencyTestUpdate";		
				meta.spDelete = "proc_ConcurrencyTestDelete";
				meta.spLoadAll = "proc_ConcurrencyTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ConcurrencyTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
