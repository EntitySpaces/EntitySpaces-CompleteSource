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
	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeCollection")]	
	[XmlType(TypeName = "EmployeeCollectionProxyStub")]	
	[Serializable]	
	public partial class EmployeeCollectionProxyStub 
	{
		public EmployeeCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<EmployeeProxyStub> Collection = new BindingList<EmployeeProxyStub>();
		
		public bool IsDirty()
		{
			foreach (EmployeeProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Employee")]
	[XmlType(TypeName = "EmployeeProxyStub")]	
	[Serializable]	
	public partial class EmployeeProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public EmployeeProxyStub()
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
		
		[DataMember(Name="LastName", Order=2, EmitDefaultValue=false)]
		public System.String LastName
		{
			get
			{
				return _LastName;
			}
			set
			{
				if (_LastName != value)
				{
					_LastName = value;
					SetDirty("LastName");
					RaisePropertyChanged("LastName");
				}
			}
		}
		private System.String _LastName;
		
		[DataMember(Name="FirstName", Order=3, EmitDefaultValue=false)]
		public System.String FirstName
		{
			get
			{
				return _FirstName;
			}
			set
			{
				if (_FirstName != value)
				{
					_FirstName = value;
					SetDirty("FirstName");
					RaisePropertyChanged("FirstName");
				}
			}
		}
		private System.String _FirstName;
		
		[DataMember(Name="Supervisor", Order=4, EmitDefaultValue=false)]
		public System.Int32? Supervisor
		{
			get
			{
				return _Supervisor;
			}
			set
			{
				if (_Supervisor != value)
				{
					_Supervisor = value;
					SetDirty("Supervisor");
					RaisePropertyChanged("Supervisor");
				}
			}
		}
		private System.Int32? _Supervisor;
		
		[DataMember(Name="Age", Order=5, EmitDefaultValue=false)]
		public System.Int32? Age
		{
			get
			{
				return _Age;
			}
			set
			{
				if (_Age != value)
				{
					_Age = value;
					SetDirty("Age");
					RaisePropertyChanged("Age");
				}
			}
		}
		private System.Int32? _Age;
		
	
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
	
	[XmlType(TypeName = "EmployeeQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "EmployeeQuery", Namespace = "http://www.entityspaces.net")]
	public partial class EmployeeQueryProxyStub : esDynamicQuerySerializable
	{
		public EmployeeQueryProxyStub() { }
		
		public EmployeeQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "EmployeeQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(EmployeeQueryProxyStub query)
		{
			return Proxies.EmployeeQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, "EmployeeID", esSystemType.Int32); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, "LastName", esSystemType.String); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, "FirstName", esSystemType.String); }
		} 
		
		public esQueryItem Supervisor
		{
			get { return new esQueryItem(this, "Supervisor", esSystemType.Int32); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, "Age", esSystemType.Int32); }
		} 
		
	}
}