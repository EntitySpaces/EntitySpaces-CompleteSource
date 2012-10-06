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
	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeTerritoryCollection")]	
	[XmlType(TypeName = "EmployeeTerritoryCollectionProxyStub")]	
	[Serializable]	
	public partial class EmployeeTerritoryCollectionProxyStub 
	{
		public EmployeeTerritoryCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<EmployeeTerritoryProxyStub> Collection = new BindingList<EmployeeTerritoryProxyStub>();
		
		public bool IsDirty()
		{
			foreach (EmployeeTerritoryProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeTerritory")]
	[XmlType(TypeName = "EmployeeTerritoryProxyStub")]	
	[Serializable]	
	public partial class EmployeeTerritoryProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public EmployeeTerritoryProxyStub()
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
		
		[DataMember(Name="EmpID", Order=1, EmitDefaultValue=false)]
		public System.Int32? EmpID
		{
			get
			{
				return _EmpID;
			}
			set
			{
				if (_EmpID != value)
				{
					_EmpID = value;
					SetDirty("EmpID");
					RaisePropertyChanged("EmpID");
				}
			}
		}
		private System.Int32? _EmpID;
		
		[DataMember(Name="TerrID", Order=2, EmitDefaultValue=false)]
		public System.Int32? TerrID
		{
			get
			{
				return _TerrID;
			}
			set
			{
				if (_TerrID != value)
				{
					_TerrID = value;
					SetDirty("TerrID");
					RaisePropertyChanged("TerrID");
				}
			}
		}
		private System.Int32? _TerrID;
		
	
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
	
	[XmlType(TypeName = "EmployeeTerritoryQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "EmployeeTerritoryQuery", Namespace = "http://www.entityspaces.net")]
	public partial class EmployeeTerritoryQueryProxyStub : esDynamicQuerySerializable
	{
		public EmployeeTerritoryQueryProxyStub() { }
		
		public EmployeeTerritoryQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "EmployeeTerritoryQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(EmployeeTerritoryQueryProxyStub query)
		{
			return Proxies.EmployeeTerritoryQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem EmpID
		{
			get { return new esQueryItem(this, "EmpID", esSystemType.Int32); }
		} 
		
		public esQueryItem TerrID
		{
			get { return new esQueryItem(this, "TerrID", esSystemType.Int32); }
		} 
		
	}
}