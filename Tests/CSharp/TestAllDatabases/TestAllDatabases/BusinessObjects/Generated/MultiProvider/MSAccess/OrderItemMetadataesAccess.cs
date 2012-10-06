/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:26 AM
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
    public partial class OrderItemMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesAccess()
		{
			// This is only executed once per the life of the application
			lock (typeof(OrderItemMetadata))
			{
				if(OrderItemMetadata.mapDelegates == null)
				{
					OrderItemMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrderItemMetadata.meta == null)
				{
					OrderItemMetadata.meta = new OrderItemMetadata();
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
				meta.AddTypeMap("ProductID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("Currency", "System.Decimal"));
				meta.AddTypeMap("Quantity", new esTypeMap("Integer", "System.Int16"));
				meta.AddTypeMap("Discount", new esTypeMap("Single", "System.Single"));				
				meta.Catalog = "ForeignKeyTest.mdb";
				
				meta.Source = "OrderItem";
				meta.Destination = "OrderItem";
				
				meta.spInsert = "proc_OrderItemInsert";				
				meta.spUpdate = "proc_OrderItemUpdate";		
				meta.spDelete = "proc_OrderItemDelete";
				meta.spLoadAll = "proc_OrderItemLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrderItemLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
