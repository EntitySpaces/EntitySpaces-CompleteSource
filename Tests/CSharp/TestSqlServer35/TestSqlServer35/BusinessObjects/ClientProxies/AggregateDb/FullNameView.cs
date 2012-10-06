/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:37 AM
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
	[DataContract(Namespace = "http://tempuri.org/", Name = "FullNameViewCollection")]	
	[XmlType(TypeName = "FullNameViewCollectionProxyStub")]	
	[Serializable]	
	public partial class FullNameViewCollectionProxyStub 
	{
		public FullNameViewCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<FullNameViewProxyStub> Collection = new BindingList<FullNameViewProxyStub>();
		
		public bool IsDirty()
		{
			foreach (FullNameViewProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "FullNameView")]
	[XmlType(TypeName = "FullNameViewProxyStub")]	
	[Serializable]	
	public partial class FullNameViewProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public FullNameViewProxyStub()
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
		
		[DataMember(Name="FullName", Order=1, EmitDefaultValue=false)]
		public System.String FullName
		{
			get
			{
				return _FullName;
			}
			set
			{
				if (_FullName != value)
				{
					_FullName = value;
					SetDirty("FullName");
					RaisePropertyChanged("FullName");
				}
			}
		}
		private System.String _FullName;
		
		[DataMember(Name="DepartmentID", Order=2, EmitDefaultValue=false)]
		public System.Int32? DepartmentID
		{
			get
			{
				return _DepartmentID;
			}
			set
			{
				if (_DepartmentID != value)
				{
					_DepartmentID = value;
					SetDirty("DepartmentID");
					RaisePropertyChanged("DepartmentID");
				}
			}
		}
		private System.Int32? _DepartmentID;
		
		[DataMember(Name="HireDate", Order=3, EmitDefaultValue=false)]
		public System.DateTime? HireDate
		{
			get
			{
				return _HireDate;
			}
			set
			{
				if (_HireDate != value)
				{
					_HireDate = value;
					SetDirty("HireDate");
					RaisePropertyChanged("HireDate");
				}
			}
		}
		private System.DateTime? _HireDate;
		
		[DataMember(Name="Salary", Order=4, EmitDefaultValue=false)]
		public System.Decimal? Salary
		{
			get
			{
				return _Salary;
			}
			set
			{
				if (_Salary != value)
				{
					_Salary = value;
					SetDirty("Salary");
					RaisePropertyChanged("Salary");
				}
			}
		}
		private System.Decimal? _Salary;
		
		[DataMember(Name="IsActive", Order=5, EmitDefaultValue=false)]
		public System.Boolean? IsActive
		{
			get
			{
				return _IsActive;
			}
			set
			{
				if (_IsActive != value)
				{
					_IsActive = value;
					SetDirty("IsActive");
					RaisePropertyChanged("IsActive");
				}
			}
		}
		private System.Boolean? _IsActive;
		
	
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
	
	[XmlType(TypeName = "FullNameViewQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "FullNameViewQuery", Namespace = "http://www.entityspaces.net")]
	public partial class FullNameViewQueryProxyStub : esDynamicQuerySerializable
	{
		public FullNameViewQueryProxyStub() { }
		
		public FullNameViewQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "FullNameViewQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(FullNameViewQueryProxyStub query)
		{
			return Proxies.FullNameViewQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem FullName
		{
			get { return new esQueryItem(this, "FullName", esSystemType.String); }
		} 
		
		public esQueryItem DepartmentID
		{
			get { return new esQueryItem(this, "DepartmentID", esSystemType.Int32); }
		} 
		
		public esQueryItem HireDate
		{
			get { return new esQueryItem(this, "HireDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem Salary
		{
			get { return new esQueryItem(this, "Salary", esSystemType.Decimal); }
		} 
		
		public esQueryItem IsActive
		{
			get { return new esQueryItem(this, "IsActive", esSystemType.Boolean); }
		} 
		
	}
}