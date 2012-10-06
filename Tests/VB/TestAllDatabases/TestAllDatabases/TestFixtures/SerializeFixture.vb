'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Linq
Imports System.Data
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

Imports NUnit.Framework
'using Adapdev.UnitTest;
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class SerializeFixture
		Private aggTestColl As New AggregateTestCollection()
		Private aggTest As New AggregateTest()
		Private aggTestQuery As New AggregateTestQuery()
		Private aggCloneColl As New AggregateTestCollection()
		Private aggClone As New AggregateTest()
		Private aggCloneQuery As New AggregateTestQuery()

		<TestFixtureSetUp> _
		Public Sub Init()
		End Sub

		<SetUp> _
		Public Sub Init2()
			aggTestColl = New AggregateTestCollection()
			aggTest = New AggregateTest()
			aggTestQuery = New AggregateTestQuery()
			aggCloneColl = New AggregateTestCollection()
			aggClone = New AggregateTest()
			aggCloneQuery = New AggregateTestQuery()
		End Sub

		<Test> _
		Public Sub SerializeDeserializeNewEntityBinary()
			If aggTest.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				aggTest.LastName = "Griffinski"

				Dim bf As New BinaryFormatter()
				Dim ms As New MemoryStream()
				bf.Serialize(ms, aggTest)

				ms.Position = 0
				aggClone = DirectCast(bf.Deserialize(ms), AggregateTest)
				ms.Close()

				Assert.AreEqual("Griffinski", aggClone.str.LastName)
			End If
		End Sub

		<Test> _
		Public Sub SerializeDeserializeLoadEntityBinary()
			If aggTest.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				Dim key As Integer = 0
				aggTest.Query.Where(aggTest.Query.LastName = "Douglas", aggTest.Query.FirstName = "Fred")
				aggTest.Query.Load()
				key = aggTest.Id.Value

				aggTest = New AggregateTest()
				aggTest.LoadByPrimaryKey(key)

				Dim bf As New BinaryFormatter()
				Dim ms As New MemoryStream()
				bf.Serialize(ms, aggTest)

				ms.Position = 0
				aggClone = DirectCast(bf.Deserialize(ms), AggregateTest)
				ms.Close()

				Assert.AreEqual("Douglas", aggClone.str.LastName)
			End If
		End Sub

		<Test> _
		Public Sub SerializeDeserializeFindEntityBinary()
			Dim key As Integer = 0
			aggTestColl.LoadAll()
			For Each test As AggregateTest In aggTestColl
				If test.LastName = "Doe" Then
					key = test.Id.Value
					Exit For
				End If
			Next
			aggTest = aggTestColl.FindByPrimaryKey(key)

			Dim bf As New BinaryFormatter()
			Dim ms As New MemoryStream()
			bf.Serialize(ms, aggTest)

			ms.Position = 0
			aggClone = DirectCast(bf.Deserialize(ms), AggregateTest)
			ms.Close()

			Assert.AreEqual("Doe", aggClone.str.LastName)
		End Sub

		<Test> _
		Public Sub SerializeDeserializeCollectionBinary()
			If aggTestColl.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				aggTestColl.LoadAll()

				Dim bf As New BinaryFormatter()
				Dim ms As New MemoryStream()
				bf.Serialize(ms, aggTestColl)

				ms.Position = 0
				aggCloneColl = DirectCast(bf.Deserialize(ms), AggregateTestCollection)
				ms.Close()

                Assert.AreEqual(30, aggCloneColl.Count)
			End If
		End Sub

		<Test> _
		Public Sub CollectionChangesBinary()
			If aggTestColl.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count, "Old")
                aggTestColl.Filter = aggTestColl.AsQueryable().OrderBy(Function(s As AggregateTest) s.Id)

				aggTestColl(0).MarkAsDeleted()
				For Each entity As AggregateTest In aggTestColl
					If entity.LastName = "Doe" Then
						entity.LastName = "Changed"
					End If
				Next
				aggTest = aggTestColl.AddNew()
				aggTest.LastName = "New"

				Dim rowCount As Integer = 0
				For Each r As AggregateTest In aggTestColl
					If r.es.IsAdded OrElse r.es.IsModified Then
						rowCount += 1
					End If
				Next
				For Each r As AggregateTest In aggTestColl.es.DeletedEntities
					rowCount += 1
				Next
				'aggTestColl.RowStateFilter = DataViewRowState.ModifiedCurrent |
				'    DataViewRowState.Deleted |
				'    DataViewRowState.Added;

				Assert.AreEqual(4, rowCount, "OldFiltered")

				Dim bf As New BinaryFormatter()
				Dim ms As New MemoryStream()
				bf.Serialize(ms, aggTestColl)

				ms.Position = 0
				aggCloneColl = DirectCast(bf.Deserialize(ms), AggregateTestCollection)
				ms.Close()

                Assert.AreEqual(30, aggCloneColl.Count, "New")

				rowCount = 0
				For Each r As AggregateTest In aggTestColl
					If r.es.IsAdded OrElse r.es.IsModified Then
						rowCount += 1
					End If
				Next
				For Each r As AggregateTest In aggTestColl.es.DeletedEntities
					rowCount += 1
				Next
				'aggCloneColl.RowStateFilter = DataViewRowState.ModifiedCurrent |
				'    DataViewRowState.Deleted |
				'    DataViewRowState.Added;

				Assert.AreEqual(4, rowCount, "NewFiltered")
			End If
		End Sub

		<Test> _
		Public Sub SerializeDeserializeProxyStubCollection()
			If aggTest.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				' Load all 5 Employees
				Dim collection As New EmployeeCollection()
				collection.es.Connection.Name = "ForeignKeyTest"

				collection.LoadAll()

				' Create a Proxy and Serialize into a string named "Packet"
				Dim proxy As New EmployeeCollectionProxyStub(collection)

				Dim sf As New XmlSerializer(GetType(EmployeeCollectionProxyStub))
				Dim sw As New StringWriter()
				sf.Serialize(sw, proxy)

				Dim packet As String = sw.ToString()

				' Now let's DeSerialize it
				Dim xs As New XmlSerializer(GetType(EmployeeCollectionProxyStub))
				Dim sr As New StringReader(packet)

				proxy = TryCast(xs.Deserialize(sr), EmployeeCollectionProxyStub)

				' Count should = 5
                Assert.AreEqual(5, proxy.GetCollection().Count)
				Assert.AreEqual("Smith", proxy.Collection(0).LastName)
			End If
		End Sub

		<Test> _
		Public Sub SerializeDeserializeProxyStubEntity()
			If aggTest.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				' Load an Employee
				Dim emp As New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				emp.LoadByPrimaryKey(1)

				' Create a Proxy and Serialize into a string named "Packet"
				Dim proxy As New EmployeeProxyStub(emp)

				Dim sf As New XmlSerializer(GetType(EmployeeProxyStub))
				Dim sw As New StringWriter()
				sf.Serialize(sw, proxy)

				Dim packet As String = sw.ToString()

				' Now let's DeSerialize it
				Dim xs As New XmlSerializer(GetType(EmployeeProxyStub))
				Dim sr As New StringReader(packet)

				proxy = TryCast(xs.Deserialize(sr), EmployeeProxyStub)

				Assert.AreEqual("Unchanged", proxy.Entity.es.RowState.ToString())
				Assert.AreEqual("Smith", proxy.Entity.LastName)
			End If
		End Sub

		<Test> _
		Public Sub SerializeDeserializeProxyStubEntityQuery()
			If aggTest.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				' Client-side query to load an Employee
				Dim emp As New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"

				emp.Query.Where(emp.Query.EmployeeID = 1)

				' Use binary serialization to include the query
				Dim bf As New BinaryFormatter()
				Dim ms As New MemoryStream()
				bf.Serialize(ms, emp)
				Dim query As Byte() = ms.ToArray()

				' Send it to the server over the wire

				' Server-side deserialize
				bf = New BinaryFormatter()
				ms = New MemoryStream(query)
				Dim newEmp As Employee = TryCast(bf.Deserialize(ms), Employee)
				newEmp.es.Connection.Name = "ForeignKeyTest"
				newEmp.Query.es2.Connection.Name = "ForeignKeyTest"

				' Now load it 
				Assert.IsTrue(newEmp.Query.Load())
				Assert.AreEqual(1, newEmp.EmployeeID.Value)

				'  Server-side Create a Proxy and Serialize to XML string
				Dim proxy As New EmployeeProxyStub(newEmp)

				Dim sf As New XmlSerializer(GetType(EmployeeProxyStub))
				Dim sw As New StringWriter()
				sf.Serialize(sw, proxy)

				Dim packet As String = sw.ToString()

				' Send it back to the client over the wire

				' Client-side Proxy XML string deserialize
				Dim xs As New XmlSerializer(GetType(EmployeeProxyStub))
				Dim sr As New StringReader(packet)

				proxy = TryCast(xs.Deserialize(sr), EmployeeProxyStub)
				emp = proxy.Entity

				Assert.AreEqual("Unchanged", emp.es.RowState.ToString())
				Assert.AreEqual(1, emp.EmployeeID.Value)
			End If
		End Sub

		<Test> _
		Public Sub SerializeDeserializeDynamicQuery()
			If aggTest.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				' Test serializing a DynamicQuery
				' Must use binary serialization
				' Xml serialization doesn't serialize all of your private properties
				' 1) Create our Query on the client
				Dim q As New EmployeeQuery("E")
				'q.es.Connection.Name = "ForeignKeyTest";

				q.[Select](q.FirstName, q.LastName)
				q.Where(q.LastName.[Like]("S%"))

				' 2) Serialize it in binary
				Dim bf As New BinaryFormatter()
				Dim ms As New MemoryStream()
				bf.Serialize(ms, q)
				Dim query As Byte() = ms.ToArray()

				' 3) Send it over the wire

				' 4) Deserialize it on the Server
				bf = New BinaryFormatter()
				ms = New MemoryStream(query)
				Dim newQuery As EmployeeQuery = TryCast(bf.Deserialize(ms), EmployeeQuery)

				' Now load it 
				Dim collection As New EmployeeCollection()
				collection.es.Connection.Name = "ForeignKeyTest"

				collection.Load(newQuery)

                Assert.AreEqual(2, collection.Count)
				Assert.AreEqual("S", collection(0).LastName.Substring(0, 1))
			End If
		End Sub

		<Test> _
		Public Sub SerializeDeserializeJoin()
			If aggTest.es.Connection.Name = "SqlCe" Then
				Assert.Ignore("Not tested for SqlCe.")
			Else
				' Test serializing a DynamicQuery
				' Must use binary serialization
				' Xml serialization doesn't serialize all of your private properties
				' 1) Create our Query on the client
				Dim emp As New EmployeeQuery("eq")
				'emp.es.Connection.Name = "ForeignKeyTest";
				Dim et As New EmployeeTerritoryQuery("etq")
				'et.es.Connection.Name = "ForeignKeyTest";
				emp.[Select](emp.FirstName, emp.LastName, et.TerrID)
				emp.InnerJoin(et).[On](emp.EmployeeID = et.EmpID)
				emp.Where(emp.LastName.[Like]("S%"))

				' 2) Serialize it in binary
				Dim bf As New BinaryFormatter()
				Dim ms As New MemoryStream()
				bf.Serialize(ms, emp)
				Dim query As Byte() = ms.ToArray()

				' 3) Send it over the wire

				' 4) Deserialize it on the Server
				bf = New BinaryFormatter()
				ms = New MemoryStream(query)
				Dim newQuery As EmployeeQuery = TryCast(bf.Deserialize(ms), EmployeeQuery)

				' Now load it 
				Dim collection As New EmployeeCollection()
				collection.es.Connection.Name = "ForeignKeyTest"

				collection.Load(newQuery)

                Assert.AreEqual(5, collection.Count)
				Assert.AreEqual("S", collection(0).LastName.Substring(0, 1))
			End If
		End Sub

	End Class
End Namespace
