'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:00 AM
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
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(CategoriesMetadata)
			
				If CategoriesMetadata.mapDelegates Is Nothing Then
					CategoriesMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If CategoriesMetadata._meta Is Nothing Then
                    CategoriesMetadata._meta = New CategoriesMetadata()
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
			

				meta.AddTypeMap("CategoryID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("CategoryName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Description", new esTypeMap("Memo", "System.String"))
				meta.AddTypeMap("Picture", new esTypeMap("OLE Object", "System.Byte()"))				
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Categories"
				meta.Destination = "Categories"
				
				meta.spInsert = "proc_CategoriesInsert"
				meta.spUpdate = "proc_CategoriesUpdate"
				meta.spDelete = "proc_CategoriesDelete"
				meta.spLoadAll = "proc_CategoriesLoadAll"
				meta.spLoadByPrimaryKey = "proc_CategoriesLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
