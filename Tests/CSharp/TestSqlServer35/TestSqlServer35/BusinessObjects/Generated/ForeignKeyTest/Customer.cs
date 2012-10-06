
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
	/// Encapsulates the 'Customer' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Customer))]	
	[XmlType("Customer")]
	[Table(Name="Customer")]
	public partial class Customer : esCustomer
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
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

		#region Implicit Casts

		public static implicit operator CustomerProxyStub(Customer entity)
		{
			return new CustomerProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String CustomerID
		{
			get { return base.CustomerID;  }
			set { base.CustomerID = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String CustomerSub
		{
			get { return base.CustomerSub;  }
			set { base.CustomerSub = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String CustomerName
		{
			get { return base.CustomerName;  }
			set { base.CustomerName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.DateTime? DateAdded
		{
			get { return base.DateAdded;  }
			set { base.DateAdded = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Boolean? Active
		{
			get { return base.Active;  }
			set { base.Active = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Byte[] ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int32? Manager
		{
			get { return base.Manager;  }
			set { base.Manager = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? StaffAssigned
		{
			get { return base.StaffAssigned;  }
			set { base.StaffAssigned = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Guid? UniqueID
		{
			get { return base.UniqueID;  }
			set { base.UniqueID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String Notes
		{
			get { return base.Notes;  }
			set { base.Notes = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? CreditLimit
		{
			get { return base.CreditLimit;  }
			set { base.CreditLimit = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? Discount
		{
			get { return base.Discount;  }
			set { base.Discount = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomerCollection")]
	public partial class CustomerCollection : esCustomerCollection, IEnumerable<Customer>
	{
		public Customer FindByPrimaryKey(System.String customerID, System.String customerSub)
		{
			return this.SingleOrDefault(e => e.CustomerID == customerID && e.CustomerSub == customerSub);
		}

		#region Implicit Casts
		
		public static implicit operator CustomerCollectionProxyStub(CustomerCollection coll)
		{
			return new CustomerCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Customer))]
		public class CustomerCollectionWCFPacket : esCollectionWCFPacket<CustomerCollection>
		{
			public static implicit operator CustomerCollection(CustomerCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomerCollectionWCFPacket(CustomerCollection collection)
			{
				return new CustomerCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "CustomerQuery", Namespace = "http://www.entityspaces.net")]	
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
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomerQuery query)
		{
			return CustomerQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomerQuery(string query)
		{
			return (CustomerQuery)CustomerQuery.SerializeHelper.FromXml(query, typeof(CustomerQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte[] ConcurrencyCheck
		{
			get
			{
				return base.GetSystemByteArray(CustomerMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemByteArray(CustomerMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(CustomerMetadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Customer.Manager
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
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
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Discount
		{
			get
			{
				return base.GetSystemDecimal(CustomerMetadata.ColumnNames.Discount);
			}
			
			set
			{
				if(base.SetSystemDecimal(CustomerMetadata.ColumnNames.Discount, value))
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
						case "CustomerID": this.str().CustomerID = (string)value; break;							
						case "CustomerSub": this.str().CustomerSub = (string)value; break;							
						case "CustomerName": this.str().CustomerName = (string)value; break;							
						case "DateAdded": this.str().DateAdded = (string)value; break;							
						case "Active": this.str().Active = (string)value; break;							
						case "Manager": this.str().Manager = (string)value; break;							
						case "StaffAssigned": this.str().StaffAssigned = (string)value; break;							
						case "UniqueID": this.str().UniqueID = (string)value; break;							
						case "Notes": this.str().Notes = (string)value; break;							
						case "CreditLimit": this.str().CreditLimit = (string)value; break;							
						case "Discount": this.str().Discount = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "DateAdded":
						
							if (value == null || value is System.DateTime)
								this.DateAdded = (System.DateTime?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.DateAdded);
							break;
						
						case "Active":
						
							if (value == null || value is System.Boolean)
								this.Active = (System.Boolean?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.Active);
							break;
						
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Byte[])
								this.ConcurrencyCheck = (System.Byte[])value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.ConcurrencyCheck);
							break;
						
						case "Manager":
						
							if (value == null || value is System.Int32)
								this.Manager = (System.Int32?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.Manager);
							break;
						
						case "StaffAssigned":
						
							if (value == null || value is System.Int32)
								this.StaffAssigned = (System.Int32?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.StaffAssigned);
							break;
						
						case "UniqueID":
						
							if (value == null || value is System.Guid)
								this.UniqueID = (System.Guid?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.UniqueID);
							break;
						
						case "CreditLimit":
						
							if (value == null || value is System.Decimal)
								this.CreditLimit = (System.Decimal?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.CreditLimit);
							break;
						
						case "Discount":
						
							if (value == null || value is System.Decimal)
								this.Discount = (System.Decimal?)value;
								OnPropertyChanged(CustomerMetadata.PropertyNames.Discount);
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
			public esStrings(esCustomer entity)
			{
				this.entity = entity;
			}
			
	
			public System.String CustomerID
			{
				get
				{
					System.String data = entity.CustomerID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerID = null;
					else entity.CustomerID = Convert.ToString(value);
				}
			}
				
			public System.String CustomerSub
			{
				get
				{
					System.String data = entity.CustomerSub;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerSub = null;
					else entity.CustomerSub = Convert.ToString(value);
				}
			}
				
			public System.String CustomerName
			{
				get
				{
					System.String data = entity.CustomerName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerName = null;
					else entity.CustomerName = Convert.ToString(value);
				}
			}
				
			public System.String DateAdded
			{
				get
				{
					System.DateTime? data = entity.DateAdded;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateAdded = null;
					else entity.DateAdded = Convert.ToDateTime(value);
				}
			}
				
			public System.String Active
			{
				get
				{
					System.Boolean? data = entity.Active;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Active = null;
					else entity.Active = Convert.ToBoolean(value);
				}
			}
				
			public System.String Manager
			{
				get
				{
					System.Int32? data = entity.Manager;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Manager = null;
					else entity.Manager = Convert.ToInt32(value);
				}
			}
				
			public System.String StaffAssigned
			{
				get
				{
					System.Int32? data = entity.StaffAssigned;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StaffAssigned = null;
					else entity.StaffAssigned = Convert.ToInt32(value);
				}
			}
				
			public System.String UniqueID
			{
				get
				{
					System.Guid? data = entity.UniqueID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UniqueID = null;
					else entity.UniqueID = new Guid(value);
				}
			}
				
			public System.String Notes
			{
				get
				{
					System.String data = entity.Notes;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Notes = null;
					else entity.Notes = Convert.ToString(value);
				}
			}
				
			public System.String CreditLimit
			{
				get
				{
					System.Decimal? data = entity.CreditLimit;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CreditLimit = null;
					else entity.CreditLimit = Convert.ToDecimal(value);
				}
			}
				
			public System.String Discount
			{
				get
				{
					System.Decimal? data = entity.Discount;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Discount = null;
					else entity.Discount = Convert.ToDecimal(value);
				}
			}
			

			private esCustomer entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
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
		
        [IgnoreDataMember]
		private CustomerQuery query;		
	}



	[Serializable]
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



	[Serializable]
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
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray); }
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
			get { return new esQueryItem(this, CustomerMetadata.ColumnNames.Discount, esSystemType.Decimal); }
		} 
		
		#endregion
		
	}


	
	public partial class Customer : esCustomer
	{

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
		/// Foreign Key Name - FK_Orders_Customers
		/// </summary>

		[XmlIgnore]
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

				
		#region UpToCustomerGroupByCustomerID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Customer_CustomerGroup
		/// </summary>

		[XmlIgnore]
					
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
		/// Foreign Key Name - FK_Customer_Manager
		/// </summary>

		[XmlIgnore]
					
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
		/// Foreign Key Name - FK_Customer_StaffAssigned
		/// </summary>

		[XmlIgnore]
					
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
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Customer")]
	[XmlType(TypeName="CustomerProxyStub")]	
	[Serializable]
	public partial class CustomerProxyStub
	{
		public CustomerProxyStub() 
		{
			theEntity = this.entity = new Customer();
		}

		public CustomerProxyStub(Customer obj)
		{
			theEntity = this.entity = obj;
		}

		public CustomerProxyStub(Customer obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Customer(CustomerProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Customer);
		}

		[DataMember(Name="CustomerID", Order=1, EmitDefaultValue=false)]
		public System.String CustomerID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CustomerMetadata.ColumnNames.CustomerID);
				else
					return this.Entity.CustomerID;
			}
			set { this.Entity.CustomerID = value; }
		}

		[DataMember(Name="CustomerSub", Order=2, EmitDefaultValue=false)]
		public System.String CustomerSub
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CustomerMetadata.ColumnNames.CustomerSub);
				else
					return this.Entity.CustomerSub;
			}
			set { this.Entity.CustomerSub = value; }
		}

		[DataMember(Name="CustomerName", Order=3, EmitDefaultValue=false)]
		public System.String CustomerName
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.CustomerName))
					return this.Entity.CustomerName;
				else
					return null;
			}
			set { this.Entity.CustomerName = value; }
		}

		[DataMember(Name="DateAdded", Order=4, EmitDefaultValue=false)]
		public System.DateTime? DateAdded
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.DateAdded))
					return this.Entity.DateAdded;
				else
					return null;
			}
			set { this.Entity.DateAdded = value; }
		}

		[DataMember(Name="Active", Order=5, EmitDefaultValue=false)]
		public System.Boolean? Active
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.Active))
					return this.Entity.Active;
				else
					return null;
			}
			set { this.Entity.Active = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=6, EmitDefaultValue=false)]
		public System.Byte[] ConcurrencyCheck
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.ConcurrencyCheck))
					return this.Entity.ConcurrencyCheck;
				else
					return null;
			}
			set { this.Entity.ConcurrencyCheck = value; }
		}

		[DataMember(Name="Manager", Order=7, EmitDefaultValue=false)]
		public System.Int32? Manager
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.Manager))
					return this.Entity.Manager;
				else
					return null;
			}
			set { this.Entity.Manager = value; }
		}

		[DataMember(Name="StaffAssigned", Order=8, EmitDefaultValue=false)]
		public System.Int32? StaffAssigned
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.StaffAssigned))
					return this.Entity.StaffAssigned;
				else
					return null;
			}
			set { this.Entity.StaffAssigned = value; }
		}

		[DataMember(Name="UniqueID", Order=9, EmitDefaultValue=false)]
		public System.Guid? UniqueID
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.UniqueID))
					return this.Entity.UniqueID;
				else
					return null;
			}
			set { this.Entity.UniqueID = value; }
		}

		[DataMember(Name="Notes", Order=10, EmitDefaultValue=false)]
		public System.String Notes
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.Notes))
					return this.Entity.Notes;
				else
					return null;
			}
			set { this.Entity.Notes = value; }
		}

		[DataMember(Name="CreditLimit", Order=11, EmitDefaultValue=false)]
		public System.Decimal? CreditLimit
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.CreditLimit))
					return this.Entity.CreditLimit;
				else
					return null;
			}
			set { this.Entity.CreditLimit = value; }
		}

		[DataMember(Name="Discount", Order=12, EmitDefaultValue=false)]
		public System.Decimal? Discount
		{
			get 
			{ 
				
				if (this.IncludeColumn(CustomerMetadata.ColumnNames.Discount))
					return this.Entity.Discount;
				else
					return null;
			}
			set { this.Entity.Discount = value; }
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
		public Customer Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Customer();
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
		public Customer entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerCollection")]
	[XmlType(TypeName="CustomerCollectionProxyStub")]	
	[Serializable]
	public partial class CustomerCollectionProxyStub 
	{
		protected CustomerCollectionProxyStub() {}
		
		public CustomerCollectionProxyStub(esEntityCollection<Customer> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public CustomerCollectionProxyStub(esEntityCollection<Customer> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator CustomerCollection(CustomerCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Customer);
		}
		
		public CustomerCollectionProxyStub(esEntityCollection<Customer> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Customer entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new CustomerProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new CustomerProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Customer entity in coll.es.DeletedEntities)
				{
					Collection.Add(new CustomerProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<CustomerProxyStub> Collection = new List<CustomerProxyStub>();

		public CustomerCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new CustomerCollection();

				foreach (CustomerProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private CustomerCollection _coll;
	}



	[Serializable]
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
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Active, 4, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = CustomerMetadata.PropertyNames.Active;
			c.HasDefault = true;
			c.Default = @"((1))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.ConcurrencyCheck, 5, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = CustomerMetadata.PropertyNames.ConcurrencyCheck;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
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
			c.HasDefault = true;
			c.Default = @"(newid())";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Notes, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 2147483647;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.CreditLimit, 10, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = CustomerMetadata.PropertyNames.CreditLimit;
			c.NumericPrecision = 19;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerMetadata.ColumnNames.Discount, 11, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = CustomerMetadata.PropertyNames.Discount;
			c.NumericPrecision = 18;
			c.NumericScale = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
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
			get { return true; }
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


				meta.AddTypeMap("CustomerID", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("CustomerSub", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("CustomerName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Active", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("varbinary", "System.Byte[]"));
				meta.AddTypeMap("Manager", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("StaffAssigned", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UniqueID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Notes", new esTypeMap("text", "System.String"));
				meta.AddTypeMap("CreditLimit", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("decimal", "System.Decimal"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Customer";
				meta.Destination = "Customer";
				
				meta.spInsert = "proc_CustomerInsert";				
				meta.spUpdate = "proc_CustomerUpdate";		
				meta.spDelete = "proc_CustomerDelete";
				meta.spLoadAll = "proc_CustomerLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerLoadByPrimaryKey";
				
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
