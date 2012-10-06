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
    [MetadataType(typeof(ProductsValidation))]
    public partial class Products
    {

    }
	
    internal class ProductsValidation
    {

		[KeyAttribute()]
		[Editable(false)]
		public System.Int32? ProductID { get; set; }

		[StringLength(40)]
		[Required]
		public System.String ProductName { get; set; }

		public System.Int32? SupplierID { get; set; }

		public System.Int32? CategoryID { get; set; }

		[StringLength(20)]
		public System.String QuantityPerUnit { get; set; }

		public System.Decimal? UnitPrice { get; set; }

		public System.Int16? UnitsInStock { get; set; }

		public System.Int16? UnitsOnOrder { get; set; }

		public System.Int16? ReorderLevel { get; set; }

		public System.Boolean? Discontinued { get; set; }
    }
}