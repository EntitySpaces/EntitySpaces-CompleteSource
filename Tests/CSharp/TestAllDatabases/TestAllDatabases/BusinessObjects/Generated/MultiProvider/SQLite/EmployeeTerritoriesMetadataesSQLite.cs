/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLite
Date Generated       : 3/17/2012 4:45:16 AM
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
    public partial class EmployeeTerritoriesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSQLite()
		{
			// This is only executed once per the life of the application
			lock (typeof(EmployeeTerritoriesMetadata))
			{
				if(EmployeeTerritoriesMetadata.mapDelegates == null)
				{
					EmployeeTerritoriesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EmployeeTerritoriesMetadata.meta == null)
				{
					EmployeeTerritoriesMetadata.meta = new EmployeeTerritoriesMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSQLite);
				mapDelegates.Add("esSQLite", mapMethod);
				mapMethod("esSQLite");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSQLite(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("TerritoryID", new esTypeMap("nvarchar", "System.String"));				
				meta.Catalog = "main";
				
				meta.Source = "EmployeeTerritories";
				meta.Destination = "EmployeeTerritories";
				
				meta.spInsert = "proc_EmployeeTerritoriesInsert";				
				meta.spUpdate = "proc_EmployeeTerritoriesUpdate";		
				meta.spDelete = "proc_EmployeeTerritoriesDelete";
				meta.spLoadAll = "proc_EmployeeTerritoriesLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeTerritoriesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSQLite"] = meta;
			}
			
			return m_providerMetadataMaps["esSQLite"];
		}
		
		static private int _esSQLite = RegisterDelegateesSQLite();
    }
}
