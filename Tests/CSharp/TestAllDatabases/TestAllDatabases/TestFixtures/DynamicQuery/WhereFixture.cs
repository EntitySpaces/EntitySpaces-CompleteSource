//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace Tests.Base
{
	[TestFixture]
	public class WhereFixture
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
		public void SelectWithAlias()
		{
			aggTestColl.Query.Select(
				aggTestColl.Query.Salary.As("S2"),
				aggTestColl.Query.FirstName,
				aggTestColl.Query.FirstName.As("FN")
			);
			aggTestColl.Query.OrderBy(aggTestColl.Query.Id.Ascending);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(30, aggTestColl.Count);

			AggregateTestCollection aggControl = new AggregateTestCollection();
			aggControl.Query.OrderBy(aggControl.Query.Id.Ascending);
			aggControl.Query.Load();

			int i = 0;
			foreach (AggregateTest agg in aggTestColl)
			{
				if (aggControl[i].Salary.HasValue)
				{
					Assert.AreEqual(aggControl[i].Salary.Value,
						agg.GetColumn("S2"));
				}
				else
				{
					Assert.AreEqual(null, agg.GetColumn("S2") as string);
				}
				Assert.AreEqual(aggControl[i].FirstName,
					agg.GetColumn("FN") as string);
				i++;
			}
		}

        [Test]
        public void OrderByWithAlias()
        {
            aggTestColl.Query.Select(
                aggTestColl.Query.Age.As("A2"),
                aggTestColl.Query.FirstName,
                aggTestColl.Query.FirstName.As("FN")
            );

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Access cannot ORDER BY an alias");
                    break;
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                    aggTestColl.Query.OrderBy("<\"A2\">", esOrderByDirection.Descending);
                    break;
                default:
                    aggTestColl.Query.OrderBy("<A2>", esOrderByDirection.Descending);
                    break;
            }

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(30, aggTestColl.Count);

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                    Assert.AreEqual(45, aggTestColl[5].GetColumn("A2"));
                    break;
                default:
                    Assert.AreEqual(45, aggTestColl[0].GetColumn("A2"));
                    break;
            }
        }

        [Test]
		public void OneWhere()
		{
			aggTestColl.Query
				.Select()
				.Where(aggTestColl.Query.IsActive.Equal(true));
            DataTable testTable = aggTestColl.Query.LoadDataTable();
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count);
			Assert.AreEqual(8, testTable.Columns.Count);
		}

		[Test]
		public void TwoWhere()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true),
					aggTestColl.Query.LastName.Equal("Doe")
				);
			DataTable testTable = aggTestColl.Query.LoadDataTable();
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(2, aggTestColl.Count);
		}

		[Test]
		public void WhereWithOrderBy()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				)
				.OrderBy
				(
					aggTestColl.Query.LastName.Ascending
				);
			DataTable testTable = aggTestColl.Query.LoadDataTable();
			DataRow[] currRows = testTable.Select(null, null, DataViewRowState.CurrentRows);
			DataRow testRow = currRows[0];
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count);
			Assert.AreEqual("Costner", testRow["LastName"], "First Row");
			testRow = currRows[15];
			Assert.AreEqual("Vincent", testRow["LastName"], "Last Row");
		}

		[Test]
		public void WhereEqual()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive.Equal(false)
				);
			Assert.IsTrue(aggTestColl.Query.Load());

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.AreEqual(14, aggTestColl.Count);
					break;
				default:
					Assert.AreEqual(8, aggTestColl.Count);
					break;
			}
		}

		[Test]
		public void WhereEqualOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive == false
				);
			Assert.IsTrue(aggTestColl.Query.Load());

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.AreEqual(14, aggTestColl.Count);
					break;
				default:
					Assert.AreEqual(8, aggTestColl.Count);
					break;
			}
		}

        [Test]
        public void WhereEqualDecimal()
        {
            aggTestColl.Query
                .Select()
                .Where
                (
                    aggTestColl.Query.Salary == 34.71
                );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
		public void WhereNotEqual()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive.NotEqual(false)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count);
		}

		[Test]
		public void WhereNotEqualOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive != false
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count);
		}

		[Test]
		public void WhereGreaterThan()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary.GreaterThan(25.03)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(12, aggTestColl.Count);
		}

		[Test]
		public void WhereGreaterThanOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary > 25.03
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(12, aggTestColl.Count);
		}

		[Test]
		public void WhereGreaterThanOrEqual()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary.GreaterThanOrEqual(25.03)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(13, aggTestColl.Count);
		}

		[Test]
		public void WhereGreaterThanOrEqualOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary >= 25.03
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(13, aggTestColl.Count);
		}

		[Test]
		public void WhereLessThan()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.FirstName.LessThan("Jane")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(6, aggTestColl.Count);
		}

		[Test]
		public void WhereLessThanOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.FirstName < "Jane"
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(6, aggTestColl.Count);
		}

		[Test]
		public void WhereLessThanOrEqual()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.FirstName.LessThanOrEqual("Jane")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(9, aggTestColl.Count);
		}

		[Test]
		public void WhereLessThanOrEqualOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.FirstName <= "Jane"
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(9, aggTestColl.Count);
		}

		[Test]
		public void WhereLikeText()
		{
			aggTestColl.Query
				.Where
				(
					aggTestColl.Query.FirstName.Like("J%")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

        [Test]
        public void WhereLikeTextEscaped()
        {
            int tempId = -1;
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            aggTest.LastName = "a 10% name";
                            aggTest.Save();
                            tempId = aggTest.Id.Value;

                            aggTestColl.Query
                                .Select()
                                .Where
                                (
                                    aggTestColl.Query.LastName.Like("%10!%%", '!')
                                );
                            Assert.IsTrue(aggTestColl.Query.Load());
                            Assert.AreEqual(1, aggTestColl.Count);
                        }
                    }
                    finally
                    {
                        // Clean up
                        aggTest = new AggregateTest();
                        if (aggTest.LoadByPrimaryKey(tempId))
                        {
                            aggTest.MarkAsDeleted();
                            aggTest.Save();
                        }
                    }
                    break;
            }
        }

        [Test]
        public void WhereNotLikeTextEscaped()
        {
            int tempId = -1;

            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            aggTest.LastName = "a 10% name";
                            aggTest.Save();
                            tempId = aggTest.Id.Value;

                            aggTestColl.Query
                                .Select()
                                .Where
                                (
                                    aggTestColl.Query.LastName.NotLike("%10!%%", '!')
                                );
                            Assert.IsTrue(aggTestColl.Query.Load());
                            Assert.AreEqual(24, aggTestColl.Count);
                        }
                    }
                    finally
                    {
                        // Clean up
                        aggTest = new AggregateTest();
                        if (aggTest.LoadByPrimaryKey(tempId))
                        {
                            aggTest.MarkAsDeleted();
                            aggTest.Save();
                        }
                    }
                    break;
            }
        }

        [Test]
		public void WhereLikeInteger()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Age.Like("%1%")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(9, aggTestColl.Count);
		}

		[Test]
		public void WhereLikeNumeric()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary.Like("%1%")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(15, aggTestColl.Count);
		}

		[Test]
		public void WhereLikeDate()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.Like("%4%"),
							aggTestColl.Query.HireDate.Like("%2002%")
						);
					break;
                case "EntitySpaces.OracleClientProvider":
                    aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.Like("%APR%"),
							aggTestColl.Query.HireDate.Like("%02%")
						);
					break;
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                    aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.Cast(esCastType.String).Like("%-04-%"),
							aggTestColl.Query.HireDate.Cast(esCastType.String).Like("%2002-%")
						);
					break;
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                case "EntitySpaces.SQLiteProvider":
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.HireDate.Like("%-04-%"),
                            aggTestColl.Query.HireDate.Like("%2002-%")
                        );
                    break;
                default:
					aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.Like("%apr%"),
							aggTestColl.Query.HireDate.Like("%2002%")
						);
					break;
			}
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(3, aggTestColl.Count);
		}

		[Test]
		public void WhereNotLikeText()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.FirstName.NotLike("J%")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(19, aggTestColl.Count);
		}

		[Test]
		public void WhereNotLikeInteger()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Age.NotLike("%1%")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count);
		}

		[Test]
		public void WhereNotLikeNumeric()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary.NotLike("%1%")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(10, aggTestColl.Count);
		}

		[Test]
		public void WhereNotLikeDate()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
					aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.NotLike("%4%"),
							aggTestColl.Query.HireDate.NotLike("%2002%")
						);
					break;
                case "EntitySpaces.OracleClientProvider":
                    aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
					aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.NotLike("%APR%"),
							aggTestColl.Query.HireDate.NotLike("%02%")
						);
					break;
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                    aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
					aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.Cast(esCastType.String).NotLike("%-04-%"),
							aggTestColl.Query.HireDate.Cast(esCastType.String).NotLike("%2002-%")
						);
					break;
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                case "EntitySpaces.SQLiteProvider":
                    aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.HireDate.NotLike("%-04-%"),
                            aggTestColl.Query.HireDate.NotLike("%2002-%")
                        );
                    break;
                default:
					aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
					aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.NotLike("%apr%"),
							aggTestColl.Query.HireDate.NotLike("%2002%")
						);
					break;
			}
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(21, aggTestColl.Count);
		}

		[Test]
		public void WhereIsNull()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.HireDate.IsNull()
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(6, aggTestColl.Count);
		}

		[Test]
		public void WhereIsNotNull()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.HireDate.IsNotNull()
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(24, aggTestColl.Count);
		}

		[Test]
		public void WhereBetweenDate()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.HireDate.Between(Convert.ToDateTime("2002-01-01"), Convert.ToDateTime("2002-12-31"))
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(4, aggTestColl.Count);
		}

		[Test]
		public void WhereBetweenText()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.LastName.Between("Doe", "Johnson")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(9, aggTestColl.Count);
		}

		[Test]
		public void WhereBetweenInteger()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Age.Between(20, 30)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(6, aggTestColl.Count);
		}

		[Test]
		public void WhereBetweenNumeric()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary.Between(21.74, 26.00)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(4, aggTestColl.Count);
		}

		[Test]
		public void WhereInDate()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.HireDate.In("#2002-04-01#", "#2003-12-31#")
                        );
                    break;
                case "EntitySpaces.OracleClientProvider":
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.HireDate.In("01-APR-02", "31-DEC-03")
                        );
                    break;
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.HireDate.In("2002-04-01", "2003-12-31")
                        );
                    break;
                case "EntitySpaces.SQLiteProvider":
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.HireDate.In("2002-04-01 00:00:00", "2003-12-31 00:00:00")
                        );
                    break;
                default:
					aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.In(Convert.ToDateTime("2002-04-01").ToString(), Convert.ToDateTime("2003-12-31").ToString())
						);
					break;
			}
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(1, aggTestColl.Count);
		}

		[Test]
		public void WhereInListText()
		{
			ArrayList array = new ArrayList();
			array.Add("Test");
			array.Add("Test2");

			ArrayList anotherArray = new ArrayList();
			anotherArray.Add("Foo");
			anotherArray.Add("Four");

			List<string> generic = new List<string>();
			generic.Add("Seven");
			generic.Add("Vincent");

			aggTestColl.Query.Where(
				aggTestColl.Query.LastName.In(
                    "Doe", array, "foo", anotherArray, generic));
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void WhereInText()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.LastName.In("Doe", "Vincent")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(5, aggTestColl.Count);
		}

		[Test]
		public void WhereInNumeric()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary.In(25.03, 11.06)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(2, aggTestColl.Count);
		}

		[Test]
		public void WhereInListNumeric()
		{
			ArrayList array = new ArrayList();
			array.Add(1);
			array.Add(2);

			ArrayList anotherArray = new ArrayList();
			anotherArray.Add(3);
			anotherArray.Add(25.03);

			List<int> generic = new List<int>();
			generic.Add(5);
			generic.Add(6);

			aggTestColl.Query.Where(
				aggTestColl.Query.Salary.In(
                    7, array, 11.06, anotherArray, generic));
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(2, aggTestColl.Count);
		}

		[Test]
		public void WhereInInteger()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Age.In(16, 28)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(4, aggTestColl.Count);
		}

		[Test]
		public void WhereNotInDate()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.NotIn("#2002-04-01#", "#2003-12-31#")
						);
					break;
                case "EntitySpaces.OracleClientProvider":
                    aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.NotIn("01-APR-02", "31-DEC-03")
						);
					break;
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.NotIn("2002-04-01", "2003-12-31")
						);
					break;
                case "EntitySpaces.SQLiteProvider":
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.HireDate.NotIn("2002-04-01 00:00:00", "2003-12-31 00:00:00")
                        );
                    break;
                default:
					aggTestColl.Query
						.Select()
						.Where
						(
							aggTestColl.Query.HireDate.NotIn(Convert.ToDateTime("2002-04-01").ToString(), Convert.ToDateTime("2003-12-31").ToString())
						);
					break;
			}
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(23, aggTestColl.Count);
		}

		[Test]
		public void WhereNotInListText()
		{
			ArrayList array = new ArrayList();
			array.Add("Test");
			array.Add("Test2");

			ArrayList anotherArray = new ArrayList();
			anotherArray.Add("Foo");
			anotherArray.Add("Four");

			List<string> generic = new List<string>();
			generic.Add("Seven");
			generic.Add("Vincent");

			aggTestColl.Query.Where(
				aggTestColl.Query.LastName.NotIn("Doe", array, "foo", anotherArray, generic));
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(19, aggTestColl.Count);
		}

		[Test]
		public void WhereNotInText()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.LastName.NotIn("Doe", "Vincent")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(19, aggTestColl.Count);
		}

		[Test]
		public void WhereNotInNumeric()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Salary.NotIn(25.03, 11.06)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(23, aggTestColl.Count);
		}

		[Test]
		public void WhereNotInListNumeric()
		{
			ArrayList array = new ArrayList();
			array.Add(1);
			array.Add(2);

			ArrayList anotherArray = new ArrayList();
			anotherArray.Add(3);
			anotherArray.Add(25.03);

			List<int> generic = new List<int>();
			generic.Add(5);
			generic.Add(6);

			aggTestColl.Query.Where(
				aggTestColl.Query.Salary.NotIn(7, array, 11.06, anotherArray, generic));
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(23, aggTestColl.Count);
		}

		[Test]
		public void WhereNotInInteger()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Age.NotIn(16, 28)
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(21, aggTestColl.Count);
		}

		[Test]
		public void WhereDefaultConjunction()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.LastName.Like("C%"),
					aggTestColl.Query.Age <= aggTestColl.Query.Salary
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(2, aggTestColl.Count);
		}

		[Test]
		public void WhereDefaultConjunctionOr()
		{
			aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.LastName.Like("C%"),
					aggTestColl.Query.Age <= aggTestColl.Query.Salary
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(13, aggTestColl.Count);
		}

		[Test]
		public void WhereConjunctionAndOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.LastName.Like("C%") &
					aggTestColl.Query.Age <= aggTestColl.Query.Salary
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(2, aggTestColl.Count);
		}

		[Test]
		public void WhereConjunctionOrOperator()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.LastName.Like("C%") |
					aggTestColl.Query.Age <= aggTestColl.Query.Salary
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(13, aggTestColl.Count);
		}

        [Test]
        public void WhereConjunctionAndNotOperator()
        {
            AggregateTestQuery query = new AggregateTestQuery();

            query.Where(query.DepartmentID == 1
                & !(query.IsActive == true & query.Age == 28));

            AggregateTestCollection coll = new AggregateTestCollection();
            Assert.IsTrue(coll.Load(query));
            Assert.AreEqual(2, coll.Count);
        }

        [Test]
        public void WhereConjunctionAndNotSeparateLines()
        {
            AggregateTestQuery query = new AggregateTestQuery();

            query.Where(query.DepartmentID == 1);

            query.es.DefaultConjunction = esConjunction.AndNot;
            query.Where(new esComparison(esParenthesis.Open));
            query.Where(query.IsActive == true);
            query.es.DefaultConjunction = esConjunction.And;
            query.Where(query.Age == 28);
            query.Where(new esComparison(esParenthesis.Close));

            AggregateTestCollection coll = new AggregateTestCollection();
            Assert.IsTrue(coll.Load(query));
            Assert.AreEqual(2, coll.Count);
        }

        [Test]
        public void WhereConjunctionAndNotNested()
        {
            AggregateTestQuery query = new AggregateTestQuery();

            query.Where
            (
                query.AndNot
                (
                    query.DepartmentID == 1,
                    query.And
                    (
                        query.IsActive == true,
                        query.Age == 28
                    )
                )
            );

            AggregateTestCollection coll = new AggregateTestCollection();
            Assert.IsTrue(coll.Load(query));
            Assert.AreEqual(2, coll.Count);
        }

        [Test]
        public void WhereConjunctionOrNotOperator()
        {
            AggregateTestQuery query = new AggregateTestQuery();

            query.Where(query.DepartmentID == 1
                | !(query.IsActive == true & query.Age == 28));

            AggregateTestCollection coll = new AggregateTestCollection();
            Assert.IsTrue(coll.Load(query));

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.AreEqual(29, coll.Count);
                    break;

                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.SqlClientProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.AreEqual(24, coll.Count);
                    break;

                default:
                    Assert.AreEqual(24, coll.Count);
                    break;
            }
        }

        [Test]
        public void WhereConjunctionOrNotSeparateLines()
        {
            AggregateTestQuery query = new AggregateTestQuery();

            query.Where(query.DepartmentID == 1);

            query.es.DefaultConjunction = esConjunction.OrNot;
            query.Where(new esComparison(esParenthesis.Open));
            query.Where(query.IsActive == true);
            query.es.DefaultConjunction = esConjunction.And;
            query.Where(query.Age == 28);
            query.Where(new esComparison(esParenthesis.Close));

            AggregateTestCollection coll = new AggregateTestCollection();
            Assert.IsTrue(coll.Load(query));

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.AreEqual(29, coll.Count);
                    break;

                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.SqlClientProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.AreEqual(24, coll.Count);
                    break;

                default:
                    Assert.AreEqual(24, coll.Count);
                    break;
            }
        }

        [Test]
        public void WhereConjunctionOrNotNested()
        {
            AggregateTestQuery query = new AggregateTestQuery();

            query.Where
            (
                query.OrNot
                (
                    query.DepartmentID == 1,
                    query.And
                    (
                        query.IsActive == true,
                        query.Age == 28
                    )
                )
            );

            AggregateTestCollection coll = new AggregateTestCollection();
            Assert.IsTrue(coll.Load(query));

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.AreEqual(29, coll.Count);
                    break;

                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.SqlClientProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.AreEqual(24, coll.Count);
                    break;

                default:
                    Assert.AreEqual(24, coll.Count);
                    break;
            }
        }

        [Test]
		public void WhereMixAndOr()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.Or
					(
						aggTestColl.Query.LastName.Like("C%"),
						aggTestColl.Query.LastName.Like("D%")
					),
					aggTestColl.Query.Age <= 30
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(4, aggTestColl.Count);
		}

        [Test]
        public void WhereMixAndOrOperators()
        {
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                    aggTestColl.Query.Where(
                        (aggTestColl.Query.HireDate.Date() <= 
                            Convert.ToDateTime("2007-01-01") |
                            aggTestColl.Query.HireDate.IsNull()) &
                        (aggTestColl.Query.LastName.Like("D%") |
                            aggTestColl.Query.LastName.IsNull())
                    );
                    break;
                default:
                    aggTestColl.Query.Where(
                        (aggTestColl.Query.HireDate.Date() <= "2007-01-01" |
                            aggTestColl.Query.HireDate.IsNull()) &
                        (aggTestColl.Query.LastName.Like("D%") |
                            aggTestColl.Query.LastName.IsNull())
                    );
                    break;
            }
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(10, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOr()
        {
            aggTestColl.Query.Where(
                aggTestColl.Query.Or(
                    aggTestColl.Query.LastName.Like("D%"),
                    aggTestColl.Query.LastName.Like("S%")),
                aggTestColl.Query.Or(
                    aggTestColl.Query.FirstName.Like("J%"),
                    aggTestColl.Query.FirstName.Like("D%"))
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiWithParen()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            collection.Query.Select(
                collection.Query.EmployeeID,
                collection.Query.Supervisor,
                collection.Query.Age);

            collection.Query.Where(collection.Query.Age == 20);

            collection.Query.Where(new esComparison(esParenthesis.Open));

            collection.Query.es.DefaultConjunction = esConjunction.Or;

            for (int i = 0; i < 4; i++)
            {
                collection.Query.Where(
                    collection.Query.Supervisor == i &
                    collection.Query.EmployeeID == i + 1);
            }

            collection.Query.Where(new esComparison(esParenthesis.Close));

            Assert.IsTrue(collection.Query.Load());
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void WhereMixMultiWithParenNested()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            collection.Query.Select(
                collection.Query.EmployeeID,
                collection.Query.Supervisor,
                collection.Query.Age);

            collection.Query.Where(collection.Query.Age == 30);

            collection.Query.Where(new esComparison(esParenthesis.Open));
            collection.Query.Where(new esComparison(esParenthesis.Open));

            collection.Query.es.DefaultConjunction = esConjunction.Or;

            collection.Query.Where(
                collection.Query.EmployeeID == 1 &
                collection.Query.Supervisor.IsNull());
            collection.Query.Where(
                collection.Query.EmployeeID == 2 &
                collection.Query.Supervisor == 1);

            collection.Query.Where(new esComparison(esParenthesis.Close));
            collection.Query.es.DefaultConjunction = esConjunction.And;
            collection.Query.Where(new esComparison(esParenthesis.Open));

            collection.Query.es.DefaultConjunction = esConjunction.Or;

            collection.Query.Where(
                collection.Query.LastName == "Smith" &
                collection.Query.Supervisor.IsNull());
            collection.Query.Where(
                collection.Query.LastName == "Jones" &
                collection.Query.Supervisor == 1);

            collection.Query.Where(new esComparison(esParenthesis.Close));
            collection.Query.Where(new esComparison(esParenthesis.Close));

            Assert.IsTrue(collection.Query.Load());
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void WhereMixMultiAndOrDefaultOr()
        {
            aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
            aggTestColl.Query.Where(
                aggTestColl.Query.And(
                    aggTestColl.Query.LastName.Like("%D%"),
                    aggTestColl.Query.LastName.Like("%s%")),
                aggTestColl.Query.And(
                    aggTestColl.Query.FirstName.Like("%J%"),
                    aggTestColl.Query.FirstName.Like("%D%"))
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNested()
        {
            aggTestColl.Query.Where(
                aggTestColl.Query.LastName.Equal("Doe"),
                aggTestColl.Query.FirstName == "David",
                aggTestColl.Query.Or(
                    aggTestColl.Query.And(
                        aggTestColl.Query.DepartmentID.Equal(3),
                        aggTestColl.Query.Age.Equal(16)),
                    aggTestColl.Query.And(
                        aggTestColl.Query.DepartmentID.Equal(4),
                        aggTestColl.Query.Age.Equal(43))
                 )
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNested2()
        {
            aggTestColl.Query.Where(
                aggTestColl.Query.Or(aggTestColl.Query.LastName.Like("%e%"),
                    aggTestColl.Query.FirstName.Like("%a%")),
                aggTestColl.Query.And(
                    aggTestColl.Query.Or(aggTestColl.Query.DepartmentID.Equal(3),
                        aggTestColl.Query.Age.Equal(16)),
                    aggTestColl.Query.Or(aggTestColl.Query.HireDate >=
                        Convert.ToDateTime("2000-01-01"),
                        aggTestColl.Query.Salary >= 15.00)
                )
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(7, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNestedOperators()
        {
            aggTestColl.Query.Where(
                aggTestColl.Query.LastName.Equal("Doe") &
                aggTestColl.Query.FirstName == "David" &
                (
                    (aggTestColl.Query.DepartmentID.Equal(3) &
                        aggTestColl.Query.Age.Equal(16))
                    |
                    (aggTestColl.Query.DepartmentID.Equal(4) &
                        aggTestColl.Query.Age.Equal(43))
                 )
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNestedOperators2()
        {
            aggTestColl.Query.Where(
                (aggTestColl.Query.LastName.Like("%e%") |
                 aggTestColl.Query.FirstName.Like("%a%")) &
                (
                    (aggTestColl.Query.DepartmentID.Equal(3) |
                        aggTestColl.Query.Age.Equal(16))
                    &
                    (aggTestColl.Query.HireDate >=
                        Convert.ToDateTime("2000-01-01") |
                    aggTestColl.Query.Salary >=
                        15.00)
                 )
            );
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(7, aggTestColl.Count);
        }

        [Test]
		public void WhereCompareColumns()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.Ignore("Not supported.");
                    break;

                default:
                    aggTestColl.Query
                        .Select()
                        .Where
                        (
                            aggTestColl.Query.Age <= aggTestColl.Query.Salary
                        );
                    Assert.IsTrue(aggTestColl.Query.Load());
                    Assert.AreEqual(11, aggTestColl.Count);
                    break;
            }
		}

		[Test]
		public void CacheQueryObject()
		{
            aggTestQuery = aggTestColl.Query;

			aggTestQuery
				.Select()
				.Where
				(
					aggTestQuery.Age <= aggTestQuery.Salary
				);
			Assert.IsTrue(aggTestQuery.Load());
			Assert.AreEqual(11, aggTestColl.Count);
		}

		[Test]
		public void MultiWhereClausesInternal()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				)
				.Where
				(
					aggTestColl.Query.LastName.Equal("Doe")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(2, aggTestColl.Count);
		}

		[Test]
		public void MultiWhereClausesExternal()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				);
			aggTestColl.Query
				.Where
				(
					aggTestColl.Query.LastName.Equal("Doe")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(2, aggTestColl.Count);
		}

		[Test]
		public void MultiWhereClausesExternalOr()
		{
			aggTestColl.Query
				.Select()
				.Where
				(
					aggTestColl.Query.IsActive.Equal(true)
				);
			aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
			aggTestColl.Query
				.Where
				(
					aggTestColl.Query.LastName.Equal("Doe")
				);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(17, aggTestColl.Count);
		}

		[Test]
		public void PagingSimple()
		{
			AggregateTestCollection collection = new AggregateTestCollection();

            if (collection.es.Connection.Name == "SqlCe"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending);
                        all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query.Select(
                            collection.Query.Id,
                            collection.Query.LastName,
                            collection.Query.FirstName,
                            collection.Query.IsActive);
                        collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending);
                        collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending);
                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        string lq = collection.Query.Parse();

                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
		}

        [Test]
        public void PagingSimpleSelectAll()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            if (collection.es.Connection.Name == "SqlCe"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Descending);
                        all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Descending);
                        collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending);
                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        string lq = collection.Query.Parse();
                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
        }

        [Test]
		public void PagingWithWhere()
		{
			AggregateTestCollection collection = new AggregateTestCollection();

            if (aggTestColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending);
                        all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                        all.Query.Where(all.Query.IsActive == true);
                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query.Select(
                            collection.Query.Id,
                            collection.Query.LastName,
                            collection.Query.FirstName,
                            collection.Query.IsActive);
                        collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending);
                        collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending);
                        collection.Query.Where(collection.Query.IsActive == true);
                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
		}

        [Test]
        public void PagingWithTop()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            if (collection.es.Connection.Name == "SqlCe"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query.es.Top = 20;
                        all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending);
                        all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query.es.Top = 20;
                        collection.Query.Select(
                            collection.Query.Id,
                            collection.Query.LastName,
                            collection.Query.FirstName,
                            collection.Query.IsActive);
                        collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending);
                        collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending);
                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
        }

        [Test]
        public void PagingWithDistinct()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.Ignore("Paging Not supported");
                    break;

                default:
                    AggregateTestCollection all = new AggregateTestCollection();

                    all.Query.es.Distinct = true;
                    all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending);
                    all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                    all.Query.Load();

                    collection = new AggregateTestCollection();

                    collection.Query.es.Distinct = true;
                    collection.Query.Select(
                        collection.Query.Id,
                        collection.Query.LastName,
                        collection.Query.FirstName,
                        collection.Query.IsActive);
                    collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending);
                    collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending);
                    collection.Query.es.PageNumber = 1;
                    collection.Query.es.PageSize = 8;

                    string lq = collection.Query.Parse();
                    Assert.IsTrue(collection.Query.Load(), "Load 1");
                    Assert.AreEqual(8, collection.Count, "Count 1");

                    AggregateTest all0 = (AggregateTest)all[0];
                    AggregateTest collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                    collection.Query.es.PageNumber = 2;
                    Assert.IsTrue(collection.Query.Load(), "Load 2");
                    Assert.AreEqual(8, collection.Count, "Count 2");

                    all0 = (AggregateTest)all[8];
                    collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                    break;
            }
        }

        [Test]
        public void SkipTake()
        {
            AggregateTestCollection coll = new AggregateTestCollection();

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlClientProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.Ignore("Not supported");
                    break;
                default:
                    AggregateTestCollection all = new AggregateTestCollection();

                    all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending);
                    all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                    all.Query.Load();

                    coll = new AggregateTestCollection();

                    coll.Query.Select(
                        coll.Query.Id,
                        coll.Query.LastName,
                        coll.Query.FirstName,
                        coll.Query.IsActive);
                    coll.Query.Skip(8).Take(2);
                    coll.Query.OrderBy(coll.Query.LastName, esOrderByDirection.Ascending);
                    coll.Query.OrderBy(coll.Query.Id, esOrderByDirection.Ascending);

                    //string lq = coll.Query.Parse();

                    Assert.IsTrue(coll.Query.Load(), "Load");
                    Assert.AreEqual(2, coll.Count, "Count");

                    AggregateTest all0 = (AggregateTest)all[8];
                    AggregateTest collection0 = (AggregateTest)coll[0];
                    Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare");

                    break;
            }
        }

        [Test]
        public void ContainsNear()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "Acme NEAR Company";

                    collection.Query.Select(
                        collection.Query.CustomerID,
                        collection.Query.CustomerSub,
                        collection.Query.CustomerName.As("CName"),
                        collection.Query.Notes);
                    collection.Query.Where(
                        collection.Query.CustomerName.Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(2, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainsWildCard()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "\"2*\"";

                    collection.Query.Select(
                        collection.Query.CustomerID,
                        collection.Query.CustomerSub,
                        collection.Query.CustomerName.As("CName"),
                        collection.Query.Notes);
                    collection.Query.Where(
                        collection.Query.CustomerName.Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(9, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainsCaseInsensitive()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                            "acme NEAR company";

                    collection.Query.Where(
                        collection.Query.CustomerName.Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(2, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainsMultiTerms()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (coll.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "Acme NEAR Company";
                    string addressTerm =
                        "Road AND (\"St*\" OR \"Ave*\")";

                    coll.Query.Select(
                        coll.Query.CustomerID,
                        coll.Query.CustomerSub,
                        coll.Query.CustomerName,
                        coll.Query.Notes);
                    coll.Query.Where(
                        coll.Query.CustomerName.Contains(nameTerm) &&
                        coll.Query.Notes.Contains(addressTerm));

                    Assert.IsTrue(coll.Query.Load());
                    Assert.AreEqual(1, coll.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainswithSubOperator()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "Acme NEAR Company";

                    // SubOperators are ignored for CONTAINS.
                    // The search conditions belong in the search term parameter
                    collection.Query.Where(
                        collection.Query.CustomerName.ToLower().Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(2, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void PagingWithGroupBy()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.Ignore("Paging Not supported");
                    break;

                default:
                    AggregateTestCollection all = new AggregateTestCollection();

                    all.Query.Select(
                        all.Query.LastName,
                        all.Query.Salary.Avg());
                    all.Query.Where(all.Query.IsActive == true);
                    all.Query.GroupBy(all.Query.LastName);
                    all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending);
                    all.Query.Load();

                    collection = new AggregateTestCollection();

                    collection.Query.Select(
                        collection.Query.LastName,
                        collection.Query.Salary.Avg());
                    collection.Query.Where(collection.Query.IsActive == true);
                    collection.Query.GroupBy(collection.Query.LastName);
                    collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending);
                    collection.Query.es.PageNumber = 1;
                    collection.Query.es.PageSize = 8;

                    Assert.IsTrue(collection.Query.Load(), "Load 1");
                    Assert.AreEqual(8, collection.Count, "Count 1");

                    AggregateTest all0 = (AggregateTest)all[0];
                    AggregateTest collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 1");

                    collection.Query.es.PageNumber = 2;
                    Assert.IsTrue(collection.Query.Load(), "Load 2");
                    Assert.AreEqual(2, collection.Count, "Count 2");

                    all0 = (AggregateTest)all[8];
                    collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 2");

                    break;
            }
        }

        [Test]
        public void ManualWhereAnd()
        {
            ProductQuery pq = new ProductQuery("p");
            pq.es2.Connection.Name = "ForeignKeyTest";

            esComparison comp = null;
            comp = pq.ManualWhere("Discontinued", "EQUAL", false, null, "AND");
            comp = pq.ManualWhere("UnitPrice", "BETWEEN", 0.15, 0.20, "AND");
            comp = pq.ManualWhere("ProductID", "GREATERTHAN", 2, null, "AND");
            pq.Where(comp);

            ProductCollection coll = new ProductCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            Assert.IsTrue(coll.Load(pq));
            Assert.AreEqual(1, coll.Count);
        }

        [Test]
        public void ManualWhereOr()
        {
            ProductQuery pq = new ProductQuery("p");
            pq.es2.Connection.Name = "ForeignKeyTest";

            List<int> inList = new List<int>();
            inList.Add(8);
            inList.Add(9);

            esComparison comp = null;
            comp = pq.ManualWhere("ProductName", "LIKE", "W%", null, "OR");
            comp = pq.ManualWhere("UnitPrice", "LESSTHAN", 10.0, null, "OR");
            comp = pq.ManualWhere("ProductID", "IN", inList, null, "OR");
            pq.Where(comp);

            ProductCollection coll = new ProductCollection();
            coll.es.Connection.Name = "ForeignKeyTest";
            Assert.IsTrue(coll.Load(pq));
            Assert.AreEqual(7, coll.Count);
        }

    }
}
