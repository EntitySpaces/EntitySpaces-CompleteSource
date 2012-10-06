//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;

using EntitySpaces.Interfaces;

using BusinessObjects;

namespace Tests.Base
{
    [TestFixture]
    public class RowStateIsDirty
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

        #region Single Entity

        [Test]
        public void TestAddNewOnEntity()
        {
            aggTest = new AggregateTest();
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
           // Assert.IsTrue(aggTest.es.RowState == esDataRowState.Detached);

            // We set a property which creates the DataTable
            aggTest.FirstName = "Mike";

            Assert.IsTrue(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsTrue(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 1);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Added);
        }

        [Test]
        public void TestAcceptChangesOnEntity()
        {
            aggTest = new AggregateTest();
            aggTest.FirstName = "Mike";
            aggTest.AcceptChanges();

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsFalse(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Unchanged);
        }

        [Test]
        public void TestRejectChangesOnEntity1()
        {
            aggTest = new AggregateTest();
            aggTest.FirstName = "Mike";
            aggTest.RejectChanges();

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsFalse(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Unchanged);
        }

        [Test]
        public void TestRejectChangesOnEntity2()
        {
            aggTest = new AggregateTest();
            aggTest.FirstName = "Mike";
            aggTest.AcceptChanges();

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsFalse(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Unchanged);

            aggTest.FirstName = "Joe";
            aggTest.RejectChanges();

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsFalse(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Unchanged);
        }

        [Test]
        public void TestTrueIsDirtyLogicOnEntity()
        {
            aggTest = new AggregateTest();
            aggTest.FirstName = "Mike";
            aggTest.AcceptChanges();

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsFalse(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Unchanged);

            // Let's change it
            aggTest.FirstName = "Joe";

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsTrue(aggTest.es.IsModified);
            Assert.IsTrue(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 1);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Modified);

            // Now let's set it back to it's original value
            aggTest.FirstName = "Mike";

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsFalse(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Unchanged);

            // Let's change it again, notice we are no longer dirty now
            aggTest.FirstName = "Joe";

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsTrue(aggTest.es.IsModified);
            Assert.IsTrue(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 1);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Modified);
        }

        [Test]
        public void TestDeleteOnEntity()
        {
            aggTest = new AggregateTest();
            aggTest.FirstName = "Mike";
            aggTest.AcceptChanges();

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsFalse(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsFalse(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Unchanged);

            // Let's mark it as deleted
            aggTest.MarkAsDeleted();

            Assert.IsFalse(aggTest.es.IsAdded);
            Assert.IsTrue(aggTest.es.IsDeleted);
            Assert.IsFalse(aggTest.es.IsModified);
            Assert.IsTrue(aggTest.es.IsDirty);
            Assert.IsTrue(aggTest.es.ModifiedColumns.Count == 0);
            Assert.IsTrue(aggTest.es.RowState == esDataRowState.Deleted);
        }

        #endregion

        #region Collections

        [Test]
        public void TestAddNewOnCollection()
        {
            aggTestColl = new AggregateTestCollection();
            Assert.IsFalse(aggTestColl.IsDirty);

            AggregateTest t = aggTestColl.AddNew();
            Assert.IsTrue(aggTestColl.IsDirty);
        }

        [Test]
        public void TestAcceptChangesOnCollection()
        {
            aggTestColl = new AggregateTestCollection();

            AggregateTest aggTest = aggTestColl.AddNew();
            aggTest.FirstName = "Mike";

            aggTestColl.AcceptChanges();

            Assert.IsFalse(aggTestColl.IsDirty);
        }

        [Test]
        public void TestRejectChangesOnCollection()
        {
            aggTestColl = new AggregateTestCollection();

            AggregateTest aggTest = aggTestColl.AddNew();
            aggTest.FirstName = "Mike";

            aggTestColl.RejectChanges();

            Assert.IsFalse(aggTestColl.IsDirty);
        }

        [Test]
        public void TestRejectChangesOnCollection2()
        {
            aggTestColl = new AggregateTestCollection();

            AggregateTest aggTest = aggTestColl.AddNew();
            aggTest.FirstName = "Mike";

            aggTestColl.AcceptChanges();

            Assert.IsFalse(aggTestColl.IsDirty);

            aggTest.FirstName = "Joe";
            aggTest.RejectChanges();

            Assert.IsFalse(aggTestColl.IsDirty);
        }

        [Test]
        public void TestTrueIsDirtyLogicOnCollection()
        {
            aggTestColl = new AggregateTestCollection();

            AggregateTest aggTest = aggTestColl.AddNew();
            aggTest.FirstName = "Mike";

            aggTestColl.AcceptChanges();
            Assert.IsFalse(aggTestColl.IsDirty);

            // Let's change it
            aggTest.FirstName = "Joe";
            Assert.IsTrue(aggTestColl.IsDirty);

            // Now let's set it back to it's original value
            aggTest.FirstName = "Mike";
            Assert.IsFalse(aggTestColl.IsDirty);

            // Let's change it again, notice we are no longer dirty now
            aggTest.FirstName = "Joe";
            Assert.IsTrue(aggTestColl.IsDirty);
        }

        [Test]
        public void TestDeleteOnCollection()
        {
            aggTestColl = new AggregateTestCollection();

            AggregateTest aggTest = aggTestColl.AddNew();
            aggTest.FirstName = "Mike";

            aggTestColl.AcceptChanges();
            Assert.IsFalse(aggTestColl.IsDirty);

            // Let's mark it as deleted
            aggTest.MarkAsDeleted();
            Assert.IsTrue(aggTestColl.IsDirty);
        }

        #endregion
    }
}