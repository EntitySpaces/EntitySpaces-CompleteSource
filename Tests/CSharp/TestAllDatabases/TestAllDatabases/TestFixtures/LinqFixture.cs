//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.DynamicQuery;
using EntitySpaces.Interfaces;

namespace Tests.Base
{
	[TestFixture]
	public class LinqFixture
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
        [Ignore("Needs provider independent DataContext")]
        public void LinqTest()
        {
            //EmployeeCollection coll = new EmployeeCollection();
            //coll.es.Connection.Name = "ForeignKeyTest";

            //DataContext context = null;
            //switch (coll.es.Connection.ProviderSignature.DataProviderName)
            //{
            //    case "EntitySpaces.MSAccessProvider":
            //        break;
            //    case "EntitySpaces.MySqlClientProvider":
            //        MySql.Data.MySqlClient.MySqlConnection mys =
            //            new MySql.Data.MySqlClient.MySqlConnection(coll.es.Connection.ConnectionString);
            //        context = new DataContext(mys);
            //        break;
            //    case "EntitySpaces.NpgsqlProvider":
            //        break;
            //    case "EntitySpaces.Npgsql2Provider":
            //        Npgsql.NpgsqlConnection pg =
            //            new Npgsql.NpgsqlConnection(coll.es.Connection.ConnectionString);
            //        context = new DataContext(pg);
            //        break;
            //    case "EntitySpaces.OracleClientProvider":
            //        break;
            //    case "EntitySpaces.SQLiteProvider":
            //        System.Data.SQLite.SQLiteConnection sq =
            //            new System.Data.SQLite.SQLiteConnection(coll.es.Connection.ConnectionString);
            //        context = new DataContext(sq);
            //        break;
            //    case "EntitySpaces.SqlServerCeProvider":
            //    case "EntitySpaces.SybaseSqlAnywhereProvider":
            //    case "EntitySpaces.VistaDBProvider":
            //        break;
            //    case "EntitySpaces.VistaDB4Provider":
            //        VistaDB.Provider.VistaDBConnection vdb =
            //            new VistaDB.Provider.VistaDBConnection(coll.es.Connection.ConnectionString);
            //        context = new DataContext(vdb);
            //        break;

            //    default:
            //        context = new DataContext(coll.es.Connection.ConnectionString);
            //        break;
            //}

            //var linqQuery = context.GetTable<Employee>().Where(s => s.LastName != "Doe")
            //    .OrderBy(s => s.LastName);

            //coll.Load(context, linqQuery);

            //foreach (Employee emp in coll)
            //{
            //    Assert.IsFalse(String.IsNullOrEmpty(emp.LastName));
            //}

            //Assert.AreEqual(4, coll.Count);
        }
    }
}
