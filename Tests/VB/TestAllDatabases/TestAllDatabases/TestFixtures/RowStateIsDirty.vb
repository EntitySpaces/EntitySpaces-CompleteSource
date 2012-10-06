'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Collections.Generic
Imports System.Text

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;

Imports EntitySpaces.Interfaces

Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class RowStateIsDirty
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

		#Region "Single Entity"

		<Test> _
		Public Sub TestAddNewOnEntity()
			aggTest = New AggregateTest()
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			' Assert.IsTrue(aggTest.es.RowState == esDataRowState.Detached);

			' We set a property which creates the DataTable
			aggTest.FirstName = "Mike"

			Assert.IsTrue(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsTrue(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 1)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Added)
		End Sub

		<Test> _
		Public Sub TestAcceptChangesOnEntity()
			aggTest = New AggregateTest()
			aggTest.FirstName = "Mike"
			aggTest.AcceptChanges()

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsFalse(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Unchanged)
		End Sub

		<Test> _
		Public Sub TestRejectChangesOnEntity1()
			aggTest = New AggregateTest()
			aggTest.FirstName = "Mike"
			aggTest.RejectChanges()

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsFalse(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Unchanged)
		End Sub

		<Test> _
		Public Sub TestRejectChangesOnEntity2()
			aggTest = New AggregateTest()
			aggTest.FirstName = "Mike"
			aggTest.AcceptChanges()

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsFalse(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Unchanged)

			aggTest.FirstName = "Joe"
			aggTest.RejectChanges()

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsFalse(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Unchanged)
		End Sub

		<Test> _
		Public Sub TestTrueIsDirtyLogicOnEntity()
			aggTest = New AggregateTest()
			aggTest.FirstName = "Mike"
			aggTest.AcceptChanges()

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsFalse(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Unchanged)

			' Let's change it
			aggTest.FirstName = "Joe"

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsTrue(aggTest.es.IsModified)
			Assert.IsTrue(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 1)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Modified)

			' Now let's set it back to it's original value
			aggTest.FirstName = "Mike"

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsFalse(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Unchanged)

			' Let's change it again, notice we are no longer dirty now
			aggTest.FirstName = "Joe"

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsTrue(aggTest.es.IsModified)
			Assert.IsTrue(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 1)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Modified)
		End Sub

		<Test> _
		Public Sub TestDeleteOnEntity()
			aggTest = New AggregateTest()
			aggTest.FirstName = "Mike"
			aggTest.AcceptChanges()

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsFalse(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsFalse(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Unchanged)

			' Let's mark it as deleted
			aggTest.MarkAsDeleted()

			Assert.IsFalse(aggTest.es.IsAdded)
			Assert.IsTrue(aggTest.es.IsDeleted)
			Assert.IsFalse(aggTest.es.IsModified)
			Assert.IsTrue(aggTest.es.IsDirty)
			Assert.IsTrue(aggTest.es.ModifiedColumns.Count = 0)
			Assert.IsTrue(aggTest.es.RowState = esDataRowState.Deleted)
		End Sub

		#End Region

		#Region "Collections"

		<Test> _
		Public Sub TestAddNewOnCollection()
			aggTestColl = New AggregateTestCollection()
			Assert.IsFalse(aggTestColl.IsDirty)

			Dim t As AggregateTest = aggTestColl.AddNew()
			Assert.IsTrue(aggTestColl.IsDirty)
		End Sub

		<Test> _
		Public Sub TestAcceptChangesOnCollection()
			aggTestColl = New AggregateTestCollection()

			Dim aggTest As AggregateTest = aggTestColl.AddNew()
			aggTest.FirstName = "Mike"

			aggTestColl.AcceptChanges()

			Assert.IsFalse(aggTestColl.IsDirty)
		End Sub

		<Test> _
		Public Sub TestRejectChangesOnCollection()
			aggTestColl = New AggregateTestCollection()

			Dim aggTest As AggregateTest = aggTestColl.AddNew()
			aggTest.FirstName = "Mike"

			aggTestColl.RejectChanges()

			Assert.IsFalse(aggTestColl.IsDirty)
		End Sub

		<Test> _
		Public Sub TestRejectChangesOnCollection2()
			aggTestColl = New AggregateTestCollection()

			Dim aggTest As AggregateTest = aggTestColl.AddNew()
			aggTest.FirstName = "Mike"

			aggTestColl.AcceptChanges()

			Assert.IsFalse(aggTestColl.IsDirty)

			aggTest.FirstName = "Joe"
			aggTest.RejectChanges()

			Assert.IsFalse(aggTestColl.IsDirty)
		End Sub

		<Test> _
		Public Sub TestTrueIsDirtyLogicOnCollection()
			aggTestColl = New AggregateTestCollection()

			Dim aggTest As AggregateTest = aggTestColl.AddNew()
			aggTest.FirstName = "Mike"

			aggTestColl.AcceptChanges()
			Assert.IsFalse(aggTestColl.IsDirty)

			' Let's change it
			aggTest.FirstName = "Joe"
			Assert.IsTrue(aggTestColl.IsDirty)

			' Now let's set it back to it's original value
			aggTest.FirstName = "Mike"
			Assert.IsFalse(aggTestColl.IsDirty)

			' Let's change it again, notice we are no longer dirty now
			aggTest.FirstName = "Joe"
			Assert.IsTrue(aggTestColl.IsDirty)
		End Sub

		<Test> _
		Public Sub TestDeleteOnCollection()
			aggTestColl = New AggregateTestCollection()

			Dim aggTest As AggregateTest = aggTestColl.AddNew()
			aggTest.FirstName = "Mike"

			aggTestColl.AcceptChanges()
			Assert.IsFalse(aggTestColl.IsDirty)

			' Let's mark it as deleted
			aggTest.MarkAsDeleted()
			Assert.IsTrue(aggTestColl.IsDirty)
		End Sub

		#End Region
	End Class
End Namespace
