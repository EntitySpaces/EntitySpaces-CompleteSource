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

	Partial Public Class OrderDetailsMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrderDetailsMetadata)
			
				If OrderDetailsMetadata.mapDelegates Is Nothing Then
					OrderDetailsMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrderDetailsMetadata._meta Is Nothing Then
                    OrderDetailsMetadata._meta = New OrderDetailsMetadata()
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
				meta.Catalog = "northwind"
				
				
				meta.Source = "order details"
				meta.Destination = "order details"
				
				meta.spInsert = "proc_order detailsInsert"
				meta.spUpdate = "proc_order detailsUpdate"
				meta.spDelete = "proc_order detailsDelete"
				meta.spLoadAll = "proc_order detailsLoadAll"
				meta.spLoadByPrimaryKey = "proc_order detailsLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
