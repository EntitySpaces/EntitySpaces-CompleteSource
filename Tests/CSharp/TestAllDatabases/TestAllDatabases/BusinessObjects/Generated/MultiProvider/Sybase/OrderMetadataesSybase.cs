/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:27 AM
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
		static private int RegisterDelegateesSybase()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSybase);
				mapDelegates.Add("esSybase", mapMethod);
				mapMethod("esSybase");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSybase(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("OrderID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("CustID", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("CustSub", new esTypeMap("char", "System.String"));
				meta.AddTypeMap("PlacedBy", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("OrderDate", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("varbinary", "System.Byte[]"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "DBA";
				meta.Source = "Order";
				meta.Destination = "Order";
				
				meta.spInsert = "proc_OrderInsert";				
				meta.spUpdate = "proc_OrderUpdate";		
				meta.spDelete = "proc_OrderDelete";
				meta.spLoadAll = "proc_OrderLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrderLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
