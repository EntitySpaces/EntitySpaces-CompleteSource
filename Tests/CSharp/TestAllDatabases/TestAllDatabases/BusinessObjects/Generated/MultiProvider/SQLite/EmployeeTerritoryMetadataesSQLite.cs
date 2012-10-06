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
    public partial class EmployeeTerritoryMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSQLite()
		{
			// This is only executed once per the life of the application
			lock (typeof(EmployeeTerritoryMetadata))
			{
				if(EmployeeTerritoryMetadata.mapDelegates == null)
				{
					EmployeeTerritoryMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EmployeeTerritoryMetadata.meta == null)
				{
					EmployeeTerritoryMetadata.meta = new EmployeeTerritoryMetadata();
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
				

				meta.AddTypeMap("EmpID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("TerrID", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "main";
				
				meta.Source = "EmployeeTerritory";
				meta.Destination = "EmployeeTerritory";
				
				meta.spInsert = "proc_EmployeeTerritoryInsert";				
				meta.spUpdate = "proc_EmployeeTerritoryUpdate";		
				meta.spDelete = "proc_EmployeeTerritoryDelete";
				meta.spLoadAll = "proc_EmployeeTerritoryLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeTerritoryLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSQLite"] = meta;
			}
			
			return m_providerMetadataMaps["esSQLite"];
		}
		
		static private int _esSQLite = RegisterDelegateesSQLite();
    }
}
