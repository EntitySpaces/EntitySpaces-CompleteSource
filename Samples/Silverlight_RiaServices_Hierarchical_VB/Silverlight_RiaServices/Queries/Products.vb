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

	<DataContract(Name:="ProductsQuery", Namespace:= "http://www.entityspaces.net")> _
	Partial Public Class ProductsQueryProxyStub 
		Inherits esDynamicQuerySerializable
	
		Public Sub New()
		
		End Sub
	
        Public Sub New(ByVal joinAlias As String)
            MyBase.es.JoinAlias = joinAlias
        End Sub	
		
        Protected Overrides Function GetQueryName() As String
			Return "ProductsQuery"
		End Function

		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal query As ProductsQueryProxyStub) As String
			Return esDynamicQuerySerializable.SerializeHelper.ToXml(query)
		End Operator

		#End Region		
        

		Public ReadOnly Property ProductID As esQueryItem
			Get
				Return new esQueryItem(Me, "ProductID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property ProductName As esQueryItem
			Get
				Return new esQueryItem(Me, "ProductName", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property SupplierID As esQueryItem
			Get
				Return new esQueryItem(Me, "SupplierID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property CategoryID As esQueryItem
			Get
				Return new esQueryItem(Me, "CategoryID", esSystemType.Int32)
			End Get			
		End Property 
		
		Public ReadOnly Property QuantityPerUnit As esQueryItem
			Get
				Return new esQueryItem(Me, "QuantityPerUnit", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property UnitPrice As esQueryItem
			Get
				Return new esQueryItem(Me, "UnitPrice", esSystemType.Decimal)
			End Get			
		End Property 
		
		Public ReadOnly Property UnitsInStock As esQueryItem
			Get
				Return new esQueryItem(Me, "UnitsInStock", esSystemType.Int16)
			End Get			
		End Property 
		
		Public ReadOnly Property UnitsOnOrder As esQueryItem
			Get
				Return new esQueryItem(Me, "UnitsOnOrder", esSystemType.Int16)
			End Get			
		End Property 
		
		Public ReadOnly Property ReorderLevel As esQueryItem
			Get
				Return new esQueryItem(Me, "ReorderLevel", esSystemType.Int16)
			End Get			
		End Property 
		
		Public ReadOnly Property Discontinued As esQueryItem
			Get
				Return new esQueryItem(Me, "Discontinued", esSystemType.Boolean)
			End Get			
		End Property 
				
	
	End Class
	
End Namespace