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

	Partial Public Class SuppliersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(SuppliersMetadata)
			
				If SuppliersMetadata.mapDelegates Is Nothing Then
					SuppliersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If SuppliersMetadata._meta Is Nothing Then
                    SuppliersMetadata._meta = New SuppliersMetadata()
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
			

				meta.AddTypeMap("SupplierID", new esTypeMap("INT", "System.Int32"))
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
				meta.AddTypeMap("HomePage", new esTypeMap("LONGTEXT", "System.String"))				
				meta.Catalog = "northwind"
				
				
				meta.Source = "suppliers"
				meta.Destination = "suppliers"
				
				meta.spInsert = "proc_suppliersInsert"
				meta.spUpdate = "proc_suppliersUpdate"
				meta.spDelete = "proc_suppliersDelete"
				meta.spLoadAll = "proc_suppliersLoadAll"
				meta.spLoadByPrimaryKey = "proc_suppliersLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
