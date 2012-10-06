
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQLCE
Date Generated       : 9/23/2012 6:16:19 PM
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
	/// Encapsulates the 'EmployeeTerritory' table
	/// </summary>

	public partial class EmployeeTerritory : esEmployeeTerritory
	{
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

		
					
		
	
	}



	public partial class EmployeeTerritoryCollection : esEmployeeTerritoryCollection, IEnumerable<EmployeeTerritory>
	{
		public EmployeeTerritory FindByPrimaryKey(System.Int32 empID, System.Int32 terrID)
		{
			return this.SingleOrDefault(e => e.EmpID == empID && e.TerrID == terrID);
		}

		
		
		
				
	}


	
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
		
					
		
	}

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
		
        
		private EmployeeTerritoryQuery query;		
	}



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
		/// Foreign Key Name - EmployeeEmployeeTerritory
		/// </summary>

					
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
		/// Foreign Key Name - TerritoryEmployeeTerritory
		/// </summary>

					
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
			get { return false; }
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
				
				
				
				meta.Source = "EmployeeTerritory";
				meta.Destination = "EmployeeTerritory";
				
				
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
