'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Collections.Generic
Imports System.Text

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class ManyToOneFixture
		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
		End Sub

		<Test> _
		Public Sub TestMultipleReferences()
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			cust.LoadByPrimaryKey("01001", "001")
			Assert.IsTrue(cust.UpToEmployeeByManager.es.HasData)
			Assert.IsTrue(cust.UpToEmployeeByStaffAssigned.es.HasData)
		End Sub

		<Test> _
		Public Sub TestNullReferences()
			Dim cSub As String
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			Select Case cust.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					cSub = "1  "
					Exit Select
				Case Else

					cSub = "1"
					Exit Select
			End Select

			If cust.LoadByPrimaryKey("10000", cSub) Then
				If cust.UpToEmployeeByStaffAssigned IsNot Nothing Then
					Assert.Fail("Should be null")
				End If
			Else
				Assert.Fail("It should load")
			End If
		End Sub

		<Test> _
		Public Sub TestAssignReference()
			Dim cSub As String
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			Select Case cust.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SQLiteProvider"
					cSub = "1  "
					Exit Select
				Case Else

					cSub = "1"
					Exit Select
			End Select

			If cust.LoadByPrimaryKey("10000", cSub) Then
				If cust.UpToEmployeeByStaffAssigned IsNot Nothing Then
					Assert.Fail("Should be null")
				End If
			Else
				Assert.Fail("It should load")
			End If

			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"
			emp.LoadByPrimaryKey(1)

			cust.UpToEmployeeByStaffAssigned = emp
			cust.Save()

			cust = New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			If cust.LoadByPrimaryKey("10000", cSub) Then
				Assert.IsNotNull(cust.UpToEmployeeByStaffAssigned)
			Else
				Assert.Fail("It should load")
			End If

			cust.StaffAssigned = Nothing
			cust.Save()

			cust.UpToEmployeeByStaffAssigned = Nothing
			Assert.IsNull(cust.UpToEmployeeByStaffAssigned)


		End Sub

		<Test> _
		Public Sub TestCompositeForeignKey()
			Dim cust As New Customer()
			cust.es.Connection.Name = "ForeignKeyTest"

			Assert.IsTrue(cust.LoadByPrimaryKey("01001", "001"), "Loaded")
			Assert.IsTrue(cust.UpToEmployeeByManager.es.HasData, "HasData")
		End Sub

		<Test> _
		Public Sub TestSelfReference()
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.LoadByPrimaryKey(2)
			Assert.IsTrue(emp.UpToEmployeeBySupervisor.es.HasData)
		End Sub
	End Class
End Namespace
