
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:43:26 AM
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
	/// Test table description Multi-line test "C:\Test\"
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(AggregateTest))]	
	[XmlType("AggregateTest")]
	[Table(Name="AggregateTest")]
	public partial class AggregateTest : esAggregateTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new AggregateTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new AggregateTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new AggregateTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator AggregateTestProxyStub(AggregateTest entity)
		{
			return new AggregateTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? DepartmentID
		{
			get { return base.DepartmentID;  }
			set { base.DepartmentID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String FirstName
		{
			get { return base.FirstName;  }
			set { base.FirstName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String LastName
		{
			get { return base.LastName;  }
			set { base.LastName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? Age
		{
			get { return base.Age;  }
			set { base.Age = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? HireDate
		{
			get { return base.HireDate;  }
			set { base.HireDate = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? Salary
		{
			get { return base.Salary;  }
			set { base.Salary = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Boolean? IsActive
		{
			get { return base.IsActive;  }
			set { base.IsActive = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("AggregateTestCollection")]
	public partial class AggregateTestCollection : esAggregateTestCollection, IEnumerable<AggregateTest>
	{
		public AggregateTest FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator AggregateTestCollectionProxyStub(AggregateTestCollection coll)
		{
			return new AggregateTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(AggregateTest))]
		public class AggregateTestCollectionWCFPacket : esCollectionWCFPacket<AggregateTestCollection>
		{
			public static implicit operator AggregateTestCollection(AggregateTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AggregateTestCollectionWCFPacket(AggregateTestCollection collection)
			{
				return new AggregateTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "AggregateTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class AggregateTestQuery : esAggregateTestQuery
	{
		public AggregateTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AggregateTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AggregateTestQuery query)
		{
			return AggregateTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AggregateTestQuery(string query)
		{
			return (AggregateTestQuery)AggregateTestQuery.SerializeHelper.FromXml(query, typeof(AggregateTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAggregateTest : EntityBase
	{
		public esAggregateTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			AggregateTestQuery query = new AggregateTestQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to AggregateTest.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(AggregateTestMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(AggregateTestMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AggregateTest.DepartmentID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? DepartmentID
		{
			get
			{
				return base.GetSystemInt32(AggregateTestMetadata.ColumnNames.DepartmentID);
			}
			
			set
			{
				if(base.SetSystemInt32(AggregateTestMetadata.ColumnNames.DepartmentID, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.DepartmentID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AggregateTest.FirstName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(AggregateTestMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(AggregateTestMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.FirstName);
				}
			}
		}		
		
		/// <summary>
		/// LastName column Multi-line test. "C:\Test\"
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(AggregateTestMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(AggregateTestMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AggregateTest.Age
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Age
		{
			get
			{
				return base.GetSystemInt32(AggregateTestMetadata.ColumnNames.Age);
			}
			
			set
			{
				if(base.SetSystemInt32(AggregateTestMetadata.ColumnNames.Age, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.Age);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AggregateTest.HireDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? HireDate
		{
			get
			{
				return base.GetSystemDateTime(AggregateTestMetadata.ColumnNames.HireDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(AggregateTestMetadata.ColumnNames.HireDate, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.HireDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AggregateTest.Salary
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Salary
		{
			get
			{
				return base.GetSystemDecimal(AggregateTestMetadata.ColumnNames.Salary);
			}
			
			set
			{
				if(base.SetSystemDecimal(AggregateTestMetadata.ColumnNames.Salary, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.Salary);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AggregateTest.IsActive
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? IsActive
		{
			get
			{
				return base.GetSystemBoolean(AggregateTestMetadata.ColumnNames.IsActive);
			}
			
			set
			{
				if(base.SetSystemBoolean(AggregateTestMetadata.ColumnNames.IsActive, value))
				{
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.IsActive);
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
						case "Id": this.str().Id = (string)value; break;							
						case "DepartmentID": this.str().DepartmentID = (string)value; break;							
						case "FirstName": this.str().FirstName = (string)value; break;							
						case "LastName": this.str().LastName = (string)value; break;							
						case "Age": this.str().Age = (string)value; break;							
						case "HireDate": this.str().HireDate = (string)value; break;							
						case "Salary": this.str().Salary = (string)value; break;							
						case "IsActive": this.str().IsActive = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.Id);
							break;
						
						case "DepartmentID":
						
							if (value == null || value is System.Int32)
								this.DepartmentID = (System.Int32?)value;
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.DepartmentID);
							break;
						
						case "Age":
						
							if (value == null || value is System.Int32)
								this.Age = (System.Int32?)value;
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.Age);
							break;
						
						case "HireDate":
						
							if (value == null || value is System.DateTime)
								this.HireDate = (System.DateTime?)value;
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.HireDate);
							break;
						
						case "Salary":
						
							if (value == null || value is System.Decimal)
								this.Salary = (System.Decimal?)value;
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.Salary);
							break;
						
						case "IsActive":
						
							if (value == null || value is System.Boolean)
								this.IsActive = (System.Boolean?)value;
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.IsActive);
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
			public esStrings(esAggregateTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String DepartmentID
			{
				get
				{
					System.Int32? data = entity.DepartmentID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DepartmentID = null;
					else entity.DepartmentID = Convert.ToInt32(value);
				}
			}
				
			public System.String FirstName
			{
				get
				{
					System.String data = entity.FirstName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FirstName = null;
					else entity.FirstName = Convert.ToString(value);
				}
			}
				
			public System.String LastName
			{
				get
				{
					System.String data = entity.LastName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastName = null;
					else entity.LastName = Convert.ToString(value);
				}
			}
				
			public System.String Age
			{
				get
				{
					System.Int32? data = entity.Age;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Age = null;
					else entity.Age = Convert.ToInt32(value);
				}
			}
				
			public System.String HireDate
			{
				get
				{
					System.DateTime? data = entity.HireDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.HireDate = null;
					else entity.HireDate = Convert.ToDateTime(value);
				}
			}
				
			public System.String Salary
			{
				get
				{
					System.Decimal? data = entity.Salary;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Salary = null;
					else entity.Salary = Convert.ToDecimal(value);
				}
			}
				
			public System.String IsActive
			{
				get
				{
					System.Boolean? data = entity.IsActive;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsActive = null;
					else entity.IsActive = Convert.ToBoolean(value);
				}
			}
			

			private esAggregateTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AggregateTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AggregateTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AggregateTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AggregateTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AggregateTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AggregateTestQuery query;		
	}



	[Serializable]
	abstract public partial class esAggregateTestCollection : CollectionBase<AggregateTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AggregateTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AggregateTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AggregateTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AggregateTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AggregateTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AggregateTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AggregateTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AggregateTestQuery)query);
		}

		#endregion
		
		private AggregateTestQuery query;
	}



	[Serializable]
	abstract public partial class esAggregateTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return AggregateTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "DepartmentID": return this.DepartmentID;
				case "FirstName": return this.FirstName;
				case "LastName": return this.LastName;
				case "Age": return this.Age;
				case "HireDate": return this.HireDate;
				case "Salary": return this.Salary;
				case "IsActive": return this.IsActive;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem DepartmentID
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.DepartmentID, esSystemType.Int32); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.Age, esSystemType.Int32); }
		} 
		
		public esQueryItem HireDate
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.HireDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem Salary
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.Salary, esSystemType.Decimal); }
		} 
		
		public esQueryItem IsActive
		{
			get { return new esQueryItem(this, AggregateTestMetadata.ColumnNames.IsActive, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "AggregateTest")]
	[XmlType(TypeName="AggregateTestProxyStub")]	
	[Serializable]
	public partial class AggregateTestProxyStub
	{
		public AggregateTestProxyStub() 
		{
			theEntity = this.entity = new AggregateTest();
		}

		public AggregateTestProxyStub(AggregateTest obj)
		{
			theEntity = this.entity = obj;
		}

		public AggregateTestProxyStub(AggregateTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator AggregateTest(AggregateTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(AggregateTest);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.Int32? Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(AggregateTestMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="DepartmentID", Order=2, EmitDefaultValue=false)]
		public System.Int32? DepartmentID
		{
			get 
			{ 
				
				if (this.IncludeColumn(AggregateTestMetadata.ColumnNames.DepartmentID))
					return this.Entity.DepartmentID;
				else
					return null;
			}
			set { this.Entity.DepartmentID = value; }
		}

		[DataMember(Name="FirstName", Order=3, EmitDefaultValue=false)]
		public System.String FirstName
		{
			get 
			{ 
				
				if (this.IncludeColumn(AggregateTestMetadata.ColumnNames.FirstName))
					return this.Entity.FirstName;
				else
					return null;
			}
			set { this.Entity.FirstName = value; }
		}

		[DataMember(Name="LastName", Order=4, EmitDefaultValue=false)]
		public System.String LastName
		{
			get 
			{ 
				
				if (this.IncludeColumn(AggregateTestMetadata.ColumnNames.LastName))
					return this.Entity.LastName;
				else
					return null;
			}
			set { this.Entity.LastName = value; }
		}

		[DataMember(Name="Age", Order=5, EmitDefaultValue=false)]
		public System.Int32? Age
		{
			get 
			{ 
				
				if (this.IncludeColumn(AggregateTestMetadata.ColumnNames.Age))
					return this.Entity.Age;
				else
					return null;
			}
			set { this.Entity.Age = value; }
		}

		[DataMember(Name="HireDate", Order=6, EmitDefaultValue=false)]
		public System.DateTime? HireDate
		{
			get 
			{ 
				
				if (this.IncludeColumn(AggregateTestMetadata.ColumnNames.HireDate))
					return this.Entity.HireDate;
				else
					return null;
			}
			set { this.Entity.HireDate = value; }
		}

		[DataMember(Name="Salary", Order=7, EmitDefaultValue=false)]
		public System.Decimal? Salary
		{
			get 
			{ 
				
				if (this.IncludeColumn(AggregateTestMetadata.ColumnNames.Salary))
					return this.Entity.Salary;
				else
					return null;
			}
			set { this.Entity.Salary = value; }
		}

		[DataMember(Name="IsActive", Order=8, EmitDefaultValue=false)]
		public System.Boolean? IsActive
		{
			get 
			{ 
				
				if (this.IncludeColumn(AggregateTestMetadata.ColumnNames.IsActive))
					return this.Entity.IsActive;
				else
					return null;
			}
			set { this.Entity.IsActive = value; }
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
		public AggregateTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new AggregateTest();
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
		public AggregateTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "AggregateTestCollection")]
	[XmlType(TypeName="AggregateTestCollectionProxyStub")]	
	[Serializable]
	public partial class AggregateTestCollectionProxyStub 
	{
		protected AggregateTestCollectionProxyStub() {}
		
		public AggregateTestCollectionProxyStub(esEntityCollection<AggregateTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public AggregateTestCollectionProxyStub(esEntityCollection<AggregateTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator AggregateTestCollection(AggregateTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(AggregateTest);
		}
		
		public AggregateTestCollectionProxyStub(esEntityCollection<AggregateTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (AggregateTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new AggregateTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new AggregateTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (AggregateTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new AggregateTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<AggregateTestProxyStub> Collection = new List<AggregateTestProxyStub>();

		public AggregateTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new AggregateTestCollection();

				foreach (AggregateTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private AggregateTestCollection _coll;
	}



	[Serializable]
	public partial class AggregateTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AggregateTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AggregateTestMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.DepartmentID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AggregateTestMetadata.PropertyNames.DepartmentID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.FirstName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = AggregateTestMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 25;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.LastName, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = AggregateTestMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 15;
			c.Description = "LastName column Multi-line test. \"C:\\Test\\\"";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.Age, 4, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AggregateTestMetadata.PropertyNames.Age;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.HireDate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = AggregateTestMetadata.PropertyNames.HireDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.Salary, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = AggregateTestMetadata.PropertyNames.Salary;
			c.NumericPrecision = 8;
			c.NumericScale = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AggregateTestMetadata.ColumnNames.IsActive, 7, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = AggregateTestMetadata.PropertyNames.IsActive;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AggregateTestMetadata Meta()
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
			 public const string Id = "ID";
			 public const string DepartmentID = "DepartmentID";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Age = "Age";
			 public const string HireDate = "HireDate";
			 public const string Salary = "Salary";
			 public const string IsActive = "IsActive";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string DepartmentID = "DepartmentID";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Age = "Age";
			 public const string HireDate = "HireDate";
			 public const string Salary = "Salary";
			 public const string IsActive = "IsActive";
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
			lock (typeof(AggregateTestMetadata))
			{
				if(AggregateTestMetadata.mapDelegates == null)
				{
					AggregateTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AggregateTestMetadata.meta == null)
				{
					AggregateTestMetadata.meta = new AggregateTestMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("HireDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("bit", "System.Boolean"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "AggregateTest";
				meta.Destination = "AggregateTest";
				
				meta.spInsert = "proc_AggregateTestInsert";				
				meta.spUpdate = "proc_AggregateTestUpdate";		
				meta.spDelete = "proc_AggregateTestDelete";
				meta.spLoadAll = "proc_AggregateTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_AggregateTestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AggregateTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
