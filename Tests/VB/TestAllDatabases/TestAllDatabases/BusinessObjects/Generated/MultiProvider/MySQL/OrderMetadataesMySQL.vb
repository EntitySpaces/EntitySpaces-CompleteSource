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

	Partial Public Class OrderMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(OrderMetadata)
			
				If OrderMetadata.mapDelegates Is Nothing Then
					OrderMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If OrderMetadata._meta Is Nothing Then
                    OrderMetadata._meta = New OrderMetadata()
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
			

				meta.AddTypeMap("OrderID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("CustID", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("CustSub", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("PlacedBy", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("OrderDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"))				
				meta.Catalog = "foreignkeytest"
				
				
				meta.Source = "order"
				meta.Destination = "order"
				
				meta.spInsert = "proc_orderInsert"
				meta.spUpdate = "proc_orderUpdate"
				meta.spDelete = "proc_orderDelete"
				meta.spLoadAll = "proc_orderLoadAll"
				meta.spLoadByPrimaryKey = "proc_orderLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
