/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:27 AM
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
		static private int RegisterDelegateesSybase()
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
				

				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("Id", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("DateLastUpdated", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("DateAdded", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("ComputedTest", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("SomeDate", new esTypeMap("timestamp", "System.DateTime"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "DBA";
				meta.Source = "ComputedTest";
				meta.Destination = "ComputedTest";
				
				meta.spInsert = "proc_ComputedTestInsert";				
				meta.spUpdate = "proc_ComputedTestUpdate";		
				meta.spDelete = "proc_ComputedTestDelete";
				meta.spLoadAll = "proc_ComputedTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ComputedTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
