'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class NamingFixture
		Private namingTestColl As New NamingTestCollection()
		Private namingTest As New NamingTest()

		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
			namingTestColl = New NamingTestCollection()
			namingTest = New NamingTest()
			' The table Naming.Test has a 'dot' in it,
			' so that is being tested as well.
			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTestColl.LoadAll()
					namingTestColl.MarkAllAsDeleted()
					namingTestColl.Save()
					Exit Select
				Case Else

					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ColumnWithSpaceAndAlias()
			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTest = namingTestColl.AddNew()
					namingTest.str.TestAliasSpace = "AliasSpace"
					namingTestColl.Save()
					Assert.IsTrue(namingTestColl.LoadAll())
					Assert.AreEqual(1, namingTestColl.Count)
					Exit Select
				Case Else

					Assert.Ignore("Database not set up, yet.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ColumnWithDot()
			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTest = namingTestColl.AddNew()
					namingTest.str.TestFieldDot = "FieldDot"
					namingTestColl.Save()
					Assert.IsTrue(namingTestColl.LoadAll())
					Assert.AreEqual(1, namingTestColl.Count)
					Exit Select
				Case Else

					Assert.Ignore("Database not set up, yet.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ColumnWithDotAndSetGuids()
			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim keyGuid As Guid = Guid.NewGuid()
					namingTest = namingTestColl.AddNew()
					namingTest.GuidKeyAlias = keyGuid
					namingTest.str.TestFieldDot = "FieldDot"
					namingTestColl.Save()
					Assert.IsTrue(namingTestColl.LoadAll())
					Assert.AreEqual(1, namingTestColl.Count)
					Assert.AreEqual(namingTestColl(0).GuidKeyAlias.Value, keyGuid)
					Exit Select
				Case Else

					Assert.Ignore("Database not set up, yet.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ColumnWithUnderScoreAndAlias()
			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTest = namingTestColl.AddNew()
					namingTest.str.Test_Alias_Underscore = "AliasUnder"
					namingTestColl.Save()
					Assert.IsTrue(namingTestColl.LoadAll())
					Assert.AreEqual(1, namingTestColl.Count)
					Exit Select
				Case Else

					Assert.Ignore("Database not set up, yet.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ColumnWithSpaceWithoutAlias()
			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTest = namingTestColl.AddNew()
					namingTest.str.TestFieldSpace = "FieldSpace"
					namingTestColl.Save()
					Assert.IsTrue(namingTestColl.LoadAll())
					Assert.AreEqual(1, namingTestColl.Count)
					Exit Select
				Case Else

					Assert.Ignore("Database not set up, yet.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub ColumnWithUnderScoreWithoutAlias()
			Select Case namingTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					namingTest = namingTestColl.AddNew()
					namingTest.str.TestFieldUnderscore = "FieldUnder"
					namingTestColl.Save()
					Assert.IsTrue(namingTestColl.LoadAll())
					Assert.AreEqual(1, namingTestColl.Count)
					Exit Select
				Case Else

					Assert.Ignore("Database not set up, yet.")
					Exit Select
			End Select
		End Sub
	End Class
End Namespace
