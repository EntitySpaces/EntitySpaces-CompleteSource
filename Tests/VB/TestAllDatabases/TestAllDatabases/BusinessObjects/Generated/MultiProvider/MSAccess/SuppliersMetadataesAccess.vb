'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:08 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class SuppliersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(SuppliersMetadata)
			
				If SuppliersMetadata.mapDelegates Is Nothing Then
					SuppliersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If SuppliersMetadata._meta Is Nothing Then
                    SuppliersMetadata._meta = New SuppliersMetadata()
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
			

				meta.AddTypeMap("SupplierID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("CompanyName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("ContactName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("ContactTitle", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Address", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("City", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Region", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("PostalCode", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Country", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Phone", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Fax", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("HomePage", new esTypeMap("Hyperlink", "System.String"))				
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Suppliers"
				meta.Destination = "Suppliers"
				
				meta.spInsert = "proc_SuppliersInsert"
				meta.spUpdate = "proc_SuppliersUpdate"
				meta.spDelete = "proc_SuppliersDelete"
				meta.spLoadAll = "proc_SuppliersLoadAll"
				meta.spLoadByPrimaryKey = "proc_SuppliersLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
