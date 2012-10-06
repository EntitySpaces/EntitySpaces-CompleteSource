/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : VistaDB4
Date Generated       : 3/17/2012 4:45:35 AM
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
    public partial class AggregateTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesVistaDB4()
		{
			// This is only executed once per the life of the application
			lock (typeof(AggregateTestMetadata))
			{
				if(AggregateTestMetadata.mapDelegates == null)
				{
					AggregateTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (AggregateTestMetadata.meta == null)
				{
					AggregateTestMetadata.meta = new AggregateTestMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esVistaDB4);
				mapDelegates.Add("esVistaDB4", mapMethod);
				mapMethod("esVistaDB4");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esVistaDB4(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("Id", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("DepartmentID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("FirstName", new esTypeMap("VarChar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("VarChar", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("HireDate", new esTypeMap("DateTime", "System.DateTime"));
				meta.AddTypeMap("Salary", new esTypeMap("Decimal", "System.Decimal"));
				meta.AddTypeMap("IsActive", new esTypeMap("Bit", "System.Boolean"));				
				meta.Catalog = "AggregateDb.vdb4";
				
				meta.Source = "AggregateTest";
				meta.Destination = "AggregateTest";
				
				meta.spInsert = "proc_AggregateTestInsert";				
				meta.spUpdate = "proc_AggregateTestUpdate";		
				meta.spDelete = "proc_AggregateTestDelete";
				meta.spLoadAll = "proc_AggregateTestLoadAll";
				meta.spLoadByPrimaryKey = "proc_AggregateTestLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
