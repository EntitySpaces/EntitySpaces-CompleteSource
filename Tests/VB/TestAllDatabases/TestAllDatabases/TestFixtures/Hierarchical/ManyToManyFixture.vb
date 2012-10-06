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
	Public Class ManyToManyFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub TestReferences()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.LoadByPrimaryKey(1)
			Assert.AreEqual(3, emp.UpToTerritoryCollection.Count)
		End Sub

		<Test> _
		Public Sub TestNullReferences()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.LoadByPrimaryKey(5)
			Assert.AreEqual(0, emp.UpToTerritoryCollection.Count)
		End Sub

		<Test> _
		Public Sub TestAssociateDissociateNew()
			Dim terrKey As Integer = -1
			Dim empKey As Integer = -1

			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"
			Dim terr As New Territory()
			terr.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					emp.LastName = "Test Last"
					emp.FirstName = "Test First"

					terr.Description = "Some New Territory"
					terr.Save()
					terrKey = terr.TerritoryID.Value

					emp.AssociateTerritoryCollection(terr)
					emp.Save()
					empKey = emp.EmployeeID.Value

					Assert.AreEqual(1, emp.UpToTerritoryCollection.Count)
					For Each et As EmployeeTerritory In emp.EmployeeTerritoryCollectionByEmpID
						Assert.AreEqual(terr.TerritoryID.Value, et.TerrID.Value)
					Next
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(empKey) Then
					For Each t As Territory In emp.UpToTerritoryCollection
						emp.DissociateTerritoryCollection(t)
					Next
					emp.MarkAsDeleted()
					emp.Save()
				End If

				terr = New Territory()
				terr.es.Connection.Name = "ForeignKeyTest"

				If terr.LoadByPrimaryKey(terrKey) Then
					terr.MarkAsDeleted()
					terr.Save()
				End If
			End Try
        End Sub

        <Test()> _
        Public Sub TestAssociateDissociateNewComposite()
            Dim c As New Course()
            c.es.Connection.Name = "ForeignKeyTest"
            Dim s As New Student()
            s.es.Connection.Name = "ForeignKeyTest"

            Select Case c.es.Connection.ProviderSignature.DataProviderName
                Case "EntitySpaces.SqlClientProvider"
                    Using scope As New esTransactionScope()
                        s.S1 = "a"
                        s.S2 = "b"
                        s.StudentName = "Test Student"

                        c.C1 = 1
                        c.C2 = "b"
                        c.ClassName = "Test Class"
                        c.Save()

                        s.AssociateCourseCollection(c)
                        s.Save()

                        Assert.AreEqual(1, c.UpToStudentCollection.Count)
                        Assert.AreEqual(1, s.UpToCourseCollection.Count)

                        For Each sc As StudentClass In s.StudentClassCollectionBySid1
                            Assert.AreEqual(c.C1.Value, sc.Cid1.Value)
                            Assert.AreEqual(c.C2.Trim(), sc.Cid2.Trim())
                            Assert.AreEqual(s.S1.Trim(), sc.Sid1.Trim())
                            Assert.AreEqual(s.S2.Trim(), sc.Sid2.Trim())
                        Next

                        s.DissociateCourseCollection(c)
                        s.Save()

                        s.UpToCourseCollection = Nothing
                        c.UpToStudentCollection = Nothing
                        Assert.AreEqual(0, c.UpToStudentCollection.Count)
                        Assert.AreEqual(0, s.UpToCourseCollection.Count)
                    End Using
                    Exit Select
                Case Else

                    Assert.Ignore("Not tested")
                    Exit Select
            End Select
        End Sub

		<Test> _
		Public Sub TestAssociateDissociate()
			Dim empKey As Integer = -1
			Dim terr As New Territory()
			terr.es.Connection.Name = "ForeignKeyTest"
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					Dim terrKey As Integer = 1
					terr.LoadByPrimaryKey(terrKey)

					emp.LastName = "Test Last"
					emp.FirstName = "Test First"

					emp.AssociateTerritoryCollection(terr)
					emp.Save()
					empKey = emp.EmployeeID.Value

					Assert.AreEqual(1, emp.UpToTerritoryCollection.Count)
					For Each et As EmployeeTerritory In emp.EmployeeTerritoryCollectionByEmpID
						Assert.AreEqual(terr.TerritoryID.Value, et.TerrID.Value)
					Next
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(empKey) Then
					For Each t As Territory In emp.UpToTerritoryCollection
						emp.DissociateTerritoryCollection(t)
					Next
					emp.MarkAsDeleted()
					emp.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub TestSettingNull()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			Try
				Using scope As New esTransactionScope()
					emp.LoadByPrimaryKey(5)
					Assert.AreEqual(0, emp.UpToTerritoryCollection.Count)

					Dim terr As New Territory()
					terr.es.Connection.Name = "ForeignKeyTest"

					terr.LoadByPrimaryKey(1)

					emp.AssociateTerritoryCollection(terr)
					emp.Save()

					Assert.AreEqual(0, emp.UpToTerritoryCollection.Count)
					emp.UpToTerritoryCollection = Nothing
					Assert.AreEqual(1, emp.UpToTerritoryCollection.Count)
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				If emp.LoadByPrimaryKey(5) Then
					For Each t As Territory In emp.UpToTerritoryCollection
						emp.DissociateTerritoryCollection(t)
					Next
					emp.Save()
				End If
			End Try
		End Sub
	End Class
End Namespace
