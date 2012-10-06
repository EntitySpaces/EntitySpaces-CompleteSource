/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:28 PM
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
	[DataContract(Namespace = "http://tempuri.org/", Name = "EmployeesCollection")]	
	[XmlType(TypeName = "EmployeesCollectionProxyStub")]	
	public partial class EmployeesCollectionProxyStub 
	{
		public EmployeesCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public ObservableCollection<EmployeesProxyStub> Collection = new ObservableCollection<EmployeesProxyStub>();
		
		public bool IsDirty()
		{
			foreach (EmployeesProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Employees")]
	[XmlType(TypeName = "EmployeesProxyStub")]	
	public partial class EmployeesProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public EmployeesProxyStub()
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
		
		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
		public System.String Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if (_Title != value)
				{
					_Title = value;
					SetDirty("Title");
					RaisePropertyChanged("Title");
				}
			}
		}
		private System.String _Title;
		
		[DataMember(Name="a4", Order=5, EmitDefaultValue=false)]
		public System.String TitleOfCourtesy
		{
			get
			{
				return _TitleOfCourtesy;
			}
			set
			{
				if (_TitleOfCourtesy != value)
				{
					_TitleOfCourtesy = value;
					SetDirty("TitleOfCourtesy");
					RaisePropertyChanged("TitleOfCourtesy");
				}
			}
		}
		private System.String _TitleOfCourtesy;
		
		[DataMember(Name="a5", Order=6, EmitDefaultValue=false)]
		public System.DateTime? BirthDate
		{
			get
			{
				return _BirthDate;
			}
			set
			{
				if (_BirthDate != value)
				{
					_BirthDate = value;
					SetDirty("BirthDate");
					RaisePropertyChanged("BirthDate");
				}
			}
		}
		private System.DateTime? _BirthDate;
		
		[DataMember(Name="a6", Order=7, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a7", Order=8, EmitDefaultValue=false)]
		public System.String Address
		{
			get
			{
				return _Address;
			}
			set
			{
				if (_Address != value)
				{
					_Address = value;
					SetDirty("Address");
					RaisePropertyChanged("Address");
				}
			}
		}
		private System.String _Address;
		
		[DataMember(Name="a8", Order=9, EmitDefaultValue=false)]
		public System.String City
		{
			get
			{
				return _City;
			}
			set
			{
				if (_City != value)
				{
					_City = value;
					SetDirty("City");
					RaisePropertyChanged("City");
				}
			}
		}
		private System.String _City;
		
		[DataMember(Name="a9", Order=10, EmitDefaultValue=false)]
		public System.String Region
		{
			get
			{
				return _Region;
			}
			set
			{
				if (_Region != value)
				{
					_Region = value;
					SetDirty("Region");
					RaisePropertyChanged("Region");
				}
			}
		}
		private System.String _Region;
		
		[DataMember(Name="a10", Order=11, EmitDefaultValue=false)]
		public System.String PostalCode
		{
			get
			{
				return _PostalCode;
			}
			set
			{
				if (_PostalCode != value)
				{
					_PostalCode = value;
					SetDirty("PostalCode");
					RaisePropertyChanged("PostalCode");
				}
			}
		}
		private System.String _PostalCode;
		
		[DataMember(Name="a11", Order=12, EmitDefaultValue=false)]
		public System.String Country
		{
			get
			{
				return _Country;
			}
			set
			{
				if (_Country != value)
				{
					_Country = value;
					SetDirty("Country");
					RaisePropertyChanged("Country");
				}
			}
		}
		private System.String _Country;
		
		[DataMember(Name="a12", Order=13, EmitDefaultValue=false)]
		public System.String HomePhone
		{
			get
			{
				return _HomePhone;
			}
			set
			{
				if (_HomePhone != value)
				{
					_HomePhone = value;
					SetDirty("HomePhone");
					RaisePropertyChanged("HomePhone");
				}
			}
		}
		private System.String _HomePhone;
		
		[DataMember(Name="a13", Order=14, EmitDefaultValue=false)]
		public System.String Extension
		{
			get
			{
				return _Extension;
			}
			set
			{
				if (_Extension != value)
				{
					_Extension = value;
					SetDirty("Extension");
					RaisePropertyChanged("Extension");
				}
			}
		}
		private System.String _Extension;
		
		[DataMember(Name="a14", Order=15, EmitDefaultValue=false)]
		public System.Byte[] Photo
		{
			get
			{
				return _Photo;
			}
			set
			{
				if (_Photo != value)
				{
					_Photo = value;
					SetDirty("Photo");
					RaisePropertyChanged("Photo");
				}
			}
		}
		private System.Byte[] _Photo;
		
		[DataMember(Name="a15", Order=16, EmitDefaultValue=false)]
		public System.String Notes
		{
			get
			{
				return _Notes;
			}
			set
			{
				if (_Notes != value)
				{
					_Notes = value;
					SetDirty("Notes");
					RaisePropertyChanged("Notes");
				}
			}
		}
		private System.String _Notes;
		
		[DataMember(Name="a16", Order=17, EmitDefaultValue=false)]
		public System.Int32? ReportsTo
		{
			get
			{
				return _ReportsTo;
			}
			set
			{
				if (_ReportsTo != value)
				{
					_ReportsTo = value;
					SetDirty("ReportsTo");
					RaisePropertyChanged("ReportsTo");
				}
			}
		}
		private System.Int32? _ReportsTo;
		
		[DataMember(Name="a17", Order=18, EmitDefaultValue=false)]
		public System.String PhotoPath
		{
			get
			{
				return _PhotoPath;
			}
			set
			{
				if (_PhotoPath != value)
				{
					_PhotoPath = value;
					SetDirty("PhotoPath");
					RaisePropertyChanged("PhotoPath");
				}
			}
		}
		private System.String _PhotoPath;
		
	
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
	
	[XmlType(TypeName = "EmployeesQueryProxyStub")]	
	[DataContract(Name = "EmployeesQuery", Namespace = "http://www.entityspaces.net")]
	public partial class EmployeesQueryProxyStub : esDynamicQuerySerializable
	{
		public EmployeesQueryProxyStub() { }
		
		public EmployeesQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "EmployeesQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(EmployeesQueryProxyStub query)
		{
			return Proxies.EmployeesQueryProxyStub.SerializeHelper.ToXml(query);
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
		
		public esQueryItem Title
		{
			get { return new esQueryItem(this, "Title", esSystemType.String); }
		} 
		
		public esQueryItem TitleOfCourtesy
		{
			get { return new esQueryItem(this, "TitleOfCourtesy", esSystemType.String); }
		} 
		
		public esQueryItem BirthDate
		{
			get { return new esQueryItem(this, "BirthDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem HireDate
		{
			get { return new esQueryItem(this, "HireDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, "Address", esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, "City", esSystemType.String); }
		} 
		
		public esQueryItem Region
		{
			get { return new esQueryItem(this, "Region", esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, "PostalCode", esSystemType.String); }
		} 
		
		public esQueryItem Country
		{
			get { return new esQueryItem(this, "Country", esSystemType.String); }
		} 
		
		public esQueryItem HomePhone
		{
			get { return new esQueryItem(this, "HomePhone", esSystemType.String); }
		} 
		
		public esQueryItem Extension
		{
			get { return new esQueryItem(this, "Extension", esSystemType.String); }
		} 
		
		public esQueryItem Photo
		{
			get { return new esQueryItem(this, "Photo", esSystemType.ByteArray); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, "Notes", esSystemType.String); }
		} 
		
		public esQueryItem ReportsTo
		{
			get { return new esQueryItem(this, "ReportsTo", esSystemType.Int32); }
		} 
		
		public esQueryItem PhotoPath
		{
			get { return new esQueryItem(this, "PhotoPath", esSystemType.String); }
		} 
		
	}
}