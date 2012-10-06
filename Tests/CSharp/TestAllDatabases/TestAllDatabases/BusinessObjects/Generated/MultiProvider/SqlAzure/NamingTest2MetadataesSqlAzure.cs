/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLAzure
Date Generated       : 3/17/2012 4:46:59 AM
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
    public partial class NamingTest2Metadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
		{
			// This is only executed once per the life of the application
			lock (typeof(NamingTest2Metadata))
			{
				if(NamingTest2Metadata.mapDelegates == null)
				{
					NamingTest2Metadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (NamingTest2Metadata.meta == null)
				{
					NamingTest2Metadata.meta = new NamingTest2Metadata();
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
				

				meta.AddTypeMap("IdentityKey", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ItemDescription", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte[]"));
				meta.AddTypeMap("GuidNewid", new esTypeMap("uniqueidentifier", "System.Guid"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "dbo";
				meta.Source = "Naming Test2";
				meta.Destination = "Naming Test2";
				
				meta.spInsert = "proc_Naming Test2Insert";				
				meta.spUpdate = "proc_Naming Test2Update";		
				meta.spDelete = "proc_Naming Test2Delete";
				meta.spLoadAll = "proc_Naming Test2LoadAll";
				meta.spLoadByPrimaryKey = "proc_Naming Test2LoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
