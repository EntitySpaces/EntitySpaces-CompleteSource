/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:27 AM
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
    public partial class ProductMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesAccess()
		{
			// This is only executed once per the life of the application
			lock (typeof(ProductMetadata))
			{
				if(ProductMetadata.mapDelegates == null)
				{
					ProductMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductMetadata.meta == null)
				{
					ProductMetadata.meta = new ProductMetadata();
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
				meta.AddTypeMap("UnitPrice", new esTypeMap("Currency", "System.Decimal"));
				meta.AddTypeMap("Discontinued", new esTypeMap("Yes/No", "System.Boolean"));				
				meta.Catalog = "ForeignKeyTest.mdb";
				
				meta.Source = "Product";
				meta.Destination = "Product";
				
				meta.spInsert = "proc_ProductInsert";				
				meta.spUpdate = "proc_ProductUpdate";		
				meta.spDelete = "proc_ProductDelete";
				meta.spLoadAll = "proc_ProductLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
