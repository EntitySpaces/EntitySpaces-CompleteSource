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
	public class ViewAggregateFixture
	{
		FullNameViewCollection aggTestColl = new FullNameViewCollection();
		FullNameView aggTest = new FullNameView();
		FullNameViewQuery aggTestQuery = new FullNameViewQuery();
		
		[TestFixtureSetUp]
		public void Init()
		{
            if (aggTestColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not supported by SqlCe.");
            }
        }

		[SetUp]
		public void Init2()
		{
			aggTestColl = new FullNameViewCollection();
			aggTest = new FullNameView();
			aggTestQuery = new FullNameViewQuery();
		}

		[Test]
		public void EmptyQueryReturnsSelectAll()
		{
			aggTestColl = new FullNameViewCollection();
            if (aggTestColl.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
            {
                Assert.IsTrue(aggTestColl.LoadAll());
                Assert.AreEqual(16, aggTestColl.Count, "LoadAll");
            }

			aggTestColl = new FullNameViewCollection();
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count, "Query.Load");

			aggTestColl = new FullNameViewCollection();
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
			aggTestColl.Query.Select
			(
				aggTestColl.Query.Salary.StdDev().As("Std Dev")
			);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(1, aggTestColl.Count);
		}

		[Test]
		public void AddAggregateVar()
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

		[Test]
		public void AddAggregateCountAll()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Total";
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(1, aggTestColl.Count);
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
		public void DistinctAggregate()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Not Supported");
					break;
				default:
					aggTestColl.Query.Select
					(
						aggTestColl.Query.FullName.Count().Distinct().As("Count")
					);
					Assert.IsTrue(aggTestColl.Query.Load());
					DataTable testTable = aggTestColl.Query.LoadDataTable();
					DataRow[] currRows = testTable.Select(null, null, DataViewRowState.CurrentRows);
					DataRow testRow = currRows[0];
					Assert.AreEqual(16, testRow[0]);
					break;
			}
		}

	}
}
