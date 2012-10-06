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
    public partial class OrderDetailsMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesVistaDB4()
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
				meta.AddTypeMap("ProductID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("Money", "System.Decimal"));
				meta.AddTypeMap("Quantity", new esTypeMap("SmallInt", "System.Int16"));
				meta.AddTypeMap("Discount", new esTypeMap("Real", "System.Single"));				
				meta.Catalog = "Northwind.vdb4";
				
				meta.Source = "Order Details";
				meta.Destination = "Order Details";
				
				meta.spInsert = "proc_Order DetailsInsert";				
				meta.spUpdate = "proc_Order DetailsUpdate";		
				meta.spDelete = "proc_Order DetailsDelete";
				meta.spLoadAll = "proc_Order DetailsLoadAll";
				meta.spLoadByPrimaryKey = "proc_Order DetailsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
