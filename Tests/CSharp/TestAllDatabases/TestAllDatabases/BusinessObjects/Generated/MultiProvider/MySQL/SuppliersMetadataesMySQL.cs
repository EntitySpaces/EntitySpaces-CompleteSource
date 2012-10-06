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
    public partial class SuppliersMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(SuppliersMetadata))
			{
				if(SuppliersMetadata.mapDelegates == null)
				{
					SuppliersMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SuppliersMetadata.meta == null)
				{
					SuppliersMetadata.meta = new SuppliersMetadata();
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
				

				meta.AddTypeMap("SupplierID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("CompanyName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("ContactName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("ContactTitle", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Region", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Country", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Fax", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("HomePage", new esTypeMap("LONGTEXT", "System.String"));				
				meta.Catalog = "northwind";
				
				meta.Source = "suppliers";
				meta.Destination = "suppliers";
				
				meta.spInsert = "proc_suppliersInsert";				
				meta.spUpdate = "proc_suppliersUpdate";		
				meta.spDelete = "proc_suppliersDelete";
				meta.spLoadAll = "proc_suppliersLoadAll";
				meta.spLoadByPrimaryKey = "proc_suppliersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
