/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:59 AM
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
		static private int RegisterDelegateesOracle()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esOracle);
				mapDelegates.Add("esOracle", mapMethod);
				mapMethod("esOracle");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esOracle(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("LastName", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("FirstName", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("Supervisor", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("Age", new esTypeMap("NUMBER", "System.Decimal"));
				meta["AutoKeyText"] = "seq_Employee";				
				meta.Catalog = "HIERARCHICAL";
				meta.Schema = "HIERARCHICAL";
				meta.Source = "Employee";
				meta.Destination = "Employee";
				
				meta.spInsert = "esEmployeeInsert";				
				meta.spUpdate = "esEmployeeUpdate";		
				meta.spDelete = "esEmployeeDelete";
				meta.spLoadAll = "esEmployeeLoadAll";
				meta.spLoadByPrimaryKey = "esEmployeeLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
