
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0530.0
EntitySpaces Driver  : Oracle
Date Generated       : 6/1/2011 2:11:25 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'MSC_ADMIN' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("MSC_ADMIN")]
	public partial class MSC_ADMIN : esMSC_ADMIN
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new MSC_ADMIN();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Decimal aDMIN_ID)
		{
			var obj = new MSC_ADMIN();
			obj.ADMIN_ID = aDMIN_ID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Decimal aDMIN_ID, esSqlAccessType sqlAccessType)
		{
			var obj = new MSC_ADMIN();
			obj.ADMIN_ID = aDMIN_ID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("MSC_ADMINCollection")]
	public partial class MSC_ADMINCollection : esMSC_ADMINCollection, IEnumerable<MSC_ADMIN>
	{
		public MSC_ADMIN FindByPrimaryKey(System.Decimal aDMIN_ID)
		{
			return this.SingleOrDefault(e => e.ADMIN_ID == aDMIN_ID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(MSC_ADMIN))]
		public class MSC_ADMINCollectionWCFPacket : esCollectionWCFPacket<MSC_ADMINCollection>
		{
			public static implicit operator MSC_ADMINCollection(MSC_ADMINCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator MSC_ADMINCollectionWCFPacket(MSC_ADMINCollection collection)
			{
				return new MSC_ADMINCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class MSC_ADMINQuery : esMSC_ADMINQuery
	{
		public MSC_ADMINQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "MSC_ADMINQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(MSC_ADMINQuery query)
		{
			return MSC_ADMINQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator MSC_ADMINQuery(string query)
		{
			return (MSC_ADMINQuery)MSC_ADMINQuery.SerializeHelper.FromXml(query, typeof(MSC_ADMINQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esMSC_ADMIN : esEntity
	{
		public esMSC_ADMIN()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Decimal aDMIN_ID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(aDMIN_ID);
			else
				return LoadByPrimaryKeyStoredProcedure(aDMIN_ID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Decimal aDMIN_ID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(aDMIN_ID);
			else
				return LoadByPrimaryKeyStoredProcedure(aDMIN_ID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Decimal aDMIN_ID)
		{
			MSC_ADMINQuery query = new MSC_ADMINQuery();
			query.Where(query.ADMIN_ID == aDMIN_ID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Decimal aDMIN_ID)
		{
			esParameters parms = new esParameters();
			parms.Add("ADMIN_ID", aDMIN_ID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to MSC_ADMIN.ADMIN_ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? ADMIN_ID
		{
			get
			{
				return base.GetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ID);
			}
			
			set
			{
				if(base.SetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ID, value))
				{
					OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to MSC_ADMIN.ADMIN_NETID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ADMIN_NETID
		{
			get
			{
				return base.GetSystemString(MSC_ADMINMetadata.ColumnNames.ADMIN_NETID);
			}
			
			set
			{
				if(base.SetSystemString(MSC_ADMINMetadata.ColumnNames.ADMIN_NETID, value))
				{
					OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_NETID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to MSC_ADMIN.ADMIN_ROLE_MASTER
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? ADMIN_ROLE_MASTER
		{
			get
			{
				return base.GetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_MASTER);
			}
			
			set
			{
				if(base.SetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_MASTER, value))
				{
					OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_MASTER);
				}
			}
		}		
		
		/// <summary>
		/// Maps to MSC_ADMIN.ADMIN_ROLE_KEYDESK
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? ADMIN_ROLE_KEYDESK
		{
			get
			{
				return base.GetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_KEYDESK);
			}
			
			set
			{
				if(base.SetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_KEYDESK, value))
				{
					OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_KEYDESK);
				}
			}
		}		
		
		/// <summary>
		/// Maps to MSC_ADMIN.ADMIN_ROLE_PAYMENT
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? ADMIN_ROLE_PAYMENT
		{
			get
			{
				return base.GetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_PAYMENT);
			}
			
			set
			{
				if(base.SetSystemDecimal(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_PAYMENT, value))
				{
					OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_PAYMENT);
				}
			}
		}		
		
		/// <summary>
		/// Maps to MSC_ADMIN.C_DATE
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? C_DATE
		{
			get
			{
				return base.GetSystemDateTime(MSC_ADMINMetadata.ColumnNames.C_DATE);
			}
			
			set
			{
				if(base.SetSystemDateTime(MSC_ADMINMetadata.ColumnNames.C_DATE, value))
				{
					OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.C_DATE);
				}
			}
		}		
		
		/// <summary>
		/// Maps to MSC_ADMIN.M_DATE
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? M_DATE
		{
			get
			{
				return base.GetSystemDateTime(MSC_ADMINMetadata.ColumnNames.M_DATE);
			}
			
			set
			{
				if(base.SetSystemDateTime(MSC_ADMINMetadata.ColumnNames.M_DATE, value))
				{
					OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.M_DATE);
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
						case "ADMIN_ID": this.str().ADMIN_ID = (string)value; break;							
						case "ADMIN_NETID": this.str().ADMIN_NETID = (string)value; break;							
						case "ADMIN_ROLE_MASTER": this.str().ADMIN_ROLE_MASTER = (string)value; break;							
						case "ADMIN_ROLE_KEYDESK": this.str().ADMIN_ROLE_KEYDESK = (string)value; break;							
						case "ADMIN_ROLE_PAYMENT": this.str().ADMIN_ROLE_PAYMENT = (string)value; break;							
						case "C_DATE": this.str().C_DATE = (string)value; break;							
						case "M_DATE": this.str().M_DATE = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ADMIN_ID":
						
							if (value == null || value is System.Decimal)
								this.ADMIN_ID = (System.Decimal?)value;
								OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ID);
							break;
						
						case "ADMIN_ROLE_MASTER":
						
							if (value == null || value is System.Decimal)
								this.ADMIN_ROLE_MASTER = (System.Decimal?)value;
								OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_MASTER);
							break;
						
						case "ADMIN_ROLE_KEYDESK":
						
							if (value == null || value is System.Decimal)
								this.ADMIN_ROLE_KEYDESK = (System.Decimal?)value;
								OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_KEYDESK);
							break;
						
						case "ADMIN_ROLE_PAYMENT":
						
							if (value == null || value is System.Decimal)
								this.ADMIN_ROLE_PAYMENT = (System.Decimal?)value;
								OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_PAYMENT);
							break;
						
						case "C_DATE":
						
							if (value == null || value is System.DateTime)
								this.C_DATE = (System.DateTime?)value;
								OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.C_DATE);
							break;
						
						case "M_DATE":
						
							if (value == null || value is System.DateTime)
								this.M_DATE = (System.DateTime?)value;
								OnPropertyChanged(MSC_ADMINMetadata.PropertyNames.M_DATE);
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
			public esStrings(esMSC_ADMIN entity)
			{
				this.entity = entity;
			}
			
	
			public System.String ADMIN_ID
			{
				get
				{
					System.Decimal? data = entity.ADMIN_ID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ADMIN_ID = null;
					else entity.ADMIN_ID = Convert.ToDecimal(value);
				}
			}
				
			public System.String ADMIN_NETID
			{
				get
				{
					System.String data = entity.ADMIN_NETID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ADMIN_NETID = null;
					else entity.ADMIN_NETID = Convert.ToString(value);
				}
			}
				
			public System.String ADMIN_ROLE_MASTER
			{
				get
				{
					System.Decimal? data = entity.ADMIN_ROLE_MASTER;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ADMIN_ROLE_MASTER = null;
					else entity.ADMIN_ROLE_MASTER = Convert.ToDecimal(value);
				}
			}
				
			public System.String ADMIN_ROLE_KEYDESK
			{
				get
				{
					System.Decimal? data = entity.ADMIN_ROLE_KEYDESK;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ADMIN_ROLE_KEYDESK = null;
					else entity.ADMIN_ROLE_KEYDESK = Convert.ToDecimal(value);
				}
			}
				
			public System.String ADMIN_ROLE_PAYMENT
			{
				get
				{
					System.Decimal? data = entity.ADMIN_ROLE_PAYMENT;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ADMIN_ROLE_PAYMENT = null;
					else entity.ADMIN_ROLE_PAYMENT = Convert.ToDecimal(value);
				}
			}
				
			public System.String C_DATE
			{
				get
				{
					System.DateTime? data = entity.C_DATE;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.C_DATE = null;
					else entity.C_DATE = Convert.ToDateTime(value);
				}
			}
				
			public System.String M_DATE
			{
				get
				{
					System.DateTime? data = entity.M_DATE;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.M_DATE = null;
					else entity.M_DATE = Convert.ToDateTime(value);
				}
			}
			

			private esMSC_ADMIN entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return MSC_ADMINMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public MSC_ADMINQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MSC_ADMINQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MSC_ADMINQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(MSC_ADMINQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private MSC_ADMINQuery query;		
	}



	[Serializable]
	abstract public partial class esMSC_ADMINCollection : esEntityCollection<MSC_ADMIN>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return MSC_ADMINMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "MSC_ADMINCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public MSC_ADMINQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new MSC_ADMINQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(MSC_ADMINQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new MSC_ADMINQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(MSC_ADMINQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((MSC_ADMINQuery)query);
		}

		#endregion
		
		private MSC_ADMINQuery query;
	}



	[Serializable]
	abstract public partial class esMSC_ADMINQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return MSC_ADMINMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem ADMIN_ID
		{
			get { return new esQueryItem(this, MSC_ADMINMetadata.ColumnNames.ADMIN_ID, esSystemType.Decimal); }
		} 
		
		public esQueryItem ADMIN_NETID
		{
			get { return new esQueryItem(this, MSC_ADMINMetadata.ColumnNames.ADMIN_NETID, esSystemType.String); }
		} 
		
		public esQueryItem ADMIN_ROLE_MASTER
		{
			get { return new esQueryItem(this, MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_MASTER, esSystemType.Decimal); }
		} 
		
		public esQueryItem ADMIN_ROLE_KEYDESK
		{
			get { return new esQueryItem(this, MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_KEYDESK, esSystemType.Decimal); }
		} 
		
		public esQueryItem ADMIN_ROLE_PAYMENT
		{
			get { return new esQueryItem(this, MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_PAYMENT, esSystemType.Decimal); }
		} 
		
		public esQueryItem C_DATE
		{
			get { return new esQueryItem(this, MSC_ADMINMetadata.ColumnNames.C_DATE, esSystemType.DateTime); }
		} 
		
		public esQueryItem M_DATE
		{
			get { return new esQueryItem(this, MSC_ADMINMetadata.ColumnNames.M_DATE, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class MSC_ADMINMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected MSC_ADMINMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(MSC_ADMINMetadata.ColumnNames.ADMIN_ID, 0, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MSC_ADMINMetadata.PropertyNames.ADMIN_ID;
			c.IsInPrimaryKey = true;
            c.IsAutoIncrement = true;
            c.NumericPrecision = 38;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MSC_ADMINMetadata.ColumnNames.ADMIN_NETID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = MSC_ADMINMetadata.PropertyNames.ADMIN_NETID;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_MASTER, 2, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_MASTER;
			c.NumericPrecision = 1;
            c.HasDefault = true;
            c.Default = @"0";
			m_columns.Add(c);
				
			c = new esColumnMetadata(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_KEYDESK, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_KEYDESK;
			c.NumericPrecision = 1;
            c.HasDefault = true;
            c.Default = @"0";
			m_columns.Add(c);
				
			c = new esColumnMetadata(MSC_ADMINMetadata.ColumnNames.ADMIN_ROLE_PAYMENT, 4, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = MSC_ADMINMetadata.PropertyNames.ADMIN_ROLE_PAYMENT;
			c.NumericPrecision = 1;
            c.HasDefault = true;
            c.Default = @"0";
			m_columns.Add(c);
				
			c = new esColumnMetadata(MSC_ADMINMetadata.ColumnNames.C_DATE, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = MSC_ADMINMetadata.PropertyNames.C_DATE;
			m_columns.Add(c);
				
			c = new esColumnMetadata(MSC_ADMINMetadata.ColumnNames.M_DATE, 6, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = MSC_ADMINMetadata.PropertyNames.M_DATE;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public MSC_ADMINMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string ADMIN_ID = "ADMIN_ID";
			 public const string ADMIN_NETID = "ADMIN_NETID";
			 public const string ADMIN_ROLE_MASTER = "ADMIN_ROLE_MASTER";
			 public const string ADMIN_ROLE_KEYDESK = "ADMIN_ROLE_KEYDESK";
			 public const string ADMIN_ROLE_PAYMENT = "ADMIN_ROLE_PAYMENT";
			 public const string C_DATE = "C_DATE";
			 public const string M_DATE = "M_DATE";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ADMIN_ID = "ADMIN_ID";
			 public const string ADMIN_NETID = "ADMIN_NETID";
			 public const string ADMIN_ROLE_MASTER = "ADMIN_ROLE_MASTER";
			 public const string ADMIN_ROLE_KEYDESK = "ADMIN_ROLE_KEYDESK";
			 public const string ADMIN_ROLE_PAYMENT = "ADMIN_ROLE_PAYMENT";
			 public const string C_DATE = "C_DATE";
			 public const string M_DATE = "M_DATE";
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
			lock (typeof(MSC_ADMINMetadata))
			{
				if(MSC_ADMINMetadata.mapDelegates == null)
				{
					MSC_ADMINMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MSC_ADMINMetadata.meta == null)
				{
					MSC_ADMINMetadata.meta = new MSC_ADMINMetadata();
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


				meta.AddTypeMap("ADMIN_ID", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ADMIN_NETID", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("ADMIN_ROLE_MASTER", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ADMIN_ROLE_KEYDESK", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ADMIN_ROLE_PAYMENT", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("C_DATE", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("M_DATE", new esTypeMap("DATE", "System.DateTime"));
                meta["AutoKeyText"] = "S_MSC_ADMIN";
                meta.Catalog = "MUSIC";
				meta.Schema = "MUSIC";
				
				meta.Source = "MSC_ADMIN";
				meta.Destination = "MSC_ADMIN";
				
				meta.spInsert = "proc_MSC_ADMINInsert";				
				meta.spUpdate = "proc_MSC_ADMINUpdate";		
				meta.spDelete = "proc_MSC_ADMINDelete";
				meta.spLoadAll = "proc_MSC_ADMINLoadAll";
				meta.spLoadByPrimaryKey = "proc_MSC_ADMINLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private MSC_ADMINMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
