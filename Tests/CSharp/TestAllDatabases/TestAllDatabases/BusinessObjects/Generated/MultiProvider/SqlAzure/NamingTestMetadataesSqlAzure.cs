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
    public partial class NamingTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
		{
			// This is only executed once per the life of the application
			lock (typeof(NamingTestMetadata))
			{
				if(NamingTestMetadata.mapDelegates == null)
				{
					NamingTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (NamingTestMetadata.meta == null)
				{
					NamingTestMetadata.meta = new NamingTestMetadata();
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
				

				meta.AddTypeMap("GuidKeyAlias", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("TestAliasSpace", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("Test_Alias_Underscore", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("TestFieldSpace", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("TestFieldUnderscore", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("TestAlias", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("GuidNonKey", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("TestFieldDot", new esTypeMap("nchar", "System.String"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "dbo";
				meta.Source = "Naming.Test";
				meta.Destination = "Naming.Test";
				
				meta.spInsert = "proc_Naming.TestInsert";				
				meta.spUpdate = "proc_Naming.TestUpdate";		
				meta.spDelete = "proc_Naming.TestDelete";
				meta.spLoadAll = "proc_Naming.TestLoadAll";
				meta.spLoadByPrimaryKey = "proc_Naming.TestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
