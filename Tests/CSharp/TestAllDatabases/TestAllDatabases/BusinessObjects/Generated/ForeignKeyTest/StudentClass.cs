
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
	/// Encapsulates the 'StudentClass' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(StudentClass))]	
	[XmlType("StudentClass")]
	[Table(Name="StudentClass")]
	public partial class StudentClass : esStudentClass
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new StudentClass();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.String sid1, System.String sid2, System.Int32 cid1, System.String cid2)
		{
			var obj = new StudentClass();
			obj.Sid1 = sid1;
			obj.Sid2 = sid2;
			obj.Cid1 = cid1;
			obj.Cid2 = cid2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.String sid1, System.String sid2, System.Int32 cid1, System.String cid2, esSqlAccessType sqlAccessType)
		{
			var obj = new StudentClass();
			obj.Sid1 = sid1;
			obj.Sid2 = sid2;
			obj.Cid1 = cid1;
			obj.Cid2 = cid2;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator StudentClassProxyStub(StudentClass entity)
		{
			return new StudentClassProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String Sid1
		{
			get { return base.Sid1;  }
			set { base.Sid1 = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String Sid2
		{
			get { return base.Sid2;  }
			set { base.Sid2 = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? Cid1
		{
			get { return base.Cid1;  }
			set { base.Cid1 = value; }
		}

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.String Cid2
		{
			get { return base.Cid2;  }
			set { base.Cid2 = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("StudentClassCollection")]
	public partial class StudentClassCollection : esStudentClassCollection, IEnumerable<StudentClass>
	{
		public StudentClass FindByPrimaryKey(System.String sid1, System.String sid2, System.Int32 cid1, System.String cid2)
		{
			return this.SingleOrDefault(e => e.Sid1 == sid1 && e.Sid2 == sid2 && e.Cid1 == cid1 && e.Cid2 == cid2);
		}

		#region Implicit Casts
		
		public static implicit operator StudentClassCollectionProxyStub(StudentClassCollection coll)
		{
			return new StudentClassCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(StudentClass))]
		public class StudentClassCollectionWCFPacket : esCollectionWCFPacket<StudentClassCollection>
		{
			public static implicit operator StudentClassCollection(StudentClassCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator StudentClassCollectionWCFPacket(StudentClassCollection collection)
			{
				return new StudentClassCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "StudentClassQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class StudentClassQuery : esStudentClassQuery
	{
		public StudentClassQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "StudentClassQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(StudentClassQuery query)
		{
			return StudentClassQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator StudentClassQuery(string query)
		{
			return (StudentClassQuery)StudentClassQuery.SerializeHelper.FromXml(query, typeof(StudentClassQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esStudentClass : esEntity
	{
		public esStudentClass()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.String sid1, System.String sid2, System.Int32 cid1, System.String cid2)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(sid1, sid2, cid1, cid2);
			else
				return LoadByPrimaryKeyStoredProcedure(sid1, sid2, cid1, cid2);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.String sid1, System.String sid2, System.Int32 cid1, System.String cid2)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(sid1, sid2, cid1, cid2);
			else
				return LoadByPrimaryKeyStoredProcedure(sid1, sid2, cid1, cid2);
		}

		private bool LoadByPrimaryKeyDynamic(System.String sid1, System.String sid2, System.Int32 cid1, System.String cid2)
		{
			StudentClassQuery query = new StudentClassQuery();
			query.Where(query.Sid1 == sid1, query.Sid2 == sid2, query.Cid1 == cid1, query.Cid2 == cid2);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.String sid1, System.String sid2, System.Int32 cid1, System.String cid2)
		{
			esParameters parms = new esParameters();
			parms.Add("Sid1", sid1);			parms.Add("Sid2", sid2);			parms.Add("Cid1", cid1);			parms.Add("Cid2", cid2);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to StudentClass.SID1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Sid1
		{
			get
			{
				return base.GetSystemString(StudentClassMetadata.ColumnNames.Sid1);
			}
			
			set
			{
				if(base.SetSystemString(StudentClassMetadata.ColumnNames.Sid1, value))
				{
					this._UpToStudentBySid1 = null;
					this.OnPropertyChanged("UpToStudentBySid1");
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Sid1);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StudentClass.SID2
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Sid2
		{
			get
			{
				return base.GetSystemString(StudentClassMetadata.ColumnNames.Sid2);
			}
			
			set
			{
				if(base.SetSystemString(StudentClassMetadata.ColumnNames.Sid2, value))
				{
					this._UpToStudentBySid1 = null;
					this.OnPropertyChanged("UpToStudentBySid1");
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Sid2);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StudentClass.CID1
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Cid1
		{
			get
			{
				return base.GetSystemInt32(StudentClassMetadata.ColumnNames.Cid1);
			}
			
			set
			{
				if(base.SetSystemInt32(StudentClassMetadata.ColumnNames.Cid1, value))
				{
					this._UpToCourseByCid1 = null;
					this.OnPropertyChanged("UpToCourseByCid1");
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Cid1);
				}
			}
		}		
		
		/// <summary>
		/// Maps to StudentClass.CID2
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Cid2
		{
			get
			{
				return base.GetSystemString(StudentClassMetadata.ColumnNames.Cid2);
			}
			
			set
			{
				if(base.SetSystemString(StudentClassMetadata.ColumnNames.Cid2, value))
				{
					this._UpToCourseByCid1 = null;
					this.OnPropertyChanged("UpToCourseByCid1");
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Cid2);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Course _UpToCourseByCid1;
		[CLSCompliant(false)]
		internal protected Student _UpToStudentBySid1;
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
						case "Sid1": this.str().Sid1 = (string)value; break;							
						case "Sid2": this.str().Sid2 = (string)value; break;							
						case "Cid1": this.str().Cid1 = (string)value; break;							
						case "Cid2": this.str().Cid2 = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Cid1":
						
							if (value == null || value is System.Int32)
								this.Cid1 = (System.Int32?)value;
								OnPropertyChanged(StudentClassMetadata.PropertyNames.Cid1);
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
			public esStrings(esStudentClass entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Sid1
			{
				get
				{
					System.String data = entity.Sid1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Sid1 = null;
					else entity.Sid1 = Convert.ToString(value);
				}
			}
				
			public System.String Sid2
			{
				get
				{
					System.String data = entity.Sid2;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Sid2 = null;
					else entity.Sid2 = Convert.ToString(value);
				}
			}
				
			public System.String Cid1
			{
				get
				{
					System.Int32? data = entity.Cid1;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Cid1 = null;
					else entity.Cid1 = Convert.ToInt32(value);
				}
			}
				
			public System.String Cid2
			{
				get
				{
					System.String data = entity.Cid2;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Cid2 = null;
					else entity.Cid2 = Convert.ToString(value);
				}
			}
			

			private esStudentClass entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return StudentClassMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public StudentClassQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StudentClassQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StudentClassQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(StudentClassQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private StudentClassQuery query;		
	}



	[Serializable]
	abstract public partial class esStudentClassCollection : esEntityCollection<StudentClass>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return StudentClassMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "StudentClassCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public StudentClassQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new StudentClassQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(StudentClassQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new StudentClassQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(StudentClassQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((StudentClassQuery)query);
		}

		#endregion
		
		private StudentClassQuery query;
	}



	[Serializable]
	abstract public partial class esStudentClassQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return StudentClassMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Sid1": return this.Sid1;
				case "Sid2": return this.Sid2;
				case "Cid1": return this.Cid1;
				case "Cid2": return this.Cid2;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Sid1
		{
			get { return new esQueryItem(this, StudentClassMetadata.ColumnNames.Sid1, esSystemType.String); }
		} 
		
		public esQueryItem Sid2
		{
			get { return new esQueryItem(this, StudentClassMetadata.ColumnNames.Sid2, esSystemType.String); }
		} 
		
		public esQueryItem Cid1
		{
			get { return new esQueryItem(this, StudentClassMetadata.ColumnNames.Cid1, esSystemType.Int32); }
		} 
		
		public esQueryItem Cid2
		{
			get { return new esQueryItem(this, StudentClassMetadata.ColumnNames.Cid2, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class StudentClass : esStudentClass
	{

				
		#region UpToCourseByCid1 - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_StudentClass_Class
		/// </summary>

		[XmlIgnore]
					
		public Course UpToCourseByCid1
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCourseByCid1 == null && Cid1 != null && Cid2 != null)
				{
					this._UpToCourseByCid1 = new Course();
					this._UpToCourseByCid1.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCourseByCid1", this._UpToCourseByCid1);
					this._UpToCourseByCid1.Query.Where(this._UpToCourseByCid1.Query.C1 == this.Cid1);
					this._UpToCourseByCid1.Query.Where(this._UpToCourseByCid1.Query.C2 == this.Cid2);
					this._UpToCourseByCid1.Query.Load();
				}	
				return this._UpToCourseByCid1;
			}
			
			set
			{
				this.RemovePreSave("UpToCourseByCid1");
				
				bool changed = this._UpToCourseByCid1 != value;

				if(value == null)
				{
					this.Cid1 = null;
					this.Cid2 = null;
					this._UpToCourseByCid1 = null;
				}
				else
				{
					this.Cid1 = value.C1;
					this.Cid2 = value.C2;
					this._UpToCourseByCid1 = value;
					this.SetPreSave("UpToCourseByCid1", this._UpToCourseByCid1);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCourseByCid1");
				}
			}
		}
		#endregion
		

				
		#region UpToStudentBySid1 - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_StudentClass_Student
		/// </summary>

		[XmlIgnore]
					
		public Student UpToStudentBySid1
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToStudentBySid1 == null && Sid1 != null && Sid2 != null)
				{
					this._UpToStudentBySid1 = new Student();
					this._UpToStudentBySid1.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToStudentBySid1", this._UpToStudentBySid1);
					this._UpToStudentBySid1.Query.Where(this._UpToStudentBySid1.Query.S1 == this.Sid1);
					this._UpToStudentBySid1.Query.Where(this._UpToStudentBySid1.Query.S2 == this.Sid2);
					this._UpToStudentBySid1.Query.Load();
				}	
				return this._UpToStudentBySid1;
			}
			
			set
			{
				this.RemovePreSave("UpToStudentBySid1");
				
				bool changed = this._UpToStudentBySid1 != value;

				if(value == null)
				{
					this.Sid1 = null;
					this.Sid2 = null;
					this._UpToStudentBySid1 = null;
				}
				else
				{
					this.Sid1 = value.S1;
					this.Sid2 = value.S2;
					this._UpToStudentBySid1 = value;
					this.SetPreSave("UpToStudentBySid1", this._UpToStudentBySid1);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToStudentBySid1");
				}
			}
		}
		#endregion
		

		
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "StudentClass")]
	[XmlType(TypeName="StudentClassProxyStub")]	
	[Serializable]
	public partial class StudentClassProxyStub
	{
		public StudentClassProxyStub() 
		{
			theEntity = this.entity = new StudentClass();
		}

		public StudentClassProxyStub(StudentClass obj)
		{
			theEntity = this.entity = obj;
		}

		public StudentClassProxyStub(StudentClass obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator StudentClass(StudentClassProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(StudentClass);
		}

		[DataMember(Name="Sid1", Order=1, EmitDefaultValue=false)]
		public System.String Sid1
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Sid1);
				else
					return this.Entity.Sid1;
			}
			set { this.Entity.Sid1 = value; }
		}

		[DataMember(Name="Sid2", Order=2, EmitDefaultValue=false)]
		public System.String Sid2
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Sid2);
				else
					return this.Entity.Sid2;
			}
			set { this.Entity.Sid2 = value; }
		}

		[DataMember(Name="Cid1", Order=3, EmitDefaultValue=false)]
		public System.Int32? Cid1
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Cid1);
				else
					return this.Entity.Cid1;
			}
			set { this.Entity.Cid1 = value; }
		}

		[DataMember(Name="Cid2", Order=4, EmitDefaultValue=false)]
		public System.String Cid2
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.String)this.Entity.
						GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Cid2);
				else
					return this.Entity.Cid2;
			}
			set { this.Entity.Cid2 = value; }
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
		public StudentClass Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new StudentClass();
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
		public StudentClass entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "StudentClassCollection")]
	[XmlType(TypeName="StudentClassCollectionProxyStub")]	
	[Serializable]
	public partial class StudentClassCollectionProxyStub 
	{
		protected StudentClassCollectionProxyStub() {}
		
		public StudentClassCollectionProxyStub(esEntityCollection<StudentClass> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public StudentClassCollectionProxyStub(esEntityCollection<StudentClass> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator StudentClassCollection(StudentClassCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(StudentClass);
		}
		
		public StudentClassCollectionProxyStub(esEntityCollection<StudentClass> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (StudentClass entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new StudentClassProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new StudentClassProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (StudentClass entity in coll.es.DeletedEntities)
				{
					Collection.Add(new StudentClassProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<StudentClassProxyStub> Collection = new List<StudentClassProxyStub>();

		public StudentClassCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new StudentClassCollection();

				foreach (StudentClassProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private StudentClassCollection _coll;
	}



	[Serializable]
	public partial class StudentClassMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected StudentClassMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(StudentClassMetadata.ColumnNames.Sid1, 0, typeof(System.String), esSystemType.String);
			c.PropertyName = StudentClassMetadata.PropertyNames.Sid1;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 5;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StudentClassMetadata.ColumnNames.Sid2, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = StudentClassMetadata.PropertyNames.Sid2;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 3;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StudentClassMetadata.ColumnNames.Cid1, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = StudentClassMetadata.PropertyNames.Cid1;
			c.IsInPrimaryKey = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(StudentClassMetadata.ColumnNames.Cid2, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = StudentClassMetadata.PropertyNames.Cid2;
			c.IsInPrimaryKey = true;
			c.CharacterMaxLength = 10;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public StudentClassMetadata Meta()
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
			 public const string Sid1 = "SID1";
			 public const string Sid2 = "SID2";
			 public const string Cid1 = "CID1";
			 public const string Cid2 = "CID2";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Sid1 = "Sid1";
			 public const string Sid2 = "Sid2";
			 public const string Cid1 = "Cid1";
			 public const string Cid2 = "Cid2";
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
			lock (typeof(StudentClassMetadata))
			{
				if(StudentClassMetadata.mapDelegates == null)
				{
					StudentClassMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (StudentClassMetadata.meta == null)
				{
					StudentClassMetadata.meta = new StudentClassMetadata();
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


				meta.AddTypeMap("Sid1", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("Sid2", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("Cid1", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Cid2", new esTypeMap("nchar", "System.String"));			
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				
				meta.Source = "StudentClass";
				meta.Destination = "StudentClass";
				
				meta.spInsert = "proc_StudentClassInsert";				
				meta.spUpdate = "proc_StudentClassUpdate";		
				meta.spDelete = "proc_StudentClassDelete";
				meta.spLoadAll = "proc_StudentClassLoadAll";
				meta.spLoadByPrimaryKey = "proc_StudentClassLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private StudentClassMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
