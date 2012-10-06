'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:07 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class ShippersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ShippersMetadata)
			
				If ShippersMetadata.mapDelegates Is Nothing Then
					ShippersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ShippersMetadata._meta Is Nothing Then
                    ShippersMetadata._meta = New ShippersMetadata()
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
			

				meta.AddTypeMap("ShipperID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("CompanyName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Phone", new esTypeMap("Text", "System.String"))				
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Shippers"
				meta.Destination = "Shippers"
				
				meta.spInsert = "proc_ShippersInsert"
				meta.spUpdate = "proc_ShippersUpdate"
				meta.spDelete = "proc_ShippersDelete"
				meta.spLoadAll = "proc_ShippersLoadAll"
				meta.spLoadByPrimaryKey = "proc_ShippersLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
