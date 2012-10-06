//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

using BusinessObjects;

namespace Tests.Base
{
    [TestFixture]
    public class SetOperatorFixture
    {
        [Test]
        public void SimpleUnion()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            EmployeeQuery eq1 = new EmployeeQuery("eq1");
            EmployeeQuery eq2 = new EmployeeQuery("eq2");

            // This leaves out the record with Age 30
            eq1.Where(eq1.Age < 30);
            eq1.Union(eq2);
            eq2.Where(eq2.Age > 30);

            Assert.IsTrue(collection.Load(eq1));
            Assert.AreEqual(4, collection.Count);
        }

        [Test]
        public void SimpleIntersect()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            EmployeeQuery eq1 = new EmployeeQuery("eq1");
            EmployeeQuery eq2 = new EmployeeQuery("eq2");

            // Only includes rows with both "n" and"a"
            eq1.Where(eq1.FirstName.Like("%n%"));
            eq1.Intersect(eq2);
            eq2.Where(eq2.FirstName.Like("%a%"));

            Assert.IsTrue(collection.Load(eq1));
            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void SimpleExcept()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            EmployeeQuery eq1 = new EmployeeQuery("eq1");
            EmployeeQuery eq2 = new EmployeeQuery("eq2");

            // Includes all "J"s except "Jim"
            eq1.Where(eq1.FirstName.Like("%J%"));
            eq1.Except(eq2);
            eq2.Where(eq2.FirstName == "Jim");

            Assert.IsTrue(collection.Load(eq1));
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void SingleUnion()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.SelectAllExcept(cq1.Notes);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.SelectAllExcept(cq2.Notes);
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")));

            // Combine 2005 and 2006 in one result set
            cq1.Union(cq2);

