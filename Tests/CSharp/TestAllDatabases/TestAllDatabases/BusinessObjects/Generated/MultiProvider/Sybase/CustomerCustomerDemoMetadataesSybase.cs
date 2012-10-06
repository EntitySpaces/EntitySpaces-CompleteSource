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
    public partial class CustomerCustomerDemoMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSybase()
		{
			// This is only executed once per the life of the application
			lock (typeof(CustomerCustomerDemoMetadata))
			{
				if(CustomerCustomerDemoMetadata.mapDelegates == null)
				{
					CustomerCustomerDemoMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerCustomerDemoMetadata.meta == null)
				{
					CustomerCustomerDemoMetadata.meta = new CustomerCustomerDemoMetadata();
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
				

				meta.AddTypeMap("CustomerID", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("CustomerTypeID", new esTypeMap("nchar", "System.String"));				
				meta.Catalog = "Northwind";
				meta.Schema = "DBA";
				meta.Source = "CustomerCustomerDemo";
				meta.Destination = "CustomerCustomerDemo";
				
				meta.spInsert = "proc_CustomerCustomerDemoInsert";				
				meta.spUpdate = "proc_CustomerCustomerDemoUpdate";		
				meta.spDelete = "proc_CustomerCustomerDemoDelete";
				meta.spLoadAll = "proc_CustomerCustomerDemoLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerCustomerDemoLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
