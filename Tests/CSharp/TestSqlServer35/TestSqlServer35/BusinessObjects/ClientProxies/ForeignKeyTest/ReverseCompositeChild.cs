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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeChildCollection")]	
	[XmlType(TypeName = "ReverseCompositeChildCollectionProxyStub")]	
	[Serializable]	
	public partial class ReverseCompositeChildCollectionProxyStub 
	{
		public ReverseCompositeChildCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ReverseCompositeChildProxyStub> Collection = new BindingList<ReverseCompositeChildProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ReverseCompositeChildProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeChild")]
	[XmlType(TypeName = "ReverseCompositeChildProxyStub")]	
	[Serializable]	
	public partial class ReverseCompositeChildProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ReverseCompositeChildProxyStub()
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
		
		[DataMember(Name="ChildId", Order=1, EmitDefaultValue=false)]
		public System.Int32? ChildId
		{
			get
			{
				return _ChildId;
			}
			set
			{
				if (_ChildId != value)
				{
					_ChildId = value;
					SetDirty("ChildId");
					RaisePropertyChanged("ChildId");
				}
			}
		}
		private System.Int32? _ChildId;
		
		[DataMember(Name="ParentKeyId", Order=2, EmitDefaultValue=false)]
		public System.Int32? ParentKeyId
		{
			get
			{
				return _ParentKeyId;
			}
			set
			{
				if (_ParentKeyId != value)
				{
					_ParentKeyId = value;
					SetDirty("ParentKeyId");
					RaisePropertyChanged("ParentKeyId");
				}
			}
		}
		private System.Int32? _ParentKeyId;
		
		[DataMember(Name="ParentKeySub", Order=3, EmitDefaultValue=false)]
		public System.String ParentKeySub
		{
			get
			{
				return _ParentKeySub;
			}
			set
			{
				if (_ParentKeySub != value)
				{
					_ParentKeySub = value;
					SetDirty("ParentKeySub");
					RaisePropertyChanged("ParentKeySub");
				}
			}
		}
		private System.String _ParentKeySub;
		
		[DataMember(Name="Description", Order=4, EmitDefaultValue=false)]
		public System.String Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if (_Description != value)
				{
					_Description = value;
					SetDirty("Description");
					RaisePropertyChanged("Description");
				}
			}
		}
		private System.String _Description;
		
	
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
	
	[XmlType(TypeName = "ReverseCompositeChildQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ReverseCompositeChildQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ReverseCompositeChildQueryProxyStub : esDynamicQuerySerializable
	{
		public ReverseCompositeChildQueryProxyStub() { }
		
		public ReverseCompositeChildQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ReverseCompositeChildQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ReverseCompositeChildQueryProxyStub query)
		{
			return Proxies.ReverseCompositeChildQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem ChildId
		{
			get { return new esQueryItem(this, "ChildId", esSystemType.Int32); }
		} 
		
		public esQueryItem ParentKeyId
		{
			get { return new esQueryItem(this, "ParentKeyId", esSystemType.Int32); }
		} 
		
		public esQueryItem ParentKeySub
		{
			get { return new esQueryItem(this, "ParentKeySub", esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, "Description", esSystemType.String); }
		} 
		
	}
}