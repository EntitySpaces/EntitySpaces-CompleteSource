'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.IO

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.DynamicQuery

Namespace Tests.Base
	<TestFixture> _
	Public Class LoadFixture
		Private aggTestColl As New AggregateTestCollection()
		Private aggTest As New AggregateTest()
		Private aggTestQuery As New AggregateTestQuery()
		Private aggCloneColl As New AggregateTestCollection()
		Private aggClone As New AggregateTest()
		Private aggCloneQuery As New AggregateTestQuery()
		Private viewColl As New FullNameViewCollection()

		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
			aggTestColl = New AggregateTestCollection()
			aggTest = New AggregateTest()
			aggTestQuery = New AggregateTestQuery()
			aggCloneColl = New AggregateTestCollection()
			aggClone = New AggregateTest()
			aggCloneQuery = New AggregateTestQuery()
		End Sub

		<Test> _
		Public Sub EntityLoadByPrimaryKey()
			aggTest.Query.[Select]().Where(aggTest.Query.FirstName.Equal("Sarah"), aggTest.Query.LastName.Equal("Doe"))
			Assert.IsTrue(aggTest.Query.Load())
			Dim primaryKey As Integer = aggTest.Id.Value

			Assert.IsTrue(aggClone.LoadByPrimaryKey(primaryKey))
			Assert.AreEqual("Doe", aggClone.str.LastName)
			Assert.AreEqual("Sarah", aggClone.str.FirstName)
		End Sub

		<Test> _
		Public Sub EntityLoadByPrimaryKeyChar()
			Dim cg As New CustomerGroup()
			cg.es.Connection.Name = "ForeignKeyTest"

			Assert.IsTrue(cg.LoadByPrimaryKey("05001"))
		End Sub

		<Test> _
		Public Sub EntityLoadByPrimaryKeyFalse()
			Assert.IsFalse(aggTest.LoadByPrimaryKey(-1))
		End Sub

		<Test> _
		Public Sub EntityQueryLoadFalse()
			aggTest.Query.[Select]().Where(aggTest.Query.FirstName.Equal("x"), aggTest.Query.LastName.Equal("x"))
			Assert.IsFalse(aggTest.Query.Load())
		End Sub

		<Test> _
		Public Sub EntityMultiFail()
			Dim failed As Boolean = False
			Try
				aggTest.Query.[Select]().Where(aggTest.Query.FirstName.Equal("Sarah"), aggTest.Query.LastName.Equal("McDonald"))
				aggTest.Query.Load()
			Catch ex As Exception
				failed = True
				Assert.AreEqual("An Entity can only hold 1 record of data", ex.Message)
			End Try

			If Not failed Then
				Assert.Fail("Exception not thrown.")
			End If
		End Sub

		<Test> _
		Public Sub EntityTop()
			aggTest.Query.[Select]().Where(aggTest.Query.FirstName.Equal("Sarah"), aggTest.Query.LastName.Equal("McDonald"))
			aggTest.Query.es.Top = 1
			Assert.IsTrue(aggTest.Query.Load())

			Assert.AreEqual("McDonald", aggTest.str.LastName)
			Assert.AreEqual("Sarah", aggTest.str.FirstName)
		End Sub

		<Test> _
		Public Sub EntityQueryReset()
			aggTest.Query.Where(aggTest.Query.FirstName.Equal("Sarah"), aggTest.Query.LastName.Equal("Doe"))
			Assert.IsTrue(aggTest.Query.Load())

			aggTest = New AggregateTest()
			aggTest.Query.Where(aggTest.Query.FirstName.Equal("Fred"), aggTest.Query.LastName.Equal("Costner"))
			aggTest.Query.Load()
			Assert.IsTrue(aggTest.Query.Load())

			Assert.AreEqual("Costner", aggTest.str.LastName)
			Assert.AreEqual("Fred", aggTest.str.FirstName)
		End Sub

		<Test> _
		Public Sub CollectionQueryReset()
			aggTestColl.Query.[Select](aggTestColl.Query.LastName)
			aggTestColl.Query.Where(aggTestColl.Query.IsActive = True)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count)

			aggTestColl.Query.[Select](aggTestColl.Query.FirstName)
			aggTestColl.Query.Where(aggTestColl.Query.LastName = "Costner")
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(3, aggTestColl.Count)

			aggTestColl = New AggregateTestCollection()
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(30, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub CollectionLoadAll()
			Assert.IsTrue(aggTestColl.LoadAll())
			Assert.AreEqual(30, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub CollectionLoadAllFalse()
			Dim testColl As New AggregateTestCollection()

			Try
				testColl.LoadAll()
				testColl.MarkAllAsDeleted()
				testColl.Save()

				testColl = New AggregateTestCollection()
				Assert.IsFalse(testColl.LoadAll())
			Finally
				UnitTestBase.RefreshDatabase()
			End Try
		End Sub

		<Test> _
		Public Sub CollectionQueryLoad()
			aggTestColl.Query.[Select](aggTestColl.Query.LastName)
			aggTestColl.Query.Where(aggTestColl.Query.IsActive = True)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(16, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub CollectionTop()
			aggTestColl.Query.es.Top = 1
			aggTestColl.Query.[Select](aggTestColl.Query.LastName)
			aggTestColl.Query.Where(aggTestColl.Query.IsActive = True)
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub TestHasData()
			Assert.IsFalse(aggTestColl.HasData)

			Assert.IsTrue(aggTestColl.LoadAll())
			Assert.AreEqual(30, aggTestColl.Count)
			Assert.IsTrue(aggTestColl.HasData)

			aggTestColl = New AggregateTestCollection()
			Assert.IsFalse(aggTestColl.HasData)
			Assert.IsFalse(aggTest.es.HasData)

			aggTest = aggTestColl.AddNew()
			Assert.IsTrue(aggTestColl.HasData)
			Assert.IsTrue(aggTest.es.HasData)

			aggTest = New AggregateTest()
			Assert.IsFalse(aggTest.es.HasData)
			aggTest.Age = 40
			Assert.IsTrue(aggTest.es.HasData)
		End Sub

		<Test> _
		Public Sub TestSpecialBinder()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					aggTestColl.Query.[Select](aggTestColl.Query.Id, "<LastName + ', ' + FirstName AS SpecialBinder>")
					Exit Select
				Case "EntitySpaces.SqlServerCeProvider"
					aggTestColl.Query.[Select](aggTestColl.Query.Id, "<LastName + ', ' + FirstName AS ""SpecialBinder"">").OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending)
					Exit Select
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
					aggTestColl.Query.[Select](aggTestColl.Query.Id, "<""LastName"" || ', ' || ""FirstName"" AS ""SpecialBinder"">").OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending)
					Exit Select
				Case Else
					If aggTestColl.es.Connection.Name = "SqlCe" Then
						aggTestColl.Query.[Select](aggTestColl.Query.Id, "<LastName + ', ' + FirstName AS ""SpecialBinder"">").OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending)
					Else
						aggTestColl.Query.[Select](aggTestColl.Query.Id, "<LastName + ', ' + FirstName AS 'SpecialBinder'>").OrderBy("SpecialBinder", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending)
					End If
					Exit Select
			End Select
			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(30, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub LoadText()
			aggTestColl = New AggregateTestCollection()
			aggTestColl.CustomLoadText()
			Assert.AreEqual(8, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub LoadTextEsParams()
			aggTestColl = New AggregateTestCollection()
			aggTestColl.CustomLoadTextEsParams("D")
			Assert.AreEqual(6, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub TestCommandTimeout()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					aggTestColl = New AggregateTestCollection()
					aggTestColl.es.Connection.CommandTimeout = 49
					Assert.IsTrue(aggTestColl.Query.Load(), "Query.Load")
					Assert.AreEqual(49, aggTestColl.es.Connection.CommandTimeout)
					aggTestColl = New AggregateTestCollection()
					Assert.IsTrue(aggTestColl.LoadAll(), "LoadAll")
					Assert.AreEqual(39, aggTestColl.es.Connection.CommandTimeout)
					Exit Select
				Case Else

					Assert.Ignore("SQL Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub TestCommandTimeoutConfig()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					' Collection
					aggTestColl = New AggregateTestCollection()
					Assert.AreEqual(39, aggTestColl.es.Connection.CommandTimeout)
					Assert.IsTrue(aggTestColl.Query.Load(), "Query.Load")
					aggTestColl = New AggregateTestCollection()
					Assert.AreEqual(39, aggTestColl.es.Connection.CommandTimeout)
					Assert.IsTrue(aggTestColl.LoadAll(), "LoadAll")

					' Entity
					aggTest = New AggregateTest()
					Assert.AreEqual(39, aggTest.es.Connection.CommandTimeout)
					aggTest.Query.es.Top = 1
					Assert.IsTrue(aggTest.Query.Load(), "Query.Load")
					Dim aggKey As Integer = aggTest.Id.Value
					aggTest = New AggregateTest()
					Assert.AreEqual(39, aggTest.es.Connection.CommandTimeout)
					Assert.IsTrue(aggTest.LoadByPrimaryKey(aggKey), "LoadByPK")
					Exit Select
				Case Else

					Assert.Ignore("tested for SQL Server only")
					Exit Select
			End Select
		End Sub

		#Region "View tests"

		<Test> _
		Public Sub CollectionCustomLoadFromView()
			If aggTestColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				viewColl = New FullNameViewCollection()
				viewColl.CustomLoadFromView()
				Assert.AreEqual(6, viewColl.Count)
			End If
		End Sub

		<Test> _
		Public Sub CollectionCustomLoadFromViewNoParams()
			viewColl = New FullNameViewCollection()

			If viewColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Dim whereClause As String = ""

				Select Case viewColl.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider"
						whereClause = "WHERE ""DepartmentID"" = 1 "
						whereClause += "OR ""DepartmentID"" = 2 "
						Exit Select

					Case "EntitySpaces.MySqlClientProvider"
						whereClause = "WHERE `DepartmentID` = 1 "
						whereClause += "OR `DepartmentID` = 2"
						Exit Select
					Case Else

						whereClause = "WHERE [DepartmentID] = 1 "
						whereClause += "OR [DepartmentID] = 2"
						Exit Select
				End Select
				viewColl.CustomLoadFromViewNoParams(whereClause)
				Assert.AreEqual(6, viewColl.Count)
			End If
		End Sub

		<Test> _
		Public Sub CollectionCustomLoadFromViewByDept()
			If aggTestColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				viewColl = New FullNameViewCollection()
				viewColl.CustomLoadFromViewByDept(1)
				Assert.AreEqual(2, viewColl.Count)
			End If
		End Sub

		#End Region

	End Class
End Namespace
