'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:25 PM
'===============================================================================

Imports System
Imports System.Runtime.Serialization

Imports EntitySpaces.DynamicQuery

Namespace BusinessObjects

	<DataContract(Name:="EmployeesQuery", Namespace:= "http://www.entityspaces.net")> _
	Partial Public Class EmployeesQueryProxyStub 
		Inherits esDynamicQuerySerializable
	
		Public Sub New()
		
		End Sub
	
        Public Sub New(ByVal joinAlias As String)
            MyBase.es.JoinAlias = joinAlias
        End Sub	
		
        Protected Overrides Function GetQueryName() As String
			Return "EmployeesQuery"
		End Function

		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal query As EmployeesQueryProxyStub) As String
			Return esDynamicQuerySerializable.SerializeHelper.ToXml(query)
		End Operator

		#End Region		
        

		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return new esQueryItem(Me, "EmployeeID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property LastName As esQueryItem
			Get
				Return new esQueryItem(Me, "LastName", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property FirstName As esQueryItem
			Get
				Return new esQueryItem(Me, "FirstName", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property Title As esQueryItem
			Get
				Return new esQueryItem(Me, "Title", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property TitleOfCourtesy As esQueryItem
			Get
				Return new esQueryItem(Me, "TitleOfCourtesy", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property BirthDate As esQueryItem
			Get
				Return new esQueryItem(Me, "BirthDate", esSystemType.DateTime)
			End Get			
		End Property 
		
		Public ReadOnly Property HireDate As esQueryItem
			Get
				Return new esQueryItem(Me, "HireDate", esSystemType.DateTime)
			End Get			
		End Property 
		
		Public ReadOnly Property Address As esQueryItem
			Get
				Return new esQueryItem(Me, "Address", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property City As esQueryItem
			Get
				Return new esQueryItem(Me, "City", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property Region As esQueryItem
			Get
				Return new esQueryItem(Me, "Region", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property PostalCode As esQueryItem
			Get
				Return new esQueryItem(Me, "PostalCode", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property Country As esQueryItem
			Get
				Return new esQueryItem(Me, "Country", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property HomePhone As esQueryItem
			Get
				Return new esQueryItem(Me, "HomePhone", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property Extension As esQueryItem
			Get
				Return new esQueryItem(Me, "Extension", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property Photo As esQueryItem
			Get
				Return new esQueryItem(Me, "Photo", esSystemType.ByteArray)
			End Get			
		End Property 
		
		Public ReadOnly Property Notes As esQueryItem
			Get
				Return new esQueryItem(Me, "Notes", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ReportsTo As esQueryItem
			Get
				Return new esQueryItem(Me, "ReportsTo", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property PhotoPath As esQueryItem
			Get
				Return new esQueryItem(Me, "PhotoPath", esSystemType.String)
			End Get			
		End Property 
				
	
	End Class
	
End Namespace