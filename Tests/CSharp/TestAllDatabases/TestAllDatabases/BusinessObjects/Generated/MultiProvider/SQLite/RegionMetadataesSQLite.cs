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
    public partial class RegionMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSQLite()
		{
			// This is only executed once per the life of the application
			lock (typeof(RegionMetadata))
			{
				if(RegionMetadata.mapDelegates == null)
				{
					RegionMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (RegionMetadata.meta == null)
				{
					RegionMetadata.meta = new RegionMetadata();
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
				

				meta.AddTypeMap("RegionID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("RegionDescription", new esTypeMap("char", "System.String"));				
				meta.Catalog = "main";
				
				meta.Source = "Region";
				meta.Destination = "Region";
				
				meta.spInsert = "proc_RegionInsert";				
				meta.spUpdate = "proc_RegionUpdate";		
				meta.spDelete = "proc_RegionDelete";
				meta.spLoadAll = "proc_RegionLoadAll";
				meta.spLoadByPrimaryKey = "proc_RegionLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSQLite"] = meta;
			}
			
			return m_providerMetadataMaps["esSQLite"];
		}
		
		static private int _esSQLite = RegisterDelegateesSQLite();
    }
}
