
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
	/// Encapsulates the 'AnnotationPlotAxisData' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("AnnotationPlotAxisData")]
	public partial class AnnotationPlotAxisData : esAnnotationPlotAxisData
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new AnnotationPlotAxisData();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new AnnotationPlotAxisData();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new AnnotationPlotAxisData();
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
	[XmlType("AnnotationPlotAxisDataCollection")]
	public partial class AnnotationPlotAxisDataCollection : esAnnotationPlotAxisDataCollection, IEnumerable<AnnotationPlotAxisData>
	{
		public AnnotationPlotAxisData FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(AnnotationPlotAxisData))]
		public class AnnotationPlotAxisDataCollectionWCFPacket : esCollectionWCFPacket<AnnotationPlotAxisDataCollection>
		{
			public static implicit operator AnnotationPlotAxisDataCollection(AnnotationPlotAxisDataCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AnnotationPlotAxisDataCollectionWCFPacket(AnnotationPlotAxisDataCollection collection)
			{
				return new AnnotationPlotAxisDataCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AnnotationPlotAxisDataQuery : esAnnotationPlotAxisDataQuery
	{
		public AnnotationPlotAxisDataQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AnnotationPlotAxisDataQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AnnotationPlotAxisDataQuery query)
		{
			return AnnotationPlotAxisDataQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AnnotationPlotAxisDataQuery(string query)
		{
			return (AnnotationPlotAxisDataQuery)AnnotationPlotAxisDataQuery.SerializeHelper.FromXml(query, typeof(AnnotationPlotAxisDataQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAnnotationPlotAxisData : esEntity
	{
		public esAnnotationPlotAxisData()
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
			AnnotationPlotAxisDataQuery query = new AnnotationPlotAxisDataQuery();
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
		/// Maps to AnnotationPlotAxisData.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotAxisDataMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotAxisDataMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxisData.AxisId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? AxisId
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotAxisDataMetadata.ColumnNames.AxisId);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotAxisDataMetadata.ColumnNames.AxisId, value))
				{
					this._UpToAnnotationPlotAxisByAxisId = null;
					this.OnPropertyChanged("UpToAnnotationPlotAxisByAxisId");
					OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.AxisId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxisData.SeriesId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? SeriesId
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotAxisDataMetadata.ColumnNames.SeriesId);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotAxisDataMetadata.ColumnNames.SeriesId, value))
				{
					this._UpToAnnotationPlotSeriesBySeriesId = null;
					this.OnPropertyChanged("UpToAnnotationPlotSeriesBySeriesId");
					OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.SeriesId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxisData.DataBin
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte[] DataBin
		{
			get
			{
				return base.GetSystemByteArray(AnnotationPlotAxisDataMetadata.ColumnNames.DataBin);
			}
			
			set
			{
				if(base.SetSystemByteArray(AnnotationPlotAxisDataMetadata.ColumnNames.DataBin, value))
				{
					OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.DataBin);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected AnnotationPlotAxis _UpToAnnotationPlotAxisByAxisId;
		[CLSCompliant(false)]
		internal protected AnnotationPlotSeries _UpToAnnotationPlotSeriesBySeriesId;
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
						case "AxisId": this.str().AxisId = (string)value; break;							
						case "SeriesId": this.str().SeriesId = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.Id);
							break;
						
						case "AxisId":
						
							if (value == null || value is System.Int32)
								this.AxisId = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.AxisId);
							break;
						
						case "SeriesId":
						
							if (value == null || value is System.Int32)
								this.SeriesId = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.SeriesId);
							break;
						
						case "DataBin":
						
							if (value == null || value is System.Byte[])
								this.DataBin = (System.Byte[])value;
								OnPropertyChanged(AnnotationPlotAxisDataMetadata.PropertyNames.DataBin);
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
			public esStrings(esAnnotationPlotAxisData entity)
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
				
			public System.String AxisId
			{
				get
				{
					System.Int32? data = entity.AxisId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AxisId = null;
					else entity.AxisId = Convert.ToInt32(value);
				}
			}
				
			public System.String SeriesId
			{
				get
				{
					System.Int32? data = entity.SeriesId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SeriesId = null;
					else entity.SeriesId = Convert.ToInt32(value);
				}
			}
			

			private esAnnotationPlotAxisData entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotAxisDataMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AnnotationPlotAxisDataQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotAxisDataQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotAxisDataQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AnnotationPlotAxisDataQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AnnotationPlotAxisDataQuery query;		
	}



	[Serializable]
	abstract public partial class esAnnotationPlotAxisDataCollection : esEntityCollection<AnnotationPlotAxisData>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotAxisDataMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AnnotationPlotAxisDataCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AnnotationPlotAxisDataQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotAxisDataQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotAxisDataQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AnnotationPlotAxisDataQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AnnotationPlotAxisDataQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AnnotationPlotAxisDataQuery)query);
		}

		#endregion
		
		private AnnotationPlotAxisDataQuery query;
	}



	[Serializable]
	abstract public partial class esAnnotationPlotAxisDataQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotAxisDataMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, AnnotationPlotAxisDataMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem AxisId
		{
			get { return new esQueryItem(this, AnnotationPlotAxisDataMetadata.ColumnNames.AxisId, esSystemType.Int32); }
		} 
		
		public esQueryItem SeriesId
		{
			get { return new esQueryItem(this, AnnotationPlotAxisDataMetadata.ColumnNames.SeriesId, esSystemType.Int32); }
		} 
		
		public esQueryItem DataBin
		{
			get { return new esQueryItem(this, AnnotationPlotAxisDataMetadata.ColumnNames.DataBin, esSystemType.ByteArray); }
		} 
		
		#endregion
		
	}


	
	public partial class AnnotationPlotAxisData : esAnnotationPlotAxisData
	{

				
		#region UpToAnnotationPlotAxisByAxisId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_AnnotationPlotAxisData_AnnotationPlotAxis
		/// </summary>

		[XmlIgnore]
					
		public AnnotationPlotAxis UpToAnnotationPlotAxisByAxisId
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToAnnotationPlotAxisByAxisId == null && AxisId != null)
				{
					this._UpToAnnotationPlotAxisByAxisId = new AnnotationPlotAxis();
					this._UpToAnnotationPlotAxisByAxisId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToAnnotationPlotAxisByAxisId", this._UpToAnnotationPlotAxisByAxisId);
					this._UpToAnnotationPlotAxisByAxisId.Query.Where(this._UpToAnnotationPlotAxisByAxisId.Query.Id == this.AxisId);
					this._UpToAnnotationPlotAxisByAxisId.Query.Load();
				}	
				return this._UpToAnnotationPlotAxisByAxisId;
			}
			
			set
			{
				this.RemovePreSave("UpToAnnotationPlotAxisByAxisId");
				

				if(value == null)
				{
					this.AxisId = null;
					this._UpToAnnotationPlotAxisByAxisId = null;
				}
				else
				{
					this.AxisId = value.Id;
					this._UpToAnnotationPlotAxisByAxisId = value;
					this.SetPreSave("UpToAnnotationPlotAxisByAxisId", this._UpToAnnotationPlotAxisByAxisId);
				}
				
			}
		}
		#endregion
		

				
		#region UpToAnnotationPlotSeriesBySeriesId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_AnnotationPlotAxisData_AnnotationPlotSeries
		/// </summary>

		[XmlIgnore]
					
		public AnnotationPlotSeries UpToAnnotationPlotSeriesBySeriesId
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToAnnotationPlotSeriesBySeriesId == null && SeriesId != null)
				{
					this._UpToAnnotationPlotSeriesBySeriesId = new AnnotationPlotSeries();
					this._UpToAnnotationPlotSeriesBySeriesId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToAnnotationPlotSeriesBySeriesId", this._UpToAnnotationPlotSeriesBySeriesId);
					this._UpToAnnotationPlotSeriesBySeriesId.Query.Where(this._UpToAnnotationPlotSeriesBySeriesId.Query.Id == this.SeriesId);
					this._UpToAnnotationPlotSeriesBySeriesId.Query.Load();
				}	
				return this._UpToAnnotationPlotSeriesBySeriesId;
			}
			
			set
			{
				this.RemovePreSave("UpToAnnotationPlotSeriesBySeriesId");
				

				if(value == null)
				{
					this.SeriesId = null;
					this._UpToAnnotationPlotSeriesBySeriesId = null;
				}
				else
				{
					this.SeriesId = value.Id;
					this._UpToAnnotationPlotSeriesBySeriesId = value;
					this.SetPreSave("UpToAnnotationPlotSeriesBySeriesId", this._UpToAnnotationPlotSeriesBySeriesId);
				}
				
			}
		}
		#endregion
		

		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToAnnotationPlotAxisByAxisId != null)
			{
				this.AxisId = this._UpToAnnotationPlotAxisByAxisId.Id;
			}
			if(!this.es.IsDeleted && this._UpToAnnotationPlotSeriesBySeriesId != null)
			{
				this.SeriesId = this._UpToAnnotationPlotSeriesBySeriesId.Id;
			}
		}
		
	}
	



	[Serializable]
	public partial class AnnotationPlotAxisDataMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AnnotationPlotAxisDataMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AnnotationPlotAxisDataMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotAxisDataMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisDataMetadata.ColumnNames.AxisId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotAxisDataMetadata.PropertyNames.AxisId;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisDataMetadata.ColumnNames.SeriesId, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotAxisDataMetadata.PropertyNames.SeriesId;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisDataMetadata.ColumnNames.DataBin, 3, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = AnnotationPlotAxisDataMetadata.PropertyNames.DataBin;
			c.CharacterMaxLength = 2147483647;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AnnotationPlotAxisDataMetadata Meta()
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
			 public const string AxisId = "AxisId";
			 public const string SeriesId = "SeriesId";
			 public const string DataBin = "DataBin";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string AxisId = "AxisId";
			 public const string SeriesId = "SeriesId";
			 public const string DataBin = "DataBin";
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
			lock (typeof(AnnotationPlotAxisDataMetadata))
			{
				if(AnnotationPlotAxisDataMetadata.mapDelegates == null)
				{
					AnnotationPlotAxisDataMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AnnotationPlotAxisDataMetadata.meta == null)
				{
					AnnotationPlotAxisDataMetadata.meta = new AnnotationPlotAxisDataMetadata();
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
				meta.AddTypeMap("AxisId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("SeriesId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DataBin", new esTypeMap("varbinary", "System.Byte[]"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "AnnotationPlotAxisData";
				meta.Destination = "AnnotationPlotAxisData";
				
				meta.spInsert = "proc_AnnotationPlotAxisDataInsert";				
				meta.spUpdate = "proc_AnnotationPlotAxisDataUpdate";		
				meta.spDelete = "proc_AnnotationPlotAxisDataDelete";
				meta.spLoadAll = "proc_AnnotationPlotAxisDataLoadAll";
				meta.spLoadByPrimaryKey = "proc_AnnotationPlotAxisDataLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AnnotationPlotAxisDataMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
