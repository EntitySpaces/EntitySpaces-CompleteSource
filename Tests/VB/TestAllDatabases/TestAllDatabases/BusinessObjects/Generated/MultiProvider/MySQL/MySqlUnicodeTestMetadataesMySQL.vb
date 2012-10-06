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

	Partial Public Class MySqlUnicodeTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(MySqlUnicodeTestMetadata)
			
				If MySqlUnicodeTestMetadata.mapDelegates Is Nothing Then
					MySqlUnicodeTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If MySqlUnicodeTestMetadata._meta Is Nothing Then
                    MySqlUnicodeTestMetadata._meta = New MySqlUnicodeTestMetadata()
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
			

				meta.AddTypeMap("TypeID", new esTypeMap("INT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"))				
				meta.Catalog = "aggregatedb"
				
				
				meta.Source = "mysqlunicodetest"
				meta.Destination = "mysqlunicodetest"
				
				meta.spInsert = "proc_mysqlunicodetestInsert"
				meta.spUpdate = "proc_mysqlunicodetestUpdate"
				meta.spDelete = "proc_mysqlunicodetestDelete"
				meta.spLoadAll = "proc_mysqlunicodetestLoadAll"
				meta.spLoadByPrimaryKey = "proc_mysqlunicodetestLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
