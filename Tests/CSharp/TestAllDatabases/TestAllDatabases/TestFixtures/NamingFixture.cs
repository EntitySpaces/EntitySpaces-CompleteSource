//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class NamingFixture
	{
		NamingTestCollection namingTestColl = new NamingTestCollection();
        NamingTest namingTest = new NamingTest();
		
		[TestFixtureSetUp]
		public void Init()
		{
        }

		[SetUp]
		public void Init2()
		{
			namingTestColl = new NamingTestCollection();
            namingTest = new NamingTest();
            // The table Naming.Test has a 'dot' in it,
            // so that is being tested as well.
            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTestColl.LoadAll();
                    namingTestColl.MarkAllAsDeleted();
                    namingTestColl.Save();
                    break;

                default:
                    break;
            }
        }

		[Test]
		public void ColumnWithSpaceAndAlias()
		{
            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTest = namingTestColl.AddNew();
					namingTest.str().TestAliasSpace = "AliasSpace";
					namingTestColl.Save();
					Assert.IsTrue(namingTestColl.LoadAll());
					Assert.AreEqual(1, namingTestColl.Count);
					break;

				default:
					Assert.Ignore("Database not set up, yet.");
					break;
			}
		}

        [Test]
        public void ColumnWithDot()
        {
            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTest = namingTestColl.AddNew();
                    namingTest.str().TestFieldDot = "FieldDot";
                    namingTestColl.Save();
                    Assert.IsTrue(namingTestColl.LoadAll());
                    Assert.AreEqual(1, namingTestColl.Count);
                    break;

                default:
                    Assert.Ignore("Database not set up, yet.");
                    break;
            }
        }

        [Test]
        public void ColumnWithDotAndSetGuids()
        {
            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    Guid keyGuid = Guid.NewGuid();
                    namingTest = namingTestColl.AddNew();
                    namingTest.GuidKeyAlias = keyGuid;
                    namingTest.str().TestFieldDot = "FieldDot";
                    namingTestColl.Save();
                    Assert.IsTrue(namingTestColl.LoadAll());
                    Assert.AreEqual(1, namingTestColl.Count);
                    Assert.AreEqual(namingTestColl[0].GuidKeyAlias.Value, keyGuid);
                    break;

                default:
                    Assert.Ignore("Database not set up, yet.");
                    break;
            }
        }

        [Test]
		public void ColumnWithUnderScoreAndAlias()
		{
            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTest = namingTestColl.AddNew();
                    namingTest.str().Test_Alias_Underscore = "AliasUnder";
                    namingTestColl.Save();
                    Assert.IsTrue(namingTestColl.LoadAll());
                    Assert.AreEqual(1, namingTestColl.Count);
                    break;

                default:
                    Assert.Ignore("Database not set up, yet.");
                    break;
            }
		}

		[Test]
		public void ColumnWithSpaceWithoutAlias()
		{
            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTest = namingTestColl.AddNew();
					namingTest.str().TestFieldSpace = "FieldSpace";
					namingTestColl.Save();
					Assert.IsTrue(namingTestColl.LoadAll());
					Assert.AreEqual(1, namingTestColl.Count);
					break;

				default:
					Assert.Ignore("Database not set up, yet.");
					break;
			}
		}

		[Test]
		public void ColumnWithUnderScoreWithoutAlias()
		{
            switch (namingTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.SqlClientProvider":
                    namingTest = namingTestColl.AddNew();
					namingTest.str().TestFieldUnderscore = "FieldUnder";
					namingTestColl.Save();
					Assert.IsTrue(namingTestColl.LoadAll());
					Assert.AreEqual(1, namingTestColl.Count);
					break;

				default:
					Assert.Ignore("Database not set up, yet.");
					break;
			}
		}
    }
}
