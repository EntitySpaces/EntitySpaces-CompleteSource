//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.DynamicQuery;
using EntitySpaces.Interfaces;
using EntitySpaces.Core;

namespace Tests.Base
{
	[TestFixture]
	public class MiscellaneousFixture
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
		public void TestMarkAllColumnsAsDirtyAndModified()
		{
            aggTest.Query.es.Top = 1;
            aggTest.Query.Load();
            Assert.IsTrue(aggTest.AllColumnsAreNotDirty());
            aggTest.MarkAllColumnsAsDirty(esDataRowState.Modified);
            Assert.IsTrue(aggTest.AllColumnsAreDirty(esDataRowState.Modified));
        }

		[Test]
		public void TestMarkAllColumnsAsDirtyAndAdded()
		{
            aggTest.Query.es.Top = 1;
            aggTest.Query.Load();
            Assert.IsTrue(aggTest.AllColumnsAreNotDirty());
            aggTest.MarkAllColumnsAsDirty(esDataRowState.Added);
            Assert.IsTrue(aggTest.AllColumnsAreDirty(esDataRowState.Added));
        }

		[Test]
		public void TestUtilityClass()
		{
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (aggTestColl.es.Connection.SqlAccessType != esSqlAccessType.StoredProcedure)
                    {
                        Assert.Ignore("Stored procedure test only.");
                    }

                    aggTestColl.LoadAll();
                    AggregateTest entity = (AggregateTest)aggTestColl[0];
                    Utility util = new Utility();

                    string entityName = aggTestColl.GetFullName(entity.Id.Value);
                    string name = util.GetFullName(entity.Id.Value);
                    Assert.AreEqual(entityName, name);
                    break;

                default:
                    Assert.Ignore("Tested on SQL Server only");
                    break;
            }
		}

        [Test]
        public void TestUtilityClassReturnNullExecuteScalar()
        {
            esUtility util = new esUtility();
            int? age = util.ExecuteScalar<int?>(esQueryType.Text, "SELECT Age FROM AggregateTest WHERE Age = 5000");
            Assert.AreEqual(age, null);  // we want "null" not DBNull.Value here
        }

        [Test]
        public void TestEsUtilityClass()
        {
            switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (aggTestColl.es.Connection.SqlAccessType != esSqlAccessType.StoredProcedure)
                    {
                        Assert.Ignore("Stored procedure test only.");
                    }

                    aggTestColl.LoadAll();
                    AggregateTest entity = (AggregateTest)aggTestColl[0];
                    string entityName = aggTestColl.GetFullName(entity.Id.Value);

                    EntitySpaces.Core.esUtility util =
                        new EntitySpaces.Core.esUtility();

                    util.es.Connection.Catalog = "AggregateDb";
                    util.es.Connection.Schema = "dbo";

                    EntitySpaces.Interfaces.esParameters parms =
                        new EntitySpaces.Interfaces.esParameters();

                    parms.Add("ID", entity.Id.Value);
                    parms.Add("FullName",
                        EntitySpaces.Interfaces.esParameterDirection.Output,
                        System.Data.DbType.String, 40);

                    util.ExecuteNonQuery(
                        EntitySpaces.DynamicQuery.esQueryType.StoredProcedure,
                        "proc_GetEmployeeFullName", parms);

                    string name = parms["FullName"].Value as string;
                    Assert.AreEqual(entityName, name);
                    break;

                default:
                    Assert.Ignore("Tested on SQL Server only");
                    break;
            }
        }

        [Test]
        public void TestQueryExecuteScalar()
        {
            aggTestQuery.es.CountAll = true;
            int count = Convert.ToInt32(aggTestQuery.ExecuteScalar());

            Assert.AreEqual(30, count);
        }

        [Test]
        public void TestQueryExecuteReader()
        {
            aggTestQuery.Select(aggTestQuery.FirstName, aggTestQuery.LastName);
            aggTestQuery.Where(aggTestQuery.LastName.Like("%a%"));

            int count = 0;
            using (IDataReader reader = aggTestQuery.ExecuteReader())
            {
                while (reader.Read())
                {
                    string s = reader.GetString(0);
                    s = reader.GetString(1);
                    count++;
                }
            }

            Assert.AreEqual(8, count);
        }
    }
}
