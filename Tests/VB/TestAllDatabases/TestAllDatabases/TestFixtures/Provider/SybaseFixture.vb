'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class SybaseFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub ConcurrencyOnUpdate()
			Dim collection As New ComputedTestCollection()
			Dim testId As Integer = 0

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SybaseSqlAnywhereProvider"
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
						Dim err As String = cex.InnerException.Message.Substring(0, 11)
						Assert.AreEqual("Error", cex.Message.Substring(0, 5))
						Assert.AreEqual("Concurrency", err)
					Finally
						Dim entity As New ComputedTest()
						If entity.LoadByPrimaryKey(testId) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("Sybase only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ConcurrencyOnDelete()
			Dim collection As New ComputedTestCollection()
			Dim testId As Integer = 0

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SybaseSqlAnywhereProvider"
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
						Dim err As String = cex.InnerException.Message.Substring(0, 11)
						Assert.AreEqual("Error", cex.Message.Substring(0, 5))
						Assert.AreEqual("Concurrency", err)
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

					Assert.Ignore("Sybase only.")
					Exit Select
			End Select
		End Sub

	End Class
End Namespace
