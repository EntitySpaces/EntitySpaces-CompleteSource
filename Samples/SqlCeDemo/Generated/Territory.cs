
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQLCE
Date Generated       : 9/23/2012 6:16:20 PM
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


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Territory' table
	/// </summary>

	public partial class Territory : esTerritory
	{
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

		
					
		
	
	}



	public partial class TerritoryCollection : esTerritoryCollection, IEnumerable<Territory>
	{
		public Territory FindByPrimaryKey(System.Int32 territoryID)
		{
			return this.SingleOrDefault(e => e.TerritoryID == territoryID);
		}

		
		
		
				
	}


	
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
		
					
		
	}

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
		
        
		private TerritoryQuery query;		
	}



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
		/// Foreign Key Name - TerritoryEmployeeTerritory
		/// </summary>

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
		/// Foreign Key Name - TerritoryEmployeeTerritory
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
		/// Foreign Key Name - TerritoryEmployeeTerritory
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
		/// Foreign Key Name - TerritoryEmployeeTerritory
		/// </summary>

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
		/// Foreign Key Name - TerritoryTerritoryEx
		/// </summary>

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
			get { return false; }
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
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Territory";
				meta.Destination = "Territory";
				
				
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
