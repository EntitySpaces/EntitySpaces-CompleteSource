/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLite
Date Generated       : 3/17/2012 4:45:16 AM
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
		static private int RegisterDelegateesSQLite()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSQLite);
				mapDelegates.Add("esSQLite", mapMethod);
				mapMethod("esSQLite");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSQLite(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("Name", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "main";
				
				meta.Source = "ConcurrencyTest";
				meta.Destination = "ConcurrencyTest";
				
				meta.spInsert = "proc_ConcurrencyTestInsert";				
				meta.spUpdate = "proc_ConcurrencyTestUpdate";		
				meta.spDelete = "proc_ConcurrencyTestDelete";
				meta.spLoadAll = "proc_ConcurrencyTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSQLite"] = meta;
			}
			
			return m_providerMetadataMaps["esSQLite"];
		}
		
		static private int _esSQLite = RegisterDelegateesSQLite();
    }
}
