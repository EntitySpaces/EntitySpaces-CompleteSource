'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:12 AM
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
		
        Private Shared Function RegisterDelegateesMySQL() As Integer
		
            ' This is only executed once per the life of the application
            SyncLock GetType(EmployeesMetadata)
			
				If EmployeesMetadata.mapDelegates Is Nothing Then
					EmployeesMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

                If EmployeesMetadata._meta Is Nothing Then
                    EmployeesMetadata._meta = New EmployeesMetadata()
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
			

				meta.AddTypeMap("EmployeeID", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("LastName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("FirstName", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Title", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("TitleOfCourtesy", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("BirthDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("HireDate", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("Address", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("City", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Region", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("PostalCode", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Country", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("HomePhone", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Extension", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Photo", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("Notes", new esTypeMap("LONGTEXT", "System.String"))
				meta.AddTypeMap("ReportsTo", new esTypeMap("INT", "System.Int32"))				
				meta.Catalog = "northwind"
				
				
				meta.Source = "employees"
				meta.Destination = "employees"
				
				meta.spInsert = "proc_employeesInsert"
				meta.spUpdate = "proc_employeesUpdate"
				meta.spDelete = "proc_employeesDelete"
				meta.spLoadAll = "proc_employeesLoadAll"
				meta.spLoadByPrimaryKey = "proc_employeesLoadByPrimaryKey"
				
                m_providerMetadataMaps.Add("esMySQL", meta)

            End If

            Return m_providerMetadataMaps("esMySQL")

        End Function
		
		Private Shared _esMySQL As Integer = RegisterDelegateesMySQL()	
		
	End Class
	
End Namespace	
