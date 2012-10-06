/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:28 AM
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
		static private int RegisterDelegateesSybase()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSybase);
				mapDelegates.Add("esSybase", mapMethod);
				mapMethod("esSybase");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSybase(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("ShipperID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("CompanyName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"));				
				meta.Catalog = "Northwind";
				meta.Schema = "DBA";
				meta.Source = "Shippers";
				meta.Destination = "Shippers";
				
				meta.spInsert = "proc_ShippersInsert";				
				meta.spUpdate = "proc_ShippersUpdate";		
				meta.spDelete = "proc_ShippersDelete";
				meta.spLoadAll = "proc_ShippersLoadAll";
				meta.spLoadByPrimaryKey = "proc_ShippersLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
