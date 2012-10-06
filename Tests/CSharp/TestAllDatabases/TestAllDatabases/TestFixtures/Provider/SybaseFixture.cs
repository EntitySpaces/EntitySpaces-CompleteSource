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
	public class SybaseFixture
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
            ComputedTestCollection collection = new ComputedTestCollection();
            int testId = 0;

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SybaseSqlAnywhereProvider":
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
                        string err = cex.InnerException.Message.Substring(0, 11);
                        Assert.AreEqual("Error", cex.Message.Substring(0, 5));
                        Assert.AreEqual("Concurrency", err);
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
                    Assert.Ignore("Sybase only.");
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
                case "EntitySpaces.SybaseSqlAnywhereProvider":
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
                        string err = cex.InnerException.Message.Substring(0, 11);
                        Assert.AreEqual("Error", cex.Message.Substring(0, 5));
                        Assert.AreEqual("Concurrency", err);
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
                    Assert.Ignore("Sybase only.");
                    break;
            }
        }

    }
}
