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
	[DataContract(Namespace = "http://tempuri.org/", Name = "TerritoryExCollection")]	
	[XmlType(TypeName = "TerritoryExCollectionProxyStub")]	
	[Serializable]	
	public partial class TerritoryExCollectionProxyStub 
	{
		public TerritoryExCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<TerritoryExProxyStub> Collection = new BindingList<TerritoryExProxyStub>();
		
		public bool IsDirty()
		{
			foreach (TerritoryExProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "TerritoryEx")]
	[XmlType(TypeName = "TerritoryExProxyStub")]	
	[Serializable]	
	public partial class TerritoryExProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public TerritoryExProxyStub()
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
		
		[DataMember(Name="TerritoryID", Order=1, EmitDefaultValue=false)]
		public System.Int32? TerritoryID
		{
			get
			{
				return _TerritoryID;
			}
			set
			{
				if (_TerritoryID != value)
				{
					_TerritoryID = value;
					SetDirty("TerritoryID");
					RaisePropertyChanged("TerritoryID");
				}
			}
		}
		private System.Int32? _TerritoryID;
		
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
	
	[XmlType(TypeName = "TerritoryExQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "TerritoryExQuery", Namespace = "http://www.entityspaces.net")]
	public partial class TerritoryExQueryProxyStub : esDynamicQuerySerializable
	{
		public TerritoryExQueryProxyStub() { }
		
		public TerritoryExQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "TerritoryExQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(TerritoryExQueryProxyStub query)
		{
			return Proxies.TerritoryExQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem TerritoryID
		{
			get { return new esQueryItem(this, "TerritoryID", esSystemType.Int32); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, "Notes", esSystemType.String); }
		} 
		
	}
}