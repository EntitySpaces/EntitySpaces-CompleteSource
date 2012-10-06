//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;
using EntitySpaces.Interfaces;

namespace Tests.Base
{
	[TestFixture]
	public class ManyToManyFixture
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
		public void TestReferences()
		{
			Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

			emp.LoadByPrimaryKey(1);
			Assert.AreEqual(3, emp.UpToTerritoryCollection.Count);
		}

		[Test]
		public void TestNullReferences()
		{
			Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

			emp.LoadByPrimaryKey(5);
			Assert.AreEqual(0, emp.UpToTerritoryCollection.Count);
		}

		[Test]
		public void TestAssociateDissociateNew()
		{
            int terrKey = -1;
            int empKey = -1;

            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";
            Territory terr = new Territory();
            terr.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    emp.LastName = "Test Last";
                    emp.FirstName = "Test First";

                    terr.Description = "Some New Territory";
                    terr.Save();
                    terrKey = terr.TerritoryID.Value;

                    emp.AssociateTerritoryCollection(terr);
                    emp.Save();
                    empKey = emp.EmployeeID.Value;

                    Assert.AreEqual(1, emp.UpToTerritoryCollection.Count);
                    foreach (EmployeeTerritory et in emp.EmployeeTerritoryCollectionByEmpID)
                    {
                        Assert.AreEqual(terr.TerritoryID.Value, et.TerrID.Value);
                    }
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(empKey))
                {
                    foreach (Territory t in emp.UpToTerritoryCollection)
                    {
                        emp.DissociateTerritoryCollection(t);
                    }
                    emp.MarkAsDeleted();
                    emp.Save();
                }

                terr = new Territory();
                terr.es.Connection.Name = "ForeignKeyTest";

                if (terr.LoadByPrimaryKey(terrKey))
                {
                    terr.MarkAsDeleted();
                    terr.Save();
                }
            }
		}

        [Test]
        public void TestAssociateDissociateNewComposite()
        {
            Course c = new Course();
            c.es.Connection.Name = "ForeignKeyTest";
            Student s = new Student();
            s.es.Connection.Name = "ForeignKeyTest";

            switch (c.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        s.S1 = "a";
                        s.S2 = "b";
                        s.StudentName = "Test Student";

                        c.C1 = 1;
                        c.C2 = "b";
                        c.ClassName = "Test Class";
                        c.Save();

                        s.AssociateCourseCollection(c);
                        s.Save();

                        Assert.AreEqual(1, c.UpToStudentCollection.Count);
                        Assert.AreEqual(1, s.UpToCourseCollection.Count);

                        foreach (StudentClass sc in s.StudentClassCollectionBySid1)
                        {
                            Assert.AreEqual(c.C1.Value, sc.Cid1.Value);
                            Assert.AreEqual(c.C2.Trim(), sc.Cid2.Trim());
                            Assert.AreEqual(s.S1.Trim(), sc.Sid1.Trim());
                            Assert.AreEqual(s.S2.Trim(), sc.Sid2.Trim());
                        }

                        s.DissociateCourseCollection(c);
                        s.Save();

                        s.UpToCourseCollection = null;
                        c.UpToStudentCollection = null;
                        Assert.AreEqual(0, c.UpToStudentCollection.Count);
                        Assert.AreEqual(0, s.UpToCourseCollection.Count);
                    }
                    break;

                default:
                    Assert.Ignore("Not tested");
                    break;
            }
        }

        [Test]
        public void TestAssociateDissociate()
        {
            int empKey = -1;
            Territory terr = new Territory();
            terr.es.Connection.Name = "ForeignKeyTest";
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    int terrKey = 1;
                    terr.LoadByPrimaryKey(terrKey);

                    emp.LastName = "Test Last";
                    emp.FirstName = "Test First";

                    emp.AssociateTerritoryCollection(terr);
                    emp.Save();
                    empKey = emp.EmployeeID.Value;

                    Assert.AreEqual(1, emp.UpToTerritoryCollection.Count);
                    foreach (EmployeeTerritory et in emp.EmployeeTerritoryCollectionByEmpID)
                    {
                        Assert.AreEqual(terr.TerritoryID.Value, et.TerrID.Value);
                    }
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(empKey))
                {
                    foreach (Territory t in emp.UpToTerritoryCollection)
                    {
                        emp.DissociateTerritoryCollection(t);
                    }
                    emp.MarkAsDeleted();
                    emp.Save();
                }
            }
        }

        [Test]
        public void TestSettingNull()
        {
            Employee emp = new Employee();
            emp.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    emp.LoadByPrimaryKey(5);
                    Assert.AreEqual(0, emp.UpToTerritoryCollection.Count);

                    Territory terr = new Territory();
                    terr.es.Connection.Name = "ForeignKeyTest";

                    terr.LoadByPrimaryKey(1);

                    emp.AssociateTerritoryCollection(terr);
                    emp.Save();

                    Assert.AreEqual(0, emp.UpToTerritoryCollection.Count);
                    emp.UpToTerritoryCollection = null;
                    Assert.AreEqual(1, emp.UpToTerritoryCollection.Count);
                }
            }
            finally
            {
                // Clean up
                emp = new Employee();
                emp.es.Connection.Name = "ForeignKeyTest";

                if (emp.LoadByPrimaryKey(5))
                {
                    foreach (Territory t in emp.UpToTerritoryCollection)
                    {
                        emp.DissociateTerritoryCollection(t);
                    }
                    emp.Save();
                }
            }
        }
    }
}
