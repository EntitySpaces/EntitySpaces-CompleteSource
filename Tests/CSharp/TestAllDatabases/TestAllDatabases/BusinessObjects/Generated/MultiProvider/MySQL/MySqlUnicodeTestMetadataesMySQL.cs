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
    public partial class MySqlUnicodeTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(MySqlUnicodeTestMetadata))
			{
				if(MySqlUnicodeTestMetadata.mapDelegates == null)
				{
					MySqlUnicodeTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (MySqlUnicodeTestMetadata.meta == null)
				{
					MySqlUnicodeTestMetadata.meta = new MySqlUnicodeTestMetadata();
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
				

				meta.AddTypeMap("TypeID", new esTypeMap("INT UNSIGNED", "System.UInt32"));
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"));				
				meta.Catalog = "aggregatedb";
				
				meta.Source = "mysqlunicodetest";
				meta.Destination = "mysqlunicodetest";
				
				meta.spInsert = "proc_mysqlunicodetestInsert";				
				meta.spUpdate = "proc_mysqlunicodetestUpdate";		
				meta.spDelete = "proc_mysqlunicodetestDelete";
				meta.spLoadAll = "proc_mysqlunicodetestLoadAll";
				meta.spLoadByPrimaryKey = "proc_mysqlunicodetestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
