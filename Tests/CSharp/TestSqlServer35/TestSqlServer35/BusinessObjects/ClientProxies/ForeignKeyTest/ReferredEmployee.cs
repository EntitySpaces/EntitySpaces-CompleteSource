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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ReferredEmployeeCollection")]	
	[XmlType(TypeName = "ReferredEmployeeCollectionProxyStub")]	
	[Serializable]	
	public partial class ReferredEmployeeCollectionProxyStub 
	{
		public ReferredEmployeeCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ReferredEmployeeProxyStub> Collection = new BindingList<ReferredEmployeeProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ReferredEmployeeProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "ReferredEmployee")]
	[XmlType(TypeName = "ReferredEmployeeProxyStub")]	
	[Serializable]	
	public partial class ReferredEmployeeProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ReferredEmployeeProxyStub()
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
		
		[DataMember(Name="EmployeeID", Order=1, EmitDefaultValue=false)]
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
		
		[DataMember(Name="ReferredID", Order=2, EmitDefaultValue=false)]
		public System.Int32? ReferredID
		{
			get
			{
				return _ReferredID;
			}
			set
			{
				if (_ReferredID != value)
				{
					_ReferredID = value;
					SetDirty("ReferredID");
					RaisePropertyChanged("ReferredID");
				}
			}
		}
		private System.Int32? _ReferredID;
		
	
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
	
	[XmlType(TypeName = "ReferredEmployeeQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ReferredEmployeeQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ReferredEmployeeQueryProxyStub : esDynamicQuerySerializable
	{
		public ReferredEmployeeQueryProxyStub() { }
		
		public ReferredEmployeeQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ReferredEmployeeQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ReferredEmployeeQueryProxyStub query)
		{
			return Proxies.ReferredEmployeeQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, "EmployeeID", esSystemType.Int32); }
		} 
		
		public esQueryItem ReferredID
		{
			get { return new esQueryItem(this, "ReferredID", esSystemType.Int32); }
		} 
		
	}
}