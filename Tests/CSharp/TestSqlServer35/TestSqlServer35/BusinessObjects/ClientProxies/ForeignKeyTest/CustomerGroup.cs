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
	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerGroupCollection")]	
	[XmlType(TypeName = "CustomerGroupCollectionProxyStub")]	
	[Serializable]	
	public partial class CustomerGroupCollectionProxyStub 
	{
		public CustomerGroupCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<CustomerGroupProxyStub> Collection = new BindingList<CustomerGroupProxyStub>();
		
		public bool IsDirty()
		{
			foreach (CustomerGroupProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "CustomerGroup")]
	[XmlType(TypeName = "CustomerGroupProxyStub")]	
	[Serializable]	
	public partial class CustomerGroupProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public CustomerGroupProxyStub()
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
		
		[DataMember(Name="GroupID", Order=1, EmitDefaultValue=false)]
		public System.String GroupID
		{
			get
			{
				return _GroupID;
			}
			set
			{
				if (_GroupID != value)
				{
					_GroupID = value;
					SetDirty("GroupID");
					RaisePropertyChanged("GroupID");
				}
			}
		}
		private System.String _GroupID;
		
		[DataMember(Name="GroupName", Order=2, EmitDefaultValue=false)]
		public System.String GroupName
		{
			get
			{
				return _GroupName;
			}
			set
			{
				if (_GroupName != value)
				{
					_GroupName = value;
					SetDirty("GroupName");
					RaisePropertyChanged("GroupName");
				}
			}
		}
		private System.String _GroupName;
		
	
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
	
	[XmlType(TypeName = "CustomerGroupQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "CustomerGroupQuery", Namespace = "http://www.entityspaces.net")]
	public partial class CustomerGroupQueryProxyStub : esDynamicQuerySerializable
	{
		public CustomerGroupQueryProxyStub() { }
		
		public CustomerGroupQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "CustomerGroupQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(CustomerGroupQueryProxyStub query)
		{
			return Proxies.CustomerGroupQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem GroupID
		{
			get { return new esQueryItem(this, "GroupID", esSystemType.String); }
		} 
		
		public esQueryItem GroupName
		{
			get { return new esQueryItem(this, "GroupName", esSystemType.String); }
		} 
		
	}
}