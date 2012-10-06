
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
	/// Encapsulates the 'EmployeeTerritory' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(EmployeeTerritory))]	
	[XmlType("EmployeeTerritory")]
	[Table(Name="EmployeeTerritory")]
	public partial class EmployeeTerritory : esEmployeeTerritory
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new EmployeeTerritory();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 empID, System.Int32 terrID)
		{
			var obj = new EmployeeTerritory();
			obj.EmpID = empID;
			obj.TerrID = terrID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 empID, System.Int32 terrID, esSqlAccessType sqlAccessType)
		{
			var obj = new EmployeeTerritory();
			obj.EmpID = empID;
			obj.TerrID = terrID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator EmployeeTerritoryProxyStub(EmployeeTerritory entity)
		{
			return new EmployeeTerritoryProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? EmpID
		{
			get { return base.EmpID;  }
			set { base.EmpID = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? TerrID
		{
			get { return base.TerrID;  }
			set { base.TerrID = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("EmployeeTerritoryCollection")]
	public partial class EmployeeTerritoryCollection : esEmployeeTerritoryCollection, IEnumerable<EmployeeTerritory>
	{
		public EmployeeTerritory FindByPrimaryKey(System.Int32 empID, System.Int32 terrID)
		{
			return this.SingleOrDefault(e => e.EmpID == empID && e.TerrID == terrID);
		}

		#region Implicit Casts
		
		public static implicit operator EmployeeTerritoryCollectionProxyStub(EmployeeTerritoryCollection coll)
		{
			return new EmployeeTerritoryCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(EmployeeTerritory))]
		public class EmployeeTerritoryCollectionWCFPacket : esCollectionWCFPacket<EmployeeTerritoryCollection>
		{
			public static implicit operator EmployeeTerritoryCollection(EmployeeTerritoryCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator EmployeeTerritoryCollectionWCFPacket(EmployeeTerritoryCollection collection)
			{
				return new EmployeeTerritoryCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "EmployeeTerritoryQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class EmployeeTerritoryQuery : esEmployeeTerritoryQuery
	{
		public EmployeeTerritoryQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "EmployeeTerritoryQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(EmployeeTerritoryQuery query)
		{
			return EmployeeTerritoryQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator EmployeeTerritoryQuery(string query)
		{
			return (EmployeeTerritoryQuery)EmployeeTerritoryQuery.SerializeHelper.FromXml(query, typeof(EmployeeTerritoryQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esEmployeeTerritory : esEntity
	{
		public esEmployeeTerritory()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 empID, System.Int32 terrID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(empID, terrID);
			else
				return LoadByPrimaryKeyStoredProcedure(empID, terrID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 empID, System.Int32 terrID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(empID, terrID);
			else
				return LoadByPrimaryKeyStoredProcedure(empID, terrID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 empID, System.Int32 terrID)
		{
			EmployeeTerritoryQuery query = new EmployeeTerritoryQuery();
			query.Where(query.EmpID == empID, query.TerrID == terrID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 empID, System.Int32 terrID)
		{
			esParameters parms = new esParameters();
			parms.Add("EmpID", empID);			parms.Add("TerrID", terrID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to EmployeeTerritory.EmpID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? EmpID
		{
			get
			{
				return base.GetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.EmpID);
			}
			
			set
			{
				if(base.SetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.EmpID, value))
				{
					this._UpToEmployeeByEmpID = null;
					this.OnPropertyChanged("UpToEmployeeByEmpID");
					OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.EmpID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to EmployeeTerritory.TerrID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? TerrID
		{
			get
			{
				return base.GetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.TerrID);
			}
			
			set
			{
				if(base.SetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.TerrID, value))
				{
					this._UpToTerritoryByTerrID = null;
					this.OnPropertyChanged("UpToTerritoryByTerrID");
					OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.TerrID);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeByEmpID;
		[CLSCompliant(false)]
		internal protected Territory _UpToTerritoryByTerrID;
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
						case "EmpID": this.str().EmpID = (string)value; break;							
						case "TerrID": this.str().TerrID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "EmpID":
						
							if (value == null || value is System.Int32)
								this.EmpID = (System.Int32?)value;
								OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.EmpID);
							break;
						
						case "TerrID":
						
							if (value == null || value is System.Int32)
								this.TerrID = (System.Int32?)value;
								OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.TerrID);
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
			public esStrings(esEmployeeTerritory entity)
			{
				this.entity = entity;
			}
			
	
			public System.String EmpID
			{
				get
				{
					System.Int32? data = entity.EmpID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EmpID = null;
					else entity.EmpID = Convert.ToInt32(value);
				}
			}
				
			public System.String TerrID
			{
				get
				{
					System.Int32? data = entity.TerrID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TerrID = null;
					else entity.TerrID = Convert.ToInt32(value);
				}
			}
			

			private esEmployeeTerritory entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return EmployeeTerritoryMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public EmployeeTerritoryQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EmployeeTerritoryQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EmployeeTerritoryQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(EmployeeTerritoryQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private EmployeeTerritoryQuery query;		
	}



	[Serializable]
	abstract public partial class esEmployeeTerritoryCollection : esEntityCollection<EmployeeTerritory>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return EmployeeTerritoryMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "EmployeeTerritoryCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public EmployeeTerritoryQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EmployeeTerritoryQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EmployeeTerritoryQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new EmployeeTerritoryQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(EmployeeTerritoryQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((EmployeeTerritoryQuery)query);
		}

		#endregion
		
		private EmployeeTerritoryQuery query;
	}



	[Serializable]
	abstract public partial class esEmployeeTerritoryQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return EmployeeTerritoryMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "EmpID": return this.EmpID;
				case "TerrID": return this.TerrID;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem EmpID
		{
			get { return new esQueryItem(this, EmployeeTerritoryMetadata.ColumnNames.EmpID, esSystemType.Int32); }
		} 
		
		public esQueryItem TerrID
		{
			get { return new esQueryItem(this, EmployeeTerritoryMetadata.ColumnNames.TerrID, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class EmployeeTerritory : esEmployeeTerritory
	{

				
		#region UpToEmployeeByEmpID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_EmployeeTerritory_Employee
		/// </summary>

		[XmlIgnore]
					
		public Employee UpToEmployeeByEmpID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeeByEmpID == null && EmpID != null)
				{
					this._UpToEmployeeByEmpID = new Employee();
					this._UpToEmployeeByEmpID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeeByEmpID", this._UpToEmployeeByEmpID);
					this._UpToEmployeeByEmpID.Query.Where(this._UpToEmployeeByEmpID.Query.EmployeeID == this.EmpID);
					this._UpToEmployeeByEmpID.Query.Load();
				}	
				return this._UpToEmployeeByEmpID;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeeByEmpID");
				
				bool changed = this._UpToEmployeeByEmpID != value;

				if(value == null)
				{
					this.EmpID = null;
					this._UpToEmployeeByEmpID = null;
				}
				else
				{
					this.EmpID = value.EmployeeID;
					this._UpToEmployeeByEmpID = value;
					this.SetPreSave("UpToEmployeeByEmpID", this._UpToEmployeeByEmpID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeeByEmpID");
				}
			}
		}
		#endregion
		

				
		#region UpToTerritoryByTerrID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_EmployeeTerritory_Territory
		/// </summary>

		[XmlIgnore]
					
		public Territory UpToTerritoryByTerrID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToTerritoryByTerrID == null && TerrID != null)
				{
					this._UpToTerritoryByTerrID = new Territory();
					this._UpToTerritoryByTerrID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToTerritoryByTerrID", this._UpToTerritoryByTerrID);
					this._UpToTerritoryByTerrID.Query.Where(this._UpToTerritoryByTerrID.Query.TerritoryID == this.TerrID);
					this._UpToTerritoryByTerrID.Query.Load();
				}	
				return this._UpToTerritoryByTerrID;
			}
			
			set
			{
				this.RemovePreSave("UpToTerritoryByTerrID");
				
				bool changed = this._UpToTerritoryByTerrID != value;

				if(value == null)
				{
					this.TerrID = null;
					this._UpToTerritoryByTerrID = null;
				}
				else
				{
					this.TerrID = value.TerritoryID;
					this._UpToTerritoryByTerrID = value;
					this.SetPreSave("UpToTerritoryByTerrID", this._UpToTerritoryByTerrID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToTerritoryByTerrID");
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
			if(!this.es.IsDeleted && this._UpToEmployeeByEmpID != null)
			{
				this.EmpID = this._UpToEmployeeByEmpID.EmployeeID;
			}
			if(!this.es.IsDeleted && this._UpToTerritoryByTerrID != null)
			{
				this.TerrID = this._UpToTerritoryByTerrID.TerritoryID;
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeTerritory")]
	[XmlType(TypeName="EmployeeTerritoryProxyStub")]	
	[Serializable]
	public partial class EmployeeTerritoryProxyStub
	{
		public EmployeeTerritoryProxyStub() 
		{
			theEntity = this.entity = new EmployeeTerritory();
		}

		public EmployeeTerritoryProxyStub(EmployeeTerritory obj)
		{
			theEntity = this.entity = obj;
		}

		public EmployeeTerritoryProxyStub(EmployeeTerritory obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator EmployeeTerritory(EmployeeTerritoryProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(EmployeeTerritory);
		}

		[DataMember(Name="EmpID", Order=1, EmitDefaultValue=false)]
		public System.Int32? EmpID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(EmployeeTerritoryMetadata.ColumnNames.EmpID);
				else
					return this.Entity.EmpID;
			}
			set { this.Entity.EmpID = value; }
		}

		[DataMember(Name="TerrID", Order=2, EmitDefaultValue=false)]
		public System.Int32? TerrID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(EmployeeTerritoryMetadata.ColumnNames.TerrID);
				else
					return this.Entity.TerrID;
			}
			set { this.Entity.TerrID = value; }
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
		public EmployeeTerritory Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new EmployeeTerritory();
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
		public EmployeeTerritory entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeTerritoryCollection")]
	[XmlType(TypeName="EmployeeTerritoryCollectionProxyStub")]	
	[Serializable]
	public partial class EmployeeTerritoryCollectionProxyStub 
	{
		protected EmployeeTerritoryCollectionProxyStub() {}
		
		public EmployeeTerritoryCollectionProxyStub(esEntityCollection<EmployeeTerritory> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public EmployeeTerritoryCollectionProxyStub(esEntityCollection<EmployeeTerritory> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator EmployeeTerritoryCollection(EmployeeTerritoryCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(EmployeeTerritory);
		}
		
		public EmployeeTerritoryCollectionProxyStub(esEntityCollection<EmployeeTerritory> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (EmployeeTerritory entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new EmployeeTerritoryProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new EmployeeTerritoryProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (EmployeeTerritory entity in coll.es.DeletedEntities)
				{
					Collection.Add(new EmployeeTerritoryProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<EmployeeTerritoryProxyStub> Collection = new List<EmployeeTerritoryProxyStub>();

		public EmployeeTerritoryCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new EmployeeTerritoryCollection();

				foreach (EmployeeTerritoryProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private EmployeeTerritoryCollection _coll;
	}



	[Serializable]
	public partial class EmployeeTerritoryMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected EmployeeTerritoryMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(EmployeeTerritoryMetadata.ColumnNames.EmpID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = EmployeeTerritoryMetadata.PropertyNames.EmpID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EmployeeTerritoryMetadata.ColumnNames.TerrID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = EmployeeTerritoryMetadata.PropertyNames.TerrID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public EmployeeTerritoryMetadata Meta()
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
			 public const string EmpID = "EmpID";
			 public const string TerrID = "TerrID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string EmpID = "EmpID";
			 public const string TerrID = "TerrID";
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
			lock (typeof(EmployeeTerritoryMetadata))
			{
				if(EmployeeTerritoryMetadata.mapDelegates == null)
				{
					EmployeeTerritoryMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EmployeeTerritoryMetadata.meta == null)
				{
					EmployeeTerritoryMetadata.meta = new EmployeeTerritoryMetadata();
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


				meta.AddTypeMap("EmpID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("TerrID", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "EmployeeTerritory";
				meta.Destination = "EmployeeTerritory";
				
				meta.spInsert = "proc_EmployeeTerritoryInsert";				
				meta.spUpdate = "proc_EmployeeTerritoryUpdate";		
				meta.spDelete = "proc_EmployeeTerritoryDelete";
				meta.spLoadAll = "proc_EmployeeTerritoryLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeTerritoryLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private EmployeeTerritoryMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
