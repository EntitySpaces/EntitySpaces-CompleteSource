/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:51 AM
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
		static private int RegisterDelegateesSqlCe()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlCe);
				mapDelegates.Add("esSqlCe", mapMethod);
				mapMethod("esSqlCe");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlCe(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("OrderID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Quantity", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("Discount", new esTypeMap("real", "System.Single"));				
				meta.Catalog = "ForeignKeyTest.sdf";
				
				meta.Source = "OrderItem";
				meta.Destination = "OrderItem";
				
				meta.spInsert = "proc_OrderItemInsert";				
				meta.spUpdate = "proc_OrderItemUpdate";		
				meta.spDelete = "proc_OrderItemDelete";
				meta.spLoadAll = "proc_OrderItemLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrderItemLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe"];
		}
		
		static private int _esSqlCe = RegisterDelegateesSqlCe();
    }
}
