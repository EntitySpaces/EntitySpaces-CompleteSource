'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:51:58 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class OrderMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrderMetadata)
			
				If OrderMetadata.mapDelegates Is Nothing Then
					OrderMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrderMetadata._meta Is Nothing Then
                    OrderMetadata._meta = New OrderMetadata()
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
			

				meta.AddTypeMap("OrderID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("CustID", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("CustSub", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("PlacedBy", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("OrderDate", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("EmployeeID", new esTypeMap("Long", "System.Int32"))				
				meta.Catalog = "ForeignKeyTest.mdb"
				
				
				meta.Source = "Order"
				meta.Destination = "Order"
				
				meta.spInsert = "proc_OrderInsert"
				meta.spUpdate = "proc_OrderUpdate"
				meta.spDelete = "proc_OrderDelete"
				meta.spLoadAll = "proc_OrderLoadAll"
				meta.spLoadByPrimaryKey = "proc_OrderLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
