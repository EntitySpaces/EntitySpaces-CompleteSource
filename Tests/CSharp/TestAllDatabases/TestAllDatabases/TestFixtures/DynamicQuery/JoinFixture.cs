//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using NUnit.Framework;
//using Adapdev.UnitTest;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;

using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class JoinFixture
	{
        #region Inner Join Tests

        [Test]
        public void InnerSimple()
		{
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";
            //collection.es.Connection.ConnectionString =
            //    UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            CustomerQuery cq = new CustomerQuery("cq");

            eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
            eq.InnerJoin(cq).On(eq.EmployeeID == cq.StaffAssigned);

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(10, collection.Count);
        }

        [Test]
        public void InnerAlias()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Not supported");
                    break;

                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    OrderQuery oq = new OrderQuery("o");
                    OrderItemQuery odq = new OrderItemQuery("od");

                    oq.Select(oq.OrderID, odq.OrderID);
                    oq.InnerJoin(odq).On(oq.OrderID == odq.OrderID);
                    oq.OrderBy(oq.OrderID.Ascending);

                    Assert.IsTrue(collection.Load(oq), "Load");
                    string lq = collection.Query.es.LastQuery;
                    Assert.AreEqual(1, collection[0].OrderID.Value, "Property");
                    Assert.AreEqual(1, Convert.ToInt32(collection[0].GetColumn("OrderID_1")), "Virtual");
                    break;

                default:
                    oq = new OrderQuery("o");
                    odq = new OrderItemQuery("od");

                    oq.Select(oq.OrderID, odq.OrderID);
                    oq.InnerJoin(odq).On(oq.OrderID == odq.OrderID);
                    oq.OrderBy(oq.OrderID.Ascending);

                    Assert.IsTrue(collection.Load(oq), "Load");
                    lq = collection.Query.es.LastQuery;
                    Assert.AreEqual(1, collection[0].OrderID.Value, "Property");
                    Assert.AreEqual(1, Convert.ToInt32(collection[0].GetColumn("OrderID1")), "Virtual");
                    break;
            }
        }

        [Test]
        public void InnerJoinFourTables()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery emp = new EmployeeQuery("e");
            EmployeeTerritoryQuery empTerr = new EmployeeTerritoryQuery("et");
            TerritoryQuery terr = new TerritoryQuery("t");
            TerritoryExQuery terrEx = new TerritoryExQuery("tx");

            emp.Select(emp.FirstName, emp.LastName, terr.Description.As("Territory"), terrEx.Notes);
            emp.InnerJoin(empTerr).On(emp.EmployeeID == empTerr.EmpID);
            emp.InnerJoin(terr).On(terr.TerritoryID == empTerr.TerrID);
            emp.InnerJoin(terrEx).On(terrEx.TerritoryID == terr.TerritoryID);
            emp.Where(terrEx.Notes.IsNotNull());

            Assert.IsTrue(collection.Load(emp));
            Assert.AreEqual(2, collection.Count);

            string theName = collection[1].GetColumn("Territory") as string;
            Assert.AreEqual("North", theName);
        }

        [Test]
        public void InnerSelectAllPrimaryQuery()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            OrderQuery oq = new OrderQuery("o");
            OrderItemQuery oiq = new OrderItemQuery("oi");

            oq.Select(oq);
            oq.InnerJoin(oiq).On(oq.OrderID == oiq.OrderID);

            Assert.IsTrue(collection.Load(oq));
            Assert.AreEqual(15, collection.Count);

            string lq = collection.Query.es.LastQuery;
            string all = lq.Substring(7, 3);
            Assert.AreEqual("o.*", all);
        }

        [Test]
        public void InnerSelectAllSecondaryQuery()
        {
            OrderCollection collection = new OrderCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            OrderQuery oq = new OrderQuery("o");
            OrderItemQuery oiq = new OrderItemQuery("oi");

            oq.Select(oiq);
            oq.InnerJoin(oiq).On(oq.OrderID == oiq.OrderID);

            Assert.IsTrue(collection.Load(oq));
            Assert.AreEqual(15, collection.Count);

            string lq = collection.Query.es.LastQuery;
            string all = lq.Substring(7, 4);
            Assert.AreEqual("oi.*", all);
        }

        #endregion

        #region Left Join Tests

        [Test]
        public void LeftSimple()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            CustomerQuery cq = new CustomerQuery("cq");

            eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
            eq.LeftJoin(cq).On(eq.EmployeeID == cq.StaffAssigned);

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(11, collection.Count);
        }

        [Test]
        public void LeftIsNull()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            CustomerQuery cq = new CustomerQuery("cq");

            eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
            eq.LeftJoin(cq).On(eq.EmployeeID == cq.Manager &
                cq.StaffAssigned.IsNull());

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(47, collection.Count);
        }

        [Test]
        public void LeftIsNotNull()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            CustomerQuery cq = new CustomerQuery("cq");

            eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
            eq.LeftJoin(cq).On(eq.EmployeeID == cq.Manager &
                cq.StaffAssigned.IsNotNull());

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(13, collection.Count);
        }

        [Test]
        public void LeftWithWhere()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            CustomerQuery cust = new CustomerQuery("cq");
            EmployeeQuery emp = new EmployeeQuery("eq");

            cust.Select(cust.CustomerID, emp.LastName,
                cust.Manager, cust.StaffAssigned);
            cust.LeftJoin(emp).On(cust.Manager ==
                emp.EmployeeID);
            cust.Where(
                cust.Manager == cust.StaffAssigned);

            Assert.IsTrue(collection.Load(cust));
            Assert.AreEqual(4, collection.Count);
        }

        [Test]
        public void LeftWithOperatorsInOn()
        {
            int record = 0;
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                    record = 2;
                    CustomerQuery cq = new CustomerQuery("cq");
                    EmployeeQuery eq = new EmployeeQuery("eq");

                    cq.Select(cq.CustomerName, eq.LastName);
                    cq.LeftJoin(eq).On(cq.StaffAssigned == eq.EmployeeID &
                        eq.Supervisor == 1);
                    cq.OrderBy(cq.CustomerName.Ascending);

                    Assert.IsTrue(collection.Load(cq));
                    Assert.AreEqual(56, collection.Count);
                    Assert.AreEqual("Doe", collection[record].GetColumn("LastName"));
                    break;
                default:
                    record = 1;
                    cq = new CustomerQuery("cq");
                    eq = new EmployeeQuery("eq");

                    cq.Select(cq.CustomerName, eq.LastName);
                    cq.LeftJoin(eq).On(cq.StaffAssigned == eq.EmployeeID &
                        eq.Supervisor == 1);
                    cq.OrderBy(cq.CustomerName.Ascending);

                    Assert.IsTrue(collection.Load(cq));
                    Assert.AreEqual(56, collection.Count);
                    Assert.AreEqual("Doe", collection[record].GetColumn("LastName"));
                    break;
            }
        }

        [Test]
        public void LeftWithDateComparisonInOn()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            CustomerQuery cq = new CustomerQuery("cq");

            eq.Select(eq.LastName);
            eq.LeftJoin(cq).On(eq.EmployeeID == cq.StaffAssigned &
                cq.DateAdded < Convert.ToDateTime("2005-12-31"));
            eq.Where(cq.DateAdded < Convert.ToDateTime("2000-12-31"));
            eq.OrderBy(eq.LastName.Ascending);

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(7, collection.Count);
        }

        [Test]
        public void LeftWithContains()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    string nameTerm =
                        "acme NEAR company";

                    EmployeeQuery eq = new EmployeeQuery("eq");
                    CustomerQuery cq = new CustomerQuery("cq");

                    eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
                    eq.LeftJoin(cq).On(eq.EmployeeID == cq.StaffAssigned);
                    eq.Where(cq.CustomerName.Contains(nameTerm));

                    Assert.IsTrue(collection.Load(eq));
                    Assert.AreEqual(2, collection.Count);
                    break;

                default:
                    Assert.Ignore("Not supported");
                    break;
            }
        }

        [Test]
        public void LeftSelfJoin()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            EmployeeQuery supervisorQuery = new EmployeeQuery("sq");

            eq.Select(eq.EmployeeID, eq.LastName,
                supervisorQuery.LastName.As("Reports To"));
            eq.LeftJoin(supervisorQuery)
                .On(eq.Supervisor == supervisorQuery.EmployeeID);

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(5, collection.Count);
        }

        [Test]
        public void LeftRawSelect()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            CustomerQuery cq = new CustomerQuery("cq");

            string special = "";
            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    special = "<cq.[CustomerID] + '-' + cq.[CustomerSub] AS FullCustomerId>";
                    break;

                case "EntitySpaces.MySqlClientProvider":
                    special = "<CONCAT(cq.`CustomerID`, '-', cq.`CustomerSub`) AS 'FullCustomerId'>";
                    break;

                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.OracleClientProvider":
                    special = "<cq.\"CustomerID\" || '-' || cq.\"CustomerSub\" AS \"FullCustomerId\">";
                    break;

                default:
                    if (collection.es.Connection.Name == "SqlCe")
                    {
                        special = "<cq.[CustomerID] + '-' + cq.[CustomerSub] AS \"FullCustomerId\">";
                    }
                    else
                    {
                        special = "<cq.[CustomerID] + '-' + cq.[CustomerSub] As FullCustomerId>";
                    }
                    break;
            }

            eq.Select(eq.EmployeeID, eq.LastName, special, cq.CustomerName);

            eq.LeftJoin(cq).On(eq.EmployeeID == cq.StaffAssigned);

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(11, collection.Count);
        }

        [Test]
        public void LeftJoinFourTables()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery emp = new EmployeeQuery("e");
            EmployeeTerritoryQuery empTerr = new EmployeeTerritoryQuery("et");
            TerritoryQuery terr = new TerritoryQuery("t");
            TerritoryExQuery terrEx = new TerritoryExQuery("tx");

            emp.Select(emp.FirstName, emp.LastName, terr.Description.As("Territory"), terrEx.Notes);
            emp.LeftJoin(empTerr).On(emp.EmployeeID == empTerr.EmpID);
            emp.LeftJoin(terr).On(empTerr.TerrID == terr.TerritoryID);
            emp.LeftJoin(terrEx).On(terr.TerritoryID == terrEx.TerritoryID);

            Assert.IsTrue(collection.Load(emp));
            Assert.AreEqual(9, collection.Count);
        }

        [Test]
        public void LeftJoinFourTablesWithWhere()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery emp = new EmployeeQuery("e");
            EmployeeTerritoryQuery empTerr = new EmployeeTerritoryQuery("et");
            TerritoryQuery terr = new TerritoryQuery("t");
            TerritoryExQuery terrEx = new TerritoryExQuery("tx");

            emp.Select(emp.FirstName, emp.LastName, terr.Description.As("Territory"), terrEx.Notes);
            emp.LeftJoin(empTerr).On(emp.EmployeeID == empTerr.EmpID);
            emp.LeftJoin(terr).On(empTerr.TerrID == terr.TerritoryID);
            emp.LeftJoin(terrEx).On(terr.TerritoryID == terrEx.TerritoryID);

            emp.Where(emp.FirstName.Trim().Like("J___"));

            Assert.IsTrue(collection.Load(emp));
            Assert.AreEqual(7, collection.Count);
        }

        #endregion

        #region Right Join Tests

        [Test]
        public void RightSimple()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("RIGHT JOIN not supported.");
                    break;

                default:
                    EmployeeQuery eq = new EmployeeQuery("eq");
                    CustomerQuery cq = new CustomerQuery("cq");

                    eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
                    eq.RightJoin(cq).On(eq.EmployeeID == cq.StaffAssigned);

                    Assert.IsTrue(collection.Load(eq));
                    Assert.AreEqual(56, collection.Count);
                    break;
            }
        }

        [Test]
        public void RightWithOnIn()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("RIGHT JOIN not supported.");
                    break;

                default:
                    List<string> custList = new List<string>();
                    custList.Add("01001");
                    custList.Add("40000");
                    custList.Add("XXXXX");

                    EmployeeQuery eq = new EmployeeQuery("eq");
                    CustomerQuery cq = new CustomerQuery("cq");

                    eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerID, cq.CustomerName);
                    eq.RightJoin(cq).On(eq.EmployeeID == cq.Manager
                        && cq.CustomerID.In(custList));

                    EmployeeCollection coll = new EmployeeCollection();
                    coll.es.Connection.Name = "ForeignKeyTest";

                    Assert.IsTrue(coll.Load(eq));
                    Assert.AreEqual(56, coll.Count);
                    break;
            }
        }

        [Test]
        public void RightWithWhereIn()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("RIGHT JOIN not supported.");
                    break;

                default:
                    List<string> custList = new List<string>();
                    custList.Add("01001");
                    custList.Add("40000");
                    custList.Add("XXXXX");

                    EmployeeQuery eq = new EmployeeQuery("eq");
                    CustomerQuery cq = new CustomerQuery("cq");

                    eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerID, cq.CustomerName);
                    eq.RightJoin(cq).On(eq.EmployeeID == cq.Manager);
                    eq.Where(cq.CustomerID.In(custList));

                    EmployeeCollection coll = new EmployeeCollection();
                    coll.es.Connection.Name = "ForeignKeyTest";

                    Assert.IsTrue(coll.Load(eq));
                    Assert.AreEqual(14, coll.Count);
                    break;
            }
        }

        [Test]
        public void RightWithFromSubQuery()
        {
            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SQLiteProvider":
                    Assert.Ignore("RIGHT JOIN not supported.");
                    break;

                default:
                    CustomerQuery cq1 = new CustomerQuery("c1");
                    cq1.es.Top = 5;
                    cq1.Select(cq1.CustomerID, cq1.CustomerSub);
                    cq1.Where(cq1.Active == true);
                    cq1.OrderBy(cq1.CustomerID.Ascending);

                    CustomerQuery cq2 = new CustomerQuery("c2");

                    CustomerQuery cq3 = new CustomerQuery("c3");
                    cq3.Select(cq2);
                    cq3.From(cq1).As("cSub");
                    cq3.RightJoin(cq2).On(cq1.CustomerID == cq2.CustomerID && 
                        cq1.CustomerSub == cq2.CustomerSub);
                    cq3.Where(cq2.Active == true && cq1.CustomerID.IsNull());
                    cq3.OrderBy(cq2.CustomerID.Ascending);

                    Assert.IsTrue(coll.Load(cq3));
                    Assert.AreEqual(36, coll.Count);
                    break;
            }
        }

        #endregion

        #region Full Join Tests

        [Test]
        public void FullSimple()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            if (collection.es.Connection.Name == "SqlCe")
            {
                Assert.Ignore("FULL JOIN not supported.");
            }
            else
            {
                switch (collection.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.MySqlClientProvider":
                    case "EntitySpaces.SQLiteProvider":
                    case "EntitySpaces.SqlServerCeProvider":
                    case "EntitySpaces.SqlServerCe4Provider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("FULL JOIN not supported.");
                        break;

                    default:
                        EmployeeQuery eq = new EmployeeQuery("eq");
                        CustomerQuery cq = new CustomerQuery("cq");

                        eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
                        eq.FullJoin(cq).On(eq.EmployeeID == cq.StaffAssigned);

                        Assert.IsTrue(collection.Load(eq));
                        Assert.AreEqual(57, collection.Count);
                        break;
                }
            }
        }

        #endregion

        #region Mixed Join Tests

        [Test]
        public void JoinFourTablesInnerLeft()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Not supported.");
                    break;

                default:
                    EmployeeQuery emp = new EmployeeQuery("e");
                    EmployeeTerritoryQuery empTerr = new EmployeeTerritoryQuery("et");
                    TerritoryQuery terr = new TerritoryQuery("t");
                    TerritoryExQuery terrEx = new TerritoryExQuery("tx");

                    emp.Select(emp.FirstName, emp.LastName, terr.Description.As("Territory"), terrEx.Notes);
                    emp.LeftJoin(empTerr).On(emp.EmployeeID == empTerr.EmpID);
                    emp.InnerJoin(terr).On(empTerr.TerrID == terr.TerritoryID);
                    emp.LeftJoin(terrEx).On(terr.TerritoryID == terrEx.TerritoryID);

                    Assert.IsTrue(collection.Load(emp));
                    Assert.AreEqual(8, collection.Count);
                    break;
            }
        }

        [Test]
        public void JoinCompositeFK()
        {
            ProductCollection collection = new ProductCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            int empId = 1;

            ProductQuery prd = new ProductQuery("pq");
            OrderItemQuery item = new OrderItemQuery("oiq");
            OrderQuery ord = new OrderQuery("oq");
            CustomerQuery cust = new CustomerQuery("cq");
            EmployeeQuery emp = new EmployeeQuery("eq");

            prd.Select(prd.ProductID);
            prd.InnerJoin(item).On(prd.ProductID == item.ProductID);
            prd.InnerJoin(ord).On(item.OrderID == ord.OrderID);
            prd.InnerJoin(cust).On(ord.CustID == cust.CustomerID &
                ord.CustSub == cust.CustomerSub);
            prd.InnerJoin(emp).On(cust.Manager == emp.EmployeeID);
            prd.Where(emp.EmployeeID == empId);
            prd.Where(prd.Discontinued == false);
            prd.OrderBy(prd.ProductID.Ascending);

            Assert.IsTrue(collection.Load(prd));
            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void MixedANDAndORInOn()
        {
            ProductCollection collection = new ProductCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            int empId = 1;

            ProductQuery prd = new ProductQuery("pq");
            OrderItemQuery item = new OrderItemQuery("oiq");
            OrderQuery ord = new OrderQuery("oq");
            CustomerQuery cust = new CustomerQuery("cq");
            EmployeeQuery emp = new EmployeeQuery("eq");

            prd.Select(prd.ProductID);
            prd.InnerJoin(item).On(prd.ProductID == item.ProductID);
            prd.InnerJoin(ord).On(item.OrderID == ord.OrderID);
            prd.InnerJoin(cust).On(ord.CustID == cust.CustomerID &
                (ord.CustSub == cust.CustomerSub |
                ord.EmployeeID == cust.StaffAssigned));
            prd.InnerJoin(emp).On(cust.Manager == emp.EmployeeID);
            prd.Where(emp.EmployeeID == empId);
            prd.Where(prd.Discontinued == false);
            prd.OrderBy(prd.ProductID.Ascending);

            Assert.IsTrue(collection.Load(prd));
            Assert.AreEqual(9, collection.Count);
        }

        #endregion

        #region Combination Join and Expression Tests

        [Test]
        public void JoinWithArithmeticExpressionOrderByCalulatedColumn()
        {
            CustomerCollection collection = new CustomerCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            string orderAlias = "";
            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    orderAlias = "<'TotalSales'>";
                    break;
                default:
                    orderAlias = "TotalSales";
                    break;
            }

            // Notice I create a calulated columns based on the TotalSales,
            // then Order by it descending
            CustomerQuery cust = new CustomerQuery("c");
            OrderQuery order = new OrderQuery("o");
            OrderItemQuery item = new OrderItemQuery("oi");

            cust.Select(cust.CustomerName,
                (item.Quantity * item.UnitPrice).Sum().As("TotalSales"));
            cust.InnerJoin(order).On(order.CustID == cust.CustomerID);
            cust.InnerJoin(item).On(item.OrderID == order.OrderID);
            cust.GroupBy(cust.CustomerName);
            cust.OrderBy(orderAlias, esOrderByDirection.Descending);

            Assert.IsTrue(collection.Load(cust));
            Assert.AreEqual(6, collection.Count);
        }

        [Test]
        public void JoinWithPaging()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                    Assert.Ignore("Not supported");
                    break;
                default:
                    EmployeeQuery emp = new EmployeeQuery("e");
                    EmployeeTerritoryQuery empTerr = new EmployeeTerritoryQuery("et");
                    TerritoryQuery terr = new TerritoryQuery("t");
                    TerritoryExQuery terrEx = new TerritoryExQuery("tx");

                    emp.Select(emp, terr.Description.As("Territory"), terrEx.Notes);
                    emp.InnerJoin(empTerr).On(empTerr.TerrID == emp.EmployeeID);
                    emp.InnerJoin(terr).On(terr.TerritoryID == empTerr.TerrID);
                    emp.InnerJoin(terrEx).On(terrEx.TerritoryID == terr.TerritoryID);
                    emp.Where(terrEx.Notes.IsNotNull());
                    emp.OrderBy(emp.FirstName.Ascending);

                    emp.es.PageNumber = 1;
                    emp.es.PageSize = 20;

                    Assert.IsTrue(collection.Load(emp));
                    Assert.AreEqual(2, collection.Count);

                    break;
            }
        }

        #endregion

        #region Custom Join Tests

        [Test]
        public void CustomMultiInnerWithDistinct()
        {
            int empId = 1;
            ProductCollection collection = new ProductCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            Assert.IsTrue(collection.GetActiveProductIds(empId));
            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void CrossDbJoin()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    // AggregateDb
                    AggregateTestQuery aq = new AggregateTestQuery("a");
                    // ForeignKeyTest
                    EmployeeQuery eq = new EmployeeQuery("e");

                    eq.Select(eq.LastName, eq.FirstName, aq.Age);
                    eq.LeftJoin(aq).On(
                        eq.LastName == aq.LastName &
                        eq.FirstName == aq.FirstName);
                    eq.OrderBy(eq.LastName.Ascending,
                        eq.FirstName.Ascending);

                    Assert.IsTrue(collection.Load(eq));
                    Assert.AreEqual(22, collection[2].GetColumn("Age"));
                    break;

                default:
                    Assert.Ignore("SQL Server only");
                    break;
            }
        }

        [Test]
        public void LeftWithExplicitParen()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");
            CustomerQuery cq = new CustomerQuery("cq");

            eq.Select(eq.EmployeeID, eq.LastName, cq.CustomerName);
            eq.LeftJoin(cq).On(eq.EmployeeID == cq.StaffAssigned);

            eq.Where(eq.Age == 20);

            eq.Where(new esComparison(esParenthesis.Open));

            eq.es.DefaultConjunction = esConjunction.Or;

            for (int i = 0; i < 4; i++)
            {
                eq.Where(
                    eq.Supervisor == i &
                    eq.EmployeeID == i + 1);
            }

            eq.Where(new esComparison(esParenthesis.Close));

            Assert.IsTrue(collection.Load(eq));
            Assert.AreEqual(5, collection.Count);
        }

        #endregion
    }
}
