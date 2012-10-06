'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.Linq

Imports NUnit.Framework

Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class DataTypeFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub TestDateTime()
			Dim testId As Integer = -1
			Dim aggTestColl As New AggregateTestCollection()
			Dim test As New AggregateTest()

			Try
				Using scope As New EntitySpaces.Interfaces.esTransactionScope()
					aggTestColl.Query.Load()
                    aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(Function(s As AggregateTest) s.Id)
					test = DirectCast(aggTestColl(0), AggregateTest)
					Dim [date] As DateTime = test.HireDate.Value
					Assert.AreEqual(Convert.ToDateTime("02/16/2000 05:59:31"), [date])

					test = New AggregateTest()
					test.HireDate = Convert.ToDateTime("12/31/9999")
					test.Save()
					testId = test.Id.Value

					test = New AggregateTest()
					Assert.IsTrue(test.LoadByPrimaryKey(testId))
					Assert.AreEqual(Convert.ToDateTime("12/31/9999"), test.HireDate.Value)
					test.MarkAsDeleted()
					test.Save()
				End Using
			Finally
				' Clean up
				test = New AggregateTest()
				If test.LoadByPrimaryKey(testId) Then
					test.MarkAsDeleted()
					test.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestDateTimeMilliSeconds()
			Dim testId As Integer = -1
			Dim test As New AggregateTest()

			Select Case test.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SqlClientProvider"
					Assert.Ignore("Requires SQL Server 2008 and datetime2 data type.")
					Exit Select

				Case "EntitySpaces.MySqlClientProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							test.HireDate = Convert.ToDateTime("1901-01-01 01:01:01.001")
							test.Save()
							testId = test.Id.Value

							test = New AggregateTest()
							Assert.IsTrue(test.LoadByPrimaryKey(testId))
							Assert.AreEqual(Convert.ToDateTime("1901-01-01 01:01:01.001"), test.HireDate.Value, "MilliSeconds")
						End Using
					Finally
						' Clean up
						test = New AggregateTest()
						If test.LoadByPrimaryKey(testId) Then
							test.MarkAsDeleted()
							test.Save()
						End If
					End Try
					Exit Select
			End Select

		End Sub

		<Test> _
		Public Sub TestDateTimeMicroSeconds()
			Dim testId As Integer = -1
			Dim test As New AggregateTest()

			Select Case test.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("MS Access only resolves to MilliSeconds.")
					Exit Select

				Case "EntitySpaces.MySqlClientProvider"
					Assert.Ignore("Not supported.")
					Exit Select

				Case "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SqlClientProvider"
					Assert.Ignore("Requires SQL Server 2008 and datetime2 data type.")
					Exit Select
				Case Else

					Try
						Using scope As New esTransactionScope()
							test.HireDate = Convert.ToDateTime("1902-01-01 01:01:01.000001")
							test.Save()
							testId = test.Id.Value

							test = New AggregateTest()
							Assert.IsTrue(test.LoadByPrimaryKey(testId))
							Assert.AreEqual(Convert.ToDateTime("1902-01-01 01:01:01.000001"), test.HireDate.Value, "MicroSeconds")
						End Using
					Finally
						' Clean up
						test = New AggregateTest()
						If test.LoadByPrimaryKey(testId) Then
							test.MarkAsDeleted()
							test.Save()
						End If
					End Try
					Exit Select
			End Select

		End Sub

	End Class
End Namespace
