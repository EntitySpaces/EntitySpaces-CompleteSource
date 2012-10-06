/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:24 AM
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
    public partial class CustomerGroupMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesAccess()
		{
			// This is only executed once per the life of the application
			lock (typeof(CustomerGroupMetadata))
			{
				if(CustomerGroupMetadata.mapDelegates == null)
				{
					CustomerGroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerGroupMetadata.meta == null)
				{
					CustomerGroupMetadata.meta = new CustomerGroupMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esAccess);
				mapDelegates.Add("esAccess", mapMethod);
				mapMethod("esAccess");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esAccess(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("GroupID", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("GroupName", new esTypeMap("Text", "System.String"));				
				meta.Catalog = "ForeignKeyTest.mdb";
				
				meta.Source = "CustomerGroup";
				meta.Destination = "CustomerGroup";
				
				meta.spInsert = "proc_CustomerGroupInsert";				
				meta.spUpdate = "proc_CustomerGroupUpdate";		
				meta.spDelete = "proc_CustomerGroupDelete";
				meta.spLoadAll = "proc_CustomerGroupLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerGroupLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
