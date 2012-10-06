
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
	/// Encapsulates the 'ConstructorTest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(ConstructorTest))]	
	[XmlType("ConstructorTest")]
	[Table(Name="ConstructorTest")]
	public partial class ConstructorTest : esConstructorTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ConstructorTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int64 constructorTestId)
		{
			var obj = new ConstructorTest();
			obj.ConstructorTestId = constructorTestId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int64 constructorTestId, esSqlAccessType sqlAccessType)
		{
			var obj = new ConstructorTest();
			obj.ConstructorTestId = constructorTestId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ConstructorTestProxyStub(ConstructorTest entity)
		{
			return new ConstructorTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int64? ConstructorTestId
		{
			get { return base.ConstructorTestId;  }
			set { base.ConstructorTestId = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int32? DefaultInt
		{
			get { return base.DefaultInt;  }
			set { base.DefaultInt = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Boolean? DefaultBool
		{
			get { return base.DefaultBool;  }
			set { base.DefaultBool = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.DateTime? DefaultDateTime
		{
			get { return base.DefaultDateTime;  }
			set { base.DefaultDateTime = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String DefaultString
		{
			get { return base.DefaultString;  }
			set { base.DefaultString = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ConstructorTestCollection")]
	public partial class ConstructorTestCollection : esConstructorTestCollection, IEnumerable<ConstructorTest>
	{
		public ConstructorTest FindByPrimaryKey(System.Int64 constructorTestId)
		{
			return this.SingleOrDefault(e => e.ConstructorTestId == constructorTestId);
		}

		#region Implicit Casts
		
		public static implicit operator ConstructorTestCollectionProxyStub(ConstructorTestCollection coll)
		{
			return new ConstructorTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ConstructorTest))]
		public class ConstructorTestCollectionWCFPacket : esCollectionWCFPacket<ConstructorTestCollection>
		{
			public static implicit operator ConstructorTestCollection(ConstructorTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ConstructorTestCollectionWCFPacket(ConstructorTestCollection collection)
			{
				return new ConstructorTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ConstructorTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ConstructorTestQuery : esConstructorTestQuery
	{
		public ConstructorTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ConstructorTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ConstructorTestQuery query)
		{
			return ConstructorTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ConstructorTestQuery(string query)
		{
			return (ConstructorTestQuery)ConstructorTestQuery.SerializeHelper.FromXml(query, typeof(ConstructorTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esConstructorTest : EntityBase
	{
		public esConstructorTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 constructorTestId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(constructorTestId);
			else
				return LoadByPrimaryKeyStoredProcedure(constructorTestId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 constructorTestId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(constructorTestId);
			else
				return LoadByPrimaryKeyStoredProcedure(constructorTestId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 constructorTestId)
		{
			ConstructorTestQuery query = new ConstructorTestQuery();
			query.Where(query.ConstructorTestId == constructorTestId);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 constructorTestId)
		{
			esParameters parms = new esParameters();
			parms.Add("ConstructorTestId", constructorTestId);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ConstructorTest.ConstructorTestId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? ConstructorTestId
		{
			get
			{
				return base.GetSystemInt64(ConstructorTestMetadata.ColumnNames.ConstructorTestId);
			}
			
			set
			{
				if(base.SetSystemInt64(ConstructorTestMetadata.ColumnNames.ConstructorTestId, value))
				{
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.ConstructorTestId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConstructorTest.DefaultInt
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? DefaultInt
		{
			get
			{
				return base.GetSystemInt32(ConstructorTestMetadata.ColumnNames.DefaultInt);
			}
			
			set
			{
				if(base.SetSystemInt32(ConstructorTestMetadata.ColumnNames.DefaultInt, value))
				{
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultInt);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConstructorTest.DefaultBool
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? DefaultBool
		{
			get
			{
				return base.GetSystemBoolean(ConstructorTestMetadata.ColumnNames.DefaultBool);
			}
			
			set
			{
				if(base.SetSystemBoolean(ConstructorTestMetadata.ColumnNames.DefaultBool, value))
				{
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultBool);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConstructorTest.DefaultDateTime
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DefaultDateTime
		{
			get
			{
				return base.GetSystemDateTime(ConstructorTestMetadata.ColumnNames.DefaultDateTime);
			}
			
			set
			{
				if(base.SetSystemDateTime(ConstructorTestMetadata.ColumnNames.DefaultDateTime, value))
				{
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultDateTime);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConstructorTest.DefaultString
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String DefaultString
		{
			get
			{
				return base.GetSystemString(ConstructorTestMetadata.ColumnNames.DefaultString);
			}
			
			set
			{
				if(base.SetSystemString(ConstructorTestMetadata.ColumnNames.DefaultString, value))
				{
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultString);
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
						case "ConstructorTestId": this.str().ConstructorTestId = (string)value; break;							
						case "DefaultInt": this.str().DefaultInt = (string)value; break;							
						case "DefaultBool": this.str().DefaultBool = (string)value; break;							
						case "DefaultDateTime": this.str().DefaultDateTime = (string)value; break;							
						case "DefaultString": this.str().DefaultString = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ConstructorTestId":
						
							if (value == null || value is System.Int64)
								this.ConstructorTestId = (System.Int64?)value;
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.ConstructorTestId);
							break;
						
						case "DefaultInt":
						
							if (value == null || value is System.Int32)
								this.DefaultInt = (System.Int32?)value;
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultInt);
							break;
						
						case "DefaultBool":
						
							if (value == null || value is System.Boolean)
								this.DefaultBool = (System.Boolean?)value;
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultBool);
							break;
						
						case "DefaultDateTime":
						
							if (value == null || value is System.DateTime)
								this.DefaultDateTime = (System.DateTime?)value;
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultDateTime);
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
			public esStrings(esConstructorTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String ConstructorTestId
			{
				get
				{
					System.Int64? data = entity.ConstructorTestId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ConstructorTestId = null;
					else entity.ConstructorTestId = Convert.ToInt64(value);
				}
			}
				
			public System.String DefaultInt
			{
				get
				{
					System.Int32? data = entity.DefaultInt;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DefaultInt = null;
					else entity.DefaultInt = Convert.ToInt32(value);
				}
			}
				
			public System.String DefaultBool
			{
				get
				{
					System.Boolean? data = entity.DefaultBool;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DefaultBool = null;
					else entity.DefaultBool = Convert.ToBoolean(value);
				}
			}
				
			public System.String DefaultDateTime
			{
				get
				{
					System.DateTime? data = entity.DefaultDateTime;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DefaultDateTime = null;
					else entity.DefaultDateTime = Convert.ToDateTime(value);
				}
			}
				
			public System.String DefaultString
			{
				get
				{
					System.String data = entity.DefaultString;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DefaultString = null;
					else entity.DefaultString = Convert.ToString(value);
				}
			}
			

			private esConstructorTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ConstructorTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ConstructorTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ConstructorTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ConstructorTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ConstructorTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ConstructorTestQuery query;		
	}



	[Serializable]
	abstract public partial class esConstructorTestCollection : CollectionBase<ConstructorTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ConstructorTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ConstructorTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ConstructorTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ConstructorTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ConstructorTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ConstructorTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ConstructorTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ConstructorTestQuery)query);
		}

		#endregion
		
		private ConstructorTestQuery query;
	}



	[Serializable]
	abstract public partial class esConstructorTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ConstructorTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "ConstructorTestId": return this.ConstructorTestId;
				case "DefaultInt": return this.DefaultInt;
				case "DefaultBool": return this.DefaultBool;
				case "DefaultDateTime": return this.DefaultDateTime;
				case "DefaultString": return this.DefaultString;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ConstructorTestId
		{
			get { return new esQueryItem(this, ConstructorTestMetadata.ColumnNames.ConstructorTestId, esSystemType.Int64); }
		} 
		
		public esQueryItem DefaultInt
		{
			get { return new esQueryItem(this, ConstructorTestMetadata.ColumnNames.DefaultInt, esSystemType.Int32); }
		} 
		
		public esQueryItem DefaultBool
		{
			get { return new esQueryItem(this, ConstructorTestMetadata.ColumnNames.DefaultBool, esSystemType.Boolean); }
		} 
		
		public esQueryItem DefaultDateTime
		{
			get { return new esQueryItem(this, ConstructorTestMetadata.ColumnNames.DefaultDateTime, esSystemType.DateTime); }
		} 
		
		public esQueryItem DefaultString
		{
			get { return new esQueryItem(this, ConstructorTestMetadata.ColumnNames.DefaultString, esSystemType.String); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ConstructorTest")]
	[XmlType(TypeName="ConstructorTestProxyStub")]	
	[Serializable]
	public partial class ConstructorTestProxyStub
	{
		public ConstructorTestProxyStub() 
		{
			theEntity = this.entity = new ConstructorTest();
		}

		public ConstructorTestProxyStub(ConstructorTest obj)
		{
			theEntity = this.entity = obj;
		}

		public ConstructorTestProxyStub(ConstructorTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator ConstructorTest(ConstructorTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(ConstructorTest);
		}

		[DataMember(Name="ConstructorTestId", Order=1, EmitDefaultValue=false)]
		public System.Int64? ConstructorTestId
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int64?)this.Entity.
						GetOriginalColumnValue(ConstructorTestMetadata.ColumnNames.ConstructorTestId);
				else
					return this.Entity.ConstructorTestId;
			}
			set { this.Entity.ConstructorTestId = value; }
		}

		[DataMember(Name="DefaultInt", Order=2, EmitDefaultValue=false)]
		public System.Int32? DefaultInt
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultInt))
					return this.Entity.DefaultInt;
				else
					return null;
			}
			set { this.Entity.DefaultInt = value; }
		}

		[DataMember(Name="DefaultBool", Order=3, EmitDefaultValue=false)]
		public System.Boolean? DefaultBool
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultBool))
					return this.Entity.DefaultBool;
				else
					return null;
			}
			set { this.Entity.DefaultBool = value; }
		}

		[DataMember(Name="DefaultDateTime", Order=4, EmitDefaultValue=false)]
		public System.DateTime? DefaultDateTime
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultDateTime))
					return this.Entity.DefaultDateTime;
				else
					return null;
			}
			set { this.Entity.DefaultDateTime = value; }
		}

		[DataMember(Name="DefaultString", Order=5, EmitDefaultValue=false)]
		public System.String DefaultString
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultString))
					return this.Entity.DefaultString;
				else
					return null;
			}
			set { this.Entity.DefaultString = value; }
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
		public ConstructorTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new ConstructorTest();
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
		public ConstructorTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ConstructorTestCollection")]
	[XmlType(TypeName="ConstructorTestCollectionProxyStub")]	
	[Serializable]
	public partial class ConstructorTestCollectionProxyStub 
	{
		protected ConstructorTestCollectionProxyStub() {}
		
		public ConstructorTestCollectionProxyStub(esEntityCollection<ConstructorTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ConstructorTestCollectionProxyStub(esEntityCollection<ConstructorTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ConstructorTestCollection(ConstructorTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(ConstructorTest);
		}
		
		public ConstructorTestCollectionProxyStub(esEntityCollection<ConstructorTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (ConstructorTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ConstructorTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ConstructorTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (ConstructorTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ConstructorTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ConstructorTestProxyStub> Collection = new List<ConstructorTestProxyStub>();

		public ConstructorTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ConstructorTestCollection();

				foreach (ConstructorTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ConstructorTestCollection _coll;
	}



	[Serializable]
	public partial class ConstructorTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ConstructorTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ConstructorTestMetadata.ColumnNames.ConstructorTestId, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = ConstructorTestMetadata.PropertyNames.ConstructorTestId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultInt, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultInt;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultBool, 2, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultBool;
			c.HasDefault = true;
			c.Default = @"((0))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultDateTime, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultDateTime;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultString, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultString;
			c.CharacterMaxLength = 10;
			c.HasDefault = true;
			c.Default = @"('[new]')";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ConstructorTestMetadata Meta()
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
			 public const string ConstructorTestId = "ConstructorTestId";
			 public const string DefaultInt = "DefaultInt";
			 public const string DefaultBool = "DefaultBool";
			 public const string DefaultDateTime = "DefaultDateTime";
			 public const string DefaultString = "DefaultString";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ConstructorTestId = "ConstructorTestId";
			 public const string DefaultInt = "DefaultInt";
			 public const string DefaultBool = "DefaultBool";
			 public const string DefaultDateTime = "DefaultDateTime";
			 public const string DefaultString = "DefaultString";
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
			lock (typeof(ConstructorTestMetadata))
			{
				if(ConstructorTestMetadata.mapDelegates == null)
				{
					ConstructorTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ConstructorTestMetadata.meta == null)
				{
					ConstructorTestMetadata.meta = new ConstructorTestMetadata();
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


				meta.AddTypeMap("ConstructorTestId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("DefaultInt", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DefaultBool", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("DefaultDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("DefaultString", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "ConstructorTest";
				meta.Destination = "ConstructorTest";
				
				meta.spInsert = "proc_ConstructorTestInsert";				
				meta.spUpdate = "proc_ConstructorTestUpdate";		
				meta.spDelete = "proc_ConstructorTestDelete";
				meta.spLoadAll = "proc_ConstructorTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConstructorTestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ConstructorTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
