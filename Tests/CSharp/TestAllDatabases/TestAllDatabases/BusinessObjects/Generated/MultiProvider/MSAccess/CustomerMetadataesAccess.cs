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
    public partial class CustomerMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesAccess()
		{
			// This is only executed once per the life of the application
			lock (typeof(CustomerMetadata))
			{
				if(CustomerMetadata.mapDelegates == null)
				{
					CustomerMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerMetadata.meta == null)
				{
					CustomerMetadata.meta = new CustomerMetadata();
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
				

				meta.AddTypeMap("CustomerID", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("CustomerSub", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("CustomerName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("DateAdded", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("Active", new esTypeMap("Yes/No", "System.Boolean"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("Manager", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("StaffAssigned", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("UniqueID", new esTypeMap("Replication ID", "System.Guid"));
				meta.AddTypeMap("Notes", new esTypeMap("Memo", "System.String"));
				meta.AddTypeMap("CreditLimit", new esTypeMap("Currency", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("Double", "System.Double"));				
				meta.Catalog = "ForeignKeyTest.mdb";
				
				meta.Source = "Customer";
				meta.Destination = "Customer";
				
				meta.spInsert = "proc_CustomerInsert";				
				meta.spUpdate = "proc_CustomerUpdate";		
				meta.spDelete = "proc_CustomerDelete";
				meta.spLoadAll = "proc_CustomerLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
