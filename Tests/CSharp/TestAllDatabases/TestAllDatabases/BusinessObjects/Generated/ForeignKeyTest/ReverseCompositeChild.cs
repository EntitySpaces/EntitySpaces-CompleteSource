
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:43:28 AM
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
	/// Encapsulates the 'ReverseCompositeChild' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(ReverseCompositeChild))]	
	[XmlType("ReverseCompositeChild")]
	[Table(Name="ReverseCompositeChild")]
	public partial class ReverseCompositeChild : esReverseCompositeChild
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ReverseCompositeChild();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 childId, System.Int32 parentKeyId, System.String parentKeySub)
		{
			var obj = new ReverseCompositeChild();
			obj.ChildId = childId;
			obj.ParentKeyId = parentKeyId;
			obj.ParentKeySub = parentKeySub;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 childId, System.Int32 parentKeyId, System.String parentKeySub, esSqlAccessType sqlAccessType)
		{
			var obj = new ReverseCompositeChild();
			obj.ChildId = childId;
			obj.ParentKeyId = parentKeyId;
			obj.ParentKeySub = parentKeySub;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ReverseCompositeChildProxyStub(ReverseCompositeChild entity)
		{
			return new ReverseCompositeChildProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? ChildId
		{
			get { return base.ChildId;  }
			set { base.ChildId = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? ParentKeyId
		{
			get { return base.ParentKeyId;  }
			set { base.ParentKeyId = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String ParentKeySub
		{
			get { return base.ParentKeySub;  }
			set { base.ParentKeySub = value; }
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
	[XmlType("ReverseCompositeChildCollection")]
	public partial class ReverseCompositeChildCollection : esReverseCompositeChildCollection, IEnumerable<ReverseCompositeChild>
	{
		public ReverseCompositeChild FindByPrimaryKey(System.Int32 childId, System.Int32 parentKeyId, System.String parentKeySub)
		{
			return this.SingleOrDefault(e => e.ChildId == childId && e.ParentKeyId == parentKeyId && e.ParentKeySub == parentKeySub);
		}

		#region Implicit Casts
		
		public static implicit operator ReverseCompositeChildCollectionProxyStub(ReverseCompositeChildCollection coll)
		{
			return new ReverseCompositeChildCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ReverseCompositeChild))]
		public class ReverseCompositeChildCollectionWCFPacket : esCollectionWCFPacket<ReverseCompositeChildCollection>
		{
			public static implicit operator ReverseCompositeChildCollection(ReverseCompositeChildCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ReverseCompositeChildCollectionWCFPacket(ReverseCompositeChildCollection collection)
			{
				return new ReverseCompositeChildCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ReverseCompositeChildQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ReverseCompositeChildQuery : esReverseCompositeChildQuery
	{
		public ReverseCompositeChildQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ReverseCompositeChildQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ReverseCompositeChildQuery query)
		{
			return ReverseCompositeChildQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ReverseCompositeChildQuery(string query)
		{
			return (ReverseCompositeChildQuery)ReverseCompositeChildQuery.SerializeHelper.FromXml(query, typeof(ReverseCompositeChildQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esReverseCompositeChild : esEntity
	{
		public esReverseCompositeChild()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 childId, System.Int32 parentKeyId, System.String parentKeySub)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(childId, parentKeyId, parentKeySub);
			else
				return LoadByPrimaryKeyStoredProcedure(childId, parentKeyId, parentKeySub);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 childId, System.Int32 parentKeyId, System.String parentKeySub)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(childId, parentKeyId, parentKeySub);
			else
				return LoadByPrimaryKeyStoredProcedure(childId, parentKeyId, parentKeySub);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 childId, System.Int32 parentKeyId, System.String parentKeySub)
		{
			ReverseCompositeChildQuery query = new ReverseCompositeChildQuery();
			query.Where(query.ChildId == childId, query.ParentKeyId == parentKeyId, query.ParentKeySub == parentKeySub);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 childId, System.Int32 parentKeyId, System.String parentKeySub)
		{
			esParameters parms = new esParameters();
			parms.Add("ChildId", childId);			parms.Add("ParentKeyId", parentKeyId);			parms.Add("ParentKeySub", parentKeySub);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ReverseCompositeChild.ChildId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ChildId
		{
			get
			{
				return base.GetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ChildId);
			}
			
			set
			{
				if(base.SetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ChildId, value))
				{
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ChildId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ReverseCompositeChild.ParentKeyId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ParentKeyId
		{
			get
			{
				return base.GetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId);
			}
			
			set
			{
				if(base.SetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, value))
				{
					this._UpToReverseCompositeParentByParentKeyId = null;
					this.OnPropertyChanged("UpToReverseCompositeParentByParentKeyId");
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ParentKeyId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ReverseCompositeChild.ParentKeySub
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ParentKeySub
		{
			get
			{
				return base.GetSystemString(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub);
			}
			
			set
			{
				if(base.SetSystemString(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, value))
				{
					this._UpToReverseCompositeParentByParentKeyId = null;
					this.OnPropertyChanged("UpToReverseCompositeParentByParentKeyId");
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ParentKeySub);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ReverseCompositeChild.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(ReverseCompositeChildMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(ReverseCompositeChildMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.Description);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected ReverseCompositeParent _UpToReverseCompositeParentByParentKeyId;
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
						case "ChildId": this.str().ChildId = (string)value; break;							
						case "ParentKeyId": this.str().ParentKeyId = (string)value; break;							
						case "ParentKeySub": this.str().ParentKeySub = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "ChildId":
						
							if (value == null || value is System.Int32)
								this.ChildId = (System.Int32?)value;
								OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ChildId);
							break;
						
						case "ParentKeyId":
						
							if (value == null || value is System.Int32)
								this.ParentKeyId = (System.Int32?)value;
								OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ParentKeyId);
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
			public esStrings(esReverseCompositeChild entity)
			{
				this.entity = entity;
			}
			
	
			public System.String ChildId
			{
				get
				{
					System.Int32? data = entity.ChildId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ChildId = null;
					else entity.ChildId = Convert.ToInt32(value);
				}
			}
				
			public System.String ParentKeyId
			{
				get
				{
					System.Int32? data = entity.ParentKeyId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ParentKeyId = null;
					else entity.ParentKeyId = Convert.ToInt32(value);
				}
			}
				
			public System.String ParentKeySub
			{
				get
				{
					System.String data = entity.ParentKeySub;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ParentKeySub = null;
					else entity.ParentKeySub = Convert.ToString(value);
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
			

			private esReverseCompositeChild entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ReverseCompositeChildMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ReverseCompositeChildQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ReverseCompositeChildQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ReverseCompositeChildQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ReverseCompositeChildQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ReverseCompositeChildQuery query;		
	}



	[Serializable]
	abstract public partial class esReverseCompositeChildCollection : esEntityCollection<ReverseCompositeChild>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ReverseCompositeChildMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ReverseCompositeChildCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ReverseCompositeChildQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ReverseCompositeChildQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ReverseCompositeChildQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ReverseCompositeChildQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ReverseCompositeChildQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ReverseCompositeChildQuery)query);
		}

		#endregion
		
		private ReverseCompositeChildQuery query;
	}



	[Serializable]
	abstract public partial class esReverseCompositeChildQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ReverseCompositeChildMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "ChildId": return this.ChildId;
				case "ParentKeyId": return this.ParentKeyId;
				case "ParentKeySub": return this.ParentKeySub;
				case "Description": return this.Description;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem ChildId
		{
			get { return new esQueryItem(this, ReverseCompositeChildMetadata.ColumnNames.ChildId, esSystemType.Int32); }
		} 
		
		public esQueryItem ParentKeyId
		{
			get { return new esQueryItem(this, ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, esSystemType.Int32); }
		} 
		
		public esQueryItem ParentKeySub
		{
			get { return new esQueryItem(this, ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, ReverseCompositeChildMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class ReverseCompositeChild : esReverseCompositeChild
	{

				
		#region UpToReverseCompositeParentByParentKeyId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_ReverseCompositeChild_ReverseCompositeParent
		/// </summary>

		[XmlIgnore]
					
		public ReverseCompositeParent UpToReverseCompositeParentByParentKeyId
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToReverseCompositeParentByParentKeyId == null && ParentKeyId != null && ParentKeySub != null)
				{
					this._UpToReverseCompositeParentByParentKeyId = new ReverseCompositeParent();
					this._UpToReverseCompositeParentByParentKeyId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToReverseCompositeParentByParentKeyId", this._UpToReverseCompositeParentByParentKeyId);
					this._UpToReverseCompositeParentByParentKeyId.Query.Where(this._UpToReverseCompositeParentByParentKeyId.Query.KeyId == this.ParentKeyId);
					this._UpToReverseCompositeParentByParentKeyId.Query.Where(this._UpToReverseCompositeParentByParentKeyId.Query.KeySub == this.ParentKeySub);
					this._UpToReverseCompositeParentByParentKeyId.Query.Load();
				}	
				return this._UpToReverseCompositeParentByParentKeyId;
			}
			
			set
			{
				this.RemovePreSave("UpToReverseCompositeParentByParentKeyId");
				
				bool changed = this._UpToReverseCompositeParentByParentKeyId != value;

				if(value == null)
				{
					this.ParentKeyId = null;
					this.ParentKeySub = null;
					this._UpToReverseCompositeParentByParentKeyId = null;
				}
				else
				{
					this.ParentKeyId = value.KeyId;
					this.ParentKeySub = value.KeySub;
					this._UpToReverseCompositeParentByParentKeyId = value;
					this.SetPreSave("UpToReverseCompositeParentByParentKeyId", this._UpToReverseCompositeParentByParentKeyId);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToReverseCompositeParentByParentKeyId");
				}
			}
		}
		#endregion
		

		
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeChild")]
	[XmlType(TypeName="ReverseCompositeChildProxyStub")]	
	[Serializable]
	public partial class ReverseCompositeChildProxyStub
	{
		public ReverseCompositeChildProxyStub() 
		{
			theEntity = this.entity = new ReverseCompositeChild();
		}

		public ReverseCompositeChildProxyStub(ReverseCompositeChild obj)
		{
			theEntity = this.entity = obj;
		}

		public ReverseCompositeChildProxyStub(ReverseCompositeChild obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator ReverseCompositeChild(ReverseCompositeChildProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(ReverseCompositeChild);
		}

		[DataMember(Name="ChildId", Order=1, EmitDefaultValue=false)]
		public System.Int32? ChildId
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ReverseCompositeChildMetadata.ColumnNames.ChildId);
				else
					return this.Entity.ChildId;
			}
			set { this.Entity.ChildId = value; }
		}

		[DataMember(Name="ParentKeyId", Order=2, EmitDefaultValue=false)]
		public System.Int32? ParentKeyId
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId);
				else
					return this.Entity.ParentKeyId;
			}
			set { this.Entity.ParentKeyId = value; }
		}

		[DataMember(Name="ParentKeySub", Order=3, EmitDefaultValue=false)]
		public System.String ParentKeySub
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub);
				else
					return this.Entity.ParentKeySub;
			}
			set { this.Entity.ParentKeySub = value; }
		}

		[DataMember(Name="Description", Order=4, EmitDefaultValue=false)]
		public System.String Description
		{
			get 
			{ 
				
				if (this.IncludeColumn(ReverseCompositeChildMetadata.ColumnNames.Description))
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
		public ReverseCompositeChild Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new ReverseCompositeChild();
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
		public ReverseCompositeChild entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ReverseCompositeChildCollection")]
	[XmlType(TypeName="ReverseCompositeChildCollectionProxyStub")]	
	[Serializable]
	public partial class ReverseCompositeChildCollectionProxyStub 
	{
		protected ReverseCompositeChildCollectionProxyStub() {}
		
		public ReverseCompositeChildCollectionProxyStub(esEntityCollection<ReverseCompositeChild> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ReverseCompositeChildCollectionProxyStub(esEntityCollection<ReverseCompositeChild> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ReverseCompositeChildCollection(ReverseCompositeChildCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(ReverseCompositeChild);
		}
		
		public ReverseCompositeChildCollectionProxyStub(esEntityCollection<ReverseCompositeChild> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (ReverseCompositeChild entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ReverseCompositeChildProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ReverseCompositeChildProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (ReverseCompositeChild entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ReverseCompositeChildProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ReverseCompositeChildProxyStub> Collection = new List<ReverseCompositeChildProxyStub>();

		public ReverseCompositeChildCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ReverseCompositeChildCollection();

				foreach (ReverseCompositeChildProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ReverseCompositeChildCollection _coll;
	}



	[Serializable]
	public partial class ReverseCompositeChildMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ReverseCompositeChildMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.ChildId, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.ChildId;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.ParentKeyId;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.ParentKeySub;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ReverseCompositeChildMetadata Meta()
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
			 public const string ChildId = "ChildId";
			 public const string ParentKeyId = "ParentKeyId";
			 public const string ParentKeySub = "ParentKeySub";
			 public const string Description = "Description";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string ChildId = "ChildId";
			 public const string ParentKeyId = "ParentKeyId";
			 public const string ParentKeySub = "ParentKeySub";
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
			lock (typeof(ReverseCompositeChildMetadata))
			{
				if(ReverseCompositeChildMetadata.mapDelegates == null)
				{
					ReverseCompositeChildMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ReverseCompositeChildMetadata.meta == null)
				{
					ReverseCompositeChildMetadata.meta = new ReverseCompositeChildMetadata();
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


				meta.AddTypeMap("ChildId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ParentKeyId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ParentKeySub", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "ReverseCompositeChild";
				meta.Destination = "ReverseCompositeChild";
				
				meta.spInsert = "proc_ReverseCompositeChildInsert";				
				meta.spUpdate = "proc_ReverseCompositeChildUpdate";		
				meta.spDelete = "proc_ReverseCompositeChildDelete";
				meta.spLoadAll = "proc_ReverseCompositeChildLoadAll";
				meta.spLoadByPrimaryKey = "proc_ReverseCompositeChildLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ReverseCompositeChildMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
