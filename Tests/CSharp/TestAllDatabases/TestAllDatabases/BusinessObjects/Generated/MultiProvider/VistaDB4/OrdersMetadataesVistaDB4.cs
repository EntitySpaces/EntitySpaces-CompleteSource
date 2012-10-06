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
    public partial class OrdersMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesVistaDB4()
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
				

				meta.AddTypeMap("OrderID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("CustomerID", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("OrderDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("RequiredDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("ShippedDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("ShipVia", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("Freight", new esTypeMap("Money", "System.Decimal"));
				meta.AddTypeMap("ShipName", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("ShipAddress", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("ShipCity", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("ShipRegion", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("ShipCountry", new esTypeMap("NVarChar", "System.String"));				
				meta.Catalog = "Northwind.vdb4";
				
				meta.Source = "Orders";
				meta.Destination = "Orders";
				
				meta.spInsert = "proc_OrdersInsert";				
				meta.spUpdate = "proc_OrdersUpdate";		
				meta.spDelete = "proc_OrdersDelete";
				meta.spLoadAll = "proc_OrdersLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrdersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
