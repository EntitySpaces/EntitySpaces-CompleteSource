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
	[DataContract(Name = "CategoriesQuery", Namespace = "http://www.entityspaces.net")]
	public partial class CategoriesQueryProxyStub : esDynamicQuerySerializable
	{
		public CategoriesQueryProxyStub() { }
		
		public CategoriesQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "CategoriesQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(CategoriesQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, "CategoryID", esSystemType.Int32); }
		} 
		
		public esQueryItem CategoryName
		{
			get { return new esQueryItem(this, "CategoryName", esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, "Description", esSystemType.String); }
		} 
		
		public esQueryItem Picture
		{
			get { return new esQueryItem(this, "Picture", esSystemType.ByteArray); }
		} 
		
	}
}