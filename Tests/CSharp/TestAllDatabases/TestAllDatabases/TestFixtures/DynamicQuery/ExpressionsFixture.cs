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
	public class ExpressionsFixture
	{
		[TestFixtureSetUp]
		public void Init()
		{
        }

		[SetUp]
		public void Init2()
		{
        }

        #region Concat Operator Tests

        [Test]
        public void ConcatTwoStrings()
		{
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select(eq.EmployeeID,
                (eq.LastName + eq.FirstName).As("FullName"));

            Assert.IsTrue(collection.Load(eq));

            string theName = collection[0].GetColumn("FullName") as string;
            Assert.AreEqual(9, theName.Length);
        }

        [Test]
        public void ConcatTwoStringsAndLiteral()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select(eq.EmployeeID,
                (eq.LastName + ", " + eq.FirstName).As("FullName"));

            Assert.IsTrue(collection.Load(eq));

            string theName = collection[0].GetColumn("FullName") as string;
            Assert.AreEqual(11, theName.Length);
        }

        [Test]
        public void ConcatTwoStringsAndTwoLiterals()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select(eq.EmployeeID,
                (eq.LastName + " (" + eq.FirstName + ")").As("FullName"));

            Assert.IsTrue(collection.Load(eq));

            string theName = collection[0].GetColumn("FullName") as string;
            Assert.AreEqual(12, theName.Length);
        }

        [Test]
        public void TwoAddStringsWithToUpper()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select(eq.EmployeeID,
                (eq.LastName.ToUpper() + ", " + eq.FirstName).As("FullName"));
            eq.Where(eq.LastName == "Doe");
            eq.OrderBy(eq.FirstName.Ascending);

            Assert.IsTrue(collection.Load(eq));

            string theName = collection[0].GetColumn("FullName") as string;
            Assert.AreEqual("DOE, Jane", theName);
        }

        [Test]
        public void TwoAddStringsWithToUpperCollection()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            collection.Query.Select(collection.Query.EmployeeID,
                (collection.Query.LastName.ToUpper() + ", " + 
                 collection.Query.FirstName).As("FullName"));
            collection.Query.Where(collection.Query.LastName == "Doe");
            collection.Query.OrderBy(collection.Query.FirstName.Ascending);

            Assert.IsTrue(collection.Query.Load());

            string theName = collection[0].GetColumn("FullName") as string;
            Assert.AreEqual("DOE, Jane", theName);
        }

        [Test]
        public void TwoAddStringsThenConcatenated()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select
            (
                eq.EmployeeID,
                (
                    (eq.LastName.ToLower() + eq.FirstName.ToLower()).Trim() +
                    " : " +
                    (eq.LastName.ToUpper() + eq.FirstName.ToUpper()).Trim()
                ).Trim().As("SomeColumn")
            );

            Assert.IsTrue(collection.Load(eq));

            string theName = collection[0].GetColumn("SomeColumn") as string;
            Assert.AreEqual("smithjohn : SMITHJOHN", theName);
        }

        [Test]
        public void TwoAddStringsWithOrderBy()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select(eq.EmployeeID,
                (eq.LastName + ", " + eq.FirstName).As("FullName"));
            eq.OrderBy(eq.EmployeeID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(eq));

            string theName = collection[0].GetColumn("FullName") as string;
            Assert.AreEqual(11, theName.Length);
        }

        #endregion

        #region Single Arithmetic Operator Tests

        [Test]
        public void OneAddIntegers()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select(eq.EmployeeID, eq.Age,
                (eq.Age + eq.Supervisor).As("SomeInt"));
            eq.OrderBy(eq.EmployeeID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(eq));

            object si = collection[0].GetColumn("SomeInt");
            Assert.AreEqual(null, si);

            int someInt = Convert.ToInt32(collection[1].GetColumn("SomeInt"));
            Assert.AreEqual(21, someInt);
        }

        [Test]
        public void OneAddDecimals()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            OrderItemQuery oiq = new OrderItemQuery("oiq");

            oiq.Select(oiq.OrderID, oiq.ProductID,
                (oiq.UnitPrice + oiq.Discount).As("SomeDecimal"));
            oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending);
            oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(oiq));

            decimal someDec = Convert.ToDecimal(collection[0].GetColumn("SomeDecimal"));
            Assert.AreEqual(Convert.ToDecimal("0.12"), Math.Round(someDec, 2));
        }

        [Test]
        public void OneAddAggregate()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            OrderItemQuery oiq = new OrderItemQuery("oiq");

            oiq.Select(oiq.ProductID,
                (oiq.UnitPrice + oiq.Discount).Sum().As("SomeDecimal"));
            oiq.GroupBy(oiq.ProductID);
            oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(oiq));

            decimal someDec = Convert.ToDecimal(collection[0].GetColumn("SomeDecimal"));
            Assert.AreEqual(Convert.ToDecimal("0.12"), Math.Round(someDec, 2));
        }

        [Test]
        public void OneSubtractDecimals()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            OrderItemQuery oiq = new OrderItemQuery("oiq");

            oiq.Select(oiq.OrderID, oiq.ProductID,
                (oiq.UnitPrice - oiq.Discount).As("SomeDecimal"));
            oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending);
            oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(oiq));

            decimal someDec = Convert.ToDecimal(collection[0].GetColumn("SomeDecimal"));
            Assert.AreEqual(Convert.ToDecimal("0.10"), Math.Round(someDec, 2));
        }

        [Test]
        public void OneMultiplyDecimals()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            OrderItemQuery oiq = new OrderItemQuery("oiq");

            oiq.Select(oiq.OrderID, oiq.ProductID,
                (oiq.UnitPrice * oiq.Discount).As("SomeDecimal"));
            oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending);
            oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(oiq));

            decimal someDec = Convert.ToDecimal(collection[0].GetColumn("SomeDecimal"));
            Assert.AreEqual(Convert.ToDecimal("0.001"), Math.Round(someDec, 3));
        }

        [Test]
        public void OneDivideDecimals()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            OrderItemQuery oiq = new OrderItemQuery("oiq");

            oiq.Select(oiq.OrderID, oiq.ProductID,
                (oiq.Discount / oiq.UnitPrice).As("SomeDecimal"));
            oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending);
            oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(oiq));

            decimal someDec = Convert.ToDecimal(collection[0].GetColumn("SomeDecimal"));
            Assert.AreEqual(Convert.ToDecimal("0.09"), Math.Round(someDec, 2));
        }

        [Test]
        public void OneModIntegers()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            switch (collection.es.Connection.ProviderMetadataKey)
            {
                case "esAccess":
                    Assert.Ignore("Not supported");
                    break;
                default:
                    OrderItemQuery oiq = new OrderItemQuery("oiq");

                    oiq.Select(oiq.OrderID, oiq.ProductID,
                        (oiq.Quantity % oiq.Quantity).As("SomeInteger"));
                    oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending);
                    oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

                    Assert.IsTrue(collection.Load(oiq));

                    decimal someInt = Convert.ToInt32(collection[0].GetColumn("SomeInteger"));
                    Assert.AreEqual(0, someInt);

                    break;
            }
        }

        [Test]
        public void OneModLiteral()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";


            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                    Assert.Ignore("Not supported");
                    break;
                default:

                    OrderItemQuery oiq = new OrderItemQuery("oiq");

                    oiq.Select(oiq.OrderID, oiq.ProductID,
                        (oiq.Quantity % 2).As("SomeInteger"));
                    oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending);
                    oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

                    Assert.IsTrue(collection.Load(oiq));

                    decimal someInt = Convert.ToInt32(collection[0].GetColumn("SomeInteger"));
                    Assert.AreEqual(1, someInt);
                    break;
            }
        }

        [Test]
        public void MultiExpression()
        {
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.ConnectionString =
                UnitTestBase.GetFktString(collection.es.Connection);

            EmployeeQuery eq = new EmployeeQuery("eq");

            eq.Select(eq.EmployeeID, eq.Age,
                ((eq.Age + eq.Supervisor) / 3).As("SomeInt"));
            eq.OrderBy(eq.EmployeeID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(eq));

            object si = collection[0].GetColumn("SomeInt");
            Assert.AreEqual(null, si);

            int someInt = Convert.ToInt32(collection[1].GetColumn("SomeInt"));
            Assert.AreEqual(7, someInt);
        }

        [Test]
        public void OneWhereSubtract()
        {
            OrderItemCollection collection = new OrderItemCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            OrderItemQuery oiq = new OrderItemQuery("oiq");

            oiq.Select(oiq.OrderID, oiq.ProductID,
                (oiq.UnitPrice - oiq.Discount).As("SomeDecimal"));
            oiq.Where(oiq.UnitPrice - oiq.Discount < .2);
            oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending);
            oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending);

            Assert.IsTrue(collection.Load(oiq));

            decimal someDec = Convert.ToDecimal(collection[0].GetColumn("SomeDecimal"));
            Assert.AreEqual(Convert.ToDecimal("0.10"), Math.Round(someDec, 2));
        }

        #endregion

    }
}
