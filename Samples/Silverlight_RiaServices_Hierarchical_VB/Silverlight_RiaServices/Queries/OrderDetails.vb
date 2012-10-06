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

	<DataContract(Name:="OrderDetailsQuery", Namespace:= "http://www.entityspaces.net")> _
	Partial Public Class OrderDetailsQueryProxyStub 
		Inherits esDynamicQuerySerializable
	
		Public Sub New()
		
		End Sub
	
        Public Sub New(ByVal joinAlias As String)
            MyBase.es.JoinAlias = joinAlias
        End Sub	
		
        Protected Overrides Function GetQueryName() As String
			Return "OrderDetailsQuery"
		End Function

		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal query As OrderDetailsQueryProxyStub) As String
			Return esDynamicQuerySerializable.SerializeHelper.ToXml(query)
		End Operator

		#End Region		
        

		Public ReadOnly Property OrderID As esQueryItem
			Get
				Return new esQueryItem(Me, "OrderID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property ProductID As esQueryItem
			Get
				Return new esQueryItem(Me, "ProductID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property UnitPrice As esQueryItem
			Get
				Return new esQueryItem(Me, "UnitPrice", esSystemType.Decimal)
			End Get			
		End Property 
		
		Public ReadOnly Property Quantity As esQueryItem
			Get
				Return new esQueryItem(Me, "Quantity", esSystemType.Int16)
			End Get			
		End Property 
		
		Public ReadOnly Property Discount As esQueryItem
			Get
				Return new esQueryItem(Me, "Discount", esSystemType.Single)
			End Get			
		End Property 
				
	
	End Class
	
End Namespace