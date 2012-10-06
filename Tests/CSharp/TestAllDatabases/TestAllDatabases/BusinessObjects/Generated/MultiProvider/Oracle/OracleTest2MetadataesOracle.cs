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
    public partial class OracleTest2Metadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
		{
			// This is only executed once per the life of the application
			lock (typeof(OracleTest2Metadata))
			{
				if(OracleTest2Metadata.mapDelegates == null)
				{
					OracleTest2Metadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OracleTest2Metadata.meta == null)
				{
					OracleTest2Metadata.meta = new OracleTest2Metadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("NumberType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("DecimalType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("BoolType", new esTypeMap("NUMBER", "System.Decimal"));				
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				meta.Source = "OracleTest2";
				meta.Destination = "OracleTest2";
				
				meta.spInsert = "esOracleTest2Insert";				
				meta.spUpdate = "esOracleTest2Update";		
				meta.spDelete = "esOracleTest2Delete";
				meta.spLoadAll = "esOracleTest2LoadAll";
				meta.spLoadByPrimaryKey = "esOracleTest2LoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
