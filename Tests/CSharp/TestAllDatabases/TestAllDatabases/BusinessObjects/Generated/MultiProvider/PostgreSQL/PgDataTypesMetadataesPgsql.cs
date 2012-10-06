/*
===============================================================================
                    EntitySpaces 2011 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2011.1.0530.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 9/22/2011 11:48:54 PM
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
    public partial class PgDataTypesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesPgsql()
		{
			// This is only executed once per the life of the application
			lock (typeof(PgDataTypesMetadata))
			{
				if(PgDataTypesMetadata.mapDelegates == null)
				{
					PgDataTypesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (PgDataTypesMetadata.meta == null)
				{
					PgDataTypesMetadata.meta = new PgDataTypesMetadata();
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
				meta.AddTypeMap("TimeType", new esTypeMap("time", "System.DateTime"));

				meta["AutoKeyText"] = @"nextval('""PgDataTypes_ID_seq""'::regclass)";				
				
				
				meta.Source = "PgDataTypes";
				meta.Destination = "PgDataTypes";
				
				meta.spInsert = "proc_PgDataTypesInsert";				
				meta.spUpdate = "proc_PgDataTypesUpdate";		
				meta.spDelete = "proc_PgDataTypesDelete";
				meta.spLoadAll = "proc_PgDataTypesLoadAll";
				meta.spLoadByPrimaryKey = "proc_PgDataTypesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
