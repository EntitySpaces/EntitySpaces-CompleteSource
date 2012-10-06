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
    public partial class ConcurrencyTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlCe()
		{
			// This is only executed once per the life of the application
			lock (typeof(ConcurrencyTestMetadata))
			{
				if(ConcurrencyTestMetadata.mapDelegates == null)
				{
					ConcurrencyTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ConcurrencyTestMetadata.meta == null)
				{
					ConcurrencyTestMetadata.meta = new ConcurrencyTestMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("bigint", "System.Int64"));				
				meta.Catalog = "AggregateDb.sdf";
				
				meta.Source = "ConcurrencyTest";
				meta.Destination = "ConcurrencyTest";
				
				meta.spInsert = "proc_ConcurrencyTestInsert";				
				meta.spUpdate = "proc_ConcurrencyTestUpdate";		
				meta.spDelete = "proc_ConcurrencyTestDelete";
				meta.spLoadAll = "proc_ConcurrencyTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe"];
		}
		
		static private int _esSqlCe = RegisterDelegateesSqlCe();
    }
}
