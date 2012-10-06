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
    [MetadataType(typeof(ShippersValidation))]
    public partial class Shippers
    {

    }
	
    internal class ShippersValidation
    {

		[KeyAttribute()]
		[Editable(false)]
		public System.Int32? ShipperID { get; set; }

		[StringLength(40)]
		[Required]
		public System.String CompanyName { get; set; }

		[StringLength(24)]
		public System.String Phone { get; set; }
    }
}