
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0530.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 9/22/2011 11:43:49 PM
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
	/// Encapsulates the 'PgDataTypes' table
	/// </summary>

	[Serializable]
	[DataContract]
	[XmlType("PgDataTypes")]
	public partial class PgDataTypes : esPgDataTypes
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new PgDataTypes();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int64 id)
		{
			var obj = new PgDataTypes();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int64 id, esSqlAccessType sqlAccessType)
		{
			var obj = new PgDataTypes();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("PgDataTypesCollection")]
	public partial class PgDataTypesCollection : esPgDataTypesCollection, IEnumerable<PgDataTypes>
	{
		public PgDataTypes FindByPrimaryKey(System.Int64 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(PgDataTypes))]
		public class PgDataTypesCollectionWCFPacket : esCollectionWCFPacket<PgDataTypesCollection>
		{
			public static implicit operator PgDataTypesCollection(PgDataTypesCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator PgDataTypesCollectionWCFPacket(PgDataTypesCollection collection)
			{
				return new PgDataTypesCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]	
	public partial class PgDataTypesQuery : esPgDataTypesQuery
	{
		public PgDataTypesQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "PgDataTypesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(PgDataTypesQuery query)
		{
			return PgDataTypesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator PgDataTypesQuery(string query)
		{
			return (PgDataTypesQuery)PgDataTypesQuery.SerializeHelper.FromXml(query, typeof(PgDataTypesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esPgDataTypes : esEntity
	{
		public esPgDataTypes()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 id)
		{
			PgDataTypesQuery query = new PgDataTypesQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to PgDataTypes.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(PgDataTypesMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt64(PgDataTypesMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(PgDataTypesMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to PgDataTypes.TimeType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TimeType
		{
			get
			{
				return base.GetSystemDateTime(PgDataTypesMetadata.ColumnNames.TimeType);
			}
			
			set
			{
				if(base.SetSystemDateTime(PgDataTypesMetadata.ColumnNames.TimeType, value))
				{
					OnPropertyChanged(PgDataTypesMetadata.PropertyNames.TimeType);
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
						case "TimeType": this.str().TimeType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
								OnPropertyChanged(PgDataTypesMetadata.PropertyNames.Id);
							break;
						
						case "TimeType":
						
							if (value == null || value is System.DateTime)
								this.TimeType = (System.DateTime?)value;
								OnPropertyChanged(PgDataTypesMetadata.PropertyNames.TimeType);
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
			public esStrings(esPgDataTypes entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int64? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt64(value);
				}
			}
				
			public System.String TimeType
			{
				get
				{
					System.DateTime? data = entity.TimeType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TimeType = null;
					else entity.TimeType = Convert.ToDateTime(value);
				}
			}
			

			private esPgDataTypes entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return PgDataTypesMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public PgDataTypesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PgDataTypesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(PgDataTypesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(PgDataTypesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private PgDataTypesQuery query;		
	}



	[Serializable]
	abstract public partial class esPgDataTypesCollection : esEntityCollection<PgDataTypes>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return PgDataTypesMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "PgDataTypesCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public PgDataTypesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new PgDataTypesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(PgDataTypesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new PgDataTypesQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(PgDataTypesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((PgDataTypesQuery)query);
		}

		#endregion
		
		private PgDataTypesQuery query;
	}



	[Serializable]
	abstract public partial class esPgDataTypesQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return PgDataTypesMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, PgDataTypesMetadata.ColumnNames.Id, esSystemType.Int64); }
		} 
		
		public esQueryItem TimeType
		{
			get { return new esQueryItem(this, PgDataTypesMetadata.ColumnNames.TimeType, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class PgDataTypesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected PgDataTypesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(PgDataTypesMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = PgDataTypesMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 64;
			c.HasDefault = true;
			c.Default = @"nextval('""PgDataTypes_ID_seq""'::regclass)";
			m_columns.Add(c);
				
			c = new esColumnMetadata(PgDataTypesMetadata.ColumnNames.TimeType, 1, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = PgDataTypesMetadata.PropertyNames.TimeType;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public PgDataTypesMetadata Meta()
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
			 public const string Id = "ID";
			 public const string TimeType = "TimeType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string TimeType = "TimeType";
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
			lock (typeof(PgDataTypesMetadata))
			{
				if(PgDataTypesMetadata.mapDelegates == null)
				{
					PgDataTypesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (PgDataTypesMetadata.meta == null)
				{
					PgDataTypesMetadata.meta = new PgDataTypesMetadata();
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


				meta["AutoKeyText"] = @"nextval('""PgDataTypes_ID_seq""'::regclass)";

				meta.AddTypeMap("Id", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("TimeType", new esTypeMap("time", "System.DateTime"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "public";
				
				meta.Source = "PgDataTypes";
				meta.Destination = "PgDataTypes";
				
				meta.spInsert = "proc_PgDataTypesInsert";				
				meta.spUpdate = "proc_PgDataTypesUpdate";		
				meta.spDelete = "proc_PgDataTypesDelete";
				meta.spLoadAll = "proc_PgDataTypesLoadAll";
				meta.spLoadByPrimaryKey = "proc_PgDataTypesLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private PgDataTypesMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
