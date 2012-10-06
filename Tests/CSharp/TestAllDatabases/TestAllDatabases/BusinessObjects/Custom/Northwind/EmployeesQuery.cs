/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2010.0.0.0
EntitySpaces Driver  : SQL
Date Generated       : 3/18/2010 5:03:52 PM
===============================================================================
*/

using System;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
	public partial class EmployeesQuery : esEmployeesQuery
	{
		public EmployeesQuery()
		{
		
		}

        public EmployeesQuery QueryByPartialName(string first, string last, string country)
        {
            if (String.IsNullOrEmpty(last))
            {
                return null;
            }
            else
            {
                this.Where(this.LastName.Like("%" + last + "%"));
            }

            if (!String.IsNullOrEmpty(first))
            {
                this.Where(this.FirstName.Like("%" + first + "%"));
            }

            if (!String.IsNullOrEmpty(country))
            {
                this.Where(this.Country == country);
            }

            return this;
        }
	}
}
