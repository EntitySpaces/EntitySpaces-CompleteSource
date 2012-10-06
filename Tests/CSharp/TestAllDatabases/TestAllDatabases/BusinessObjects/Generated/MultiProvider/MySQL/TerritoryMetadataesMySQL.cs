/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:09 AM
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
		static private int RegisterDelegateesMySQL()
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
				

				meta.AddTypeMap("TerritoryID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("VARCHAR", "System.String"));				
				meta.Catalog = "foreignkeytest";
				
				meta.Source = "territory";
				meta.Destination = "territory";
				
				meta.spInsert = "proc_territoryInsert";				
				meta.spUpdate = "proc_territoryUpdate";		
				meta.spDelete = "proc_territoryDelete";
				meta.spLoadAll = "proc_territoryLoadAll";
				meta.spLoadByPrimaryKey = "proc_territoryLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
