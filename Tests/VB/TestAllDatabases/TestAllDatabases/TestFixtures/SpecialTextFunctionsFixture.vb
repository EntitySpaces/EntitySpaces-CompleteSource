'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.IO

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class SpecialTextFunctionsFixture
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

		#Region "ExecuteNonQuery"

		<Test> _
		Public Sub ExecuteNonQueryText()
			Try
				Dim rowsAffected As Integer = aggTestColl.CustomExecuteNonQueryText("EntitySpaces")
				Assert.AreEqual(1, rowsAffected)

				rowsAffected = aggTestColl.CustomExecuteNonQueryText("Sarah")
				Assert.AreEqual(1, rowsAffected)
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		<Test> _
		Public Sub ExecuteNonQueryTextEsParams()
			Try
				Dim rowsAffected As Integer = aggTestColl.CustomExecuteNonQueryTextEsParams("EntitySpaces")
				Assert.AreEqual(1, rowsAffected)

				rowsAffected = aggTestColl.CustomExecuteNonQueryTextEsParams("Sarah")
				Assert.AreEqual(1, rowsAffected)
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		#End Region

		#Region "ExecuteReader"

		<Test> _
		Public Sub ExecuteReaderTextEsParams()
			Try
				Dim i As Integer = 0
				Dim rdr As IDataReader = aggTestColl.CustomExecuteReaderTextEsParams()
				Assert.AreEqual(8, rdr.FieldCount)
				While rdr.Read()
					i += 1
				End While
				Assert.AreEqual(3, i)
				rdr.Close()
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		#End Region

		#Region "ExecuteScalar"

		<Test> _
		Public Sub ExecuteScalarTextEsParams()
			Try
				Dim nameCount As Integer = aggTestColl.CustomExecuteScalarTextEsParams()
				Assert.AreEqual(3, nameCount)
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		#End Region

		#Region "FillDataSet"

		<Test> _
		Public Sub FillDataSetTextNoParams()
			Try
				Dim lastName As String = "Doe"
				Dim testDataSet As DataSet = aggTestColl.CustomFillDataSetTextNoParams(lastName)
				Assert.AreEqual(3, testDataSet.Tables(0).DefaultView.Count)
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		<Test> _
		Public Sub FillDataSetText()
			Try
				Dim testDataSet As DataSet = aggTestColl.CustomFillDataSetText()
				Assert.AreEqual(3, testDataSet.Tables(0).DefaultView.Count)
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		#End Region

		#Region "FillDataTable"

		<Test> _
		Public Sub FillDataTableText()
			Try
				Dim testTable As DataTable = aggTestColl.CustomFillDataTableText()
				Assert.AreEqual(6, testTable.DefaultView.Count)
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		#End Region

	End Class
End Namespace
