/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:06 AM
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
		static private int RegisterDelegateesMySQL()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esMySQL);
				mapDelegates.Add("esMySQL", mapMethod);
				mapMethod("esMySQL");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esMySQL(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("BIGINT", "System.Int64"));
				meta.AddTypeMap("Name", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Parent", new esTypeMap("BIGINT", "System.Int64"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("BIGINT", "System.Int64"));
				meta.AddTypeMap("DefaultTest", new esTypeMap("TIMESTAMP", "System.DateTime"));
				meta.AddTypeMap("ColumnA", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("ColumnB", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("ComputedAB", new esTypeMap("SMALLINT", "System.Int16"));				
				meta.Catalog = "aggregatedb";
				
				meta.Source = "concurrencytestchild";
				meta.Destination = "concurrencytestchild";
				
				meta.spInsert = "proc_concurrencytestchildInsert";				
				meta.spUpdate = "proc_concurrencytestchildUpdate";		
				meta.spDelete = "proc_concurrencytestchildDelete";
				meta.spLoadAll = "proc_concurrencytestchildLoadAll";
				meta.spLoadByPrimaryKey = "proc_concurrencytestchildLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
