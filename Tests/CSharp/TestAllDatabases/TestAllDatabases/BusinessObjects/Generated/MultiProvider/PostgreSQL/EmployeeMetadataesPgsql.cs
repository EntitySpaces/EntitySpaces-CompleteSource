/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 3/17/2012 4:45:08 AM
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
		static private int RegisterDelegateesPgsql()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esPgsql);
				mapDelegates.Add("esPgsql", mapMethod);
				mapMethod("esPgsql");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esPgsql(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Supervisor", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("Age", new esTypeMap("int4", "System.Int32"));

				meta["AutoKeyText"] = @"nextval('""Employee_EmployeeID_seq""'::regclass)";				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "public";
				meta.Source = "Employee";
				meta.Destination = "Employee";
				
				meta.spInsert = "proc_EmployeeInsert";				
				meta.spUpdate = "proc_EmployeeUpdate";		
				meta.spDelete = "proc_EmployeeDelete";
				meta.spLoadAll = "proc_EmployeeLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
