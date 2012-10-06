'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class SubQueryFixture
		#Region "Select SubQueries"

		<Test> _
		Public Sub SelectAllExceptOne()
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			coll.Query.SelectAllExcept(coll.Query.EmployeeID)
			coll.Query.OrderBy(coll.Query.LastName.Descending)
			coll.Query.OrderBy(coll.Query.FirstName.Descending)
			coll.Query.Load()

			' Confirm that EmployeeID is null,
			' and all other columns are not.
			Assert.AreEqual(5, coll.Count)
			Assert.IsTrue(coll(0).GetColumn(EmployeeMetadata.ColumnNames.EmployeeID) Is Nothing)
			Assert.AreEqual("John", coll(0).GetColumn(EmployeeMetadata.ColumnNames.FirstName))
			Assert.AreEqual("Smith", coll(0).GetColumn(EmployeeMetadata.ColumnNames.LastName))
			Assert.AreEqual(30, coll(0).GetColumn(EmployeeMetadata.ColumnNames.Age))
			Assert.IsTrue(coll(0).GetColumn(EmployeeMetadata.ColumnNames.Supervisor) Is Nothing)
		End Sub

		<Test> _
		Public Sub SelectAllExceptTwo()
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			coll.Query.SelectAllExcept(coll.Query.EmployeeID, coll.Query.FirstName)
			coll.Query.OrderBy(coll.Query.LastName.Descending)
			coll.Query.OrderBy(coll.Query.FirstName.Descending)
			coll.Query.Load()

			' Confirm that EmployeeID and LastName are null,
			' and all other columns are not.
			Assert.AreEqual(5, coll.Count)
			Assert.IsTrue(coll(0).GetColumn(EmployeeMetadata.ColumnNames.EmployeeID) Is Nothing)
			Assert.IsTrue(coll(0).GetColumn(EmployeeMetadata.ColumnNames.FirstName) Is Nothing)
			Assert.AreEqual("Smith", coll(0).GetColumn(EmployeeMetadata.ColumnNames.LastName))
			Assert.AreEqual(30, coll(0).GetColumn(EmployeeMetadata.ColumnNames.Age))
			Assert.IsTrue(coll(0).GetColumn(EmployeeMetadata.ColumnNames.Supervisor) Is Nothing)
		End Sub

		<Test> _
		Public Sub SelectStatement()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim orders As New OrderQuery("o")
			Dim details As New OrderItemQuery("oi")

			' A SubQuery in the Select clause must return a single value.
			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					orders.[Select](orders.OrderID, orders.OrderDate, details.[Select](details.UnitPrice.Max()).Where(orders.OrderID = details.OrderID).[As]("MaxUnitPrice"))
					orders.OrderBy(orders.OrderID.Ascending)
					Exit Select
			End Select

			Assert.IsTrue(collection.Load(orders))
			Assert.AreEqual(8, collection.Count)
			Assert.AreEqual(3D, collection(0).GetColumn("MaxUnitPrice"))
		End Sub

		<Test> _
		Public Sub SelectAllPlusSubQuery()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim orders As New OrderQuery("o")
			Dim details As New OrderItemQuery("oi")

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					orders.[Select](orders, details.[Select](details.UnitPrice.Max()).Where(orders.OrderID = details.OrderID).[As]("MaxUnitPrice"))
					orders.OrderBy(orders.OrderID.Ascending)

					Exit Select
			End Select

            Assert.IsTrue(collection.Load(orders))
			Assert.AreEqual(8, collection.Count)
			Assert.AreEqual(3D, collection(0).GetColumn("MaxUnitPrice"))

			Dim all As String = collection.Query.es.LastQuery.Substring(7, 3)
			Assert.AreEqual("o.*", all)
		End Sub

		<Test> _
		Public Sub SubQueryWithBetween()
			Dim coll As New CustomerCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Dim fromDate As New DateTime(2005, 1, 1)
					Dim toDate As New DateTime(2005, 8, 31)
					Dim startDate As New DateTime(2000, 1, 1)
					Dim endDate As New DateTime(2000, 12, 31)

					Dim cq As New CustomerQuery("c")
					Dim oq As New OrderQuery("o")
					Dim oqSub As New OrderQuery("oSub")

					oqSub.[Select](oqSub.OrderDate.Max())
					oqSub.Where(oqSub.CustID = cq.CustomerID And oqSub.CustSub = cq.CustomerSub)

					' These work
					'oqSub.Where(oqSub.OrderDate >= fromDate);
					'oqSub.Where(oqSub.OrderDate <= toDate);

					' Gets Null Reference exception on Load()?
					oqSub.Where(oqSub.OrderDate.Between(fromDate, toDate))

					cq.es.Distinct = True
					cq.[Select](cq.CustomerID, cq.CustomerSub, cq.DateAdded, oqSub.[As]("MaxOrderDate"))
					cq.InnerJoin(oq).[On](cq.CustomerID = oq.CustID And cq.CustomerSub = oq.CustSub)
					cq.Where(cq.DateAdded.Between(startDate, endDate))

					Assert.IsTrue(coll.Load(cq))
					Assert.AreEqual(1, coll.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub SubQueryWithGT_LT()
			Dim coll As New CustomerCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Dim fromDate As New DateTime(2005, 1, 1)
					Dim toDate As New DateTime(2005, 8, 31)
					Dim startDate As New DateTime(2000, 1, 1)
					Dim endDate As New DateTime(2000, 12, 31)

					Dim cq As New CustomerQuery("c")
					Dim oq As New OrderQuery("o")
					Dim oqSub As New OrderQuery("oSub")

					oqSub.[Select](oqSub.OrderDate.Max())
					oqSub.Where(oqSub.CustID = cq.CustomerID And oqSub.CustSub = cq.CustomerSub)

					' These work in SubQuery
					oqSub.Where(oqSub.OrderDate >= fromDate)
					oqSub.Where(oqSub.OrderDate <= toDate)

					' If you comment the above 2 GT/LT lines
					' and un-comment the Between line below
					' it gets Null Reference exception on Load()
					'oqSub.Where(oqSub.OrderDate.Between(fromDate, toDate));

					cq.es.Distinct = True
					cq.[Select](cq.CustomerID, cq.CustomerSub, cq.DateAdded, oqSub.[As]("MaxOrderDate"))
					cq.InnerJoin(oq).[On](cq.CustomerID = oq.CustID And cq.CustomerSub = oq.CustSub)
					' This works in outer query
					cq.Where(cq.DateAdded.Between(startDate, endDate))

					Assert.IsTrue(coll.Load(cq))
					Assert.AreEqual(1, coll.Count)
					Exit Select
			End Select
		End Sub

		#End Region

		#Region "From SubQueries"

		<Test> _
		Public Sub FromClause()
			Dim collection As New OrderCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Dim oq As New OrderQuery("o")
					Dim oiq As New OrderItemQuery("oi")

					' The inner Select contains an aggregate,
					' which requires a GroupBy for each non-aggregate in the Select.
					' The outer Select includes the aggregate from the inner Select,
					' plus columns where no GroupBy was desired.
					oq.[Select](oq.CustID, oq.OrderDate, oiq.UnitPrice)
					oq.From(oiq.[Select](oiq.OrderID, oiq.UnitPrice.Sum()).GroupBy(oiq.OrderID)).[As]("sub")
					oq.InnerJoin(oq).[On](oq.OrderID = oiq.OrderID)
					oq.OrderBy(oq.OrderID.Ascending)

					Assert.IsTrue(collection.Load(oq))
					Assert.AreEqual(5, collection.Count)
					Dim up As [Decimal] = Convert.ToDecimal(collection(0).GetColumn("UnitPrice"))
					Assert.AreEqual(5.11D, Math.Round(up, 2))

					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub FromClauseWithAlias()
			Dim collection As New OrderCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Dim oq As New OrderQuery("o")
			Dim oiq As New OrderItemQuery("oi")

			' Calculate total price per order

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
					oq.[Select](oq.CustID, oq.OrderDate, "<sub.""OrderTotal"">")
					Exit Select
				Case Else
					oq.[Select](oq.CustID, oq.OrderDate, "<sub.OrderTotal>")
					Exit Select
			End Select

			oq.From(oiq.[Select](oiq.OrderID, (oiq.UnitPrice * oiq.Quantity).Sum().[As]("OrderTotal")).GroupBy(oiq.OrderID)).[As]("sub")
			oq.InnerJoin(oq).[On](oq.OrderID = oiq.OrderID)
			oq.OrderBy(oq.OrderID.Ascending)

			Assert.IsTrue(collection.Load(oq))
			Assert.AreEqual(5, collection.Count)
			Assert.AreEqual(13.11D, collection(0).GetColumn("OrderTotal"))
		End Sub

		<Test> _
		Public Sub FromClauseUsingInstance()
			Dim collection As New OrderCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			' Select an arbitrary number of rows from
			' any starting row.
			Dim startRow As Integer = 4
			Dim numberOfRows As Integer = 7

			' OrderItem SubQuery 1
			' Get all rows through start + number, ascending
			Dim oisq As New OrderItemQuery("ois")
			oisq.es.Top = startRow + numberOfRows - 1
			oisq.[Select](oisq.OrderID, oisq.ProductID, oisq.Quantity)
			oisq.OrderBy(oisq.OrderID.Ascending, oisq.ProductID.Ascending)

			' OrderItem SubQuery 2
			' Get just the number of rows, descending
			Dim oisq2 As New OrderItemQuery("ois2")
			oisq2.es.Top = numberOfRows
			oisq2.From(oisq).[As]("sub1")

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					oisq2.OrderBy("<sub1.""OrderID"">", esOrderByDirection.Descending)
					oisq2.OrderBy("<sub1.""ProductID"">", esOrderByDirection.Descending)
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					oisq2.OrderBy("<sub1.OrderID>", esOrderByDirection.Descending)
					oisq2.OrderBy("<sub1.ProductID>", esOrderByDirection.Descending)
					Exit Select
			End Select

			' Put it back in ascending order
			Dim oq As New OrderQuery("o")
			oq.From(oisq2).[As]("sub2")

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					oq.OrderBy("<sub2.""OrderID"">", esOrderByDirection.Ascending)
					oq.OrderBy("<sub2.""ProductID"">", esOrderByDirection.Ascending)
					Exit Select
				Case Else
					oq.OrderBy("<sub2.OrderID>", esOrderByDirection.Ascending)
					oq.OrderBy("<sub2.ProductID>", esOrderByDirection.Ascending)
					Exit Select
			End Select

			Assert.IsTrue(collection.Load(oq))
			Assert.AreEqual(7, collection.Count)
			Assert.AreEqual(10, collection(0).GetColumn("Quantity"))
		End Sub

		#End Region

		#Region "Where SubQueries"

		<Test> _
		Public Sub WhereNotIn()
			Dim collection As New TerritoryCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			' SubQuery of Territories that Employee 1 is assigned to.
			Dim etq As New EmployeeTerritoryQuery("et")
			etq.[Select](etq.TerrID)
			etq.Where(etq.EmpID = 1)

			' Territories that Employee 1 is not assigned to.
			Dim tq As New TerritoryQuery("t")
			tq.[Select](tq.Description)
			tq.Where(tq.TerritoryID.NotIn(etq))
			tq.OrderBy(tq.TerritoryID.Ascending)

			Assert.IsTrue(collection.Load(tq))
			Assert.AreEqual(2, collection.Count)
			Assert.AreEqual("West", collection(0).GetColumn(TerritoryMetadata.ColumnNames.Description))
		End Sub

		<Test> _
		Public Sub WhereExists()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			' SubQuery of Employees with a null Supervisor column.
			Dim sq As New EmployeeQuery("s")
			sq.es.Distinct = True
			sq.[Select](sq.EmployeeID)
			sq.Where(sq.Supervisor.IsNull())

			' If even one employee has a null supervisor,
			' i.e., the above query has a result set,
			' then run a list of all employees.
			Dim eq As New EmployeeQuery("e")
			eq.[Select](eq.EmployeeID, eq.Supervisor)
			eq.Where(eq.Exists(sq))

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(5, collection.Count)
		End Sub

		<Test> _
		Public Sub WhereExistsFalse()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			' EmployeeID is required and will never be NULL
			Dim sq As New EmployeeQuery("s")
			sq.es.Distinct = True
			sq.[Select](sq.EmployeeID)
			sq.Where(sq.EmployeeID.IsNull())

			' This should produce no results as the
			' inner query does not exist.
			Dim eq As New EmployeeQuery("e")
			eq.[Select](eq.EmployeeID, eq.Supervisor)
			eq.Where(eq.Exists(sq))

			Assert.IsFalse(collection.Load(eq))
		End Sub

		<Test> _
		Public Sub WhereExistsANDed()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq1 As New EmployeeQuery("e1")
			Dim eq2 As New EmployeeQuery("e2")

			eq1.Where(eq1.EmployeeID > 2, eq1.Exists(eq2))

			Assert.IsTrue(collection.Load(eq1))
			Assert.AreEqual(3, collection.Count)

			Dim lq As String = collection.Query.es.LastQuery
			Dim one As String() = lq.Split("1"C)
			Assert.AreEqual(4, one.GetLength(0))
			Dim two As String() = lq.Split("2"C)
			Assert.AreEqual(2, two.GetLength(0))
		End Sub

		<Test> _
		Public Sub WhereExistsANDedTogether()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq1 As New EmployeeQuery("e1")
			Dim eq2 As New EmployeeQuery("e2")
			Dim eq3 As New EmployeeQuery("e3")

			eq1.Where(eq1.Exists(eq2), eq1.Exists(eq3))

			Assert.IsTrue(collection.Load(eq1))
			Assert.AreEqual(5, collection.Count)

			Dim lq As String = collection.Query.es.LastQuery
			Dim one As String() = lq.Split("1"C)
			Assert.AreEqual(2, one.GetLength(0))
			Dim two As String() = lq.Split("2"C)
			Assert.AreEqual(2, two.GetLength(0))
			Dim three As String() = lq.Split("3"C)
			Assert.AreEqual(2, three.GetLength(0))
		End Sub

		<Test> _
		Public Sub WhereInANDedTogether()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq1 As New EmployeeQuery("e1")
			Dim eq2 As New EmployeeQuery("e2")
			Dim eq3 As New EmployeeQuery("e3")

			eq2.[Select](eq2.EmployeeID)
			eq3.[Select](eq3.EmployeeID)

			eq1.Where(eq1.EmployeeID.[In](eq2), eq1.EmployeeID.[In](eq3))

			Assert.IsTrue(collection.Load(eq1))
			Assert.AreEqual(5, collection.Count)

			Dim lq As String = collection.Query.es.LastQuery
			Dim one As String() = lq.Split("1"C)
			Assert.AreEqual(4, one.GetLength(0))
			Dim two As String() = lq.Split("2"C)
			Assert.AreEqual(3, two.GetLength(0))
			Dim three As String() = lq.Split("3"C)
			Assert.AreEqual(3, three.GetLength(0))
		End Sub

		<Test> _
		Public Sub WhereInANDedTogetherOperator()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq1 As New EmployeeQuery("e1")
			Dim eq2 As New EmployeeQuery("e2")
			Dim eq3 As New EmployeeQuery("e3")

			eq2.[Select](eq2.EmployeeID)
			eq3.[Select](eq3.EmployeeID)

			eq1.Where(eq1.EmployeeID.[In](eq2) And eq1.EmployeeID.[In](eq3))

			Assert.IsTrue(collection.Load(eq1))
			Assert.AreEqual(5, collection.Count)

			Dim lq As String = collection.Query.es.LastQuery
			Dim one As String() = lq.Split("1"C)
			Assert.AreEqual(4, one.GetLength(0))
			Dim two As String() = lq.Split("2"C)
			Assert.AreEqual(3, two.GetLength(0))
			Dim three As String() = lq.Split("3"C)
			Assert.AreEqual(3, three.GetLength(0))
		End Sub

		<Test> _
		Public Sub WhereWithJoin()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			' SubQuery of Territories
			Dim tq As New TerritoryQuery("t")
			tq.[Select](tq.TerritoryID)
			tq.Where(tq.Description = "North" Or tq.Description = "West")

			' EmployeeTerritory Query for Join
			Dim etq As New EmployeeTerritoryQuery("et")

			' Employees matching those territories
			Dim eq As New EmployeeQuery("e")
			eq.es.Distinct = True
			eq.[Select](eq.EmployeeID, etq.TerrID)
			eq.LeftJoin(etq).[On](eq.EmployeeID = etq.EmpID)
			eq.Where(etq.TerrID.[In](tq))
			eq.OrderBy(eq.EmployeeID.Ascending)

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(3, collection.Count)
		End Sub

		#End Region

		#Region "Join SubQueries"

		<Test> _
		Public Sub SimpleJoinOn()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("SubQuery inside an ON clause not Supported")
					Exit Select
				Case Else
					' Query for the Join
					Dim oiq As New OrderItemQuery("oi")

					' SubQuery of OrderItems with a discount
					Dim oisq As New OrderItemQuery("ois")
					oisq.es.Distinct = True
					oisq.[Select](oisq.Discount)
					oisq.Where(oisq.Discount > 0)

					' Orders with discounted items
					Dim oq As New OrderQuery("o")
					oq.[Select](oq.OrderID, oiq.Discount)
					oq.InnerJoin(oiq).[On](oq.OrderID = oiq.OrderID And oiq.Discount.[In](oisq))

					Assert.IsTrue(collection.Load(oq))
					Assert.AreEqual(2, collection.Count)
					Exit Select
			End Select
		End Sub

		' There is currently no support for Subqueries in a Join()
		' clause, only the .On() clause.
		'[Test]
		'public void SimpleJoin()
		'{
		'    // SubQuery of OrderItems with a discount
		'    OrderItemQuery oiq = new OrderItemQuery("oi");
		'    oiq.es.Distinct = true;
		'    oiq.Select(oiq.OrderID, oiq.Discount);
		'    oiq.Where(oiq.Discount > 0);

		'    // Orders with discounted items
		'    OrderQuery oq = new OrderQuery("o");
		'    oq.Select(oq.OrderID, oiq.Discount);
		'    oq.InnerJoin(oiq).On(oq.OrderID == oiq.OrderID);

		'    OrderCollection collection = new OrderCollection();

		'    Assert.IsTrue(collection.Load(oq));
		'    Assert.AreEqual(2, collection.Count);
		'}

		#End Region

		#Region "Miscellaneous SubQueries"

		<Test> _
		Public Sub Correlated()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim oiq As New OrderItemQuery("oi")
			Dim pq As New ProductQuery("p")

			' oiq.ProductID in the inner Select is pulled from
			' the outer Select, making a correlated SubQuery.
			oiq.[Select](oiq.OrderID, (oiq.Quantity * oiq.UnitPrice).Sum().[As]("Total"))
			oiq.Where(oiq.ProductID.[In](pq.[Select](pq.ProductID).Where(oiq.ProductID = pq.ProductID)))
			oiq.GroupBy(oiq.OrderID)

			Assert.IsTrue(collection.Load(oiq))
			Assert.AreEqual(5, collection.Count)
		End Sub

		<Test> _
		Public Sub Nested()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim oq As New OrderQuery("o")
			Dim cq As New CustomerQuery("c")
			Dim eq As New EmployeeQuery("e")

			' OrderID and CustID for customers who ordered on the same date
			' a customer was added, and have a manager whose 
			' last name starts with 'S'.
			oq.[Select](oq.OrderID, oq.CustID)
			oq.Where(oq.OrderDate.[In](cq.[Select](cq.DateAdded).Where(cq.Manager.[In](eq.[Select](eq.EmployeeID).Where(eq.LastName.[Like]("S%"))))))

			Assert.IsTrue(collection.Load(oq))
			Assert.AreEqual(2, collection.Count)
		End Sub

		<Test> _
		Public Sub NestedBySubQuery()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			' This is the same as the traditional nested SubQuery 
			' in the 'Nested' test, but is easier to construct
			' and understand.
			' The key is to start with the innermost SubQuery,
			' and work your way out to the outermost Query.

			' Employees whose LastName begins with 'S'.
			Dim eq As New EmployeeQuery("e")
			eq.[Select](eq.EmployeeID)
			eq.Where(eq.LastName.[Like]("S%"))

			' DateAdded for Customers whose Managers are in the
			' EmployeeQuery above.
			Dim cq As New CustomerQuery("c")
			cq.[Select](cq.DateAdded)
			cq.Where(cq.Manager.[In](eq))

			' OrderID and CustID where the OrderDate is in the
			' CustomerQuery above.
			Dim oq As New OrderQuery("o")
			oq.[Select](oq.OrderID, oq.CustID)
			oq.Where(oq.OrderDate.[In](cq))

			Assert.IsTrue(collection.Load(oq))
			Assert.AreEqual(2, collection.Count)
		End Sub

		<Test> _
		Public Sub AnyNestedBySubQuery()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					Assert.Ignore("Not supported by SQLite.")
					Exit Select
				Case Else

					' Employees whose LastName begins with 'S'.
					Dim eq As New EmployeeQuery("e")
					eq.[Select](eq.EmployeeID)
					eq.Where(eq.LastName.[Like]("S%"))

					' DateAdded for Customers whose Managers are in the
					' EmployeeQuery above.
					Dim cq As New CustomerQuery("c")
					cq.es.Any = True
					cq.[Select](cq.DateAdded)
					cq.Where(cq.Manager.[In](eq))

					' OrderID and CustID where the OrderDate is 
					' less than any one of the dates in the CustomerQuery above.
					Dim oq As New OrderQuery("o")
					oq.[Select](oq.OrderID, oq.CustID)
					oq.Where(oq.OrderDate < cq)

					Assert.IsTrue(collection.Load(oq))
					Assert.AreEqual(8, collection.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub AllSubQuery()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					Assert.Ignore("Not supported by SQLite.")
					Exit Select
				Case Else

					' DateAdded for Customers whose Manager  = 3
					Dim cq As New CustomerQuery("c")
					cq.es.All = True
					cq.[Select](cq.DateAdded)
					cq.Where(cq.Manager = 3)

					' OrderID and CustID where the OrderDate is 
					' less than all of the dates in the CustomerQuery above.
					Dim oq As New OrderQuery("o")
					oq.[Select](oq.OrderID, oq.CustID)
					oq.Where(oq.OrderDate < cq)

					Assert.IsTrue(collection.Load(oq))
					Assert.AreEqual(8, collection.Count)
					Exit Select
			End Select
		End Sub

		#End Region
	End Class
End Namespace
