
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
	/// Encapsulates the 'mysqltypetest2' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Mysqltypetest2))]	
	[XmlType("Mysqltypetest2")]
	[Table(Name="Mysqltypetest2")]
	public partial class Mysqltypetest2 : esMysqltypetest2
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Mysqltypetest2();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.UInt32 id)
		{
			var obj = new Mysqltypetest2();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.UInt32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new Mysqltypetest2();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator Mysqltypetest2ProxyStub(Mysqltypetest2 entity)
		{
			return new Mysqltypetest2ProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.UInt32? Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String VarCharType
		{
			get { return base.VarCharType;  }
			set { base.VarCharType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String CharType
		{
			get { return base.CharType;  }
			set { base.CharType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.DateTime? TimeStampType
		{
			get { return base.TimeStampType;  }
			set { base.TimeStampType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateType
		{
			get { return base.DateType;  }
			set { base.DateType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateTimeType
		{
			get { return base.DateTimeType;  }
			set { base.DateTimeType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Byte[] BlobType
		{
			get { return base.BlobType;  }
			set { base.BlobType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String TextType
		{
			get { return base.TextType;  }
			set { base.TextType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.TimeSpan? TimeType
		{
			get { return base.TimeType;  }
			set { base.TimeType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String LongTextType
		{
			get { return base.LongTextType;  }
			set { base.LongTextType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String BinaryType
		{
			get { return base.BinaryType;  }
			set { base.BinaryType = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String VarBinaryType
		{
			get { return base.VarBinaryType;  }
			set { base.VarBinaryType = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("Mysqltypetest2Collection")]
	public partial class Mysqltypetest2Collection : esMysqltypetest2Collection, IEnumerable<Mysqltypetest2>
	{
		public Mysqltypetest2 FindByPrimaryKey(System.UInt32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator Mysqltypetest2CollectionProxyStub(Mysqltypetest2Collection coll)
		{
			return new Mysqltypetest2CollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Mysqltypetest2))]
		public class Mysqltypetest2CollectionWCFPacket : esCollectionWCFPacket<Mysqltypetest2Collection>
		{
			public static implicit operator Mysqltypetest2Collection(Mysqltypetest2CollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator Mysqltypetest2CollectionWCFPacket(Mysqltypetest2Collection collection)
			{
				return new Mysqltypetest2CollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "Mysqltypetest2Query", Namespace = "http://www.entityspaces.net")]	
	public partial class Mysqltypetest2Query : esMysqltypetest2Query
	{
		public Mysqltypetest2Query(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "Mysqltypetest2Query";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(Mysqltypetest2Query query)
		{
			return Mysqltypetest2Query.SerializeHelper.ToXml(query);
		}

		public static explicit operator Mysqltypetest2Query(string query)
		{
			return (Mysqltypetest2Query)Mysqltypetest2Query.SerializeHelper.FromXml(query, typeof(Mysqltypetest2Query));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esMysqltypetest2 : EntityBase
	{
		public esMysqltypetest2()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.UInt32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.UInt32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.UInt32 id)
		{
			Mysqltypetest2Query query = new Mysqltypetest2Query();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.UInt32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to mysqltypetest2.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.UInt32? Id
		{
			get
			{
				return base.GetSystemUInt32(Mysqltypetest2Metadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemUInt32(Mysqltypetest2Metadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.VarCharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String VarCharType
		{
			get
			{
				return base.GetSystemString(Mysqltypetest2Metadata.ColumnNames.VarCharType);
			}
			
			set
			{
				if(base.SetSystemString(Mysqltypetest2Metadata.ColumnNames.VarCharType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.VarCharType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.CharType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CharType
		{
			get
			{
				return base.GetSystemString(Mysqltypetest2Metadata.ColumnNames.CharType);
			}
			
			set
			{
				if(base.SetSystemString(Mysqltypetest2Metadata.ColumnNames.CharType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.CharType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.TimeStampType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? TimeStampType
		{
			get
			{
				return base.GetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.TimeStampType);
			}
			
			set
			{
				if(base.SetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.TimeStampType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeStampType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.DateType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateType
		{
			get
			{
				return base.GetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateType);
			}
			
			set
			{
				if(base.SetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.DateTimeType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateTimeType
		{
			get
			{
				return base.GetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateTimeType);
			}
			
			set
			{
				if(base.SetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateTimeType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateTimeType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.BlobType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte[] BlobType
		{
			get
			{
				return base.GetSystemByteArray(Mysqltypetest2Metadata.ColumnNames.BlobType);
			}
			
			set
			{
				if(base.SetSystemByteArray(Mysqltypetest2Metadata.ColumnNames.BlobType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.BlobType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.TextType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String TextType
		{
			get
			{
				return base.GetSystemString(Mysqltypetest2Metadata.ColumnNames.TextType);
			}
			
			set
			{
				if(base.SetSystemString(Mysqltypetest2Metadata.ColumnNames.TextType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TextType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.TimeType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.TimeSpan? TimeType
		{
			get
			{
				return base.GetSystemTimeSpan(Mysqltypetest2Metadata.ColumnNames.TimeType);
			}
			
			set
			{
				if(base.SetSystemTimeSpan(Mysqltypetest2Metadata.ColumnNames.TimeType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.LongTextType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LongTextType
		{
			get
			{
				return base.GetSystemString(Mysqltypetest2Metadata.ColumnNames.LongTextType);
			}
			
			set
			{
				if(base.SetSystemString(Mysqltypetest2Metadata.ColumnNames.LongTextType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.LongTextType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.BinaryType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String BinaryType
		{
			get
			{
				return base.GetSystemString(Mysqltypetest2Metadata.ColumnNames.BinaryType);
			}
			
			set
			{
				if(base.SetSystemString(Mysqltypetest2Metadata.ColumnNames.BinaryType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.BinaryType);
				}
			}
		}		
		
		/// <summary>
		/// Maps to mysqltypetest2.VarBinaryType
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String VarBinaryType
		{
			get
			{
				return base.GetSystemString(Mysqltypetest2Metadata.ColumnNames.VarBinaryType);
			}
			
			set
			{
				if(base.SetSystemString(Mysqltypetest2Metadata.ColumnNames.VarBinaryType, value))
				{
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.VarBinaryType);
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
						case "VarCharType": this.str().VarCharType = (string)value; break;							
						case "CharType": this.str().CharType = (string)value; break;							
						case "TimeStampType": this.str().TimeStampType = (string)value; break;							
						case "DateType": this.str().DateType = (string)value; break;							
						case "DateTimeType": this.str().DateTimeType = (string)value; break;							
						case "TextType": this.str().TextType = (string)value; break;							
						case "TimeType": this.str().TimeType = (string)value; break;							
						case "LongTextType": this.str().LongTextType = (string)value; break;							
						case "BinaryType": this.str().BinaryType = (string)value; break;							
						case "VarBinaryType": this.str().VarBinaryType = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.UInt32)
								this.Id = (System.UInt32?)value;
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.Id);
							break;
						
						case "TimeStampType":
						
							if (value == null || value is System.DateTime)
								this.TimeStampType = (System.DateTime?)value;
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeStampType);
							break;
						
						case "DateType":
						
							if (value == null || value is System.DateTime)
								this.DateType = (System.DateTime?)value;
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateType);
							break;
						
						case "DateTimeType":
						
							if (value == null || value is System.DateTime)
								this.DateTimeType = (System.DateTime?)value;
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateTimeType);
							break;
						
						case "BlobType":
						
							if (value == null || value is System.Byte[])
								this.BlobType = (System.Byte[])value;
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.BlobType);
							break;
						
						case "TimeType":
						
							if (value == null || value is System.TimeSpan)
								this.TimeType = (System.TimeSpan?)value;
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeType);
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
			public esStrings(esMysqltypetest2 entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.UInt32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToUInt32(value);
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
				
			public System.String TimeStampType
			{
				get
				{
					System.DateTime? data = entity.TimeStampType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TimeStampType = null;
					else entity.TimeStampType = Convert.ToDateTime(value);
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
				
			public System.String DateTimeType
			{
				get
				{
					System.DateTime? data = entity.DateTimeType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateTimeType = null;
					else entity.DateTimeType = Convert.ToDateTime(value);
				}
			}
				
			public System.String TextType
			{
				get
				{
					System.String data = entity.TextType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TextType = null;
					else entity.TextType = Convert.ToString(value);
				}
			}
				
			public System.String TimeType
			{
				get
				{
					System.TimeSpan? data = entity.TimeType;
					return (data == null) ? String.Empty : data.ToString();
				}

				set
				{
					if (value == null || value.Length == 0) entity.TimeType = null;
					else entity.TimeType = TimeSpan.Parse(value);
				}
			}
				
			public System.String LongTextType
			{
				get
				{
					System.String data = entity.LongTextType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LongTextType = null;
					else entity.LongTextType = Convert.ToString(value);
				}
			}
				
			public System.String BinaryType
			{
				get
				{
					System.String data = entity.BinaryType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.BinaryType = null;
					else entity.BinaryType = Convert.ToString(value);
				}
			}
				
			public System.String VarBinaryType
			{
				get
				{
					System.String data = entity.VarBinaryType;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.VarBinaryType = null;
					else entity.VarBinaryType = Convert.ToString(value);
				}
			}
			

			private esMysqltypetest2 entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return Mysqltypetest2Metadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public Mysqltypetest2Query Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new Mysqltypetest2Query();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(Mysqltypetest2Query query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(Mysqltypetest2Query query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private Mysqltypetest2Query query;		
	}



	[Serializable]
	abstract public partial class esMysqltypetest2Collection : CollectionBase<Mysqltypetest2>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return Mysqltypetest2Metadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "Mysqltypetest2Collection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public Mysqltypetest2Query Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new Mysqltypetest2Query();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(Mysqltypetest2Query query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new Mysqltypetest2Query();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(Mysqltypetest2Query query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((Mysqltypetest2Query)query);
		}

		#endregion
		
		private Mysqltypetest2Query query;
	}



	[Serializable]
	abstract public partial class esMysqltypetest2Query : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return Mysqltypetest2Metadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "VarCharType": return this.VarCharType;
				case "CharType": return this.CharType;
				case "TimeStampType": return this.TimeStampType;
				case "DateType": return this.DateType;
				case "DateTimeType": return this.DateTimeType;
				case "BlobType": return this.BlobType;
				case "TextType": return this.TextType;
				case "TimeType": return this.TimeType;
				case "LongTextType": return this.LongTextType;
				case "BinaryType": return this.BinaryType;
				case "VarBinaryType": return this.VarBinaryType;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.Id, esSystemType.UInt32); }
		} 
		
		public esQueryItem VarCharType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.VarCharType, esSystemType.String); }
		} 
		
		public esQueryItem CharType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.CharType, esSystemType.String); }
		} 
		
		public esQueryItem TimeStampType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.TimeStampType, esSystemType.DateTime); }
		} 
		
		public esQueryItem DateType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.DateType, esSystemType.DateTime); }
		} 
		
		public esQueryItem DateTimeType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.DateTimeType, esSystemType.DateTime); }
		} 
		
		public esQueryItem BlobType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.BlobType, esSystemType.ByteArray); }
		} 
		
		public esQueryItem TextType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.TextType, esSystemType.String); }
		} 
		
		public esQueryItem TimeType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.TimeType, esSystemType.TimeSpan); }
		} 
		
		public esQueryItem LongTextType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.LongTextType, esSystemType.String); }
		} 
		
		public esQueryItem BinaryType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.BinaryType, esSystemType.String); }
		} 
		
		public esQueryItem VarBinaryType
		{
			get { return new esQueryItem(this, Mysqltypetest2Metadata.ColumnNames.VarBinaryType, esSystemType.String); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "Mysqltypetest2")]
	[XmlType(TypeName="Mysqltypetest2ProxyStub")]	
	[Serializable]
	public partial class Mysqltypetest2ProxyStub
	{
		public Mysqltypetest2ProxyStub() 
		{
			theEntity = this.entity = new Mysqltypetest2();
		}

		public Mysqltypetest2ProxyStub(Mysqltypetest2 obj)
		{
			theEntity = this.entity = obj;
		}

		public Mysqltypetest2ProxyStub(Mysqltypetest2 obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Mysqltypetest2(Mysqltypetest2ProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Mysqltypetest2);
		}

		[DataMember(Name="Id", Order=0, EmitDefaultValue=false)]
		public System.UInt32? Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.UInt32?)this.Entity.
						GetOriginalColumnValue(Mysqltypetest2Metadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="VarCharType", Order=0, EmitDefaultValue=false)]
		public System.String VarCharType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.VarCharType))
					return this.Entity.VarCharType;
				else
					return null;
			}
			set { this.Entity.VarCharType = value; }
		}

		[DataMember(Name="CharType", Order=0, EmitDefaultValue=false)]
		public System.String CharType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.CharType))
					return this.Entity.CharType;
				else
					return null;
			}
			set { this.Entity.CharType = value; }
		}

		[DataMember(Name="TimeStampType", Order=0, EmitDefaultValue=false)]
		public System.DateTime? TimeStampType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.TimeStampType))
					return this.Entity.TimeStampType;
				else
					return null;
			}
			set { this.Entity.TimeStampType = value; }
		}

		[DataMember(Name="DateType", Order=0, EmitDefaultValue=false)]
		public System.DateTime? DateType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.DateType))
					return this.Entity.DateType;
				else
					return null;
			}
			set { this.Entity.DateType = value; }
		}

		[DataMember(Name="DateTimeType", Order=0, EmitDefaultValue=false)]
		public System.DateTime? DateTimeType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.DateTimeType))
					return this.Entity.DateTimeType;
				else
					return null;
			}
			set { this.Entity.DateTimeType = value; }
		}

		[DataMember(Name="BlobType", Order=0, EmitDefaultValue=false)]
		public System.Byte[] BlobType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.BlobType))
					return this.Entity.BlobType;
				else
					return null;
			}
			set { this.Entity.BlobType = value; }
		}

		[DataMember(Name="TextType", Order=0, EmitDefaultValue=false)]
		public System.String TextType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.TextType))
					return this.Entity.TextType;
				else
					return null;
			}
			set { this.Entity.TextType = value; }
		}

		[DataMember(Name="TimeType", Order=0, EmitDefaultValue=false)]
		public System.TimeSpan? TimeType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.TimeType))
					return this.Entity.TimeType;
				else
					return null;
			}
			set { this.Entity.TimeType = value; }
		}

		[DataMember(Name="LongTextType", Order=0, EmitDefaultValue=false)]
		public System.String LongTextType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.LongTextType))
					return this.Entity.LongTextType;
				else
					return null;
			}
			set { this.Entity.LongTextType = value; }
		}

		[DataMember(Name="BinaryType", Order=0, EmitDefaultValue=false)]
		public System.String BinaryType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.BinaryType))
					return this.Entity.BinaryType;
				else
					return null;
			}
			set { this.Entity.BinaryType = value; }
		}

		[DataMember(Name="VarBinaryType", Order=0, EmitDefaultValue=false)]
		public System.String VarBinaryType
		{
			get 
			{ 
				
				if (this.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.VarBinaryType))
					return this.Entity.VarBinaryType;
				else
					return null;
			}
			set { this.Entity.VarBinaryType = value; }
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
		public Mysqltypetest2 Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Mysqltypetest2();
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
		public Mysqltypetest2 entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "Mysqltypetest2Collection")]
	[XmlType(TypeName="Mysqltypetest2CollectionProxyStub")]	
	[Serializable]
	public partial class Mysqltypetest2CollectionProxyStub 
	{
		protected Mysqltypetest2CollectionProxyStub() {}
		
		public Mysqltypetest2CollectionProxyStub(esEntityCollection<Mysqltypetest2> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public Mysqltypetest2CollectionProxyStub(esEntityCollection<Mysqltypetest2> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator Mysqltypetest2Collection(Mysqltypetest2CollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Mysqltypetest2);
		}
		
		public Mysqltypetest2CollectionProxyStub(esEntityCollection<Mysqltypetest2> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Mysqltypetest2 entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new Mysqltypetest2ProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new Mysqltypetest2ProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Mysqltypetest2 entity in coll.es.DeletedEntities)
				{
					Collection.Add(new Mysqltypetest2ProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<Mysqltypetest2ProxyStub> Collection = new List<Mysqltypetest2ProxyStub>();

		public Mysqltypetest2Collection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new Mysqltypetest2Collection();

				foreach (Mysqltypetest2ProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private Mysqltypetest2Collection _coll;
	}



	[Serializable]
	public partial class Mysqltypetest2Metadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected Mysqltypetest2Metadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.Id, 0, typeof(System.UInt32), esSystemType.UInt32);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.VarCharType, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.VarCharType;
			c.CharacterMaxLength = 20;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.CharType, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.CharType;
			c.CharacterMaxLength = 1;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.TimeStampType, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.TimeStampType;
			c.HasDefault = true;
			c.Default = @"CURRENT_TIMESTAMP";
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.DateType, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.DateType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.DateTimeType, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.DateTimeType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.BlobType, 6, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.BlobType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.TextType, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.TextType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.TimeType, 8, typeof(System.TimeSpan), esSystemType.TimeSpan);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.TimeType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.LongTextType, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.LongTextType;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.BinaryType, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.BinaryType;
			c.NumericPrecision = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.VarBinaryType, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.VarBinaryType;
			c.NumericPrecision = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public Mysqltypetest2Metadata Meta()
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
			 public const string VarCharType = "VarCharType";
			 public const string CharType = "CharType";
			 public const string TimeStampType = "TimeStampType";
			 public const string DateType = "DateType";
			 public const string DateTimeType = "DateTimeType";
			 public const string BlobType = "BlobType";
			 public const string TextType = "TextType";
			 public const string TimeType = "TimeType";
			 public const string LongTextType = "LongTextType";
			 public const string BinaryType = "BinaryType";
			 public const string VarBinaryType = "VarBinaryType";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string VarCharType = "VarCharType";
			 public const string CharType = "CharType";
			 public const string TimeStampType = "TimeStampType";
			 public const string DateType = "DateType";
			 public const string DateTimeType = "DateTimeType";
			 public const string BlobType = "BlobType";
			 public const string TextType = "TextType";
			 public const string TimeType = "TimeType";
			 public const string LongTextType = "LongTextType";
			 public const string BinaryType = "BinaryType";
			 public const string VarBinaryType = "VarBinaryType";
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
			lock (typeof(Mysqltypetest2Metadata))
			{
				if(Mysqltypetest2Metadata.mapDelegates == null)
				{
					Mysqltypetest2Metadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (Mysqltypetest2Metadata.meta == null)
				{
					Mysqltypetest2Metadata.meta = new Mysqltypetest2Metadata();
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


				meta.AddTypeMap("Id", new esTypeMap("INT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("CharType", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("TimeStampType", new esTypeMap("TIMESTAMP", "System.DateTime"));
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("DateTimeType", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("BlobType", new esTypeMap("BLOB", "System.Byte[]"));
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"));
				meta.AddTypeMap("TimeType", new esTypeMap("TIME", "System.TimeSpan"));
				meta.AddTypeMap("LongTextType", new esTypeMap("LONGTEXT", "System.String"));
				meta.AddTypeMap("BinaryType", new esTypeMap("BINARY", "System.String"));
				meta.AddTypeMap("VarBinaryType", new esTypeMap("VARBINARY", "System.String"));			
				meta.Catalog = "aggregatedb";
				
				
				meta.Source = "mysqltypetest2";
				meta.Destination = "mysqltypetest2";
				
				meta.spInsert = "proc_mysqltypetest2Insert";				
				meta.spUpdate = "proc_mysqltypetest2Update";		
				meta.spDelete = "proc_mysqltypetest2Delete";
				meta.spLoadAll = "proc_mysqltypetest2LoadAll";
				meta.spLoadByPrimaryKey = "proc_mysqltypetest2LoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private Mysqltypetest2Metadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
