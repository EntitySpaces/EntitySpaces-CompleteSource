//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;

using EntitySpaces.Interfaces;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class StoredProcFixture
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

		#region ExecuteNonQuery

		[Test]
		public void ExecuteNonQueryNoParams()
		{
			if (aggTestColl.es.Connection.SqlAccessType ==
				EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
			{
				try
				{
					int rowsAffected = aggTestColl.CustomExecuteNonQueryNoParams();
                    switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
                    {
                        case "EntitySpaces.MSAccessProvider":
                        case "EntitySpaces.MySqlClientProvider":
                            Assert.AreEqual(0, rowsAffected);
							break;
						default:
							Assert.AreEqual(-1, rowsAffected);
							break;
					}
				}
				catch (Exception ex)
				{
					Assert.Fail(ex.ToString());
				}
			}
			else
			{
				Assert.Ignore("Stored procedure mode only.");
			}
		}

		[Test]
		public void ExecuteNonQueryNoParamsWithCatalog()
		{
			if (aggTestColl.es.Connection.SqlAccessType ==
				EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
			{
				try
				{
					int rowsAffected = aggTestColl.CustomExecuteNonQueryNoParamsWithCatalog();
                    switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
                    {
                        case "EntitySpaces.MSAccessProvider":
                        case "EntitySpaces.MySqlClientProvider":
                            Assert.AreEqual(0, rowsAffected);
							break;
						default:
							Assert.AreEqual(-1, rowsAffected);
							break;
					}
				}
				catch (Exception ex)
				{
					Assert.Fail(ex.ToString());
				}
			}
			else
			{
                Assert.Ignore("Stored procedure mode only.");
            }
		}

		#endregion

		#region ExecuteReader

		[Test]
		public void ExecuteReaderNoParams()
		{
			if (aggTestColl.es.Connection.SqlAccessType ==
				EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
			{
				try
				{
					int i = 0;
					IDataReader rdr = aggTestColl.CustomExecuteReaderNoParams();
					Assert.AreEqual(8, rdr.FieldCount);
					while (rdr.Read())
					{
						i++;
					}
					rdr.Close();
					Assert.AreEqual(30, i);
				}
				catch (Exception ex)
				{
					Assert.Fail(ex.ToString());
				}
			}
			else
			{
                Assert.Ignore("Stored procedure mode only.");
            }
		}

		#endregion

		#region ExecuteScalar

		[Test]
		public void ExecuteScalarNoParams()
		{
			if (aggTestColl.es.Connection.SqlAccessType ==
				EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
            {
				try
				{
					string result = aggTestColl.CustomExecuteScalarNoParams();
					Assert.IsTrue(result.Length != 0);
				}
				catch (Exception ex)
				{
					Assert.Fail(ex.ToString());
				}
			}
			else
			{
                Assert.Ignore("Stored procedure mode only.");
            }
		}

		#endregion

		#region FillDataSet

		[Test]
		public void FillDataSetNoParams()
		{
			if (aggTestColl.es.Connection.SqlAccessType ==
				EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
			{
				try
				{
					DataSet testDataSet = aggTestColl.CustomFillDataSetNoParams();
					Assert.AreEqual(30, testDataSet.Tables[0].DefaultView.Count);
				}
				catch (Exception ex)
				{
					Assert.Fail(ex.ToString());
				}
			}
			else
			{
                Assert.Ignore("Stored procedure mode only.");
            }
		}

		#endregion

		#region FillDataTable

		[Test]
		public void FillDataTableNoParams()
		{
			if (aggTestColl.es.Connection.SqlAccessType ==
				EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
			{
				try
				{
					DataTable testTable = aggTestColl.CustomFillDataTableNoParams();
					Assert.AreEqual(30, testTable.DefaultView.Count);
				}
				catch (Exception ex)
				{
					Assert.Fail(ex.ToString());
				}
			}
			else
			{
                Assert.Ignore("Stored procedure mode only.");
            }
		}

		#endregion

		[Test]
		public void StoredProcWithOutputParams()
		{
			if (aggTestColl.es.Connection.SqlAccessType ==
				EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
			{
				try
				{
					aggTest.Query
						.Select()
						.Where
						(
							aggTest.Query.FirstName.Equal("Sarah"),
							aggTest.Query.LastName.Equal("Doe")
						);
					Assert.IsTrue(aggTest.Query.Load());
					int primaryKey = aggTest.Id.Value;

					string fullName = aggTestColl.GetFullName(primaryKey);

					Assert.AreEqual("Doe, Sarah", fullName);
				}
				catch (Exception ex)
				{
					Assert.Fail(ex.ToString());
				}
			}
			else
			{
                Assert.Ignore("Stored procedure mode only.");
            }
		}

        [Test]
        public void TestScaleAndPrecision()
        {
            try
            {
                switch (aggTestColl.es.Connection.ProviderSignature.DataProviderName)
                {
                    case "EntitySpaces.MSAccessProvider":
                    case "EntitySpaces.MySqlClientProvider":
                    case "EntitySpaces.NpgsqlProvider":
                    case "EntitySpaces.Npgsql2Provider":
                    case "EntitySpaces.OracleClientProvider":
                    case "EntitySpaces.SQLiteProvider":
                    case "EntitySpaces.SqlServerCeProvider":
                    case "EntitySpaces.SqlServerCe4Provider":
                    case "EntitySpaces.SybaseSqlAnywhereProvider":
                    case "EntitySpaces.VistaDBProvider":
                    case "EntitySpaces.VistaDB4Provider":
                        Assert.Ignore("Not implemented.");
                        break;
                    default:
                        if (aggTestColl.es.Connection.SqlAccessType != esSqlAccessType.StoredProcedure)
                        {
                            Assert.Ignore("Stored procedure test only.");
                        }

                        aggTestColl.TestParamsWithScale();
                        aggTestColl.Query.Where(
                            aggTestColl.Query.LastName == "Spaces",
                            aggTestColl.Query.FirstName == "Entity");
                        aggTestColl.Query.Load();
                        Assert.AreEqual(1, aggTestColl.Count);
                        aggTestColl.MarkAllAsDeleted();
                        aggTestColl.Save();
                        break;
                }
            }
            catch (IgnoreException exIgnore)
            {
                Assert.Ignore(exIgnore.Message.ToString());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

        [Test]
        public void TestNullParams()
        {
            if (aggTestColl.es.Connection.SqlAccessType ==
                EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure)
            {
                aggTestColl.TestNullParams();

                aggTestColl.Query.Where(
                    aggTestColl.Query.LastName == "NullTest");
                aggTestColl.Query.Load();

                Assert.AreEqual(1, aggTestColl.Count);

                // Cleanup
                aggTestColl.MarkAllAsDeleted();
                aggTestColl.Save();
            }
            else
            {
                    Assert.Ignore("Stored Procedure mode only.");
            }
        }

    }
}
