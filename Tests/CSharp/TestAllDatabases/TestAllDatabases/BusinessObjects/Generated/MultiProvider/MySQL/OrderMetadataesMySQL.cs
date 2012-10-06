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
    public partial class OrderMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
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
				meta.AddTypeMap("CustID", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("CustSub", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("PlacedBy", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("OrderDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"));				
				meta.Catalog = "foreignkeytest";
				
				meta.Source = "order";
				meta.Destination = "order";
				
				meta.spInsert = "proc_orderInsert";				
				meta.spUpdate = "proc_orderUpdate";		
				meta.spDelete = "proc_orderDelete";
				meta.spLoadAll = "proc_orderLoadAll";
				meta.spLoadByPrimaryKey = "proc_orderLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
