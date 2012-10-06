'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:11 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class TerritoryExMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(TerritoryExMetadata)
			
				If TerritoryExMetadata.mapDelegates Is Nothing Then
					TerritoryExMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If TerritoryExMetadata._meta Is Nothing Then
                    TerritoryExMetadata._meta = New TerritoryExMetadata()
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
			

				meta.AddTypeMap("TerritoryID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("Notes", new esTypeMap("VARCHAR", "System.String"))				
				meta.Catalog = "foreignkeytest"
				
				
				meta.Source = "territoryex"
				meta.Destination = "territoryex"
				
				meta.spInsert = "proc_territoryexInsert"
				meta.spUpdate = "proc_territoryexUpdate"
				meta.spDelete = "proc_territoryexDelete"
				meta.spLoadAll = "proc_territoryexLoadAll"
				meta.spLoadByPrimaryKey = "proc_territoryexLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
