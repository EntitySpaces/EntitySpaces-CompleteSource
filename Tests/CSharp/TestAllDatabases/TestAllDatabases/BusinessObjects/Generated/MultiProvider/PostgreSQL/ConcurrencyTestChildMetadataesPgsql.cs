/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 3/17/2012 4:45:07 AM
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
		static private int RegisterDelegateesPgsql()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esPgsql);
				mapDelegates.Add("esPgsql", mapMethod);
				mapMethod("esPgsql");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esPgsql(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("Name", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Parent", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("DefaultTest", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("ColumnA", new esTypeMap("int4", "System.Int32"));
				meta.AddTypeMap("ColumnB", new esTypeMap("int4", "System.Int32"));
				meta.AddTypeMap("ColumnAB", new esTypeMap("int4", "System.Int32"));

				meta["AutoKeyText"] = @"nextval('""ConcurrencyTestChild_Id_seq""'::regclass)";				
				meta.Catalog = "AggregateDb";
				meta.Schema = "public";
				meta.Source = "ConcurrencyTestChild";
				meta.Destination = "ConcurrencyTestChild";
				
				meta.spInsert = "proc_ConcurrencyTestChildInsert";				
				meta.spUpdate = "proc_ConcurrencyTestChildUpdate";		
				meta.spDelete = "proc_ConcurrencyTestChildDelete";
				meta.spLoadAll = "proc_ConcurrencyTestChildLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestChildLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
