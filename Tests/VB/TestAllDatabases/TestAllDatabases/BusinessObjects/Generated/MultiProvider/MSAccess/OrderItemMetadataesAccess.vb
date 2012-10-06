'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:51:59 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class OrderItemMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrderItemMetadata)
			
				If OrderItemMetadata.mapDelegates Is Nothing Then
					OrderItemMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrderItemMetadata._meta Is Nothing Then
                    OrderItemMetadata._meta = New OrderItemMetadata()
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
				meta.AddTypeMap("ProductID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("Currency", "System.Decimal"))
				meta.AddTypeMap("Quantity", new esTypeMap("Integer", "System.Int16"))
				meta.AddTypeMap("Discount", new esTypeMap("Single", "System.Single"))				
				meta.Catalog = "ForeignKeyTest.mdb"
				
				
				meta.Source = "OrderItem"
				meta.Destination = "OrderItem"
				
				meta.spInsert = "proc_OrderItemInsert"
				meta.spUpdate = "proc_OrderItemUpdate"
				meta.spDelete = "proc_OrderItemDelete"
				meta.spLoadAll = "proc_OrderItemLoadAll"
				meta.spLoadByPrimaryKey = "proc_OrderItemLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
