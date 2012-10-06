/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:59 AM
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
    public partial class OrderDetailsMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlCe4()
		{
			// This is only executed once per the life of the application
			lock (typeof(OrderDetailsMetadata))
			{
				if(OrderDetailsMetadata.mapDelegates == null)
				{
					OrderDetailsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrderDetailsMetadata.meta == null)
				{
					OrderDetailsMetadata.meta = new OrderDetailsMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlCe4);
				mapDelegates.Add("esSqlCe4", mapMethod);
				mapMethod("esSqlCe4");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlCe4(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("OrderID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Quantity", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("Discount", new esTypeMap("real", "System.Single"));				
				meta.Catalog = "Northwind.sdf";
				
				meta.Source = "Order Details";
				meta.Destination = "Order Details";
				
				meta.spInsert = "proc_Order DetailsInsert";				
				meta.spUpdate = "proc_Order DetailsUpdate";		
				meta.spDelete = "proc_Order DetailsDelete";
				meta.spLoadAll = "proc_Order DetailsLoadAll";
				meta.spLoadByPrimaryKey = "proc_Order DetailsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe4"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe4"];
		}
		
		static private int _esSqlCe4 = RegisterDelegateesSqlCe4();
    }
}
