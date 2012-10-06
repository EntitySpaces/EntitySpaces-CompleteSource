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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ComputedTestCollection")]	
	[XmlType(TypeName = "ComputedTestCollectionProxyStub")]	
	[Serializable]	
	public partial class ComputedTestCollectionProxyStub 
	{
		public ComputedTestCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ComputedTestProxyStub> Collection = new BindingList<ComputedTestProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ComputedTestProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "ComputedTest")]
	[XmlType(TypeName = "ComputedTestProxyStub")]	
	[Serializable]	
	public partial class ComputedTestProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ComputedTestProxyStub()
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
		
		[DataMember(Name="ConcurrencyCheck", Order=2, EmitDefaultValue=false)]
		public System.Byte[] ConcurrencyCheck
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
		private System.Byte[] _ConcurrencyCheck;
		
		[DataMember(Name="DateLastUpdated", Order=3, EmitDefaultValue=false)]
		public System.DateTime? DateLastUpdated
		{
			get
			{
				return _DateLastUpdated;
			}
			set
			{
				if (_DateLastUpdated != value)
				{
					_DateLastUpdated = value;
					SetDirty("DateLastUpdated");
					RaisePropertyChanged("DateLastUpdated");
				}
			}
		}
		private System.DateTime? _DateLastUpdated;
		
		[DataMember(Name="DateAdded", Order=4, EmitDefaultValue=false)]
		public System.DateTime? DateAdded
		{
			get
			{
				return _DateAdded;
			}
			set
			{
				if (_DateAdded != value)
				{
					_DateAdded = value;
					SetDirty("DateAdded");
					RaisePropertyChanged("DateAdded");
				}
			}
		}
		private System.DateTime? _DateAdded;
		
		[DataMember(Name="ComputedField", Order=5, EmitDefaultValue=false)]
		public System.Int32? ComputedField
		{
			get
			{
				return _ComputedField;
			}
			set
			{
				if (_ComputedField != value)
				{
					_ComputedField = value;
					SetDirty("ComputedTest");
					RaisePropertyChanged("ComputedField");
				}
			}
		}
		private System.Int32? _ComputedField;
		
		[DataMember(Name="SomeDate", Order=6, EmitDefaultValue=false)]
		public System.DateTime? SomeDate
		{
			get
			{
				return _SomeDate;
			}
			set
			{
				if (_SomeDate != value)
				{
					_SomeDate = value;
					SetDirty("SomeDate");
					RaisePropertyChanged("SomeDate");
				}
			}
		}
		private System.DateTime? _SomeDate;
		
	
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
	
	[XmlType(TypeName = "ComputedTestQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ComputedTestQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ComputedTestQueryProxyStub : esDynamicQuerySerializable
	{
		public ComputedTestQueryProxyStub() { }
		
		public ComputedTestQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ComputedTestQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ComputedTestQueryProxyStub query)
		{
			return Proxies.ComputedTestQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem Id
		{
			get { return new esQueryItem(this, "ID", esSystemType.Int32); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, "ConcurrencyCheck", esSystemType.ByteArray); }
		} 
		
		public esQueryItem DateLastUpdated
		{
			get { return new esQueryItem(this, "DateLastUpdated", esSystemType.DateTime); }
		} 
		
		public esQueryItem DateAdded
		{
			get { return new esQueryItem(this, "DateAdded", esSystemType.DateTime); }
		} 
		
		public esQueryItem ComputedField
		{
			get { return new esQueryItem(this, "ComputedTest", esSystemType.Int32); }
		} 
		
		public esQueryItem SomeDate
		{
			get { return new esQueryItem(this, "SomeDate", esSystemType.DateTime); }
		} 
		
	}
}