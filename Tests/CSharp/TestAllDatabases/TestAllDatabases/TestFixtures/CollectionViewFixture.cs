//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using EntitySpaces.Core;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class CollectionViewFixture
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
		public void ViewOnCollection()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.ToUpper() == "DOE");
			collection.Query.Load();
			Assert.AreEqual(3, collection.Count);

            esEntityCollectionView<AggregateTest> view1 =
                new esEntityCollectionView<AggregateTest>(collection);
            Assert.AreEqual(3, view1.Count);
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void ViewOnFilteredCollection()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Load();
            Assert.AreEqual(30, collection.Count);
            collection.Filter = collection.AsQueryable().Where(f => f.LastName == "Doe");
            Assert.AreEqual(3, collection.Count);

            esEntityCollectionView<AggregateTest> view1 =
                new esEntityCollectionView<AggregateTest>(collection);
            Assert.AreEqual(30, view1.Count);
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void FilteredViewOnFilteredCollection()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Load();
            Assert.AreEqual(30, collection.Count);
            collection.Filter = collection.AsQueryable().Where(d => d.LastName == "Doe");
            Assert.AreEqual(3, collection.Count);

            esEntityCollectionView<AggregateTest> view1 =
                new esEntityCollectionView<AggregateTest>(collection);
            Assert.AreEqual(30, view1.Count);
            view1.Filter = view1.AsQueryable().Where(f => f.Age > 20);
            Assert.AreEqual(18, view1.Count);
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void TwoFilteredViewsOnFilteredCollection()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Load();
            Assert.AreEqual(30, collection.Count);
            collection.Filter = collection.AsQueryable().Where(f => f.LastName == "Doe");
            Assert.AreEqual(3, collection.Count);

            esEntityCollectionView<AggregateTest> view1 =
                new esEntityCollectionView<AggregateTest>(collection);
            Assert.AreEqual(30, view1.Count);
            view1.Filter = view1.AsQueryable().Where(f => f.Age > 20);
            Assert.AreEqual(18, view1.Count);
            Assert.AreEqual(3, collection.Count);

            esEntityCollectionView<AggregateTest> view2 =
                new esEntityCollectionView<AggregateTest>(collection);
            Assert.AreEqual(30, view2.Count);
            view2.Filter = view2.AsQueryable().Where(f => f.FirstName == "John");
            Assert.AreEqual(2, view2.Count);
            Assert.AreEqual(18, view1.Count);
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void IterateSortedViewAndCollection()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Load();
            collection.Filter = collection.AsQueryable().OrderBy(s => s.LastName);

            esEntityCollectionView<AggregateTest> view1 =
                new esEntityCollectionView<AggregateTest>(collection);
            view1.Filter = view1.AsQueryable().OrderByDescending(s => s.LastName);

            string prevName = collection[0].LastName;
            foreach (AggregateTest at in collection)
            {
                Assert.IsTrue(String.Compare(prevName, at.LastName) <= 0);
                prevName = at.LastName;
            }

            prevName = view1[0].LastName;
            foreach (AggregateTest at in view1)
            {
                Assert.IsTrue(String.Compare(prevName, at.LastName) >= 0);
                prevName = at.LastName;
            }
        }

	}
}
