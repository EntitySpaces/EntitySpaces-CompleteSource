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
    [MetadataType(typeof(EmployeesValidation))]
    public partial class Employees
    {

    }
	
    internal class EmployeesValidation
    {

		[KeyAttribute()]
		[Editable(false)]
		public System.Int32? EmployeeID { get; set; }

		[StringLength(20)]
		[Required]
		public System.String LastName { get; set; }

		[StringLength(10)]
		[Required]
		public System.String FirstName { get; set; }

		[StringLength(30)]
		public System.String Title { get; set; }

		[StringLength(25)]
		public System.String TitleOfCourtesy { get; set; }

		public System.DateTime? BirthDate { get; set; }

		public System.DateTime? HireDate { get; set; }

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
		public System.String HomePhone { get; set; }

		[StringLength(4)]
		public System.String Extension { get; set; }

		public System.Byte[] Photo { get; set; }

		[StringLength(1073741823)]
		public System.String Notes { get; set; }

		public System.Int32? ReportsTo { get; set; }

		[StringLength(255)]
		public System.String PhotoPath { get; set; }
    }
}