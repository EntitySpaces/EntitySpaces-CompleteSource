/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:59 AM
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
		static private int RegisterDelegateesOracle()
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
				
				MapToMeta mapMethod = new MapToMeta(meta.esOracle);
				mapDelegates.Add("esOracle", mapMethod);
				mapMethod("esOracle");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esOracle(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("CHAR", "System.String"));
				meta.AddTypeMap("Notes", new esTypeMap("LONG", "System.String"));				
				meta.Catalog = "HIERARCHICAL";
				meta.Schema = "HIERARCHICAL";
				meta.Source = "Group";
				meta.Destination = "Group";
				
				meta.spInsert = "esGroupInsert";				
				meta.spUpdate = "esGroupUpdate";		
				meta.spDelete = "esGroupDelete";
				meta.spLoadAll = "esGroupLoadAll";
				meta.spLoadByPrimaryKey = "esGroupLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
