
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:43 AM
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
	/// Encapsulates the 'OracleDataTypes' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(OracleDataTypes))]	
	[XmlType("OracleDataTypes")]
	[Table(Name="OracleDataTypes")]
	public partial class OracleDataTypes : esOracleDataTypes
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new OracleDataTypes();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String charType)
		{
			var obj = new OracleDataTypes();
			obj.CharType = charType;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String charType, esSqlAccessType sqlAccessType)
		{
			var obj = new OracleDataTypes();
			obj.CharType = charType;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator OracleDataTypesProxyStub(OracleDataTypes entity)
		{
			return new OracleDataTypesProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String CharType
		{
			get { return base.CharType;  }
			set { base.CharType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String VarCharType
		{
			get { return base.VarCharType;  }
			set { base.VarCharType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateType
		{
			get { return base.DateType;  }
			set { base.DateType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? IntegerType
		{
			get { return base.IntegerType;  }
			set { base.IntegerType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? SmallIntType
		{
			get { return base.SmallIntType;  }
			set { base.SmallIntType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? DecimalType
		{
			get { return base.DecimalType;  }
			set { base.DecimalType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? FloatType
		{
			get { return base.FloatType;  }
			set { base.FloatType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? DoubleType
		{
			get { return base.DoubleType;  }
			set { base.DoubleType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? RealType
		{
			get { return base.RealType;  }
			set { base.RealType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? NumberType
		{
			get { return base.NumberType;  }
			set { base.NumberType = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("OracleDataTypesCollection")]
	public partial class OracleDataTypesCollection : esOracleDataTypesCollection, IEnumerable<OracleDataTypes>
	{
		public OracleDataTypes FindByPrimaryKey(System.String charType)
		{
			return this.SingleOrDefault(e => e.CharType == charType);
		}

		#region Implicit Casts
		
		public static implicit operator OracleDataTypesCollectionProxyStub(OracleDataTypesCollection coll)
		{
			return new OracleDataTypesCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(OracleDataTypes))]
		public class OracleDataTypesCollectionWCFPacket : esCollectionWCFPacket<OracleDataTypesCollection>
		{
			public static implicit operator OracleDataTypesCollection(OracleDataTypesCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator OracleDataTypesCollectionWCFPacket(OracleDataTypesCollection collection)
			{
				return new OracleDataTypesCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "OracleDataTypesQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class OracleDataTypesQuery : esOracleDataTypesQuery
	{
		public OracleDataTypesQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "OracleDataTypesQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OracleDataTypesQuery query)
		{
			return OracleDataTypesQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OracleDataTypesQuery(string query)
		{
			return (OracleDataTypesQuery)OracleDataTypesQuery.SerializeHelper.FromXml(query, typeof(OracleDataTypesQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esOracleDataTypes : EntityBase
	{
		public esOracleDataTypes()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String charType)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(charType);
			else
				return LoadByPrimaryKeyStoredProcedure(charType);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String charType)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(charType);
			else
				return LoadByPrimaryKeyStoredProcedure(charType);
		}

		private bool LoadByPrimaryKeyDynamic(System.String charType)
		{
			OracleDataTypesQuery query = new OracleDataTypesQuery();
			query.Where(query.CharType == charType);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String charType)
		{
			esParameters parms = new esParameters();
			parms.Add("CharType", charType);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to OracleDataTypes.CharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CharType
		{
			get
			{
				return base.GetSystemString(OracleDataTypesMetadata.ColumnNames.CharType);
			}
			
			set
			{
				if(base.SetSystemString(OracleDataTypesMetadata.ColumnNames.CharType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.CharType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.VarCharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String VarCharType
		{
			get
			{
				return base.GetSystemString(OracleDataTypesMetadata.ColumnNames.VarCharType);
			}
			
			set
			{
				if(base.SetSystemString(OracleDataTypesMetadata.ColumnNames.VarCharType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.VarCharType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.DateType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateType
		{
			get
			{
				return base.GetSystemDateTime(OracleDataTypesMetadata.ColumnNames.DateType);
			}
			
			set
			{
				if(base.SetSystemDateTime(OracleDataTypesMetadata.ColumnNames.DateType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.DateType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.IntegerType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? IntegerType
		{
			get
			{
				return base.GetSystemDecimal(OracleDataTypesMetadata.ColumnNames.IntegerType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleDataTypesMetadata.ColumnNames.IntegerType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.IntegerType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.SmallIntType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? SmallIntType
		{
			get
			{
				return base.GetSystemDecimal(OracleDataTypesMetadata.ColumnNames.SmallIntType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleDataTypesMetadata.ColumnNames.SmallIntType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.SmallIntType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.DecimalType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? DecimalType
		{
			get
			{
				return base.GetSystemDecimal(OracleDataTypesMetadata.ColumnNames.DecimalType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleDataTypesMetadata.ColumnNames.DecimalType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.DecimalType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.FloatType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? FloatType
		{
			get
			{
				return base.GetSystemDecimal(OracleDataTypesMetadata.ColumnNames.FloatType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleDataTypesMetadata.ColumnNames.FloatType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.FloatType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.DoubleType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? DoubleType
		{
			get
			{
				return base.GetSystemDecimal(OracleDataTypesMetadata.ColumnNames.DoubleType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleDataTypesMetadata.ColumnNames.DoubleType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.DoubleType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.RealType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? RealType
		{
			get
			{
				return base.GetSystemDecimal(OracleDataTypesMetadata.ColumnNames.RealType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleDataTypesMetadata.ColumnNames.RealType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.RealType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to OracleDataTypes.NumberType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? NumberType
		{
			get
			{
				return base.GetSystemDecimal(OracleDataTypesMetadata.ColumnNames.NumberType);
			}
			
			set
			{
				if(base.SetSystemDecimal(OracleDataTypesMetadata.ColumnNames.NumberType, value))
				{
					OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.NumberType);
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
						case "CharType": this.str().CharType = (string)value; break;							
						case "VarCharType": this.str().VarCharType = (string)value; break;							
						case "DateType": this.str().DateType = (string)value; break;							
						case "IntegerType": this.str().IntegerType = (string)value; break;							
						case "SmallIntType": this.str().SmallIntType = (string)value; break;							
						case "DecimalType": this.str().DecimalType = (string)value; break;							
						case "FloatType": this.str().FloatType = (string)value; break;							
						case "DoubleType": this.str().DoubleType = (string)value; break;							
						case "RealType": this.str().RealType = (string)value; break;							
						case "NumberType": this.str().NumberType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "DateType":
						
							if (value == null || value is System.DateTime)
								this.DateType = (System.DateTime?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.DateType);
							break;
						
						case "IntegerType":
						
							if (value == null || value is System.Decimal)
								this.IntegerType = (System.Decimal?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.IntegerType);
							break;
						
						case "SmallIntType":
						
							if (value == null || value is System.Decimal)
								this.SmallIntType = (System.Decimal?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.SmallIntType);
							break;
						
						case "DecimalType":
						
							if (value == null || value is System.Decimal)
								this.DecimalType = (System.Decimal?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.DecimalType);
							break;
						
						case "FloatType":
						
							if (value == null || value is System.Decimal)
								this.FloatType = (System.Decimal?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.FloatType);
							break;
						
						case "DoubleType":
						
							if (value == null || value is System.Decimal)
								this.DoubleType = (System.Decimal?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.DoubleType);
							break;
						
						case "RealType":
						
							if (value == null || value is System.Decimal)
								this.RealType = (System.Decimal?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.RealType);
							break;
						
						case "NumberType":
						
							if (value == null || value is System.Decimal)
								this.NumberType = (System.Decimal?)value;
								OnPropertyChanged(OracleDataTypesMetadata.PropertyNames.NumberType);
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
			public esStrings(esOracleDataTypes entity)
			{
				this.entity = entity;
			}
			
	
			public System.String CharType
			{
				get
				{
					System.String data = entity.CharType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CharType = null;
					else entity.CharType = Convert.ToString(value);
				}
			}
				
			public System.String VarCharType
			{
				get
				{
					System.String data = entity.VarCharType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.VarCharType = null;
					else entity.VarCharType = Convert.ToString(value);
				}
			}
				
			public System.String DateType
			{
				get
				{
					System.DateTime? data = entity.DateType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateType = null;
					else entity.DateType = Convert.ToDateTime(value);
				}
			}
				
			public System.String IntegerType
			{
				get
				{
					System.Decimal? data = entity.IntegerType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IntegerType = null;
					else entity.IntegerType = Convert.ToDecimal(value);
				}
			}
				
			public System.String SmallIntType
			{
				get
				{
					System.Decimal? data = entity.SmallIntType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SmallIntType = null;
					else entity.SmallIntType = Convert.ToDecimal(value);
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
				
			public System.String FloatType
			{
				get
				{
					System.Decimal? data = entity.FloatType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FloatType = null;
					else entity.FloatType = Convert.ToDecimal(value);
				}
			}
				
			public System.String DoubleType
			{
				get
				{
					System.Decimal? data = entity.DoubleType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DoubleType = null;
					else entity.DoubleType = Convert.ToDecimal(value);
				}
			}
				
			public System.String RealType
			{
				get
				{
					System.Decimal? data = entity.RealType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RealType = null;
					else entity.RealType = Convert.ToDecimal(value);
				}
			}
				
			public System.String NumberType
			{
				get
				{
					System.Decimal? data = entity.NumberType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NumberType = null;
					else entity.NumberType = Convert.ToDecimal(value);
				}
			}
			

			private esOracleDataTypes entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return OracleDataTypesMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public OracleDataTypesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OracleDataTypesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OracleDataTypesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(OracleDataTypesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private OracleDataTypesQuery query;		
	}



	[Serializable]
	abstract public partial class esOracleDataTypesCollection : CollectionBase<OracleDataTypes>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return OracleDataTypesMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "OracleDataTypesCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public OracleDataTypesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OracleDataTypesQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OracleDataTypesQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new OracleDataTypesQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(OracleDataTypesQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((OracleDataTypesQuery)query);
		}

		#endregion
		
		private OracleDataTypesQuery query;
	}



	[Serializable]
	abstract public partial class esOracleDataTypesQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return OracleDataTypesMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "CharType": return this.CharType;
				case "VarCharType": return this.VarCharType;
				case "DateType": return this.DateType;
				case "IntegerType": return this.IntegerType;
				case "SmallIntType": return this.SmallIntType;
				case "DecimalType": return this.DecimalType;
				case "FloatType": return this.FloatType;
				case "DoubleType": return this.DoubleType;
				case "RealType": return this.RealType;
				case "NumberType": return this.NumberType;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem CharType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.CharType, esSystemType.String); }
		} 
		
		public esQueryItem VarCharType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.VarCharType, esSystemType.String); }
		} 
		
		public esQueryItem DateType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.DateType, esSystemType.DateTime); }
		} 
		
		public esQueryItem IntegerType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.IntegerType, esSystemType.Decimal); }
		} 
		
		public esQueryItem SmallIntType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.SmallIntType, esSystemType.Decimal); }
		} 
		
		public esQueryItem DecimalType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.DecimalType, esSystemType.Decimal); }
		} 
		
		public esQueryItem FloatType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.FloatType, esSystemType.Decimal); }
		} 
		
		public esQueryItem DoubleType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.DoubleType, esSystemType.Decimal); }
		} 
		
		public esQueryItem RealType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.RealType, esSystemType.Decimal); }
		} 
		
		public esQueryItem NumberType
		{
			get { return new esQueryItem(this, OracleDataTypesMetadata.ColumnNames.NumberType, esSystemType.Decimal); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OracleDataTypes")]
	[XmlType(TypeName="OracleDataTypesProxyStub")]	
	[Serializable]
	public partial class OracleDataTypesProxyStub
	{
		public OracleDataTypesProxyStub() 
		{
			theEntity = this.entity = new OracleDataTypes();
		}

		public OracleDataTypesProxyStub(OracleDataTypes obj)
		{
			theEntity = this.entity = obj;
		}

		public OracleDataTypesProxyStub(OracleDataTypes obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator OracleDataTypes(OracleDataTypesProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(OracleDataTypes);
		}

		[DataMember(Name="CharType", Order=1, EmitDefaultValue=false)]
		public System.String CharType
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(OracleDataTypesMetadata.ColumnNames.CharType);
				else
					return this.Entity.CharType;
			}
			set { this.Entity.CharType = value; }
		}

		[DataMember(Name="VarCharType", Order=2, EmitDefaultValue=false)]
		public System.String VarCharType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.VarCharType))
					return this.Entity.VarCharType;
				else
					return null;
			}
			set { this.Entity.VarCharType = value; }
		}

		[DataMember(Name="DateType", Order=3, EmitDefaultValue=false)]
		public System.DateTime? DateType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.DateType))
					return this.Entity.DateType;
				else
					return null;
			}
			set { this.Entity.DateType = value; }
		}

		[DataMember(Name="IntegerType", Order=4, EmitDefaultValue=false)]
		public System.Decimal? IntegerType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.IntegerType))
					return this.Entity.IntegerType;
				else
					return null;
			}
			set { this.Entity.IntegerType = value; }
		}

		[DataMember(Name="SmallIntType", Order=5, EmitDefaultValue=false)]
		public System.Decimal? SmallIntType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.SmallIntType))
					return this.Entity.SmallIntType;
				else
					return null;
			}
			set { this.Entity.SmallIntType = value; }
		}

		[DataMember(Name="DecimalType", Order=6, EmitDefaultValue=false)]
		public System.Decimal? DecimalType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.DecimalType))
					return this.Entity.DecimalType;
				else
					return null;
			}
			set { this.Entity.DecimalType = value; }
		}

		[DataMember(Name="FloatType", Order=7, EmitDefaultValue=false)]
		public System.Decimal? FloatType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.FloatType))
					return this.Entity.FloatType;
				else
					return null;
			}
			set { this.Entity.FloatType = value; }
		}

		[DataMember(Name="DoubleType", Order=8, EmitDefaultValue=false)]
		public System.Decimal? DoubleType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.DoubleType))
					return this.Entity.DoubleType;
				else
					return null;
			}
			set { this.Entity.DoubleType = value; }
		}

		[DataMember(Name="RealType", Order=9, EmitDefaultValue=false)]
		public System.Decimal? RealType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.RealType))
					return this.Entity.RealType;
				else
					return null;
			}
			set { this.Entity.RealType = value; }
		}

		[DataMember(Name="NumberType", Order=10, EmitDefaultValue=false)]
		public System.Decimal? NumberType
		{
			get 
			{ 
				
				if (this.IncludeColumn(OracleDataTypesMetadata.ColumnNames.NumberType))
					return this.Entity.NumberType;
				else
					return null;
			}
			set { this.Entity.NumberType = value; }
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
		public OracleDataTypes Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new OracleDataTypes();
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
		public OracleDataTypes entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OracleDataTypesCollection")]
	[XmlType(TypeName="OracleDataTypesCollectionProxyStub")]	
	[Serializable]
	public partial class OracleDataTypesCollectionProxyStub 
	{
		protected OracleDataTypesCollectionProxyStub() {}
		
		public OracleDataTypesCollectionProxyStub(esEntityCollection<OracleDataTypes> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public OracleDataTypesCollectionProxyStub(esEntityCollection<OracleDataTypes> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator OracleDataTypesCollection(OracleDataTypesCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(OracleDataTypes);
		}
		
		public OracleDataTypesCollectionProxyStub(esEntityCollection<OracleDataTypes> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (OracleDataTypes entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new OracleDataTypesProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new OracleDataTypesProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (OracleDataTypes entity in coll.es.DeletedEntities)
				{
					Collection.Add(new OracleDataTypesProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<OracleDataTypesProxyStub> Collection = new List<OracleDataTypesProxyStub>();

		public OracleDataTypesCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new OracleDataTypesCollection();

				foreach (OracleDataTypesProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private OracleDataTypesCollection _coll;
	}



	[Serializable]
	public partial class OracleDataTypesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OracleDataTypesMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.CharType, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.CharType;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.VarCharType, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.VarCharType;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.DateType, 2, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.DateType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.IntegerType, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.IntegerType;
			c.NumericPrecision = 38;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.SmallIntType, 4, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.SmallIntType;
			c.NumericPrecision = 38;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.DecimalType, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.DecimalType;
			c.NumericPrecision = 8;
			c.NumericScale = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.FloatType, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.FloatType;
			c.NumericPrecision = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.DoubleType, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.DoubleType;
			c.NumericPrecision = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.RealType, 8, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.RealType;
			c.NumericPrecision = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OracleDataTypesMetadata.ColumnNames.NumberType, 9, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OracleDataTypesMetadata.PropertyNames.NumberType;
			c.NumericPrecision = 38;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public OracleDataTypesMetadata Meta()
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
			 public const string CharType = "CharType";
			 public const string VarCharType = "VarCharType";
			 public const string DateType = "DateType";
			 public const string IntegerType = "IntegerType";
			 public const string SmallIntType = "SmallIntType";
			 public const string DecimalType = "DecimalType";
			 public const string FloatType = "FloatType";
			 public const string DoubleType = "DoubleType";
			 public const string RealType = "RealType";
			 public const string NumberType = "NumberType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string CharType = "CharType";
			 public const string VarCharType = "VarCharType";
			 public const string DateType = "DateType";
			 public const string IntegerType = "IntegerType";
			 public const string SmallIntType = "SmallIntType";
			 public const string DecimalType = "DecimalType";
			 public const string FloatType = "FloatType";
			 public const string DoubleType = "DoubleType";
			 public const string RealType = "RealType";
			 public const string NumberType = "NumberType";
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
			lock (typeof(OracleDataTypesMetadata))
			{
				if(OracleDataTypesMetadata.mapDelegates == null)
				{
					OracleDataTypesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OracleDataTypesMetadata.meta == null)
				{
					OracleDataTypesMetadata.meta = new OracleDataTypesMetadata();
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


				meta.AddTypeMap("CharType", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("IntegerType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("SmallIntType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DecimalType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("FloatType", new esTypeMap("FLOAT", "System.Decimal"));
				meta.AddTypeMap("DoubleType", new esTypeMap("FLOAT", "System.Decimal"));
				meta.AddTypeMap("RealType", new esTypeMap("FLOAT", "System.Decimal"));
				meta.AddTypeMap("NumberType", new esTypeMap("NUMBER", "System.Decimal"));			
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				
				meta.Source = "OracleDataTypes";
				meta.Destination = "OracleDataTypes";
				
				meta.spInsert = "esOracleDataTypesInsert";				
				meta.spUpdate = "esOracleDataTypesUpdate";		
				meta.spDelete = "esOracleDataTypesDelete";
				meta.spLoadAll = "esOracleDataTypesLoadAll";
				meta.spLoadByPrimaryKey = "esOracleDataTypesLoadByPK";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private OracleDataTypesMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
