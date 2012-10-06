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
    public partial class ComputedTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
		{
			// This is only executed once per the life of the application
			lock (typeof(ComputedTestMetadata))
			{
				if(ComputedTestMetadata.mapDelegates == null)
				{
					ComputedTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ComputedTestMetadata.meta == null)
				{
					ComputedTestMetadata.meta = new ComputedTestMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte[]"));
				meta.AddTypeMap("DateLastUpdated", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ComputedField", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("SomeDate", new esTypeMap("datetime", "System.DateTime"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "dbo";
				meta.Source = "ComputedTest";
				meta.Destination = "ComputedTest";
				
				meta.spInsert = "proc_ComputedTestInsert";				
				meta.spUpdate = "proc_ComputedTestUpdate";		
				meta.spDelete = "proc_ComputedTestDelete";
				meta.spLoadAll = "proc_ComputedTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ComputedTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
