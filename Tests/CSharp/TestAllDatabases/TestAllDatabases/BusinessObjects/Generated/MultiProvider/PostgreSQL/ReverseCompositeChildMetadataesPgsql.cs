/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 3/17/2012 4:45:08 AM
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
    public partial class ReverseCompositeChildMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesPgsql()
		{
			// This is only executed once per the life of the application
			lock (typeof(ReverseCompositeChildMetadata))
			{
				if(ReverseCompositeChildMetadata.mapDelegates == null)
				{
					ReverseCompositeChildMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ReverseCompositeChildMetadata.meta == null)
				{
					ReverseCompositeChildMetadata.meta = new ReverseCompositeChildMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esPgsql);
				mapDelegates.Add("esPgsql", mapMethod);
				mapMethod("esPgsql");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esPgsql(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("ChildId", new esTypeMap("int4", "System.Int32"));
				meta.AddTypeMap("ParentKeyId", new esTypeMap("int4", "System.Int32"));
				meta.AddTypeMap("ParentKeySub", new esTypeMap("bpchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"));				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "public";
				meta.Source = "ReverseCompositeChild";
				meta.Destination = "ReverseCompositeChild";
				
				meta.spInsert = "proc_ReverseCompositeChildInsert";				
				meta.spUpdate = "proc_ReverseCompositeChildUpdate";		
				meta.spDelete = "proc_ReverseCompositeChildDelete";
				meta.spLoadAll = "proc_ReverseCompositeChildLoadAll";
				meta.spLoadByPrimaryKey = "proc_ReverseCompositeChildLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
