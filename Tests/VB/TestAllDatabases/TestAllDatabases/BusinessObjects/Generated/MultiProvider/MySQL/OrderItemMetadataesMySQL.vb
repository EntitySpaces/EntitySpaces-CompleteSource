'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:11 AM
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
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrderItemMetadata)
			
				If OrderItemMetadata.mapDelegates Is Nothing Then
					OrderItemMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrderItemMetadata._meta Is Nothing Then
                    OrderItemMetadata._meta = New OrderItemMetadata()
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
				meta.AddTypeMap("ProductID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("Quantity", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("Discount", new esTypeMap("DOUBLE", "System.Double"))				
				meta.Catalog = "foreignkeytest"
				
				
				meta.Source = "orderitem"
				meta.Destination = "orderitem"
				
				meta.spInsert = "proc_orderitemInsert"
				meta.spUpdate = "proc_orderitemUpdate"
				meta.spDelete = "proc_orderitemDelete"
				meta.spLoadAll = "proc_orderitemLoadAll"
				meta.spLoadByPrimaryKey = "proc_orderitemLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
