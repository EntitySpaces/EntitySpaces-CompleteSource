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
	public class GroupByFixture
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
		public void OneGroupBy()
		{
			aggTestColl.Query.es.CountAll = true;
			aggTestColl.Query.es.CountAllAlias = "Count";
			aggTestColl.Query
				.Select(aggTestColl.Query.IsActive)
				.GroupBy(aggTestColl.Query.IsActive);
			Assert.IsTrue(aggTestColl.Query.Load());

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.AreEqual(2, aggTestColl.Count);
					break;
				default:
					Assert.AreEqual(3, aggTestColl.Count);
					break;
			}
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
            Assert.AreEqual(12, aggTestColl.Count);
        }

        [Test]
        public void TwoGroupByWithHaving()
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
                )
                .Having("<COUNT(*) > 1>");
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(7, aggTestColl.Count);
        }

        [Test]
        public void HavingWithSimpleExpression()
        {
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            OrderItemQuery q = new OrderItemQuery();
            //q.es2.Connection.Name = "ForeignKeyTest";

            q.Select(q.OrderID, q.Quantity.Sum().As("TotalQty"));
            q.Where(q.Discount.IsNull());
            q.GroupBy(q.OrderID);

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    q.Having(q.Quantity.Sum() > 100);
                    q.OrderBy("<TotalQty>", esOrderByDirection.Descending);
                    break;

                case "EntitySpaces.SQLiteProvider":
                    q.Having((q.Quantity * 1).Sum() > 100);
                    q.OrderBy(q.Quantity.Sum().Descending);
                    break;

                default:
                    q.Having(q.Quantity.Sum() > 100);
                    q.OrderBy(q.Quantity.Sum().Descending);
                    break;
            }

            Assert.IsTrue(coll.Load(q), "Load");
            Assert.AreEqual(3, coll.Count, "Count");

            int qty = Convert.ToInt32(coll[0].GetColumn("TotalQty"));
            Assert.AreEqual(240, qty, "GetColumn");
        }

        [Test]
        public void HavingWithComplexExpression()
        {
            OrderItemCollection coll = new OrderItemCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            OrderItemQuery q = new OrderItemQuery();
            q.Select(q.OrderID, (q.Quantity * q.UnitPrice).Sum().As("TotalPrice"));
            q.Where(q.Discount.IsNull());
            q.GroupBy(q.OrderID);
            q.Having((q.Quantity * q.UnitPrice).Sum() > 500);

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    q.OrderBy("<TotalPrice>", esOrderByDirection.Descending);
                    break;

                default:
                    q.OrderBy((q.Quantity * q.UnitPrice).Sum().Descending);
                    break;
            }

            Assert.IsTrue(coll.Load(q), "Load");
            Assert.AreEqual(2, coll.Count, "Count");

            decimal price = Convert.ToDecimal(coll[0].GetColumn("TotalPrice"));
            Assert.AreEqual(1940.0M, price, "GetColumn");
        }

        [Test]
		public void AggregateInOrderBy()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Not supported");
					break;

				default:
					aggTestColl.Query
						.Select
						(
							aggTestColl.Query.DepartmentID,
							aggTestColl.Query.Salary.Min()
						)
						.OrderBy
						(
							aggTestColl.Query.Salary.Descending
						)
						.GroupBy
						(
							aggTestColl.Query.DepartmentID
						);
					aggTestColl.Query.Load();
                    break;
			}

            AggregateTest test = new AggregateTest();

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                    test = (AggregateTest)aggTestColl[1];
                    break;

                default:
                    test = (AggregateTest)aggTestColl[0];
                    break;
            }

			Assert.AreEqual(4, test.DepartmentID.Value);
			Assert.AreEqual(18.44, Math.Round(test.Salary.Value, 2));
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
            if (aggTestColl.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.NpgsqlProvider":
                    case "EntitySpaces.Npgsql2Provider":
                    case "EntitySpaces.SQLiteProvider":
                    case "EntitySpaces.SqlServerCeProvider":
                    case "EntitySpaces.SqlServerCe4Provider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
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
        }

	}
}
