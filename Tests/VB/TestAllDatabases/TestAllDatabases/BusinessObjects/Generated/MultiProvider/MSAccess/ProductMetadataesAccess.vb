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

	Partial Public Class ProductMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ProductMetadata)
			
				If ProductMetadata.mapDelegates Is Nothing Then
					ProductMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ProductMetadata._meta Is Nothing Then
                    ProductMetadata._meta = New ProductMetadata()
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
			

				meta.AddTypeMap("ProductID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("ProductName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("Currency", "System.Decimal"))
				meta.AddTypeMap("Discontinued", new esTypeMap("Yes/No", "System.Boolean"))				
				meta.Catalog = "ForeignKeyTest.mdb"
				
				
				meta.Source = "Product"
				meta.Destination = "Product"
				
				meta.spInsert = "proc_ProductInsert"
				meta.spUpdate = "proc_ProductUpdate"
				meta.spDelete = "proc_ProductDelete"
				meta.spLoadAll = "proc_ProductLoadAll"
				meta.spLoadByPrimaryKey = "proc_ProductLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
