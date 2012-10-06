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
	[DataContract(Namespace = "http://tempuri.org/", Name = "RegionCollection")]	
	[XmlType(TypeName = "RegionCollectionProxyStub")]	
	[Serializable]	
	public partial class RegionCollectionProxyStub 
	{
		public RegionCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<RegionProxyStub> Collection = new BindingList<RegionProxyStub>();
		
		public bool IsDirty()
		{
			foreach (RegionProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Region")]
	[XmlType(TypeName = "RegionProxyStub")]	
	[Serializable]	
	public partial class RegionProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public RegionProxyStub()
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
		public System.Int32? RegionID
		{
			get
			{
				return _RegionID;
			}
			set
			{
				if (_RegionID != value)
				{
					_RegionID = value;
					SetDirty("RegionID");
					RaisePropertyChanged("RegionID");
				}
			}
		}
		private System.Int32? _RegionID;
		
		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String RegionDescription
		{
			get
			{
				return _RegionDescription;
			}
			set
			{
				if (_RegionDescription != value)
				{
					_RegionDescription = value;
					SetDirty("RegionDescription");
					RaisePropertyChanged("RegionDescription");
				}
			}
		}
		private System.String _RegionDescription;
		
	
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
	
	[XmlType(TypeName = "RegionQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "RegionQuery", Namespace = "http://www.entityspaces.net")]
	public partial class RegionQueryProxyStub : esDynamicQuerySerializable
	{
		public RegionQueryProxyStub() { }
		
		public RegionQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "RegionQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(RegionQueryProxyStub query)
		{
			return Proxies.RegionQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem RegionID
		{
			get { return new esQueryItem(this, "RegionID", esSystemType.Int32); }
		} 
		
		public esQueryItem RegionDescription
		{
			get { return new esQueryItem(this, "RegionDescription", esSystemType.String); }
		} 
		
	}
}