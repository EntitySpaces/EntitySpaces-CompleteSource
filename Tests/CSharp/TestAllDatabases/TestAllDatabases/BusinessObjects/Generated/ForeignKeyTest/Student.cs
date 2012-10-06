
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
	/// Encapsulates the 'Student' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(Student))]	
	[XmlType("Student")]
	[Table(Name="Student")]
	public partial class Student : esStudent
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Student();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String s1, System.String s2)
		{
			var obj = new Student();
			obj.S1 = s1;
			obj.S2 = s2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String s1, System.String s2, esSqlAccessType sqlAccessType)
		{
			var obj = new Student();
			obj.S1 = s1;
			obj.S2 = s2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator StudentProxyStub(Student entity)
		{
			return new StudentProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String S1
		{
			get { return base.S1;  }
			set { base.S1 = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String S2
		{
			get { return base.S2;  }
			set { base.S2 = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String StudentName
		{
			get { return base.StudentName;  }
			set { base.StudentName = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("StudentCollection")]
	public partial class StudentCollection : esStudentCollection, IEnumerable<Student>
	{
		public Student FindByPrimaryKey(System.String s1, System.String s2)
		{
			return this.SingleOrDefault(e => e.S1 == s1 && e.S2 == s2);
		}

		#region Implicit Casts
		
		public static implicit operator StudentCollectionProxyStub(StudentCollection coll)
		{
			return new StudentCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Student))]
		public class StudentCollectionWCFPacket : esCollectionWCFPacket<StudentCollection>
		{
			public static implicit operator StudentCollection(StudentCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator StudentCollectionWCFPacket(StudentCollection collection)
			{
				return new StudentCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "StudentQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class StudentQuery : esStudentQuery
	{
		public StudentQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "StudentQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(StudentQuery query)
		{
			return StudentQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator StudentQuery(string query)
		{
			return (StudentQuery)StudentQuery.SerializeHelper.FromXml(query, typeof(StudentQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esStudent : esEntity
	{
		public esStudent()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String s1, System.String s2)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(s1, s2);
			else
				return LoadByPrimaryKeyStoredProcedure(s1, s2);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String s1, System.String s2)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(s1, s2);
			else
				return LoadByPrimaryKeyStoredProcedure(s1, s2);
		}

		private bool LoadByPrimaryKeyDynamic(System.String s1, System.String s2)
		{
			StudentQuery query = new StudentQuery();
			query.Where(query.S1 == s1, query.S2 == s2);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String s1, System.String s2)
		{
			esParameters parms = new esParameters();
			parms.Add("S1", s1);			parms.Add("S2", s2);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Student.S1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S1
		{
			get
			{
				return base.GetSystemString(StudentMetadata.ColumnNames.S1);
			}
			
			set
			{
				if(base.SetSystemString(StudentMetadata.ColumnNames.S1, value))
				{
					OnPropertyChanged(StudentMetadata.PropertyNames.S1);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Student.S2
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String S2
		{
			get
			{
				return base.GetSystemString(StudentMetadata.ColumnNames.S2);
			}
			
			set
			{
				if(base.SetSystemString(StudentMetadata.ColumnNames.S2, value))
				{
					OnPropertyChanged(StudentMetadata.PropertyNames.S2);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Student.StudentName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String StudentName
		{
			get
			{
				return base.GetSystemString(StudentMetadata.ColumnNames.StudentName);
			}
			
			set
			{
				if(base.SetSystemString(StudentMetadata.ColumnNames.StudentName, value))
				{
					OnPropertyChanged(StudentMetadata.PropertyNames.StudentName);
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
						case "S1": this.str().S1 = (string)value; break;							
						case "S2": this.str().S2 = (string)value; break;							
						case "StudentName": this.str().StudentName = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{

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
			public esStrings(esStudent entity)
			{
				this.entity = entity;
			}
			
	
			public System.String S1
			{
				get
				{
					System.String data = entity.S1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S1 = null;
					else entity.S1 = Convert.ToString(value);
				}
			}
				
			public System.String S2
			{
				get
				{
					System.String data = entity.S2;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.S2 = null;
					else entity.S2 = Convert.ToString(value);
				}
			}
				
			public System.String StudentName
			{
				get
				{
					System.String data = entity.StudentName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.StudentName = null;
					else entity.StudentName = Convert.ToString(value);
				}
			}
			

			private esStudent entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return StudentMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public StudentQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StudentQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StudentQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(StudentQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private StudentQuery query;		
	}



	[Serializable]
	abstract public partial class esStudentCollection : esEntityCollection<Student>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return StudentMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "StudentCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public StudentQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StudentQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StudentQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new StudentQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(StudentQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((StudentQuery)query);
		}

		#endregion
		
		private StudentQuery query;
	}



	[Serializable]
	abstract public partial class esStudentQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return StudentMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "S1": return this.S1;
				case "S2": return this.S2;
				case "StudentName": return this.StudentName;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem S1
		{
			get { return new esQueryItem(this, StudentMetadata.ColumnNames.S1, esSystemType.String); }
		} 
		
		public esQueryItem S2
		{
			get { return new esQueryItem(this, StudentMetadata.ColumnNames.S2, esSystemType.String); }
		} 
		
		public esQueryItem StudentName
		{
			get { return new esQueryItem(this, StudentMetadata.ColumnNames.StudentName, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Student : esStudent
	{

		#region UpToCourseCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_StudentClass_Student
		/// </summary>

		[XmlIgnore]
		public CourseCollection UpToCourseCollection
		{
			get
			{
				if(this._UpToCourseCollection == null)
				{
					this._UpToCourseCollection = new CourseCollection();
					this._UpToCourseCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToCourseCollection", this._UpToCourseCollection);
					if (!this.es.IsLazyLoadDisabled && this.S1 != null)
					{
						CourseQuery m = new CourseQuery("m");
						StudentClassQuery j = new StudentClassQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.C1 == j.Cid1 && m.C2 == j.Cid2);
                        m.Where(j.Sid1 == this.S1);
                        m.Where(j.Sid2 == this.S2);

						this._UpToCourseCollection.Load(m);
					}
				}

				return this._UpToCourseCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToCourseCollection != null) 
				{ 
					this.RemovePostSave("UpToCourseCollection"); 
					this._UpToCourseCollection = null;
					this.OnPropertyChanged("UpToCourseCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_StudentClass_Student
		/// </summary>
		public void AssociateCourseCollection(Course entity)
		{
			if (this._StudentClassCollection == null)
			{
				this._StudentClassCollection = new StudentClassCollection();
				this._StudentClassCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("StudentClassCollection", this._StudentClassCollection);
			}

			StudentClass obj = this._StudentClassCollection.AddNew();
			obj.Sid1 = this.S1;
			obj.Sid2 = this.S2;
			obj.Cid1 = entity.C1;
			obj.Cid2 = entity.C2;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_StudentClass_Student
		/// </summary>
		public void DissociateCourseCollection(Course entity)
		{
			if (this._StudentClassCollection == null)
			{
				this._StudentClassCollection = new StudentClassCollection();
				this._StudentClassCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("StudentClassCollection", this._StudentClassCollection);
			}

			StudentClass obj = this._StudentClassCollection.AddNew();
			obj.Sid1 = this.S1;
			obj.Sid2 = this.S2;
            obj.Cid1 = entity.C1;
            obj.Cid2 = entity.C2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private CourseCollection _UpToCourseCollection;
		private StudentClassCollection _StudentClassCollection;
		#endregion

		#region StudentClassCollectionBySid1 - Zero To Many
		
		static public esPrefetchMap Prefetch_StudentClassCollectionBySid1
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Student.StudentClassCollectionBySid1_Delegate;
				map.PropertyName = "StudentClassCollectionBySid1";
				map.MyColumnName = "SID1,SID2";
				map.ParentColumnName = "S1,S2";
				map.IsMultiPartKey = true;
				return map;
			}
		}		
		
		static private void StudentClassCollectionBySid1_Delegate(esPrefetchParameters data)
		{
			StudentQuery parent = new StudentQuery(data.NextAlias());

			StudentClassQuery me = data.You != null ? data.You as StudentClassQuery : new StudentClassQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.S1 == me.Sid1 && parent.S2 == me.Sid2);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_StudentClass_Student
		/// </summary>

		[XmlIgnore]
		public StudentClassCollection StudentClassCollectionBySid1
		{
			get
			{
				if(this._StudentClassCollectionBySid1 == null)
				{
					this._StudentClassCollectionBySid1 = new StudentClassCollection();
					this._StudentClassCollectionBySid1.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("StudentClassCollectionBySid1", this._StudentClassCollectionBySid1);
				
					if (this.S1 != null && this.S2 != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._StudentClassCollectionBySid1.Query.Where(this._StudentClassCollectionBySid1.Query.Sid1 == this.S1);
							this._StudentClassCollectionBySid1.Query.Where(this._StudentClassCollectionBySid1.Query.Sid2 == this.S2);
							this._StudentClassCollectionBySid1.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._StudentClassCollectionBySid1.fks.Add(StudentClassMetadata.ColumnNames.Sid1, this.S1);
						this._StudentClassCollectionBySid1.fks.Add(StudentClassMetadata.ColumnNames.Sid2, this.S2);
					}
				}

				return this._StudentClassCollectionBySid1;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._StudentClassCollectionBySid1 != null) 
				{ 
					this.RemovePostSave("StudentClassCollectionBySid1"); 
					this._StudentClassCollectionBySid1 = null;
					this.OnPropertyChanged("StudentClassCollectionBySid1");
				} 
			} 			
		}
			
		
		private StudentClassCollection _StudentClassCollectionBySid1;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "StudentClassCollectionBySid1":
					coll = this.StudentClassCollectionBySid1;
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
			
			props.Add(new esPropertyDescriptor(this, "StudentClassCollectionBySid1", typeof(StudentClassCollection), new StudentClass()));
		
			return props;
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Student")]
	[XmlType(TypeName="StudentProxyStub")]	
	[Serializable]
	public partial class StudentProxyStub
	{
		public StudentProxyStub() 
		{
			theEntity = this.entity = new Student();
		}

		public StudentProxyStub(Student obj)
		{
			theEntity = this.entity = obj;
		}

		public StudentProxyStub(Student obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Student(StudentProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Student);
		}

		[DataMember(Name="S1", Order=1, EmitDefaultValue=false)]
		public System.String S1
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(StudentMetadata.ColumnNames.S1);
				else
					return this.Entity.S1;
			}
			set { this.Entity.S1 = value; }
		}

		[DataMember(Name="S2", Order=2, EmitDefaultValue=false)]
		public System.String S2
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(StudentMetadata.ColumnNames.S2);
				else
					return this.Entity.S2;
			}
			set { this.Entity.S2 = value; }
		}

		[DataMember(Name="StudentName", Order=3, EmitDefaultValue=false)]
		public System.String StudentName
		{
			get 
			{ 
				
				if (this.IncludeColumn(StudentMetadata.ColumnNames.StudentName))
					return this.Entity.StudentName;
				else
					return null;
			}
			set { this.Entity.StudentName = value; }
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
		public Student Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Student();
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
		public Student entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "StudentCollection")]
	[XmlType(TypeName="StudentCollectionProxyStub")]	
	[Serializable]
	public partial class StudentCollectionProxyStub 
	{
		protected StudentCollectionProxyStub() {}
		
		public StudentCollectionProxyStub(esEntityCollection<Student> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public StudentCollectionProxyStub(esEntityCollection<Student> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator StudentCollection(StudentCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Student);
		}
		
		public StudentCollectionProxyStub(esEntityCollection<Student> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Student entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new StudentProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new StudentProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Student entity in coll.es.DeletedEntities)
				{
					Collection.Add(new StudentProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<StudentProxyStub> Collection = new List<StudentProxyStub>();

		public StudentCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new StudentCollection();

				foreach (StudentProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private StudentCollection _coll;
	}



	[Serializable]
	public partial class StudentMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected StudentMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(StudentMetadata.ColumnNames.S1, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = StudentMetadata.PropertyNames.S1;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StudentMetadata.ColumnNames.S2, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = StudentMetadata.PropertyNames.S2;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StudentMetadata.ColumnNames.StudentName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = StudentMetadata.PropertyNames.StudentName;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public StudentMetadata Meta()
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
			 public const string S1 = "S1";
			 public const string S2 = "S2";
			 public const string StudentName = "StudentName";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string S1 = "S1";
			 public const string S2 = "S2";
			 public const string StudentName = "StudentName";
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
			lock (typeof(StudentMetadata))
			{
				if(StudentMetadata.mapDelegates == null)
				{
					StudentMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (StudentMetadata.meta == null)
				{
					StudentMetadata.meta = new StudentMetadata();
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


				meta.AddTypeMap("S1", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("S2", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("StudentName", new esTypeMap("varchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "Student";
				meta.Destination = "Student";
				
				meta.spInsert = "proc_StudentInsert";				
				meta.spUpdate = "proc_StudentUpdate";		
				meta.spDelete = "proc_StudentDelete";
				meta.spLoadAll = "proc_StudentLoadAll";
				meta.spLoadByPrimaryKey = "proc_StudentLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private StudentMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
