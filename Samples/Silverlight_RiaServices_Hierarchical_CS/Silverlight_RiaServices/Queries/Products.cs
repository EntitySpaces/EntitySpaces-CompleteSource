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
	[DataContract(Name = "ProductsQuery", Namespace = "http://www.entityspaces.net")]
	public partial class ProductsQueryProxyStub : esDynamicQuerySerializable
	{
		public ProductsQueryProxyStub() { }
		
		public ProductsQueryProxyStub(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}

        override protected string GetQueryName()
        {
            return "ProductsQuery";
        }	
		
        #region Implicit Casts

        public static implicit operator string(ProductsQueryProxyStub query)
        {
            return esDynamicQuerySerializable.SerializeHelper.ToXml(query);
        }

        #endregion			

		public esQueryItem ProductID
		{
			get { return new esQueryItem(this, "ProductID", esSystemType.Int32); }
		} 
		
		public esQueryItem ProductName
		{
			get { return new esQueryItem(this, "ProductName", esSystemType.String); }
		} 
		
		public esQueryItem SupplierID
		{
			get { return new esQueryItem(this, "SupplierID", esSystemType.Int32); }
		} 
		
		public esQueryItem CategoryID
		{
			get { return new esQueryItem(this, "CategoryID", esSystemType.Int32); }
		} 
		
		public esQueryItem QuantityPerUnit
		{
			get { return new esQueryItem(this, "QuantityPerUnit", esSystemType.String); }
		} 
		
		public esQueryItem UnitPrice
		{
			get { return new esQueryItem(this, "UnitPrice", esSystemType.Decimal); }
		} 
		
		public esQueryItem UnitsInStock
		{
			get { return new esQueryItem(this, "UnitsInStock", esSystemType.Int16); }
		} 
		
		public esQueryItem UnitsOnOrder
		{
			get { return new esQueryItem(this, "UnitsOnOrder", esSystemType.Int16); }
		} 
		
		public esQueryItem ReorderLevel
		{
			get { return new esQueryItem(this, "ReorderLevel", esSystemType.Int16); }
		} 
		
		public esQueryItem Discontinued
		{
			get { return new esQueryItem(this, "Discontinued", esSystemType.Boolean); }
		} 
		
	}
}