/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:09 AM
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
		static private int RegisterDelegateesMySQL()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esMySQL);
				mapDelegates.Add("esMySQL", mapMethod);
				mapMethod("esMySQL");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esMySQL(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("CustomerID", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("CustomerSub", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("CustomerName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("DateAdded", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("Active", new esTypeMap("TINYINT UNSIGNED", "System.Byte"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Manager", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("StaffAssigned", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("UniqueID", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("LONGTEXT", "System.String"));
				meta.AddTypeMap("CreditLimit", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("DOUBLE", "System.Double"));				
				meta.Catalog = "foreignkeytest";
				
				meta.Source = "customer";
				meta.Destination = "customer";
				
				meta.spInsert = "proc_customerInsert";				
				meta.spUpdate = "proc_customerUpdate";		
				meta.spDelete = "proc_customerDelete";
				meta.spLoadAll = "proc_customerLoadAll";
				meta.spLoadByPrimaryKey = "proc_customerLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
