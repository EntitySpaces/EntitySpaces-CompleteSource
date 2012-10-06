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
    public partial class ShippersMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(ShippersMetadata))
			{
				if(ShippersMetadata.mapDelegates == null)
				{
					ShippersMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ShippersMetadata.meta == null)
				{
					ShippersMetadata.meta = new ShippersMetadata();
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
				

				meta.AddTypeMap("ShipperID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("CompanyName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("VARCHAR", "System.String"));				
				meta.Catalog = "northwind";
				
				meta.Source = "shippers";
				meta.Destination = "shippers";
				
				meta.spInsert = "proc_shippersInsert";				
				meta.spUpdate = "proc_shippersUpdate";		
				meta.spDelete = "proc_shippersDelete";
				meta.spLoadAll = "proc_shippersLoadAll";
				meta.spLoadByPrimaryKey = "proc_shippersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
