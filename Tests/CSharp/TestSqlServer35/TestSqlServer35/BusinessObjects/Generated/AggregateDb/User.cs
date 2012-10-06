
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0627.0
EntitySpaces Driver  : SQL
Date Generated       : 7/19/2011 8:20:07 AM
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
	/// Encapsulates the 'User' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("User")]
	public partial class User : esUser
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new User();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 userId)
		{
			var obj = new User();
			obj.UserId = userId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 userId, esSqlAccessType sqlAccessType)
		{
			var obj = new User();
			obj.UserId = userId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("UserCollection")]
	public partial class UserCollection : esUserCollection, IEnumerable<User>
	{
		public User FindByPrimaryKey(System.Int32 userId)
		{
			return this.SingleOrDefault(e => e.UserId == userId);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(User))]
		public class UserCollectionWCFPacket : esCollectionWCFPacket<UserCollection>
		{
			public static implicit operator UserCollection(UserCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator UserCollectionWCFPacket(UserCollection collection)
			{
				return new UserCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class UserQuery : esUserQuery
	{
		public UserQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "UserQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(UserQuery query)
		{
			return UserQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator UserQuery(string query)
		{
			return (UserQuery)UserQuery.SerializeHelper.FromXml(query, typeof(UserQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esUser : esEntity
	{
		public esUser()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 userId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userId);
			else
				return LoadByPrimaryKeyStoredProcedure(userId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 userId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(userId);
			else
				return LoadByPrimaryKeyStoredProcedure(userId);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 userId)
		{
			UserQuery query = new UserQuery();
			query.Where(query.UserId == userId);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 userId)
		{
			esParameters parms = new esParameters();
			parms.Add("UserId", userId);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to User.UserId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? UserId
		{
			get
			{
				return base.GetSystemInt32(UserMetadata.ColumnNames.UserId);
			}
			
			set
			{
				if(base.SetSystemInt32(UserMetadata.ColumnNames.UserId, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.UserId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to User.UserName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String UserName
		{
			get
			{
				return base.GetSystemString(UserMetadata.ColumnNames.UserName);
			}
			
			set
			{
				if(base.SetSystemString(UserMetadata.ColumnNames.UserName, value))
				{
					OnPropertyChanged(UserMetadata.PropertyNames.UserName);
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
						case "UserId": this.str().UserId = (string)value; break;							
						case "UserName": this.str().UserName = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "UserId":
						
							if (value == null || value is System.Int32)
								this.UserId = (System.Int32?)value;
								OnPropertyChanged(UserMetadata.PropertyNames.UserId);
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
			public esStrings(esUser entity)
			{
				this.entity = entity;
			}
			
	
			public System.String UserId
			{
				get
				{
					System.Int32? data = entity.UserId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserId = null;
					else entity.UserId = Convert.ToInt32(value);
				}
			}
				
			public System.String UserName
			{
				get
				{
					System.String data = entity.UserName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserName = null;
					else entity.UserName = Convert.ToString(value);
				}
			}
			

			private esUser entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return UserMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public UserQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new UserQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(UserQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(UserQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private UserQuery query;		
	}



	[Serializable]
	abstract public partial class esUserCollection : esEntityCollection<User>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return UserMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "UserCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public UserQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new UserQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(UserQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new UserQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(UserQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((UserQuery)query);
		}

		#endregion
		
		private UserQuery query;
	}



	[Serializable]
	abstract public partial class esUserQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return UserMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem UserId
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.UserId, esSystemType.Int32); }
		} 
		
		public esQueryItem UserName
		{
			get { return new esQueryItem(this, UserMetadata.ColumnNames.UserName, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class User : esUser
	{

		#region AnnouncementCollectionByUserID - Zero To Many
		
		static public esPrefetchMap Prefetch_AnnouncementCollectionByUserID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.User.AnnouncementCollectionByUserID_Delegate;
				map.PropertyName = "AnnouncementCollectionByUserID";
				map.MyColumnName = "UserID";
				map.ParentColumnName = "UserId";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AnnouncementCollectionByUserID_Delegate(esPrefetchParameters data)
		{
			UserQuery parent = new UserQuery(data.NextAlias());

			AnnouncementQuery me = data.You != null ? data.You as AnnouncementQuery : new AnnouncementQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.UserId == me.UserID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Announcement_User
		/// </summary>

		[XmlIgnore]
		public AnnouncementCollection AnnouncementCollectionByUserID
		{
			get
			{
				if(this._AnnouncementCollectionByUserID == null)
				{
					this._AnnouncementCollectionByUserID = new AnnouncementCollection();
					this._AnnouncementCollectionByUserID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AnnouncementCollectionByUserID", this._AnnouncementCollectionByUserID);
				
					if (this.UserId != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AnnouncementCollectionByUserID.Query.Where(this._AnnouncementCollectionByUserID.Query.UserID == this.UserId);
							this._AnnouncementCollectionByUserID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AnnouncementCollectionByUserID.fks.Add(AnnouncementMetadata.ColumnNames.UserID, this.UserId);
					}
				}

				return this._AnnouncementCollectionByUserID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AnnouncementCollectionByUserID != null) 
				{ 
					this.RemovePostSave("AnnouncementCollectionByUserID"); 
					this._AnnouncementCollectionByUserID = null;
					this.OnPropertyChanged("AnnouncementCollectionByUserID");
				} 
			} 			
		}
			
		
		private AnnouncementCollection _AnnouncementCollectionByUserID;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "AnnouncementCollectionByUserID":
					coll = this.AnnouncementCollectionByUserID;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "AnnouncementCollectionByUserID", typeof(AnnouncementCollection), new Announcement()));
		
			return props;
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetColumn(key, value, false);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._AnnouncementCollectionByUserID != null)
			{
				Apply(this._AnnouncementCollectionByUserID, "UserID", this.UserId);
			}
		}
		
	}
	



	[Serializable]
	public partial class UserMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected UserMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(UserMetadata.ColumnNames.UserId, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = UserMetadata.PropertyNames.UserId;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(UserMetadata.ColumnNames.UserName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = UserMetadata.PropertyNames.UserName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public UserMetadata Meta()
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
			 public const string UserId = "UserId";
			 public const string UserName = "UserName";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string UserId = "UserId";
			 public const string UserName = "UserName";
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
			lock (typeof(UserMetadata))
			{
				if(UserMetadata.mapDelegates == null)
				{
					UserMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (UserMetadata.meta == null)
				{
					UserMetadata.meta = new UserMetadata();
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


				meta.AddTypeMap("UserId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UserName", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "User";
				meta.Destination = "User";
				
				meta.spInsert = "proc_UserInsert";				
				meta.spUpdate = "proc_UserUpdate";		
				meta.spDelete = "proc_UserDelete";
				meta.spLoadAll = "proc_UserLoadAll";
				meta.spLoadByPrimaryKey = "proc_UserLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private UserMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
