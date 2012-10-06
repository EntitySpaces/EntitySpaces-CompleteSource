'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:02 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class CustomersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(CustomersMetadata)
			
				If CustomersMetadata.mapDelegates Is Nothing Then
					CustomersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If CustomersMetadata._meta Is Nothing Then
                    CustomersMetadata._meta = New CustomersMetadata()
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
			

				meta.AddTypeMap("CustomerID", new esTypeMap("Text", "System.String"))
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
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Customers"
				meta.Destination = "Customers"
				
				meta.spInsert = "proc_CustomersInsert"
				meta.spUpdate = "proc_CustomersUpdate"
				meta.spDelete = "proc_CustomersDelete"
				meta.spLoadAll = "proc_CustomersLoadAll"
				meta.spLoadByPrimaryKey = "proc_CustomersLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
