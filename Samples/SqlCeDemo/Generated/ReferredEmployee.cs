
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
	/// Encapsulates the 'ReferredEmployee' table
	/// </summary>

	public partial class ReferredEmployee : esReferredEmployee
	{
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

		
					
		
	
	}



	public partial class ReferredEmployeeCollection : esReferredEmployeeCollection, IEnumerable<ReferredEmployee>
	{
		public ReferredEmployee FindByPrimaryKey(System.Int32 employeeID, System.Int32 referredID)
		{
			return this.SingleOrDefault(e => e.EmployeeID == employeeID && e.ReferredID == referredID);
		}

		
		
		
				
	}


	
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
		
					
		
	}

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
		internal protected Employee _UpToEmployeeByReferredID;
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeByEmployeeID;
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
		
        
		private ReferredEmployeeQuery query;		
	}



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

				
		#region UpToEmployeeByReferredID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - EmployeeReferredEmployee
		/// </summary>

					
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
		

				
		#region UpToEmployeeByEmployeeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - EmployeeReferredEmployee1
		/// </summary>

					
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
		

		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToEmployeeByReferredID != null)
			{
				this.ReferredID = this._UpToEmployeeByReferredID.EmployeeID;
			}
			if(!this.es.IsDeleted && this._UpToEmployeeByEmployeeID != null)
			{
				this.EmployeeID = this._UpToEmployeeByEmployeeID.EmployeeID;
			}
		}
		
	}
	



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
			get { return false; }
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
				
				
				
				meta.Source = "ReferredEmployee";
				meta.Destination = "ReferredEmployee";
				
				
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
