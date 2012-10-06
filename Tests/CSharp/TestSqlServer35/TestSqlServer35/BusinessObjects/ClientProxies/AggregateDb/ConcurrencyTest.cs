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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTestCollection")]	
	[XmlType(TypeName = "ConcurrencyTestCollectionProxyStub")]	
	[Serializable]	
	public partial class ConcurrencyTestCollectionProxyStub 
	{
		public ConcurrencyTestCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ConcurrencyTestProxyStub> Collection = new BindingList<ConcurrencyTestProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ConcurrencyTestProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTest")]
	[XmlType(TypeName = "ConcurrencyTestProxyStub")]	
	[Serializable]	
	public partial class ConcurrencyTestProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ConcurrencyTestProxyStub()
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
		public System.String Id
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
		private System.String _Id;
		
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
		
		[DataMember(Name="ConcurrencyCheck", Order=3, EmitDefaultValue=false)]
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
	
	[XmlType(TypeName = "ConcurrencyTestQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ConcurrencyTestQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ConcurrencyTestQueryProxyStub : esDynamicQuerySerializable
	{
		public ConcurrencyTestQueryProxyStub() { }
		
		public ConcurrencyTestQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ConcurrencyTestQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ConcurrencyTestQueryProxyStub query)
		{
			return Proxies.ConcurrencyTestQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem Id
		{
			get { return new esQueryItem(this, "Id", esSystemType.String); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, "Name", esSystemType.String); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, "ConcurrencyCheck", esSystemType.Int64); }
		} 
		
	}
}