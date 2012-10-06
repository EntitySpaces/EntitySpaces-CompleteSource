
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
	/// Encapsulates the 'Employee' table
	/// </summary>

	public partial class Employee : esEmployee
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Employee();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 employeeID)
		{
			var obj = new Employee();
			obj.EmployeeID = employeeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 employeeID, esSqlAccessType sqlAccessType)
		{
			var obj = new Employee();
			obj.EmployeeID = employeeID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class EmployeeCollection : esEmployeeCollection, IEnumerable<Employee>
	{
		public Employee FindByPrimaryKey(System.Int32 employeeID)
		{
			return this.SingleOrDefault(e => e.EmployeeID == employeeID);
		}

		
		
		
				
	}


	
	public partial class EmployeeQuery : esEmployeeQuery
	{
		public EmployeeQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "EmployeeQuery";
		}
		
					
		
	}

	abstract public partial class esEmployee : esEntity
	{
		public esEmployee()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 employeeID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 employeeID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(employeeID);
			else
				return LoadByPrimaryKeyStoredProcedure(employeeID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 employeeID)
		{
			EmployeeQuery query = new EmployeeQuery();
			query.Where(query.EmployeeID == employeeID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 employeeID)
		{
			esParameters parms = new esParameters();
			parms.Add("EmployeeID", employeeID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Employee.EmployeeID
		/// </summary>
		virtual public System.Int32? EmployeeID
		{
			get
			{
				return base.GetSystemInt32(EmployeeMetadata.ColumnNames.EmployeeID);
			}
			
			set
			{
				if(base.SetSystemInt32(EmployeeMetadata.ColumnNames.EmployeeID, value))
				{
					OnPropertyChanged(EmployeeMetadata.PropertyNames.EmployeeID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Employee.LastName
		/// </summary>
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(EmployeeMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(EmployeeMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(EmployeeMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Employee.FirstName
		/// </summary>
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(EmployeeMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(EmployeeMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(EmployeeMetadata.PropertyNames.FirstName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Employee.Supervisor
		/// </summary>
		virtual public System.Int32? Supervisor
		{
			get
			{
				return base.GetSystemInt32(EmployeeMetadata.ColumnNames.Supervisor);
			}
			
			set
			{
				if(base.SetSystemInt32(EmployeeMetadata.ColumnNames.Supervisor, value))
				{
					this._UpToEmployeeBySupervisor = null;
					this.OnPropertyChanged("UpToEmployeeBySupervisor");
					OnPropertyChanged(EmployeeMetadata.PropertyNames.Supervisor);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Employee.Age
		/// </summary>
		virtual public System.Int32? Age
		{
			get
			{
				return base.GetSystemInt32(EmployeeMetadata.ColumnNames.Age);
			}
			
			set
			{
				if(base.SetSystemInt32(EmployeeMetadata.ColumnNames.Age, value))
				{
					OnPropertyChanged(EmployeeMetadata.PropertyNames.Age);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeBySupervisor;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return EmployeeMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public EmployeeQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EmployeeQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EmployeeQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(EmployeeQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private EmployeeQuery query;		
	}



	abstract public partial class esEmployeeCollection : esEntityCollection<Employee>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return EmployeeMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "EmployeeCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public EmployeeQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EmployeeQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EmployeeQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new EmployeeQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(EmployeeQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((EmployeeQuery)query);
		}

		#endregion
		
		private EmployeeQuery query;
	}



	abstract public partial class esEmployeeQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return EmployeeMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "EmployeeID": return this.EmployeeID;
				case "LastName": return this.LastName;
				case "FirstName": return this.FirstName;
				case "Supervisor": return this.Supervisor;
				case "Age": return this.Age;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, EmployeeMetadata.ColumnNames.EmployeeID, esSystemType.Int32); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, EmployeeMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, EmployeeMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		public esQueryItem Supervisor
		{
			get { return new esQueryItem(this, EmployeeMetadata.ColumnNames.Supervisor, esSystemType.Int32); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, EmployeeMetadata.ColumnNames.Age, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Employee : esEmployee
	{

		#region EmployeeCollectionBySupervisor - Zero To Many
		
		static public esPrefetchMap Prefetch_EmployeeCollectionBySupervisor
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Employee.EmployeeCollectionBySupervisor_Delegate;
				map.PropertyName = "EmployeeCollectionBySupervisor";
				map.MyColumnName = "EmployeeID";
				map.ParentColumnName = "Supervisor";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void EmployeeCollectionBySupervisor_Delegate(esPrefetchParameters data)
		{
			EmployeeQuery parent = new EmployeeQuery(data.NextAlias());

			EmployeeQuery me = data.You != null ? data.You as EmployeeQuery : new EmployeeQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Supervisor == me.EmployeeID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - EmployeeEmployee
		/// </summary>

		public EmployeeCollection EmployeeCollectionBySupervisor
		{
			get
			{
				if(this._EmployeeCollectionBySupervisor == null)
				{
					this._EmployeeCollectionBySupervisor = new EmployeeCollection();
					this._EmployeeCollectionBySupervisor.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("EmployeeCollectionBySupervisor", this._EmployeeCollectionBySupervisor);
				
					if (this.EmployeeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._EmployeeCollectionBySupervisor.Query.Where(this._EmployeeCollectionBySupervisor.Query.Supervisor == this.EmployeeID);
							this._EmployeeCollectionBySupervisor.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._EmployeeCollectionBySupervisor.fks.Add(EmployeeMetadata.ColumnNames.Supervisor, this.EmployeeID);
					}
				}

				return this._EmployeeCollectionBySupervisor;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._EmployeeCollectionBySupervisor != null) 
				{ 
					this.RemovePostSave("EmployeeCollectionBySupervisor"); 
					this._EmployeeCollectionBySupervisor = null;
					this.OnPropertyChanged("EmployeeCollectionBySupervisor");
				} 
			} 			
		}
			
		
		private EmployeeCollection _EmployeeCollectionBySupervisor;
		#endregion

				
		#region UpToEmployeeBySupervisor - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - EmployeeEmployee
		/// </summary>

					
		public Employee UpToEmployeeBySupervisor
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeeBySupervisor == null && Supervisor != null)
				{
					this._UpToEmployeeBySupervisor = new Employee();
					this._UpToEmployeeBySupervisor.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeeBySupervisor", this._UpToEmployeeBySupervisor);
					this._UpToEmployeeBySupervisor.Query.Where(this._UpToEmployeeBySupervisor.Query.EmployeeID == this.Supervisor);
					this._UpToEmployeeBySupervisor.Query.Load();
				}	
				return this._UpToEmployeeBySupervisor;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeeBySupervisor");
				
				bool changed = this._UpToEmployeeBySupervisor != value;

				if(value == null)
				{
					this.Supervisor = null;
					this._UpToEmployeeBySupervisor = null;
				}
				else
				{
					this.Supervisor = value.EmployeeID;
					this._UpToEmployeeBySupervisor = value;
					this.SetPreSave("UpToEmployeeBySupervisor", this._UpToEmployeeBySupervisor);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeeBySupervisor");
				}
			}
		}
		#endregion
		

		#region CustomerCollectionByManager - Zero To Many
		
		static public esPrefetchMap Prefetch_CustomerCollectionByManager
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Employee.CustomerCollectionByManager_Delegate;
				map.PropertyName = "CustomerCollectionByManager";
				map.MyColumnName = "Manager";
				map.ParentColumnName = "EmployeeID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CustomerCollectionByManager_Delegate(esPrefetchParameters data)
		{
			EmployeeQuery parent = new EmployeeQuery(data.NextAlias());

			CustomerQuery me = data.You != null ? data.You as CustomerQuery : new CustomerQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID == me.Manager);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - EmployeeCustomer
		/// </summary>

		public CustomerCollection CustomerCollectionByManager
		{
			get
			{
				if(this._CustomerCollectionByManager == null)
				{
					this._CustomerCollectionByManager = new CustomerCollection();
					this._CustomerCollectionByManager.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CustomerCollectionByManager", this._CustomerCollectionByManager);
				
					if (this.EmployeeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CustomerCollectionByManager.Query.Where(this._CustomerCollectionByManager.Query.Manager == this.EmployeeID);
							this._CustomerCollectionByManager.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CustomerCollectionByManager.fks.Add(CustomerMetadata.ColumnNames.Manager, this.EmployeeID);
					}
				}

				return this._CustomerCollectionByManager;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CustomerCollectionByManager != null) 
				{ 
					this.RemovePostSave("CustomerCollectionByManager"); 
					this._CustomerCollectionByManager = null;
					this.OnPropertyChanged("CustomerCollectionByManager");
				} 
			} 			
		}
			
		
		private CustomerCollection _CustomerCollectionByManager;
		#endregion

		#region CustomerCollectionByStaffAssigned - Zero To Many
		
		static public esPrefetchMap Prefetch_CustomerCollectionByStaffAssigned
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Employee.CustomerCollectionByStaffAssigned_Delegate;
				map.PropertyName = "CustomerCollectionByStaffAssigned";
				map.MyColumnName = "StaffAssigned";
				map.ParentColumnName = "EmployeeID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CustomerCollectionByStaffAssigned_Delegate(esPrefetchParameters data)
		{
			EmployeeQuery parent = new EmployeeQuery(data.NextAlias());

			CustomerQuery me = data.You != null ? data.You as CustomerQuery : new CustomerQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID == me.StaffAssigned);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - EmployeeCustomer1
		/// </summary>

		public CustomerCollection CustomerCollectionByStaffAssigned
		{
			get
			{
				if(this._CustomerCollectionByStaffAssigned == null)
				{
					this._CustomerCollectionByStaffAssigned = new CustomerCollection();
					this._CustomerCollectionByStaffAssigned.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CustomerCollectionByStaffAssigned", this._CustomerCollectionByStaffAssigned);
				
					if (this.EmployeeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CustomerCollectionByStaffAssigned.Query.Where(this._CustomerCollectionByStaffAssigned.Query.StaffAssigned == this.EmployeeID);
							this._CustomerCollectionByStaffAssigned.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CustomerCollectionByStaffAssigned.fks.Add(CustomerMetadata.ColumnNames.StaffAssigned, this.EmployeeID);
					}
				}

				return this._CustomerCollectionByStaffAssigned;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CustomerCollectionByStaffAssigned != null) 
				{ 
					this.RemovePostSave("CustomerCollectionByStaffAssigned"); 
					this._CustomerCollectionByStaffAssigned = null;
					this.OnPropertyChanged("CustomerCollectionByStaffAssigned");
				} 
			} 			
		}
			
		
		private CustomerCollection _CustomerCollectionByStaffAssigned;
		#endregion

		#region UpToTerritoryCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - EmployeeEmployeeTerritory
		/// </summary>

		public TerritoryCollection UpToTerritoryCollection
		{
			get
			{
				if(this._UpToTerritoryCollection == null)
				{
					this._UpToTerritoryCollection = new TerritoryCollection();
					this._UpToTerritoryCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToTerritoryCollection", this._UpToTerritoryCollection);
					if (!this.es.IsLazyLoadDisabled && this.EmployeeID != null)
					{
						TerritoryQuery m = new TerritoryQuery("m");
						EmployeeTerritoryQuery j = new EmployeeTerritoryQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.TerritoryID == j.TerrID);
                        m.Where(j.EmpID == this.EmployeeID);

						this._UpToTerritoryCollection.Load(m);
					}
				}

				return this._UpToTerritoryCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToTerritoryCollection != null) 
				{ 
					this.RemovePostSave("UpToTerritoryCollection"); 
					this._UpToTerritoryCollection = null;
					this.OnPropertyChanged("UpToTerritoryCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - EmployeeEmployeeTerritory
		/// </summary>
		public void AssociateTerritoryCollection(Territory entity)
		{
			if (this._EmployeeTerritoryCollection == null)
			{
				this._EmployeeTerritoryCollection = new EmployeeTerritoryCollection();
				this._EmployeeTerritoryCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeTerritoryCollection", this._EmployeeTerritoryCollection);
			}

			EmployeeTerritory obj = this._EmployeeTerritoryCollection.AddNew();
			obj.EmpID = this.EmployeeID;
			obj.TerrID = entity.TerritoryID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - EmployeeEmployeeTerritory
		/// </summary>
		public void DissociateTerritoryCollection(Territory entity)
		{
			if (this._EmployeeTerritoryCollection == null)
			{
				this._EmployeeTerritoryCollection = new EmployeeTerritoryCollection();
				this._EmployeeTerritoryCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("EmployeeTerritoryCollection", this._EmployeeTerritoryCollection);
			}

			EmployeeTerritory obj = this._EmployeeTerritoryCollection.AddNew();
			obj.EmpID = this.EmployeeID;
            obj.TerrID = entity.TerritoryID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private TerritoryCollection _UpToTerritoryCollection;
		private EmployeeTerritoryCollection _EmployeeTerritoryCollection;
		#endregion

		#region EmployeeTerritoryCollectionByEmpID - Zero To Many
		
		static public esPrefetchMap Prefetch_EmployeeTerritoryCollectionByEmpID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Employee.EmployeeTerritoryCollectionByEmpID_Delegate;
				map.PropertyName = "EmployeeTerritoryCollectionByEmpID";
				map.MyColumnName = "EmpID";
				map.ParentColumnName = "EmployeeID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void EmployeeTerritoryCollectionByEmpID_Delegate(esPrefetchParameters data)
		{
			EmployeeQuery parent = new EmployeeQuery(data.NextAlias());

			EmployeeTerritoryQuery me = data.You != null ? data.You as EmployeeTerritoryQuery : new EmployeeTerritoryQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID == me.EmpID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - EmployeeEmployeeTerritory
		/// </summary>

		public EmployeeTerritoryCollection EmployeeTerritoryCollectionByEmpID
		{
			get
			{
				if(this._EmployeeTerritoryCollectionByEmpID == null)
				{
					this._EmployeeTerritoryCollectionByEmpID = new EmployeeTerritoryCollection();
					this._EmployeeTerritoryCollectionByEmpID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("EmployeeTerritoryCollectionByEmpID", this._EmployeeTerritoryCollectionByEmpID);
				
					if (this.EmployeeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._EmployeeTerritoryCollectionByEmpID.Query.Where(this._EmployeeTerritoryCollectionByEmpID.Query.EmpID == this.EmployeeID);
							this._EmployeeTerritoryCollectionByEmpID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._EmployeeTerritoryCollectionByEmpID.fks.Add(EmployeeTerritoryMetadata.ColumnNames.EmpID, this.EmployeeID);
					}
				}

				return this._EmployeeTerritoryCollectionByEmpID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._EmployeeTerritoryCollectionByEmpID != null) 
				{ 
					this.RemovePostSave("EmployeeTerritoryCollectionByEmpID"); 
					this._EmployeeTerritoryCollectionByEmpID = null;
					this.OnPropertyChanged("EmployeeTerritoryCollectionByEmpID");
				} 
			} 			
		}
			
		
		private EmployeeTerritoryCollection _EmployeeTerritoryCollectionByEmpID;
		#endregion

		#region OrderCollectionByEmployeeID - Zero To Many
		
		static public esPrefetchMap Prefetch_OrderCollectionByEmployeeID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Employee.OrderCollectionByEmployeeID_Delegate;
				map.PropertyName = "OrderCollectionByEmployeeID";
				map.MyColumnName = "EmployeeID";
				map.ParentColumnName = "EmployeeID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void OrderCollectionByEmployeeID_Delegate(esPrefetchParameters data)
		{
			EmployeeQuery parent = new EmployeeQuery(data.NextAlias());

			OrderQuery me = data.You != null ? data.You as OrderQuery : new OrderQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID == me.EmployeeID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - EmployeeOrder
		/// </summary>

		public OrderCollection OrderCollectionByEmployeeID
		{
			get
			{
				if(this._OrderCollectionByEmployeeID == null)
				{
					this._OrderCollectionByEmployeeID = new OrderCollection();
					this._OrderCollectionByEmployeeID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("OrderCollectionByEmployeeID", this._OrderCollectionByEmployeeID);
				
					if (this.EmployeeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._OrderCollectionByEmployeeID.Query.Where(this._OrderCollectionByEmployeeID.Query.EmployeeID == this.EmployeeID);
							this._OrderCollectionByEmployeeID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._OrderCollectionByEmployeeID.fks.Add(OrderMetadata.ColumnNames.EmployeeID, this.EmployeeID);
					}
				}

				return this._OrderCollectionByEmployeeID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._OrderCollectionByEmployeeID != null) 
				{ 
					this.RemovePostSave("OrderCollectionByEmployeeID"); 
					this._OrderCollectionByEmployeeID = null;
					this.OnPropertyChanged("OrderCollectionByEmployeeID");
				} 
			} 			
		}
			
		
		private OrderCollection _OrderCollectionByEmployeeID;
		#endregion

		#region ReferredEmployeeCollectionByReferredID - Zero To Many
		
		static public esPrefetchMap Prefetch_ReferredEmployeeCollectionByReferredID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Employee.ReferredEmployeeCollectionByReferredID_Delegate;
				map.PropertyName = "ReferredEmployeeCollectionByReferredID";
				map.MyColumnName = "ReferredID";
				map.ParentColumnName = "EmployeeID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void ReferredEmployeeCollectionByReferredID_Delegate(esPrefetchParameters data)
		{
			EmployeeQuery parent = new EmployeeQuery(data.NextAlias());

			ReferredEmployeeQuery me = data.You != null ? data.You as ReferredEmployeeQuery : new ReferredEmployeeQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID == me.ReferredID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - EmployeeReferredEmployee
		/// </summary>

		public ReferredEmployeeCollection ReferredEmployeeCollectionByReferredID
		{
			get
			{
				if(this._ReferredEmployeeCollectionByReferredID == null)
				{
					this._ReferredEmployeeCollectionByReferredID = new ReferredEmployeeCollection();
					this._ReferredEmployeeCollectionByReferredID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ReferredEmployeeCollectionByReferredID", this._ReferredEmployeeCollectionByReferredID);
				
					if (this.EmployeeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ReferredEmployeeCollectionByReferredID.Query.Where(this._ReferredEmployeeCollectionByReferredID.Query.ReferredID == this.EmployeeID);
							this._ReferredEmployeeCollectionByReferredID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ReferredEmployeeCollectionByReferredID.fks.Add(ReferredEmployeeMetadata.ColumnNames.ReferredID, this.EmployeeID);
					}
				}

				return this._ReferredEmployeeCollectionByReferredID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ReferredEmployeeCollectionByReferredID != null) 
				{ 
					this.RemovePostSave("ReferredEmployeeCollectionByReferredID"); 
					this._ReferredEmployeeCollectionByReferredID = null;
					this.OnPropertyChanged("ReferredEmployeeCollectionByReferredID");
				} 
			} 			
		}
			
		
		private ReferredEmployeeCollection _ReferredEmployeeCollectionByReferredID;
		#endregion

		#region ReferredEmployeeCollectionByEmployeeID - Zero To Many
		
		static public esPrefetchMap Prefetch_ReferredEmployeeCollectionByEmployeeID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Employee.ReferredEmployeeCollectionByEmployeeID_Delegate;
				map.PropertyName = "ReferredEmployeeCollectionByEmployeeID";
				map.MyColumnName = "EmployeeID";
				map.ParentColumnName = "EmployeeID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void ReferredEmployeeCollectionByEmployeeID_Delegate(esPrefetchParameters data)
		{
			EmployeeQuery parent = new EmployeeQuery(data.NextAlias());

			ReferredEmployeeQuery me = data.You != null ? data.You as ReferredEmployeeQuery : new ReferredEmployeeQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID == me.EmployeeID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - EmployeeReferredEmployee1
		/// </summary>

		public ReferredEmployeeCollection ReferredEmployeeCollectionByEmployeeID
		{
			get
			{
				if(this._ReferredEmployeeCollectionByEmployeeID == null)
				{
					this._ReferredEmployeeCollectionByEmployeeID = new ReferredEmployeeCollection();
					this._ReferredEmployeeCollectionByEmployeeID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ReferredEmployeeCollectionByEmployeeID", this._ReferredEmployeeCollectionByEmployeeID);
				
					if (this.EmployeeID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ReferredEmployeeCollectionByEmployeeID.Query.Where(this._ReferredEmployeeCollectionByEmployeeID.Query.EmployeeID == this.EmployeeID);
							this._ReferredEmployeeCollectionByEmployeeID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ReferredEmployeeCollectionByEmployeeID.fks.Add(ReferredEmployeeMetadata.ColumnNames.EmployeeID, this.EmployeeID);
					}
				}

				return this._ReferredEmployeeCollectionByEmployeeID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ReferredEmployeeCollectionByEmployeeID != null) 
				{ 
					this.RemovePostSave("ReferredEmployeeCollectionByEmployeeID"); 
					this._ReferredEmployeeCollectionByEmployeeID = null;
					this.OnPropertyChanged("ReferredEmployeeCollectionByEmployeeID");
				} 
			} 			
		}
			
		
		private ReferredEmployeeCollection _ReferredEmployeeCollectionByEmployeeID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "EmployeeCollectionBySupervisor":
					coll = this.EmployeeCollectionBySupervisor;
					break;
				case "CustomerCollectionByManager":
					coll = this.CustomerCollectionByManager;
					break;
				case "CustomerCollectionByStaffAssigned":
					coll = this.CustomerCollectionByStaffAssigned;
					break;
				case "EmployeeTerritoryCollectionByEmpID":
					coll = this.EmployeeTerritoryCollectionByEmpID;
					break;
				case "OrderCollectionByEmployeeID":
					coll = this.OrderCollectionByEmployeeID;
					break;
				case "ReferredEmployeeCollectionByReferredID":
					coll = this.ReferredEmployeeCollectionByReferredID;
					break;
				case "ReferredEmployeeCollectionByEmployeeID":
					coll = this.ReferredEmployeeCollectionByEmployeeID;
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
			
			props.Add(new esPropertyDescriptor(this, "EmployeeCollectionBySupervisor", typeof(EmployeeCollection), new Employee()));
			props.Add(new esPropertyDescriptor(this, "CustomerCollectionByManager", typeof(CustomerCollection), new Customer()));
			props.Add(new esPropertyDescriptor(this, "CustomerCollectionByStaffAssigned", typeof(CustomerCollection), new Customer()));
			props.Add(new esPropertyDescriptor(this, "EmployeeTerritoryCollectionByEmpID", typeof(EmployeeTerritoryCollection), new EmployeeTerritory()));
			props.Add(new esPropertyDescriptor(this, "OrderCollectionByEmployeeID", typeof(OrderCollection), new Order()));
			props.Add(new esPropertyDescriptor(this, "ReferredEmployeeCollectionByReferredID", typeof(ReferredEmployeeCollection), new ReferredEmployee()));
			props.Add(new esPropertyDescriptor(this, "ReferredEmployeeCollectionByEmployeeID", typeof(ReferredEmployeeCollection), new ReferredEmployee()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToEmployeeBySupervisor != null)
			{
				this.Supervisor = this._UpToEmployeeBySupervisor.EmployeeID;
			}
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
			if(this._EmployeeCollectionBySupervisor != null)
			{
				Apply(this._EmployeeCollectionBySupervisor, "Supervisor", this.EmployeeID);
			}
			if(this._CustomerCollectionByManager != null)
			{
				Apply(this._CustomerCollectionByManager, "Manager", this.EmployeeID);
			}
			if(this._CustomerCollectionByStaffAssigned != null)
			{
				Apply(this._CustomerCollectionByStaffAssigned, "StaffAssigned", this.EmployeeID);
			}
			if(this._EmployeeTerritoryCollection != null)
			{
				Apply(this._EmployeeTerritoryCollection, "EmpID", this.EmployeeID);
			}
			if(this._EmployeeTerritoryCollectionByEmpID != null)
			{
				Apply(this._EmployeeTerritoryCollectionByEmpID, "EmpID", this.EmployeeID);
			}
			if(this._OrderCollectionByEmployeeID != null)
			{
				Apply(this._OrderCollectionByEmployeeID, "EmployeeID", this.EmployeeID);
			}
			if(this._ReferredEmployeeCollectionByReferredID != null)
			{
				Apply(this._ReferredEmployeeCollectionByReferredID, "ReferredID", this.EmployeeID);
			}
			if(this._ReferredEmployeeCollectionByEmployeeID != null)
			{
				Apply(this._ReferredEmployeeCollectionByEmployeeID, "EmployeeID", this.EmployeeID);
			}
		}
		
	}
	



	public partial class EmployeeMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected EmployeeMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(EmployeeMetadata.ColumnNames.EmployeeID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = EmployeeMetadata.PropertyNames.EmployeeID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EmployeeMetadata.ColumnNames.LastName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = EmployeeMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EmployeeMetadata.ColumnNames.FirstName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = EmployeeMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EmployeeMetadata.ColumnNames.Supervisor, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = EmployeeMetadata.PropertyNames.Supervisor;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EmployeeMetadata.ColumnNames.Age, 4, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = EmployeeMetadata.PropertyNames.Age;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public EmployeeMetadata Meta()
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
			 public const string LastName = "LastName";
			 public const string FirstName = "FirstName";
			 public const string Supervisor = "Supervisor";
			 public const string Age = "Age";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string EmployeeID = "EmployeeID";
			 public const string LastName = "LastName";
			 public const string FirstName = "FirstName";
			 public const string Supervisor = "Supervisor";
			 public const string Age = "Age";
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
			lock (typeof(EmployeeMetadata))
			{
				if(EmployeeMetadata.mapDelegates == null)
				{
					EmployeeMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EmployeeMetadata.meta == null)
				{
					EmployeeMetadata.meta = new EmployeeMetadata();
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
				meta.AddTypeMap("LastName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Supervisor", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"));			
				
				
				
				meta.Source = "Employee";
				meta.Destination = "Employee";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private EmployeeMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
