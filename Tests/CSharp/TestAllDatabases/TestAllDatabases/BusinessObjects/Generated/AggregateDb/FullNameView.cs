
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
	/// Multi-line View Description
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(FullNameView))]	
	[XmlType("FullNameView")]
	[Table(Name="FullNameView")]
	public partial class FullNameView : esFullNameView
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new FullNameView();
		}
		
		#region Static Quick Access Methods
		
		#endregion

		#region Implicit Casts

		public static implicit operator FullNameViewProxyStub(FullNameView entity)
		{
			return new FullNameViewProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String FullName
		{
			get { return base.FullName;  }
			set { base.FullName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? DepartmentID
		{
			get { return base.DepartmentID;  }
			set { base.DepartmentID = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? HireDate
		{
			get { return base.HireDate;  }
			set { base.HireDate = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Decimal? Salary
		{
			get { return base.Salary;  }
			set { base.Salary = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Boolean? IsActive
		{
			get { return base.IsActive;  }
			set { base.IsActive = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("FullNameViewCollection")]
	public partial class FullNameViewCollection : esFullNameViewCollection, IEnumerable<FullNameView>
	{

		#region Implicit Casts
		
		public static implicit operator FullNameViewCollectionProxyStub(FullNameViewCollection coll)
		{
			return new FullNameViewCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(FullNameView))]
		public class FullNameViewCollectionWCFPacket : esCollectionWCFPacket<FullNameViewCollection>
		{
			public static implicit operator FullNameViewCollection(FullNameViewCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator FullNameViewCollectionWCFPacket(FullNameViewCollection collection)
			{
				return new FullNameViewCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "FullNameViewQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class FullNameViewQuery : esFullNameViewQuery
	{
		public FullNameViewQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "FullNameViewQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(FullNameViewQuery query)
		{
			return FullNameViewQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator FullNameViewQuery(string query)
		{
			return (FullNameViewQuery)FullNameViewQuery.SerializeHelper.FromXml(query, typeof(FullNameViewQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esFullNameView : EntityBase
	{
		public esFullNameView()
		{

		}
		
		#region LoadByPrimaryKey
		
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to FullNameView.FullName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FullName
		{
			get
			{
				return base.GetSystemString(FullNameViewMetadata.ColumnNames.FullName);
			}
			
			set
			{
				if(base.SetSystemString(FullNameViewMetadata.ColumnNames.FullName, value))
				{
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.FullName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to FullNameView.DepartmentID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? DepartmentID
		{
			get
			{
				return base.GetSystemInt32(FullNameViewMetadata.ColumnNames.DepartmentID);
			}
			
			set
			{
				if(base.SetSystemInt32(FullNameViewMetadata.ColumnNames.DepartmentID, value))
				{
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.DepartmentID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to FullNameView.HireDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? HireDate
		{
			get
			{
				return base.GetSystemDateTime(FullNameViewMetadata.ColumnNames.HireDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(FullNameViewMetadata.ColumnNames.HireDate, value))
				{
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.HireDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to FullNameView.Salary
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Salary
		{
			get
			{
				return base.GetSystemDecimal(FullNameViewMetadata.ColumnNames.Salary);
			}
			
			set
			{
				if(base.SetSystemDecimal(FullNameViewMetadata.ColumnNames.Salary, value))
				{
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.Salary);
				}
			}
		}		
		
		/// <summary>
		/// Maps to FullNameView.IsActive
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Boolean? IsActive
		{
			get
			{
				return base.GetSystemBoolean(FullNameViewMetadata.ColumnNames.IsActive);
			}
			
			set
			{
				if(base.SetSystemBoolean(FullNameViewMetadata.ColumnNames.IsActive, value))
				{
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.IsActive);
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
						case "FullName": this.str().FullName = (string)value; break;							
						case "DepartmentID": this.str().DepartmentID = (string)value; break;							
						case "HireDate": this.str().HireDate = (string)value; break;							
						case "Salary": this.str().Salary = (string)value; break;							
						case "IsActive": this.str().IsActive = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "DepartmentID":
						
							if (value == null || value is System.Int32)
								this.DepartmentID = (System.Int32?)value;
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.DepartmentID);
							break;
						
						case "HireDate":
						
							if (value == null || value is System.DateTime)
								this.HireDate = (System.DateTime?)value;
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.HireDate);
							break;
						
						case "Salary":
						
							if (value == null || value is System.Decimal)
								this.Salary = (System.Decimal?)value;
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.Salary);
							break;
						
						case "IsActive":
						
							if (value == null || value is System.Boolean)
								this.IsActive = (System.Boolean?)value;
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.IsActive);
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
			public esStrings(esFullNameView entity)
			{
				this.entity = entity;
			}
			
	
			public System.String FullName
			{
				get
				{
					System.String data = entity.FullName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FullName = null;
					else entity.FullName = Convert.ToString(value);
				}
			}
				
			public System.String DepartmentID
			{
				get
				{
					System.Int32? data = entity.DepartmentID;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DepartmentID = null;
					else entity.DepartmentID = Convert.ToInt32(value);
				}
			}
				
			public System.String HireDate
			{
				get
				{
					System.DateTime? data = entity.HireDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.HireDate = null;
					else entity.HireDate = Convert.ToDateTime(value);
				}
			}
				
			public System.String Salary
			{
				get
				{
					System.Decimal? data = entity.Salary;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Salary = null;
					else entity.Salary = Convert.ToDecimal(value);
				}
			}
				
			public System.String IsActive
			{
				get
				{
					System.Boolean? data = entity.IsActive;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsActive = null;
					else entity.IsActive = Convert.ToBoolean(value);
				}
			}
			

			private esFullNameView entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return FullNameViewMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public FullNameViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new FullNameViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(FullNameViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(FullNameViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private FullNameViewQuery query;		
	}



	[Serializable]
	abstract public partial class esFullNameViewCollection : CollectionBase<FullNameView>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return FullNameViewMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "FullNameViewCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public FullNameViewQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new FullNameViewQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(FullNameViewQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new FullNameViewQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(FullNameViewQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((FullNameViewQuery)query);
		}

		#endregion
		
		private FullNameViewQuery query;
	}



	[Serializable]
	abstract public partial class esFullNameViewQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return FullNameViewMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "FullName": return this.FullName;
				case "DepartmentID": return this.DepartmentID;
				case "HireDate": return this.HireDate;
				case "Salary": return this.Salary;
				case "IsActive": return this.IsActive;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem FullName
		{
			get { return new esQueryItem(this, FullNameViewMetadata.ColumnNames.FullName, esSystemType.String); }
		} 
		
		public esQueryItem DepartmentID
		{
			get { return new esQueryItem(this, FullNameViewMetadata.ColumnNames.DepartmentID, esSystemType.Int32); }
		} 
		
		public esQueryItem HireDate
		{
			get { return new esQueryItem(this, FullNameViewMetadata.ColumnNames.HireDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem Salary
		{
			get { return new esQueryItem(this, FullNameViewMetadata.ColumnNames.Salary, esSystemType.Decimal); }
		} 
		
		public esQueryItem IsActive
		{
			get { return new esQueryItem(this, FullNameViewMetadata.ColumnNames.IsActive, esSystemType.Boolean); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "FullNameView")]
	[XmlType(TypeName="FullNameViewProxyStub")]	
	[Serializable]
	public partial class FullNameViewProxyStub
	{
		public FullNameViewProxyStub() 
		{
			theEntity = this.entity = new FullNameView();
		}

		public FullNameViewProxyStub(FullNameView obj)
		{
			theEntity = this.entity = obj;
		}

		public FullNameViewProxyStub(FullNameView obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator FullNameView(FullNameViewProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(FullNameView);
		}

		[DataMember(Name="FullName", Order=1, EmitDefaultValue=false)]
		public System.String FullName
		{
			get 
			{ 
				
				if (this.IncludeColumn(FullNameViewMetadata.ColumnNames.FullName))
					return this.Entity.FullName;
				else
					return null;
			}
			set { this.Entity.FullName = value; }
		}

		[DataMember(Name="DepartmentID", Order=2, EmitDefaultValue=false)]
		public System.Int32? DepartmentID
		{
			get 
			{ 
				
				if (this.IncludeColumn(FullNameViewMetadata.ColumnNames.DepartmentID))
					return this.Entity.DepartmentID;
				else
					return null;
			}
			set { this.Entity.DepartmentID = value; }
		}

		[DataMember(Name="HireDate", Order=3, EmitDefaultValue=false)]
		public System.DateTime? HireDate
		{
			get 
			{ 
				
				if (this.IncludeColumn(FullNameViewMetadata.ColumnNames.HireDate))
					return this.Entity.HireDate;
				else
					return null;
			}
			set { this.Entity.HireDate = value; }
		}

		[DataMember(Name="Salary", Order=4, EmitDefaultValue=false)]
		public System.Decimal? Salary
		{
			get 
			{ 
				
				if (this.IncludeColumn(FullNameViewMetadata.ColumnNames.Salary))
					return this.Entity.Salary;
				else
					return null;
			}
			set { this.Entity.Salary = value; }
		}

		[DataMember(Name="IsActive", Order=5, EmitDefaultValue=false)]
		public System.Boolean? IsActive
		{
			get 
			{ 
				
				if (this.IncludeColumn(FullNameViewMetadata.ColumnNames.IsActive))
					return this.Entity.IsActive;
				else
					return null;
			}
			set { this.Entity.IsActive = value; }
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
		public FullNameView Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new FullNameView();
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
		public FullNameView entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "FullNameViewCollection")]
	[XmlType(TypeName="FullNameViewCollectionProxyStub")]	
	[Serializable]
	public partial class FullNameViewCollectionProxyStub 
	{
		protected FullNameViewCollectionProxyStub() {}
		
		public FullNameViewCollectionProxyStub(esEntityCollection<FullNameView> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public FullNameViewCollectionProxyStub(esEntityCollection<FullNameView> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator FullNameViewCollection(FullNameViewCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(FullNameView);
		}
		
		public FullNameViewCollectionProxyStub(esEntityCollection<FullNameView> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (FullNameView entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new FullNameViewProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new FullNameViewProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (FullNameView entity in coll.es.DeletedEntities)
				{
					Collection.Add(new FullNameViewProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<FullNameViewProxyStub> Collection = new List<FullNameViewProxyStub>();

		public FullNameViewCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new FullNameViewCollection();

				foreach (FullNameViewProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private FullNameViewCollection _coll;
	}



	[Serializable]
	public partial class FullNameViewMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected FullNameViewMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(FullNameViewMetadata.ColumnNames.FullName, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = FullNameViewMetadata.PropertyNames.FullName;
			c.CharacterMaxLength = 42;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(FullNameViewMetadata.ColumnNames.DepartmentID, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = FullNameViewMetadata.PropertyNames.DepartmentID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(FullNameViewMetadata.ColumnNames.HireDate, 2, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = FullNameViewMetadata.PropertyNames.HireDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(FullNameViewMetadata.ColumnNames.Salary, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = FullNameViewMetadata.PropertyNames.Salary;
			c.NumericPrecision = 8;
			c.NumericScale = 4;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(FullNameViewMetadata.ColumnNames.IsActive, 4, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = FullNameViewMetadata.PropertyNames.IsActive;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public FullNameViewMetadata Meta()
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
			 public const string FullName = "FullName";
			 public const string DepartmentID = "DepartmentID";
			 public const string HireDate = "HireDate";
			 public const string Salary = "Salary";
			 public const string IsActive = "IsActive";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string FullName = "FullName";
			 public const string DepartmentID = "DepartmentID";
			 public const string HireDate = "HireDate";
			 public const string Salary = "Salary";
			 public const string IsActive = "IsActive";
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
			lock (typeof(FullNameViewMetadata))
			{
				if(FullNameViewMetadata.mapDelegates == null)
				{
					FullNameViewMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (FullNameViewMetadata.meta == null)
				{
					FullNameViewMetadata.meta = new FullNameViewMetadata();
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


				meta.AddTypeMap("FullName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("HireDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("bit", "System.Boolean"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "FullNameView";
				meta.Destination = "FullNameView";
				
				meta.spInsert = "proc_FullNameViewInsert";				
				meta.spUpdate = "proc_FullNameViewUpdate";		
				meta.spDelete = "proc_FullNameViewDelete";
				meta.spLoadAll = "proc_FullNameViewLoadAll";
				meta.spLoadByPrimaryKey = "proc_FullNameViewLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private FullNameViewMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
