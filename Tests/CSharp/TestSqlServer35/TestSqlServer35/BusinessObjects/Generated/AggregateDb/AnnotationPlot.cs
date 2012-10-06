
/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0627.0
EntitySpaces Driver  : SQL
Date Generated       : 7/17/2011 9:16:19 PM
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
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'AnnotationPlot' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("AnnotationPlot")]
	public partial class AnnotationPlot : esAnnotationPlot
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new AnnotationPlot();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new AnnotationPlot();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new AnnotationPlot();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("AnnotationPlotCollection")]
	public partial class AnnotationPlotCollection : esAnnotationPlotCollection, IEnumerable<AnnotationPlot>
	{
		public AnnotationPlot FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(AnnotationPlot))]
		public class AnnotationPlotCollectionWCFPacket : esCollectionWCFPacket<AnnotationPlotCollection>
		{
			public static implicit operator AnnotationPlotCollection(AnnotationPlotCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AnnotationPlotCollectionWCFPacket(AnnotationPlotCollection collection)
			{
				return new AnnotationPlotCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AnnotationPlotQuery : esAnnotationPlotQuery
	{
		public AnnotationPlotQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AnnotationPlotQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AnnotationPlotQuery query)
		{
			return AnnotationPlotQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AnnotationPlotQuery(string query)
		{
			return (AnnotationPlotQuery)AnnotationPlotQuery.SerializeHelper.FromXml(query, typeof(AnnotationPlotQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAnnotationPlot : esEntity
	{
		public esAnnotationPlot()
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
			AnnotationPlotQuery query = new AnnotationPlotQuery();
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
		/// Maps to AnnotationPlot.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlot.AnnotationId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? AnnotationId
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotMetadata.ColumnNames.AnnotationId);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotMetadata.ColumnNames.AnnotationId, value))
				{
					this._UpToAnnotationByAnnotationId = null;
					this.OnPropertyChanged("UpToAnnotationByAnnotationId");
					OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.AnnotationId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlot.RegionId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? RegionId
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotMetadata.ColumnNames.RegionId);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotMetadata.ColumnNames.RegionId, value))
				{
					OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.RegionId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlot.Description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(AnnotationPlotMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(AnnotationPlotMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlot.Title
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Title
		{
			get
			{
				return base.GetSystemString(AnnotationPlotMetadata.ColumnNames.Title);
			}
			
			set
			{
				if(base.SetSystemString(AnnotationPlotMetadata.ColumnNames.Title, value))
				{
					OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.Title);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlot.Type
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Type
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotMetadata.ColumnNames.Type);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotMetadata.ColumnNames.Type, value))
				{
					OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.Type);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlot.DimensionCount
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte? DimensionCount
		{
			get
			{
				return base.GetSystemByte(AnnotationPlotMetadata.ColumnNames.DimensionCount);
			}
			
			set
			{
				if(base.SetSystemByte(AnnotationPlotMetadata.ColumnNames.DimensionCount, value))
				{
					OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.DimensionCount);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Annotation _UpToAnnotationByAnnotationId;
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
						case "AnnotationId": this.str().AnnotationId = (string)value; break;							
						case "RegionId": this.str().RegionId = (string)value; break;							
						case "Description": this.str().Description = (string)value; break;							
						case "Title": this.str().Title = (string)value; break;							
						case "Type": this.str().Type = (string)value; break;							
						case "DimensionCount": this.str().DimensionCount = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.Id);
							break;
						
						case "AnnotationId":
						
							if (value == null || value is System.Int32)
								this.AnnotationId = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.AnnotationId);
							break;
						
						case "RegionId":
						
							if (value == null || value is System.Int32)
								this.RegionId = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.RegionId);
							break;
						
						case "Type":
						
							if (value == null || value is System.Int32)
								this.Type = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.Type);
							break;
						
						case "DimensionCount":
						
							if (value == null || value is System.Byte)
								this.DimensionCount = (System.Byte?)value;
								OnPropertyChanged(AnnotationPlotMetadata.PropertyNames.DimensionCount);
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
			public esStrings(esAnnotationPlot entity)
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
				
			public System.String AnnotationId
			{
				get
				{
					System.Int32? data = entity.AnnotationId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AnnotationId = null;
					else entity.AnnotationId = Convert.ToInt32(value);
				}
			}
				
			public System.String RegionId
			{
				get
				{
					System.Int32? data = entity.RegionId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.RegionId = null;
					else entity.RegionId = Convert.ToInt32(value);
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
				
			public System.String Title
			{
				get
				{
					System.String data = entity.Title;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Title = null;
					else entity.Title = Convert.ToString(value);
				}
			}
				
			public System.String Type
			{
				get
				{
					System.Int32? data = entity.Type;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Type = null;
					else entity.Type = Convert.ToInt32(value);
				}
			}
				
			public System.String DimensionCount
			{
				get
				{
					System.Byte? data = entity.DimensionCount;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DimensionCount = null;
					else entity.DimensionCount = Convert.ToByte(value);
				}
			}
			

			private esAnnotationPlot entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AnnotationPlotQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AnnotationPlotQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AnnotationPlotQuery query;		
	}



	[Serializable]
	abstract public partial class esAnnotationPlotCollection : esEntityCollection<AnnotationPlot>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AnnotationPlotCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AnnotationPlotQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AnnotationPlotQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AnnotationPlotQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AnnotationPlotQuery)query);
		}

		#endregion
		
		private AnnotationPlotQuery query;
	}



	[Serializable]
	abstract public partial class esAnnotationPlotQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, AnnotationPlotMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem AnnotationId
		{
			get { return new esQueryItem(this, AnnotationPlotMetadata.ColumnNames.AnnotationId, esSystemType.Int32); }
		} 
		
		public esQueryItem RegionId
		{
			get { return new esQueryItem(this, AnnotationPlotMetadata.ColumnNames.RegionId, esSystemType.Int32); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, AnnotationPlotMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Title
		{
			get { return new esQueryItem(this, AnnotationPlotMetadata.ColumnNames.Title, esSystemType.String); }
		} 
		
		public esQueryItem Type
		{
			get { return new esQueryItem(this, AnnotationPlotMetadata.ColumnNames.Type, esSystemType.Int32); }
		} 
		
		public esQueryItem DimensionCount
		{
			get { return new esQueryItem(this, AnnotationPlotMetadata.ColumnNames.DimensionCount, esSystemType.Byte); }
		} 
		
		#endregion
		
	}


	
	public partial class AnnotationPlot : esAnnotationPlot
	{

		#region AnnotationPlotAxisCollectionByPlotId - Zero To Many
		
		static public esPrefetchMap Prefetch_AnnotationPlotAxisCollectionByPlotId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.AnnotationPlot.AnnotationPlotAxisCollectionByPlotId_Delegate;
				map.PropertyName = "AnnotationPlotAxisCollectionByPlotId";
				map.MyColumnName = "PlotId";
				map.ParentColumnName = "Id";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AnnotationPlotAxisCollectionByPlotId_Delegate(esPrefetchParameters data)
		{
			AnnotationPlotQuery parent = new AnnotationPlotQuery(data.NextAlias());

			AnnotationPlotAxisQuery me = data.You != null ? data.You as AnnotationPlotAxisQuery : new AnnotationPlotAxisQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Id == me.PlotId);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_AnnotationPlotAxis_AnnotationPlot
		/// </summary>

		[XmlIgnore]
		public AnnotationPlotAxisCollection AnnotationPlotAxisCollectionByPlotId
		{
			get
			{
				if(this._AnnotationPlotAxisCollectionByPlotId == null)
				{
					this._AnnotationPlotAxisCollectionByPlotId = new AnnotationPlotAxisCollection();
					this._AnnotationPlotAxisCollectionByPlotId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AnnotationPlotAxisCollectionByPlotId", this._AnnotationPlotAxisCollectionByPlotId);
				
					if (this.Id != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AnnotationPlotAxisCollectionByPlotId.Query.Where(this._AnnotationPlotAxisCollectionByPlotId.Query.PlotId == this.Id);
							this._AnnotationPlotAxisCollectionByPlotId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AnnotationPlotAxisCollectionByPlotId.fks.Add(AnnotationPlotAxisMetadata.ColumnNames.PlotId, this.Id);
					}
				}

				return this._AnnotationPlotAxisCollectionByPlotId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AnnotationPlotAxisCollectionByPlotId != null) 
				{ 
					this.RemovePostSave("AnnotationPlotAxisCollectionByPlotId"); 
					this._AnnotationPlotAxisCollectionByPlotId = null;
					
				} 
			} 			
		}
			
		
		private AnnotationPlotAxisCollection _AnnotationPlotAxisCollectionByPlotId;
		#endregion

		#region AnnotationPlotSeriesCollectionByPlotId - Zero To Many
		
		static public esPrefetchMap Prefetch_AnnotationPlotSeriesCollectionByPlotId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.AnnotationPlot.AnnotationPlotSeriesCollectionByPlotId_Delegate;
				map.PropertyName = "AnnotationPlotSeriesCollectionByPlotId";
				map.MyColumnName = "PlotId";
				map.ParentColumnName = "Id";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AnnotationPlotSeriesCollectionByPlotId_Delegate(esPrefetchParameters data)
		{
			AnnotationPlotQuery parent = new AnnotationPlotQuery(data.NextAlias());

			AnnotationPlotSeriesQuery me = data.You != null ? data.You as AnnotationPlotSeriesQuery : new AnnotationPlotSeriesQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Id == me.PlotId);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_AnnotationPlotSeries_AnnotationPlot
		/// </summary>

		[XmlIgnore]
		public AnnotationPlotSeriesCollection AnnotationPlotSeriesCollectionByPlotId
		{
			get
			{
				if(this._AnnotationPlotSeriesCollectionByPlotId == null)
				{
					this._AnnotationPlotSeriesCollectionByPlotId = new AnnotationPlotSeriesCollection();
					this._AnnotationPlotSeriesCollectionByPlotId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AnnotationPlotSeriesCollectionByPlotId", this._AnnotationPlotSeriesCollectionByPlotId);
				
					if (this.Id != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AnnotationPlotSeriesCollectionByPlotId.Query.Where(this._AnnotationPlotSeriesCollectionByPlotId.Query.PlotId == this.Id);
							this._AnnotationPlotSeriesCollectionByPlotId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AnnotationPlotSeriesCollectionByPlotId.fks.Add(AnnotationPlotSeriesMetadata.ColumnNames.PlotId, this.Id);
					}
				}

				return this._AnnotationPlotSeriesCollectionByPlotId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AnnotationPlotSeriesCollectionByPlotId != null) 
				{ 
					this.RemovePostSave("AnnotationPlotSeriesCollectionByPlotId"); 
					this._AnnotationPlotSeriesCollectionByPlotId = null;
					
				} 
			} 			
		}
			
		
		private AnnotationPlotSeriesCollection _AnnotationPlotSeriesCollectionByPlotId;
		#endregion

				
		#region UpToAnnotationByAnnotationId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_AnnotationPlot_Annotation
		/// </summary>

		[XmlIgnore]
					
		public Annotation UpToAnnotationByAnnotationId
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToAnnotationByAnnotationId == null && AnnotationId != null)
				{
					this._UpToAnnotationByAnnotationId = new Annotation();
					this._UpToAnnotationByAnnotationId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToAnnotationByAnnotationId", this._UpToAnnotationByAnnotationId);
					this._UpToAnnotationByAnnotationId.Query.Where(this._UpToAnnotationByAnnotationId.Query.AnnotationId == this.AnnotationId);
					this._UpToAnnotationByAnnotationId.Query.Load();
				}	
				return this._UpToAnnotationByAnnotationId;
			}
			
			set
			{
				this.RemovePreSave("UpToAnnotationByAnnotationId");
				

				if(value == null)
				{
					this.AnnotationId = null;
					this._UpToAnnotationByAnnotationId = null;
				}
				else
				{
					this.AnnotationId = value.AnnotationId;
					this._UpToAnnotationByAnnotationId = value;
					this.SetPreSave("UpToAnnotationByAnnotationId", this._UpToAnnotationByAnnotationId);
				}
				
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "AnnotationPlotAxisCollectionByPlotId":
					coll = this.AnnotationPlotAxisCollectionByPlotId;
					break;
				case "AnnotationPlotSeriesCollectionByPlotId":
					coll = this.AnnotationPlotSeriesCollectionByPlotId;
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
			
			props.Add(new esPropertyDescriptor(this, "AnnotationPlotAxisCollectionByPlotId", typeof(AnnotationPlotAxisCollection), new AnnotationPlotAxis()));
			props.Add(new esPropertyDescriptor(this, "AnnotationPlotSeriesCollectionByPlotId", typeof(AnnotationPlotSeriesCollection), new AnnotationPlotSeries()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToAnnotationByAnnotationId != null)
			{
				this.AnnotationId = this._UpToAnnotationByAnnotationId.AnnotationId;
			}
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetColumn(key, value, false);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._AnnotationPlotAxisCollectionByPlotId != null)
			{
				Apply(this._AnnotationPlotAxisCollectionByPlotId, "PlotId", this.Id);
			}
			if(this._AnnotationPlotSeriesCollectionByPlotId != null)
			{
				Apply(this._AnnotationPlotSeriesCollectionByPlotId, "PlotId", this.Id);
			}
		}
		
	}
	



	[Serializable]
	public partial class AnnotationPlotMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AnnotationPlotMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AnnotationPlotMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotMetadata.ColumnNames.AnnotationId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotMetadata.PropertyNames.AnnotationId;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotMetadata.ColumnNames.RegionId, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotMetadata.PropertyNames.RegionId;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotMetadata.ColumnNames.Description, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = AnnotationPlotMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 128;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotMetadata.ColumnNames.Title, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = AnnotationPlotMetadata.PropertyNames.Title;
			c.CharacterMaxLength = 128;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotMetadata.ColumnNames.Type, 5, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotMetadata.PropertyNames.Type;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotMetadata.ColumnNames.DimensionCount, 6, typeof(System.Byte), esSystemType.Byte);
			c.PropertyName = AnnotationPlotMetadata.PropertyNames.DimensionCount;
			c.NumericPrecision = 3;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AnnotationPlotMetadata Meta()
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
			 public const string AnnotationId = "AnnotationId";
			 public const string RegionId = "RegionId";
			 public const string Description = "Description";
			 public const string Title = "Title";
			 public const string Type = "Type";
			 public const string DimensionCount = "DimensionCount";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string AnnotationId = "AnnotationId";
			 public const string RegionId = "RegionId";
			 public const string Description = "Description";
			 public const string Title = "Title";
			 public const string Type = "Type";
			 public const string DimensionCount = "DimensionCount";
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
			lock (typeof(AnnotationPlotMetadata))
			{
				if(AnnotationPlotMetadata.mapDelegates == null)
				{
					AnnotationPlotMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AnnotationPlotMetadata.meta == null)
				{
					AnnotationPlotMetadata.meta = new AnnotationPlotMetadata();
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
				meta.AddTypeMap("AnnotationId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("RegionId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Title", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Type", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DimensionCount", new esTypeMap("tinyint", "System.Byte"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "AnnotationPlot";
				meta.Destination = "AnnotationPlot";
				
				meta.spInsert = "proc_AnnotationPlotInsert";				
				meta.spUpdate = "proc_AnnotationPlotUpdate";		
				meta.spDelete = "proc_AnnotationPlotDelete";
				meta.spLoadAll = "proc_AnnotationPlotLoadAll";
				meta.spLoadByPrimaryKey = "proc_AnnotationPlotLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AnnotationPlotMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
