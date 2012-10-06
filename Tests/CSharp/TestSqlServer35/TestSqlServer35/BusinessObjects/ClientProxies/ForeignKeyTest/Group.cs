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
	[DataContract(Namespace = "http://tempuri.org/", Name = "GroupCollection")]	
	[XmlType(TypeName = "GroupCollectionProxyStub")]	
	[Serializable]	
	public partial class GroupCollectionProxyStub 
	{
		public GroupCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<GroupProxyStub> Collection = new BindingList<GroupProxyStub>();
		
		public bool IsDirty()
		{
			foreach (GroupProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Group")]
	[XmlType(TypeName = "GroupProxyStub")]	
	[Serializable]	
	public partial class GroupProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public GroupProxyStub()
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
					SetDirty("ID");
					RaisePropertyChanged("Id");
				}
			}
		}
		private System.String _Id;
		
		[DataMember(Name="Notes", Order=2, EmitDefaultValue=false)]
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
	
	[XmlType(TypeName = "GroupQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "GroupQuery", Namespace = "http://www.entityspaces.net")]
	public partial class GroupQueryProxyStub : esDynamicQuerySerializable
	{
		public GroupQueryProxyStub() { }
		
		public GroupQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "GroupQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(GroupQueryProxyStub query)
		{
			return Proxies.GroupQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem Id
		{
			get { return new esQueryItem(this, "ID", esSystemType.String); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, "Notes", esSystemType.String); }
		} 
		
	}
}