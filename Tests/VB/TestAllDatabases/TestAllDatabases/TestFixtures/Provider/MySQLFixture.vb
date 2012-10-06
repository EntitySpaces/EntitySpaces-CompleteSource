'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class MySQLFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub MySQLNumericTypeTest()
			Dim datatypeTestColl As New MysqltypetestCollection()
			Dim datatypeTest As New Mysqltypetest()

			' There is a bug in the 1.0.7 Connector/Net for unsigned types.
			' It is fixed in 5.0.3.
			Select Case datatypeTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MySqlClientProvider"
					Try
						datatypeTest.BigIntType = -1
						datatypeTest.BigIntUType = 1
						datatypeTest.DblType = -1
						datatypeTest.DblUType = 1
						datatypeTest.DecType = CDec((-1.5))
						datatypeTest.DecUType = CDec((1.5))
						datatypeTest.FloatType = CSng((-1.5))
						datatypeTest.FloatUType = CSng((1.5))
						datatypeTest.IntType = -1
						datatypeTest.IntUType = 1
						datatypeTest.MedIntType = -1
						datatypeTest.MedIntUType = 1
						datatypeTest.NumType = CDec((-1.5))
						datatypeTest.NumUType = CDec((1.5))
						datatypeTest.RealType = -1.5
						datatypeTest.RealUType = 1.5
						datatypeTest.SmallIntType = -1
						datatypeTest.SmallIntUType = 1
						datatypeTest.TinyIntType = CSByte((1))
						datatypeTest.TinyIntUType = Convert.ToByte(1)

						datatypeTest.Save()
						Dim tempKey As System.Nullable(Of Integer) = datatypeTest.Id
						Assert.IsTrue(datatypeTest.LoadByPrimaryKey(tempKey.Value))
						datatypeTest.MarkAsDeleted()
						datatypeTest.Save()
					Catch ex As Exception
						Assert.Fail(ex.ToString())
					End Try
					Exit Select
				Case Else

					Assert.Ignore("MySQL only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub MySQLUnicodeTest()
			Dim collection As New MySqlUnicodeTestCollection()

			If collection.es.Connection.ProviderMetadataKey = "esMySQL" AndAlso collection.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.DynamicSQL Then
				Try
					Dim uniKey As UInteger

					Dim uniTest As MySqlUnicodeTest = collection.AddNew()
					uniTest.VarCharType = "Hello ££ World"
					uniTest.TextType = "Hello ££ World"
					collection.Save()
					uniKey = uniTest.TypeID.Value

					uniTest = New MySqlUnicodeTest()
					uniTest.LoadByPrimaryKey(uniKey)
					Assert.AreEqual("££", uniTest.VarCharType.Substring(6, 2))
					Assert.AreEqual(14, uniTest.VarCharType.Length)
					Assert.AreEqual("££", uniTest.TextType.Substring(6, 2))
					Assert.AreEqual(14, uniTest.TextType.Length)

					' Clean up
					uniTest.MarkAsDeleted()
					uniTest.Save()
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("MySQL Dynamic only")
			End If
		End Sub

		<Test> _
		Public Sub MySQLBinaryTest()
			Dim collection As New Mysqltypetest2Collection()

			If collection.es.Connection.ProviderMetadataKey = "esMySQL" AndAlso collection.es.Connection.SqlAccessType = EntitySpaces.Interfaces.esSqlAccessType.DynamicSQL Then
				Try
					Dim datatypeTest As New Mysqltypetest2()

					datatypeTest.LoadByPrimaryKey(1)
					Assert.AreEqual("Hello", datatypeTest.BinaryType.TrimEnd(ControlChars.NullChar))
					Assert.AreEqual("Hello 2", datatypeTest.VarBinaryType)

					datatypeTest = New Mysqltypetest2()
					datatypeTest.BinaryType = "Testing"
					datatypeTest.VarBinaryType = "Testing 2"
					datatypeTest.Save()
					Dim typeKey As UInteger = datatypeTest.Id.Value

					datatypeTest = New Mysqltypetest2()
					datatypeTest.LoadByPrimaryKey(typeKey)
					Assert.AreEqual("Testing", datatypeTest.BinaryType.TrimEnd(ControlChars.NullChar))
					Assert.AreEqual("Testing 2", datatypeTest.VarBinaryType)

					' Clean up
					datatypeTest.MarkAsDeleted()
					datatypeTest.Save()
				Catch ex As Exception
					Assert.Fail(ex.ToString())
				End Try
			Else
				Assert.Ignore("MySQL Dynamic only")
			End If
		End Sub

		<Test> _
		Public Sub UnsignedAutoIncrement()
			Dim collection As New Mysqltypetest2Collection()

			' There is a bug in the 1.0.7 Connector/Net for unsigned types.
			' It is fixed in 5.0.3.
			Select Case collection.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.MySqlClientProvider"
					Try
						Dim datatypeTest As New Mysqltypetest2()
						datatypeTest.CharType = "X"
						datatypeTest.VarCharType = "xxx"
						datatypeTest.str.DateType = "2007-01-01"
						datatypeTest.str.DateTimeType = "2006-12-31 11:59:30"
						datatypeTest.TextType = "Some test text."
						datatypeTest.str.TimeType = "123456"
						datatypeTest.LongTextType = "Some more test text."

						datatypeTest.Save()
						Dim tempKey As System.Nullable(Of UInteger) = datatypeTest.Id
						Assert.IsTrue(datatypeTest.LoadByPrimaryKey(tempKey.Value))
						datatypeTest.MarkAsDeleted()
						datatypeTest.Save()
					Catch ex As Exception
						Assert.Fail(ex.ToString())
					End Try
					Exit Select
				Case Else

					Assert.Ignore("MySQL only")
					Exit Select
			End Select
		End Sub

	End Class
End Namespace
