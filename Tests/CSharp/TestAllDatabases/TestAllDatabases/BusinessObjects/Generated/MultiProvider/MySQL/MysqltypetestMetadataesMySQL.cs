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
    public partial class MysqltypetestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(MysqltypetestMetadata))
			{
				if(MysqltypetestMetadata.mapDelegates == null)
				{
					MysqltypetestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MysqltypetestMetadata.meta == null)
				{
					MysqltypetestMetadata.meta = new MysqltypetestMetadata();
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
				meta.AddTypeMap("BigIntType", new esTypeMap("BIGINT", "System.Int64"));
				meta.AddTypeMap("IntType", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("MedIntType", new esTypeMap("MEDIUMINT", "System.Int32"));
				meta.AddTypeMap("SmallIntType", new esTypeMap("SMALLINT", "System.Int16"));
				meta.AddTypeMap("TinyIntType", new esTypeMap("TINYINT", "System.SByte"));
				meta.AddTypeMap("BigIntUType", new esTypeMap("BIGINT UNSIGNED", "System.UInt64"));
				meta.AddTypeMap("IntUType", new esTypeMap("INT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("MedIntUType", new esTypeMap("MEDIUMINT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("SmallIntUType", new esTypeMap("SMALLINT UNSIGNED", "System.UInt16"));
				meta.AddTypeMap("TinyIntUType", new esTypeMap("TINYINT UNSIGNED", "System.Byte"));
				meta.AddTypeMap("FloatType", new esTypeMap("FLOAT", "System.Single"));
				meta.AddTypeMap("FloatUType", new esTypeMap("FLOAT UNSIGNED", "System.Single"));
				meta.AddTypeMap("DecType", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("DecUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"));
				meta.AddTypeMap("NumType", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("NumUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"));
				meta.AddTypeMap("DblType", new esTypeMap("DOUBLE", "System.Double"));
				meta.AddTypeMap("DblUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"));
				meta.AddTypeMap("RealType", new esTypeMap("DOUBLE", "System.Double"));
				meta.AddTypeMap("RealUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"));
				meta.AddTypeMap("BitType", new esTypeMap("BIT", "System.SByte"));				
				meta.Catalog = "aggregatedb";
				
				meta.Source = "mysqltypetest";
				meta.Destination = "mysqltypetest";
				
				meta.spInsert = "proc_mysqltypetestInsert";				
				meta.spUpdate = "proc_mysqltypetestUpdate";		
				meta.spDelete = "proc_mysqltypetestDelete";
				meta.spLoadAll = "proc_mysqltypetestLoadAll";
				meta.spLoadByPrimaryKey = "proc_mysqltypetestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
