//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.Interfaces;

namespace Tests.Base
{
	[TestFixture]
	public class TransactionFixture
	{
		AggregateTestCollection aggTestColl = new AggregateTestCollection();
        AggregateTest aggTest = new AggregateTest();
		
		[TestFixtureSetUp]
		public void Init()
		{
        }

		[SetUp]
		public void Init2()
		{
            aggTestColl = new AggregateTestCollection();
            aggTest = new AggregateTest();
        }

		[Test]
		public void TestTransactions()
		{
			switch (aggTest.es.Connection.Name)
			{
				case "SQLStoredProcEnterprise":
				case "SQLDynamicEnterprise":
				case "ORACLEStoredProcEnterprise":
				case "ORACLEDynamicEnterprise":
				case "VistaDBDynamic":
					Assert.Ignore("Using esTransactionScope only");
					break;

				default:
                    int tempId1 = 0;
                    int tempId2 = 0;

                    aggTest = new AggregateTest();
                    AggregateTest aggTest2 = new AggregateTest();

                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        aggTest.Save();
                        tempId1 = aggTest.Id.Value;
                        aggTest2.Save();
                        tempId2 = aggTest2.Id.Value;

                        scope.Complete();
                    }

                    aggTest = new AggregateTest();
                    Assert.IsTrue(aggTest.LoadByPrimaryKey(tempId1));
                    aggTest.MarkAsDeleted();
                    aggTest.Save();

                    aggTest = new AggregateTest();
                    Assert.IsTrue(aggTest.LoadByPrimaryKey(tempId2));
                    aggTest.MarkAsDeleted();
                    aggTest.Save();

					break;
			}
		}

        [Test]
        public void TestFailedTransaction()
        {
            switch (aggTest.es.Connection.Name)
            {
                case "SQLStoredProcEnterprise":
                case "SQLDynamicEnterprise":
                case "ORACLEStoredProcEnterprise":
                case "ORACLEDynamicEnterprise":
                case "VistaDBDynamic":
                    Assert.Ignore("Using esTransactionScope only");
                    break;

                default:
                    try
                    {
                        aggTest = new AggregateTest();
                        AggregateTest aggTest2 = new AggregateTest();
                        int tempId1 = -1;
                        int tempId2 = -1;
                        aggTest2.str().HireDate = "1/1/1";

                        using (esTransactionScope scope = new esTransactionScope())
                        {
                            try
                            {
                                aggTest.Save();
                                tempId1 = aggTest.Id.Value;
                                aggTest2.Save();
                                tempId2 = aggTest2.Id.Value;

                                throw new Exception();

                                scope.Complete();
                            }
                            catch
                            {
                            }
                        }
                        aggTest = new AggregateTest();
                        Assert.IsFalse(aggTest.LoadByPrimaryKey(tempId1));

                        aggTest = new AggregateTest();
                        Assert.IsFalse(aggTest.LoadByPrimaryKey(tempId2));
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail(ex.ToString());
                    }
                    break;
            }
        }

		[Test]
		public void TestTransactionWithoutComplete()
		{
			switch (aggTest.es.Connection.Name)
			{
				case "SQLStoredProcEnterprise":
				case "SQLDynamicEnterprise":
				case "ORACLEStoredProcEnterprise":
				case "ORACLEDynamicEnterprise":
				case "VistaDBDynamic":
					Assert.Ignore("Using esTransactionScope only");
					break;

				default:
					int tempId = 0;
					try
					{
						using (esTransactionScope scope = new esTransactionScope())
						{
							aggTest.Save();
							tempId = aggTest.Id.Value;
						}
						aggTest = new AggregateTest();
						Assert.IsFalse(aggTest.LoadByPrimaryKey(tempId));
					}
					finally
					{
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
	}
}
