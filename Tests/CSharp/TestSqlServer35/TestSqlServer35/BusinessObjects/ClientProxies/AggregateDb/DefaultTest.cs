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
	[DataContract(Namespace = "http://tempuri.org/", Name = "DefaultTestCollection")]	
	[XmlType(TypeName = "DefaultTestCollectionProxyStub")]	
	[Serializable]	
	public partial class DefaultTestCollectionProxyStub 
	{
		public DefaultTestCollectionProxyStub() { }
	
		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public BindingList<DefaultTestProxyStub> Collection = new BindingList<DefaultTestProxyStub>();
		
		public bool IsDirty()
		{
			foreach (DefaultTestProxyStub obj in Collection)
			{
				if (obj.IsDirty()) return true;
			}

			return false;
		}
	}
	
	[DataContract(Namespace = "http://tempuri.org/", Name = "DefaultTest")]
	[XmlType(TypeName = "DefaultTestProxyStub")]	
	[Serializable]	
	public partial class DefaultTestProxyStub : object, System.ComponentModel.INotifyPropertyChanged
	{
		public DefaultTestProxyStub()
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
		
		[DataMember(Name="TestId", Order=1, EmitDefaultValue=false)]
		public System.Int32? TestId
		{
			get
			{
				return _TestId;
			}
			set
			{
				if (_TestId != value)
				{
					_TestId = value;
					SetDirty("TestId");
					RaisePropertyChanged("TestId");
				}
			}
		}
		private System.Int32? _TestId;
		
		[DataMember(Name="DefaultNotNullInt", Order=2, EmitDefaultValue=false)]
		public System.Int32? DefaultNotNullInt
		{
			get
			{
				return _DefaultNotNullInt;
			}
			set
			{
				if (_DefaultNotNullInt != value)
				{
					_DefaultNotNullInt = value;
					SetDirty("DefaultNotNullInt");
					RaisePropertyChanged("DefaultNotNullInt");
				}
			}
		}
		private System.Int32? _DefaultNotNullInt;
		
		[DataMember(Name="DefaultNotNullBool", Order=3, EmitDefaultValue=false)]
		public System.Boolean? DefaultNotNullBool
		{
			get
			{
				return _DefaultNotNullBool;
			}
			set
			{
				if (_DefaultNotNullBool != value)
				{
					_DefaultNotNullBool = value;
					SetDirty("DefaultNotNullBool");
					RaisePropertyChanged("DefaultNotNullBool");
				}
			}
		}
		private System.Boolean? _DefaultNotNullBool;
		
	
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
	
	[XmlType(TypeName = "DefaultTestQueryProxyStub")]	
	[Serializable]	
	[DataContract(Name = "DefaultTestQuery", Namespace = "http://www.entityspaces.net")]
	public partial class DefaultTestQueryProxyStub : esDynamicQuerySerializable
	{
		public DefaultTestQueryProxyStub() { }
		
		public DefaultTestQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	
		
		override protected string GetQueryName()
		{
			return "DefaultTestQuery";
		}
		
		#region Implicit Casts

		public static implicit operator string(DefaultTestQueryProxyStub query)
		{
			return Proxies.DefaultTestQueryProxyStub.SerializeHelper.ToXml(query);
		}

		#endregion
	
		public esQueryItem TestId
		{
			get { return new esQueryItem(this, "TestId", esSystemType.Int32); }
		} 
		
		public esQueryItem DefaultNotNullInt
		{
			get { return new esQueryItem(this, "DefaultNotNullInt", esSystemType.Int32); }
		} 
		
		public esQueryItem DefaultNotNullBool
		{
			get { return new esQueryItem(this, "DefaultNotNullBool", esSystemType.Boolean); }
		} 
		
	}
}