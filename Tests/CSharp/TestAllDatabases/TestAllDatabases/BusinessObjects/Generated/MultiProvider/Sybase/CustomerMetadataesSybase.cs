/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:27 AM
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
		static private int RegisterDelegateesSybase()
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
				

				meta.AddTypeMap("CustomerID", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("CustomerSub", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("CustomerName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("DateAdded", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("Active", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("varbinary", "System.Byte[]"));
				meta.AddTypeMap("Manager", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("StaffAssigned", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("UniqueID", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Notes", new esTypeMap("long varchar", "System.String"));
				meta.AddTypeMap("CreditLimit", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("numeric", "System.Decimal"));				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "DBA";
				meta.Source = "Customer";
				meta.Destination = "Customer";
				
				meta.spInsert = "proc_CustomerInsert";				
				meta.spUpdate = "proc_CustomerUpdate";		
				meta.spDelete = "proc_CustomerDelete";
				meta.spLoadAll = "proc_CustomerLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
