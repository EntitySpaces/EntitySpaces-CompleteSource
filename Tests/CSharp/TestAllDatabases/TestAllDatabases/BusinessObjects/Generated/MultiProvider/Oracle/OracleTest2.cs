
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:50 AM
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
	/// Encapsulates the 'OracleTest2' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(OracleTest2))]	
	[XmlType("OracleTest2")]
	[Table(Name="OracleTest2")]
	public partial class OracleTest2 : esOracleTest2
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new OracleTest2();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String id)
		{
			var obj = new OracleTest2();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String id, esSqlAccessType sqlAccessType)
		{
			var obj = new OracleTest2();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator OracleTest2ProxyStub(OracleTest2 entity)
		{
			return new OracleTest2ProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String VarCharType
		{
			get { return base.VarCharType;  }
			set { base.VarCharType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? NumberType
		{
			get { return base.NumberType;  }
			set { base.NumberType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateType
		{
			get { return base.DateType;  }
			set { base.DateType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? DecimalType
		{
			get { return base.DecimalType;  }
			set { base.DecimalType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? BoolType
		{
			get { return base.BoolType;  }
			set { base.BoolType = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("OracleTest2Collection")]
	public partial class OracleTest2Collection : esOracleTest2Collection, IEnumerable<OracleTest2>
	{
		public OracleTest2 FindByPrimaryKey(System.String id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator OracleTest2CollectionProxyStub(OracleTest2Collection coll)
		{
			return new OracleTest2CollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(OracleTest2))]
		public class OracleTest2CollectionWCFPacket : esCollectionWCFPacket<OracleTest2Collection>
		{
			public static implicit operator OracleTest2Collection(OracleTest2CollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator OracleTest2CollectionWCFPacket(OracleTest2Collection collection)
			{
				return new OracleTest2CollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "OracleTest2Query", Namespace = "http://www.entityspaces.net")]	
	public partial class OracleTest2Query : esOracleTest2Query
	{
		public OracleTest2Query(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "OracleTest2Query";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OracleTest2Query query)
		{
			return OracleTest2Query.SerializeHelper.ToXml(query);
		}

		public static explicit operator OracleTest2Query(string query)
		{
			return (OracleTest2Query)OracleTest2Query.SerializeHelper.FromXml(query, typeof(OracleTest2Query));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esOracleTest2 : EntityBase
	{
		public esOracleTest2()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.String id)
		{
			OracleTest2Query query = new OracleTest2Query();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to OracleTest2.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Id
		{
			get
			{
				return base.GetSystemString(OracleTest2Metadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemString(OracleTest2Metadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(OracleTest2Metadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleTest2.ConcurrencyCheck
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? ConcurrencyCheck
		{
			get
			{
				return base.GetSystemDecimal(OracleTest2Metadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleTest2Metadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(OracleTest2Metadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleTest2.VarCharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String VarCharType
		{
			get
			{
				return base.GetSystemString(OracleTest2Metadata.ColumnNames.VarCharType);
			}
			
			set
			{
				if(base.SetSystemString(OracleTest2Metadata.ColumnNames.VarCharType, value))
				{
					OnPropertyChanged(OracleTest2Metadata.PropertyNames.VarCharType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleTest2.NumberType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? NumberType
		{
			get
			{
				return base.GetSystemDecimal(OracleTest2Metadata.ColumnNames.NumberType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleTest2Metadata.ColumnNames.NumberType, value))
				{
					OnPropertyChanged(OracleTest2Metadata.PropertyNames.NumberType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleTest2.DateType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateType
		{
			get
			{
				return base.GetSystemDateTime(OracleTest2Metadata.ColumnNames.DateType);
			}
			
			set
			{
				if(base.SetSystemDateTime(OracleTest2Metadata.ColumnNames.DateType, value))
				{
					OnPropertyChanged(OracleTest2Metadata.PropertyNames.DateType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleTest2.DecimalType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? DecimalType
		{
			get
			{
				return base.GetSystemDecimal(OracleTest2Metadata.ColumnNames.DecimalType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleTest2Metadata.ColumnNames.DecimalType, value))
				{
					OnPropertyChanged(OracleTest2Metadata.PropertyNames.DecimalType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleTest2.BoolType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? BoolType
		{
			get
			{
				return base.GetSystemDecimal(OracleTest2Metadata.ColumnNames.BoolType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleTest2Metadata.ColumnNames.BoolType, value))
				{
					OnPropertyChanged(OracleTest2Metadata.PropertyNames.BoolType);
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
						case "ConcurrencyCheck": this.str().ConcurrencyCheck = (string)value; break;							
						case "VarCharType": this.str().VarCharType = (string)value; break;							
						case "NumberType": this.str().NumberType = (string)value; break;							
						case "DateType": this.str().DateType = (string)value; break;							
						case "DecimalType": this.str().DecimalType = (string)value; break;							
						case "BoolType": this.str().BoolType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Decimal)
								this.ConcurrencyCheck = (System.Decimal?)value;
								OnPropertyChanged(OracleTest2Metadata.PropertyNames.ConcurrencyCheck);
							break;
						
						case "NumberType":
						
							if (value == null || value is System.Decimal)
								this.NumberType = (System.Decimal?)value;
								OnPropertyChanged(OracleTest2Metadata.PropertyNames.NumberType);
							break;
						
						case "DateType":
						
							if (value == null || value is System.DateTime)
								this.DateType = (System.DateTime?)value;
								OnPropertyChanged(OracleTest2Metadata.PropertyNames.DateType);
							break;
						
						case "DecimalType":
						
							if (value == null || value is System.Decimal)
								this.DecimalType = (System.Decimal?)value;
								OnPropertyChanged(OracleTest2Metadata.PropertyNames.DecimalType);
							break;
						
						case "BoolType":
						
							if (value == null || value is System.Decimal)
								this.BoolType = (System.Decimal?)value;
								OnPropertyChanged(OracleTest2Metadata.PropertyNames.BoolType);
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
			public esStrings(esOracleTest2 entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.String data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToString(value);
				}
			}
				
			public System.String ConcurrencyCheck
			{
				get
				{
					System.Decimal? data = entity.ConcurrencyCheck;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ConcurrencyCheck = null;
					else entity.ConcurrencyCheck = Convert.ToDecimal(value);
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
				
			public System.String NumberType
			{
				get
				{
					System.Decimal? data = entity.NumberType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NumberType = null;
					else entity.NumberType = Convert.ToDecimal(value);
				}
			}
				
			public System.String DateType
			{
				get
				{
					System.DateTime? data = entity.DateType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateType = null;
					else entity.DateType = Convert.ToDateTime(value);
				}
			}
				
			public System.String DecimalType
			{
				get
				{
					System.Decimal? data = entity.DecimalType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DecimalType = null;
					else entity.DecimalType = Convert.ToDecimal(value);
				}
			}
				
			public System.String BoolType
			{
				get
				{
					System.Decimal? data = entity.BoolType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.BoolType = null;
					else entity.BoolType = Convert.ToDecimal(value);
				}
			}
			

			private esOracleTest2 entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return OracleTest2Metadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public OracleTest2Query Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OracleTest2Query();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OracleTest2Query query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(OracleTest2Query query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private OracleTest2Query query;		
	}



	[Serializable]
	abstract public partial class esOracleTest2Collection : CollectionBase<OracleTest2>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return OracleTest2Metadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "OracleTest2Collection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public OracleTest2Query Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OracleTest2Query();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OracleTest2Query query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new OracleTest2Query();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(OracleTest2Query query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((OracleTest2Query)query);
		}

		#endregion
		
		private OracleTest2Query query;
	}



	[Serializable]
	abstract public partial class esOracleTest2Query : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return OracleTest2Metadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;
				case "VarCharType": return this.VarCharType;
				case "NumberType": return this.NumberType;
				case "DateType": return this.DateType;
				case "DecimalType": return this.DecimalType;
				case "BoolType": return this.BoolType;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, OracleTest2Metadata.ColumnNames.Id, esSystemType.String); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, OracleTest2Metadata.ColumnNames.ConcurrencyCheck, esSystemType.Decimal); }
		} 
		
		public esQueryItem VarCharType
		{
			get { return new esQueryItem(this, OracleTest2Metadata.ColumnNames.VarCharType, esSystemType.String); }
		} 
		
		public esQueryItem NumberType
		{
			get { return new esQueryItem(this, OracleTest2Metadata.ColumnNames.NumberType, esSystemType.Decimal); }
		} 
		
		public esQueryItem DateType
		{
			get { return new esQueryItem(this, OracleTest2Metadata.ColumnNames.DateType, esSystemType.DateTime); }
		} 
		
		public esQueryItem DecimalType
		{
			get { return new esQueryItem(this, OracleTest2Metadata.ColumnNames.DecimalType, esSystemType.Decimal); }
		} 
		
		public esQueryItem BoolType
		{
			get { return new esQueryItem(this, OracleTest2Metadata.ColumnNames.BoolType, esSystemType.Decimal); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OracleTest2")]
	[XmlType(TypeName="OracleTest2ProxyStub")]	
	[Serializable]
	public partial class OracleTest2ProxyStub
	{
		public OracleTest2ProxyStub() 
		{
			theEntity = this.entity = new OracleTest2();
		}

		public OracleTest2ProxyStub(OracleTest2 obj)
		{
			theEntity = this.entity = obj;
		}

		public OracleTest2ProxyStub(OracleTest2 obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator OracleTest2(OracleTest2ProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(OracleTest2);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.String Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(OracleTest2Metadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=2, EmitDefaultValue=false)]
		public System.Decimal? ConcurrencyCheck
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleTest2Metadata.ColumnNames.ConcurrencyCheck))
					return this.Entity.ConcurrencyCheck;
				else
					return null;
			}
			set { this.Entity.ConcurrencyCheck = value; }
		}

		[DataMember(Name="VarCharType", Order=3, EmitDefaultValue=false)]
		public System.String VarCharType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleTest2Metadata.ColumnNames.VarCharType))
					return this.Entity.VarCharType;
				else
					return null;
			}
			set { this.Entity.VarCharType = value; }
		}

		[DataMember(Name="NumberType", Order=4, EmitDefaultValue=false)]
		public System.Decimal? NumberType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleTest2Metadata.ColumnNames.NumberType))
					return this.Entity.NumberType;
				else
					return null;
			}
			set { this.Entity.NumberType = value; }
		}

		[DataMember(Name="DateType", Order=5, EmitDefaultValue=false)]
		public System.DateTime? DateType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleTest2Metadata.ColumnNames.DateType))
					return this.Entity.DateType;
				else
					return null;
			}
			set { this.Entity.DateType = value; }
		}

		[DataMember(Name="DecimalType", Order=6, EmitDefaultValue=false)]
		public System.Decimal? DecimalType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleTest2Metadata.ColumnNames.DecimalType))
					return this.Entity.DecimalType;
				else
					return null;
			}
			set { this.Entity.DecimalType = value; }
		}

		[DataMember(Name="BoolType", Order=7, EmitDefaultValue=false)]
		public System.Decimal? BoolType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleTest2Metadata.ColumnNames.BoolType))
					return this.Entity.BoolType;
				else
					return null;
			}
			set { this.Entity.BoolType = value; }
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
		public OracleTest2 Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new OracleTest2();
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
		public OracleTest2 entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OracleTest2Collection")]
	[XmlType(TypeName="OracleTest2CollectionProxyStub")]	
	[Serializable]
	public partial class OracleTest2CollectionProxyStub 
	{
		protected OracleTest2CollectionProxyStub() {}
		
		public OracleTest2CollectionProxyStub(esEntityCollection<OracleTest2> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public OracleTest2CollectionProxyStub(esEntityCollection<OracleTest2> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator OracleTest2Collection(OracleTest2CollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(OracleTest2);
		}
		
		public OracleTest2CollectionProxyStub(esEntityCollection<OracleTest2> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (OracleTest2 entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new OracleTest2ProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new OracleTest2ProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (OracleTest2 entity in coll.es.DeletedEntities)
				{
					Collection.Add(new OracleTest2ProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<OracleTest2ProxyStub> Collection = new List<OracleTest2ProxyStub>();

		public OracleTest2Collection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new OracleTest2Collection();

				foreach (OracleTest2ProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private OracleTest2Collection _coll;
	}



	[Serializable]
	public partial class OracleTest2Metadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OracleTest2Metadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(OracleTest2Metadata.ColumnNames.Id, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = OracleTest2Metadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleTest2Metadata.ColumnNames.ConcurrencyCheck, 1, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleTest2Metadata.PropertyNames.ConcurrencyCheck;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			c.IsEntitySpacesConcurrency = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleTest2Metadata.ColumnNames.VarCharType, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = OracleTest2Metadata.PropertyNames.VarCharType;
			c.CharacterMaxLength = 25;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleTest2Metadata.ColumnNames.NumberType, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleTest2Metadata.PropertyNames.NumberType;
			c.NumericPrecision = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleTest2Metadata.ColumnNames.DateType, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = OracleTest2Metadata.PropertyNames.DateType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleTest2Metadata.ColumnNames.DecimalType, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleTest2Metadata.PropertyNames.DecimalType;
			c.NumericPrecision = 8;
			c.NumericScale = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleTest2Metadata.ColumnNames.BoolType, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleTest2Metadata.PropertyNames.BoolType;
			c.NumericPrecision = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public OracleTest2Metadata Meta()
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
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string VarCharType = "VarCharType";
			 public const string NumberType = "NumberType";
			 public const string DateType = "DateType";
			 public const string DecimalType = "DecimalType";
			 public const string BoolType = "BoolType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string VarCharType = "VarCharType";
			 public const string NumberType = "NumberType";
			 public const string DateType = "DateType";
			 public const string DecimalType = "DecimalType";
			 public const string BoolType = "BoolType";
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
			lock (typeof(OracleTest2Metadata))
			{
				if(OracleTest2Metadata.mapDelegates == null)
				{
					OracleTest2Metadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OracleTest2Metadata.meta == null)
				{
					OracleTest2Metadata.meta = new OracleTest2Metadata();
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


				meta.AddTypeMap("Id", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("NumberType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("DecimalType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("BoolType", new esTypeMap("NUMBER", "System.Decimal"));			
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				
				meta.Source = "OracleTest2";
				meta.Destination = "OracleTest2";
				
				meta.spInsert = "esOracleTest2Insert";				
				meta.spUpdate = "esOracleTest2Update";		
				meta.spDelete = "esOracleTest2Delete";
				meta.spLoadAll = "esOracleTest2LoadAll";
				meta.spLoadByPrimaryKey = "esOracleTest2LoadByPK";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private OracleTest2Metadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
