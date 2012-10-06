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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeParentCollection")]	
	[XmlType(TypeName = "ReverseCompositeParentCollectionProxyStub")]	
	[Serializable]	
	public partial class ReverseCompositeParentCollectionProxyStub 
	{
		public ReverseCompositeParentCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ReverseCompositeParentProxyStub> Collection = new BindingList<ReverseCompositeParentProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ReverseCompositeParentProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeParent")]
	[XmlType(TypeName = "ReverseCompositeParentProxyStub")]	
	[Serializable]	
	public partial class ReverseCompositeParentProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ReverseCompositeParentProxyStub()
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
		
		[DataMember(Name="KeySub", Order=1, EmitDefaultValue=false)]
		public System.String KeySub
		{
			get
			{
				return _KeySub;
			}
			set
			{
				if (_KeySub != value)
				{
					_KeySub = value;
					SetDirty("KeySub");
					RaisePropertyChanged("KeySub");
				}
			}
		}
		private System.String _KeySub;
		
		[DataMember(Name="KeyId", Order=2, EmitDefaultValue=false)]
		public System.Int32? KeyId
		{
			get
			{
				return _KeyId;
			}
			set
			{
				if (_KeyId != value)
				{
					_KeyId = value;
					SetDirty("KeyId");
					RaisePropertyChanged("KeyId");
				}
			}
		}
		private System.Int32? _KeyId;
		
		[DataMember(Name="Description", Order=3, EmitDefaultValue=false)]
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
	
	[XmlType(TypeName = "ReverseCompositeParentQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ReverseCompositeParentQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ReverseCompositeParentQueryProxyStub : esDynamicQuerySerializable
	{
		public ReverseCompositeParentQueryProxyStub() { }
		
		public ReverseCompositeParentQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ReverseCompositeParentQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ReverseCompositeParentQueryProxyStub query)
		{
			return Proxies.ReverseCompositeParentQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem KeySub
		{
			get { return new esQueryItem(this, "KeySub", esSystemType.String); }
		} 
		
		public esQueryItem KeyId
		{
			get { return new esQueryItem(this, "KeyId", esSystemType.Int32); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, "Description", esSystemType.String); }
		} 
		
	}
}