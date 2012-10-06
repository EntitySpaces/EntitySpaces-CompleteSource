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
	[DataContract(Name = "CustomerDemographicsQuery", Namespace = "http://www.entityspaces.net")]
	public partial class CustomerDemographicsQueryProxyStub : esDynamicQuerySerializable
	{
		public CustomerDemographicsQueryProxyStub() { }
		
		public CustomerDemographicsQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "CustomerDemographicsQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(CustomerDemographicsQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem CustomerTypeID
		{
			get { return new esQueryItem(this, "CustomerTypeID", esSystemType.String); }
		} 
		
		public esQueryItem CustomerDesc
		{
			get { return new esQueryItem(this, "CustomerDesc", esSystemType.String); }
		} 
		
	}
}