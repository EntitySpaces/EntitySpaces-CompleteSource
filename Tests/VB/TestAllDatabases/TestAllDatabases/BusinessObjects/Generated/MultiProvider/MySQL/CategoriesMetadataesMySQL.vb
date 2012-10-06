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

	Partial Public Class CategoriesMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(CategoriesMetadata)
			
				If CategoriesMetadata.mapDelegates Is Nothing Then
					CategoriesMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If CategoriesMetadata._meta Is Nothing Then
                    CategoriesMetadata._meta = New CategoriesMetadata()
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
			

				meta.AddTypeMap("CategoryID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("CategoryName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Description", new esTypeMap("LONGTEXT", "System.String"))
				meta.AddTypeMap("Picture", new esTypeMap("LONGBLOB", "System.Byte()"))				
				meta.Catalog = "northwind"
				
				
				meta.Source = "categories"
				meta.Destination = "categories"
				
				meta.spInsert = "proc_categoriesInsert"
				meta.spUpdate = "proc_categoriesUpdate"
				meta.spDelete = "proc_categoriesDelete"
				meta.spLoadAll = "proc_categoriesLoadAll"
				meta.spLoadByPrimaryKey = "proc_categoriesLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
