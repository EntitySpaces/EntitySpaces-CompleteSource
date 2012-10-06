//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.IO;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.DynamicQuery;

namespace Tests.Base
{
	[TestFixture]
	public class LoadFixture
	{
        AggregateTestCollection aggTestColl = new AggregateTestCollection();
        AggregateTest aggTest = new AggregateTest();
        AggregateTestQuery aggTestQuery = new AggregateTestQuery();
        AggregateTestCollection aggCloneColl = new AggregateTestCollection();
        AggregateTest aggClone = new AggregateTest();
        AggregateTestQuery aggCloneQuery = new AggregateTestQuery();
		FullNameViewCollection viewColl = new FullNameViewCollection();
		
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
			aggCloneColl = new AggregateTestCollection();
			aggClone = new AggregateTest();
			aggCloneQuery = new AggregateTestQuery();
		}

		[Test]
		public void EntityLoadByPrimaryKey()
		{
			aggTest.Query
				.Select()
				.Where
				(
					aggTest.Query.FirstName.Equal("Sarah"),
					aggTest.Query.LastName.Equal("Doe")
				);
			Assert.IsTrue(aggTest.Query.Load());
			int primaryKey = aggTest.Id.Value;

			Assert.IsTrue(aggClone.LoadByPrimaryKey(primaryKey));
			Assert.AreEqual("Doe", aggClone.str().LastName);
			Assert.AreEqual("Sarah", aggClone.str().FirstName);
		}

        [Test]
        public void EntityLoadByPrimaryKeyChar()
        {
            CustomerGroup cg = new CustomerGroup();
            cg.es.Connection.Name = "ForeignKeyTest";

            Assert.IsTrue(cg.LoadByPrimaryKey("05001"));
        }

        [Test]
		public void EntityLoadByPrimaryKeyFalse()
		{
			Assert.IsFalse(aggTest.LoadByPrimaryKey(-1));
		}

		[Test]
		public void EntityQueryLoadFalse()
		{
			aggTest.Query
				.Select()
				.Where
				(
					aggTest.Query.FirstName.Equal("x"),
					aggTest.Query.LastName.Equal("x")
				);
			Assert.IsFalse(aggTest.Query.Load());
		}

		[Test]
		public void EntityMultiFail()
		{
			bool failed = false;
			try
			{
				aggTest.Query
					.Select()
					.Where
					(
						aggTest.Query.FirstName.Equal("Sarah"),
						aggTest.Query.LastName.Equal("McDonald")
					);
				aggTest.Query.Load();
			}
			catch(Exception ex)
			{
				failed = true;
				Assert.AreEqual("An Entity can only hold 1 record of data", ex.Message);
			}

			if (!failed)
			{
				Assert.Fail("Exception not thrown.");
			}
		}

		[Test]
		public void EntityTop()
		{
            aggTest.Query
                .Select()
                .Where
                (
                    aggTest.Query.FirstName.Equal("Sarah"),
                    aggTest.Query.LastName.Equal("McDonald")
                );
            aggTest.Query.es.Top = 1;
            Assert.IsTrue(aggTest.Query.Load());

            Assert.AreEqual("McDonald", aggTest.str().LastName);
            Assert.AreEqual("Sarah", aggTest.str().FirstName);
        }

		[Test]
		public void EntityQueryReset()
		{
			aggTest.Query
				.Where
				(
					aggTest.Query.FirstName.Equal("Sarah"),
					aggTest.Query.LastName.Equal("Doe")
				);
			Assert.IsTrue(aggTest.Query.Load());

            aggTest = new AggregateTest();
			aggTest.Query
				.Where
				(
					aggTest.Query.FirstName.Equal("Fred"),
					aggTest.Query.LastName.Equal("Costner")
				);
			aggTest.Query.Load();
			Assert.IsTrue(aggTest.Query.Load());

			Assert.AreEqual("Costner", aggTest.str().LastName);
			Assert.AreEqual("Fred", aggTest.str().FirstName);
		}

