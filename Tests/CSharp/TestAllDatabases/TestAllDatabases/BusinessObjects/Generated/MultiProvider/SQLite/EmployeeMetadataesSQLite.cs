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
    public partial class EmployeeMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSQLite()
		{
			// This is only executed once per the life of the application
			lock (typeof(EmployeeMetadata))
			{
				if(EmployeeMetadata.mapDelegates == null)
				{
					EmployeeMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EmployeeMetadata.meta == null)
				{
					EmployeeMetadata.meta = new EmployeeMetadata();
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
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Supervisor", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("Age", new esTypeMap("integer", "System.Int32"));				
				meta.Catalog = "main";
				
				meta.Source = "Employee";
				meta.Destination = "Employee";
				
				meta.spInsert = "proc_EmployeeInsert";				
				meta.spUpdate = "proc_EmployeeUpdate";		
				meta.spDelete = "proc_EmployeeDelete";
				meta.spLoadAll = "proc_EmployeeLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSQLite"] = meta;
			}
			
			return m_providerMetadataMaps["esSQLite"];
		}
		
		static private int _esSQLite = RegisterDelegateesSQLite();
    }
}
