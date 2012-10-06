
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
	/// Encapsulates the 'Class' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Course))]	
	[XmlType("Course")]
	[Table(Name="Course")]
	public partial class Course : esCourse
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Course();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 c1, System.String c2)
		{
			var obj = new Course();
			obj.C1 = c1;
			obj.C2 = c2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 c1, System.String c2, esSqlAccessType sqlAccessType)
		{
			var obj = new Course();
			obj.C1 = c1;
			obj.C2 = c2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator CourseProxyStub(Course entity)
		{
			return new CourseProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? C1
		{
			get { return base.C1;  }
			set { base.C1 = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String C2
		{
			get { return base.C2;  }
			set { base.C2 = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String ClassName
		{
			get { return base.ClassName;  }
			set { base.ClassName = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CourseCollection")]
	public partial class CourseCollection : esCourseCollection, IEnumerable<Course>
	{
		public Course FindByPrimaryKey(System.Int32 c1, System.String c2)
		{
			return this.SingleOrDefault(e => e.C1 == c1 && e.C2 == c2);
		}

		#region Implicit Casts
		
		public static implicit operator CourseCollectionProxyStub(CourseCollection coll)
		{
			return new CourseCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Course))]
		public class CourseCollectionWCFPacket : esCollectionWCFPacket<CourseCollection>
		{
			public static implicit operator CourseCollection(CourseCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CourseCollectionWCFPacket(CourseCollection collection)
			{
				return new CourseCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "CourseQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CourseQuery : esCourseQuery
	{
		public CourseQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CourseQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CourseQuery query)
		{
			return CourseQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CourseQuery(string query)
		{
			return (CourseQuery)CourseQuery.SerializeHelper.FromXml(query, typeof(CourseQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCourse : esEntity
	{
		public esCourse()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 c1, System.String c2)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(c1, c2);
			else
				return LoadByPrimaryKeyStoredProcedure(c1, c2);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 c1, System.String c2)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(c1, c2);
			else
				return LoadByPrimaryKeyStoredProcedure(c1, c2);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 c1, System.String c2)
		{
			CourseQuery query = new CourseQuery();
			query.Where(query.C1 == c1, query.C2 == c2);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 c1, System.String c2)
		{
			esParameters parms = new esParameters();
			parms.Add("C1", c1);			parms.Add("C2", c2);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Class.C1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? C1
		{
			get
			{
				return base.GetSystemInt32(CourseMetadata.ColumnNames.C1);
			}
			
			set
			{
				if(base.SetSystemInt32(CourseMetadata.ColumnNames.C1, value))
				{
					OnPropertyChanged(CourseMetadata.PropertyNames.C1);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Class.C2
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String C2
		{
			get
			{
				return base.GetSystemString(CourseMetadata.ColumnNames.C2);
			}
			
			set
			{
				if(base.SetSystemString(CourseMetadata.ColumnNames.C2, value))
				{
					OnPropertyChanged(CourseMetadata.PropertyNames.C2);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Class.ClassName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ClassName
		{
			get
			{
				return base.GetSystemString(CourseMetadata.ColumnNames.ClassName);
			}
			
			set
			{
				if(base.SetSystemString(CourseMetadata.ColumnNames.ClassName, value))
				{
					OnPropertyChanged(CourseMetadata.PropertyNames.ClassName);
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
						case "C1": this.str().C1 = (string)value; break;							
						case "C2": this.str().C2 = (string)value; break;							
						case "ClassName": this.str().ClassName = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "C1":
						
							if (value == null || value is System.Int32)
								this.C1 = (System.Int32?)value;
								OnPropertyChanged(CourseMetadata.PropertyNames.C1);
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
			public esStrings(esCourse entity)
			{
				this.entity = entity;
			}
			
	
			public System.String C1
			{
				get
				{
					System.Int32? data = entity.C1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.C1 = null;
					else entity.C1 = Convert.ToInt32(value);
				}
			}
				
			public System.String C2
			{
				get
				{
					System.String data = entity.C2;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.C2 = null;
					else entity.C2 = Convert.ToString(value);
				}
			}
				
			public System.String ClassName
			{
				get
				{
					System.String data = entity.ClassName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ClassName = null;
					else entity.ClassName = Convert.ToString(value);
				}
			}
			

			private esCourse entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CourseMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CourseQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CourseQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CourseQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CourseQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CourseQuery query;		
	}



	[Serializable]
	abstract public partial class esCourseCollection : esEntityCollection<Course>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CourseMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CourseCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CourseQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CourseQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CourseQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CourseQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CourseQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CourseQuery)query);
		}

		#endregion
		
		private CourseQuery query;
	}



	[Serializable]
	abstract public partial class esCourseQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CourseMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "C1": return this.C1;
				case "C2": return this.C2;
				case "ClassName": return this.ClassName;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem C1
		{
			get { return new esQueryItem(this, CourseMetadata.ColumnNames.C1, esSystemType.Int32); }
		} 
		
		public esQueryItem C2
		{
			get { return new esQueryItem(this, CourseMetadata.ColumnNames.C2, esSystemType.String); }
		} 
		
		public esQueryItem ClassName
		{
			get { return new esQueryItem(this, CourseMetadata.ColumnNames.ClassName, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Course : esCourse
	{

		#region UpToStudentCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_StudentClass_Class
		/// </summary>

		[XmlIgnore]
		public StudentCollection UpToStudentCollection
		{
			get
			{
				if(this._UpToStudentCollection == null)
				{
					this._UpToStudentCollection = new StudentCollection();
					this._UpToStudentCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToStudentCollection", this._UpToStudentCollection);
					if (!this.es.IsLazyLoadDisabled && this.C1 != null)
					{
						StudentQuery m = new StudentQuery("m");
						StudentClassQuery j = new StudentClassQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.S1 == j.Sid1 && m.S2 == j.Sid2);
                        m.Where(j.Cid1 == this.C1);
                        m.Where(j.Cid2 == this.C2);

						this._UpToStudentCollection.Load(m);
					}
				}

				return this._UpToStudentCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToStudentCollection != null) 
				{ 
					this.RemovePostSave("UpToStudentCollection"); 
					this._UpToStudentCollection = null;
					this.OnPropertyChanged("UpToStudentCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_StudentClass_Class
		/// </summary>
		public void AssociateStudentCollection(Student entity)
		{
			if (this._StudentClassCollection == null)
			{
				this._StudentClassCollection = new StudentClassCollection();
				this._StudentClassCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("StudentClassCollection", this._StudentClassCollection);
			}

			StudentClass obj = this._StudentClassCollection.AddNew();
			obj.Cid1 = this.C1;
			obj.Cid2 = this.C2;
			obj.Sid1 = entity.S1;
			obj.Sid2 = entity.S2;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_StudentClass_Class
		/// </summary>
		public void DissociateStudentCollection(Student entity)
		{
			if (this._StudentClassCollection == null)
			{
				this._StudentClassCollection = new StudentClassCollection();
				this._StudentClassCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("StudentClassCollection", this._StudentClassCollection);
			}

			StudentClass obj = this._StudentClassCollection.AddNew();
			obj.Cid1 = this.C1;
			obj.Cid2 = this.C2;
            obj.Sid1 = entity.S1;
            obj.Sid2 = entity.S2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private StudentCollection _UpToStudentCollection;
		private StudentClassCollection _StudentClassCollection;
		#endregion

		#region StudentClassCollectionByCid1 - Zero To Many
		
		static public esPrefetchMap Prefetch_StudentClassCollectionByCid1
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Course.StudentClassCollectionByCid1_Delegate;
				map.PropertyName = "StudentClassCollectionByCid1";
				map.MyColumnName = "CID1,CID2";
				map.ParentColumnName = "C1,C2";
				map.IsMultiPartKey = true;
				return map;
			}
		}		
		
		static private void StudentClassCollectionByCid1_Delegate(esPrefetchParameters data)
		{
			CourseQuery parent = new CourseQuery(data.NextAlias());

			StudentClassQuery me = data.You != null ? data.You as StudentClassQuery : new StudentClassQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.C1 == me.Cid1 && parent.C2 == me.Cid2);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_StudentClass_Class
		/// </summary>

		[XmlIgnore]
		public StudentClassCollection StudentClassCollectionByCid1
		{
			get
			{
				if(this._StudentClassCollectionByCid1 == null)
				{
					this._StudentClassCollectionByCid1 = new StudentClassCollection();
					this._StudentClassCollectionByCid1.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StudentClassCollectionByCid1", this._StudentClassCollectionByCid1);
				
					if (this.C1 != null && this.C2 != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StudentClassCollectionByCid1.Query.Where(this._StudentClassCollectionByCid1.Query.Cid1 == this.C1);
							this._StudentClassCollectionByCid1.Query.Where(this._StudentClassCollectionByCid1.Query.Cid2 == this.C2);
							this._StudentClassCollectionByCid1.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StudentClassCollectionByCid1.fks.Add(StudentClassMetadata.ColumnNames.Cid1, this.C1);
						this._StudentClassCollectionByCid1.fks.Add(StudentClassMetadata.ColumnNames.Cid2, this.C2);
					}
				}

				return this._StudentClassCollectionByCid1;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StudentClassCollectionByCid1 != null) 
				{ 
					this.RemovePostSave("StudentClassCollectionByCid1"); 
					this._StudentClassCollectionByCid1 = null;
					this.OnPropertyChanged("StudentClassCollectionByCid1");
				} 
			} 			
		}
			
		
		private StudentClassCollection _StudentClassCollectionByCid1;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "StudentClassCollectionByCid1":
					coll = this.StudentClassCollectionByCid1;
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
			
			props.Add(new esPropertyDescriptor(this, "StudentClassCollectionByCid1", typeof(StudentClassCollection), new StudentClass()));
		
			return props;
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Course")]
	[XmlType(TypeName="CourseProxyStub")]	
	[Serializable]
	public partial class CourseProxyStub
	{
		public CourseProxyStub() 
		{
			theEntity = this.entity = new Course();
		}

		public CourseProxyStub(Course obj)
		{
			theEntity = this.entity = obj;
		}

		public CourseProxyStub(Course obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Course(CourseProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Course);
		}

		[DataMember(Name="C1", Order=1, EmitDefaultValue=false)]
		public System.Int32? C1
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(CourseMetadata.ColumnNames.C1);
				else
					return this.Entity.C1;
			}
			set { this.Entity.C1 = value; }
		}

		[DataMember(Name="C2", Order=2, EmitDefaultValue=false)]
		public System.String C2
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(CourseMetadata.ColumnNames.C2);
				else
					return this.Entity.C2;
			}
			set { this.Entity.C2 = value; }
		}

		[DataMember(Name="ClassName", Order=3, EmitDefaultValue=false)]
		public System.String ClassName
		{
			get 
			{ 
				
				if (this.IncludeColumn(CourseMetadata.ColumnNames.ClassName))
					return this.Entity.ClassName;
				else
					return null;
			}
			set { this.Entity.ClassName = value; }
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
		public Course Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Course();
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
		public Course entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "CourseCollection")]
	[XmlType(TypeName="CourseCollectionProxyStub")]	
	[Serializable]
	public partial class CourseCollectionProxyStub 
	{
		protected CourseCollectionProxyStub() {}
		
		public CourseCollectionProxyStub(esEntityCollection<Course> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public CourseCollectionProxyStub(esEntityCollection<Course> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator CourseCollection(CourseCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Course);
		}
		
		public CourseCollectionProxyStub(esEntityCollection<Course> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Course entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new CourseProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new CourseProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Course entity in coll.es.DeletedEntities)
				{
					Collection.Add(new CourseProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<CourseProxyStub> Collection = new List<CourseProxyStub>();

		public CourseCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new CourseCollection();

				foreach (CourseProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private CourseCollection _coll;
	}



	[Serializable]
	public partial class CourseMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CourseMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CourseMetadata.ColumnNames.C1, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CourseMetadata.PropertyNames.C1;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CourseMetadata.ColumnNames.C2, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CourseMetadata.PropertyNames.C2;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CourseMetadata.ColumnNames.ClassName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CourseMetadata.PropertyNames.ClassName;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public CourseMetadata Meta()
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
			 public const string C1 = "C1";
			 public const string C2 = "C2";
			 public const string ClassName = "ClassName";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string C1 = "C1";
			 public const string C2 = "C2";
			 public const string ClassName = "ClassName";
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
			lock (typeof(CourseMetadata))
			{
				if(CourseMetadata.mapDelegates == null)
				{
					CourseMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CourseMetadata.meta == null)
				{
					CourseMetadata.meta = new CourseMetadata();
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


				meta.AddTypeMap("C1", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("C2", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("ClassName", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Class";
				meta.Destination = "Class";
				
				meta.spInsert = "proc_ClassInsert";				
				meta.spUpdate = "proc_ClassUpdate";		
				meta.spDelete = "proc_ClassDelete";
				meta.spLoadAll = "proc_ClassLoadAll";
				meta.spLoadByPrimaryKey = "proc_ClassLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CourseMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