            //string lq = cq1.Parse();

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(49, coll.Count);
        }

        [Test]
        public void SingleUnionWithOrderBy()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.Select(cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.Select(cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName);
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")));

            // Combine 2005 and 2006 in one result set
            cq1.Union(cq2);
            cq1.OrderBy(cq1.CustomerName.Ascending);

            //string lq = cq1.Parse();

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(49, coll.Count);
        }

        [Test]
        public void SingleUnionWithJoin()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            EmployeeQuery eq1 = new EmployeeQuery("e1");

            cq1.Select(cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName, eq1.LastName);
            cq1.InnerJoin(eq1).On(cq1.Manager == eq1.EmployeeID);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            EmployeeQuery eq2 = new EmployeeQuery("e2");

            cq2.Select(cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName, eq2.LastName);
            cq2.InnerJoin(eq2).On(cq2.Manager == eq2.EmployeeID);
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")));

            cq1.Union(cq2);
            cq1.OrderBy(cq1.CustomerID.Ascending, cq1.CustomerSub.Ascending);

            //string lq = cq1.Parse();

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(49, coll.Count);
            Assert.AreEqual("Smith", coll[0].GetColumn("LastName"));
        }

        [Test]
        public void SingleUnionWithSubSelect()
        {
            OrderCollection coll = new OrderCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                    Assert.Ignore("Scalar SubSelects are not supported in SqlCe.");
                    break;

                default:
                    OrderQuery oq1 = new OrderQuery("o1");
                    OrderItemQuery oiq1 = new OrderItemQuery("oi1");

                    oq1.Select
                    (
                        oq1.OrderID,
                        oq1.OrderDate,
                        oiq1.Select(
                            oiq1.UnitPrice.Max())
                            .Where(oq1.OrderID == oiq1.OrderID).As("MaxUnitPrice")
                    );
                    oq1.Where(oq1.OrderDate.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

                    OrderQuery oq2 = new OrderQuery("o2");
                    OrderItemQuery oiq2 = new OrderItemQuery("oi2");

                    oq2.Select
                    (
                        oq2.OrderID,
                        oq2.OrderDate,
                        oiq2.Select(
                            oiq2.UnitPrice.Max())
                            .Where(oq2.OrderID == oiq2.OrderID).As("MaxUnitPrice")
                    );
                    oq2.Where(oq2.OrderDate.Between(Convert.ToDateTime("2004-01-01"), Convert.ToDateTime("2004-12-31")));

                    oq1.Union(oq2);
                    oq1.OrderBy(oq1.OrderID.Ascending);

                    //string lq = cq1.Parse();

                    Assert.IsTrue(coll.Load(oq1));
                    Assert.AreEqual(6, coll.Count);
                    Assert.AreEqual(3m, coll[0].GetColumn("MaxUnitPrice"));
                    break;
            }
        }

        [Test]
        public void MultipleUnion()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.SelectAllExcept(cq1.Notes);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.SelectAllExcept(cq2.Notes);
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")));

            CustomerQuery cq3 = new CustomerQuery("c3");
            cq3.SelectAllExcept(cq3.Notes);
            cq3.Where(cq3.DateAdded.Between(Convert.ToDateTime("2000-01-01"), Convert.ToDateTime("2000-12-31")));

            // Combine 2000, 2005, and 2006
            cq1.Union(cq2);
            cq1.Union(cq3);

            //string lq = cq1.Parse();

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(51, coll.Count);

        }

        [Test]
        public void SingleUnionAll()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")));

            // Combine 2005 and 2006 in one result set
            cq1.UnionAll(cq2);

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(49, coll.Count);
        }

        [Test]
        public void SingleUnionWithOverlap()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.SelectAllExcept(cq1.Notes);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.SelectAllExcept(cq2.Notes);
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-12-31"), Convert.ToDateTime("2006-12-31")));

            // Combine 2005 and 2006 in one result set with the 2 duplicate rows eliminated
            cq1.Union(cq2);

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(49, coll.Count);
        }

        [Test]
        public void SingleUnionAllWithOverlap()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-12-31"), Convert.ToDateTime("2006-12-31")));

            // Combine 2005 and 2006 in one result set with the 2 duplicate rows retained
            cq1.UnionAll(cq2);

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(51, coll.Count);
        }

        [Test]
        public void SingleExcept()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.SelectAllExcept(cq1.Notes);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2006-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.SelectAllExcept(cq2.Notes);
            cq2.Where(cq2.DateAdded == Convert.ToDateTime("2005-12-31"));

            // All 2005 and 2006 except the 2 for 2005-12-31
            cq1.Except(cq2);

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(47, coll.Count);
        }

        [Test]
        public void SingleExceptWithNoOverlap()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.SelectAllExcept(cq1.Notes);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2006-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.SelectAllExcept(cq2.Notes);
            cq2.Where(cq2.DateAdded == Convert.ToDateTime("1900-12-31"));

            // All 2005 and 2006
            cq1.Except(cq2);

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(49, coll.Count);
        }

        [Test]
        public void SingleIntersect()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.SelectAllExcept(cq1.Notes);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.SelectAllExcept(cq2.Notes);
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-12-31"), Convert.ToDateTime("2006-12-31")));

            // Only the 2 rows for 2005-12-31
            cq1.Intersect(cq2);

            Assert.IsTrue(coll.Load(cq1));
            Assert.AreEqual(2, coll.Count);
        }

        [Test]
        public void SingleIntersectWithNoOverlap()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            CustomerQuery cq1 = new CustomerQuery("c1");
            cq1.SelectAllExcept(cq1.Notes);
            cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

            CustomerQuery cq2 = new CustomerQuery("c2");
            cq2.SelectAllExcept(cq2.Notes);
            cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")));

            // There is no intersection for 2005 and 2006
            cq1.Intersect(cq2);

            Assert.IsFalse(coll.Load(cq1));
            Assert.AreEqual(0, coll.Count);
        }

        //[Test]
        //public void MixedSetOperatorsUnionAllWithParen()
        //{
        //    CustomerCollection coll = new CustomerCollection();
        //    coll.es.Connection.Name = "ForeignKeyTest";

        //    CustomerQuery cq1 = new CustomerQuery("c1");
        //    cq1.Select(cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName);
        //    cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

        //    CustomerQuery cq2 = new CustomerQuery("c2");
        //    cq2.Select(cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName);
        //    cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

        //    CustomerQuery cq3 = new CustomerQuery("c3");
        //    cq3.Select(cq3.CustomerID, cq3.CustomerSub, cq3.CustomerName);
        //    cq3.Where(cq3.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-01-01")));

        //    // Combine with duplicates, then eliminate the duplicates and the 2 for 2005-01-01
        //    cq1.Where(new esComparison(esParenthesis.Open));
        //    cq1.UnionAll(cq2);
        //    cq1.Where(new esComparison(esParenthesis.Close));
        //    cq1.Except(cq3);

        //    //string lq = cq1.Parse();

        //    Assert.IsTrue(coll.Load(cq1));
        //    Assert.AreEqual(2, coll.Count);

        //}

        //[Test]
        //public void MixedSetOperatorsExceptWithParen()
        //{
        //    CustomerCollection coll = new CustomerCollection();
        //    coll.es.Connection.Name = "ForeignKeyTest";

        //    CustomerQuery cq1 = new CustomerQuery("c1");
        //    cq1.Select(cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName);
        //    cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

        //    CustomerQuery cq2 = new CustomerQuery("c2");
        //    cq2.Select(cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName);
        //    cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")));

        //    CustomerQuery cq3 = new CustomerQuery("c3");
        //    cq3.Select(cq3.CustomerID, cq3.CustomerSub, cq3.CustomerName);
        //    cq3.Where(cq3.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-01-01")));

        //    // Eliminate the 1 for 2005-01-01, then combine with duplicates
        //    cq1.UnionAll(cq2);
        //    cq1.Where(new esComparison(esParenthesis.Open));
        //    cq1.Except(cq3);
        //    cq1.Where(new esComparison(esParenthesis.Close));

        //    //string lq = cq1.Parse();

        //    Assert.IsTrue(coll.Load(cq1));
        //    Assert.AreEqual(5, coll.Count);

        //}

    }
}
