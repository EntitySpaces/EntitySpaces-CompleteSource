/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Access
Date Generated       : 3/17/2012 4:44:23 AM
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
		static private int RegisterDelegateesAccess()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esAccess);
				mapDelegates.Add("esAccess", mapMethod);
				mapMethod("esAccess");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esAccess(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("FullName", new esTypeMap("Text", "System.String"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("Long", "System.Int32"));
				meta.AddTypeMap("HireDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("Decimal", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("Yes/No", "System.Boolean"));				
				meta.Catalog = "AggregateDb.mdb";
				
				meta.Source = "FullNameView";
				meta.Destination = "FullNameView";
				
				meta.spInsert = "proc_FullNameViewInsert";				
				meta.spUpdate = "proc_FullNameViewUpdate";		
				meta.spDelete = "proc_FullNameViewDelete";
				meta.spLoadAll = "proc_FullNameViewLoadAll";
				meta.spLoadByPrimaryKey = "proc_FullNameViewLoadByPrimaryKey";
				
				m_providerMetadataMaps["esAccess"] = meta;
			}
			
			return m_providerMetadataMaps["esAccess"];
		}
		
		static private int _esAccess = RegisterDelegateesAccess();
    }
}
