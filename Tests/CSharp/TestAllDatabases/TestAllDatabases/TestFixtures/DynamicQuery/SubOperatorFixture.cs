//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using BusinessObjects;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace Tests.Base
{
	[TestFixture]
	public class SubOperatorFixture
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
		public void TestToUpper()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.ToUpper() == "DOE");
			collection.Query.Load();
			Assert.AreEqual(3, collection.Count);
		}

        [Test]
        public void TestToUpperInSelect()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Select(collection.Query.LastName.ToUpper());
            collection.Query.Where(collection.Query.LastName == "Doe");
            collection.Query.Load();
            Assert.AreEqual(3, collection.Count);
            Assert.AreEqual("DOE", collection[0].LastName);
        }

        [Test]
		public void TestToUpperWithLike()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.ToUpper().Like("DO%"));
			collection.Query.Load();
			Assert.AreEqual(4, collection.Count);
		}

		[Test]
		public void TestToLower()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.ToLower() == "doe");
			collection.Query.Load();
			Assert.AreEqual(3, collection.Count);
		}

		[Test]
		public void TestToLowerWithIn()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.ToLower().In("doe", "douglas"));
			collection.Query.Load();
			Assert.AreEqual(4, collection.Count);
		}

		[Test]
		public void TestLTrim()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.LTrim() == "Doe");
			collection.Query.Load();
			Assert.AreEqual(3, collection.Count);
		}

		[Test]
		public void TestLTrimWithBetween()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.LTrim().Between("Doe", "Douglas"));
			collection.Query.Load();
			Assert.AreEqual(4, collection.Count);
		}

		[Test]
		public void TestRTrim()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.RTrim() == "Doe");
			collection.Query.Load();
			Assert.AreEqual(3, collection.Count);
		}

		[Test]
		public void TestRTrimWithEqual()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.RTrim().Equal("Doe"));
			collection.Query.Load();
			Assert.AreEqual(3, collection.Count);
		}

		[Test]
		public void TestTrim()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.Trim() == "Doe");
			collection.Query.Load();
			Assert.AreEqual(3, collection.Count);
		}

		[Test]
		public void TestTrimWithNotEqual()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.Trim().NotEqual("Doe"));
			collection.Query.Load();
			Assert.AreEqual(21, collection.Count);
		}

		[Test]
		public void TestSubstring()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.Substring(1, 2) == "Do");
			collection.Query.Load();
			Assert.AreEqual(4, collection.Count);
		}

        [Test]
        public void TestSubstringNoStart()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Where(collection.Query.LastName.Substring(2) == "Do");
            collection.Query.OrderBy(collection.Query.Id,
                EntitySpaces.DynamicQuery.esOrderByDirection.Ascending);
            collection.Query.Load();
            Assert.AreEqual(4, collection.Count);
            Assert.AreEqual("Doe", collection[0].LastName);
        }

        [Test]
		public void TestSubstringWithNotNull()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Where(collection.Query.LastName.Substring(1, 2).IsNotNull());
			collection.Query.Load();
			Assert.AreEqual(24, collection.Count);
		}

		[Test]
		public void TestCoalesceInWhere()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			if (collection.es.Connection.ProviderMetadataKey != "esAccess")
			{
				collection.Query.Where(collection.Query.LastName.Coalesce("'1'") == "1");
				collection.Query.Load();
				Assert.AreEqual(6, collection.Count);
			}
			else
			{
				Assert.Ignore("Not supported.");
			}
		}

		[Test]
		public void TestCoalesceInSelect()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			if (collection.es.Connection.ProviderMetadataKey != "esAccess")
			{
				collection.Query.Select(collection.Query.LastName.Coalesce("'x'"));
				collection.Query.Load();
				collection.Filter = collection.AsQueryable().Where(f => f.LastName == "x");
				Assert.AreEqual(6, collection.Count);
			}
			else
			{
				Assert.Ignore("Not supported.");
			}
		}

		[Test]
		public void TestDateInWhere()
		{
			AggregateTestCollection collection = new AggregateTestCollection();

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    collection.Query.Where(collection.Query.HireDate.Date() ==
                        "2000-02-16");
                    break;

                default:
                    collection.Query.Where(collection.Query.HireDate.Date() ==
                        Convert.ToDateTime("2000-02-16"));
                    break;
            }

            collection.Query.Load();
            Assert.AreEqual(1, collection.Count);
        }

		[Test]
		public void TestDateInSelect()
		{
			AggregateTestCollection collection = new AggregateTestCollection();
			collection.Query.Select(collection.Query.HireDate.Date());
            string lq = collection.Query.Parse();
			collection.Query.Load();
			Assert.AreEqual(30, collection.Count);
            collection.Filter = collection.AsQueryable().Where(f => f.HireDate != null && f.HireDate.Value.ToShortDateString() == "2/16/2000");
			Assert.AreEqual(1, collection.Count);
		}

        [Test]
        public void TestDateWithPaging()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;

                case "EntitySpaces.SQLiteProvider":
                    collection.Query.Where(collection.Query.HireDate.Date().Equal("2000-02-16"));
                    break;

                default:
                    collection.Query.Where(
                        collection.Query.HireDate.Date().Equal(Convert.ToDateTime("2000-02-16")));
                    break;
            }

            collection.Query.OrderBy(collection.Query.LastName.Ascending);
            collection.Query.es.PageNumber = 1;
            collection.Query.es.PageSize = 10;
            Assert.IsTrue(collection.Query.Load());
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void WhereLikeEscapedMultiWithSubOp()
        {
            int tempId = -1;
            AggregateTestCollection collection = new AggregateTestCollection();
            AggregateTest aggTest = new AggregateTest();

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
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

                            collection.Query
                                .Select()
                                .Where
                                (
                                    collection.Query.LastName.Trim().Like("%10!%%", '!'),
                                    collection.Query.LastName.Like("%a%")
                                );
                            Assert.IsTrue(collection.Query.Load());
                            Assert.AreEqual(1, collection.Count);
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
        public void TestLength()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Where(collection.Query.LastName.Length() == 3);
            string lq = collection.Query.Parse();
            collection.Query.Load();
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void TestRoundInSelect()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Select(collection.Query.Salary.Round(0));
            collection.Query.Where(collection.Query.FirstName == "David");
            collection.Query.Where(collection.Query.LastName == "Doe");
            collection.Query.Load();
            Assert.AreEqual(35.0000m, collection[0].Salary.Value);
        }

        [Test]
        public void TestRoundInSelectPositive()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            collection.Query.Select(collection.Query.Salary.Round(1));
            collection.Query.Where(collection.Query.FirstName == "David");
            collection.Query.Where(collection.Query.LastName == "Doe");
            collection.Query.Load();
            Assert.AreEqual(34.7000m, collection[0].Salary.Value);
        }

        [Test]
        public void TestRoundInWhereZero()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            collection.Query.Where(collection.Query.Salary.Round(0) == 35);

            string lq = collection.Query.Parse();
            collection.Query.Load();
            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void TestRoundInWherePositive()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            collection.Query.Where(collection.Query.Salary.Round(1) == 34.7);

            string lq = collection.Query.Parse();
            collection.Query.Load();
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void TestRoundInWhereNegative()
        {
            AggregateTestCollection collection = new AggregateTestCollection();


            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("Not Supported");
                    break;

                default:
                    collection.Query.Where(collection.Query.Salary.Round(-1) == 30);
                    break;
            }

            string lq = collection.Query.Parse();
            collection.Query.Load();
            Assert.AreEqual(9, collection.Count);
        }

        [Test]
        public void TestDatePartInSelect()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    collection.Query.Select
                    (
                        collection.Query.FirstName,
                        collection.Query.LastName,
                        collection.Query.HireDate.DatePart("month").As("HireMonth")
                    );
                    break;

                case "EntitySpaces.OracleClientProvider":
                    collection.Query.Select
                    (
                        collection.Query.FirstName,
                        collection.Query.LastName,
                        collection.Query.HireDate.DatePart("MONTH").As("HireMonth")
                    );
                    break;

                case "EntitySpaces.SQLiteProvider":
                    collection.Query.Select
                    (
                        collection.Query.FirstName,
                        collection.Query.LastName,
                        collection.Query.HireDate.DatePart("'%m'").As("HireMonth")
                    );
                    break;

                default:
                    collection.Query.Select
                    (
                        collection.Query.FirstName,
                        collection.Query.LastName,
                        collection.Query.HireDate.DatePart("m").As("HireMonth")
                    );
                    break;
            }

            collection.Query.Where(collection.Query.FirstName == "David");
            collection.Query.Where(collection.Query.LastName == "Doe");
            string lq = collection.Query.Parse();
            collection.Query.Load();

            if (collection.es.Connection.ProviderSignature.DataProviderName ==
                "EntitySpaces.SQLiteProvider")
            {
                Assert.AreEqual("02", collection[0].GetColumn("HireMonth"));
            }
            else
            {
                Assert.AreEqual(2, collection[0].GetColumn("HireMonth"));
            }
        }

        [Test]
        public void TestDatePartInWhere()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("month") == 5);
                    break;

                case "EntitySpaces.OracleClientProvider":
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("MONTH") == 5);
                    break;

                case "EntitySpaces.SQLiteProvider":
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("'%m'") == "05");
                    break;

                default:
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("m") == 5);
                    break;
            }

            collection.Query.Load();
            Assert.AreEqual(4, collection.Count);
        }

        [Test]
        public void TestDatePartInWhereGreaterThan()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("year") > 2000);
                    break;

                case "EntitySpaces.OracleClientProvider":
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("YEAR") > 2000);
                    break;

                case "EntitySpaces.SQLiteProvider":
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("'%Y'") > "2000");
                    break;

                default:
                    collection.Query.Where(
                        collection.Query.HireDate.DatePart("yyyy") > 2000);
                    break;
            }

            collection.Query.Where(
                collection.Query.IsActive == true);
            collection.Query.Where(
                collection.Query.DepartmentID >= 2);
            collection.Query.Where(
                collection.Query.FirstName.Substring(1, 4) != "Paul");
            collection.Query.Load();
            Assert.AreEqual(4, collection.Count);
        }

        [Test]
        public void TestDatePartInOrderBy()
        {
            AggregateTestCollection collection = new AggregateTestCollection();
            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    collection.Query.OrderBy(
                        collection.Query.HireDate.DatePart("month").Ascending);
                    break;

                case "EntitySpaces.OracleClientProvider":
                    collection.Query.OrderBy(
                        collection.Query.HireDate.DatePart("MONTH").Ascending);
                    break;

                case "EntitySpaces.SQLiteProvider":
                    collection.Query.OrderBy(
                        collection.Query.HireDate.DatePart("'%m'").Ascending);
                    break;

                default:
                    collection.Query.OrderBy(
                        collection.Query.HireDate.DatePart("m").Ascending);
                    break;
            }

            Assert.IsTrue(collection.Query.Load());
        }
    }
}
