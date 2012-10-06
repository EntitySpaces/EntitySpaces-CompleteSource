/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Sybase
Date Generated       : 3/17/2012 4:45:27 AM
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
		static private int RegisterDelegateesSybase()
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
				

				meta.AddTypeMap("EmpID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("TerrID", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "DBA";
				meta.Source = "EmployeeTerritory";
				meta.Destination = "EmployeeTerritory";
				
				meta.spInsert = "proc_EmployeeTerritoryInsert";				
				meta.spUpdate = "proc_EmployeeTerritoryUpdate";		
				meta.spDelete = "proc_EmployeeTerritoryDelete";
				meta.spLoadAll = "proc_EmployeeTerritoryLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeTerritoryLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
