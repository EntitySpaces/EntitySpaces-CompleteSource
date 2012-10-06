'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Collections.Generic
Imports System.Text

Imports NUnit.Framework
Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class OneToOneFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub TestReferences()
			Dim cg As New CustomerGroup()
			cg.es.Connection.Name = "ForeignKeyTest"

			Assert.IsTrue(cg.LoadByPrimaryKey("05001"))
			Assert.IsTrue(cg.Group.es.HasData)
		End Sub

		<Test> _
		Public Sub TestUpTo()
			Dim g As New Group()
			g.es.Connection.Name = "ForeignKeyTest"

			g.LoadByPrimaryKey("05001")
			Assert.IsTrue(g.UpToCustomerGroup.es.HasData)
		End Sub

		<Test> _
		Public Sub TestNullReferences()
			Dim cg As New CustomerGroup()
			cg.es.Connection.Name = "ForeignKeyTest"

			cg.LoadByPrimaryKey("99999")
			Assert.IsFalse(cg.Group.es.HasData)
		End Sub

		<Test> _
		Public Sub TestSaveWithAutoKey()
			Dim terrKey As Integer = -1
			Dim terr As New Territory()
			terr.es.Connection.Name = "ForeignKeyTest"
			Dim terrEx As New TerritoryEx()
			terrEx.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					terr.Description = "Some New Territory"

					terrEx = terr.TerritoryEx
					terrEx.Notes = "Test Group"

					terr.Save()

					terrKey = terr.TerritoryID.Value

					Assert.IsTrue(terr.TerritoryEx.es.HasData)
					Assert.AreEqual(terr.TerritoryID.Value, terrEx.TerritoryID.Value)

					terr = New Territory()
					terr.es.Connection.Name = "ForeignKeyTest"

					Assert.IsTrue(terr.LoadByPrimaryKey(terrKey))
					Assert.IsTrue(terr.TerritoryEx.es.HasData)
				End Using
			Finally
				' Clean up
				terr = New Territory()
				terr.es.Connection.Name = "ForeignKeyTest"

				If terr.LoadByPrimaryKey(terrKey) Then
					terrEx = terr.TerritoryEx
					terrEx.MarkAsDeleted()
					terr.MarkAsDeleted()
					terr.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestSaveWithoutAutoKey()
			Dim cg As New CustomerGroup()
			cg.es.Connection.Name = "ForeignKeyTest"
			Dim g As New Group()
			g.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					cg.GroupID = "XXXXy"
					cg.GroupName = "Test Group"

					g = cg.Group
					g.Id = cg.GroupID
					g.Notes = "Some Text"

					cg.Save()

					Assert.IsTrue(cg.Group.es.HasData)
					Assert.AreEqual(cg.GroupID, cg.Group.Id)
				End Using
			Finally
				' Clean up
				cg = New CustomerGroup()
				cg.es.Connection.Name = "ForeignKeyTest"

				If cg.LoadByPrimaryKey("XXXXy") Then
					g = cg.Group
					g.MarkAsDeleted()
					cg.MarkAsDeleted()
					cg.Save()
				End If
			End Try
		End Sub
	End Class
End Namespace
