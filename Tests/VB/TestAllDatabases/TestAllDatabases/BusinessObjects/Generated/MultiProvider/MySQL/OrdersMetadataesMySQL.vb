'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:12 AM
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
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrdersMetadata)
			
				If OrdersMetadata.mapDelegates Is Nothing Then
					OrdersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrdersMetadata._meta Is Nothing Then
                    OrdersMetadata._meta = New OrdersMetadata()
                End If

                Dim mapMethod As New MapToMeta(AddressOf _meta.esMySQL)
                mapDelegates.Add("esMySQL", mapMethod)
                mapMethod("esMySQL")
                Return 0

            End SyncLock			
		
        End Function

        Private Function esMySQL(ByVal mapName As String) As esProviderSpecificMetadata

            If (Not m_providerMetadataMaps.ContainsKey(mapName)) Then		

				Dim meta As esProviderSpecificMetadata = new esProviderSpecificMetadata()
			

				meta.AddTypeMap("OrderID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("CustomerID", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("OrderDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("RequiredDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("ShippedDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("ShipVia", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("Freight", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("ShipName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ShipAddress", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ShipCity", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ShipRegion", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ShipCountry", new esTypeMap("VARCHAR", "System.String"))				
				meta.Catalog = "northwind"
				
				
				meta.Source = "orders"
				meta.Destination = "orders"
				
				meta.spInsert = "proc_ordersInsert"
				meta.spUpdate = "proc_ordersUpdate"
				meta.spDelete = "proc_ordersDelete"
				meta.spLoadAll = "proc_ordersLoadAll"
				meta.spLoadByPrimaryKey = "proc_ordersLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
