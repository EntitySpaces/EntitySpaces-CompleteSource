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

	Partial Public Class CustomersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(CustomersMetadata)
			
				If CustomersMetadata.mapDelegates Is Nothing Then
					CustomersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If CustomersMetadata._meta Is Nothing Then
                    CustomersMetadata._meta = New CustomersMetadata()
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
			

				meta.AddTypeMap("CustomerID", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("CompanyName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ContactName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ContactTitle", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Address", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("City", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Region", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("PostalCode", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Country", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Phone", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Fax", new esTypeMap("VARCHAR", "System.String"))				
				meta.Catalog = "northwind"
				
				
				meta.Source = "customers"
				meta.Destination = "customers"
				
				meta.spInsert = "proc_customersInsert"
				meta.spUpdate = "proc_customersUpdate"
				meta.spDelete = "proc_customersDelete"
				meta.spLoadAll = "proc_customersLoadAll"
				meta.spLoadByPrimaryKey = "proc_customersLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
