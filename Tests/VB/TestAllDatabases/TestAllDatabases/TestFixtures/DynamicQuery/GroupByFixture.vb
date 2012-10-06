'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================


Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Namespace Tests.Base
	<TestFixture> _
	Public Class GroupByFixture
		Private aggTestColl As New AggregateTestCollection()
		Private aggTest As New AggregateTest()
		Private aggTestQuery As New AggregateTestQuery()

		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
			aggTestColl = New AggregateTestCollection()
			aggTest = New AggregateTest()
			aggTestQuery = New AggregateTestQuery()
		End Sub

		<Test> _
		Public Sub OneGroupBy()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive).GroupBy(aggTestColl.Query.IsActive)
			Assert.IsTrue(aggTestColl.Query.Load())

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.AreEqual(2, aggTestColl.Count)
					Exit Select
				Case Else
					Assert.AreEqual(3, aggTestColl.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub TwoGroupBy()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(12, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub TwoGroupByWithHaving()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Having("<COUNT(*) > 1>")
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(7, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub HavingWithSimpleExpression()
			Dim coll As New OrderItemCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim q As New OrderItemQuery()
			q.[Select](q.OrderID, q.Quantity.Sum().[As]("TotalQty"))
			q.Where(q.Discount.IsNull())
			q.GroupBy(q.OrderID)

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					q.Having(q.Quantity.Sum() > 100)
					q.OrderBy("<TotalQty>", esOrderByDirection.Descending)
					Exit Select

				Case "EntitySpaces.SQLiteProvider"
					q.Having((q.Quantity * 1).Sum() > 100)
					q.OrderBy(q.Quantity.Sum().Descending)
					Exit Select
				Case Else

					q.Having(q.Quantity.Sum() > 100)
					q.OrderBy(q.Quantity.Sum().Descending)
					Exit Select
			End Select

            Assert.IsTrue(coll.Load(q), "Load")
			Assert.AreEqual(3, coll.Count, "Count")

			Dim qty As Integer = Convert.ToInt32(coll(0).GetColumn("TotalQty"))
			Assert.AreEqual(240, qty, "GetColumn")
		End Sub

		<Test> _
		Public Sub HavingWithComplexExpression()
			Dim coll As New OrderItemCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim q As New OrderItemQuery()
			q.[Select](q.OrderID, (q.Quantity * q.UnitPrice).Sum().[As]("TotalPrice"))
			q.Where(q.Discount.IsNull())
			q.GroupBy(q.OrderID)
			q.Having((q.Quantity * q.UnitPrice).Sum() > 500)

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					q.OrderBy("<TotalPrice>", esOrderByDirection.Descending)
					Exit Select
				Case Else

					q.OrderBy((q.Quantity * q.UnitPrice).Sum().Descending)
					Exit Select
			End Select

			Assert.IsTrue(coll.Load(q), "Load")
			Assert.AreEqual(2, coll.Count, "Count")

			Dim price As Decimal = Convert.ToDecimal(coll(0).GetColumn("TotalPrice"))
			Assert.AreEqual(1940.0D, price, "GetColumn")
		End Sub

		<Test> _
		Public Sub AggregateInOrderBy()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not supported")
					Exit Select
				Case Else

					aggTestColl.Query.[Select](aggTestColl.Query.DepartmentID, aggTestColl.Query.Salary.Min()).OrderBy(aggTestColl.Query.Salary.Descending).GroupBy(aggTestColl.Query.DepartmentID)
					aggTestColl.Query.Load()
					Exit Select
			End Select

			Dim test As New AggregateTest()

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
					test = DirectCast(aggTestColl(1), AggregateTest)
					Exit Select
				Case Else

					test = DirectCast(aggTestColl(0), AggregateTest)
					Exit Select
			End Select

			Assert.AreEqual(4, test.DepartmentID.Value)
			Assert.AreEqual(18.44, Math.Round(test.Salary.Value, 2))
		End Sub

		<Test> _
		Public Sub GroupByWithWhere()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithWhereAndOrderBy()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithOrderByCountAll()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy("<Count(*)>", esOrderByDirection.Ascending)
					Exit Select
				Case Else
					aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.es.CountAllAlias, esOrderByDirection.Ascending)
					Exit Select
			End Select

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithTop()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			aggTestColl.Query.es.Top = 3
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(aggTestColl.Query.es.Top, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithDistinct()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			aggTestColl.Query.es.Distinct = True
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithTearoff()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Sum().[As]("Sum"), aggTestColl.Query.Salary.Min().[As]("Min"), aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithRollup()
			If aggTestColl.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", _
						"EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not Supported")
						Exit Select
					' For MySQL GROUP BY and ORDER BY are mutually exclusive.
					Case "EntitySpaces.MySqlClientProvider"
						aggTestColl.Query.es.CountAll = True
						aggTestColl.Query.es.CountAllAlias = "Count"
						aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID)
						aggTestColl.Query.es.WithRollup = True
						Assert.IsTrue(aggTestColl.Query.Load())
						Assert.AreEqual(7, aggTestColl.Count)
						Exit Select
					Case Else
						aggTestColl.Query.es.CountAll = True
						aggTestColl.Query.es.CountAllAlias = "Count"
						aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
						aggTestColl.Query.es.WithRollup = True
						Assert.IsTrue(aggTestColl.Query.Load())
						Assert.AreEqual(7, aggTestColl.Count)
						Exit Select
				End Select
			End If
		End Sub

	End Class
End Namespace
