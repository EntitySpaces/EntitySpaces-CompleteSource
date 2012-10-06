
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
	/// Encapsulates the 'KeyNotFirst' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(KeyNotFirst))]	
	[XmlType("KeyNotFirst")]
	[Table(Name="KeyNotFirst")]
	public partial class KeyNotFirst : esKeyNotFirst
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new KeyNotFirst();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 theKey)
		{
			var obj = new KeyNotFirst();
			obj.TheKey = theKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 theKey, esSqlAccessType sqlAccessType)
		{
			var obj = new KeyNotFirst();
			obj.TheKey = theKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator KeyNotFirstProxyStub(KeyNotFirst entity)
		{
			return new KeyNotFirstProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String SomeText
		{
			get { return base.SomeText;  }
			set { base.SomeText = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? TheKey
		{
			get { return base.TheKey;  }
			set { base.TheKey = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("KeyNotFirstCollection")]
	public partial class KeyNotFirstCollection : esKeyNotFirstCollection, IEnumerable<KeyNotFirst>
	{
		public KeyNotFirst FindByPrimaryKey(System.Int32 theKey)
		{
			return this.SingleOrDefault(e => e.TheKey == theKey);
		}

		#region Implicit Casts
		
		public static implicit operator KeyNotFirstCollectionProxyStub(KeyNotFirstCollection coll)
		{
			return new KeyNotFirstCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(KeyNotFirst))]
		public class KeyNotFirstCollectionWCFPacket : esCollectionWCFPacket<KeyNotFirstCollection>
		{
			public static implicit operator KeyNotFirstCollection(KeyNotFirstCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator KeyNotFirstCollectionWCFPacket(KeyNotFirstCollection collection)
			{
				return new KeyNotFirstCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "KeyNotFirstQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class KeyNotFirstQuery : esKeyNotFirstQuery
	{
		public KeyNotFirstQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "KeyNotFirstQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(KeyNotFirstQuery query)
		{
			return KeyNotFirstQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator KeyNotFirstQuery(string query)
		{
			return (KeyNotFirstQuery)KeyNotFirstQuery.SerializeHelper.FromXml(query, typeof(KeyNotFirstQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esKeyNotFirst : EntityBase
	{
		public esKeyNotFirst()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 theKey)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(theKey);
			else
				return LoadByPrimaryKeyStoredProcedure(theKey);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 theKey)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(theKey);
			else
				return LoadByPrimaryKeyStoredProcedure(theKey);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 theKey)
		{
			KeyNotFirstQuery query = new KeyNotFirstQuery();
			query.Where(query.TheKey == theKey);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 theKey)
		{
			esParameters parms = new esParameters();
			parms.Add("TheKey", theKey);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to KeyNotFirst.SomeText
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String SomeText
		{
			get
			{
				return base.GetSystemString(KeyNotFirstMetadata.ColumnNames.SomeText);
			}
			
			set
			{
				if(base.SetSystemString(KeyNotFirstMetadata.ColumnNames.SomeText, value))
				{
					OnPropertyChanged(KeyNotFirstMetadata.PropertyNames.SomeText);
				}
			}
		}		
		
		/// <summary>
		/// Maps to KeyNotFirst.TheKey
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? TheKey
		{
			get
			{
				return base.GetSystemInt32(KeyNotFirstMetadata.ColumnNames.TheKey);
			}
			
			set
			{
				if(base.SetSystemInt32(KeyNotFirstMetadata.ColumnNames.TheKey, value))
				{
					OnPropertyChanged(KeyNotFirstMetadata.PropertyNames.TheKey);
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
						case "SomeText": this.str().SomeText = (string)value; break;							
						case "TheKey": this.str().TheKey = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TheKey":
						
							if (value == null || value is System.Int32)
								this.TheKey = (System.Int32?)value;
								OnPropertyChanged(KeyNotFirstMetadata.PropertyNames.TheKey);
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
			public esStrings(esKeyNotFirst entity)
			{
				this.entity = entity;
			}
			
	
			public System.String SomeText
			{
				get
				{
					System.String data = entity.SomeText;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SomeText = null;
					else entity.SomeText = Convert.ToString(value);
				}
			}
				
			public System.String TheKey
			{
				get
				{
					System.Int32? data = entity.TheKey;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TheKey = null;
					else entity.TheKey = Convert.ToInt32(value);
				}
			}
			

			private esKeyNotFirst entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return KeyNotFirstMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public KeyNotFirstQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KeyNotFirstQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(KeyNotFirstQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(KeyNotFirstQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private KeyNotFirstQuery query;		
	}



	[Serializable]
	abstract public partial class esKeyNotFirstCollection : CollectionBase<KeyNotFirst>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return KeyNotFirstMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "KeyNotFirstCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public KeyNotFirstQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new KeyNotFirstQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(KeyNotFirstQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new KeyNotFirstQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(KeyNotFirstQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((KeyNotFirstQuery)query);
		}

		#endregion
		
		private KeyNotFirstQuery query;
	}



	[Serializable]
	abstract public partial class esKeyNotFirstQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return KeyNotFirstMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "SomeText": return this.SomeText;
				case "TheKey": return this.TheKey;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem SomeText
		{
			get { return new esQueryItem(this, KeyNotFirstMetadata.ColumnNames.SomeText, esSystemType.String); }
		} 
		
		public esQueryItem TheKey
		{
			get { return new esQueryItem(this, KeyNotFirstMetadata.ColumnNames.TheKey, esSystemType.Int32); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "KeyNotFirst")]
	[XmlType(TypeName="KeyNotFirstProxyStub")]	
	[Serializable]
	public partial class KeyNotFirstProxyStub
	{
		public KeyNotFirstProxyStub() 
		{
			theEntity = this.entity = new KeyNotFirst();
		}

		public KeyNotFirstProxyStub(KeyNotFirst obj)
		{
			theEntity = this.entity = obj;
		}

		public KeyNotFirstProxyStub(KeyNotFirst obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator KeyNotFirst(KeyNotFirstProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(KeyNotFirst);
		}

		[DataMember(Name="SomeText", Order=1, EmitDefaultValue=false)]
		public System.String SomeText
		{
			get 
			{ 
				
				if (this.IncludeColumn(KeyNotFirstMetadata.ColumnNames.SomeText))
					return this.Entity.SomeText;
				else
					return null;
			}
			set { this.Entity.SomeText = value; }
		}

		[DataMember(Name="TheKey", Order=2, EmitDefaultValue=false)]
		public System.Int32? TheKey
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(KeyNotFirstMetadata.ColumnNames.TheKey);
				else
					return this.Entity.TheKey;
			}
			set { this.Entity.TheKey = value; }
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
		public KeyNotFirst Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new KeyNotFirst();
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
		public KeyNotFirst entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "KeyNotFirstCollection")]
	[XmlType(TypeName="KeyNotFirstCollectionProxyStub")]	
	[Serializable]
	public partial class KeyNotFirstCollectionProxyStub 
	{
		protected KeyNotFirstCollectionProxyStub() {}
		
		public KeyNotFirstCollectionProxyStub(esEntityCollection<KeyNotFirst> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public KeyNotFirstCollectionProxyStub(esEntityCollection<KeyNotFirst> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator KeyNotFirstCollection(KeyNotFirstCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(KeyNotFirst);
		}
		
		public KeyNotFirstCollectionProxyStub(esEntityCollection<KeyNotFirst> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (KeyNotFirst entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new KeyNotFirstProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new KeyNotFirstProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (KeyNotFirst entity in coll.es.DeletedEntities)
				{
					Collection.Add(new KeyNotFirstProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<KeyNotFirstProxyStub> Collection = new List<KeyNotFirstProxyStub>();

		public KeyNotFirstCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new KeyNotFirstCollection();

				foreach (KeyNotFirstProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private KeyNotFirstCollection _coll;
	}



	[Serializable]
	public partial class KeyNotFirstMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected KeyNotFirstMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(KeyNotFirstMetadata.ColumnNames.SomeText, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = KeyNotFirstMetadata.PropertyNames.SomeText;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(KeyNotFirstMetadata.ColumnNames.TheKey, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = KeyNotFirstMetadata.PropertyNames.TheKey;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public KeyNotFirstMetadata Meta()
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
			 public const string SomeText = "SomeText";
			 public const string TheKey = "TheKey";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string SomeText = "SomeText";
			 public const string TheKey = "TheKey";
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
			lock (typeof(KeyNotFirstMetadata))
			{
				if(KeyNotFirstMetadata.mapDelegates == null)
				{
					KeyNotFirstMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (KeyNotFirstMetadata.meta == null)
				{
					KeyNotFirstMetadata.meta = new KeyNotFirstMetadata();
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


				meta.AddTypeMap("SomeText", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("TheKey", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "KeyNotFirst";
				meta.Destination = "KeyNotFirst";
				
				meta.spInsert = "proc_KeyNotFirstInsert";				
				meta.spUpdate = "proc_KeyNotFirstUpdate";		
				meta.spDelete = "proc_KeyNotFirstDelete";
				meta.spLoadAll = "proc_KeyNotFirstLoadAll";
				meta.spLoadByPrimaryKey = "proc_KeyNotFirstLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private KeyNotFirstMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
