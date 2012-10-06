/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:28 AM
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
    public partial class TerritoriesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSybase()
		{
			// This is only executed once per the life of the application
			lock (typeof(TerritoriesMetadata))
			{
				if(TerritoriesMetadata.mapDelegates == null)
				{
					TerritoriesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoriesMetadata.meta == null)
				{
					TerritoriesMetadata.meta = new TerritoriesMetadata();
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
				

				meta.AddTypeMap("TerritoryID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TerritoryDescription", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("RegionID", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "Northwind";
				meta.Schema = "DBA";
				meta.Source = "Territories";
				meta.Destination = "Territories";
				
				meta.spInsert = "proc_TerritoriesInsert";				
				meta.spUpdate = "proc_TerritoriesUpdate";		
				meta.spDelete = "proc_TerritoriesDelete";
				meta.spLoadAll = "proc_TerritoriesLoadAll";
				meta.spLoadByPrimaryKey = "proc_TerritoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
