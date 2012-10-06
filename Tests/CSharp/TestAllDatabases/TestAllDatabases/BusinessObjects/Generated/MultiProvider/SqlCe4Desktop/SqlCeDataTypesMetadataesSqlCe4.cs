/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:58 AM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;

namespace BusinessObjects
{
    public partial class SqlCeDataTypesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlCe4()
		{
			// This is only executed once per the life of the application
			lock (typeof(SqlCeDataTypesMetadata))
			{
				if(SqlCeDataTypesMetadata.mapDelegates == null)
				{
					SqlCeDataTypesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SqlCeDataTypesMetadata.meta == null)
				{
					SqlCeDataTypesMetadata.meta = new SqlCeDataTypesMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlCe4);
				mapDelegates.Add("esSqlCe4", mapMethod);
				mapMethod("esSqlCe4");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlCe4(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("NumericType", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("RealType", new esTypeMap("real", "System.Single"));
				meta.AddTypeMap("FloatType", new esTypeMap("float", "System.Double"));				
				meta.Catalog = "AggregateDb.sdf";
				
				meta.Source = "SqlCeDataTypes";
				meta.Destination = "SqlCeDataTypes";
				
				meta.spInsert = "proc_SqlCeDataTypesInsert";				
				meta.spUpdate = "proc_SqlCeDataTypesUpdate";		
				meta.spDelete = "proc_SqlCeDataTypesDelete";
				meta.spLoadAll = "proc_SqlCeDataTypesLoadAll";
				meta.spLoadByPrimaryKey = "proc_SqlCeDataTypesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe4"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe4"];
		}
		
		static private int _esSqlCe4 = RegisterDelegateesSqlCe4();
    }
}
