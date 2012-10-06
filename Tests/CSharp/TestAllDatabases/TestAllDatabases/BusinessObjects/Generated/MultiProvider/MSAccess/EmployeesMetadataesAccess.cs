/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:31 AM
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
		static private int RegisterDelegateesAccess()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esAccess);
				mapDelegates.Add("esAccess", mapMethod);
				mapMethod("esAccess");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esAccess(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("LastName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Title", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("TitleOfCourtesy", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("BirthDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("HireDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("Address", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("City", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Region", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("PostalCode", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Country", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("HomePhone", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Extension", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Photo", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("Memo", "System.String"));
				meta.AddTypeMap("ReportsTo", new esTypeMap("Long", "System.Int32"));				
				meta.Catalog = "Northwind.mdb";
				
				meta.Source = "Employees";
				meta.Destination = "Employees";
				
				meta.spInsert = "proc_EmployeesInsert";				
				meta.spUpdate = "proc_EmployeesUpdate";		
				meta.spDelete = "proc_EmployeesDelete";
				meta.spLoadAll = "proc_EmployeesLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeesLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
