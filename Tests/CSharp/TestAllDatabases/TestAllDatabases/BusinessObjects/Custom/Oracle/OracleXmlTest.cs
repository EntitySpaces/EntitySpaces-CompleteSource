/*
===============================================================================
                    EntitySpaces 2010 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2010.1.0726.0
EntitySpaces Driver  : Oracle
Date Generated       : 7/28/2010 2:06:43 AM
===============================================================================
*/

using System;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
	public partial class OracleXmlTest : esOracleXmlTest
	{
		public OracleXmlTest()
		{
		
		}

        public int InsertOracleXml()
        {
            string sqlText = "";

            sqlText = "INSERT INTO \"OracleXmlTest\" ";
            sqlText += "VALUES ('" + this.Id + "', ";
            sqlText += "SYS.XMLTYPE.CREATEXML('" + this.XmlColumn + "'))";

            return this.ExecuteNonQuery(esQueryType.Text, sqlText);
        }
    }
}
