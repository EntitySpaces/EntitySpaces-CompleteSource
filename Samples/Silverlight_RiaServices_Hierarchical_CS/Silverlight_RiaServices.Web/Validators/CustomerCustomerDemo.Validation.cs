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
    [MetadataType(typeof(CustomerCustomerDemoValidation))]
    public partial class CustomerCustomerDemo
    {

    }
	
    internal class CustomerCustomerDemoValidation
    {

		[KeyAttribute()]
		[StringLength(5)]
		[Required]
		public System.String CustomerID { get; set; }

		[KeyAttribute()]
		[StringLength(10)]
		[Required]
		public System.String CustomerTypeID { get; set; }
    }
}