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
    public partial class ConstructorTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
		{
			// This is only executed once per the life of the application
			lock (typeof(ConstructorTestMetadata))
			{
				if(ConstructorTestMetadata.mapDelegates == null)
				{
					ConstructorTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ConstructorTestMetadata.meta == null)
				{
					ConstructorTestMetadata.meta = new ConstructorTestMetadata();
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
				

				meta.AddTypeMap("ConstructorTestId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("DefaultInt", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DefaultBool", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("DefaultDateTime", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("DefaultString", new esTypeMap("varchar", "System.String"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "dbo";
				meta.Source = "ConstructorTest";
				meta.Destination = "ConstructorTest";
				
				meta.spInsert = "proc_ConstructorTestInsert";				
				meta.spUpdate = "proc_ConstructorTestUpdate";		
				meta.spDelete = "proc_ConstructorTestDelete";
				meta.spLoadAll = "proc_ConstructorTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_ConstructorTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
