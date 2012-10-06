
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:36 AM
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
	/// Encapsulates the 'Naming Test2' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(NamingTest2))]	
	[XmlType("NamingTest2")]
	[Table(Name="NamingTest2")]
	public partial class NamingTest2 : esNamingTest2
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new NamingTest2();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 identityKey)
		{
			var obj = new NamingTest2();
			obj.IdentityKey = identityKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 identityKey, esSqlAccessType sqlAccessType)
		{
			var obj = new NamingTest2();
			obj.IdentityKey = identityKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator NamingTest2ProxyStub(NamingTest2 entity)
		{
			return new NamingTest2ProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? IdentityKey
		{
			get { return base.IdentityKey;  }
			set { base.IdentityKey = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String ItemDescription
		{
			get { return base.ItemDescription;  }
			set { base.ItemDescription = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Byte[] ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Guid? GuidNewid
		{
			get { return base.GuidNewid;  }
			set { base.GuidNewid = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("NamingTest2Collection")]
	public partial class NamingTest2Collection : esNamingTest2Collection, IEnumerable<NamingTest2>
	{
		public NamingTest2 FindByPrimaryKey(System.Int32 identityKey)
		{
			return this.SingleOrDefault(e => e.IdentityKey == identityKey);
		}

		#region Implicit Casts
		
		public static implicit operator NamingTest2CollectionProxyStub(NamingTest2Collection coll)
		{
			return new NamingTest2CollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(NamingTest2))]
		public class NamingTest2CollectionWCFPacket : esCollectionWCFPacket<NamingTest2Collection>
		{
			public static implicit operator NamingTest2Collection(NamingTest2CollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator NamingTest2CollectionWCFPacket(NamingTest2Collection collection)
			{
				return new NamingTest2CollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "NamingTest2Query", Namespace = "http://www.entityspaces.net")]	
	public partial class NamingTest2Query : esNamingTest2Query
	{
		public NamingTest2Query(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "NamingTest2Query";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(NamingTest2Query query)
		{
			return NamingTest2Query.SerializeHelper.ToXml(query);
		}

		public static explicit operator NamingTest2Query(string query)
		{
			return (NamingTest2Query)NamingTest2Query.SerializeHelper.FromXml(query, typeof(NamingTest2Query));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esNamingTest2 : EntityBase
	{
		public esNamingTest2()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 identityKey)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(identityKey);
			else
				return LoadByPrimaryKeyStoredProcedure(identityKey);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 identityKey)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(identityKey);
			else
				return LoadByPrimaryKeyStoredProcedure(identityKey);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 identityKey)
		{
			NamingTest2Query query = new NamingTest2Query();
			query.Where(query.IdentityKey == identityKey);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 identityKey)
		{
			esParameters parms = new esParameters();
			parms.Add("IdentityKey", identityKey);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Naming Test2.Identity.Key
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? IdentityKey
		{
			get
			{
				return base.GetSystemInt32(NamingTest2Metadata.ColumnNames.IdentityKey);
			}
			
			set
			{
				if(base.SetSystemInt32(NamingTest2Metadata.ColumnNames.IdentityKey, value))
				{
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.IdentityKey);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming Test2.Item.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ItemDescription
		{
			get
			{
				return base.GetSystemString(NamingTest2Metadata.ColumnNames.ItemDescription);
			}
			
			set
			{
				if(base.SetSystemString(NamingTest2Metadata.ColumnNames.ItemDescription, value))
				{
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.ItemDescription);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming Test2.Concurrency.Check
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte[] ConcurrencyCheck
		{
			get
			{
				return base.GetSystemByteArray(NamingTest2Metadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemByteArray(NamingTest2Metadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming Test2.Guid.Newid
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? GuidNewid
		{
			get
			{
				return base.GetSystemGuid(NamingTest2Metadata.ColumnNames.GuidNewid);
			}
			
			set
			{
				if(base.SetSystemGuid(NamingTest2Metadata.ColumnNames.GuidNewid, value))
				{
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.GuidNewid);
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
						case "IdentityKey": this.str().IdentityKey = (string)value; break;							
						case "ItemDescription": this.str().ItemDescription = (string)value; break;							
						case "GuidNewid": this.str().GuidNewid = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "IdentityKey":
						
							if (value == null || value is System.Int32)
								this.IdentityKey = (System.Int32?)value;
								OnPropertyChanged(NamingTest2Metadata.PropertyNames.IdentityKey);
							break;
						
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Byte[])
								this.ConcurrencyCheck = (System.Byte[])value;
								OnPropertyChanged(NamingTest2Metadata.PropertyNames.ConcurrencyCheck);
							break;
						
						case "GuidNewid":
						
							if (value == null || value is System.Guid)
								this.GuidNewid = (System.Guid?)value;
								OnPropertyChanged(NamingTest2Metadata.PropertyNames.GuidNewid);
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
			public esStrings(esNamingTest2 entity)
			{
				this.entity = entity;
			}
			
	
			public System.String IdentityKey
			{
				get
				{
					System.Int32? data = entity.IdentityKey;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IdentityKey = null;
					else entity.IdentityKey = Convert.ToInt32(value);
				}
			}
				
			public System.String ItemDescription
			{
				get
				{
					System.String data = entity.ItemDescription;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ItemDescription = null;
					else entity.ItemDescription = Convert.ToString(value);
				}
			}
				
			public System.String GuidNewid
			{
				get
				{
					System.Guid? data = entity.GuidNewid;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GuidNewid = null;
					else entity.GuidNewid = new Guid(value);
				}
			}
			

			private esNamingTest2 entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return NamingTest2Metadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public NamingTest2Query Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NamingTest2Query();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NamingTest2Query query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(NamingTest2Query query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private NamingTest2Query query;		
	}



	[Serializable]
	abstract public partial class esNamingTest2Collection : CollectionBase<NamingTest2>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return NamingTest2Metadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "NamingTest2Collection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public NamingTest2Query Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NamingTest2Query();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NamingTest2Query query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new NamingTest2Query();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(NamingTest2Query query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((NamingTest2Query)query);
		}

		#endregion
		
		private NamingTest2Query query;
	}



	[Serializable]
	abstract public partial class esNamingTest2Query : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return NamingTest2Metadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "IdentityKey": return this.IdentityKey;
				case "ItemDescription": return this.ItemDescription;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;
				case "GuidNewid": return this.GuidNewid;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem IdentityKey
		{
			get { return new esQueryItem(this, NamingTest2Metadata.ColumnNames.IdentityKey, esSystemType.Int32); }
		} 
		
		public esQueryItem ItemDescription
		{
			get { return new esQueryItem(this, NamingTest2Metadata.ColumnNames.ItemDescription, esSystemType.String); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, NamingTest2Metadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray); }
		} 
		
		public esQueryItem GuidNewid
		{
			get { return new esQueryItem(this, NamingTest2Metadata.ColumnNames.GuidNewid, esSystemType.Guid); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTest2")]
	[XmlType(TypeName="NamingTest2ProxyStub")]	
	[Serializable]
	public partial class NamingTest2ProxyStub
	{
		public NamingTest2ProxyStub() 
		{
			theEntity = this.entity = new NamingTest2();
		}

		public NamingTest2ProxyStub(NamingTest2 obj)
		{
			theEntity = this.entity = obj;
		}

		public NamingTest2ProxyStub(NamingTest2 obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator NamingTest2(NamingTest2ProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(NamingTest2);
		}

		[DataMember(Name="IdentityKey", Order=1, EmitDefaultValue=false)]
		public System.Int32? IdentityKey
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(NamingTest2Metadata.ColumnNames.IdentityKey);
				else
					return this.Entity.IdentityKey;
			}
			set { this.Entity.IdentityKey = value; }
		}

		[DataMember(Name="ItemDescription", Order=2, EmitDefaultValue=false)]
		public System.String ItemDescription
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTest2Metadata.ColumnNames.ItemDescription))
					return this.Entity.ItemDescription;
				else
					return null;
			}
			set { this.Entity.ItemDescription = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=3, EmitDefaultValue=false)]
		public System.Byte[] ConcurrencyCheck
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Byte[])this.Entity.
						GetOriginalColumnValue(NamingTest2Metadata.ColumnNames.ConcurrencyCheck);
				else
					return this.Entity.ConcurrencyCheck;
			}
			set { this.Entity.ConcurrencyCheck = value; }
		}

		[DataMember(Name="GuidNewid", Order=4, EmitDefaultValue=false)]
		public System.Guid? GuidNewid
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTest2Metadata.ColumnNames.GuidNewid))
					return this.Entity.GuidNewid;
				else
					return null;
			}
			set { this.Entity.GuidNewid = value; }
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
		public NamingTest2 Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new NamingTest2();
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
		public NamingTest2 entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTest2Collection")]
	[XmlType(TypeName="NamingTest2CollectionProxyStub")]	
	[Serializable]
	public partial class NamingTest2CollectionProxyStub 
	{
		protected NamingTest2CollectionProxyStub() {}
		
		public NamingTest2CollectionProxyStub(esEntityCollection<NamingTest2> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public NamingTest2CollectionProxyStub(esEntityCollection<NamingTest2> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator NamingTest2Collection(NamingTest2CollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(NamingTest2);
		}
		
		public NamingTest2CollectionProxyStub(esEntityCollection<NamingTest2> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (NamingTest2 entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new NamingTest2ProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new NamingTest2ProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (NamingTest2 entity in coll.es.DeletedEntities)
				{
					Collection.Add(new NamingTest2ProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<NamingTest2ProxyStub> Collection = new List<NamingTest2ProxyStub>();

		public NamingTest2Collection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new NamingTest2Collection();

				foreach (NamingTest2ProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private NamingTest2Collection _coll;
	}



	[Serializable]
	public partial class NamingTest2Metadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected NamingTest2Metadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(NamingTest2Metadata.ColumnNames.IdentityKey, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = NamingTest2Metadata.PropertyNames.IdentityKey;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTest2Metadata.ColumnNames.ItemDescription, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = NamingTest2Metadata.PropertyNames.ItemDescription;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTest2Metadata.ColumnNames.ConcurrencyCheck, 2, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = NamingTest2Metadata.PropertyNames.ConcurrencyCheck;
			c.CharacterMaxLength = 8;
			c.IsComputed = true;
			c.IsConcurrency = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTest2Metadata.ColumnNames.GuidNewid, 3, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = NamingTest2Metadata.PropertyNames.GuidNewid;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public NamingTest2Metadata Meta()
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
			 public const string IdentityKey = "Identity.Key";
			 public const string ItemDescription = "Item.Description";
			 public const string ConcurrencyCheck = "Concurrency.Check";
			 public const string GuidNewid = "Guid.Newid";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string IdentityKey = "IdentityKey";
			 public const string ItemDescription = "ItemDescription";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string GuidNewid = "GuidNewid";
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
			lock (typeof(NamingTest2Metadata))
			{
				if(NamingTest2Metadata.mapDelegates == null)
				{
					NamingTest2Metadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (NamingTest2Metadata.meta == null)
				{
					NamingTest2Metadata.meta = new NamingTest2Metadata();
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


				meta.AddTypeMap("IdentityKey", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ItemDescription", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte[]"));
				meta.AddTypeMap("GuidNewid", new esTypeMap("uniqueidentifier", "System.Guid"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "Naming Test2";
				meta.Destination = "Naming Test2";
				
				meta.spInsert = "proc_Naming Test2Insert";				
				meta.spUpdate = "proc_Naming Test2Update";		
				meta.spDelete = "proc_Naming Test2Delete";
				meta.spLoadAll = "proc_Naming Test2LoadAll";
				meta.spLoadByPrimaryKey = "proc_Naming Test2LoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private NamingTest2Metadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
