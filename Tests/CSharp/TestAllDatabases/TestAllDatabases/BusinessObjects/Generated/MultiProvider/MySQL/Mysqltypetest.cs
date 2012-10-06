
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:06 AM
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
	/// Encapsulates the 'mysqltypetest' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Mysqltypetest))]	
	[XmlType("Mysqltypetest")]
	[Table(Name="Mysqltypetest")]
	public partial class Mysqltypetest : esMysqltypetest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Mysqltypetest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new Mysqltypetest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new Mysqltypetest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator MysqltypetestProxyStub(Mysqltypetest entity)
		{
			return new MysqltypetestProxyStub(entity);
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
		public override System.Int64? BigIntType
		{
			get { return base.BigIntType;  }
			set { base.BigIntType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? IntType
		{
			get { return base.IntType;  }
			set { base.IntType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? MedIntType
		{
			get { return base.MedIntType;  }
			set { base.MedIntType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int16? SmallIntType
		{
			get { return base.SmallIntType;  }
			set { base.SmallIntType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.SByte? TinyIntType
		{
			get { return base.TinyIntType;  }
			set { base.TinyIntType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.UInt64? BigIntUType
		{
			get { return base.BigIntUType;  }
			set { base.BigIntUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.UInt32? IntUType
		{
			get { return base.IntUType;  }
			set { base.IntUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.UInt32? MedIntUType
		{
			get { return base.MedIntUType;  }
			set { base.MedIntUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.UInt16? SmallIntUType
		{
			get { return base.SmallIntUType;  }
			set { base.SmallIntUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Byte? TinyIntUType
		{
			get { return base.TinyIntUType;  }
			set { base.TinyIntUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Single? FloatType
		{
			get { return base.FloatType;  }
			set { base.FloatType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Single? FloatUType
		{
			get { return base.FloatUType;  }
			set { base.FloatUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? DecType
		{
			get { return base.DecType;  }
			set { base.DecType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? DecUType
		{
			get { return base.DecUType;  }
			set { base.DecUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? NumType
		{
			get { return base.NumType;  }
			set { base.NumType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? NumUType
		{
			get { return base.NumUType;  }
			set { base.NumUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Double? DblType
		{
			get { return base.DblType;  }
			set { base.DblType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Double? DblUType
		{
			get { return base.DblUType;  }
			set { base.DblUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Double? RealType
		{
			get { return base.RealType;  }
			set { base.RealType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Double? RealUType
		{
			get { return base.RealUType;  }
			set { base.RealUType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.SByte? BitType
		{
			get { return base.BitType;  }
			set { base.BitType = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("MysqltypetestCollection")]
	public partial class MysqltypetestCollection : esMysqltypetestCollection, IEnumerable<Mysqltypetest>
	{
		public Mysqltypetest FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator MysqltypetestCollectionProxyStub(MysqltypetestCollection coll)
		{
			return new MysqltypetestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Mysqltypetest))]
		public class MysqltypetestCollectionWCFPacket : esCollectionWCFPacket<MysqltypetestCollection>
		{
			public static implicit operator MysqltypetestCollection(MysqltypetestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator MysqltypetestCollectionWCFPacket(MysqltypetestCollection collection)
			{
				return new MysqltypetestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "MysqltypetestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class MysqltypetestQuery : esMysqltypetestQuery
	{
		public MysqltypetestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "MysqltypetestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(MysqltypetestQuery query)
		{
			return MysqltypetestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator MysqltypetestQuery(string query)
		{
			return (MysqltypetestQuery)MysqltypetestQuery.SerializeHelper.FromXml(query, typeof(MysqltypetestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esMysqltypetest : EntityBase
	{
		public esMysqltypetest()
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
			MysqltypetestQuery query = new MysqltypetestQuery();
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
		/// Maps to mysqltypetest.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(MysqltypetestMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(MysqltypetestMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.BigIntType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? BigIntType
		{
			get
			{
				return base.GetSystemInt64(MysqltypetestMetadata.ColumnNames.BigIntType);
			}
			
			set
			{
				if(base.SetSystemInt64(MysqltypetestMetadata.ColumnNames.BigIntType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.IntType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? IntType
		{
			get
			{
				return base.GetSystemInt32(MysqltypetestMetadata.ColumnNames.IntType);
			}
			
			set
			{
				if(base.SetSystemInt32(MysqltypetestMetadata.ColumnNames.IntType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.MedIntType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? MedIntType
		{
			get
			{
				return base.GetSystemInt32(MysqltypetestMetadata.ColumnNames.MedIntType);
			}
			
			set
			{
				if(base.SetSystemInt32(MysqltypetestMetadata.ColumnNames.MedIntType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.SmallIntType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int16? SmallIntType
		{
			get
			{
				return base.GetSystemInt16(MysqltypetestMetadata.ColumnNames.SmallIntType);
			}
			
			set
			{
				if(base.SetSystemInt16(MysqltypetestMetadata.ColumnNames.SmallIntType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.TinyIntType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.SByte? TinyIntType
		{
			get
			{
				return base.GetSystemSByte(MysqltypetestMetadata.ColumnNames.TinyIntType);
			}
			
			set
			{
				if(base.SetSystemSByte(MysqltypetestMetadata.ColumnNames.TinyIntType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.BigIntUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.UInt64? BigIntUType
		{
			get
			{
				return base.GetSystemUInt64(MysqltypetestMetadata.ColumnNames.BigIntUType);
			}
			
			set
			{
				if(base.SetSystemUInt64(MysqltypetestMetadata.ColumnNames.BigIntUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.IntUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.UInt32? IntUType
		{
			get
			{
				return base.GetSystemUInt32(MysqltypetestMetadata.ColumnNames.IntUType);
			}
			
			set
			{
				if(base.SetSystemUInt32(MysqltypetestMetadata.ColumnNames.IntUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.MedIntUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.UInt32? MedIntUType
		{
			get
			{
				return base.GetSystemUInt32(MysqltypetestMetadata.ColumnNames.MedIntUType);
			}
			
			set
			{
				if(base.SetSystemUInt32(MysqltypetestMetadata.ColumnNames.MedIntUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.SmallIntUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.UInt16? SmallIntUType
		{
			get
			{
				return base.GetSystemUInt16(MysqltypetestMetadata.ColumnNames.SmallIntUType);
			}
			
			set
			{
				if(base.SetSystemUInt16(MysqltypetestMetadata.ColumnNames.SmallIntUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.TinyIntUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte? TinyIntUType
		{
			get
			{
				return base.GetSystemByte(MysqltypetestMetadata.ColumnNames.TinyIntUType);
			}
			
			set
			{
				if(base.SetSystemByte(MysqltypetestMetadata.ColumnNames.TinyIntUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.FloatType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Single? FloatType
		{
			get
			{
				return base.GetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatType);
			}
			
			set
			{
				if(base.SetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.FloatUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Single? FloatUType
		{
			get
			{
				return base.GetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatUType);
			}
			
			set
			{
				if(base.SetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.DecType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? DecType
		{
			get
			{
				return base.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecType);
			}
			
			set
			{
				if(base.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.DecUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? DecUType
		{
			get
			{
				return base.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecUType);
			}
			
			set
			{
				if(base.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.NumType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? NumType
		{
			get
			{
				return base.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumType);
			}
			
			set
			{
				if(base.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.NumUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? NumUType
		{
			get
			{
				return base.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumUType);
			}
			
			set
			{
				if(base.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.DblType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? DblType
		{
			get
			{
				return base.GetSystemDouble(MysqltypetestMetadata.ColumnNames.DblType);
			}
			
			set
			{
				if(base.SetSystemDouble(MysqltypetestMetadata.ColumnNames.DblType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.DblUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? DblUType
		{
			get
			{
				return base.GetSystemDouble(MysqltypetestMetadata.ColumnNames.DblUType);
			}
			
			set
			{
				if(base.SetSystemDouble(MysqltypetestMetadata.ColumnNames.DblUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.RealType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? RealType
		{
			get
			{
				return base.GetSystemDouble(MysqltypetestMetadata.ColumnNames.RealType);
			}
			
			set
			{
				if(base.SetSystemDouble(MysqltypetestMetadata.ColumnNames.RealType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.RealUType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? RealUType
		{
			get
			{
				return base.GetSystemDouble(MysqltypetestMetadata.ColumnNames.RealUType);
			}
			
			set
			{
				if(base.SetSystemDouble(MysqltypetestMetadata.ColumnNames.RealUType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealUType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest.BitType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.SByte? BitType
		{
			get
			{
				return base.GetSystemSByte(MysqltypetestMetadata.ColumnNames.BitType);
			}
			
			set
			{
				if(base.SetSystemSByte(MysqltypetestMetadata.ColumnNames.BitType, value))
				{
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BitType);
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
						case "BigIntType": this.str().BigIntType = (string)value; break;							
						case "IntType": this.str().IntType = (string)value; break;							
						case "MedIntType": this.str().MedIntType = (string)value; break;							
						case "SmallIntType": this.str().SmallIntType = (string)value; break;							
						case "TinyIntType": this.str().TinyIntType = (string)value; break;							
						case "BigIntUType": this.str().BigIntUType = (string)value; break;							
						case "IntUType": this.str().IntUType = (string)value; break;							
						case "MedIntUType": this.str().MedIntUType = (string)value; break;							
						case "SmallIntUType": this.str().SmallIntUType = (string)value; break;							
						case "TinyIntUType": this.str().TinyIntUType = (string)value; break;							
						case "FloatType": this.str().FloatType = (string)value; break;							
						case "FloatUType": this.str().FloatUType = (string)value; break;							
						case "DecType": this.str().DecType = (string)value; break;							
						case "DecUType": this.str().DecUType = (string)value; break;							
						case "NumType": this.str().NumType = (string)value; break;							
						case "NumUType": this.str().NumUType = (string)value; break;							
						case "DblType": this.str().DblType = (string)value; break;							
						case "DblUType": this.str().DblUType = (string)value; break;							
						case "RealType": this.str().RealType = (string)value; break;							
						case "RealUType": this.str().RealUType = (string)value; break;							
						case "BitType": this.str().BitType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.Id);
							break;
						
						case "BigIntType":
						
							if (value == null || value is System.Int64)
								this.BigIntType = (System.Int64?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntType);
							break;
						
						case "IntType":
						
							if (value == null || value is System.Int32)
								this.IntType = (System.Int32?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntType);
							break;
						
						case "MedIntType":
						
							if (value == null || value is System.Int32)
								this.MedIntType = (System.Int32?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntType);
							break;
						
						case "SmallIntType":
						
							if (value == null || value is System.Int16)
								this.SmallIntType = (System.Int16?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntType);
							break;
						
						case "TinyIntType":
						
							if (value == null || value is System.SByte)
								this.TinyIntType = (System.SByte?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntType);
							break;
						
						case "BigIntUType":
						
							if (value == null || value is System.UInt64)
								this.BigIntUType = (System.UInt64?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntUType);
							break;
						
						case "IntUType":
						
							if (value == null || value is System.UInt32)
								this.IntUType = (System.UInt32?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntUType);
							break;
						
						case "MedIntUType":
						
							if (value == null || value is System.UInt32)
								this.MedIntUType = (System.UInt32?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntUType);
							break;
						
						case "SmallIntUType":
						
							if (value == null || value is System.UInt16)
								this.SmallIntUType = (System.UInt16?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntUType);
							break;
						
						case "TinyIntUType":
						
							if (value == null || value is System.Byte)
								this.TinyIntUType = (System.Byte?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntUType);
							break;
						
						case "FloatType":
						
							if (value == null || value is System.Single)
								this.FloatType = (System.Single?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatType);
							break;
						
						case "FloatUType":
						
							if (value == null || value is System.Single)
								this.FloatUType = (System.Single?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatUType);
							break;
						
						case "DecType":
						
							if (value == null || value is System.Decimal)
								this.DecType = (System.Decimal?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecType);
							break;
						
						case "DecUType":
						
							if (value == null || value is System.Decimal)
								this.DecUType = (System.Decimal?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecUType);
							break;
						
						case "NumType":
						
							if (value == null || value is System.Decimal)
								this.NumType = (System.Decimal?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumType);
							break;
						
						case "NumUType":
						
							if (value == null || value is System.Decimal)
								this.NumUType = (System.Decimal?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumUType);
							break;
						
						case "DblType":
						
							if (value == null || value is System.Double)
								this.DblType = (System.Double?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblType);
							break;
						
						case "DblUType":
						
							if (value == null || value is System.Double)
								this.DblUType = (System.Double?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblUType);
							break;
						
						case "RealType":
						
							if (value == null || value is System.Double)
								this.RealType = (System.Double?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealType);
							break;
						
						case "RealUType":
						
							if (value == null || value is System.Double)
								this.RealUType = (System.Double?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealUType);
							break;
						
						case "BitType":
						
							if (value == null || value is System.SByte)
								this.BitType = (System.SByte?)value;
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BitType);
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
			public esStrings(esMysqltypetest entity)
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
				
			public System.String IntType
			{
				get
				{
					System.Int32? data = entity.IntType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IntType = null;
					else entity.IntType = Convert.ToInt32(value);
				}
			}
				
			public System.String MedIntType
			{
				get
				{
					System.Int32? data = entity.MedIntType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MedIntType = null;
					else entity.MedIntType = Convert.ToInt32(value);
				}
			}
				
			public System.String SmallIntType
			{
				get
				{
					System.Int16? data = entity.SmallIntType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SmallIntType = null;
					else entity.SmallIntType = Convert.ToInt16(value);
				}
			}
				
			public System.String TinyIntType
			{
				get
				{
					System.SByte? data = entity.TinyIntType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TinyIntType = null;
					else entity.TinyIntType = Convert.ToSByte(value);
				}
			}
				
			public System.String BigIntUType
			{
				get
				{
					System.UInt64? data = entity.BigIntUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.BigIntUType = null;
					else entity.BigIntUType = Convert.ToUInt64(value);
				}
			}
				
			public System.String IntUType
			{
				get
				{
					System.UInt32? data = entity.IntUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IntUType = null;
					else entity.IntUType = Convert.ToUInt32(value);
				}
			}
				
			public System.String MedIntUType
			{
				get
				{
					System.UInt32? data = entity.MedIntUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MedIntUType = null;
					else entity.MedIntUType = Convert.ToUInt32(value);
				}
			}
				
			public System.String SmallIntUType
			{
				get
				{
					System.UInt16? data = entity.SmallIntUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SmallIntUType = null;
					else entity.SmallIntUType = Convert.ToUInt16(value);
				}
			}
				
			public System.String TinyIntUType
			{
				get
				{
					System.Byte? data = entity.TinyIntUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TinyIntUType = null;
					else entity.TinyIntUType = Convert.ToByte(value);
				}
			}
				
			public System.String FloatType
			{
				get
				{
					System.Single? data = entity.FloatType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FloatType = null;
					else entity.FloatType = Convert.ToSingle(value);
				}
			}
				
			public System.String FloatUType
			{
				get
				{
					System.Single? data = entity.FloatUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FloatUType = null;
					else entity.FloatUType = Convert.ToSingle(value);
				}
			}
				
			public System.String DecType
			{
				get
				{
					System.Decimal? data = entity.DecType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DecType = null;
					else entity.DecType = Convert.ToDecimal(value);
				}
			}
				
			public System.String DecUType
			{
				get
				{
					System.Decimal? data = entity.DecUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DecUType = null;
					else entity.DecUType = Convert.ToDecimal(value);
				}
			}
				
			public System.String NumType
			{
				get
				{
					System.Decimal? data = entity.NumType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NumType = null;
					else entity.NumType = Convert.ToDecimal(value);
				}
			}
				
			public System.String NumUType
			{
				get
				{
					System.Decimal? data = entity.NumUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.NumUType = null;
					else entity.NumUType = Convert.ToDecimal(value);
				}
			}
				
			public System.String DblType
			{
				get
				{
					System.Double? data = entity.DblType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DblType = null;
					else entity.DblType = Convert.ToDouble(value);
				}
			}
				
			public System.String DblUType
			{
				get
				{
					System.Double? data = entity.DblUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DblUType = null;
					else entity.DblUType = Convert.ToDouble(value);
				}
			}
				
			public System.String RealType
			{
				get
				{
					System.Double? data = entity.RealType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RealType = null;
					else entity.RealType = Convert.ToDouble(value);
				}
			}
				
			public System.String RealUType
			{
				get
				{
					System.Double? data = entity.RealUType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RealUType = null;
					else entity.RealUType = Convert.ToDouble(value);
				}
			}
				
			public System.String BitType
			{
				get
				{
					System.SByte? data = entity.BitType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.BitType = null;
					else entity.BitType = Convert.ToSByte(value);
				}
			}
			

			private esMysqltypetest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return MysqltypetestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public MysqltypetestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MysqltypetestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MysqltypetestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(MysqltypetestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private MysqltypetestQuery query;		
	}



	[Serializable]
	abstract public partial class esMysqltypetestCollection : CollectionBase<Mysqltypetest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return MysqltypetestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "MysqltypetestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public MysqltypetestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MysqltypetestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MysqltypetestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MysqltypetestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(MysqltypetestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((MysqltypetestQuery)query);
		}

		#endregion
		
		private MysqltypetestQuery query;
	}



	[Serializable]
	abstract public partial class esMysqltypetestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return MysqltypetestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "BigIntType": return this.BigIntType;
				case "IntType": return this.IntType;
				case "MedIntType": return this.MedIntType;
				case "SmallIntType": return this.SmallIntType;
				case "TinyIntType": return this.TinyIntType;
				case "BigIntUType": return this.BigIntUType;
				case "IntUType": return this.IntUType;
				case "MedIntUType": return this.MedIntUType;
				case "SmallIntUType": return this.SmallIntUType;
				case "TinyIntUType": return this.TinyIntUType;
				case "FloatType": return this.FloatType;
				case "FloatUType": return this.FloatUType;
				case "DecType": return this.DecType;
				case "DecUType": return this.DecUType;
				case "NumType": return this.NumType;
				case "NumUType": return this.NumUType;
				case "DblType": return this.DblType;
				case "DblUType": return this.DblUType;
				case "RealType": return this.RealType;
				case "RealUType": return this.RealUType;
				case "BitType": return this.BitType;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem BigIntType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.BigIntType, esSystemType.Int64); }
		} 
		
		public esQueryItem IntType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.IntType, esSystemType.Int32); }
		} 
		
		public esQueryItem MedIntType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.MedIntType, esSystemType.Int32); }
		} 
		
		public esQueryItem SmallIntType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.SmallIntType, esSystemType.Int16); }
		} 
		
		public esQueryItem TinyIntType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.TinyIntType, esSystemType.SByte); }
		} 
		
		public esQueryItem BigIntUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.BigIntUType, esSystemType.UInt64); }
		} 
		
		public esQueryItem IntUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.IntUType, esSystemType.UInt32); }
		} 
		
		public esQueryItem MedIntUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.MedIntUType, esSystemType.UInt32); }
		} 
		
		public esQueryItem SmallIntUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.SmallIntUType, esSystemType.UInt16); }
		} 
		
		public esQueryItem TinyIntUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.TinyIntUType, esSystemType.Byte); }
		} 
		
		public esQueryItem FloatType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.FloatType, esSystemType.Single); }
		} 
		
		public esQueryItem FloatUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.FloatUType, esSystemType.Single); }
		} 
		
		public esQueryItem DecType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.DecType, esSystemType.Decimal); }
		} 
		
		public esQueryItem DecUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.DecUType, esSystemType.Decimal); }
		} 
		
		public esQueryItem NumType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.NumType, esSystemType.Decimal); }
		} 
		
		public esQueryItem NumUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.NumUType, esSystemType.Decimal); }
		} 
		
		public esQueryItem DblType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.DblType, esSystemType.Double); }
		} 
		
		public esQueryItem DblUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.DblUType, esSystemType.Double); }
		} 
		
		public esQueryItem RealType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.RealType, esSystemType.Double); }
		} 
		
		public esQueryItem RealUType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.RealUType, esSystemType.Double); }
		} 
		
		public esQueryItem BitType
		{
			get { return new esQueryItem(this, MysqltypetestMetadata.ColumnNames.BitType, esSystemType.SByte); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "Mysqltypetest")]
	[XmlType(TypeName="MysqltypetestProxyStub")]	
	[Serializable]
	public partial class MysqltypetestProxyStub
	{
		public MysqltypetestProxyStub() 
		{
			theEntity = this.entity = new Mysqltypetest();
		}

		public MysqltypetestProxyStub(Mysqltypetest obj)
		{
			theEntity = this.entity = obj;
		}

		public MysqltypetestProxyStub(Mysqltypetest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Mysqltypetest(MysqltypetestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Mysqltypetest);
		}

		[DataMember(Name="Id", Order=0, EmitDefaultValue=false)]
		public System.Int32? Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(MysqltypetestMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="BigIntType", Order=0, EmitDefaultValue=false)]
		public System.Int64? BigIntType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.BigIntType))
					return this.Entity.BigIntType;
				else
					return null;
			}
			set { this.Entity.BigIntType = value; }
		}

		[DataMember(Name="IntType", Order=0, EmitDefaultValue=false)]
		public System.Int32? IntType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.IntType))
					return this.Entity.IntType;
				else
					return null;
			}
			set { this.Entity.IntType = value; }
		}

		[DataMember(Name="MedIntType", Order=0, EmitDefaultValue=false)]
		public System.Int32? MedIntType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.MedIntType))
					return this.Entity.MedIntType;
				else
					return null;
			}
			set { this.Entity.MedIntType = value; }
		}

		[DataMember(Name="SmallIntType", Order=0, EmitDefaultValue=false)]
		public System.Int16? SmallIntType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.SmallIntType))
					return this.Entity.SmallIntType;
				else
					return null;
			}
			set { this.Entity.SmallIntType = value; }
		}

		[DataMember(Name="TinyIntType", Order=0, EmitDefaultValue=false)]
		public System.SByte? TinyIntType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.TinyIntType))
					return this.Entity.TinyIntType;
				else
					return null;
			}
			set { this.Entity.TinyIntType = value; }
		}

		[DataMember(Name="BigIntUType", Order=0, EmitDefaultValue=false)]
		public System.UInt64? BigIntUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.BigIntUType))
					return this.Entity.BigIntUType;
				else
					return null;
			}
			set { this.Entity.BigIntUType = value; }
		}

		[DataMember(Name="IntUType", Order=0, EmitDefaultValue=false)]
		public System.UInt32? IntUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.IntUType))
					return this.Entity.IntUType;
				else
					return null;
			}
			set { this.Entity.IntUType = value; }
		}

		[DataMember(Name="MedIntUType", Order=0, EmitDefaultValue=false)]
		public System.UInt32? MedIntUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.MedIntUType))
					return this.Entity.MedIntUType;
				else
					return null;
			}
			set { this.Entity.MedIntUType = value; }
		}

		[DataMember(Name="SmallIntUType", Order=0, EmitDefaultValue=false)]
		public System.UInt16? SmallIntUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.SmallIntUType))
					return this.Entity.SmallIntUType;
				else
					return null;
			}
			set { this.Entity.SmallIntUType = value; }
		}

		[DataMember(Name="TinyIntUType", Order=0, EmitDefaultValue=false)]
		public System.Byte? TinyIntUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.TinyIntUType))
					return this.Entity.TinyIntUType;
				else
					return null;
			}
			set { this.Entity.TinyIntUType = value; }
		}

		[DataMember(Name="FloatType", Order=0, EmitDefaultValue=false)]
		public System.Single? FloatType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.FloatType))
					return this.Entity.FloatType;
				else
					return null;
			}
			set { this.Entity.FloatType = value; }
		}

		[DataMember(Name="FloatUType", Order=0, EmitDefaultValue=false)]
		public System.Single? FloatUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.FloatUType))
					return this.Entity.FloatUType;
				else
					return null;
			}
			set { this.Entity.FloatUType = value; }
		}

		[DataMember(Name="DecType", Order=0, EmitDefaultValue=false)]
		public System.Decimal? DecType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.DecType))
					return this.Entity.DecType;
				else
					return null;
			}
			set { this.Entity.DecType = value; }
		}

		[DataMember(Name="DecUType", Order=0, EmitDefaultValue=false)]
		public System.Decimal? DecUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.DecUType))
					return this.Entity.DecUType;
				else
					return null;
			}
			set { this.Entity.DecUType = value; }
		}

		[DataMember(Name="NumType", Order=0, EmitDefaultValue=false)]
		public System.Decimal? NumType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.NumType))
					return this.Entity.NumType;
				else
					return null;
			}
			set { this.Entity.NumType = value; }
		}

		[DataMember(Name="NumUType", Order=0, EmitDefaultValue=false)]
		public System.Decimal? NumUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.NumUType))
					return this.Entity.NumUType;
				else
					return null;
			}
			set { this.Entity.NumUType = value; }
		}

		[DataMember(Name="DblType", Order=0, EmitDefaultValue=false)]
		public System.Double? DblType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.DblType))
					return this.Entity.DblType;
				else
					return null;
			}
			set { this.Entity.DblType = value; }
		}

		[DataMember(Name="DblUType", Order=0, EmitDefaultValue=false)]
		public System.Double? DblUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.DblUType))
					return this.Entity.DblUType;
				else
					return null;
			}
			set { this.Entity.DblUType = value; }
		}

		[DataMember(Name="RealType", Order=0, EmitDefaultValue=false)]
		public System.Double? RealType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.RealType))
					return this.Entity.RealType;
				else
					return null;
			}
			set { this.Entity.RealType = value; }
		}

		[DataMember(Name="RealUType", Order=0, EmitDefaultValue=false)]
		public System.Double? RealUType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.RealUType))
					return this.Entity.RealUType;
				else
					return null;
			}
			set { this.Entity.RealUType = value; }
		}

		[DataMember(Name="BitType", Order=0, EmitDefaultValue=false)]
		public System.SByte? BitType
		{
			get 
			{ 
				
				if (this.IncludeColumn(MysqltypetestMetadata.ColumnNames.BitType))
					return this.Entity.BitType;
				else
					return null;
			}
			set { this.Entity.BitType = value; }
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
		public Mysqltypetest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Mysqltypetest();
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
		public Mysqltypetest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "MysqltypetestCollection")]
	[XmlType(TypeName="MysqltypetestCollectionProxyStub")]	
	[Serializable]
	public partial class MysqltypetestCollectionProxyStub 
	{
		protected MysqltypetestCollectionProxyStub() {}
		
		public MysqltypetestCollectionProxyStub(esEntityCollection<Mysqltypetest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public MysqltypetestCollectionProxyStub(esEntityCollection<Mysqltypetest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator MysqltypetestCollection(MysqltypetestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Mysqltypetest);
		}
		
		public MysqltypetestCollectionProxyStub(esEntityCollection<Mysqltypetest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Mysqltypetest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new MysqltypetestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new MysqltypetestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Mysqltypetest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new MysqltypetestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<MysqltypetestProxyStub> Collection = new List<MysqltypetestProxyStub>();

		public MysqltypetestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new MysqltypetestCollection();

				foreach (MysqltypetestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private MysqltypetestCollection _coll;
	}



	[Serializable]
	public partial class MysqltypetestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected MysqltypetestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 11;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.BigIntType, 1, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.BigIntType;
			c.NumericPrecision = 20;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.IntType, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.IntType;
			c.NumericPrecision = 11;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.MedIntType, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.MedIntType;
			c.NumericPrecision = 9;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.SmallIntType, 4, typeof(System.Int16), esSystemType.Int16);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.SmallIntType;
			c.NumericPrecision = 6;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.TinyIntType, 5, typeof(System.SByte), esSystemType.SByte);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.TinyIntType;
			c.NumericPrecision = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.BigIntUType, 6, typeof(System.UInt64), esSystemType.UInt64);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.BigIntUType;
			c.NumericPrecision = 20;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.IntUType, 7, typeof(System.UInt32), esSystemType.UInt32);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.IntUType;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.MedIntUType, 8, typeof(System.UInt32), esSystemType.UInt32);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.MedIntUType;
			c.NumericPrecision = 8;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.SmallIntUType, 9, typeof(System.UInt16), esSystemType.UInt16);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.SmallIntUType;
			c.NumericPrecision = 5;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.TinyIntUType, 10, typeof(System.Byte), esSystemType.Byte);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.TinyIntUType;
			c.NumericPrecision = 3;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.FloatType, 11, typeof(System.Single), esSystemType.Single);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.FloatType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.FloatUType, 12, typeof(System.Single), esSystemType.Single);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.FloatUType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.DecType, 13, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DecType;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.DecUType, 14, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DecUType;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.NumType, 15, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.NumType;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.NumUType, 16, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.NumUType;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.DblType, 17, typeof(System.Double), esSystemType.Double);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DblType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.DblUType, 18, typeof(System.Double), esSystemType.Double);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DblUType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.RealType, 19, typeof(System.Double), esSystemType.Double);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.RealType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.RealUType, 20, typeof(System.Double), esSystemType.Double);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.RealUType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MysqltypetestMetadata.ColumnNames.BitType, 21, typeof(System.SByte), esSystemType.SByte);
			c.PropertyName = MysqltypetestMetadata.PropertyNames.BitType;
			c.NumericPrecision = 1;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public MysqltypetestMetadata Meta()
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
			 public const string BigIntType = "BigIntType";
			 public const string IntType = "IntType";
			 public const string MedIntType = "MedIntType";
			 public const string SmallIntType = "SmallIntType";
			 public const string TinyIntType = "TinyIntType";
			 public const string BigIntUType = "BigIntUType";
			 public const string IntUType = "IntUType";
			 public const string MedIntUType = "MedIntUType";
			 public const string SmallIntUType = "SmallIntUType";
			 public const string TinyIntUType = "TinyIntUType";
			 public const string FloatType = "FloatType";
			 public const string FloatUType = "FloatUType";
			 public const string DecType = "DecType";
			 public const string DecUType = "DecUType";
			 public const string NumType = "NumType";
			 public const string NumUType = "NumUType";
			 public const string DblType = "DblType";
			 public const string DblUType = "DblUType";
			 public const string RealType = "RealType";
			 public const string RealUType = "RealUType";
			 public const string BitType = "BitType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string BigIntType = "BigIntType";
			 public const string IntType = "IntType";
			 public const string MedIntType = "MedIntType";
			 public const string SmallIntType = "SmallIntType";
			 public const string TinyIntType = "TinyIntType";
			 public const string BigIntUType = "BigIntUType";
			 public const string IntUType = "IntUType";
			 public const string MedIntUType = "MedIntUType";
			 public const string SmallIntUType = "SmallIntUType";
			 public const string TinyIntUType = "TinyIntUType";
			 public const string FloatType = "FloatType";
			 public const string FloatUType = "FloatUType";
			 public const string DecType = "DecType";
			 public const string DecUType = "DecUType";
			 public const string NumType = "NumType";
			 public const string NumUType = "NumUType";
			 public const string DblType = "DblType";
			 public const string DblUType = "DblUType";
			 public const string RealType = "RealType";
			 public const string RealUType = "RealUType";
			 public const string BitType = "BitType";
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
			lock (typeof(MysqltypetestMetadata))
			{
				if(MysqltypetestMetadata.mapDelegates == null)
				{
					MysqltypetestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MysqltypetestMetadata.meta == null)
				{
					MysqltypetestMetadata.meta = new MysqltypetestMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("BigIntType", new esTypeMap("BIGINT", "System.Int64"));
				meta.AddTypeMap("IntType", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("MedIntType", new esTypeMap("MEDIUMINT", "System.Int32"));
				meta.AddTypeMap("SmallIntType", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("TinyIntType", new esTypeMap("TINYINT", "System.SByte"));
				meta.AddTypeMap("BigIntUType", new esTypeMap("BIGINT UNSIGNED", "System.UInt64"));
				meta.AddTypeMap("IntUType", new esTypeMap("INT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("MedIntUType", new esTypeMap("MEDIUMINT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("SmallIntUType", new esTypeMap("SMALLINT UNSIGNED", "System.UInt16"));
				meta.AddTypeMap("TinyIntUType", new esTypeMap("TINYINT UNSIGNED", "System.Byte"));
				meta.AddTypeMap("FloatType", new esTypeMap("FLOAT", "System.Single"));
				meta.AddTypeMap("FloatUType", new esTypeMap("FLOAT UNSIGNED", "System.Single"));
				meta.AddTypeMap("DecType", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("DecUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"));
				meta.AddTypeMap("NumType", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("NumUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"));
				meta.AddTypeMap("DblType", new esTypeMap("DOUBLE", "System.Double"));
				meta.AddTypeMap("DblUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"));
				meta.AddTypeMap("RealType", new esTypeMap("DOUBLE", "System.Double"));
				meta.AddTypeMap("RealUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"));
				meta.AddTypeMap("BitType", new esTypeMap("BIT", "System.SByte"));			
				meta.Catalog = "aggregatedb";
				
				
				meta.Source = "mysqltypetest";
				meta.Destination = "mysqltypetest";
				
				meta.spInsert = "proc_mysqltypetestInsert";				
				meta.spUpdate = "proc_mysqltypetestUpdate";		
				meta.spDelete = "proc_mysqltypetestDelete";
				meta.spLoadAll = "proc_mysqltypetestLoadAll";
				meta.spLoadByPrimaryKey = "proc_mysqltypetestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private MysqltypetestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
