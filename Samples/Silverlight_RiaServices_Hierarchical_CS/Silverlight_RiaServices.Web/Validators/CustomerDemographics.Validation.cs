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
    [MetadataType(typeof(CustomerDemographicsValidation))]
    public partial class CustomerDemographics
    {

    }
	
    internal class CustomerDemographicsValidation
    {

		[KeyAttribute()]
		[StringLength(10)]
		[Required]
		public System.String CustomerTypeID { get; set; }

		[StringLength(1073741823)]
		public System.String CustomerDesc { get; set; }
    }
}