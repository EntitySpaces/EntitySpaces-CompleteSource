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
using System.Collections.Generic;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
	public partial class Employees : esEmployees
	{
		public Employees()
		{
		
		}

        //protected override List<esPropertyDescriptor> GetLocalBindingProperties()
        //{
        //    List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();

        //    props.Add(new esPropertyDescriptor(this, "FullName", typeof(string)));

        //    return props;
        //}

        //public string FullName
        //{
        //    get { return (string)this.GetColumn("FullName"); }
        //    set { this.SetColumn("FullName", value); }
        //}
    }
}
