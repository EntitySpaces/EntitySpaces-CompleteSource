
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0627.0
EntitySpaces Driver  : SQL
Date Generated       : 7/17/2011 9:16:19 PM
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
	/// Encapsulates the 'AnnotationPlotSeries' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("AnnotationPlotSeries")]
	public partial class AnnotationPlotSeries : esAnnotationPlotSeries
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new AnnotationPlotSeries();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new AnnotationPlotSeries();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new AnnotationPlotSeries();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("AnnotationPlotSeriesCollection")]
	public partial class AnnotationPlotSeriesCollection : esAnnotationPlotSeriesCollection, IEnumerable<AnnotationPlotSeries>
	{
		public AnnotationPlotSeries FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(AnnotationPlotSeries))]
		public class AnnotationPlotSeriesCollectionWCFPacket : esCollectionWCFPacket<AnnotationPlotSeriesCollection>
		{
			public static implicit operator AnnotationPlotSeriesCollection(AnnotationPlotSeriesCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AnnotationPlotSeriesCollectionWCFPacket(AnnotationPlotSeriesCollection collection)
			{
				return new AnnotationPlotSeriesCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AnnotationPlotSeriesQuery : esAnnotationPlotSeriesQuery
	{
		public AnnotationPlotSeriesQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AnnotationPlotSeriesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AnnotationPlotSeriesQuery query)
		{
			return AnnotationPlotSeriesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AnnotationPlotSeriesQuery(string query)
		{
			return (AnnotationPlotSeriesQuery)AnnotationPlotSeriesQuery.SerializeHelper.FromXml(query, typeof(AnnotationPlotSeriesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAnnotationPlotSeries : esEntity
	{
		public esAnnotationPlotSeries()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			AnnotationPlotSeriesQuery query = new AnnotationPlotSeriesQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to AnnotationPlotSeries.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotSeriesMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotSeriesMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(AnnotationPlotSeriesMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotSeries.PlotId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? PlotId
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotSeriesMetadata.ColumnNames.PlotId);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotSeriesMetadata.ColumnNames.PlotId, value))
				{
					this._UpToAnnotationPlotByPlotId = null;
					this.OnPropertyChanged("UpToAnnotationPlotByPlotId");
					OnPropertyChanged(AnnotationPlotSeriesMetadata.PropertyNames.PlotId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotSeries.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(AnnotationPlotSeriesMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(AnnotationPlotSeriesMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(AnnotationPlotSeriesMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotSeries.ColorRGB
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ColorRGB
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotSeriesMetadata.ColumnNames.ColorRGB);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotSeriesMetadata.ColumnNames.ColorRGB, value))
				{
					OnPropertyChanged(AnnotationPlotSeriesMetadata.PropertyNames.ColorRGB);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected AnnotationPlot _UpToAnnotationPlotByPlotId;
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
						case "PlotId": this.str().PlotId = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "ColorRGB": this.str().ColorRGB = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotSeriesMetadata.PropertyNames.Id);
							break;
						
						case "PlotId":
						
							if (value == null || value is System.Int32)
								this.PlotId = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotSeriesMetadata.PropertyNames.PlotId);
							break;
						
						case "ColorRGB":
						
							if (value == null || value is System.Int32)
								this.ColorRGB = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotSeriesMetadata.PropertyNames.ColorRGB);
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
			public esStrings(esAnnotationPlotSeries entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String PlotId
			{
				get
				{
					System.Int32? data = entity.PlotId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PlotId = null;
					else entity.PlotId = Convert.ToInt32(value);
				}
			}
				
			public System.String Description
			{
				get
				{
					System.String data = entity.Description;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Description = null;
					else entity.Description = Convert.ToString(value);
				}
			}
				
			public System.String ColorRGB
			{
				get
				{
					System.Int32? data = entity.ColorRGB;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ColorRGB = null;
					else entity.ColorRGB = Convert.ToInt32(value);
				}
			}
			

			private esAnnotationPlotSeries entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotSeriesMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AnnotationPlotSeriesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotSeriesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotSeriesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AnnotationPlotSeriesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AnnotationPlotSeriesQuery query;		
	}



	[Serializable]
	abstract public partial class esAnnotationPlotSeriesCollection : esEntityCollection<AnnotationPlotSeries>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotSeriesMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AnnotationPlotSeriesCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AnnotationPlotSeriesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotSeriesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotSeriesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AnnotationPlotSeriesQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AnnotationPlotSeriesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AnnotationPlotSeriesQuery)query);
		}

		#endregion
		
		private AnnotationPlotSeriesQuery query;
	}



	[Serializable]
	abstract public partial class esAnnotationPlotSeriesQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotSeriesMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, AnnotationPlotSeriesMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem PlotId
		{
			get { return new esQueryItem(this, AnnotationPlotSeriesMetadata.ColumnNames.PlotId, esSystemType.Int32); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, AnnotationPlotSeriesMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem ColorRGB
		{
			get { return new esQueryItem(this, AnnotationPlotSeriesMetadata.ColumnNames.ColorRGB, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class AnnotationPlotSeries : esAnnotationPlotSeries
	{

		#region AnnotationPlotAxisDataCollectionBySeriesId - Zero To Many
		
		static public esPrefetchMap Prefetch_AnnotationPlotAxisDataCollectionBySeriesId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.AnnotationPlotSeries.AnnotationPlotAxisDataCollectionBySeriesId_Delegate;
				map.PropertyName = "AnnotationPlotAxisDataCollectionBySeriesId";
				map.MyColumnName = "SeriesId";
				map.ParentColumnName = "Id";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AnnotationPlotAxisDataCollectionBySeriesId_Delegate(esPrefetchParameters data)
		{
			AnnotationPlotSeriesQuery parent = new AnnotationPlotSeriesQuery(data.NextAlias());

			AnnotationPlotAxisDataQuery me = data.You != null ? data.You as AnnotationPlotAxisDataQuery : new AnnotationPlotAxisDataQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Id == me.SeriesId);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_AnnotationPlotAxisData_AnnotationPlotSeries
		/// </summary>

		[XmlIgnore]
		public AnnotationPlotAxisDataCollection AnnotationPlotAxisDataCollectionBySeriesId
		{
			get
			{
				if(this._AnnotationPlotAxisDataCollectionBySeriesId == null)
				{
					this._AnnotationPlotAxisDataCollectionBySeriesId = new AnnotationPlotAxisDataCollection();
					this._AnnotationPlotAxisDataCollectionBySeriesId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AnnotationPlotAxisDataCollectionBySeriesId", this._AnnotationPlotAxisDataCollectionBySeriesId);
				
					if (this.Id != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AnnotationPlotAxisDataCollectionBySeriesId.Query.Where(this._AnnotationPlotAxisDataCollectionBySeriesId.Query.SeriesId == this.Id);
							this._AnnotationPlotAxisDataCollectionBySeriesId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AnnotationPlotAxisDataCollectionBySeriesId.fks.Add(AnnotationPlotAxisDataMetadata.ColumnNames.SeriesId, this.Id);
					}
				}

				return this._AnnotationPlotAxisDataCollectionBySeriesId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AnnotationPlotAxisDataCollectionBySeriesId != null) 
				{ 
					this.RemovePostSave("AnnotationPlotAxisDataCollectionBySeriesId"); 
					this._AnnotationPlotAxisDataCollectionBySeriesId = null;
					
				} 
			} 			
		}
			
		
		private AnnotationPlotAxisDataCollection _AnnotationPlotAxisDataCollectionBySeriesId;
		#endregion

				
		#region UpToAnnotationPlotByPlotId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_AnnotationPlotSeries_AnnotationPlot
		/// </summary>

		[XmlIgnore]
					
		public AnnotationPlot UpToAnnotationPlotByPlotId
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToAnnotationPlotByPlotId == null && PlotId != null)
				{
					this._UpToAnnotationPlotByPlotId = new AnnotationPlot();
					this._UpToAnnotationPlotByPlotId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToAnnotationPlotByPlotId", this._UpToAnnotationPlotByPlotId);
					this._UpToAnnotationPlotByPlotId.Query.Where(this._UpToAnnotationPlotByPlotId.Query.Id == this.PlotId);
					this._UpToAnnotationPlotByPlotId.Query.Load();
				}	
				return this._UpToAnnotationPlotByPlotId;
			}
			
			set
			{
				this.RemovePreSave("UpToAnnotationPlotByPlotId");
				

				if(value == null)
				{
					this.PlotId = null;
					this._UpToAnnotationPlotByPlotId = null;
				}
				else
				{
					this.PlotId = value.Id;
					this._UpToAnnotationPlotByPlotId = value;
					this.SetPreSave("UpToAnnotationPlotByPlotId", this._UpToAnnotationPlotByPlotId);
				}
				
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "AnnotationPlotAxisDataCollectionBySeriesId":
					coll = this.AnnotationPlotAxisDataCollectionBySeriesId;
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
			
			props.Add(new esPropertyDescriptor(this, "AnnotationPlotAxisDataCollectionBySeriesId", typeof(AnnotationPlotAxisDataCollection), new AnnotationPlotAxisData()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToAnnotationPlotByPlotId != null)
			{
				this.PlotId = this._UpToAnnotationPlotByPlotId.Id;
			}
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetColumn(key, value, false);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._AnnotationPlotAxisDataCollectionBySeriesId != null)
			{
				Apply(this._AnnotationPlotAxisDataCollectionBySeriesId, "SeriesId", this.Id);
			}
		}
		
	}
	



	[Serializable]
	public partial class AnnotationPlotSeriesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AnnotationPlotSeriesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AnnotationPlotSeriesMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotSeriesMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotSeriesMetadata.ColumnNames.PlotId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotSeriesMetadata.PropertyNames.PlotId;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotSeriesMetadata.ColumnNames.Description, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = AnnotationPlotSeriesMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 256;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotSeriesMetadata.ColumnNames.ColorRGB, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotSeriesMetadata.PropertyNames.ColorRGB;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AnnotationPlotSeriesMetadata Meta()
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
			 public const string PlotId = "PlotId";
			 public const string Description = "Description";
			 public const string ColorRGB = "ColorRGB";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string PlotId = "PlotId";
			 public const string Description = "Description";
			 public const string ColorRGB = "ColorRGB";
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
			lock (typeof(AnnotationPlotSeriesMetadata))
			{
				if(AnnotationPlotSeriesMetadata.mapDelegates == null)
				{
					AnnotationPlotSeriesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AnnotationPlotSeriesMetadata.meta == null)
				{
					AnnotationPlotSeriesMetadata.meta = new AnnotationPlotSeriesMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("PlotId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ColorRGB", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "AnnotationPlotSeries";
				meta.Destination = "AnnotationPlotSeries";
				
				meta.spInsert = "proc_AnnotationPlotSeriesInsert";				
				meta.spUpdate = "proc_AnnotationPlotSeriesUpdate";		
				meta.spDelete = "proc_AnnotationPlotSeriesDelete";
				meta.spLoadAll = "proc_AnnotationPlotSeriesLoadAll";
				meta.spLoadByPrimaryKey = "proc_AnnotationPlotSeriesLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AnnotationPlotSeriesMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
