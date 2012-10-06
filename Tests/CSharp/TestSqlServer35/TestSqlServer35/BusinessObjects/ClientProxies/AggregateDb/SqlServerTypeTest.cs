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
	[DataContract(Namespace = "http://tempuri.org/", Name = "SqlServerTypeTestCollection")]	
	[XmlType(TypeName = "SqlServerTypeTestCollectionProxyStub")]	
	[Serializable]	
	public partial class SqlServerTypeTestCollectionProxyStub 
	{
		public SqlServerTypeTestCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<SqlServerTypeTestProxyStub> Collection = new BindingList<SqlServerTypeTestProxyStub>();
		
		public bool IsDirty()
		{
			foreach (SqlServerTypeTestProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "SqlServerTypeTest")]
	[XmlType(TypeName = "SqlServerTypeTestProxyStub")]	
	[Serializable]	
	public partial class SqlServerTypeTestProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public SqlServerTypeTestProxyStub()
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
		public System.Int64? Id
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
		private System.Int64? _Id;
		
		[DataMember(Name="ConcurrencyCheck", Order=2, EmitDefaultValue=false)]
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
					SetDirty("ConcurrencyCheck");
					RaisePropertyChanged("ConcurrencyCheck");
				}
			}
		}
		private System.Byte[] _ConcurrencyCheck;
		
		[DataMember(Name="NVarCharType", Order=3, EmitDefaultValue=false)]
		public System.String NVarCharType
		{
			get
			{
				return _NVarCharType;
			}
			set
			{
				if (_NVarCharType != value)
				{
					_NVarCharType = value;
					SetDirty("NVarCharType");
					RaisePropertyChanged("NVarCharType");
				}
			}
		}
		private System.String _NVarCharType;
		
		[DataMember(Name="NumericType", Order=4, EmitDefaultValue=false)]
		public System.Decimal? NumericType
		{
			get
			{
				return _NumericType;
			}
			set
			{
				if (_NumericType != value)
				{
					_NumericType = value;
					SetDirty("NumericType");
					RaisePropertyChanged("NumericType");
				}
			}
		}
		private System.Decimal? _NumericType;
		
		[DataMember(Name="RealType", Order=5, EmitDefaultValue=false)]
		public System.Single? RealType
		{
			get
			{
				return _RealType;
			}
			set
			{
				if (_RealType != value)
				{
					_RealType = value;
					SetDirty("RealType");
					RaisePropertyChanged("RealType");
				}
			}
		}
		private System.Single? _RealType;
		
		[DataMember(Name="FloatType", Order=6, EmitDefaultValue=false)]
		public System.Double? FloatType
		{
			get
			{
				return _FloatType;
			}
			set
			{
				if (_FloatType != value)
				{
					_FloatType = value;
					SetDirty("FloatType");
					RaisePropertyChanged("FloatType");
				}
			}
		}
		private System.Double? _FloatType;
		
		[DataMember(Name="DecimalType", Order=7, EmitDefaultValue=false)]
		public System.Decimal? DecimalType
		{
			get
			{
				return _DecimalType;
			}
			set
			{
				if (_DecimalType != value)
				{
					_DecimalType = value;
					SetDirty("DecimalType");
					RaisePropertyChanged("DecimalType");
				}
			}
		}
		private System.Decimal? _DecimalType;
		
		[DataMember(Name="VarCharMaxType", Order=8, EmitDefaultValue=false)]
		public System.String VarCharMaxType
		{
			get
			{
				return _VarCharMaxType;
			}
			set
			{
				if (_VarCharMaxType != value)
				{
					_VarCharMaxType = value;
					SetDirty("VarCharMaxType");
					RaisePropertyChanged("VarCharMaxType");
				}
			}
		}
		private System.String _VarCharMaxType;
		
		[DataMember(Name="BigIntType", Order=9, EmitDefaultValue=false)]
		public System.Int64? BigIntType
		{
			get
			{
				return _BigIntType;
			}
			set
			{
				if (_BigIntType != value)
				{
					_BigIntType = value;
					SetDirty("BigIntType");
					RaisePropertyChanged("BigIntType");
				}
			}
		}
		private System.Int64? _BigIntType;
		
		[DataMember(Name="NCharType", Order=10, EmitDefaultValue=false)]
		public System.Char? NCharType
		{
			get
			{
				return _NCharType;
			}
			set
			{
				if (_NCharType != value)
				{
					_NCharType = value;
					SetDirty("NCharType");
					RaisePropertyChanged("NCharType");
				}
			}
		}
		private System.Char? _NCharType;
		
	
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
	
	[XmlType(TypeName = "SqlServerTypeTestQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "SqlServerTypeTestQuery", Namespace = "http://www.entityspaces.net")]
	public partial class SqlServerTypeTestQueryProxyStub : esDynamicQuerySerializable
	{
		public SqlServerTypeTestQueryProxyStub() { }
		
		public SqlServerTypeTestQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "SqlServerTypeTestQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(SqlServerTypeTestQueryProxyStub query)
		{
			return Proxies.SqlServerTypeTestQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem Id
		{
			get { return new esQueryItem(this, "Id", esSystemType.Int64); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, "ConcurrencyCheck", esSystemType.ByteArray); }
		} 
		
		public esQueryItem NVarCharType
		{
			get { return new esQueryItem(this, "NVarCharType", esSystemType.String); }
		} 
		
		public esQueryItem NumericType
		{
			get { return new esQueryItem(this, "NumericType", esSystemType.Decimal); }
		} 
		
		public esQueryItem RealType
		{
			get { return new esQueryItem(this, "RealType", esSystemType.Single); }
		} 
		
		public esQueryItem FloatType
		{
			get { return new esQueryItem(this, "FloatType", esSystemType.Double); }
		} 
		
		public esQueryItem DecimalType
		{
			get { return new esQueryItem(this, "DecimalType", esSystemType.Decimal); }
		} 
		
		public esQueryItem VarCharMaxType
		{
			get { return new esQueryItem(this, "VarCharMaxType", esSystemType.String); }
		} 
		
		public esQueryItem BigIntType
		{
			get { return new esQueryItem(this, "BigIntType", esSystemType.Int64); }
		} 
		
		public esQueryItem NCharType
		{
			get { return new esQueryItem(this, "NCharType", esSystemType.Char); }
		} 
		
	}
}