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
	Public Class ExpressionsFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		#Region "Concat Operator Tests"

		<Test> _
		Public Sub ConcatTwoStrings()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")

			eq.[Select](eq.EmployeeID, (eq.LastName + eq.FirstName).[As]("FullName"))

			Assert.IsTrue(collection.Load(eq))

			Dim theName As String = TryCast(collection(0).GetColumn("FullName"), String)
			Assert.AreEqual(9, theName.Length)
		End Sub

		<Test> _
		Public Sub ConcatTwoStringsAndLiteral()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")

            eq.[Select](eq.EmployeeID, (eq.LastName + ", " + eq.FirstName).[As]("FullName"))

			Assert.IsTrue(collection.Load(eq))

			Dim theName As String = TryCast(collection(0).GetColumn("FullName"), String)
			Assert.AreEqual(11, theName.Length)
		End Sub

		<Test> _
		Public Sub ConcatTwoStringsAndTwoLiterals()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")

            eq.[Select](eq.EmployeeID, (eq.LastName + " (" + eq.FirstName + ")").[As]("FullName"))

			Assert.IsTrue(collection.Load(eq))

			Dim theName As String = TryCast(collection(0).GetColumn("FullName"), String)
			Assert.AreEqual(12, theName.Length)
		End Sub

		<Test> _
		Public Sub TwoAddStringsWithToUpper()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")

            eq.[Select](eq.EmployeeID, (eq.LastName.ToUpper() + ", " + eq.FirstName).[As]("FullName"))
			eq.Where(eq.LastName = "Doe")
			eq.OrderBy(eq.FirstName.Ascending)

			Assert.IsTrue(collection.Load(eq))

			Dim theName As String = TryCast(collection(0).GetColumn("FullName"), String)
			Assert.AreEqual("DOE, Jane", theName)
		End Sub

		<Test> _
		Public Sub TwoAddStringsWithToUpperCollection()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

            collection.Query.[Select](collection.Query.EmployeeID, (collection.Query.LastName.ToUpper() + ", " + collection.Query.FirstName).[As]("FullName"))
			collection.Query.Where(collection.Query.LastName = "Doe")
			collection.Query.OrderBy(collection.Query.FirstName.Ascending)

			Assert.IsTrue(collection.Query.Load())

			Dim theName As String = TryCast(collection(0).GetColumn("FullName"), String)
			Assert.AreEqual("DOE, Jane", theName)
		End Sub

		<Test> _
		Public Sub TwoAddStringsThenConcatenated()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")

			eq.[Select](eq.EmployeeID, ((eq.LastName.ToLower() + eq.FirstName.ToLower()).Trim() + " : " + (eq.LastName.ToUpper() + eq.FirstName.ToUpper()).Trim()).Trim().[As]("SomeColumn"))

			Assert.IsTrue(collection.Load(eq))

			Dim theName As String = TryCast(collection(0).GetColumn("SomeColumn"), String)
			Assert.AreEqual("smithjohn : SMITHJOHN", theName)
		End Sub

		<Test> _
		Public Sub TwoAddStringsWithOrderBy()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")

            eq.[Select](eq.EmployeeID, (eq.LastName + ", " + eq.FirstName).[As]("FullName"))
			eq.OrderBy(eq.EmployeeID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(eq))

			Dim theName As String = TryCast(collection(0).GetColumn("FullName"), String)
			Assert.AreEqual(11, theName.Length)
		End Sub

		#End Region

		#Region "Single Arithmetic Operator Tests"

		<Test> _
		Public Sub OneAddIntegers()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Dim eq As New EmployeeQuery("eq")

			eq.[Select](eq.EmployeeID, eq.Age, (eq.Age + eq.Supervisor).[As]("SomeInt"))
			eq.OrderBy(eq.EmployeeID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(eq))

			Dim si As Object = collection(0).GetColumn("SomeInt")
			Assert.AreEqual(Nothing, si)

			Dim someInt As Integer = Convert.ToInt32(collection(1).GetColumn("SomeInt"))
			Assert.AreEqual(21, someInt)
		End Sub

		<Test> _
		Public Sub OneAddDecimals()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Dim oiq As New OrderItemQuery("oiq")

			oiq.[Select](oiq.OrderID, oiq.ProductID, (oiq.UnitPrice + oiq.Discount).[As]("SomeDecimal"))
			oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending)
			oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(oiq))

			Dim someDec As Decimal = Convert.ToDecimal(collection(0).GetColumn("SomeDecimal"))
			Assert.AreEqual(Convert.ToDecimal("0.12"), Math.Round(someDec, 2))
		End Sub

		<Test> _
		Public Sub OneAddAggregate()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Dim oiq As New OrderItemQuery("oiq")

			oiq.[Select](oiq.ProductID, (oiq.UnitPrice + oiq.Discount).Sum().[As]("SomeDecimal"))
			oiq.GroupBy(oiq.ProductID)
			oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(oiq))

			Dim someDec As Decimal = Convert.ToDecimal(collection(0).GetColumn("SomeDecimal"))
			Assert.AreEqual(Convert.ToDecimal("0.12"), Math.Round(someDec, 2))
		End Sub

		<Test> _
		Public Sub OneSubtractDecimals()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Dim oiq As New OrderItemQuery("oiq")

			oiq.[Select](oiq.OrderID, oiq.ProductID, (oiq.UnitPrice - oiq.Discount).[As]("SomeDecimal"))
			oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending)
			oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(oiq))

			Dim someDec As Decimal = Convert.ToDecimal(collection(0).GetColumn("SomeDecimal"))
			Assert.AreEqual(Convert.ToDecimal("0.10"), Math.Round(someDec, 2))
		End Sub

		<Test> _
		Public Sub OneMultiplyDecimals()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Dim oiq As New OrderItemQuery("oiq")

			oiq.[Select](oiq.OrderID, oiq.ProductID, (oiq.UnitPrice * oiq.Discount).[As]("SomeDecimal"))
			oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending)
			oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(oiq))

			Dim someDec As Decimal = Convert.ToDecimal(collection(0).GetColumn("SomeDecimal"))
			Assert.AreEqual(Convert.ToDecimal("0.001"), Math.Round(someDec, 3))
		End Sub

		<Test> _
		Public Sub OneDivideDecimals()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Dim oiq As New OrderItemQuery("oiq")

			oiq.[Select](oiq.OrderID, oiq.ProductID, (oiq.Discount / oiq.UnitPrice).[As]("SomeDecimal"))
			oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending)
			oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(oiq))

			Dim someDec As Decimal = Convert.ToDecimal(collection(0).GetColumn("SomeDecimal"))
			Assert.AreEqual(Convert.ToDecimal("0.09"), Math.Round(someDec, 2))
		End Sub

		<Test> _
		Public Sub OneModIntegers()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Select Case collection.es.Connection.ProviderMetadataKey
				Case "esAccess"
					Assert.Ignore("Not supported")
					Exit Select
				Case Else
					If collection.es.Connection.Name = "SqlCe" OrElse collection.es.Connection.ProviderMetadataKey = "esSqlCe" Then
						Assert.Ignore("Gets an overflow exception")
					Else
						Dim oiq As New OrderItemQuery("oiq")

						oiq.[Select](oiq.OrderID, oiq.ProductID, (oiq.Quantity Mod oiq.Quantity).[As]("SomeInteger"))
						oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending)
						oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

						Assert.IsTrue(collection.Load(oiq))

						Dim someInt As Decimal = Convert.ToInt32(collection(0).GetColumn("SomeInteger"))
						Assert.AreEqual(0, someInt)
					End If
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub OneModLiteral()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"


			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MSAccessProvider"
					Assert.Ignore("Not supported")
					Exit Select
				Case Else

					Dim oiq As New OrderItemQuery("oiq")

					oiq.[Select](oiq.OrderID, oiq.ProductID, (oiq.Quantity Mod 2).[As]("SomeInteger"))
					oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending)
					oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

					Assert.IsTrue(collection.Load(oiq))

					Dim someInt As Decimal = Convert.ToInt32(collection(0).GetColumn("SomeInteger"))
					Assert.AreEqual(1, someInt)
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub MultiExpression()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.ConnectionString = UnitTestBase.GetFktString(collection.es.Connection)

			Dim eq As New EmployeeQuery("eq")

			eq.[Select](eq.EmployeeID, eq.Age, ((eq.Age + eq.Supervisor) / 3).[As]("SomeInt"))
			eq.OrderBy(eq.EmployeeID, esOrderByDirection.Ascending)

			Assert.IsTrue(collection.Load(eq))

			Dim si As Object = collection(0).GetColumn("SomeInt")
			Assert.AreEqual(Nothing, si)

			Dim someInt As Integer = Convert.ToInt32(collection(1).GetColumn("SomeInt"))
			Assert.AreEqual(7, someInt)
		End Sub

		<Test> _
		Public Sub OneWhereSubtract()
			Dim collection As New OrderItemCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Dim oiq As New OrderItemQuery("oiq")

			oiq.[Select](oiq.OrderID, oiq.ProductID, (oiq.UnitPrice - oiq.Discount).[As]("SomeDecimal"))
			oiq.Where(oiq.UnitPrice - oiq.Discount < 0.2)
			oiq.OrderBy(oiq.OrderID, esOrderByDirection.Ascending)
			oiq.OrderBy(oiq.ProductID, esOrderByDirection.Ascending)

            Assert.IsTrue(collection.Load(oiq))

			Dim someDec As Decimal = Convert.ToDecimal(collection(0).GetColumn("SomeDecimal"))
			Assert.AreEqual(Convert.ToDecimal("0.10"), Math.Round(someDec, 2))
		End Sub

		#End Region

	End Class
End Namespace
