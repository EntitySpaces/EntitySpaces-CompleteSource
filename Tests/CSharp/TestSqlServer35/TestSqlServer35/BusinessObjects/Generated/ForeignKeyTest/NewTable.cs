
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0530.0
EntitySpaces Driver  : SQL
Date Generated       : 10/14/2011 12:49:04 PM
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
	/// Encapsulates the 'NewTable' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("NewTable")]
	public partial class NewTable : esNewTable
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new NewTable();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int64 id)
		{
			var obj = new NewTable();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int64 id, esSqlAccessType sqlAccessType)
		{
			var obj = new NewTable();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("NewTableCollection")]
	public partial class NewTableCollection : esNewTableCollection, IEnumerable<NewTable>
	{
		public NewTable FindByPrimaryKey(System.Int64 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(NewTable))]
		public class NewTableCollectionWCFPacket : esCollectionWCFPacket<NewTableCollection>
		{
			public static implicit operator NewTableCollection(NewTableCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator NewTableCollectionWCFPacket(NewTableCollection collection)
			{
				return new NewTableCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class NewTableQuery : esNewTableQuery
	{
		public NewTableQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "NewTableQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(NewTableQuery query)
		{
			return NewTableQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator NewTableQuery(string query)
		{
			return (NewTableQuery)NewTableQuery.SerializeHelper.FromXml(query, typeof(NewTableQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esNewTable : esEntity
	{
		public esNewTable()
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
			NewTableQuery query = new NewTableQuery();
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
		/// Maps to NewTable.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(NewTableMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt64(NewTableMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(NewTableMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to NewTable.CustomerName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomerName
		{
			get
			{
				return base.GetSystemString(NewTableMetadata.ColumnNames.CustomerName);
			}
			
			set
			{
				if(base.SetSystemString(NewTableMetadata.ColumnNames.CustomerName, value))
				{
					OnPropertyChanged(NewTableMetadata.PropertyNames.CustomerName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to NewTable.LastName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(NewTableMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(NewTableMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(NewTableMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to NewTable.FirstName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(NewTableMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(NewTableMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(NewTableMetadata.PropertyNames.FirstName);
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
						case "CustomerName": this.str().CustomerName = (string)value; break;							
						case "LastName": this.str().LastName = (string)value; break;							
						case "FirstName": this.str().FirstName = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
								OnPropertyChanged(NewTableMetadata.PropertyNames.Id);
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
			public esStrings(esNewTable entity)
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
				
			public System.String CustomerName
			{
				get
				{
					System.String data = entity.CustomerName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerName = null;
					else entity.CustomerName = Convert.ToString(value);
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
			

			private esNewTable entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return NewTableMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public NewTableQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NewTableQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NewTableQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(NewTableQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private NewTableQuery query;		
	}



	[Serializable]
	abstract public partial class esNewTableCollection : esEntityCollection<NewTable>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return NewTableMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "NewTableCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public NewTableQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new NewTableQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(NewTableQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new NewTableQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(NewTableQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((NewTableQuery)query);
		}

		#endregion
		
		private NewTableQuery query;
	}



	[Serializable]
	abstract public partial class esNewTableQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return NewTableMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, NewTableMetadata.ColumnNames.Id, esSystemType.Int64); }
		} 
		
		public esQueryItem CustomerName
		{
			get { return new esQueryItem(this, NewTableMetadata.ColumnNames.CustomerName, esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, NewTableMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, NewTableMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class NewTable : esNewTable
	{

		
		
	}
	



	[Serializable]
	public partial class NewTableMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected NewTableMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(NewTableMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = NewTableMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NewTableMetadata.ColumnNames.CustomerName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = NewTableMetadata.PropertyNames.CustomerName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NewTableMetadata.ColumnNames.LastName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = NewTableMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
			c = new esColumnMetadata(NewTableMetadata.ColumnNames.FirstName, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = NewTableMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public NewTableMetadata Meta()
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
			 public const string CustomerName = "CustomerName";
			 public const string LastName = "LastName";
			 public const string FirstName = "FirstName";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string CustomerName = "CustomerName";
			 public const string LastName = "LastName";
			 public const string FirstName = "FirstName";
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
			lock (typeof(NewTableMetadata))
			{
				if(NewTableMetadata.mapDelegates == null)
				{
					NewTableMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (NewTableMetadata.meta == null)
				{
					NewTableMetadata.meta = new NewTableMetadata();
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
				meta.AddTypeMap("CustomerName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "NewTable";
				meta.Destination = "NewTable";
				
				meta.spInsert = "proc_NewTableInsert";				
				meta.spUpdate = "proc_NewTableUpdate";		
				meta.spDelete = "proc_NewTableDelete";
				meta.spLoadAll = "proc_NewTableLoadAll";
				meta.spLoadByPrimaryKey = "proc_NewTableLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private NewTableMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
