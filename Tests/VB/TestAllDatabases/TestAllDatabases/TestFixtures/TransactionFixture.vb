'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces

Namespace Tests.Base
	<TestFixture> _
	Public Class TransactionFixture
		Private aggTestColl As New AggregateTestCollection()
		Private aggTest As New AggregateTest()

		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
			aggTestColl = New AggregateTestCollection()
			aggTest = New AggregateTest()
		End Sub

		<Test> _
		Public Sub TestTransactions()
			Select Case aggTest.es.Connection.Name
				Case "SQLStoredProcEnterprise", "SQLDynamicEnterprise", "ORACLEStoredProcEnterprise", "ORACLEDynamicEnterprise", "VistaDBDynamic"
					Assert.Ignore("Using esTransactionScope only")
					Exit Select
				Case Else

					Dim tempId1 As Integer = 0
					Dim tempId2 As Integer = 0

					aggTest = New AggregateTest()
					Dim aggTest2 As New AggregateTest()

					Using scope As New esTransactionScope()
						aggTest.Save()
						tempId1 = aggTest.Id.Value
						aggTest2.Save()
						tempId2 = aggTest2.Id.Value

						scope.Complete()
					End Using

					aggTest = New AggregateTest()
					Assert.IsTrue(aggTest.LoadByPrimaryKey(tempId1))
					aggTest.MarkAsDeleted()
					aggTest.Save()

					aggTest = New AggregateTest()
					Assert.IsTrue(aggTest.LoadByPrimaryKey(tempId2))
					aggTest.MarkAsDeleted()
					aggTest.Save()

					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub TestFailedTransaction()
			Select Case aggTest.es.Connection.Name
				Case "SQLStoredProcEnterprise", "SQLDynamicEnterprise", "ORACLEStoredProcEnterprise", "ORACLEDynamicEnterprise", "VistaDBDynamic"
					Assert.Ignore("Using esTransactionScope only")
					Exit Select
				Case Else

					Try
						aggTest = New AggregateTest()
						Dim aggTest2 As New AggregateTest()
						Dim tempId1 As Integer = -1
						Dim tempId2 As Integer = -1
						aggTest2.str.HireDate = "1/1/1"

						Using scope As New esTransactionScope()
							Try
								aggTest.Save()
								tempId1 = aggTest.Id.Value
								aggTest2.Save()
								tempId2 = aggTest2.Id.Value

								Throw New Exception()

								scope.Complete()
							Catch
							End Try
						End Using
						aggTest = New AggregateTest()
						Assert.IsFalse(aggTest.LoadByPrimaryKey(tempId1))

						aggTest = New AggregateTest()
						Assert.IsFalse(aggTest.LoadByPrimaryKey(tempId2))
					Catch ex As Exception
						Assert.Fail(ex.ToString())
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub TestTransactionWithoutComplete()
			Select Case aggTest.es.Connection.Name
				Case "SQLStoredProcEnterprise", "SQLDynamicEnterprise", "ORACLEStoredProcEnterprise", "ORACLEDynamicEnterprise", "VistaDBDynamic"
					Assert.Ignore("Using esTransactionScope only")
					Exit Select
				Case Else

					Dim tempId As Integer = 0
					Try
						Using scope As New esTransactionScope()
							aggTest.Save()
							tempId = aggTest.Id.Value
						End Using
						aggTest = New AggregateTest()
						Assert.IsFalse(aggTest.LoadByPrimaryKey(tempId))
					Finally
						aggTest = New AggregateTest()
						If aggTest.LoadByPrimaryKey(tempId) Then
							aggTest.MarkAsDeleted()
							aggTest.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub
	End Class
End Namespace
