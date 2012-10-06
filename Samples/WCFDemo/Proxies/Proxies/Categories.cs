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
	[DataContract(Namespace = "http://tempuri.org/", Name = "CategoriesCollection")]	
	[XmlType(TypeName = "CategoriesCollectionProxyStub")]	
	[Serializable]	
	public partial class CategoriesCollectionProxyStub 
	{
		public CategoriesCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<CategoriesProxyStub> Collection = new BindingList<CategoriesProxyStub>();
		
		public bool IsDirty()
		{
			foreach (CategoriesProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Categories")]
	[XmlType(TypeName = "CategoriesProxyStub")]	
	[Serializable]	
	public partial class CategoriesProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public CategoriesProxyStub()
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
		public System.Int32? CategoryID
		{
			get
			{
				return _CategoryID;
			}
			set
			{
				if (_CategoryID != value)
				{
					_CategoryID = value;
					SetDirty("CategoryID");
					RaisePropertyChanged("CategoryID");
				}
			}
		}
		private System.Int32? _CategoryID;
		
		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String CategoryName
		{
			get
			{
				return _CategoryName;
			}
			set
			{
				if (_CategoryName != value)
				{
					_CategoryName = value;
					SetDirty("CategoryName");
					RaisePropertyChanged("CategoryName");
				}
			}
		}
		private System.String _CategoryName;
		
		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
		public System.Byte[] Picture
		{
			get
			{
				return _Picture;
			}
			set
			{
				if (_Picture != value)
				{
					_Picture = value;
					SetDirty("Picture");
					RaisePropertyChanged("Picture");
				}
			}
		}
		private System.Byte[] _Picture;
		
	
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
	
	[XmlType(TypeName = "CategoriesQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "CategoriesQuery", Namespace = "http://www.entityspaces.net")]
	public partial class CategoriesQueryProxyStub : esDynamicQuerySerializable
	{
		public CategoriesQueryProxyStub() { }
		
		public CategoriesQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "CategoriesQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(CategoriesQueryProxyStub query)
		{
			return Proxies.CategoriesQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, "CategoryID", esSystemType.Int32); }
		} 
		
		public esQueryItem CategoryName
		{
			get { return new esQueryItem(this, "CategoryName", esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, "Description", esSystemType.String); }
		} 
		
		public esQueryItem Picture
		{
			get { return new esQueryItem(this, "Picture", esSystemType.ByteArray); }
		} 
		
	}
}