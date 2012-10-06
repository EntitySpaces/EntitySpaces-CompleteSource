'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:51:55 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class ConcurrencyTestChildMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ConcurrencyTestChildMetadata)
			
				If ConcurrencyTestChildMetadata.mapDelegates Is Nothing Then
					ConcurrencyTestChildMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ConcurrencyTestChildMetadata._meta Is Nothing Then
                    ConcurrencyTestChildMetadata._meta = New ConcurrencyTestChildMetadata()
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
			

				meta.AddTypeMap("Id", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("Name", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Parent", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("DefaultTest", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("ColumnA", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("ColumnB", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("ComputedAB", new esTypeMap("Long", "System.Int32"))				
				meta.Catalog = "AggregateDb.mdb"
				
				
				meta.Source = "ConcurrencyTestChild"
				meta.Destination = "ConcurrencyTestChild"
				
				meta.spInsert = "proc_ConcurrencyTestChildInsert"
				meta.spUpdate = "proc_ConcurrencyTestChildUpdate"
				meta.spDelete = "proc_ConcurrencyTestChildDelete"
				meta.spLoadAll = "proc_ConcurrencyTestChildLoadAll"
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestChildLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
