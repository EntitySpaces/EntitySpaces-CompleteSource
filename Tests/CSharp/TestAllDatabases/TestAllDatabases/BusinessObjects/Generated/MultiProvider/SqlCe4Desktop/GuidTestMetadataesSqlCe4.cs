/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQLCE
Date Generated       : 3/17/2012 4:43:58 AM
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
    public partial class GuidTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlCe4()
		{
			// This is only executed once per the life of the application
			lock (typeof(GuidTestMetadata))
			{
				if(GuidTestMetadata.mapDelegates == null)
				{
					GuidTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GuidTestMetadata.meta == null)
				{
					GuidTestMetadata.meta = new GuidTestMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esSqlCe4);
				mapDelegates.Add("esSqlCe4", mapMethod);
				mapMethod("esSqlCe4");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esSqlCe4(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("GuidKey", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("GuidNonKey", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("GuidRowGuid", new esTypeMap("uniqueidentifier", "System.Guid"));				
				meta.Catalog = "GuidTestDb.sdf";
				
				meta.Source = "GuidTest";
				meta.Destination = "GuidTest";
				
				meta.spInsert = "proc_GuidTestInsert";				
				meta.spUpdate = "proc_GuidTestUpdate";		
				meta.spDelete = "proc_GuidTestDelete";
				meta.spLoadAll = "proc_GuidTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_GuidTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe4"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe4"];
		}
		
		static private int _esSqlCe4 = RegisterDelegateesSqlCe4();
    }
}
