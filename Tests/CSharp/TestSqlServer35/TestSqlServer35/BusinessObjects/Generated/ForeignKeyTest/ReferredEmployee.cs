
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:38 AM
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
	/// Encapsulates the 'ReferredEmployee' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(ReferredEmployee))]	
	[XmlType("ReferredEmployee")]
	[Table(Name="ReferredEmployee")]
	public partial class ReferredEmployee : esReferredEmployee
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ReferredEmployee();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 employeeID, System.Int32 referredID)
		{
			var obj = new ReferredEmployee();
			obj.EmployeeID = employeeID;
			obj.ReferredID = referredID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 employeeID, System.Int32 referredID, esSqlAccessType sqlAccessType)
		{
			var obj = new ReferredEmployee();
			obj.EmployeeID = employeeID;
			obj.ReferredID = referredID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ReferredEmployeeProxyStub(ReferredEmployee entity)
		{
			return new ReferredEmployeeProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? EmployeeID
		{
			get { return base.EmployeeID;  }
			set { base.EmployeeID = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? ReferredID
		{
			get { return base.ReferredID;  }
			set { base.ReferredID = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ReferredEmployeeCollection")]
	public partial class ReferredEmployeeCollection : esReferredEmployeeCollection, IEnumerable<ReferredEmployee>
	{
		public ReferredEmployee FindByPrimaryKey(System.Int32 employeeID, System.Int32 referredID)
		{
			return this.SingleOrDefault(e => e.EmployeeID == employeeID && e.ReferredID == referredID);
		}

		#region Implicit Casts
		
		public static implicit operator ReferredEmployeeCollectionProxyStub(ReferredEmployeeCollection coll)
		{
			return new ReferredEmployeeCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ReferredEmployee))]
		public class ReferredEmployeeCollectionWCFPacket : esCollectionWCFPacket<ReferredEmployeeCollection>
		{
			public static implicit operator ReferredEmployeeCollection(ReferredEmployeeCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ReferredEmployeeCollectionWCFPacket(ReferredEmployeeCollection collection)
			{
				return new ReferredEmployeeCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ReferredEmployeeQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ReferredEmployeeQuery : esReferredEmployeeQuery
	{
		public ReferredEmployeeQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ReferredEmployeeQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ReferredEmployeeQuery query)
		{
			return ReferredEmployeeQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ReferredEmployeeQuery(string query)
		{
			return (ReferredEmployeeQuery)ReferredEmployeeQuery.SerializeHelper.FromXml(query, typeof(ReferredEmployeeQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esReferredEmployee : esEntity
	{
		public esReferredEmployee()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 employeeID, System.Int32 referredID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID, referredID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID, referredID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 employeeID, System.Int32 referredID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID, referredID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID, referredID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 employeeID, System.Int32 referredID)
		{
			ReferredEmployeeQuery query = new ReferredEmployeeQuery();
			query.Where(query.EmployeeID == employeeID, query.ReferredID == referredID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 employeeID, System.Int32 referredID)
		{
			esParameters parms = new esParameters();
			parms.Add("EmployeeID", employeeID);			parms.Add("ReferredID", referredID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ReferredEmployee.EmployeeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? EmployeeID
		{
			get
			{
				return base.GetSystemInt32(ReferredEmployeeMetadata.ColumnNames.EmployeeID);
			}
			
			set
			{
				if(base.SetSystemInt32(ReferredEmployeeMetadata.ColumnNames.EmployeeID, value))
				{
					this._UpToEmployeeByEmployeeID = null;
					this.OnPropertyChanged("UpToEmployeeByEmployeeID");
					OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.EmployeeID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ReferredEmployee.ReferredID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ReferredID
		{
			get
			{
				return base.GetSystemInt32(ReferredEmployeeMetadata.ColumnNames.ReferredID);
			}
			
			set
			{
				if(base.SetSystemInt32(ReferredEmployeeMetadata.ColumnNames.ReferredID, value))
				{
					this._UpToEmployeeByReferredID = null;
					this.OnPropertyChanged("UpToEmployeeByReferredID");
					OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.ReferredID);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeByEmployeeID;
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeByReferredID;
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
						case "EmployeeID": this.str().EmployeeID = (string)value; break;							
						case "ReferredID": this.str().ReferredID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "EmployeeID":
						
							if (value == null || value is System.Int32)
								this.EmployeeID = (System.Int32?)value;
								OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.EmployeeID);
							break;
						
						case "ReferredID":
						
							if (value == null || value is System.Int32)
								this.ReferredID = (System.Int32?)value;
								OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.ReferredID);
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
			public esStrings(esReferredEmployee entity)
			{
				this.entity = entity;
			}
			
	
			public System.String EmployeeID
			{
				get
				{
					System.Int32? data = entity.EmployeeID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EmployeeID = null;
					else entity.EmployeeID = Convert.ToInt32(value);
				}
			}
				
			public System.String ReferredID
			{
				get
				{
					System.Int32? data = entity.ReferredID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ReferredID = null;
					else entity.ReferredID = Convert.ToInt32(value);
				}
			}
			

			private esReferredEmployee entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ReferredEmployeeMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ReferredEmployeeQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ReferredEmployeeQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ReferredEmployeeQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ReferredEmployeeQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ReferredEmployeeQuery query;		
	}



	[Serializable]
	abstract public partial class esReferredEmployeeCollection : esEntityCollection<ReferredEmployee>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ReferredEmployeeMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ReferredEmployeeCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ReferredEmployeeQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ReferredEmployeeQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ReferredEmployeeQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ReferredEmployeeQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ReferredEmployeeQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ReferredEmployeeQuery)query);
		}

		#endregion
		
		private ReferredEmployeeQuery query;
	}



	[Serializable]
	abstract public partial class esReferredEmployeeQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ReferredEmployeeMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "EmployeeID": return this.EmployeeID;
				case "ReferredID": return this.ReferredID;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, ReferredEmployeeMetadata.ColumnNames.EmployeeID, esSystemType.Int32); }
		} 
		
		public esQueryItem ReferredID
		{
			get { return new esQueryItem(this, ReferredEmployeeMetadata.ColumnNames.ReferredID, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class ReferredEmployee : esReferredEmployee
	{

				
		#region UpToEmployeeByEmployeeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_ReferredEmployee_Employee1
		/// </summary>

		[XmlIgnore]
					
		public Employee UpToEmployeeByEmployeeID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeeByEmployeeID == null && EmployeeID != null)
				{
					this._UpToEmployeeByEmployeeID = new Employee();
					this._UpToEmployeeByEmployeeID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeeByEmployeeID", this._UpToEmployeeByEmployeeID);
					this._UpToEmployeeByEmployeeID.Query.Where(this._UpToEmployeeByEmployeeID.Query.EmployeeID == this.EmployeeID);
					this._UpToEmployeeByEmployeeID.Query.Load();
				}	
				return this._UpToEmployeeByEmployeeID;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeeByEmployeeID");
				
				bool changed = this._UpToEmployeeByEmployeeID != value;

				if(value == null)
				{
					this.EmployeeID = null;
					this._UpToEmployeeByEmployeeID = null;
				}
				else
				{
					this.EmployeeID = value.EmployeeID;
					this._UpToEmployeeByEmployeeID = value;
					this.SetPreSave("UpToEmployeeByEmployeeID", this._UpToEmployeeByEmployeeID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeeByEmployeeID");
				}
			}
		}
		#endregion
		

				
		#region UpToEmployeeByReferredID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_ReferredEmployee_Employee2
		/// </summary>

		[XmlIgnore]
					
		public Employee UpToEmployeeByReferredID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeeByReferredID == null && ReferredID != null)
				{
					this._UpToEmployeeByReferredID = new Employee();
					this._UpToEmployeeByReferredID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeeByReferredID", this._UpToEmployeeByReferredID);
					this._UpToEmployeeByReferredID.Query.Where(this._UpToEmployeeByReferredID.Query.EmployeeID == this.ReferredID);
					this._UpToEmployeeByReferredID.Query.Load();
				}	
				return this._UpToEmployeeByReferredID;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeeByReferredID");
				
				bool changed = this._UpToEmployeeByReferredID != value;

				if(value == null)
				{
					this.ReferredID = null;
					this._UpToEmployeeByReferredID = null;
				}
				else
				{
					this.ReferredID = value.EmployeeID;
					this._UpToEmployeeByReferredID = value;
					this.SetPreSave("UpToEmployeeByReferredID", this._UpToEmployeeByReferredID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeeByReferredID");
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
			if(!this.es.IsDeleted && this._UpToEmployeeByEmployeeID != null)
			{
				this.EmployeeID = this._UpToEmployeeByEmployeeID.EmployeeID;
			}
			if(!this.es.IsDeleted && this._UpToEmployeeByReferredID != null)
			{
				this.ReferredID = this._UpToEmployeeByReferredID.EmployeeID;
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "ReferredEmployee")]
	[XmlType(TypeName="ReferredEmployeeProxyStub")]	
	[Serializable]
	public partial class ReferredEmployeeProxyStub
	{
		public ReferredEmployeeProxyStub() 
		{
			theEntity = this.entity = new ReferredEmployee();
		}

		public ReferredEmployeeProxyStub(ReferredEmployee obj)
		{
			theEntity = this.entity = obj;
		}

		public ReferredEmployeeProxyStub(ReferredEmployee obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator ReferredEmployee(ReferredEmployeeProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(ReferredEmployee);
		}

		[DataMember(Name="EmployeeID", Order=1, EmitDefaultValue=false)]
		public System.Int32? EmployeeID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ReferredEmployeeMetadata.ColumnNames.EmployeeID);
				else
					return this.Entity.EmployeeID;
			}
			set { this.Entity.EmployeeID = value; }
		}

		[DataMember(Name="ReferredID", Order=2, EmitDefaultValue=false)]
		public System.Int32? ReferredID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ReferredEmployeeMetadata.ColumnNames.ReferredID);
				else
					return this.Entity.ReferredID;
			}
			set { this.Entity.ReferredID = value; }
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
		public ReferredEmployee Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new ReferredEmployee();
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
		public ReferredEmployee entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ReferredEmployeeCollection")]
	[XmlType(TypeName="ReferredEmployeeCollectionProxyStub")]	
	[Serializable]
	public partial class ReferredEmployeeCollectionProxyStub 
	{
		protected ReferredEmployeeCollectionProxyStub() {}
		
		public ReferredEmployeeCollectionProxyStub(esEntityCollection<ReferredEmployee> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ReferredEmployeeCollectionProxyStub(esEntityCollection<ReferredEmployee> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ReferredEmployeeCollection(ReferredEmployeeCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(ReferredEmployee);
		}
		
		public ReferredEmployeeCollectionProxyStub(esEntityCollection<ReferredEmployee> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (ReferredEmployee entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ReferredEmployeeProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ReferredEmployeeProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (ReferredEmployee entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ReferredEmployeeProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ReferredEmployeeProxyStub> Collection = new List<ReferredEmployeeProxyStub>();

		public ReferredEmployeeCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ReferredEmployeeCollection();

				foreach (ReferredEmployeeProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ReferredEmployeeCollection _coll;
	}



	[Serializable]
	public partial class ReferredEmployeeMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ReferredEmployeeMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ReferredEmployeeMetadata.ColumnNames.EmployeeID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ReferredEmployeeMetadata.PropertyNames.EmployeeID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ReferredEmployeeMetadata.ColumnNames.ReferredID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ReferredEmployeeMetadata.PropertyNames.ReferredID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ReferredEmployeeMetadata Meta()
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
			 public const string EmployeeID = "EmployeeID";
			 public const string ReferredID = "ReferredID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string EmployeeID = "EmployeeID";
			 public const string ReferredID = "ReferredID";
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
			lock (typeof(ReferredEmployeeMetadata))
			{
				if(ReferredEmployeeMetadata.mapDelegates == null)
				{
					ReferredEmployeeMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ReferredEmployeeMetadata.meta == null)
				{
					ReferredEmployeeMetadata.meta = new ReferredEmployeeMetadata();
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


				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ReferredID", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "ReferredEmployee";
				meta.Destination = "ReferredEmployee";
				
				meta.spInsert = "proc_ReferredEmployeeInsert";				
				meta.spUpdate = "proc_ReferredEmployeeUpdate";		
				meta.spDelete = "proc_ReferredEmployeeDelete";
				meta.spLoadAll = "proc_ReferredEmployeeLoadAll";
				meta.spLoadByPrimaryKey = "proc_ReferredEmployeeLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ReferredEmployeeMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
