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
    public partial class CategoriesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(CategoriesMetadata))
			{
				if(CategoriesMetadata.mapDelegates == null)
				{
					CategoriesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CategoriesMetadata.meta == null)
				{
					CategoriesMetadata.meta = new CategoriesMetadata();
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
				

				meta.AddTypeMap("CategoryID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("CategoryName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("LONGTEXT", "System.String"));
				meta.AddTypeMap("Picture", new esTypeMap("LONGBLOB", "System.Byte[]"));				
				meta.Catalog = "northwind";
				
				meta.Source = "categories";
				meta.Destination = "categories";
				
				meta.spInsert = "proc_categoriesInsert";				
				meta.spUpdate = "proc_categoriesUpdate";		
				meta.spDelete = "proc_categoriesDelete";
				meta.spLoadAll = "proc_categoriesLoadAll";
				meta.spLoadByPrimaryKey = "proc_categoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
