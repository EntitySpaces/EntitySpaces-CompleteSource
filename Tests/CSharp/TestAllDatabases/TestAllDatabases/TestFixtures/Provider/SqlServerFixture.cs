//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class SqlServerFixture
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
		public void DataTypeBigInt()
		{
            SqlServerTypeTest dataTest = new SqlServerTypeTest();

            switch (dataTest.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        dataTest = new SqlServerTypeTest();

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count1");
                        dataTest.BigIntType = 1000000000;
                        Assert.AreEqual(1, dataTest.es.ModifiedColumns.Count, "Count2");
                        dataTest.Save();
                        long tempKey = dataTest.Id.Value;

                        dataTest = new SqlServerTypeTest();
                        Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey));
                        Assert.AreEqual(1000000000, dataTest.BigIntType.Value);

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count3");
                        dataTest.BigIntType = dataTest.BigIntType;
                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count4");

                        // Clean up
                        dataTest.MarkAsDeleted();
                        dataTest.Save();
                    }
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
		}

        [Test]
        public void DataTypeVarCharMax()
        {
            SqlServerTypeTest dataTest = new SqlServerTypeTest();

            switch (dataTest.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        dataTest = new SqlServerTypeTest();

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count1");
                        dataTest.VarCharMaxType = "Test";
                        Assert.AreEqual(1, dataTest.es.ModifiedColumns.Count, "Count2");
                        dataTest.Save();
                        long tempKey = dataTest.Id.Value;

                        dataTest = new SqlServerTypeTest();
                        Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey));
                        Assert.AreEqual("Test", dataTest.VarCharMaxType);

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count3");
                        dataTest.VarCharMaxType = dataTest.VarCharMaxType;
                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count4");

                        // Clean up
                        dataTest.MarkAsDeleted();
                        dataTest.Save();
                    }
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
        }

        [Test]
        public void DataTypeNChar()
        {
            SqlServerTypeTest dataTest = new SqlServerTypeTest();

            switch (dataTest.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        dataTest = new SqlServerTypeTest();

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count1");
                        dataTest.NCharType = 'T';
                        Assert.AreEqual(1, dataTest.es.ModifiedColumns.Count, "Count2");
                        dataTest.Save();
                        long tempKey = dataTest.Id.Value;

                        dataTest = new SqlServerTypeTest();
                        Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey));
                        Assert.AreEqual('T', dataTest.NCharType.Value);

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count3");
                        dataTest.NCharType = dataTest.NCharType;
                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count4");

                        // Clean up
                        dataTest.MarkAsDeleted();
                        dataTest.Save();
                    }
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
        }

        [Test]
        public void DataTypeLargeMoneyMin()
        {
            OrderItem dataTest = new OrderItem();
            dataTest.es.Connection.Name = "ForeignKeyTest";

            switch (dataTest.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            dataTest = new OrderItem();
                            dataTest.es.Connection.Name = "ForeignKeyTest";
                            dataTest.OrderID = 3;
                            dataTest.ProductID = 3;
                            dataTest.Quantity = 1;
                            dataTest.UnitPrice = -922337203685477.5808M;
                            dataTest.Save();

                            dataTest = new OrderItem();
                            dataTest.es.Connection.Name = "ForeignKeyTest";
                            Assert.IsTrue(dataTest.LoadByPrimaryKey(3, 3));
                            Assert.AreEqual(-922337203685477.5808M, dataTest.UnitPrice.Value);
                        }
                    }
                    finally
                    {
                        // Clean up
                        dataTest = new OrderItem();
                        dataTest.es.Connection.Name = "ForeignKeyTest";
                        if (dataTest.LoadByPrimaryKey(3, 3))
                        {
                            dataTest.MarkAsDeleted();
                            dataTest.Save();
                        }
                    }

                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
        }

        [Test]
        public void DataTypeLargeMoneyMax()
        {
            OrderItem dataTest = new OrderItem();
            dataTest.es.Connection.Name = "ForeignKeyTest";

            switch (dataTest.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            dataTest = new OrderItem();
                            dataTest.es.Connection.Name = "ForeignKeyTest";
                            dataTest.OrderID = 3;
                            dataTest.ProductID = 3;
                            dataTest.Quantity = 1;
                            dataTest.UnitPrice = 922337203685477.5807M;
                            dataTest.Save();

                            dataTest = new OrderItem();
                            dataTest.es.Connection.Name = "ForeignKeyTest";
                            Assert.IsTrue(dataTest.LoadByPrimaryKey(3, 3));
                            Assert.AreEqual(922337203685477.5807M, dataTest.UnitPrice.Value);
                        }
                    }
                    finally
                    {
                        // Clean up
                        dataTest = new OrderItem();
                        dataTest.es.Connection.Name = "ForeignKeyTest";
                        if (dataTest.LoadByPrimaryKey(3, 3))
                        {
                            dataTest.MarkAsDeleted();
                            dataTest.Save();
                        }
                    }

                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
        }

        [Test]
        public void InsertGuidPrimaryKey()
        {
            NamingTestCollection namingTestColl = new NamingTestCollection();
            NamingTest namingTest = new NamingTest();

            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTest.Save();
                    Guid? tempKey = namingTest.GuidKeyAlias;

                    namingTest = new NamingTest();
                    Assert.IsTrue(namingTest.LoadByPrimaryKey(tempKey.Value));
                    namingTest.MarkAsDeleted();
                    namingTest.Save();
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
        }

        [Test]
		public void SetGuidPrimaryKey()
		{
            NamingTestCollection namingTestColl = new NamingTestCollection();
            NamingTest namingTest = new NamingTest();

            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    string testGuid = "b3883c65-ff94-47c4-8b0c-76896bedd45a";
                    namingTest.GuidKeyAlias = new Guid(testGuid);
                    namingTest.Save();
                    Guid? tempKey = namingTest.GuidKeyAlias;
                    namingTest.MarkAsDeleted();
                    namingTest.Save();
                    Assert.AreEqual(testGuid, tempKey.Value.ToString());
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
		}

        [Test]
        public void IdentityKeyPlusGuidNewid()
        {
            NamingTest2Collection namingTestColl = new NamingTest2Collection();
            NamingTest2 namingTest = new NamingTest2();

            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    string testGuid = "b3883c65-ff94-47c4-8b0c-76896bedd45a";
                    namingTest.GuidNewid = new Guid(testGuid);
                    namingTest.Save();
                    int tempKey = namingTest.IdentityKey.Value;

                    namingTest = new NamingTest2();
                    namingTest.LoadByPrimaryKey(tempKey);
                    Assert.AreEqual(testGuid, namingTest.str().GuidNewid);

                    namingTest.MarkAsDeleted();
                    namingTest.Save();
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
        }

        [Test]
		public void GuidDynamicQuery()
		{
            NamingTestCollection namingTestColl = new NamingTestCollection();
            NamingTest namingTest = new NamingTest();

            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTest.Save();
                    Guid? tempKey = namingTest.GuidKeyAlias;
                    namingTestColl.Query.Where(namingTestColl.Query.GuidKeyAlias == tempKey);
                    namingTestColl.Query.Load();
                    Assert.AreEqual(1, namingTestColl.Count);
                    Assert.IsTrue(namingTest.LoadByPrimaryKey(tempKey.Value));
                    namingTest.MarkAsDeleted();
                    namingTest.Save();
                    break;

                default:
                    Assert.Ignore("Sql Server only");
                    break;
            }
		}

        [Test]
        public void ConcurrencyOnUpdate()
        {
            ComputedTestCollection collection = new ComputedTestCollection();
            int testId = 0;

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            // Setup
                            ComputedTest entity = new ComputedTest();
                            entity.Save();
                            testId = entity.Id.Value;

                            // Test
                            entity = new ComputedTest();
                            entity.LoadByPrimaryKey(testId);
                            entity.str().SomeDate = "2007-01-01";

                            ComputedTest entity2 = new ComputedTest();
                            entity2.LoadByPrimaryKey(testId);
                            entity2.str().SomeDate = "1999-12-31";

                            entity.Save();
                            entity2.Save();
                            Assert.Fail("Concurrency Exception not thrown.");
                        }
                    }
                    catch (EntitySpaces.Interfaces.esConcurrencyException cex)
                    {
                        Assert.AreEqual("Update failed", cex.Message.Substring(0, 13));
                    }
                    finally
                    {
                        ComputedTest entity = new ComputedTest();
                        if (entity.LoadByPrimaryKey(testId))
                        {
                            entity.MarkAsDeleted();
                            entity.Save();
                        }
                    }
                    break;

                default:
                    Assert.Ignore("SQL Server only.");
                    break;
            }
        }

        [Test]
        public void ConcurrencyOnDelete()
        {
            ComputedTestCollection collection = new ComputedTestCollection();
            int testId = 0;

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            // Setup
                            ComputedTest entity = new ComputedTest();
                            entity.Save();
                            testId = entity.Id.Value;

                            // Test
                            entity = new ComputedTest();
                            entity.LoadByPrimaryKey(testId);
                            entity.str().SomeDate = "2007-01-01";

                            ComputedTest entity2 = new ComputedTest();
                            entity2.LoadByPrimaryKey(testId);
                            entity2.MarkAsDeleted();

                            entity.Save();
                            entity2.Save();
                            Assert.Fail("Concurrency Exception not thrown.");
                        }
                    }
                    catch (EntitySpaces.Interfaces.esConcurrencyException cex)
                    {
                        Assert.AreEqual("Update failed", cex.Message.Substring(0, 13));
                    }
                    finally
                    {
                        // Cleanup
                        ComputedTest entity = new ComputedTest();
                        if (entity.LoadByPrimaryKey(testId))
                        {
                            entity.MarkAsDeleted();
                            entity.Save();
                        }
                    }
                    break;

                default:
                    Assert.Ignore("SQL Server only.");
                    break;
            }
        }

    }
}
