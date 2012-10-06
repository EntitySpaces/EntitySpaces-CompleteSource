'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:09 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class ConcurrencyTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ConcurrencyTestMetadata)
			
				If ConcurrencyTestMetadata.mapDelegates Is Nothing Then
					ConcurrencyTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ConcurrencyTestMetadata._meta Is Nothing Then
                    ConcurrencyTestMetadata._meta = New ConcurrencyTestMetadata()
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
			

				meta.AddTypeMap("Id", new esTypeMap("CHAR", "System.String"))
				meta.AddTypeMap("Name", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("BIGINT", "System.Int64"))				
				meta.Catalog = "aggregatedb"
				
				
				meta.Source = "concurrencytest"
				meta.Destination = "concurrencytest"
				
				meta.spInsert = "proc_concurrencytestInsert"
				meta.spUpdate = "proc_concurrencytestUpdate"
				meta.spDelete = "proc_concurrencytestDelete"
				meta.spLoadAll = "proc_concurrencytestLoadAll"
				meta.spLoadByPrimaryKey = "proc_concurrencytestLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
