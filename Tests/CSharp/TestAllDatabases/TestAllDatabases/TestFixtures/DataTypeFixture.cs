//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Linq;

using NUnit.Framework;

using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class DataTypeFixture
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
		public void TestDateTime()
		{
            int testId = -1;
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
            AggregateTest test = new AggregateTest();

            try
            {
                using (EntitySpaces.Interfaces.esTransactionScope scope =
                    new EntitySpaces.Interfaces.esTransactionScope())
                {
                    aggTestColl.Query.Load();
                    aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(s => s.Id);
                    test = (AggregateTest)aggTestColl[0];
                    DateTime date = test.HireDate.Value;
                    Assert.AreEqual(Convert.ToDateTime("02/16/2000 05:59:31"), date);

                    test = new AggregateTest();
                    test.HireDate = Convert.ToDateTime("12/31/9999");
                    test.Save();
                    testId = test.Id.Value;

                    test = new AggregateTest();
                    Assert.IsTrue(test.LoadByPrimaryKey(testId));
                    Assert.AreEqual(Convert.ToDateTime("12/31/9999"), test.HireDate.Value);
                    test.MarkAsDeleted();
                    test.Save();
                }
            }
            finally
            {
                // Clean up
                test = new AggregateTest();
                if (test.LoadByPrimaryKey(testId))
                {
                    test.MarkAsDeleted();
                    test.Save();
                }
            }
		}

        [Test]
        public void TestDateTimeMilliSeconds()
        {
            int testId = -1;
            AggregateTest test = new AggregateTest();

            switch (test.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                case "EntitySpaces.SqlClientProvider":
                    Assert.Ignore("Requires SQL Server 2008 and datetime2 data type.");
                    break;

                case "EntitySpaces.MySqlClientProvider":
                    Assert.Ignore("Not supported.");
                    break;

                default:
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            test.HireDate = Convert.ToDateTime("1901-01-01 01:01:01.001");
                            test.Save();
                            testId = test.Id.Value;

                            test = new AggregateTest();
                            Assert.IsTrue(test.LoadByPrimaryKey(testId));
                            Assert.AreEqual(Convert.ToDateTime("1901-01-01 01:01:01.001"), test.HireDate.Value, "MilliSeconds");
                        }
                    }
                    finally
                    {
                        // Clean up
                        test = new AggregateTest();
                        if (test.LoadByPrimaryKey(testId))
                        {
                            test.MarkAsDeleted();
                            test.Save();
                        }
                    }
                    break;
            }

        }

        [Test]
        public void TestDateTimeMicroSeconds()
        {
            int testId = -1;
            AggregateTest test = new AggregateTest();

            switch (test.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("MS Access only resolves to MilliSeconds.");
                    break;

                case "EntitySpaces.MySqlClientProvider":
                    Assert.Ignore("Not supported.");
                    break;

                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                case "EntitySpaces.SqlClientProvider":
                    Assert.Ignore("Requires SQL Server 2008 and datetime2 data type.");
                    break;

                default:
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            test.HireDate = Convert.ToDateTime("1902-01-01 01:01:01.000001");
                            test.Save();
                            testId = test.Id.Value;

                            test = new AggregateTest();
                            Assert.IsTrue(test.LoadByPrimaryKey(testId));
                            Assert.AreEqual(Convert.ToDateTime("1902-01-01 01:01:01.000001"), test.HireDate.Value, "MicroSeconds");
                        }
                    }
                    finally
                    {
                        // Clean up
                        test = new AggregateTest();
                        if (test.LoadByPrimaryKey(testId))
                        {
                            test.MarkAsDeleted();
                            test.Save();
                        }
                    }
                    break;
            }

        }

    }
}
