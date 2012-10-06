/*===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:16 PM
===============================================================================
*/

using System;
using System.Runtime.Serialization;

using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
	[DataContract(Name = "TerritoriesQuery", Namespace = "http://www.entityspaces.net")]
	public partial class TerritoriesQueryProxyStub : esDynamicQuerySerializable
	{
		public TerritoriesQueryProxyStub() { }
		
		public TerritoriesQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "TerritoriesQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(TerritoriesQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem TerritoryID
		{
			get { return new esQueryItem(this, "TerritoryID", esSystemType.String); }
		} 
		
		public esQueryItem TerritoryDescription
		{
			get { return new esQueryItem(this, "TerritoryDescription", esSystemType.String); }
		} 
		
		public esQueryItem RegionID
		{
			get { return new esQueryItem(this, "RegionID", esSystemType.Int32); }
		} 
		
	}
}