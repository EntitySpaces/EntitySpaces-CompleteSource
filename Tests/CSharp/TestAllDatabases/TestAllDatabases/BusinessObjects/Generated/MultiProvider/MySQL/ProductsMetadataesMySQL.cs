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
    public partial class ProductsMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
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
				

				meta.AddTypeMap("ProductID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("ProductName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("SupplierID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("CategoryID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("UnitsInStock", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("ReorderLevel", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("Discontinued", new esTypeMap("TINYINT UNSIGNED", "System.Byte"));				
				meta.Catalog = "northwind";
				
				meta.Source = "products";
				meta.Destination = "products";
				
				meta.spInsert = "proc_productsInsert";				
				meta.spUpdate = "proc_productsUpdate";		
				meta.spDelete = "proc_productsDelete";
				meta.spLoadAll = "proc_productsLoadAll";
				meta.spLoadByPrimaryKey = "proc_productsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