		[Test]
		public void CollectionQueryReset()
		{
			aggTestColl.Query.Select(aggTestColl.Query.LastName);
			aggTestColl.Query.Where(aggTestColl.Query.IsActive == true);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count);

			aggTestColl.Query.Select(aggTestColl.Query.FirstName);
			aggTestColl.Query.Where(aggTestColl.Query.LastName == "Costner");
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(3, aggTestColl.Count);

			aggTestColl = new AggregateTestCollection();
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(30, aggTestColl.Count);
		}

		[Test]
		public void CollectionLoadAll()
		{
			Assert.IsTrue(aggTestColl.LoadAll());
			Assert.AreEqual(30, aggTestColl.Count);
		}

		[Test]
		public void CollectionLoadAllFalse()
		{
			AggregateTestCollection testColl = new AggregateTestCollection();

            try
            {
                testColl.LoadAll();
                testColl.MarkAllAsDeleted();
                testColl.Save();

                testColl = new AggregateTestCollection();
                Assert.IsFalse(testColl.LoadAll());
            }
            finally
            {
                UnitTestBase.RefreshDatabase();
            }
		}

		[Test]
		public void CollectionQueryLoad()
		{
			aggTestColl.Query.Select(aggTestColl.Query.LastName);
			aggTestColl.Query.Where(aggTestColl.Query.IsActive == true);
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(16, aggTestColl.Count);
		}

		[Test]
		public void CollectionTop()
		{
            aggTestColl.Query.es.Top = 1;
            aggTestColl.Query.Select(aggTestColl.Query.LastName);
            aggTestColl.Query.Where(aggTestColl.Query.IsActive == true);
            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

		[Test]
		public void TestHasData()
		{
			Assert.IsFalse(aggTestColl.HasData);

			Assert.IsTrue(aggTestColl.LoadAll());
			Assert.AreEqual(30, aggTestColl.Count);
			Assert.IsTrue(aggTestColl.HasData);

			aggTestColl = new AggregateTestCollection();
			Assert.IsFalse(aggTestColl.HasData);
			Assert.IsFalse(aggTest.es.HasData);

			aggTest = aggTestColl.AddNew();
			Assert.IsTrue(aggTestColl.HasData);
			Assert.IsTrue(aggTest.es.HasData);

			aggTest = new AggregateTest();
			Assert.IsFalse(aggTest.es.HasData);
            aggTest.Age = 40;
			Assert.IsTrue(aggTest.es.HasData);
		}

		[Test]
		public void TestSpecialBinder()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    aggTestColl.Query.Select
					(
						aggTestColl.Query.Id,
						"<LastName + ', ' + FirstName AS SpecialBinder>"
					);
					break;
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                    aggTestColl.Query.Select
                    (
                        aggTestColl.Query.Id,
                        "<LastName + ', ' + FirstName AS \"SpecialBinder\">"
                    )
                    .OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending);
                    break;
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                    aggTestColl.Query.Select
					(
						aggTestColl.Query.Id,
						"<\"LastName\" || ', ' || \"FirstName\" AS \"SpecialBinder\">"
					)
                    .OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending);
					break;
				default:
                    if (aggTestColl.es.Connection.Name == "SqlCe")
                    {
                        aggTestColl.Query.Select
                        (
                            aggTestColl.Query.Id,
                            "<LastName + ', ' + FirstName AS \"SpecialBinder\">"
                        )
                        .OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending);
                    }
                    else
                    {
                        aggTestColl.Query.Select
                        (
                            aggTestColl.Query.Id,
                            "<LastName + ', ' + FirstName AS 'SpecialBinder'>"
                        )
                        .OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending);
                    }
					break;
			}
			Assert.IsTrue(aggTestColl.Query.Load());
			Assert.AreEqual(30, aggTestColl.Count);
		}

		[Test]
		public void LoadText()
		{
			aggTestColl = new AggregateTestCollection();
			aggTestColl.CustomLoadText();
			Assert.AreEqual(8, aggTestColl.Count);
		}

		[Test]
		public void LoadTextEsParams()
		{
			aggTestColl = new AggregateTestCollection();
			aggTestColl.CustomLoadTextEsParams("D");
			Assert.AreEqual(6, aggTestColl.Count);
		}

        [Test]
        public void TestCommandTimeout()
        {
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    aggTestColl = new AggregateTestCollection();
                    aggTestColl.es.Connection.CommandTimeout = 49;
                    Assert.IsTrue(aggTestColl.Query.Load(), "Query.Load");
                    Assert.AreEqual(49, aggTestColl.es.Connection.CommandTimeout);
                    aggTestColl = new AggregateTestCollection();
                    Assert.IsTrue(aggTestColl.LoadAll(), "LoadAll");
                    Assert.AreEqual(39, aggTestColl.es.Connection.CommandTimeout);
                    break;

                default:
                    Assert.Ignore("SQL Server only");
                    break;
            }
        }

        [Test]
        public void TestCommandTimeoutConfig()
        {
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    // Collection
                    aggTestColl = new AggregateTestCollection();
                    Assert.AreEqual(39, aggTestColl.es.Connection.CommandTimeout);
                    Assert.IsTrue(aggTestColl.Query.Load(), "Query.Load");
                    aggTestColl = new AggregateTestCollection();
                    Assert.AreEqual(39, aggTestColl.es.Connection.CommandTimeout);
                    Assert.IsTrue(aggTestColl.LoadAll(), "LoadAll");

                    // Entity
                    aggTest = new AggregateTest();
                    Assert.AreEqual(39, aggTest.es.Connection.CommandTimeout);
                    aggTest.Query.es.Top = 1;
                    Assert.IsTrue(aggTest.Query.Load(), "Query.Load");
                    int aggKey = aggTest.Id.Value;
                    aggTest = new AggregateTest();
                    Assert.AreEqual(39, aggTest.es.Connection.CommandTimeout);
                    Assert.IsTrue(aggTest.LoadByPrimaryKey(aggKey), "LoadByPK");
                    break;

                default:
                    Assert.Ignore("tested for SQL Server only");
                    break;
            }
        }

        #region View tests

		[Test]
		public void CollectionCustomLoadFromView()
		{
            if (aggTestColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                viewColl = new FullNameViewCollection();
                viewColl.CustomLoadFromView();
                Assert.AreEqual(6, viewColl.Count);
            }
		}

		[Test]
		public void CollectionCustomLoadFromViewNoParams()
		{
            viewColl = new FullNameViewCollection();

            if (viewColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                string whereClause = "";

                switch (viewColl.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.NpgsqlProvider":
                    case "EntitySpaces.Npgsql2Provider":
                    case "EntitySpaces.OracleClientProvider":
                        whereClause = "WHERE \"DepartmentID\" = 1 ";
                        whereClause += "OR \"DepartmentID\" = 2 ";
                        break;

                    case "EntitySpaces.MySqlClientProvider":
                        whereClause = "WHERE `DepartmentID` = 1 ";
                        whereClause += "OR `DepartmentID` = 2";
                        break;

                    default:
                        whereClause = "WHERE [DepartmentID] = 1 ";
                        whereClause += "OR [DepartmentID] = 2";
                        break;
                }
                viewColl.CustomLoadFromViewNoParams(whereClause);
                Assert.AreEqual(6, viewColl.Count);
            }
		}

        [Test]
        public void CollectionCustomLoadFromViewByDept()
        {
            if (aggTestColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                viewColl = new FullNameViewCollection();
                viewColl.CustomLoadFromViewByDept(1);
                Assert.AreEqual(2, viewColl.Count);
            }
        }

        #endregion

	}
}
