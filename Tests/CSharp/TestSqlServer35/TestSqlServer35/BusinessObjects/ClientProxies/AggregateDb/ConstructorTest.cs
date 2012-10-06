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
	[DataContract(Namespace = "http://tempuri.org/", Name = "ConstructorTestCollection")]	
	[XmlType(TypeName = "ConstructorTestCollectionProxyStub")]	
	[Serializable]	
	public partial class ConstructorTestCollectionProxyStub 
	{
		public ConstructorTestCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<ConstructorTestProxyStub> Collection = new BindingList<ConstructorTestProxyStub>();
		
		public bool IsDirty()
		{
			foreach (ConstructorTestProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "ConstructorTest")]
	[XmlType(TypeName = "ConstructorTestProxyStub")]	
	[Serializable]	
	public partial class ConstructorTestProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public ConstructorTestProxyStub()
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
		
		[DataMember(Name="ConstructorTestId", Order=1, EmitDefaultValue=false)]
		public System.Int64? ConstructorTestId
		{
			get
			{
				return _ConstructorTestId;
			}
			set
			{
				if (_ConstructorTestId != value)
				{
					_ConstructorTestId = value;
					SetDirty("ConstructorTestId");
					RaisePropertyChanged("ConstructorTestId");
				}
			}
		}
		private System.Int64? _ConstructorTestId;
		
		[DataMember(Name="DefaultInt", Order=2, EmitDefaultValue=false)]
		public System.Int32? DefaultInt
		{
			get
			{
				return _DefaultInt;
			}
			set
			{
				if (_DefaultInt != value)
				{
					_DefaultInt = value;
					SetDirty("DefaultInt");
					RaisePropertyChanged("DefaultInt");
				}
			}
		}
		private System.Int32? _DefaultInt;
		
		[DataMember(Name="DefaultBool", Order=3, EmitDefaultValue=false)]
		public System.Boolean? DefaultBool
		{
			get
			{
				return _DefaultBool;
			}
			set
			{
				if (_DefaultBool != value)
				{
					_DefaultBool = value;
					SetDirty("DefaultBool");
					RaisePropertyChanged("DefaultBool");
				}
			}
		}
		private System.Boolean? _DefaultBool;
		
		[DataMember(Name="DefaultDateTime", Order=4, EmitDefaultValue=false)]
		public System.DateTime? DefaultDateTime
		{
			get
			{
				return _DefaultDateTime;
			}
			set
			{
				if (_DefaultDateTime != value)
				{
					_DefaultDateTime = value;
					SetDirty("DefaultDateTime");
					RaisePropertyChanged("DefaultDateTime");
				}
			}
		}
		private System.DateTime? _DefaultDateTime;
		
		[DataMember(Name="DefaultString", Order=5, EmitDefaultValue=false)]
		public System.String DefaultString
		{
			get
			{
				return _DefaultString;
			}
			set
			{
				if (_DefaultString != value)
				{
					_DefaultString = value;
					SetDirty("DefaultString");
					RaisePropertyChanged("DefaultString");
				}
			}
		}
		private System.String _DefaultString;
		
	
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
	
	[XmlType(TypeName = "ConstructorTestQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "ConstructorTestQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ConstructorTestQueryProxyStub : esDynamicQuerySerializable
	{
		public ConstructorTestQueryProxyStub() { }
		
		public ConstructorTestQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "ConstructorTestQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(ConstructorTestQueryProxyStub query)
		{
			return Proxies.ConstructorTestQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem ConstructorTestId
		{
			get { return new esQueryItem(this, "ConstructorTestId", esSystemType.Int64); }
		} 
		
		public esQueryItem DefaultInt
		{
			get { return new esQueryItem(this, "DefaultInt", esSystemType.Int32); }
		} 
		
		public esQueryItem DefaultBool
		{
			get { return new esQueryItem(this, "DefaultBool", esSystemType.Boolean); }
		} 
		
		public esQueryItem DefaultDateTime
		{
			get { return new esQueryItem(this, "DefaultDateTime", esSystemType.DateTime); }
		} 
		
		public esQueryItem DefaultString
		{
			get { return new esQueryItem(this, "DefaultString", esSystemType.String); }
		} 
		
	}
}