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
    public partial class ProductsMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesVistaDB4()
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
				

				meta.AddTypeMap("ProductID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("ProductName", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("SupplierID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("CategoryID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("UnitPrice", new esTypeMap("Money", "System.Decimal"));
				meta.AddTypeMap("UnitsInStock", new esTypeMap("SmallInt", "System.Int16"));
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("SmallInt", "System.Int16"));
				meta.AddTypeMap("ReorderLevel", new esTypeMap("SmallInt", "System.Int16"));
				meta.AddTypeMap("Discontinued", new esTypeMap("Bit", "System.Boolean"));				
				meta.Catalog = "Northwind.vdb4";
				
				meta.Source = "Products";
				meta.Destination = "Products";
				
				meta.spInsert = "proc_ProductsInsert";				
				meta.spUpdate = "proc_ProductsUpdate";		
				meta.spDelete = "proc_ProductsDelete";
				meta.spLoadAll = "proc_ProductsLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductsLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
