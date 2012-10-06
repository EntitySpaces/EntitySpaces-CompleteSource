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
	public class MetadataFixture
	{
		AggregateTestCollection aggTestColl = new AggregateTestCollection();
		AggregateTest aggTest = new AggregateTest();
		AggregateTestQuery aggTestQuery = new AggregateTestQuery();

		[TestFixtureSetUp]
		public void Init()
		{
		}

		[SetUp]
		public void Init2()
		{
			aggTestColl = new AggregateTestCollection();
			aggTest = new AggregateTest();
			aggTestQuery = new AggregateTestQuery();
		}

		[Test]
		public void DescriptionWithDoubleQuote()
		{
			ComputedTest comp = new ComputedTest();

            switch (comp.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
//                  comp.AddNew();
                    string desc = comp.GetDescriptionDoubleQuoteTest();

                    Assert.AreEqual("See \"this\"", desc);
                    break;

                default:
                    Assert.Ignore("Tested for SQL Server only.");
                    break;
            }
		}

		[Test]
		public void DescriptionWithBackSlash()
		{
			ComputedTest comp = new ComputedTest();

            switch (comp.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
					string desc = comp.GetDescriptionBackSlashTest();

					Assert.AreEqual("See C:\\this", desc);
                    break;

                default:
                    Assert.Ignore("Tested for SQL Server only.");
                    break;
            }
		}

		[Test]
		public void GetColumnName()
		{
			AggregateTestMetadata meta = AggregateTestMetadata.Meta();

			foreach (esColumnMetadata col in meta.Columns)
			{
				string colName = col.Name;
				Assert.IsTrue(colName != string.Empty);
			}
		}

        [Test]
        public void GetColumnWithAliasEntity()
        {
            AggregateTest entity = new AggregateTest();
            entity.Query.es.CountAll = true;
            entity.Query.es.CountAllAlias = "Count";
            entity.Query.Load();

            Assert.AreEqual(30, Convert.ToInt32(entity.GetColumn("Count")));
        }

        [Test]
        public void GetColumnWithAliasEntityView()
        {
            FullNameView entity = new FullNameView();

            if (entity.es.Connection.Name == "SqlCe"
                || entity.es.Connection.ProviderMetadataKey ==
                "esSqlCe4"
                || entity.es.Connection.ProviderMetadataKey ==
                "esSqlCe")
            {
                Assert.Ignore("Not tested for SqlCe.");
            }
            else
            {
                entity.Query.es.CountAll = true;
                entity.Query.es.CountAllAlias = "Count";
                entity.Query.Load();

                Assert.AreEqual(16, Convert.ToInt32(entity.GetColumn("Count")));
            }
        }

        [Test]
        public void GetColumnWithAliasCollection()
        {
            AggregateTestCollection coll = new AggregateTestCollection();
            coll.Query.es.CountAll = true;
            coll.Query.es.CountAllAlias = "Count";
            coll.Query.Load();

            Assert.AreEqual(30, Convert.ToInt32(coll[0].GetColumn("Count")));
        }

        [Test]
		public void ChangeMetadata()
		{
			AggregateTest entity = new AggregateTest();

			Assert.IsTrue(entity.GetAutoKey() == true);
			entity.ToggleAutoKey();
			Assert.IsTrue(entity.GetAutoKey() == false);
			entity.ToggleAutoKey();
			Assert.IsTrue(entity.GetAutoKey() == true);
		}

        [Test]
        public void ConfigNotReadOnly()
        {
            AggregateTest entity = new AggregateTest();
            Assert.AreEqual("AggregateDb", entity.es.Connection.Name);

            string oldDefault = esConfigSettings.ConnectionInfo.Default;
            esConfigSettings.ConnectionInfo.Default = "ForeignKeyTest";

            entity = new AggregateTest();
            Assert.AreEqual("ForeignKeyTest", entity.es.Connection.Name);

            if (entity.es.Connection.ProviderSignature.DataProviderName == "EntitySpaces.OracleClientProvider")
            {
                Assert.IsTrue(entity.es.Connection.ConnectionString.ToLower().Contains("hierarchical"));
            }
            else
            {
                Assert.IsTrue(entity.es.Connection.ConnectionString.ToLower().Contains("foreignkeytest"));
            }

            entity.es.Connection.ConnectionString = "Test";
            Assert.AreEqual("Test", entity.es.Connection.ConnectionString);

            esConfigSettings.ConnectionInfo.Default = oldDefault;
        }
    }
}
