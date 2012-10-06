//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Configuration;

using BusinessObjects;

namespace Tests.Base
{
	/// <summary>
	/// Description of RefreshDatabase.
	/// </summary>
	public class UnitTestBase
	{
		static UnitTestBase()
		{
		}

		public static void RefreshDatabase()
		{
			RefreshDatabase("");
		}

		public static void RefreshDatabase(string connectionName)
		{
            AggregateTestCollection aggTestColl = new AggregateTestCollection();
			if (connectionName.Length != 0)
			{
				aggTestColl.es.Connection.Name = connectionName;
			}

			aggTestColl.LoadAll();
            aggTestColl.MarkAllAsDeleted();
			aggTestColl.Save();

			aggTestColl = new AggregateTestCollection();
			AggregateTest aggTest = new AggregateTest();
			if (connectionName.Length != 0)
			{
				aggTestColl.es.Connection.Name = connectionName;
				aggTest.es.Connection.Name = connectionName;
			}

            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "David";
            aggTest.str().LastName = "Doe";
            aggTest.str().Age = "16";
            aggTest.str().HireDate = "2000-02-16 05:59:31";
            aggTest.str().Salary = "34.71";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "1";
            aggTest.str().FirstName = "Sarah";
            aggTest.str().LastName = "McDonald";
            aggTest.str().Age = "28";
            aggTest.str().HireDate = "1999-03-25 00:00:00";
            aggTest.str().Salary = "11.06";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "David";
            aggTest.str().LastName = "Vincent";
            aggTest.str().Age = "43";
            aggTest.str().HireDate = "2000-10-17 00:00:00";
            aggTest.str().Salary = "10.27";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "2";
            aggTest.str().FirstName = "Fred";
            aggTest.str().LastName = "Smith";
            aggTest.str().Age = "15";
            aggTest.str().HireDate = "1999-03-15 00:00:00";
            aggTest.str().Salary = "15.15";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "Sally";
            aggTest.str().LastName = "Johnson";
            aggTest.str().Age = "30";
            aggTest.str().HireDate = "2000-10-07 00:00:00";
            aggTest.str().Salary = "14.36";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "5";
            aggTest.str().FirstName = "Jane";
            aggTest.str().LastName = "Rapaport";
            aggTest.str().Age = "44";
            aggTest.str().HireDate = "2002-05-02 00:00:00";
            aggTest.str().Salary = "13.56";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "4";
            aggTest.str().FirstName = "Paul";
            aggTest.str().LastName = "Gellar";
            aggTest.str().Age = "16";
            aggTest.str().HireDate = "2000-09-27 00:00:00";
            aggTest.str().Salary = "18.44";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "2";
            aggTest.str().FirstName = "John";
            aggTest.str().LastName = "Jones";
            aggTest.str().Age = "31";
            aggTest.str().HireDate = "2002-04-22 00:00:00";
            aggTest.str().Salary = "17.65";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "Michelle";
            aggTest.str().LastName = "Johnson";
            aggTest.str().Age = "45";
            aggTest.str().HireDate = "2003-11-14 00:00:00";
            aggTest.str().Salary = "16.86";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "2";
            aggTest.str().FirstName = "David";
            aggTest.str().LastName = "Costner";
            aggTest.str().Age = "17";
            aggTest.str().HireDate = "2002-04-11 00:00:00";
            aggTest.str().Salary = "21.74";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "4";
            aggTest.str().FirstName = "William";
            aggTest.str().LastName = "Gellar";
            aggTest.str().Age = "32";
            aggTest.str().HireDate = "2003-11-04 00:00:00";
            aggTest.str().Salary = "20.94";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "Sally";
            aggTest.str().LastName = "Rapaport";
            aggTest.str().Age = "39";
            aggTest.str().HireDate = "2002-04-01 00:00:00";
            aggTest.str().Salary = "25.82";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "5";
            aggTest.str().FirstName = "Jane";
            aggTest.str().LastName = "Vincent";
            aggTest.str().Age = "18";
            aggTest.str().HireDate = "2003-10-25 00:00:00";
            aggTest.str().Salary = "25.03";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "2";
            aggTest.str().FirstName = "Fred";
            aggTest.str().LastName = "Costner";
            aggTest.str().Age = "33";
            aggTest.str().HireDate = "1998-05-20 00:00:00";
            aggTest.str().Salary = "24.24";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "1";
            aggTest.str().FirstName = "John";
            aggTest.str().LastName = "Johnson";
            aggTest.str().Age = "40";
            aggTest.str().HireDate = "2003-10-15 00:00:00";
            aggTest.str().Salary = "29.12";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "Michelle";
            aggTest.str().LastName = "Rapaport";
            aggTest.str().Age = "19";
            aggTest.str().HireDate = "1998-05-10 00:00:00";
            aggTest.str().Salary = "28.32";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "4";
            aggTest.str().FirstName = "Sarah";
            aggTest.str().LastName = "Doe";
            aggTest.str().Age = "34";
            aggTest.str().HireDate = "1999-12-03 00:00:00";
            aggTest.str().Salary = "27.53";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "4";
            aggTest.str().FirstName = "William";
            aggTest.str().LastName = "Jones";
            aggTest.str().Age = "41";
            aggTest.str().HireDate = "1998-04-30 00:00:00";
            aggTest.str().Salary = "32.41";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "1";
            aggTest.str().FirstName = "Sarah";
            aggTest.str().LastName = "McDonald";
            aggTest.str().Age = "21";
            aggTest.str().HireDate = "1999-11-23 00:00:00";
            aggTest.str().Salary = "31.62";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "4";
            aggTest.str().FirstName = "Jane";
            aggTest.str().LastName = "Costner";
            aggTest.str().Age = "28";
            aggTest.str().HireDate = "1998-04-20 00:00:00";
            aggTest.str().Salary = "36.50";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "2";
            aggTest.str().FirstName = "Fred";
            aggTest.str().LastName = "Douglas";
            aggTest.str().Age = "42";
            aggTest.str().HireDate = "1999-11-13 00:00:00";
            aggTest.str().Salary = "35.71";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "Sarah";
            aggTest.str().LastName = "Jones";
            aggTest.str().Age = "22";
            aggTest.str().HireDate = "2001-06-07 00:00:00";
            aggTest.str().Salary = "34.91";
            aggTest.str().IsActive = "false";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "3";
            aggTest.str().FirstName = "Michelle";
            aggTest.str().LastName = "Doe";
            aggTest.str().Age = "29";
            aggTest.str().HireDate = "1999-11-03 00:00:00";
            aggTest.str().Salary = "39.79";
            aggTest.str().IsActive = "true";
            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "4";
            aggTest.str().FirstName = "Paul";
            aggTest.str().LastName = "Costner";
            aggTest.str().Age = "43";
            aggTest.str().HireDate = "2001-05-28 00:00:00";
            aggTest.str().Salary = "39.00";
            aggTest.str().IsActive = "true";

            aggTest = aggTestColl.AddNew();
            aggTest.str().DepartmentID = "0";
            aggTest.str().FirstName = "";
            aggTest.str().LastName = "";
            aggTest.str().Age = "0";
            aggTest.str().Salary = "0";

            aggTest = aggTestColl.AddNew();
            aggTest = aggTestColl.AddNew();
            aggTest = aggTestColl.AddNew();
            aggTest = aggTestColl.AddNew();
            aggTest = aggTestColl.AddNew();

            aggTestColl.Save();

        }

