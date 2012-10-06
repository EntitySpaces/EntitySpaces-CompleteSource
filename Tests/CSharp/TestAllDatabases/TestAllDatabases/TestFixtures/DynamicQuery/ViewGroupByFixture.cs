//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace Tests.Base
{
	[TestFixture]
	public class ViewGroupByFixture
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
		public void OneGroupBy()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select(aggTestColl.Query.IsActive)
				.GroupBy(aggTestColl.Query.IsActive);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(1, aggTestColl.Count);
		}

		[Test]
		public void TwoGroupBy()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.GroupBy
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void GroupByWithWhere()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				)
				.GroupBy
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void GroupByWithWhereAndOrderBy()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				)
				.GroupBy
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.OrderBy
				(
					aggTestColl.Query.DepartmentID.Ascending,
					aggTestColl.Query.IsActive.Ascending
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void GroupByWithOrderByCountAll()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    aggTestColl.Query
						.Select
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						)
						.Where
						(
							aggTestColl.Query.IsActive.Equal(true)
						)
						.GroupBy
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						)
						.OrderBy
						(
							"<Count(*)>", esOrderByDirection.Ascending
						);
					break;
				default:
					aggTestColl.Query
						.Select
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						)
						.Where
						(
							aggTestColl.Query.IsActive.Equal(true)
						)
						.GroupBy
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						)
						.OrderBy
						(
							aggTestColl.Query.es.CountAllAlias, esOrderByDirection.Ascending
						);
					break;
			}
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void GroupByWithTop()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				)
				.GroupBy
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.OrderBy
				(
					aggTestColl.Query.DepartmentID.Ascending,
					aggTestColl.Query.IsActive.Ascending
				);
			aggTestColl.Query.es.Top = 3;
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(aggTestColl.Query.es.Top, aggTestColl.Count);
		}

		[Test]
		public void GroupByWithDistinct()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				)
				.GroupBy
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.OrderBy
				(
					aggTestColl.Query.DepartmentID.Ascending,
					aggTestColl.Query.IsActive.Ascending
				);
			aggTestColl.Query.es.Distinct = true;
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void GroupByWithTearoff()
		{
			aggTestColl.Query
				.Select
				(
					aggTestColl.Query.Salary.Sum().As("Sum"),
					aggTestColl.Query.Salary.Min().As("Min"),
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				)
				.GroupBy
				(
					aggTestColl.Query.IsActive,
					aggTestColl.Query.DepartmentID
				)
				.OrderBy
				(
					aggTestColl.Query.DepartmentID.Ascending,
					aggTestColl.Query.IsActive.Ascending
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void GroupByWithRollup()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
			{
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("Not Supported");
					break;
				// For MySQL GROUP BY and ORDER BY are mutually exclusive.
                case "EntitySpaces.MySqlClientProvider":
                    aggTestColl.Query.es.CountAll = true;
					aggTestColl.Query.es.CountAllAlias = "Count";
					aggTestColl.Query
						.Select
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						)
						.Where
						(
							aggTestColl.Query.IsActive.Equal(true)
						)
						.GroupBy
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						);
					aggTestColl.Query.es.WithRollup = true;
					Assert.IsTrue(aggTestColl.Query.Load());
					Assert.AreEqual(7, aggTestColl.Count);
					break;
				default:
					aggTestColl.Query.es.CountAll = true;
					aggTestColl.Query.es.CountAllAlias = "Count";
					aggTestColl.Query
						.Select
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						)
						.Where
						(
							aggTestColl.Query.IsActive.Equal(true)
						)
						.GroupBy
						(
							aggTestColl.Query.IsActive,
							aggTestColl.Query.DepartmentID
						)
						.OrderBy
						(
							aggTestColl.Query.DepartmentID.Ascending,
							aggTestColl.Query.IsActive.Ascending
						);
					aggTestColl.Query.es.WithRollup = true;
					Assert.IsTrue(aggTestColl.Query.Load());
					Assert.AreEqual(7, aggTestColl.Count);
					break;
			}
		}

		[Test]
		public void GroupByFullName()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select(aggTestColl.Query.FullName)
				.GroupBy(aggTestColl.Query.FullName);
			Assert.IsTrue(aggTestColl.Query.Load());
			switch (aggTestColl.es.Connection.Name)
			{
				case "ACCESS":
					Assert.AreEqual(16, aggTestColl.Count);
					break;
				default:
					Assert.AreEqual(16, aggTestColl.Count);
					break;
			}
		}

    }
}
