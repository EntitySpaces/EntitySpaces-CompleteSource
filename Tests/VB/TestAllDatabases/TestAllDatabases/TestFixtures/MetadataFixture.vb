'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Collections.Generic
Imports System.Text

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects
Imports EntitySpaces.Interfaces

Namespace Tests.Base
	<TestFixture> _
	Public Class MetadataFixture
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
		Public Sub DescriptionWithDoubleQuote()
			Dim comp As New ComputedTest()

			Select Case comp.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					'                  comp.AddNew();
					Dim desc As String = comp.GetDescriptionDoubleQuoteTest()

					Assert.AreEqual("See ""this""", desc)
					Exit Select
				Case Else

					Assert.Ignore("Tested for SQL Server only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub DescriptionWithBackSlash()
			Dim comp As New ComputedTest()

			Select Case comp.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Dim desc As String = comp.GetDescriptionBackSlashTest()

					Assert.AreEqual("See C:\this", desc)
					Exit Select
				Case Else

					Assert.Ignore("Tested for SQL Server only.")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub GetColumnName()
			Dim meta As AggregateTestMetadata = AggregateTestMetadata.Meta()

			For Each col As esColumnMetadata In meta.Columns
				Dim colName As String = col.Name
				Assert.IsTrue(colName <> String.Empty)
			Next
		End Sub

		<Test> _
		Public Sub GetColumnWithAliasEntity()
			Dim entity As New AggregateTest()
			entity.Query.es.CountAll = True
			entity.Query.es.CountAllAlias = "Count"
			entity.Query.Load()

			Assert.AreEqual(30, Convert.ToInt32(entity.GetColumn("Count")))
		End Sub

		<Test> _
		Public Sub GetColumnWithAliasEntityView()
			Dim entity As New FullNameView()

			If entity.es.Connection.Name = "SqlCe" OrElse entity.es.Connection.ProviderMetadataKey = "esSqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				entity.Query.es.CountAll = True
				entity.Query.es.CountAllAlias = "Count"
				entity.Query.Load()

				Assert.AreEqual(16, Convert.ToInt32(entity.GetColumn("Count")))
			End If
		End Sub

		<Test> _
		Public Sub GetColumnWithAliasCollection()
			Dim coll As New AggregateTestCollection()
			coll.Query.es.CountAll = True
			coll.Query.es.CountAllAlias = "Count"
			coll.Query.Load()

			Assert.AreEqual(30, Convert.ToInt32(coll(0).GetColumn("Count")))
		End Sub

		<Test> _
		Public Sub ChangeMetadata()
			Dim entity As New AggregateTest()

			Assert.IsTrue(entity.GetAutoKey() = True)
			entity.ToggleAutoKey()
			Assert.IsTrue(entity.GetAutoKey() = False)
			entity.ToggleAutoKey()
			Assert.IsTrue(entity.GetAutoKey() = True)
		End Sub

		<Test> _
		Public Sub ConfigNotReadOnly()
			Dim entity As New AggregateTest()
			Assert.AreEqual("AggregateDb", entity.es.Connection.Name)

			Dim oldDefault As String = esConfigSettings.ConnectionInfo.[Default]
			esConfigSettings.ConnectionInfo.[Default] = "ForeignKeyTest"

			entity = New AggregateTest()
			Assert.AreEqual("ForeignKeyTest", entity.es.Connection.Name)

			If entity.es.Connection.ProviderSignature.DataProviderName = "EntitySpaces.OracleClientProvider" Then
				Assert.IsTrue(entity.es.Connection.ConnectionString.ToLower().Contains("hierarchical"))
			Else
				Assert.IsTrue(entity.es.Connection.ConnectionString.ToLower().Contains("foreignkeytest"))
			End If

			entity.es.Connection.ConnectionString = "Test"
			Assert.AreEqual("Test", entity.es.Connection.ConnectionString)

			esConfigSettings.ConnectionInfo.[Default] = oldDefault
		End Sub
	End Class
End Namespace