        public static void RefreshForeignKeyTest()
        {
            RefreshForeignKeyTest("");
        }

        public static void RefreshForeignKeyTest(string connectionName)
        {
            OrderItemCollection oiColl = new OrderItemCollection();
            oiColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                oiColl.es.Connection.Name = connectionName;
            }

            oiColl.Query.Where(oiColl.Query.OrderID > 11 |
                oiColl.Query.ProductID > 9);
            oiColl.Query.Load();
            oiColl.MarkAllAsDeleted();
            oiColl.Save();

            OrderCollection oColl = new OrderCollection();
            oColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                oColl.es.Connection.Name = connectionName;
            }

            oColl.Query.Where(oColl.Query.OrderID > 11);
            oColl.Query.Load();
            oColl.MarkAllAsDeleted();
            oColl.Save();

            EmployeeTerritoryCollection etColl = new EmployeeTerritoryCollection();
            etColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                etColl.es.Connection.Name = connectionName;
            }

            etColl.Query.Where(etColl.Query.EmpID > 4 |
                etColl.Query.TerrID > 4);
            etColl.Query.Load();
            etColl.MarkAllAsDeleted();
            etColl.Save();

            CustomerCollection cColl = new CustomerCollection();
            cColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                cColl.es.Connection.Name = connectionName;
            }

            cColl.Query.Where(cColl.Query.CustomerID > "99999" &
                cColl.Query.CustomerSub > "001");
            cColl.Query.Load();
            cColl.MarkAllAsDeleted();
            cColl.Save();

            TerritoryExCollection tExColl = new TerritoryExCollection();
            tExColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                tExColl.es.Connection.Name = connectionName;
            }

            tExColl.Query.Where(tExColl.Query.TerritoryID > 1);
            tExColl.Query.Load();
            tExColl.MarkAllAsDeleted();
            tExColl.Save();

            TerritoryCollection tColl = new TerritoryCollection();
            tColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                tColl.es.Connection.Name = connectionName;
            }

            tColl.Query.Where(tColl.Query.TerritoryID > 5);
            tColl.Query.Load();
            tColl.MarkAllAsDeleted();
            tColl.Save();

            ReferredEmployeeCollection reColl = new ReferredEmployeeCollection();
            reColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                reColl.es.Connection.Name = connectionName;
            }

            reColl.Query.Where(reColl.Query.EmployeeID > 4 |
                reColl.Query.ReferredID > 5);
            reColl.Query.Load();
            reColl.MarkAllAsDeleted();
            reColl.Save();

            ProductCollection pColl = new ProductCollection();
            pColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                pColl.es.Connection.Name = connectionName;
            }

            pColl.Query.Where(pColl.Query.ProductID > 10);
            pColl.Query.Load();
            pColl.MarkAllAsDeleted();
            pColl.Save();

            GroupCollection gColl = new GroupCollection();
            gColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                gColl.es.Connection.Name = connectionName;
            }

            gColl.Query.Where(gColl.Query.Id > "15001");
            gColl.Query.Load();
            gColl.MarkAllAsDeleted();
            gColl.Save();

            EmployeeCollection eColl = new EmployeeCollection();
            eColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                eColl.es.Connection.Name = connectionName;
            }

            eColl.Query.Where(eColl.Query.EmployeeID > 5);
            eColl.Query.Load();
            eColl.MarkAllAsDeleted();
            eColl.Save();

            CustomerGroupCollection cgColl = new CustomerGroupCollection();
            cgColl.es.Connection.Name = "ForeignKeyTest";
            if (connectionName.Length != 0)
            {
                cgColl.es.Connection.Name = connectionName;
            }

            cgColl.Query.Where(cgColl.Query.GroupID > "99999" |
                cgColl.Query.GroupID < "00001");
            cgColl.Query.Load();
            cgColl.MarkAllAsDeleted();
            cgColl.Save();

        }

        public static string GetFktString(EntitySpaces.Interfaces.esConnection conn)
        {
            ConnectionStringSettings settings;
            string fktString = "";

            switch (conn.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlServerCeProvider":
                    settings =
                        ConfigurationManager.ConnectionStrings["SqlCeFkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.SqlServerCe4Provider":
                    settings =
                        ConfigurationManager.ConnectionStrings["SqlCe4Fkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.OracleClientProvider":
                    settings =
                        ConfigurationManager.ConnectionStrings["OracleFkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.MSAccessProvider":
                    settings =
                        ConfigurationManager.ConnectionStrings["AccessFkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.VistaDBProvider":
                    settings =
                        ConfigurationManager.ConnectionStrings["VistaDBFkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.VistaDB4Provider":
                    settings =
                        ConfigurationManager.ConnectionStrings["VistaDB4Fkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.SQLiteProvider":
                    settings =
                        ConfigurationManager.ConnectionStrings["SQLiteFkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.NpgsqlProvider":
                case "EntitySpaces.Npgsql2Provider":
                    settings =
                        ConfigurationManager.ConnectionStrings["PgsqlFkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.MySqlClientProvider":
                    settings =
                        ConfigurationManager.ConnectionStrings["MySQLFkt"];
                    fktString = settings.ConnectionString;
                    break;

                case "EntitySpaces.SybaseSqlAnywhereProvider":
                    settings =
                        ConfigurationManager.ConnectionStrings["SybaseFkt"];
                    fktString = settings.ConnectionString;
                    break;

                default:
                    settings =
                        ConfigurationManager.ConnectionStrings["SqlServerFkt"];
                    fktString = settings.ConnectionString;
                    break;
            }

            return fktString;
        }
    }
}
