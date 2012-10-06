/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:59 AM
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
    public partial class TerritoryExMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
		{
			// This is only executed once per the life of the application
			lock (typeof(TerritoryExMetadata))
			{
				if(TerritoryExMetadata.mapDelegates == null)
				{
					TerritoryExMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoryExMetadata.meta == null)
				{
					TerritoryExMetadata.meta = new TerritoryExMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esOracle);
				mapDelegates.Add("esOracle", mapMethod);
				mapMethod("esOracle");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esOracle(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("TerritoryID", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("Notes", new esTypeMap("VARCHAR2", "System.String"));				
				meta.Catalog = "HIERARCHICAL";
				meta.Schema = "HIERARCHICAL";
				meta.Source = "TerritoryEx";
				meta.Destination = "TerritoryEx";
				
				meta.spInsert = "esTerritoryExInsert";				
				meta.spUpdate = "esTerritoryExUpdate";		
				meta.spDelete = "esTerritoryExDelete";
				meta.spLoadAll = "esTerritoryExLoadAll";
				meta.spLoadByPrimaryKey = "esTerritoryExLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
