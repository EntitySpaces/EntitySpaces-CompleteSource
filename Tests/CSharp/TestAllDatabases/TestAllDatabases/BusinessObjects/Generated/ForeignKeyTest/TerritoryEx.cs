
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:43:28 AM
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
	/// Encapsulates the 'TerritoryEx' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(TerritoryEx))]	
	[XmlType("TerritoryEx")]
	[Table(Name="TerritoryEx")]
	public partial class TerritoryEx : esTerritoryEx
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new TerritoryEx();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 territoryID)
		{
			var obj = new TerritoryEx();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 territoryID, esSqlAccessType sqlAccessType)
		{
			var obj = new TerritoryEx();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator TerritoryExProxyStub(TerritoryEx entity)
		{
			return new TerritoryExProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? TerritoryID
		{
			get { return base.TerritoryID;  }
			set { base.TerritoryID = value; }
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
	[XmlType("TerritoryExCollection")]
	public partial class TerritoryExCollection : esTerritoryExCollection, IEnumerable<TerritoryEx>
	{
		public TerritoryEx FindByPrimaryKey(System.Int32 territoryID)
		{
			return this.SingleOrDefault(e => e.TerritoryID == territoryID);
		}

		#region Implicit Casts
		
		public static implicit operator TerritoryExCollectionProxyStub(TerritoryExCollection coll)
		{
			return new TerritoryExCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(TerritoryEx))]
		public class TerritoryExCollectionWCFPacket : esCollectionWCFPacket<TerritoryExCollection>
		{
			public static implicit operator TerritoryExCollection(TerritoryExCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator TerritoryExCollectionWCFPacket(TerritoryExCollection collection)
			{
				return new TerritoryExCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "TerritoryExQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class TerritoryExQuery : esTerritoryExQuery
	{
		public TerritoryExQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "TerritoryExQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(TerritoryExQuery query)
		{
			return TerritoryExQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator TerritoryExQuery(string query)
		{
			return (TerritoryExQuery)TerritoryExQuery.SerializeHelper.FromXml(query, typeof(TerritoryExQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esTerritoryEx : esEntity
	{
		public esTerritoryEx()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 territoryID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(territoryID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 territoryID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(territoryID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 territoryID)
		{
			TerritoryExQuery query = new TerritoryExQuery();
			query.Where(query.TerritoryID == territoryID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 territoryID)
		{
			esParameters parms = new esParameters();
			parms.Add("TerritoryID", territoryID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to TerritoryEx.TerritoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? TerritoryID
		{
			get
			{
				return base.GetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID);
			}
			
			set
			{
				if(base.SetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID, value))
				{
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.TerritoryID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TerritoryEx.Notes
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Notes
		{
			get
			{
				return base.GetSystemString(TerritoryExMetadata.ColumnNames.Notes);
			}
			
			set
			{
				if(base.SetSystemString(TerritoryExMetadata.ColumnNames.Notes, value))
				{
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.Notes);
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
						case "TerritoryID": this.str().TerritoryID = (string)value; break;							
						case "Notes": this.str().Notes = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TerritoryID":
						
							if (value == null || value is System.Int32)
								this.TerritoryID = (System.Int32?)value;
								OnPropertyChanged(TerritoryExMetadata.PropertyNames.TerritoryID);
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
			public esStrings(esTerritoryEx entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TerritoryID
			{
				get
				{
					System.Int32? data = entity.TerritoryID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TerritoryID = null;
					else entity.TerritoryID = Convert.ToInt32(value);
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
			

			private esTerritoryEx entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return TerritoryExMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public TerritoryExQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TerritoryExQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TerritoryExQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(TerritoryExQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private TerritoryExQuery query;		
	}



	[Serializable]
	abstract public partial class esTerritoryExCollection : esEntityCollection<TerritoryEx>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TerritoryExMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "TerritoryExCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public TerritoryExQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TerritoryExQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TerritoryExQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TerritoryExQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(TerritoryExQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((TerritoryExQuery)query);
		}

		#endregion
		
		private TerritoryExQuery query;
	}



	[Serializable]
	abstract public partial class esTerritoryExQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return TerritoryExMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TerritoryID": return this.TerritoryID;
				case "Notes": return this.Notes;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TerritoryID
		{
			get { return new esQueryItem(this, TerritoryExMetadata.ColumnNames.TerritoryID, esSystemType.Int32); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, TerritoryExMetadata.ColumnNames.Notes, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class TerritoryEx : esTerritoryEx
	{

		#region UpToTerritory - One To One
		/// <summary>
		/// One to One
		/// Foreign Key Name - FK_TerritoryEx_Territory
		/// </summary>

		[XmlIgnore]
		public Territory UpToTerritory
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
			
				if(this._UpToTerritory == null && TerritoryID != null)
				{
					this._UpToTerritory = new Territory();
					this._UpToTerritory.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToTerritory", this._UpToTerritory);
					this._UpToTerritory.Query.Where(this._UpToTerritory.Query.TerritoryID == this.TerritoryID);
					this._UpToTerritory.Query.Load();
				}

				return this._UpToTerritory;
			}
			
			set 
			{ 
				this.RemovePreSave("UpToTerritory");

				if(value == null)
				{
					this._UpToTerritory = null;
				}
				else
				{
					this._UpToTerritory = value;
					this.SetPreSave("UpToTerritory", this._UpToTerritory);
				}
				
				this.OnPropertyChanged("UpToTerritory");
			} 
		}
				
		
		private Territory _UpToTerritory;
		#endregion

		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToTerritory != null)
			{
				this.TerritoryID = this._UpToTerritory.TerritoryID;
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "TerritoryEx")]
	[XmlType(TypeName="TerritoryExProxyStub")]	
	[Serializable]
	public partial class TerritoryExProxyStub
	{
		public TerritoryExProxyStub() 
		{
			theEntity = this.entity = new TerritoryEx();
		}

		public TerritoryExProxyStub(TerritoryEx obj)
		{
			theEntity = this.entity = obj;
		}

		public TerritoryExProxyStub(TerritoryEx obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator TerritoryEx(TerritoryExProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(TerritoryEx);
		}

		[DataMember(Name="TerritoryID", Order=1, EmitDefaultValue=false)]
		public System.Int32? TerritoryID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(TerritoryExMetadata.ColumnNames.TerritoryID);
				else
					return this.Entity.TerritoryID;
			}
			set { this.Entity.TerritoryID = value; }
		}

		[DataMember(Name="Notes", Order=2, EmitDefaultValue=false)]
		public System.String Notes
		{
			get 
			{ 
				
				if (this.IncludeColumn(TerritoryExMetadata.ColumnNames.Notes))
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
		public TerritoryEx Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new TerritoryEx();
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
		public TerritoryEx entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "TerritoryExCollection")]
	[XmlType(TypeName="TerritoryExCollectionProxyStub")]	
	[Serializable]
	public partial class TerritoryExCollectionProxyStub 
	{
		protected TerritoryExCollectionProxyStub() {}
		
		public TerritoryExCollectionProxyStub(esEntityCollection<TerritoryEx> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public TerritoryExCollectionProxyStub(esEntityCollection<TerritoryEx> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator TerritoryExCollection(TerritoryExCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(TerritoryEx);
		}
		
		public TerritoryExCollectionProxyStub(esEntityCollection<TerritoryEx> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (TerritoryEx entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new TerritoryExProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new TerritoryExProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (TerritoryEx entity in coll.es.DeletedEntities)
				{
					Collection.Add(new TerritoryExProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<TerritoryExProxyStub> Collection = new List<TerritoryExProxyStub>();

		public TerritoryExCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new TerritoryExCollection();

				foreach (TerritoryExProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private TerritoryExCollection _coll;
	}



	[Serializable]
	public partial class TerritoryExMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TerritoryExMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TerritoryExMetadata.ColumnNames.TerritoryID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TerritoryExMetadata.PropertyNames.TerritoryID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TerritoryExMetadata.ColumnNames.Notes, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = TerritoryExMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public TerritoryExMetadata Meta()
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
			 public const string TerritoryID = "TerritoryID";
			 public const string Notes = "Notes";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TerritoryID = "TerritoryID";
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
			lock (typeof(TerritoryExMetadata))
			{
				if(TerritoryExMetadata.mapDelegates == null)
				{
					TerritoryExMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoryExMetadata.meta == null)
				{
					TerritoryExMetadata.meta = new TerritoryExMetadata();
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


				meta.AddTypeMap("TerritoryID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Notes", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "TerritoryEx";
				meta.Destination = "TerritoryEx";
				
				meta.spInsert = "proc_TerritoryExInsert";				
				meta.spUpdate = "proc_TerritoryExUpdate";		
				meta.spDelete = "proc_TerritoryExDelete";
				meta.spLoadAll = "proc_TerritoryExLoadAll";
				meta.spLoadByPrimaryKey = "proc_TerritoryExLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TerritoryExMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
