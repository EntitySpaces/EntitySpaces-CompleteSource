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
	[DataContract(Name = "CustomersQuery", Namespace = "http://www.entityspaces.net")]
	public partial class CustomersQueryProxyStub : esDynamicQuerySerializable
	{
		public CustomersQueryProxyStub() { }
		
		public CustomersQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "CustomersQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(CustomersQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, "CustomerID", esSystemType.String); }
		} 
		
		public esQueryItem CompanyName
		{
			get { return new esQueryItem(this, "CompanyName", esSystemType.String); }
		} 
		
		public esQueryItem ContactName
		{
			get { return new esQueryItem(this, "ContactName", esSystemType.String); }
		} 
		
		public esQueryItem ContactTitle
		{
			get { return new esQueryItem(this, "ContactTitle", esSystemType.String); }
		} 
		
		public esQueryItem Address
		{
			get { return new esQueryItem(this, "Address", esSystemType.String); }
		} 
		
		public esQueryItem City
		{
			get { return new esQueryItem(this, "City", esSystemType.String); }
		} 
		
		public esQueryItem Region
		{
			get { return new esQueryItem(this, "Region", esSystemType.String); }
		} 
		
		public esQueryItem PostalCode
		{
			get { return new esQueryItem(this, "PostalCode", esSystemType.String); }
		} 
		
		public esQueryItem Country
		{
			get { return new esQueryItem(this, "Country", esSystemType.String); }
		} 
		
		public esQueryItem Phone
		{
			get { return new esQueryItem(this, "Phone", esSystemType.String); }
		} 
		
		public esQueryItem Fax
		{
			get { return new esQueryItem(this, "Fax", esSystemType.String); }
		} 
		
	}
}