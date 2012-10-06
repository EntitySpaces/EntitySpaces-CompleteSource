/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:27 AM
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
		static private int RegisterDelegateesSybase()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSybase);
				mapDelegates.Add("esSybase", mapMethod);
				mapMethod("esSybase");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSybase(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Parent", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("DefaultTest", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("ColumnA", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("ColumnB", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("ComputedAB", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "DBA";
				meta.Source = "ConcurrencyTestChild";
				meta.Destination = "ConcurrencyTestChild";
				
				meta.spInsert = "proc_ConcurrencyTestChildInsert";				
				meta.spUpdate = "proc_ConcurrencyTestChildUpdate";		
				meta.spDelete = "proc_ConcurrencyTestChildDelete";
				meta.spLoadAll = "proc_ConcurrencyTestChildLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestChildLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
