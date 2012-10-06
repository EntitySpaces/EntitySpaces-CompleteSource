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
    public partial class OrderDetailsMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
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
				meta.AddTypeMap("ProductID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("Quantity", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("Discount", new esTypeMap("DOUBLE", "System.Double"));				
				meta.Catalog = "northwind";
				
				meta.Source = "order details";
				meta.Destination = "order details";
				
				meta.spInsert = "proc_order detailsInsert";				
				meta.spUpdate = "proc_order detailsUpdate";		
				meta.spDelete = "proc_order detailsDelete";
				meta.spLoadAll = "proc_order detailsLoadAll";
				meta.spLoadByPrimaryKey = "proc_order detailsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
