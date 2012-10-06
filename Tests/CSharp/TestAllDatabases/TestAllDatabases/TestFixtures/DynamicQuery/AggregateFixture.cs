//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace Tests.Base
{
	[TestFixture]
	public class AggregateFixture
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
		public void EmptyQueryReturnsSelectAll()
		{
            aggTestColl = new AggregateTestCollection();
            Assert.IsTrue(aggTestColl.LoadAll());
            Assert.AreEqual(30, aggTestColl.Count, "LoadAll");

            aggTestColl = new AggregateTestCollection();
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(30, aggTestColl.Count, "Query.Load");

            aggTestColl = new AggregateTestCollection();
            aggTestColl.Query.LoadDataTable();
			Assert.AreEqual(0, aggTestColl.Count, "Query.LoadDataTable");
		}

        [Test]
        public void AddAggregateAvg()
        {
            aggTestColl.Query.Select
            (
				aggTestColl.Query.Salary.Avg().As("Avg")
            );

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void AddAggregateCount()
        {
            aggTestColl.Query.Select
            (
				aggTestColl.Query.Salary.Count().As("Count")
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void AddAggregateMin()
        {
            aggTestColl.Query.Select
            (
				aggTestColl.Query.Salary.Min().As("Min")
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void AddAggregateMax()
        {
            aggTestColl.Query.Select
            (
				aggTestColl.Query.Salary.Max().As("Max")
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void AddAggregateSum()
        {
            aggTestColl.Query.Select
            (
				aggTestColl.Query.Salary.Sum().As("Sum")
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void AddAggregateStdDev()
        {
            if (aggTestColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not supported by SqlCe.");
            }
            else
            {
                aggTestColl.Query.Select
                (
                    aggTestColl.Query.Salary.StdDev().As("Std Dev")
                );
                Assert.IsTrue(aggTestColl.Query.Load());
                Assert.AreEqual(1, aggTestColl.Count);
            }
        }

        [Test]
        public void AddAggregateVar()
        {
            if (aggTestColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not supported by SqlCe.");
            }
            else
            {
                switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.SQLiteProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not Supported");
                        break;
                    default:
                        aggTestColl.Query.Select
                        (
                            aggTestColl.Query.Salary.Var().As("Var")
                        );
                        Assert.IsTrue(aggTestColl.Query.Load());
                        Assert.AreEqual(1, aggTestColl.Count);
                        break;
                }
            }
        }

        [Test]
        public void AddAggregateCountAllDefaultAlias()
        {
            aggTestColl.Query.es.CountAll = true;
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count, "Retrieved 1 row.");

            int aggCount = Convert.ToInt32(aggTestColl[0].GetColumn("Count"));
            Assert.AreEqual(30, aggCount, "Value equals 30.");
        }

        [Test]
        public void AddAggregateCountAll()
        {
            aggTestColl.Query.es.CountAll = true;
            aggTestColl.Query.es.CountAllAlias = "Total";
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count, "Retrieved 1 row.");

            int aggCount = Convert.ToInt32(aggTestColl[0].GetColumn("Total"));
            Assert.AreEqual(30, aggCount, "Value equals 30.");
        }

        [Test]
        public void AddAggregateCountAllAliasReversed()
        {
            aggTestColl.Query.es.CountAllAlias = "Total";
            aggTestColl.Query.es.CountAll = true;
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count, "Retrieved 1 row.");

            int aggCount = Convert.ToInt32(aggTestColl[0].GetColumn("Total"));
            Assert.AreEqual(30, aggCount, "Value equals 30.");
        }

        [Test]
        public void AddTwoAggregates()
        {
            aggTestColl.Query.Select
            (
				aggTestColl.Query.Salary.Sum().As("Sum")
            );
            aggTestColl.Query.es.CountAll = true;
            aggTestColl.Query.es.CountAllAlias = "Total";
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void AggregateWithTearoff()
        {
            aggTestColl.Query.Select
            (
				aggTestColl.Query.Salary.Sum().As("Sum"),
				aggTestColl.Query.Salary.Min().As("Min")
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void AggregateWithWhere()
        {
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Total";
			aggTestColl.Query.Where
			(
				aggTestColl.Query.IsActive.Equal(true)
			);

			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void EmptyAliasUsesColumnName()
        {
            aggTestColl.Query.Select
            (
                aggTestColl.Query.Salary.Sum()
            );
            Assert.IsTrue(aggTestColl.Query.Load());

            IDynamicQuerySerializableInternal iQuery = aggTestColl.Query as IDynamicQuerySerializableInternal;
            Assert.AreEqual("Salary", iQuery.InternalSelectColumns[0].Column.Alias);
            //Assert.AreEqual("Salary", aggTestColl.Query.Salary.Sum().Alias);
        }

        [Test]
        public void AliasAndGetColumn()
        {
            int totalNo = 0;
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Select(
                collection.Query.Age.Sum().As("total"));
            collection.Query.Load();
            totalNo = Convert.ToInt32(collection[0].GetColumn("total"));
            Assert.AreEqual(726, totalNo);
        }

        [Test]
        public void DistinctAggregate()
        {
            if (aggTestColl.es.Connection.ProviderSignature.DataProviderName == 
                "EntitySpaces.SqlServerCeProvider.CF")
            {
                Assert.Ignore("Not supported by SqlCe.");
            }
            else
            {
                switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.SqlServerCeProvider":
                    case "EntitySpaces.SqlServerCe4Provider":
                        Assert.Ignore("Not Supported");
                        break;
                    default:
                        aggTestColl.Query.Select
                        (
                            aggTestColl.Query.LastName.Count().Distinct().As("Count")
                        );
                        Assert.IsTrue(aggTestColl.Query.Load());
                        DataTable testTable = aggTestColl.Query.LoadDataTable();
                        DataRow[] currRows = testTable.Select(null, null, DataViewRowState.CurrentRows);
                        DataRow testRow = currRows[0];
                        Assert.AreEqual(10, testRow[0]);
                        break;
                }
            }
        }

	}
}
