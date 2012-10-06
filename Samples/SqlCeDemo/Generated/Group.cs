
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQLCE
Date Generated       : 9/23/2012 6:16:19 PM
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


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Group' table
	/// </summary>

	public partial class Group : esGroup
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Group();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String id)
		{
			var obj = new Group();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String id, esSqlAccessType sqlAccessType)
		{
			var obj = new Group();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class GroupCollection : esGroupCollection, IEnumerable<Group>
	{
		public Group FindByPrimaryKey(System.String id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		
				
	}


	
	public partial class GroupQuery : esGroupQuery
	{
		public GroupQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "GroupQuery";
		}
		
					
		
	}

	abstract public partial class esGroup : esEntity
	{
		public esGroup()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.String id)
		{
			GroupQuery query = new GroupQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Group.ID
		/// </summary>
		virtual public System.String Id
		{
			get
			{
				return base.GetSystemString(GroupMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemString(GroupMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(GroupMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Group.Notes
		/// </summary>
		virtual public System.String Notes
		{
			get
			{
				return base.GetSystemString(GroupMetadata.ColumnNames.Notes);
			}
			
			set
			{
				if(base.SetSystemString(GroupMetadata.ColumnNames.Notes, value))
				{
					OnPropertyChanged(GroupMetadata.PropertyNames.Notes);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return GroupMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public GroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(GroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private GroupQuery query;		
	}



	abstract public partial class esGroupCollection : esEntityCollection<Group>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return GroupMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "GroupCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public GroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new GroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(GroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new GroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(GroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((GroupQuery)query);
		}

		#endregion
		
		private GroupQuery query;
	}



	abstract public partial class esGroupQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return GroupMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "Notes": return this.Notes;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, GroupMetadata.ColumnNames.Id, esSystemType.String); }
		} 
		
		public esQueryItem Notes
		{
			get { return new esQueryItem(this, GroupMetadata.ColumnNames.Notes, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Group : esGroup
	{

		#region UpToCustomerGroup - One To One
		/// <summary>
		/// One to One
		/// Foreign Key Name - CustomerGroupGroup
		/// </summary>

		public CustomerGroup UpToCustomerGroup
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
			
				if(this._UpToCustomerGroup == null && Id != null)
				{
					this._UpToCustomerGroup = new CustomerGroup();
					this._UpToCustomerGroup.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomerGroup", this._UpToCustomerGroup);
					this._UpToCustomerGroup.Query.Where(this._UpToCustomerGroup.Query.GroupID == this.Id);
					this._UpToCustomerGroup.Query.Load();
				}

				return this._UpToCustomerGroup;
			}
			
			set 
			{ 
				this.RemovePreSave("UpToCustomerGroup");

				if(value == null)
				{
					this._UpToCustomerGroup = null;
				}
				else
				{
					this._UpToCustomerGroup = value;
					this.SetPreSave("UpToCustomerGroup", this._UpToCustomerGroup);
				}
				
				this.OnPropertyChanged("UpToCustomerGroup");
			} 
		}
				
		
		private CustomerGroup _UpToCustomerGroup;
		#endregion

		
		
	}
	



	public partial class GroupMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected GroupMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(GroupMetadata.ColumnNames.Id, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(GroupMetadata.ColumnNames.Notes, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = GroupMetadata.PropertyNames.Notes;
			c.CharacterMaxLength = 536870911;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public GroupMetadata Meta()
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
			 public const string Id = "ID";
			 public const string Notes = "Notes";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Notes = "Notes";
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
			lock (typeof(GroupMetadata))
			{
				if(GroupMetadata.mapDelegates == null)
				{
					GroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GroupMetadata.meta == null)
				{
					GroupMetadata.meta = new GroupMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("ntext", "System.String"));			
				
				
				
				meta.Source = "Group";
				meta.Destination = "Group";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private GroupMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
