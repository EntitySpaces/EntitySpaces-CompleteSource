//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

namespace Tests.Base
{
    [TestFixture]
    public class WhereDaisyChainingFixture
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
        public void SelectWithAlias()
        {
            aggTestColl.Query
                .Select(aggTestColl.Query.Salary.As("S2"),aggTestColl.Query.FirstName,aggTestColl.Query.FirstName.As("FN"))
                .OrderBy(aggTestColl.Query.Id.Ascending);

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(30, aggTestColl.Count);

            AggregateTestCollection aggControl = new AggregateTestCollection();
            aggControl.Query.OrderBy(aggControl.Query.Id.Ascending);
            aggControl.Query.Load();

            int i = 0;
            foreach (AggregateTest agg in aggTestColl)
            {
                if (aggControl[i].Salary.HasValue)
                {
                    Assert.AreEqual(aggControl[i].Salary.Value,
                        agg.GetColumn("S2"));
                }
                else
                {
                    Assert.AreEqual(null, agg.GetColumn("S2") as string);
                }
                Assert.AreEqual(aggControl[i].FirstName,
                    agg.GetColumn("FN") as string);
                i++;
            }
        }

        [Test]
        public void WhereMixMultiWithParenNested()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            collection.Query
                .Select(collection.Query.EmployeeID,collection.Query.Supervisor,collection.Query.Age)
                .Where(collection.Query.Age == 30)
                .Where(new esComparison(esParenthesis.Open))
                .Where(new esComparison(esParenthesis.Open));

            collection.Query.es.DefaultConjunction = esConjunction.Or;

            collection.Query
                .Where(collection.Query.EmployeeID == 1 & collection.Query.Supervisor.IsNull())
                .Where(collection.Query.EmployeeID == 2 & collection.Query.Supervisor == 1)
                .Where(new esComparison(esParenthesis.Close));

            collection.Query.es.DefaultConjunction = esConjunction.And;

            collection.Query.Where(new esComparison(esParenthesis.Open));

            collection.Query.es.DefaultConjunction = esConjunction.Or;

            collection.Query
                .Where(collection.Query.LastName == "Smith" & collection.Query.Supervisor.IsNull())
                .Where(collection.Query.LastName == "Jones" & collection.Query.Supervisor == 1);

            collection.Query.Where(new esComparison(esParenthesis.Close));
            collection.Query.Where(new esComparison(esParenthesis.Close));

