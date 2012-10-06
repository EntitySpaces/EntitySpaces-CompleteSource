'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Linq
Imports System.Collections.Generic
Imports System.Text

Imports NUnit.Framework

Imports EntitySpaces.Core
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class CollectionViewFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub ViewOnCollection()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.ToUpper() = "DOE")
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)

			Dim view1 As New esEntityCollectionView(Of AggregateTest)(collection)
			Assert.AreEqual(3, view1.Count)
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub ViewOnFilteredCollection()
			Dim collection As New AggregateTestCollection()
			collection.Query.Load()
            Assert.AreEqual(30, collection.Count)
            collection.Filter = collection.AsQueryable().Where(Function(f As AggregateTest) f.LastName = "Doe")
            Assert.AreEqual(3, collection.Count)

			Dim view1 As New esEntityCollectionView(Of AggregateTest)(collection)
			Assert.AreEqual(30, view1.Count)
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub FilteredViewOnFilteredCollection()
			Dim collection As New AggregateTestCollection()
			collection.Query.Load()
            Assert.AreEqual(30, collection.Count)
            collection.Filter = collection.AsQueryable().Where(Function(d As AggregateTest) d.LastName = "Doe")
            Assert.AreEqual(3, collection.Count)

			Dim view1 As New esEntityCollectionView(Of AggregateTest)(collection)
			Assert.AreEqual(30, view1.Count)
            view1.Filter = view1.AsQueryable().Where(Function(f As AggregateTest) f.Age.HasValue AndAlso CBool(f.Age > 20))
			Assert.AreEqual(18, view1.Count)
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TwoFilteredViewsOnFilteredCollection()
			Dim collection As New AggregateTestCollection()
			collection.Query.Load()
            Assert.AreEqual(30, collection.Count)
            collection.Filter = collection.AsQueryable().Where(Function(f As AggregateTest) f.LastName = "Doe")
            Assert.AreEqual(3, collection.Count)

			Dim view1 As New esEntityCollectionView(Of AggregateTest)(collection)
			Assert.AreEqual(30, view1.Count)
            view1.Filter = view1.AsQueryable().Where(Function(f As AggregateTest) f.Age.HasValue AndAlso CBool(f.Age > 20))
			Assert.AreEqual(18, view1.Count)
            Assert.AreEqual(3, collection.Count)

			Dim view2 As New esEntityCollectionView(Of AggregateTest)(collection)
			Assert.AreEqual(30, view2.Count)
            view2.Filter = view2.AsQueryable().Where(Function(f As AggregateTest) f.FirstName = "John")
			Assert.AreEqual(2, view2.Count)
			Assert.AreEqual(18, view1.Count)
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub IterateSortedViewAndCollection()
			Dim collection As New AggregateTestCollection()
			collection.Query.Load()
            collection.Filter = collection.AsQueryable().OrderBy(Function(s As AggregateTest) s.LastName)

			Dim view1 As New esEntityCollectionView(Of AggregateTest)(collection)
            view1.Filter = view1.AsQueryable().OrderByDescending(Function(s As AggregateTest) s.LastName)

			Dim prevName As String = collection(0).LastName
			For Each at As AggregateTest In collection
				Assert.IsTrue([String].Compare(prevName, at.LastName) <= 0)
				prevName = at.LastName
			Next

			prevName = view1(0).LastName
			For Each at As AggregateTest In view1
				Assert.IsTrue([String].Compare(prevName, at.LastName) >= 0)
				prevName = at.LastName
			Next
		End Sub

	End Class
End Namespace
