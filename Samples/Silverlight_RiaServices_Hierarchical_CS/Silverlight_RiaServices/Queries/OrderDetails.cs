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
	[DataContract(Name = "OrderDetailsQuery", Namespace = "http://www.entityspaces.net")]
	public partial class OrderDetailsQueryProxyStub : esDynamicQuerySerializable
	{
		public OrderDetailsQueryProxyStub() { }
		
		public OrderDetailsQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "OrderDetailsQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(OrderDetailsQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem OrderID
		{
			get { return new esQueryItem(this, "OrderID", esSystemType.Int32); }
		} 
		
		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, "ProductID", esSystemType.Int32); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, "UnitPrice", esSystemType.Decimal); }
		} 
		
		public esQueryItem Quantity
		{
			get { return new esQueryItem(this, "Quantity", esSystemType.Int16); }
		} 
		
		public esQueryItem Discount
		{
			get { return new esQueryItem(this, "Discount", esSystemType.Single); }
		} 
		
	}
}