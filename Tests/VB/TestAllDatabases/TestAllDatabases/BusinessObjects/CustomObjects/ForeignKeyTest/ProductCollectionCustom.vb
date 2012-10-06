'
'===============================================================================
'                     EntitySpaces(TM) by EntitySpaces, LLC
'                 A New 2.0 Architecture for the .NET Framework
'                          http://www.entityspaces.net
'===============================================================================
'                       EntitySpaces Version # 1.4.2.0
'                       MyGeneration Version # 1.1.5.1
'                           8/9/2006 6:42:11 PM
'-------------------------------------------------------------------------------
'



Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects
	Public Partial Class ProductCollection
		Inherits esProductCollection
		Public Function GetActiveProductIds(employeeId As Integer) As Boolean
			Dim prd As New ProductQuery("pq")
			'prd.es.Connection.Name = "ForeignKeyTest";
			Dim item As New OrderItemQuery("oiq")
			'item.es.Connection.Name = "ForeignKeyTest";
			Dim ord As New OrderQuery("oq")
			'ord.es.Connection.Name = "ForeignKeyTest";
			Dim cust As New CustomerQuery("cq")
			'cust.es.Connection.Name = "ForeignKeyTest";
			Dim emp As New EmployeeQuery("eq")
			'emp.es.Connection.Name = "ForeignKeyTest";

			prd.[Select](prd.ProductID)
			prd.InnerJoin(item).[On](prd.ProductID = item.ProductID)
			prd.InnerJoin(ord).[On](item.OrderID = ord.OrderID)
			prd.InnerJoin(cust).[On](ord.CustID = cust.CustomerID And ord.CustSub = cust.CustomerSub)
			prd.InnerJoin(emp).[On](cust.Manager = emp.EmployeeID)
			prd.Where(emp.EmployeeID = employeeId)
			prd.Where(prd.Discontinued = False)
			prd.es.Distinct = True

			Return Me.Load(prd)
		End Function
	End Class
End Namespace
