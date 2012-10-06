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
    [MetadataType(typeof(CustomersValidation))]
    public partial class Customers
    {

    }
	
    internal class CustomersValidation
    {

		[KeyAttribute()]
		[StringLength(5)]
		[Required]
		public System.String CustomerID { get; set; }

		[StringLength(40)]
		[Required]
		public System.String CompanyName { get; set; }

		[StringLength(30)]
		public System.String ContactName { get; set; }

		[StringLength(30)]
		public System.String ContactTitle { get; set; }

		[StringLength(60)]
		public System.String Address { get; set; }

		[StringLength(15)]
		public System.String City { get; set; }

		[StringLength(15)]
		public System.String Region { get; set; }

		[StringLength(10)]
		public System.String PostalCode { get; set; }

		[StringLength(15)]
		public System.String Country { get; set; }

		[StringLength(24)]
		public System.String Phone { get; set; }

		[StringLength(24)]
		public System.String Fax { get; set; }
    }
}