/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:33 AM
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
    public partial class OrdersMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesAccess()
		{
			// This is only executed once per the life of the application
			lock (typeof(OrdersMetadata))
			{
				if(OrdersMetadata.mapDelegates == null)
				{
					OrdersMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrdersMetadata.meta == null)
				{
					OrdersMetadata.meta = new OrdersMetadata();
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
				

				meta.AddTypeMap("OrderID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("CustomerID", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("OrderDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("RequiredDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("ShippedDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("ShipVia", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("Freight", new esTypeMap("Currency", "System.Decimal"));
				meta.AddTypeMap("ShipName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("ShipAddress", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("ShipCity", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("ShipRegion", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("ShipCountry", new esTypeMap("Text", "System.String"));				
				meta.Catalog = "Northwind.mdb";
				
				meta.Source = "Orders";
				meta.Destination = "Orders";
				
				meta.spInsert = "proc_OrdersInsert";				
				meta.spUpdate = "proc_OrdersUpdate";		
				meta.spDelete = "proc_OrdersDelete";
				meta.spLoadAll = "proc_OrdersLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrdersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
