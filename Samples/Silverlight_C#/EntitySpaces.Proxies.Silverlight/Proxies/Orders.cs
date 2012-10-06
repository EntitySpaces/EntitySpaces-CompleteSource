/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:13 PM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.DynamicQuery;

namespace Proxies
{
	[DataContract(Namespace = "http://tempuri.org/", Name = "OrdersCollection")]	
	[XmlType(TypeName = "OrdersCollectionProxyStub")]	
	public partial class OrdersCollectionProxyStub 
	{
		public OrdersCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public ObservableCollection<OrdersProxyStub> Collection = new ObservableCollection<OrdersProxyStub>();
		
		public bool IsDirty()
		{
			foreach (OrdersProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Orders")]
	[XmlType(TypeName = "OrdersProxyStub")]	
	public partial class OrdersProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public OrdersProxyStub()
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
		
		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a4", Order=5, EmitDefaultValue=false)]
		public System.DateTime? RequiredDate
		{
			get
			{
				return _RequiredDate;
			}
			set
			{
				if (_RequiredDate != value)
				{
					_RequiredDate = value;
					SetDirty("RequiredDate");
					RaisePropertyChanged("RequiredDate");
				}
			}
		}
		private System.DateTime? _RequiredDate;
		
		[DataMember(Name="a5", Order=6, EmitDefaultValue=false)]
		public System.DateTime? ShippedDate
		{
			get
			{
				return _ShippedDate;
			}
			set
			{
				if (_ShippedDate != value)
				{
					_ShippedDate = value;
					SetDirty("ShippedDate");
					RaisePropertyChanged("ShippedDate");
				}
			}
		}
		private System.DateTime? _ShippedDate;
		
		[DataMember(Name="a6", Order=7, EmitDefaultValue=false)]
		public System.Int32? ShipVia
		{
			get
			{
				return _ShipVia;
			}
			set
			{
				if (_ShipVia != value)
				{
					_ShipVia = value;
					SetDirty("ShipVia");
					RaisePropertyChanged("ShipVia");
				}
			}
		}
		private System.Int32? _ShipVia;
		
		[DataMember(Name="a7", Order=8, EmitDefaultValue=false)]
		public System.Decimal? Freight
		{
			get
			{
				return _Freight;
			}
			set
			{
				if (_Freight != value)
				{
					_Freight = value;
					SetDirty("Freight");
					RaisePropertyChanged("Freight");
				}
			}
		}
		private System.Decimal? _Freight;
		
		[DataMember(Name="a8", Order=9, EmitDefaultValue=false)]
		public System.String ShipName
		{
			get
			{
				return _ShipName;
			}
			set
			{
				if (_ShipName != value)
				{
					_ShipName = value;
					SetDirty("ShipName");
					RaisePropertyChanged("ShipName");
				}
			}
		}
		private System.String _ShipName;
		
		[DataMember(Name="a9", Order=10, EmitDefaultValue=false)]
		public System.String ShipAddress
		{
			get
			{
				return _ShipAddress;
			}
			set
			{
				if (_ShipAddress != value)
				{
					_ShipAddress = value;
					SetDirty("ShipAddress");
					RaisePropertyChanged("ShipAddress");
				}
			}
		}
		private System.String _ShipAddress;
		
		[DataMember(Name="a10", Order=11, EmitDefaultValue=false)]
		public System.String ShipCity
		{
			get
			{
				return _ShipCity;
			}
			set
			{
				if (_ShipCity != value)
				{
					_ShipCity = value;
					SetDirty("ShipCity");
					RaisePropertyChanged("ShipCity");
				}
			}
		}
		private System.String _ShipCity;
		
		[DataMember(Name="a11", Order=12, EmitDefaultValue=false)]
		public System.String ShipRegion
		{
			get
			{
				return _ShipRegion;
			}
			set
			{
				if (_ShipRegion != value)
				{
					_ShipRegion = value;
					SetDirty("ShipRegion");
					RaisePropertyChanged("ShipRegion");
				}
			}
		}
		private System.String _ShipRegion;
		
		[DataMember(Name="a12", Order=13, EmitDefaultValue=false)]
		public System.String ShipPostalCode
		{
			get
			{
				return _ShipPostalCode;
			}
			set
			{
				if (_ShipPostalCode != value)
				{
					_ShipPostalCode = value;
					SetDirty("ShipPostalCode");
					RaisePropertyChanged("ShipPostalCode");
				}
			}
		}
		private System.String _ShipPostalCode;
		
		[DataMember(Name="a13", Order=14, EmitDefaultValue=false)]
		public System.String ShipCountry
		{
			get
			{
				return _ShipCountry;
			}
			set
			{
				if (_ShipCountry != value)
				{
					_ShipCountry = value;
					SetDirty("ShipCountry");
					RaisePropertyChanged("ShipCountry");
				}
			}
		}
		private System.String _ShipCountry;
		
	
		[DataMember(Name="a10000", Order=10000)]
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
		
		[DataMember(Name="a10001", Order=10001, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a10002", Order=10002, EmitDefaultValue=false)]		
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
	
	[XmlType(TypeName = "OrdersQueryProxyStub")]	
	[DataContract(Name = "OrdersQuery", Namespace = "http://www.entityspaces.net")]
	public partial class OrdersQueryProxyStub : esDynamicQuerySerializable
	{
		public OrdersQueryProxyStub() { }
		
		public OrdersQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "OrdersQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(OrdersQueryProxyStub query)
		{
			return Proxies.OrdersQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem OrderID
		{
			get { return new esQueryItem(this, "OrderID", esSystemType.Int32); }
		} 
		
		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, "CustomerID", esSystemType.String); }
		} 
		
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, "EmployeeID", esSystemType.Int32); }
		} 
		
		public esQueryItem OrderDate
		{
			get { return new esQueryItem(this, "OrderDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem RequiredDate
		{
			get { return new esQueryItem(this, "RequiredDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem ShippedDate
		{
			get { return new esQueryItem(this, "ShippedDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem ShipVia
		{
			get { return new esQueryItem(this, "ShipVia", esSystemType.Int32); }
		} 
		
		public esQueryItem Freight
		{
			get { return new esQueryItem(this, "Freight", esSystemType.Decimal); }
		} 
		
		public esQueryItem ShipName
		{
			get { return new esQueryItem(this, "ShipName", esSystemType.String); }
		} 
		
		public esQueryItem ShipAddress
		{
			get { return new esQueryItem(this, "ShipAddress", esSystemType.String); }
		} 
		
		public esQueryItem ShipCity
		{
			get { return new esQueryItem(this, "ShipCity", esSystemType.String); }
		} 
		
		public esQueryItem ShipRegion
		{
			get { return new esQueryItem(this, "ShipRegion", esSystemType.String); }
		} 
		
		public esQueryItem ShipPostalCode
		{
			get { return new esQueryItem(this, "ShipPostalCode", esSystemType.String); }
		} 
		
		public esQueryItem ShipCountry
		{
			get { return new esQueryItem(this, "ShipCountry", esSystemType.String); }
		} 
		
	}
}