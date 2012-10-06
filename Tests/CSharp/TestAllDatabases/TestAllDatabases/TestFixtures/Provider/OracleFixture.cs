//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using EntitySpaces.Interfaces;

using NUnit.Framework;
using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class OracleFixture
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
        public void ConcurrencyOnUpdate()
        {
            OracleTestCollection collection = new OracleTestCollection();
            int testId = 0;

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.OracleClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            // Setup
                            OracleTest entity = new OracleTest();
                            entity.Save();
                            testId = (int)entity.Id.Value;

                            // Test
                            entity = new OracleTest();
                            entity.LoadByPrimaryKey(testId);
                            entity.str().DateType = "2007-01-01";

                            OracleTest entity2 = new OracleTest();
                            entity2.LoadByPrimaryKey(testId);
                            entity2.str().DateType = "1999-12-31";

                            entity.Save();
                            entity2.Save();
                            Assert.Fail("Concurrency Exception not thrown.");
                        }
                    }
                    catch (EntitySpaces.Interfaces.esConcurrencyException cex)
                    {
                        Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5));
                    }
                    finally
                    {
                        // Cleanup
                        OracleTest entity = new OracleTest();
                        if (entity.LoadByPrimaryKey(testId))
                        {
                            entity.MarkAsDeleted();
                            entity.Save();
                        }
                    }
                    break;

                default:
                    Assert.Ignore("Oracle only.");
                    break;
            }
        }

        [Test]
        public void NoSeqConcurrencyOnUpdate()
        {
            OracleTest2Collection collection = new OracleTest2Collection();
            string testId = "XXXXX";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.OracleClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            // Setup
                            OracleTest2 entity = new OracleTest2();
                            entity.Id = testId;
                            entity.Save();

                            // Test
                            entity = new OracleTest2();
                            entity.LoadByPrimaryKey(testId);
                            entity.str().DateType = "2007-01-01";

                            OracleTest2 entity2 = new OracleTest2();
                            entity2.LoadByPrimaryKey(testId);
                            entity2.str().DateType = "1999-12-31";

                            entity.Save();
                            entity2.Save();
                            Assert.Fail("Concurrency Exception not thrown.");
                        }
                    }
                    catch (EntitySpaces.Interfaces.esConcurrencyException cex)
                    {
                        Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5));
                    }
                    finally
                    {
                        // Cleanup
                        OracleTest2 entity = new OracleTest2();
                        if (entity.LoadByPrimaryKey(testId))
                        {
                            entity.MarkAsDeleted();
                            entity.Save();
                        }
                    }
                    break;

                default:
                    Assert.Ignore("Oracle only.");
                    break;
            }
        }

        [Test]
        public void ConcurrencyOnDelete()
        {
            OracleTestCollection collection = new OracleTestCollection();
            int testId = 0;

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.OracleClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            // Setup
                            OracleTest entity = new OracleTest();
                            entity.Save();
                            testId = (int)entity.Id.Value;

                            // Test
                            entity = new OracleTest();
                            entity.LoadByPrimaryKey(testId);
                            entity.str().DateType = "2007-01-01";

                            OracleTest entity2 = new OracleTest();
                            entity2.LoadByPrimaryKey(testId);
                            entity2.MarkAsDeleted();

                            entity.Save();
                            entity2.Save();
                            Assert.Fail("Concurrency Exception not thrown.");
                        }
                    }
                    catch (EntitySpaces.Interfaces.esConcurrencyException cex)
                    {
                        Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5));
                    }
                    finally
                    {
                        // Cleanup
                        OracleTest entity = new OracleTest();
                        if (entity.LoadByPrimaryKey(testId))
                        {
                            entity.MarkAsDeleted();
                            entity.Save();
                        }
                    }
                    break;

                default:
                    Assert.Ignore("Oracle only.");
                    break;
            }
        }

        [Test]
        public void NoSeqConcurrencyOnDelete()
        {
            OracleTest2Collection collection = new OracleTest2Collection();
            string testId = "XXXXX";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.OracleClientProvider":
                    try
                    {
                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            // Setup
                            OracleTest2 entity = new OracleTest2();
                            entity.Id = testId;
                            entity.Save();

                            // Test
                            entity = new OracleTest2();
                            entity.LoadByPrimaryKey(testId);
                            entity.str().DateType = "2007-01-01";

                            OracleTest2 entity2 = new OracleTest2();
                            entity2.LoadByPrimaryKey(testId);
                            entity2.MarkAsDeleted();

                            entity.Save();
                            entity2.Save();
                            Assert.Fail("Concurrency Exception not thrown.");
                        }
                    }
                    catch (EntitySpaces.Interfaces.esConcurrencyException cex)
                    {
                        Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5));
                    }
                    finally
                    {
                        // Cleanup
                        OracleTest2 entity = new OracleTest2();
                        if (entity.LoadByPrimaryKey(testId))
                        {
                            entity.MarkAsDeleted();
                            entity.Save();
                        }
                    }
                    break;

                default:
                    Assert.Ignore("Oracle only.");
                    break;
            }
        }

        [Test]
        public void InlineRawSqlInOrderBy()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.OracleClientProvider":
                    // Oracle case insensitive sort.
                    collection.Query.OrderBy(
                        "<NLSSORT(\"CustomerName\", 'NLS_SORT=BINARY_CI')>",
                        EntitySpaces.DynamicQuery.esOrderByDirection.Ascending);

                    Assert.IsTrue(collection.Query.Load(), "Load 1");
                    Assert.AreEqual(56, collection.Count);

                    //collection = new CustomerCollection();
                    //collection.es.Connection.Name = "ForeignKeyTest";
                    //collection.Query.Where(
                    //    collection.Query.CustomerName == "entityspaces");

                    //Assert.IsTrue(collection.Query.Load(), "Load 2");
                    //Assert.AreEqual(1, collection.Count);

                    collection = new CustomerCollection();
                    collection.es.Connection.Name = "ForeignKeyTest";
                    collection.Query.Where(
                        collection.Query.CustomerName.ToLower() ==
                          "entityspaces");

                    Assert.IsTrue(collection.Query.Load(), "Load 3");
                    Assert.AreEqual(46, collection.Count);

                    break;

                default:
                    Assert.Ignore("Oracle only.");
                    break;
            }
        }

        [Test]
        public void OracleXmlType()
        {
            OracleXmlTestCollection coll = new OracleXmlTestCollection();
            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.OracleClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        string xmltypeCol = @"<?xml version=""1.0""?><EMAIL>SKING</EMAIL>";

                        OracleXmlTest entity = new OracleXmlTest();
                        entity.Id = "test1";
                        entity.XmlColumn = xmltypeCol;
                        entity.Save();
                        //entity.InsertOracleXml();

                        coll = new OracleXmlTestCollection();
                        //coll.LoadAll();
                        //Assert.IsTrue(coll.LoadOracleXml(), "Load");
                        coll.Query.SelectAllExcept(coll.Query.XmlColumn);
                        coll.Query.Select("<SYS.XMLTYPE.GETSTRINGVAL(\"XmlColumn\") AS \"XmlColumn\">");
                        coll.Query.Load();

                        //string xmlCol = coll[0].XmlColumn;
                        //string xmlId = coll[0].Id;
                        Assert.AreEqual(xmltypeCol, coll[0].XmlColumn, "Compare");
                    }
                    break;

                default:
                    Assert.Ignore("Oracle only.");
                    break;
            }
        }

    }
}
