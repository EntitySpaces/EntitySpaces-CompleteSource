
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
	/// Encapsulates the 'CUSTOM_SERVER_ALIASED' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(CustomServerAliased))]	
	[XmlType("CustomServerAliased")]
	[Table(Name="CustomServerAliased")]
	public partial class CustomServerAliased : esCustomServerAliased
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new CustomServerAliased();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 autoKey)
		{
			var obj = new CustomServerAliased();
			obj.AutoKey = autoKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 autoKey, esSqlAccessType sqlAccessType)
		{
			var obj = new CustomServerAliased();
			obj.AutoKey = autoKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? AutoKey
		{
			get { return base.AutoKey;  }
			set { base.AutoKey = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String FirstName
		{
			get { return base.FirstName;  }
			set { base.FirstName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String LastName
		{
			get { return base.LastName;  }
			set { base.LastName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int32? Age
		{
			get { return base.Age;  }
			set { base.Age = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateAdded
		{
			get { return base.DateAdded;  }
			set { base.DateAdded = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateModifiedAlias
		{
			get { return base.DateModifiedAlias;  }
			set { base.DateModifiedAlias = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String AddedByAlias
		{
			get { return base.AddedByAlias;  }
			set { base.AddedByAlias = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String ModifiedBy
		{
			get { return base.ModifiedBy;  }
			set { base.ModifiedBy = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int32? EsVersion
		{
			get { return base.EsVersion;  }
			set { base.EsVersion = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomServerAliasedCollection")]
	public partial class CustomServerAliasedCollection : esCustomServerAliasedCollection, IEnumerable<CustomServerAliased>
	{
		public CustomServerAliased FindByPrimaryKey(System.Int32 autoKey)
		{
			return this.SingleOrDefault(e => e.AutoKey == autoKey);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(CustomServerAliased))]
		public class CustomServerAliasedCollectionWCFPacket : esCollectionWCFPacket<CustomServerAliasedCollection>
		{
			public static implicit operator CustomServerAliasedCollection(CustomServerAliasedCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomServerAliasedCollectionWCFPacket(CustomServerAliasedCollection collection)
			{
				return new CustomServerAliasedCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "CustomServerAliasedQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CustomServerAliasedQuery : esCustomServerAliasedQuery
	{
		public CustomServerAliasedQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomServerAliasedQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomServerAliasedQuery query)
		{
			return CustomServerAliasedQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomServerAliasedQuery(string query)
		{
			return (CustomServerAliasedQuery)CustomServerAliasedQuery.SerializeHelper.FromXml(query, typeof(CustomServerAliasedQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomServerAliased : EntityBase
	{
		public esCustomServerAliased()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 autoKey)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(autoKey);
			else
				return LoadByPrimaryKeyStoredProcedure(autoKey);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 autoKey)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(autoKey);
			else
				return LoadByPrimaryKeyStoredProcedure(autoKey);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 autoKey)
		{
			CustomServerAliasedQuery query = new CustomServerAliasedQuery();
			query.Where(query.AutoKey == autoKey);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 autoKey)
		{
			esParameters parms = new esParameters();
			parms.Add("AutoKey", autoKey);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.AUTO_KEY
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? AutoKey
		{
			get
			{
				return base.GetSystemInt32(CustomServerAliasedMetadata.ColumnNames.AutoKey);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomServerAliasedMetadata.ColumnNames.AutoKey, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.AutoKey);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.FIRST_NAME
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(CustomServerAliasedMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(CustomServerAliasedMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.FirstName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.LAST_NAME
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(CustomServerAliasedMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(CustomServerAliasedMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.AGE
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Age
		{
			get
			{
				return base.GetSystemInt32(CustomServerAliasedMetadata.ColumnNames.Age);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomServerAliasedMetadata.ColumnNames.Age, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.Age);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.DATE_ADDED
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateAdded
		{
			get
			{
				return base.GetSystemDateTime(CustomServerAliasedMetadata.ColumnNames.DateAdded);
			}
			
			set
			{
				if(base.SetSystemDateTime(CustomServerAliasedMetadata.ColumnNames.DateAdded, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.DateAdded);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.DATE_MODIFIED
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateModifiedAlias
		{
			get
			{
				return base.GetSystemDateTime(CustomServerAliasedMetadata.ColumnNames.DateModifiedAlias);
			}
			
			set
			{
				if(base.SetSystemDateTime(CustomServerAliasedMetadata.ColumnNames.DateModifiedAlias, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.DateModifiedAlias);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.ADDED_BY
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String AddedByAlias
		{
			get
			{
				return base.GetSystemString(CustomServerAliasedMetadata.ColumnNames.AddedByAlias);
			}
			
			set
			{
				if(base.SetSystemString(CustomServerAliasedMetadata.ColumnNames.AddedByAlias, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.AddedByAlias);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.MODIFIED_BY
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ModifiedBy
		{
			get
			{
				return base.GetSystemString(CustomServerAliasedMetadata.ColumnNames.ModifiedBy);
			}
			
			set
			{
				if(base.SetSystemString(CustomServerAliasedMetadata.ColumnNames.ModifiedBy, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.ModifiedBy);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CUSTOM_SERVER_ALIASED.ES_VERSION
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? EsVersion
		{
			get
			{
				return base.GetSystemInt32(CustomServerAliasedMetadata.ColumnNames.EsVersion);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomServerAliasedMetadata.ColumnNames.EsVersion, value))
				{
					OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.EsVersion);
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
						case "AutoKey": this.str().AutoKey = (string)value; break;							
						case "FirstName": this.str().FirstName = (string)value; break;							
						case "LastName": this.str().LastName = (string)value; break;							
						case "Age": this.str().Age = (string)value; break;							
						case "DateAdded": this.str().DateAdded = (string)value; break;							
						case "DateModifiedAlias": this.str().DateModifiedAlias = (string)value; break;							
						case "AddedByAlias": this.str().AddedByAlias = (string)value; break;							
						case "ModifiedBy": this.str().ModifiedBy = (string)value; break;							
						case "EsVersion": this.str().EsVersion = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "AutoKey":
						
							if (value == null || value is System.Int32)
								this.AutoKey = (System.Int32?)value;
								OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.AutoKey);
							break;
						
						case "Age":
						
							if (value == null || value is System.Int32)
								this.Age = (System.Int32?)value;
								OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.Age);
							break;
						
						case "DateAdded":
						
							if (value == null || value is System.DateTime)
								this.DateAdded = (System.DateTime?)value;
								OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.DateAdded);
							break;
						
						case "DateModifiedAlias":
						
							if (value == null || value is System.DateTime)
								this.DateModifiedAlias = (System.DateTime?)value;
								OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.DateModifiedAlias);
							break;
						
						case "EsVersion":
						
							if (value == null || value is System.Int32)
								this.EsVersion = (System.Int32?)value;
								OnPropertyChanged(CustomServerAliasedMetadata.PropertyNames.EsVersion);
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
			public esStrings(esCustomServerAliased entity)
			{
				this.entity = entity;
			}
			
	
			public System.String AutoKey
			{
				get
				{
					System.Int32? data = entity.AutoKey;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AutoKey = null;
					else entity.AutoKey = Convert.ToInt32(value);
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
				
			public System.String DateAdded
			{
				get
				{
					System.DateTime? data = entity.DateAdded;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateAdded = null;
					else entity.DateAdded = Convert.ToDateTime(value);
				}
			}
				
			public System.String DateModifiedAlias
			{
				get
				{
					System.DateTime? data = entity.DateModifiedAlias;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateModifiedAlias = null;
					else entity.DateModifiedAlias = Convert.ToDateTime(value);
				}
			}
				
			public System.String AddedByAlias
			{
				get
				{
					System.String data = entity.AddedByAlias;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AddedByAlias = null;
					else entity.AddedByAlias = Convert.ToString(value);
				}
			}
				
			public System.String ModifiedBy
			{
				get
				{
					System.String data = entity.ModifiedBy;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ModifiedBy = null;
					else entity.ModifiedBy = Convert.ToString(value);
				}
			}
				
			public System.String EsVersion
			{
				get
				{
					System.Int32? data = entity.EsVersion;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EsVersion = null;
					else entity.EsVersion = Convert.ToInt32(value);
				}
			}
			

			private esCustomServerAliased entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomServerAliasedMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomServerAliasedQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomServerAliasedQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomServerAliasedQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomServerAliasedQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomServerAliasedQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomServerAliasedCollection : CollectionBase<CustomServerAliased>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomServerAliasedMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomServerAliasedCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomServerAliasedQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomServerAliasedQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomServerAliasedQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomServerAliasedQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomServerAliasedQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomServerAliasedQuery)query);
		}

		#endregion
		
		private CustomServerAliasedQuery query;
	}



	[Serializable]
	abstract public partial class esCustomServerAliasedQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomServerAliasedMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "AutoKey": return this.AutoKey;
				case "FirstName": return this.FirstName;
				case "LastName": return this.LastName;
				case "Age": return this.Age;
				case "DateAdded": return this.DateAdded;
				case "DateModifiedAlias": return this.DateModifiedAlias;
				case "AddedByAlias": return this.AddedByAlias;
				case "ModifiedBy": return this.ModifiedBy;
				case "EsVersion": return this.EsVersion;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem AutoKey
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.AutoKey, esSystemType.Int32); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.Age, esSystemType.Int32); }
		} 
		
		public esQueryItem DateAdded
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.DateAdded, esSystemType.DateTime); }
		} 
		
		public esQueryItem DateModifiedAlias
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.DateModifiedAlias, esSystemType.DateTime); }
		} 
		
		public esQueryItem AddedByAlias
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.AddedByAlias, esSystemType.String); }
		} 
		
		public esQueryItem ModifiedBy
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.ModifiedBy, esSystemType.String); }
		} 
		
		public esQueryItem EsVersion
		{
			get { return new esQueryItem(this, CustomServerAliasedMetadata.ColumnNames.EsVersion, esSystemType.Int32); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class CustomServerAliasedMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomServerAliasedMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.AutoKey, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.AutoKey;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.FirstName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.LastName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.Age, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.Age;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((30))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.DateAdded, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.DateAdded;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.DateModifiedAlias, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.DateModifiedAlias;
			c.IsNullable = true;
			c.Alias = "DateModifiedAlias";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.AddedByAlias, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.AddedByAlias;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			c.Alias = "AddedByAlias";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.ModifiedBy, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.ModifiedBy;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomServerAliasedMetadata.ColumnNames.EsVersion, 8, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomServerAliasedMetadata.PropertyNames.EsVersion;
			c.NumericPrecision = 10;
			c.IsEntitySpacesConcurrency = true;
			m_columns.Add(c);
				
			m_columns.DateAdded = new esColumnMetadataCollection.SpecialDate();
			m_columns.DateAdded.ColumnName = "DATE_ADDED";
			m_columns.DateAdded.IsEnabled = true;
			m_columns.DateAdded.Type = DateType.ServerSide;

			m_columns.DateModified = new esColumnMetadataCollection.SpecialDate();
			m_columns.DateModified.ColumnName = "DATE_MODIFIED";
			m_columns.DateModified.IsEnabled = true;
			m_columns.DateModified.Type = DateType.ServerSide;

			m_columns.AddedBy = new esColumnMetadataCollection.AuditingInfo();
			m_columns.AddedBy.ColumnName = "ADDED_BY";
			m_columns.AddedBy.IsEnabled = true;
			m_columns.AddedBy.UseEventHandler = false;

			m_columns.ModifiedBy = new esColumnMetadataCollection.AuditingInfo();
			m_columns.ModifiedBy.ColumnName = "MODIFIED_BY";
			m_columns.ModifiedBy.IsEnabled = true;
			m_columns.ModifiedBy.UseEventHandler = false;

		}
		#endregion	
	
		static public CustomServerAliasedMetadata Meta()
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
			 public const string AutoKey = "AUTO_KEY";
			 public const string FirstName = "FIRST_NAME";
			 public const string LastName = "LAST_NAME";
			 public const string Age = "AGE";
			 public const string DateAdded = "DATE_ADDED";
			 public const string DateModifiedAlias = "DATE_MODIFIED";
			 public const string AddedByAlias = "ADDED_BY";
			 public const string ModifiedBy = "MODIFIED_BY";
			 public const string EsVersion = "ES_VERSION";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string AutoKey = "AutoKey";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Age = "Age";
			 public const string DateAdded = "DateAdded";
			 public const string DateModifiedAlias = "DateModifiedAlias";
			 public const string AddedByAlias = "AddedByAlias";
			 public const string ModifiedBy = "ModifiedBy";
			 public const string EsVersion = "EsVersion";
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
			lock (typeof(CustomServerAliasedMetadata))
			{
				if(CustomServerAliasedMetadata.mapDelegates == null)
				{
					CustomServerAliasedMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomServerAliasedMetadata.meta == null)
				{
					CustomServerAliasedMetadata.meta = new CustomServerAliasedMetadata();
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


				meta["DateAdded.ServerSideText"] = "getutcdate()";

				meta["DateModified.ServerSideText"] = "getutcdate()";

				meta["AddedBy.ServerSideText"] = "dbo.GetCustomUser()";

				meta["ModifiedBy.ServerSideText"] = "dbo.GetCustomUser()";

				meta.AddTypeMap("AutoKey", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("DateModifiedAlias", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("AddedByAlias", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ModifiedBy", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("EsVersion", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "CUSTOM_SERVER_ALIASED";
				meta.Destination = "CUSTOM_SERVER_ALIASED";
				
				meta.spInsert = "proc_CUSTOM_SERVER_ALIASEDInsert";				
				meta.spUpdate = "proc_CUSTOM_SERVER_ALIASEDUpdate";		
				meta.spDelete = "proc_CUSTOM_SERVER_ALIASEDDelete";
				meta.spLoadAll = "proc_CUSTOM_SERVER_ALIASEDLoadAll";
				meta.spLoadByPrimaryKey = "proc_CUSTOM_SERVER_ALIASEDLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomServerAliasedMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
