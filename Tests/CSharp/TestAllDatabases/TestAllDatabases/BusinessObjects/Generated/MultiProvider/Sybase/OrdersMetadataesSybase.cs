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
    public partial class OrdersMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSybase()
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
				

				meta.AddTypeMap("OrderID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("CustomerID", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("OrderDate", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("RequiredDate", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("ShippedDate", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("ShipVia", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("Freight", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("ShipName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipAddress", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipCity", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipRegion", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipCountry", new esTypeMap("nvarchar", "System.String"));				
				meta.Catalog = "Northwind";
				meta.Schema = "DBA";
				meta.Source = "Orders";
				meta.Destination = "Orders";
				
				meta.spInsert = "proc_OrdersInsert";				
				meta.spUpdate = "proc_OrdersUpdate";		
				meta.spDelete = "proc_OrdersDelete";
				meta.spLoadAll = "proc_OrdersLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrdersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
