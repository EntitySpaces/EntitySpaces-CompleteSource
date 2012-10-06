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
    [MetadataType(typeof(OrderDetailsValidation))]
    public partial class OrderDetails
    {

    }
	
    internal class OrderDetailsValidation
    {

		[KeyAttribute()]
		[Required]
		public System.Int32? OrderID { get; set; }

		[KeyAttribute()]
		[Required]
		public System.Int32? ProductID { get; set; }

		public System.Decimal? UnitPrice { get; set; }

		public System.Int16? Quantity { get; set; }

		public System.Single? Discount { get; set; }
    }
}