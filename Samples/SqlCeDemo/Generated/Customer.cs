
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
	/// Encapsulates the 'Customer' table
	/// </summary>

	public partial class Customer : esCustomer
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Customer();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String customerID, System.String customerSub)
		{
			var obj = new Customer();
			obj.CustomerID = customerID;
			obj.CustomerSub = customerSub;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String customerID, System.String customerSub, esSqlAccessType sqlAccessType)
		{
			var obj = new Customer();
			obj.CustomerID = customerID;
			obj.CustomerSub = customerSub;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class CustomerCollection : esCustomerCollection, IEnumerable<Customer>
	{
		public Customer FindByPrimaryKey(System.String customerID, System.String customerSub)
		{
			return this.SingleOrDefault(e => e.CustomerID == customerID && e.CustomerSub == customerSub);
		}

		
		
		
				
	}


	
	public partial class CustomerQuery : esCustomerQuery
	{
		public CustomerQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomerQuery";
		}
		
					
		
	}

	abstract public partial class esCustomer : esEntity
	{
		public esCustomer()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String customerID, System.String customerSub)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID, customerSub);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID, customerSub);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String customerID, System.String customerSub)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(customerID, customerSub);
			else
				return LoadByPrimaryKeyStoredProcedure(customerID, customerSub);
		}

		private bool LoadByPrimaryKeyDynamic(System.String customerID, System.String customerSub)
		{
			CustomerQuery query = new CustomerQuery();
			query.Where(query.CustomerID == customerID, query.CustomerSub == customerSub);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String customerID, System.String customerSub)
		{
			esParameters parms = new esParameters();
			parms.Add("CustomerID", customerID);			parms.Add("CustomerSub", customerSub);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Customer.CustomerID
		/// </summary>
		virtual public System.String CustomerID
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.CustomerID);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.CustomerID, value))
				{
					this._UpToCustomerGroupByCustomerID = null;
					this.OnPropertyChanged("UpToCustomerGroupByCustomerID");
					OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.CustomerSub
		/// </summary>
		virtual public System.String CustomerSub
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.CustomerSub);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.CustomerSub, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerSub);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.CustomerName
		/// </summary>
		virtual public System.String CustomerName
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.CustomerName);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.CustomerName, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.DateAdded
		/// </summary>
		virtual public System.DateTime? DateAdded
		{
			get
			{
				return base.GetSystemDateTime(CustomerMetadata.ColumnNames.DateAdded);
			}
			
			set
			{
				if(base.SetSystemDateTime(CustomerMetadata.ColumnNames.DateAdded, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.DateAdded);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Active
		/// </summary>
		virtual public System.Boolean? Active
		{
			get
			{
				return base.GetSystemBoolean(CustomerMetadata.ColumnNames.Active);
			}
			
			set
			{
				if(base.SetSystemBoolean(CustomerMetadata.ColumnNames.Active, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Active);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.ConcurrencyCheck
		/// </summary>
		virtual public System.Int32? ConcurrencyCheck
		{
			get
			{
				return base.GetSystemInt32(CustomerMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomerMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Manager
		/// </summary>
		virtual public System.Int32? Manager
		{
			get
			{
				return base.GetSystemInt32(CustomerMetadata.ColumnNames.Manager);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomerMetadata.ColumnNames.Manager, value))
				{
					this._UpToEmployeeByManager = null;
					this.OnPropertyChanged("UpToEmployeeByManager");
					OnPropertyChanged(CustomerMetadata.PropertyNames.Manager);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.StaffAssigned
		/// </summary>
		virtual public System.Int32? StaffAssigned
		{
			get
			{
				return base.GetSystemInt32(CustomerMetadata.ColumnNames.StaffAssigned);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomerMetadata.ColumnNames.StaffAssigned, value))
				{
					this._UpToEmployeeByStaffAssigned = null;
					this.OnPropertyChanged("UpToEmployeeByStaffAssigned");
					OnPropertyChanged(CustomerMetadata.PropertyNames.StaffAssigned);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.UniqueID
		/// </summary>
		virtual public System.Guid? UniqueID
		{
			get
			{
				return base.GetSystemGuid(CustomerMetadata.ColumnNames.UniqueID);
			}
			
			set
			{
				if(base.SetSystemGuid(CustomerMetadata.ColumnNames.UniqueID, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.UniqueID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Notes
		/// </summary>
		virtual public System.String Notes
		{
			get
			{
				return base.GetSystemString(CustomerMetadata.ColumnNames.Notes);
			}
			
			set
			{
				if(base.SetSystemString(CustomerMetadata.ColumnNames.Notes, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Notes);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.CreditLimit
		/// </summary>
		virtual public System.Decimal? CreditLimit
		{
			get
			{
				return base.GetSystemDecimal(CustomerMetadata.ColumnNames.CreditLimit);
			}
			
			set
			{
				if(base.SetSystemDecimal(CustomerMetadata.ColumnNames.CreditLimit, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.CreditLimit);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Discount
		/// </summary>
		virtual public System.Double? Discount
		{
			get
			{
				return base.GetSystemDouble(CustomerMetadata.ColumnNames.Discount);
			}
			
			set
			{
				if(base.SetSystemDouble(CustomerMetadata.ColumnNames.Discount, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.Discount);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected CustomerGroup _UpToCustomerGroupByCustomerID;
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeByManager;
		[CLSCompliant(false)]
		internal protected Employee _UpToEmployeeByStaffAssigned;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomerMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomerQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomerQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private CustomerQuery query;		
	}



	abstract public partial class esCustomerCollection : esEntityCollection<Customer>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomerMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomerCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomerQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomerQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomerQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomerQuery)query);
		}

		#endregion
		
		private CustomerQuery query;
	}



	abstract public partial class esCustomerQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomerMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CustomerID": return this.CustomerID;
				case "CustomerSub": return this.CustomerSub;
				case "CustomerName": return this.CustomerName;
				case "DateAdded": return this.DateAdded;
				case "Active": return this.Active;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;
				case "Manager": return this.Manager;
				case "StaffAssigned": return this.StaffAssigned;
				case "UniqueID": return this.UniqueID;
				case "Notes": return this.Notes;
				case "CreditLimit": return this.CreditLimit;
				case "Discount": return this.Discount;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.CustomerID, esSystemType.String); }
		} 
		
		public esQueryItem CustomerSub
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.CustomerSub, esSystemType.String); }
		} 
		
		public esQueryItem CustomerName
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.CustomerName, esSystemType.String); }
		} 
		
		public esQueryItem DateAdded
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.DateAdded, esSystemType.DateTime); }
		} 
		
		public esQueryItem Active
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Active, esSystemType.Boolean); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int32); }
		} 
		
		public esQueryItem Manager
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Manager, esSystemType.Int32); }
		} 
		
		public esQueryItem StaffAssigned
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.StaffAssigned, esSystemType.Int32); }
		} 
		
		public esQueryItem UniqueID
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.UniqueID, esSystemType.Guid); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Notes, esSystemType.String); }
		} 
		
		public esQueryItem CreditLimit
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.CreditLimit, esSystemType.Decimal); }
		} 
		
		public esQueryItem Discount
		{
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Discount, esSystemType.Double); }
		} 
		
		#endregion
		
	}


	
	public partial class Customer : esCustomer
	{

				
		#region UpToCustomerGroupByCustomerID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - CustomerGroupCustomer
		/// </summary>

					
		public CustomerGroup UpToCustomerGroupByCustomerID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCustomerGroupByCustomerID == null && CustomerID != null)
				{
					this._UpToCustomerGroupByCustomerID = new CustomerGroup();
					this._UpToCustomerGroupByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomerGroupByCustomerID", this._UpToCustomerGroupByCustomerID);
					this._UpToCustomerGroupByCustomerID.Query.Where(this._UpToCustomerGroupByCustomerID.Query.GroupID == this.CustomerID);
					this._UpToCustomerGroupByCustomerID.Query.Load();
				}	
				return this._UpToCustomerGroupByCustomerID;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomerGroupByCustomerID");
				
				bool changed = this._UpToCustomerGroupByCustomerID != value;

				if(value == null)
				{
					this.CustomerID = null;
					this._UpToCustomerGroupByCustomerID = null;
				}
				else
				{
					this.CustomerID = value.GroupID;
					this._UpToCustomerGroupByCustomerID = value;
					this.SetPreSave("UpToCustomerGroupByCustomerID", this._UpToCustomerGroupByCustomerID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCustomerGroupByCustomerID");
				}
			}
		}
		#endregion
		

				
		#region UpToEmployeeByManager - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - EmployeeCustomer
		/// </summary>

					
		public Employee UpToEmployeeByManager
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeeByManager == null && Manager != null)
				{
					this._UpToEmployeeByManager = new Employee();
					this._UpToEmployeeByManager.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeeByManager", this._UpToEmployeeByManager);
					this._UpToEmployeeByManager.Query.Where(this._UpToEmployeeByManager.Query.EmployeeID == this.Manager);
					this._UpToEmployeeByManager.Query.Load();
				}	
				return this._UpToEmployeeByManager;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeeByManager");
				
				bool changed = this._UpToEmployeeByManager != value;

				if(value == null)
				{
					this.Manager = null;
					this._UpToEmployeeByManager = null;
				}
				else
				{
					this.Manager = value.EmployeeID;
					this._UpToEmployeeByManager = value;
					this.SetPreSave("UpToEmployeeByManager", this._UpToEmployeeByManager);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeeByManager");
				}
			}
		}
		#endregion
		

				
		#region UpToEmployeeByStaffAssigned - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - EmployeeCustomer1
		/// </summary>

					
		public Employee UpToEmployeeByStaffAssigned
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeeByStaffAssigned == null && StaffAssigned != null)
				{
					this._UpToEmployeeByStaffAssigned = new Employee();
					this._UpToEmployeeByStaffAssigned.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeeByStaffAssigned", this._UpToEmployeeByStaffAssigned);
					this._UpToEmployeeByStaffAssigned.Query.Where(this._UpToEmployeeByStaffAssigned.Query.EmployeeID == this.StaffAssigned);
					this._UpToEmployeeByStaffAssigned.Query.Load();
				}	
				return this._UpToEmployeeByStaffAssigned;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeeByStaffAssigned");
				
				bool changed = this._UpToEmployeeByStaffAssigned != value;

				if(value == null)
				{
					this.StaffAssigned = null;
					this._UpToEmployeeByStaffAssigned = null;
				}
				else
				{
					this.StaffAssigned = value.EmployeeID;
					this._UpToEmployeeByStaffAssigned = value;
					this.SetPreSave("UpToEmployeeByStaffAssigned", this._UpToEmployeeByStaffAssigned);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeeByStaffAssigned");
				}
			}
		}
		#endregion
		

		#region OrderCollectionByCustID - Zero To Many
		
		static public esPrefetchMap Prefetch_OrderCollectionByCustID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Customer.OrderCollectionByCustID_Delegate;
				map.PropertyName = "OrderCollectionByCustID";
				map.MyColumnName = "CustID,CustSub";
				map.ParentColumnName = "CustomerID,CustomerSub";
				map.IsMultiPartKey = true;
				return map;
			}
		}		
		
		static private void OrderCollectionByCustID_Delegate(esPrefetchParameters data)
		{
			CustomerQuery parent = new CustomerQuery(data.NextAlias());

			OrderQuery me = data.You != null ? data.You as OrderQuery : new OrderQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.CustomerID == me.CustID && parent.CustomerSub == me.CustSub);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - CustomerOrder
		/// </summary>

		public OrderCollection OrderCollectionByCustID
		{
			get
			{
				if(this._OrderCollectionByCustID == null)
				{
					this._OrderCollectionByCustID = new OrderCollection();
					this._OrderCollectionByCustID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("OrderCollectionByCustID", this._OrderCollectionByCustID);
				
					if (this.CustomerID != null && this.CustomerSub != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._OrderCollectionByCustID.Query.Where(this._OrderCollectionByCustID.Query.CustID == this.CustomerID);
							this._OrderCollectionByCustID.Query.Where(this._OrderCollectionByCustID.Query.CustSub == this.CustomerSub);
							this._OrderCollectionByCustID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._OrderCollectionByCustID.fks.Add(OrderMetadata.ColumnNames.CustID, this.CustomerID);
						this._OrderCollectionByCustID.fks.Add(OrderMetadata.ColumnNames.CustSub, this.CustomerSub);
					}
				}

				return this._OrderCollectionByCustID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._OrderCollectionByCustID != null) 
				{ 
					this.RemovePostSave("OrderCollectionByCustID"); 
					this._OrderCollectionByCustID = null;
					this.OnPropertyChanged("OrderCollectionByCustID");
				} 
			} 			
		}
			
		
		private OrderCollection _OrderCollectionByCustID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrderCollectionByCustID":
					coll = this.OrderCollectionByCustID;
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
			
			props.Add(new esPropertyDescriptor(this, "OrderCollectionByCustID", typeof(OrderCollection), new Order()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToEmployeeByManager != null)
			{
				this.Manager = this._UpToEmployeeByManager.EmployeeID;
			}
			if(!this.es.IsDeleted && this._UpToEmployeeByStaffAssigned != null)
			{
				this.StaffAssigned = this._UpToEmployeeByStaffAssigned.EmployeeID;
			}
		}
		
	}
	



	public partial class CustomerMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomerMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomerMetadata.ColumnNames.CustomerID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.CustomerID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.CustomerSub, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.CustomerSub;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.CustomerName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.CustomerName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.DateAdded, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomerMetadata.PropertyNames.DateAdded;
			c.NumericPrecision = 23;
			c.NumericScale = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Active, 4, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = CustomerMetadata.PropertyNames.Active;
			c.NumericPrecision = 1;
			c.HasDefault = true;
			c.Default = @"1";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.ConcurrencyCheck, 5, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomerMetadata.PropertyNames.ConcurrencyCheck;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"0";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Manager, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomerMetadata.PropertyNames.Manager;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.StaffAssigned, 7, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomerMetadata.PropertyNames.StaffAssigned;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.UniqueID, 8, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = CustomerMetadata.PropertyNames.UniqueID;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Notes, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 536870911;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.CreditLimit, 10, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = CustomerMetadata.PropertyNames.CreditLimit;
			c.NumericPrecision = 19;
			c.NumericScale = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Discount, 11, typeof(System.Double), esSystemType.Double);
			c.PropertyName = CustomerMetadata.PropertyNames.Discount;
			c.NumericPrecision = 53;
			c.IsNullable = true;
			m_columns.Add(c);
				
			m_columns.DateAdded = new esColumnMetadataCollection.SpecialDate();
			m_columns.DateAdded.ColumnName = "DateAdded";
			m_columns.DateAdded.IsEnabled = true;
			m_columns.DateAdded.Type = DateType.ClientSide;
			m_columns.DateAdded.ClientType = ClientType.Now;

		}
		#endregion	
	
		static public CustomerMetadata Meta()
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
			 public const string CustomerID = "CustomerID";
			 public const string CustomerSub = "CustomerSub";
			 public const string CustomerName = "CustomerName";
			 public const string DateAdded = "DateAdded";
			 public const string Active = "Active";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string Manager = "Manager";
			 public const string StaffAssigned = "StaffAssigned";
			 public const string UniqueID = "UniqueID";
			 public const string Notes = "Notes";
			 public const string CreditLimit = "CreditLimit";
			 public const string Discount = "Discount";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CustomerID = "CustomerID";
			 public const string CustomerSub = "CustomerSub";
			 public const string CustomerName = "CustomerName";
			 public const string DateAdded = "DateAdded";
			 public const string Active = "Active";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string Manager = "Manager";
			 public const string StaffAssigned = "StaffAssigned";
			 public const string UniqueID = "UniqueID";
			 public const string Notes = "Notes";
			 public const string CreditLimit = "CreditLimit";
			 public const string Discount = "Discount";
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
			lock (typeof(CustomerMetadata))
			{
				if(CustomerMetadata.mapDelegates == null)
				{
					CustomerMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerMetadata.meta == null)
				{
					CustomerMetadata.meta = new CustomerMetadata();
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


				meta.AddTypeMap("CustomerID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CustomerSub", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CustomerName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Active", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Manager", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("StaffAssigned", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UniqueID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Notes", new esTypeMap("ntext", "System.String"));
				meta.AddTypeMap("CreditLimit", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("float", "System.Double"));			
				
				
				
				meta.Source = "Customer";
				meta.Destination = "Customer";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomerMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
