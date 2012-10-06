/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:40 AM
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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ShippersCollection")]	
	[XmlType(TypeName = "ShippersCollectionProxyStub")]	
	[Serializable]	
	public partial class ShippersCollectionProxyStub 
	{
		public ShippersCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ShippersProxyStub> Collection = new BindingList<ShippersProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ShippersProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Shippers")]
	[XmlType(TypeName = "ShippersProxyStub")]	
	[Serializable]	
	public partial class ShippersProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ShippersProxyStub()
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
		public System.Int32? ShipperID
		{
			get
			{
				return _ShipperID;
			}
			set
			{
				if (_ShipperID != value)
				{
					_ShipperID = value;
					SetDirty("ShipperID");
					RaisePropertyChanged("ShipperID");
				}
			}
		}
		private System.Int32? _ShipperID;
		
		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String CompanyName
		{
			get
			{
				return _CompanyName;
			}
			set
			{
				if (_CompanyName != value)
				{
					_CompanyName = value;
					SetDirty("CompanyName");
					RaisePropertyChanged("CompanyName");
				}
			}
		}
		private System.String _CompanyName;
		
		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
		public System.String Phone
		{
			get
			{
				return _Phone;
			}
			set
			{
				if (_Phone != value)
				{
					_Phone = value;
					SetDirty("Phone");
					RaisePropertyChanged("Phone");
				}
			}
		}
		private System.String _Phone;
		
	
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
	
	[XmlType(TypeName = "ShippersQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ShippersQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ShippersQueryProxyStub : esDynamicQuerySerializable
	{
		public ShippersQueryProxyStub() { }
		
		public ShippersQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ShippersQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ShippersQueryProxyStub query)
		{
			return Proxies.ShippersQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem ShipperID
		{
			get { return new esQueryItem(this, "ShipperID", esSystemType.Int32); }
		} 
		
		public esQueryItem CompanyName
		{
			get { return new esQueryItem(this, "CompanyName", esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, "Phone", esSystemType.String); }
		} 
		
	}
}