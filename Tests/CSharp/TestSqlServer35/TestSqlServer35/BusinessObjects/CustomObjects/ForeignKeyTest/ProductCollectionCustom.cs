/*
===============================================================================
                     EntitySpaces(TM) by EntitySpaces, LLC
                 A New 2.0 Architecture for the .NET Framework
                          http://www.entityspaces.net
===============================================================================
                       EntitySpaces Version # 1.4.2.0
                       MyGeneration Version # 1.1.5.1
                           8/9/2006 6:42:11 PM
-------------------------------------------------------------------------------
*/


using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;

namespace BusinessObjects
{
    public partial class ProductCollection : esProductCollection
	{
        public bool GetActiveProductIds(int employeeId)
        {
            ProductQuery prd = new ProductQuery("pq");
            //prd.es.Connection.Name = "ForeignKeyTest";
            OrderItemQuery item = new OrderItemQuery("oiq");
            //item.es.Connection.Name = "ForeignKeyTest";
            OrderQuery ord = new OrderQuery("oq");
            //ord.es.Connection.Name = "ForeignKeyTest";
            CustomerQuery cust = new CustomerQuery("cq");
            //cust.es.Connection.Name = "ForeignKeyTest";
            EmployeeQuery emp = new EmployeeQuery("eq");
            //emp.es.Connection.Name = "ForeignKeyTest";

            prd.Select(prd.ProductID);
            prd.InnerJoin(item).On(prd.ProductID == item.ProductID);
            prd.InnerJoin(ord).On(item.OrderID == ord.OrderID);
            prd.InnerJoin(cust).On(ord.CustID == cust.CustomerID &
                ord.CustSub == cust.CustomerSub);
            prd.InnerJoin(emp).On(cust.Manager == emp.EmployeeID);
            prd.Where(emp.EmployeeID == employeeId);
            prd.Where(prd.Discontinued == false);
            prd.es.Distinct = true;

            return this.Load(prd);
        }
    }
}
