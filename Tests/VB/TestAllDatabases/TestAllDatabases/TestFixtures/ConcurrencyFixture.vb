'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports NUnit.Framework

Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class ConcurrencyFixture
		<Test> _
		Public Sub ConcurrencyOnUpdate()
			Dim collection As New ConcurrencyTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not implemented for SqlCe")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New ConcurrencyTest()
							If entity.LoadByPrimaryKey("abc") Then
								entity.MarkAsDeleted()
								entity.Save()
							End If

							entity = New ConcurrencyTest()
							entity.Id = "abc"
							entity.Name = "Test 1"
							entity.Save()

							' Test
							entity = New ConcurrencyTest()
							entity.LoadByPrimaryKey("abc")
							Assert.AreEqual(1, entity.ConcurrencyCheck, "Check 1")
							entity.Name = "Test 2"
							entity.Save()

							entity = New ConcurrencyTest()
							entity.LoadByPrimaryKey("abc")
							Assert.AreEqual(2, entity.ConcurrencyCheck, "Check 2")
							entity.Name = "Test 3"
							entity.Save()

							entity = New ConcurrencyTest()
							entity.LoadByPrimaryKey("abc")
							Assert.AreEqual(3, entity.ConcurrencyCheck, "Check 3")
							entity.Name = "Test 4"

							Dim entity2 As New ConcurrencyTest()
							entity2.LoadByPrimaryKey("abc")
							entity2.Name = "Collision"

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Select Case collection.es.Connection.ProviderSignature.DataProviderName
							Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.VistaDBProvider", _
								"EntitySpaces.VistaDB4Provider"
								Assert.AreEqual("Error in", cex.Message.Substring(0, 8))
								Exit Select

							Case "EntitySpaces.OracleClientProvider"
								Assert.AreEqual("ORA-20101", cex.Message.Substring(0, 9))
								Exit Select
							Case Else

								Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
								Exit Select
						End Select
					Finally
						' Clean up
						Dim entity As New ConcurrencyTest()
						If entity.LoadByPrimaryKey("abc") Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnUpdateAutoKey()
			Dim oldKey As Long = -1
			Dim collection As New ConcurrencyTestChildCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not implemented for SqlCe")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New ConcurrencyTestChild()
							entity.Name = "Test 1"
							entity.DefaultTest = Convert.ToDateTime("2010-01-01")
							entity.Save()
							oldKey = entity.Id.Value

							' Test
							entity = New ConcurrencyTestChild()
							entity.LoadByPrimaryKey(oldKey)
							Assert.AreEqual(1, entity.ConcurrencyCheck, "Check 1")
							entity.Name = "Test 2"
							entity.Save()

							entity = New ConcurrencyTestChild()
							entity.LoadByPrimaryKey(oldKey)
							Assert.AreEqual(2, entity.ConcurrencyCheck, "Check 2")
							entity.Name = "Test 3"
							entity.Save()

							entity = New ConcurrencyTestChild()
							entity.LoadByPrimaryKey(oldKey)
							Assert.AreEqual(3, entity.ConcurrencyCheck, "Check 3")
							entity.Name = "Test 4"

							Dim entity2 As New ConcurrencyTestChild()
							entity2.LoadByPrimaryKey(oldKey)
							entity2.Name = "Collision"

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Select Case collection.es.Connection.ProviderSignature.DataProviderName
							Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.VistaDBProvider", _
								"EntitySpaces.VistaDB4Provider"
								Assert.AreEqual("Error in", cex.Message.Substring(0, 8))
								Exit Select

							Case "EntitySpaces.OracleClientProvider"
								Assert.AreEqual("ORA-20101", cex.Message.Substring(0, 9))
								Exit Select
							Case Else

								Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
								Exit Select
						End Select
					Finally
						' Clean up
						Dim entity As New ConcurrencyTestChild()
						If entity.LoadByPrimaryKey(oldKey) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnDelete()
			Dim collection As New ConcurrencyTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not implemented for SqlCe")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New ConcurrencyTest()
							If entity.LoadByPrimaryKey("abc") Then
								entity.MarkAsDeleted()
								entity.Save()
							End If

							entity = New ConcurrencyTest()
							entity.Id = "abc"
							entity.Name = "Test 1"
							entity.Save()

							' Test
							entity = New ConcurrencyTest()
							entity.LoadByPrimaryKey("abc")
							entity.MarkAsDeleted()

							Dim entity2 As New ConcurrencyTest()
							entity2.LoadByPrimaryKey("abc")
							entity2.MarkAsDeleted()

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Select Case collection.es.Connection.ProviderSignature.DataProviderName
							Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.VistaDBProvider", _
								"EntitySpaces.VistaDB4Provider"
								Assert.AreEqual("Error in", cex.Message.Substring(0, 8))
								Exit Select

							Case "EntitySpaces.OracleClientProvider"
								Assert.AreEqual("ORA-20101", cex.Message.Substring(0, 9))
								Exit Select
							Case Else

								Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
								Exit Select
						End Select
					Finally
						' Cleanup
						Dim entity As New ConcurrencyTest()
						If entity.LoadByPrimaryKey("abc") Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnDeleteAutoKey()
			Dim oldKey As Long = -1
			Dim collection As New ConcurrencyTestChildCollection()
			Dim entity As New ConcurrencyTestChild()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not implemented for SqlCe")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							' Setup
							collection.LoadAll()
							collection.MarkAllAsDeleted()
							collection.Save()

							entity.Name = "Test 1"
							entity.DefaultTest = Convert.ToDateTime("2010-01-01")
							entity.Save()
							oldKey = entity.Id.Value

							' Test
							entity = New ConcurrencyTestChild()
							entity.LoadByPrimaryKey(oldKey)
							entity.MarkAsDeleted()

							Dim entity2 As New ConcurrencyTestChild()
							entity2.LoadByPrimaryKey(oldKey)
							entity2.MarkAsDeleted()

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Select Case collection.es.Connection.ProviderSignature.DataProviderName
							Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.VistaDBProvider", _
								"EntitySpaces.VistaDB4Provider"
								Assert.AreEqual("Error in", cex.Message.Substring(0, 8))
								Exit Select

							Case "EntitySpaces.OracleClientProvider"
								Assert.AreEqual("ORA-20101", cex.Message.Substring(0, 9))
								Exit Select
							Case Else

								Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
								Exit Select
						End Select
					Finally
						' Cleanup
						entity = New ConcurrencyTestChild()
						If entity.LoadByPrimaryKey(oldKey) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnUpdateDelete()
			Dim collection As New ConcurrencyTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not implemented for SqlCe")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New ConcurrencyTest()
							If entity.LoadByPrimaryKey("abc") Then
								entity.MarkAsDeleted()
								entity.Save()
							End If

							entity = New ConcurrencyTest()
							entity.Id = "abc"
							entity.Name = "Test 1"
							entity.Save()

							' Test
							entity = New ConcurrencyTest()
							entity.LoadByPrimaryKey("abc")
							entity.Name = "Test 2"

							Dim entity2 As New ConcurrencyTest()
							entity2.LoadByPrimaryKey("abc")
							entity2.MarkAsDeleted()

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Select Case collection.es.Connection.ProviderSignature.DataProviderName
							Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.VistaDBProvider", _
								"EntitySpaces.VistaDB4Provider"
								Assert.AreEqual("Error in", cex.Message.Substring(0, 8))
								Exit Select

							Case "EntitySpaces.OracleClientProvider"
								Assert.AreEqual("ORA-20101", cex.Message.Substring(0, 9))
								Exit Select
							Case Else

								Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
								Exit Select
						End Select
					Finally
						' Cleanup
						Dim entity As New ConcurrencyTest()
						If entity.LoadByPrimaryKey("abc") Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnUpdateDeleteAutoKey()
			Dim oldKey As Long = -1
			Dim collection As New ConcurrencyTestChildCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not implemented for SqlCe")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							' Setup
							Dim entity As New ConcurrencyTestChild()
							entity.Name = "Test 1"
							entity.DefaultTest = Convert.ToDateTime("2010-01-01")
							entity.Save()
							oldKey = entity.Id.Value

							' Test
							entity = New ConcurrencyTestChild()
							entity.LoadByPrimaryKey(oldKey)
							entity.Name = "Test 2"

							Dim entity2 As New ConcurrencyTestChild()
							entity2.LoadByPrimaryKey(oldKey)
							entity2.MarkAsDeleted()

							entity.Save()
							entity2.Save()
							Assert.Fail("Concurrency Exception not thrown.")
						End Using
					Catch cex As EntitySpaces.Interfaces.esConcurrencyException
						Select Case collection.es.Connection.ProviderSignature.DataProviderName
							Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.VistaDBProvider", _
								"EntitySpaces.VistaDB4Provider"
								Assert.AreEqual("Error in", cex.Message.Substring(0, 8))
								Exit Select

							Case "EntitySpaces.OracleClientProvider"
								Assert.AreEqual("ORA-20101", cex.Message.Substring(0, 9))
								Exit Select
							Case Else

								Assert.AreEqual("Update failed", cex.Message.Substring(0, 13))
								Exit Select
						End Select
					Finally
						' Cleanup
						Dim entity As New ConcurrencyTestChild()
						If entity.LoadByPrimaryKey(oldKey) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

	End Class
End Namespace
