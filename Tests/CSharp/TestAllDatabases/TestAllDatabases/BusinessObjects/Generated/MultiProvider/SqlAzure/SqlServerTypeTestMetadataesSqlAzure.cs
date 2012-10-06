/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLAzure
Date Generated       : 3/17/2012 4:46:59 AM
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
    public partial class SqlServerTypeTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlAzure()
		{
			// This is only executed once per the life of the application
			lock (typeof(SqlServerTypeTestMetadata))
			{
				if(SqlServerTypeTestMetadata.mapDelegates == null)
				{
					SqlServerTypeTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (SqlServerTypeTestMetadata.meta == null)
				{
					SqlServerTypeTestMetadata.meta = new SqlServerTypeTestMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlAzure);
				mapDelegates.Add("esSqlAzure", mapMethod);
				mapMethod("esSqlAzure");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlAzure(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte[]"));
				meta.AddTypeMap("NVarCharType", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("NumericType", new esTypeMap("numeric", "System.Decimal"));
				meta.AddTypeMap("RealType", new esTypeMap("real", "System.Single"));
				meta.AddTypeMap("FloatType", new esTypeMap("float", "System.Double"));
				meta.AddTypeMap("DecimalType", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("VarCharMaxType", new esTypeMap("text", "System.String"));
				meta.AddTypeMap("BigIntType", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("NCharType", new esTypeMap("nchar", "System.Char"));				
				meta.Catalog = "AggregateDB";
				meta.Schema = "dbo";
				meta.Source = "SqlServerTypeTest";
				meta.Destination = "SqlServerTypeTest";
				
				meta.spInsert = "proc_SqlServerTypeTestInsert";				
				meta.spUpdate = "proc_SqlServerTypeTestUpdate";		
				meta.spDelete = "proc_SqlServerTypeTestDelete";
				meta.spLoadAll = "proc_SqlServerTypeTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_SqlServerTypeTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlAzure"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlAzure"];
		}
		
		static private int _esSqlAzure = RegisterDelegateesSqlAzure();
    }
}
