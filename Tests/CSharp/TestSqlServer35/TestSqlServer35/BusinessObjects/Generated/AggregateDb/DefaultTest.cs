
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:36 AM
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
	/// Encapsulates the 'DefaultTest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(DefaultTest))]	
	[XmlType("DefaultTest")]
	[Table(Name="DefaultTest")]
	public partial class DefaultTest : esDefaultTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new DefaultTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 testId)
		{
			var obj = new DefaultTest();
			obj.TestId = testId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 testId, esSqlAccessType sqlAccessType)
		{
			var obj = new DefaultTest();
			obj.TestId = testId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator DefaultTestProxyStub(DefaultTest entity)
		{
			return new DefaultTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? TestId
		{
			get { return base.TestId;  }
			set { base.TestId = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int32? DefaultNotNullInt
		{
			get { return base.DefaultNotNullInt;  }
			set { base.DefaultNotNullInt = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Boolean? DefaultNotNullBool
		{
			get { return base.DefaultNotNullBool;  }
			set { base.DefaultNotNullBool = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("DefaultTestCollection")]
	public partial class DefaultTestCollection : esDefaultTestCollection, IEnumerable<DefaultTest>
	{
		public DefaultTest FindByPrimaryKey(System.Int32 testId)
		{
			return this.SingleOrDefault(e => e.TestId == testId);
		}

		#region Implicit Casts
		
		public static implicit operator DefaultTestCollectionProxyStub(DefaultTestCollection coll)
		{
			return new DefaultTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(DefaultTest))]
		public class DefaultTestCollectionWCFPacket : esCollectionWCFPacket<DefaultTestCollection>
		{
			public static implicit operator DefaultTestCollection(DefaultTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator DefaultTestCollectionWCFPacket(DefaultTestCollection collection)
			{
				return new DefaultTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "DefaultTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class DefaultTestQuery : esDefaultTestQuery
	{
		public DefaultTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "DefaultTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(DefaultTestQuery query)
		{
			return DefaultTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator DefaultTestQuery(string query)
		{
			return (DefaultTestQuery)DefaultTestQuery.SerializeHelper.FromXml(query, typeof(DefaultTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esDefaultTest : EntityBase
	{
		public esDefaultTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 testId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(testId);
			else
				return LoadByPrimaryKeyStoredProcedure(testId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 testId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(testId);
			else
				return LoadByPrimaryKeyStoredProcedure(testId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 testId)
		{
			DefaultTestQuery query = new DefaultTestQuery();
			query.Where(query.TestId == testId);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 testId)
		{
			esParameters parms = new esParameters();
			parms.Add("TestId", testId);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to DefaultTest.TestId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? TestId
		{
			get
			{
				return base.GetSystemInt32(DefaultTestMetadata.ColumnNames.TestId);
			}
			
			set
			{
				if(base.SetSystemInt32(DefaultTestMetadata.ColumnNames.TestId, value))
				{
					OnPropertyChanged(DefaultTestMetadata.PropertyNames.TestId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DefaultTest.DefaultNotNullInt
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? DefaultNotNullInt
		{
			get
			{
				return base.GetSystemInt32(DefaultTestMetadata.ColumnNames.DefaultNotNullInt);
			}
			
			set
			{
				if(base.SetSystemInt32(DefaultTestMetadata.ColumnNames.DefaultNotNullInt, value))
				{
					OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullInt);
				}
			}
		}		
		
		/// <summary>
		/// Maps to DefaultTest.DefaultNotNullBool
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? DefaultNotNullBool
		{
			get
			{
				return base.GetSystemBoolean(DefaultTestMetadata.ColumnNames.DefaultNotNullBool);
			}
			
			set
			{
				if(base.SetSystemBoolean(DefaultTestMetadata.ColumnNames.DefaultNotNullBool, value))
				{
					OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullBool);
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
						case "TestId": this.str().TestId = (string)value; break;							
						case "DefaultNotNullInt": this.str().DefaultNotNullInt = (string)value; break;							
						case "DefaultNotNullBool": this.str().DefaultNotNullBool = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TestId":
						
							if (value == null || value is System.Int32)
								this.TestId = (System.Int32?)value;
								OnPropertyChanged(DefaultTestMetadata.PropertyNames.TestId);
							break;
						
						case "DefaultNotNullInt":
						
							if (value == null || value is System.Int32)
								this.DefaultNotNullInt = (System.Int32?)value;
								OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullInt);
							break;
						
						case "DefaultNotNullBool":
						
							if (value == null || value is System.Boolean)
								this.DefaultNotNullBool = (System.Boolean?)value;
								OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullBool);
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
			public esStrings(esDefaultTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TestId
			{
				get
				{
					System.Int32? data = entity.TestId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TestId = null;
					else entity.TestId = Convert.ToInt32(value);
				}
			}
				
			public System.String DefaultNotNullInt
			{
				get
				{
					System.Int32? data = entity.DefaultNotNullInt;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DefaultNotNullInt = null;
					else entity.DefaultNotNullInt = Convert.ToInt32(value);
				}
			}
				
			public System.String DefaultNotNullBool
			{
				get
				{
					System.Boolean? data = entity.DefaultNotNullBool;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DefaultNotNullBool = null;
					else entity.DefaultNotNullBool = Convert.ToBoolean(value);
				}
			}
			

			private esDefaultTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return DefaultTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public DefaultTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new DefaultTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(DefaultTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(DefaultTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private DefaultTestQuery query;		
	}



	[Serializable]
	abstract public partial class esDefaultTestCollection : CollectionBase<DefaultTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return DefaultTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "DefaultTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public DefaultTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new DefaultTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(DefaultTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new DefaultTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(DefaultTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((DefaultTestQuery)query);
		}

		#endregion
		
		private DefaultTestQuery query;
	}



	[Serializable]
	abstract public partial class esDefaultTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return DefaultTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TestId": return this.TestId;
				case "DefaultNotNullInt": return this.DefaultNotNullInt;
				case "DefaultNotNullBool": return this.DefaultNotNullBool;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TestId
		{
			get { return new esQueryItem(this, DefaultTestMetadata.ColumnNames.TestId, esSystemType.Int32); }
		} 
		
		public esQueryItem DefaultNotNullInt
		{
			get { return new esQueryItem(this, DefaultTestMetadata.ColumnNames.DefaultNotNullInt, esSystemType.Int32); }
		} 
		
		public esQueryItem DefaultNotNullBool
		{
			get { return new esQueryItem(this, DefaultTestMetadata.ColumnNames.DefaultNotNullBool, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "DefaultTest")]
	[XmlType(TypeName="DefaultTestProxyStub")]	
	[Serializable]
	public partial class DefaultTestProxyStub
	{
		public DefaultTestProxyStub() 
		{
			theEntity = this.entity = new DefaultTest();
		}

		public DefaultTestProxyStub(DefaultTest obj)
		{
			theEntity = this.entity = obj;
		}

		public DefaultTestProxyStub(DefaultTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator DefaultTest(DefaultTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(DefaultTest);
		}

		[DataMember(Name="TestId", Order=1, EmitDefaultValue=false)]
		public System.Int32? TestId
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(DefaultTestMetadata.ColumnNames.TestId);
				else
					return this.Entity.TestId;
			}
			set { this.Entity.TestId = value; }
		}

		[DataMember(Name="DefaultNotNullInt", Order=2, EmitDefaultValue=false)]
		public System.Int32? DefaultNotNullInt
		{
			get 
			{ 
				
				if (this.IncludeColumn(DefaultTestMetadata.ColumnNames.DefaultNotNullInt))
					return this.Entity.DefaultNotNullInt;
				else
					return null;
			}
			set { this.Entity.DefaultNotNullInt = value; }
		}

		[DataMember(Name="DefaultNotNullBool", Order=3, EmitDefaultValue=false)]
		public System.Boolean? DefaultNotNullBool
		{
			get 
			{ 
				
				if (this.IncludeColumn(DefaultTestMetadata.ColumnNames.DefaultNotNullBool))
					return this.Entity.DefaultNotNullBool;
				else
					return null;
			}
			set { this.Entity.DefaultNotNullBool = value; }
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
		public DefaultTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new DefaultTest();
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
		public DefaultTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "DefaultTestCollection")]
	[XmlType(TypeName="DefaultTestCollectionProxyStub")]	
	[Serializable]
	public partial class DefaultTestCollectionProxyStub 
	{
		protected DefaultTestCollectionProxyStub() {}
		
		public DefaultTestCollectionProxyStub(esEntityCollection<DefaultTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public DefaultTestCollectionProxyStub(esEntityCollection<DefaultTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator DefaultTestCollection(DefaultTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(DefaultTest);
		}
		
		public DefaultTestCollectionProxyStub(esEntityCollection<DefaultTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (DefaultTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new DefaultTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new DefaultTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (DefaultTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new DefaultTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<DefaultTestProxyStub> Collection = new List<DefaultTestProxyStub>();

		public DefaultTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new DefaultTestCollection();

				foreach (DefaultTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private DefaultTestCollection _coll;
	}



	[Serializable]
	public partial class DefaultTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected DefaultTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(DefaultTestMetadata.ColumnNames.TestId, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = DefaultTestMetadata.PropertyNames.TestId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(DefaultTestMetadata.ColumnNames.DefaultNotNullInt, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = DefaultTestMetadata.PropertyNames.DefaultNotNullInt;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(DefaultTestMetadata.ColumnNames.DefaultNotNullBool, 2, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = DefaultTestMetadata.PropertyNames.DefaultNotNullBool;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public DefaultTestMetadata Meta()
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
			 public const string TestId = "TestId";
			 public const string DefaultNotNullInt = "DefaultNotNullInt";
			 public const string DefaultNotNullBool = "DefaultNotNullBool";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TestId = "TestId";
			 public const string DefaultNotNullInt = "DefaultNotNullInt";
			 public const string DefaultNotNullBool = "DefaultNotNullBool";
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
			lock (typeof(DefaultTestMetadata))
			{
				if(DefaultTestMetadata.mapDelegates == null)
				{
					DefaultTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (DefaultTestMetadata.meta == null)
				{
					DefaultTestMetadata.meta = new DefaultTestMetadata();
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


				meta.AddTypeMap("TestId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DefaultNotNullInt", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DefaultNotNullBool", new esTypeMap("bit", "System.Boolean"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "DefaultTest";
				meta.Destination = "DefaultTest";
				
				meta.spInsert = "proc_DefaultTestInsert";				
				meta.spUpdate = "proc_DefaultTestUpdate";		
				meta.spDelete = "proc_DefaultTestDelete";
				meta.spLoadAll = "proc_DefaultTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_DefaultTestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private DefaultTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
