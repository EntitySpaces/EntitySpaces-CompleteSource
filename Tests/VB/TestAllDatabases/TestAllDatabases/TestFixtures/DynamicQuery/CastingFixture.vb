'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class CastingFixture
		#Region "Low Level Cast Tests"

		<Test> _
		Public Sub CastToBoolean()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esBoolean))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.OracleClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SybaseSqlAnywhereProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Dim lq As String = emp.Query.Parse()
					Assert.IsTrue(emp.Query.Load())

					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Boolean", obj.[GetType]().ToString())
					Assert.AreEqual(True, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToByte()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esByte))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.OracleClientProvider", "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider", "EntitySpaces.SQLiteProvider", _
					"EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

					Dim value As Byte = 30
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Byte", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToChar()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.VistaDBProvider":
				'case "EntitySpaces.SQLiteProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					emp.Query.[Select](emp.Query.FirstName.Cast(esCastType.[Char], 25).[As]("CastColumn"))
					Assert.IsTrue(emp.Query.Load())

					'string value = "John";
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.String", obj.[GetType]().ToString())
					'Assert.AreEqual(value, obj);
					Exit Select
				Case Else
                    emp.Query.[Select](CType(emp.Query.FirstName.[As]("CastColumn"), esChar))
					Assert.IsTrue(emp.Query.Load())

					'string value = "John";
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.String", obj.[GetType]().ToString())
					'Assert.AreEqual(value, obj);
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToCharWithSizePadded()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.Query.[Select](emp.Query.FirstName.Cast(esCastType.[Char], 5).[As]("CastColumn"))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.OracleClientProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider", _
					"EntitySpaces.SybaseSqlAnywhereProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

					Dim value As String = "John "
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.String", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToCharWithSizeTrunc()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.Query.[Select](emp.Query.FirstName.Cast(esCastType.[Char], 3).[As]("CastColumn"))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.OracleClientProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider", _
					"EntitySpaces.SybaseSqlAnywhereProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

					Dim value As String = "Joh"
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.String", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToDateTime()
			Dim empId As Integer = 0

			Try
				Using scope As New esTransactionScope()
					' Create an employee with a date in the LastName column
					Dim emp As New Employee()
					emp.es.Connection.Name = "ForeignKeyTest"

					Select Case emp.es.Connection.ProviderSignature.DataProviderName
						Case "EntitySpaces.OracleClientProvider"
							emp.LastName = "31-DEC-2008 01:01:01"
							Exit Select
						Case Else
							emp.LastName = "2008-12-31"
							Exit Select
					End Select
					emp.FirstName = "required"
					emp.Save()

					empId = emp.EmployeeID.Value

					emp = New Employee()
					emp.es.Connection.Name = "ForeignKeyTest"

                    emp.Query.[Select](CType(emp.Query.LastName.[As]("CastColumn"), esDateTime))
					emp.Query.Where(emp.Query.EmployeeID = empId)

					Select Case emp.es.Connection.ProviderSignature.DataProviderName
						'case "EntitySpaces.MySqlClientProvider":
						'case "EntitySpaces.NpgsqlProvider":
						'case "EntitySpaces.Npgsql2Provider":
						'case "EntitySpaces.VistaDBProvider":
						Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider"
							Assert.Ignore("Not supported.")
							Exit Select
						Case "EntitySpaces.OracleClientProvider"
							Dim lq As String = emp.Query.Parse()
							Assert.IsTrue(emp.Query.Load())

							Dim value As DateTime = DateTime.Parse("2008-12-31 01:01:01")
							Dim obj As Object = emp.GetColumn("CastColumn")
							Assert.AreEqual("System.DateTime", obj.[GetType]().ToString())
							Assert.AreEqual(value, obj)
							Exit Select
						Case Else
                            Dim lq As String = emp.Query.Parse()
                            Assert.IsTrue(emp.Query.Load())

                            Dim value As DateTime = DateTime.Parse("2008-12-31 00:00:00")
                            Dim obj As Object = emp.GetColumn("CastColumn")
                            Assert.AreEqual("System.DateTime", obj.[GetType]().ToString())
							Assert.AreEqual(value, obj)
							Exit Select
					End Select
				End Using
			Finally
				Dim emp As New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				emp.Query.Where(emp.Query.EmployeeID = empId)
				If emp.Query.Load() Then
					emp.MarkAsDeleted()
					emp.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub CastToDecimal()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esDecimal))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.OracleClientProvider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

					Dim value As Decimal = 30
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToDouble()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esDouble))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.SQLiteProvider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					Assert.IsTrue(emp.Query.Load())

					Dim value As Double = 30
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case "EntitySpaces.MySqlClientProvider"
					Assert.IsTrue(emp.Query.Load())

                    Dim value As Double = 30
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

                    Dim value As Double = 30
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Double", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToGuid()
			Dim prdId As Integer = 0

			Try
				Using scope As New esTransactionScope()
					' Create an employee with a guid in the LastName column
					Dim prd As New Product()
					prd.es.Connection.Name = "ForeignKeyTest"

					prd.ProductName = "551cfc32-c6d2-4756-8c59-efb460a0d1d9"
					prd.UnitPrice = 35.23D
					prd.Discontinued = False
					prd.Save()

					prdId = prd.ProductID.Value

					prd = New Product()
					prd.es.Connection.Name = "ForeignKeyTest"

                    prd.Query.[Select](CType(prd.Query.ProductName.[As]("CastColumn"), esGuid))
					prd.Query.Where(prd.Query.ProductID = prdId)

					Select Case prd.es.Connection.ProviderSignature.DataProviderName
						'case "EntitySpaces.VistaDBProvider":
						Case "EntitySpaces.MSAccessProvider", "EntitySpaces.MySqlClientProvider", "EntitySpaces.OracleClientProvider", "EntitySpaces.NpgsqlProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider"
							Assert.Ignore("Not supported.")
							Exit Select
						Case Else
							Assert.IsTrue(prd.Query.Load())

							Dim value As New Guid("551cfc32-c6d2-4756-8c59-efb460a0d1d9")
							Dim obj As Object = prd.GetColumn("CastColumn")
							Assert.AreEqual("System.Guid", obj.[GetType]().ToString())
							Assert.AreEqual(value, obj)
							Exit Select
					End Select
				End Using
			Finally
				Dim prd As New Product()
				prd.es.Connection.Name = "ForeignKeyTest"

				prd.Query.Where(prd.Query.ProductID = prdId)
				

				If prd.Query.Load() Then
					prd.MarkAsDeleted()
					prd.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub CastToInt16()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esInt16))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					Assert.IsTrue(emp.Query.Load())

					Dim value As System.Int16 = 30
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case "EntitySpaces.MySqlClientProvider"
					Assert.IsTrue(emp.Query.Load())

                    Dim value As System.Int16 = 30
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Int64", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

                    Dim value As System.Int16 = 30
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Int16", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToInt32()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esInt32))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					Assert.IsTrue(emp.Query.Load())

					Dim value As System.Int32 = 30
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case "EntitySpaces.MySqlClientProvider"
					Assert.IsTrue(emp.Query.Load())

                    Dim value As System.Int32 = 30
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Int64", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

                    Dim value As System.Int32 = 30
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Int32", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToInt64()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esInt64))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.SQLiteProvider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					Assert.IsTrue(emp.Query.Load())

					Dim value As System.Int64 = 30
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

                    Dim value As System.Int64 = 30
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Int64", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToSingle()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

            emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esSingle))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.MySqlClientProvider"
					Assert.IsTrue(emp.Query.Load())

					Dim value As [Single] = 30F
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					Assert.IsTrue(emp.Query.Load())

                    Dim value As [Single] = 30.0F
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

                    Dim value As [Single] = 30.0F
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.Single", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToString()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.SQLiteProvider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
					emp.Query.[Select](emp.Query.Age.Cast(esCastType.[String], 3).[As]("CastColumn"))
					Assert.IsTrue(emp.Query.Load())

					Dim value As String = "30"
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.String", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
				Case Else
                    emp.Query.[Select](CType(emp.Query.Age.[As]("CastColumn"), esString))
					Assert.IsTrue(emp.Query.Load())

                    Dim value As String = "30"
                    Dim obj As Object = emp.GetColumn("CastColumn")
                    Assert.AreEqual("System.String", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		#End Region

		#Region "esQueryItem.Cast tests"

		<Test> _
		Public Sub CastToDecimalPrecisionScale()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.Query.[Select](emp.Query.Age.Cast(esCastType.[Decimal], 8, 4).[As]("CastColumn"))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.OracleClientProvider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

					Dim value As System.Decimal = 30
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.Decimal", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub CastToStringLength()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.Query.[Select](emp.Query.FirstName.Cast(esCastType.[String], 2).[As]("CastColumn"))
			emp.Query.Where(emp.Query.EmployeeID = 1)

			Select Case emp.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.OracleClientProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SQLiteProvider", "EntitySpaces.SqlServerCeProvider", "EntitySpaces.VistaDBProvider", "EntitySpaces.VistaDB4Provider", "EntitySpaces.SybaseSqlAnywhereProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case Else
					Assert.IsTrue(emp.Query.Load())

					Dim value As String = "Jo"
					Dim obj As Object = emp.GetColumn("CastColumn")
					Assert.AreEqual("System.String", obj.[GetType]().ToString())
					Assert.AreEqual(value, obj)
					Exit Select
			End Select
		End Sub

		#End Region

		#Region "Select Tests"

		<Test> _
		Public Sub SelectCollection()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			collection.Query.OrderBy(collection.Query.EmployeeID.Ascending)

			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				'case "EntitySpaces.MySqlClientProvider":
				'case "EntitySpaces.NpgsqlProvider":
				'case "EntitySpaces.Npgsql2Provider":
				'case "EntitySpaces.SQLiteProvider":
				'case "EntitySpaces.VistaDBProvider":
				Case "EntitySpaces.MSAccessProvider", "EntitySpaces.SqlServerCeProvider"
					Assert.Ignore("Not supported.")
					Exit Select
				Case "EntitySpaces.OracleClientProvider"
                    collection.Query.[Select]((collection.Query.FirstName.ToUpper() + ":" + Convert.ToString(collection.Query.Age.Cast(esCastType.[String], 2))).[As]("FirstName"), collection.Query.LastName)
					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual("JOHN:30", collection(0).FirstName)
					Exit Select
				Case Else
                    collection.Query.[Select]((collection.Query.FirstName.ToUpper() + ":" + CType(collection.Query.Age, esString)).[As]("FirstName"), collection.Query.LastName)
					Assert.IsTrue(collection.Query.Load())
					Assert.AreEqual("JOHN:30", collection(0).FirstName)
					Exit Select
			End Select
		End Sub


		#End Region
	End Class
End Namespace
