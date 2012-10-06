//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;
using System.Linq;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class CollectionFixture
	{
        [Test]
        public void CollectionFindByPrimaryKey()
        {
            AggregateTest aggTest = new AggregateTest();
            aggTest.Query
                .Select()
                .Where
                (
                    aggTest.Query.FirstName.Equal("Sarah"),
                    aggTest.Query.LastName.Equal("Doe")
                );
            Assert.IsTrue(aggTest.Query.Load());
            int primaryKey = aggTest.Id.Value;

            AggregateTestCollection aggCloneColl = new AggregateTestCollection();
            aggCloneColl.LoadAll();
            AggregateTest aggClone = aggCloneColl.FindByPrimaryKey(primaryKey);
            Assert.AreEqual("Doe", aggClone.str().LastName);
            Assert.AreEqual("Sarah", aggClone.str().FirstName);
        }

        [Test]
        public void CollectionSort()
        {
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
            aggTestColl.LoadAll();
            aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(s => s.Age);

            int? oldAge = 0;
            foreach (AggregateTest agg in aggTestColl)
            {
                if (agg.Age.HasValue)
                {
                    Assert.IsTrue(oldAge <= agg.Age);
                    oldAge = agg.Age;
                }
            }

            aggTestColl.Filter = aggTestColl.AsQueryable().OrderByDescending(s => s.Age);

            oldAge = 1000;
            foreach (AggregateTest agg in aggTestColl)
            {
                if (agg.Age.HasValue)
                {
                    Assert.IsTrue(oldAge >= agg.Age);
                    oldAge = agg.Age;
                }
            }

            aggTestColl.Filter = null;

            bool sorted = true;
            oldAge = 0;
            foreach (AggregateTest agg in aggTestColl)
            {
                if (agg.Age.HasValue)
                {
                    if (!(oldAge <= agg.Age))
                    {
                        sorted = false;
                    }
                    oldAge = agg.Age;
                }
            }
            Assert.IsFalse(sorted);
        }

        [Test]
        public void CollectionSortDate()
        {
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
            aggTestColl.LoadAll();
            aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(s => s.HireDate);

            DateTime? oldDate = Convert.ToDateTime("01/01/0001");
            foreach (AggregateTest agg in aggTestColl)
            {
                if (agg.HireDate.HasValue)
                {
                    Assert.IsTrue(oldDate <= agg.HireDate);
                    oldDate = agg.HireDate;
                }
            }
        }

        [Test]
        public void CollectionFilter()
        {
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
            aggTestColl.LoadAll();
            Assert.AreEqual(30, aggTestColl.Count);
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(f => f.LastName == "Doe");
            Assert.AreEqual(3, aggTestColl.Count);

            foreach (AggregateTest agg in aggTestColl)
            {
                Assert.AreEqual("Doe", agg.LastName);
            }

            aggTestColl.Filter = null;
            Assert.AreEqual(30, aggTestColl.Count);

            aggTestColl.Filter = aggTestColl.AsQueryable().Where(f => f.LastName == "x");
            Assert.AreEqual(0, aggTestColl.Count);
            aggTestColl.Filter = null;
            Assert.AreEqual(30, aggTestColl.Count);
        }

        [Test]
        public void CollectionFilterDate()
        {
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
            aggTestColl.LoadAll();
            aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(s => s.Id);

            AggregateTest entity = (AggregateTest)aggTestColl[5];
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(f => f.HireDate > entity.HireDate);

            Assert.AreEqual(4, aggTestColl.Count);

            aggTestColl.Filter = null;
            Assert.AreEqual(30, aggTestColl.Count);
        }

        //[Test]
        //public void AssignPrimaryKeysTest()
        //{
        //    AggregateTestCollection aggTestColl = new AggregateTestCollection();
        //    Assert.IsTrue(aggTestColl.LoadAll());
        //    Assert.AreEqual(1, aggTestColl.TestAssignPrimaryKeys());
        //    Assert.AreEqual(0, aggTestColl.TestRemovePrimaryKeys());
        //}

        [Test]
        public void FilteredDeleteAll()
        {
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
            aggTestColl.LoadAll();
            Assert.AreEqual(30, aggTestColl.Count);
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(f => f.LastName == "Doe");
            Assert.AreEqual(3, aggTestColl.Count);

            aggTestColl.MarkAllAsDeleted();

            aggTestColl.Filter = null;
            Assert.AreEqual(27, aggTestColl.Count);
        }

        [Test]
        public void TestForEach()
        {
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
            aggTestColl.LoadAll();
            foreach (AggregateTest entity in aggTestColl)
            {
                entity.LastName = "E_" + entity.LastName;
            }
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(f => f.LastName.Contains("E_"));
            Assert.AreEqual(30, aggTestColl.Count);
        }

        [Test]
        public void TestCustomForEach()
        {
            AggregateTestCollection.CustomForEach();
        }

        [Test]
        public void TestAttachDetachEntityModified()
        {
            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    AggregateTestCollection aggTestColl = new AggregateTestCollection();
                    AggregateTestCollection aggCloneColl = new AggregateTestCollection();
                    aggCloneColl.LoadAll();
                    foreach (AggregateTest entity in aggCloneColl)
                    {
                        if (entity.LastName == "Doe")
                        {
                            entity.MarkAllColumnsAsDirty(esDataRowState.Modified);
                            aggTestColl.AttachEntity(aggCloneColl.DetachEntity(entity));
                            break;
                        }
                    }
                    Assert.IsTrue(aggTestColl.IsDirty);
                    aggTestColl.Save();
                    Assert.IsFalse(aggTestColl.IsDirty, "Collection is still dirty");
                    aggTestColl.LoadAll();
                    Assert.AreEqual(30, aggTestColl.Count);
                }
            }
            finally
            {
                UnitTestBase.RefreshDatabase();
            }
        }

        [Test]
        public void TestAttachDetachEntityAdded()
        {
            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    AggregateTestCollection aggTestColl = new AggregateTestCollection();
                    AggregateTestCollection aggCloneColl = new AggregateTestCollection();
                    aggCloneColl.LoadAll();
                    foreach (AggregateTest entity in aggCloneColl)
                    {
                        if (entity.LastName == "Doe")
                        {
                            entity.MarkAllColumnsAsDirty(esDataRowState.Added);
                            aggTestColl.AttachEntity(aggCloneColl.DetachEntity(entity));
                            break;
                        }
                    }
                    Assert.IsTrue(aggTestColl.IsDirty);
                    aggTestColl.Save();
                    Assert.IsFalse(aggTestColl.IsDirty, "Collection is still dirty");
                    aggTestColl.LoadAll();
                    Assert.AreEqual(31, aggTestColl.Count);
                }
            }
            finally
            {
                UnitTestBase.RefreshDatabase();
            }
        }

        [Test]
        public void CombineCollections()
        {
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            coll.LoadAll();
            Assert.AreEqual(15, coll.Count);

            OrderItemCollection coll2 = new OrderItemCollection();
            coll2.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll2.es.Connection);

            coll2.LoadAll();
            Assert.AreEqual(15, coll2.Count);

            coll.Combine(coll2);
            Assert.AreEqual(30, coll.Count);
        }

        [Test]
        public void CombineQueriedCollections()
        {
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            coll.Query.Where(coll.Query.ProductID == 1);
            coll.Query.Load();
            Assert.AreEqual(4, coll.Count);

            OrderItemCollection coll2 = new OrderItemCollection();
            coll2.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll2.es.Connection);

            coll2.Query.Where(coll2.Query.ProductID == 2);
            coll2.Query.Load();
            Assert.AreEqual(3, coll2.Count);

            coll.Combine(coll2);
            Assert.AreEqual(7, coll.Count);
        }

        [Test]
        public void CombineJoinQueriedCollections()
        {
            EmployeeQuery eq1 = new EmployeeQuery("e1");
            CustomerQuery cq1 = new CustomerQuery("c1");

            eq1.Select(eq1, cq1.CustomerName);
            eq1.InnerJoin(cq1).On(eq1.EmployeeID == cq1.Manager);
            eq1.Where(eq1.EmployeeID == 1);

            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);
            collection.Load(eq1);
            Assert.AreEqual(35, collection.Count);

            EmployeeQuery eq2 = new EmployeeQuery("e2");
            CustomerQuery cq2 = new CustomerQuery("c2");

            eq2.Select(eq2, cq2.CustomerName);
            eq2.InnerJoin(cq2).On(eq2.EmployeeID == cq2.Manager);
            eq2.Where(eq2.EmployeeID == 2);

            EmployeeCollection collection2 = new EmployeeCollection();
            collection2.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection2.es.Connection);
            collection2.Load(eq2);
            Assert.AreEqual(12, collection2.Count);

            collection.Combine(collection2);
            Assert.AreEqual(47, collection.Count);

            foreach (Employee emp in collection)
            {
                string custName = CustomerMetadata.ColumnNames.CustomerName;
                Assert.IsTrue(emp.GetColumn(custName).ToString().Length > 0);
            }
        }

        [Test]
        public void CombineFilteredOriginal()
        {
            // Load a collection and apply a filter
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            coll.LoadAll();
            Assert.AreEqual(15, coll.Count);
            coll.Filter = coll.AsQueryable().Where(f => f.ProductID == 1);
            Assert.AreEqual(4, coll.Count);

            // Load a second collection
            OrderItemCollection coll2 = new OrderItemCollection();
            coll2.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll2.es.Connection);

            coll2.LoadAll();
            Assert.AreEqual(15, coll2.Count);

            // Combine the 15 rows from the second collection
            // to the 15 rows from the first collection.
            // Since the first collection still has a filter,
            // only 8 rows are counted (4 from the first and 4 from the second).
            coll.Combine(coll2);
            Assert.AreEqual(8, coll.Count);

            // Remove the filter to count all 30 rows.
            coll.Filter = null;
            Assert.AreEqual(30, coll.Count);
        }

        [Test]
        public void CombineFilteredCombine()
        {
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            coll.LoadAll();
            Assert.AreEqual(15, coll.Count);

            OrderItemCollection coll2 = new OrderItemCollection();
            coll2.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll2.es.Connection);

            coll2.LoadAll();
            Assert.AreEqual(15, coll2.Count);
            coll2.Filter = coll.AsQueryable().Where(f => f.ProductID == 1);
            Assert.AreEqual(4, coll2.Count);

            coll.Combine(coll2);
            Assert.AreEqual(19, coll.Count);
        }

        [Test]
        public void CombineFilteredOriginalAndCombine()
        {
            // Load a collection and apply a filter.
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            coll.LoadAll();
            Assert.AreEqual(15, coll.Count);
            coll.Filter = coll.AsQueryable().Where(f => f.ProductID == 1);
            Assert.AreEqual(4, coll.Count);

            // Load a second collection and apply a different filter.
            OrderItemCollection coll2 = new OrderItemCollection();
            coll2.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll2.es.Connection);

            coll2.LoadAll();
            Assert.AreEqual(15, coll2.Count);
            coll2.Filter = coll2.AsQueryable().Where(f => f.ProductID == 2);
            Assert.AreEqual(3, coll2.Count);

            // Add only the 3 filtered rows from coll2
            // to all 15 rows in coll1.
            // The filter for coll1 still applies.
            // None of the items from coll2 appear,
            // until the filter is removed from coll1.
            coll.Combine(coll2);
            Assert.AreEqual(4, coll.Count);
            coll.Filter = null;
            Assert.AreEqual(18, coll.Count);
        }

        [Test]
        public void CombineBuildOriginal()
        {
            // Start with an empty collection
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            Assert.AreEqual(0, coll.Count);

            OrderItemCollection coll2 = new OrderItemCollection();
            coll2.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll2.es.Connection);

            coll2.LoadAll();
            Assert.AreEqual(15, coll2.Count);
            coll2.Filter = coll2.AsQueryable().Where(f => f.ProductID == 1);
            Assert.AreEqual(4, coll2.Count);

            // Add only the 4 filtered rows for coll2
            coll.Combine(coll2);
            Assert.AreEqual(4, coll.Count);

            OrderItemCollection coll3 = new OrderItemCollection();
            coll3.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll3.es.Connection);

            coll3.LoadAll();
            Assert.AreEqual(15, coll3.Count);
            coll3.Filter = coll3.AsQueryable().Where(f => f.ProductID == 2);
            Assert.AreEqual(3, coll3.Count);

            // Add only the 3 filtered rows for coll3
            // coll1 now has all 7 rows
            coll.Combine(coll3);
            Assert.AreEqual(7, coll.Count);
        }

    }
}
