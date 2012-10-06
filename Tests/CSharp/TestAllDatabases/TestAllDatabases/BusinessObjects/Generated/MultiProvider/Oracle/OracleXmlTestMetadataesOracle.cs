/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : Oracle
Date Generated       : 3/17/2012 4:44:58 AM
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
    public partial class OracleXmlTestMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesOracle()
		{
			// This is only executed once per the life of the application
			lock (typeof(OracleXmlTestMetadata))
			{
				if(OracleXmlTestMetadata.mapDelegates == null)
				{
					OracleXmlTestMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OracleXmlTestMetadata.meta == null)
				{
					OracleXmlTestMetadata.meta = new OracleXmlTestMetadata();
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
				

				meta.AddTypeMap("Id", new esTypeMap("VARCHAR2", "System.String"));
				meta.AddTypeMap("XmlColumn", new esTypeMap("XMLTYPE", "System.String"));				
				meta.Catalog = "ENTITYSPACES";
				meta.Schema = "ENTITYSPACES";
				meta.Source = "OracleXmlTest";
				meta.Destination = "OracleXmlTest";
				
				meta.spInsert = "esOracleXmlTestInsert";				
				meta.spUpdate = "esOracleXmlTestUpdate";		
				meta.spDelete = "esOracleXmlTestDelete";
				meta.spLoadAll = "esOracleXmlTestLoadAll";
				meta.spLoadByPrimaryKey = "esOracleXmlTestLoadByPK";
				
				m_providerMetadataMaps["esOracle"] = meta;
			}
			
			return m_providerMetadataMaps["esOracle"];
		}
		
		static private int _esOracle = RegisterDelegateesOracle();
    }
}
