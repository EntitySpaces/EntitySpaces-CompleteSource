
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:50 AM
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
	/// Encapsulates the 'SqlCeDataTypes' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(SqlCeDataTypes))]	
	[XmlType("SqlCeDataTypes")]
	[Table(Name="SqlCeDataTypes")]
	public partial class SqlCeDataTypes : esSqlCeDataTypes
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new SqlCeDataTypes();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new SqlCeDataTypes();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new SqlCeDataTypes();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator SqlCeDataTypesProxyStub(SqlCeDataTypes entity)
		{
			return new SqlCeDataTypesProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? NumericType
		{
			get { return base.NumericType;  }
			set { base.NumericType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Single? RealType
		{
			get { return base.RealType;  }
			set { base.RealType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Double? FloatType
		{
			get { return base.FloatType;  }
			set { base.FloatType = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("SqlCeDataTypesCollection")]
	public partial class SqlCeDataTypesCollection : esSqlCeDataTypesCollection, IEnumerable<SqlCeDataTypes>
	{
		public SqlCeDataTypes FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator SqlCeDataTypesCollectionProxyStub(SqlCeDataTypesCollection coll)
		{
			return new SqlCeDataTypesCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(SqlCeDataTypes))]
		public class SqlCeDataTypesCollectionWCFPacket : esCollectionWCFPacket<SqlCeDataTypesCollection>
		{
			public static implicit operator SqlCeDataTypesCollection(SqlCeDataTypesCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SqlCeDataTypesCollectionWCFPacket(SqlCeDataTypesCollection collection)
			{
				return new SqlCeDataTypesCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "SqlCeDataTypesQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class SqlCeDataTypesQuery : esSqlCeDataTypesQuery
	{
		public SqlCeDataTypesQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SqlCeDataTypesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SqlCeDataTypesQuery query)
		{
			return SqlCeDataTypesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SqlCeDataTypesQuery(string query)
		{
			return (SqlCeDataTypesQuery)SqlCeDataTypesQuery.SerializeHelper.FromXml(query, typeof(SqlCeDataTypesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSqlCeDataTypes : EntityBase
	{
		public esSqlCeDataTypes()
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
			SqlCeDataTypesQuery query = new SqlCeDataTypesQuery();
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
		/// Maps to SqlCeDataTypes.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(SqlCeDataTypesMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(SqlCeDataTypesMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlCeDataTypes.NumericType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? NumericType
		{
			get
			{
				return base.GetSystemDecimal(SqlCeDataTypesMetadata.ColumnNames.NumericType);
			}
			
			set
			{
				if(base.SetSystemDecimal(SqlCeDataTypesMetadata.ColumnNames.NumericType, value))
				{
					OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.NumericType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlCeDataTypes.RealType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Single? RealType
		{
			get
			{
				return base.GetSystemSingle(SqlCeDataTypesMetadata.ColumnNames.RealType);
			}
			
			set
			{
				if(base.SetSystemSingle(SqlCeDataTypesMetadata.ColumnNames.RealType, value))
				{
					OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.RealType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlCeDataTypes.FloatType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? FloatType
		{
			get
			{
				return base.GetSystemDouble(SqlCeDataTypesMetadata.ColumnNames.FloatType);
			}
			
			set
			{
				if(base.SetSystemDouble(SqlCeDataTypesMetadata.ColumnNames.FloatType, value))
				{
					OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.FloatType);
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
						case "NumericType": this.str().NumericType = (string)value; break;							
						case "RealType": this.str().RealType = (string)value; break;							
						case "FloatType": this.str().FloatType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.Id);
							break;
						
						case "NumericType":
						
							if (value == null || value is System.Decimal)
								this.NumericType = (System.Decimal?)value;
								OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.NumericType);
							break;
						
						case "RealType":
						
							if (value == null || value is System.Single)
								this.RealType = (System.Single?)value;
								OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.RealType);
							break;
						
						case "FloatType":
						
							if (value == null || value is System.Double)
								this.FloatType = (System.Double?)value;
								OnPropertyChanged(SqlCeDataTypesMetadata.PropertyNames.FloatType);
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
			public esStrings(esSqlCeDataTypes entity)
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
				
			public System.String NumericType
			{
				get
				{
					System.Decimal? data = entity.NumericType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NumericType = null;
					else entity.NumericType = Convert.ToDecimal(value);
				}
			}
				
			public System.String RealType
			{
				get
				{
					System.Single? data = entity.RealType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RealType = null;
					else entity.RealType = Convert.ToSingle(value);
				}
			}
				
			public System.String FloatType
			{
				get
				{
					System.Double? data = entity.FloatType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FloatType = null;
					else entity.FloatType = Convert.ToDouble(value);
				}
			}
			

			private esSqlCeDataTypes entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SqlCeDataTypesMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SqlCeDataTypesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SqlCeDataTypesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SqlCeDataTypesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SqlCeDataTypesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SqlCeDataTypesQuery query;		
	}



	[Serializable]
	abstract public partial class esSqlCeDataTypesCollection : CollectionBase<SqlCeDataTypes>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SqlCeDataTypesMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SqlCeDataTypesCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SqlCeDataTypesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SqlCeDataTypesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SqlCeDataTypesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SqlCeDataTypesQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SqlCeDataTypesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SqlCeDataTypesQuery)query);
		}

		#endregion
		
		private SqlCeDataTypesQuery query;
	}



	[Serializable]
	abstract public partial class esSqlCeDataTypesQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return SqlCeDataTypesMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "NumericType": return this.NumericType;
				case "RealType": return this.RealType;
				case "FloatType": return this.FloatType;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, SqlCeDataTypesMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem NumericType
		{
			get { return new esQueryItem(this, SqlCeDataTypesMetadata.ColumnNames.NumericType, esSystemType.Decimal); }
		} 
		
		public esQueryItem RealType
		{
			get { return new esQueryItem(this, SqlCeDataTypesMetadata.ColumnNames.RealType, esSystemType.Single); }
		} 
		
		public esQueryItem FloatType
		{
			get { return new esQueryItem(this, SqlCeDataTypesMetadata.ColumnNames.FloatType, esSystemType.Double); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "SqlCeDataTypes")]
	[XmlType(TypeName="SqlCeDataTypesProxyStub")]	
	[Serializable]
	public partial class SqlCeDataTypesProxyStub
	{
		public SqlCeDataTypesProxyStub() 
		{
			theEntity = this.entity = new SqlCeDataTypes();
		}

		public SqlCeDataTypesProxyStub(SqlCeDataTypes obj)
		{
			theEntity = this.entity = obj;
		}

		public SqlCeDataTypesProxyStub(SqlCeDataTypes obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator SqlCeDataTypes(SqlCeDataTypesProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(SqlCeDataTypes);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.Int32? Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(SqlCeDataTypesMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="NumericType", Order=2, EmitDefaultValue=false)]
		public System.Decimal? NumericType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlCeDataTypesMetadata.ColumnNames.NumericType))
					return this.Entity.NumericType;
				else
					return null;
			}
			set { this.Entity.NumericType = value; }
		}

		[DataMember(Name="RealType", Order=3, EmitDefaultValue=false)]
		public System.Single? RealType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlCeDataTypesMetadata.ColumnNames.RealType))
					return this.Entity.RealType;
				else
					return null;
			}
			set { this.Entity.RealType = value; }
		}

		[DataMember(Name="FloatType", Order=4, EmitDefaultValue=false)]
		public System.Double? FloatType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlCeDataTypesMetadata.ColumnNames.FloatType))
					return this.Entity.FloatType;
				else
					return null;
			}
			set { this.Entity.FloatType = value; }
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
		public SqlCeDataTypes Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new SqlCeDataTypes();
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
		public SqlCeDataTypes entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "SqlCeDataTypesCollection")]
	[XmlType(TypeName="SqlCeDataTypesCollectionProxyStub")]	
	[Serializable]
	public partial class SqlCeDataTypesCollectionProxyStub 
	{
		protected SqlCeDataTypesCollectionProxyStub() {}
		
		public SqlCeDataTypesCollectionProxyStub(esEntityCollection<SqlCeDataTypes> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public SqlCeDataTypesCollectionProxyStub(esEntityCollection<SqlCeDataTypes> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator SqlCeDataTypesCollection(SqlCeDataTypesCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(SqlCeDataTypes);
		}
		
		public SqlCeDataTypesCollectionProxyStub(esEntityCollection<SqlCeDataTypes> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (SqlCeDataTypes entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new SqlCeDataTypesProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new SqlCeDataTypesProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (SqlCeDataTypes entity in coll.es.DeletedEntities)
				{
					Collection.Add(new SqlCeDataTypesProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<SqlCeDataTypesProxyStub> Collection = new List<SqlCeDataTypesProxyStub>();

		public SqlCeDataTypesCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new SqlCeDataTypesCollection();

				foreach (SqlCeDataTypesProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private SqlCeDataTypesCollection _coll;
	}



	[Serializable]
	public partial class SqlCeDataTypesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SqlCeDataTypesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SqlCeDataTypesMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = SqlCeDataTypesMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlCeDataTypesMetadata.ColumnNames.NumericType, 1, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = SqlCeDataTypesMetadata.PropertyNames.NumericType;
			c.NumericPrecision = 18;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlCeDataTypesMetadata.ColumnNames.RealType, 2, typeof(System.Single), esSystemType.Single);
			c.PropertyName = SqlCeDataTypesMetadata.PropertyNames.RealType;
			c.NumericPrecision = 24;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlCeDataTypesMetadata.ColumnNames.FloatType, 3, typeof(System.Double), esSystemType.Double);
			c.PropertyName = SqlCeDataTypesMetadata.PropertyNames.FloatType;
			c.NumericPrecision = 53;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SqlCeDataTypesMetadata Meta()
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
			 public const string NumericType = "NumericType";
			 public const string RealType = "RealType";
			 public const string FloatType = "FloatType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string NumericType = "NumericType";
			 public const string RealType = "RealType";
			 public const string FloatType = "FloatType";
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
			lock (typeof(SqlCeDataTypesMetadata))
			{
				if(SqlCeDataTypesMetadata.mapDelegates == null)
				{
					SqlCeDataTypesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SqlCeDataTypesMetadata.meta == null)
				{
					SqlCeDataTypesMetadata.meta = new SqlCeDataTypesMetadata();
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
				meta.AddTypeMap("NumericType", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("RealType", new esTypeMap("real", "System.Single"));
				meta.AddTypeMap("FloatType", new esTypeMap("float", "System.Double"));			
				meta.Catalog = "AggregateDb.sdf";
				
				
				meta.Source = "SqlCeDataTypes";
				meta.Destination = "SqlCeDataTypes";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SqlCeDataTypesMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
