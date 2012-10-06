
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:38 AM
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
	/// Encapsulates the 'ReverseCompositeParent' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(ReverseCompositeParent))]	
	[XmlType("ReverseCompositeParent")]
	[Table(Name="ReverseCompositeParent")]
	public partial class ReverseCompositeParent : esReverseCompositeParent
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ReverseCompositeParent();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String keySub, System.Int32 keyId)
		{
			var obj = new ReverseCompositeParent();
			obj.KeySub = keySub;
			obj.KeyId = keyId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String keySub, System.Int32 keyId, esSqlAccessType sqlAccessType)
		{
			var obj = new ReverseCompositeParent();
			obj.KeySub = keySub;
			obj.KeyId = keyId;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ReverseCompositeParentProxyStub(ReverseCompositeParent entity)
		{
			return new ReverseCompositeParentProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String KeySub
		{
			get { return base.KeySub;  }
			set { base.KeySub = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? KeyId
		{
			get { return base.KeyId;  }
			set { base.KeyId = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String Description
		{
			get { return base.Description;  }
			set { base.Description = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ReverseCompositeParentCollection")]
	public partial class ReverseCompositeParentCollection : esReverseCompositeParentCollection, IEnumerable<ReverseCompositeParent>
	{
		public ReverseCompositeParent FindByPrimaryKey(System.String keySub, System.Int32 keyId)
		{
			return this.SingleOrDefault(e => e.KeySub == keySub && e.KeyId == keyId);
		}

		#region Implicit Casts
		
		public static implicit operator ReverseCompositeParentCollectionProxyStub(ReverseCompositeParentCollection coll)
		{
			return new ReverseCompositeParentCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ReverseCompositeParent))]
		public class ReverseCompositeParentCollectionWCFPacket : esCollectionWCFPacket<ReverseCompositeParentCollection>
		{
			public static implicit operator ReverseCompositeParentCollection(ReverseCompositeParentCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ReverseCompositeParentCollectionWCFPacket(ReverseCompositeParentCollection collection)
			{
				return new ReverseCompositeParentCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ReverseCompositeParentQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ReverseCompositeParentQuery : esReverseCompositeParentQuery
	{
		public ReverseCompositeParentQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ReverseCompositeParentQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ReverseCompositeParentQuery query)
		{
			return ReverseCompositeParentQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ReverseCompositeParentQuery(string query)
		{
			return (ReverseCompositeParentQuery)ReverseCompositeParentQuery.SerializeHelper.FromXml(query, typeof(ReverseCompositeParentQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esReverseCompositeParent : esEntity
	{
		public esReverseCompositeParent()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String keySub, System.Int32 keyId)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(keySub, keyId);
			else
				return LoadByPrimaryKeyStoredProcedure(keySub, keyId);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String keySub, System.Int32 keyId)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(keySub, keyId);
			else
				return LoadByPrimaryKeyStoredProcedure(keySub, keyId);
		}

		private bool LoadByPrimaryKeyDynamic(System.String keySub, System.Int32 keyId)
		{
			ReverseCompositeParentQuery query = new ReverseCompositeParentQuery();
			query.Where(query.KeySub == keySub, query.KeyId == keyId);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String keySub, System.Int32 keyId)
		{
			esParameters parms = new esParameters();
			parms.Add("KeySub", keySub);			parms.Add("KeyId", keyId);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ReverseCompositeParent.KeySub
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String KeySub
		{
			get
			{
				return base.GetSystemString(ReverseCompositeParentMetadata.ColumnNames.KeySub);
			}
			
			set
			{
				if(base.SetSystemString(ReverseCompositeParentMetadata.ColumnNames.KeySub, value))
				{
					OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.KeySub);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ReverseCompositeParent.KeyId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? KeyId
		{
			get
			{
				return base.GetSystemInt32(ReverseCompositeParentMetadata.ColumnNames.KeyId);
			}
			
			set
			{
				if(base.SetSystemInt32(ReverseCompositeParentMetadata.ColumnNames.KeyId, value))
				{
					OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.KeyId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ReverseCompositeParent.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(ReverseCompositeParentMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(ReverseCompositeParentMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.Description);
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
						case "KeySub": this.str().KeySub = (string)value; break;							
						case "KeyId": this.str().KeyId = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "KeyId":
						
							if (value == null || value is System.Int32)
								this.KeyId = (System.Int32?)value;
								OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.KeyId);
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
			public esStrings(esReverseCompositeParent entity)
			{
				this.entity = entity;
			}
			
	
			public System.String KeySub
			{
				get
				{
					System.String data = entity.KeySub;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KeySub = null;
					else entity.KeySub = Convert.ToString(value);
				}
			}
				
			public System.String KeyId
			{
				get
				{
					System.Int32? data = entity.KeyId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.KeyId = null;
					else entity.KeyId = Convert.ToInt32(value);
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
			

			private esReverseCompositeParent entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ReverseCompositeParentMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ReverseCompositeParentQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ReverseCompositeParentQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ReverseCompositeParentQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ReverseCompositeParentQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ReverseCompositeParentQuery query;		
	}



	[Serializable]
	abstract public partial class esReverseCompositeParentCollection : esEntityCollection<ReverseCompositeParent>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ReverseCompositeParentMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ReverseCompositeParentCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ReverseCompositeParentQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ReverseCompositeParentQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ReverseCompositeParentQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ReverseCompositeParentQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ReverseCompositeParentQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ReverseCompositeParentQuery)query);
		}

		#endregion
		
		private ReverseCompositeParentQuery query;
	}



	[Serializable]
	abstract public partial class esReverseCompositeParentQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ReverseCompositeParentMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "KeySub": return this.KeySub;
				case "KeyId": return this.KeyId;
				case "Description": return this.Description;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem KeySub
		{
			get { return new esQueryItem(this, ReverseCompositeParentMetadata.ColumnNames.KeySub, esSystemType.String); }
		} 
		
		public esQueryItem KeyId
		{
			get { return new esQueryItem(this, ReverseCompositeParentMetadata.ColumnNames.KeyId, esSystemType.Int32); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, ReverseCompositeParentMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class ReverseCompositeParent : esReverseCompositeParent
	{

		#region ReverseCompositeChildCollectionByParentKeyId - Zero To Many
		
		static public esPrefetchMap Prefetch_ReverseCompositeChildCollectionByParentKeyId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.ReverseCompositeParent.ReverseCompositeChildCollectionByParentKeyId_Delegate;
				map.PropertyName = "ReverseCompositeChildCollectionByParentKeyId";
				map.MyColumnName = "ParentKeyId,ParentKeySub";
				map.ParentColumnName = "KeyId,KeySub";
				map.IsMultiPartKey = true;
				return map;
			}
		}		
		
		static private void ReverseCompositeChildCollectionByParentKeyId_Delegate(esPrefetchParameters data)
		{
			ReverseCompositeParentQuery parent = new ReverseCompositeParentQuery(data.NextAlias());

			ReverseCompositeChildQuery me = data.You != null ? data.You as ReverseCompositeChildQuery : new ReverseCompositeChildQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.KeyId == me.ParentKeyId && parent.KeySub == me.ParentKeySub);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_ReverseCompositeChild_ReverseCompositeParent
		/// </summary>

		[XmlIgnore]
		public ReverseCompositeChildCollection ReverseCompositeChildCollectionByParentKeyId
		{
			get
			{
				if(this._ReverseCompositeChildCollectionByParentKeyId == null)
				{
					this._ReverseCompositeChildCollectionByParentKeyId = new ReverseCompositeChildCollection();
					this._ReverseCompositeChildCollectionByParentKeyId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("ReverseCompositeChildCollectionByParentKeyId", this._ReverseCompositeChildCollectionByParentKeyId);
				
					if (this.KeyId != null && this.KeySub != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._ReverseCompositeChildCollectionByParentKeyId.Query.Where(this._ReverseCompositeChildCollectionByParentKeyId.Query.ParentKeyId == this.KeyId);
							this._ReverseCompositeChildCollectionByParentKeyId.Query.Where(this._ReverseCompositeChildCollectionByParentKeyId.Query.ParentKeySub == this.KeySub);
							this._ReverseCompositeChildCollectionByParentKeyId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._ReverseCompositeChildCollectionByParentKeyId.fks.Add(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, this.KeyId);
						this._ReverseCompositeChildCollectionByParentKeyId.fks.Add(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, this.KeySub);
					}
				}

				return this._ReverseCompositeChildCollectionByParentKeyId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._ReverseCompositeChildCollectionByParentKeyId != null) 
				{ 
					this.RemovePostSave("ReverseCompositeChildCollectionByParentKeyId"); 
					this._ReverseCompositeChildCollectionByParentKeyId = null;
					this.OnPropertyChanged("ReverseCompositeChildCollectionByParentKeyId");
				} 
			} 			
		}
			
		
		private ReverseCompositeChildCollection _ReverseCompositeChildCollectionByParentKeyId;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "ReverseCompositeChildCollectionByParentKeyId":
					coll = this.ReverseCompositeChildCollectionByParentKeyId;
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
			
			props.Add(new esPropertyDescriptor(this, "ReverseCompositeChildCollectionByParentKeyId", typeof(ReverseCompositeChildCollection), new ReverseCompositeChild()));
		
			return props;
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeParent")]
	[XmlType(TypeName="ReverseCompositeParentProxyStub")]	
	[Serializable]
	public partial class ReverseCompositeParentProxyStub
	{
		public ReverseCompositeParentProxyStub() 
		{
			theEntity = this.entity = new ReverseCompositeParent();
		}

		public ReverseCompositeParentProxyStub(ReverseCompositeParent obj)
		{
			theEntity = this.entity = obj;
		}

		public ReverseCompositeParentProxyStub(ReverseCompositeParent obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator ReverseCompositeParent(ReverseCompositeParentProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(ReverseCompositeParent);
		}

		[DataMember(Name="KeySub", Order=1, EmitDefaultValue=false)]
		public System.String KeySub
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(ReverseCompositeParentMetadata.ColumnNames.KeySub);
				else
					return this.Entity.KeySub;
			}
			set { this.Entity.KeySub = value; }
		}

		[DataMember(Name="KeyId", Order=2, EmitDefaultValue=false)]
		public System.Int32? KeyId
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ReverseCompositeParentMetadata.ColumnNames.KeyId);
				else
					return this.Entity.KeyId;
			}
			set { this.Entity.KeyId = value; }
		}

		[DataMember(Name="Description", Order=3, EmitDefaultValue=false)]
		public System.String Description
		{
			get 
			{ 
				
				if (this.IncludeColumn(ReverseCompositeParentMetadata.ColumnNames.Description))
					return this.Entity.Description;
				else
					return null;
			}
			set { this.Entity.Description = value; }
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
		public ReverseCompositeParent Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new ReverseCompositeParent();
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
		public ReverseCompositeParent entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeParentCollection")]
	[XmlType(TypeName="ReverseCompositeParentCollectionProxyStub")]	
	[Serializable]
	public partial class ReverseCompositeParentCollectionProxyStub 
	{
		protected ReverseCompositeParentCollectionProxyStub() {}
		
		public ReverseCompositeParentCollectionProxyStub(esEntityCollection<ReverseCompositeParent> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ReverseCompositeParentCollectionProxyStub(esEntityCollection<ReverseCompositeParent> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ReverseCompositeParentCollection(ReverseCompositeParentCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(ReverseCompositeParent);
		}
		
		public ReverseCompositeParentCollectionProxyStub(esEntityCollection<ReverseCompositeParent> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (ReverseCompositeParent entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ReverseCompositeParentProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ReverseCompositeParentProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (ReverseCompositeParent entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ReverseCompositeParentProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ReverseCompositeParentProxyStub> Collection = new List<ReverseCompositeParentProxyStub>();

		public ReverseCompositeParentCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ReverseCompositeParentCollection();

				foreach (ReverseCompositeParentProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ReverseCompositeParentCollection _coll;
	}



	[Serializable]
	public partial class ReverseCompositeParentMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ReverseCompositeParentMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ReverseCompositeParentMetadata.ColumnNames.KeySub, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = ReverseCompositeParentMetadata.PropertyNames.KeySub;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ReverseCompositeParentMetadata.ColumnNames.KeyId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ReverseCompositeParentMetadata.PropertyNames.KeyId;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ReverseCompositeParentMetadata.ColumnNames.Description, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = ReverseCompositeParentMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ReverseCompositeParentMetadata Meta()
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
			 public const string KeySub = "KeySub";
			 public const string KeyId = "KeyId";
			 public const string Description = "Description";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string KeySub = "KeySub";
			 public const string KeyId = "KeyId";
			 public const string Description = "Description";
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
			lock (typeof(ReverseCompositeParentMetadata))
			{
				if(ReverseCompositeParentMetadata.mapDelegates == null)
				{
					ReverseCompositeParentMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ReverseCompositeParentMetadata.meta == null)
				{
					ReverseCompositeParentMetadata.meta = new ReverseCompositeParentMetadata();
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


				meta.AddTypeMap("KeySub", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("KeyId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "ReverseCompositeParent";
				meta.Destination = "ReverseCompositeParent";
				
				meta.spInsert = "proc_ReverseCompositeParentInsert";				
				meta.spUpdate = "proc_ReverseCompositeParentUpdate";		
				meta.spDelete = "proc_ReverseCompositeParentDelete";
				meta.spLoadAll = "proc_ReverseCompositeParentLoadAll";
				meta.spLoadByPrimaryKey = "proc_ReverseCompositeParentLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ReverseCompositeParentMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
