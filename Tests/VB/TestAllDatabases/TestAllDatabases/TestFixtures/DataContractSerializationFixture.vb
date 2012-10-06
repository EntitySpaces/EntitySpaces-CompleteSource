'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Runtime.Serialization.Json
Imports System.Linq

Imports NUnit.Framework


Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class DataContractSerializationFixture
		<Test> _
		Public Sub TestSerializeQuery()
			Dim query As New EmployeeQuery("e")
			query.Where(query.EmployeeID.[In](1, 2, 3, New List(Of Object)()))

			Dim qq As String = EmployeeQuery.SerializeHelper.ToXml(query)

			Dim types As New List(Of Type)()
			types.Add(GetType(EmployeeQuery))

			Dim employeeQuery__1 As EmployeeQuery = TryCast(EmployeeQuery.SerializeHelper.FromXml(qq, GetType(EmployeeQuery), types), EmployeeQuery)

			Dim c As New EmployeeCollection()
			c.es.Connection.Name = "ForeignKeyTest"
			c.Load(employeeQuery__1)

            Assert.IsTrue(c.Count = 3)
		End Sub

		<Test> _
		Public Sub TestJSONSerialization()
			'---------------------------------------------------------------
			' Server Side
			'---------------------------------------------------------------
			Dim emp As New Employee()
			emp.es.Connection.Name = "ForeignKeyTest"

			emp.Query.es.Top = 1
            emp.Query.[Select](emp.Query.EmployeeID, emp.Query.FirstName, emp.Query.LastName, emp.Query.Age, (emp.Query.LastName + ", " + emp.Query.FirstName).[As]("Fullname"))
			emp.Query.Load()

			' Modifiy the first name ...
			emp.FirstName = "Freddy"

			'=======================

			Dim ser As New DataContractJsonSerializer(GetType(EmployeeProxyStub))
			Dim ms As New MemoryStream()
            ser.WriteObject(ms, CType(emp, EmployeeProxyStub))

			Dim json As String = Encoding.[Default].GetString(ms.ToArray())
			ms.Close()

			ms = New MemoryStream(Encoding.Unicode.GetBytes(json))
			ser = New DataContractJsonSerializer(GetType(EmployeeProxyStub))
			Dim empProxy As EmployeeProxyStub = TryCast(ser.ReadObject(ms), EmployeeProxyStub)
			ms.Close()

			Dim emp2 As Employee = empProxy.Entity
		End Sub

		<Test> _
		Public Sub TestProxiesDirtyRowsOnly()
			Dim coll As New EmployeeCollection()

			Dim e As Employee = coll.AddNew()
			e.EmployeeID = 1
			e.FirstName = "unchanged"
			e.LastName = "unchanged"

			e = coll.AddNew()
			e.EmployeeID = 2
			e.FirstName = "unchanged"
			e.LastName = "unchanged"

			e = coll.AddNew()
			e.EmployeeID = 3
			e.FirstName = "deleted"
			e.LastName = "deleted"

			coll.AcceptChanges()

			coll(2).MarkAsDeleted()

			e = coll.AddNew()
			e.EmployeeID = 4
			e.FirstName = "Added"
			e.LastName = "Added"

			Dim proxy As New EmployeeCollectionProxyStub(coll)

			Dim qq As String = esDataContractSerializer.ToXml(proxy)
		End Sub
	End Class
End Namespace
