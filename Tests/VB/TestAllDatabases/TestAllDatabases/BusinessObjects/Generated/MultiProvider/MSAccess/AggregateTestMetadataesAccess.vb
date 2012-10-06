'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:51:54 AM
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
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(AggregateTestMetadata)
			
				If AggregateTestMetadata.mapDelegates Is Nothing Then
					AggregateTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If AggregateTestMetadata._meta Is Nothing Then
                    AggregateTestMetadata._meta = New AggregateTestMetadata()
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
				meta.AddTypeMap("DepartmentID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("FirstName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("LastName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Age", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("HireDate", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("Salary", new esTypeMap("Decimal", "System.Decimal"))
				meta.AddTypeMap("IsActive", new esTypeMap("Yes/No", "System.Boolean"))				
				meta.Catalog = "AggregateDb.mdb"
				
				
				meta.Source = "AggregateTest"
				meta.Destination = "AggregateTest"
				
				meta.spInsert = "proc_AggregateTestInsert"
				meta.spUpdate = "proc_AggregateTestUpdate"
				meta.spDelete = "proc_AggregateTestDelete"
				meta.spLoadAll = "proc_AggregateTestLoadAll"
				meta.spLoadByPrimaryKey = "proc_AggregateTestLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
