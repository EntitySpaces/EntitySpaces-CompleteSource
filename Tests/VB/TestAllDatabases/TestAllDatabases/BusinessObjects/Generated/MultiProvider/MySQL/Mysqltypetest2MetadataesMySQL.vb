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

	Partial Public Class Mysqltypetest2Metadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(Mysqltypetest2Metadata)
			
				If Mysqltypetest2Metadata.mapDelegates Is Nothing Then
					Mysqltypetest2Metadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If Mysqltypetest2Metadata._meta Is Nothing Then
                    Mysqltypetest2Metadata._meta = New Mysqltypetest2Metadata()
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
			

				meta.AddTypeMap("Id", new esTypeMap("INT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("CharType", new esTypeMap("CHAR", "System.String"))
				meta.AddTypeMap("TimeStampType", new esTypeMap("TIMESTAMP", "System.DateTime"))
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"))
				meta.AddTypeMap("DateTimeType", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("BlobType", new esTypeMap("BLOB", "System.Byte()"))
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"))
				meta.AddTypeMap("TimeType", new esTypeMap("TIME", "System.TimeSpan"))
				meta.AddTypeMap("LongTextType", new esTypeMap("LONGTEXT", "System.String"))
				meta.AddTypeMap("BinaryType", new esTypeMap("BINARY", "System.String"))
				meta.AddTypeMap("VarBinaryType", new esTypeMap("VARBINARY", "System.String"))				
				meta.Catalog = "aggregatedb"
				
				
				meta.Source = "mysqltypetest2"
				meta.Destination = "mysqltypetest2"
				
				meta.spInsert = "proc_mysqltypetest2Insert"
				meta.spUpdate = "proc_mysqltypetest2Update"
				meta.spDelete = "proc_mysqltypetest2Delete"
				meta.spLoadAll = "proc_mysqltypetest2LoadAll"
				meta.spLoadByPrimaryKey = "proc_mysqltypetest2LoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
