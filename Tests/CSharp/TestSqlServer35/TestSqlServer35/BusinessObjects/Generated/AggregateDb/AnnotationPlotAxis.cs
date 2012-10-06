
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
	/// Encapsulates the 'AnnotationPlotAxis' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[XmlType("AnnotationPlotAxis")]
	public partial class AnnotationPlotAxis : esAnnotationPlotAxis
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new AnnotationPlotAxis();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 id)
		{
			var obj = new AnnotationPlotAxis();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 id, esSqlAccessType sqlAccessType)
		{
			var obj = new AnnotationPlotAxis();
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
	[XmlType("AnnotationPlotAxisCollection")]
	public partial class AnnotationPlotAxisCollection : esAnnotationPlotAxisCollection, IEnumerable<AnnotationPlotAxis>
	{
		public AnnotationPlotAxis FindByPrimaryKey(System.Int32 id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(AnnotationPlotAxis))]
		public class AnnotationPlotAxisCollectionWCFPacket : esCollectionWCFPacket<AnnotationPlotAxisCollection>
		{
			public static implicit operator AnnotationPlotAxisCollection(AnnotationPlotAxisCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator AnnotationPlotAxisCollectionWCFPacket(AnnotationPlotAxisCollection collection)
			{
				return new AnnotationPlotAxisCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]	
	public partial class AnnotationPlotAxisQuery : esAnnotationPlotAxisQuery
	{
		public AnnotationPlotAxisQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "AnnotationPlotAxisQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(AnnotationPlotAxisQuery query)
		{
			return AnnotationPlotAxisQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator AnnotationPlotAxisQuery(string query)
		{
			return (AnnotationPlotAxisQuery)AnnotationPlotAxisQuery.SerializeHelper.FromXml(query, typeof(AnnotationPlotAxisQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esAnnotationPlotAxis : esEntity
	{
		public esAnnotationPlotAxis()
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
			AnnotationPlotAxisQuery query = new AnnotationPlotAxisQuery();
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
		/// Maps to AnnotationPlotAxis.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxis.PlotId
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? PlotId
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.PlotId);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.PlotId, value))
				{
					this._UpToAnnotationPlotByPlotId = null;
					this.OnPropertyChanged("UpToAnnotationPlotByPlotId");
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.PlotId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxis.Label
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Label
		{
			get
			{
				return base.GetSystemString(AnnotationPlotAxisMetadata.ColumnNames.Label);
			}
			
			set
			{
				if(base.SetSystemString(AnnotationPlotAxisMetadata.ColumnNames.Label, value))
				{
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Label);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxis.MinValue
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? MinValue
		{
			get
			{
				return base.GetSystemDouble(AnnotationPlotAxisMetadata.ColumnNames.MinValue);
			}
			
			set
			{
				if(base.SetSystemDouble(AnnotationPlotAxisMetadata.ColumnNames.MinValue, value))
				{
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.MinValue);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxis.MaxValue
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Double? MaxValue
		{
			get
			{
				return base.GetSystemDouble(AnnotationPlotAxisMetadata.ColumnNames.MaxValue);
			}
			
			set
			{
				if(base.SetSystemDouble(AnnotationPlotAxisMetadata.ColumnNames.MaxValue, value))
				{
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.MaxValue);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxis.Scale
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Scale
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.Scale);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.Scale, value))
				{
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Scale);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxis.Type
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Type
		{
			get
			{
				return base.GetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.Type);
			}
			
			set
			{
				if(base.SetSystemInt32(AnnotationPlotAxisMetadata.ColumnNames.Type, value))
				{
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Type);
				}
			}
		}		
		
		/// <summary>
		/// Maps to AnnotationPlotAxis.Dimension
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Byte? Dimension
		{
			get
			{
				return base.GetSystemByte(AnnotationPlotAxisMetadata.ColumnNames.Dimension);
			}
			
			set
			{
				if(base.SetSystemByte(AnnotationPlotAxisMetadata.ColumnNames.Dimension, value))
				{
					OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Dimension);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected AnnotationPlot _UpToAnnotationPlotByPlotId;
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
						case "PlotId": this.str().PlotId = (string)value; break;							
						case "Label": this.str().Label = (string)value; break;							
						case "MinValue": this.str().MinValue = (string)value; break;							
						case "MaxValue": this.str().MaxValue = (string)value; break;							
						case "Scale": this.str().Scale = (string)value; break;							
						case "Type": this.str().Type = (string)value; break;							
						case "Dimension": this.str().Dimension = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Id);
							break;
						
						case "PlotId":
						
							if (value == null || value is System.Int32)
								this.PlotId = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.PlotId);
							break;
						
						case "MinValue":
						
							if (value == null || value is System.Double)
								this.MinValue = (System.Double?)value;
								OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.MinValue);
							break;
						
						case "MaxValue":
						
							if (value == null || value is System.Double)
								this.MaxValue = (System.Double?)value;
								OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.MaxValue);
							break;
						
						case "Scale":
						
							if (value == null || value is System.Int32)
								this.Scale = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Scale);
							break;
						
						case "Type":
						
							if (value == null || value is System.Int32)
								this.Type = (System.Int32?)value;
								OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Type);
							break;
						
						case "Dimension":
						
							if (value == null || value is System.Byte)
								this.Dimension = (System.Byte?)value;
								OnPropertyChanged(AnnotationPlotAxisMetadata.PropertyNames.Dimension);
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
			public esStrings(esAnnotationPlotAxis entity)
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
				
			public System.String PlotId
			{
				get
				{
					System.Int32? data = entity.PlotId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.PlotId = null;
					else entity.PlotId = Convert.ToInt32(value);
				}
			}
				
			public System.String Label
			{
				get
				{
					System.String data = entity.Label;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Label = null;
					else entity.Label = Convert.ToString(value);
				}
			}
				
			public System.String MinValue
			{
				get
				{
					System.Double? data = entity.MinValue;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MinValue = null;
					else entity.MinValue = Convert.ToDouble(value);
				}
			}
				
			public System.String MaxValue
			{
				get
				{
					System.Double? data = entity.MaxValue;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.MaxValue = null;
					else entity.MaxValue = Convert.ToDouble(value);
				}
			}
				
			public System.String Scale
			{
				get
				{
					System.Int32? data = entity.Scale;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Scale = null;
					else entity.Scale = Convert.ToInt32(value);
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
				
			public System.String Dimension
			{
				get
				{
					System.Byte? data = entity.Dimension;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Dimension = null;
					else entity.Dimension = Convert.ToByte(value);
				}
			}
			

			private esAnnotationPlotAxis entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotAxisMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public AnnotationPlotAxisQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotAxisQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotAxisQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(AnnotationPlotAxisQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private AnnotationPlotAxisQuery query;		
	}



	[Serializable]
	abstract public partial class esAnnotationPlotAxisCollection : esEntityCollection<AnnotationPlotAxis>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotAxisMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "AnnotationPlotAxisCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public AnnotationPlotAxisQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new AnnotationPlotAxisQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(AnnotationPlotAxisQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new AnnotationPlotAxisQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(AnnotationPlotAxisQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((AnnotationPlotAxisQuery)query);
		}

		#endregion
		
		private AnnotationPlotAxisQuery query;
	}



	[Serializable]
	abstract public partial class esAnnotationPlotAxisQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return AnnotationPlotAxisMetadata.Meta();
			}
		}	
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.Id, esSystemType.Int32); }
		} 
		
		public esQueryItem PlotId
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.PlotId, esSystemType.Int32); }
		} 
		
		public esQueryItem Label
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.Label, esSystemType.String); }
		} 
		
		public esQueryItem MinValue
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.MinValue, esSystemType.Double); }
		} 
		
		public esQueryItem MaxValue
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.MaxValue, esSystemType.Double); }
		} 
		
		public esQueryItem Scale
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.Scale, esSystemType.Int32); }
		} 
		
		public esQueryItem Type
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.Type, esSystemType.Int32); }
		} 
		
		public esQueryItem Dimension
		{
			get { return new esQueryItem(this, AnnotationPlotAxisMetadata.ColumnNames.Dimension, esSystemType.Byte); }
		} 
		
		#endregion
		
	}


	
	public partial class AnnotationPlotAxis : esAnnotationPlotAxis
	{

		#region AnnotationPlotAxisDataCollectionByAxisId - Zero To Many
		
		static public esPrefetchMap Prefetch_AnnotationPlotAxisDataCollectionByAxisId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.AnnotationPlotAxis.AnnotationPlotAxisDataCollectionByAxisId_Delegate;
				map.PropertyName = "AnnotationPlotAxisDataCollectionByAxisId";
				map.MyColumnName = "AxisId";
				map.ParentColumnName = "Id";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void AnnotationPlotAxisDataCollectionByAxisId_Delegate(esPrefetchParameters data)
		{
			AnnotationPlotAxisQuery parent = new AnnotationPlotAxisQuery(data.NextAlias());

			AnnotationPlotAxisDataQuery me = data.You != null ? data.You as AnnotationPlotAxisDataQuery : new AnnotationPlotAxisDataQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Id == me.AxisId);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_AnnotationPlotAxisData_AnnotationPlotAxis
		/// </summary>

		[XmlIgnore]
		public AnnotationPlotAxisDataCollection AnnotationPlotAxisDataCollectionByAxisId
		{
			get
			{
				if(this._AnnotationPlotAxisDataCollectionByAxisId == null)
				{
					this._AnnotationPlotAxisDataCollectionByAxisId = new AnnotationPlotAxisDataCollection();
					this._AnnotationPlotAxisDataCollectionByAxisId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("AnnotationPlotAxisDataCollectionByAxisId", this._AnnotationPlotAxisDataCollectionByAxisId);
				
					if (this.Id != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._AnnotationPlotAxisDataCollectionByAxisId.Query.Where(this._AnnotationPlotAxisDataCollectionByAxisId.Query.AxisId == this.Id);
							this._AnnotationPlotAxisDataCollectionByAxisId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._AnnotationPlotAxisDataCollectionByAxisId.fks.Add(AnnotationPlotAxisDataMetadata.ColumnNames.AxisId, this.Id);
					}
				}

				return this._AnnotationPlotAxisDataCollectionByAxisId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._AnnotationPlotAxisDataCollectionByAxisId != null) 
				{ 
					this.RemovePostSave("AnnotationPlotAxisDataCollectionByAxisId"); 
					this._AnnotationPlotAxisDataCollectionByAxisId = null;
					
				} 
			} 			
		}
			
		
		private AnnotationPlotAxisDataCollection _AnnotationPlotAxisDataCollectionByAxisId;
		#endregion

				
		#region UpToAnnotationPlotByPlotId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_AnnotationPlotAxis_AnnotationPlot
		/// </summary>

		[XmlIgnore]
					
		public AnnotationPlot UpToAnnotationPlotByPlotId
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToAnnotationPlotByPlotId == null && PlotId != null)
				{
					this._UpToAnnotationPlotByPlotId = new AnnotationPlot();
					this._UpToAnnotationPlotByPlotId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToAnnotationPlotByPlotId", this._UpToAnnotationPlotByPlotId);
					this._UpToAnnotationPlotByPlotId.Query.Where(this._UpToAnnotationPlotByPlotId.Query.Id == this.PlotId);
					this._UpToAnnotationPlotByPlotId.Query.Load();
				}	
				return this._UpToAnnotationPlotByPlotId;
			}
			
			set
			{
				this.RemovePreSave("UpToAnnotationPlotByPlotId");
				

				if(value == null)
				{
					this.PlotId = null;
					this._UpToAnnotationPlotByPlotId = null;
				}
				else
				{
					this.PlotId = value.Id;
					this._UpToAnnotationPlotByPlotId = value;
					this.SetPreSave("UpToAnnotationPlotByPlotId", this._UpToAnnotationPlotByPlotId);
				}
				
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "AnnotationPlotAxisDataCollectionByAxisId":
					coll = this.AnnotationPlotAxisDataCollectionByAxisId;
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
			
			props.Add(new esPropertyDescriptor(this, "AnnotationPlotAxisDataCollectionByAxisId", typeof(AnnotationPlotAxisDataCollection), new AnnotationPlotAxisData()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToAnnotationPlotByPlotId != null)
			{
				this.PlotId = this._UpToAnnotationPlotByPlotId.Id;
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
			if(this._AnnotationPlotAxisDataCollectionByAxisId != null)
			{
				Apply(this._AnnotationPlotAxisDataCollectionByAxisId, "AxisId", this.Id);
			}
		}
		
	}
	



	[Serializable]
	public partial class AnnotationPlotAxisMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected AnnotationPlotAxisMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.PlotId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.PlotId;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.Label, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.Label;
			c.CharacterMaxLength = 256;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.MinValue, 3, typeof(System.Double), esSystemType.Double);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.MinValue;
			c.NumericPrecision = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.MaxValue, 4, typeof(System.Double), esSystemType.Double);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.MaxValue;
			c.NumericPrecision = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.Scale, 5, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.Scale;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.Type, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.Type;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(AnnotationPlotAxisMetadata.ColumnNames.Dimension, 7, typeof(System.Byte), esSystemType.Byte);
			c.PropertyName = AnnotationPlotAxisMetadata.PropertyNames.Dimension;
			c.NumericPrecision = 3;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public AnnotationPlotAxisMetadata Meta()
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
			 public const string PlotId = "PlotId";
			 public const string Label = "Label";
			 public const string MinValue = "MinValue";
			 public const string MaxValue = "MaxValue";
			 public const string Scale = "Scale";
			 public const string Type = "Type";
			 public const string Dimension = "Dimension";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string PlotId = "PlotId";
			 public const string Label = "Label";
			 public const string MinValue = "MinValue";
			 public const string MaxValue = "MaxValue";
			 public const string Scale = "Scale";
			 public const string Type = "Type";
			 public const string Dimension = "Dimension";
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
			lock (typeof(AnnotationPlotAxisMetadata))
			{
				if(AnnotationPlotAxisMetadata.mapDelegates == null)
				{
					AnnotationPlotAxisMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AnnotationPlotAxisMetadata.meta == null)
				{
					AnnotationPlotAxisMetadata.meta = new AnnotationPlotAxisMetadata();
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
				meta.AddTypeMap("PlotId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Label", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("MinValue", new esTypeMap("float", "System.Double"));
				meta.AddTypeMap("MaxValue", new esTypeMap("float", "System.Double"));
				meta.AddTypeMap("Scale", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Type", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Dimension", new esTypeMap("tinyint", "System.Byte"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "AnnotationPlotAxis";
				meta.Destination = "AnnotationPlotAxis";
				
				meta.spInsert = "proc_AnnotationPlotAxisInsert";				
				meta.spUpdate = "proc_AnnotationPlotAxisUpdate";		
				meta.spDelete = "proc_AnnotationPlotAxisDelete";
				meta.spLoadAll = "proc_AnnotationPlotAxisLoadAll";
				meta.spLoadByPrimaryKey = "proc_AnnotationPlotAxisLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private AnnotationPlotAxisMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
