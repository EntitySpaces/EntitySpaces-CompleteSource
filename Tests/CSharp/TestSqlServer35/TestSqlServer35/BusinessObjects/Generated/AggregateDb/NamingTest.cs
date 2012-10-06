
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:36 AM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Naming.Test' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(NamingTest))]	
	[XmlType("NamingTest")]
	[Table(Name="NamingTest")]
	public partial class NamingTest : esNamingTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new NamingTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid guidKeyAlias)
		{
			var obj = new NamingTest();
			obj.GuidKeyAlias = guidKeyAlias;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid guidKeyAlias, esSqlAccessType sqlAccessType)
		{
			var obj = new NamingTest();
			obj.GuidKeyAlias = guidKeyAlias;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator NamingTestProxyStub(NamingTest entity)
		{
			return new NamingTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Guid? GuidKeyAlias
		{
			get { return base.GuidKeyAlias;  }
			set { base.GuidKeyAlias = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String TestAliasSpace
		{
			get { return base.TestAliasSpace;  }
			set { base.TestAliasSpace = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String Test_Alias_Underscore
		{
			get { return base.Test_Alias_Underscore;  }
			set { base.Test_Alias_Underscore = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String TestFieldSpace
		{
			get { return base.TestFieldSpace;  }
			set { base.TestFieldSpace = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String TestFieldUnderscore
		{
			get { return base.TestFieldUnderscore;  }
			set { base.TestFieldUnderscore = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String TestAlias
		{
			get { return base.TestAlias;  }
			set { base.TestAlias = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Guid? GuidNonKey
		{
			get { return base.GuidNonKey;  }
			set { base.GuidNonKey = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String TestFieldDot
		{
			get { return base.TestFieldDot;  }
			set { base.TestFieldDot = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("NamingTestCollection")]
	public partial class NamingTestCollection : esNamingTestCollection, IEnumerable<NamingTest>
	{
		public NamingTest FindByPrimaryKey(System.Guid guidKeyAlias)
		{
			return this.SingleOrDefault(e => e.GuidKeyAlias == guidKeyAlias);
		}

		#region Implicit Casts
		
		public static implicit operator NamingTestCollectionProxyStub(NamingTestCollection coll)
		{
			return new NamingTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(NamingTest))]
		public class NamingTestCollectionWCFPacket : esCollectionWCFPacket<NamingTestCollection>
		{
			public static implicit operator NamingTestCollection(NamingTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator NamingTestCollectionWCFPacket(NamingTestCollection collection)
			{
				return new NamingTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "NamingTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class NamingTestQuery : esNamingTestQuery
	{
		public NamingTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "NamingTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(NamingTestQuery query)
		{
			return NamingTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator NamingTestQuery(string query)
		{
			return (NamingTestQuery)NamingTestQuery.SerializeHelper.FromXml(query, typeof(NamingTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esNamingTest : EntityBase
	{
		public esNamingTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid guidKeyAlias)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(guidKeyAlias);
			else
				return LoadByPrimaryKeyStoredProcedure(guidKeyAlias);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid guidKeyAlias)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(guidKeyAlias);
			else
				return LoadByPrimaryKeyStoredProcedure(guidKeyAlias);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid guidKeyAlias)
		{
			NamingTestQuery query = new NamingTestQuery();
			query.Where(query.GuidKeyAlias == guidKeyAlias);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid guidKeyAlias)
		{
			esParameters parms = new esParameters();
			parms.Add("GuidKeyAlias", guidKeyAlias);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Naming.Test.GuidKey
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? GuidKeyAlias
		{
			get
			{
				return base.GetSystemGuid(NamingTestMetadata.ColumnNames.GuidKeyAlias);
			}
			
			set
			{
				if(base.SetSystemGuid(NamingTestMetadata.ColumnNames.GuidKeyAlias, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidKeyAlias);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming.Test.Test AliasSpace
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TestAliasSpace
		{
			get
			{
				return base.GetSystemString(NamingTestMetadata.ColumnNames.TestAliasSpace);
			}
			
			set
			{
				if(base.SetSystemString(NamingTestMetadata.ColumnNames.TestAliasSpace, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestAliasSpace);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming.Test.Test_AliasUnderscore
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Test_Alias_Underscore
		{
			get
			{
				return base.GetSystemString(NamingTestMetadata.ColumnNames.Test_Alias_Underscore);
			}
			
			set
			{
				if(base.SetSystemString(NamingTestMetadata.ColumnNames.Test_Alias_Underscore, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.Test_Alias_Underscore);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming.Test.Test FieldSpace
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TestFieldSpace
		{
			get
			{
				return base.GetSystemString(NamingTestMetadata.ColumnNames.TestFieldSpace);
			}
			
			set
			{
				if(base.SetSystemString(NamingTestMetadata.ColumnNames.TestFieldSpace, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestFieldSpace);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming.Test.test_field_underscore
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TestFieldUnderscore
		{
			get
			{
				return base.GetSystemString(NamingTestMetadata.ColumnNames.TestFieldUnderscore);
			}
			
			set
			{
				if(base.SetSystemString(NamingTestMetadata.ColumnNames.TestFieldUnderscore, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestFieldUnderscore);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming.Test.TestAliasPascal
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TestAlias
		{
			get
			{
				return base.GetSystemString(NamingTestMetadata.ColumnNames.TestAlias);
			}
			
			set
			{
				if(base.SetSystemString(NamingTestMetadata.ColumnNames.TestAlias, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestAlias);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming.Test.GuidNonKey
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? GuidNonKey
		{
			get
			{
				return base.GetSystemGuid(NamingTestMetadata.ColumnNames.GuidNonKey);
			}
			
			set
			{
				if(base.SetSystemGuid(NamingTestMetadata.ColumnNames.GuidNonKey, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidNonKey);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Naming.Test.Test.FieldDot
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TestFieldDot
		{
			get
			{
				return base.GetSystemString(NamingTestMetadata.ColumnNames.TestFieldDot);
			}
			
			set
			{
				if(base.SetSystemString(NamingTestMetadata.ColumnNames.TestFieldDot, value))
				{
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestFieldDot);
				}
			}
		}		
		
		#endregion	

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "GuidKeyAlias": this.str().GuidKeyAlias = (string)value; break;							
						case "TestAliasSpace": this.str().TestAliasSpace = (string)value; break;							
						case "Test_Alias_Underscore": this.str().Test_Alias_Underscore = (string)value; break;							
						case "TestFieldSpace": this.str().TestFieldSpace = (string)value; break;							
						case "TestFieldUnderscore": this.str().TestFieldUnderscore = (string)value; break;							
						case "TestAlias": this.str().TestAlias = (string)value; break;							
						case "GuidNonKey": this.str().GuidNonKey = (string)value; break;							
						case "TestFieldDot": this.str().TestFieldDot = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "GuidKeyAlias":
						
							if (value == null || value is System.Guid)
								this.GuidKeyAlias = (System.Guid?)value;
								OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidKeyAlias);
							break;
						
						case "GuidNonKey":
						
							if (value == null || value is System.Guid)
								this.GuidNonKey = (System.Guid?)value;
								OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidNonKey);
							break;
					

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esNamingTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String GuidKeyAlias
			{
				get
				{
					System.Guid? data = entity.GuidKeyAlias;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GuidKeyAlias = null;
					else entity.GuidKeyAlias = new Guid(value);
				}
			}
				
			public System.String TestAliasSpace
			{
				get
				{
					System.String data = entity.TestAliasSpace;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TestAliasSpace = null;
					else entity.TestAliasSpace = Convert.ToString(value);
				}
			}
				
			public System.String Test_Alias_Underscore
			{
				get
				{
					System.String data = entity.Test_Alias_Underscore;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Test_Alias_Underscore = null;
					else entity.Test_Alias_Underscore = Convert.ToString(value);
				}
			}
				
			public System.String TestFieldSpace
			{
				get
				{
					System.String data = entity.TestFieldSpace;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TestFieldSpace = null;
					else entity.TestFieldSpace = Convert.ToString(value);
				}
			}
				
			public System.String TestFieldUnderscore
			{
				get
				{
					System.String data = entity.TestFieldUnderscore;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TestFieldUnderscore = null;
					else entity.TestFieldUnderscore = Convert.ToString(value);
				}
			}
				
			public System.String TestAlias
			{
				get
				{
					System.String data = entity.TestAlias;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TestAlias = null;
					else entity.TestAlias = Convert.ToString(value);
				}
			}
				
			public System.String GuidNonKey
			{
				get
				{
					System.Guid? data = entity.GuidNonKey;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.GuidNonKey = null;
					else entity.GuidNonKey = new Guid(value);
				}
			}
				
			public System.String TestFieldDot
			{
				get
				{
					System.String data = entity.TestFieldDot;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TestFieldDot = null;
					else entity.TestFieldDot = Convert.ToString(value);
				}
			}
			

			private esNamingTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return NamingTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public NamingTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NamingTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NamingTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(NamingTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private NamingTestQuery query;		
	}



	[Serializable]
	abstract public partial class esNamingTestCollection : CollectionBase<NamingTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return NamingTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "NamingTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public NamingTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NamingTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NamingTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new NamingTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(NamingTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((NamingTestQuery)query);
		}

		#endregion
		
		private NamingTestQuery query;
	}



	[Serializable]
	abstract public partial class esNamingTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return NamingTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "GuidKeyAlias": return this.GuidKeyAlias;
				case "TestAliasSpace": return this.TestAliasSpace;
				case "Test_Alias_Underscore": return this.Test_Alias_Underscore;
				case "TestFieldSpace": return this.TestFieldSpace;
				case "TestFieldUnderscore": return this.TestFieldUnderscore;
				case "TestAlias": return this.TestAlias;
				case "GuidNonKey": return this.GuidNonKey;
				case "TestFieldDot": return this.TestFieldDot;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem GuidKeyAlias
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.GuidKeyAlias, esSystemType.Guid); }
		} 
		
		public esQueryItem TestAliasSpace
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.TestAliasSpace, esSystemType.String); }
		} 
		
		public esQueryItem Test_Alias_Underscore
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.Test_Alias_Underscore, esSystemType.String); }
		} 
		
		public esQueryItem TestFieldSpace
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.TestFieldSpace, esSystemType.String); }
		} 
		
		public esQueryItem TestFieldUnderscore
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.TestFieldUnderscore, esSystemType.String); }
		} 
		
		public esQueryItem TestAlias
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.TestAlias, esSystemType.String); }
		} 
		
		public esQueryItem GuidNonKey
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.GuidNonKey, esSystemType.Guid); }
		} 
		
		public esQueryItem TestFieldDot
		{
			get { return new esQueryItem(this, NamingTestMetadata.ColumnNames.TestFieldDot, esSystemType.String); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTest")]
	[XmlType(TypeName="NamingTestProxyStub")]	
	[Serializable]
	public partial class NamingTestProxyStub
	{
		public NamingTestProxyStub() 
		{
			theEntity = this.entity = new NamingTest();
		}

		public NamingTestProxyStub(NamingTest obj)
		{
			theEntity = this.entity = obj;
		}

		public NamingTestProxyStub(NamingTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator NamingTest(NamingTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(NamingTest);
		}

		[DataMember(Name="GuidKeyAlias", Order=1, EmitDefaultValue=false)]
		public System.Guid? GuidKeyAlias
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Guid?)this.Entity.
						GetOriginalColumnValue(NamingTestMetadata.ColumnNames.GuidKeyAlias);
				else
					return this.Entity.GuidKeyAlias;
			}
			set { this.Entity.GuidKeyAlias = value; }
		}

		[DataMember(Name="TestAliasSpace", Order=2, EmitDefaultValue=false)]
		public System.String TestAliasSpace
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTestMetadata.ColumnNames.TestAliasSpace))
					return this.Entity.TestAliasSpace;
				else
					return null;
			}
			set { this.Entity.TestAliasSpace = value; }
		}

		[DataMember(Name="Test_Alias_Underscore", Order=3, EmitDefaultValue=false)]
		public System.String Test_Alias_Underscore
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTestMetadata.ColumnNames.Test_Alias_Underscore))
					return this.Entity.Test_Alias_Underscore;
				else
					return null;
			}
			set { this.Entity.Test_Alias_Underscore = value; }
		}

		[DataMember(Name="TestFieldSpace", Order=4, EmitDefaultValue=false)]
		public System.String TestFieldSpace
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTestMetadata.ColumnNames.TestFieldSpace))
					return this.Entity.TestFieldSpace;
				else
					return null;
			}
			set { this.Entity.TestFieldSpace = value; }
		}

		[DataMember(Name="TestFieldUnderscore", Order=5, EmitDefaultValue=false)]
		public System.String TestFieldUnderscore
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTestMetadata.ColumnNames.TestFieldUnderscore))
					return this.Entity.TestFieldUnderscore;
				else
					return null;
			}
			set { this.Entity.TestFieldUnderscore = value; }
		}

		[DataMember(Name="TestAlias", Order=6, EmitDefaultValue=false)]
		public System.String TestAlias
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTestMetadata.ColumnNames.TestAlias))
					return this.Entity.TestAlias;
				else
					return null;
			}
			set { this.Entity.TestAlias = value; }
		}

		[DataMember(Name="GuidNonKey", Order=7, EmitDefaultValue=false)]
		public System.Guid? GuidNonKey
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTestMetadata.ColumnNames.GuidNonKey))
					return this.Entity.GuidNonKey;
				else
					return null;
			}
			set { this.Entity.GuidNonKey = value; }
		}

		[DataMember(Name="TestFieldDot", Order=8, EmitDefaultValue=false)]
		public System.String TestFieldDot
		{
			get 
			{ 
				
				if (this.IncludeColumn(NamingTestMetadata.ColumnNames.TestFieldDot))
					return this.Entity.TestFieldDot;
				else
					return null;
			}
			set { this.Entity.TestFieldDot = value; }
		}


		[DataMember(Name="esRowState", Order=10000)]
		public string esRowState
		{
			get { return TheRowState;  }
			set { TheRowState = value; }
		}
		
		[DataMember(Name="ModifiedColumns", Order=10001, EmitDefaultValue=false)]
		private List<string> ModifiedColumns
		{
			get { return Entity.es.ModifiedColumns; }
			set 
			{ 
				Entity.es.ModifiedColumns.AddRange(value); 
			}
		}
		
		[DataMember(Name="ExtraColumns", Order=10002, EmitDefaultValue=false)]
		[XmlIgnore]		
		public Dictionary<string, object> esExtraColumns
		{
			get { return Entity.GetExtraColumns(); }
			set { Entity.SetExtraColumns(value);   }
		}
		
		[XmlArray("_x_ExtraColumns")]
		[XmlArrayItem("_x_ExtraColumns", Type = typeof(DictionaryEntry))]
		public DictionaryEntry[] _x_ExtraColumns
		{
			get
			{
				Dictionary<string, object> extra = Entity.GetExtraColumns();

				// Make an array of DictionaryEntries to return   
				DictionaryEntry[] ret = new DictionaryEntry[extra.Count];
				int i = 0;
				DictionaryEntry de;

				// Iterate through the extra columns to load items into the array.   
				foreach (KeyValuePair<string, object> kv in extra)
				{
					de = new DictionaryEntry();
					de.Key = kv.Key;
					de.Value = kv.Value;
					ret[i] = de;
					i++;
				}
				return ret;
			}
			set
			{
				Dictionary<string, object> extra = new Dictionary<string, object>();
				for (int i = 0; i < value.Length; i++)
				{
					extra.Add((string)value[i].Key, (int)value[i].Value);
				}
				Entity.SetExtraColumns(extra);
			}
		}	

		[XmlIgnore]
		public NamingTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new NamingTest();
				}

				return this.entity;
			}

			set
			{
				this.entity = value;
			}
		}
		
		protected string TheRowState
		{
			get
			{
				return theEntity.es.RowState.ToString();
			}

			set
			{
				switch (value)
				{
					case "Unchanged":
						theEntity.AcceptChanges();
						break;

					case "Added":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Added;
						break;

					case "Modified":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Modified;
						break;

					case "Deleted":
						theEntity.AcceptChanges();
						theEntity.MarkAsDeleted();
						break;
				}
			}
		}		
		
		protected bool IncludeColumn(string columnName)
		{
			bool include = false;

			if (dirtyColumnsOnly)
			{
				if (theEntity.es.ModifiedColumns != null &&
					theEntity.es.ModifiedColumns.Contains(columnName))
				{
					include = true;
				}
			}
			else if (!theEntity.es.IsDeleted)
			{
				include = true;
			}

			return include;
		}		

		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		public NamingTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "NamingTestCollection")]
	[XmlType(TypeName="NamingTestCollectionProxyStub")]	
	[Serializable]
	public partial class NamingTestCollectionProxyStub 
	{
		protected NamingTestCollectionProxyStub() {}
		
		public NamingTestCollectionProxyStub(esEntityCollection<NamingTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public NamingTestCollectionProxyStub(esEntityCollection<NamingTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator NamingTestCollection(NamingTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(NamingTest);
		}
		
		public NamingTestCollectionProxyStub(esEntityCollection<NamingTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (NamingTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new NamingTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new NamingTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (NamingTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new NamingTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<NamingTestProxyStub> Collection = new List<NamingTestProxyStub>();

		public NamingTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new NamingTestCollection();

				foreach (NamingTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private NamingTestCollection _coll;
	}



	[Serializable]
	public partial class NamingTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected NamingTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.GuidKeyAlias, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = NamingTestMetadata.PropertyNames.GuidKeyAlias;
			c.IsInPrimaryKey = true;
			c.HasDefault = true;
			c.Default = @"(newid())";
			c.Alias = "GuidKeyAlias";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.TestAliasSpace, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = NamingTestMetadata.PropertyNames.TestAliasSpace;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			c.Alias = "TestAliasSpace";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.Test_Alias_Underscore, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = NamingTestMetadata.PropertyNames.Test_Alias_Underscore;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			c.Alias = "Test_Alias_Underscore";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.TestFieldSpace, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = NamingTestMetadata.PropertyNames.TestFieldSpace;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.TestFieldUnderscore, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = NamingTestMetadata.PropertyNames.TestFieldUnderscore;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.TestAlias, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = NamingTestMetadata.PropertyNames.TestAlias;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			c.Alias = "TestAlias";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.GuidNonKey, 6, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = NamingTestMetadata.PropertyNames.GuidNonKey;
			c.HasDefault = true;
			c.Default = @"(newid())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(NamingTestMetadata.ColumnNames.TestFieldDot, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = NamingTestMetadata.PropertyNames.TestFieldDot;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public NamingTestMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return true; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string GuidKeyAlias = "GuidKey";
			 public const string TestAliasSpace = "Test AliasSpace";
			 public const string Test_Alias_Underscore = "Test_AliasUnderscore";
			 public const string TestFieldSpace = "Test FieldSpace";
			 public const string TestFieldUnderscore = "test_field_underscore";
			 public const string TestAlias = "TestAliasPascal";
			 public const string GuidNonKey = "GuidNonKey";
			 public const string TestFieldDot = "Test.FieldDot";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GuidKeyAlias = "GuidKeyAlias";
			 public const string TestAliasSpace = "TestAliasSpace";
			 public const string Test_Alias_Underscore = "Test_Alias_Underscore";
			 public const string TestFieldSpace = "TestFieldSpace";
			 public const string TestFieldUnderscore = "TestFieldUnderscore";
			 public const string TestAlias = "TestAlias";
			 public const string GuidNonKey = "GuidNonKey";
			 public const string TestFieldDot = "TestFieldDot";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(NamingTestMetadata))
			{
				if(NamingTestMetadata.mapDelegates == null)
				{
					NamingTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (NamingTestMetadata.meta == null)
				{
					NamingTestMetadata.meta = new NamingTestMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("GuidKeyAlias", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("TestAliasSpace", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("Test_Alias_Underscore", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("TestFieldSpace", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("TestFieldUnderscore", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("TestAlias", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("GuidNonKey", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("TestFieldDot", new esTypeMap("nchar", "System.String"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "Naming.Test";
				meta.Destination = "Naming.Test";
				
				meta.spInsert = "proc_Naming.TestInsert";				
				meta.spUpdate = "proc_Naming.TestUpdate";		
				meta.spDelete = "proc_Naming.TestDelete";
				meta.spLoadAll = "proc_Naming.TestLoadAll";
				meta.spLoadByPrimaryKey = "proc_Naming.TestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private NamingTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
