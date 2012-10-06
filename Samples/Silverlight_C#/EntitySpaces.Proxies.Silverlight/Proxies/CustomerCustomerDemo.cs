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
	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerCustomerDemoCollection")]	
	[XmlType(TypeName = "CustomerCustomerDemoCollectionProxyStub")]	
	public partial class CustomerCustomerDemoCollectionProxyStub 
	{
		public CustomerCustomerDemoCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public ObservableCollection<CustomerCustomerDemoProxyStub> Collection = new ObservableCollection<CustomerCustomerDemoProxyStub>();
		
		public bool IsDirty()
		{
			foreach (CustomerCustomerDemoProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerCustomerDemo")]
	[XmlType(TypeName = "CustomerCustomerDemoProxyStub")]	
	public partial class CustomerCustomerDemoProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public CustomerCustomerDemoProxyStub()
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
		
		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String CustomerTypeID
		{
			get
			{
				return _CustomerTypeID;
			}
			set
			{
				if (_CustomerTypeID != value)
				{
					_CustomerTypeID = value;
					SetDirty("CustomerTypeID");
					RaisePropertyChanged("CustomerTypeID");
				}
			}
		}
		private System.String _CustomerTypeID;
		
	
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
	
	[XmlType(TypeName = "CustomerCustomerDemoQueryProxyStub")]	
	[DataContract(Name = "CustomerCustomerDemoQuery", Namespace = "http://www.entityspaces.net")]
	public partial class CustomerCustomerDemoQueryProxyStub : esDynamicQuerySerializable
	{
		public CustomerCustomerDemoQueryProxyStub() { }
		
		public CustomerCustomerDemoQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "CustomerCustomerDemoQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(CustomerCustomerDemoQueryProxyStub query)
		{
			return Proxies.CustomerCustomerDemoQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, "CustomerID", esSystemType.String); }
		} 
		
		public esQueryItem CustomerTypeID
		{
			get { return new esQueryItem(this, "CustomerTypeID", esSystemType.String); }
		} 
		
	}
}