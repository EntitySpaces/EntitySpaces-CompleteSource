'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Configuration

Imports BusinessObjects

Namespace Tests.Base
	''' <summary>
	''' Description of RefreshDatabase.
	''' </summary>
	Public Class UnitTestBase
		Shared Sub New()
		End Sub

		Public Shared Sub RefreshDatabase()
			RefreshDatabase("")
		End Sub

		Public Shared Sub RefreshDatabase(connectionName As String)
			Dim aggTestColl As New AggregateTestCollection()
			If connectionName.Length <> 0 Then
				aggTestColl.es.Connection.Name = connectionName
			End If

			aggTestColl.LoadAll()
			aggTestColl.MarkAllAsDeleted()
			aggTestColl.Save()

			aggTestColl = New AggregateTestCollection()
			Dim aggTest As New AggregateTest()
			If connectionName.Length <> 0 Then
				aggTestColl.es.Connection.Name = connectionName
				aggTest.es.Connection.Name = connectionName
			End If

			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "David"
			aggTest.str.LastName = "Doe"
			aggTest.str.Age = "16"
			aggTest.str.HireDate = "2000-02-16 05:59:31"
			aggTest.str.Salary = "34.71"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "1"
			aggTest.str.FirstName = "Sarah"
			aggTest.str.LastName = "McDonald"
			aggTest.str.Age = "28"
			aggTest.str.HireDate = "1999-03-25 00:00:00"
			aggTest.str.Salary = "11.06"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "David"
			aggTest.str.LastName = "Vincent"
			aggTest.str.Age = "43"
			aggTest.str.HireDate = "2000-10-17 00:00:00"
			aggTest.str.Salary = "10.27"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "2"
			aggTest.str.FirstName = "Fred"
			aggTest.str.LastName = "Smith"
			aggTest.str.Age = "15"
			aggTest.str.HireDate = "1999-03-15 00:00:00"
			aggTest.str.Salary = "15.15"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "Sally"
			aggTest.str.LastName = "Johnson"
			aggTest.str.Age = "30"
			aggTest.str.HireDate = "2000-10-07 00:00:00"
			aggTest.str.Salary = "14.36"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "5"
			aggTest.str.FirstName = "Jane"
			aggTest.str.LastName = "Rapaport"
			aggTest.str.Age = "44"
			aggTest.str.HireDate = "2002-05-02 00:00:00"
			aggTest.str.Salary = "13.56"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "4"
			aggTest.str.FirstName = "Paul"
			aggTest.str.LastName = "Gellar"
			aggTest.str.Age = "16"
			aggTest.str.HireDate = "2000-09-27 00:00:00"
			aggTest.str.Salary = "18.44"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "2"
			aggTest.str.FirstName = "John"
			aggTest.str.LastName = "Jones"
			aggTest.str.Age = "31"
			aggTest.str.HireDate = "2002-04-22 00:00:00"
			aggTest.str.Salary = "17.65"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "Michelle"
			aggTest.str.LastName = "Johnson"
			aggTest.str.Age = "45"
			aggTest.str.HireDate = "2003-11-14 00:00:00"
			aggTest.str.Salary = "16.86"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "2"
			aggTest.str.FirstName = "David"
			aggTest.str.LastName = "Costner"
			aggTest.str.Age = "17"
			aggTest.str.HireDate = "2002-04-11 00:00:00"
			aggTest.str.Salary = "21.74"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "4"
			aggTest.str.FirstName = "William"
			aggTest.str.LastName = "Gellar"
			aggTest.str.Age = "32"
			aggTest.str.HireDate = "2003-11-04 00:00:00"
			aggTest.str.Salary = "20.94"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "Sally"
			aggTest.str.LastName = "Rapaport"
			aggTest.str.Age = "39"
			aggTest.str.HireDate = "2002-04-01 00:00:00"
			aggTest.str.Salary = "25.82"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "5"
			aggTest.str.FirstName = "Jane"
			aggTest.str.LastName = "Vincent"
			aggTest.str.Age = "18"
			aggTest.str.HireDate = "2003-10-25 00:00:00"
			aggTest.str.Salary = "25.03"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "2"
			aggTest.str.FirstName = "Fred"
			aggTest.str.LastName = "Costner"
			aggTest.str.Age = "33"
			aggTest.str.HireDate = "1998-05-20 00:00:00"
			aggTest.str.Salary = "24.24"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "1"
			aggTest.str.FirstName = "John"
			aggTest.str.LastName = "Johnson"
			aggTest.str.Age = "40"
			aggTest.str.HireDate = "2003-10-15 00:00:00"
			aggTest.str.Salary = "29.12"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "Michelle"
			aggTest.str.LastName = "Rapaport"
			aggTest.str.Age = "19"
			aggTest.str.HireDate = "1998-05-10 00:00:00"
			aggTest.str.Salary = "28.32"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "4"
			aggTest.str.FirstName = "Sarah"
			aggTest.str.LastName = "Doe"
			aggTest.str.Age = "34"
			aggTest.str.HireDate = "1999-12-03 00:00:00"
			aggTest.str.Salary = "27.53"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "4"
			aggTest.str.FirstName = "William"
			aggTest.str.LastName = "Jones"
			aggTest.str.Age = "41"
			aggTest.str.HireDate = "1998-04-30 00:00:00"
			aggTest.str.Salary = "32.41"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "1"
			aggTest.str.FirstName = "Sarah"
			aggTest.str.LastName = "McDonald"
			aggTest.str.Age = "21"
			aggTest.str.HireDate = "1999-11-23 00:00:00"
			aggTest.str.Salary = "31.62"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "4"
			aggTest.str.FirstName = "Jane"
			aggTest.str.LastName = "Costner"
			aggTest.str.Age = "28"
			aggTest.str.HireDate = "1998-04-20 00:00:00"
			aggTest.str.Salary = "36.50"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "2"
			aggTest.str.FirstName = "Fred"
			aggTest.str.LastName = "Douglas"
			aggTest.str.Age = "42"
			aggTest.str.HireDate = "1999-11-13 00:00:00"
			aggTest.str.Salary = "35.71"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "Sarah"
			aggTest.str.LastName = "Jones"
			aggTest.str.Age = "22"
			aggTest.str.HireDate = "2001-06-07 00:00:00"
			aggTest.str.Salary = "34.91"
			aggTest.str.IsActive = "false"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "3"
			aggTest.str.FirstName = "Michelle"
			aggTest.str.LastName = "Doe"
			aggTest.str.Age = "29"
			aggTest.str.HireDate = "1999-11-03 00:00:00"
			aggTest.str.Salary = "39.79"
			aggTest.str.IsActive = "true"
			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "4"
			aggTest.str.FirstName = "Paul"
			aggTest.str.LastName = "Costner"
			aggTest.str.Age = "43"
			aggTest.str.HireDate = "2001-05-28 00:00:00"
			aggTest.str.Salary = "39.00"
			aggTest.str.IsActive = "true"

			aggTest = aggTestColl.AddNew()
			aggTest.str.DepartmentID = "0"
			aggTest.str.FirstName = ""
			aggTest.str.LastName = ""
			aggTest.str.Age = "0"
			aggTest.str.Salary = "0"

			aggTest = aggTestColl.AddNew()
			aggTest = aggTestColl.AddNew()
			aggTest = aggTestColl.AddNew()
			aggTest = aggTestColl.AddNew()
			aggTest = aggTestColl.AddNew()

			aggTestColl.Save()

		End Sub

		Public Shared Sub RefreshForeignKeyTest()
			RefreshForeignKeyTest("")
		End Sub

		Public Shared Sub RefreshForeignKeyTest(connectionName As String)
			Dim oiColl As New OrderItemCollection()
			oiColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				oiColl.es.Connection.Name = connectionName
			End If

			oiColl.Query.Where(oiColl.Query.OrderID > 11 Or oiColl.Query.ProductID > 9)
			oiColl.Query.Load()
			oiColl.MarkAllAsDeleted()
			oiColl.Save()

			Dim oColl As New OrderCollection()
			oColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				oColl.es.Connection.Name = connectionName
			End If

			oColl.Query.Where(oColl.Query.OrderID > 11)
			oColl.Query.Load()
			oColl.MarkAllAsDeleted()
			oColl.Save()

			Dim etColl As New EmployeeTerritoryCollection()
			etColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				etColl.es.Connection.Name = connectionName
			End If

			etColl.Query.Where(etColl.Query.EmpID > 4 Or etColl.Query.TerrID > 4)
			etColl.Query.Load()
			etColl.MarkAllAsDeleted()
			etColl.Save()

			Dim cColl As New CustomerCollection()
			cColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				cColl.es.Connection.Name = connectionName
			End If

			cColl.Query.Where(cColl.Query.CustomerID > "99999" And cColl.Query.CustomerSub > "001")
			cColl.Query.Load()
			cColl.MarkAllAsDeleted()
			cColl.Save()

			Dim tExColl As New TerritoryExCollection()
			tExColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				tExColl.es.Connection.Name = connectionName
			End If

			tExColl.Query.Where(tExColl.Query.TerritoryID > 1)
			tExColl.Query.Load()
			tExColl.MarkAllAsDeleted()
			tExColl.Save()

			Dim tColl As New TerritoryCollection()
			tColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				tColl.es.Connection.Name = connectionName
			End If

			tColl.Query.Where(tColl.Query.TerritoryID > 5)
			tColl.Query.Load()
			tColl.MarkAllAsDeleted()
			tColl.Save()

			Dim reColl As New ReferredEmployeeCollection()
			reColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				reColl.es.Connection.Name = connectionName
			End If

			reColl.Query.Where(reColl.Query.EmployeeID > 4 Or reColl.Query.ReferredID > 5)
			reColl.Query.Load()
			reColl.MarkAllAsDeleted()
			reColl.Save()

			Dim pColl As New ProductCollection()
			pColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				pColl.es.Connection.Name = connectionName
			End If

			pColl.Query.Where(pColl.Query.ProductID > 10)
			pColl.Query.Load()
			pColl.MarkAllAsDeleted()
			pColl.Save()

			Dim gColl As New GroupCollection()
			gColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				gColl.es.Connection.Name = connectionName
			End If

			gColl.Query.Where(gColl.Query.Id > "15001")
			gColl.Query.Load()
			gColl.MarkAllAsDeleted()
			gColl.Save()

			Dim eColl As New EmployeeCollection()
			eColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				eColl.es.Connection.Name = connectionName
			End If

			eColl.Query.Where(eColl.Query.EmployeeID > 5)
			eColl.Query.Load()
			eColl.MarkAllAsDeleted()
			eColl.Save()

			Dim cgColl As New CustomerGroupCollection()
			cgColl.es.Connection.Name = "ForeignKeyTest"
			If connectionName.Length <> 0 Then
				cgColl.es.Connection.Name = connectionName
			End If

			cgColl.Query.Where(cgColl.Query.GroupID > "99999" Or cgColl.Query.GroupID < "00001")
			cgColl.Query.Load()
			cgColl.MarkAllAsDeleted()
			cgColl.Save()

		End Sub

		Public Shared Function GetFktString(conn As EntitySpaces.Interfaces.esConnection) As String
			Dim settings As ConnectionStringSettings
			Dim fktString As String = ""

			Select Case conn.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider"
					settings = ConfigurationManager.ConnectionStrings("SqlCeFkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.OracleClientProvider"
					settings = ConfigurationManager.ConnectionStrings("OracleFkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.MSAccessProvider"
					settings = ConfigurationManager.ConnectionStrings("AccessFkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.VistaDBProvider"
					settings = ConfigurationManager.ConnectionStrings("VistaDBFkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.VistaDB4Provider"
					settings = ConfigurationManager.ConnectionStrings("VistaDB4Fkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.SQLiteProvider"
					settings = ConfigurationManager.ConnectionStrings("SQLiteFkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					settings = ConfigurationManager.ConnectionStrings("PgsqlFkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.MySqlClientProvider"
					settings = ConfigurationManager.ConnectionStrings("MySQLFkt")
					fktString = settings.ConnectionString
					Exit Select

				Case "EntitySpaces.SybaseSqlAnywhereProvider"
					settings = ConfigurationManager.ConnectionStrings("SybaseFkt")
					fktString = settings.ConnectionString
					Exit Select
				Case Else

					settings = ConfigurationManager.ConnectionStrings("SqlServerFkt")
					fktString = settings.ConnectionString
					Exit Select
			End Select

			Return fktString
		End Function
	End Class
End Namespace
