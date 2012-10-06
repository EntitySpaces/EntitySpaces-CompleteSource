//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;
using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
	class Utility : esEntity
	{
		public string GetFullName(int ID)
		{
			esConnection cn = this.es.Connection;
			cn.Catalog = "AggregateDb";
			cn.Schema = "dbo";

			esParameters parms = new esParameters();

			parms.Add("ID", ID);
			parms.Add("FullName", esParameterDirection.Output, DbType.String, 40);

			this.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_GetEmployeeFullName", parms);

			return parms["FullName"].Value as string;
		}

		protected override IMetadata Meta
		{
			get
			{
				return md;
			}
		}

		static private MetaData md = new MetaData();

		protected class MetaData : IMetadata
		{
			public Guid DataID
			{
				get { return Guid.NewGuid(); }
			}

			public bool MultiProviderMode
			{
				get { return true; }
			}

			public esColumnMetadataCollection Columns
			{
				get { return null; }
			}

			public esProviderSpecificMetadata GetProviderMetadata(string mapName)
			{
				return null;
			}
		}
	}
}
