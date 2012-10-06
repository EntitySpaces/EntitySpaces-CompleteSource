/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:59 AM
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
		static private int RegisterDelegateesOracle()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esOracle);
				mapDelegates.Add("esOracle", mapMethod);
				mapMethod("esOracle");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esOracle(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("CustomerID", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("CustomerSub", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("CustomerName", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("DateAdded", new esTypeMap("TIMESTAMP", "System.DateTime"));
				meta.AddTypeMap("Active", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("Manager", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("StaffAssigned", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("UniqueID", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("CreditLimit", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("NUMBER", "System.Decimal"));				
				meta.Catalog = "HIERARCHICAL";
				meta.Schema = "HIERARCHICAL";
				meta.Source = "Customer";
				meta.Destination = "Customer";
				
				meta.spInsert = "esCustomerInsert";				
				meta.spUpdate = "esCustomerUpdate";		
				meta.spDelete = "esCustomerDelete";
				meta.spLoadAll = "esCustomerLoadAll";
				meta.spLoadByPrimaryKey = "esCustomerLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