            Assert.IsTrue(collection.Query.Load());
            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void WhereMixMultiAndOrDefaultOr()
        {
            aggTestColl.Query.es.DefaultConjunction = esConjunction.Or;
            aggTestColl.Query
                .Where(aggTestColl.Query
                .And(aggTestColl.Query.LastName.Like("%D%"),aggTestColl.Query.LastName.Like("%s%")), aggTestColl.Query
                .And(aggTestColl.Query.FirstName.Like("%J%"),aggTestColl.Query.FirstName.Like("%D%")));

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNested()
        {
            aggTestColl.Query
                .Where(aggTestColl.Query.LastName
                .Equal("Doe"), aggTestColl.Query.FirstName == "David",aggTestColl.Query
                .Or(aggTestColl.Query
                .And(aggTestColl.Query.DepartmentID
                .Equal(3),aggTestColl.Query.Age
                .Equal(16)),aggTestColl.Query
                .And(aggTestColl.Query.DepartmentID
                .Equal(4),aggTestColl.Query.Age
                .Equal(43))));

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNested2()
        {
            aggTestColl.Query
                .Where(aggTestColl.Query
                .Or(aggTestColl.Query.LastName
                .Like("%e%"),aggTestColl.Query.FirstName
                .Like("%a%")),aggTestColl.Query
                .And(aggTestColl.Query
                .Or(aggTestColl.Query.DepartmentID
                .Equal(3),aggTestColl.Query.Age
                .Equal(16)),aggTestColl.Query
                .Or(aggTestColl.Query.HireDate >= Convert.ToDateTime("2000-01-01"), aggTestColl.Query.Salary >= 15.00)));

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(7, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNestedOperators()
        {
            aggTestColl.Query
                .Where(aggTestColl.Query.LastName
                .Equal("Doe") & aggTestColl.Query.FirstName == "David" &
                ((
                    aggTestColl.Query.DepartmentID
                        .Equal(3) & aggTestColl.Query.Age
                        .Equal(16)) | (aggTestColl.Query.DepartmentID
                        .Equal(4) & aggTestColl.Query.Age
                        .Equal(43))));

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(1, aggTestColl.Count);
        }

        [Test]
        public void WhereMixMultiAndOrNestedOperators2()
        {
            aggTestColl.Query
                .Where((aggTestColl.Query.LastName
                .Like("%e%") | aggTestColl.Query.FirstName.Like("%a%")) &
                ((
                    aggTestColl.Query.DepartmentID
                    .Equal(3) | aggTestColl.Query.Age
                    .Equal(16)) & (aggTestColl.Query.HireDate >= Convert.ToDateTime("2000-01-01") | aggTestColl.Query.Salary >= 15.00)
                ));

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(7, aggTestColl.Count);
        }



        [Test]
        public void MultiWhereClausesExternal()
        {
            aggTestColl.Query
                .Select()
                .Where(aggTestColl.Query.IsActive.Equal(true))
                .Where(aggTestColl.Query.LastName.Equal("Doe"));

            Assert.IsTrue(aggTestColl.Query.Load());
            Assert.AreEqual(2, aggTestColl.Count);
        }

        [Test]
        public void PagingSimple()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            if (collection.es.Connection.Name == "SqlCe"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query
                            .OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
                            .OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query
                            .Select(collection.Query.Id,collection.Query.LastName,collection.Query.FirstName,collection.Query.IsActive)
                            .OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
                            .OrderBy(collection.Query.Id, esOrderByDirection.Ascending);

                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
        }

        [Test]
        public void PagingSimpleSelectAll()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            if (collection.es.Connection.Name == "SqlCe"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query
                            .OrderBy(all.Query.LastName, esOrderByDirection.Descending)
                            .OrderBy(all.Query.Id, esOrderByDirection.Ascending);

                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query
                            .OrderBy(collection.Query.LastName, esOrderByDirection.Descending)
                            .OrderBy(collection.Query.Id, esOrderByDirection.Ascending);

                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
        }

        [Test]
        public void PagingWithWhere()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            if (aggTestColl.es.Connection.Name == "SqlCe"
                || aggTestColl.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query
                            .OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
                            .OrderBy(all.Query.Id, esOrderByDirection.Ascending)
                            .Where(all.Query.IsActive == true);

                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query
                            .Select(collection.Query.Id,collection.Query.LastName,collection.Query.FirstName,collection.Query.IsActive)
                            .OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
                            .OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
                            .Where(collection.Query.IsActive == true);

                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
        }

        [Test]
        public void PagingWithTop()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            if (collection.es.Connection.Name == "SqlCe"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || collection.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not supported");
                        break;
                    default:
                        AggregateTestCollection all = new AggregateTestCollection();

                        all.Query.es.Top = 20;
                        all.Query
                            .OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
                            .OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                        all.Query.Load();

                        collection = new AggregateTestCollection();

                        collection.Query.es.Top = 20;
                        collection.Query
                            .Select(collection.Query.Id,collection.Query.LastName,collection.Query.FirstName,collection.Query.IsActive)
                            .OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
                            .OrderBy(collection.Query.Id, esOrderByDirection.Ascending);
                        collection.Query.es.PageNumber = 1;
                        collection.Query.es.PageSize = 8;

                        Assert.IsTrue(collection.Query.Load(), "Load 1");
                        Assert.AreEqual(8, collection.Count, "Count 1");

                        AggregateTest all0 = (AggregateTest)all[0];
                        AggregateTest collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                        collection.Query.es.PageNumber = 2;
                        Assert.IsTrue(collection.Query.Load(), "Load 2");
                        Assert.AreEqual(8, collection.Count, "Count 2");

                        all0 = (AggregateTest)all[8];
                        collection0 = (AggregateTest)collection[0];
                        Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                        break;
                }
            }
        }

        [Test]
        public void PagingWithDistinct()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.Ignore("Paging Not supported");
                    break;

                default:
                    AggregateTestCollection all = new AggregateTestCollection();

                    all.Query.es.Distinct = true;
                    all.Query
                        .OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
                        .OrderBy(all.Query.Id, esOrderByDirection.Ascending);
                    all.Query.Load();

                    collection = new AggregateTestCollection();

                    collection.Query.es.Distinct = true;
                    collection.Query
                        .Select(collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive)
                        .OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
                        .OrderBy(collection.Query.Id, esOrderByDirection.Ascending);
                    collection.Query.es.PageNumber = 1;
                    collection.Query.es.PageSize = 8;

                    Assert.IsTrue(collection.Query.Load(), "Load 1");
                    Assert.AreEqual(8, collection.Count, "Count 1");

                    AggregateTest all0 = (AggregateTest)all[0];
                    AggregateTest collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1");

                    collection.Query.es.PageNumber = 2;
                    Assert.IsTrue(collection.Query.Load(), "Load 2");
                    Assert.AreEqual(8, collection.Count, "Count 2");

                    all0 = (AggregateTest)all[8];
                    collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2");

                    break;
            }
        }

