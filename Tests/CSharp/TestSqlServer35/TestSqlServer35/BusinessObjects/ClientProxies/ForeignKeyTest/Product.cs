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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ProductCollection")]	
	[XmlType(TypeName = "ProductCollectionProxyStub")]	
	[Serializable]	
	public partial class ProductCollectionProxyStub 
	{
		public ProductCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ProductProxyStub> Collection = new BindingList<ProductProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ProductProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Product")]
	[XmlType(TypeName = "ProductProxyStub")]	
	[Serializable]	
	public partial class ProductProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ProductProxyStub()
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
		
		[DataMember(Name="ProductID", Order=1, EmitDefaultValue=false)]
		public System.Int32? ProductID
		{
			get
			{
				return _ProductID;
			}
			set
			{
				if (_ProductID != value)
				{
					_ProductID = value;
					SetDirty("ProductID");
					RaisePropertyChanged("ProductID");
				}
			}
		}
		private System.Int32? _ProductID;
		
		[DataMember(Name="ProductName", Order=2, EmitDefaultValue=false)]
		public System.String ProductName
		{
			get
			{
				return _ProductName;
			}
			set
			{
				if (_ProductName != value)
				{
					_ProductName = value;
					SetDirty("ProductName");
					RaisePropertyChanged("ProductName");
				}
			}
		}
		private System.String _ProductName;
		
		[DataMember(Name="UnitPrice", Order=3, EmitDefaultValue=false)]
		public System.Decimal? UnitPrice
		{
			get
			{
				return _UnitPrice;
			}
			set
			{
				if (_UnitPrice != value)
				{
					_UnitPrice = value;
					SetDirty("UnitPrice");
					RaisePropertyChanged("UnitPrice");
				}
			}
		}
		private System.Decimal? _UnitPrice;
		
		[DataMember(Name="Discontinued", Order=4, EmitDefaultValue=false)]
		public System.Boolean? Discontinued
		{
			get
			{
				return _Discontinued;
			}
			set
			{
				if (_Discontinued != value)
				{
					_Discontinued = value;
					SetDirty("Discontinued");
					RaisePropertyChanged("Discontinued");
				}
			}
		}
		private System.Boolean? _Discontinued;
		
	
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
	
	[XmlType(TypeName = "ProductQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ProductQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ProductQueryProxyStub : esDynamicQuerySerializable
	{
		public ProductQueryProxyStub() { }
		
		public ProductQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ProductQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ProductQueryProxyStub query)
		{
			return Proxies.ProductQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, "ProductID", esSystemType.Int32); }
		} 
		
		public esQueryItem ProductName
		{
			get { return new esQueryItem(this, "ProductName", esSystemType.String); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, "UnitPrice", esSystemType.Decimal); }
		} 
		
		public esQueryItem Discontinued
		{
			get { return new esQueryItem(this, "Discontinued", esSystemType.Boolean); }
		} 
		
	}
}