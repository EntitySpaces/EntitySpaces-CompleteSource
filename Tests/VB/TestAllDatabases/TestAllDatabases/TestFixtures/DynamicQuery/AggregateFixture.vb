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
	Public Class AggregateFixture
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
		Public Sub EmptyQueryReturnsSelectAll()
			aggTestColl = New AggregateTestCollection()
			Assert.IsTrue(aggTestColl.LoadAll())
			Assert.AreEqual(30, aggTestColl.Count, "LoadAll")

			aggTestColl = New AggregateTestCollection()
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(30, aggTestColl.Count, "Query.Load")

			aggTestColl = New AggregateTestCollection()
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
			If aggTestColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not supported by SqlCe.")
			Else
				aggTestColl.Query.[Select](aggTestColl.Query.Salary.StdDev().[As]("Std Dev"))
				Assert.IsTrue(aggTestColl.Query.Load())
				Assert.AreEqual(1, aggTestColl.Count)
			End If
		End Sub

		<Test> _
		Public Sub AddAggregateVar()
			If aggTestColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not supported by SqlCe.")
			Else
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
			End If
		End Sub

		<Test> _
		Public Sub AddAggregateCountAllDefaultAlias()
			aggTestColl.Query.es.CountAll = True
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count, "Retrieved 1 row.")

			Dim aggCount As Integer = Convert.ToInt32(aggTestColl(0).GetColumn("Count"))
			Assert.AreEqual(30, aggCount, "Value equals 30.")
		End Sub

		<Test> _
		Public Sub AddAggregateCountAll()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Total"
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count, "Retrieved 1 row.")

			Dim aggCount As Integer = Convert.ToInt32(aggTestColl(0).GetColumn("Total"))
			Assert.AreEqual(30, aggCount, "Value equals 30.")
		End Sub

		<Test> _
		Public Sub AddAggregateCountAllAliasReversed()
			aggTestColl.Query.es.CountAllAlias = "Total"
			aggTestColl.Query.es.CountAll = True
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count, "Retrieved 1 row.")

			Dim aggCount As Integer = Convert.ToInt32(aggTestColl(0).GetColumn("Total"))
			Assert.AreEqual(30, aggCount, "Value equals 30.")
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
		Public Sub AliasAndGetColumn()
			Dim totalNo As Integer = 0
			Dim collection As New AggregateTestCollection()
			collection.Query.[Select](collection.Query.Age.Sum().[As]("total"))
			collection.Query.Load()
			totalNo = Convert.ToInt32(collection(0).GetColumn("total"))
			Assert.AreEqual(726, totalNo)
		End Sub

		<Test> _
		Public Sub DistinctAggregate()
			If aggTestColl.es.Connection.ProviderSignature.DataProviderName = "EntitySpaces.SqlServerCeProvider.CF" Then
				Assert.Ignore("Not supported by SqlCe.")
			Else
				Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider"
						Assert.Ignore("Not Supported")
						Exit Select
					Case Else
						aggTestColl.Query.[Select](aggTestColl.Query.LastName.Count().Distinct().[As]("Count"))
						Assert.IsTrue(aggTestColl.Query.Load())
						Dim testTable As DataTable = aggTestColl.Query.LoadDataTable()
						Dim currRows As DataRow() = testTable.[Select](Nothing, Nothing, DataViewRowState.CurrentRows)
						Dim testRow As DataRow = currRows(0)
						Assert.AreEqual(10, testRow(0))
						Exit Select
				End Select
			End If
		End Sub

	End Class
End Namespace
