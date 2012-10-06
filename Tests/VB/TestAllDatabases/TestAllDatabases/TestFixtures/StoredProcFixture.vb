'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class StoredProcFixture
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

		#Region "ExecuteNonQuery"

		<Test> _
		Public Sub ExecuteNonQueryNoParams()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				Try
					Dim rowsAffected As Integer = aggTestColl.CustomExecuteNonQueryNoParams()
					Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
						Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider"
							Assert.AreEqual(0, rowsAffected)
							Exit Select
						Case Else
							Assert.AreEqual(-1, rowsAffected)
							Exit Select
					End Select
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("Stored procedure mode only.")
			End If
		End Sub

		<Test> _
		Public Sub ExecuteNonQueryNoParamsWithCatalog()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				Try
					Dim rowsAffected As Integer = aggTestColl.CustomExecuteNonQueryNoParamsWithCatalog()
					Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
						Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider"
							Assert.AreEqual(0, rowsAffected)
							Exit Select
						Case Else
							Assert.AreEqual(-1, rowsAffected)
							Exit Select
					End Select
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("Stored procedure mode only.")
			End If
		End Sub

		#End Region

		#Region "ExecuteReader"

		<Test> _
		Public Sub ExecuteReaderNoParams()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				Try
					Dim i As Integer = 0
					Dim rdr As IDataReader = aggTestColl.CustomExecuteReaderNoParams()
					Assert.AreEqual(8, rdr.FieldCount)
					While rdr.Read()
						i += 1
					End While
					rdr.Close()
					Assert.AreEqual(30, i)
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("Stored procedure mode only.")
			End If
		End Sub

		#End Region

		#Region "ExecuteScalar"

		<Test> _
		Public Sub ExecuteScalarNoParams()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				Try
					Dim result As String = aggTestColl.CustomExecuteScalarNoParams()
					Assert.IsTrue(result.Length <> 0)
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("Stored procedure mode only.")
			End If
		End Sub

		#End Region

		#Region "FillDataSet"

		<Test> _
		Public Sub FillDataSetNoParams()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				Try
					Dim testDataSet As DataSet = aggTestColl.CustomFillDataSetNoParams()
					Assert.AreEqual(30, testDataSet.Tables(0).DefaultView.Count)
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("Stored procedure mode only.")
			End If
		End Sub

		#End Region

		#Region "FillDataTable"

		<Test> _
		Public Sub FillDataTableNoParams()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				Try
					Dim testTable As DataTable = aggTestColl.CustomFillDataTableNoParams()
					Assert.AreEqual(30, testTable.DefaultView.Count)
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("Stored procedure mode only.")
			End If
		End Sub

		#End Region

		<Test> _
		Public Sub StoredProcWithOutputParams()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				Try
					aggTest.Query.[Select]().Where(aggTest.Query.FirstName.Equal("Sarah"), aggTest.Query.LastName.Equal("Doe"))
					Assert.IsTrue(aggTest.Query.Load())
					Dim primaryKey As Integer = aggTest.Id.Value

					Dim fullName As String = aggTestColl.GetFullName(primaryKey)

					Assert.AreEqual("Doe, Sarah", fullName)
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("Stored procedure mode only.")
			End If
		End Sub

		<Test> _
		Public Sub TestScaleAndPrecision()
			Try
				Select Case aggTestColl.es.Connection.ProviderSignature.DataProviderName
					Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.OracleClientProvider", "EntitySpaces.SQLiteProvider", _
						"EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider"
						Assert.Ignore("Not implemented.")
						Exit Select
					Case Else
                        If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
                            aggTestColl.TestParamsWithScale()
                            aggTestColl.Query.Where(aggTestColl.Query.LastName = "Spaces", aggTestColl.Query.FirstName = "Entity")
                            aggTestColl.Query.Load()
                            Assert.AreEqual(1, aggTestColl.Count)
                            aggTestColl.MarkAllAsDeleted()
                            aggTestColl.Save()
                        Else

                            Assert.Ignore("Stored Procedure mode only.")
                        End If
                        Exit Select
                End Select
			Catch exIgnore As IgnoreException
				Assert.Ignore(exIgnore.Message.ToString())
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		<Test> _
		Public Sub TestNullParams()
			If aggTestColl.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.StoredProcedure Then
				aggTestColl.TestNullParams()

				aggTestColl.Query.Where(aggTestColl.Query.LastName = "NullTest")
				aggTestColl.Query.Load()

				Assert.AreEqual(1, aggTestColl.Count)

				' Cleanup
				aggTestColl.MarkAllAsDeleted()
				aggTestColl.Save()
			Else
				Assert.Ignore("Stored Procedure mode only.")
			End If
		End Sub

	End Class
End Namespace
