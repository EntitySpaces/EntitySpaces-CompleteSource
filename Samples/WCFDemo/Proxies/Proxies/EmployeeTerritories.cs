/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:27 PM
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
	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeTerritoriesCollection")]	
	[XmlType(TypeName = "EmployeeTerritoriesCollectionProxyStub")]	
	[Serializable]	
	public partial class EmployeeTerritoriesCollectionProxyStub 
	{
		public EmployeeTerritoriesCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<EmployeeTerritoriesProxyStub> Collection = new BindingList<EmployeeTerritoriesProxyStub>();
		
		public bool IsDirty()
		{
			foreach (EmployeeTerritoriesProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeeTerritories")]
	[XmlType(TypeName = "EmployeeTerritoriesProxyStub")]	
	[Serializable]	
	public partial class EmployeeTerritoriesProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public EmployeeTerritoriesProxyStub()
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
		
		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String TerritoryID
		{
			get
			{
				return _TerritoryID;
			}
			set
			{
				if (_TerritoryID != value)
				{
					_TerritoryID = value;
					SetDirty("TerritoryID");
					RaisePropertyChanged("TerritoryID");
				}
			}
		}
		private System.String _TerritoryID;
		
	
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
	
	[XmlType(TypeName = "EmployeeTerritoriesQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "EmployeeTerritoriesQuery", Namespace = "http://www.entityspaces.net")]
	public partial class EmployeeTerritoriesQueryProxyStub : esDynamicQuerySerializable
	{
		public EmployeeTerritoriesQueryProxyStub() { }
		
		public EmployeeTerritoriesQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "EmployeeTerritoriesQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(EmployeeTerritoriesQueryProxyStub query)
		{
			return Proxies.EmployeeTerritoriesQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, "EmployeeID", esSystemType.Int32); }
		} 
		
		public esQueryItem TerritoryID
		{
			get { return new esQueryItem(this, "TerritoryID", esSystemType.String); }
		} 
		
	}
}