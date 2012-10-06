'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Namespace Tests.Base
	<TestFixture> _
	Public Class WhereFixture
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
		Public Sub SelectWithAlias()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.[As]("S2"), aggTestColl.Query.FirstName, aggTestColl.Query.FirstName.[As]("FN"))
			aggTestColl.Query.OrderBy(aggTestColl.Query.Id.Ascending)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(30, aggTestColl.Count)

			Dim aggControl As New AggregateTestCollection()
			aggControl.Query.OrderBy(aggControl.Query.Id.Ascending)
			aggControl.Query.Load()

			Dim i As Integer = 0
			For Each agg As AggregateTest In aggTestColl
				If aggControl(i).Salary.HasValue Then
					Assert.AreEqual(aggControl(i).Salary.Value, agg.GetColumn("S2"))
				Else
					Assert.AreEqual(Nothing, TryCast(agg.GetColumn("S2"), String))
				End If
				Assert.AreEqual(aggControl(i).FirstName, TryCast(agg.GetColumn("FN"), String))
				i += 1
			Next
		End Sub

		<Test> _
		Public Sub OrderByWithAlias()
			aggTestColl.Query.[Select](aggTestColl.Query.Age.[As]("A2"), aggTestColl.Query.FirstName, aggTestColl.Query.FirstName.[As]("FN"))

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Access cannot ORDER BY an alias")
					Exit Select
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
					aggTestColl.Query.OrderBy("<""A2"">", esOrderByDirection.Descending)
					Exit Select
				Case Else
					aggTestColl.Query.OrderBy("<A2>", esOrderByDirection.Descending)
					Exit Select
			End Select

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(30, aggTestColl.Count)

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
					Assert.AreEqual(45, aggTestColl(5).GetColumn("A2"))
					Exit Select
				Case Else
					Assert.AreEqual(45, aggTestColl(0).GetColumn("A2"))
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub OneWhere()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(True))
			Dim testTable As DataTable = aggTestColl.Query.LoadDataTable()
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count)
			Assert.AreEqual(8, testTable.Columns.Count)
		End Sub

		<Test> _
		Public Sub TwoWhere()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(True), aggTestColl.Query.LastName.Equal("Doe"))
			Dim testTable As DataTable = aggTestColl.Query.LoadDataTable()
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereWithOrderBy()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(True)).OrderBy(aggTestColl.Query.LastName.Ascending)
			Dim testTable As DataTable = aggTestColl.Query.LoadDataTable()
			Dim currRows As DataRow() = testTable.[Select](Nothing, Nothing, DataViewRowState.CurrentRows)
			Dim testRow As DataRow = currRows(0)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count)
			Assert.AreEqual("Costner", testRow("LastName"), "First Row")
			testRow = currRows(15)
			Assert.AreEqual("Vincent", testRow("LastName"), "Last Row")
		End Sub

		<Test> _
		Public Sub WhereEqual()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(False))
			Assert.IsTrue(aggTestColl.Query.Load())

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.AreEqual(14, aggTestColl.Count)
					Exit Select
				Case Else
					Assert.AreEqual(8, aggTestColl.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub WhereEqualOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive = False)
			Assert.IsTrue(aggTestColl.Query.Load())

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.AreEqual(14, aggTestColl.Count)
					Exit Select
				Case Else
					Assert.AreEqual(8, aggTestColl.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub WhereEqualDecimal()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary = 34.71)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotEqual()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.NotEqual(False))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotEqualOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive <> False)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereGreaterThan()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary.GreaterThan(25.03))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(12, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereGreaterThanOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary > 25.03)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(12, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereGreaterThanOrEqual()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary.GreaterThanOrEqual(25.03))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(13, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereGreaterThanOrEqualOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary >= 25.03)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(13, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLessThan()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.FirstName.LessThan("Jane"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(6, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLessThanOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.FirstName < "Jane")
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(6, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLessThanOrEqual()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.FirstName.LessThanOrEqual("Jane"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(9, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLessThanOrEqualOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.FirstName <= "Jane")
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(9, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLikeText()
			aggTestColl.Query.Where(aggTestColl.Query.FirstName.[Like]("J%"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLikeTextEscaped()
			Dim tempId As Integer = -1
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Try
						Using scope As New esTransactionScope()
							aggTest.LastName = "a 10% name"
							aggTest.Save()
							tempId = aggTest.Id.Value

							aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.[Like]("%10!%%", "!"C))
							Assert.IsTrue(aggTestColl.Query.Load())
							Assert.AreEqual(1, aggTestColl.Count)
						End Using
					Finally
						' Clean up
						aggTest = New AggregateTest()
						If aggTest.LoadByPrimaryKey(tempId) Then
							aggTest.MarkAsDeleted()
							aggTest.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub WhereNotLikeTextEscaped()
			Dim tempId As Integer = -1

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Try
						Using scope As New esTransactionScope()
							aggTest.LastName = "a 10% name"
							aggTest.Save()
							tempId = aggTest.Id.Value

							aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.NotLike("%10!%%", "!"C))
							Assert.IsTrue(aggTestColl.Query.Load())
							Assert.AreEqual(24, aggTestColl.Count)
						End Using
					Finally
						' Clean up
						aggTest = New AggregateTest()
						If aggTest.LoadByPrimaryKey(tempId) Then
							aggTest.MarkAsDeleted()
							aggTest.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub WhereLikeInteger()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Age.[Like]("%1%"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(9, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLikeNumeric()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary.[Like]("%1%"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(15, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereLikeDate()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[Like]("%4%"), aggTestColl.Query.HireDate.[Like]("%2002%"))
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[Like]("%APR%"), aggTestColl.Query.HireDate.[Like]("%02%"))
					Exit Select
				Case "EntitySpaces.MySqlClientProvider", "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.SQLiteProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[Like]("%-04-%"), aggTestColl.Query.HireDate.[Like]("%2002-%"))
					Exit Select
				Case Else
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[Like]("%apr%"), aggTestColl.Query.HireDate.[Like]("%2002%"))
					Exit Select
			End Select
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(3, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotLikeText()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.FirstName.NotLike("J%"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(19, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotLikeInteger()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Age.NotLike("%1%"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotLikeNumeric()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary.NotLike("%1%"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(10, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotLikeDate()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotLike("%4%"), aggTestColl.Query.HireDate.NotLike("%2002%"))
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotLike("%APR%"), aggTestColl.Query.HireDate.NotLike("%02%"))
					Exit Select
				Case "EntitySpaces.MySqlClientProvider", "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.SQLiteProvider"
					aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotLike("%-04-%"), aggTestColl.Query.HireDate.NotLike("%2002-%"))
					Exit Select
				Case Else
					aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotLike("%apr%"), aggTestColl.Query.HireDate.NotLike("%2002%"))
					Exit Select
			End Select
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(21, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereIsNull()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.IsNull())
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(6, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereIsNotNull()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.IsNotNull())
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(24, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereBetweenDate()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.Between(Convert.ToDateTime("2002-01-01"), Convert.ToDateTime("2002-12-31")))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(4, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereBetweenText()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.Between("Doe", "Johnson"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(9, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereBetweenInteger()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Age.Between(20, 30))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(6, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereBetweenNumeric()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary.Between(21.74, 26))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(4, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereInDate()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[In]("#2002-04-01#", "#2003-12-31#"))
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[In]("01-APR-02", "31-DEC-03"))
					Exit Select
				Case "EntitySpaces.MySqlClientProvider", "EntitySpaces.SybaseSqlAnywhereProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[In]("2002-04-01", "2003-12-31"))
					Exit Select
				Case "EntitySpaces.SQLiteProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[In]("2002-04-01 00:00:00", "2003-12-31 00:00:00"))
					Exit Select
				Case Else
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.[In](Convert.ToDateTime("2002-04-01").ToString(), Convert.ToDateTime("2003-12-31").ToString()))
					Exit Select
			End Select
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereInListText()
			Dim array As New ArrayList()
			array.Add("Test")
			array.Add("Test2")

			Dim anotherArray As New ArrayList()
			anotherArray.Add("Foo")
			anotherArray.Add("Four")

			Dim generic As New List(Of String)()
			generic.Add("Seven")
			generic.Add("Vincent")

			aggTestColl.Query.Where(aggTestColl.Query.LastName.[In]("Doe", array, "foo", anotherArray, generic))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereInText()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.[In]("Doe", "Vincent"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereInNumeric()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary.[In](25.03, 11.06))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereInListNumeric()
			Dim array As New ArrayList()
			array.Add(1)
			array.Add(2)

			Dim anotherArray As New ArrayList()
			anotherArray.Add(3)
			anotherArray.Add(25.03)

			Dim generic As New List(Of Integer)()
			generic.Add(5)
			generic.Add(6)

			aggTestColl.Query.Where(aggTestColl.Query.Salary.[In](7, array, 11.06, anotherArray, generic))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereInInteger()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Age.[In](16, 28))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(4, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotInDate()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotIn("#2002-04-01#", "#2003-12-31#"))
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotIn("01-APR-02", "31-DEC-03"))
					Exit Select
				Case "EntitySpaces.MySqlClientProvider", "EntitySpaces.SybaseSqlAnywhereProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotIn("2002-04-01", "2003-12-31"))
					Exit Select
				Case "EntitySpaces.SQLiteProvider"
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotIn("2002-04-01 00:00:00", "2003-12-31 00:00:00"))
					Exit Select
				Case Else
					aggTestColl.Query.[Select]().Where(aggTestColl.Query.HireDate.NotIn(Convert.ToDateTime("2002-04-01").ToString(), Convert.ToDateTime("2003-12-31").ToString()))
					Exit Select
			End Select
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(23, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotInListText()
			Dim array As New ArrayList()
			array.Add("Test")
			array.Add("Test2")

			Dim anotherArray As New ArrayList()
			anotherArray.Add("Foo")
			anotherArray.Add("Four")

			Dim generic As New List(Of String)()
			generic.Add("Seven")
			generic.Add("Vincent")

			aggTestColl.Query.Where(aggTestColl.Query.LastName.NotIn("Doe", array, "foo", anotherArray, generic))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(19, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotInText()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.NotIn("Doe", "Vincent"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(19, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotInNumeric()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Salary.NotIn(25.03, 11.06))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(23, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotInListNumeric()
			Dim array As New ArrayList()
			array.Add(1)
			array.Add(2)

			Dim anotherArray As New ArrayList()
			anotherArray.Add(3)
			anotherArray.Add(25.03)

			Dim generic As New List(Of Integer)()
			generic.Add(5)
			generic.Add(6)

			aggTestColl.Query.Where(aggTestColl.Query.Salary.NotIn(7, array, 11.06, anotherArray, generic))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(23, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereNotInInteger()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.Age.NotIn(16, 28))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(21, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereDefaultConjunction()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.[Like]("C%"), aggTestColl.Query.Age <= aggTestColl.Query.Salary)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereDefaultConjunctionOr()
			aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.[Like]("C%"), aggTestColl.Query.Age <= aggTestColl.Query.Salary)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(13, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereConjunctionAndOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.[Like]("C%") And aggTestColl.Query.Age <= aggTestColl.Query.Salary)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereConjunctionOrOperator()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.LastName.[Like]("C%") Or aggTestColl.Query.Age <= aggTestColl.Query.Salary)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(13, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereConjunctionAndNotOperator()
			Dim query As New AggregateTestQuery()

			query.Where(query.DepartmentID = 1 And Not (query.IsActive = True And query.Age = 28))

			Dim coll As New AggregateTestCollection()
			Assert.IsTrue(coll.Load(query))
			Assert.AreEqual(2, coll.Count)
		End Sub

		<Test> _
		Public Sub WhereConjunctionAndNotSeparateLines()
			Dim query As New AggregateTestQuery()

			query.Where(query.DepartmentID = 1)

			query.es.DefaultConjunction = esConjunction.AndNot
			query.Where(New esComparison(esParenthesis.Open))
			query.Where(query.IsActive = True)
			query.es.DefaultConjunction = esConjunction.[And]
			query.Where(query.Age = 28)
			query.Where(New esComparison(esParenthesis.Close))

			Dim coll As New AggregateTestCollection()
			Assert.IsTrue(coll.Load(query))
			Assert.AreEqual(2, coll.Count)
		End Sub

		<Test> _
		Public Sub WhereConjunctionAndNotNested()
			Dim query As New AggregateTestQuery()

			query.Where(query.AndNot(query.DepartmentID = 1, query.[And](query.IsActive = True, query.Age = 28)))

			Dim coll As New AggregateTestCollection()
			Assert.IsTrue(coll.Load(query))
			Assert.AreEqual(2, coll.Count)
		End Sub

		<Test> _
		Public Sub WhereConjunctionOrNotOperator()
			Dim query As New AggregateTestQuery()

			query.Where(query.DepartmentID = 1 Or Not (query.IsActive = True And query.Age = 28))

			Dim coll As New AggregateTestCollection()
			Assert.IsTrue(coll.Load(query))

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.AreEqual(29, coll.Count)
					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider", "EntitySpaces.SqlClientProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", _
					"EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.AreEqual(24, coll.Count)
					Exit Select
				Case Else

					Assert.AreEqual(24, coll.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub WhereConjunctionOrNotSeparateLines()
			Dim query As New AggregateTestQuery()

			query.Where(query.DepartmentID = 1)

			query.es.DefaultConjunction = esConjunction.OrNot
			query.Where(New esComparison(esParenthesis.Open))
			query.Where(query.IsActive = True)
			query.es.DefaultConjunction = esConjunction.[And]
			query.Where(query.Age = 28)
			query.Where(New esComparison(esParenthesis.Close))

			Dim coll As New AggregateTestCollection()
			Assert.IsTrue(coll.Load(query))

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.AreEqual(29, coll.Count)
					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider", "EntitySpaces.SqlClientProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", _
					"EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.AreEqual(24, coll.Count)
					Exit Select
				Case Else

					Assert.AreEqual(24, coll.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub WhereConjunctionOrNotNested()
			Dim query As New AggregateTestQuery()

			query.Where(query.OrNot(query.DepartmentID = 1, query.[And](query.IsActive = True, query.Age = 28)))

			Dim coll As New AggregateTestCollection()
			Assert.IsTrue(coll.Load(query))

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.AreEqual(29, coll.Count)
					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider", "EntitySpaces.SqlClientProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", _
					"EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.AreEqual(24, coll.Count)
					Exit Select
				Case Else

					Assert.AreEqual(24, coll.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub WhereMixAndOr()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.[Or](aggTestColl.Query.LastName.[Like]("C%"), aggTestColl.Query.LastName.[Like]("D%")), aggTestColl.Query.Age <= 30)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(4, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixAndOrOperators()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					aggTestColl.Query.Where((aggTestColl.Query.HireDate.[Date]() <= Convert.ToDateTime("2007-01-01") Or aggTestColl.Query.HireDate.IsNull()) And (aggTestColl.Query.LastName.[Like]("D%") Or aggTestColl.Query.LastName.IsNull()))
					Exit Select
				Case Else
					aggTestColl.Query.Where((aggTestColl.Query.HireDate.[Date]() <= "2007-01-01" Or aggTestColl.Query.HireDate.IsNull()) And (aggTestColl.Query.LastName.[Like]("D%") Or aggTestColl.Query.LastName.IsNull()))
					Exit Select
			End Select
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(10, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOr()
			aggTestColl.Query.Where(aggTestColl.Query.[Or](aggTestColl.Query.LastName.[Like]("D%"), aggTestColl.Query.LastName.[Like]("S%")), aggTestColl.Query.[Or](aggTestColl.Query.FirstName.[Like]("J%"), aggTestColl.Query.FirstName.[Like]("D%")))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiWithParen()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			collection.Query.[Select](collection.Query.EmployeeID, collection.Query.Supervisor, collection.Query.Age)

			collection.Query.Where(collection.Query.Age = 20)

			collection.Query.Where(New esComparison(esParenthesis.Open))

			collection.Query.es.DefaultConjunction = esConjunction.[Or]

			For i As Integer = 0 To 3
				collection.Query.Where(collection.Query.Supervisor = i And collection.Query.EmployeeID = i + 1)
			Next

			collection.Query.Where(New esComparison(esParenthesis.Close))

			Assert.IsTrue(collection.Query.Load())
			Assert.AreEqual(1, collection.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiWithParenNested()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			collection.Query.[Select](collection.Query.EmployeeID, collection.Query.Supervisor, collection.Query.Age)

			collection.Query.Where(collection.Query.Age = 30)

			collection.Query.Where(New esComparison(esParenthesis.Open))
			collection.Query.Where(New esComparison(esParenthesis.Open))

			collection.Query.es.DefaultConjunction = esConjunction.[Or]

			collection.Query.Where(collection.Query.EmployeeID = 1 And collection.Query.Supervisor.IsNull())
			collection.Query.Where(collection.Query.EmployeeID = 2 And collection.Query.Supervisor = 1)

			collection.Query.Where(New esComparison(esParenthesis.Close))
			collection.Query.es.DefaultConjunction = esConjunction.[And]
			collection.Query.Where(New esComparison(esParenthesis.Open))

			collection.Query.es.DefaultConjunction = esConjunction.[Or]

			collection.Query.Where(collection.Query.LastName = "Smith" And collection.Query.Supervisor.IsNull())
			collection.Query.Where(collection.Query.LastName = "Jones" And collection.Query.Supervisor = 1)

			collection.Query.Where(New esComparison(esParenthesis.Close))
			collection.Query.Where(New esComparison(esParenthesis.Close))

			Assert.IsTrue(collection.Query.Load())
			Assert.AreEqual(1, collection.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrDefaultOr()
			aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
			aggTestColl.Query.Where(aggTestColl.Query.[And](aggTestColl.Query.LastName.[Like]("%D%"), aggTestColl.Query.LastName.[Like]("%s%")), aggTestColl.Query.[And](aggTestColl.Query.FirstName.[Like]("%J%"), aggTestColl.Query.FirstName.[Like]("%D%")))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNested()
			aggTestColl.Query.Where(aggTestColl.Query.LastName.Equal("Doe"), aggTestColl.Query.FirstName = "David", aggTestColl.Query.[Or](aggTestColl.Query.[And](aggTestColl.Query.DepartmentID.Equal(3), aggTestColl.Query.Age.Equal(16)), aggTestColl.Query.[And](aggTestColl.Query.DepartmentID.Equal(4), aggTestColl.Query.Age.Equal(43))))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNested2()
			aggTestColl.Query.Where(aggTestColl.Query.[Or](aggTestColl.Query.LastName.[Like]("%e%"), aggTestColl.Query.FirstName.[Like]("%a%")), aggTestColl.Query.[And](aggTestColl.Query.[Or](aggTestColl.Query.DepartmentID.Equal(3), aggTestColl.Query.Age.Equal(16)), aggTestColl.Query.[Or](aggTestColl.Query.HireDate >= Convert.ToDateTime("2000-01-01"), aggTestColl.Query.Salary >= 15)))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(7, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNestedOperators()
			aggTestColl.Query.Where(aggTestColl.Query.LastName.Equal("Doe") And aggTestColl.Query.FirstName = "David" And ((aggTestColl.Query.DepartmentID.Equal(3) And aggTestColl.Query.Age.Equal(16)) Or (aggTestColl.Query.DepartmentID.Equal(4) And aggTestColl.Query.Age.Equal(43))))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNestedOperators2()
			aggTestColl.Query.Where((aggTestColl.Query.LastName.[Like]("%e%") Or aggTestColl.Query.FirstName.[Like]("%a%")) And ((aggTestColl.Query.DepartmentID.Equal(3) Or aggTestColl.Query.Age.Equal(16)) And (aggTestColl.Query.HireDate >= Convert.ToDateTime("2000-01-01") Or aggTestColl.Query.Salary >= 15)))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(7, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereCompareColumns()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else

					aggTestColl.Query.[Select]().Where(aggTestColl.Query.Age <= aggTestColl.Query.Salary)
					Assert.IsTrue(aggTestColl.Query.Load())
					Assert.AreEqual(11, aggTestColl.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CacheQueryObject()
			aggTestQuery = aggTestColl.Query

			aggTestQuery.[Select]().Where(aggTestQuery.Age <= aggTestQuery.Salary)
			Assert.IsTrue(aggTestQuery.Load())
			Assert.AreEqual(11, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub MultiWhereClausesInternal()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(True)).Where(aggTestColl.Query.LastName.Equal("Doe"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub MultiWhereClausesExternal()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(True))
			aggTestColl.Query.Where(aggTestColl.Query.LastName.Equal("Doe"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub MultiWhereClausesExternalOr()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(True))
			aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
			aggTestColl.Query.Where(aggTestColl.Query.LastName.Equal("Doe"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(17, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub PagingSimple()
			Dim collection As New AggregateTestCollection()

			If collection.es.Connection.Name = "SqlCe" OrElse collection.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
						all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending)
						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive)
						collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
						collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingSimpleSelectAll()
			Dim collection As New AggregateTestCollection()

			If collection.es.Connection.Name = "SqlCe" OrElse collection.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Descending)
						all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending)
						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Descending)
						collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Dim lq As String = collection.Query.Parse()
						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingWithWhere()
			Dim collection As New AggregateTestCollection()

			If aggTestColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
						all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending)
						all.Query.Where(all.Query.IsActive = True)
						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive)
						collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
						collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
						collection.Query.Where(collection.Query.IsActive = True)
						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingWithTop()
			Dim collection As New AggregateTestCollection()

			If collection.es.Connection.Name = "SqlCe" OrElse collection.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.es.Top = 20
						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
						all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending)
						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.es.Top = 20
						collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive)
						collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
						collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingWithDistinct()
			Dim collection As New AggregateTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.Ignore("Paging Not supported")
					Exit Select
				Case Else

					Dim all As New AggregateTestCollection()

					all.Query.es.Distinct = True
					all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
					all.Query.OrderBy(all.Query.Id, esOrderByDirection.Ascending)
					all.Query.Load()

					collection = New AggregateTestCollection()

					collection.Query.es.Distinct = True
					collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive)
					collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
					collection.Query.OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
					collection.Query.es.PageNumber = 1
					collection.Query.es.PageSize = 8

					Dim lq As String = collection.Query.Parse()
					Assert.IsTrue(collection.Query.Load(), "Load 1")
					Assert.AreEqual(8, collection.Count, "Count 1")

					Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
					Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

					collection.Query.es.PageNumber = 2
					Assert.IsTrue(collection.Query.Load(), "Load 2")
					Assert.AreEqual(8, collection.Count, "Count 2")

					all0 = DirectCast(all(8), AggregateTest)
					collection0 = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsNear()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "Acme NEAR Company"

					collection.Query.[Select](collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.[As]("CName"), collection.Query.Notes)
					collection.Query.Where(collection.Query.CustomerName.Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(2, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsWildCard()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = """2*"""

					collection.Query.[Select](collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.[As]("CName"), collection.Query.Notes)
					collection.Query.Where(collection.Query.CustomerName.Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(9, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsCaseInsensitive()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "acme NEAR company"

					collection.Query.Where(collection.Query.CustomerName.Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(2, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsMultiTerms()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "Acme NEAR Company"
					Dim addressTerm As String = "Road AND (""St*"" OR ""Ave*"")"

					collection.Query.[Select](collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.[As]("CName"), collection.Query.Notes)
					collection.Query.Where(collection.Query.CustomerName.Contains(nameTerm))
					collection.Query.Where(collection.Query.Notes.Contains(addressTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(1, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainswithSubOperator()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "Acme NEAR Company"

					' SubOperators are ignored for CONTAINS.
					' The search conditions belong in the search term parameter
					collection.Query.Where(collection.Query.CustomerName.ToLower().Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(2, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub PagingWithGroupBy()
			Dim collection As New AggregateTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.Ignore("Paging Not supported")
					Exit Select
				Case Else

					Dim all As New AggregateTestCollection()

					all.Query.[Select](all.Query.LastName, all.Query.Salary.Avg())
					all.Query.Where(all.Query.IsActive = True)
					all.Query.GroupBy(all.Query.LastName)
					all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
					all.Query.Load()

					collection = New AggregateTestCollection()

					collection.Query.[Select](collection.Query.LastName, collection.Query.Salary.Avg())
					collection.Query.Where(collection.Query.IsActive = True)
					collection.Query.GroupBy(collection.Query.LastName)
					collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
					collection.Query.es.PageNumber = 1
					collection.Query.es.PageSize = 8

					Assert.IsTrue(collection.Query.Load(), "Load 1")
					Assert.AreEqual(8, collection.Count, "Count 1")

					Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
					Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 1")

					collection.Query.es.PageNumber = 2
					Assert.IsTrue(collection.Query.Load(), "Load 2")
					Assert.AreEqual(2, collection.Count, "Count 2")

					all0 = DirectCast(all(8), AggregateTest)
					collection0 = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 2")

					Exit Select
			End Select
		End Sub

	End Class
End Namespace
