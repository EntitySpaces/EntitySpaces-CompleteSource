'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports EntitySpaces.DynamicQuery
Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces

Namespace Tests.Base
	<TestFixture> _
	Public Class SubQueryDaisyChainingFixture
		#Region "Select SubQueries"

		<Test> _
		Public Sub SelectAllExceptOne()
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"
			coll.Query.SelectAllExcept(coll.Query.EmployeeID).OrderBy(coll.Query.LastName.Descending).OrderBy(coll.Query.FirstName.Descending)

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

			coll.Query.SelectAllExcept(coll.Query.EmployeeID, coll.Query.FirstName).OrderBy(coll.Query.LastName.Descending).OrderBy(coll.Query.FirstName.Descending)

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
					orders.[Select](orders.OrderID, orders.OrderDate, details.[Select](details.UnitPrice.Max()).Where(orders.OrderID = details.OrderID).[As]("MaxUnitPrice")).OrderBy(orders.OrderID.Ascending)
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
					orders.[Select](orders, details.[Select](details.UnitPrice.Max()).Where(orders.OrderID = details.OrderID).[As]("MaxUnitPrice")).OrderBy(orders.OrderID.Ascending)

					Exit Select
			End Select

			Assert.IsTrue(collection.Load(orders))
			Assert.AreEqual(8, collection.Count)
			Assert.AreEqual(3D, collection(0).GetColumn("MaxUnitPrice"))

			Dim lq As String = collection.Query.es.LastQuery
			Dim all As String = lq.Substring(7, 3)
			Assert.AreEqual("o.*", all)
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
					oq.[Select](oq.CustID, oq.OrderDate, oiq.UnitPrice).From(oiq.[Select](oiq.OrderID, oiq.UnitPrice.Sum()).GroupBy(oiq.OrderID)).[As]("sub").InnerJoin(oq).[On](oq.OrderID = oiq.OrderID).OrderBy(oq.OrderID.Ascending)

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

			oq.From(oiq.[Select](oiq.OrderID, (oiq.UnitPrice * oiq.Quantity).Sum().[As]("OrderTotal")).GroupBy(oiq.OrderID)).[As]("sub").InnerJoin(oq).[On](oq.OrderID = oiq.OrderID).OrderBy(oq.OrderID.Ascending)

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
			oisq.[Select](oisq.OrderID, oisq.ProductID, oisq.Quantity).OrderBy(oisq.OrderID.Ascending, oisq.ProductID.Ascending)

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
					oisq2.OrderBy("<sub1.""OrderID"">", esOrderByDirection.Descending).OrderBy("<sub1.""ProductID"">", esOrderByDirection.Descending)
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					oisq2.OrderBy("<sub1.OrderID>", esOrderByDirection.Descending).OrderBy("<sub1.ProductID>", esOrderByDirection.Descending)
					Exit Select
			End Select

			' Put it back in ascending order
			Dim oq As New OrderQuery("o")
			oq.From(oisq2).[As]("sub2")

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					oq.OrderBy("<sub2.""OrderID"">", esOrderByDirection.Ascending).OrderBy("<sub2.""ProductID"">", esOrderByDirection.Ascending)
					Exit Select
				Case Else
					oq.OrderBy("<sub2.OrderID>", esOrderByDirection.Ascending).OrderBy("<sub2.ProductID>", esOrderByDirection.Ascending)
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
			etq.[Select](etq.TerrID).Where(etq.EmpID = 1)

			' Territories that Employee 1 is not assigned to.
			Dim tq As New TerritoryQuery("t")
			tq.[Select](tq.Description).Where(tq.TerritoryID.NotIn(etq)).OrderBy(tq.TerritoryID.Ascending)

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
			sq.[Select](sq.EmployeeID).Where(sq.Supervisor.IsNull())

			' If even one employee has a null supervisor,
			' i.e., the above query has a result set,
			' then run a list of all employees.
			Dim eq As New EmployeeQuery("e")
			eq.[Select](eq.EmployeeID, eq.Supervisor).Where(eq.Exists(sq))

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
			sq.[Select](sq.EmployeeID).Where(sq.EmployeeID.IsNull())

			' This should produce no results as the
			' inner query does not exist.
			Dim eq As New EmployeeQuery("e")
			eq.[Select](eq.EmployeeID, eq.Supervisor).Where(eq.Exists(sq))

			Assert.IsFalse(collection.Load(eq))
		End Sub

		<Test> _
		Public Sub WhereWithJoin()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			' SubQuery of Territories
			Dim tq As New TerritoryQuery("t")
			tq.[Select](tq.TerritoryID).Where(tq.Description = "North" Or tq.Description = "West")

			' EmployeeTerritory Query for Join
			Dim etq As New EmployeeTerritoryQuery("et")

			' Employees matching those territories
			Dim eq As New EmployeeQuery("e")
			eq.es.Distinct = True
			eq.[Select](eq.EmployeeID, etq.TerrID).LeftJoin(etq).[On](eq.EmployeeID = etq.EmpID).Where(etq.TerrID.[In](tq)).OrderBy(eq.EmployeeID.Ascending)

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
					oisq.[Select](oisq.Discount).Where(oisq.Discount > 0)

					' Orders with discounted items
					Dim oq As New OrderQuery("o")
					oq.[Select](oq.OrderID, oiq.Discount).InnerJoin(oiq).[On](oq.OrderID = oiq.OrderID And oiq.Discount.[In](oisq))

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
			oiq.[Select](oiq.OrderID, (oiq.Quantity * oiq.UnitPrice).Sum().[As]("Total")).Where(oiq.ProductID.[In](pq.[Select](pq.ProductID).Where(oiq.ProductID = pq.ProductID))).GroupBy(oiq.OrderID)

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
			oq.[Select](oq.OrderID, oq.CustID).Where(oq.OrderDate.[In](cq.[Select](cq.DateAdded).Where(cq.Manager.[In](eq.[Select](eq.EmployeeID).Where(eq.LastName.[Like]("S%"))))))

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
			eq.[Select](eq.EmployeeID).Where(eq.LastName.[Like]("S%"))

			' DateAdded for Customers whose Managers are in the
			' EmployeeQuery above.
			Dim cq As New CustomerQuery("c")
			cq.[Select](cq.DateAdded).Where(cq.Manager.[In](eq))

			' OrderID and CustID where the OrderDate is in the
			' CustomerQuery above.
			Dim oq As New OrderQuery("o")
			oq.[Select](oq.OrderID, oq.CustID).Where(oq.OrderDate.[In](cq))

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
					eq.[Select](eq.EmployeeID).Where(eq.LastName.[Like]("S%"))

					' DateAdded for Customers whose Managers are in the
					' EmployeeQuery above.
					Dim cq As New CustomerQuery("c")
					cq.es.Any = True
					cq.[Select](cq.DateAdded).Where(cq.Manager.[In](eq))

					' OrderID and CustID where the OrderDate is 
					' less than any one of the dates in the CustomerQuery above.
					Dim oq As New OrderQuery("o")
					oq.[Select](oq.OrderID, oq.CustID).Where(oq.OrderDate < cq)

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
					cq.[Select](cq.DateAdded).Where(cq.Manager = 3)

					' OrderID and CustID where the OrderDate is 
					' less than all of the dates in the CustomerQuery above.
					Dim oq As New OrderQuery("o")
					oq.[Select](oq.OrderID, oq.CustID).Where(oq.OrderDate < cq)

					Assert.IsTrue(collection.Load(oq))
					Assert.AreEqual(8, collection.Count)
					Exit Select
			End Select
		End Sub

		#End Region
	End Class
End Namespace
