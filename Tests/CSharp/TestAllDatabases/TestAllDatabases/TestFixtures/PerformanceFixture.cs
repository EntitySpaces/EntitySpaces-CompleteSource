//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Linq;
using NUnit.Framework;

using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
    [TestFixture]
    public class PerformanceFixture
    {

        //[Test]
        //public void TestBulkInserts()
        //{
        //    AggregateTestCollection coll = new AggregateTestCollection();
        //    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        //    coll.Query.Where(coll.Query.Age < 100);
        //    sw.Start();
        //    coll.Query.Load();
        //    sw.Stop();
        //    Console.WriteLine("Initial Load: " + sw.Elapsed.ToString());

        //    coll.MarkAllAsDeleted();

        //    sw.Start();
        //    coll.Save();
        //    sw.Stop();
        //    Console.WriteLine("Deleted Save: " + sw.Elapsed.ToString());

        //    coll = new AggregateTestCollection();

        //    sw.Start();
        //    for (int i = 0; i < 50000; i++)
        //    {
        //        AggregateTest entity = coll.AddNew();
        //        entity.LastName = "BulkTest";
        //        entity.FirstName = "SomeName";
        //        entity.HireDate = DateTime.Now;
        //        entity.Age = 50;
        //        entity.IsActive = false;
        //    }
        //    sw.Stop();
        //    Console.WriteLine("Loop: " + sw.Elapsed.ToString());

        //    sw.Start();
        //    coll.Save();
        //    sw.Stop();
        //    Console.WriteLine("Added Save: " + sw.Elapsed.ToString());

        //    coll = new AggregateTestCollection();

        //    coll.Query.Load();

        //    string lq = coll.Query.es.LastQuery;

        //    //UnitTestBase.RefreshDatabase();

        //}

        [Test]
        public void LoadJoined()
        {
            CustomerQuery cq = new CustomerQuery("c");
            EmployeeQuery eq = new EmployeeQuery("e");
            EmployeeQuery eq2 = new EmployeeQuery("e2");
            OrderQuery oq = new OrderQuery("o");
            OrderItemQuery oiq = new OrderItemQuery("oi");
            ProductQuery pq = new ProductQuery("p");

            cq.Select(
                cq.CustomerID,
                cq.CustomerSub,
                cq.CustomerName,
                eq,
                eq2.LastName.As("ReportsTo"),
                oq.PlacedBy,
                oq.OrderDate,
                oiq,
                pq.ProductName,
                pq.Discontinued);
            cq.LeftJoin(eq).On(eq.EmployeeID == cq.Manager);
            cq.LeftJoin(eq2).On(eq.Supervisor == eq2.EmployeeID);
            cq.LeftJoin(oq).On(cq.CustomerID == oq.CustID
                && cq.CustomerSub == oq.CustSub);
            cq.LeftJoin(oiq).On(oq.OrderID == oiq.OrderID);
            cq.LeftJoin(pq).On(oiq.ProductID == pq.ProductID);

            CustomerCollection coll = new CustomerCollection();
            coll.es.Connection.Name = "ForeignKeyTest";

            Assert.IsTrue(coll.Load(cq));
            Assert.AreEqual(69, coll.Count);
        }
    }
}
