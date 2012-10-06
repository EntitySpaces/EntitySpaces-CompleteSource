'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports NUnit.Framework

Imports BusinessObjects
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Namespace Tests.Base
	<TestFixture> _
	Public Class SubOperatorFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub TestToUpper()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.ToUpper() = "DOE")
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TestToUpperInSelect()
			Dim collection As New AggregateTestCollection()
			collection.Query.[Select](collection.Query.LastName.ToUpper())
			collection.Query.Where(collection.Query.LastName = "Doe")
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
			Assert.AreEqual("DOE", collection(0).LastName)
		End Sub

		<Test> _
		Public Sub TestToUpperWithLike()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.ToUpper().[Like]("DO%"))
			collection.Query.Load()
            Assert.AreEqual(4, collection.Count)
		End Sub

		<Test> _
		Public Sub TestToLower()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.ToLower() = "doe")
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TestToLowerWithIn()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.ToLower().[In]("doe", "douglas"))
			collection.Query.Load()
            Assert.AreEqual(4, collection.Count)
		End Sub

		<Test> _
		Public Sub TestLTrim()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.LTrim() = "Doe")
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TestLTrimWithBetween()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.LTrim().Between("Doe", "Douglas"))
			collection.Query.Load()
            Assert.AreEqual(4, collection.Count)
		End Sub

		<Test> _
		Public Sub TestRTrim()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.RTrim() = "Doe")
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TestRTrimWithEqual()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.RTrim().Equal("Doe"))
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TestTrim()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.Trim() = "Doe")
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TestTrimWithNotEqual()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.Trim().NotEqual("Doe"))
			collection.Query.Load()
            Assert.AreEqual(21, collection.Count)
		End Sub

		<Test> _
		Public Sub TestSubstring()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.Substring(1, 2) = "Do")
			collection.Query.Load()
            Assert.AreEqual(4, collection.Count)
		End Sub

		<Test> _
		Public Sub TestSubstringNoStart()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.Substring(2) = "Do")
			collection.Query.OrderBy(collection.Query.Id, EntitySpaces.DynamicQuery.esOrderByDirection.Ascending)
			collection.Query.Load()
            Assert.AreEqual(4, collection.Count)
			Assert.AreEqual("Doe", collection(0).LastName)
		End Sub

		<Test> _
		Public Sub TestSubstringWithNotNull()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.Substring(1, 2).IsNotNull())
			collection.Query.Load()
            Assert.AreEqual(24, collection.Count)
		End Sub

		<Test> _
		Public Sub TestCoalesceInWhere()
			Dim collection As New AggregateTestCollection()
			If collection.es.Connection.ProviderMetadataKey <> "esAccess" Then
				collection.Query.Where(collection.Query.LastName.Coalesce("'1'") = "1")
				collection.Query.Load()
                Assert.AreEqual(6, collection.Count)
			Else
				Assert.Ignore("Not supported.")
			End If
		End Sub

		<Test> _
		Public Sub TestCoalesceInSelect()
			Dim collection As New AggregateTestCollection()
			If collection.es.Connection.ProviderMetadataKey <> "esAccess" Then
				collection.Query.[Select](collection.Query.LastName.Coalesce("'x'"))
				collection.Query.Load()
                collection.Filter = collection.AsQueryable().Where(Function(f As AggregateTest) f.LastName = "x")
                Assert.AreEqual(6, collection.Count)
			Else
				Assert.Ignore("Not supported.")
			End If
		End Sub

		<Test> _
		Public Sub TestDateInWhere()
			Dim collection As New AggregateTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					collection.Query.Where(collection.Query.HireDate.[Date]() = "2000-02-16")
					Exit Select
				Case Else

					collection.Query.Where(collection.Query.HireDate.[Date]() = Convert.ToDateTime("2000-02-16"))
					Exit Select
			End Select

			Dim lq As String = collection.Query.Parse()
			collection.Query.Load()
            Assert.AreEqual(1, collection.Count)
		End Sub

		<Test> _
		Public Sub TestDateInSelect()
			Dim collection As New AggregateTestCollection()
			collection.Query.[Select](collection.Query.HireDate.[Date]())
			Dim lq As String = collection.Query.Parse()
			collection.Query.Load()
            Assert.AreEqual(30, collection.Count)
            collection.Filter = collection.AsQueryable().Where(Function(f As AggregateTest) f.HireDate IsNot Nothing AndAlso f.HireDate.Value.ToShortDateString() = "2/16/2000")
            Assert.AreEqual(1, collection.Count)
		End Sub

		<Test> _
		Public Sub TestDateWithPaging()
			Dim collection As New AggregateTestCollection()
			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select

				Case "EntitySpaces.SQLiteProvider"
					collection.Query.Where(collection.Query.HireDate.[Date]().Equal("2000-02-16"))
					Exit Select
				Case Else

					collection.Query.Where(collection.Query.HireDate.[Date]().Equal(Convert.ToDateTime("2000-02-16")))
					Exit Select
			End Select

			collection.Query.OrderBy(collection.Query.LastName.Ascending)
			collection.Query.es.PageNumber = 1
			collection.Query.es.PageSize = 10
			Assert.IsTrue(collection.Query.Load())
            Assert.AreEqual(1, collection.Count)
		End Sub

		<Test> _
		Public Sub WhereLikeEscapedMultiWithSubOp()
			Dim tempId As Integer = -1
			Dim collection As New AggregateTestCollection()
			Dim aggTest As New AggregateTest()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Try
						Using scope As New esTransactionScope()
							aggTest.LastName = "a 10% name"
							aggTest.Save()
							tempId = aggTest.Id.Value

							collection.Query.[Select]().Where(collection.Query.LastName.Trim().[Like]("%10!%%", "!"C), collection.Query.LastName.[Like]("%a%"))
							Assert.IsTrue(collection.Query.Load())
                            Assert.AreEqual(1, collection.Count)
						End Using
					Finally
						' Clean up
						aggTest = New AggregateTest()
						If aggTest.LoadByPrimaryKey(tempId) Then
							aggTest.MarkAsDeleted()
							aggTest.Save()
						End If
					End Try
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub TestLength()
			Dim collection As New AggregateTestCollection()
			collection.Query.Where(collection.Query.LastName.Length() = 3)
			Dim lq As String = collection.Query.Parse()
			collection.Query.Load()
            Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub TestRoundInSelect()
			Dim collection As New AggregateTestCollection()
			collection.Query.[Select](collection.Query.Salary.Round(0))
			collection.Query.Where(collection.Query.FirstName = "David")
			collection.Query.Where(collection.Query.LastName = "Doe")
			collection.Query.Load()
			Assert.AreEqual(35.0000D, collection(0).Salary.Value)
		End Sub

		<Test> _
		Public Sub TestRoundInSelectPositive()
			Dim collection As New AggregateTestCollection()
			collection.Query.[Select](collection.Query.Salary.Round(1))
			collection.Query.Where(collection.Query.FirstName = "David")
			collection.Query.Where(collection.Query.LastName = "Doe")
			collection.Query.Load()
			Assert.AreEqual(34.7000D, collection(0).Salary.Value)
		End Sub

		<Test> _
		Public Sub TestRoundInWhereZero()
			Dim collection As New AggregateTestCollection()

			collection.Query.Where(collection.Query.Salary.Round(0) = 35)

			Dim lq As String = collection.Query.Parse()
			collection.Query.Load()
            Assert.AreEqual(2, collection.Count)
		End Sub

		<Test> _
		Public Sub TestRoundInWherePositive()
			Dim collection As New AggregateTestCollection()

			collection.Query.Where(collection.Query.Salary.Round(1) = 34.7)

			Dim lq As String = collection.Query.Parse()
			collection.Query.Load()
            Assert.AreEqual(1, collection.Count)
		End Sub

		<Test> _
		Public Sub TestRoundInWhereNegative()
			Dim collection As New AggregateTestCollection()


			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider"
					Assert.Ignore("Not Supported")
					Exit Select
				Case Else

					collection.Query.Where(collection.Query.Salary.Round(-1) = 30)
					Exit Select
			End Select

			Dim lq As String = collection.Query.Parse()
			collection.Query.Load()
            Assert.AreEqual(9, collection.Count)
		End Sub

		<Test> _
		Public Sub TestDatePartInSelect()
			Dim collection As New AggregateTestCollection()

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SybaseSqlAnywhereProvider"
					collection.Query.[Select](collection.Query.FirstName, collection.Query.LastName, collection.Query.HireDate.DatePart("month").[As]("HireMonth"))
					Exit Select

				Case "EntitySpaces.OracleClientProvider"
					collection.Query.[Select](collection.Query.FirstName, collection.Query.LastName, collection.Query.HireDate.DatePart("MONTH").[As]("HireMonth"))
					Exit Select

				Case "EntitySpaces.SQLiteProvider"
					collection.Query.[Select](collection.Query.FirstName, collection.Query.LastName, collection.Query.HireDate.DatePart("'%m'").[As]("HireMonth"))
					Exit Select
				Case Else

					collection.Query.[Select](collection.Query.FirstName, collection.Query.LastName, collection.Query.HireDate.DatePart("m").[As]("HireMonth"))
					Exit Select
			End Select

			collection.Query.Where(collection.Query.FirstName = "David")
			collection.Query.Where(collection.Query.LastName = "Doe")
			Dim lq As String = collection.Query.Parse()
			collection.Query.Load()

			If collection.es.Connection.ProviderSignature.DataProviderName = "EntitySpaces.SQLiteProvider" Then
				Assert.AreEqual("02", collection(0).GetColumn("HireMonth"))
			Else
				Assert.AreEqual(2, collection(0).GetColumn("HireMonth"))
			End If
		End Sub

		<Test> _
		Public Sub TestDatePartInWhere()
			Dim collection As New AggregateTestCollection()
			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SybaseSqlAnywhereProvider"
					collection.Query.Where(collection.Query.HireDate.DatePart("month") = 5)
					Exit Select

				Case "EntitySpaces.OracleClientProvider"
					collection.Query.Where(collection.Query.HireDate.DatePart("MONTH") = 5)
					Exit Select

				Case "EntitySpaces.SQLiteProvider"
					collection.Query.Where(collection.Query.HireDate.DatePart("'%m'") = "05")
					Exit Select
				Case Else

					collection.Query.Where(collection.Query.HireDate.DatePart("m") = 5)
					Exit Select
			End Select

			collection.Query.Load()
            Assert.AreEqual(4, collection.Count)
		End Sub

		<Test> _
		Public Sub TestDatePartInWhereGreaterThan()
			Dim collection As New AggregateTestCollection()
			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SybaseSqlAnywhereProvider"
					collection.Query.Where(collection.Query.HireDate.DatePart("year") > 2000)
					Exit Select

				Case "EntitySpaces.OracleClientProvider"
					collection.Query.Where(collection.Query.HireDate.DatePart("YEAR") > 2000)
					Exit Select

				Case "EntitySpaces.SQLiteProvider"
					collection.Query.Where(collection.Query.HireDate.DatePart("'%Y'") > "2000")
					Exit Select
				Case Else

					collection.Query.Where(collection.Query.HireDate.DatePart("yyyy") > 2000)
					Exit Select
			End Select

			collection.Query.Where(collection.Query.IsActive = True)
			collection.Query.Where(collection.Query.DepartmentID >= 2)
			collection.Query.Where(collection.Query.FirstName.Substring(1, 4) <> "Paul")
			collection.Query.Load()
            Assert.AreEqual(4, collection.Count)
		End Sub
	End Class
End Namespace
