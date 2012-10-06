
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
	/// Encapsulates the 'ConcurrencyTestChild' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(ConcurrencyTestChild))]	
	[XmlType("ConcurrencyTestChild")]
	[Table(Name="ConcurrencyTestChild")]
	public partial class ConcurrencyTestChild : esConcurrencyTestChild
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new ConcurrencyTestChild();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int64 id)
		{
			var obj = new ConcurrencyTestChild();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int64 id, esSqlAccessType sqlAccessType)
		{
			var obj = new ConcurrencyTestChild();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator ConcurrencyTestChildProxyStub(ConcurrencyTestChild entity)
		{
			return new ConcurrencyTestChildProxyStub(entity);
		}

		#endregion
		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int64? Id
		{
			get { return base.Id;  }
			set { base.Id = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String Name
		{
			get { return base.Name;  }
			set { base.Name = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int64? Parent
		{
			get { return base.Parent;  }
			set { base.Parent = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int64? ConcurrencyCheck
		{
			get { return base.ConcurrencyCheck;  }
			set { base.ConcurrencyCheck = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.DateTime? DefaultTest
		{
			get { return base.DefaultTest;  }
			set { base.DefaultTest = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? ColumnA
		{
			get { return base.ColumnA;  }
			set { base.ColumnA = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? ColumnB
		{
			get { return base.ColumnB;  }
			set { base.ColumnB = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.Int32? ComputedAB
		{
			get { return base.ComputedAB;  }
			set { base.ComputedAB = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("ConcurrencyTestChildCollection")]
	public partial class ConcurrencyTestChildCollection : esConcurrencyTestChildCollection, IEnumerable<ConcurrencyTestChild>
	{
		public ConcurrencyTestChild FindByPrimaryKey(System.Int64 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		#region Implicit Casts
		
		public static implicit operator ConcurrencyTestChildCollectionProxyStub(ConcurrencyTestChildCollection coll)
		{
			return new ConcurrencyTestChildCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(ConcurrencyTestChild))]
		public class ConcurrencyTestChildCollectionWCFPacket : esCollectionWCFPacket<ConcurrencyTestChildCollection>
		{
			public static implicit operator ConcurrencyTestChildCollection(ConcurrencyTestChildCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator ConcurrencyTestChildCollectionWCFPacket(ConcurrencyTestChildCollection collection)
			{
				return new ConcurrencyTestChildCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "ConcurrencyTestChildQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class ConcurrencyTestChildQuery : esConcurrencyTestChildQuery
	{
		public ConcurrencyTestChildQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "ConcurrencyTestChildQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(ConcurrencyTestChildQuery query)
		{
			return ConcurrencyTestChildQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator ConcurrencyTestChildQuery(string query)
		{
			return (ConcurrencyTestChildQuery)ConcurrencyTestChildQuery.SerializeHelper.FromXml(query, typeof(ConcurrencyTestChildQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esConcurrencyTestChild : EntityBase
	{
		public esConcurrencyTestChild()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int64 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int64 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int64 id)
		{
			ConcurrencyTestChildQuery query = new ConcurrencyTestChildQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int64 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? Id
		{
			get
			{
				return base.GetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.Name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(ConcurrencyTestChildMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(ConcurrencyTestChildMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.Parent
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? Parent
		{
			get
			{
				return base.GetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Parent);
			}
			
			set
			{
				if(base.SetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Parent, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Parent);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.ConcurrencyCheck
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int64? ConcurrencyCheck
		{
			get
			{
				return base.GetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck);
			}
			
			set
			{
				if(base.SetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ConcurrencyCheck);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.DefaultTest
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DefaultTest
		{
			get
			{
				return base.GetSystemDateTime(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest);
			}
			
			set
			{
				if(base.SetSystemDateTime(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.DefaultTest);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.ColumnA
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ColumnA
		{
			get
			{
				return base.GetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnA);
			}
			
			set
			{
				if(base.SetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnA, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnA);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.ColumnB
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ColumnB
		{
			get
			{
				return base.GetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnB);
			}
			
			set
			{
				if(base.SetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnB, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnB);
				}
			}
		}		
		
		/// <summary>
		/// Maps to ConcurrencyTestChild.ComputedAB
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ComputedAB
		{
			get
			{
				return base.GetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB);
			}
			
			set
			{
				if(base.SetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB, value))
				{
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ComputedAB);
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
						case "Name": this.str().Name = (string)value; break;							
						case "Parent": this.str().Parent = (string)value; break;							
						case "ConcurrencyCheck": this.str().ConcurrencyCheck = (string)value; break;							
						case "DefaultTest": this.str().DefaultTest = (string)value; break;							
						case "ColumnA": this.str().ColumnA = (string)value; break;							
						case "ColumnB": this.str().ColumnB = (string)value; break;							
						case "ComputedAB": this.str().ComputedAB = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int64)
								this.Id = (System.Int64?)value;
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Id);
							break;
						
						case "Parent":
						
							if (value == null || value is System.Int64)
								this.Parent = (System.Int64?)value;
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Parent);
							break;
						
						case "ConcurrencyCheck":
						
							if (value == null || value is System.Int64)
								this.ConcurrencyCheck = (System.Int64?)value;
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ConcurrencyCheck);
							break;
						
						case "DefaultTest":
						
							if (value == null || value is System.DateTime)
								this.DefaultTest = (System.DateTime?)value;
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.DefaultTest);
							break;
						
						case "ColumnA":
						
							if (value == null || value is System.Int32)
								this.ColumnA = (System.Int32?)value;
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnA);
							break;
						
						case "ColumnB":
						
							if (value == null || value is System.Int32)
								this.ColumnB = (System.Int32?)value;
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnB);
							break;
						
						case "ComputedAB":
						
							if (value == null || value is System.Int32)
								this.ComputedAB = (System.Int32?)value;
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ComputedAB);
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
			public esStrings(esConcurrencyTestChild entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int64? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt64(value);
				}
			}
				
			public System.String Name
			{
				get
				{
					System.String data = entity.Name;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Name = null;
					else entity.Name = Convert.ToString(value);
				}
			}
				
			public System.String Parent
			{
				get
				{
					System.Int64? data = entity.Parent;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Parent = null;
					else entity.Parent = Convert.ToInt64(value);
				}
			}
				
			public System.String ConcurrencyCheck
			{
				get
				{
					System.Int64? data = entity.ConcurrencyCheck;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ConcurrencyCheck = null;
					else entity.ConcurrencyCheck = Convert.ToInt64(value);
				}
			}
				
			public System.String DefaultTest
			{
				get
				{
					System.DateTime? data = entity.DefaultTest;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DefaultTest = null;
					else entity.DefaultTest = Convert.ToDateTime(value);
				}
			}
				
			public System.String ColumnA
			{
				get
				{
					System.Int32? data = entity.ColumnA;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ColumnA = null;
					else entity.ColumnA = Convert.ToInt32(value);
				}
			}
				
			public System.String ColumnB
			{
				get
				{
					System.Int32? data = entity.ColumnB;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ColumnB = null;
					else entity.ColumnB = Convert.ToInt32(value);
				}
			}
				
			public System.String ComputedAB
			{
				get
				{
					System.Int32? data = entity.ComputedAB;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ComputedAB = null;
					else entity.ComputedAB = Convert.ToInt32(value);
				}
			}
			

			private esConcurrencyTestChild entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return ConcurrencyTestChildMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public ConcurrencyTestChildQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ConcurrencyTestChildQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ConcurrencyTestChildQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(ConcurrencyTestChildQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private ConcurrencyTestChildQuery query;		
	}



	[Serializable]
	abstract public partial class esConcurrencyTestChildCollection : CollectionBase<ConcurrencyTestChild>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ConcurrencyTestChildMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "ConcurrencyTestChildCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public ConcurrencyTestChildQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ConcurrencyTestChildQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(ConcurrencyTestChildQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ConcurrencyTestChildQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(ConcurrencyTestChildQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((ConcurrencyTestChildQuery)query);
		}

		#endregion
		
		private ConcurrencyTestChildQuery query;
	}



	[Serializable]
	abstract public partial class esConcurrencyTestChildQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return ConcurrencyTestChildMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "Name": return this.Name;
				case "Parent": return this.Parent;
				case "ConcurrencyCheck": return this.ConcurrencyCheck;
				case "DefaultTest": return this.DefaultTest;
				case "ColumnA": return this.ColumnA;
				case "ColumnB": return this.ColumnB;
				case "ComputedAB": return this.ComputedAB;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.Id, esSystemType.Int64); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Parent
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.Parent, esSystemType.Int64); }
		} 
		
		public esQueryItem ConcurrencyCheck
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int64); }
		} 
		
		public esQueryItem DefaultTest
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.DefaultTest, esSystemType.DateTime); }
		} 
		
		public esQueryItem ColumnA
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.ColumnA, esSystemType.Int32); }
		} 
		
		public esQueryItem ColumnB
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.ColumnB, esSystemType.Int32); }
		} 
		
		public esQueryItem ComputedAB
		{
			get { return new esQueryItem(this, ConcurrencyTestChildMetadata.ColumnNames.ComputedAB, esSystemType.Int32); }
		} 
		
		#endregion
		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTestChild")]
	[XmlType(TypeName="ConcurrencyTestChildProxyStub")]	
	[Serializable]
	public partial class ConcurrencyTestChildProxyStub
	{
		public ConcurrencyTestChildProxyStub() 
		{
			theEntity = this.entity = new ConcurrencyTestChild();
		}

		public ConcurrencyTestChildProxyStub(ConcurrencyTestChild obj)
		{
			theEntity = this.entity = obj;
		}

		public ConcurrencyTestChildProxyStub(ConcurrencyTestChild obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator ConcurrencyTestChild(ConcurrencyTestChildProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(ConcurrencyTestChild);
		}

		[DataMember(Name="Id", Order=1, EmitDefaultValue=false)]
		public System.Int64? Id
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int64?)this.Entity.
						GetOriginalColumnValue(ConcurrencyTestChildMetadata.ColumnNames.Id);
				else
					return this.Entity.Id;
			}
			set { this.Entity.Id = value; }
		}

		[DataMember(Name="Name", Order=2, EmitDefaultValue=false)]
		public System.String Name
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.Name))
					return this.Entity.Name;
				else
					return null;
			}
			set { this.Entity.Name = value; }
		}

		[DataMember(Name="Parent", Order=3, EmitDefaultValue=false)]
		public System.Int64? Parent
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.Parent))
					return this.Entity.Parent;
				else
					return null;
			}
			set { this.Entity.Parent = value; }
		}

		[DataMember(Name="ConcurrencyCheck", Order=4, EmitDefaultValue=false)]
		public System.Int64? ConcurrencyCheck
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck))
					return this.Entity.ConcurrencyCheck;
				else
					return null;
			}
			set { this.Entity.ConcurrencyCheck = value; }
		}

		[DataMember(Name="DefaultTest", Order=5, EmitDefaultValue=false)]
		public System.DateTime? DefaultTest
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest))
					return this.Entity.DefaultTest;
				else
					return null;
			}
			set { this.Entity.DefaultTest = value; }
		}

		[DataMember(Name="ColumnA", Order=6, EmitDefaultValue=false)]
		public System.Int32? ColumnA
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ColumnA))
					return this.Entity.ColumnA;
				else
					return null;
			}
			set { this.Entity.ColumnA = value; }
		}

		[DataMember(Name="ColumnB", Order=7, EmitDefaultValue=false)]
		public System.Int32? ColumnB
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ColumnB))
					return this.Entity.ColumnB;
				else
					return null;
			}
			set { this.Entity.ColumnB = value; }
		}

		[DataMember(Name="ComputedAB", Order=8, EmitDefaultValue=false)]
		public System.Int32? ComputedAB
		{
			get 
			{ 
				
				if (this.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB))
					return this.Entity.ComputedAB;
				else
					return null;
			}
			set { this.Entity.ComputedAB = value; }
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
		public ConcurrencyTestChild Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new ConcurrencyTestChild();
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
		public ConcurrencyTestChild entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "ConcurrencyTestChildCollection")]
	[XmlType(TypeName="ConcurrencyTestChildCollectionProxyStub")]	
	[Serializable]
	public partial class ConcurrencyTestChildCollectionProxyStub 
	{
		protected ConcurrencyTestChildCollectionProxyStub() {}
		
		public ConcurrencyTestChildCollectionProxyStub(esEntityCollection<ConcurrencyTestChild> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public ConcurrencyTestChildCollectionProxyStub(esEntityCollection<ConcurrencyTestChild> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator ConcurrencyTestChildCollection(ConcurrencyTestChildCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(ConcurrencyTestChild);
		}
		
		public ConcurrencyTestChildCollectionProxyStub(esEntityCollection<ConcurrencyTestChild> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (ConcurrencyTestChild entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new ConcurrencyTestChildProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new ConcurrencyTestChildProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (ConcurrencyTestChild entity in coll.es.DeletedEntities)
				{
					Collection.Add(new ConcurrencyTestChildProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<ConcurrencyTestChildProxyStub> Collection = new List<ConcurrencyTestChildProxyStub>();

		public ConcurrencyTestChildCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new ConcurrencyTestChildCollection();

				foreach (ConcurrencyTestChildProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private ConcurrencyTestChildCollection _coll;
	}



	[Serializable]
	public partial class ConcurrencyTestChildMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ConcurrencyTestChildMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.Id, 0, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 19;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.Name, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.Parent, 2, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.Parent;
			c.NumericPrecision = 19;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck, 3, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ConcurrencyCheck;
			c.NumericPrecision = 19;
			c.IsEntitySpacesConcurrency = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.DefaultTest;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ColumnA, 5, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ColumnA;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ColumnB, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ColumnB;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB, 7, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ComputedAB;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			c.IsComputed = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public ConcurrencyTestChildMetadata Meta()
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
			 public const string Id = "Id";
			 public const string Name = "Name";
			 public const string Parent = "Parent";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string DefaultTest = "DefaultTest";
			 public const string ColumnA = "ColumnA";
			 public const string ColumnB = "ColumnB";
			 public const string ComputedAB = "ComputedAB";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Name = "Name";
			 public const string Parent = "Parent";
			 public const string ConcurrencyCheck = "ConcurrencyCheck";
			 public const string DefaultTest = "DefaultTest";
			 public const string ColumnA = "ColumnA";
			 public const string ColumnB = "ColumnB";
			 public const string ComputedAB = "ComputedAB";
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
			lock (typeof(ConcurrencyTestChildMetadata))
			{
				if(ConcurrencyTestChildMetadata.mapDelegates == null)
				{
					ConcurrencyTestChildMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ConcurrencyTestChildMetadata.meta == null)
				{
					ConcurrencyTestChildMetadata.meta = new ConcurrencyTestChildMetadata();
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


				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Parent", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("DefaultTest", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ColumnA", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ColumnB", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ComputedAB", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "ConcurrencyTestChild";
				meta.Destination = "ConcurrencyTestChild";
				
				meta.spInsert = "proc_ConcurrencyTestChildInsert";				
				meta.spUpdate = "proc_ConcurrencyTestChildUpdate";		
				meta.spDelete = "proc_ConcurrencyTestChildDelete";
				meta.spLoadAll = "proc_ConcurrencyTestChildLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestChildLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ConcurrencyTestChildMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
