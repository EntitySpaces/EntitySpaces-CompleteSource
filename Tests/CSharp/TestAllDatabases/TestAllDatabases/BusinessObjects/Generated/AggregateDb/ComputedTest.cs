
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
	/// Multi-line table Description
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(ComputedTest))]	
	[XmlType("ComputedTest")]
	[Table(Name="ComputedTest")]
	public partial class ComputedTest : esComputedTest
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ComputedTest();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new ComputedTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new ComputedTest();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ComputedTestProxyStub(ComputedTest entity)
		{
			return new ComputedTestProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Byte[] ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateLastUpdated
		{
			get { return base.DateLastUpdated;  }
			set { base.DateLastUpdated = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateAdded
		{
			get { return base.DateAdded;  }
			set { base.DateAdded = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? ComputedField
		{
			get { return base.ComputedField;  }
			set { base.ComputedField = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? SomeDate
		{
			get { return base.SomeDate;  }
			set { base.SomeDate = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ComputedTestCollection")]
	public partial class ComputedTestCollection : esComputedTestCollection, IEnumerable<ComputedTest>
	{
		public ComputedTest FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator ComputedTestCollectionProxyStub(ComputedTestCollection coll)
		{
			return new ComputedTestCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ComputedTest))]
		public class ComputedTestCollectionWCFPacket : esCollectionWCFPacket<ComputedTestCollection>
		{
			public static implicit operator ComputedTestCollection(ComputedTestCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ComputedTestCollectionWCFPacket(ComputedTestCollection collection)
			{
				return new ComputedTestCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ComputedTestQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ComputedTestQuery : esComputedTestQuery
	{
		public ComputedTestQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ComputedTestQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ComputedTestQuery query)
		{
			return ComputedTestQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ComputedTestQuery(string query)
		{
			return (ComputedTestQuery)ComputedTestQuery.SerializeHelper.FromXml(query, typeof(ComputedTestQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esComputedTest : EntityBase
	{
		public esComputedTest()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			ComputedTestQuery query = new ComputedTestQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ComputedTest.ID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(ComputedTestMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(ComputedTestMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ComputedTest.ConcurrencyCheck
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte[] ConcurrencyCheck
		{
			get
			{
				return base.GetSystemByteArray(ComputedTestMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemByteArray(ComputedTestMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Multi-line Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateLastUpdated
		{
			get
			{
				return base.GetSystemDateTime(ComputedTestMetadata.ColumnNames.DateLastUpdated);
			}
			
			set
			{
				if(base.SetSystemDateTime(ComputedTestMetadata.ColumnNames.DateLastUpdated, value))
				{
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateLastUpdated);
				}
			}
		}		
		
		/// <summary>
		/// See "this"
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateAdded
		{
			get
			{
				return base.GetSystemDateTime(ComputedTestMetadata.ColumnNames.DateAdded);
			}
			
			set
			{
				if(base.SetSystemDateTime(ComputedTestMetadata.ColumnNames.DateAdded, value))
				{
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateAdded);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ComputedTest.ComputedTest
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ComputedField
		{
			get
			{
				return base.GetSystemInt32(ComputedTestMetadata.ColumnNames.ComputedField);
			}
			
			set
			{
				if(base.SetSystemInt32(ComputedTestMetadata.ColumnNames.ComputedField, value))
				{
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.ComputedField);
				}
			}
		}		
		
		/// <summary>
		/// See C:\this
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? SomeDate
		{
			get
			{
				return base.GetSystemDateTime(ComputedTestMetadata.ColumnNames.SomeDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(ComputedTestMetadata.ColumnNames.SomeDate, value))
				{
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.SomeDate);
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
						case "Id": this.str().Id = (string)value; break;							
						case "DateLastUpdated": this.str().DateLastUpdated = (string)value; break;							
						case "DateAdded": this.str().DateAdded = (string)value; break;							
						case "ComputedField": this.str().ComputedField = (string)value; break;							
						case "SomeDate": this.str().SomeDate = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.Id);
							break;
						
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Byte[])
								this.ConcurrencyCheck = (System.Byte[])value;
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.ConcurrencyCheck);
							break;
						
						case "DateLastUpdated":
						
							if (value == null || value is System.DateTime)
								this.DateLastUpdated = (System.DateTime?)value;
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateLastUpdated);
							break;
						
						case "DateAdded":
						
							if (value == null || value is System.DateTime)
								this.DateAdded = (System.DateTime?)value;
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateAdded);
							break;
						
						case "ComputedField":
						
							if (value == null || value is System.Int32)
								this.ComputedField = (System.Int32?)value;
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.ComputedField);
							break;
						
						case "SomeDate":
						
							if (value == null || value is System.DateTime)
								this.SomeDate = (System.DateTime?)value;
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.SomeDate);
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
			public esStrings(esComputedTest entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String DateLastUpdated
			{
				get
				{
					System.DateTime? data = entity.DateLastUpdated;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateLastUpdated = null;
					else entity.DateLastUpdated = Convert.ToDateTime(value);
				}
			}
				
			public System.String DateAdded
			{
				get
				{
					System.DateTime? data = entity.DateAdded;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateAdded = null;
					else entity.DateAdded = Convert.ToDateTime(value);
				}
			}
				
			public System.String ComputedField
			{
				get
				{
					System.Int32? data = entity.ComputedField;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ComputedField = null;
					else entity.ComputedField = Convert.ToInt32(value);
				}
			}
				
			public System.String SomeDate
			{
				get
				{
					System.DateTime? data = entity.SomeDate;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SomeDate = null;
					else entity.SomeDate = Convert.ToDateTime(value);
				}
			}
			

			private esComputedTest entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ComputedTestMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ComputedTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ComputedTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ComputedTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ComputedTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ComputedTestQuery query;		
	}



	[Serializable]
	abstract public partial class esComputedTestCollection : CollectionBase<ComputedTest>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ComputedTestMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ComputedTestCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ComputedTestQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ComputedTestQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ComputedTestQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ComputedTestQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ComputedTestQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ComputedTestQuery)query);
		}

		#endregion
		
		private ComputedTestQuery query;
	}



	[Serializable]
	abstract public partial class esComputedTestQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ComputedTestMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;
				case "DateLastUpdated": return this.DateLastUpdated;
				case "DateAdded": return this.DateAdded;
				case "ComputedField": return this.ComputedField;
				case "SomeDate": return this.SomeDate;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, ComputedTestMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, ComputedTestMetadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray); }
		} 
		
		public esQueryItem DateLastUpdated
		{
			get { return new esQueryItem(this, ComputedTestMetadata.ColumnNames.DateLastUpdated, esSystemType.DateTime); }
		} 
		
		public esQueryItem DateAdded
		{
			get { return new esQueryItem(this, ComputedTestMetadata.ColumnNames.DateAdded, esSystemType.DateTime); }
		} 
		
		public esQueryItem ComputedField
		{
			get { return new esQueryItem(this, ComputedTestMetadata.ColumnNames.ComputedField, esSystemType.Int32); }
		} 
		
		public esQueryItem SomeDate
		{
			get { return new esQueryItem(this, ComputedTestMetadata.ColumnNames.SomeDate, esSystemType.DateTime); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ComputedTest")]
	[XmlType(TypeName="ComputedTestProxyStub")]	
	[Serializable]
	public partial class ComputedTestProxyStub
	{
		public ComputedTestProxyStub() 
		{
			theEntity = this.entity = new ComputedTest();
		}

		public ComputedTestProxyStub(ComputedTest obj)
		{
			theEntity = this.entity = obj;
		}

		public ComputedTestProxyStub(ComputedTest obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator ComputedTest(ComputedTestProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(ComputedTest);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.Int32? Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(ComputedTestMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=2, EmitDefaultValue=false)]
		public System.Byte[] ConcurrencyCheck
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Byte[])this.Entity.
						GetOriginalColumnValue(ComputedTestMetadata.ColumnNames.ConcurrencyCheck);
				else
					return this.Entity.ConcurrencyCheck;
			}
			set { this.Entity.ConcurrencyCheck = value; }
		}

		[DataMember(Name="DateLastUpdated", Order=3, EmitDefaultValue=false)]
		public System.DateTime? DateLastUpdated
		{
			get 
			{ 
				
				if (this.IncludeColumn(ComputedTestMetadata.ColumnNames.DateLastUpdated))
					return this.Entity.DateLastUpdated;
				else
					return null;
			}
			set { this.Entity.DateLastUpdated = value; }
		}

		[DataMember(Name="DateAdded", Order=4, EmitDefaultValue=false)]
		public System.DateTime? DateAdded
		{
			get 
			{ 
				
				if (this.IncludeColumn(ComputedTestMetadata.ColumnNames.DateAdded))
					return this.Entity.DateAdded;
				else
					return null;
			}
			set { this.Entity.DateAdded = value; }
		}

		[DataMember(Name="ComputedField", Order=5, EmitDefaultValue=false)]
		public System.Int32? ComputedField
		{
			get 
			{ 
				
				if (this.IncludeColumn(ComputedTestMetadata.ColumnNames.ComputedField))
					return this.Entity.ComputedField;
				else
					return null;
			}
			set { this.Entity.ComputedField = value; }
		}

		[DataMember(Name="SomeDate", Order=6, EmitDefaultValue=false)]
		public System.DateTime? SomeDate
		{
			get 
			{ 
				
				if (this.IncludeColumn(ComputedTestMetadata.ColumnNames.SomeDate))
					return this.Entity.SomeDate;
				else
					return null;
			}
			set { this.Entity.SomeDate = value; }
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
		public ComputedTest Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new ComputedTest();
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
		public ComputedTest entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ComputedTestCollection")]
	[XmlType(TypeName="ComputedTestCollectionProxyStub")]	
	[Serializable]
	public partial class ComputedTestCollectionProxyStub 
	{
		protected ComputedTestCollectionProxyStub() {}
		
		public ComputedTestCollectionProxyStub(esEntityCollection<ComputedTest> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ComputedTestCollectionProxyStub(esEntityCollection<ComputedTest> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ComputedTestCollection(ComputedTestCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(ComputedTest);
		}
		
		public ComputedTestCollectionProxyStub(esEntityCollection<ComputedTest> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (ComputedTest entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ComputedTestProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ComputedTestProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (ComputedTest entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ComputedTestProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ComputedTestProxyStub> Collection = new List<ComputedTestProxyStub>();

		public ComputedTestCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ComputedTestCollection();

				foreach (ComputedTestProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ComputedTestCollection _coll;
	}



	[Serializable]
	public partial class ComputedTestMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ComputedTestMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ComputedTestMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ComputedTestMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ComputedTestMetadata.ColumnNames.ConcurrencyCheck, 1, typeof(System.Byte[]), esSystemType.ByteArray);
			c.PropertyName = ComputedTestMetadata.PropertyNames.ConcurrencyCheck;
			c.CharacterMaxLength = 8;
			c.IsComputed = true;
			c.IsConcurrency = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ComputedTestMetadata.ColumnNames.DateLastUpdated, 2, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ComputedTestMetadata.PropertyNames.DateLastUpdated;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			c.Description = "Multi-line Description";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ComputedTestMetadata.ColumnNames.DateAdded, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ComputedTestMetadata.PropertyNames.DateAdded;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			c.Description = "See \"this\"";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ComputedTestMetadata.ColumnNames.ComputedField, 4, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ComputedTestMetadata.PropertyNames.ComputedField;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			c.IsComputed = true;
			c.Alias = "ComputedField";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ComputedTestMetadata.ColumnNames.SomeDate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ComputedTestMetadata.PropertyNames.SomeDate;
			c.Description = "See C:\\this";
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ComputedTestMetadata Meta()
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
			 public const string Id = "ID";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string DateLastUpdated = "DateLastUpdated";
			 public const string DateAdded = "DateAdded";
			 public const string ComputedField = "ComputedTest";
			 public const string SomeDate = "SomeDate";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string DateLastUpdated = "DateLastUpdated";
			 public const string DateAdded = "DateAdded";
			 public const string ComputedField = "ComputedField";
			 public const string SomeDate = "SomeDate";
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
			lock (typeof(ComputedTestMetadata))
			{
				if(ComputedTestMetadata.mapDelegates == null)
				{
					ComputedTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ComputedTestMetadata.meta == null)
				{
					ComputedTestMetadata.meta = new ComputedTestMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte[]"));
				meta.AddTypeMap("DateLastUpdated", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ComputedField", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("SomeDate", new esTypeMap("datetime", "System.DateTime"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "ComputedTest";
				meta.Destination = "ComputedTest";
				
				meta.spInsert = "proc_ComputedTestInsert";				
				meta.spUpdate = "proc_ComputedTestUpdate";		
				meta.spDelete = "proc_ComputedTestDelete";
				meta.spLoadAll = "proc_ComputedTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ComputedTestLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ComputedTestMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
