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
    public partial class OrderMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesVistaDB4()
		{
			// This is only executed once per the life of the application
			lock (typeof(OrderMetadata))
			{
				if(OrderMetadata.mapDelegates == null)
				{
					OrderMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrderMetadata.meta == null)
				{
					OrderMetadata.meta = new OrderMetadata();
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
				meta.AddTypeMap("CustID", new esTypeMap("Char", "System.String"));
				meta.AddTypeMap("CustSub", new esTypeMap("Char", "System.String"));
				meta.AddTypeMap("PlacedBy", new esTypeMap("VarChar", "System.String"));
				meta.AddTypeMap("OrderDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("BigInt", "System.Int64"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("Int", "System.Int32"));				
				meta.Catalog = "ForeignKeyTest.vdb4";
				
				meta.Source = "Order";
				meta.Destination = "Order";
				
				meta.spInsert = "proc_OrderInsert";				
				meta.spUpdate = "proc_OrderUpdate";		
				meta.spDelete = "proc_OrderDelete";
				meta.spLoadAll = "proc_OrderLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrderLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
