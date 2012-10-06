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
    [MetadataType(typeof(CategoriesValidation))]
    public partial class Categories
    {

    }
	
    internal class CategoriesValidation
    {

		[KeyAttribute()]
		[Editable(false)]
		public System.Int32? CategoryID { get; set; }

		[StringLength(15)]
		[Required]
		public System.String CategoryName { get; set; }

		[StringLength(1073741823)]
		public System.String Description { get; set; }

		public System.Byte[] Picture { get; set; }
    }
}