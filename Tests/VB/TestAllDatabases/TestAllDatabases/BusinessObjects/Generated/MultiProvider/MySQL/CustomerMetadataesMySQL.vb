'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:10 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class CustomerMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(CustomerMetadata)
			
				If CustomerMetadata.mapDelegates Is Nothing Then
					CustomerMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If CustomerMetadata._meta Is Nothing Then
                    CustomerMetadata._meta = New CustomerMetadata()
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
			

				meta.AddTypeMap("CustomerID", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("CustomerSub", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("CustomerName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("DateAdded", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("Active", new esTypeMap("TINYINT UNSIGNED", "System.Byte"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("Manager", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("StaffAssigned", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("UniqueID", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Notes", new esTypeMap("LONGTEXT", "System.String"))
				meta.AddTypeMap("CreditLimit", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("Discount", new esTypeMap("DOUBLE", "System.Double"))				
				meta.Catalog = "foreignkeytest"
				
				
				meta.Source = "customer"
				meta.Destination = "customer"
				
				meta.spInsert = "proc_customerInsert"
				meta.spUpdate = "proc_customerUpdate"
				meta.spDelete = "proc_customerDelete"
				meta.spLoadAll = "proc_customerLoadAll"
				meta.spLoadByPrimaryKey = "proc_customerLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
