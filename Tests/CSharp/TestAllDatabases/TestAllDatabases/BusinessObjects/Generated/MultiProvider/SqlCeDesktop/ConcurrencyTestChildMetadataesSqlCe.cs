/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:50 AM
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
    public partial class ConcurrencyTestChildMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlCe()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlCe);
				mapDelegates.Add("esSqlCe", mapMethod);
				mapMethod("esSqlCe");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlCe(string mapName)
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
				meta.Catalog = "AggregateDb.sdf";
				
				meta.Source = "ConcurrencyTestChild";
				meta.Destination = "ConcurrencyTestChild";
				
				meta.spInsert = "proc_ConcurrencyTestChildInsert";				
				meta.spUpdate = "proc_ConcurrencyTestChildUpdate";		
				meta.spDelete = "proc_ConcurrencyTestChildDelete";
				meta.spLoadAll = "proc_ConcurrencyTestChildLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestChildLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe"];
		}
		
		static private int _esSqlCe = RegisterDelegateesSqlCe();
    }
}
