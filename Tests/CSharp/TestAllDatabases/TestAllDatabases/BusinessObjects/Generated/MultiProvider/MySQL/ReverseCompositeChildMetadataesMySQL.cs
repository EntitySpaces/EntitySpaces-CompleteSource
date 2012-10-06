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
    public partial class ReverseCompositeChildMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesMySQL()
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
				

				meta.AddTypeMap("ChildId", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("ParentKeyId", new esTypeMap("INT", "System.Int32"));
				meta.AddTypeMap("ParentKeySub", new esTypeMap("VARCHAR", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("VARCHAR", "System.String"));				
				meta.Catalog = "foreignkeytest";
				
				meta.Source = "reversecompositechild";
				meta.Destination = "reversecompositechild";
				
				meta.spInsert = "proc_reversecompositechildInsert";				
				meta.spUpdate = "proc_reversecompositechildUpdate";		
				meta.spDelete = "proc_reversecompositechildDelete";
				meta.spLoadAll = "proc_reversecompositechildLoadAll";
				meta.spLoadByPrimaryKey = "proc_reversecompositechildLoadByPrimaryKey";
				
				m_providerMetadataMaps["esMySQL"] = meta;
			}
			
			return m_providerMetadataMaps["esMySQL"];
		}
		
		static private int _esMySQL = RegisterDelegateesMySQL();
    }
}
