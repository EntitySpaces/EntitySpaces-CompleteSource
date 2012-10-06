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
    public partial class FullNameViewMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(FullNameViewMetadata))
			{
				if(FullNameViewMetadata.mapDelegates == null)
				{
					FullNameViewMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (FullNameViewMetadata.meta == null)
				{
					FullNameViewMetadata.meta = new FullNameViewMetadata();
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
				

				meta.AddTypeMap("FullName", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("HireDate", new esTypeMap("DATETIME", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("DECIMAL", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("TINYINT UNSIGNED", "System.Byte"));				
				meta.Catalog = "aggregatedb";
				
				meta.Source = "fullnameview";
				meta.Destination = "fullnameview";
				
				meta.spInsert = "proc_fullnameviewInsert";				
				meta.spUpdate = "proc_fullnameviewUpdate";		
				meta.spDelete = "proc_fullnameviewDelete";
				meta.spLoadAll = "proc_fullnameviewLoadAll";
				meta.spLoadByPrimaryKey = "proc_fullnameviewLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
