'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================


Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Namespace Tests.Base
	<TestFixture> _
	Public Class ViewGroupByFixture
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
		Public Sub OneGroupBy()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive).GroupBy(aggTestColl.Query.IsActive)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub TwoGroupBy()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithWhere()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithWhereAndOrderBy()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithOrderByCountAll()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"

			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy("<Count(*)>", esOrderByDirection.Ascending)
					Exit Select
				Case Else
					aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.es.CountAllAlias, esOrderByDirection.Ascending)
					Exit Select
			End Select
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithTop()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			aggTestColl.Query.es.Top = 3
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(aggTestColl.Query.es.Top, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithDistinct()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			aggTestColl.Query.es.Distinct = True
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithTearoff()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.Sum().[As]("Sum"), aggTestColl.Query.Salary.Min().[As]("Min"), aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(5, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub GroupByWithRollup()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider", "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.SQLiteProvider"
					Assert.Ignore("Not Supported")
					Exit Select
				' For MySQL GROUP BY and ORDER BY are mutually exclusive.
				Case "EntitySpaces.MySqlClientProvider"
					aggTestColl.Query.es.CountAll = True
					aggTestColl.Query.es.CountAllAlias = "Count"
					aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID)
					aggTestColl.Query.es.WithRollup = True
					Assert.IsTrue(aggTestColl.Query.Load())
					Assert.AreEqual(7, aggTestColl.Count)
					Exit Select
				Case Else
					aggTestColl.Query.es.CountAll = True
					aggTestColl.Query.es.CountAllAlias = "Count"
					aggTestColl.Query.[Select](aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).Where(aggTestColl.Query.IsActive.Equal(True)).GroupBy(aggTestColl.Query.IsActive, aggTestColl.Query.DepartmentID).OrderBy(aggTestColl.Query.DepartmentID.Ascending, aggTestColl.Query.IsActive.Ascending)
					aggTestColl.Query.es.WithRollup = True
					Assert.IsTrue(aggTestColl.Query.Load())
					Assert.AreEqual(7, aggTestColl.Count)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub GroupByFullName()
			aggTestColl.Query.es.CountAll = True
			aggTestColl.Query.es.CountAllAlias = "Count"
			aggTestColl.Query.[Select](aggTestColl.Query.FullName).GroupBy(aggTestColl.Query.FullName)
			Assert.IsTrue(aggTestColl.Query.Load())
			Select Case aggTestColl.es.Connection.Name
				Case "ACCESS"
					Assert.AreEqual(16, aggTestColl.Count)
					Exit Select
				Case Else
					Assert.AreEqual(16, aggTestColl.Count)
					Exit Select
			End Select
		End Sub

	End Class
End Namespace
