'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:05 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class OrdersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrdersMetadata)
			
				If OrdersMetadata.mapDelegates Is Nothing Then
					OrdersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrdersMetadata._meta Is Nothing Then
                    OrdersMetadata._meta = New OrdersMetadata()
                End If

                Dim mapMethod As New MapToMeta(AddressOf _meta.esAccess)
                mapDelegates.Add("esAccess", mapMethod)
                mapMethod("esAccess")
                Return 0

            End SyncLock			
		
        End Function

        Private Function esAccess(ByVal mapName As String) As esProviderSpecificMetadata

            If (Not m_providerMetadataMaps.ContainsKey(mapName)) Then		

				Dim meta As esProviderSpecificMetadata = new esProviderSpecificMetadata()
			

				meta.AddTypeMap("OrderID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("CustomerID", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("EmployeeID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("OrderDate", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("RequiredDate", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("ShippedDate", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("ShipVia", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("Freight", new esTypeMap("Currency", "System.Decimal"))
				meta.AddTypeMap("ShipName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("ShipAddress", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("ShipCity", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("ShipRegion", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("ShipCountry", new esTypeMap("Text", "System.String"))				
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Orders"
				meta.Destination = "Orders"
				
				meta.spInsert = "proc_OrdersInsert"
				meta.spUpdate = "proc_OrdersUpdate"
				meta.spDelete = "proc_OrdersDelete"
				meta.spLoadAll = "proc_OrdersLoadAll"
				meta.spLoadByPrimaryKey = "proc_OrdersLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
