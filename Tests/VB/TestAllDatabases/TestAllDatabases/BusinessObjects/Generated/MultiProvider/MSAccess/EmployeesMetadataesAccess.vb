'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : Access
' Date Generated       : 3/17/2012 4:52:03 AM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core

Namespace BusinessObjects

	Partial Public Class EmployeesMetadata 
		Inherits esMetadata
		Implements IMetadata
		
        Private Shared Function RegisterDelegateesAccess() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(EmployeesMetadata)
			
				If EmployeesMetadata.mapDelegates Is Nothing Then
					EmployeesMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If EmployeesMetadata._meta Is Nothing Then
                    EmployeesMetadata._meta = New EmployeesMetadata()
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
			

				meta.AddTypeMap("EmployeeID", new esTypeMap("Long", "System.Int32"))
				meta.AddTypeMap("LastName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("FirstName", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Title", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("TitleOfCourtesy", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("BirthDate", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("HireDate", new esTypeMap("DateTime", "System.DateTime"))
				meta.AddTypeMap("Address", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("City", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Region", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("PostalCode", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Country", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("HomePhone", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Extension", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Photo", new esTypeMap("Text", "System.String"))
				meta.AddTypeMap("Notes", new esTypeMap("Memo", "System.String"))
				meta.AddTypeMap("ReportsTo", new esTypeMap("Long", "System.Int32"))				
				meta.Catalog = "Northwind.mdb"
				
				
				meta.Source = "Employees"
				meta.Destination = "Employees"
				
				meta.spInsert = "proc_EmployeesInsert"
				meta.spUpdate = "proc_EmployeesUpdate"
				meta.spDelete = "proc_EmployeesDelete"
				meta.spLoadAll = "proc_EmployeesLoadAll"
				meta.spLoadByPrimaryKey = "proc_EmployeesLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esAccess", meta)

            End If

            Return m_providerMetadataMaps("esAccess")

        End Function
		
		Private Shared _esAccess As Integer = RegisterDelegateesAccess()	
		
	End Class
	
End Namespace	
