//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class ManyToOneFixture
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
			Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";
            
            cust.LoadByPrimaryKey("01001", "001");
			Assert.IsTrue(cust.UpToEmployeeByManager.es.HasData);
			Assert.IsTrue(cust.UpToEmployeeByStaffAssigned.es.HasData);
		}

		[Test]
		public void TestNullReferences()
		{
            string cSub;
			Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";

            switch (cust.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    cSub = "1  ";
                    break;

                default:
                    cSub = "1";
                    break;
            }

            if (cust.LoadByPrimaryKey("10000", cSub))
            {
                if (cust.UpToEmployeeByStaffAssigned != null)
                {
                    Assert.Fail("Should be null");
                }
            }
            else
            {
                Assert.Fail("It should load");
            }
		}

        [Test]
        public void TestAssignReference()
        {
            string cSub;
            Customer cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";

            switch (cust.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    cSub = "1  ";
                    break;

                default:
                    cSub = "1";
                    break;
            }

            if (cust.LoadByPrimaryKey("10000", cSub))
            {
                if (cust.UpToEmployeeByStaffAssigned != null)
                {
                    Assert.Fail("Should be null");
                }
            }
            else
            {
                Assert.Fail("It should load");
            }

            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            emp.LoadByPrimaryKey(1);

            cust.UpToEmployeeByStaffAssigned = emp;
            cust.Save();

            cust = new Customer();
            cust.es.Connection.Name = "ForeignKeyTest";

            if (cust.LoadByPrimaryKey("10000", cSub))
            {
                Assert.IsNotNull(cust.UpToEmployeeByStaffAssigned);
            }
            else
            {
                Assert.Fail("It should load");
            }

            cust.StaffAssigned = null;
            cust.Save();

            cust.UpToEmployeeByStaffAssigned = null;
            Assert.IsNull(cust.UpToEmployeeByStaffAssigned);


        }

        [Test]
		public void TestCompositeForeignKey()
        {
            Order ord = new Order();
            ord.es.Connection.Name = "ForeignKeyTest";

            Assert.IsTrue(ord.LoadByPrimaryKey(1), "Loaded");
            Assert.IsTrue(ord.UpToCustomerByCustID.es.HasData, "HasData");
        }

		[Test]
		public void TestSelfReference()
		{
			Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.LoadByPrimaryKey(2);
			Assert.IsTrue(emp.UpToEmployeeBySupervisor.es.HasData);
		}
	}
}
