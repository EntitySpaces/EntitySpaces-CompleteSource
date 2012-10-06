'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports EntitySpaces.Interfaces

Imports NUnit.Framework
Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class OracleFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub ConcurrencyOnUpdate()
			Dim collection As New OracleTestCollection()
			Dim testId As Integer = 0

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New OracleTest()
							entity.Save()
							testId = CInt(entity.Id.Value)

							' Test
							entity = New OracleTest()
							entity.LoadByPrimaryKey(testId)
							entity.str.DateType = "2007-01-01"

							Dim entity2 As New OracleTest()
							entity2.LoadByPrimaryKey(testId)
							entity2.str.DateType = "1999-12-31"

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5))
					Finally
						' Cleanup
						Dim entity As New OracleTest()
						If entity.LoadByPrimaryKey(testId) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("Oracle only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub NoSeqConcurrencyOnUpdate()
			Dim collection As New OracleTest2Collection()
			Dim testId As String = "XXXXX"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New OracleTest2()
							entity.Id = testId
							entity.Save()

							' Test
							entity = New OracleTest2()
							entity.LoadByPrimaryKey(testId)
							entity.str.DateType = "2007-01-01"

							Dim entity2 As New OracleTest2()
							entity2.LoadByPrimaryKey(testId)
							entity2.str.DateType = "1999-12-31"

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5))
					Finally
						' Cleanup
						Dim entity As New OracleTest2()
						If entity.LoadByPrimaryKey(testId) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("Oracle only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnDelete()
			Dim collection As New OracleTestCollection()
			Dim testId As Integer = 0

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New OracleTest()
							entity.Save()
							testId = CInt(entity.Id.Value)

							' Test
							entity = New OracleTest()
							entity.LoadByPrimaryKey(testId)
							entity.str.DateType = "2007-01-01"

							Dim entity2 As New OracleTest()
							entity2.LoadByPrimaryKey(testId)
							entity2.MarkAsDeleted()

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5))
					Finally
						' Cleanup
						Dim entity As New OracleTest()
						If entity.LoadByPrimaryKey(testId) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("Oracle only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub NoSeqConcurrencyOnDelete()
			Dim collection As New OracleTest2Collection()
			Dim testId As String = "XXXXX"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New OracleTest2()
							entity.Id = testId
							entity.Save()

							' Test
							entity = New OracleTest2()
							entity.LoadByPrimaryKey(testId)
							entity.str.DateType = "2007-01-01"

							Dim entity2 As New OracleTest2()
							entity2.LoadByPrimaryKey(testId)
							entity2.MarkAsDeleted()

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Assert.AreEqual("ORA-2", cex.Message.ToString().Substring(0, 5))
					Finally
						' Cleanup
						Dim entity As New OracleTest2()
						If entity.LoadByPrimaryKey(testId) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("Oracle only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub InlineRawSqlInOrderBy()
			Dim collection As New CustomerCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					' Oracle case insensitive sort.
					collection.Query.OrderBy("<NLSSORT(""CustomerName"", 'NLS_SORT=BINARY_CI')>", EntitySpaces.DynamicQuery.esOrderByDirection.Ascending)

					Assert.IsTrue(collection.Query.Load(), "Load 1")
					Assert.AreEqual(56, collection.Count)

					'collection = new CustomerCollection();
					'collection.es.Connection.Name = "ForeignKeyTest";
					'collection.Query.Where(
					'    collection.Query.CustomerName == "entityspaces");

					'Assert.IsTrue(collection.Query.Load(), "Load 2");
					'Assert.AreEqual(1, collection.Count);

					collection = New CustomerCollection()
					collection.es.Connection.Name = "ForeignKeyTest"
					collection.Query.Where(collection.Query.CustomerName.ToLower() = "entityspaces")

					Assert.IsTrue(collection.Query.Load(), "Load 3")
					Assert.AreEqual(46, collection.Count)

					Exit Select
				Case Else

					Assert.Ignore("Oracle only.")
					Exit Select
			End Select
		End Sub

	End Class
End Namespace
