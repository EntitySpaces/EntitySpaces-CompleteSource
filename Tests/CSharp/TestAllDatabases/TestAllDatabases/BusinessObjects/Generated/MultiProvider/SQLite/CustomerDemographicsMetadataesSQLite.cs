/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLite
Date Generated       : 3/17/2012 4:45:16 AM
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
    public partial class CustomerDemographicsMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSQLite()
		{
			// This is only executed once per the life of the application
			lock (typeof(CustomerDemographicsMetadata))
			{
				if(CustomerDemographicsMetadata.mapDelegates == null)
				{
					CustomerDemographicsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerDemographicsMetadata.meta == null)
				{
					CustomerDemographicsMetadata.meta = new CustomerDemographicsMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSQLite);
				mapDelegates.Add("esSQLite", mapMethod);
				mapMethod("esSQLite");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSQLite(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("CustomerTypeID", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("CustomerDesc", new esTypeMap("text", "System.String"));				
				meta.Catalog = "main";
				
				meta.Source = "CustomerDemographics";
				meta.Destination = "CustomerDemographics";
				
				meta.spInsert = "proc_CustomerDemographicsInsert";				
				meta.spUpdate = "proc_CustomerDemographicsUpdate";		
				meta.spDelete = "proc_CustomerDemographicsDelete";
				meta.spLoadAll = "proc_CustomerDemographicsLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerDemographicsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSQLite"] = meta;
			}
			
			return m_providerMetadataMaps["esSQLite"];
		}
		
		static private int _esSQLite = RegisterDelegateesSQLite();
    }
}
