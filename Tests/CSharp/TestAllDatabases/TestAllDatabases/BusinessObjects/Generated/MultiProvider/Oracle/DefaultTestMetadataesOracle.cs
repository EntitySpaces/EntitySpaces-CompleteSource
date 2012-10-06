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
    public partial class DefaultTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
		{
			// This is only executed once per the life of the application
			lock (typeof(DefaultTestMetadata))
			{
				if(DefaultTestMetadata.mapDelegates == null)
				{
					DefaultTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (DefaultTestMetadata.meta == null)
				{
					DefaultTestMetadata.meta = new DefaultTestMetadata();
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
				

				meta.AddTypeMap("TestId", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DefaultNotNullInt", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DefaultNotNullBool", new esTypeMap("NUMBER", "System.Decimal"));
				meta["AutoKeyText"] = "DEFAULTTEST_SEQ";				
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				meta.Source = "DefaultTest";
				meta.Destination = "DefaultTest";
				
				meta.spInsert = "esDefaultTestInsert";				
				meta.spUpdate = "esDefaultTestUpdate";		
				meta.spDelete = "esDefaultTestDelete";
				meta.spLoadAll = "esDefaultTestLoadAll";
				meta.spLoadByPrimaryKey = "esDefaultTestLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
