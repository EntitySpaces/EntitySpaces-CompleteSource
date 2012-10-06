//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.Data;
using System.IO;

using NUnit.Framework;
//using Adapdev.UnitTest;
using BusinessObjects;

namespace Tests.Base
{
	[TestFixture]
	public class SpecialTextFunctionsFixture
	{
        AggregateTestCollection aggTestColl = new AggregateTestCollection();
        AggregateTest aggTest = new AggregateTest();
		
		[TestFixtureSetUp]
		public void Init()
		{
		}

		[SetUp]
		public void Init2()
		{
            aggTestColl = new AggregateTestCollection();
            aggTest = new AggregateTest();
		}

		#region ExecuteNonQuery

		[Test]
		public void ExecuteNonQueryText()
		{
			try
			{
				int rowsAffected = aggTestColl.CustomExecuteNonQueryText("EntitySpaces");
				Assert.AreEqual(1, rowsAffected);

				rowsAffected = aggTestColl.CustomExecuteNonQueryText("Sarah");
				Assert.AreEqual(1, rowsAffected);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

		[Test]
		public void ExecuteNonQueryTextEsParams()
		{
			try
			{
				int rowsAffected = aggTestColl.CustomExecuteNonQueryTextEsParams("EntitySpaces");
				Assert.AreEqual(1, rowsAffected);

				rowsAffected = aggTestColl.CustomExecuteNonQueryTextEsParams("Sarah");
				Assert.AreEqual(1, rowsAffected);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

		#endregion

		#region ExecuteReader

		[Test]
		public void ExecuteReaderTextEsParams()
		{
			try
			{
				int i = 0;
				IDataReader rdr = aggTestColl.CustomExecuteReaderTextEsParams();
				Assert.AreEqual(8, rdr.FieldCount);
				while (rdr.Read())
				{
					i++;
				}
                Assert.AreEqual(3, i);
                rdr.Close();
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

		#endregion

		#region ExecuteScalar

		[Test]
		public void ExecuteScalarTextEsParams()
		{
			try
			{
				int nameCount = aggTestColl.CustomExecuteScalarTextEsParams();
				Assert.AreEqual(3, nameCount);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

		#endregion

		#region FillDataSet

		[Test]
		public void FillDataSetTextNoParams()
		{
			try
			{
				string lastName = "Doe";
				DataSet testDataSet = aggTestColl.CustomFillDataSetTextNoParams(lastName);
				Assert.AreEqual(3, testDataSet.Tables[0].DefaultView.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

		[Test]
		public void FillDataSetText()
		{
			try
			{
				DataSet testDataSet = aggTestColl.CustomFillDataSetText();
				Assert.AreEqual(3, testDataSet.Tables[0].DefaultView.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

		#endregion

		#region FillDataTable

		[Test]
		public void FillDataTableText()
		{
			try
			{
				DataTable testTable = aggTestColl.CustomFillDataTableText();
				Assert.AreEqual(6, testTable.DefaultView.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.ToString());
			}
		}

		#endregion

	}
}