        [Test]
        public void ContainsNear()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "Acme NEAR Company";

                    collection.Query
                        .Select(collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.As("CName"), collection.Query.Notes)
                        .Where(collection.Query.CustomerName.Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(2, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainsWildCard()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "\"2*\"";

                    collection.Query
                        .Select(collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.As("CName"), collection.Query.Notes)
                        .Where(collection.Query.CustomerName.Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(9, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainsCaseInsensitive()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                            "acme NEAR company";

                    collection.Query.Where(
                        collection.Query.CustomerName.Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(2, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainsMultiTerms()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "Acme NEAR Company";
                    string addressTerm =
                        "Road AND (\"St*\" OR \"Ave*\")";

                    collection.Query
                        .Select(collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.As("CName"), collection.Query.Notes)
                        .Where(collection.Query.CustomerName.Contains(nameTerm))
                        .Where(collection.Query.Notes.Contains(addressTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(1, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void ContainswithSubOperator()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    if (collection.es.Connection.ProviderMetadataKey == "esSqlAzure")
                    {
                        Assert.Ignore("Not supported");
                        break;
                    }

                    string nameTerm =
                        "Acme NEAR Company";

                    // SubOperators are ignored for CONTAINS.
                    // The search conditions belong in the search term parameter
                    collection.Query.Where(
                        collection.Query.CustomerName.ToLower().Contains(nameTerm));

                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual(2, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void PagingWithGroupBy()
        {
            AggregateTestCollection collection = new AggregateTestCollection();

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.Ignore("Paging Not supported");
                    break;

                default:
                    AggregateTestCollection all = new AggregateTestCollection();

                    all.Query
                        .Select(all.Query.LastName, all.Query.Salary.Avg())
                        .Where(all.Query.IsActive == true)
                        .GroupBy(all.Query.LastName)
                        .OrderBy(all.Query.LastName, esOrderByDirection.Ascending);
                    all.Query.Load();

                    collection = new AggregateTestCollection();

                    collection.Query
                        .Select(collection.Query.LastName, collection.Query.Salary.Avg())
                        .Where(collection.Query.IsActive == true)
                        .GroupBy(collection.Query.LastName)
                        .OrderBy(collection.Query.LastName, esOrderByDirection.Ascending);
                    collection.Query.es.PageNumber = 1;
                    collection.Query.es.PageSize = 8;

                    Assert.IsTrue(collection.Query.Load(), "Load 1");
                    Assert.AreEqual(8, collection.Count, "Count 1");

                    AggregateTest all0 = (AggregateTest)all[0];
                    AggregateTest collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 1");

                    collection.Query.es.PageNumber = 2;
                    Assert.IsTrue(collection.Query.Load(), "Load 2");
                    Assert.AreEqual(2, collection.Count, "Count 2");

                    all0 = (AggregateTest)all[8];
                    collection0 = (AggregateTest)collection[0];
                    Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 2");

                    break;
            }
        }
    }
}
