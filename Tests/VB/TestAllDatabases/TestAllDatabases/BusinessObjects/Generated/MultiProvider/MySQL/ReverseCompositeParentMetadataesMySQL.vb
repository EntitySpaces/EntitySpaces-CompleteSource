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

	Partial Public Class ReverseCompositeParentMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(ReverseCompositeParentMetadata)
			
				If ReverseCompositeParentMetadata.mapDelegates Is Nothing Then
					ReverseCompositeParentMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If ReverseCompositeParentMetadata._meta Is Nothing Then
                    ReverseCompositeParentMetadata._meta = New ReverseCompositeParentMetadata()
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
			

				meta.AddTypeMap("KeySub", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("KeyId", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("Description", new esTypeMap("VARCHAR", "System.String"))				
				meta.Catalog = "foreignkeytest"
				
				
				meta.Source = "reversecompositeparent"
				meta.Destination = "reversecompositeparent"
				
				meta.spInsert = "proc_reversecompositeparentInsert"
				meta.spUpdate = "proc_reversecompositeparentUpdate"
				meta.spDelete = "proc_reversecompositeparentDelete"
				meta.spLoadAll = "proc_reversecompositeparentLoadAll"
				meta.spLoadByPrimaryKey = "proc_reversecompositeparentLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
