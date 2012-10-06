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
    public partial class GroupMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesPgsql()
		{
			// This is only executed once per the life of the application
			lock (typeof(GroupMetadata))
			{
				if(GroupMetadata.mapDelegates == null)
				{
					GroupMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (GroupMetadata.meta == null)
				{
					GroupMetadata.meta = new GroupMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("bpchar", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("text", "System.String"));				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "public";
				meta.Source = "Group";
				meta.Destination = "Group";
				
				meta.spInsert = "proc_GroupInsert";				
				meta.spUpdate = "proc_GroupUpdate";		
				meta.spDelete = "proc_GroupDelete";
				meta.spLoadAll = "proc_GroupLoadAll";
				meta.spLoadByPrimaryKey = "proc_GroupLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
