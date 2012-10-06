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
    public partial class DefaultTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
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
				

				meta.AddTypeMap("TestId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DefaultNotNullInt", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DefaultNotNullBool", new esTypeMap("bit", "System.Boolean"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "dbo";
				meta.Source = "DefaultTest";
				meta.Destination = "DefaultTest";
				
				meta.spInsert = "proc_DefaultTestInsert";				
				meta.spUpdate = "proc_DefaultTestUpdate";		
				meta.spDelete = "proc_DefaultTestDelete";
				meta.spLoadAll = "proc_DefaultTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_DefaultTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
