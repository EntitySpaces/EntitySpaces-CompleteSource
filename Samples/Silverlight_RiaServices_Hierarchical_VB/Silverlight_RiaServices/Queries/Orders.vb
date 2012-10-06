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

	<DataContract(Name:="OrdersQuery", Namespace:= "http://www.entityspaces.net")> _
	Partial Public Class OrdersQueryProxyStub 
		Inherits esDynamicQuerySerializable
	
		Public Sub New()
		
		End Sub
	
        Public Sub New(ByVal joinAlias As String)
            MyBase.es.JoinAlias = joinAlias
        End Sub	
		
        Protected Overrides Function GetQueryName() As String
			Return "OrdersQuery"
		End Function

		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal query As OrdersQueryProxyStub) As String
			Return esDynamicQuerySerializable.SerializeHelper.ToXml(query)
		End Operator

		#End Region		
        

		Public ReadOnly Property OrderID As esQueryItem
			Get
				Return new esQueryItem(Me, "OrderID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property CustomerID As esQueryItem
			Get
				Return new esQueryItem(Me, "CustomerID", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return new esQueryItem(Me, "EmployeeID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property OrderDate As esQueryItem
			Get
				Return new esQueryItem(Me, "OrderDate", esSystemType.DateTime)
			End Get			
		End Property 
		
		Public ReadOnly Property RequiredDate As esQueryItem
			Get
				Return new esQueryItem(Me, "RequiredDate", esSystemType.DateTime)
			End Get			
		End Property 
		
		Public ReadOnly Property ShippedDate As esQueryItem
			Get
				Return new esQueryItem(Me, "ShippedDate", esSystemType.DateTime)
			End Get			
		End Property 
		
		Public ReadOnly Property ShipVia As esQueryItem
			Get
				Return new esQueryItem(Me, "ShipVia", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property Freight As esQueryItem
			Get
				Return new esQueryItem(Me, "Freight", esSystemType.Decimal)
			End Get			
		End Property 
		
		Public ReadOnly Property ShipName As esQueryItem
			Get
				Return new esQueryItem(Me, "ShipName", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ShipAddress As esQueryItem
			Get
				Return new esQueryItem(Me, "ShipAddress", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ShipCity As esQueryItem
			Get
				Return new esQueryItem(Me, "ShipCity", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ShipRegion As esQueryItem
			Get
				Return new esQueryItem(Me, "ShipRegion", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ShipPostalCode As esQueryItem
			Get
				Return new esQueryItem(Me, "ShipPostalCode", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property ShipCountry As esQueryItem
			Get
				Return new esQueryItem(Me, "ShipCountry", esSystemType.String)
			End Get			
		End Property 
				
	
	End Class
	
End Namespace