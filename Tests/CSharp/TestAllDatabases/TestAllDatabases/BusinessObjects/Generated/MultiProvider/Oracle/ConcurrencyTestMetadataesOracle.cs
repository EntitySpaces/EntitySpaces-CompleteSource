/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:58 AM
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
		static private int RegisterDelegateesOracle()
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
				

				meta.AddTypeMap("Id", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("Name", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("NUMBER", "System.Decimal"));				
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				meta.Source = "ConcurrencyTest";
				meta.Destination = "ConcurrencyTest";
				
				meta.spInsert = "esConcurrencyTestInsert";				
				meta.spUpdate = "esConcurrencyTestUpdate";		
				meta.spDelete = "esConcurrencyTestDelete";
				meta.spLoadAll = "esConcurrencyTestLoadAll";
				meta.spLoadByPrimaryKey = "esConcurrencyTestLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
