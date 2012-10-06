/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:34 AM
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
    public partial class ProductsMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesAccess()
		{
			// This is only executed once per the life of the application
			lock (typeof(ProductsMetadata))
			{
				if(ProductsMetadata.mapDelegates == null)
				{
					ProductsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductsMetadata.meta == null)
				{
					ProductsMetadata.meta = new ProductsMetadata();
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
				

				meta.AddTypeMap("ProductID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("ProductName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("SupplierID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("CategoryID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("Currency", "System.Decimal"));
				meta.AddTypeMap("UnitsInStock", new esTypeMap("Integer", "System.Int16"));
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("Integer", "System.Int16"));
				meta.AddTypeMap("ReorderLevel", new esTypeMap("Integer", "System.Int16"));
				meta.AddTypeMap("Discontinued", new esTypeMap("Yes/No", "System.Boolean"));				
				meta.Catalog = "Northwind.mdb";
				
				meta.Source = "Products";
				meta.Destination = "Products";
				
				meta.spInsert = "proc_ProductsInsert";				
				meta.spUpdate = "proc_ProductsUpdate";		
				meta.spDelete = "proc_ProductsDelete";
				meta.spLoadAll = "proc_ProductsLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
