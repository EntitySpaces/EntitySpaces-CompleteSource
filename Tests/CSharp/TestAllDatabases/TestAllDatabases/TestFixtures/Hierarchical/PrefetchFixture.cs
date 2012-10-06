//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class PrefetchFixture
	{
		[TestFixtureSetUp]
		public void Init()
		{
		}

		[SetUp]
		public void Init2()
		{
		}

        [Test]
        public void DisableLazyLoad()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            emp.es.IsLazyLoadDisabled = true;

            emp.LoadByPrimaryKey(1);
            Assert.AreEqual(0, emp.CustomerCollectionByManager.Count);
            Assert.AreEqual(0, emp.CustomerCollectionByStaffAssigned.Count);
            Assert.AreEqual(0, emp.EmployeeCollectionBySupervisor.Count);
            Assert.AreEqual(0, emp.EmployeeTerritoryCollectionByEmpID.Count);
            Assert.AreEqual(0, emp.OrderCollectionByEmployeeID.Count);
            Assert.AreEqual(0, emp.ReferredEmployeeCollectionByEmployeeID.Count);
            Assert.AreEqual(0, emp.ReferredEmployeeCollectionByReferredID.Count);
            Assert.IsNull(emp.UpToEmployeeBySupervisor);
            Assert.AreEqual(0, emp.UpToTerritoryCollection.Count);
        }

		[Test]
		public void SingleZeroToMany()
		{
            // The main Employee query
            EmployeeQuery eq1 = new EmployeeQuery("e");
            eq1.Where(eq1.EmployeeID < 3);
            eq1.OrderBy(eq1.EmployeeID.Ascending);

            // The Order Collection
            OrderQuery oq1 = eq1.Prefetch<OrderQuery>(Employee.Prefetch_OrderCollectionByEmployeeID);
            EmployeeQuery eq2 = oq1.GetQuery<EmployeeQuery>();
            oq1.Where(eq2.EmployeeID < 3);

            // Pre-test the Order query
            OrderCollection oColl = new OrderCollection();
            oColl.es.Connection.Name = "ForeignKeyTest";
            oColl.Load(oq1);
            Assert.AreEqual(3, oColl.Count, "Order pre-test");

            // This will Prefetch the Order query
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            //coll.es.IsLazyLoadDisabled = true;
            coll.Load(eq1);

            foreach (Employee emp in coll)
            {
                emp.es.IsLazyLoadDisabled = true;

                switch (emp.EmployeeID.Value)
                {
                    case 1:
                        Assert.AreEqual(1, emp.EmployeeID.Value);
                        Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count);
                        break;

                    case 2:
                        Assert.AreEqual(2, emp.EmployeeID.Value);
                        Assert.AreEqual(2, emp.OrderCollectionByEmployeeID.Count);
                        break;

                    default:
                        Assert.Fail("Only employees 1 and 2 should be loaded.");
                        break;
                }
            }
		}

        [Test]
        public void NestedZeroToMany()
        {
            // The main Employee query
            EmployeeQuery eq1 = new EmployeeQuery("e");
            eq1.Where(eq1.EmployeeID < 4);
            eq1.OrderBy(eq1.EmployeeID.Ascending);

            // The Order Collection
            OrderQuery oq1 = eq1.Prefetch<OrderQuery>(Employee.Prefetch_OrderCollectionByEmployeeID);
            EmployeeQuery eq2 = oq1.GetQuery<EmployeeQuery>();
            oq1.Where(eq2.EmployeeID < 4 && oq1.PlacedBy < 3);

            // Pre-test the Order query
            OrderCollection oColl = new OrderCollection();
            oColl.es.Connection.Name = "ForeignKeyTest";
            oColl.Load(oq1);
            Assert.AreEqual(5, oColl.Count, "Order pre-test");
            
            // The OrderItem Collection
            OrderItemQuery oiq1 = eq1.Prefetch<OrderItemQuery>(Employee.Prefetch_OrderCollectionByEmployeeID, Order.Prefetch_OrderItemCollectionByOrderID);
            EmployeeQuery eq3 = oiq1.GetQuery<EmployeeQuery>();
            OrderQuery oq2 = oiq1.GetQuery<OrderQuery>();
            oiq1.Where(eq3.EmployeeID < 4 && oq2.PlacedBy < 3 && oiq1.Quantity < 100);

            // Pre-test the OrderItem query
            OrderItemCollection oiColl = new OrderItemCollection();
            oiColl.es.Connection.Name = "ForeignKeyTest";
            oiColl.Load(oiq1);
            Assert.AreEqual(4, oiColl.Count, "OrderItem pre-test");

            // Will Prefetch the Order and OrderItems queries
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            //coll.es.IsLazyLoadDisabled = true;
            coll.Load(eq1);

            foreach (Employee emp in coll)
            {
                emp.es.IsLazyLoadDisabled = true;

                switch (emp.EmployeeID.Value)
                {
                    case 1:
                        Assert.AreEqual(1, emp.EmployeeID.Value);
                        Assert.AreEqual(0, emp.OrderCollectionByEmployeeID.Count);
                        break;

                    case 2:
                        Assert.AreEqual(2, emp.EmployeeID.Value);
                        Assert.AreEqual(2, emp.OrderCollectionByEmployeeID.Count);

                        foreach (Order o in emp.OrderCollectionByEmployeeID)
                        {
                            Assert.Less(0, o.OrderItemCollectionByOrderID.Count);
                        }
                        break;

                    case 3:
                        Assert.AreEqual(3, emp.EmployeeID.Value);
                        Assert.AreEqual(3, emp.OrderCollectionByEmployeeID.Count);

                        foreach (Order o in emp.OrderCollectionByEmployeeID)
                        {
                            Assert.AreEqual(0, o.OrderItemCollectionByOrderID.Count);
                        }
                        break;

                    default:
                        Assert.Fail("Only employees 1, 2, and 3 should be loaded.");
                        break;
                }
            }
        }

        [Test]
        public void NestedZeroToManyEntity()
        {
            //The main Employee query
            EmployeeQuery eq1 = new EmployeeQuery();
            eq1.Where(eq1.EmployeeID == 1);

            // Prefetch Employee Customers by Manager
            CustomerQuery cq1 = eq1.Prefetch<CustomerQuery>(
                Employee.Prefetch_CustomerCollectionByManager);
            EmployeeQuery eq2 = cq1.GetQuery<EmployeeQuery>();
            cq1.Where(eq2.EmployeeID == 1);

            // Prefetch Employee Customers Orders (composite FK)
            OrderQuery oq1 = eq1.Prefetch<OrderQuery>(
                Employee.Prefetch_CustomerCollectionByManager, 
                Customer.Prefetch_OrderCollectionByCustID);
            EmployeeQuery eq3 = oq1.GetQuery<EmployeeQuery>();
            oq1.Where(eq3.EmployeeID == 1);

            // Prefetch Employee Customers Orders OrderItems
            OrderItemQuery oiq1 = eq1.Prefetch<OrderItemQuery>(
                Employee.Prefetch_CustomerCollectionByManager, 
                Customer.Prefetch_OrderCollectionByCustID, 
                Order.Prefetch_OrderItemCollectionByOrderID);
            EmployeeQuery eq4 = oiq1.GetQuery<EmployeeQuery>();
            oiq1.Where(eq4.EmployeeID == 1);

            // Prefetch Employee Customers by StaffAssigned
            CustomerQuery cq2 = eq1.Prefetch<CustomerQuery>(
                Employee.Prefetch_CustomerCollectionByStaffAssigned);
            EmployeeQuery eq5 = cq2.GetQuery<EmployeeQuery>();
            cq2.Where(eq5.EmployeeID == 1);

            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            emp.Load(eq1);

            Assert.AreEqual(1, emp.EmployeeID.Value);
            Assert.AreEqual(35, emp.CustomerCollectionByManager.Count);
            Assert.AreEqual(2, emp.CustomerCollectionByStaffAssigned.Count);
            Assert.AreEqual(0, emp.EmployeeCollectionBySupervisor.Count, "These 2 are not Prefetched");

            foreach (Customer c in emp.CustomerCollectionByManager)
            {
                if (c.CustomerID == "01001" && c.CustomerSub == "001")
                {
                    Assert.AreEqual(3, c.OrderCollectionByCustID.Count);

                    foreach (Order o in c.OrderCollectionByCustID)
                    {
                        if (o.OrderID == 1)
                        {
                            Assert.AreEqual(3, o.OrderItemCollectionByOrderID.Count);
                        }
                    }
                }
            }
        }

        [Test]
        public void NestedZeroToManyEntity2()
        {
            //The main Employee
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            emp.Query.Where(emp.Query.EmployeeID == 1);

            // Prefetch Employee Customers by Manager
            CustomerQuery cq1 = emp.Query.Prefetch<CustomerQuery>(
                Employee.Prefetch_CustomerCollectionByManager);
            EmployeeQuery eq1 = cq1.GetQuery<EmployeeQuery>();
            cq1.Where(eq1.EmployeeID == 1);

            // Prefetch Employee Customers Orders (composite FK)
            OrderQuery oq1 = emp.Query.Prefetch<OrderQuery>(
                Employee.Prefetch_CustomerCollectionByManager,
                Customer.Prefetch_OrderCollectionByCustID);
            EmployeeQuery eq2 = oq1.GetQuery<EmployeeQuery>();
            oq1.Where(eq2.EmployeeID == 1);

            // Prefetch Employee Customers Orders OrderItems
            OrderItemQuery oiq1 = emp.Query.Prefetch<OrderItemQuery>(
                Employee.Prefetch_CustomerCollectionByManager,
                Customer.Prefetch_OrderCollectionByCustID,
                Order.Prefetch_OrderItemCollectionByOrderID);
            EmployeeQuery eq3 = oiq1.GetQuery<EmployeeQuery>();
            oiq1.Where(eq3.EmployeeID == 1);

            // Prefetch Employee Customers by StaffAssigned
            CustomerQuery cq2 = emp.Query.Prefetch<CustomerQuery>(
                Employee.Prefetch_CustomerCollectionByStaffAssigned);
            EmployeeQuery eq4 = cq2.GetQuery<EmployeeQuery>();
            cq2.Where(eq4.EmployeeID == 1);

            emp.Query.Load();

            Assert.AreEqual(1, emp.EmployeeID.Value);
            Assert.AreEqual(35, emp.CustomerCollectionByManager.Count);
            Assert.AreEqual(2, emp.CustomerCollectionByStaffAssigned.Count);
            Assert.AreEqual(0, emp.EmployeeCollectionBySupervisor.Count, "These 2 are not Prefetched");

            foreach (Customer c in emp.CustomerCollectionByManager)
            {
                if (c.CustomerID == "01001" && c.CustomerSub == "001")
                {
                    Assert.AreEqual(3, c.OrderCollectionByCustID.Count);

                    foreach (Order o in c.OrderCollectionByCustID)
                    {
                        if (o.OrderID == 1)
                        {
                            Assert.AreEqual(3, o.OrderItemCollectionByOrderID.Count);
                        }
                    }
                }
            }
        }

        [Test]
        public void NestedZeroToManyCollection()
        {
            //The main Employee query
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            coll.Query.Where(coll.Query.EmployeeID < 4);

            // Prefetch Employees Customers by Manager
            CustomerQuery cq1 = coll.Query.Prefetch<CustomerQuery>(
                Employee.Prefetch_CustomerCollectionByManager);
            EmployeeQuery eq1 = cq1.GetQuery<EmployeeQuery>();
            cq1.Where(eq1.EmployeeID < 4);

            // Prefetch Employees Customers Orders (composite FK)
            OrderQuery oq1 = coll.Query.Prefetch<OrderQuery>(
                Employee.Prefetch_CustomerCollectionByManager,
                Customer.Prefetch_OrderCollectionByCustID);
            EmployeeQuery eq2 = oq1.GetQuery<EmployeeQuery>();
            oq1.Where(eq2.EmployeeID < 4);

            // Prefetch Employees Customers Orders OrderItems
            OrderItemQuery oiq1 = coll.Query.Prefetch<OrderItemQuery>(
                Employee.Prefetch_CustomerCollectionByManager,
                Customer.Prefetch_OrderCollectionByCustID,
                Order.Prefetch_OrderItemCollectionByOrderID);
            EmployeeQuery eq3 = oiq1.GetQuery<EmployeeQuery>();
            oiq1.Where(eq3.EmployeeID < 4);

            // Prefetch Employees Customers by StaffAssigned
            CustomerQuery cq2 = coll.Query.Prefetch<CustomerQuery>(
                Employee.Prefetch_CustomerCollectionByStaffAssigned);
            EmployeeQuery eq4 = cq2.GetQuery<EmployeeQuery>();
            cq2.Where(eq4.EmployeeID < 4);

            coll.Query.Load();

            foreach (Employee emp in coll)
            {
                switch (emp.EmployeeID.Value)
                {
                    case 1:
                        Assert.AreEqual(1, emp.EmployeeID.Value);
                        Assert.AreEqual(35, emp.CustomerCollectionByManager.Count);
                        Assert.AreEqual(2, emp.CustomerCollectionByStaffAssigned.Count);
                        Assert.AreEqual(0, emp.EmployeeCollectionBySupervisor.Count, "These 2 are not Prefetched");

                        foreach (Customer c in emp.CustomerCollectionByManager)
                        {
                            if (c.CustomerID == "01001" && c.CustomerSub == "001")
                            {
                                Assert.AreEqual(3, c.OrderCollectionByCustID.Count);

                                foreach (Order o in c.OrderCollectionByCustID)
                                {
                                    if (o.OrderID == 1)
                                    {
                                        Assert.AreEqual(3, o.OrderItemCollectionByOrderID.Count);
                                    }
                                }
                            }
                        }

                        break;

                    case 2:
                        Assert.AreEqual(2, emp.EmployeeID.Value);
                        Assert.AreEqual(12, emp.CustomerCollectionByManager.Count);
                        Assert.AreEqual(5, emp.CustomerCollectionByStaffAssigned.Count);

                        break;

                    case 3:
                        Assert.AreEqual(3, emp.EmployeeID.Value);
                        Assert.AreEqual(6, emp.CustomerCollectionByManager.Count);
                        Assert.AreEqual(1, emp.CustomerCollectionByStaffAssigned.Count);

                        break;

                    default:
                        Assert.Fail("Only employees 1, 2, and 3 should be loaded.");

                        break;
                }
            }
        }
    }
}
