//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class OneToOneFixture
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
			CustomerGroup cg = new CustomerGroup();
            cg.es.Connection.Name = "ForeignKeyTest";

            Assert.IsTrue(cg.LoadByPrimaryKey("05001"));
			Assert.IsTrue(cg.Group.es.HasData);
		}

		[Test]
		public void TestUpTo()
		{
			Group g = new Group();
            g.es.Connection.Name = "ForeignKeyTest";

            g.LoadByPrimaryKey("05001");
			Assert.IsTrue(g.UpToCustomerGroup.es.HasData);
		}

		[Test]
		public void TestNullReferences()
		{
			CustomerGroup cg = new CustomerGroup();
            cg.es.Connection.Name = "ForeignKeyTest";

            cg.LoadByPrimaryKey("99999");
			Assert.IsFalse(cg.Group.es.HasData);
		}

		[Test]
		public void TestSaveWithAutoKey()
		{
            int terrKey = -1;
            Territory terr = new Territory();
            terr.es.Connection.Name = "ForeignKeyTest";
            TerritoryEx terrEx = new TerritoryEx();
            terrEx.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    terr.Description = "Some New Territory";

                    terrEx = terr.TerritoryEx;
                    terrEx.Notes = "Test Group";

                    terr.Save();

                    terrKey = terr.TerritoryID.Value;

                    Assert.IsTrue(terr.TerritoryEx.es.HasData);
                    Assert.AreEqual(terr.TerritoryID.Value, terrEx.TerritoryID.Value);

                    terr = new Territory();
                    terr.es.Connection.Name = "ForeignKeyTest";

                    Assert.IsTrue(terr.LoadByPrimaryKey(terrKey));
                    Assert.IsTrue(terr.TerritoryEx.es.HasData);
                }
            }
            finally
            {
                // Clean up
                terr = new Territory();
                terr.es.Connection.Name = "ForeignKeyTest";

                if (terr.LoadByPrimaryKey(terrKey))
                {
                    terrEx = terr.TerritoryEx;
                    terrEx.MarkAsDeleted();
                    terr.MarkAsDeleted();
                    terr.Save();
                }
            }
		}

		[Test]
		public void TestSaveWithoutAutoKey()
		{
            CustomerGroup cg = new CustomerGroup();
            cg.es.Connection.Name = "ForeignKeyTest";
            Group g = new Group();
            g.es.Connection.Name = "ForeignKeyTest";

            try
            {
                using (esTransactionScope scope = new esTransactionScope())
                {
                    cg.GroupID = "XXXXy";
                    cg.GroupName = "Test Group";

                    g = cg.Group;
                    g.Id = cg.GroupID;
                    g.Notes = "Some Text";

                    cg.Save();

                    Assert.IsTrue(cg.Group.es.HasData);
                    Assert.AreEqual(cg.GroupID, cg.Group.Id);
                }
            }
            finally
            {
                // Clean up
                cg = new CustomerGroup();
                cg.es.Connection.Name = "ForeignKeyTest";

                if (cg.LoadByPrimaryKey("XXXXy"))
                {
                    g = cg.Group;
                    g.MarkAsDeleted();
                    cg.MarkAsDeleted();
                    cg.Save();
                }
            }
		}
	}
}
