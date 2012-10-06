
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0627.0
EntitySpaces Driver  : SQL
Date Generated       : 7/17/2011 9:16:18 PM
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
	/// Encapsulates the 'Annotation' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("Annotation")]
	public partial class Annotation : esAnnotation
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Annotation();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 annotationId)
		{
			var obj = new Annotation();
			obj.AnnotationId = annotationId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 annotationId, esSqlAccessType sqlAccessType)
		{
			var obj = new Annotation();
			obj.AnnotationId = annotationId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("AnnotationCollection")]
	public partial class AnnotationCollection : esAnnotationCollection, IEnumerable<Annotation>
	{
		public Annotation FindByPrimaryKey(System.Int32 annotationId)
		{
			return this.SingleOrDefault(e => e.AnnotationId == annotationId);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Annotation))]
		public class AnnotationCollectionWCFPacket : esCollectionWCFPacket<AnnotationCollection>
		{
			public static implicit operator AnnotationCollection(AnnotationCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AnnotationCollectionWCFPacket(AnnotationCollection collection)
			{
				return new AnnotationCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AnnotationQuery : esAnnotationQuery
	{
		public AnnotationQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AnnotationQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AnnotationQuery query)
		{
			return AnnotationQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AnnotationQuery(string query)
		{
			return (AnnotationQuery)AnnotationQuery.SerializeHelper.FromXml(query, typeof(AnnotationQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAnnotation : esEntity
	{
		public esAnnotation()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 annotationId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(annotationId);
			else
				return LoadByPrimaryKeyStoredProcedure(annotationId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 annotationId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(annotationId);
			else
				return LoadByPrimaryKeyStoredProcedure(annotationId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 annotationId)
		{
			AnnotationQuery query = new AnnotationQuery();
			query.Where(query.AnnotationId == annotationId);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 annotationId)
		{
			esParameters parms = new esParameters();
			parms.Add("AnnotationId", annotationId);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Annotation.AnnotationId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? AnnotationId
		{
			get
			{
				return base.GetSystemInt32(AnnotationMetadata.ColumnNames.AnnotationId);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationMetadata.ColumnNames.AnnotationId, value))
				{
					OnPropertyChanged(AnnotationMetadata.PropertyNames.AnnotationId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Annotation.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(AnnotationMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(AnnotationMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(AnnotationMetadata.PropertyNames.Description);
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
						case "AnnotationId": this.str().AnnotationId = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "AnnotationId":
						
							if (value == null || value is System.Int32)
								this.AnnotationId = (System.Int32?)value;
								OnPropertyChanged(AnnotationMetadata.PropertyNames.AnnotationId);
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
			public esStrings(esAnnotation entity)
			{
				this.entity = entity;
			}
			
	
			public System.String AnnotationId
			{
				get
				{
					System.Int32? data = entity.AnnotationId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AnnotationId = null;
					else entity.AnnotationId = Convert.ToInt32(value);
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
			

			private esAnnotation entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AnnotationMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AnnotationQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AnnotationQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AnnotationQuery query;		
	}



	[Serializable]
	abstract public partial class esAnnotationCollection : esEntityCollection<Annotation>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AnnotationCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AnnotationQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AnnotationQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AnnotationQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AnnotationQuery)query);
		}

		#endregion
		
		private AnnotationQuery query;
	}



	[Serializable]
	abstract public partial class esAnnotationQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem AnnotationId
		{
			get { return new esQueryItem(this, AnnotationMetadata.ColumnNames.AnnotationId, esSystemType.Int32); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, AnnotationMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Annotation : esAnnotation
	{

		#region AnnotationPlotCollectionByAnnotationId - Zero To Many
		
		static public esPrefetchMap Prefetch_AnnotationPlotCollectionByAnnotationId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Annotation.AnnotationPlotCollectionByAnnotationId_Delegate;
				map.PropertyName = "AnnotationPlotCollectionByAnnotationId";
				map.MyColumnName = "AnnotationId";
				map.ParentColumnName = "AnnotationId";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AnnotationPlotCollectionByAnnotationId_Delegate(esPrefetchParameters data)
		{
			AnnotationQuery parent = new AnnotationQuery(data.NextAlias());

			AnnotationPlotQuery me = data.You != null ? data.You as AnnotationPlotQuery : new AnnotationPlotQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.AnnotationId == me.AnnotationId);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_AnnotationPlot_Annotation
		/// </summary>

		[XmlIgnore]
		public AnnotationPlotCollection AnnotationPlotCollectionByAnnotationId
		{
			get
			{
				if(this._AnnotationPlotCollectionByAnnotationId == null)
				{
					this._AnnotationPlotCollectionByAnnotationId = new AnnotationPlotCollection();
					this._AnnotationPlotCollectionByAnnotationId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AnnotationPlotCollectionByAnnotationId", this._AnnotationPlotCollectionByAnnotationId);
				
					if (this.AnnotationId != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AnnotationPlotCollectionByAnnotationId.Query.Where(this._AnnotationPlotCollectionByAnnotationId.Query.AnnotationId == this.AnnotationId);
							this._AnnotationPlotCollectionByAnnotationId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AnnotationPlotCollectionByAnnotationId.fks.Add(AnnotationPlotMetadata.ColumnNames.AnnotationId, this.AnnotationId);
					}
				}

				return this._AnnotationPlotCollectionByAnnotationId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AnnotationPlotCollectionByAnnotationId != null) 
				{ 
					this.RemovePostSave("AnnotationPlotCollectionByAnnotationId"); 
					this._AnnotationPlotCollectionByAnnotationId = null;
					
				} 
			} 			
		}
			
		
		private AnnotationPlotCollection _AnnotationPlotCollectionByAnnotationId;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "AnnotationPlotCollectionByAnnotationId":
					coll = this.AnnotationPlotCollectionByAnnotationId;
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
			
			props.Add(new esPropertyDescriptor(this, "AnnotationPlotCollectionByAnnotationId", typeof(AnnotationPlotCollection), new AnnotationPlot()));
		
			return props;
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
			if(this._AnnotationPlotCollectionByAnnotationId != null)
			{
				Apply(this._AnnotationPlotCollectionByAnnotationId, "AnnotationId", this.AnnotationId);
			}
		}
		
	}
	



	[Serializable]
	public partial class AnnotationMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AnnotationMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AnnotationMetadata.ColumnNames.AnnotationId, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationMetadata.PropertyNames.AnnotationId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationMetadata.ColumnNames.Description, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AnnotationMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 128;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AnnotationMetadata Meta()
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
			 public const string AnnotationId = "AnnotationId";
			 public const string Description = "Description";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string AnnotationId = "AnnotationId";
			 public const string Description = "Description";
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
			lock (typeof(AnnotationMetadata))
			{
				if(AnnotationMetadata.mapDelegates == null)
				{
					AnnotationMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AnnotationMetadata.meta == null)
				{
					AnnotationMetadata.meta = new AnnotationMetadata();
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


				meta.AddTypeMap("AnnotationId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "Annotation";
				meta.Destination = "Annotation";
				
				meta.spInsert = "proc_AnnotationInsert";				
				meta.spUpdate = "proc_AnnotationUpdate";		
				meta.spDelete = "proc_AnnotationDelete";
				meta.spLoadAll = "proc_AnnotationLoadAll";
				meta.spLoadByPrimaryKey = "proc_AnnotationLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AnnotationMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
