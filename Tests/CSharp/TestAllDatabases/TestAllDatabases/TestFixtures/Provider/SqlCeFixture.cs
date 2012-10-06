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
	public class SqlCeFixture
	{
		[TestFixtureSetUp]
		public void Init()
		{
		}

		[SetUp]
		public void Init2()
		{
		}

        // SqlCe has no output parameters
        // Guids must be set in code rather than returned via
        // database-side newid()
        //[Test]
        //public void InsertGuidPrimaryKey()
        //{
        //    GuidTest dataTest = new GuidTest();
        //    dataTest.es.Connection.Name = "GuidTest";

        //    switch (dataTest.es.Connection.ProviderMetadataKey)
        //    {
        //        case "esSqlCe":
        //            try
        //            {
        //                dataTest.AddNew();
        //                dataTest.Save();
        //                Guid? tempKey = dataTest.GuidKey;

        //                dataTest = new GuidTest();
        //                Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey.Value));

        //                // Clean up
        //                dataTest.MarkAsDeleted();
        //                dataTest.Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                Assert.Fail(ex.ToString());
        //            }
        //            break;

        //        default:
        //            Assert.Ignore("SqlCe only");
        //            break;
        //    }
        //}

        [Test]
		public void SetGuidPrimaryKey()
		{
            GuidTest dataTest = new GuidTest();
            dataTest.es.Connection.Name = "GuidTest";

            switch (dataTest.es.Connection.ProviderMetadataKey)
            {
                case "esSqlCe":
                case "esSqlCe4":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        string testGuid = "b3883c65-ff94-47c4-8b0c-76896bedd45a";
                        dataTest = new GuidTest();
                        dataTest.es.Connection.Name = "GuidTest";
                        dataTest.GuidKey = new Guid(testGuid);
                        dataTest.Save();
                        Guid? tempKey = dataTest.GuidKey;
                        dataTest.MarkAsDeleted();
                        dataTest.Save();
                        Assert.AreEqual(testGuid, tempKey.Value.ToString());
                    }
                    break;

                default:
                    Assert.Ignore("SqlCe only");
                    break;
            }
		}

        [Test]
		public void GuidDynamicQuery()
		{
            GuidTestCollection dataTestColl = new GuidTestCollection();
            dataTestColl.es.Connection.Name = "GuidTest";
            GuidTest dataTest = new GuidTest();
            dataTest.es.Connection.Name = "GuidTest";

            switch (dataTest.es.Connection.ProviderMetadataKey)
            {
                case "esSqlCe":
                case "esSqlCe4":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        dataTest = new GuidTest();
                        dataTest.es.Connection.Name = "GuidTest";
                        dataTest.GuidKey = Guid.NewGuid();
                        dataTest.Save();
                        Guid tempKey = dataTest.GuidKey.Value;

                        dataTestColl = new GuidTestCollection();
                        dataTestColl.es.Connection.Name = "GuidTest";
                        dataTestColl.Query.Where(dataTestColl.Query.GuidKey == tempKey);
                        dataTestColl.Query.Load();
                        Assert.AreEqual(1, dataTestColl.Count);

                        dataTest = new GuidTest();
                        dataTest.es.Connection.Name = "GuidTest";
                        Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey));
                        dataTest.MarkAsDeleted();
                        dataTest.Save();
                    }
                    break;

                default:
                    Assert.Ignore("SqlCe only");
                    break;
            }
		}
	}
}
