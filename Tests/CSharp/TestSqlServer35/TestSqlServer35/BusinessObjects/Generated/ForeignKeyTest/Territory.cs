
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
	/// Encapsulates the 'Territory' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Territory))]	
	[XmlType("Territory")]
	[Table(Name="Territory")]
	public partial class Territory : esTerritory
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Territory();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 territoryID)
		{
			var obj = new Territory();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 territoryID, esSqlAccessType sqlAccessType)
		{
			var obj = new Territory();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator TerritoryProxyStub(Territory entity)
		{
			return new TerritoryProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? TerritoryID
		{
			get { return base.TerritoryID;  }
			set { base.TerritoryID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String Description
		{
			get { return base.Description;  }
			set { base.Description = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("TerritoryCollection")]
	public partial class TerritoryCollection : esTerritoryCollection, IEnumerable<Territory>
	{
		public Territory FindByPrimaryKey(System.Int32 territoryID)
		{
			return this.SingleOrDefault(e => e.TerritoryID == territoryID);
		}

		#region Implicit Casts
		
		public static implicit operator TerritoryCollectionProxyStub(TerritoryCollection coll)
		{
			return new TerritoryCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Territory))]
		public class TerritoryCollectionWCFPacket : esCollectionWCFPacket<TerritoryCollection>
		{
			public static implicit operator TerritoryCollection(TerritoryCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator TerritoryCollectionWCFPacket(TerritoryCollection collection)
			{
				return new TerritoryCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "TerritoryQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class TerritoryQuery : esTerritoryQuery
	{
		public TerritoryQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "TerritoryQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(TerritoryQuery query)
		{
			return TerritoryQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator TerritoryQuery(string query)
		{
			return (TerritoryQuery)TerritoryQuery.SerializeHelper.FromXml(query, typeof(TerritoryQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esTerritory : esEntity
	{
		public esTerritory()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 territoryID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(territoryID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 territoryID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(territoryID);
			else
				return LoadByPrimaryKeyStoredProcedure(territoryID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 territoryID)
		{
			TerritoryQuery query = new TerritoryQuery();
			query.Where(query.TerritoryID == territoryID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 territoryID)
		{
			esParameters parms = new esParameters();
			parms.Add("TerritoryID", territoryID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Territory.TerritoryID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? TerritoryID
		{
			get
			{
				return base.GetSystemInt32(TerritoryMetadata.ColumnNames.TerritoryID);
			}
			
			set
			{
				if(base.SetSystemInt32(TerritoryMetadata.ColumnNames.TerritoryID, value))
				{
					OnPropertyChanged(TerritoryMetadata.PropertyNames.TerritoryID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Territory.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(TerritoryMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(TerritoryMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(TerritoryMetadata.PropertyNames.Description);
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
						case "TerritoryID": this.str().TerritoryID = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "TerritoryID":
						
							if (value == null || value is System.Int32)
								this.TerritoryID = (System.Int32?)value;
								OnPropertyChanged(TerritoryMetadata.PropertyNames.TerritoryID);
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
			public esStrings(esTerritory entity)
			{
				this.entity = entity;
			}
			
	
			public System.String TerritoryID
			{
				get
				{
					System.Int32? data = entity.TerritoryID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TerritoryID = null;
					else entity.TerritoryID = Convert.ToInt32(value);
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
			

			private esTerritory entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return TerritoryMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public TerritoryQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TerritoryQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TerritoryQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(TerritoryQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private TerritoryQuery query;		
	}



	[Serializable]
	abstract public partial class esTerritoryCollection : esEntityCollection<Territory>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TerritoryMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "TerritoryCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public TerritoryQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TerritoryQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TerritoryQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TerritoryQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(TerritoryQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((TerritoryQuery)query);
		}

		#endregion
		
		private TerritoryQuery query;
	}



	[Serializable]
	abstract public partial class esTerritoryQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return TerritoryMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TerritoryID": return this.TerritoryID;
				case "Description": return this.Description;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TerritoryID
		{
			get { return new esQueryItem(this, TerritoryMetadata.ColumnNames.TerritoryID, esSystemType.Int32); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, TerritoryMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Territory : esTerritory
	{

		#region UpToEmployeeCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_EmployeeTerritory_Territory
		/// </summary>

		[XmlIgnore]
		public EmployeeCollection UpToEmployeeCollection
		{
			get
			{
				if(this._UpToEmployeeCollection == null)
				{
					this._UpToEmployeeCollection = new EmployeeCollection();
					this._UpToEmployeeCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToEmployeeCollection", this._UpToEmployeeCollection);
					if (!this.es.IsLazyLoadDisabled && this.TerritoryID != null)
					{
						EmployeeQuery m = new EmployeeQuery("m");
						EmployeeTerritoryQuery j = new EmployeeTerritoryQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.EmployeeID == j.EmpID);
                        m.Where(j.TerrID == this.TerritoryID);

						this._UpToEmployeeCollection.Load(m);
					}
				}

				return this._UpToEmployeeCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToEmployeeCollection != null) 
				{ 
					this.RemovePostSave("UpToEmployeeCollection"); 
					this._UpToEmployeeCollection = null;
					this.OnPropertyChanged("UpToEmployeeCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_EmployeeTerritory_Territory
		/// </summary>
		public void AssociateEmployeeCollection(Employee entity)
		{
			if (this._EmployeeTerritoryCollection == null)
			{
				this._EmployeeTerritoryCollection = new EmployeeTerritoryCollection();
				this._EmployeeTerritoryCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeTerritoryCollection", this._EmployeeTerritoryCollection);
			}

			EmployeeTerritory obj = this._EmployeeTerritoryCollection.AddNew();
			obj.TerrID = this.TerritoryID;
			obj.EmpID = entity.EmployeeID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_EmployeeTerritory_Territory
		/// </summary>
		public void DissociateEmployeeCollection(Employee entity)
		{
			if (this._EmployeeTerritoryCollection == null)
			{
				this._EmployeeTerritoryCollection = new EmployeeTerritoryCollection();
				this._EmployeeTerritoryCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeTerritoryCollection", this._EmployeeTerritoryCollection);
			}

			EmployeeTerritory obj = this._EmployeeTerritoryCollection.AddNew();
			obj.TerrID = this.TerritoryID;
            obj.EmpID = entity.EmployeeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private EmployeeCollection _UpToEmployeeCollection;
		private EmployeeTerritoryCollection _EmployeeTerritoryCollection;
		#endregion

		#region EmployeeTerritoryCollectionByTerrID - Zero To Many
		
		static public esPrefetchMap Prefetch_EmployeeTerritoryCollectionByTerrID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Territory.EmployeeTerritoryCollectionByTerrID_Delegate;
				map.PropertyName = "EmployeeTerritoryCollectionByTerrID";
				map.MyColumnName = "TerrID";
				map.ParentColumnName = "TerritoryID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void EmployeeTerritoryCollectionByTerrID_Delegate(esPrefetchParameters data)
		{
			TerritoryQuery parent = new TerritoryQuery(data.NextAlias());

			EmployeeTerritoryQuery me = data.You != null ? data.You as EmployeeTerritoryQuery : new EmployeeTerritoryQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.TerritoryID == me.TerrID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_EmployeeTerritory_Territory
		/// </summary>

		[XmlIgnore]
		public EmployeeTerritoryCollection EmployeeTerritoryCollectionByTerrID
		{
			get
			{
				if(this._EmployeeTerritoryCollectionByTerrID == null)
				{
					this._EmployeeTerritoryCollectionByTerrID = new EmployeeTerritoryCollection();
					this._EmployeeTerritoryCollectionByTerrID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("EmployeeTerritoryCollectionByTerrID", this._EmployeeTerritoryCollectionByTerrID);
				
					if (this.TerritoryID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._EmployeeTerritoryCollectionByTerrID.Query.Where(this._EmployeeTerritoryCollectionByTerrID.Query.TerrID == this.TerritoryID);
							this._EmployeeTerritoryCollectionByTerrID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._EmployeeTerritoryCollectionByTerrID.fks.Add(EmployeeTerritoryMetadata.ColumnNames.TerrID, this.TerritoryID);
					}
				}

				return this._EmployeeTerritoryCollectionByTerrID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._EmployeeTerritoryCollectionByTerrID != null) 
				{ 
					this.RemovePostSave("EmployeeTerritoryCollectionByTerrID"); 
					this._EmployeeTerritoryCollectionByTerrID = null;
					this.OnPropertyChanged("EmployeeTerritoryCollectionByTerrID");
				} 
			} 			
		}
			
		
		private EmployeeTerritoryCollection _EmployeeTerritoryCollectionByTerrID;
		#endregion

				
		#region TerritoryEx - One To One
		/// <summary>
		/// One to One
		/// Foreign Key Name - FK_TerritoryEx_Territory
		/// </summary>

		[XmlIgnore]
		public TerritoryEx TerritoryEx
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._TerritoryEx == null)
				{
					this._TerritoryEx = new TerritoryEx();
					this._TerritoryEx.es.Connection.Name = this.es.Connection.Name;
					this.SetPostOneSave("TerritoryEx", this._TerritoryEx);
				
					if(this.TerritoryID != null)
					{
						this._TerritoryEx.Query.Where(this._TerritoryEx.Query.TerritoryID == this.TerritoryID);
						this._TerritoryEx.Query.Load();
					}
				}

				return this._TerritoryEx;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._TerritoryEx != null) 
				{ 
					this.RemovePostOneSave("TerritoryEx"); 
					this._TerritoryEx = null;
					this.OnPropertyChanged("TerritoryEx");
				} 
			}          			
		}
		
		
		private TerritoryEx _TerritoryEx;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "EmployeeTerritoryCollectionByTerrID":
					coll = this.EmployeeTerritoryCollectionByTerrID;
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
			
			props.Add(new esPropertyDescriptor(this, "EmployeeTerritoryCollectionByTerrID", typeof(EmployeeTerritoryCollection), new EmployeeTerritory()));
		
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
					obj.SetProperty(key, value);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._EmployeeTerritoryCollection != null)
			{
				Apply(this._EmployeeTerritoryCollection, "TerrID", this.TerritoryID);
			}
			if(this._EmployeeTerritoryCollectionByTerrID != null)
			{
				Apply(this._EmployeeTerritoryCollectionByTerrID, "TerrID", this.TerritoryID);
			}
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostOneToOneSave.
		/// </summary>
		protected override void ApplyPostOneSaveKeys()
		{
			if(this._TerritoryEx != null)
			{
				if(this._TerritoryEx.es.IsAdded)
				{
					this._TerritoryEx.TerritoryID = this.TerritoryID;
				}
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Territory")]
	[XmlType(TypeName="TerritoryProxyStub")]	
	[Serializable]
	public partial class TerritoryProxyStub
	{
		public TerritoryProxyStub() 
		{
			theEntity = this.entity = new Territory();
		}

		public TerritoryProxyStub(Territory obj)
		{
			theEntity = this.entity = obj;
		}

		public TerritoryProxyStub(Territory obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Territory(TerritoryProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Territory);
		}

		[DataMember(Name="TerritoryID", Order=1, EmitDefaultValue=false)]
		public System.Int32? TerritoryID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(TerritoryMetadata.ColumnNames.TerritoryID);
				else
					return this.Entity.TerritoryID;
			}
			set { this.Entity.TerritoryID = value; }
		}

		[DataMember(Name="Description", Order=2, EmitDefaultValue=false)]
		public System.String Description
		{
			get 
			{ 
				
				if (this.IncludeColumn(TerritoryMetadata.ColumnNames.Description))
					return this.Entity.Description;
				else
					return null;
			}
			set { this.Entity.Description = value; }
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
		public Territory Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Territory();
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
		public Territory entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "TerritoryCollection")]
	[XmlType(TypeName="TerritoryCollectionProxyStub")]	
	[Serializable]
	public partial class TerritoryCollectionProxyStub 
	{
		protected TerritoryCollectionProxyStub() {}
		
		public TerritoryCollectionProxyStub(esEntityCollection<Territory> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public TerritoryCollectionProxyStub(esEntityCollection<Territory> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator TerritoryCollection(TerritoryCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Territory);
		}
		
		public TerritoryCollectionProxyStub(esEntityCollection<Territory> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Territory entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new TerritoryProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new TerritoryProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Territory entity in coll.es.DeletedEntities)
				{
					Collection.Add(new TerritoryProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<TerritoryProxyStub> Collection = new List<TerritoryProxyStub>();

		public TerritoryCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new TerritoryCollection();

				foreach (TerritoryProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private TerritoryCollection _coll;
	}



	[Serializable]
	public partial class TerritoryMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TerritoryMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TerritoryMetadata.ColumnNames.TerritoryID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TerritoryMetadata.PropertyNames.TerritoryID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TerritoryMetadata.ColumnNames.Description, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = TerritoryMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public TerritoryMetadata Meta()
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
			 public const string TerritoryID = "TerritoryID";
			 public const string Description = "Description";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TerritoryID = "TerritoryID";
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
			lock (typeof(TerritoryMetadata))
			{
				if(TerritoryMetadata.mapDelegates == null)
				{
					TerritoryMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoryMetadata.meta == null)
				{
					TerritoryMetadata.meta = new TerritoryMetadata();
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


				meta.AddTypeMap("TerritoryID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Territory";
				meta.Destination = "Territory";
				
				meta.spInsert = "proc_TerritoryInsert";				
				meta.spUpdate = "proc_TerritoryUpdate";		
				meta.spDelete = "proc_TerritoryDelete";
				meta.spLoadAll = "proc_TerritoryLoadAll";
				meta.spLoadByPrimaryKey = "proc_TerritoryLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TerritoryMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
