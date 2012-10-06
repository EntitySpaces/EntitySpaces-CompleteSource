'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:51:56 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class CustomerMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(CustomerMetadata)
			
				If CustomerMetadata.mapDelegates Is Nothing Then
					CustomerMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If CustomerMetadata._meta Is Nothing Then
                    CustomerMetadata._meta = New CustomerMetadata()
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
				meta.AddTypeMap("CustomerSub", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("CustomerName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("DateAdded", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("Active", new esTypeMap("Yes/No", "System.Boolean"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("Manager", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("StaffAssigned", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("UniqueID", new esTypeMap("Replication ID", "System.Guid"))
				meta.AddTypeMap("Notes", new esTypeMap("Memo", "System.String"))
				meta.AddTypeMap("CreditLimit", new esTypeMap("Currency", "System.Decimal"))
				meta.AddTypeMap("Discount", new esTypeMap("Double", "System.Double"))				
				meta.Catalog = "ForeignKeyTest.mdb"
				
				
				meta.Source = "Customer"
				meta.Destination = "Customer"
				
				meta.spInsert = "proc_CustomerInsert"
				meta.spUpdate = "proc_CustomerUpdate"
				meta.spDelete = "proc_CustomerDelete"
				meta.spLoadAll = "proc_CustomerLoadAll"
				meta.spLoadByPrimaryKey = "proc_CustomerLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
