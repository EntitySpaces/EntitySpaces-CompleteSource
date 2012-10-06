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
    public partial class EmployeesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSybase()
		{
			// This is only executed once per the life of the application
			lock (typeof(EmployeesMetadata))
			{
				if(EmployeesMetadata.mapDelegates == null)
				{
					EmployeesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EmployeesMetadata.meta == null)
				{
					EmployeesMetadata.meta = new EmployeesMetadata();
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
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("LastName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Title", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("TitleOfCourtesy", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("BirthDate", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("HireDate", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Region", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Country", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("HomePhone", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Extension", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Photo", new esTypeMap("long binary", "System.Byte[]"));
				meta.AddTypeMap("Notes", new esTypeMap("long nvarchar", "System.String"));
				meta.AddTypeMap("ReportsTo", new esTypeMap("integer", "System.Int32"));
				meta.AddTypeMap("PhotoPath", new esTypeMap("nvarchar", "System.String"));				
				meta.Catalog = "Northwind";
				meta.Schema = "DBA";
				meta.Source = "Employees";
				meta.Destination = "Employees";
				
				meta.spInsert = "proc_EmployeesInsert";				
				meta.spUpdate = "proc_EmployeesUpdate";		
				meta.spDelete = "proc_EmployeesDelete";
				meta.spLoadAll = "proc_EmployeesLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSybase"] = meta;
			}
			
			return m_providerMetadataMaps["esSybase"];
		}
		
		static private int _esSybase = RegisterDelegateesSybase();
    }
}
