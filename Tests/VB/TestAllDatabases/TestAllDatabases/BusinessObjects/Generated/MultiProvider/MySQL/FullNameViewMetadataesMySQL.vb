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

	Partial Public Class FullNameViewMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(FullNameViewMetadata)
			
				If FullNameViewMetadata.mapDelegates Is Nothing Then
					FullNameViewMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If FullNameViewMetadata._meta Is Nothing Then
                    FullNameViewMetadata._meta = New FullNameViewMetadata()
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
			

				meta.AddTypeMap("FullName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("DepartmentID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("HireDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("Salary", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("IsActive", new esTypeMap("TINYINT UNSIGNED", "System.Byte"))				
				meta.Catalog = "aggregatedb"
				
				
				meta.Source = "fullnameview"
				meta.Destination = "fullnameview"
				
				meta.spInsert = "proc_fullnameviewInsert"
				meta.spUpdate = "proc_fullnameviewUpdate"
				meta.spDelete = "proc_fullnameviewDelete"
				meta.spLoadAll = "proc_fullnameviewLoadAll"
				meta.spLoadByPrimaryKey = "proc_fullnameviewLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
