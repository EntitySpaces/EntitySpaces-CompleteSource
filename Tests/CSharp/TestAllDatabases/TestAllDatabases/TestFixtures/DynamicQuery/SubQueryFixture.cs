//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class SubQueryFixture
	{
        #region Select SubQueries

        [Test]
        public void SelectAllExceptOne()
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            coll.Query.SelectAllExcept(coll.Query.EmployeeID);
            coll.Query.OrderBy(coll.Query.LastName.Descending);
            coll.Query.OrderBy(coll.Query.FirstName.Descending);
            coll.Query.Load();

            // Confirm that EmployeeID is null,
            // and all other columns are not.
            Assert.AreEqual(5, coll.Count);
            Assert.IsTrue(coll[0].GetColumn(EmployeeMetadata.ColumnNames.EmployeeID) == null);
            Assert.AreEqual("John", coll[0].GetColumn(EmployeeMetadata.ColumnNames.FirstName));
            Assert.AreEqual("Smith", coll[0].GetColumn(EmployeeMetadata.ColumnNames.LastName));
            Assert.AreEqual(30, coll[0].GetColumn(EmployeeMetadata.ColumnNames.Age));
            Assert.IsTrue(coll[0].GetColumn(EmployeeMetadata.ColumnNames.Supervisor) == null);
        }

        [Test]
        public void SelectAllExceptTwo()
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            coll.Query.SelectAllExcept(coll.Query.EmployeeID, coll.Query.FirstName);
            coll.Query.OrderBy(coll.Query.LastName.Descending);
            coll.Query.OrderBy(coll.Query.FirstName.Descending);
            coll.Query.Load();

            // Confirm that EmployeeID and LastName are null,
            // and all other columns are not.
            Assert.AreEqual(5, coll.Count);
            Assert.IsTrue(coll[0].GetColumn(EmployeeMetadata.ColumnNames.EmployeeID) == null);
            Assert.IsTrue(coll[0].GetColumn(EmployeeMetadata.ColumnNames.FirstName) == null);
            Assert.AreEqual("Smith", coll[0].GetColumn(EmployeeMetadata.ColumnNames.LastName));
            Assert.AreEqual(30, coll[0].GetColumn(EmployeeMetadata.ColumnNames.Age));
            Assert.IsTrue(coll[0].GetColumn(EmployeeMetadata.ColumnNames.Supervisor) == null);
        }

        [Test]
        public void SelectStatement()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            OrderQuery orders = new OrderQuery("o");
            OrderItemQuery details = new OrderItemQuery("oi");

            // A SubQuery in the Select clause must return a single value.
            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    orders.Select
                    (
                        orders.OrderID,
                        orders.OrderDate,
                        details.Select(
                            details.UnitPrice.Max())
                            .Where(orders.OrderID == details.OrderID).As("MaxUnitPrice")
                    );
                    orders.OrderBy(orders.OrderID.Ascending);
                    break;
            }

            Assert.IsTrue(collection.Load(orders));
            Assert.AreEqual(8, collection.Count);
            Assert.AreEqual(3m, collection[0].GetColumn("MaxUnitPrice"));
        }

        [Test]
        public void SelectAllPlusSubQuery()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            OrderQuery orders = new OrderQuery("o");
            OrderItemQuery details = new OrderItemQuery("oi");

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    orders.Select
                    (
                        orders,
                        details.Select(
                            details.UnitPrice.Max())
                            .Where(orders.OrderID == details.OrderID).As("MaxUnitPrice")
                    );
                    orders.OrderBy(orders.OrderID.Ascending);

                    break;
            }

            Assert.IsTrue(collection.Load(orders));
            Assert.AreEqual(8, collection.Count);
            Assert.AreEqual(3m, collection[0].GetColumn("MaxUnitPrice"));

            string all = collection.Query.es.LastQuery.Substring(7, 3);
            Assert.AreEqual("o.*", all);
        }

        [Test]
        public void SubQueryWithBetween()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    DateTime fromDate = new DateTime(2005, 1, 1);
                    DateTime toDate = new DateTime(2005, 8, 31);
                    DateTime startDate = new DateTime(2000, 1, 1);
                    DateTime endDate = new DateTime(2000, 12, 31);

                    CustomerQuery cq = new CustomerQuery("c");
                    OrderQuery oq = new OrderQuery("o");
                    OrderQuery oqSub = new OrderQuery("oSub");

                    oqSub.Select(oqSub.OrderDate.Max());
                    oqSub.Where(oqSub.CustID == cq.CustomerID &
                        oqSub.CustSub == cq.CustomerSub);

                    // These work
                    //oqSub.Where(oqSub.OrderDate >= fromDate);
                    //oqSub.Where(oqSub.OrderDate <= toDate);

                    // Gets Null Reference exception on Load()?
                    oqSub.Where(oqSub.OrderDate.Between(fromDate, toDate));

                    cq.es.Distinct = true;
                    cq.Select(cq.CustomerID, cq.CustomerSub, cq.DateAdded, oqSub.As("MaxOrderDate"));
                    cq.InnerJoin(oq).On(cq.CustomerID == oq.CustID &
                        cq.CustomerSub == oq.CustSub);
                    cq.Where(cq.DateAdded.Between(startDate, endDate));

                    Assert.IsTrue(coll.Load(cq));
                    Assert.AreEqual(1, coll.Count);
                    break;
            }
        }

        [Test]
        public void SubQueryWithGT_LT()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(coll.es.Connection);

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    DateTime fromDate = new DateTime(2005, 1, 1);
                    DateTime toDate = new DateTime(2005, 8, 31);
                    DateTime startDate = new DateTime(2000, 1, 1);
                    DateTime endDate = new DateTime(2000, 12, 31);

                    CustomerQuery cq = new CustomerQuery("c");
                    OrderQuery oq = new OrderQuery("o");
                    OrderQuery oqSub = new OrderQuery("oSub");

                    oqSub.Select(oqSub.OrderDate.Max());
                    oqSub.Where(oqSub.CustID == cq.CustomerID &
                        oqSub.CustSub == cq.CustomerSub);

                    // These work in SubQuery
                    oqSub.Where(oqSub.OrderDate >= fromDate);
                    oqSub.Where(oqSub.OrderDate <= toDate);

                    // If you comment the above 2 GT/LT lines
                    // and un-comment the Between line below
                    // it gets Null Reference exception on Load()
                    //oqSub.Where(oqSub.OrderDate.Between(fromDate, toDate));

                    cq.es.Distinct = true;
                    cq.Select(cq.CustomerID, cq.CustomerSub, cq.DateAdded, oqSub.As("MaxOrderDate"));
                    cq.InnerJoin(oq).On(cq.CustomerID == oq.CustID &
                        cq.CustomerSub == oq.CustSub);
                    // This works in outer query
                    cq.Where(cq.DateAdded.Between(startDate, endDate));

                    Assert.IsTrue(coll.Load(cq));
                    Assert.AreEqual(1, coll.Count);
                    break;
            }
        }

        #endregion

        #region From SubQueries

        [Test]
        public void FromClause()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.SqlServerCeProvider":
                //    Assert.Ignore("Not supported.");
                //    break;
                default:
                    OrderQuery oq = new OrderQuery("o");
                    OrderItemQuery oiq = new OrderItemQuery("oi");

                    // The inner Select contains an aggregate,
                    // which requires a GroupBy for each non-aggregate in the Select.
                    // The outer Select includes the aggregate from the inner Select,
                    // plus columns where no GroupBy was desired.
                    oq.Select(oq.CustID, oq.OrderDate, oiq.UnitPrice);
                    oq.From
                        (
                            oiq.Select(oiq.OrderID, oiq.UnitPrice.Sum()).GroupBy(oiq.OrderID)
                        ).As("sub");
                    oq.InnerJoin(oq).On(oq.OrderID == oiq.OrderID);
                    oq.OrderBy(oq.OrderID.Ascending);

                    Assert.IsTrue(collection.Load(oq));
                    Assert.AreEqual(5, collection.Count);
                    Decimal up = Convert.ToDecimal(collection[0].GetColumn("UnitPrice"));
                    Assert.AreEqual(5.11m, Math.Round(up, 2));

                    break;
            }
        }

        [Test]
        public void FromClauseWithAlias()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            OrderQuery oq = new OrderQuery("o");
            OrderItemQuery oiq = new OrderItemQuery("oi");

            // Calculate total price per order

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.SqlServerCeProvider":
                //    Assert.Ignore("Not supported.");
                //    break;
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                    oq.Select(oq.CustID, oq.OrderDate, "<sub.\"OrderTotal\">");
                    break;
                default:
                    oq.Select(oq.CustID, oq.OrderDate, "<sub.OrderTotal>");
                    break;
            }

            oq.From
                (
                    oiq.Select(oiq.OrderID,
                        (oiq.UnitPrice * oiq.Quantity).Sum().As("OrderTotal"))
                        .GroupBy(oiq.OrderID)
                ).As("sub");
            oq.InnerJoin(oq).On(oq.OrderID == oiq.OrderID);
            oq.OrderBy(oq.OrderID.Ascending);

            Assert.IsTrue(collection.Load(oq));
            Assert.AreEqual(5, collection.Count);
            Assert.AreEqual(13.11m, collection[0].GetColumn("OrderTotal"));
        }

        [Test]
        public void FromClauseUsingInstance()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            // Select an arbitrary number of rows from
            // any starting row.
            int startRow = 4;
            int numberOfRows = 7;

            // OrderItem SubQuery 1
            // Get all rows through start + number, ascending
            OrderItemQuery oisq = new OrderItemQuery("ois");
            oisq.es.Top = startRow + numberOfRows - 1;
            oisq.Select(oisq.OrderID, oisq.ProductID, oisq.Quantity);
            oisq.OrderBy(oisq.OrderID.Ascending,
                oisq.ProductID.Ascending);

            // OrderItem SubQuery 2
            // Get just the number of rows, descending
            OrderItemQuery oisq2 = new OrderItemQuery("ois2");
            oisq2.es.Top = numberOfRows;
            oisq2.From(oisq).As("sub1");

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.SqlServerCeProvider":
                //    Assert.Ignore("Not supported.");
                //    break;
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                    oisq2.OrderBy("<sub1.\"OrderID\">", esOrderByDirection.Descending);
                    oisq2.OrderBy("<sub1.\"ProductID\">", esOrderByDirection.Descending);
                    break;
                case "EntitySpaces.OracleClientProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    oisq2.OrderBy("<sub1.OrderID>", esOrderByDirection.Descending);
                    oisq2.OrderBy("<sub1.ProductID>", esOrderByDirection.Descending);
                    break;
            }

            // Put it back in ascending order
            OrderQuery oq = new OrderQuery("o");
            oq.From(oisq2).As("sub2");

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                    oq.OrderBy("<sub2.\"OrderID\">", esOrderByDirection.Ascending);
                    oq.OrderBy("<sub2.\"ProductID\">", esOrderByDirection.Ascending);
                    break;
                default:
                    oq.OrderBy("<sub2.OrderID>", esOrderByDirection.Ascending);
                    oq.OrderBy("<sub2.ProductID>", esOrderByDirection.Ascending);
                    break;
            }

            Assert.IsTrue(collection.Load(oq));
            Assert.AreEqual(7, collection.Count);
            Assert.AreEqual(10, collection[0].GetColumn("Quantity"));
        }

        #endregion

        #region Where SubQueries

        [Test]
        public void WhereNotIn()
        {
            TerritoryCollection collection = new TerritoryCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            // SubQuery of Territories that Employee 1 is assigned to.
            EmployeeTerritoryQuery etq = new EmployeeTerritoryQuery("et");
            etq.Select(etq.TerrID);
            etq.Where(etq.EmpID == 1);

            // Territories that Employee 1 is not assigned to.
            TerritoryQuery tq = new TerritoryQuery("t");
            tq.Select(tq.Description);
            tq.Where(tq.TerritoryID.NotIn(etq));
            tq.OrderBy(tq.TerritoryID.Ascending);

            Assert.IsTrue(collection.Load(tq));
            Assert.AreEqual(2, collection.Count);
            Assert.AreEqual("West", collection[0].GetColumn(
                TerritoryMetadata.ColumnNames.Description));
        }

        [Test]
        public void WhereExists()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            // SubQuery of Employees with a null Supervisor column.
            EmployeeQuery sq = new EmployeeQuery("s");
            sq.es.Distinct = true;
            sq.Select(sq.EmployeeID);
            sq.Where(sq.Supervisor.IsNull());

            // If even one employee has a null supervisor,
            // i.e., the above query has a result set,
            // then run a list of all employees.
            EmployeeQuery eq = new EmployeeQuery("e");
            eq.Select(eq.EmployeeID, eq.Supervisor);
            eq.Where(eq.Exists(sq));

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(5, collection.Count);
        }

        [Test]
        public void WhereExistsFalse()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            // EmployeeID is required and will never be NULL
            EmployeeQuery sq = new EmployeeQuery("s");
            sq.es.Distinct = true;
            sq.Select(sq.EmployeeID);
            sq.Where(sq.EmployeeID.IsNull());

            // This should produce no results as the
            // inner query does not exist.
            EmployeeQuery eq = new EmployeeQuery("e");
            eq.Select(eq.EmployeeID, eq.Supervisor);
            eq.Where(eq.Exists(sq));

            Assert.IsFalse(collection.Load(eq));
        }

        [Test]
        public void WhereExistsANDed()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq1 = new EmployeeQuery("e1");
            EmployeeQuery eq2 = new EmployeeQuery("e2");

            eq1.Where(eq1.EmployeeID > 2, eq1.Exists(eq2)); 

            Assert.IsTrue(collection.Load(eq1));
            Assert.AreEqual(3, collection.Count);

            string lq = collection.Query.es.LastQuery;
            string[] one = lq.Split('1');
            Assert.AreEqual(4, one.GetLength(0));
            string[] two = lq.Split('2');
            Assert.AreEqual(2, two.GetLength(0));
        }

        [Test]
        public void WhereExistsANDedTogether()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq1 = new EmployeeQuery("e1");
            EmployeeQuery eq2 = new EmployeeQuery("e2");
            EmployeeQuery eq3 = new EmployeeQuery("e3");

            eq1.Where(eq1.Exists(eq2), eq1.Exists(eq3));

            Assert.IsTrue(collection.Load(eq1));
            Assert.AreEqual(5, collection.Count);

            string lq = collection.Query.es.LastQuery;
            string[] one = lq.Split('1');
            Assert.AreEqual(2, one.GetLength(0));
            string[] two = lq.Split('2');
            Assert.AreEqual(2, two.GetLength(0));
            string[] three = lq.Split('3');
            Assert.AreEqual(2, three.GetLength(0));
        }

        [Test]
        public void WhereInANDedTogether()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq1 = new EmployeeQuery("e1");
            EmployeeQuery eq2 = new EmployeeQuery("e2");
            EmployeeQuery eq3 = new EmployeeQuery("e3");

            eq2.Select(eq2.EmployeeID);
            eq3.Select(eq3.EmployeeID);

            eq1.Where(eq1.EmployeeID.In(eq2), eq1.EmployeeID.In(eq3));

            Assert.IsTrue(collection.Load(eq1));
            Assert.AreEqual(5, collection.Count);

            string lq = collection.Query.es.LastQuery;
            string[] one = lq.Split('1');
            Assert.AreEqual(4, one.GetLength(0));
            string[] two = lq.Split('2');
            Assert.AreEqual(3, two.GetLength(0));
            string[] three = lq.Split('3');
            Assert.AreEqual(3, three.GetLength(0));
        }

        [Test]
        public void WhereInANDedTogetherOperator()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq1 = new EmployeeQuery("e1");
            EmployeeQuery eq2 = new EmployeeQuery("e2");
            EmployeeQuery eq3 = new EmployeeQuery("e3");

            eq2.Select(eq2.EmployeeID);
            eq3.Select(eq3.EmployeeID);

            eq1.Where(eq1.EmployeeID.In(eq2) & eq1.EmployeeID.In(eq3));

            Assert.IsTrue(collection.Load(eq1));
            Assert.AreEqual(5, collection.Count);

            string lq = collection.Query.es.LastQuery;
            string[] one = lq.Split('1');
            Assert.AreEqual(4, one.GetLength(0));
            string[] two = lq.Split('2');
            Assert.AreEqual(3, two.GetLength(0));
            string[] three = lq.Split('3');
            Assert.AreEqual(3, three.GetLength(0));
        }

        [Test]
        public void WhereWithJoin()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            // SubQuery of Territories
            TerritoryQuery tq = new TerritoryQuery("t");
            tq.Select(tq.TerritoryID);
            tq.Where(tq.Description == "North" |
                tq.Description == "West");

            // EmployeeTerritory Query for Join
            EmployeeTerritoryQuery etq = new EmployeeTerritoryQuery("et");

            // Employees matching those territories
            EmployeeQuery eq = new EmployeeQuery("e");
            eq.es.Distinct = true;
            eq.Select(eq.EmployeeID, etq.TerrID);
            eq.LeftJoin(etq).On(
                eq.EmployeeID == etq.EmpID);
            eq.Where(etq.TerrID.In(tq));
            eq.OrderBy(eq.EmployeeID.Ascending);

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(3, collection.Count);
        }

        #endregion

        #region Join SubQueries

        [Test]
        public void SimpleJoinOn()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("SubQuery inside an ON clause not Supported");
                    break;
                default:
                    // Query for the Join
                    OrderItemQuery oiq = new OrderItemQuery("oi");

                    // SubQuery of OrderItems with a discount
                    OrderItemQuery oisq = new OrderItemQuery("ois");
                    oisq.es.Distinct = true;
                    oisq.Select(oisq.Discount);
                    oisq.Where(oisq.Discount > 0);

                    // Orders with discounted items
                    OrderQuery oq = new OrderQuery("o");
                    oq.Select(oq.OrderID, oiq.Discount);
                    oq.InnerJoin(oiq).On(oq.OrderID == oiq.OrderID &
                        oiq.Discount.In(oisq));

                    Assert.IsTrue(collection.Load(oq));
                    Assert.AreEqual(2, collection.Count);
                    break;
            }
        }

        // There is currently no support for Subqueries in a Join()
        // clause, only the .On() clause.
        //[Test]
        //public void SimpleJoin()
        //{
        //    // SubQuery of OrderItems with a discount
        //    OrderItemQuery oiq = new OrderItemQuery("oi");
        //    oiq.es.Distinct = true;
        //    oiq.Select(oiq.OrderID, oiq.Discount);
        //    oiq.Where(oiq.Discount > 0);

        //    // Orders with discounted items
        //    OrderQuery oq = new OrderQuery("o");
        //    oq.Select(oq.OrderID, oiq.Discount);
        //    oq.InnerJoin(oiq).On(oq.OrderID == oiq.OrderID);

        //    OrderCollection collection = new OrderCollection();

        //    Assert.IsTrue(collection.Load(oq));
        //    Assert.AreEqual(2, collection.Count);
        //}

        #endregion

        #region Miscellaneous SubQueries

        [Test]
        public void Correlated()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            OrderItemQuery oiq = new OrderItemQuery("oi");
            ProductQuery pq = new ProductQuery("p");

            // oiq.ProductID in the inner Select is pulled from
            // the outer Select, making a correlated SubQuery.
            oiq.Select(
                oiq.OrderID,
                (oiq.Quantity * oiq.UnitPrice).Sum().As("Total")
            );
            oiq.Where(oiq.ProductID
                .In(
                    pq.Select(pq.ProductID)
                    .Where(oiq.ProductID == pq.ProductID)
                )
            );
            oiq.GroupBy(oiq.OrderID);

            Assert.IsTrue(collection.Load(oiq));
            Assert.AreEqual(5, collection.Count);
        }

        [Test]
        public void Nested()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            OrderQuery oq = new OrderQuery("o");
            CustomerQuery cq = new CustomerQuery("c");
            EmployeeQuery eq = new EmployeeQuery("e");

            // OrderID and CustID for customers who ordered on the same date
            // a customer was added, and have a manager whose 
            // last name starts with 'S'.
            oq.Select(
                oq.OrderID,
                oq.CustID
            );
            oq.Where(oq.OrderDate
                .In(
                    cq.Select(cq.DateAdded)
                    .Where(cq.Manager.In(
                        eq.Select(eq.EmployeeID)
                        .Where(eq.LastName.Like("S%"))
                        )
                    )
                )
            );

            Assert.IsTrue(collection.Load(oq));
            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void NestedBySubQuery()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            // This is the same as the traditional nested SubQuery 
            // in the 'Nested' test, but is easier to construct
            // and understand.
            // The key is to start with the innermost SubQuery,
            // and work your way out to the outermost Query.

            // Employees whose LastName begins with 'S'.
            EmployeeQuery eq = new EmployeeQuery("e");
            eq.Select(eq.EmployeeID);
            eq.Where(eq.LastName.Like("S%"));

            // DateAdded for Customers whose Managers are in the
            // EmployeeQuery above.
            CustomerQuery cq = new CustomerQuery("c");
            cq.Select(cq.DateAdded);
            cq.Where(cq.Manager.In(eq));

            // OrderID and CustID where the OrderDate is in the
            // CustomerQuery above.
            OrderQuery oq = new OrderQuery("o");
            oq.Select(
                oq.OrderID,
                oq.CustID
            );
            oq.Where(oq.OrderDate.In(cq));

            Assert.IsTrue(collection.Load(oq));
            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void AnyNestedBySubQuery()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("Not supported by SQLite.");
                    break;

                default:
                    // Employees whose LastName begins with 'S'.
                    EmployeeQuery eq = new EmployeeQuery("e");
                    eq.Select(eq.EmployeeID);
                    eq.Where(eq.LastName.Like("S%"));

                    // DateAdded for Customers whose Managers are in the
                    // EmployeeQuery above.
                    CustomerQuery cq = new CustomerQuery("c");
                    cq.es.Any = true;
                    cq.Select(cq.DateAdded);
                    cq.Where(cq.Manager.In(eq));

                    // OrderID and CustID where the OrderDate is 
                    // less than any one of the dates in the CustomerQuery above.
                    OrderQuery oq = new OrderQuery("o");
                    oq.Select(
                        oq.OrderID,
                        oq.CustID
                    );
                    oq.Where(oq.OrderDate < cq);

                    Assert.IsTrue(collection.Load(oq));
                    Assert.AreEqual(8, collection.Count);
                    break;
            }
        }

        [Test]
        public void AllSubQuery()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("Not supported by SQLite.");
                    break;

                default:
                    // DateAdded for Customers whose Manager  = 3
                    CustomerQuery cq = new CustomerQuery("c");
                    cq.es.All = true;
                    cq.Select(cq.DateAdded);
                    cq.Where(cq.Manager == 3);

                    // OrderID and CustID where the OrderDate is 
                    // less than all of the dates in the CustomerQuery above.
                    OrderQuery oq = new OrderQuery("o");
                    oq.Select(
                        oq.OrderID,
                        oq.CustID
                    );
                    oq.Where(oq.OrderDate < cq);

                    Assert.IsTrue(collection.Load(oq));
                    Assert.AreEqual(8, collection.Count);
                    break;
            }
        }

        #endregion
    }
}
