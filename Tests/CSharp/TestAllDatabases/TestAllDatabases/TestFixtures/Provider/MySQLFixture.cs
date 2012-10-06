//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using NUnit.Framework;
//using Adapdev.UnitTest;
using EntitySpaces.Interfaces;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class MySQLFixture
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
		public void MySQLNumericTypeTest()
		{
			MysqltypetestCollection datatypeTestColl = new MysqltypetestCollection();
			Mysqltypetest datatypeTest = new Mysqltypetest();

			// There is a bug in the 1.0.7 Connector/Net for unsigned types.
			// It is fixed in 5.0.3.
            switch (datatypeTestColl.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MySqlClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        datatypeTest.BigIntType = -1;
                        datatypeTest.BigIntUType = 1;
                        datatypeTest.DblType = -1;
                        datatypeTest.DblUType = 1;
                        datatypeTest.DecType = (decimal)(-1.5);
                        datatypeTest.DecUType = (decimal)(1.5);
                        datatypeTest.FloatType = (float)(-1.5);
                        datatypeTest.FloatUType = (float)(1.5);
                        datatypeTest.IntType = -1;
                        datatypeTest.IntUType = 1;
                        datatypeTest.MedIntType = -1;
                        datatypeTest.MedIntUType = 1;
                        datatypeTest.NumType = (decimal)(-1.5);
                        datatypeTest.NumUType = (decimal)(1.5);
                        datatypeTest.RealType = -1.5;
                        datatypeTest.RealUType = 1.5;
                        datatypeTest.SmallIntType = -1;
                        datatypeTest.SmallIntUType = 1;
                        datatypeTest.TinyIntType = (sbyte)(1);
                        datatypeTest.TinyIntUType = Convert.ToByte(1);

                        datatypeTest.Save();

                        int? tempKey = datatypeTest.Id;
                        Assert.IsTrue(datatypeTest.LoadByPrimaryKey(tempKey.Value));
                        datatypeTest.MarkAsDeleted();
                        datatypeTest.Save();
                    }
					break;

				default:
					Assert.Ignore("MySQL only");
					break;
			}
		}

        [Test]
        public void MySQLUnicodeTest()
        {
            MySqlUnicodeTestCollection collection = new MySqlUnicodeTestCollection();

            if (collection.es.Connection.ProviderMetadataKey ==
                "esMySQL" && collection.es.Connection.SqlAccessType ==
                EntitySpaces.Interfaces.esSqlAccessType.DynamicSQL)
            {
                try
                {
                    uint uniKey;

                    MySqlUnicodeTest uniTest = collection.AddNew();
                    uniTest.VarCharType = "Hello ££ World";
                    uniTest.TextType = "Hello ££ World";
                    collection.Save();
                    uniKey = uniTest.TypeID.Value;

                    uniTest = new MySqlUnicodeTest();
                    uniTest.LoadByPrimaryKey(uniKey);
                    Assert.AreEqual("££", uniTest.VarCharType.Substring(6, 2));
                    Assert.AreEqual(14, uniTest.VarCharType.Length);
                    Assert.AreEqual("££", uniTest.TextType.Substring(6, 2));
                    Assert.AreEqual(14, uniTest.TextType.Length);

                    // Clean up
                    uniTest.MarkAsDeleted();
                    uniTest.Save();
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.ToString());
                }
            }
            else
            {
                    Assert.Ignore("MySQL Dynamic only");
            }
        }

        [Test]
        public void MySQLBinaryTest()
        {
            Mysqltypetest2Collection collection = new Mysqltypetest2Collection();

            if (collection.es.Connection.ProviderMetadataKey ==
                "esMySQL" && collection.es.Connection.SqlAccessType ==
                EntitySpaces.Interfaces.esSqlAccessType.DynamicSQL)
            {
                try
                {
                    Mysqltypetest2 datatypeTest = new Mysqltypetest2();

                    datatypeTest.LoadByPrimaryKey(1);
                    Assert.AreEqual("Hello", datatypeTest.BinaryType.TrimEnd('\0'));
                    Assert.AreEqual("Hello 2", datatypeTest.VarBinaryType);

                    datatypeTest = new Mysqltypetest2();
                    datatypeTest.BinaryType = "Testing";
                    datatypeTest.VarBinaryType = "Testing 2";
                    datatypeTest.Save();
                    uint typeKey = datatypeTest.Id.Value;

                    datatypeTest = new Mysqltypetest2();
                    datatypeTest.LoadByPrimaryKey(typeKey);
                    Assert.AreEqual("Testing", datatypeTest.BinaryType.TrimEnd('\0'));
                    Assert.AreEqual("Testing 2", datatypeTest.VarBinaryType);

                    // Clean up
                    datatypeTest.MarkAsDeleted();
                    datatypeTest.Save();
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.ToString());
                }
            }
            else
            {
                Assert.Ignore("MySQL Dynamic only");
            }
        }

        [Test]
        public void UnsignedAutoIncrement()
        {
            Mysqltypetest2Collection coll = new Mysqltypetest2Collection();

            // There is a bug in the 1.0.7 Connector/Net for unsigned types.
            // It is fixed in 5.0.3.
            switch (coll.es.Connection.ProviderSignature.DataProviderName)
            {
                case "EntitySpaces.MySqlClientProvider":
                    using (esTransactionScope scope = new esTransactionScope())
                    {
                        Mysqltypetest2 datatypeTest = new Mysqltypetest2();
                        datatypeTest.CharType = "X";
                        datatypeTest.VarCharType = "xxx";
                        datatypeTest.str().DateType = "2007-01-01";
                        datatypeTest.str().DateTimeType = "2006-12-31 11:59:30";
                        datatypeTest.TextType = "Some test text.";
                        datatypeTest.str().TimeType = "12:34:56.789";
                        datatypeTest.LongTextType = "Some more test text.";

                        datatypeTest.Save();

                        uint? tempKey = datatypeTest.Id;
                        Assert.IsTrue(datatypeTest.LoadByPrimaryKey(tempKey.Value));
                        datatypeTest.MarkAsDeleted();
                        datatypeTest.Save();
                    }
                    break;

                default:
                    Assert.Ignore("MySQL only");
                    break;
            }
        }

    }
}
