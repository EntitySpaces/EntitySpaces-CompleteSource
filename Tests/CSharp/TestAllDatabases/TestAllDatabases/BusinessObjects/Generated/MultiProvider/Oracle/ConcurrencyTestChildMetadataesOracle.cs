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
    public partial class ConcurrencyTestChildMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
		{
			// This is only executed once per the life of the application
			lock (typeof(ConcurrencyTestChildMetadata))
			{
				if(ConcurrencyTestChildMetadata.mapDelegates == null)
				{
					ConcurrencyTestChildMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ConcurrencyTestChildMetadata.meta == null)
				{
					ConcurrencyTestChildMetadata.meta = new ConcurrencyTestChildMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("Name", new esTypeMap("NVARCHAR2", "System.String"));
				meta.AddTypeMap("Parent", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DefaultTest", new esTypeMap("TIMESTAMP", "System.DateTime"));
				meta.AddTypeMap("ColumnA", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ColumnB", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ColumnAB", new esTypeMap("NUMBER", "System.Decimal"));
				meta["AutoKeyText"] = "CHILD_SEQ";				
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				meta.Source = "ConcurrencyTestChild";
				meta.Destination = "ConcurrencyTestChild";
				
				meta.spInsert = "esConcurrencyTestChildInsert";				
				meta.spUpdate = "esConcurrencyTestChildUpdate";		
				meta.spDelete = "esConcurrencyTestChildDelete";
				meta.spLoadAll = "esConcurrencyTestChildLoadAll";
				meta.spLoadByPrimaryKey = "esConcurrencyTestChildLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
