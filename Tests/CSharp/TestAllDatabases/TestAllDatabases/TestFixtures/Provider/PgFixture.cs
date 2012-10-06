//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;
using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class PgFixture
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
		public void PgDataTypeTest()
		{
            DateTime testTime = Convert.ToDateTime("0001-01-01 01:23:45.678");
            PgDataTypes datatypeTest = new PgDataTypes();

            switch (datatypeTest.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.Npgsql2Provider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        datatypeTest.TimeType = testTime;
                        datatypeTest.Save();

                        long? tempKey = datatypeTest.Id;

                        datatypeTest = new PgDataTypes();
                        Assert.IsTrue(datatypeTest.LoadByPrimaryKey(tempKey.Value));
                        Assert.IsTrue(datatypeTest.TimeType.HasValue);
                        Assert.AreEqual(datatypeTest.TimeType.Value, testTime);
                        datatypeTest.MarkAsDeleted();
                        datatypeTest.Save();
                    }
					break;

				default:
					Assert.Ignore("PostgreSQL only");
					break;
			}
		}
    }
}
