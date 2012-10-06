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
    public partial class CategoriesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesVistaDB4()
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
				

				meta.AddTypeMap("CategoryID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("CategoryName", new esTypeMap("NVarChar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("NText", "System.String"));
				meta.AddTypeMap("Picture", new esTypeMap("Image", "System.Byte[]"));				
				meta.Catalog = "Northwind.vdb4";
				
				meta.Source = "Categories";
				meta.Destination = "Categories";
				
				meta.spInsert = "proc_CategoriesInsert";				
				meta.spUpdate = "proc_CategoriesUpdate";		
				meta.spDelete = "proc_CategoriesDelete";
				meta.spLoadAll = "proc_CategoriesLoadAll";
				meta.spLoadByPrimaryKey = "proc_CategoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
