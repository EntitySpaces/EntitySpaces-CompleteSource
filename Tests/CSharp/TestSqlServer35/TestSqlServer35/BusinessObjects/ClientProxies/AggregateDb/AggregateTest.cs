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
	[DataContract(Namespace = "http://tempuri.org/", Name = "AggregateTestCollection")]	
	[XmlType(TypeName = "AggregateTestCollectionProxyStub")]	
	[Serializable]	
	public partial class AggregateTestCollectionProxyStub 
	{
		public AggregateTestCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<AggregateTestProxyStub> Collection = new BindingList<AggregateTestProxyStub>();
		
		public bool IsDirty()
		{
			foreach (AggregateTestProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "AggregateTest")]
	[XmlType(TypeName = "AggregateTestProxyStub")]	
	[Serializable]	
	public partial class AggregateTestProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public AggregateTestProxyStub()
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
		
		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.Int32? Id
		{
			get
			{
				return _Id;
			}
			set
			{
				if (_Id != value)
				{
					_Id = value;
					SetDirty("ID");
					RaisePropertyChanged("Id");
				}
			}
		}
		private System.Int32? _Id;
		
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
		
		[DataMember(Name="LastName", Order=4, EmitDefaultValue=false)]
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
		
		[DataMember(Name="HireDate", Order=6, EmitDefaultValue=false)]
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
		
		[DataMember(Name="Salary", Order=7, EmitDefaultValue=false)]
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
		
		[DataMember(Name="IsActive", Order=8, EmitDefaultValue=false)]
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
	
	[XmlType(TypeName = "AggregateTestQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "AggregateTestQuery", Namespace = "http://www.entityspaces.net")]
	public partial class AggregateTestQueryProxyStub : esDynamicQuerySerializable
	{
		public AggregateTestQueryProxyStub() { }
		
		public AggregateTestQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "AggregateTestQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(AggregateTestQueryProxyStub query)
		{
			return Proxies.AggregateTestQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem Id
		{
			get { return new esQueryItem(this, "ID", esSystemType.Int32); }
		} 
		
		public esQueryItem DepartmentID
		{
			get { return new esQueryItem(this, "DepartmentID", esSystemType.Int32); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, "FirstName", esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, "LastName", esSystemType.String); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, "Age", esSystemType.Int32); }
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