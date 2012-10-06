/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:58 AM
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
		static private int RegisterDelegateesOracle()
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
				

				meta.AddTypeMap("Id", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("FirstName", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("HireDate", new esTypeMap("TIMESTAMP", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("NUMBER", "System.Decimal"));
				meta["AutoKeyText"] = "SEQ_ID";				
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				meta.Source = "AggregateTest";
				meta.Destination = "AggregateTest";
				
				meta.spInsert = "esAggregateTestInsert";				
				meta.spUpdate = "esAggregateTestUpdate";		
				meta.spDelete = "esAggregateTestDelete";
				meta.spLoadAll = "esAggregateTestLoadAll";
				meta.spLoadByPrimaryKey = "esAggregateTestLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
