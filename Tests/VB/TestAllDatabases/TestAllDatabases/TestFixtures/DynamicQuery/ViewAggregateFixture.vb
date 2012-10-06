'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Namespace Tests.Base
	<TestFixture> _
	Public Class ViewAggregateFixture
		Private aggTestColl As New FullNameViewCollection()
		Private aggTest As New FullNameView()
		Private aggTestQuery As New FullNameViewQuery()

		<TestFixtureSetUp> _
		Public Sub Init()
			If aggTestColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not supported by SqlCe.")
			End If
		End Sub

		<SetUp> _
		Public Sub Init2()
			aggTestColl = New FullNameViewCollection()
			aggTest = New FullNameView()
			aggTestQuery = New FullNameViewQuery()
		End Sub

		<Test> _
		Public Sub EmptyQueryReturnsSelectAll()
			aggTestColl = New FullNameViewCollection()
			If aggTestColl.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL Then
				Assert.IsTrue(aggTestColl.LoadAll())
				Assert.AreEqual(16, aggTestColl.Count, "LoadAll")
			End If

			aggTestColl = New FullNameViewCollection()
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count, "Query.Load")

			aggTestColl = New FullNameViewCollection()
			aggTestColl.Query.LoadDataTable()
			Assert.AreEqual(0, aggTestColl.Count, "Query.LoadDataTable")
		End Sub

		<Test> _
		Public Sub AddAggregateAvg()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Avg().[As]("Avg"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AddAggregateCount()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Count().[As]("Count"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AddAggregateMin()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Min().[As]("Min"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AddAggregateMax()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Max().[As]("Max"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AddAggregateSum()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Sum().[As]("Sum"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AddAggregateStdDev()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.StdDev().[As]("Std Dev"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AddAggregateVar()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.Ignore("Not Supported")
					Exit Select
				Case Else
					aggTestColl.Query.[Select](aggTestColl.Query.Salary.Var().[As]("Var"))
					Assert.IsTrue(aggTestColl.Query.Load())
					Assert.AreEqual(1, aggTestColl.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub AddAggregateCountAll()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Total"
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AddTwoAggregates()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Sum().[As]("Sum"))
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Total"
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AggregateWithTearoff()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Sum().[As]("Sum"), aggTestColl.Query.Salary.Min().[As]("Min"))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub AggregateWithWhere()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Total"
			aggTestColl.Query.Where(aggTestColl.Query.IsActive.Equal(True))
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub EmptyAliasUsesColumnName()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Sum())
			Assert.IsTrue(aggTestColl.Query.Load())

            Dim iQuery As IDynamicQuerySerializableInternal = TryCast(aggTestColl.Query, IDynamicQuerySerializableInternal)
			Assert.AreEqual("Salary", iQuery.InternalSelectColumns(0).Column.[Alias])

			'Assert.AreEqual("Salary", aggTestColl.Query.Salary.Sum().Alias);
		End Sub

		<Test> _
		Public Sub DistinctAggregate()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not Supported")
					Exit Select
				Case Else
					aggTestColl.Query.[Select](aggTestColl.Query.FullName.Count().Distinct().[As]("Count"))
					Assert.IsTrue(aggTestColl.Query.Load())
					Dim testTable As DataTable = aggTestColl.Query.LoadDataTable()
					Dim currRows As DataRow() = testTable.[Select](Nothing, Nothing, DataViewRowState.CurrentRows)
					Dim testRow As DataRow = currRows(0)
					Assert.AreEqual(16, testRow(0))
					Exit Select
			End Select
		End Sub

	End Class
End Namespace
