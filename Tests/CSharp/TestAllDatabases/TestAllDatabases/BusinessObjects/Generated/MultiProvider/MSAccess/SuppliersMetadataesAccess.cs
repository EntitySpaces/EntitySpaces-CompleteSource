/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:36 AM
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
		static private int RegisterDelegateesAccess()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esAccess);
				mapDelegates.Add("esAccess", mapMethod);
				mapMethod("esAccess");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esAccess(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("SupplierID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("CompanyName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("ContactName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("ContactTitle", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Address", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Region", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Country", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Fax", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("HomePage", new esTypeMap("Hyperlink", "System.String"));				
				meta.Catalog = "Northwind.mdb";
				
				meta.Source = "Suppliers";
				meta.Destination = "Suppliers";
				
				meta.spInsert = "proc_SuppliersInsert";				
				meta.spUpdate = "proc_SuppliersUpdate";		
				meta.spDelete = "proc_SuppliersDelete";
				meta.spLoadAll = "proc_SuppliersLoadAll";
				meta.spLoadByPrimaryKey = "proc_SuppliersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
