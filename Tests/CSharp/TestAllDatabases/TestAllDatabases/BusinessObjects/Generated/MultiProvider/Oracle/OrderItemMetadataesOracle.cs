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
    public partial class OrderItemMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
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
				

				meta.AddTypeMap("OrderID", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("ProductID", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("Quantity", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("Discount", new esTypeMap("NUMBER", "System.Decimal"));				
				meta.Catalog = "HIERARCHICAL";
				meta.Schema = "HIERARCHICAL";
				meta.Source = "OrderItem";
				meta.Destination = "OrderItem";
				
				meta.spInsert = "esOrderItemInsert";				
				meta.spUpdate = "esOrderItemUpdate";		
				meta.spDelete = "esOrderItemDelete";
				meta.spLoadAll = "esOrderItemLoadAll";
				meta.spLoadByPrimaryKey = "esOrderItemLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
