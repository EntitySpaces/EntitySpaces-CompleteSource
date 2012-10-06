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
    public partial class CustomerGroupMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesSqlCe4()
		{
			// This is only executed once per the life of the application
			lock (typeof(CustomerGroupMetadata))
			{
				if(CustomerGroupMetadata.mapDelegates == null)
				{
					CustomerGroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomerGroupMetadata.meta == null)
				{
					CustomerGroupMetadata.meta = new CustomerGroupMetadata();
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
				

				meta.AddTypeMap("GroupID", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("GroupName", new esTypeMap("nvarchar", "System.String"));				
				meta.Catalog = "ForeignKeyTest.sdf";
				
				meta.Source = "CustomerGroup";
				meta.Destination = "CustomerGroup";
				
				meta.spInsert = "proc_CustomerGroupInsert";				
				meta.spUpdate = "proc_CustomerGroupUpdate";		
				meta.spDelete = "proc_CustomerGroupDelete";
				meta.spLoadAll = "proc_CustomerGroupLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomerGroupLoadByPrimaryKey";
				
				m_providerMetadataMaps["esSqlCe4"] = meta;
			}
			
			return m_providerMetadataMaps["esSqlCe4"];
		}
		
		static private int _esSqlCe4 = RegisterDelegateesSqlCe4();
    }
}
