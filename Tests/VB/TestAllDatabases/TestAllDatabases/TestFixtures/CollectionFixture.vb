'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports System.Linq
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class CollectionFixture
		<Test> _
		Public Sub CollectionFindByPrimaryKey()
			Dim aggTest As New AggregateTest()
			aggTest.Query.[Select]().Where(aggTest.Query.FirstName.Equal("Sarah"), aggTest.Query.LastName.Equal("Doe"))
			Assert.IsTrue(aggTest.Query.Load())
			Dim primaryKey As Integer = aggTest.Id.Value

			Dim aggCloneColl As New AggregateTestCollection()
			aggCloneColl.LoadAll()
			Dim aggClone As AggregateTest = aggCloneColl.FindByPrimaryKey(primaryKey)
			Assert.AreEqual("Doe", aggClone.str.LastName)
			Assert.AreEqual("Sarah", aggClone.str.FirstName)
		End Sub

		<Test> _
		Public Sub CollectionSort()
			Dim aggTestColl As New AggregateTestCollection()
			aggTestColl.LoadAll()
            'aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(Function(s As ) s.Age)
            aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(Function(s As AggregateTest) s.Age)

			Dim oldAge As System.Nullable(Of Integer) = 0
			For Each agg As AggregateTest In aggTestColl
				If agg.Age.HasValue Then
                    Assert.IsTrue(CBool(oldAge <= agg.Age))
					oldAge = agg.Age
				End If
			Next

            aggTestColl.Filter = aggTestColl.AsQueryable().OrderByDescending(Function(s As AggregateTest) s.Age)

			oldAge = 1000
			For Each agg As AggregateTest In aggTestColl
				If agg.Age.HasValue Then
                    Assert.IsTrue(CBool(oldAge >= agg.Age))
					oldAge = agg.Age
				End If
			Next

			aggTestColl.Filter = Nothing

			Dim sorted As Boolean = True
			oldAge = 0
			For Each agg As AggregateTest In aggTestColl
				If agg.Age.HasValue Then
					If Not (oldAge <= agg.Age) Then
						sorted = False
					End If
					oldAge = agg.Age
				End If
			Next
			Assert.IsFalse(sorted)
		End Sub

		<Test> _
		Public Sub CollectionSortDate()
			Dim aggTestColl As New AggregateTestCollection()
			aggTestColl.LoadAll()
            aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(Function(s As AggregateTest) s.HireDate)

			Dim oldDate As System.Nullable(Of DateTime) = Convert.ToDateTime("01/01/0001")
			For Each agg As AggregateTest In aggTestColl
				If agg.HireDate.HasValue Then
                    Assert.IsTrue(CBool(oldDate <= agg.HireDate))
					oldDate = agg.HireDate
				End If
			Next
		End Sub

		<Test> _
		Public Sub CollectionFilter()
			Dim aggTestColl As New AggregateTestCollection()
			aggTestColl.LoadAll()
            Assert.AreEqual(30, aggTestColl.Count)
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(Function(f As AggregateTest) f.LastName = "Doe")
            Assert.AreEqual(3, aggTestColl.Count)

			For Each agg As AggregateTest In aggTestColl
				Assert.AreEqual("Doe", agg.LastName)
			Next

			aggTestColl.Filter = Nothing
            Assert.AreEqual(30, aggTestColl.Count)

            aggTestColl.Filter = aggTestColl.AsQueryable().Where(Function(f As AggregateTest) f.LastName = "x")
            Assert.AreEqual(0, aggTestColl.Count)
			aggTestColl.Filter = Nothing
            Assert.AreEqual(30, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub CollectionFilterDate()
			Dim aggTestColl As New AggregateTestCollection()
			aggTestColl.LoadAll()
            aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(Function(s As AggregateTest) s.Id)

            Dim entity As AggregateTest = CType(aggTestColl(5), AggregateTest)
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(Function(f As AggregateTest) f.HireDate.HasValue AndAlso CBool(f.HireDate > entity.HireDate))

            Assert.AreEqual(4, aggTestColl.Count)

			aggTestColl.Filter = Nothing
            Assert.AreEqual(30, aggTestColl.Count)
		End Sub

		'[Test]
		'public void AssignPrimaryKeysTest()
		'{
		'    AggregateTestCollection aggTestColl = new AggregateTestCollection();
		'    Assert.IsTrue(aggTestColl.LoadAll());
		'    Assert.AreEqual(1, aggTestColl.TestAssignPrimaryKeys());
		'    Assert.AreEqual(0, aggTestColl.TestRemovePrimaryKeys());
		'}

		<Test> _
		Public Sub FilteredDeleteAll()
			Dim aggTestColl As New AggregateTestCollection()
			aggTestColl.LoadAll()
            Assert.AreEqual(30, aggTestColl.Count)
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(Function(f As AggregateTest) f.LastName = "Doe")
            Assert.AreEqual(3, aggTestColl.Count)

			aggTestColl.MarkAllAsDeleted()

			aggTestColl.Filter = Nothing
            Assert.AreEqual(27, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub TestForEach()
			Dim aggTestColl As New AggregateTestCollection()
			aggTestColl.LoadAll()
			For Each entity As AggregateTest In aggTestColl
				entity.LastName = "E_" & entity.LastName
			Next
            aggTestColl.Filter = aggTestColl.AsQueryable().Where(Function(f As AggregateTest) f.LastName.Contains("E_"))
            Assert.AreEqual(30, aggTestColl.Count)
		End Sub

        <Test()> _
        Public Sub TestCustomForEach()
            AggregateTestCollection.CustomForEach()
        End Sub

        <Test()> _
        Public Sub TestAttachDetachEntityModified()
            Try
                Using scope As New esTransactionScope()
                    Dim aggTestColl As New AggregateTestCollection()
                    Dim aggCloneColl As New AggregateTestCollection()
                    aggCloneColl.LoadAll()
                    For Each entity As AggregateTest In aggCloneColl
                        If entity.LastName = "Doe" Then
                            entity.MarkAllColumnsAsDirty(esDataRowState.Modified)
                            aggTestColl.AttachEntity(aggCloneColl.DetachEntity(entity))
                            Exit For
                        End If
                    Next
                    Assert.IsTrue(aggTestColl.IsDirty)
                    aggTestColl.Save()
                    Assert.IsFalse(aggTestColl.IsDirty, "Collection is still dirty")
                    aggTestColl.LoadAll()
                    Assert.AreEqual(30, aggTestColl.Count)
                End Using
            Finally
                UnitTestBase.RefreshDatabase()
            End Try
        End Sub

		<Test> _
		Public Sub TestAttachDetachEntityAdded()
			Try
				Using scope As New esTransactionScope()
					Dim aggTestColl As New AggregateTestCollection()
					Dim aggCloneColl As New AggregateTestCollection()
					aggCloneColl.LoadAll()
					For Each entity As AggregateTest In aggCloneColl
						If entity.LastName = "Doe" Then
							entity.MarkAllColumnsAsDirty(esDataRowState.Added)
							aggTestColl.AttachEntity(aggCloneColl.DetachEntity(entity))
							Exit For
						End If
					Next
					Assert.IsTrue(aggTestColl.IsDirty)
					aggTestColl.Save()
					Assert.IsFalse(aggTestColl.IsDirty, "Collection is still dirty")
					aggTestColl.LoadAll()
                    Assert.AreEqual(31, aggTestColl.Count)
				End Using
			Finally
				UnitTestBase.RefreshDatabase()
			End Try
		End Sub

		<Test> _
		Public Sub CombineCollections()
			Dim coll As New OrderItemCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

			coll.LoadAll()
            Assert.AreEqual(15, coll.Count)

			Dim coll2 As New OrderItemCollection()
			coll2.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll2.es.Connection)

			coll2.LoadAll()
            Assert.AreEqual(15, coll2.Count)

			coll.Combine(coll2)
            Assert.AreEqual(30, coll.Count)
		End Sub

		<Test> _
		Public Sub CombineQueriedCollections()
			Dim coll As New OrderItemCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

			coll.Query.Where(coll.Query.ProductID = 1)
			coll.Query.Load()
            Assert.AreEqual(4, coll.Count)

			Dim coll2 As New OrderItemCollection()
			coll2.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll2.es.Connection)

			coll2.Query.Where(coll2.Query.ProductID = 2)
			coll2.Query.Load()
            Assert.AreEqual(3, coll2.Count)

			coll.Combine(coll2)
            Assert.AreEqual(7, coll.Count)
		End Sub

		<Test> _
		Public Sub CombineJoinQueriedCollections()
			Dim eq1 As New EmployeeQuery("e1")
			Dim cq1 As New CustomerQuery("c1")

			eq1.[Select](eq1, cq1.CustomerName)
			eq1.InnerJoin(cq1).[On](eq1.EmployeeID = cq1.Manager)
			eq1.Where(eq1.EmployeeID = 1)

			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)
			collection.Load(eq1)
            Assert.AreEqual(35, collection.Count)

			Dim eq2 As New EmployeeQuery("e2")
			Dim cq2 As New CustomerQuery("c2")

			eq2.[Select](eq2, cq2.CustomerName)
			eq2.InnerJoin(cq2).[On](eq2.EmployeeID = cq2.Manager)
			eq2.Where(eq2.EmployeeID = 2)

			Dim collection2 As New EmployeeCollection()
			collection2.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection2.es.Connection)
			collection2.Load(eq2)
            Assert.AreEqual(12, collection2.Count)

			collection.Combine(collection2)
            Assert.AreEqual(47, collection.Count)

			For Each emp As Employee In collection
				Dim custName As String = CustomerMetadata.ColumnNames.CustomerName
				Assert.IsTrue(emp.GetColumn(custName).ToString().Length > 0)
			Next
		End Sub

		<Test> _
		Public Sub CombineFilteredOriginal()
			' Load a collection and apply a filter
			Dim coll As New OrderItemCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

			coll.LoadAll()
            Assert.AreEqual(15, coll.Count)
            'coll.Filter = coll.AsQueryable().Where(Function(f As OrderItem) f.ProductID = 1)
            coll.Filter = coll.AsQueryable().Where(Function(f As OrderItem) CBool(f.ProductID = 1))
            Assert.AreEqual(4, coll.Count)

			' Load a second collection
			Dim coll2 As New OrderItemCollection()
			coll2.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll2.es.Connection)

			coll2.LoadAll()
            Assert.AreEqual(15, coll2.Count)

			' Combine the 15 rows from the second collection
			' to the 15 rows from the first collection.
			' Since the first collection still has a filter,
			' only 8 rows are counted (4 from the first and 4 from the second).
			coll.Combine(coll2)
            Assert.AreEqual(8, coll.Count)

			' Remove the filter to count all 30 rows.
			coll.Filter = Nothing
            Assert.AreEqual(30, coll.Count)
		End Sub

		<Test> _
		Public Sub CombineFilteredCombine()
			Dim coll As New OrderItemCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

			coll.LoadAll()
            Assert.AreEqual(15, coll.Count)

			Dim coll2 As New OrderItemCollection()
			coll2.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll2.es.Connection)

			coll2.LoadAll()
            Assert.AreEqual(15, coll2.Count)
            coll2.Filter = coll.AsQueryable().Where(Function(f As OrderItem) CBool(f.ProductID = 1))
            Assert.AreEqual(4, coll2.Count)

			coll.Combine(coll2)
            Assert.AreEqual(19, coll.Count)
		End Sub

		<Test> _
		Public Sub CombineFilteredOriginalAndCombine()
			' Load a collection and apply a filter.
			Dim coll As New OrderItemCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

			coll.LoadAll()
            Assert.AreEqual(15, coll.Count)
            coll.Filter = coll.AsQueryable().Where(Function(f As OrderItem) CBool(f.ProductID = 1))
            Assert.AreEqual(4, coll.Count)

			' Load a second collection and apply a different filter.
			Dim coll2 As New OrderItemCollection()
			coll2.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll2.es.Connection)

			coll2.LoadAll()
            Assert.AreEqual(15, coll2.Count)
            coll2.Filter = coll2.AsQueryable().Where(Function(f As OrderItem) CBool(f.ProductID = 2))
            Assert.AreEqual(3, coll2.Count)

			' Add only the 3 filtered rows from coll2
			' to all 15 rows in coll1.
			' The filter for coll1 still applies.
			' None of the items from coll2 appear,
			' until the filter is removed from coll1.
			coll.Combine(coll2)
            Assert.AreEqual(4, coll.Count)
			coll.Filter = Nothing
            Assert.AreEqual(18, coll.Count)
		End Sub

		<Test> _
		Public Sub CombineBuildOriginal()
			' Start with an empty collection
			Dim coll As New OrderItemCollection()
			coll.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll.es.Connection)

            Assert.AreEqual(0, coll.Count)

			Dim coll2 As New OrderItemCollection()
			coll2.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll2.es.Connection)

			coll2.LoadAll()
            Assert.AreEqual(15, coll2.Count)
            coll2.Filter = coll2.AsQueryable().Where(Function(f As OrderItem) CBool(f.ProductID = 1))
            Assert.AreEqual(4, coll2.Count)

			' Add only the 4 filtered rows for coll2
			coll.Combine(coll2)
            Assert.AreEqual(4, coll.Count)

			Dim coll3 As New OrderItemCollection()
			coll3.es.Connection.ConnectionString = UnitTestBase.GetFktString(coll3.es.Connection)

			coll3.LoadAll()
            Assert.AreEqual(15, coll3.Count)
            coll3.Filter = coll3.AsQueryable().Where(Function(f As OrderItem) CBool(f.ProductID = 2))
            Assert.AreEqual(3, coll3.Count)

			' Add only the 3 filtered rows for coll3
			' coll1 now has all 7 rows
			coll.Combine(coll3)
            Assert.AreEqual(7, coll.Count)
		End Sub

	End Class
End Namespace
