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

	Partial Public Class ConcurrencyTestChildMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ConcurrencyTestChildMetadata)
			
				If ConcurrencyTestChildMetadata.mapDelegates Is Nothing Then
					ConcurrencyTestChildMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ConcurrencyTestChildMetadata._meta Is Nothing Then
                    ConcurrencyTestChildMetadata._meta = New ConcurrencyTestChildMetadata()
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
			

				meta.AddTypeMap("Id", new esTypeMap("BIGINT", "System.Int64"))
				meta.AddTypeMap("Name", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Parent", new esTypeMap("BIGINT", "System.Int64"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("BIGINT", "System.Int64"))
				meta.AddTypeMap("DefaultTest", new esTypeMap("TIMESTAMP", "System.DateTime"))
				meta.AddTypeMap("ColumnA", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("ColumnB", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("ComputedAB", new esTypeMap("SMALLINT", "System.Int16"))				
				meta.Catalog = "aggregatedb"
				
				
				meta.Source = "concurrencytestchild"
				meta.Destination = "concurrencytestchild"
				
				meta.spInsert = "proc_concurrencytestchildInsert"
				meta.spUpdate = "proc_concurrencytestchildUpdate"
				meta.spDelete = "proc_concurrencytestchildDelete"
				meta.spLoadAll = "proc_concurrencytestchildLoadAll"
				meta.spLoadByPrimaryKey = "proc_concurrencytestchildLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
