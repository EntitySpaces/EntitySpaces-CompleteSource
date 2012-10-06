//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Linq;
using NUnit.Framework;

using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class SaveFixture
	{
		AggregateTestCollection aggTestColl = new AggregateTestCollection();
        AggregateTest aggTest = new AggregateTest();
        AggregateTestQuery aggTestQuery = new AggregateTestQuery();
		
		[TestFixtureSetUp]
		public void Init()
		{
        }

		[SetUp]
		public void Init2()
		{
            aggTestColl = new AggregateTestCollection();
            aggTest = new AggregateTest();
            aggTestQuery = new AggregateTestQuery();
        }

		[Test]
		public void LoadAllDeleteAllSave()
		{
			try
			{
				aggTestColl.LoadAll();
				aggTestColl.MarkAllAsDeleted();
				aggTestColl.Save();
				Assert.IsFalse(aggTestColl.LoadAll());
				UnitTestBase.RefreshDatabase();
			}
			catch(Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

        [Test]
        public void SaveComposite()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                OrderItemCollection coll = new OrderItemCollection();
                coll.es.Connection.Name = "ForeignKeyTest";

                OrderItem entity = coll.AddNew();
                entity.OrderID = 9;
                entity.ProductID = 1;
                entity.UnitPrice = 1000;
                entity.Quantity = 1000;
                entity = coll.AddNew();
                entity.OrderID = 9;
                entity.ProductID = 2;
                entity.UnitPrice = 1000;
                entity.Quantity = 1000;
                entity = coll.AddNew();
                entity.OrderID = 9;
                entity.ProductID = 3;
                entity.UnitPrice = 1000;
                entity.Quantity = 1000;

                coll.Save();

                coll = new OrderItemCollection();
                coll.es.Connection.Name = "ForeignKeyTest";

                coll.Query.Where(coll.Query.OrderID == 9);
                Assert.IsTrue(coll.Query.Load());
                Assert.AreEqual(3, coll.Count);

                // Clean up
                coll.MarkAllAsDeleted();
                coll.Save();

                coll = new OrderItemCollection();
                coll.es.Connection.Name = "ForeignKeyTest";

                coll.Query.Where(coll.Query.OrderID == 9);
                Assert.IsFalse(coll.Query.Load());

                coll = new OrderItemCollection();
                coll.es.Connection.Name = "ForeignKeyTest";

                Assert.IsTrue(coll.LoadAll());
                Assert.AreEqual(15, coll.Count);
            }
        }

        [Test]
        public void SaveWithExtraColumns()
        {
            int aggTestId = -1;

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // INSERT
                    AggregateTest t = new AggregateTest();
                    t.Age = 50;
                    t.SetColumn("extracolumn", 50);
                    t.Save();
                    aggTestId = t.Id.Value;

                    // UPDATE
                    t.Age = 51;
                    t.SetColumn("extracolumn", 51);
                    t.Save();

                    // DELETE
                    t.SetColumn("extracolumn", 52);
                    t.MarkAsDeleted();
                    t.Save();
                }
            }
            finally
            {
                // Clean up
                aggTest = new AggregateTest();
                if (aggTest.LoadByPrimaryKey(aggTestId))
                {
                    aggTest.MarkAsDeleted();
                    aggTest.Save();
                }
            }
        }

        [Test]
        public void CollectionMixedInsUpdDel()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                // Setup
                Employee newEmp = new Employee();
                newEmp.es.Connection.Name = "ForeignKeyTest";
                newEmp.LastName = "new";
                newEmp.FirstName = "new";
                newEmp.Save();

                EmployeeCollection coll = new EmployeeCollection();
                coll.es.Connection.Name = "ForeignKeyTest";
                coll.LoadAll();
                Assert.AreEqual(6, coll.Count, "Initial Load");

                // Insert
                Employee emp1 = coll.AddNew();
                emp1.FirstName = "emp1";
                emp1.LastName = "emp1";

                // Update
                Employee emp3 = coll.FindByPrimaryKey(1);
                emp3.LastName = "emp3";

                // Delete
                Employee emp4 = coll.FindByPrimaryKey(newEmp.EmployeeID.Value);
                emp4.MarkAsDeleted();

                coll.Save();

                // Confirm INSERT
                Employee empIns = new Employee();
                empIns.es.Connection.Name = "ForeignKeyTest";
                Assert.IsTrue(empIns.LoadByPrimaryKey(emp1.EmployeeID.Value), "Insert");

                // Confirm UPDATE
                Employee empUpd = new Employee();
                empUpd.es.Connection.Name = "ForeignKeyTest";
                Assert.IsTrue(empUpd.LoadByPrimaryKey(1), "Update");
                Assert.AreEqual("emp3", empUpd.LastName, "UpdateValue");

                // Confirm DELETE
                Employee empDel = new Employee();
                empDel.es.Connection.Name = "ForeignKeyTest";
                Assert.IsFalse(empDel.LoadByPrimaryKey(newEmp.EmployeeID.Value), "Delete");
            }
        }

        [Test]
        public void ErrorsWithContinueDefaultFalse()
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            coll.LoadAll();
            Assert.AreEqual(5, coll.Count, "Initial Load");

            using (esTransactionScope scope = new esTransactionScope())
            {
                try
                {
                    // INSERT would succeed
                    // but should rollback by default
                    Employee emp1 = coll.AddNew();
                    emp1.FirstName = "asdf";
                    emp1.LastName = "adf";

                    // INSERT will fail - LastName required
                    Employee emp2 = coll.AddNew();

                    // UPDATE will fail - LastName required
                    Employee emp3 = coll.FindByPrimaryKey(1);
                    emp3.LastName = null;

                    // DELETE will fail - FK constraint
                    Employee emp4 = coll.FindByPrimaryKey(2);
                    emp4.MarkAsDeleted();

                    coll.Save(false);
                }
                catch (Exception ex)
                {
                    // Save() throws exception on first error encountered
                    Assert.AreEqual(1, coll.Errors.Count(), "ExceptionCount");
                    Assert.IsTrue(ex.ToString().Length > 0, "ExceptionLength");
                }
                finally
                {
                    // Confirm nothing got INSERTed
                    EmployeeCollection coll2 = new EmployeeCollection();
                    coll2.es.Connection.Name = "ForeignKeyTest";
                    coll2.LoadAll();
                    Assert.AreEqual(5, coll2.Count, "LoadInFinally");

                    // Confirm nothing got UPDATEd
                    Employee empUpd = coll2.FindByPrimaryKey(1);
                    Assert.AreEqual("Smith", empUpd.LastName, "Update");

                    // Confirm nothing got DELETEd
                    Employee empDel = new Employee();
                    empDel.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsTrue(empDel.LoadByPrimaryKey(2), "Delete");
                }
            }
        }

        [Test]
        public void ErrorsWithContinueTrueInsUpd()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                EmployeeCollection coll = new EmployeeCollection();
                coll.es.Connection.Name = "ForeignKeyTest";

                // This employee should save fine
                Employee e = coll.AddNew();
                e.FirstName = "Test1";
                e.LastName = "K98700"; 

                // Should fail, missing LastName
                e = coll.AddNew();
                e.FirstName = "Joe";

                // Should fail, missing FirstName
                e = coll.AddNew();
                e.LastName = "Kokomo";

                // This employee should save fine
                e = coll.AddNew();
                e.FirstName = "Test4";
                e.LastName = "K98700";

                try
                {
                    coll.Save(true); // ContinueUpdateOnError
                }
                catch
                {
                    Assert.Fail("1. We shouldn't get here");
                }

                Assert.IsTrue(coll.Errors.Count() == 2, "Count");
                Assert.IsTrue(coll[0].es.RowState == esDataRowState.Unchanged, "Unchanged0");
                Assert.IsTrue(coll[1].es.RowState == esDataRowState.Added, "Added1");
                Assert.IsTrue(coll[2].es.RowState == esDataRowState.Added, "Added2");
                Assert.IsTrue(coll[3].es.RowState == esDataRowState.Unchanged, "Unchanged3");
                Assert.IsTrue(coll[0].EmployeeID != null, "Id0");
                Assert.IsTrue(coll[1].EmployeeID == null, "Id1");
                Assert.IsTrue(coll[2].EmployeeID == null, "Id2");
                Assert.IsTrue(coll[3].EmployeeID != null, "Id3");

                foreach (Employee emp in coll.Errors)
                {
                    Assert.IsTrue(emp.es.RowState == esDataRowState.Added, "ForeachRowSate");
                    Assert.IsTrue(emp.es.RowError != null, "ForeachRowError");
                    Assert.IsTrue(emp.es.RowError.Length > 0, "ForeachLength");
                }

                // Call Save again with the 2 bad records just for kicks
                try
                {
                    coll.Save(true); // ContinueUpdateOnError
                }
                catch
                {
                    Assert.Fail("2. We shouldn't get here, either");
                }

                Assert.IsTrue(coll.Errors.Count() == 2);

                // Fix our two bad records and call Save again
                coll[1].LastName = "LastName";
                coll[2].FirstName = "FirstName";

                try
                {
                    coll.Save(true); // ContinueUpdateOnError
                }
                catch
                {
                    Assert.Fail("3. We shouldn't get here, either");
                }

                Assert.IsTrue(coll.Errors.Count() == 0);

                // Load the two original records and see if they were saved even though during the
                // save there were two bad records
                coll = new EmployeeCollection();
                coll.es.Connection.Name = "ForeignKeyTest";
                coll.Query.Where(coll.Query.LastName == "K98700");
                coll.Query.Load();

                Assert.IsTrue(coll.Count() == 2, "FinalCount");
            }
        }

        [Test]
        public void ErrorsWithContinueTrueInsUpdDel()
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            coll.LoadAll();
            Assert.AreEqual(5, coll.Count, "Initial Load");

            using (esTransactionScope scope = new esTransactionScope())
            {
                // SQLite does not enforce FK constraints
                // So force a concurrency failure instead
                if (coll.es.Connection.ProviderSignature.DataProviderName
                    == "EntitySpaces.SQLiteProvider")
                {
                    Employee empConcurr = new Employee();
                    empConcurr.es.Connection.Name = "ForeignKeyTest";
                    empConcurr.LoadByPrimaryKey(2);
                    empConcurr.MarkAsDeleted();
                    empConcurr.Save();
                }

                // INSERT will succeed
                Employee emp1 = coll.AddNew();
                emp1.FirstName = "First1";
                emp1.LastName = "Last1";

                // INSERT will fail - LastName required
                Employee emp2 = coll.AddNew();

                // UPDATE will fail - LastName required
                Employee emp3 = coll.FindByPrimaryKey(1);
                emp3.LastName = null;

                // DELETE will fail - FK constraint
                Employee emp4 = coll.FindByPrimaryKey(2);
                emp4.MarkAsDeleted();

                // INSERT will succeed
                Employee emp5 = coll.AddNew();
                emp5.FirstName = "First5";
                emp5.LastName = "Last5";

                coll.Save(true);

                Assert.AreEqual(3, coll.Errors.Count(), "ErrorsCount");
                Assert.IsNotNull(coll.es.DeletedEntities, "DeletedErrors");

                foreach (Employee e in coll.Errors)
                {
                    Assert.IsTrue(e.es.RowError.Length > 0);
                }

                // Confirm only 2 rows got INSERTed
                EmployeeCollection coll2 = new EmployeeCollection();
                coll2.es.Connection.Name = "ForeignKeyTest";
                coll2.LoadAll();
                if (coll.es.Connection.ProviderSignature.DataProviderName
                    == "EntitySpaces.SQLiteProvider")
                {
                    Assert.AreEqual(6, coll2.Count, "Load");
                }
                else
                {
                    Assert.AreEqual(7, coll2.Count, "Load");

                    // Confirm nothing got DELETEd
                    Employee empDel = new Employee();
                    empDel.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsTrue(empDel.LoadByPrimaryKey(2), "Delete");
                }

                // Confirm nothing got UPDATEd
                Employee empUpd = new Employee();
                empUpd.es.Connection.Name = "ForeignKeyTest";
                Assert.IsTrue(empUpd.LoadByPrimaryKey(1));
                Assert.AreEqual("Smith", empUpd.LastName, "Update");

                // Confirm auto-incremeting PKs are brought back
                // and delete the 2 successfully inserted rows
                int emp1Id = emp1.EmployeeID.Value;
                Employee emp1Ins = new Employee();
                emp1Ins.es.Connection.Name = "ForeignKeyTest";

                Assert.IsTrue(emp1Ins.LoadByPrimaryKey(emp1Id), "LoadByPK1");
                emp1Ins.MarkAsDeleted();
                emp1Ins.Save();

                int emp5Id = emp5.EmployeeID.Value;
                Employee emp5Ins = new Employee();
                emp5Ins.es.Connection.Name = "ForeignKeyTest";

                Assert.IsTrue(emp5Ins.LoadByPrimaryKey(emp5Id), "LoadByPK2");
                emp5Ins.MarkAsDeleted();
                emp5Ins.Save();
            }
        }

        [Test]
        public void ErrorsWithContinueTrueDel()
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            coll.LoadAll();
            Assert.AreEqual(5, coll.Count, "Initial Load");

            using (esTransactionScope scope = new esTransactionScope())
            {
                // SQLite does not enforce FK constraints
                // So force a concurrency failure instead
                if (coll.es.Connection.ProviderSignature.DataProviderName
                    == "EntitySpaces.SQLiteProvider")
                {
                    Employee empConcurr = new Employee();
                    empConcurr.es.Connection.Name = "ForeignKeyTest";
                    empConcurr.LoadByPrimaryKey(2);
                    empConcurr.MarkAsDeleted();
                    empConcurr.Save();
                }

                // DELETE will fail - FK constraint
                Employee emp4 = coll.FindByPrimaryKey(2);
                emp4.MarkAsDeleted();

                coll.Save(true);

                Assert.AreEqual(1, coll.Errors.Count(), "ErrorsCount");
                Assert.IsNotNull(coll.es.DeletedEntities, "DeletedErrors");

                foreach (Employee e in coll.Errors)
                {
                    Assert.IsTrue(e.es.RowError.Length > 0);
                }

                if (coll.es.Connection.ProviderSignature.DataProviderName
                    != "EntitySpaces.SQLiteProvider")
                {
                    // Confirm same table row count
                    EmployeeCollection coll2 = new EmployeeCollection();
                    coll2.es.Connection.Name = "ForeignKeyTest";
                    coll2.LoadAll();
                    Assert.AreEqual(5, coll2.Count, "Load");

                    // Confirm nothing got DELETEd
                    Employee empDel = new Employee();
                    empDel.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsTrue(empDel.LoadByPrimaryKey(2), "Delete");
                }
            }
        }

        [Test]
        public void ErrorsWithContinueTrueNoFailures()
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            coll.LoadAll();
            Assert.AreEqual(5, coll.Count, "Initial Load");

            using (esTransactionScope scope = new esTransactionScope())
            {
                // INSERT will succeed
                Employee emp5 = coll.AddNew();
                emp5.FirstName = "First5";
                emp5.LastName = "Last5";

                coll.Save(true);

                Assert.AreEqual(0, coll.Errors.Count(), "ErrorsCount");
                Assert.IsNull(coll.es.DeletedEntities, "DeletedErrors");

                // Confirm only 1 row got INSERTed
                EmployeeCollection coll2 = new EmployeeCollection();
                coll2.es.Connection.Name = "ForeignKeyTest";
                coll2.LoadAll();
                Assert.AreEqual(6, coll2.Count, "Load");

                // Confirm auto-incremeting PKs are brought back
                // and delete the successfully inserted row
                int emp5Id = emp5.EmployeeID.Value;
                Employee emp5Ins = new Employee();
                emp5Ins.es.Connection.Name = "ForeignKeyTest";

                Assert.IsTrue(emp5Ins.LoadByPrimaryKey(emp5Id), "LoadByPK2");
                emp5Ins.MarkAsDeleted();
                emp5Ins.Save();
            }
        }

        [Test]
        public void FilteredDeleteAll()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                AggregateTestCollection aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
                aggTestColl.Filter = aggTestColl.AsQueryable().Where(f => f.LastName == "Doe");
                Assert.AreEqual(3, aggTestColl.Count);

                aggTestColl.MarkAllAsDeleted();

                aggTestColl.Filter = null;
                Assert.AreEqual(27, aggTestColl.Count);

                aggTestColl.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(27, aggTestColl.Count);
            }
        }

        // Tests adding a new row that has only Autoinc and nullable
		// fields as would be found in DataBaseRefresh
		[Test]
		public void AddNewEmptySave()
		{
            using (esTransactionScope scope = new esTransactionScope())
            {
                aggTest = aggTestColl.AddNew();
                aggTestColl.Save();
                int aggTestId = aggTest.Id.Value;

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(31, aggTestColl.Count);

                aggTest = new AggregateTest();
                Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId));
                aggTest.MarkAsDeleted();
                aggTest.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
            }
        }

		[Test]
		public void NoAddNew()
		{
            int aggTestId = -1;

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    aggTest = new AggregateTest();
                    aggTest.Age = 30;
                    aggTest.Save();
                    aggTestId = aggTest.Id.Value;

                    aggTest = new AggregateTest();
                    Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId));
                    Assert.AreEqual(30, aggTest.Age.Value);
                }
            }
            finally
            {
                // Clean up
                aggTest = new AggregateTest();
                if (aggTest.LoadByPrimaryKey(aggTestId))
                {
                    aggTest.MarkAsDeleted();
                    aggTest.Save();
                }

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
            }
		}

        [Test]
        public void SaveAlternateConnection()
        {
            Employee emp = new Employee();
            int empId = -1;

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    emp = new Employee();
                    emp.es.Connection.Name = "ForeignKeyTest";

                    emp.LastName = "McTest";
                    emp.FirstName = "Testy";
                    emp.Age = 30;
                    emp.Save();
                    empId = emp.EmployeeID.Value;

                    emp = new Employee();
                    emp.es.Connection.Name = "ForeignKeyTest";
                    Assert.IsTrue(emp.LoadByPrimaryKey(empId));
                    Assert.AreEqual(30, emp.Age.Value);
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";
                if (emp.LoadByPrimaryKey(empId))
                {
                    emp.MarkAsDeleted();
                    emp.Save();
                }
            }
        }

        [Test]
        public void EmptyEntity()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                aggTest = new AggregateTest();
                aggTest.Save();
                int aggTestId = aggTest.Id.Value;

                aggTest = new AggregateTest();
                Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId));

                // Clean up
                aggTest.MarkAsDeleted();
                aggTest.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
            }
        }

        [Test]
        public void EmptyCollection()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                aggTestColl = new AggregateTestCollection();
                aggTestColl.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
            }
        }

        [Test]
		public void RetrieveAutoIncrementingKey()
		{
            using (esTransactionScope scope = new esTransactionScope())
            {
                aggTest = aggTestColl.AddNew();
                aggTestColl.Save();
                int aggTestId = aggTest.Id.Value;

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(31, aggTestColl.Count);

                aggTest = new AggregateTest();
                Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId));
                aggTest.MarkAsDeleted();
                aggTest.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
            }
		}

		[Test]
		public void IsDirtyEntity()
		{
            int tempId = 0;
            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    aggTest = new AggregateTest();
                    Assert.IsTrue(aggTest.es.IsDirty);
                    aggTest.Save();
                    Assert.IsFalse(aggTest.es.IsDirty);
                    tempId = aggTest.Id.Value;
                    aggTest.LastName = "LastName";
                    Assert.IsTrue(aggTest.es.IsDirty);
                    aggTest.Save();
                    Assert.IsFalse(aggTest.es.IsDirty);
                    aggTest.MarkAsDeleted();
                    Assert.IsTrue(aggTest.es.IsDirty);
                    aggTest.Save();
                    Assert.IsFalse(aggTest.es.IsDirty);
                }
            }
            finally
            {
                // Cleanup
                aggTest = new AggregateTest();
                if (aggTest.LoadByPrimaryKey(tempId))
                {
                    aggTest.MarkAsDeleted();
                    aggTest.Save();
                }
            }
		}

		[Test]
		public void IsDirtyCollection()
		{
            using (esTransactionScope scope = new esTransactionScope())
            {
                Assert.IsFalse(aggTestColl.IsDirty);
                aggTest = aggTestColl.AddNew();
                Assert.IsTrue(aggTestColl.IsDirty);
                aggTestColl.Save();
                Assert.IsFalse(aggTestColl.IsDirty);
                int tempId = aggTest.Id.Value;
                aggTest.LastName = "LastName";
                Assert.IsTrue(aggTestColl.IsDirty);
                aggTestColl.Save();
                Assert.IsFalse(aggTestColl.IsDirty);
                aggTest.MarkAsDeleted();
                Assert.IsTrue(aggTestColl.IsDirty);
                aggTestColl.Save();
                Assert.IsFalse(aggTestColl.IsDirty);

                aggTest = aggTestColl.AddNew();
                aggTestColl.Save();
                tempId = aggTest.Id.Value;
                aggTest = aggTestColl.AddNew();
                aggTestColl.Save();
                int tempId2 = aggTest.Id.Value;

                aggTest = aggTestColl.FindByPrimaryKey(tempId);
                aggTest.MarkAsDeleted();
                aggTest = aggTestColl.FindByPrimaryKey(tempId2);
                aggTest.LastName = "Test";
                aggTest = aggTestColl.AddNew();
                aggTest.LastName = "Test2";
                Assert.IsTrue(aggTestColl.IsDirty);
                aggTestColl.Save();
                Assert.IsFalse(aggTestColl.IsDirty);
                int tempId3 = aggTest.Id.Value;

                // Cleanup
                aggTest = new AggregateTest();
                if (aggTest.LoadByPrimaryKey(tempId))
                {
                    aggTest.MarkAsDeleted();
                    aggTest.Save();
                }
                aggTest = new AggregateTest();
                aggTest.LoadByPrimaryKey(tempId2);
                aggTest.MarkAsDeleted();
                aggTest.Save();
                aggTest = new AggregateTest();
                aggTest.LoadByPrimaryKey(tempId3);
                aggTest.MarkAsDeleted();
                aggTest.Save();
            }
		}

        [Test]
        public void UpdateOrInsertEntity()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                // The PK does not exist, so insert
                aggTest = new AggregateTest();
                Assert.IsFalse(aggTest.LoadByPrimaryKey(0));
                aggTest.LastName = "IsInsert";
                aggTest.Save();
                int aggTestId = aggTest.Id.Value;

                // The PK does exist, so update
                aggTest = new AggregateTest();
                Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId));
                Assert.AreEqual("IsInsert", aggTest.LastName);
                aggTest.LastName = "IsUpdate";
                aggTest.Save();

                aggTest = new AggregateTest();
                Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId));
                Assert.AreEqual("IsUpdate", aggTest.LastName);

                // Clean up
                aggTest.MarkAsDeleted();
                aggTest.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
            }
        }

        [Test]
        public void UpdateOrInsertEntityCustom()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                // The PK does not exist, so insert
                AggregateTest entity = new AggregateTest();
                entity.SaveUpdateOrInsert(-1, "IsInsert");
                int aggTestId = entity.Id.Value;

                entity = new AggregateTest();
                Assert.IsTrue(entity.LoadByPrimaryKey(aggTestId));
                Assert.AreEqual("IsInsert", entity.LastName);

                // The PK does exist, so update
                entity = new AggregateTest();
                entity.SaveUpdateOrInsert(aggTestId, "IsUpdate");

                entity = new AggregateTest();
                Assert.IsTrue(entity.LoadByPrimaryKey(aggTestId));
                Assert.AreEqual("IsUpdate", entity.LastName);

                // Clean up
                entity.MarkAsDeleted();
                entity.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(30, aggTestColl.Count);
            }
        }

        [Test]
		public void UpdateEntity()
		{
			string originalName = "";
            using (esTransactionScope scope = new esTransactionScope())
            {
                int key = 0;
                aggTestColl.LoadAll();
                foreach (AggregateTest agg in aggTestColl)
                {
                    key = agg.Id.Value;
                    break;
                }
                aggTest.LoadByPrimaryKey(key);
                originalName = aggTest.LastName;
                aggTest.LastName = "TestName";
                aggTest.Save();

                aggTest = new AggregateTest();
                aggTest.LoadByPrimaryKey(key);
                Assert.AreEqual("TestName", aggTest.LastName);

                aggTest.LastName = originalName;
                aggTest.Save();
            }
		}

        [Test]
        public void SaveTwice_LoadEntity()
        {
            string originalName = "";
            int key = -1;

            using (esTransactionScope scope = new esTransactionScope())
            {
                aggTestColl.LoadAll();
                foreach (AggregateTest agg in aggTestColl)
                {
                    key = agg.Id.Value;
                    break;
                }

                aggTest.LoadByPrimaryKey(key);
                originalName = aggTest.LastName;
                aggTest.LastName = "TestName";
                aggTest.Save();

                aggTest.LastName = "TestName2";
                aggTest.Save();

                aggTest = new AggregateTest();
                aggTest.LoadByPrimaryKey(key);
                Assert.AreEqual("TestName2", aggTest.LastName);

                aggTest.LastName = originalName;
                aggTest.Save();
            }
        }

        [Test]
        public void SaveTwice_NewEntity()
        {
            int key = -1;

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    aggTest.LastName = "TestName";
                    aggTest.Save();

                    key = aggTest.Id.Value;

                    aggTest.LastName = "TestName2";
                    aggTest.Save();

                    aggTest = new AggregateTest();
                    aggTest.LoadByPrimaryKey(key);
                    Assert.AreEqual("TestName2", aggTest.LastName);
                }
            }
            finally
            {
                // Clean up
                aggTest = new AggregateTest();

                if (aggTest.LoadByPrimaryKey(key))
                {
                    aggTest.MarkAsDeleted();
                    aggTest.Save();
                }
            }
        }

        [Test]
        public void SetIdentityKeyIgnored()
        {
            int key = -1;

            using (esTransactionScope scope = new esTransactionScope())
            {
                aggTest.Id = 0;
                aggTest.LastName = "TestName";
                aggTest.Save();

                key = aggTest.Id.Value;
                Assert.Less(0, key);

                aggTest = new AggregateTest();
                aggTest.LoadByPrimaryKey(key);
                Assert.AreEqual("TestName", aggTest.LastName);

                aggTest.MarkAsDeleted();
                aggTest.Save();
            }
        }

        [Test]
        public void RejectChangesCollection()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                aggTest = aggTestColl.AddNew();
                aggTestColl.Save();
                int aggTestId = aggTest.Id.Value;

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(31, aggTestColl.Count);

                aggTest = aggTestColl.FindByPrimaryKey(aggTestId);
                aggTest.MarkAsDeleted();
                aggTestColl.AddNew();
                aggTestColl.RejectChanges();
                aggTestColl.Save();

                aggTestColl = new AggregateTestCollection();
                aggTestColl.LoadAll();
                Assert.AreEqual(31, aggTestColl.Count);

                // Cleanup
                aggTest = new AggregateTest();
                Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId));
                aggTest.MarkAsDeleted();
                aggTest.Save();
            }
        }

        [Test]
		public void ChangeWithoutLoading()
		{
            using (esTransactionScope scope = new esTransactionScope())
            {
                AggregateTestCollection changeList = new AggregateTestCollection();
                changeList.Query.Select(changeList.Query.Id, changeList.Query.LastName)
                    .Where(changeList.Query.LastName == "Doe");
                changeList.Query.Load();

                foreach (AggregateTest change in changeList)
                {
                    AggregateTest tempEntity = new AggregateTest();
                    tempEntity.Id = change.Id;
                    tempEntity.AcceptChanges(); // Sets RowState to Unchanged
                    tempEntity.LastName = "X" + change.LastName; // RowState is Modified
                    tempEntity.Save();
                }

                AggregateTestCollection testList = new AggregateTestCollection();
                testList.Query.Select(testList.Query.Id, testList.Query.LastName)
                    .Where(testList.Query.LastName == "XDoe");
                testList.Query.Load();

                foreach (AggregateTest change in testList)
                {
                    Assert.AreEqual("X", change.LastName.Substring(0, 1));
                }

                // Change it back
                foreach (AggregateTest change in changeList)
                {
                    AggregateTest tempEntity = new AggregateTest();
                    tempEntity.Id = change.Id;
                    tempEntity.AcceptChanges(); // Sets RowState to Unchanged
                    tempEntity.LastName = change.LastName; // RowState is Modified
                    tempEntity.Save();
                }
            }
        }

        [Test]
        public void DeleteWithoutLoading()
        {
            using (esTransactionScope scope = new esTransactionScope())
            {
                AggregateTestCollection deleteList = new AggregateTestCollection();
                deleteList.Query.Select(deleteList.Query.Id, deleteList.Query.LastName)
                    .Where(deleteList.Query.LastName == "Doe");
                Assert.IsTrue(deleteList.Query.Load());

                foreach (AggregateTest entity in deleteList)
                {
                    AggregateTest tempEntity = new AggregateTest();
                    tempEntity.Id = entity.Id;
                    tempEntity.AcceptChanges(); // Sets RowState to Unchanged
                    tempEntity.MarkAsDeleted(); // RowState is Deleted
                    tempEntity.Save();
                }

                AggregateTestCollection testList = new AggregateTestCollection();
                testList.Query.Select(testList.Query.Id, testList.Query.LastName)
                    .Where(testList.Query.LastName == "Doe");
                Assert.IsFalse(testList.Query.Load());
            }
        }

        [Test]
		public void PrimaryKeyNotFirstColumn()
		{
			KeyNotFirstCollection notFirstTestColl = new KeyNotFirstCollection();

            switch (notFirstTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        notFirstTestColl.LoadAll();
                        notFirstTestColl.MarkAllAsDeleted();
                        notFirstTestColl.Save();

                        notFirstTestColl = new KeyNotFirstCollection();
                        KeyNotFirst notFirstTest = notFirstTestColl.AddNew();
                        notFirstTestColl.Save();

                        notFirstTestColl = new KeyNotFirstCollection();
                        notFirstTestColl.LoadAll();
                        Assert.IsTrue(notFirstTestColl.Count > 0);
                    }
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
		}

        [Test]
		public void DynamicSaveNull()
		{
            int id = -1;
            //if (aggTestColl.es.Connection.SqlAccessType ==
            //    EntitySpaces.Interfaces.esSqlAccessType.DynamicSQL)
            //{
            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Create our test record
                    aggTest = new AggregateTest();
                    aggTest.FirstName = "TestFirst";
                    aggTest.LastName = "TestLast";
                    aggTest.Save();

                    // Get the ID of the newly saved object
                    id = aggTest.Id.Value;

                    // Confirm it saved
                    aggTest = new AggregateTest();
                    aggTest.LoadByPrimaryKey(id);
                    Assert.AreEqual("TestFirst", aggTest.FirstName);
                    Assert.AreEqual("TestLast", aggTest.LastName);

                    // Set the LastName to null
                    // FirstName to a empty string
                    aggTest.FirstName = String.Empty;
                    aggTest.LastName = null;
                    aggTest.Save();

                    // Re-read it, confirm null/empty
                    aggTest = new AggregateTest();
                    aggTest.LoadByPrimaryKey(id);

                    // Oracle is not ANSI SQL compliant.
                    // It treats an empty string as NULL.
                    if (aggTest.es.Connection.ProviderSignature.DataProviderName ==
                        "EntitySpaces.OracleClientProvider")
                    {
                        Assert.IsNull(aggTest.FirstName);
                    }
                    else
                    {
                        Assert.AreEqual("", aggTest.FirstName);
                        Assert.IsNotNull(aggTest.FirstName);
                    }
                    Assert.IsNull(aggTest.LastName);
                }
            }
            finally
            {
                // Clean up
                aggTest = new AggregateTest();
                if (aggTest.LoadByPrimaryKey(id))
                {
                    aggTest.MarkAsDeleted();
                    aggTest.Save();
                }
            }
			//}
            //else
            //{
            //    Assert.Ignore("DynamicSQL test only.");
            //}
		}

        [Test]
        public void RetrieveComputed()
        {
            long id = -1;
            ConcurrencyTestChild entity = new ConcurrencyTestChild();

            switch (entity.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            // Create test record
                            entity = new ConcurrencyTestChild();
                            entity.Name = "TestFirst";
                            entity.DefaultTest = Convert.ToDateTime("2010-01-01");
                            entity.ColumnA = 1;
                            entity.ColumnB = 2;
                            entity.Save();

                            // Get the ID of the newly saved object
                            id = entity.Id.Value;

                            // Check computed column is retrieved on insert
                            Assert.AreEqual(3, entity.ComputedAB.Value);

                            // Retrieve record for update
                            entity = new ConcurrencyTestChild();
                            entity.LoadByPrimaryKey(id);

                            // Set the columns for computation
                            entity.ColumnA = 10;
                            entity.ColumnB = 20;
                            entity.Save();

                            // Check computed values are retrieved on update
                            Assert.AreEqual(30, entity.ComputedAB.Value);
                        }
                    }
                    finally
                    {
                        // Clean up
                        entity = new ConcurrencyTestChild();
                        if (entity.LoadByPrimaryKey(id))
                        {
                            entity.MarkAsDeleted();
                            entity.Save();
                        }
                    }
                    break;

                default:
                    Assert.Ignore("SQL Server only");
                    break;
            }
        }

        [Test]
        public void RetrieveDefaultOnInsert()
        {
            long id = -1;
            ConcurrencyTestChild entity = new ConcurrencyTestChild();

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Create test record
                    entity = new ConcurrencyTestChild();
                    entity.Name = "TestFirst";
                    entity.Save();

                    // Get the ID of the newly saved object
                    id = entity.Id.Value;

                    // Check default value is retrieved on insert
                    Assert.AreEqual(DateTime.Now.Day, entity.DefaultTest.Value.Day);
                }
            }
            finally
            {
                // Clean up
                entity = new ConcurrencyTestChild();
                if (entity.LoadByPrimaryKey(id))
                {
                    entity.MarkAsDeleted();
                    entity.Save();
                }
            }
        }

        [Test]
        public void DefaultNotNullOnInsert()
        {
            int id = -1;
            DefaultTest entity = new DefaultTest();

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Create test record
                    entity = new DefaultTest();
                    entity.Save();

                    // Get the ID of the newly saved object
                    id = entity.TestId.Value;

                    // Check default value was set on insert
                    entity = new DefaultTest();
                    Assert.IsTrue(entity.LoadByPrimaryKey(id));
                    Assert.AreEqual(0, entity.DefaultNotNullInt.Value);
                    Assert.AreEqual(false, entity.DefaultNotNullBool.Value);
                }
            }
            finally
            {
                // Clean up
                entity = new DefaultTest();
                if (entity.LoadByPrimaryKey(id))
                {
                    entity.MarkAsDeleted();
                    entity.Save();
                }
            }
        }

        [Test]
        public void DefaultIsDirtyCollection()
        {
            int id = -1;
            DefaultTest entity = new DefaultTest();

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Create test record
                    entity = new DefaultTest();
                    entity.DefaultNotNullBool = true;
                    entity.DefaultNotNullInt = -1;
                    entity.Save();

                    // Get the ID of the newly saved object
                    id = entity.TestId.Value;

                    DefaultTestCollection coll = new DefaultTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.AreEqual(true, coll[0].DefaultNotNullBool.Value);
                    Assert.AreEqual(-1, coll[0].DefaultNotNullInt.Value);
                    Assert.IsFalse(coll[0].es.IsDirty, "Load Dirty");
                    Assert.AreEqual(0, coll[0].es.ModifiedColumns.Count, "Load Count");

                    coll[0].DefaultNotNullBool = false;
                    Assert.AreEqual(1, coll[0].es.ModifiedColumns.Count, "Bool Count");
                    Assert.IsTrue(coll[0].es.IsDirty, "Bool Dirty");

                    coll = new DefaultTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.AreEqual(true, coll[0].DefaultNotNullBool.Value);
                    Assert.AreEqual(-1, coll[0].DefaultNotNullInt.Value);

                    coll[0].DefaultNotNullInt = 0;
                    Assert.AreEqual(1, coll[0].es.ModifiedColumns.Count, "Int Count");
                    Assert.IsTrue(coll[0].es.IsDirty, "Int Dirty");

                }
            }
            finally
            {
                // Clean up
                entity = new DefaultTest();
                if (entity.LoadByPrimaryKey(id))
                {
                    entity.MarkAsDeleted();
                    entity.Save();
                }
            }
        }

        [Test]
        public void DefaultInConstructorIsDirtyCollection()
        {
            long id = -1;
            ConstructorTest entity = new ConstructorTest();

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Create test record
                    entity = new ConstructorTest();
                    entity.DefaultBool = true;
                    entity.DefaultInt = -1;
                    entity.DefaultDateTime = Convert.ToDateTime("2000-01-01");
                    entity.DefaultString = "Not new";
                    entity.Save();

                    // Get the ID of the newly saved object
                    id = entity.ConstructorTestId.Value;

                    // bool
                    ConstructorTestCollection coll = new ConstructorTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.AreEqual(true, coll[0].DefaultBool.Value);
                    Assert.AreEqual(-1, coll[0].DefaultInt.Value);
                    Assert.AreEqual(Convert.ToDateTime("2000-01-01"), coll[0].DefaultDateTime.Value);
                    Assert.AreEqual("Not new", coll[0].DefaultString);
                    Assert.IsFalse(coll[0].es.IsDirty, "Load Dirty");
                    Assert.AreEqual(0, coll[0].es.ModifiedColumns.Count, "Load Count");

                    coll[0].DefaultBool = false;
                    Assert.AreEqual(1, coll[0].es.ModifiedColumns.Count, "Bool Count");
                    Assert.IsTrue(coll[0].es.IsDirty, "Bool Dirty");
                    coll.Save();

                    // int
                    coll = new ConstructorTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.AreEqual(false, coll[0].DefaultBool.Value);
                    Assert.AreEqual(-1, coll[0].DefaultInt.Value);
                    Assert.AreEqual(Convert.ToDateTime("2000-01-01"), coll[0].DefaultDateTime.Value);
                    Assert.AreEqual("Not new", coll[0].DefaultString);

                    coll[0].DefaultInt = 0;
                    Assert.AreEqual(1, coll[0].es.ModifiedColumns.Count, "Int Count");
                    Assert.IsTrue(coll[0].es.IsDirty, "Int Dirty");
                    coll.Save();

                    // DateTime
                    coll = new ConstructorTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.AreEqual(false, coll[0].DefaultBool.Value);
                    Assert.AreEqual(0, coll[0].DefaultInt.Value);
                    Assert.AreEqual(Convert.ToDateTime("2000-01-01"), coll[0].DefaultDateTime.Value);
                    Assert.AreEqual("Not new", coll[0].DefaultString);

                    coll[0].DefaultDateTime = Convert.ToDateTime("1900-01-01");
                    Assert.AreEqual(1, coll[0].es.ModifiedColumns.Count, "DateTime Count");
                    Assert.IsTrue(coll[0].es.IsDirty, "DateTime Dirty");
                    coll.Save();

                    // String
                    coll = new ConstructorTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.AreEqual(false, coll[0].DefaultBool.Value);
                    Assert.AreEqual(0, coll[0].DefaultInt.Value);
                    Assert.AreEqual(Convert.ToDateTime("1900-01-01"), coll[0].DefaultDateTime.Value);
                    Assert.AreEqual("Not new", coll[0].DefaultString);

                    coll[0].DefaultString = "Is newer";
                    Assert.AreEqual(1, coll[0].es.ModifiedColumns.Count, "String Count");
                    Assert.IsTrue(coll[0].es.IsDirty, "String Dirty");
                    coll.Save();

                    coll = new ConstructorTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.AreEqual(false, coll[0].DefaultBool.Value);
                    Assert.AreEqual(0, coll[0].DefaultInt.Value);
                    Assert.AreEqual(Convert.ToDateTime("1900-01-01"), coll[0].DefaultDateTime.Value);
                    Assert.AreEqual("Is newer", coll[0].DefaultString);

                    // Constructor defaults
                    coll[0].MarkAsDeleted();
                    coll.AddNew();
                    coll.Save();

                    coll = new ConstructorTestCollection();
                    Assert.IsTrue(coll.LoadAll());
                    Assert.IsFalse(coll.IsDirty, "Coll Constructor Dirty");
                    Assert.IsFalse(coll[0].es.IsDirty, "Entity Constructor Dirty");
                    Assert.AreEqual(0, coll[0].es.ModifiedColumns.Count);
                    Assert.AreEqual(false, coll[0].DefaultBool.Value);
                    Assert.AreEqual(0, coll[0].DefaultInt.Value);
                    Assert.AreEqual(DateTime.Now.Year, coll[0].DefaultDateTime.Value.Year);
                    Assert.AreEqual("[new]", coll[0].DefaultString);
                }
            }
            finally
            {
                // Clean up
                entity = new ConstructorTest();
                if (entity.LoadByPrimaryKey(id))
                {
                    entity.MarkAsDeleted();
                    entity.Save();
                }
            }
        }
    }
}
