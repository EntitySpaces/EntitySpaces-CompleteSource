/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : VistaDB4
Date Generated       : 3/17/2012 4:45:36 AM
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
		static private int RegisterDelegateesVistaDB4()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esVistaDB4);
				mapDelegates.Add("esVistaDB4", mapMethod);
				mapMethod("esVistaDB4");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esVistaDB4(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("CustomerID", new esTypeMap("Char", "System.String"));
				meta.AddTypeMap("CustomerSub", new esTypeMap("Char", "System.String"));
				meta.AddTypeMap("CustomerName", new esTypeMap("VarChar", "System.String"));
				meta.AddTypeMap("DateAdded", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("Active", new esTypeMap("Bit", "System.Boolean"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("BigInt", "System.Int64"));
				meta.AddTypeMap("Manager", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("StaffAssigned", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("UniqueID", new esTypeMap("UniqueIdentifier", "System.Guid"));
				meta.AddTypeMap("Notes", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("CreditLimit", new esTypeMap("Money", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("Decimal", "System.Decimal"));				
				meta.Catalog = "ForeignKeyTest.vdb4";
				
				meta.Source = "Customer";
				meta.Destination = "Customer";
				
				meta.spInsert = "proc_CustomerInsert";				
				meta.spUpdate = "proc_CustomerUpdate";		
				meta.spDelete = "proc_CustomerDelete";
				meta.spLoadAll = "proc_CustomerLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
