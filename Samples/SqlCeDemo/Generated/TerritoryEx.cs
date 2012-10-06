
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
	/// Encapsulates the 'TerritoryEx' table
	/// </summary>

	public partial class TerritoryEx : esTerritoryEx
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new TerritoryEx();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 territoryID)
		{
			var obj = new TerritoryEx();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 territoryID, esSqlAccessType sqlAccessType)
		{
			var obj = new TerritoryEx();
			obj.TerritoryID = territoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class TerritoryExCollection : esTerritoryExCollection, IEnumerable<TerritoryEx>
	{
		public TerritoryEx FindByPrimaryKey(System.Int32 territoryID)
		{
			return this.SingleOrDefault(e => e.TerritoryID == territoryID);
		}

		
		
		
				
	}


	
	public partial class TerritoryExQuery : esTerritoryExQuery
	{
		public TerritoryExQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "TerritoryExQuery";
		}
		
					
		
	}

	abstract public partial class esTerritoryEx : esEntity
	{
		public esTerritoryEx()
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
			TerritoryExQuery query = new TerritoryExQuery();
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
		/// Maps to TerritoryEx.TerritoryID
		/// </summary>
		virtual public System.Int32? TerritoryID
		{
			get
			{
				return base.GetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID);
			}
			
			set
			{
				if(base.SetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID, value))
				{
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.TerritoryID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to TerritoryEx.Notes
		/// </summary>
		virtual public System.String Notes
		{
			get
			{
				return base.GetSystemString(TerritoryExMetadata.ColumnNames.Notes);
			}
			
			set
			{
				if(base.SetSystemString(TerritoryExMetadata.ColumnNames.Notes, value))
				{
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.Notes);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return TerritoryExMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public TerritoryExQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TerritoryExQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TerritoryExQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(TerritoryExQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private TerritoryExQuery query;		
	}



	abstract public partial class esTerritoryExCollection : esEntityCollection<TerritoryEx>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return TerritoryExMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "TerritoryExCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public TerritoryExQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new TerritoryExQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(TerritoryExQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new TerritoryExQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(TerritoryExQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((TerritoryExQuery)query);
		}

		#endregion
		
		private TerritoryExQuery query;
	}



	abstract public partial class esTerritoryExQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return TerritoryExMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "TerritoryID": return this.TerritoryID;
				case "Notes": return this.Notes;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem TerritoryID
		{
			get { return new esQueryItem(this, TerritoryExMetadata.ColumnNames.TerritoryID, esSystemType.Int32); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, TerritoryExMetadata.ColumnNames.Notes, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class TerritoryEx : esTerritoryEx
	{

		#region UpToTerritory - One To One
		/// <summary>
		/// One to One
		/// Foreign Key Name - TerritoryTerritoryEx
		/// </summary>

		public Territory UpToTerritory
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
			
				if(this._UpToTerritory == null && TerritoryID != null)
				{
					this._UpToTerritory = new Territory();
					this._UpToTerritory.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToTerritory", this._UpToTerritory);
					this._UpToTerritory.Query.Where(this._UpToTerritory.Query.TerritoryID == this.TerritoryID);
					this._UpToTerritory.Query.Load();
				}

				return this._UpToTerritory;
			}
			
			set 
			{ 
				this.RemovePreSave("UpToTerritory");

				if(value == null)
				{
					this._UpToTerritory = null;
				}
				else
				{
					this._UpToTerritory = value;
					this.SetPreSave("UpToTerritory", this._UpToTerritory);
				}
				
				this.OnPropertyChanged("UpToTerritory");
			} 
		}
				
		
		private Territory _UpToTerritory;
		#endregion

		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToTerritory != null)
			{
				this.TerritoryID = this._UpToTerritory.TerritoryID;
			}
		}
		
	}
	



	public partial class TerritoryExMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected TerritoryExMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(TerritoryExMetadata.ColumnNames.TerritoryID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = TerritoryExMetadata.PropertyNames.TerritoryID;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(TerritoryExMetadata.ColumnNames.Notes, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = TerritoryExMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public TerritoryExMetadata Meta()
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
			 public const string Notes = "Notes";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string TerritoryID = "TerritoryID";
			 public const string Notes = "Notes";
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
			lock (typeof(TerritoryExMetadata))
			{
				if(TerritoryExMetadata.mapDelegates == null)
				{
					TerritoryExMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoryExMetadata.meta == null)
				{
					TerritoryExMetadata.meta = new TerritoryExMetadata();
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
				meta.AddTypeMap("Notes", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "TerritoryEx";
				meta.Destination = "TerritoryEx";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private TerritoryExMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
