
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:06 AM
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
	/// Encapsulates the 'mysqlunicodetest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(MySqlUnicodeTest))]	
	[XmlType("MySqlUnicodeTest")]
	[Table(Name="MySqlUnicodeTest")]
	public partial class MySqlUnicodeTest : esMySqlUnicodeTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new MySqlUnicodeTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.UInt32 typeID)
		{
			var obj = new MySqlUnicodeTest();
			obj.TypeID = typeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.UInt32 typeID, esSqlAccessType sqlAccessType)
		{
			var obj = new MySqlUnicodeTest();
			obj.TypeID = typeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator MySqlUnicodeTestProxyStub(MySqlUnicodeTest entity)
		{
			return new MySqlUnicodeTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.UInt32? TypeID
		{
			get { return base.TypeID;  }
			set { base.TypeID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String VarCharType
		{
			get { return base.VarCharType;  }
			set { base.VarCharType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String TextType
		{
			get { return base.TextType;  }
			set { base.TextType = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("MySqlUnicodeTestCollection")]
	public partial class MySqlUnicodeTestCollection : esMySqlUnicodeTestCollection, IEnumerable<MySqlUnicodeTest>
	{
		public MySqlUnicodeTest FindByPrimaryKey(System.UInt32 typeID)
		{
			return this.SingleOrDefault(e => e.TypeID == typeID);
		}

		#region Implicit Casts
		
		public static implicit operator MySqlUnicodeTestCollectionProxyStub(MySqlUnicodeTestCollection coll)
		{
			return new MySqlUnicodeTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(MySqlUnicodeTest))]
		public class MySqlUnicodeTestCollectionWCFPacket : esCollectionWCFPacket<MySqlUnicodeTestCollection>
		{
			public static implicit operator MySqlUnicodeTestCollection(MySqlUnicodeTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator MySqlUnicodeTestCollectionWCFPacket(MySqlUnicodeTestCollection collection)
			{
				return new MySqlUnicodeTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "MySqlUnicodeTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class MySqlUnicodeTestQuery : esMySqlUnicodeTestQuery
	{
		public MySqlUnicodeTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "MySqlUnicodeTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(MySqlUnicodeTestQuery query)
		{
			return MySqlUnicodeTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator MySqlUnicodeTestQuery(string query)
		{
			return (MySqlUnicodeTestQuery)MySqlUnicodeTestQuery.SerializeHelper.FromXml(query, typeof(MySqlUnicodeTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esMySqlUnicodeTest : EntityBase
	{
		public esMySqlUnicodeTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.UInt32 typeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(typeID);
			else
				return LoadByPrimaryKeyStoredProcedure(typeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.UInt32 typeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(typeID);
			else
				return LoadByPrimaryKeyStoredProcedure(typeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.UInt32 typeID)
		{
			MySqlUnicodeTestQuery query = new MySqlUnicodeTestQuery();
			query.Where(query.TypeID == typeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.UInt32 typeID)
		{
			esParameters parms = new esParameters();
			parms.Add("TypeID", typeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to mysqlunicodetest.TypeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.UInt32? TypeID
		{
			get
			{
				return base.GetSystemUInt32(MySqlUnicodeTestMetadata.ColumnNames.TypeID);
			}
			
			set
			{
				if(base.SetSystemUInt32(MySqlUnicodeTestMetadata.ColumnNames.TypeID, value))
				{
					OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.TypeID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqlunicodetest.VarCharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String VarCharType
		{
			get
			{
				return base.GetSystemString(MySqlUnicodeTestMetadata.ColumnNames.VarCharType);
			}
			
			set
			{
				if(base.SetSystemString(MySqlUnicodeTestMetadata.ColumnNames.VarCharType, value))
				{
					OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.VarCharType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqlunicodetest.TextType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TextType
		{
			get
			{
				return base.GetSystemString(MySqlUnicodeTestMetadata.ColumnNames.TextType);
			}
			
			set
			{
				if(base.SetSystemString(MySqlUnicodeTestMetadata.ColumnNames.TextType, value))
				{
					OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.TextType);
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
						case "TypeID": this.str().TypeID = (string)value; break;							
						case "VarCharType": this.str().VarCharType = (string)value; break;							
						case "TextType": this.str().TextType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TypeID":
						
							if (value == null || value is System.UInt32)
								this.TypeID = (System.UInt32?)value;
								OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.TypeID);
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
			public esStrings(esMySqlUnicodeTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TypeID
			{
				get
				{
					System.UInt32? data = entity.TypeID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TypeID = null;
					else entity.TypeID = Convert.ToUInt32(value);
				}
			}
				
			public System.String VarCharType
			{
				get
				{
					System.String data = entity.VarCharType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.VarCharType = null;
					else entity.VarCharType = Convert.ToString(value);
				}
			}
				
			public System.String TextType
			{
				get
				{
					System.String data = entity.TextType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TextType = null;
					else entity.TextType = Convert.ToString(value);
				}
			}
			

			private esMySqlUnicodeTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return MySqlUnicodeTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public MySqlUnicodeTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MySqlUnicodeTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MySqlUnicodeTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(MySqlUnicodeTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private MySqlUnicodeTestQuery query;		
	}



	[Serializable]
	abstract public partial class esMySqlUnicodeTestCollection : CollectionBase<MySqlUnicodeTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return MySqlUnicodeTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "MySqlUnicodeTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public MySqlUnicodeTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MySqlUnicodeTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MySqlUnicodeTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MySqlUnicodeTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(MySqlUnicodeTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((MySqlUnicodeTestQuery)query);
		}

		#endregion
		
		private MySqlUnicodeTestQuery query;
	}



	[Serializable]
	abstract public partial class esMySqlUnicodeTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return MySqlUnicodeTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TypeID": return this.TypeID;
				case "VarCharType": return this.VarCharType;
				case "TextType": return this.TextType;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TypeID
		{
			get { return new esQueryItem(this, MySqlUnicodeTestMetadata.ColumnNames.TypeID, esSystemType.UInt32); }
		} 
		
		public esQueryItem VarCharType
		{
			get { return new esQueryItem(this, MySqlUnicodeTestMetadata.ColumnNames.VarCharType, esSystemType.String); }
		} 
		
		public esQueryItem TextType
		{
			get { return new esQueryItem(this, MySqlUnicodeTestMetadata.ColumnNames.TextType, esSystemType.String); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "MySqlUnicodeTest")]
	[XmlType(TypeName="MySqlUnicodeTestProxyStub")]	
	[Serializable]
	public partial class MySqlUnicodeTestProxyStub
	{
		public MySqlUnicodeTestProxyStub() 
		{
			theEntity = this.entity = new MySqlUnicodeTest();
		}

		public MySqlUnicodeTestProxyStub(MySqlUnicodeTest obj)
		{
			theEntity = this.entity = obj;
		}

		public MySqlUnicodeTestProxyStub(MySqlUnicodeTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator MySqlUnicodeTest(MySqlUnicodeTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(MySqlUnicodeTest);
		}

		[DataMember(Name="TypeID", Order=0, EmitDefaultValue=false)]
		public System.UInt32? TypeID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.UInt32?)this.Entity.
						GetOriginalColumnValue(MySqlUnicodeTestMetadata.ColumnNames.TypeID);
				else
					return this.Entity.TypeID;
			}
			set { this.Entity.TypeID = value; }
		}

		[DataMember(Name="VarCharType", Order=0, EmitDefaultValue=false)]
		public System.String VarCharType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MySqlUnicodeTestMetadata.ColumnNames.VarCharType))
					return this.Entity.VarCharType;
				else
					return null;
			}
			set { this.Entity.VarCharType = value; }
		}

		[DataMember(Name="TextType", Order=0, EmitDefaultValue=false)]
		public System.String TextType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MySqlUnicodeTestMetadata.ColumnNames.TextType))
					return this.Entity.TextType;
				else
					return null;
			}
			set { this.Entity.TextType = value; }
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
		public MySqlUnicodeTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new MySqlUnicodeTest();
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
		public MySqlUnicodeTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "MySqlUnicodeTestCollection")]
	[XmlType(TypeName="MySqlUnicodeTestCollectionProxyStub")]	
	[Serializable]
	public partial class MySqlUnicodeTestCollectionProxyStub 
	{
		protected MySqlUnicodeTestCollectionProxyStub() {}
		
		public MySqlUnicodeTestCollectionProxyStub(esEntityCollection<MySqlUnicodeTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public MySqlUnicodeTestCollectionProxyStub(esEntityCollection<MySqlUnicodeTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator MySqlUnicodeTestCollection(MySqlUnicodeTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(MySqlUnicodeTest);
		}
		
		public MySqlUnicodeTestCollectionProxyStub(esEntityCollection<MySqlUnicodeTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (MySqlUnicodeTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new MySqlUnicodeTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new MySqlUnicodeTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (MySqlUnicodeTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new MySqlUnicodeTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<MySqlUnicodeTestProxyStub> Collection = new List<MySqlUnicodeTestProxyStub>();

		public MySqlUnicodeTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new MySqlUnicodeTestCollection();

				foreach (MySqlUnicodeTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private MySqlUnicodeTestCollection _coll;
	}



	[Serializable]
	public partial class MySqlUnicodeTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected MySqlUnicodeTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(MySqlUnicodeTestMetadata.ColumnNames.TypeID, 0, typeof(System.UInt32), esSystemType.UInt32);
			c.PropertyName = MySqlUnicodeTestMetadata.PropertyNames.TypeID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MySqlUnicodeTestMetadata.ColumnNames.VarCharType, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = MySqlUnicodeTestMetadata.PropertyNames.VarCharType;
			c.CharacterMaxLength = 1024;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MySqlUnicodeTestMetadata.ColumnNames.TextType, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = MySqlUnicodeTestMetadata.PropertyNames.TextType;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public MySqlUnicodeTestMetadata Meta()
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
			 public const string TypeID = "TypeID";
			 public const string VarCharType = "VarCharType";
			 public const string TextType = "TextType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TypeID = "TypeID";
			 public const string VarCharType = "VarCharType";
			 public const string TextType = "TextType";
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
			lock (typeof(MySqlUnicodeTestMetadata))
			{
				if(MySqlUnicodeTestMetadata.mapDelegates == null)
				{
					MySqlUnicodeTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MySqlUnicodeTestMetadata.meta == null)
				{
					MySqlUnicodeTestMetadata.meta = new MySqlUnicodeTestMetadata();
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


				meta.AddTypeMap("TypeID", new esTypeMap("INT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"));			
				meta.Catalog = "aggregatedb";
				
				
				meta.Source = "mysqlunicodetest";
				meta.Destination = "mysqlunicodetest";
				
				meta.spInsert = "proc_mysqlunicodetestInsert";				
				meta.spUpdate = "proc_mysqlunicodetestUpdate";		
				meta.spDelete = "proc_mysqlunicodetestDelete";
				meta.spLoadAll = "proc_mysqlunicodetestLoadAll";
				meta.spLoadByPrimaryKey = "proc_mysqlunicodetestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private MySqlUnicodeTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
