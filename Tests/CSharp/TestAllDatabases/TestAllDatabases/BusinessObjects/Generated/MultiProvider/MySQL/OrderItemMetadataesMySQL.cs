/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:09 AM
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
		static private int RegisterDelegateesMySQL()
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
				meta.Catalog = "foreignkeytest";
				
				meta.Source = "orderitem";
				meta.Destination = "orderitem";
				
				meta.spInsert = "proc_orderitemInsert";				
				meta.spUpdate = "proc_orderitemUpdate";		
				meta.spDelete = "proc_orderitemDelete";
				meta.spLoadAll = "proc_orderitemLoadAll";
				meta.spLoadByPrimaryKey = "proc_orderitemLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
