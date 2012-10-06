'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.Data

Imports NUnit.Framework
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports BusinessObjects

Namespace Tests.Base
	<TestFixture> _
	Public Class SetOperatorFixture
		<Test> _
		Public Sub SimpleUnion()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Dim eq1 As New EmployeeQuery("eq1")
			Dim eq2 As New EmployeeQuery("eq2")

			' This leaves out the record with Age 30
			eq1.Where(eq1.Age < 30)
			eq1.Union(eq2)
			eq2.Where(eq2.Age > 30)

			Assert.IsTrue(collection.Load(eq1))
			Assert.AreEqual(4, collection.Count)
		End Sub

		<Test> _
		Public Sub SimpleIntersect()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Dim eq1 As New EmployeeQuery("eq1")
			Dim eq2 As New EmployeeQuery("eq2")

			' Only includes rows with both "n" and"a"
			eq1.Where(eq1.FirstName.[Like]("%n%"))
			eq1.Intersect(eq2)
			eq2.Where(eq2.FirstName.[Like]("%a%"))

			Assert.IsTrue(collection.Load(eq1))
			Assert.AreEqual(2, collection.Count)
		End Sub

		<Test> _
		Public Sub SimpleExcept()
			Dim collection As New EmployeeCollection()
			collection.es.Connection.Name = "ForeignKeyTest"

			Dim eq1 As New EmployeeQuery("eq1")
			Dim eq2 As New EmployeeQuery("eq2")

			' Includes all "J"s except "Jim"
			eq1.Where(eq1.FirstName.[Like]("%J%"))
			eq1.Except(eq2)
			eq2.Where(eq2.FirstName = "Jim")

			Assert.IsTrue(collection.Load(eq1))
			Assert.AreEqual(3, collection.Count)
		End Sub

		<Test> _
		Public Sub SingleUnion()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.SelectAllExcept(cq1.Notes)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.SelectAllExcept(cq2.Notes)
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")))

			' Combine 2005 and 2006 in one result set
			cq1.Union(cq2)

			'string lq = cq1.Parse();

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(49, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleUnionWithOrderBy()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.[Select](cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.[Select](cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName)
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")))

			' Combine 2005 and 2006 in one result set
			cq1.Union(cq2)
			cq1.OrderBy(cq1.CustomerName.Ascending)

			'string lq = cq1.Parse();

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(49, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleUnionWithJoin()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			Dim eq1 As New EmployeeQuery("e1")

			cq1.[Select](cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName, eq1.LastName)
			cq1.InnerJoin(eq1).[On](cq1.Manager = eq1.EmployeeID)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			Dim eq2 As New EmployeeQuery("e2")

			cq2.[Select](cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName, eq2.LastName)
			cq2.InnerJoin(eq2).[On](cq2.Manager = eq2.EmployeeID)
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")))

			cq1.Union(cq2)
			cq1.OrderBy(cq1.CustomerID.Ascending, cq1.CustomerSub.Ascending)

			'string lq = cq1.Parse();

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(49, coll.Count)
			Assert.AreEqual("Smith", coll(0).GetColumn("LastName"))
		End Sub

		<Test> _
		Public Sub SingleUnionWithSubSelect()
			Dim coll As New OrderCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Select Case coll.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.SqlServerCeProvider", "EntitySpaces.SqlServerCe4Provider"
					Assert.Ignore("Scalar SubSelects are not supported in SqlCe.")
					Exit Select
				Case Else

					Dim oq1 As New OrderQuery("o1")
					Dim oiq1 As New OrderItemQuery("oi1")

					oq1.[Select](oq1.OrderID, oq1.OrderDate, oiq1.[Select](oiq1.UnitPrice.Max()).Where(oq1.OrderID = oiq1.OrderID).[As]("MaxUnitPrice"))
					oq1.Where(oq1.OrderDate.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

					Dim oq2 As New OrderQuery("o2")
					Dim oiq2 As New OrderItemQuery("oi2")

					oq2.[Select](oq2.OrderID, oq2.OrderDate, oiq2.[Select](oiq2.UnitPrice.Max()).Where(oq2.OrderID = oiq2.OrderID).[As]("MaxUnitPrice"))
					oq2.Where(oq2.OrderDate.Between(Convert.ToDateTime("2004-01-01"), Convert.ToDateTime("2004-12-31")))

					oq1.Union(oq2)
					oq1.OrderBy(oq1.OrderID.Ascending)

					'string lq = cq1.Parse();

					Assert.IsTrue(coll.Load(oq1))
					Assert.AreEqual(6, coll.Count)
					Assert.AreEqual(3D, coll(0).GetColumn("MaxUnitPrice"))
					Exit Select
			End Select
		End Sub

		<Test> _
		Public Sub MultipleUnion()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.SelectAllExcept(cq1.Notes)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.SelectAllExcept(cq2.Notes)
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")))

			Dim cq3 As New CustomerQuery("c3")
			cq3.SelectAllExcept(cq3.Notes)
			cq3.Where(cq3.DateAdded.Between(Convert.ToDateTime("2000-01-01"), Convert.ToDateTime("2000-12-31")))

			' Combine 2000, 2005, and 2006
			cq1.Union(cq2)
			cq1.Union(cq3)

			'string lq = cq1.Parse();

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(51, coll.Count)

		End Sub

		<Test> _
		Public Sub SingleUnionAll()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")))

			' Combine 2005 and 2006 in one result set
			cq1.UnionAll(cq2)

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(49, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleUnionWithOverlap()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.SelectAllExcept(cq1.Notes)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.SelectAllExcept(cq2.Notes)
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-12-31"), Convert.ToDateTime("2006-12-31")))

			' Combine 2005 and 2006 in one result set with the 2 duplicate rows eliminated
			cq1.Union(cq2)

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(49, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleUnionAllWithOverlap()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-12-31"), Convert.ToDateTime("2006-12-31")))

			' Combine 2005 and 2006 in one result set with the 2 duplicate rows retained
			cq1.UnionAll(cq2)

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(51, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleExcept()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.SelectAllExcept(cq1.Notes)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2006-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.SelectAllExcept(cq2.Notes)
			cq2.Where(cq2.DateAdded = Convert.ToDateTime("2005-12-31"))

			' All 2005 and 2006 except the 2 for 2005-12-31
			cq1.Except(cq2)

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(47, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleExceptWithNoOverlap()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.SelectAllExcept(cq1.Notes)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2006-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.SelectAllExcept(cq2.Notes)
			cq2.Where(cq2.DateAdded = Convert.ToDateTime("1900-12-31"))

			' All 2005 and 2006
			cq1.Except(cq2)

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(49, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleIntersect()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.SelectAllExcept(cq1.Notes)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.SelectAllExcept(cq2.Notes)
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-12-31"), Convert.ToDateTime("2006-12-31")))

			' Only the 2 rows for 2005-12-31
			cq1.Intersect(cq2)

			Assert.IsTrue(coll.Load(cq1))
			Assert.AreEqual(2, coll.Count)
		End Sub

		<Test> _
		Public Sub SingleIntersectWithNoOverlap()
			Dim coll As New CustomerCollection()
			coll.es.Connection.Name = "ForeignKeyTest"

			Dim cq1 As New CustomerQuery("c1")
			cq1.SelectAllExcept(cq1.Notes)
			cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

			Dim cq2 As New CustomerQuery("c2")
			cq2.SelectAllExcept(cq2.Notes)
			cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2006-01-01"), Convert.ToDateTime("2006-12-31")))

			' There is no intersection for 2005 and 2006
			cq1.Intersect(cq2)

			Assert.IsFalse(coll.Load(cq1))
			Assert.AreEqual(0, coll.Count)
		End Sub

        '<Test> _
        'Public Sub MixedSetOperatorsUnionAllWithParen()
        '	Dim coll As New CustomerCollection()
        '	coll.es.Connection.Name = "ForeignKeyTest"

        '	Dim cq1 As New CustomerQuery("c1")
        '	cq1.[Select](cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName)
        '	cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

        '	Dim cq2 As New CustomerQuery("c2")
        '	cq2.[Select](cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName)
        '	cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

        '	Dim cq3 As New CustomerQuery("c3")
        '	cq3.[Select](cq3.CustomerID, cq3.CustomerSub, cq3.CustomerName)
        '	cq3.Where(cq3.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-01-01")))

        '	' Combine with duplicates, then eliminate the duplicates and the 2 for 2005-01-01
        '	cq1.Where(New esComparison(esParenthesis.Open))
        '	cq1.UnionAll(cq2)
        '	cq1.Where(New esComparison(esParenthesis.Close))
        '	cq1.Except(cq3)

        '	'string lq = cq1.Parse();

        '	Assert.IsTrue(coll.Load(cq1))
        '	Assert.AreEqual(2, coll.Count)

        'End Sub

        '<Test> _
        'Public Sub MixedSetOperatorsExceptWithParen()
        '	Dim coll As New CustomerCollection()
        '	coll.es.Connection.Name = "ForeignKeyTest"

        '	Dim cq1 As New CustomerQuery("c1")
        '	cq1.[Select](cq1.CustomerID, cq1.CustomerSub, cq1.CustomerName)
        '	cq1.Where(cq1.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

        '	Dim cq2 As New CustomerQuery("c2")
        '	cq2.[Select](cq2.CustomerID, cq2.CustomerSub, cq2.CustomerName)
        '	cq2.Where(cq2.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-12-31")))

        '	Dim cq3 As New CustomerQuery("c3")
        '	cq3.[Select](cq3.CustomerID, cq3.CustomerSub, cq3.CustomerName)
        '	cq3.Where(cq3.DateAdded.Between(Convert.ToDateTime("2005-01-01"), Convert.ToDateTime("2005-01-01")))

        '	' Eliminate the 1 for 2005-01-01, then combine with duplicates
        '	cq1.UnionAll(cq2)
        '	cq1.Where(New esComparison(esParenthesis.Open))
        '	cq1.Except(cq3)
        '	cq1.Where(New esComparison(esParenthesis.Close))

        '	'string lq = cq1.Parse();

        '	Assert.IsTrue(coll.Load(cq1))
        '	Assert.AreEqual(5, coll.Count)

        'End Sub

	End Class
End Namespace
