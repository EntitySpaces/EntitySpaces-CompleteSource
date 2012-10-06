'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class SqlServerFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub DataTypeBigInt()
			Dim dataTest As New SqlServerTypeTest()

			Select Case dataTest.es.Connection.ProviderSignature.DataProviderName
                Case "EntitySpaces.SqlClientProvider"
                    Using scope As New esTransactionScope()
                        dataTest = New SqlServerTypeTest()

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count1")
                        dataTest.BigIntType = 1000000000
                        Assert.AreEqual(1, dataTest.es.ModifiedColumns.Count, "Count2")
                        dataTest.Save()
                        Dim tempKey As Long = dataTest.Id.Value

                        dataTest = New SqlServerTypeTest()
                        Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey))
                        Assert.AreEqual(1000000000, dataTest.BigIntType.Value)

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count3")
                        dataTest.BigIntType = dataTest.BigIntType
                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count4")

                        ' Clean up
                        dataTest.MarkAsDeleted()
                        dataTest.Save()
                    End Using
                    Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub DataTypeVarCharMax()
			Dim dataTest As New SqlServerTypeTest()

			Select Case dataTest.es.Connection.ProviderSignature.DataProviderName
                Case "EntitySpaces.SqlClientProvider"
                    Using scope As New esTransactionScope()
                        dataTest = New SqlServerTypeTest()

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count1")
                        dataTest.VarCharMaxType = "Test"
                        Assert.AreEqual(1, dataTest.es.ModifiedColumns.Count, "Count2")
                        dataTest.Save()
                        Dim tempKey As Long = dataTest.Id.Value

                        dataTest = New SqlServerTypeTest()
                        Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey))
                        Assert.AreEqual("Test", dataTest.VarCharMaxType)

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count3")
                        dataTest.VarCharMaxType = dataTest.VarCharMaxType
                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count4")

                        ' Clean up
                        dataTest.MarkAsDeleted()
                        dataTest.Save()
                    End Using
                    Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

        <Test()> _
        Public Sub DataTypeNChar()
            Dim dataTest As New SqlServerTypeTest()

            Select Case dataTest.es.Connection.ProviderSignature.DataProviderName
                Case "EntitySpaces.SqlClientProvider"
                    Using scope As New esTransactionScope()
                        dataTest = New SqlServerTypeTest()

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count1")
                        dataTest.NCharType = "T"c
                        Assert.AreEqual(1, dataTest.es.ModifiedColumns.Count, "Count2")
                        dataTest.Save()
                        Dim tempKey As Long = dataTest.Id.Value

                        dataTest = New SqlServerTypeTest()
                        Assert.IsTrue(dataTest.LoadByPrimaryKey(tempKey))
                        Assert.AreEqual("T"c, dataTest.NCharType.Value)

                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count3")
                        dataTest.NCharType = dataTest.NCharType
                        Assert.AreEqual(0, dataTest.es.ModifiedColumns.Count, "Count4")

                        ' Clean up
                        dataTest.MarkAsDeleted()
                        dataTest.Save()
                    End Using
                    Exit Select
                Case Else

                    Assert.Ignore("Sql Server only")
                    Exit Select
            End Select
        End Sub

		<Test> _
		Public Sub DataTypeLargeMoneyMin()
			Dim dataTest As New OrderItem()

			Select Case dataTest.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Try
						Using scope As New esTransactionScope()
							dataTest = New OrderItem()
							dataTest.OrderID = 3
							dataTest.ProductID = 3
							dataTest.Quantity = 1
							dataTest.UnitPrice = -922337203685477.5808D
							dataTest.Save()

							dataTest = New OrderItem()
							Assert.IsTrue(dataTest.LoadByPrimaryKey(3, 3))
							Assert.AreEqual(-922337203685477.5808D, dataTest.UnitPrice.Value)
						End Using
					Finally
						' Clean up
						dataTest = New OrderItem()
						If dataTest.LoadByPrimaryKey(3, 3) Then
							dataTest.MarkAsDeleted()
							dataTest.Save()
						End If
					End Try

					Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub DataTypeLargeMoneyMax()
			Dim dataTest As New OrderItem()

			Select Case dataTest.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Try
						Using scope As New esTransactionScope()
							dataTest = New OrderItem()
							dataTest.OrderID = 3
							dataTest.ProductID = 3
							dataTest.Quantity = 1
							dataTest.UnitPrice = 922337203685477.5807D
							dataTest.Save()

							dataTest = New OrderItem()
							Assert.IsTrue(dataTest.LoadByPrimaryKey(3, 3))
							Assert.AreEqual(922337203685477.5807D, dataTest.UnitPrice.Value)
						End Using
					Finally
						' Clean up
						dataTest = New OrderItem()
						If dataTest.LoadByPrimaryKey(3, 3) Then
							dataTest.MarkAsDeleted()
							dataTest.Save()
						End If
					End Try

					Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub InsertGuidPrimaryKey()
			Dim namingTestColl As New NamingTestCollection()
			Dim namingTest As New NamingTest()

			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTest.Save()
					Dim tempKey As System.Nullable(Of Guid) = namingTest.GuidKeyAlias

					namingTest = New NamingTest()
					Assert.IsTrue(namingTest.LoadByPrimaryKey(tempKey.Value))
					namingTest.MarkAsDeleted()
					namingTest.Save()
					Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub SetGuidPrimaryKey()
			Dim namingTestColl As New NamingTestCollection()
			Dim namingTest As New NamingTest()

			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim testGuid As String = "b3883c65-ff94-47c4-8b0c-76896bedd45a"
					namingTest.GuidKeyAlias = New Guid(testGuid)
					namingTest.Save()
					Dim tempKey As System.Nullable(Of Guid) = namingTest.GuidKeyAlias
					namingTest.MarkAsDeleted()
					namingTest.Save()
					Assert.AreEqual(testGuid, tempKey.Value.ToString())
					Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub IdentityKeyPlusGuidNewid()
			Dim namingTestColl As New NamingTest2Collection()
			Dim namingTest As New NamingTest2()

			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim testGuid As String = "b3883c65-ff94-47c4-8b0c-76896bedd45a"
					namingTest.GuidNewid = New Guid(testGuid)
					namingTest.Save()
					Dim tempKey As Integer = namingTest.IdentityKey.Value

					namingTest = New NamingTest2()
					namingTest.LoadByPrimaryKey(tempKey)
					Assert.AreEqual(testGuid, namingTest.str.GuidNewid)

					namingTest.MarkAsDeleted()
					namingTest.Save()
					Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub GuidDynamicQuery()
			Dim namingTestColl As New NamingTestCollection()
			Dim namingTest As New NamingTest()

			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTest.Save()
					Dim tempKey As System.Nullable(Of Guid) = namingTest.GuidKeyAlias
					namingTestColl.Query.Where(namingTestColl.Query.GuidKeyAlias = tempKey)
					namingTestColl.Query.Load()
					Assert.AreEqual(1, namingTestColl.Count)
					Assert.IsTrue(namingTest.LoadByPrimaryKey(tempKey.Value))
					namingTest.MarkAsDeleted()
					namingTest.Save()
					Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnUpdate()
			Dim collection As New ComputedTestCollection()
			Dim testId As Integer = 0

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New ComputedTest()
							entity.Save()
							testId = entity.Id.Value

							' Test
							entity = New ComputedTest()
							entity.LoadByPrimaryKey(testId)
							entity.str.SomeDate = "2007-01-01"

							Dim entity2 As New ComputedTest()
							entity2.LoadByPrimaryKey(testId)
							entity2.str.SomeDate = "1999-12-31"

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
					Finally
						Dim entity As New ComputedTest()
						If entity.LoadByPrimaryKey(testId) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("SQL Server only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnDelete()
			Dim collection As New ComputedTestCollection()
			Dim testId As Integer = 0

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New ComputedTest()
							entity.Save()
							testId = entity.Id.Value

							' Test
							entity = New ComputedTest()
							entity.LoadByPrimaryKey(testId)
							entity.str.SomeDate = "2007-01-01"

							Dim entity2 As New ComputedTest()
							entity2.LoadByPrimaryKey(testId)
							entity2.MarkAsDeleted()

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
					Finally
						' Cleanup
						Dim entity As New ComputedTest()
						If entity.LoadByPrimaryKey(testId) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("SQL Server only.")
					Exit Select
			End Select
		End Sub

	End Class
End Namespace
