'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class JoinFixture
		#Region "Inner Join Tests"

		<Test> _
		Public Sub InnerSimple()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim cq As New CustomerQuery("cq")

			eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
			eq.InnerJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned)

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(10, collection.Count)
		End Sub

		<Test> _
		Public Sub InnerAlias()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not supported")
					Exit Select

				Case "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Dim oq As New OrderQuery("o")
					Dim odq As New OrderItemQuery("od")

					oq.[Select](oq.OrderID, odq.OrderID)
					oq.InnerJoin(odq).[On](oq.OrderID = odq.OrderID)
					oq.OrderBy(oq.OrderID.Ascending)

					Assert.IsTrue(collection.Load(oq), "Load")
					Dim lq As String = collection.Query.es.LastQuery
					Assert.AreEqual(1, collection(0).OrderID.Value, "Property")
					Assert.AreEqual(1, Convert.ToInt32(collection(0).GetColumn("OrderID_1")), "Virtual")
					Exit Select
				Case Else

                    Dim oq As New OrderQuery("o")
                    Dim odq As New OrderItemQuery("od")

					oq.[Select](oq.OrderID, odq.OrderID)
					oq.InnerJoin(odq).[On](oq.OrderID = odq.OrderID)
					oq.OrderBy(oq.OrderID.Ascending)

					Assert.IsTrue(collection.Load(oq), "Load")
                    Dim lq As String = collection.Query.es.LastQuery
                    Assert.AreEqual(1, collection(0).OrderID.Value, "Property")
					Assert.AreEqual(1, Convert.ToInt32(collection(0).GetColumn("OrderID1")), "Virtual")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub InnerJoinFourTables()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim emp As New EmployeeQuery("e")
			Dim empTerr As New EmployeeTerritoryQuery("et")
			Dim terr As New TerritoryQuery("t")
			Dim terrEx As New TerritoryExQuery("tx")

			emp.[Select](emp.FirstName, emp.LastName, terr.Description.[As]("Territory"), terrEx.Notes)
			emp.InnerJoin(empTerr).[On](emp.EmployeeID = empTerr.EmpID)
			emp.InnerJoin(terr).[On](terr.TerritoryID = empTerr.TerrID)
			emp.InnerJoin(terrEx).[On](terrEx.TerritoryID = terr.TerritoryID)
			emp.Where(terrEx.Notes.IsNotNull())

			Assert.IsTrue(collection.Load(emp))
			Assert.AreEqual(2, collection.Count)

			Dim theName As String = TryCast(collection(1).GetColumn("Territory"), String)
			Assert.AreEqual("North", theName)
		End Sub

		<Test> _
		Public Sub InnerSelectAllPrimaryQuery()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim oq As New OrderQuery("o")
			Dim oiq As New OrderItemQuery("oi")

			oq.[Select](oq)
			oq.InnerJoin(oiq).[On](oq.OrderID = oiq.OrderID)

			Assert.IsTrue(collection.Load(oq))
			Assert.AreEqual(15, collection.Count)

			Dim lq As String = collection.Query.es.LastQuery
			Dim all As String = lq.Substring(7, 3)
			Assert.AreEqual("o.*", all)
		End Sub

		<Test> _
		Public Sub InnerSelectAllSecondaryQuery()
			Dim collection As New OrderCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim oq As New OrderQuery("o")
			Dim oiq As New OrderItemQuery("oi")

			oq.[Select](oiq)
			oq.InnerJoin(oiq).[On](oq.OrderID = oiq.OrderID)

			Assert.IsTrue(collection.Load(oq))
			Assert.AreEqual(15, collection.Count)

			Dim lq As String = collection.Query.es.LastQuery
			Dim all As String = lq.Substring(7, 4)
			Assert.AreEqual("oi.*", all)
		End Sub

		#End Region

		#Region "Left Join Tests"

		<Test> _
		Public Sub LeftSimple()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim cq As New CustomerQuery("cq")

			eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
			eq.LeftJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned)

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(11, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftIsNull()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim cq As New CustomerQuery("cq")

			eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
			eq.LeftJoin(cq).[On](eq.EmployeeID = cq.Manager And cq.StaffAssigned.IsNull())

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(47, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftIsNotNull()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim cq As New CustomerQuery("cq")

			eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
			eq.LeftJoin(cq).[On](eq.EmployeeID = cq.Manager And cq.StaffAssigned.IsNotNull())

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(13, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftWithWhere()
			Dim collection As New CustomerCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim cust As New CustomerQuery("cq")
			Dim emp As New EmployeeQuery("eq")

			cust.[Select](cust.CustomerID, emp.LastName, cust.Manager, cust.StaffAssigned)
			cust.LeftJoin(emp).[On](cust.Manager = emp.EmployeeID)
			cust.Where(cust.Manager = cust.StaffAssigned)

			Assert.IsTrue(collection.Load(cust))
			Assert.AreEqual(4, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftWithOperatorsInOn()
			Dim record As Integer = 0
			Dim collection As New CustomerCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
					record = 2
					Dim cq As New CustomerQuery("cq")
					Dim eq As New EmployeeQuery("eq")

					cq.[Select](cq.CustomerName, eq.LastName)
					cq.LeftJoin(eq).[On](cq.StaffAssigned = eq.EmployeeID And eq.Supervisor = 1)
					cq.OrderBy(cq.CustomerName.Ascending)

					Assert.IsTrue(collection.Load(cq))
					Assert.AreEqual(56, collection.Count)
					Assert.AreEqual("Doe", collection(record).GetColumn("LastName"))
					Exit Select
				Case Else
					record = 1
                    Dim cq As New CustomerQuery("cq")
                    Dim eq As New EmployeeQuery("eq")

					cq.[Select](cq.CustomerName, eq.LastName)
					cq.LeftJoin(eq).[On](cq.StaffAssigned = eq.EmployeeID And eq.Supervisor = 1)
					cq.OrderBy(cq.CustomerName.Ascending)

					Assert.IsTrue(collection.Load(cq))
					Assert.AreEqual(56, collection.Count)
					Assert.AreEqual("Doe", collection(record).GetColumn("LastName"))
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub LeftWithDateComparisonInOn()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim cq As New CustomerQuery("cq")

			eq.[Select](eq.LastName)
			eq.LeftJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned And cq.DateAdded < Convert.ToDateTime("2005-12-31"))
			eq.Where(cq.DateAdded < Convert.ToDateTime("2000-12-31"))
			eq.OrderBy(eq.LastName.Ascending)

            Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(7, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftWithContains()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "acme NEAR company"

					Dim eq As New EmployeeQuery("eq")
					Dim cq As New CustomerQuery("cq")

					eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
					eq.LeftJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned)
					eq.Where(cq.CustomerName.Contains(nameTerm))

					Assert.IsTrue(collection.Load(eq))
					Assert.AreEqual(2, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub LeftSelfJoin()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim supervisorQuery As New EmployeeQuery("sq")

			eq.[Select](eq.EmployeeID, eq.LastName, supervisorQuery.LastName.[As]("Reports To"))
			eq.LeftJoin(supervisorQuery).[On](eq.Supervisor = supervisorQuery.EmployeeID)

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(5, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftRawSelect()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim cq As New CustomerQuery("cq")

			Dim special As String = ""
			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					special = "<cq.[CustomerID] + '-' + cq.[CustomerSub] AS FullCustomerId>"
					Exit Select

				Case "EntitySpaces.MySqlClientProvider"
					special = "<CONCAT(cq.`CustomerID`, '-', cq.`CustomerSub`) AS 'FullCustomerId'>"
					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
					special = "<cq.""CustomerID"" || '-' || cq.""CustomerSub"" AS ""FullCustomerId"">"
					Exit Select
				Case Else

					If collection.es.Connection.Name = "SqlCe" Then
						special = "<cq.[CustomerID] + '-' + cq.[CustomerSub] AS ""FullCustomerId"">"
					Else
						special = "<cq.[CustomerID] + '-' + cq.[CustomerSub] As FullCustomerId>"
					End If
					Exit Select
			End Select

			eq.[Select](eq.EmployeeID, eq.LastName, special, cq.CustomerName)

			eq.LeftJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned)

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(11, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftJoinFourTables()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim emp As New EmployeeQuery("e")
			Dim empTerr As New EmployeeTerritoryQuery("et")
			Dim terr As New TerritoryQuery("t")
			Dim terrEx As New TerritoryExQuery("tx")

			emp.[Select](emp.FirstName, emp.LastName, terr.Description.[As]("Territory"), terrEx.Notes)
			emp.LeftJoin(empTerr).[On](emp.EmployeeID = empTerr.EmpID)
			emp.LeftJoin(terr).[On](empTerr.TerrID = terr.TerritoryID)
			emp.LeftJoin(terrEx).[On](terr.TerritoryID = terrEx.TerritoryID)

			Assert.IsTrue(collection.Load(emp))
			Assert.AreEqual(9, collection.Count)
		End Sub

		<Test> _
		Public Sub LeftJoinFourTablesWithWhere()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim emp As New EmployeeQuery("e")
			Dim empTerr As New EmployeeTerritoryQuery("et")
			Dim terr As New TerritoryQuery("t")
			Dim terrEx As New TerritoryExQuery("tx")

			emp.[Select](emp.FirstName, emp.LastName, terr.Description.[As]("Territory"), terrEx.Notes)
			emp.LeftJoin(empTerr).[On](emp.EmployeeID = empTerr.EmpID)
			emp.LeftJoin(terr).[On](empTerr.TerrID = terr.TerritoryID)
			emp.LeftJoin(terrEx).[On](terr.TerritoryID = terrEx.TerritoryID)

			emp.Where(emp.FirstName.Trim().[Like]("J___"))

			Assert.IsTrue(collection.Load(emp))
			Assert.AreEqual(7, collection.Count)
		End Sub

		#End Region

		#Region "Right Join Tests"

		<Test> _
		Public Sub RightSimple()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					Assert.Ignore("RIGHT JOIN not supported.")
					Exit Select
				Case Else

					Dim eq As New EmployeeQuery("eq")
					Dim cq As New CustomerQuery("cq")

					eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
					eq.RightJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned)

					Assert.IsTrue(collection.Load(eq))
					Assert.AreEqual(56, collection.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub RightWithOnIn()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					Assert.Ignore("RIGHT JOIN not supported.")
					Exit Select
				Case Else

					Dim custList As New List(Of String)()
					custList.Add("01001")
					custList.Add("40000")
					custList.Add("XXXXX")

					Dim eq As New EmployeeQuery("eq")
					Dim cq As New CustomerQuery("cq")

					eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerID, cq.CustomerName)
					eq.RightJoin(cq).[On](eq.EmployeeID = cq.Manager AndAlso cq.CustomerID.[In](custList))

					Dim coll As New EmployeeCollection()
					coll.es.Connection.Name = "ForeignKeyTest"

					Assert.IsTrue(coll.Load(eq))
					Assert.AreEqual(56, coll.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub RightWithWhereIn()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					Assert.Ignore("RIGHT JOIN not supported.")
					Exit Select
				Case Else

					Dim custList As New List(Of String)()
					custList.Add("01001")
					custList.Add("40000")
					custList.Add("XXXXX")

					Dim eq As New EmployeeQuery("eq")
					Dim cq As New CustomerQuery("cq")

					eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerID, cq.CustomerName)
					eq.RightJoin(cq).[On](eq.EmployeeID = cq.Manager)
					eq.Where(cq.CustomerID.[In](custList))

					Dim coll As New EmployeeCollection()
					coll.es.Connection.Name = "ForeignKeyTest"

					Assert.IsTrue(coll.Load(eq))
					Assert.AreEqual(14, coll.Count)
					Exit Select
			End Select
		End Sub

		#End Region

		#Region "Full Join Tests"

		<Test> _
		Public Sub FullSimple()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			If collection.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("FULL JOIN not supported.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("FULL JOIN not supported.")
						Exit Select
					Case Else

						Dim eq As New EmployeeQuery("eq")
						Dim cq As New CustomerQuery("cq")

						eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
						eq.FullJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned)

						Assert.IsTrue(collection.Load(eq))
						Assert.AreEqual(57, collection.Count)
						Exit Select
				End Select
			End If
		End Sub

		#End Region

		#Region "Mixed Join Tests"

		<Test> _
		Public Sub JoinFourTablesInnerLeft()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else

					Dim emp As New EmployeeQuery("e")
					Dim empTerr As New EmployeeTerritoryQuery("et")
					Dim terr As New TerritoryQuery("t")
					Dim terrEx As New TerritoryExQuery("tx")

					emp.[Select](emp.FirstName, emp.LastName, terr.Description.[As]("Territory"), terrEx.Notes)
					emp.LeftJoin(empTerr).[On](emp.EmployeeID = empTerr.EmpID)
					emp.InnerJoin(terr).[On](empTerr.TerrID = terr.TerritoryID)
					emp.LeftJoin(terrEx).[On](terr.TerritoryID = terrEx.TerritoryID)

					Assert.IsTrue(collection.Load(emp))
					Assert.AreEqual(8, collection.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub JoinCompositeFK()
			Dim collection As New ProductCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim empId As Integer = 1

			Dim prd As New ProductQuery("pq")
			Dim item As New OrderItemQuery("oiq")
			Dim ord As New OrderQuery("oq")
			Dim cust As New CustomerQuery("cq")
			Dim emp As New EmployeeQuery("eq")

			prd.[Select](prd.ProductID)
			prd.InnerJoin(item).[On](prd.ProductID = item.ProductID)
			prd.InnerJoin(ord).[On](item.OrderID = ord.OrderID)
			prd.InnerJoin(cust).[On](ord.CustID = cust.CustomerID And ord.CustSub = cust.CustomerSub)
			prd.InnerJoin(emp).[On](cust.Manager = emp.EmployeeID)
			prd.Where(emp.EmployeeID = empId)
			prd.Where(prd.Discontinued = False)
			prd.OrderBy(prd.ProductID.Ascending)

			Assert.IsTrue(collection.Load(prd))
			Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub MixedANDAndORInOn()
			Dim collection As New ProductCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim empId As Integer = 1

			Dim prd As New ProductQuery("pq")
			Dim item As New OrderItemQuery("oiq")
			Dim ord As New OrderQuery("oq")
			Dim cust As New CustomerQuery("cq")
			Dim emp As New EmployeeQuery("eq")

			prd.[Select](prd.ProductID)
			prd.InnerJoin(item).[On](prd.ProductID = item.ProductID)
			prd.InnerJoin(ord).[On](item.OrderID = ord.OrderID)
			prd.InnerJoin(cust).[On](ord.CustID = cust.CustomerID And (ord.CustSub = cust.CustomerSub Or ord.EmployeeID = cust.StaffAssigned))
			prd.InnerJoin(emp).[On](cust.Manager = emp.EmployeeID)
			prd.Where(emp.EmployeeID = empId)
			prd.Where(prd.Discontinued = False)
			prd.OrderBy(prd.ProductID.Ascending)

			Assert.IsTrue(collection.Load(prd))
			Assert.AreEqual(9, collection.Count)
		End Sub

		#End Region

		#Region "Combination Join and Expression Tests"

		<Test> _
		Public Sub JoinWithArithmeticExpressionOrderByCalulatedColumn()
			Dim collection As New CustomerCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim orderAlias As String = ""
			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					orderAlias = "<'TotalSales'>"
					Exit Select
				Case Else
					orderAlias = "TotalSales"
					Exit Select
			End Select

			' Notice I create a calulated columns based on the TotalSales,
			' then Order by it descending
			Dim cust As New CustomerQuery("c")
			Dim order As New OrderQuery("o")
			Dim item As New OrderItemQuery("oi")

			cust.[Select](cust.CustomerName, (item.Quantity * item.UnitPrice).Sum().[As]("TotalSales"))
			cust.InnerJoin(order).[On](order.CustID = cust.CustomerID)
			cust.InnerJoin(item).[On](item.OrderID = order.OrderID)
			cust.GroupBy(cust.CustomerName)
			cust.OrderBy(orderAlias, esOrderByDirection.Descending)

			Assert.IsTrue(collection.Load(cust))
			Assert.AreEqual(6, collection.Count)
		End Sub

		<Test> _
		Public Sub JoinWithPaging()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			If collection.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim emp As New EmployeeQuery("e")
						Dim empTerr As New EmployeeTerritoryQuery("et")
						Dim terr As New TerritoryQuery("t")
						Dim terrEx As New TerritoryExQuery("tx")

						emp.[Select](emp, terr.Description.[As]("Territory"), terrEx.Notes)
						emp.InnerJoin(empTerr).[On](empTerr.TerrID = emp.EmployeeID)
						emp.InnerJoin(terr).[On](terr.TerritoryID = empTerr.TerrID)
						emp.InnerJoin(terrEx).[On](terrEx.TerritoryID = terr.TerritoryID)
						emp.Where(terrEx.Notes.IsNotNull())
						emp.OrderBy(emp.FirstName.Ascending)

						emp.es.PageNumber = 1
						emp.es.PageSize = 20

						Assert.IsTrue(collection.Load(emp))
						Assert.AreEqual(2, collection.Count)

						Exit Select
				End Select
			End If
		End Sub

		#End Region

		#Region "Custom Join Tests"

		<Test> _
		Public Sub CustomMultiInnerWithDistinct()
			Dim empId As Integer = 1
			Dim collection As New ProductCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Assert.IsTrue(collection.GetActiveProductIds(empId))
			Assert.AreEqual(2, collection.Count)
		End Sub

		<Test> _
		Public Sub CrossDbJoin()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					' AggregateDb
					Dim aq As New AggregateTestQuery("a")
					' ForeignKeyTest
					Dim eq As New EmployeeQuery("e")

					eq.[Select](eq.LastName, eq.FirstName, aq.Age)
					eq.LeftJoin(aq).[On](eq.LastName = aq.LastName And eq.FirstName = aq.FirstName)
					eq.OrderBy(eq.LastName.Ascending, eq.FirstName.Ascending)

					Assert.IsTrue(collection.Load(eq))
					Assert.AreEqual(22, collection(2).GetColumn("Age"))
					Exit Select
				Case Else

					Assert.Ignore("SQL Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub LeftWithExplicitParen()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")
			Dim cq As New CustomerQuery("cq")

			eq.[Select](eq.EmployeeID, eq.LastName, cq.CustomerName)
			eq.LeftJoin(cq).[On](eq.EmployeeID = cq.StaffAssigned)

			eq.Where(eq.Age = 20)

			eq.Where(New esComparison(esParenthesis.Open))

			eq.es.DefaultConjunction = esConjunction.[Or]

			For i As Integer = 0 To 3
				eq.Where(eq.Supervisor = i And eq.EmployeeID = i + 1)
			Next

			eq.Where(New esComparison(esParenthesis.Close))

			Assert.IsTrue(collection.Load(eq))
			Assert.AreEqual(5, collection.Count)
		End Sub

		#End Region
	End Class
End Namespace
