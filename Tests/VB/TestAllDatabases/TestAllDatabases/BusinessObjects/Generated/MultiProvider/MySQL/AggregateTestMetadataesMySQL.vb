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

	Partial Public Class AggregateTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(AggregateTestMetadata)
			
				If AggregateTestMetadata.mapDelegates Is Nothing Then
					AggregateTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If AggregateTestMetadata._meta Is Nothing Then
                    AggregateTestMetadata._meta = New AggregateTestMetadata()
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
			

				meta.AddTypeMap("Id", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("DepartmentID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("FirstName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("LastName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Age", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("HireDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("Salary", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("IsActive", new esTypeMap("TINYINT UNSIGNED", "System.Byte"))				
				meta.Catalog = "aggregatedb"
				
				
				meta.Source = "aggregatetest"
				meta.Destination = "aggregatetest"
				
				meta.spInsert = "proc_aggregatetestInsert"
				meta.spUpdate = "proc_aggregatetestUpdate"
				meta.spDelete = "proc_aggregatetestDelete"
				meta.spLoadAll = "proc_aggregatetestLoadAll"
				meta.spLoadByPrimaryKey = "proc_aggregatetestLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
