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
	[DataContract(Name = "RegionQuery", Namespace = "http://www.entityspaces.net")]
	public partial class RegionQueryProxyStub : esDynamicQuerySerializable
	{
		public RegionQueryProxyStub() { }
		
		public RegionQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "RegionQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(RegionQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem RegionID
		{
			get { return new esQueryItem(this, "RegionID", esSystemType.Int32); }
		} 
		
		public esQueryItem RegionDescription
		{
			get { return new esQueryItem(this, "RegionDescription", esSystemType.String); }
		} 
		
	}
}