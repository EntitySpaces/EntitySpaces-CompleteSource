/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:13 PM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.DynamicQuery;

namespace Proxies
{
	[DataContract(Namespace = "http://tempuri.org/", Name = "ProductsCollection")]	
	[XmlType(TypeName = "ProductsCollectionProxyStub")]	
	public partial class ProductsCollectionProxyStub 
	{
		public ProductsCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public ObservableCollection<ProductsProxyStub> Collection = new ObservableCollection<ProductsProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ProductsProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "Products")]
	[XmlType(TypeName = "ProductsProxyStub")]	
	public partial class ProductsProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ProductsProxyStub()
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
		
		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
		public System.Int32? SupplierID
		{
			get
			{
				return _SupplierID;
			}
			set
			{
				if (_SupplierID != value)
				{
					_SupplierID = value;
					SetDirty("SupplierID");
					RaisePropertyChanged("SupplierID");
				}
			}
		}
		private System.Int32? _SupplierID;
		
		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a4", Order=5, EmitDefaultValue=false)]
		public System.String QuantityPerUnit
		{
			get
			{
				return _QuantityPerUnit;
			}
			set
			{
				if (_QuantityPerUnit != value)
				{
					_QuantityPerUnit = value;
					SetDirty("QuantityPerUnit");
					RaisePropertyChanged("QuantityPerUnit");
				}
			}
		}
		private System.String _QuantityPerUnit;
		
		[DataMember(Name="a5", Order=6, EmitDefaultValue=false)]
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
		
		[DataMember(Name="a6", Order=7, EmitDefaultValue=false)]
		public System.Int16? UnitsInStock
		{
			get
			{
				return _UnitsInStock;
			}
			set
			{
				if (_UnitsInStock != value)
				{
					_UnitsInStock = value;
					SetDirty("UnitsInStock");
					RaisePropertyChanged("UnitsInStock");
				}
			}
		}
		private System.Int16? _UnitsInStock;
		
		[DataMember(Name="a7", Order=8, EmitDefaultValue=false)]
		public System.Int16? UnitsOnOrder
		{
			get
			{
				return _UnitsOnOrder;
			}
			set
			{
				if (_UnitsOnOrder != value)
				{
					_UnitsOnOrder = value;
					SetDirty("UnitsOnOrder");
					RaisePropertyChanged("UnitsOnOrder");
				}
			}
		}
		private System.Int16? _UnitsOnOrder;
		
		[DataMember(Name="a8", Order=9, EmitDefaultValue=false)]
		public System.Int16? ReorderLevel
		{
			get
			{
				return _ReorderLevel;
			}
			set
			{
				if (_ReorderLevel != value)
				{
					_ReorderLevel = value;
					SetDirty("ReorderLevel");
					RaisePropertyChanged("ReorderLevel");
				}
			}
		}
		private System.Int16? _ReorderLevel;
		
		[DataMember(Name="a9", Order=10, EmitDefaultValue=false)]
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
	
	[XmlType(TypeName = "ProductsQueryProxyStub")]	
	[DataContract(Name = "ProductsQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ProductsQueryProxyStub : esDynamicQuerySerializable
	{
		public ProductsQueryProxyStub() { }
		
		public ProductsQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ProductsQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ProductsQueryProxyStub query)
		{
			return Proxies.ProductsQueryProxyStub.SerializeHelper.ToXml(query);
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
		
		public esQueryItem SupplierID
		{
			get { return new esQueryItem(this, "SupplierID", esSystemType.Int32); }
		} 
		
		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, "CategoryID", esSystemType.Int32); }
		} 
		
		public esQueryItem QuantityPerUnit
		{
			get { return new esQueryItem(this, "QuantityPerUnit", esSystemType.String); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, "UnitPrice", esSystemType.Decimal); }
		} 
		
		public esQueryItem UnitsInStock
		{
			get { return new esQueryItem(this, "UnitsInStock", esSystemType.Int16); }
		} 
		
		public esQueryItem UnitsOnOrder
		{
			get { return new esQueryItem(this, "UnitsOnOrder", esSystemType.Int16); }
		} 
		
		public esQueryItem ReorderLevel
		{
			get { return new esQueryItem(this, "ReorderLevel", esSystemType.Int16); }
		} 
		
		public esQueryItem Discontinued
		{
			get { return new esQueryItem(this, "Discontinued", esSystemType.Boolean); }
		} 
		
	}
}