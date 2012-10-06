'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:06 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class ProductsMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ProductsMetadata)
			
				If ProductsMetadata.mapDelegates Is Nothing Then
					ProductsMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ProductsMetadata._meta Is Nothing Then
                    ProductsMetadata._meta = New ProductsMetadata()
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
				meta.AddTypeMap("SupplierID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("CategoryID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("Currency", "System.Decimal"))
				meta.AddTypeMap("UnitsInStock", new esTypeMap("Integer", "System.Int16"))
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("Integer", "System.Int16"))
				meta.AddTypeMap("ReorderLevel", new esTypeMap("Integer", "System.Int16"))
				meta.AddTypeMap("Discontinued", new esTypeMap("Yes/No", "System.Boolean"))				
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Products"
				meta.Destination = "Products"
				
				meta.spInsert = "proc_ProductsInsert"
				meta.spUpdate = "proc_ProductsUpdate"
				meta.spDelete = "proc_ProductsDelete"
				meta.spLoadAll = "proc_ProductsLoadAll"
				meta.spLoadByPrimaryKey = "proc_ProductsLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
