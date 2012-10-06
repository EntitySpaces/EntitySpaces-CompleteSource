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
	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTest2Collection")]	
	[XmlType(TypeName = "NamingTest2CollectionProxyStub")]	
	[Serializable]	
	public partial class NamingTest2CollectionProxyStub 
	{
		public NamingTest2CollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<NamingTest2ProxyStub> Collection = new BindingList<NamingTest2ProxyStub>();
		
		public bool IsDirty()
		{
			foreach (NamingTest2ProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTest2")]
	[XmlType(TypeName = "NamingTest2ProxyStub")]	
	[Serializable]	
	public partial class NamingTest2ProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public NamingTest2ProxyStub()
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
		
		[DataMember(Name="IdentityKey", Order=1, EmitDefaultValue=false)]
		public System.Int32? IdentityKey
		{
			get
			{
				return _IdentityKey;
			}
			set
			{
				if (_IdentityKey != value)
				{
					_IdentityKey = value;
					SetDirty("Identity.Key");
					RaisePropertyChanged("IdentityKey");
				}
			}
		}
		private System.Int32? _IdentityKey;
		
		[DataMember(Name="ItemDescription", Order=2, EmitDefaultValue=false)]
		public System.String ItemDescription
		{
			get
			{
				return _ItemDescription;
			}
			set
			{
				if (_ItemDescription != value)
				{
					_ItemDescription = value;
					SetDirty("Item.Description");
					RaisePropertyChanged("ItemDescription");
				}
			}
		}
		private System.String _ItemDescription;
		
		[DataMember(Name="ConcurrencyCheck", Order=3, EmitDefaultValue=false)]
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
					SetDirty("Concurrency.Check");
					RaisePropertyChanged("ConcurrencyCheck");
				}
			}
		}
		private System.Byte[] _ConcurrencyCheck;
		
		[DataMember(Name="GuidNewid", Order=4, EmitDefaultValue=false)]
		public System.Guid? GuidNewid
		{
			get
			{
				return _GuidNewid;
			}
			set
			{
				if (_GuidNewid != value)
				{
					_GuidNewid = value;
					SetDirty("Guid.Newid");
					RaisePropertyChanged("GuidNewid");
				}
			}
		}
		private System.Guid? _GuidNewid;
		
	
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
	
	[XmlType(TypeName = "NamingTest2QueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "NamingTest2Query", Namespace = "http://www.entityspaces.net")]
	public partial class NamingTest2QueryProxyStub : esDynamicQuerySerializable
	{
		public NamingTest2QueryProxyStub() { }
		
		public NamingTest2QueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "NamingTest2Query";
		}
		
		#region Implicit Casts

		public static implicit operator string(NamingTest2QueryProxyStub query)
		{
			return Proxies.NamingTest2QueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem IdentityKey
		{
			get { return new esQueryItem(this, "Identity.Key", esSystemType.Int32); }
		} 
		
		public esQueryItem ItemDescription
		{
			get { return new esQueryItem(this, "Item.Description", esSystemType.String); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, "Concurrency.Check", esSystemType.ByteArray); }
		} 
		
		public esQueryItem GuidNewid
		{
			get { return new esQueryItem(this, "Guid.Newid", esSystemType.Guid); }
		} 
		
	}
}