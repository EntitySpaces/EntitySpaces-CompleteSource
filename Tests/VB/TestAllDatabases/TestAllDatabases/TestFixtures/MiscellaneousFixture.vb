'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.DynamicQuery
Imports EntitySpaces.Interfaces

Namespace Tests.Base
	<TestFixture> _
	Public Class MiscellaneousFixture
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
		Public Sub TestMarkAllColumnsAsDirtyAndModified()
			If aggTest.es.Connection.Name = "SqlCe" OrElse aggTest.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				aggTest.Query.es.Top = 1
				aggTest.Query.Load()
				Assert.IsTrue(aggTest.AllColumnsAreNotDirty())
				aggTest.MarkAllColumnsAsDirty(esDataRowState.Modified)
				Assert.IsTrue(aggTest.AllColumnsAreDirty(esDataRowState.Modified))
			End If
		End Sub

		<Test> _
		Public Sub TestMarkAllColumnsAsDirtyAndAdded()
			If aggTest.es.Connection.Name = "SqlCe" OrElse aggTest.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				aggTest.Query.es.Top = 1
				aggTest.Query.Load()
				Assert.IsTrue(aggTest.AllColumnsAreNotDirty())
				aggTest.MarkAllColumnsAsDirty(esDataRowState.Added)
				Assert.IsTrue(aggTest.AllColumnsAreDirty(esDataRowState.Added))
			End If
		End Sub

		<Test> _
		Public Sub TestUtilityClass()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
                    If aggTestColl.es.Connection.SqlAccessType <> esSqlAccessType.StoredProcedure Then
                        Assert.Ignore("Stored procedure test only.")
                    End If
                    aggTestColl.LoadAll()
					Dim entity As AggregateTest = DirectCast(aggTestColl(0), AggregateTest)
					Dim util As New Utility()

					Dim entityName As String = aggTestColl.GetFullName(entity.Id.Value)
					Dim name As String = util.GetFullName(entity.Id.Value)
					Assert.AreEqual(entityName, name)
					Exit Select
				Case Else

					Assert.Ignore("Tested on SQL Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub TestEsUtilityClass()
			Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
                    If aggTestColl.es.Connection.SqlAccessType <> esSqlAccessType.StoredProcedure Then
                        Assert.Ignore("Stored procedure test only.")
                    End If
                    aggTestColl.LoadAll()
					Dim entity As AggregateTest = DirectCast(aggTestColl(0), AggregateTest)
					Dim entityName As String = aggTestColl.GetFullName(entity.Id.Value)

					Dim util As New EntitySpaces.Core.esUtility()

                    'util.Catalog = "AggregateDb"
                    'util.Schema = "dbo"

					Dim parms As New EntitySpaces.Interfaces.esParameters()

					parms.Add("ID", entity.Id.Value)
					parms.Add("FullName", EntitySpaces.Interfaces.esParameterDirection.Output, System.Data.DbType.[String], 40)

					util.ExecuteNonQuery(EntitySpaces.DynamicQuery.esQueryType.StoredProcedure, "proc_GetEmployeeFullName", parms)

					Dim name As String = TryCast(parms("FullName").Value, String)
					Assert.AreEqual(entityName, name)
					Exit Select
				Case Else

					Assert.Ignore("Tested on SQL Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub TestQueryExecuteScalar()
			aggTestQuery.es.CountAll = True
			Dim count As Integer = Convert.ToInt32(aggTestQuery.ExecuteScalar())

			Assert.AreEqual(30, count)
		End Sub

		<Test> _
		Public Sub TestQueryExecuteReader()
			aggTestQuery.[Select](aggTestQuery.FirstName, aggTestQuery.LastName)
			aggTestQuery.Where(aggTestQuery.LastName.[Like]("%a%"))

			Dim count As Integer = 0
			Using reader As IDataReader = aggTestQuery.ExecuteReader()
				While reader.Read()
					Dim s As String = reader.GetString(0)
					s = reader.GetString(1)
					count += 1
				End While
			End Using

			Assert.AreEqual(8, count)
		End Sub
	End Class
End Namespace
