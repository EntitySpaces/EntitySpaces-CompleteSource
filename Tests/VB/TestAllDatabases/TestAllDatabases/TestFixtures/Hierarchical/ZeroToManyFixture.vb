'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Collections.Generic
Imports System.Text

Imports NUnit.Framework
Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class ZeroToManyFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub TestMultipleReferences()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.LoadByPrimaryKey(1)
			Assert.AreEqual(35, emp.CustomerCollectionByManager.Count)
			Assert.AreEqual(2, emp.CustomerCollectionByStaffAssigned.Count)
		End Sub

		<Test> _
		Public Sub TestNullReferences()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.LoadByPrimaryKey(5)
			Assert.AreEqual(0, emp.CustomerCollectionByManager.Count)
			Assert.AreEqual(0, emp.CustomerCollectionByStaffAssigned.Count)
		End Sub

		<Test> _
		Public Sub TestCompositeForeignKey()
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			cust.LoadByPrimaryKey("01001", "001")
			Assert.AreEqual(3, cust.OrderCollectionByCustID.Count)
		End Sub

		<Test> _
		Public Sub TestSelfReference()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.LoadByPrimaryKey(1)
			Assert.AreEqual(2, emp.EmployeeCollectionBySupervisor.Count)
		End Sub

		<Test> _
		Public Sub TestSave()
			Dim empKey As Integer = -1
			Dim custGroup As New CustomerGroup()
			custGroup.es.Connection.Name = "ForeignKeyTest"
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					custGroup.GroupID = "XXXXX"
					custGroup.GroupName = "Test"
					custGroup.Save()

					emp.LastName = "LastName"
					emp.FirstName = "FirstName"

					cust = emp.CustomerCollectionByStaffAssigned.AddNew()
					cust.CustomerID = "XXXXX"
					cust.CustomerSub = "XXX"
					cust.CustomerName = "Test"
					cust.str.DateAdded = "2007-01-01 00:00:00"
					cust.Active = True
					cust.Manager = 1

					emp.Save()
					empKey = emp.EmployeeID.Value

					Assert.AreEqual(1, emp.CustomerCollectionByStaffAssigned.Count)
					Assert.AreEqual(emp.EmployeeID.Value, cust.StaffAssigned.Value)
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(empKey) Then
					Dim custColl As CustomerCollection = emp.CustomerCollectionByStaffAssigned
					custColl.MarkAllAsDeleted()
					emp.MarkAsDeleted()

					emp.Save()
				End If

				custGroup = New CustomerGroup()
				custGroup.es.Connection.Name = "ForeignKeyTest"

				If custGroup.LoadByPrimaryKey("XXXXX") Then
					custGroup.MarkAsDeleted()
					custGroup.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestSaveSimple()
			Dim empKey As Integer = -1

			Try
				Using scope As New esTransactionScope()
					Dim emp As New Employee()
					emp.es.Connection.Name = "ForeignKeyTest"

					emp.LastName = "LastName"
					emp.FirstName = "FirstName"

					Dim ord As Order = emp.OrderCollectionByEmployeeID.AddNew()
					ord.CustID = "10001"
					ord.CustSub = "001"
					ord.str.OrderDate = "2007-01-01 00:00:00"

					emp.Save()
					empKey = emp.EmployeeID.Value

					Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count)
					Assert.AreEqual(emp.EmployeeID.Value, ord.EmployeeID.Value)
				End Using
			Finally
				' Clean up
				Dim emp As New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(empKey) Then
					Dim ordColl As OrderCollection = emp.OrderCollectionByEmployeeID
					ordColl.MarkAllAsDeleted()
					emp.MarkAsDeleted()
					emp.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestSaveFromCollection()
			Dim empKey As Integer = -1
			Dim custGroup As New CustomerGroup()
			custGroup.es.Connection.Name = "ForeignKeyTest"
			Dim empColl As New EmployeeCollection()
			empColl.es.Connection.Name = "ForeignKeyTest"
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					custGroup.GroupID = "XXXXX"
					custGroup.GroupName = "Test"
					custGroup.Save()

					emp = empColl.AddNew()
					emp.LastName = "LastName"
					emp.FirstName = "FirstName"

					cust = emp.CustomerCollectionByStaffAssigned.AddNew()
					cust.CustomerID = "XXXXX"
					cust.CustomerSub = "XXX"
					cust.CustomerName = "Test"
					cust.str.DateAdded = "2007-01-01 00:00:00"
					cust.Active = True
					cust.Manager = 1

					empColl.Save()
					empKey = emp.EmployeeID.Value

					Assert.AreEqual(1, emp.CustomerCollectionByStaffAssigned.Count)
					Assert.AreEqual(emp.EmployeeID.Value, cust.StaffAssigned.Value)
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(empKey) Then
					Dim custColl As CustomerCollection = emp.CustomerCollectionByStaffAssigned
					custColl.MarkAllAsDeleted()
					emp.MarkAsDeleted()
					emp.Save()
				End If

				custGroup = New CustomerGroup()
				custGroup.es.Connection.Name = "ForeignKeyTest"

				If custGroup.LoadByPrimaryKey("XXXXX") Then
					custGroup.MarkAsDeleted()
					custGroup.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestSaveSimpleCollection()
			Dim empKey As Integer = -1
			Dim empColl As New EmployeeCollection()
			empColl.es.Connection.Name = "ForeignKeyTest"
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					empColl.LoadAll()
					emp = empColl.AddNew()
					emp.LastName = "LastName"
					emp.FirstName = "FirstName"

					Dim ord As Order = emp.OrderCollectionByEmployeeID.AddNew()
					ord.CustID = "10001"
					ord.CustSub = "001"
					ord.str.OrderDate = "2007-01-01 00:00:00"

					empColl.Save()
					empKey = emp.EmployeeID.Value

					Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count)
					Assert.AreEqual(emp.EmployeeID.Value, ord.EmployeeID.Value)
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(empKey) Then
					Dim ordColl As OrderCollection = emp.OrderCollectionByEmployeeID
					ordColl.MarkAllAsDeleted()
					emp.MarkAsDeleted()
					emp.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestSaveSelfReference()
			Dim empKey As Integer = -1
			Dim supvKey As Integer = -1
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"
			Dim supv As New Employee()
			supv.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					emp.LastName = "LastName"
					emp.FirstName = "FirstName"

					supv = emp.EmployeeCollectionBySupervisor.AddNew()
					supv.LastName = "SupvLast"
					supv.FirstName = "SupvFirst"

					emp.Save()
					empKey = emp.EmployeeID.Value
					supvKey = supv.EmployeeID.Value

					Assert.AreEqual(1, emp.EmployeeCollectionBySupervisor.Count)
					Assert.AreEqual(emp.EmployeeID.Value, supv.Supervisor.Value)
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(empKey) Then
					Dim empColl As EmployeeCollection = emp.EmployeeCollectionBySupervisor
					empColl.MarkAllAsDeleted()
					emp.MarkAsDeleted()
					emp.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestSaveComposite()
			Dim ordKey As Integer = -1
			Dim custGroup As New CustomerGroup()
			custGroup.es.Connection.Name = "ForeignKeyTest"
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"
			Dim ord As New Order()
			ord.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					custGroup.GroupID = "XXXXX"
					custGroup.GroupName = "Test"
					custGroup.Save()

					cust.CustomerID = "XXXXX"
					cust.CustomerSub = "XXX"
					cust.CustomerName = "Test"
					cust.str.DateAdded = "2007-01-01 00:00:00"
					cust.Active = True
					cust.Manager = 1

					ord = cust.OrderCollectionByCustID.AddNew()
					ord.str.OrderDate = "2007-12-31 00:00:00"

					cust.Save()
					ordKey = ord.OrderID.Value

					Assert.AreEqual(1, cust.OrderCollectionByCustID.Count)
				End Using
			Finally
				' Clean up
				cust = New Customer()
				cust.es.Connection.Name = "ForeignKeyTest"

				If cust.LoadByPrimaryKey("XXXXX", "XXX") Then
					Dim ordColl As OrderCollection = cust.OrderCollectionByCustID
					ordColl.MarkAllAsDeleted()
					cust.MarkAsDeleted()
					cust.Save()
				End If

				custGroup = New CustomerGroup()
				custGroup.es.Connection.Name = "ForeignKeyTest"

				If custGroup.LoadByPrimaryKey("XXXXX") Then
					custGroup.MarkAsDeleted()
					custGroup.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestEntityDeleteAll()
			Dim prdId As Integer = -1
			Dim prd As New Product()
			prd.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					' Setup
					prd.ProductName = "UnitTest"
					prd.UnitPrice = 1
					prd.Discontinued = False
					For i As Integer = 0 To 2
						Dim oi As OrderItem = prd.OrderItemCollectionByProductID.AddNew()
						oi.OrderID = i + 1
						oi.UnitPrice = prd.UnitPrice
						oi.Quantity = Convert.ToInt16(i)
						oi.Discount = 0
					Next
					prd.Save()
					prdId = prd.ProductID.Value

					' Test
					prd = New Product()
					prd.es.Connection.Name = "ForeignKeyTest"

					Assert.IsTrue(prd.LoadByPrimaryKey(prdId))
					Assert.AreEqual(3, prd.OrderItemCollectionByProductID.Count)
					prd.OrderItemCollectionByProductID.MarkAllAsDeleted()
					prd.MarkAsDeleted()
					prd.Save()

					prd = New Product()
					prd.es.Connection.Name = "ForeignKeyTest"

					Assert.IsFalse(prd.LoadByPrimaryKey(prdId))
				End Using
			Finally
				prd = New Product()
				prd.es.Connection.Name = "ForeignKeyTest"

				If prd.LoadByPrimaryKey(prdId) Then
					prd.OrderItemCollectionByProductID.MarkAllAsDeleted()
					prd.MarkAsDeleted()
					prd.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestCollectionDeleteAll()
			Dim prdId As Integer = -1
			Dim prd As New Product()
			prd.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					prd.ProductName = "UnitTest"
					prd.UnitPrice = 1
					prd.Discontinued = False
					For i As Integer = 0 To 2
						Dim oi As OrderItem = prd.OrderItemCollectionByProductID.AddNew()
						oi.OrderID = i + 1
						oi.UnitPrice = prd.UnitPrice
						oi.Quantity = Convert.ToInt16(i)
						oi.Discount = 0
					Next
					prd.Save()
					prdId = prd.ProductID.Value

					' Test
					Dim collection As New ProductCollection()
					collection.es.Connection.Name = "ForeignKeyTest"

					Assert.IsTrue(collection.LoadAll())
					Dim entity As Product = collection.FindByPrimaryKey(prdId)
					Assert.AreEqual(3, entity.OrderItemCollectionByProductID.Count)
					entity.OrderItemCollectionByProductID.MarkAllAsDeleted()
					entity.MarkAsDeleted()
					collection.Save()

					prd = New Product()
					prd.es.Connection.Name = "ForeignKeyTest"
					Assert.IsFalse(prd.LoadByPrimaryKey(prdId))

					Dim oic As New OrderItemCollection()
					oic.es.Connection.Name = "ForeignKeyTest"
					oic.Query.Where(oic.Query.ProductID = prdId)
					Assert.IsFalse(oic.Query.Load())
				End Using
			Finally
				prd = New Product()
				prd.es.Connection.Name = "ForeignKeyTest"

				If prd.LoadByPrimaryKey(prdId) Then
					prd.OrderItemCollectionByProductID.MarkAllAsDeleted()
					prd.MarkAsDeleted()
					prd.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestMultiDeleteEntity()
			Dim empKey As Integer = -1
			Dim ordKey As Integer = -1
			Dim custGroup As New CustomerGroup()
			custGroup.es.Connection.Name = "ForeignKeyTest"
			Dim empColl As New EmployeeCollection()
			empColl.es.Connection.Name = "ForeignKeyTest"
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"
			Dim testEmp As New Employee()
			testEmp.es.Connection.Name = "ForeignKeyTest"
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"
			Dim ord As New Order()
			ord.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					' Setup
					custGroup.GroupID = "YYYYY"
					custGroup.GroupName = "Test"
					custGroup.Save()

					emp = empColl.AddNew()
					emp.LastName = "LastName"
					emp.FirstName = "FirstName"

					cust = emp.CustomerCollectionByStaffAssigned.AddNew()
					cust.CustomerID = "YYYYY"
					cust.CustomerSub = "YYY"
					cust.CustomerName = "Test"
					cust.str.DateAdded = "2007-01-01 00:00:00"
					cust.Active = True
					cust.Manager = 1

					ord = emp.OrderCollectionByEmployeeID.AddNew()
					ord.CustID = "YYYYY"
					ord.CustSub = "YYY"
					ord.str.OrderDate = "2007-01-01"

					empColl.Save()
					empKey = emp.EmployeeID.Value
					ordKey = ord.OrderID.Value

					Assert.AreEqual(1, emp.CustomerCollectionByStaffAssigned.Count)
					Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count)
					Assert.AreEqual(emp.EmployeeID.Value, cust.StaffAssigned.Value)
					Assert.AreEqual(emp.EmployeeID.Value, ord.EmployeeID.Value)

					' Test
					testEmp.LoadByPrimaryKey(empKey)
					testEmp.OrderCollectionByEmployeeID.MarkAllAsDeleted()
					testEmp.CustomerCollectionByStaffAssigned.MarkAllAsDeleted()
					testEmp.MarkAsDeleted()
					testEmp.Save()

					emp = New Employee()
					emp.es.Connection.Name = "ForeignKeyTest"
					Assert.IsFalse(emp.LoadByPrimaryKey(empKey))

					ord = New Order()
					ord.es.Connection.Name = "ForeignKeyTest"
					Assert.IsFalse(ord.LoadByPrimaryKey(ordKey))

					cust = New Customer()
					cust.es.Connection.Name = "ForeignKeyTest"
					Assert.IsFalse(cust.LoadByPrimaryKey("YYYYY", "YYY"))
				End Using
			Finally
				' Clean up
				ord = New Order()
				ord.es.Connection.Name = "ForeignKeyTest"
				If ord.LoadByPrimaryKey(ordKey) Then
					ord.MarkAsDeleted()
					ord.Save()
				End If

				cust = New Customer()
				cust.es.Connection.Name = "ForeignKeyTest"
				If cust.LoadByPrimaryKey("YYYYY", "YYY") Then
					cust.MarkAsDeleted()
					cust.Save()
				End If

				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"
				If emp.LoadByPrimaryKey(empKey) Then
					emp.MarkAsDeleted()
					emp.Save()
				End If

				custGroup = New CustomerGroup()
				custGroup.es.Connection.Name = "ForeignKeyTest"

				If custGroup.LoadByPrimaryKey("YYYYY") Then
					custGroup.MarkAsDeleted()
					custGroup.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestForeach()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.LoadByPrimaryKey(1)

			Dim i As Integer = 0
			Dim oldKey As String = ""
			For Each cust As Customer In emp.CustomerCollectionByManager
				i += 1
				Dim custKey As String = cust.CustomerID & cust.CustomerSub
				Assert.AreNotEqual(oldKey, custKey)
				oldKey = custKey
			Next

			Assert.AreEqual(35, i)
		End Sub
	End Class
End Namespace
