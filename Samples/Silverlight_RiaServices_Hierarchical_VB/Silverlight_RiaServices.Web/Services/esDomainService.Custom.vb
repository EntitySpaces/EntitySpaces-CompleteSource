'===============================================================================
'                   EntitySpaces 2010 by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2010.1.1011.0
' EntitySpaces Driver  : SQL
' Date Generated       : 10/9/2010 5:04:23 PM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery

Imports Silverlight_RiaServices.BusinessObjects

Namespace esDomainServices

    ' Add Custom Methods here, this file will not be ovewrriten
    Partial Public Class esDomainService

        ''' <summary>
        ''' Give you a chance to handle any error during PersistChangeSet()
        ''' </summary>
        ''' <param name="ex">The Exception</param>
        ''' <returns>True if handle, otherwise the Exception is rethrown and bubbled up</returns>
        Private Function HandleError(ByVal ex As Exception) As Boolean
            Return False
        End Function

        <Query()> _
        Public Function Employees_Prefetch() As EmployeesCollection

            ' Very simplistic prefetch ..
            Dim coll As New EmployeesCollection()
            coll.Query.Prefetch(Employees.Prefetch_OrdersCollectionByEmployeeID)
            coll.Query.Prefetch(Employees.Prefetch_OrdersCollectionByEmployeeID, Orders.Prefetch_OrderDetailsCollectionByOrderID)
            coll.Query.Load()

            Return coll

        End Function

        <Query()> _
        Public Function Employees_PrefetchSophisticated() As EmployeesCollection

            ' EmployeeID = "1"
            Dim coll As New EmployeesCollection()
            coll.Query.Where(coll.Query.EmployeeID = 1)

            ' Orders Query (nothing fancy, just ensure we're only getting Orders for EmployeeID = 1
            Dim o As OrdersQuery = coll.Query.Prefetch(Of OrdersQuery)(Employees.Prefetch_OrdersCollectionByEmployeeID)
            Dim e1 As EmployeesQuery = o.GetQuery(Of EmployeesQuery)()
            o.Where(e1.EmployeeID = 1)

            ' OrderDetailsQuery (here we even limit the Select in addition to  EmployeeID = 1) notice the "false"
            Dim od As OrderDetailsQuery = coll.Query.Prefetch(Of OrderDetailsQuery)(False, Employees.Prefetch_OrdersCollectionByEmployeeID, Orders.Prefetch_OrderDetailsCollectionByOrderID)
            Dim e2 As EmployeesQuery = od.GetQuery(Of EmployeesQuery)()
            od.Where(e2.EmployeeID = 1)
            od.[Select](od.OrderID, od.ProductID, od.UnitPrice)

            coll.Query.Load()
            Return coll

        End Function

        <Query()> _
        Public Function Products_LoadWithExtraColumn() As ProductsCollection

            Dim p As New ProductsQuery("p")
            Dim s As New SuppliersQuery("s")

            ' Bring back the suppliers name for the Product from the Supplier table
            p.[Select](p, s.CompanyName.[As]("SupplierName"))
            p.InnerJoin(s).[On](p.SupplierID = s.SupplierID)

            Dim coll As New ProductsCollection()
            coll.Load(p)

            Return coll

        End Function

    End Class

End Namespace
