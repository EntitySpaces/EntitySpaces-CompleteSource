
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
	/// Encapsulates the 'CustomerGroup' table
	/// </summary>

	public partial class CustomerGroup : esCustomerGroup
	{
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new CustomerGroup();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String groupID)
		{
			var obj = new CustomerGroup();
			obj.GroupID = groupID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String groupID, esSqlAccessType sqlAccessType)
		{
			var obj = new CustomerGroup();
			obj.GroupID = groupID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	public partial class CustomerGroupCollection : esCustomerGroupCollection, IEnumerable<CustomerGroup>
	{
		public CustomerGroup FindByPrimaryKey(System.String groupID)
		{
			return this.SingleOrDefault(e => e.GroupID == groupID);
		}

		
		
		
				
	}


	
	public partial class CustomerGroupQuery : esCustomerGroupQuery
	{
		public CustomerGroupQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomerGroupQuery";
		}
		
					
		
	}

	abstract public partial class esCustomerGroup : esEntity
	{
		public esCustomerGroup()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String groupID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(groupID);
			else
				return LoadByPrimaryKeyStoredProcedure(groupID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String groupID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(groupID);
			else
				return LoadByPrimaryKeyStoredProcedure(groupID);
		}

		private bool LoadByPrimaryKeyDynamic(System.String groupID)
		{
			CustomerGroupQuery query = new CustomerGroupQuery();
			query.Where(query.GroupID == groupID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String groupID)
		{
			esParameters parms = new esParameters();
			parms.Add("GroupID", groupID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to CustomerGroup.GroupID
		/// </summary>
		virtual public System.String GroupID
		{
			get
			{
				return base.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupID);
			}
			
			set
			{
				if(base.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupID, value))
				{
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomerGroup.GroupName
		/// </summary>
		virtual public System.String GroupName
		{
			get
			{
				return base.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupName);
			}
			
			set
			{
				if(base.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupName, value))
				{
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupName);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomerGroupMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomerGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerGroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerGroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomerGroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        
		private CustomerGroupQuery query;		
	}



	abstract public partial class esCustomerGroupCollection : esEntityCollection<CustomerGroup>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomerGroupMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomerGroupCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomerGroupQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomerGroupQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomerGroupQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomerGroupQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomerGroupQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomerGroupQuery)query);
		}

		#endregion
		
		private CustomerGroupQuery query;
	}



	abstract public partial class esCustomerGroupQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomerGroupMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "GroupID": return this.GroupID;
				case "GroupName": return this.GroupName;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem GroupID
		{
			get { return new esQueryItem(this, CustomerGroupMetadata.ColumnNames.GroupID, esSystemType.String); }
		} 
		
		public esQueryItem GroupName
		{
			get { return new esQueryItem(this, CustomerGroupMetadata.ColumnNames.GroupName, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class CustomerGroup : esCustomerGroup
	{

		#region CustomerCollectionByCustomerID - Zero To Many
		
		static public esPrefetchMap Prefetch_CustomerCollectionByCustomerID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.CustomerGroup.CustomerCollectionByCustomerID_Delegate;
				map.PropertyName = "CustomerCollectionByCustomerID";
				map.MyColumnName = "CustomerID";
				map.ParentColumnName = "GroupID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void CustomerCollectionByCustomerID_Delegate(esPrefetchParameters data)
		{
			CustomerGroupQuery parent = new CustomerGroupQuery(data.NextAlias());

			CustomerQuery me = data.You != null ? data.You as CustomerQuery : new CustomerQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.GroupID == me.CustomerID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - CustomerGroupCustomer
		/// </summary>

		public CustomerCollection CustomerCollectionByCustomerID
		{
			get
			{
				if(this._CustomerCollectionByCustomerID == null)
				{
					this._CustomerCollectionByCustomerID = new CustomerCollection();
					this._CustomerCollectionByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("CustomerCollectionByCustomerID", this._CustomerCollectionByCustomerID);
				
					if (this.GroupID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._CustomerCollectionByCustomerID.Query.Where(this._CustomerCollectionByCustomerID.Query.CustomerID == this.GroupID);
							this._CustomerCollectionByCustomerID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._CustomerCollectionByCustomerID.fks.Add(CustomerMetadata.ColumnNames.CustomerID, this.GroupID);
					}
				}

				return this._CustomerCollectionByCustomerID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._CustomerCollectionByCustomerID != null) 
				{ 
					this.RemovePostSave("CustomerCollectionByCustomerID"); 
					this._CustomerCollectionByCustomerID = null;
					this.OnPropertyChanged("CustomerCollectionByCustomerID");
				} 
			} 			
		}
			
		
		private CustomerCollection _CustomerCollectionByCustomerID;
		#endregion

				
		#region Group - One To One
		/// <summary>
		/// One to One
		/// Foreign Key Name - CustomerGroupGroup
		/// </summary>

		public Group Group
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._Group == null)
				{
					this._Group = new Group();
					this._Group.es.Connection.Name = this.es.Connection.Name;
					this.SetPostOneSave("Group", this._Group);
				
					if(this.GroupID != null)
					{
						this._Group.Query.Where(this._Group.Query.Id == this.GroupID);
						this._Group.Query.Load();
					}
				}

				return this._Group;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._Group != null) 
				{ 
					this.RemovePostOneSave("Group"); 
					this._Group = null;
					this.OnPropertyChanged("Group");
				} 
			}          			
		}
		
		
		private Group _Group;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "CustomerCollectionByCustomerID":
					coll = this.CustomerCollectionByCustomerID;
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
			
			props.Add(new esPropertyDescriptor(this, "CustomerCollectionByCustomerID", typeof(CustomerCollection), new Customer()));
		
			return props;
		}
		
	}
	



	public partial class CustomerGroupMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomerGroupMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupID, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupID;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupName;
			c.CharacterMaxLength = 25;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CustomerGroupMetadata Meta()
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
			 public const string GroupID = "GroupID";
			 public const string GroupName = "GroupName";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string GroupID = "GroupID";
			 public const string GroupName = "GroupName";
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
			lock (typeof(CustomerGroupMetadata))
			{
				if(CustomerGroupMetadata.mapDelegates == null)
				{
					CustomerGroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerGroupMetadata.meta == null)
				{
					CustomerGroupMetadata.meta = new CustomerGroupMetadata();
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


				meta.AddTypeMap("GroupID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("GroupName", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "CustomerGroup";
				meta.Destination = "CustomerGroup";
				
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomerGroupMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
