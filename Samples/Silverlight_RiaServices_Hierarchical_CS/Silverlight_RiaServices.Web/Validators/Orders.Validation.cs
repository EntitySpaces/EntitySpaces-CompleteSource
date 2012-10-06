/*===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:17 PM
===============================================================================
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    [MetadataType(typeof(OrdersValidation))]
    public partial class Orders
    {

    }
	
    internal class OrdersValidation
    {

		[KeyAttribute()]
		[Editable(false)]
		public System.Int32? OrderID { get; set; }

		[StringLength(5)]
		public System.String CustomerID { get; set; }

		public System.Int32? EmployeeID { get; set; }

		public System.DateTime? OrderDate { get; set; }

		public System.DateTime? RequiredDate { get; set; }

		public System.DateTime? ShippedDate { get; set; }

		public System.Int32? ShipVia { get; set; }

		public System.Decimal? Freight { get; set; }

		[StringLength(40)]
		public System.String ShipName { get; set; }

		[StringLength(60)]
		public System.String ShipAddress { get; set; }

		[StringLength(15)]
		public System.String ShipCity { get; set; }

		[StringLength(15)]
		public System.String ShipRegion { get; set; }

		[StringLength(10)]
		public System.String ShipPostalCode { get; set; }

		[StringLength(15)]
		public System.String ShipCountry { get; set; }
    }
}