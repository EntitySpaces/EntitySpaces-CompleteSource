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
	[DataContract(Name = "OrdersQuery", Namespace = "http://www.entityspaces.net")]
	public partial class OrdersQueryProxyStub : esDynamicQuerySerializable
	{
		public OrdersQueryProxyStub() { }
		
		public OrdersQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "OrdersQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(OrdersQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem OrderID
		{
			get { return new esQueryItem(this, "OrderID", esSystemType.Int32); }
		} 
		
		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, "CustomerID", esSystemType.String); }
		} 
		
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, "EmployeeID", esSystemType.Int32); }
		} 
		
		public esQueryItem OrderDate
		{
			get { return new esQueryItem(this, "OrderDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem RequiredDate
		{
			get { return new esQueryItem(this, "RequiredDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem ShippedDate
		{
			get { return new esQueryItem(this, "ShippedDate", esSystemType.DateTime); }
		} 
		
		public esQueryItem ShipVia
		{
			get { return new esQueryItem(this, "ShipVia", esSystemType.Int32); }
		} 
		
		public esQueryItem Freight
		{
			get { return new esQueryItem(this, "Freight", esSystemType.Decimal); }
		} 
		
		public esQueryItem ShipName
		{
			get { return new esQueryItem(this, "ShipName", esSystemType.String); }
		} 
		
		public esQueryItem ShipAddress
		{
			get { return new esQueryItem(this, "ShipAddress", esSystemType.String); }
		} 
		
		public esQueryItem ShipCity
		{
			get { return new esQueryItem(this, "ShipCity", esSystemType.String); }
		} 
		
		public esQueryItem ShipRegion
		{
			get { return new esQueryItem(this, "ShipRegion", esSystemType.String); }
		} 
		
		public esQueryItem ShipPostalCode
		{
			get { return new esQueryItem(this, "ShipPostalCode", esSystemType.String); }
		} 
		
		public esQueryItem ShipCountry
		{
			get { return new esQueryItem(this, "ShipCountry", esSystemType.String); }
		} 
		
	}
}