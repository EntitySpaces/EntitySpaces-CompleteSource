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

	Partial Public Class ProductMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ProductMetadata)
			
				If ProductMetadata.mapDelegates Is Nothing Then
					ProductMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ProductMetadata._meta Is Nothing Then
                    ProductMetadata._meta = New ProductMetadata()
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
				meta.AddTypeMap("UnitPrice", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("Discontinued", new esTypeMap("TINYINT", "System.SByte"))				
				meta.Catalog = "foreignkeytest"
				
				
				meta.Source = "product"
				meta.Destination = "product"
				
				meta.spInsert = "proc_productInsert"
				meta.spUpdate = "proc_productUpdate"
				meta.spDelete = "proc_productDelete"
				meta.spLoadAll = "proc_productLoadAll"
				meta.spLoadByPrimaryKey = "proc_productLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
