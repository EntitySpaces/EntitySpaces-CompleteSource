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
	[DataContract(Namespace = "http://tempuri.org/", Name = "OrderCollection")]	
	[XmlType(TypeName = "OrderCollectionProxyStub")]	
	[Serializable]	
	public partial class OrderCollectionProxyStub 
	{
		public OrderCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<OrderProxyStub> Collection = new BindingList<OrderProxyStub>();
		
		public bool IsDirty()
		{
			foreach (OrderProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Order")]
	[XmlType(TypeName = "OrderProxyStub")]	
	[Serializable]	
	public partial class OrderProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public OrderProxyStub()
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
		
		[DataMember(Name="OrderID", Order=1, EmitDefaultValue=false)]
		public System.Int32? OrderID
		{
			get
			{
				return _OrderID;
			}
			set
			{
				if (_OrderID != value)
				{
					_OrderID = value;
					SetDirty("OrderID");
					RaisePropertyChanged("OrderID");
				}
			}
		}
		private System.Int32? _OrderID;
		
		[DataMember(Name="CustID", Order=2, EmitDefaultValue=false)]
		public System.String CustID
		{
			get
			{
				return _CustID;
			}
			set
			{
				if (_CustID != value)
				{
					_CustID = value;
					SetDirty("CustID");
					RaisePropertyChanged("CustID");
				}
			}
		}
		private System.String _CustID;
		
		[DataMember(Name="CustSub", Order=3, EmitDefaultValue=false)]
		public System.String CustSub
		{
			get
			{
				return _CustSub;
			}
			set
			{
				if (_CustSub != value)
				{
					_CustSub = value;
					SetDirty("CustSub");
					RaisePropertyChanged("CustSub");
				}
			}
		}
		private System.String _CustSub;
		
		[DataMember(Name="PlacedBy", Order=4, EmitDefaultValue=false)]
		public System.String PlacedBy
		{
			get
			{
				return _PlacedBy;
			}
			set
			{
				if (_PlacedBy != value)
				{
					_PlacedBy = value;
					SetDirty("PlacedBy");
					RaisePropertyChanged("PlacedBy");
				}
			}
		}
		private System.String _PlacedBy;
		
		[DataMember(Name="OrderDate", Order=5, EmitDefaultValue=false)]
		public System.DateTime? OrderDate
		{
			get
			{
				return _OrderDate;
			}
			set
			{
				if (_OrderDate != value)
				{
					_OrderDate = value;
					SetDirty("OrderDate");
					RaisePropertyChanged("OrderDate");
				}
			}
		}
		private System.DateTime? _OrderDate;
		
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
		
		[DataMember(Name="EmployeeID", Order=7, EmitDefaultValue=false)]
		public System.Int32? EmployeeID
		{
			get
			{
				return _EmployeeID;
			}
			set
			{
				if (_EmployeeID != value)
				{
					_EmployeeID = value;
					SetDirty("EmployeeID");
					RaisePropertyChanged("EmployeeID");
				}
			}
		}
		private System.Int32? _EmployeeID;
		
	
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
	
	[XmlType(TypeName = "OrderQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "OrderQuery", Namespace = "http://www.entityspaces.net")]
	public partial class OrderQueryProxyStub : esDynamicQuerySerializable
	{
		public OrderQueryProxyStub() { }
		
		public OrderQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "OrderQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(OrderQueryProxyStub query)
		{
			return Proxies.OrderQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem OrderID
		{
			get { return new esQueryItem(this, "OrderID", esSystemType.Int32); }
		} 
		
		public esQueryItem CustID
		{
			get { return new esQueryItem(this, "CustID", esSystemType.String); }
		} 
		
		public esQueryItem CustSub
		{
			get { return new esQueryItem(this, "CustSub", esSystemType.String); }
		} 
		
		public esQueryItem PlacedBy
		{
			get { return new esQueryItem(this, "PlacedBy", esSystemType.String); }
		} 
		
		public esQueryItem OrderDate
		{
			get { return new esQueryItem(this, "OrderDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, "ConcurrencyCheck", esSystemType.ByteArray); }
		} 
		
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, "EmployeeID", esSystemType.Int32); }
		} 
		
	}
}