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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTestChildCollection")]	
	[XmlType(TypeName = "ConcurrencyTestChildCollectionProxyStub")]	
	[Serializable]	
	public partial class ConcurrencyTestChildCollectionProxyStub 
	{
		public ConcurrencyTestChildCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ConcurrencyTestChildProxyStub> Collection = new BindingList<ConcurrencyTestChildProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ConcurrencyTestChildProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTestChild")]
	[XmlType(TypeName = "ConcurrencyTestChildProxyStub")]	
	[Serializable]	
	public partial class ConcurrencyTestChildProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ConcurrencyTestChildProxyStub()
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
		public System.Int64? Id
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
					SetDirty("Id");
					RaisePropertyChanged("Id");
				}
			}
		}
		private System.Int64? _Id;
		
		[DataMember(Name="Name", Order=2, EmitDefaultValue=false)]
		public System.String Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if (_Name != value)
				{
					_Name = value;
					SetDirty("Name");
					RaisePropertyChanged("Name");
				}
			}
		}
		private System.String _Name;
		
		[DataMember(Name="Parent", Order=3, EmitDefaultValue=false)]
		public System.Int64? Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				if (_Parent != value)
				{
					_Parent = value;
					SetDirty("Parent");
					RaisePropertyChanged("Parent");
				}
			}
		}
		private System.Int64? _Parent;
		
		[DataMember(Name="ConcurrencyCheck", Order=4, EmitDefaultValue=false)]
		public System.Int64? ConcurrencyCheck
		{
			get
			{
				return _ConcurrencyCheck;
			}
			set
			{
				if (_ConcurrencyCheck != value)
				{
					_ConcurrencyCheck = value;
					SetDirty("ConcurrencyCheck");
					RaisePropertyChanged("ConcurrencyCheck");
				}
			}
		}
		private System.Int64? _ConcurrencyCheck;
		
		[DataMember(Name="DefaultTest", Order=5, EmitDefaultValue=false)]
		public System.DateTime? DefaultTest
		{
			get
			{
				return _DefaultTest;
			}
			set
			{
				if (_DefaultTest != value)
				{
					_DefaultTest = value;
					SetDirty("DefaultTest");
					RaisePropertyChanged("DefaultTest");
				}
			}
		}
		private System.DateTime? _DefaultTest;
		
		[DataMember(Name="ColumnA", Order=6, EmitDefaultValue=false)]
		public System.Int32? ColumnA
		{
			get
			{
				return _ColumnA;
			}
			set
			{
				if (_ColumnA != value)
				{
					_ColumnA = value;
					SetDirty("ColumnA");
					RaisePropertyChanged("ColumnA");
				}
			}
		}
		private System.Int32? _ColumnA;
		
		[DataMember(Name="ColumnB", Order=7, EmitDefaultValue=false)]
		public System.Int32? ColumnB
		{
			get
			{
				return _ColumnB;
			}
			set
			{
				if (_ColumnB != value)
				{
					_ColumnB = value;
					SetDirty("ColumnB");
					RaisePropertyChanged("ColumnB");
				}
			}
		}
		private System.Int32? _ColumnB;
		
		[DataMember(Name="ComputedAB", Order=8, EmitDefaultValue=false)]
		public System.Int32? ComputedAB
		{
			get
			{
				return _ComputedAB;
			}
			set
			{
				if (_ComputedAB != value)
				{
					_ComputedAB = value;
					SetDirty("ComputedAB");
					RaisePropertyChanged("ComputedAB");
				}
			}
		}
		private System.Int32? _ComputedAB;
		
	
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
	
	[XmlType(TypeName = "ConcurrencyTestChildQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ConcurrencyTestChildQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ConcurrencyTestChildQueryProxyStub : esDynamicQuerySerializable
	{
		public ConcurrencyTestChildQueryProxyStub() { }
		
		public ConcurrencyTestChildQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ConcurrencyTestChildQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ConcurrencyTestChildQueryProxyStub query)
		{
			return Proxies.ConcurrencyTestChildQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem Id
		{
			get { return new esQueryItem(this, "Id", esSystemType.Int64); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, "Name", esSystemType.String); }
		} 
		
		public esQueryItem Parent
		{
			get { return new esQueryItem(this, "Parent", esSystemType.Int64); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, "ConcurrencyCheck", esSystemType.Int64); }
		} 
		
		public esQueryItem DefaultTest
		{
			get { return new esQueryItem(this, "DefaultTest", esSystemType.DateTime); }
		} 
		
		public esQueryItem ColumnA
		{
			get { return new esQueryItem(this, "ColumnA", esSystemType.Int32); }
		} 
		
		public esQueryItem ColumnB
		{
			get { return new esQueryItem(this, "ColumnB", esSystemType.Int32); }
		} 
		
		public esQueryItem ComputedAB
		{
			get { return new esQueryItem(this, "ComputedAB", esSystemType.Int32); }
		} 
		
	}
}