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
    public partial class OracleDataTypesMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
		{
			// This is only executed once per the life of the application
			lock (typeof(OracleDataTypesMetadata))
			{
				if(OracleDataTypesMetadata.mapDelegates == null)
				{
					OracleDataTypesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OracleDataTypesMetadata.meta == null)
				{
					OracleDataTypesMetadata.meta = new OracleDataTypesMetadata();
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
				

				meta.AddTypeMap("CharType", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("IntegerType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("SmallIntType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("DecimalType", new esTypeMap("NUMBER", "System.Decimal"));
				meta.AddTypeMap("FloatType", new esTypeMap("FLOAT", "System.Decimal"));
				meta.AddTypeMap("DoubleType", new esTypeMap("FLOAT", "System.Decimal"));
				meta.AddTypeMap("RealType", new esTypeMap("FLOAT", "System.Decimal"));
				meta.AddTypeMap("NumberType", new esTypeMap("NUMBER", "System.Decimal"));				
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				meta.Source = "OracleDataTypes";
				meta.Destination = "OracleDataTypes";
				
				meta.spInsert = "esOracleDataTypesInsert";				
				meta.spUpdate = "esOracleDataTypesUpdate";		
				meta.spDelete = "esOracleDataTypesDelete";
				meta.spLoadAll = "esOracleDataTypesLoadAll";
				meta.spLoadByPrimaryKey = "esOracleDataTypesLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
