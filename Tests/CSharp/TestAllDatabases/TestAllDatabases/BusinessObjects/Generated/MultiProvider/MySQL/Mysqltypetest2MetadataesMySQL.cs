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
    public partial class Mysqltypetest2Metadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(Mysqltypetest2Metadata))
			{
				if(Mysqltypetest2Metadata.mapDelegates == null)
				{
					Mysqltypetest2Metadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (Mysqltypetest2Metadata.meta == null)
				{
					Mysqltypetest2Metadata.meta = new Mysqltypetest2Metadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("INT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("CharType", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("TimeStampType", new esTypeMap("TIMESTAMP", "System.DateTime"));
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"));
				meta.AddTypeMap("DateTimeType", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("BlobType", new esTypeMap("BLOB", "System.Byte[]"));
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"));
				meta.AddTypeMap("TimeType", new esTypeMap("TIME", "System.TimeSpan"));
				meta.AddTypeMap("LongTextType", new esTypeMap("LONGTEXT", "System.String"));
				meta.AddTypeMap("BinaryType", new esTypeMap("BINARY", "System.String"));
				meta.AddTypeMap("VarBinaryType", new esTypeMap("VARBINARY", "System.String"));				
				meta.Catalog = "aggregatedb";
				
				meta.Source = "mysqltypetest2";
				meta.Destination = "mysqltypetest2";
				
				meta.spInsert = "proc_mysqltypetest2Insert";				
				meta.spUpdate = "proc_mysqltypetest2Update";		
				meta.spDelete = "proc_mysqltypetest2Delete";
				meta.spLoadAll = "proc_mysqltypetest2LoadAll";
				meta.spLoadByPrimaryKey = "proc_mysqltypetest2LoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
