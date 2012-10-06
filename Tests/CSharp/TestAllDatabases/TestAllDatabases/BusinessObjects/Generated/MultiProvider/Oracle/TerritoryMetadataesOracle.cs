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
    public partial class TerritoryMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
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
				meta.AddTypeMap("Description", new esTypeMap("VARCHAR2", "System.String"));
				meta["AutoKeyText"] = "seq_Territory";				
				meta.Catalog = "HIERARCHICAL";
				meta.Schema = "HIERARCHICAL";
				meta.Source = "Territory";
				meta.Destination = "Territory";
				
				meta.spInsert = "esTerritoryInsert";				
				meta.spUpdate = "esTerritoryUpdate";		
				meta.spDelete = "esTerritoryDelete";
				meta.spLoadAll = "esTerritoryLoadAll";
				meta.spLoadByPrimaryKey = "esTerritoryLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
