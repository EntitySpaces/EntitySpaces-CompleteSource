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
    public partial class EmployeesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
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
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("LastName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Title", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("TitleOfCourtesy", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("BirthDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("HireDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("Address", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Region", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Country", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("HomePhone", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Extension", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Photo", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("LONGTEXT", "System.String"));
				meta.AddTypeMap("ReportsTo", new esTypeMap("INT", "System.Int32"));				
				meta.Catalog = "northwind";
				
				meta.Source = "employees";
				meta.Destination = "employees";
				
				meta.spInsert = "proc_employeesInsert";				
				meta.spUpdate = "proc_employeesUpdate";		
				meta.spDelete = "proc_employeesDelete";
				meta.spLoadAll = "proc_employeesLoadAll";
				meta.spLoadByPrimaryKey = "proc_employeesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
