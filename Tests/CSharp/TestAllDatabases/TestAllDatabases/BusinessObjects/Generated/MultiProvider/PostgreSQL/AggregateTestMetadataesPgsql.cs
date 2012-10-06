/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 3/17/2012 4:45:07 AM
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
		static private int RegisterDelegateesPgsql()
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
				

				meta.AddTypeMap("Id", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("int4", "System.Int32"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("int4", "System.Int32"));
				meta.AddTypeMap("HireDate", new esTypeMap("timestamp", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("bool", "System.Boolean"));

				meta["AutoKeyText"] = @"nextval('""AggregateTest_ID_seq""'::regclass)";				
				meta.Catalog = "AggregateDb";
				meta.Schema = "public";
				meta.Source = "AggregateTest";
				meta.Destination = "AggregateTest";
				
				meta.spInsert = "proc_AggregateTestInsert";				
				meta.spUpdate = "proc_AggregateTestUpdate";		
				meta.spDelete = "proc_AggregateTestDelete";
				meta.spLoadAll = "proc_AggregateTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_AggregateTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
