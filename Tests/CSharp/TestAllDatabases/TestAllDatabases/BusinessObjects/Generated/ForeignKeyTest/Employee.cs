
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
	/// Encapsulates the 'Employee' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Employee))]	
	[XmlType("Employee")]
	[Table(Name="Employee")]
	public partial class Employee : esEmployee
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
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

		#region Implicit Casts

		public static implicit operator EmployeeProxyStub(Employee entity)
		{
			return new EmployeeProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? EmployeeID
		{
			get { return base.EmployeeID;  }
			set { base.EmployeeID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String LastName
		{
			get { return base.LastName;  }
			set { base.LastName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String FirstName
		{
			get { return base.FirstName;  }
			set { base.FirstName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? Supervisor
		{
			get { return base.Supervisor;  }
			set { base.Supervisor = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? Age
		{
			get { return base.Age;  }
			set { base.Age = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("EmployeeCollection")]
	public partial class EmployeeCollection : esEmployeeCollection, IEnumerable<Employee>
	{
		public Employee FindByPrimaryKey(System.Int32 employeeID)
		{
			return this.SingleOrDefault(e => e.EmployeeID == employeeID);
		}

		#region Implicit Casts
		
		public static implicit operator EmployeeCollectionProxyStub(EmployeeCollection coll)
		{
			return new EmployeeCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Employee))]
		public class EmployeeCollectionWCFPacket : esCollectionWCFPacket<EmployeeCollection>
		{
			public static implicit operator EmployeeCollection(EmployeeCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator EmployeeCollectionWCFPacket(EmployeeCollection collection)
			{
				return new EmployeeCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "EmployeeQuery", Namespace = "http://www.entityspaces.net")]	
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
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(EmployeeQuery query)
		{
			return EmployeeQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator EmployeeQuery(string query)
		{
			return (EmployeeQuery)EmployeeQuery.SerializeHelper.FromXml(query, typeof(EmployeeQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
						case "LastName": this.str().LastName = (string)value; break;							
						case "FirstName": this.str().FirstName = (string)value; break;							
						case "Supervisor": this.str().Supervisor = (string)value; break;							
						case "Age": this.str().Age = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "EmployeeID":
						
							if (value == null || value is System.Int32)
								this.EmployeeID = (System.Int32?)value;
								OnPropertyChanged(EmployeeMetadata.PropertyNames.EmployeeID);
							break;
						
						case "Supervisor":
						
							if (value == null || value is System.Int32)
								this.Supervisor = (System.Int32?)value;
								OnPropertyChanged(EmployeeMetadata.PropertyNames.Supervisor);
							break;
						
						case "Age":
						
							if (value == null || value is System.Int32)
								this.Age = (System.Int32?)value;
								OnPropertyChanged(EmployeeMetadata.PropertyNames.Age);
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
			public esStrings(esEmployee entity)
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
				
			public System.String LastName
			{
				get
				{
					System.String data = entity.LastName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastName = null;
					else entity.LastName = Convert.ToString(value);
				}
			}
				
			public System.String FirstName
			{
				get
				{
					System.String data = entity.FirstName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FirstName = null;
					else entity.FirstName = Convert.ToString(value);
				}
			}
				
			public System.String Supervisor
			{
				get
				{
					System.Int32? data = entity.Supervisor;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Supervisor = null;
					else entity.Supervisor = Convert.ToInt32(value);
				}
			}
				
			public System.String Age
			{
				get
				{
					System.Int32? data = entity.Age;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Age = null;
					else entity.Age = Convert.ToInt32(value);
				}
			}
			

			private esEmployee entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
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
		
        [IgnoreDataMember]
		private EmployeeQuery query;		
	}



	[Serializable]
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



	[Serializable]
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
		/// Foreign Key Name - FK_Customer_Manager
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_Customer_StaffAssigned
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_EmpSupervisor
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_EmpSupervisor
		/// </summary>

		[XmlIgnore]
					
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
		

		#region UpToTerritoryCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_EmployeeTerritory_Employee
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_EmployeeTerritory_Employee
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
		/// Foreign Key Name - FK_EmployeeTerritory_Employee
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
		/// Foreign Key Name - FK_EmployeeTerritory_Employee
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_Order_Employee
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_ReferredEmployee_Employee1
		/// </summary>

		[XmlIgnore]
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
		/// Foreign Key Name - FK_ReferredEmployee_Employee2
		/// </summary>

		[XmlIgnore]
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

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "CustomerCollectionByManager":
					coll = this.CustomerCollectionByManager;
					break;
				case "CustomerCollectionByStaffAssigned":
					coll = this.CustomerCollectionByStaffAssigned;
					break;
				case "EmployeeCollectionBySupervisor":
					coll = this.EmployeeCollectionBySupervisor;
					break;
				case "EmployeeTerritoryCollectionByEmpID":
					coll = this.EmployeeTerritoryCollectionByEmpID;
					break;
				case "OrderCollectionByEmployeeID":
					coll = this.OrderCollectionByEmployeeID;
					break;
				case "ReferredEmployeeCollectionByEmployeeID":
					coll = this.ReferredEmployeeCollectionByEmployeeID;
					break;
				case "ReferredEmployeeCollectionByReferredID":
					coll = this.ReferredEmployeeCollectionByReferredID;
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
			
			props.Add(new esPropertyDescriptor(this, "CustomerCollectionByManager", typeof(CustomerCollection), new Customer()));
			props.Add(new esPropertyDescriptor(this, "CustomerCollectionByStaffAssigned", typeof(CustomerCollection), new Customer()));
			props.Add(new esPropertyDescriptor(this, "EmployeeCollectionBySupervisor", typeof(EmployeeCollection), new Employee()));
			props.Add(new esPropertyDescriptor(this, "EmployeeTerritoryCollectionByEmpID", typeof(EmployeeTerritoryCollection), new EmployeeTerritory()));
			props.Add(new esPropertyDescriptor(this, "OrderCollectionByEmployeeID", typeof(OrderCollection), new Order()));
			props.Add(new esPropertyDescriptor(this, "ReferredEmployeeCollectionByEmployeeID", typeof(ReferredEmployeeCollection), new ReferredEmployee()));
			props.Add(new esPropertyDescriptor(this, "ReferredEmployeeCollectionByReferredID", typeof(ReferredEmployeeCollection), new ReferredEmployee()));
		
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
			if(this._CustomerCollectionByManager != null)
			{
				Apply(this._CustomerCollectionByManager, "Manager", this.EmployeeID);
			}
			if(this._CustomerCollectionByStaffAssigned != null)
			{
				Apply(this._CustomerCollectionByStaffAssigned, "StaffAssigned", this.EmployeeID);
			}
			if(this._EmployeeCollectionBySupervisor != null)
			{
				Apply(this._EmployeeCollectionBySupervisor, "Supervisor", this.EmployeeID);
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
			if(this._ReferredEmployeeCollectionByEmployeeID != null)
			{
				Apply(this._ReferredEmployeeCollectionByEmployeeID, "EmployeeID", this.EmployeeID);
			}
			if(this._ReferredEmployeeCollectionByReferredID != null)
			{
				Apply(this._ReferredEmployeeCollectionByReferredID, "ReferredID", this.EmployeeID);
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Employee")]
	[XmlType(TypeName="EmployeeProxyStub")]	
	[Serializable]
	public partial class EmployeeProxyStub
	{
		public EmployeeProxyStub() 
		{
			theEntity = this.entity = new Employee();
		}

		public EmployeeProxyStub(Employee obj)
		{
			theEntity = this.entity = obj;
		}

		public EmployeeProxyStub(Employee obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Employee(EmployeeProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Employee);
		}

		[DataMember(Name="EmployeeID", Order=1, EmitDefaultValue=false)]
		public System.Int32? EmployeeID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(EmployeeMetadata.ColumnNames.EmployeeID);
				else
					return this.Entity.EmployeeID;
			}
			set { this.Entity.EmployeeID = value; }
		}

		[DataMember(Name="LastName", Order=2, EmitDefaultValue=false)]
		public System.String LastName
		{
			get 
			{ 
				
				if (this.IncludeColumn(EmployeeMetadata.ColumnNames.LastName))
					return this.Entity.LastName;
				else
					return null;
			}
			set { this.Entity.LastName = value; }
		}

		[DataMember(Name="FirstName", Order=3, EmitDefaultValue=false)]
		public System.String FirstName
		{
			get 
			{ 
				
				if (this.IncludeColumn(EmployeeMetadata.ColumnNames.FirstName))
					return this.Entity.FirstName;
				else
					return null;
			}
			set { this.Entity.FirstName = value; }
		}

		[DataMember(Name="Supervisor", Order=4, EmitDefaultValue=false)]
		public System.Int32? Supervisor
		{
			get 
			{ 
				
				if (this.IncludeColumn(EmployeeMetadata.ColumnNames.Supervisor))
					return this.Entity.Supervisor;
				else
					return null;
			}
			set { this.Entity.Supervisor = value; }
		}

		[DataMember(Name="Age", Order=5, EmitDefaultValue=false)]
		public System.Int32? Age
		{
			get 
			{ 
				
				if (this.IncludeColumn(EmployeeMetadata.ColumnNames.Age))
					return this.Entity.Age;
				else
					return null;
			}
			set { this.Entity.Age = value; }
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
		public Employee Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Employee();
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
		public Employee entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeCollection")]
	[XmlType(TypeName="EmployeeCollectionProxyStub")]	
	[Serializable]
	public partial class EmployeeCollectionProxyStub 
	{
		protected EmployeeCollectionProxyStub() {}
		
		public EmployeeCollectionProxyStub(esEntityCollection<Employee> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public EmployeeCollectionProxyStub(esEntityCollection<Employee> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator EmployeeCollection(EmployeeCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Employee);
		}
		
		public EmployeeCollectionProxyStub(esEntityCollection<Employee> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Employee entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new EmployeeProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new EmployeeProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Employee entity in coll.es.DeletedEntities)
				{
					Collection.Add(new EmployeeProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<EmployeeProxyStub> Collection = new List<EmployeeProxyStub>();

		public EmployeeCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new EmployeeCollection();

				foreach (EmployeeProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private EmployeeCollection _coll;
	}



	[Serializable]
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
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Supervisor", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Employee";
				meta.Destination = "Employee";
				
				meta.spInsert = "proc_EmployeeInsert";				
				meta.spUpdate = "proc_EmployeeUpdate";		
				meta.spDelete = "proc_EmployeeDelete";
				meta.spLoadAll = "proc_EmployeeLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeLoadByPrimaryKey";
				
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
