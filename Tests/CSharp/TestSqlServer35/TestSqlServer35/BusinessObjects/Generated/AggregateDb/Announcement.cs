
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0627.0
EntitySpaces Driver  : SQL
Date Generated       : 7/19/2011 8:20:06 AM
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
	/// Encapsulates the 'Announcement' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("Announcement")]
	public partial class Announcement : esAnnouncement
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Announcement();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 announcementID)
		{
			var obj = new Announcement();
			obj.AnnouncementID = announcementID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 announcementID, esSqlAccessType sqlAccessType)
		{
			var obj = new Announcement();
			obj.AnnouncementID = announcementID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("AnnouncementCollection")]
	public partial class AnnouncementCollection : esAnnouncementCollection, IEnumerable<Announcement>
	{
		public Announcement FindByPrimaryKey(System.Int32 announcementID)
		{
			return this.SingleOrDefault(e => e.AnnouncementID == announcementID);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Announcement))]
		public class AnnouncementCollectionWCFPacket : esCollectionWCFPacket<AnnouncementCollection>
		{
			public static implicit operator AnnouncementCollection(AnnouncementCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AnnouncementCollectionWCFPacket(AnnouncementCollection collection)
			{
				return new AnnouncementCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AnnouncementQuery : esAnnouncementQuery
	{
		public AnnouncementQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AnnouncementQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AnnouncementQuery query)
		{
			return AnnouncementQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AnnouncementQuery(string query)
		{
			return (AnnouncementQuery)AnnouncementQuery.SerializeHelper.FromXml(query, typeof(AnnouncementQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAnnouncement : esEntity
	{
		public esAnnouncement()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 announcementID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(announcementID);
			else
				return LoadByPrimaryKeyStoredProcedure(announcementID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 announcementID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(announcementID);
			else
				return LoadByPrimaryKeyStoredProcedure(announcementID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 announcementID)
		{
			AnnouncementQuery query = new AnnouncementQuery();
			query.Where(query.AnnouncementID == announcementID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 announcementID)
		{
			esParameters parms = new esParameters();
			parms.Add("AnnouncementID", announcementID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Announcement.AnnouncementID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? AnnouncementID
		{
			get
			{
				return base.GetSystemInt32(AnnouncementMetadata.ColumnNames.AnnouncementID);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnouncementMetadata.ColumnNames.AnnouncementID, value))
				{
					OnPropertyChanged(AnnouncementMetadata.PropertyNames.AnnouncementID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Announcement.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(AnnouncementMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(AnnouncementMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(AnnouncementMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Announcement.UserID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? UserID
		{
			get
			{
				return base.GetSystemInt32(AnnouncementMetadata.ColumnNames.UserID);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnouncementMetadata.ColumnNames.UserID, value))
				{
					this._UpToUserByUserID = null;
					this.OnPropertyChanged("UpToUserByUserID");
					OnPropertyChanged(AnnouncementMetadata.PropertyNames.UserID);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected User _UpToUserByUserID;
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
						case "AnnouncementID": this.str().AnnouncementID = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "UserID": this.str().UserID = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "AnnouncementID":
						
							if (value == null || value is System.Int32)
								this.AnnouncementID = (System.Int32?)value;
								OnPropertyChanged(AnnouncementMetadata.PropertyNames.AnnouncementID);
							break;
						
						case "UserID":
						
							if (value == null || value is System.Int32)
								this.UserID = (System.Int32?)value;
								OnPropertyChanged(AnnouncementMetadata.PropertyNames.UserID);
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
			public esStrings(esAnnouncement entity)
			{
				this.entity = entity;
			}
			
	
			public System.String AnnouncementID
			{
				get
				{
					System.Int32? data = entity.AnnouncementID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AnnouncementID = null;
					else entity.AnnouncementID = Convert.ToInt32(value);
				}
			}
				
			public System.String Description
			{
				get
				{
					System.String data = entity.Description;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Description = null;
					else entity.Description = Convert.ToString(value);
				}
			}
				
			public System.String UserID
			{
				get
				{
					System.Int32? data = entity.UserID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.UserID = null;
					else entity.UserID = Convert.ToInt32(value);
				}
			}
			

			private esAnnouncement entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AnnouncementMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AnnouncementQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnouncementQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnouncementQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AnnouncementQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AnnouncementQuery query;		
	}



	[Serializable]
	abstract public partial class esAnnouncementCollection : esEntityCollection<Announcement>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AnnouncementMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AnnouncementCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AnnouncementQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnouncementQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnouncementQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AnnouncementQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AnnouncementQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AnnouncementQuery)query);
		}

		#endregion
		
		private AnnouncementQuery query;
	}



	[Serializable]
	abstract public partial class esAnnouncementQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AnnouncementMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem AnnouncementID
		{
			get { return new esQueryItem(this, AnnouncementMetadata.ColumnNames.AnnouncementID, esSystemType.Int32); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, AnnouncementMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem UserID
		{
			get { return new esQueryItem(this, AnnouncementMetadata.ColumnNames.UserID, esSystemType.Int32); }
		} 
		
		#endregion
		
	}


	
	public partial class Announcement : esAnnouncement
	{

				
		#region UpToUserByUserID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Announcement_User
		/// </summary>

		[XmlIgnore]
					
		public User UpToUserByUserID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToUserByUserID == null && UserID != null)
				{
					this._UpToUserByUserID = new User();
					this._UpToUserByUserID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToUserByUserID", this._UpToUserByUserID);
					this._UpToUserByUserID.Query.Where(this._UpToUserByUserID.Query.UserId == this.UserID);
					this._UpToUserByUserID.Query.Load();
				}	
				return this._UpToUserByUserID;
			}
			
			set
			{
				this.RemovePreSave("UpToUserByUserID");
				
				bool changed = this._UpToUserByUserID != value;

				if(value == null)
				{
					this.UserID = null;
					this._UpToUserByUserID = null;
				}
				else
				{
					this.UserID = value.UserId;
					this._UpToUserByUserID = value;
					this.SetPreSave("UpToUserByUserID", this._UpToUserByUserID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToUserByUserID");
				}
			}
		}
		#endregion
		

		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToUserByUserID != null)
			{
				this.UserID = this._UpToUserByUserID.UserId;
			}
		}
		
	}
	



	[Serializable]
	public partial class AnnouncementMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AnnouncementMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AnnouncementMetadata.ColumnNames.AnnouncementID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnouncementMetadata.PropertyNames.AnnouncementID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnouncementMetadata.ColumnNames.Description, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = AnnouncementMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnouncementMetadata.ColumnNames.UserID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnouncementMetadata.PropertyNames.UserID;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AnnouncementMetadata Meta()
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
			 public const string AnnouncementID = "AnnouncementID";
			 public const string Description = "Description";
			 public const string UserID = "UserID";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string AnnouncementID = "AnnouncementID";
			 public const string Description = "Description";
			 public const string UserID = "UserID";
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
			lock (typeof(AnnouncementMetadata))
			{
				if(AnnouncementMetadata.mapDelegates == null)
				{
					AnnouncementMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AnnouncementMetadata.meta == null)
				{
					AnnouncementMetadata.meta = new AnnouncementMetadata();
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


				meta.AddTypeMap("AnnouncementID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("UserID", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "Announcement";
				meta.Destination = "Announcement";
				
				meta.spInsert = "proc_AnnouncementInsert";				
				meta.spUpdate = "proc_AnnouncementUpdate";		
				meta.spDelete = "proc_AnnouncementDelete";
				meta.spLoadAll = "proc_AnnouncementLoadAll";
				meta.spLoadByPrimaryKey = "proc_AnnouncementLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AnnouncementMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
