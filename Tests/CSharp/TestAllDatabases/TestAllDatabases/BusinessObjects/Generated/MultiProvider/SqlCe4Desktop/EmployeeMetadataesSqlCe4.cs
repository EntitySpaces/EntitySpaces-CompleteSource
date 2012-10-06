/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:58 AM
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
		static private int RegisterDelegateesSqlCe4()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlCe4);
				mapDelegates.Add("esSqlCe4", mapMethod);
				mapMethod("esSqlCe4");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlCe4(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("LastName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Supervisor", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"));				
				meta.Catalog = "ForeignKeyTest.sdf";
				
				meta.Source = "Employee";
				meta.Destination = "Employee";
				
				meta.spInsert = "proc_EmployeeInsert";				
				meta.spUpdate = "proc_EmployeeUpdate";		
				meta.spDelete = "proc_EmployeeDelete";
				meta.spLoadAll = "proc_EmployeeLoadAll";
				meta.spLoadByPrimaryKey = "proc_EmployeeLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe4"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe4"];
		}
		
		static private int _esSqlCe4 = RegisterDelegateesSqlCe4();
    }
}
