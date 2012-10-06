/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLAzure
Date Generated       : 3/17/2012 4:47:09 AM
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
    public partial class ReferredEmployeeMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
		{
			// This is only executed once per the life of the application
			lock (typeof(ReferredEmployeeMetadata))
			{
				if(ReferredEmployeeMetadata.mapDelegates == null)
				{
					ReferredEmployeeMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ReferredEmployeeMetadata.meta == null)
				{
					ReferredEmployeeMetadata.meta = new ReferredEmployeeMetadata();
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
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ReferredID", new esTypeMap("int", "System.Int32"));				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "dbo";
				meta.Source = "ReferredEmployee";
				meta.Destination = "ReferredEmployee";
				
				meta.spInsert = "proc_ReferredEmployeeInsert";				
				meta.spUpdate = "proc_ReferredEmployeeUpdate";		
				meta.spDelete = "proc_ReferredEmployeeDelete";
				meta.spLoadAll = "proc_ReferredEmployeeLoadAll";
				meta.spLoadByPrimaryKey = "proc_ReferredEmployeeLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
