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
    [MetadataType(typeof(SuppliersValidation))]
    public partial class Suppliers
    {

    }
	
    internal class SuppliersValidation
    {

		[KeyAttribute()]
		[Editable(false)]
		public System.Int32? SupplierID { get; set; }

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

		[StringLength(1073741823)]
		public System.String HomePage { get; set; }
    }
}