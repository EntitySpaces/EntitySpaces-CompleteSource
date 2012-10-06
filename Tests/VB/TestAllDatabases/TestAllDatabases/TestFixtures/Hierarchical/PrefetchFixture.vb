'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Collections.Generic
Imports System.Text

Imports NUnit.Framework
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class PrefetchFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub DisableLazyLoad()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"
			emp.es.IsLazyLoadDisabled = True

			emp.LoadByPrimaryKey(1)
			Assert.AreEqual(0, emp.CustomerCollectionByManager.Count)
			Assert.AreEqual(0, emp.CustomerCollectionByStaffAssigned.Count)
			Assert.AreEqual(0, emp.EmployeeCollectionBySupervisor.Count)
			Assert.AreEqual(0, emp.EmployeeTerritoryCollectionByEmpID.Count)
			Assert.AreEqual(0, emp.OrderCollectionByEmployeeID.Count)
			Assert.AreEqual(0, emp.ReferredEmployeeCollectionByEmployeeID.Count)
			Assert.AreEqual(0, emp.ReferredEmployeeCollectionByReferredID.Count)
			Assert.IsNull(emp.UpToEmployeeBySupervisor)
			Assert.AreEqual(0, emp.UpToTerritoryCollection.Count)
		End Sub

		<Test> _
		Public Sub SingleZeroToMany()
			' The main Employee query
			Dim eq1 As New EmployeeQuery("e")
			eq1.Where(eq1.EmployeeID < 3)
			eq1.OrderBy(eq1.EmployeeID.Ascending)

			' The Order Collection
			Dim oq1 As OrderQuery = eq1.Prefetch(Of OrderQuery)(Employee.Prefetch_OrderCollectionByEmployeeID)
			Dim eq2 As EmployeeQuery = oq1.GetQuery(Of EmployeeQuery)()
			oq1.Where(eq2.EmployeeID < 3)

			' Pre-test the Order query
			Dim oColl As New OrderCollection()
			oColl.es.Connection.Name = "ForeignKeyTest"
			oColl.Load(oq1)
			Assert.AreEqual(3, oColl.Count, "Order pre-test")

			' This will Prefetch the Order query
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"
			'coll.es.IsLazyLoadDisabled = true;
			coll.Load(eq1)

			For Each emp As Employee In coll
				emp.es.IsLazyLoadDisabled = True

				Select Case emp.EmployeeID.Value
					Case 1
						Assert.AreEqual(1, emp.EmployeeID.Value)
						Assert.AreEqual(1, emp.OrderCollectionByEmployeeID.Count)
						Exit Select

					Case 2
						Assert.AreEqual(2, emp.EmployeeID.Value)
						Assert.AreEqual(2, emp.OrderCollectionByEmployeeID.Count)
						Exit Select
					Case Else

						Assert.Fail("Only employees 1 and 2 should be loaded.")
						Exit Select
				End Select
			Next
		End Sub

		<Test> _
		Public Sub NestedZeroToMany()
			' The main Employee query
			Dim eq1 As New EmployeeQuery("e")
			eq1.Where(eq1.EmployeeID < 4)
			eq1.OrderBy(eq1.EmployeeID.Ascending)

			' The Order Collection
			Dim oq1 As OrderQuery = eq1.Prefetch(Of OrderQuery)(Employee.Prefetch_OrderCollectionByEmployeeID)
			Dim eq2 As EmployeeQuery = oq1.GetQuery(Of EmployeeQuery)()
			oq1.Where(eq2.EmployeeID < 4 AndAlso oq1.PlacedBy < 3)

			' Pre-test the Order query
			Dim oColl As New OrderCollection()
			oColl.es.Connection.Name = "ForeignKeyTest"
			oColl.Load(oq1)
			Assert.AreEqual(5, oColl.Count, "Order pre-test")

			' The OrderItem Collection
			Dim oiq1 As OrderItemQuery = eq1.Prefetch(Of OrderItemQuery)(Employee.Prefetch_OrderCollectionByEmployeeID, Order.Prefetch_OrderItemCollectionByOrderID)
			Dim eq3 As EmployeeQuery = oiq1.GetQuery(Of EmployeeQuery)()
			Dim oq2 As OrderQuery = oiq1.GetQuery(Of OrderQuery)()
			oiq1.Where(eq3.EmployeeID < 4 AndAlso oq2.PlacedBy < 3 AndAlso oiq1.Quantity < 100)

			' Pre-test the OrderItem query
			Dim oiColl As New OrderItemCollection()
			oiColl.es.Connection.Name = "ForeignKeyTest"
			oiColl.Load(oiq1)
			Assert.AreEqual(4, oiColl.Count, "OrderItem pre-test")

			' Will Prefetch the Order and OrderItems queries
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"
			'coll.es.IsLazyLoadDisabled = true;
			coll.Load(eq1)

			For Each emp As Employee In coll
				emp.es.IsLazyLoadDisabled = True

				Select Case emp.EmployeeID.Value
					Case 1
						Assert.AreEqual(1, emp.EmployeeID.Value)
						Assert.AreEqual(0, emp.OrderCollectionByEmployeeID.Count)
						Exit Select

					Case 2
						Assert.AreEqual(2, emp.EmployeeID.Value)
						Assert.AreEqual(2, emp.OrderCollectionByEmployeeID.Count)

						For Each o As Order In emp.OrderCollectionByEmployeeID
							Assert.Less(0, o.OrderItemCollectionByOrderID.Count)
						Next
						Exit Select

					Case 3
						Assert.AreEqual(3, emp.EmployeeID.Value)
						Assert.AreEqual(3, emp.OrderCollectionByEmployeeID.Count)

						For Each o As Order In emp.OrderCollectionByEmployeeID
							Assert.AreEqual(0, o.OrderItemCollectionByOrderID.Count)
						Next
						Exit Select
					Case Else

						Assert.Fail("Only employees 1, 2, and 3 should be loaded.")
						Exit Select
				End Select
			Next
		End Sub
	End Class
End Namespace
