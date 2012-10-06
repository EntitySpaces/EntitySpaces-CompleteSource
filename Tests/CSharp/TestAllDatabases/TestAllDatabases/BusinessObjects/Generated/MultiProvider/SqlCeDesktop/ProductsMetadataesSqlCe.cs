/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:51 AM
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
		static private int RegisterDelegateesSqlCe()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlCe);
				mapDelegates.Add("esSqlCe", mapMethod);
				mapMethod("esSqlCe");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlCe(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("SupplierID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("CategoryID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ProductName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("EnglishName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("UnitsInStock", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("ReorderLevel", new esTypeMap("smallint", "System.Int16"));
				meta.AddTypeMap("Discontinued", new esTypeMap("bit", "System.Boolean"));				
				meta.Catalog = "Northwind.sdf";
				
				meta.Source = "Products";
				meta.Destination = "Products";
				
				meta.spInsert = "proc_ProductsInsert";				
				meta.spUpdate = "proc_ProductsUpdate";		
				meta.spDelete = "proc_ProductsDelete";
				meta.spLoadAll = "proc_ProductsLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe"];
		}
		
		static private int _esSqlCe = RegisterDelegateesSqlCe();
    }
}
