/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : MySql
Date Generated       : 3/17/2012 4:44:09 AM
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
    public partial class ReverseCompositeParentMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
		{
			// This is only executed once per the life of the application
			lock (typeof(ReverseCompositeParentMetadata))
			{
				if(ReverseCompositeParentMetadata.mapDelegates == null)
				{
					ReverseCompositeParentMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ReverseCompositeParentMetadata.meta == null)
				{
					ReverseCompositeParentMetadata.meta = new ReverseCompositeParentMetadata();
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
				

				meta.AddTypeMap("KeySub", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("KeyId", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("VARCHAR", "System.String"));				
				meta.Catalog = "foreignkeytest";
				
				meta.Source = "reversecompositeparent";
				meta.Destination = "reversecompositeparent";
				
				meta.spInsert = "proc_reversecompositeparentInsert";				
				meta.spUpdate = "proc_reversecompositeparentUpdate";		
				meta.spDelete = "proc_reversecompositeparentDelete";
				meta.spLoadAll = "proc_reversecompositeparentLoadAll";
				meta.spLoadByPrimaryKey = "proc_reversecompositeparentLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
