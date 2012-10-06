/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:06 AM
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
    public partial class AggregateTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(AggregateTestMetadata))
			{
				if(AggregateTestMetadata.mapDelegates == null)
				{
					AggregateTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AggregateTestMetadata.meta == null)
				{
					AggregateTestMetadata.meta = new AggregateTestMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("FirstName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("HireDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("TINYINT UNSIGNED", "System.Byte"));				
				meta.Catalog = "aggregatedb";
				
				meta.Source = "aggregatetest";
				meta.Destination = "aggregatetest";
				
				meta.spInsert = "proc_aggregatetestInsert";				
				meta.spUpdate = "proc_aggregatetestUpdate";		
				meta.spDelete = "proc_aggregatetestDelete";
				meta.spLoadAll = "proc_aggregatetestLoadAll";
				meta.spLoadByPrimaryKey = "proc_aggregatetestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
