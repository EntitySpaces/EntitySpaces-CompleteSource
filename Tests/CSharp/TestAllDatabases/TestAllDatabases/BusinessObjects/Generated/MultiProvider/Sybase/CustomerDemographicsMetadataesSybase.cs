/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:28 AM
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
		static private int RegisterDelegateesSybase()
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
				

				meta.AddTypeMap("CustomerTypeID", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("CustomerDesc", new esTypeMap("long nvarchar", "System.String"));				
				meta.Catalog = "Northwind";
				meta.Schema = "DBA";
				meta.Source = "CustomerDemographics";
				meta.Destination = "CustomerDemographics";
				
				meta.spInsert = "proc_CustomerDemographicsInsert";				
				meta.spUpdate = "proc_CustomerDemographicsUpdate";		
				meta.spDelete = "proc_CustomerDemographicsDelete";
				meta.spLoadAll = "proc_CustomerDemographicsLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerDemographicsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
