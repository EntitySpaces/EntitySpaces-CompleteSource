/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLAzure
Date Generated       : 3/17/2012 4:46:58 AM
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
    public partial class KeyNotFirstMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
		{
			// This is only executed once per the life of the application
			lock (typeof(KeyNotFirstMetadata))
			{
				if(KeyNotFirstMetadata.mapDelegates == null)
				{
					KeyNotFirstMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (KeyNotFirstMetadata.meta == null)
				{
					KeyNotFirstMetadata.meta = new KeyNotFirstMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlAzure);
				mapDelegates.Add("esSqlAzure", mapMethod);
				mapMethod("esSqlAzure");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlAzure(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("SomeText", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("TheKey", new esTypeMap("int", "System.Int32"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "dbo";
				meta.Source = "KeyNotFirst";
				meta.Destination = "KeyNotFirst";
				
				meta.spInsert = "proc_KeyNotFirstInsert";				
				meta.spUpdate = "proc_KeyNotFirstUpdate";		
				meta.spDelete = "proc_KeyNotFirstDelete";
				meta.spLoadAll = "proc_KeyNotFirstLoadAll";
				meta.spLoadByPrimaryKey = "proc_KeyNotFirstLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
