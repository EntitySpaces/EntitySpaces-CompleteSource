/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:08 AM
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
		static private int RegisterDelegateesMySQL()
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
				

				meta.AddTypeMap("OrderID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("CustomerID", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("OrderDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("RequiredDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("ShippedDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("ShipVia", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Freight", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("ShipName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("ShipAddress", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("ShipCity", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("ShipRegion", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("ShipCountry", new esTypeMap("VARCHAR", "System.String"));				
				meta.Catalog = "northwind";
				
				meta.Source = "orders";
				meta.Destination = "orders";
				
				meta.spInsert = "proc_ordersInsert";				
				meta.spUpdate = "proc_ordersUpdate";		
				meta.spDelete = "proc_ordersDelete";
				meta.spLoadAll = "proc_ordersLoadAll";
				meta.spLoadByPrimaryKey = "proc_ordersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
