'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Namespace Tests.Base
	<TestFixture> _
	Public Class WhereDaisyChainingFixture
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
		Public Sub SelectWithAlias()
			aggTestColl.Query.[Select](aggTestColl.Query.Salary.[As]("S2"), aggTestColl.Query.FirstName, aggTestColl.Query.FirstName.[As]("FN")).OrderBy(aggTestColl.Query.Id.Ascending)

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(30, aggTestColl.Count)

			Dim aggControl As New AggregateTestCollection()
			aggControl.Query.OrderBy(aggControl.Query.Id.Ascending)
			aggControl.Query.Load()

			Dim i As Integer = 0
			For Each agg As AggregateTest In aggTestColl
				If aggControl(i).Salary.HasValue Then
					Assert.AreEqual(aggControl(i).Salary.Value, agg.GetColumn("S2"))
				Else
					Assert.AreEqual(Nothing, TryCast(agg.GetColumn("S2"), String))
				End If
				Assert.AreEqual(aggControl(i).FirstName, TryCast(agg.GetColumn("FN"), String))
				i += 1
			Next
		End Sub

		<Test> _
		Public Sub WhereMixMultiWithParenNested()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			collection.Query.[Select](collection.Query.EmployeeID, collection.Query.Supervisor, collection.Query.Age).Where(collection.Query.Age = 30).Where(New esComparison(esParenthesis.Open)).Where(New esComparison(esParenthesis.Open))

			collection.Query.es.DefaultConjunction = esConjunction.[Or]

			collection.Query.Where(collection.Query.EmployeeID = 1 And collection.Query.Supervisor.IsNull()).Where(collection.Query.EmployeeID = 2 And collection.Query.Supervisor = 1).Where(New esComparison(esParenthesis.Close))

			collection.Query.es.DefaultConjunction = esConjunction.[And]

			collection.Query.Where(New esComparison(esParenthesis.Open))

			collection.Query.es.DefaultConjunction = esConjunction.[Or]

			collection.Query.Where(collection.Query.LastName = "Smith" And collection.Query.Supervisor.IsNull()).Where(collection.Query.LastName = "Jones" And collection.Query.Supervisor = 1)

			collection.Query.Where(New esComparison(esParenthesis.Close))
			collection.Query.Where(New esComparison(esParenthesis.Close))

			Assert.IsTrue(collection.Query.Load())
			Assert.AreEqual(1, collection.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrDefaultOr()
			aggTestColl.Query.es.DefaultConjunction = esConjunction.[Or]
			aggTestColl.Query.Where(aggTestColl.Query.[And](aggTestColl.Query.LastName.[Like]("%D%"), aggTestColl.Query.LastName.[Like]("%s%")), aggTestColl.Query.[And](aggTestColl.Query.FirstName.[Like]("%J%"), aggTestColl.Query.FirstName.[Like]("%D%")))

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNested()
			aggTestColl.Query.Where(aggTestColl.Query.LastName.Equal("Doe"), aggTestColl.Query.FirstName = "David", aggTestColl.Query.[Or](aggTestColl.Query.[And](aggTestColl.Query.DepartmentID.Equal(3), aggTestColl.Query.Age.Equal(16)), aggTestColl.Query.[And](aggTestColl.Query.DepartmentID.Equal(4), aggTestColl.Query.Age.Equal(43))))

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNested2()
			aggTestColl.Query.Where(aggTestColl.Query.[Or](aggTestColl.Query.LastName.[Like]("%e%"), aggTestColl.Query.FirstName.[Like]("%a%")), aggTestColl.Query.[And](aggTestColl.Query.[Or](aggTestColl.Query.DepartmentID.Equal(3), aggTestColl.Query.Age.Equal(16)), aggTestColl.Query.[Or](aggTestColl.Query.HireDate >= Convert.ToDateTime("2000-01-01"), aggTestColl.Query.Salary >= 15)))

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(7, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNestedOperators()
			aggTestColl.Query.Where(aggTestColl.Query.LastName.Equal("Doe") And aggTestColl.Query.FirstName = "David" And ((aggTestColl.Query.DepartmentID.Equal(3) And aggTestColl.Query.Age.Equal(16)) Or (aggTestColl.Query.DepartmentID.Equal(4) And aggTestColl.Query.Age.Equal(43))))

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(1, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub WhereMixMultiAndOrNestedOperators2()
			aggTestColl.Query.Where((aggTestColl.Query.LastName.[Like]("%e%") Or aggTestColl.Query.FirstName.[Like]("%a%")) And ((aggTestColl.Query.DepartmentID.Equal(3) Or aggTestColl.Query.Age.Equal(16)) And (aggTestColl.Query.HireDate >= Convert.ToDateTime("2000-01-01") Or aggTestColl.Query.Salary >= 15)))

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(7, aggTestColl.Count)
		End Sub



		<Test> _
		Public Sub MultiWhereClausesExternal()
			aggTestColl.Query.[Select]().Where(aggTestColl.Query.IsActive.Equal(True)).Where(aggTestColl.Query.LastName.Equal("Doe"))

			Assert.IsTrue(aggTestColl.Query.Load())
			Assert.AreEqual(2, aggTestColl.Count)
		End Sub

		<Test> _
		Public Sub PagingSimple()
			Dim collection As New AggregateTestCollection()

			If collection.es.Connection.Name = "SqlCe" OrElse collection.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending).OrderBy(all.Query.Id, esOrderByDirection.Ascending)
						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive).OrderBy(collection.Query.LastName, esOrderByDirection.Ascending).OrderBy(collection.Query.Id, esOrderByDirection.Ascending)

						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingSimpleSelectAll()
			Dim collection As New AggregateTestCollection()

			If collection.es.Connection.Name = "SqlCe" OrElse collection.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Descending).OrderBy(all.Query.Id, esOrderByDirection.Ascending)

						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.OrderBy(collection.Query.LastName, esOrderByDirection.Descending).OrderBy(collection.Query.Id, esOrderByDirection.Ascending)

						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingWithWhere()
			Dim collection As New AggregateTestCollection()

			If aggTestColl.es.Connection.Name = "SqlCe" OrElse aggTestColl.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending).OrderBy(all.Query.Id, esOrderByDirection.Ascending).Where(all.Query.IsActive = True)

						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive).OrderBy(collection.Query.LastName, esOrderByDirection.Ascending).OrderBy(collection.Query.Id, esOrderByDirection.Ascending).Where(collection.Query.IsActive = True)

						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingWithTop()
			Dim collection As New AggregateTestCollection()

			If collection.es.Connection.Name = "SqlCe" OrElse collection.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Select Case collection.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not supported")
						Exit Select
					Case Else
						Dim all As New AggregateTestCollection()

						all.Query.es.Top = 20
						all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending).OrderBy(all.Query.Id, esOrderByDirection.Ascending)
						all.Query.Load()

						collection = New AggregateTestCollection()

						collection.Query.es.Top = 20
						collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive).OrderBy(collection.Query.LastName, esOrderByDirection.Ascending).OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
						collection.Query.es.PageNumber = 1
						collection.Query.es.PageSize = 8

						Assert.IsTrue(collection.Query.Load(), "Load 1")
						Assert.AreEqual(8, collection.Count, "Count 1")

						Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
						Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

						collection.Query.es.PageNumber = 2
						Assert.IsTrue(collection.Query.Load(), "Load 2")
						Assert.AreEqual(8, collection.Count, "Count 2")

						all0 = DirectCast(all(8), AggregateTest)
						collection0 = DirectCast(collection(0), AggregateTest)
						Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

						Exit Select
				End Select
			End If
		End Sub

		<Test> _
		Public Sub PagingWithDistinct()
			Dim collection As New AggregateTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.Ignore("Paging Not supported")
					Exit Select
				Case Else

					Dim all As New AggregateTestCollection()

					all.Query.es.Distinct = True
					all.Query.OrderBy(all.Query.LastName, esOrderByDirection.Ascending).OrderBy(all.Query.Id, esOrderByDirection.Ascending)
					all.Query.Load()

					collection = New AggregateTestCollection()

					collection.Query.es.Distinct = True
					collection.Query.[Select](collection.Query.Id, collection.Query.LastName, collection.Query.FirstName, collection.Query.IsActive).OrderBy(collection.Query.LastName, esOrderByDirection.Ascending).OrderBy(collection.Query.Id, esOrderByDirection.Ascending)
					collection.Query.es.PageNumber = 1
					collection.Query.es.PageSize = 8

					Assert.IsTrue(collection.Query.Load(), "Load 1")
					Assert.AreEqual(8, collection.Count, "Count 1")

					Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
					Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 1")

					collection.Query.es.PageNumber = 2
					Assert.IsTrue(collection.Query.Load(), "Load 2")
					Assert.AreEqual(8, collection.Count, "Count 2")

					all0 = DirectCast(all(8), AggregateTest)
					collection0 = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.Id.Value, collection0.Id.Value, "Compare 2")

					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsNear()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "Acme NEAR Company"

					collection.Query.[Select](collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.[As]("CName"), collection.Query.Notes).Where(collection.Query.CustomerName.Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(2, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsWildCard()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = """2*"""

					collection.Query.[Select](collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.[As]("CName"), collection.Query.Notes).Where(collection.Query.CustomerName.Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(9, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsCaseInsensitive()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "acme NEAR company"

					collection.Query.Where(collection.Query.CustomerName.Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(2, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainsMultiTerms()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "Acme NEAR Company"
					Dim addressTerm As String = "Road AND (""St*"" OR ""Ave*"")"

					collection.Query.[Select](collection.Query.CustomerID, collection.Query.CustomerSub, collection.Query.CustomerName.[As]("CName"), collection.Query.Notes).Where(collection.Query.CustomerName.Contains(nameTerm)).Where(collection.Query.Notes.Contains(addressTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(1, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ContainswithSubOperator()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim nameTerm As String = "Acme NEAR Company"

					' SubOperators are ignored for CONTAINS.
					' The search conditions belong in the search term parameter
					collection.Query.Where(collection.Query.CustomerName.ToLower().Contains(nameTerm))

					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual(2, collection.Count)
					Exit Select
				Case Else

					Assert.Ignore("Not supported")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub PagingWithGroupBy()
			Dim collection As New AggregateTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
					Assert.Ignore("Paging Not supported")
					Exit Select
				Case Else

					Dim all As New AggregateTestCollection()

					all.Query.[Select](all.Query.LastName, all.Query.Salary.Avg()).Where(all.Query.IsActive = True).GroupBy(all.Query.LastName).OrderBy(all.Query.LastName, esOrderByDirection.Ascending)
					all.Query.Load()

					collection = New AggregateTestCollection()

					collection.Query.[Select](collection.Query.LastName, collection.Query.Salary.Avg()).Where(collection.Query.IsActive = True).GroupBy(collection.Query.LastName).OrderBy(collection.Query.LastName, esOrderByDirection.Ascending)
					collection.Query.es.PageNumber = 1
					collection.Query.es.PageSize = 8

					Assert.IsTrue(collection.Query.Load(), "Load 1")
					Assert.AreEqual(8, collection.Count, "Count 1")

					Dim all0 As AggregateTest = DirectCast(all(0), AggregateTest)
					Dim collection0 As AggregateTest = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 1")

					collection.Query.es.PageNumber = 2
					Assert.IsTrue(collection.Query.Load(), "Load 2")
					Assert.AreEqual(2, collection.Count, "Count 2")

					all0 = DirectCast(all(8), AggregateTest)
					collection0 = DirectCast(collection(0), AggregateTest)
					Assert.AreEqual(all0.LastName, collection0.LastName, "Compare 2")

					Exit Select
			End Select
		End Sub
	End Class
End Namespace
