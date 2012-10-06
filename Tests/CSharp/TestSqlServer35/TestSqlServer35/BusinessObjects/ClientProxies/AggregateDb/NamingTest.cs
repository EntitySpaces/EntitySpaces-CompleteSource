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
	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTestCollection")]	
	[XmlType(TypeName = "NamingTestCollectionProxyStub")]	
	[Serializable]	
	public partial class NamingTestCollectionProxyStub 
	{
		public NamingTestCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<NamingTestProxyStub> Collection = new BindingList<NamingTestProxyStub>();
		
		public bool IsDirty()
		{
			foreach (NamingTestProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTest")]
	[XmlType(TypeName = "NamingTestProxyStub")]	
	[Serializable]	
	public partial class NamingTestProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public NamingTestProxyStub()
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
		
		[DataMember(Name="GuidKeyAlias", Order=1, EmitDefaultValue=false)]
		public System.Guid? GuidKeyAlias
		{
			get
			{
				return _GuidKeyAlias;
			}
			set
			{
				if (_GuidKeyAlias != value)
				{
					_GuidKeyAlias = value;
					SetDirty("GuidKey");
					RaisePropertyChanged("GuidKeyAlias");
				}
			}
		}
		private System.Guid? _GuidKeyAlias;
		
		[DataMember(Name="TestAliasSpace", Order=2, EmitDefaultValue=false)]
		public System.String TestAliasSpace
		{
			get
			{
				return _TestAliasSpace;
			}
			set
			{
				if (_TestAliasSpace != value)
				{
					_TestAliasSpace = value;
					SetDirty("Test AliasSpace");
					RaisePropertyChanged("TestAliasSpace");
				}
			}
		}
		private System.String _TestAliasSpace;
		
		[DataMember(Name="Test_Alias_Underscore", Order=3, EmitDefaultValue=false)]
		public System.String Test_Alias_Underscore
		{
			get
			{
				return _Test_Alias_Underscore;
			}
			set
			{
				if (_Test_Alias_Underscore != value)
				{
					_Test_Alias_Underscore = value;
					SetDirty("Test_AliasUnderscore");
					RaisePropertyChanged("Test_Alias_Underscore");
				}
			}
		}
		private System.String _Test_Alias_Underscore;
		
		[DataMember(Name="TestFieldSpace", Order=4, EmitDefaultValue=false)]
		public System.String TestFieldSpace
		{
			get
			{
				return _TestFieldSpace;
			}
			set
			{
				if (_TestFieldSpace != value)
				{
					_TestFieldSpace = value;
					SetDirty("Test FieldSpace");
					RaisePropertyChanged("TestFieldSpace");
				}
			}
		}
		private System.String _TestFieldSpace;
		
		[DataMember(Name="TestFieldUnderscore", Order=5, EmitDefaultValue=false)]
		public System.String TestFieldUnderscore
		{
			get
			{
				return _TestFieldUnderscore;
			}
			set
			{
				if (_TestFieldUnderscore != value)
				{
					_TestFieldUnderscore = value;
					SetDirty("test_field_underscore");
					RaisePropertyChanged("TestFieldUnderscore");
				}
			}
		}
		private System.String _TestFieldUnderscore;
		
		[DataMember(Name="TestAlias", Order=6, EmitDefaultValue=false)]
		public System.String TestAlias
		{
			get
			{
				return _TestAlias;
			}
			set
			{
				if (_TestAlias != value)
				{
					_TestAlias = value;
					SetDirty("TestAliasPascal");
					RaisePropertyChanged("TestAlias");
				}
			}
		}
		private System.String _TestAlias;
		
		[DataMember(Name="GuidNonKey", Order=7, EmitDefaultValue=false)]
		public System.Guid? GuidNonKey
		{
			get
			{
				return _GuidNonKey;
			}
			set
			{
				if (_GuidNonKey != value)
				{
					_GuidNonKey = value;
					SetDirty("GuidNonKey");
					RaisePropertyChanged("GuidNonKey");
				}
			}
		}
		private System.Guid? _GuidNonKey;
		
		[DataMember(Name="TestFieldDot", Order=8, EmitDefaultValue=false)]
		public System.String TestFieldDot
		{
			get
			{
				return _TestFieldDot;
			}
			set
			{
				if (_TestFieldDot != value)
				{
					_TestFieldDot = value;
					SetDirty("Test.FieldDot");
					RaisePropertyChanged("TestFieldDot");
				}
			}
		}
		private System.String _TestFieldDot;
		
	
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
	
	[XmlType(TypeName = "NamingTestQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "NamingTestQuery", Namespace = "http://www.entityspaces.net")]
	public partial class NamingTestQueryProxyStub : esDynamicQuerySerializable
	{
		public NamingTestQueryProxyStub() { }
		
		public NamingTestQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "NamingTestQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(NamingTestQueryProxyStub query)
		{
			return Proxies.NamingTestQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem GuidKeyAlias
		{
			get { return new esQueryItem(this, "GuidKey", esSystemType.Guid); }
		} 
		
		public esQueryItem TestAliasSpace
		{
			get { return new esQueryItem(this, "Test AliasSpace", esSystemType.String); }
		} 
		
		public esQueryItem Test_Alias_Underscore
		{
			get { return new esQueryItem(this, "Test_AliasUnderscore", esSystemType.String); }
		} 
		
		public esQueryItem TestFieldSpace
		{
			get { return new esQueryItem(this, "Test FieldSpace", esSystemType.String); }
		} 
		
		public esQueryItem TestFieldUnderscore
		{
			get { return new esQueryItem(this, "test_field_underscore", esSystemType.String); }
		} 
		
		public esQueryItem TestAlias
		{
			get { return new esQueryItem(this, "TestAliasPascal", esSystemType.String); }
		} 
		
		public esQueryItem GuidNonKey
		{
			get { return new esQueryItem(this, "GuidNonKey", esSystemType.Guid); }
		} 
		
		public esQueryItem TestFieldDot
		{
			get { return new esQueryItem(this, "Test.FieldDot", esSystemType.String); }
		} 
		
	}
}