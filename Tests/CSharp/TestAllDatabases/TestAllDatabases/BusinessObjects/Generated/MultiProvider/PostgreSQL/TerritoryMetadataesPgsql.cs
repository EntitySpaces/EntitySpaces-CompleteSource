/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 3/17/2012 4:45:08 AM
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
    public partial class TerritoryMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesPgsql()
		{
			// This is only executed once per the life of the application
			lock (typeof(TerritoryMetadata))
			{
				if(TerritoryMetadata.mapDelegates == null)
				{
					TerritoryMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoryMetadata.meta == null)
				{
					TerritoryMetadata.meta = new TerritoryMetadata();
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
				

				meta.AddTypeMap("TerritoryID", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"));

				meta["AutoKeyText"] = @"nextval('""Territory_TerritoryID_seq""'::regclass)";				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "public";
				meta.Source = "Territory";
				meta.Destination = "Territory";
				
				meta.spInsert = "proc_TerritoryInsert";				
				meta.spUpdate = "proc_TerritoryUpdate";		
				meta.spDelete = "proc_TerritoryDelete";
				meta.spLoadAll = "proc_TerritoryLoadAll";
				meta.spLoadByPrimaryKey = "proc_TerritoryLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
