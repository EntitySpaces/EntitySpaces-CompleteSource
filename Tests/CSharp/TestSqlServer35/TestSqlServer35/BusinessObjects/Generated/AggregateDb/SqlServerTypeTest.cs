
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
	/// Encapsulates the 'SqlServerTypeTest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(SqlServerTypeTest))]	
	[XmlType("SqlServerTypeTest")]
	[Table(Name="SqlServerTypeTest")]
	public partial class SqlServerTypeTest : esSqlServerTypeTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new SqlServerTypeTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int64 id)
		{
			var obj = new SqlServerTypeTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int64 id, esSqlAccessType sqlAccessType)
		{
			var obj = new SqlServerTypeTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator SqlServerTypeTestProxyStub(SqlServerTypeTest entity)
		{
			return new SqlServerTypeTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int64? Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Byte[] ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String NVarCharType
		{
			get { return base.NVarCharType;  }
			set { base.NVarCharType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? NumericType
		{
			get { return base.NumericType;  }
			set { base.NumericType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Single? RealType
		{
			get { return base.RealType;  }
			set { base.RealType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Double? FloatType
		{
			get { return base.FloatType;  }
			set { base.FloatType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? DecimalType
		{
			get { return base.DecimalType;  }
			set { base.DecimalType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String VarCharMaxType
		{
			get { return base.VarCharMaxType;  }
			set { base.VarCharMaxType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int64? BigIntType
		{
			get { return base.BigIntType;  }
			set { base.BigIntType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Char? NCharType
		{
			get { return base.NCharType;  }
			set { base.NCharType = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("SqlServerTypeTestCollection")]
	public partial class SqlServerTypeTestCollection : esSqlServerTypeTestCollection, IEnumerable<SqlServerTypeTest>
	{
		public SqlServerTypeTest FindByPrimaryKey(System.Int64 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator SqlServerTypeTestCollectionProxyStub(SqlServerTypeTestCollection coll)
		{
			return new SqlServerTypeTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(SqlServerTypeTest))]
		public class SqlServerTypeTestCollectionWCFPacket : esCollectionWCFPacket<SqlServerTypeTestCollection>
		{
			public static implicit operator SqlServerTypeTestCollection(SqlServerTypeTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator SqlServerTypeTestCollectionWCFPacket(SqlServerTypeTestCollection collection)
			{
				return new SqlServerTypeTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "SqlServerTypeTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class SqlServerTypeTestQuery : esSqlServerTypeTestQuery
	{
		public SqlServerTypeTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "SqlServerTypeTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(SqlServerTypeTestQuery query)
		{
			return SqlServerTypeTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator SqlServerTypeTestQuery(string query)
		{
			return (SqlServerTypeTestQuery)SqlServerTypeTestQuery.SerializeHelper.FromXml(query, typeof(SqlServerTypeTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esSqlServerTypeTest : EntityBase
	{
		public esSqlServerTypeTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 id)
		{
			SqlServerTypeTestQuery query = new SqlServerTypeTestQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.ConcurrencyCheck
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte[] ConcurrencyCheck
		{
			get
			{
				return base.GetSystemByteArray(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemByteArray(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.NVarCharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String NVarCharType
		{
			get
			{
				return base.GetSystemString(SqlServerTypeTestMetadata.ColumnNames.NVarCharType);
			}
			
			set
			{
				if(base.SetSystemString(SqlServerTypeTestMetadata.ColumnNames.NVarCharType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NVarCharType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.NumericType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? NumericType
		{
			get
			{
				return base.GetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.NumericType);
			}
			
			set
			{
				if(base.SetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.NumericType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NumericType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.RealType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Single? RealType
		{
			get
			{
				return base.GetSystemSingle(SqlServerTypeTestMetadata.ColumnNames.RealType);
			}
			
			set
			{
				if(base.SetSystemSingle(SqlServerTypeTestMetadata.ColumnNames.RealType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.RealType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.FloatType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? FloatType
		{
			get
			{
				return base.GetSystemDouble(SqlServerTypeTestMetadata.ColumnNames.FloatType);
			}
			
			set
			{
				if(base.SetSystemDouble(SqlServerTypeTestMetadata.ColumnNames.FloatType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.FloatType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.DecimalType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? DecimalType
		{
			get
			{
				return base.GetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.DecimalType);
			}
			
			set
			{
				if(base.SetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.DecimalType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.DecimalType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.VarCharMaxType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String VarCharMaxType
		{
			get
			{
				return base.GetSystemString(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType);
			}
			
			set
			{
				if(base.SetSystemString(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.VarCharMaxType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.BigIntType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? BigIntType
		{
			get
			{
				return base.GetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.BigIntType);
			}
			
			set
			{
				if(base.SetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.BigIntType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.BigIntType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to SqlServerTypeTest.NCharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Char? NCharType
		{
			get
			{
				return base.GetSystemChar(SqlServerTypeTestMetadata.ColumnNames.NCharType);
			}
			
			set
			{
				if(base.SetSystemChar(SqlServerTypeTestMetadata.ColumnNames.NCharType, value))
				{
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NCharType);
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
						case "NVarCharType": this.str().NVarCharType = (string)value; break;							
						case "NumericType": this.str().NumericType = (string)value; break;							
						case "RealType": this.str().RealType = (string)value; break;							
						case "FloatType": this.str().FloatType = (string)value; break;							
						case "DecimalType": this.str().DecimalType = (string)value; break;							
						case "VarCharMaxType": this.str().VarCharMaxType = (string)value; break;							
						case "BigIntType": this.str().BigIntType = (string)value; break;							
						case "NCharType": this.str().NCharType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.Id);
							break;
						
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Byte[])
								this.ConcurrencyCheck = (System.Byte[])value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.ConcurrencyCheck);
							break;
						
						case "NumericType":
						
							if (value == null || value is System.Decimal)
								this.NumericType = (System.Decimal?)value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NumericType);
							break;
						
						case "RealType":
						
							if (value == null || value is System.Single)
								this.RealType = (System.Single?)value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.RealType);
							break;
						
						case "FloatType":
						
							if (value == null || value is System.Double)
								this.FloatType = (System.Double?)value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.FloatType);
							break;
						
						case "DecimalType":
						
							if (value == null || value is System.Decimal)
								this.DecimalType = (System.Decimal?)value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.DecimalType);
							break;
						
						case "BigIntType":
						
							if (value == null || value is System.Int64)
								this.BigIntType = (System.Int64?)value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.BigIntType);
							break;
						
						case "NCharType":
						
							if (value == null || value is System.Char)
								this.NCharType = (System.Char?)value;
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NCharType);
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
			public esStrings(esSqlServerTypeTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int64? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt64(value);
				}
			}
				
			public System.String NVarCharType
			{
				get
				{
					System.String data = entity.NVarCharType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NVarCharType = null;
					else entity.NVarCharType = Convert.ToString(value);
				}
			}
				
			public System.String NumericType
			{
				get
				{
					System.Decimal? data = entity.NumericType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NumericType = null;
					else entity.NumericType = Convert.ToDecimal(value);
				}
			}
				
			public System.String RealType
			{
				get
				{
					System.Single? data = entity.RealType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RealType = null;
					else entity.RealType = Convert.ToSingle(value);
				}
			}
				
			public System.String FloatType
			{
				get
				{
					System.Double? data = entity.FloatType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FloatType = null;
					else entity.FloatType = Convert.ToDouble(value);
				}
			}
				
			public System.String DecimalType
			{
				get
				{
					System.Decimal? data = entity.DecimalType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DecimalType = null;
					else entity.DecimalType = Convert.ToDecimal(value);
				}
			}
				
			public System.String VarCharMaxType
			{
				get
				{
					System.String data = entity.VarCharMaxType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.VarCharMaxType = null;
					else entity.VarCharMaxType = Convert.ToString(value);
				}
			}
				
			public System.String BigIntType
			{
				get
				{
					System.Int64? data = entity.BigIntType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.BigIntType = null;
					else entity.BigIntType = Convert.ToInt64(value);
				}
			}
				
			public System.String NCharType
			{
				get
				{
					System.Char? data = entity.NCharType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NCharType = null;
					else entity.NCharType = Convert.ToChar(value);
				}
			}
			

			private esSqlServerTypeTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return SqlServerTypeTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public SqlServerTypeTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SqlServerTypeTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SqlServerTypeTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(SqlServerTypeTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private SqlServerTypeTestQuery query;		
	}



	[Serializable]
	abstract public partial class esSqlServerTypeTestCollection : CollectionBase<SqlServerTypeTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return SqlServerTypeTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "SqlServerTypeTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public SqlServerTypeTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new SqlServerTypeTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(SqlServerTypeTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new SqlServerTypeTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(SqlServerTypeTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((SqlServerTypeTestQuery)query);
		}

		#endregion
		
		private SqlServerTypeTestQuery query;
	}



	[Serializable]
	abstract public partial class esSqlServerTypeTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return SqlServerTypeTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;
				case "NVarCharType": return this.NVarCharType;
				case "NumericType": return this.NumericType;
				case "RealType": return this.RealType;
				case "FloatType": return this.FloatType;
				case "DecimalType": return this.DecimalType;
				case "VarCharMaxType": return this.VarCharMaxType;
				case "BigIntType": return this.BigIntType;
				case "NCharType": return this.NCharType;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.Id, esSystemType.Int64); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray); }
		} 
		
		public esQueryItem NVarCharType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.NVarCharType, esSystemType.String); }
		} 
		
		public esQueryItem NumericType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.NumericType, esSystemType.Decimal); }
		} 
		
		public esQueryItem RealType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.RealType, esSystemType.Single); }
		} 
		
		public esQueryItem FloatType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.FloatType, esSystemType.Double); }
		} 
		
		public esQueryItem DecimalType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.DecimalType, esSystemType.Decimal); }
		} 
		
		public esQueryItem VarCharMaxType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType, esSystemType.String); }
		} 
		
		public esQueryItem BigIntType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.BigIntType, esSystemType.Int64); }
		} 
		
		public esQueryItem NCharType
		{
			get { return new esQueryItem(this, SqlServerTypeTestMetadata.ColumnNames.NCharType, esSystemType.Char); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "SqlServerTypeTest")]
	[XmlType(TypeName="SqlServerTypeTestProxyStub")]	
	[Serializable]
	public partial class SqlServerTypeTestProxyStub
	{
		public SqlServerTypeTestProxyStub() 
		{
			theEntity = this.entity = new SqlServerTypeTest();
		}

		public SqlServerTypeTestProxyStub(SqlServerTypeTest obj)
		{
			theEntity = this.entity = obj;
		}

		public SqlServerTypeTestProxyStub(SqlServerTypeTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator SqlServerTypeTest(SqlServerTypeTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(SqlServerTypeTest);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.Int64? Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int64?)this.Entity.
						GetOriginalColumnValue(SqlServerTypeTestMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=2, EmitDefaultValue=false)]
		public System.Byte[] ConcurrencyCheck
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Byte[])this.Entity.
						GetOriginalColumnValue(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck);
				else
					return this.Entity.ConcurrencyCheck;
			}
			set { this.Entity.ConcurrencyCheck = value; }
		}

		[DataMember(Name="NVarCharType", Order=3, EmitDefaultValue=false)]
		public System.String NVarCharType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.NVarCharType))
					return this.Entity.NVarCharType;
				else
					return null;
			}
			set { this.Entity.NVarCharType = value; }
		}

		[DataMember(Name="NumericType", Order=4, EmitDefaultValue=false)]
		public System.Decimal? NumericType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.NumericType))
					return this.Entity.NumericType;
				else
					return null;
			}
			set { this.Entity.NumericType = value; }
		}

		[DataMember(Name="RealType", Order=5, EmitDefaultValue=false)]
		public System.Single? RealType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.RealType))
					return this.Entity.RealType;
				else
					return null;
			}
			set { this.Entity.RealType = value; }
		}

		[DataMember(Name="FloatType", Order=6, EmitDefaultValue=false)]
		public System.Double? FloatType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.FloatType))
					return this.Entity.FloatType;
				else
					return null;
			}
			set { this.Entity.FloatType = value; }
		}

		[DataMember(Name="DecimalType", Order=7, EmitDefaultValue=false)]
		public System.Decimal? DecimalType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.DecimalType))
					return this.Entity.DecimalType;
				else
					return null;
			}
			set { this.Entity.DecimalType = value; }
		}

		[DataMember(Name="VarCharMaxType", Order=8, EmitDefaultValue=false)]
		public System.String VarCharMaxType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType))
					return this.Entity.VarCharMaxType;
				else
					return null;
			}
			set { this.Entity.VarCharMaxType = value; }
		}

		[DataMember(Name="BigIntType", Order=9, EmitDefaultValue=false)]
		public System.Int64? BigIntType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.BigIntType))
					return this.Entity.BigIntType;
				else
					return null;
			}
			set { this.Entity.BigIntType = value; }
		}

		[DataMember(Name="NCharType", Order=10, EmitDefaultValue=false)]
		public System.Char? NCharType
		{
			get 
			{ 
				
				if (this.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.NCharType))
					return this.Entity.NCharType;
				else
					return null;
			}
			set { this.Entity.NCharType = value; }
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
		public SqlServerTypeTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new SqlServerTypeTest();
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
		public SqlServerTypeTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "SqlServerTypeTestCollection")]
	[XmlType(TypeName="SqlServerTypeTestCollectionProxyStub")]	
	[Serializable]
	public partial class SqlServerTypeTestCollectionProxyStub 
	{
		protected SqlServerTypeTestCollectionProxyStub() {}
		
		public SqlServerTypeTestCollectionProxyStub(esEntityCollection<SqlServerTypeTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public SqlServerTypeTestCollectionProxyStub(esEntityCollection<SqlServerTypeTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator SqlServerTypeTestCollection(SqlServerTypeTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(SqlServerTypeTest);
		}
		
		public SqlServerTypeTestCollectionProxyStub(esEntityCollection<SqlServerTypeTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (SqlServerTypeTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new SqlServerTypeTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new SqlServerTypeTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (SqlServerTypeTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new SqlServerTypeTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<SqlServerTypeTestProxyStub> Collection = new List<SqlServerTypeTestProxyStub>();

		public SqlServerTypeTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new SqlServerTypeTestCollection();

				foreach (SqlServerTypeTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private SqlServerTypeTestCollection _coll;
	}



	[Serializable]
	public partial class SqlServerTypeTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected SqlServerTypeTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck, 1, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.ConcurrencyCheck;
			c.CharacterMaxLength = 8;
			c.IsComputed = true;
			c.IsConcurrency = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.NVarCharType, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.NVarCharType;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.NumericType, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.NumericType;
			c.NumericPrecision = 18;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.RealType, 4, typeof(System.Single), esSystemType.Single);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.RealType;
			c.NumericPrecision = 7;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.FloatType, 5, typeof(System.Double), esSystemType.Double);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.FloatType;
			c.NumericPrecision = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.DecimalType, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.DecimalType;
			c.NumericPrecision = 18;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.VarCharMaxType;
			c.CharacterMaxLength = 2147483647;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.BigIntType, 8, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.BigIntType;
			c.NumericPrecision = 19;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.NCharType, 9, typeof(System.Char), esSystemType.Char);
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.NCharType;
			c.CharacterMaxLength = 1;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public SqlServerTypeTestMetadata Meta()
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
			 public const string Id = "Id";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string NVarCharType = "NVarCharType";
			 public const string NumericType = "NumericType";
			 public const string RealType = "RealType";
			 public const string FloatType = "FloatType";
			 public const string DecimalType = "DecimalType";
			 public const string VarCharMaxType = "VarCharMaxType";
			 public const string BigIntType = "BigIntType";
			 public const string NCharType = "NCharType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string NVarCharType = "NVarCharType";
			 public const string NumericType = "NumericType";
			 public const string RealType = "RealType";
			 public const string FloatType = "FloatType";
			 public const string DecimalType = "DecimalType";
			 public const string VarCharMaxType = "VarCharMaxType";
			 public const string BigIntType = "BigIntType";
			 public const string NCharType = "NCharType";
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
			lock (typeof(SqlServerTypeTestMetadata))
			{
				if(SqlServerTypeTestMetadata.mapDelegates == null)
				{
					SqlServerTypeTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SqlServerTypeTestMetadata.meta == null)
				{
					SqlServerTypeTestMetadata.meta = new SqlServerTypeTestMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte[]"));
				meta.AddTypeMap("NVarCharType", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("NumericType", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("RealType", new esTypeMap("real", "System.Single"));
				meta.AddTypeMap("FloatType", new esTypeMap("float", "System.Double"));
				meta.AddTypeMap("DecimalType", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("VarCharMaxType", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("BigIntType", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("NCharType", new esTypeMap("nchar", "System.Char"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "SqlServerTypeTest";
				meta.Destination = "SqlServerTypeTest";
				
				meta.spInsert = "proc_SqlServerTypeTestInsert";				
				meta.spUpdate = "proc_SqlServerTypeTestUpdate";		
				meta.spDelete = "proc_SqlServerTypeTestDelete";
				meta.spLoadAll = "proc_SqlServerTypeTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_SqlServerTypeTestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private SqlServerTypeTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
