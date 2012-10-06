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
	public class CastingFixture
    {
        #region Low Level Cast Tests

        [Test]
        public void CastToBoolean()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esBoolean)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    string lq = emp.Query.Parse();
                    Assert.IsTrue(emp.Query.Load());

                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Boolean", obj.GetType().ToString());
                    Assert.AreEqual(true, obj);
                    break;
            }
        }

        [Test]
        public void CastToByte()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esByte)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    byte value = 30;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Byte", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToChar()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.VistaDBProvider":
                //case "EntitySpaces.SQLiteProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.OracleClientProvider":
                    emp.Query.Select(emp.Query.FirstName.Cast(esCastType.Char, 25).As("CastColumn"));
                    Assert.IsTrue(emp.Query.Load());

                    //string value = "John";
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.String", obj.GetType().ToString());
                    //Assert.AreEqual(value, obj);
                    break;
                default:
                    emp.Query.Select((esChar)emp.Query.FirstName.As("CastColumn"));
                    Assert.IsTrue(emp.Query.Load());

                    //string value = "John";
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.String", obj.GetType().ToString());
                    //Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToCharWithSizePadded()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select(emp.Query.FirstName.Cast(esCastType.Char, 5).As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.MySqlClientProvider":
                case "EntitySpaces.SQLiteProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    string value = "John ";
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.String", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToCharWithSizeTrunc()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select(emp.Query.FirstName.Cast(esCastType.Char, 3).As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.SQLiteProvider":
                case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.SqlServerCe4Provider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    string value = "Joh";
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.String", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToDateTime()
        {
            int empId = 0;

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Create an employee with a date in the LastName column
                    Employee emp = new Employee();
                    emp.es.Connection.Name = "ForeignKeyTest";

                    switch (emp.es.Connection.ProviderSignature.DataProviderName)
                    {
                        case "EntitySpaces.OracleClientProvider":
                            emp.LastName = "31-DEC-2008 01:01:01";
                            break;
                        default:
                            emp.LastName = "2008-12-31";
                            break;
                    }
                    emp.FirstName = "required";
                    emp.Save();

                    empId = emp.EmployeeID.Value;

                    emp = new Employee();
                    emp.es.Connection.Name = "ForeignKeyTest";

                    emp.Query.Select((esDateTime)emp.Query.LastName.As("CastColumn"));
                    emp.Query.Where(emp.Query.EmployeeID == empId);

                    switch (emp.es.Connection.ProviderSignature.DataProviderName)
                    {
                        //case "EntitySpaces.MySqlClientProvider":
                        //case "EntitySpaces.NpgsqlProvider":
                        //case "EntitySpaces.Npgsql2Provider":
                        //case "EntitySpaces.VistaDBProvider":
                        case "EntitySpaces.MSAccessProvider":
                        case "EntitySpaces.SQLiteProvider":
                        //case "EntitySpaces.SqlServerCeProvider":
                            Assert.Ignore("Not supported.");
                            break;
                        case "EntitySpaces.OracleClientProvider":
                            string lq = emp.Query.Parse();
                            Assert.IsTrue(emp.Query.Load());

                            DateTime value = DateTime.Parse("2008-12-31 01:01:01");
                            object obj = emp.GetColumn("CastColumn");
                            Assert.AreEqual("System.DateTime", obj.GetType().ToString());
                            Assert.AreEqual(value, obj);
                            break;
                        default:
                            lq = emp.Query.Parse();
                            Assert.IsTrue(emp.Query.Load());

                            value = DateTime.Parse("2008-12-31");
                            obj = emp.GetColumn("CastColumn");
                            Assert.AreEqual("System.DateTime", obj.GetType().ToString());
                            Assert.AreEqual(value, obj);
                            break;
                    }
                }
            }
            finally
            {
                Employee emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                emp.Query.Where(emp.Query.EmployeeID == empId);
                if (emp.Query.Load())
                {
                    emp.MarkAsDeleted();
                    emp.Save();
                }
            }               
        }

        [Test]
        public void CastToDecimal()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esDecimal)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.OracleClientProvider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    decimal value = 30;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToDouble()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esDouble)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.OracleClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    double value = 30.0;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                case "EntitySpaces.MySqlClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    value = 30.0;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    value = 30.0;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Double", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToGuid()
        {
            int prdId = 0;

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    // Create an employee with a guid in the LastName column
                    Product prd = new Product();
                    prd.es.Connection.Name = "ForeignKeyTest";

                    prd.ProductName = "551cfc32-c6d2-4756-8c59-efb460a0d1d9";
                    prd.UnitPrice = 35.23M;
                    prd.Discontinued = false;
                    prd.Save();

                    prdId = prd.ProductID.Value;

                    prd = new Product();
                    prd.es.Connection.Name = "ForeignKeyTest";

                    prd.Query.Select((esGuid)prd.Query.ProductName.As("CastColumn"));
                    prd.Query.Where(prd.Query.ProductID == prdId);

                    switch (prd.es.Connection.ProviderSignature.DataProviderName)
                    {
                        //case "EntitySpaces.VistaDBProvider":
                        case "EntitySpaces.MSAccessProvider":
                        case "EntitySpaces.MySqlClientProvider":
                        case "EntitySpaces.OracleClientProvider":
                        case "EntitySpaces.NpgsqlProvider":
                        case "EntitySpaces.SQLiteProvider":
                        //case "EntitySpaces.SqlServerCeProvider":
                            Assert.Ignore("Not supported.");
                            break;
                        default:
                            Assert.IsTrue(prd.Query.Load());

                            Guid value = new Guid("551cfc32-c6d2-4756-8c59-efb460a0d1d9");
                            object obj = prd.GetColumn("CastColumn");
                            Assert.AreEqual("System.Guid", obj.GetType().ToString());
                            Assert.AreEqual(value, obj);
                            break;
                    }
                }
            }
            finally
            {
                Product prd = new Product();
                prd.es.Connection.Name = "ForeignKeyTest";

                prd.Query.Where(prd.Query.ProductID == prdId); ;
                if (prd.Query.Load())
                {
                    prd.MarkAsDeleted();
                    prd.Save();
                }
            } 
        }

        [Test]
        public void CastToInt16()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esInt16)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.OracleClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    System.Int16 value = 30;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                case "EntitySpaces.MySqlClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    value = 30;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Int64", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    value = 30;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Int16", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToInt32()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esInt32)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.OracleClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    System.Int32 value = 30;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                case "EntitySpaces.MySqlClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    value = 30;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Int64", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    value = 30;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Int32", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToInt64()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esInt64)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.OracleClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    System.Int64 value = 30;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    value = 30;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Int64", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToSingle()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select((esSingle)emp.Query.Age.As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.MySqlClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    Single value = 30.0f;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                case "EntitySpaces.OracleClientProvider":
                    Assert.IsTrue(emp.Query.Load());

                    value = 30.0f;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    value = 30.0f;
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Single", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToString()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.OracleClientProvider":
                    emp.Query.Select(emp.Query.Age.Cast(esCastType.String, 3).As("CastColumn"));
                    Assert.IsTrue(emp.Query.Load());

                    string value = "30";
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.String", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
                default:
                    emp.Query.Select((esString)emp.Query.Age.As("CastColumn"));
                    Assert.IsTrue(emp.Query.Load());

                    value = "30";
                    obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.String", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        #endregion

        #region esQueryItem.Cast tests

        [Test]
        public void CastToDecimalPrecisionScale()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select(emp.Query.Age.Cast(esCastType.Decimal, 8, 4).As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.OracleClientProvider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    System.Decimal value = 30;
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.Decimal", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        [Test]
        public void CastToStringLength()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            emp.Query.Select(emp.Query.FirstName.Cast(esCastType.String, 2).As("CastColumn"));
            emp.Query.Where(emp.Query.EmployeeID == 1);

            switch (emp.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.OracleClientProvider":
                case "EntitySpaces.MSAccessProvider":
                case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.VistaDB4Provider":
                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    Assert.Ignore("Not supported.");
                    break;
                default:
                    Assert.IsTrue(emp.Query.Load());

                    string value = "Jo";
                    object obj = emp.GetColumn("CastColumn");
                    Assert.AreEqual("System.String", obj.GetType().ToString());
                    Assert.AreEqual(value, obj);
                    break;
            }
        }

        #endregion

        #region Select Tests

        [Test]
        public void SelectCollection()
		{
            EmployeeCollection collection = new EmployeeCollection();
            collection.es.Connection.Name = "ForeignKeyTest";

            collection.Query.OrderBy(collection.Query.EmployeeID.Ascending);

            switch (collection.es.Connection.ProviderSignature.DataProviderName)
            {
                //case "EntitySpaces.MySqlClientProvider":
                //case "EntitySpaces.NpgsqlProvider":
                //case "EntitySpaces.Npgsql2Provider":
                //case "EntitySpaces.SQLiteProvider":
                //case "EntitySpaces.VistaDBProvider":
                case "EntitySpaces.MSAccessProvider":
                //case "EntitySpaces.SqlServerCeProvider":
                    Assert.Ignore("Not supported.");
                    break;
                case "EntitySpaces.OracleClientProvider":
                    collection.Query.Select
                    (
                        (collection.Query.FirstName.ToUpper() + ":" + collection.Query.Age.Cast(esCastType.String, 2)).As("FirstName"),
                        collection.Query.LastName
                    );
                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual("JOHN:30", collection[0].FirstName);
                    break;
                default:
                    collection.Query.Select
                    (
                        (collection.Query.FirstName.ToUpper() + ":" + (esString)collection.Query.Age).As("FirstName"),
                        collection.Query.LastName
                    );
                    Assert.IsTrue(collection.Query.Load());
                    Assert.AreEqual("JOHN:30", collection[0].FirstName);
                    break;
            }
        }


        #endregion
    }
}
