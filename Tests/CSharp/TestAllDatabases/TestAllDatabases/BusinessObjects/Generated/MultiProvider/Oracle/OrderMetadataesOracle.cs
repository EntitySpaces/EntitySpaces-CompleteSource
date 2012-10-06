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
    public partial class OrderMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
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
				meta.AddTypeMap("CustID", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("CustSub", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("PlacedBy", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("OrderDate", new esTypeMap("TIMESTAMP", "System.DateTime"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("NUMBER", "System.Decimal"));
				meta["AutoKeyText"] = "seq_Order";				
				meta.Catalog = "HIERARCHICAL";
				meta.Schema = "HIERARCHICAL";
				meta.Source = "Order";
				meta.Destination = "Order";
				
				meta.spInsert = "esOrderInsert";				
				meta.spUpdate = "esOrderUpdate";		
				meta.spDelete = "esOrderDelete";
				meta.spLoadAll = "esOrderLoadAll";
				meta.spLoadByPrimaryKey = "esOrderLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
