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

	<DataContract(Name:="CustomersQuery", Namespace:= "http://www.entityspaces.net")> _
	Partial Public Class CustomersQueryProxyStub 
		Inherits esDynamicQuerySerializable
	
		Public Sub New()
		
		End Sub
	
        Public Sub New(ByVal joinAlias As String)
            MyBase.es.JoinAlias = joinAlias
        End Sub	
		
        Protected Overrides Function GetQueryName() As String
			Return "CustomersQuery"
		End Function

		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal query As CustomersQueryProxyStub) As String
			Return esDynamicQuerySerializable.SerializeHelper.ToXml(query)
		End Operator

		#End Region		
        

		Public ReadOnly Property CustomerID As esQueryItem
			Get
				Return new esQueryItem(Me, "CustomerID", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property CompanyName As esQueryItem
			Get
				Return new esQueryItem(Me, "CompanyName", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ContactName As esQueryItem
			Get
				Return new esQueryItem(Me, "ContactName", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ContactTitle As esQueryItem
			Get
				Return new esQueryItem(Me, "ContactTitle", esSystemType.String)
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
		
		Public ReadOnly Property Phone As esQueryItem
			Get
				Return new esQueryItem(Me, "Phone", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property Fax As esQueryItem
			Get
				Return new esQueryItem(Me, "Fax", esSystemType.String)
			End Get			
		End Property 
				
	
	End Class
	
End Namespace