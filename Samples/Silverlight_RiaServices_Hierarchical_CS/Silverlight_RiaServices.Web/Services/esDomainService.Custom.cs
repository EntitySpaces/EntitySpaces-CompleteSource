
/*===============================================================================
                    EntitySpaces 2010 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2010.1.1025.0
EntitySpaces Driver  : SQL
Date Generated       : 10/21/2010 10:45:05 PM
===============================================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;
using BusinessObjects;

namespace Silverlight_RiaServices.Web
{
	// Add Custom Methods here, this file will not be ovewrriten
	public partial class esDomainService
	{
        /// <summary>
        /// Give you a chance to handle any error during PersistChangeSet()
        /// </summary>
        /// <param name="ex">The Exception</param>
        /// <returns>True if handle, otherwise the Exception is rethrown and bubbled up</returns>
        private bool HandleError(Exception ex)
        {
            return false;
        }

        [Query]
        public EmployeesCollection Employees_Prefetch()
        {
            // Very simplistic prefetch ..
            EmployeesCollection coll = new EmployeesCollection();
            coll.Query.Prefetch(Employees.Prefetch_OrdersCollectionByEmployeeID);
            coll.Query.Prefetch(Employees.Prefetch_OrdersCollectionByEmployeeID, Orders.Prefetch_OrderDetailsCollectionByOrderID);
            coll.Query.Load();

            return coll;
        }

        [Query]
        public EmployeesCollection Employees_PrefetchSophisticated()
        {
            // EmployeeID = "1"
            EmployeesCollection coll = new EmployeesCollection();
            coll.Query.Where(coll.Query.EmployeeID == 1);

            // Orders Query (nothing fancy, just ensure we're only getting Orders for EmployeeID = 1
            OrdersQuery o = coll.Query.Prefetch<OrdersQuery>(Employees.Prefetch_OrdersCollectionByEmployeeID);
            EmployeesQuery e1 = o.GetQuery<EmployeesQuery>();
            o.Where(e1.EmployeeID == 1);

            // OrderDetailsQuery (here we even limit the Select in addition to  EmployeeID = 1) notice the "false"
            OrderDetailsQuery od = coll.Query.Prefetch<OrderDetailsQuery>(false, Employees.Prefetch_OrdersCollectionByEmployeeID, Orders.Prefetch_OrderDetailsCollectionByOrderID);
            EmployeesQuery e2 = od.GetQuery<EmployeesQuery>();
            od.Where(e2.EmployeeID == 1);
            od.Select(od.OrderID, od.ProductID, od.UnitPrice);

            coll.Query.Load();
            return coll;
        }

        [Query]
        public ProductsCollection Products_LoadWithExtraColumn()
        {
            ProductsQuery p = new ProductsQuery("p");
            SuppliersQuery s = new SuppliersQuery("s");

            // Bring back the suppliers name for the Product from the Supplier table
            p.Select(p, s.CompanyName.As("SupplierName"));
            p.InnerJoin(s).On(p.SupplierID == s.SupplierID);

            ProductsCollection coll = new ProductsCollection();
            coll.Load(p);

            return coll;
        }
	}
}
