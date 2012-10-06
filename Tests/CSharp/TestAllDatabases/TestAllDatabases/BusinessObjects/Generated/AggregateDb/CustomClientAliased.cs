
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:43:27 AM
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
	/// Encapsulates the 'custom_client_aliased' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(CustomClientAliased))]	
	[XmlType("CustomClientAliased")]
	[Table(Name="CustomClientAliased")]
	public partial class CustomClientAliased : esCustomClientAliased
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new CustomClientAliased();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 autoKey)
		{
			var obj = new CustomClientAliased();
			obj.AutoKey = autoKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 autoKey, esSqlAccessType sqlAccessType)
		{
			var obj = new CustomClientAliased();
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
		public override System.DateTime? DateAddedAlias
		{
			get { return base.DateAddedAlias;  }
			set { base.DateAddedAlias = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateModified
		{
			get { return base.DateModified;  }
			set { base.DateModified = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String AddedBy
		{
			get { return base.AddedBy;  }
			set { base.AddedBy = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String ModifiedByAlias
		{
			get { return base.ModifiedByAlias;  }
			set { base.ModifiedByAlias = value; }
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
	[XmlType("CustomClientAliasedCollection")]
	public partial class CustomClientAliasedCollection : esCustomClientAliasedCollection, IEnumerable<CustomClientAliased>
	{
		public CustomClientAliased FindByPrimaryKey(System.Int32 autoKey)
		{
			return this.SingleOrDefault(e => e.AutoKey == autoKey);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(CustomClientAliased))]
		public class CustomClientAliasedCollectionWCFPacket : esCollectionWCFPacket<CustomClientAliasedCollection>
		{
			public static implicit operator CustomClientAliasedCollection(CustomClientAliasedCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomClientAliasedCollectionWCFPacket(CustomClientAliasedCollection collection)
			{
				return new CustomClientAliasedCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "CustomClientAliasedQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CustomClientAliasedQuery : esCustomClientAliasedQuery
	{
		public CustomClientAliasedQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomClientAliasedQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomClientAliasedQuery query)
		{
			return CustomClientAliasedQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomClientAliasedQuery(string query)
		{
			return (CustomClientAliasedQuery)CustomClientAliasedQuery.SerializeHelper.FromXml(query, typeof(CustomClientAliasedQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomClientAliased : EntityBase
	{
		public esCustomClientAliased()
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
			CustomClientAliasedQuery query = new CustomClientAliasedQuery();
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
		/// Maps to custom_client_aliased.auto_key
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? AutoKey
		{
			get
			{
				return base.GetSystemInt32(CustomClientAliasedMetadata.ColumnNames.AutoKey);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomClientAliasedMetadata.ColumnNames.AutoKey, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.AutoKey);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.first_name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(CustomClientAliasedMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(CustomClientAliasedMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.FirstName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.last_name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(CustomClientAliasedMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(CustomClientAliasedMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.age
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Age
		{
			get
			{
				return base.GetSystemInt32(CustomClientAliasedMetadata.ColumnNames.Age);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomClientAliasedMetadata.ColumnNames.Age, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.Age);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.date_added
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateAddedAlias
		{
			get
			{
				return base.GetSystemDateTime(CustomClientAliasedMetadata.ColumnNames.DateAddedAlias);
			}
			
			set
			{
				if(base.SetSystemDateTime(CustomClientAliasedMetadata.ColumnNames.DateAddedAlias, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.DateAddedAlias);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.date_modified
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateModified
		{
			get
			{
				return base.GetSystemDateTime(CustomClientAliasedMetadata.ColumnNames.DateModified);
			}
			
			set
			{
				if(base.SetSystemDateTime(CustomClientAliasedMetadata.ColumnNames.DateModified, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.DateModified);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.added_by
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String AddedBy
		{
			get
			{
				return base.GetSystemString(CustomClientAliasedMetadata.ColumnNames.AddedBy);
			}
			
			set
			{
				if(base.SetSystemString(CustomClientAliasedMetadata.ColumnNames.AddedBy, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.AddedBy);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.modified_by
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ModifiedByAlias
		{
			get
			{
				return base.GetSystemString(CustomClientAliasedMetadata.ColumnNames.ModifiedByAlias);
			}
			
			set
			{
				if(base.SetSystemString(CustomClientAliasedMetadata.ColumnNames.ModifiedByAlias, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.ModifiedByAlias);
				}
			}
		}		
		
		/// <summary>
		/// Maps to custom_client_aliased.es_version
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? EsVersion
		{
			get
			{
				return base.GetSystemInt32(CustomClientAliasedMetadata.ColumnNames.EsVersion);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomClientAliasedMetadata.ColumnNames.EsVersion, value))
				{
					OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.EsVersion);
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
						case "DateAddedAlias": this.str().DateAddedAlias = (string)value; break;							
						case "DateModified": this.str().DateModified = (string)value; break;							
						case "AddedBy": this.str().AddedBy = (string)value; break;							
						case "ModifiedByAlias": this.str().ModifiedByAlias = (string)value; break;							
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
								OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.AutoKey);
							break;
						
						case "Age":
						
							if (value == null || value is System.Int32)
								this.Age = (System.Int32?)value;
								OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.Age);
							break;
						
						case "DateAddedAlias":
						
							if (value == null || value is System.DateTime)
								this.DateAddedAlias = (System.DateTime?)value;
								OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.DateAddedAlias);
							break;
						
						case "DateModified":
						
							if (value == null || value is System.DateTime)
								this.DateModified = (System.DateTime?)value;
								OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.DateModified);
							break;
						
						case "EsVersion":
						
							if (value == null || value is System.Int32)
								this.EsVersion = (System.Int32?)value;
								OnPropertyChanged(CustomClientAliasedMetadata.PropertyNames.EsVersion);
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
			public esStrings(esCustomClientAliased entity)
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
				
			public System.String DateAddedAlias
			{
				get
				{
					System.DateTime? data = entity.DateAddedAlias;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateAddedAlias = null;
					else entity.DateAddedAlias = Convert.ToDateTime(value);
				}
			}
				
			public System.String DateModified
			{
				get
				{
					System.DateTime? data = entity.DateModified;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateModified = null;
					else entity.DateModified = Convert.ToDateTime(value);
				}
			}
				
			public System.String AddedBy
			{
				get
				{
					System.String data = entity.AddedBy;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AddedBy = null;
					else entity.AddedBy = Convert.ToString(value);
				}
			}
				
			public System.String ModifiedByAlias
			{
				get
				{
					System.String data = entity.ModifiedByAlias;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ModifiedByAlias = null;
					else entity.ModifiedByAlias = Convert.ToString(value);
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
			

			private esCustomClientAliased entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomClientAliasedMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomClientAliasedQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomClientAliasedQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomClientAliasedQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomClientAliasedQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomClientAliasedQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomClientAliasedCollection : CollectionBase<CustomClientAliased>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomClientAliasedMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomClientAliasedCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomClientAliasedQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomClientAliasedQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomClientAliasedQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomClientAliasedQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomClientAliasedQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomClientAliasedQuery)query);
		}

		#endregion
		
		private CustomClientAliasedQuery query;
	}



	[Serializable]
	abstract public partial class esCustomClientAliasedQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomClientAliasedMetadata.Meta();
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
				case "DateAddedAlias": return this.DateAddedAlias;
				case "DateModified": return this.DateModified;
				case "AddedBy": return this.AddedBy;
				case "ModifiedByAlias": return this.ModifiedByAlias;
				case "EsVersion": return this.EsVersion;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem AutoKey
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.AutoKey, esSystemType.Int32); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.Age, esSystemType.Int32); }
		} 
		
		public esQueryItem DateAddedAlias
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.DateAddedAlias, esSystemType.DateTime); }
		} 
		
		public esQueryItem DateModified
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.DateModified, esSystemType.DateTime); }
		} 
		
		public esQueryItem AddedBy
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.AddedBy, esSystemType.String); }
		} 
		
		public esQueryItem ModifiedByAlias
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.ModifiedByAlias, esSystemType.String); }
		} 
		
		public esQueryItem EsVersion
		{
			get { return new esQueryItem(this, CustomClientAliasedMetadata.ColumnNames.EsVersion, esSystemType.Int32); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class CustomClientAliasedMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomClientAliasedMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.AutoKey, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.AutoKey;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.FirstName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.LastName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.Age, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.Age;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((40))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.DateAddedAlias, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.DateAddedAlias;
			c.IsNullable = true;
			c.Alias = "DateAddedAlias";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.DateModified, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.DateModified;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.AddedBy, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.AddedBy;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.ModifiedByAlias, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.ModifiedByAlias;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			c.Alias = "ModifiedByAlias";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomClientAliasedMetadata.ColumnNames.EsVersion, 8, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomClientAliasedMetadata.PropertyNames.EsVersion;
			c.NumericPrecision = 10;
			c.IsEntitySpacesConcurrency = true;
			m_columns.Add(c);
				
			m_columns.DateAdded = new esColumnMetadataCollection.SpecialDate();
			m_columns.DateAdded.ColumnName = "date_added";
			m_columns.DateAdded.IsEnabled = true;
			m_columns.DateAdded.Type = DateType.ClientSide;
			m_columns.DateAdded.ClientType = ClientType.UtcNow;

			m_columns.DateModified = new esColumnMetadataCollection.SpecialDate();
			m_columns.DateModified.ColumnName = "date_modified";
			m_columns.DateModified.IsEnabled = true;
			m_columns.DateModified.Type = DateType.ClientSide;
			m_columns.DateModified.ClientType = ClientType.UtcNow;

			m_columns.AddedBy = new esColumnMetadataCollection.AuditingInfo();
			m_columns.AddedBy.ColumnName = "added_by";
			m_columns.AddedBy.IsEnabled = true;
			m_columns.AddedBy.UseEventHandler = true;

			m_columns.ModifiedBy = new esColumnMetadataCollection.AuditingInfo();
			m_columns.ModifiedBy.ColumnName = "modified_by";
			m_columns.ModifiedBy.IsEnabled = true;
			m_columns.ModifiedBy.UseEventHandler = true;

		}
		#endregion	
	
		static public CustomClientAliasedMetadata Meta()
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
			 public const string AutoKey = "auto_key";
			 public const string FirstName = "first_name";
			 public const string LastName = "last_name";
			 public const string Age = "age";
			 public const string DateAddedAlias = "date_added";
			 public const string DateModified = "date_modified";
			 public const string AddedBy = "added_by";
			 public const string ModifiedByAlias = "modified_by";
			 public const string EsVersion = "es_version";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string AutoKey = "AutoKey";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Age = "Age";
			 public const string DateAddedAlias = "DateAddedAlias";
			 public const string DateModified = "DateModified";
			 public const string AddedBy = "AddedBy";
			 public const string ModifiedByAlias = "ModifiedByAlias";
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
			lock (typeof(CustomClientAliasedMetadata))
			{
				if(CustomClientAliasedMetadata.mapDelegates == null)
				{
					CustomClientAliasedMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomClientAliasedMetadata.meta == null)
				{
					CustomClientAliasedMetadata.meta = new CustomClientAliasedMetadata();
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


				meta.AddTypeMap("AutoKey", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DateAddedAlias", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("DateModified", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("AddedBy", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ModifiedByAlias", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("EsVersion", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "custom_client_aliased";
				meta.Destination = "custom_client_aliased";
				
				meta.spInsert = "proc_custom_client_aliasedInsert";				
				meta.spUpdate = "proc_custom_client_aliasedUpdate";		
				meta.spDelete = "proc_custom_client_aliasedDelete";
				meta.spLoadAll = "proc_custom_client_aliasedLoadAll";
				meta.spLoadByPrimaryKey = "proc_custom_client_aliasedLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomClientAliasedMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
