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

	Partial Public Class ProductsMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ProductsMetadata)
			
				If ProductsMetadata.mapDelegates Is Nothing Then
					ProductsMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ProductsMetadata._meta Is Nothing Then
                    ProductsMetadata._meta = New ProductsMetadata()
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
			

				meta.AddTypeMap("ProductID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("ProductName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("SupplierID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("CategoryID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("UnitsInStock", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("ReorderLevel", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("Discontinued", new esTypeMap("TINYINT UNSIGNED", "System.Byte"))				
				meta.Catalog = "northwind"
				
				
				meta.Source = "products"
				meta.Destination = "products"
				
				meta.spInsert = "proc_productsInsert"
				meta.spUpdate = "proc_productsUpdate"
				meta.spDelete = "proc_productsDelete"
				meta.spLoadAll = "proc_productsLoadAll"
				meta.spLoadByPrimaryKey = "proc_productsLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
