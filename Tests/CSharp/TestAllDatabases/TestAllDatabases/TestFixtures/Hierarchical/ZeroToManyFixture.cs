//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class ZeroToManyFixture
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
		public void TestMultipleReferences()
		{
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.LoadByPrimaryKey(1);
            Assert.AreEqual(35, emp.CustomerCollectionByManager.Count);
            Assert.AreEqual(2, emp.CustomerCollectionByStaffAssigned.Count);
		}

		[Test]
		public void TestNullReferences()
		{
			Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.LoadByPrimaryKey(5);
			Assert.AreEqual(0, emp.CustomerCollectionByManager.Count);
			Assert.AreEqual(0, emp.CustomerCollectionByStaffAssigned.Count);
		}

		[Test]
		public void TestCompositeForeignKey()
		{
			Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";

            cust.LoadByPrimaryKey("01001", "001");
			Assert.AreEqual(3, cust.OrderCollectionByCustID.Count);
		}

		[Test]
		public void TestSelfReference()
		{
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.LoadByPrimaryKey(1);
            Assert.AreEqual(2, emp.EmployeeCollectionBySupervisor.Count);
		}

		[Test]
		public void TestSave()
		{
            int empKey = -1;
            CustomerGroup custGroup = new CustomerGroup();
            custGroup.es.Connection.Name = "ForeignKeyTest";
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    custGroup.GroupID = "XXXXX";
                    custGroup.GroupName = "Test";
                    custGroup.Save();

                    emp.LastName = "LastName";
                    emp.FirstName = "FirstName";

                    cust = emp.CustomerCollectionByStaffAssigned.AddNew();
                    cust.CustomerID = "XXXXX";
                    cust.CustomerSub = "XXX";
                    cust.CustomerName = "Test";
                    cust.str().DateAdded = "2007-01-01 00:00:00";
                    cust.Active = true;
                    cust.Manager = 1;

                    emp.Save();
                    empKey = emp.EmployeeID.Value;

                    Assert.AreEqual(1, emp.CustomerCollectionByStaffAssigned.Count);
                    Assert.AreEqual(emp.EmployeeID.Value, cust.StaffAssigned.Value);
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(empKey))
                {
                    CustomerCollection custColl = emp.CustomerCollectionByStaffAssigned;
                    custColl.MarkAllAsDeleted();
                    emp.MarkAsDeleted();
                    emp.Save();

                }

                custGroup = new CustomerGroup();
                custGroup.es.Connection.Name = "ForeignKeyTest";

                if (custGroup.LoadByPrimaryKey("XXXXX"))
                {
                    custGroup.MarkAsDeleted();
                    custGroup.Save();
                }
            }
		}

        [Test]
        public void TestSaveSimple()
        {
            int empKey = -1;

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    Employee emp = new Employee();
                    emp.es.Connection.Name = "ForeignKeyTest";

                    emp.LastName = "LastName";
                    emp.FirstName = "FirstName";

                    Order ord = emp.OrderCollectionByEmployeeID.AddNew();
                    ord.CustID = "10001";
                    ord.CustSub = "001";
                    ord.str().OrderDate = "2007-01-01 00:00:00";

                    emp.Save();
                    empKey = emp.EmployeeID.Value;

                    Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count);
                    Assert.AreEqual(emp.EmployeeID.Value, ord.EmployeeID.Value);
                }
            }
            finally
            {
                // Clean up
                Employee emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(empKey))
                {
                    OrderCollection ordColl = emp.OrderCollectionByEmployeeID;
                    ordColl.MarkAllAsDeleted();
                    emp.MarkAsDeleted();
                    emp.Save();
                }
            }
        }

        [Test]
		public void TestSaveFromCollection()
		{
            int empKey = -1;
            CustomerGroup custGroup = new CustomerGroup();
            custGroup.es.Connection.Name = "ForeignKeyTest";
            EmployeeCollection empColl = new EmployeeCollection();
            empColl.es.Connection.Name = "ForeignKeyTest";
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    custGroup.GroupID = "XXXXX";
                    custGroup.GroupName = "Test";
                    custGroup.Save();

                    emp = empColl.AddNew();
                    emp.LastName = "LastName";
                    emp.FirstName = "FirstName";

                    cust = emp.CustomerCollectionByStaffAssigned.AddNew();
                    cust.CustomerID = "XXXXX";
                    cust.CustomerSub = "XXX";
                    cust.CustomerName = "Test";
                    cust.str().DateAdded = "2007-01-01 00:00:00";
                    cust.Active = true;
                    cust.Manager = 1;

                    empColl.Save();
                    empKey = emp.EmployeeID.Value;

                    Assert.AreEqual(1, emp.CustomerCollectionByStaffAssigned.Count);
                    Assert.AreEqual(emp.EmployeeID.Value, cust.StaffAssigned.Value);
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(empKey))
                {
                    CustomerCollection custColl = emp.CustomerCollectionByStaffAssigned;
                    custColl.MarkAllAsDeleted();
                    emp.MarkAsDeleted();
                    emp.Save();
                }

                custGroup = new CustomerGroup();
                custGroup.es.Connection.Name = "ForeignKeyTest";

                if (custGroup.LoadByPrimaryKey("XXXXX"))
                {
                    custGroup.MarkAsDeleted();
                    custGroup.Save();
                }
            }
		}

        [Test]
        public void TestSaveSimpleCollection()
        {
            int empKey = -1;
            EmployeeCollection empColl = new EmployeeCollection();
            empColl.es.Connection.Name = "ForeignKeyTest";
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    empColl.LoadAll();
                    emp = empColl.AddNew();
                    emp.LastName = "LastName";
                    emp.FirstName = "FirstName";

                    Order ord = emp.OrderCollectionByEmployeeID.AddNew();
                    ord.CustID = "10001";
                    ord.CustSub = "001";
                    ord.str().OrderDate = "2007-01-01 00:00:00";

                    empColl.Save();
                    empKey = emp.EmployeeID.Value;

                    Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count);
                    Assert.AreEqual(emp.EmployeeID.Value, ord.EmployeeID.Value);
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(empKey))
                {
                    OrderCollection ordColl = emp.OrderCollectionByEmployeeID;
                    ordColl.MarkAllAsDeleted();
                    emp.MarkAsDeleted();
                    emp.Save();
                }
            }
        }

        [Test]
		public void TestSaveSelfReference()
		{
            int empKey = -1;
            int supvKey = -1;
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            Employee supv = new Employee();
            supv.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    emp.LastName = "LastName";
                    emp.FirstName = "FirstName";

                    supv = emp.EmployeeCollectionBySupervisor.AddNew();
                    supv.LastName = "SupvLast";
                    supv.FirstName = "SupvFirst";

                    emp.Save();
                    empKey = emp.EmployeeID.Value;
                    supvKey = supv.EmployeeID.Value;

                    Assert.AreEqual(1, emp.EmployeeCollectionBySupervisor.Count);
                    Assert.AreEqual(emp.EmployeeID.Value, supv.Supervisor.Value);
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(empKey))
                {
                    EmployeeCollection empColl = emp.EmployeeCollectionBySupervisor;
                    empColl.MarkAllAsDeleted();
                    emp.MarkAsDeleted();
                    emp.Save();
                }
            }
		}

		[Test]
		public void TestSaveComposite()
		{
            int ordKey = -1;
            CustomerGroup custGroup = new CustomerGroup();
            custGroup.es.Connection.Name = "ForeignKeyTest";
            Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";
            Order ord = new Order();
            ord.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    custGroup.GroupID = "XXXXX";
                    custGroup.GroupName = "Test";
                    custGroup.Save();

                    cust.CustomerID = "XXXXX";
                    cust.CustomerSub = "XXX";
                    cust.CustomerName = "Test";
                    cust.str().DateAdded = "2007-01-01 00:00:00";
                    cust.Active = true;
                    cust.Manager = 1;

                    ord = cust.OrderCollectionByCustID.AddNew();
                    ord.str().OrderDate = "2007-12-31 00:00:00";

                    cust.Save();
                    ordKey = ord.OrderID.Value;

                    Assert.AreEqual(1, cust.OrderCollectionByCustID.Count);
                }
            }
            finally
            {
                // Clean up
                cust = new Customer();
                cust.es.Connection.Name = "ForeignKeyTest";

                if (cust.LoadByPrimaryKey("XXXXX", "XXX"))
                {
                    OrderCollection ordColl = cust.OrderCollectionByCustID;
                    ordColl.MarkAllAsDeleted();
                    cust.MarkAsDeleted();
                    cust.Save();
                }

                custGroup = new CustomerGroup();
                custGroup.es.Connection.Name = "ForeignKeyTest";

                if (custGroup.LoadByPrimaryKey("XXXXX"))
                {
                    custGroup.MarkAsDeleted();
                    custGroup.Save();
                }
            }
		}

		[Test]
		public void TestEntityDeleteAll()
		{
            int prdId = -1;
            Product prd = new Product();
            prd.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Setup
                    prd.ProductName = "UnitTest";
                    prd.UnitPrice = 1;
                    prd.Discontinued = false;
                    for (int i = 0; i < 3; i++)
                    {
                        OrderItem oi = prd.OrderItemCollectionByProductID.AddNew();
                        oi.OrderID = i + 1;
                        oi.UnitPrice = prd.UnitPrice;
                        oi.Quantity = Convert.ToInt16(i);
                        oi.Discount = 0;
                    }
                    prd.Save();
                    prdId = prd.ProductID.Value;

                    // Test
                    prd = new Product();
                    prd.es.Connection.Name = "ForeignKeyTest";

                    Assert.IsTrue(prd.LoadByPrimaryKey(prdId));
                    Assert.AreEqual(3, prd.OrderItemCollectionByProductID.Count);
                    prd.OrderItemCollectionByProductID.MarkAllAsDeleted();
                    prd.MarkAsDeleted();
                    prd.Save();

                    prd = new Product();
                    prd.es.Connection.Name = "ForeignKeyTest";

                    Assert.IsFalse(prd.LoadByPrimaryKey(prdId));
                }
            }
            finally
            {
                prd = new Product();
                prd.es.Connection.Name = "ForeignKeyTest";

                if (prd.LoadByPrimaryKey(prdId))
                {
                    prd.OrderItemCollectionByProductID.MarkAllAsDeleted();
                    prd.MarkAsDeleted();
                    prd.Save();
                }
            }
		}

        [Test]
        public void TestCollectionDeleteAll()
        {
            int prdId = -1;
            Product prd = new Product();
            prd.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    prd.ProductName = "UnitTest";
                    prd.UnitPrice = 1;
                    prd.Discontinued = false;
                    for (int i = 0; i < 3; i++)
                    {
                        OrderItem oi = prd.OrderItemCollectionByProductID.AddNew();
                        oi.OrderID = i + 1;
                        oi.UnitPrice = prd.UnitPrice;
                        oi.Quantity = Convert.ToInt16(i);
                        oi.Discount = 0;
                    }
                    prd.Save();
                    prdId = prd.ProductID.Value;

                    // Test
                    ProductCollection collection = new ProductCollection();
                    collection.es.Connection.Name = "ForeignKeyTest";

                    Assert.IsTrue(collection.LoadAll());
                    Product entity = collection.FindByPrimaryKey(prdId);
                    Assert.AreEqual(3, entity.OrderItemCollectionByProductID.Count);
                    entity.OrderItemCollectionByProductID.MarkAllAsDeleted();
                    entity.MarkAsDeleted();
                    collection.Save();

                    prd = new Product();
                    prd.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsFalse(prd.LoadByPrimaryKey(prdId));

                    OrderItemCollection oic = new OrderItemCollection();
                    oic.es.Connection.Name = "ForeignKeyTest";
                    oic.Query.Where(oic.Query.ProductID == prdId);
                    Assert.IsFalse(oic.Query.Load());
                }
            }
            finally
            {
                prd = new Product();
                prd.es.Connection.Name = "ForeignKeyTest";

                if (prd.LoadByPrimaryKey(prdId))
                {
                    prd.OrderItemCollectionByProductID.MarkAllAsDeleted();
                    prd.MarkAsDeleted();
                    prd.Save();
                }
            }
        }

        [Test]
        public void TestMultiDeleteEntity()
        {
            int empKey = -1;
            int ordKey = -1;
            CustomerGroup custGroup = new CustomerGroup();
            custGroup.es.Connection.Name = "ForeignKeyTest";
            EmployeeCollection empColl = new EmployeeCollection();
            empColl.es.Connection.Name = "ForeignKeyTest";
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            Employee testEmp = new Employee();
            testEmp.es.Connection.Name = "ForeignKeyTest";
            Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";
            Order ord = new Order();
            ord.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Setup
                    custGroup.GroupID = "YYYYY";
                    custGroup.GroupName = "Test";
                    custGroup.Save();

                    emp = empColl.AddNew();
                    emp.LastName = "LastName";
                    emp.FirstName = "FirstName";

                    cust = emp.CustomerCollectionByStaffAssigned.AddNew();
                    cust.CustomerID = "YYYYY";
                    cust.CustomerSub = "YYY";
                    cust.CustomerName = "Test";
                    cust.str().DateAdded = "2007-01-01 00:00:00";
                    cust.Active = true;
                    cust.Manager = 1;

                    ord = emp.OrderCollectionByEmployeeID.AddNew();
                    ord.CustID = "YYYYY";
                    ord.CustSub = "YYY";
                    ord.str().OrderDate = "2007-01-01";

                    empColl.Save();
                    empKey = emp.EmployeeID.Value;
                    ordKey = ord.OrderID.Value;

                    Assert.AreEqual(1, emp.CustomerCollectionByStaffAssigned.Count);
                    Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count);
                    Assert.AreEqual(emp.EmployeeID.Value, cust.StaffAssigned.Value);
                    Assert.AreEqual(emp.EmployeeID.Value, ord.EmployeeID.Value);

                    // Test
                    testEmp.LoadByPrimaryKey(empKey);
                    testEmp.OrderCollectionByEmployeeID.MarkAllAsDeleted();
                    testEmp.CustomerCollectionByStaffAssigned.MarkAllAsDeleted();
                    testEmp.MarkAsDeleted();
                    testEmp.Save();

                    emp = new Employee();
                    emp.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsFalse(emp.LoadByPrimaryKey(empKey));

                    ord = new Order();
                    ord.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsFalse(ord.LoadByPrimaryKey(ordKey));

                    cust = new Customer();
                    cust.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsFalse(cust.LoadByPrimaryKey("YYYYY", "YYY"));
                }
            }
            finally
            {
                // Clean up
                ord = new Order();
                ord.es.Connection.Name = "ForeignKeyTest";
                if (ord.LoadByPrimaryKey(ordKey))
                {
                    ord.MarkAsDeleted();
                    ord.Save();
                }

                cust = new Customer();
                cust.es.Connection.Name = "ForeignKeyTest";
                if (cust.LoadByPrimaryKey("YYYYY", "YYY"))
                {
                    cust.MarkAsDeleted();
                    cust.Save();
                }

                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";
                if (emp.LoadByPrimaryKey(empKey))
                {
                    emp.MarkAsDeleted();
                    emp.Save();
                }

                custGroup = new CustomerGroup();
                custGroup.es.Connection.Name = "ForeignKeyTest";

                if (custGroup.LoadByPrimaryKey("YYYYY"))
                {
                    custGroup.MarkAsDeleted();
                    custGroup.Save();
                }
            }
        }

        [Test]
		public void TestForeach()
		{
			Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.LoadByPrimaryKey(1);

            int i = 0;
            string oldKey = "";
            foreach (Customer cust in emp.CustomerCollectionByManager)
            {
                i++;
                string custKey = cust.CustomerID + cust.CustomerSub;
                Assert.AreNotEqual(oldKey, custKey);
                oldKey = custKey;
            }

            Assert.AreEqual(35, i);
        }
	}
}
