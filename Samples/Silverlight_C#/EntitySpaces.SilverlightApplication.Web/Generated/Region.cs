
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:14 PM
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
	/// Encapsulates the 'Region' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Region))]	
	[XmlType("Region")]
	public partial class Region : esRegion
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Region();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 regionID)
		{
			var obj = new Region();
			obj.RegionID = regionID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 regionID, esSqlAccessType sqlAccessType)
		{
			var obj = new Region();
			obj.RegionID = regionID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator RegionProxyStub(Region entity)
		{
			return new RegionProxyStub(entity);
		}

		#endregion
		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("RegionCollection")]
	public partial class RegionCollection : esRegionCollection, IEnumerable<Region>
	{
		public Region FindByPrimaryKey(System.Int32 regionID)
		{
			return this.SingleOrDefault(e => e.RegionID == regionID);
		}

		#region Implicit Casts
		
		public static implicit operator RegionCollectionProxyStub(RegionCollection coll)
		{
			return new RegionCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Region))]
		public class RegionCollectionWCFPacket : esCollectionWCFPacket<RegionCollection>
		{
			public static implicit operator RegionCollection(RegionCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator RegionCollectionWCFPacket(RegionCollection collection)
			{
				return new RegionCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]
	[DataContract(Name = "RegionQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class RegionQuery : esRegionQuery
	{
		public RegionQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "RegionQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(RegionQuery query)
		{
			return RegionQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator RegionQuery(string query)
		{
			return (RegionQuery)RegionQuery.SerializeHelper.FromXml(query, typeof(RegionQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esRegion : esEntity
	{
		public esRegion()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 regionID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(regionID);
			else
				return LoadByPrimaryKeyStoredProcedure(regionID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 regionID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(regionID);
			else
				return LoadByPrimaryKeyStoredProcedure(regionID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 regionID)
		{
			RegionQuery query = new RegionQuery();
			query.Where(query.RegionID == regionID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 regionID)
		{
			esParameters parms = new esParameters();
			parms.Add("RegionID", regionID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Region.RegionID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? RegionID
		{
			get
			{
				return base.GetSystemInt32(RegionMetadata.ColumnNames.RegionID);
			}
			
			set
			{
				if(base.SetSystemInt32(RegionMetadata.ColumnNames.RegionID, value))
				{
					OnPropertyChanged(RegionMetadata.PropertyNames.RegionID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Region.RegionDescription
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String RegionDescription
		{
			get
			{
				return base.GetSystemString(RegionMetadata.ColumnNames.RegionDescription);
			}
			
			set
			{
				if(base.SetSystemString(RegionMetadata.ColumnNames.RegionDescription, value))
				{
					OnPropertyChanged(RegionMetadata.PropertyNames.RegionDescription);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return RegionMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public RegionQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new RegionQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(RegionQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(RegionQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private RegionQuery query;		
	}



	[Serializable]
	abstract public partial class esRegionCollection : esEntityCollection<Region>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return RegionMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "RegionCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public RegionQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new RegionQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(RegionQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new RegionQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(RegionQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((RegionQuery)query);
		}

		#endregion
		
		private RegionQuery query;
	}



	[Serializable]
	abstract public partial class esRegionQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return RegionMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "RegionID": return this.RegionID;
				case "RegionDescription": return this.RegionDescription;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem RegionID
		{
			get { return new esQueryItem(this, RegionMetadata.ColumnNames.RegionID, esSystemType.Int32); }
		} 
		
		public esQueryItem RegionDescription
		{
			get { return new esQueryItem(this, RegionMetadata.ColumnNames.RegionDescription, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Region : esRegion
	{

		#region TerritoriesCollectionByRegionID - Zero To Many
		
		static public esPrefetchMap Prefetch_TerritoriesCollectionByRegionID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Region.TerritoriesCollectionByRegionID_Delegate;
				map.PropertyName = "TerritoriesCollectionByRegionID";
				map.MyColumnName = "RegionID";
				map.ParentColumnName = "RegionID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void TerritoriesCollectionByRegionID_Delegate(esPrefetchParameters data)
		{
			RegionQuery parent = new RegionQuery(data.NextAlias());

			TerritoriesQuery me = data.You != null ? data.You as TerritoriesQuery : new TerritoriesQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.RegionID == me.RegionID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Territories_Region
		/// </summary>

		[XmlIgnore]
		public TerritoriesCollection TerritoriesCollectionByRegionID
		{
			get
			{
				if(this._TerritoriesCollectionByRegionID == null)
				{
					this._TerritoriesCollectionByRegionID = new TerritoriesCollection();
					this._TerritoriesCollectionByRegionID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("TerritoriesCollectionByRegionID", this._TerritoriesCollectionByRegionID);
				
					if (this.RegionID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._TerritoriesCollectionByRegionID.Query.Where(this._TerritoriesCollectionByRegionID.Query.RegionID == this.RegionID);
							this._TerritoriesCollectionByRegionID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._TerritoriesCollectionByRegionID.fks.Add(TerritoriesMetadata.ColumnNames.RegionID, this.RegionID);
					}
				}

				return this._TerritoriesCollectionByRegionID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TerritoriesCollectionByRegionID != null) 
				{ 
					this.RemovePostSave("TerritoriesCollectionByRegionID"); 
					this._TerritoriesCollectionByRegionID = null;
					this.OnPropertyChanged("TerritoriesCollectionByRegionID");
				} 
			} 			
		}
			
		
		private TerritoriesCollection _TerritoriesCollectionByRegionID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "TerritoriesCollectionByRegionID":
					coll = this.TerritoriesCollectionByRegionID;
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
			
			props.Add(new esPropertyDescriptor(this, "TerritoriesCollectionByRegionID", typeof(TerritoriesCollection), new Territories()));
		
			return props;
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Region")]
	[XmlType(TypeName="RegionProxyStub")]	
	[Serializable]
	public partial class RegionProxyStub
	{
		public RegionProxyStub() 
		{
			theEntity = this.entity = new Region();
		}

		public RegionProxyStub(Region obj)
		{
			theEntity = this.entity = obj;
		}

		public RegionProxyStub(Region obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Region(RegionProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Region);
		}

		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
		public System.Int32? RegionID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(RegionMetadata.ColumnNames.RegionID);
				else
					return this.Entity.RegionID;
			}
			set { this.Entity.RegionID = value; }
		}

		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String RegionDescription
		{
			get 
			{ 
				
				if (this.IncludeColumn(RegionMetadata.ColumnNames.RegionDescription))
					return this.Entity.RegionDescription;
				else
					return null;
			}
			set { this.Entity.RegionDescription = value; }
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
		public Region Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Region();
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
		public Region entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "RegionCollection")]
	[XmlType(TypeName="RegionCollectionProxyStub")]	
	[Serializable]
	public partial class RegionCollectionProxyStub 
	{
		protected RegionCollectionProxyStub() {}
		
		public RegionCollectionProxyStub(esEntityCollection<Region> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public RegionCollectionProxyStub(esEntityCollection<Region> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator RegionCollection(RegionCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Region);
		}
		
		public RegionCollectionProxyStub(esEntityCollection<Region> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Region entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new RegionProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new RegionProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Region entity in coll.es.DeletedEntities)
				{
					Collection.Add(new RegionProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<RegionProxyStub> Collection = new List<RegionProxyStub>();

		public RegionCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new RegionCollection();

				foreach (RegionProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private RegionCollection _coll;
	}



	[Serializable]
	public partial class RegionMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected RegionMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(RegionMetadata.ColumnNames.RegionID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = RegionMetadata.PropertyNames.RegionID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(RegionMetadata.ColumnNames.RegionDescription, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = RegionMetadata.PropertyNames.RegionDescription;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public RegionMetadata Meta()
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
			 public const string RegionID = "RegionID";
			 public const string RegionDescription = "RegionDescription";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string RegionID = "RegionID";
			 public const string RegionDescription = "RegionDescription";
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
			lock (typeof(RegionMetadata))
			{
				if(RegionMetadata.mapDelegates == null)
				{
					RegionMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (RegionMetadata.meta == null)
				{
					RegionMetadata.meta = new RegionMetadata();
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


				meta.AddTypeMap("RegionID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("RegionDescription", new esTypeMap("nchar", "System.String"));			
				
				
				
				meta.Source = "Region";
				meta.Destination = "Region";
				
				meta.spInsert = "proc_RegionInsert";				
				meta.spUpdate = "proc_RegionUpdate";		
				meta.spDelete = "proc_RegionDelete";
				meta.spLoadAll = "proc_RegionLoadAll";
				meta.spLoadByPrimaryKey = "proc_RegionLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private RegionMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
