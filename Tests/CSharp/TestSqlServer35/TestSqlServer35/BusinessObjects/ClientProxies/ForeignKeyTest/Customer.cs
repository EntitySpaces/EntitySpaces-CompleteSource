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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.DynamicQuery;

namespace Proxies
{
	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerCollection")]	
	[XmlType(TypeName = "CustomerCollectionProxyStub")]	
	[Serializable]	
	public partial class CustomerCollectionProxyStub 
	{
		public CustomerCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<CustomerProxyStub> Collection = new BindingList<CustomerProxyStub>();
		
		public bool IsDirty()
		{
			foreach (CustomerProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Customer")]
	[XmlType(TypeName = "CustomerProxyStub")]	
	[Serializable]	
	public partial class CustomerProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public CustomerProxyStub()
		{
			this.esRowState = "Added";
		}
		
		public bool IsDirty()
		{
			return esRowState != "Unchanged" ? true : false;
		}
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		protected void RaisePropertyChanged(string propertyName) 
		{
			System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if ((propertyChanged != null)) 
			{
				propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		[DataMember(Name="CustomerID", Order=1, EmitDefaultValue=false)]
		public System.String CustomerID
		{
			get
			{
				return _CustomerID;
			}
			set
			{
				if (_CustomerID != value)
				{
					_CustomerID = value;
					SetDirty("CustomerID");
					RaisePropertyChanged("CustomerID");
				}
			}
		}
		private System.String _CustomerID;
		
		[DataMember(Name="CustomerSub", Order=2, EmitDefaultValue=false)]
		public System.String CustomerSub
		{
			get
			{
				return _CustomerSub;
			}
			set
			{
				if (_CustomerSub != value)
				{
					_CustomerSub = value;
					SetDirty("CustomerSub");
					RaisePropertyChanged("CustomerSub");
				}
			}
		}
		private System.String _CustomerSub;
		
		[DataMember(Name="CustomerName", Order=3, EmitDefaultValue=false)]
		public System.String CustomerName
		{
			get
			{
				return _CustomerName;
			}
			set
			{
				if (_CustomerName != value)
				{
					_CustomerName = value;
					SetDirty("CustomerName");
					RaisePropertyChanged("CustomerName");
				}
			}
		}
		private System.String _CustomerName;
		
		[DataMember(Name="DateAdded", Order=4, EmitDefaultValue=false)]
		public System.DateTime? DateAdded
		{
			get
			{
				return _DateAdded;
			}
			set
			{
				if (_DateAdded != value)
				{
					_DateAdded = value;
					SetDirty("DateAdded");
					RaisePropertyChanged("DateAdded");
				}
			}
		}
		private System.DateTime? _DateAdded;
		
		[DataMember(Name="Active", Order=5, EmitDefaultValue=false)]
		public System.Boolean? Active
		{
			get
			{
				return _Active;
			}
			set
			{
				if (_Active != value)
				{
					_Active = value;
					SetDirty("Active");
					RaisePropertyChanged("Active");
				}
			}
		}
		private System.Boolean? _Active;
		
		[DataMember(Name="ConcurrencyCheck", Order=6, EmitDefaultValue=false)]
		public System.Byte[] ConcurrencyCheck
		{
			get
			{
				return _ConcurrencyCheck;
			}
			set
			{
				if (_ConcurrencyCheck != value)
				{
					_ConcurrencyCheck = value;
					SetDirty("ConcurrencyCheck");
					RaisePropertyChanged("ConcurrencyCheck");
				}
			}
		}
		private System.Byte[] _ConcurrencyCheck;
		
		[DataMember(Name="Manager", Order=7, EmitDefaultValue=false)]
		public System.Int32? Manager
		{
			get
			{
				return _Manager;
			}
			set
			{
				if (_Manager != value)
				{
					_Manager = value;
					SetDirty("Manager");
					RaisePropertyChanged("Manager");
				}
			}
		}
		private System.Int32? _Manager;
		
		[DataMember(Name="StaffAssigned", Order=8, EmitDefaultValue=false)]
		public System.Int32? StaffAssigned
		{
			get
			{
				return _StaffAssigned;
			}
			set
			{
				if (_StaffAssigned != value)
				{
					_StaffAssigned = value;
					SetDirty("StaffAssigned");
					RaisePropertyChanged("StaffAssigned");
				}
			}
		}
		private System.Int32? _StaffAssigned;
		
		[DataMember(Name="UniqueID", Order=9, EmitDefaultValue=false)]
		public System.Guid? UniqueID
		{
			get
			{
				return _UniqueID;
			}
			set
			{
				if (_UniqueID != value)
				{
					_UniqueID = value;
					SetDirty("UniqueID");
					RaisePropertyChanged("UniqueID");
				}
			}
		}
		private System.Guid? _UniqueID;
		
		[DataMember(Name="Notes", Order=10, EmitDefaultValue=false)]
		public System.String Notes
		{
			get
			{
				return _Notes;
			}
			set
			{
				if (_Notes != value)
				{
					_Notes = value;
					SetDirty("Notes");
					RaisePropertyChanged("Notes");
				}
			}
		}
		private System.String _Notes;
		
		[DataMember(Name="CreditLimit", Order=11, EmitDefaultValue=false)]
		public System.Decimal? CreditLimit
		{
			get
			{
				return _CreditLimit;
			}
			set
			{
				if (_CreditLimit != value)
				{
					_CreditLimit = value;
					SetDirty("CreditLimit");
					RaisePropertyChanged("CreditLimit");
				}
			}
		}
		private System.Decimal? _CreditLimit;
		
		[DataMember(Name="Discount", Order=12, EmitDefaultValue=false)]
		public System.Decimal? Discount
		{
			get
			{
				return _Discount;
			}
			set
			{
				if (_Discount != value)
				{
					_Discount = value;
					SetDirty("Discount");
					RaisePropertyChanged("Discount");
				}
			}
		}
		private System.Decimal? _Discount;
		
	
		[DataMember(Name="esRowState", Order=10000)]
		public string esRowState
		{
			get { return _esRowState; }
			set 
			{
				if(_esRowState != value)
				{
					_esRowState = value; 
					RaisePropertyChanged("esRowState");
				}
			}
		}
		private string _esRowState = "Unchanged";
		
		[DataMember(Name="ModifiedColumns", Order=10001, EmitDefaultValue=false)]
		public List<string> ModifiedColumns
		{
			get
			{
				if (_ModifiedColumns == null)
				{
					_ModifiedColumns = new List<string>();
				}
				return _ModifiedColumns;
			}
			set
			{
				_ModifiedColumns = new List<string>(value);
			}
		}
		List<string> _ModifiedColumns;
		
		[DataMember(Name="ExtraColumns", Order=10002, EmitDefaultValue=false)]		
		public Dictionary<string, object> esExtraColumns
		{
			get
			{
				if (_ExtraColumns == null)
				{
					_ExtraColumns = new Dictionary<string, object>();
				}
				return _ExtraColumns;
			}
			set
			{
				_ExtraColumns = new Dictionary<string, object>(value);
			}
		}
		Dictionary<string, object> _ExtraColumns;

		public void MarkAsDeleted()
		{
			this.esRowState = "Deleted";
		}

		private void SetDirty(string property)
		{
			if (!ModifiedColumns.Contains(property))
			{
				ModifiedColumns.Add(property);
			}

			if (this.esRowState == "Unchanged")
			{
				this.esRowState = "Modified";
			}
		}
	}
	
	[XmlType(TypeName = "CustomerQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "CustomerQuery", Namespace = "http://www.entityspaces.net")]
	public partial class CustomerQueryProxyStub : esDynamicQuerySerializable
	{
		public CustomerQueryProxyStub() { }
		
		public CustomerQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "CustomerQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(CustomerQueryProxyStub query)
		{
			return Proxies.CustomerQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, "CustomerID", esSystemType.String); }
		} 
		
		public esQueryItem CustomerSub
		{
			get { return new esQueryItem(this, "CustomerSub", esSystemType.String); }
		} 
		
		public esQueryItem CustomerName
		{
			get { return new esQueryItem(this, "CustomerName", esSystemType.String); }
		} 
		
		public esQueryItem DateAdded
		{
			get { return new esQueryItem(this, "DateAdded", esSystemType.DateTime); }
		} 
		
		public esQueryItem Active
		{
			get { return new esQueryItem(this, "Active", esSystemType.Boolean); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, "ConcurrencyCheck", esSystemType.ByteArray); }
		} 
		
		public esQueryItem Manager
		{
			get { return new esQueryItem(this, "Manager", esSystemType.Int32); }
		} 
		
		public esQueryItem StaffAssigned
		{
			get { return new esQueryItem(this, "StaffAssigned", esSystemType.Int32); }
		} 
		
		public esQueryItem UniqueID
		{
			get { return new esQueryItem(this, "UniqueID", esSystemType.Guid); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, "Notes", esSystemType.String); }
		} 
		
		public esQueryItem CreditLimit
		{
			get { return new esQueryItem(this, "CreditLimit", esSystemType.Decimal); }
		} 
		
		public esQueryItem Discount
		{
			get { return new esQueryItem(this, "Discount", esSystemType.Decimal); }
		} 
		
	}
}