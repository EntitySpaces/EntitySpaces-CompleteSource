'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data
Imports System.Linq
Imports NUnit.Framework

Imports EntitySpaces.Interfaces
Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class SaveFixture
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
		Public Sub LoadAllDeleteAllSave()
			Try
				aggTestColl.LoadAll()
				aggTestColl.MarkAllAsDeleted()
				aggTestColl.Save()
				Assert.IsFalse(aggTestColl.LoadAll())
				UnitTestBase.RefreshDatabase()
			Catch ex As Exception
				Assert.Fail(ex.ToString())
			End Try
		End Sub

		<Test> _
		Public Sub SaveComposite()
			Using scope As New esTransactionScope()
				Dim coll As New OrderItemCollection()
				coll.es.Connection.Name = "ForeignKeyTest"

				Dim entity As OrderItem = coll.AddNew()
				entity.OrderID = 9
				entity.ProductID = 1
				entity.UnitPrice = 1000
				entity.Quantity = 1000
				entity = coll.AddNew()
				entity.OrderID = 9
				entity.ProductID = 2
				entity.UnitPrice = 1000
				entity.Quantity = 1000
				entity = coll.AddNew()
				entity.OrderID = 9
				entity.ProductID = 3
				entity.UnitPrice = 1000
				entity.Quantity = 1000

				coll.Save()

				coll = New OrderItemCollection()
				coll.es.Connection.Name = "ForeignKeyTest"

				coll.Query.Where(coll.Query.OrderID = 9)
				Assert.IsTrue(coll.Query.Load())
                Assert.AreEqual(3, coll.Count)

				' Clean up
				coll.MarkAllAsDeleted()
				coll.Save()

				coll = New OrderItemCollection()
				coll.es.Connection.Name = "ForeignKeyTest"

				coll.Query.Where(coll.Query.OrderID = 9)
				Assert.IsFalse(coll.Query.Load())

				coll = New OrderItemCollection()
				coll.es.Connection.Name = "ForeignKeyTest"

				Assert.IsTrue(coll.LoadAll())
                Assert.AreEqual(15, coll.Count)
			End Using
		End Sub

		<Test> _
		Public Sub SaveWithExtraColumns()
			Dim aggTestId As Integer = -1

			Try
				Using scope As New esTransactionScope()
					' INSERT
					Dim t As New AggregateTest()
					t.Age = 50
					t.SetColumn("extracolumn", 50)
					t.Save()
					aggTestId = t.Id.Value

					' UPDATE
					t.Age = 51
					t.SetColumn("extracolumn", 51)
					t.Save()

					' DELETE
					t.SetColumn("extracolumn", 52)
					t.MarkAsDeleted()
					t.Save()
				End Using
			Finally
				' Clean up
				aggTest = New AggregateTest()
				If aggTest.LoadByPrimaryKey(aggTestId) Then
					aggTest.MarkAsDeleted()
					aggTest.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub CollectionMixedInsUpdDel()
			Using scope As New esTransactionScope()
				' Setup
				Dim newEmp As New Employee()
				newEmp.es.Connection.Name = "ForeignKeyTest"
				newEmp.LastName = "new"
				newEmp.FirstName = "new"
				newEmp.Save()

				Dim coll As New EmployeeCollection()
				coll.es.Connection.Name = "ForeignKeyTest"
				coll.LoadAll()
                Assert.AreEqual(6, coll.Count, "Initial Load")

				' Insert
				Dim emp1 As Employee = coll.AddNew()
				emp1.FirstName = "emp1"
				emp1.LastName = "emp1"

				' Update
				Dim emp3 As Employee = coll.FindByPrimaryKey(1)
				emp3.LastName = "emp3"

				' Delete
				Dim emp4 As Employee = coll.FindByPrimaryKey(newEmp.EmployeeID.Value)
				emp4.MarkAsDeleted()

				coll.Save()

				' Confirm INSERT
				Dim empIns As New Employee()
				empIns.es.Connection.Name = "ForeignKeyTest"
				Assert.IsTrue(empIns.LoadByPrimaryKey(emp1.EmployeeID.Value), "Insert")

				' Confirm UPDATE
				Dim empUpd As New Employee()
				empUpd.es.Connection.Name = "ForeignKeyTest"
				Assert.IsTrue(empUpd.LoadByPrimaryKey(1), "Update")
				Assert.AreEqual("emp3", empUpd.LastName, "UpdateValue")

				' Confirm DELETE
				Dim empDel As New Employee()
				empDel.es.Connection.Name = "ForeignKeyTest"
				Assert.IsFalse(empDel.LoadByPrimaryKey(newEmp.EmployeeID.Value), "Delete")
			End Using
		End Sub

		<Test> _
		Public Sub ErrorsWithContinueDefaultFalse()
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"
			coll.LoadAll()
            Assert.AreEqual(5, coll.Count, "Initial Load")

			Using scope As New esTransactionScope()
				Try
					' INSERT would succeed
					' but should rollback by default
					Dim emp1 As Employee = coll.AddNew()
					emp1.FirstName = "asdf"
					emp1.LastName = "adf"

					' INSERT will fail - LastName required
					Dim emp2 As Employee = coll.AddNew()

					' UPDATE will fail - LastName required
					Dim emp3 As Employee = coll.FindByPrimaryKey(1)
					emp3.LastName = Nothing

					' DELETE will fail - FK constraint
					Dim emp4 As Employee = coll.FindByPrimaryKey(2)
					emp4.MarkAsDeleted()

					coll.Save(False)
				Catch ex As Exception
					' Save() throws exception on first error encountered
					Assert.AreEqual(1, coll.Errors.Count(), "ExceptionCount")
					Assert.IsTrue(ex.ToString().Length > 0, "ExceptionLength")
				Finally
					' Confirm nothing got INSERTed
					Dim coll2 As New EmployeeCollection()
					coll2.es.Connection.Name = "ForeignKeyTest"
					coll2.LoadAll()
                    Assert.AreEqual(5, coll2.Count, "LoadInFinally")

					' Confirm nothing got UPDATEd
					Dim empUpd As Employee = coll2.FindByPrimaryKey(1)
					Assert.AreEqual("Smith", empUpd.LastName, "Update")

					' Confirm nothing got DELETEd
					Dim empDel As New Employee()
					empDel.es.Connection.Name = "ForeignKeyTest"
					Assert.IsTrue(empDel.LoadByPrimaryKey(2), "Delete")
				End Try
			End Using
		End Sub

		<Test> _
		Public Sub ErrorsWithContinueTrueInsUpd()
			Using scope As New esTransactionScope()
				Dim coll As New EmployeeCollection()
				coll.es.Connection.Name = "ForeignKeyTest"

				' This employee should save fine
				Dim e As Employee = coll.AddNew()
				e.FirstName = "Test1"
				e.LastName = "K98700"

				' Should fail, missing LastName
				e = coll.AddNew()
				e.FirstName = "Joe"

				' Should fail, missing FirstName
				e = coll.AddNew()
				e.LastName = "Kokomo"

				' This employee should save fine
				e = coll.AddNew()
				e.FirstName = "Test4"
				e.LastName = "K98700"

				Try
						' ContinueUpdateOnError
					coll.Save(True)
				Catch
					Assert.Fail("1. We shouldn't get here")
				End Try

				Assert.IsTrue(coll.Errors.Count() = 2, "Count")
				Assert.IsTrue(coll(0).es.RowState = esDataRowState.Unchanged, "Unchanged0")
				Assert.IsTrue(coll(1).es.RowState = esDataRowState.Added, "Added1")
				Assert.IsTrue(coll(2).es.RowState = esDataRowState.Added, "Added2")
				Assert.IsTrue(coll(3).es.RowState = esDataRowState.Unchanged, "Unchanged3")
				Assert.IsTrue(coll(0).EmployeeID IsNot Nothing, "Id0")
				Assert.IsTrue(coll(1).EmployeeID Is Nothing, "Id1")
				Assert.IsTrue(coll(2).EmployeeID Is Nothing, "Id2")
				Assert.IsTrue(coll(3).EmployeeID IsNot Nothing, "Id3")

				For Each emp As Employee In coll.Errors
					Assert.IsTrue(emp.es.RowState = esDataRowState.Added, "ForeachRowSate")
					Assert.IsTrue(emp.es.RowError IsNot Nothing, "ForeachRowError")
					Assert.IsTrue(emp.es.RowError.Length > 0, "ForeachLength")
				Next

				' Call Save again with the 2 bad records just for kicks
				Try
						' ContinueUpdateOnError
					coll.Save(True)
				Catch
					Assert.Fail("2. We shouldn't get here, either")
				End Try

				Assert.IsTrue(coll.Errors.Count() = 2)

				' Fix our two bad records and call Save again
				coll(1).LastName = "LastName"
				coll(2).FirstName = "FirstName"

				Try
						' ContinueUpdateOnError
					coll.Save(True)
				Catch
					Assert.Fail("3. We shouldn't get here, either")
				End Try

				Assert.IsTrue(coll.Errors.Count() = 0)

				' Load the two original records and see if they were saved even though during the
				' save there were two bad records
				coll = New EmployeeCollection()
				coll.es.Connection.Name = "ForeignKeyTest"
				coll.Query.Where(coll.Query.LastName = "K98700")
				coll.Query.Load()

				Assert.IsTrue(coll.Count() = 2, "FinalCount")
			End Using
		End Sub

		<Test> _
		Public Sub ErrorsWithContinueTrueInsUpdDel()
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"
			coll.LoadAll()
            Assert.AreEqual(5, coll.Count, "Initial Load")

			Using scope As New esTransactionScope()
				' SQLite does not enforce FK constraints
				' So force a concurrency failure instead
				If coll.es.Connection.ProviderSignature.DataProviderName = "EntitySpaces.SQLiteProvider" Then
					Dim empConcurr As New Employee()
					empConcurr.es.Connection.Name = "ForeignKeyTest"
					empConcurr.LoadByPrimaryKey(2)
					empConcurr.MarkAsDeleted()
					empConcurr.Save()
				End If

				' INSERT will succeed
				Dim emp1 As Employee = coll.AddNew()
				emp1.FirstName = "First1"
				emp1.LastName = "Last1"

				' INSERT will fail - LastName required
				Dim emp2 As Employee = coll.AddNew()

				' UPDATE will fail - LastName required
				Dim emp3 As Employee = coll.FindByPrimaryKey(1)
				emp3.LastName = Nothing

				' DELETE will fail - FK constraint
				Dim emp4 As Employee = coll.FindByPrimaryKey(2)
				emp4.MarkAsDeleted()

				' INSERT will succeed
				Dim emp5 As Employee = coll.AddNew()
				emp5.FirstName = "First5"
				emp5.LastName = "Last5"

				coll.Save(True)

				Assert.AreEqual(3, coll.Errors.Count(), "ErrorsCount")
				Assert.IsNotNull(coll.es.DeletedEntities, "DeletedErrors")

				For Each e As Employee In coll.Errors
					Assert.IsTrue(e.es.RowError.Length > 0)
				Next

				' Confirm only 2 rows got INSERTed
				Dim coll2 As New EmployeeCollection()
				coll2.es.Connection.Name = "ForeignKeyTest"
				coll2.LoadAll()
				If coll.es.Connection.ProviderSignature.DataProviderName = "EntitySpaces.SQLiteProvider" Then
                    Assert.AreEqual(6, coll2.Count, "Load")
				Else
                    Assert.AreEqual(7, coll2.Count, "Load")

					' Confirm nothing got DELETEd
					Dim empDel As New Employee()
					empDel.es.Connection.Name = "ForeignKeyTest"
					Assert.IsTrue(empDel.LoadByPrimaryKey(2), "Delete")
				End If

				' Confirm nothing got UPDATEd
				Dim empUpd As New Employee()
				empUpd.es.Connection.Name = "ForeignKeyTest"
				Assert.IsTrue(empUpd.LoadByPrimaryKey(1))
				Assert.AreEqual("Smith", empUpd.LastName, "Update")

				' Confirm auto-incremeting PKs are brought back
				' and delete the 2 successfully inserted rows
				Dim emp1Id As Integer = emp1.EmployeeID.Value
				Dim emp1Ins As New Employee()
				emp1Ins.es.Connection.Name = "ForeignKeyTest"

				Assert.IsTrue(emp1Ins.LoadByPrimaryKey(emp1Id), "LoadByPK1")
				emp1Ins.MarkAsDeleted()
				emp1Ins.Save()

				Dim emp5Id As Integer = emp5.EmployeeID.Value
				Dim emp5Ins As New Employee()
				emp5Ins.es.Connection.Name = "ForeignKeyTest"

				Assert.IsTrue(emp5Ins.LoadByPrimaryKey(emp5Id), "LoadByPK2")
				emp5Ins.MarkAsDeleted()
				emp5Ins.Save()
			End Using
		End Sub

		<Test> _
		Public Sub ErrorsWithContinueTrueDel()
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"
			coll.LoadAll()
            Assert.AreEqual(5, coll.Count, "Initial Load")

			Using scope As New esTransactionScope()
				' SQLite does not enforce FK constraints
				' So force a concurrency failure instead
				If coll.es.Connection.ProviderSignature.DataProviderName = "EntitySpaces.SQLiteProvider" Then
					Dim empConcurr As New Employee()
					empConcurr.es.Connection.Name = "ForeignKeyTest"
					empConcurr.LoadByPrimaryKey(2)
					empConcurr.MarkAsDeleted()
					empConcurr.Save()
				End If

				' DELETE will fail - FK constraint
				Dim emp4 As Employee = coll.FindByPrimaryKey(2)
				emp4.MarkAsDeleted()

				coll.Save(True)

				Assert.AreEqual(1, coll.Errors.Count(), "ErrorsCount")
				Assert.IsNotNull(coll.es.DeletedEntities, "DeletedErrors")

				For Each e As Employee In coll.Errors
					Assert.IsTrue(e.es.RowError.Length > 0)
				Next

				If coll.es.Connection.ProviderSignature.DataProviderName <> "EntitySpaces.SQLiteProvider" Then
					' Confirm same table row count
					Dim coll2 As New EmployeeCollection()
					coll2.es.Connection.Name = "ForeignKeyTest"
					coll2.LoadAll()
                    Assert.AreEqual(5, coll2.Count, "Load")

					' Confirm nothing got DELETEd
					Dim empDel As New Employee()
					empDel.es.Connection.Name = "ForeignKeyTest"
					Assert.IsTrue(empDel.LoadByPrimaryKey(2), "Delete")
				End If
			End Using
		End Sub

		<Test> _
		Public Sub ErrorsWithContinueTrueNoFailures()
			Dim coll As New EmployeeCollection()
			coll.es.Connection.Name = "ForeignKeyTest"
			coll.LoadAll()
            Assert.AreEqual(5, coll.Count, "Initial Load")

			Using scope As New esTransactionScope()
				' INSERT will succeed
				Dim emp5 As Employee = coll.AddNew()
				emp5.FirstName = "First5"
				emp5.LastName = "Last5"

				coll.Save(True)

				Assert.AreEqual(0, coll.Errors.Count(), "ErrorsCount")
				Assert.IsNull(coll.es.DeletedEntities, "DeletedErrors")

				' Confirm only 1 row got INSERTed
				Dim coll2 As New EmployeeCollection()
				coll2.es.Connection.Name = "ForeignKeyTest"
				coll2.LoadAll()
                Assert.AreEqual(6, coll2.Count, "Load")

				' Confirm auto-incremeting PKs are brought back
				' and delete the successfully inserted row
				Dim emp5Id As Integer = emp5.EmployeeID.Value
				Dim emp5Ins As New Employee()
				emp5Ins.es.Connection.Name = "ForeignKeyTest"

				Assert.IsTrue(emp5Ins.LoadByPrimaryKey(emp5Id), "LoadByPK2")
				emp5Ins.MarkAsDeleted()
				emp5Ins.Save()
			End Using
		End Sub

		<Test> _
		Public Sub FilteredDeleteAll()
			Using scope As New esTransactionScope()
				Dim aggTestColl As New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
                aggTestColl.Filter = aggTestColl.AsQueryable().Where(Function(f As AggregateTest) f.LastName = "Doe")
                Assert.AreEqual(3, aggTestColl.Count)

				aggTestColl.MarkAllAsDeleted()

				aggTestColl.Filter = Nothing
                Assert.AreEqual(27, aggTestColl.Count)

				aggTestColl.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(27, aggTestColl.Count)
			End Using
		End Sub

		' Tests adding a new row that has only Autoinc and nullable
		' fields as would be found in DataBaseRefresh
		<Test> _
		Public Sub AddNewEmptySave()
			Using scope As New esTransactionScope()
				aggTest = aggTestColl.AddNew()
				aggTestColl.Save()
				Dim aggTestId As Integer = aggTest.Id.Value

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(31, aggTestColl.Count)

				aggTest = New AggregateTest()
				Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId))
				aggTest.MarkAsDeleted()
				aggTest.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
			End Using
		End Sub

		<Test> _
		Public Sub NoAddNew()
			Dim aggTestId As Integer = -1

			Try
				Using scope As New esTransactionScope()
					aggTest = New AggregateTest()
					aggTest.Age = 30
					aggTest.Save()
					aggTestId = aggTest.Id.Value

					aggTest = New AggregateTest()
					Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId))
					Assert.AreEqual(30, aggTest.Age.Value)
				End Using
			Finally
				' Clean up
				aggTest = New AggregateTest()
				If aggTest.LoadByPrimaryKey(aggTestId) Then
					aggTest.MarkAsDeleted()
					aggTest.Save()
				End If

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
			End Try
		End Sub

		<Test> _
		Public Sub SaveAlternateConnection()
			Dim emp As New Employee()
			Dim empId As Integer = -1

			Try
				Using scope As New esTransactionScope()
					emp = New Employee()
					emp.es.Connection.Name = "ForeignKeyTest"

					emp.LastName = "McTest"
					emp.FirstName = "Testy"
					emp.Age = 30
					emp.Save()
					empId = emp.EmployeeID.Value

					emp = New Employee()
					emp.es.Connection.Name = "ForeignKeyTest"
					Assert.IsTrue(emp.LoadByPrimaryKey(empId))
					Assert.AreEqual(30, emp.Age.Value)
				End Using
			Finally
				' Clean up
				emp = New Employee()
				emp.es.Connection.Name = "ForeignKeyTest"
				If emp.LoadByPrimaryKey(empId) Then
					emp.MarkAsDeleted()
					emp.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub EmptyEntity()
			Using scope As New esTransactionScope()
				aggTest = New AggregateTest()
				aggTest.Save()
				Dim aggTestId As Integer = aggTest.Id.Value

				aggTest = New AggregateTest()
				Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId))

				' Clean up
				aggTest.MarkAsDeleted()
				aggTest.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
			End Using
		End Sub

		<Test> _
		Public Sub EmptyCollection()
			Using scope As New esTransactionScope()
				aggTestColl = New AggregateTestCollection()
				aggTestColl.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
			End Using
		End Sub

		<Test> _
		Public Sub RetrieveAutoIncrementingKey()
			Using scope As New esTransactionScope()
				aggTest = aggTestColl.AddNew()
				aggTestColl.Save()
				Dim aggTestId As Integer = aggTest.Id.Value

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(31, aggTestColl.Count)

				aggTest = New AggregateTest()
				Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId))
				aggTest.MarkAsDeleted()
				aggTest.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
			End Using
		End Sub

		<Test> _
		Public Sub IsDirtyEntity()
			Dim tempId As Integer = 0
			Try
				Using scope As New esTransactionScope()
					aggTest = New AggregateTest()
					Assert.IsTrue(aggTest.es.IsDirty)
					aggTest.Save()
					Assert.IsFalse(aggTest.es.IsDirty)
					tempId = aggTest.Id.Value
					aggTest.LastName = "LastName"
					Assert.IsTrue(aggTest.es.IsDirty)
					aggTest.Save()
					Assert.IsFalse(aggTest.es.IsDirty)
					aggTest.MarkAsDeleted()
					Assert.IsTrue(aggTest.es.IsDirty)
					aggTest.Save()
					Assert.IsFalse(aggTest.es.IsDirty)
				End Using
			Finally
				' Cleanup
				aggTest = New AggregateTest()
				If aggTest.LoadByPrimaryKey(tempId) Then
					aggTest.MarkAsDeleted()
					aggTest.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub IsDirtyCollection()
			Using scope As New esTransactionScope()
				Assert.IsFalse(aggTestColl.IsDirty)
				aggTest = aggTestColl.AddNew()
				Assert.IsTrue(aggTestColl.IsDirty)
				aggTestColl.Save()
				Assert.IsFalse(aggTestColl.IsDirty)
				Dim tempId As Integer = aggTest.Id.Value
				aggTest.LastName = "LastName"
				Assert.IsTrue(aggTestColl.IsDirty)
				aggTestColl.Save()
				Assert.IsFalse(aggTestColl.IsDirty)
				aggTest.MarkAsDeleted()
				Assert.IsTrue(aggTestColl.IsDirty)
				aggTestColl.Save()
				Assert.IsFalse(aggTestColl.IsDirty)

				aggTest = aggTestColl.AddNew()
				aggTestColl.Save()
				tempId = aggTest.Id.Value
				aggTest = aggTestColl.AddNew()
				aggTestColl.Save()
				Dim tempId2 As Integer = aggTest.Id.Value

				aggTest = aggTestColl.FindByPrimaryKey(tempId)
				aggTest.MarkAsDeleted()
				aggTest = aggTestColl.FindByPrimaryKey(tempId2)
				aggTest.LastName = "Test"
				aggTest = aggTestColl.AddNew()
				aggTest.LastName = "Test2"
				Assert.IsTrue(aggTestColl.IsDirty)
				aggTestColl.Save()
				Assert.IsFalse(aggTestColl.IsDirty)
				Dim tempId3 As Integer = aggTest.Id.Value

				' Cleanup
				aggTest = New AggregateTest()
				If aggTest.LoadByPrimaryKey(tempId) Then
					aggTest.MarkAsDeleted()
					aggTest.Save()
				End If
				aggTest = New AggregateTest()
				aggTest.LoadByPrimaryKey(tempId2)
				aggTest.MarkAsDeleted()
				aggTest.Save()
				aggTest = New AggregateTest()
				aggTest.LoadByPrimaryKey(tempId3)
				aggTest.MarkAsDeleted()
				aggTest.Save()
			End Using
		End Sub

		<Test> _
		Public Sub UpdateOrInsertEntity()
			Using scope As New esTransactionScope()
				' The PK does not exist, so insert
				aggTest = New AggregateTest()
				Assert.IsFalse(aggTest.LoadByPrimaryKey(0))
				aggTest.LastName = "IsInsert"
				aggTest.Save()
				Dim aggTestId As Integer = aggTest.Id.Value

				' The PK does exist, so update
				aggTest = New AggregateTest()
				Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId))
				Assert.AreEqual("IsInsert", aggTest.LastName)
				aggTest.LastName = "IsUpdate"
				aggTest.Save()

				aggTest = New AggregateTest()
				Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId))
				Assert.AreEqual("IsUpdate", aggTest.LastName)

				' Clean up
				aggTest.MarkAsDeleted()
				aggTest.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
			End Using
		End Sub

		<Test> _
		Public Sub UpdateOrInsertEntityCustom()
			Using scope As New esTransactionScope()
				' The PK does not exist, so insert
				Dim entity As New AggregateTest()
				entity.SaveUpdateOrInsert(-1, "IsInsert")
				Dim aggTestId As Integer = entity.Id.Value

				entity = New AggregateTest()
				Assert.IsTrue(entity.LoadByPrimaryKey(aggTestId))
				Assert.AreEqual("IsInsert", entity.LastName)

				' The PK does exist, so update
				entity = New AggregateTest()
				entity.SaveUpdateOrInsert(aggTestId, "IsUpdate")

				entity = New AggregateTest()
				Assert.IsTrue(entity.LoadByPrimaryKey(aggTestId))
				Assert.AreEqual("IsUpdate", entity.LastName)

				' Clean up
				entity.MarkAsDeleted()
				entity.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(30, aggTestColl.Count)
			End Using
		End Sub

		<Test> _
		Public Sub UpdateEntity()
			Dim originalName As String = ""
			Using scope As New esTransactionScope()
				Dim key As Integer = 0
				aggTestColl.LoadAll()
				For Each agg As AggregateTest In aggTestColl
					key = agg.Id.Value
					Exit For
				Next
				aggTest.LoadByPrimaryKey(key)
				originalName = aggTest.LastName
				aggTest.LastName = "TestName"
				aggTest.Save()

				aggTest = New AggregateTest()
				aggTest.LoadByPrimaryKey(key)
				Assert.AreEqual("TestName", aggTest.LastName)

				aggTest.LastName = originalName
				aggTest.Save()
			End Using
		End Sub

		<Test> _
		Public Sub SaveTwice_LoadEntity()
			Dim originalName As String = ""
			Dim key As Integer = -1

			Using scope As New esTransactionScope()
				aggTestColl.LoadAll()
				For Each agg As AggregateTest In aggTestColl
					key = agg.Id.Value
					Exit For
				Next

				aggTest.LoadByPrimaryKey(key)
				originalName = aggTest.LastName
				aggTest.LastName = "TestName"
				aggTest.Save()

				aggTest.LastName = "TestName2"
				aggTest.Save()

				aggTest = New AggregateTest()
				aggTest.LoadByPrimaryKey(key)
				Assert.AreEqual("TestName2", aggTest.LastName)

				aggTest.LastName = originalName
				aggTest.Save()
			End Using
		End Sub

		<Test> _
		Public Sub SaveTwice_NewEntity()
			Dim key As Integer = -1

			Try
				Using scope As New esTransactionScope()
					aggTest.LastName = "TestName"
					aggTest.Save()

					key = aggTest.Id.Value

					aggTest.LastName = "TestName2"
					aggTest.Save()

					aggTest = New AggregateTest()
					aggTest.LoadByPrimaryKey(key)
					Assert.AreEqual("TestName2", aggTest.LastName)
				End Using
			Finally
				' Clean up
				aggTest = New AggregateTest()

				If aggTest.LoadByPrimaryKey(key) Then
					aggTest.MarkAsDeleted()
					aggTest.Save()
				End If
			End Try
		End Sub

		<Test> _
		Public Sub SetIdentityKeyIgnored()
			Dim key As Integer = -1

			Using scope As New esTransactionScope()
				aggTest.Id = 0
				aggTest.LastName = "TestName"
				aggTest.Save()

				key = aggTest.Id.Value
				Assert.Less(0, key)

				aggTest = New AggregateTest()
				aggTest.LoadByPrimaryKey(key)
				Assert.AreEqual("TestName", aggTest.LastName)

				aggTest.MarkAsDeleted()
				aggTest.Save()
			End Using
		End Sub

		<Test> _
		Public Sub RejectChangesCollection()
			Using scope As New esTransactionScope()
				aggTest = aggTestColl.AddNew()
				aggTestColl.Save()
				Dim aggTestId As Integer = aggTest.Id.Value

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(31, aggTestColl.Count)

				aggTest = aggTestColl.FindByPrimaryKey(aggTestId)
				aggTest.MarkAsDeleted()
				aggTestColl.AddNew()
				aggTestColl.RejectChanges()
				aggTestColl.Save()

				aggTestColl = New AggregateTestCollection()
				aggTestColl.LoadAll()
                Assert.AreEqual(31, aggTestColl.Count)

				' Cleanup
				aggTest = New AggregateTest()
				Assert.IsTrue(aggTest.LoadByPrimaryKey(aggTestId))
				aggTest.MarkAsDeleted()
				aggTest.Save()
			End Using
		End Sub

		<Test> _
		Public Sub ChangeWithoutLoading()
			Using scope As New esTransactionScope()
				Dim changeList As New AggregateTestCollection()
				changeList.Query.[Select](changeList.Query.Id, changeList.Query.LastName).Where(changeList.Query.LastName = "Doe")
				changeList.Query.Load()

				For Each change As AggregateTest In changeList
					Dim tempEntity As New AggregateTest()
					tempEntity.Id = change.Id
					tempEntity.AcceptChanges()
					' Sets RowState to Unchanged
					tempEntity.LastName = "X" & change.LastName
					' RowState is Modified
					tempEntity.Save()
				Next

				Dim testList As New AggregateTestCollection()
				testList.Query.[Select](testList.Query.Id, testList.Query.LastName).Where(testList.Query.LastName = "XDoe")
				testList.Query.Load()

				For Each change As AggregateTest In testList
					Assert.AreEqual("X", change.LastName.Substring(0, 1))
				Next

				' Change it back
				For Each change As AggregateTest In changeList
					Dim tempEntity As New AggregateTest()
					tempEntity.Id = change.Id
					tempEntity.AcceptChanges()
					' Sets RowState to Unchanged
					tempEntity.LastName = change.LastName
					' RowState is Modified
					tempEntity.Save()
				Next
			End Using
		End Sub

		<Test> _
		Public Sub PrimaryKeyNotFirstColumn()
			Dim notFirstTestColl As New KeyNotFirstCollection()

			Select Case notFirstTestColl.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider"
					Using scope As New esTransactionScope()
						notFirstTestColl.LoadAll()
						notFirstTestColl.MarkAllAsDeleted()
						notFirstTestColl.Save()

						notFirstTestColl = New KeyNotFirstCollection()
						Dim notFirstTest As KeyNotFirst = notFirstTestColl.AddNew()
						notFirstTestColl.Save()

						notFirstTestColl = New KeyNotFirstCollection()
						notFirstTestColl.LoadAll()
                        Assert.IsTrue(notFirstTestColl.Count > 0)
					End Using
					Exit Select
				Case Else

					Assert.Ignore("Sql Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub DynamicSaveNull()
			Dim id As Integer = -1
			'if (aggTestColl.es.Connection.SqlAccessType ==
			'    EntitySpaces.Interfaces.esSqlAccessType.DynamicSQL)
			'{
			Try
				Using scope As New esTransactionScope()
					' Create our test record
					aggTest = New AggregateTest()
					aggTest.FirstName = "TestFirst"
					aggTest.LastName = "TestLast"
					aggTest.Save()

					' Get the ID of the newly saved object
					id = aggTest.Id.Value

					' Confirm it saved
					aggTest = New AggregateTest()
					aggTest.LoadByPrimaryKey(id)
					Assert.AreEqual("TestFirst", aggTest.FirstName)
					Assert.AreEqual("TestLast", aggTest.LastName)

					' Set the LastName to null
					' FirstName to a empty string
					aggTest.FirstName = [String].Empty
					aggTest.LastName = Nothing
					aggTest.Save()

					' Re-read it, confirm null/empty
					aggTest = New AggregateTest()
					aggTest.LoadByPrimaryKey(id)

					' Oracle is not ANSI SQL compliant.
					' It treats an empty string as NULL.
					If aggTest.es.Connection.ProviderSignature.DataProviderName = "EntitySpaces.OracleClientProvider" Then
						Assert.IsNull(aggTest.FirstName)
					Else
						Assert.AreEqual("", aggTest.FirstName)
						Assert.IsNotNull(aggTest.FirstName)
					End If
					Assert.IsNull(aggTest.LastName)
				End Using
			Finally
				' Clean up
				aggTest = New AggregateTest()
				If aggTest.LoadByPrimaryKey(id) Then
					aggTest.MarkAsDeleted()
					aggTest.Save()
				End If
			End Try
			'}
			'else
			'{
			'    Assert.Ignore("DynamicSQL test only.");
			'}
		End Sub

		<Test> _
		Public Sub RetrieveComputed()
			Dim id As Long = -1
			Dim entity As New ConcurrencyTestChild()

			Select Case entity.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlClientProvider", "EntitySpaces.SybaseSqlAnywhereProvider"
					Try
						Using scope As New esTransactionScope()
							' Create test record
							entity = New ConcurrencyTestChild()
							entity.Name = "TestFirst"
							entity.DefaultTest = Convert.ToDateTime("2010-01-01")
							entity.ColumnA = 1
							entity.ColumnB = 2
							entity.Save()

							' Get the ID of the newly saved object
							id = entity.Id.Value

							' Check computed column is retrieved on insert
							Assert.AreEqual(3, entity.ComputedAB.Value)

							' Retrieve record for update
							entity = New ConcurrencyTestChild()
							entity.LoadByPrimaryKey(id)

							' Set the columns for computation
							entity.ColumnA = 10
							entity.ColumnB = 20
							entity.Save()

							' Check computed values are retrieved on update
							Assert.AreEqual(30, entity.ComputedAB.Value)
						End Using
					Finally
						' Clean up
						entity = New ConcurrencyTestChild()
						If entity.LoadByPrimaryKey(id) Then
							entity.MarkAsDeleted()
							entity.Save()
						End If
					End Try
					Exit Select
				Case Else

					Assert.Ignore("SQL Server only")
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub RetrieveDefaultOnInsert()
			Dim id As Long = -1
			Dim entity As New ConcurrencyTestChild()

			Try
				Using scope As New esTransactionScope()
					' Create test record
					entity = New ConcurrencyTestChild()
					entity.Name = "TestFirst"
					entity.Save()

					' Get the ID of the newly saved object
					id = entity.Id.Value

					' Check default value is retrieved on insert
					Assert.AreEqual(DateTime.Now.Day, entity.DefaultTest.Value.Day)
				End Using
			Finally
				' Clean up
				entity = New ConcurrencyTestChild()
				If entity.LoadByPrimaryKey(id) Then
					entity.MarkAsDeleted()
					entity.Save()
				End If
			End Try
        End Sub

        <Test()> _
        Public Sub DefaultNotNullOnInsert()
            Dim id As Integer = -1
            Dim entity As New DefaultTest()

            Try
                Using scope As New esTransactionScope()
                    ' Create test record
                    entity = New DefaultTest()
                    entity.Save()

                    ' Get the ID of the newly saved object
                    id = entity.TestId.Value

                    ' Check default value was set on insert
                    entity = New DefaultTest()
                    Assert.IsTrue(entity.LoadByPrimaryKey(id))
                    Assert.AreEqual(0, entity.DefaultNotNullInt.Value)
                    Assert.AreEqual(False, entity.DefaultNotNullBool.Value)
                End Using
            Finally
                ' Clean up
                entity = New DefaultTest()
                If entity.LoadByPrimaryKey(id) Then
                    entity.MarkAsDeleted()
                    entity.Save()
                End If
            End Try
        End Sub

        <Test()> _
        Public Sub DefaultIsDirtyCollection()
            Dim id As Integer = -1
            Dim entity As New DefaultTest()

            Try
                Using scope As New esTransactionScope()
                    ' Create test record
                    entity = New DefaultTest()
                    entity.DefaultNotNullBool = True
                    entity.DefaultNotNullInt = -1
                    entity.Save()

                    ' Get the ID of the newly saved object
                    id = entity.TestId.Value

                    Dim coll As New DefaultTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.AreEqual(True, coll(0).DefaultNotNullBool.Value)
                    Assert.AreEqual(-1, coll(0).DefaultNotNullInt.Value)
                    Assert.IsFalse(coll(0).es.IsDirty, "Load Dirty")
                    Assert.AreEqual(0, coll(0).es.ModifiedColumns.Count, "Load Count")

                    coll(0).DefaultNotNullBool = False
                    Assert.AreEqual(1, coll(0).es.ModifiedColumns.Count, "Bool Count")
                    Assert.IsTrue(coll(0).es.IsDirty, "Bool Dirty")

                    coll = New DefaultTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.AreEqual(True, coll(0).DefaultNotNullBool.Value)
                    Assert.AreEqual(-1, coll(0).DefaultNotNullInt.Value)

                    coll(0).DefaultNotNullInt = 0
                    Assert.AreEqual(1, coll(0).es.ModifiedColumns.Count, "Int Count")

                    Assert.IsTrue(coll(0).es.IsDirty, "Int Dirty")
                End Using
            Finally
                ' Clean up
                entity = New DefaultTest()
                If entity.LoadByPrimaryKey(id) Then
                    entity.MarkAsDeleted()
                    entity.Save()
                End If
            End Try
        End Sub

        <Test()> _
        Public Sub DefaultInConstructorIsDirtyCollection()
            Dim id As Long = -1
            Dim entity As New ConstructorTest()

            Try
                Using scope As New esTransactionScope()
                    ' Create test record
                    entity = New ConstructorTest()
                    entity.DefaultBool = True
                    entity.DefaultInt = -1
                    entity.DefaultDateTime = Convert.ToDateTime("2000-01-01")
                    entity.DefaultString = "Not new"
                    entity.Save()

                    ' Get the ID of the newly saved object
                    id = entity.ConstructorTestId.Value

                    ' bool
                    Dim coll As New ConstructorTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.AreEqual(True, coll(0).DefaultBool.Value)
                    Assert.AreEqual(-1, coll(0).DefaultInt.Value)
                    Assert.AreEqual(Convert.ToDateTime("2000-01-01"), coll(0).DefaultDateTime.Value)
                    Assert.AreEqual("Not new", coll(0).DefaultString)
                    Assert.IsFalse(coll(0).es.IsDirty, "Load Dirty")
                    Assert.AreEqual(0, coll(0).es.ModifiedColumns.Count, "Load Count")

                    coll(0).DefaultBool = False
                    Assert.AreEqual(1, coll(0).es.ModifiedColumns.Count, "Bool Count")
                    Assert.IsTrue(coll(0).es.IsDirty, "Bool Dirty")
                    coll.Save()

                    ' int
                    coll = New ConstructorTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.AreEqual(False, coll(0).DefaultBool.Value)
                    Assert.AreEqual(-1, coll(0).DefaultInt.Value)
                    Assert.AreEqual(Convert.ToDateTime("2000-01-01"), coll(0).DefaultDateTime.Value)
                    Assert.AreEqual("Not new", coll(0).DefaultString)

                    coll(0).DefaultInt = 0
                    Assert.AreEqual(1, coll(0).es.ModifiedColumns.Count, "Int Count")
                    Assert.IsTrue(coll(0).es.IsDirty, "Int Dirty")
                    coll.Save()

                    ' DateTime
                    coll = New ConstructorTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.AreEqual(False, coll(0).DefaultBool.Value)
                    Assert.AreEqual(0, coll(0).DefaultInt.Value)
                    Assert.AreEqual(Convert.ToDateTime("2000-01-01"), coll(0).DefaultDateTime.Value)
                    Assert.AreEqual("Not new", coll(0).DefaultString)

                    coll(0).DefaultDateTime = Convert.ToDateTime("1900-01-01")
                    Assert.AreEqual(1, coll(0).es.ModifiedColumns.Count, "DateTime Count")
                    Assert.IsTrue(coll(0).es.IsDirty, "DateTime Dirty")
                    coll.Save()

                    ' String
                    coll = New ConstructorTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.AreEqual(False, coll(0).DefaultBool.Value)
                    Assert.AreEqual(0, coll(0).DefaultInt.Value)
                    Assert.AreEqual(Convert.ToDateTime("1900-01-01"), coll(0).DefaultDateTime.Value)
                    Assert.AreEqual("Not new", coll(0).DefaultString)

                    coll(0).DefaultString = "Is newer"
                    Assert.AreEqual(1, coll(0).es.ModifiedColumns.Count, "String Count")
                    Assert.IsTrue(coll(0).es.IsDirty, "String Dirty")
                    coll.Save()

                    coll = New ConstructorTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.AreEqual(False, coll(0).DefaultBool.Value)
                    Assert.AreEqual(0, coll(0).DefaultInt.Value)
                    Assert.AreEqual(Convert.ToDateTime("1900-01-01"), coll(0).DefaultDateTime.Value)
                    Assert.AreEqual("Is newer", coll(0).DefaultString)

                    ' Constructor defaults
                    coll(0).MarkAsDeleted()
                    coll.AddNew()
                    coll.Save()

                    coll = New ConstructorTestCollection()
                    Assert.IsTrue(coll.LoadAll())
                    Assert.IsFalse(coll.IsDirty, "Coll Constructor Dirty")
                    Assert.IsFalse(coll(0).es.IsDirty, "Entity Constructor Dirty")
                    Assert.AreEqual(0, coll(0).es.ModifiedColumns.Count)
                    Assert.AreEqual(False, coll(0).DefaultBool.Value)
                    Assert.AreEqual(0, coll(0).DefaultInt.Value)
                    Assert.AreEqual(DateTime.Now.Year, coll(0).DefaultDateTime.Value.Year)
                    Assert.AreEqual("[new]", coll(0).DefaultString)
                End Using
            Finally
                ' Clean up
                entity = New ConstructorTest()
                If entity.LoadByPrimaryKey(id) Then
                    entity.MarkAsDeleted()
                    entity.Save()
                End If
            End Try
        End Sub

    End Class
End Namespace
