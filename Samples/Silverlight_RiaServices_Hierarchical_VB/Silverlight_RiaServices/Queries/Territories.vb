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

	<DataContract(Name:="TerritoriesQuery", Namespace:= "http://www.entityspaces.net")> _
	Partial Public Class TerritoriesQueryProxyStub 
		Inherits esDynamicQuerySerializable
	
		Public Sub New()
		
		End Sub
	
        Public Sub New(ByVal joinAlias As String)
            MyBase.es.JoinAlias = joinAlias
        End Sub	
		
        Protected Overrides Function GetQueryName() As String
			Return "TerritoriesQuery"
		End Function

		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal query As TerritoriesQueryProxyStub) As String
			Return esDynamicQuerySerializable.SerializeHelper.ToXml(query)
		End Operator

		#End Region		
        

		Public ReadOnly Property TerritoryID As esQueryItem
			Get
				Return new esQueryItem(Me, "TerritoryID", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property TerritoryDescription As esQueryItem
			Get
				Return new esQueryItem(Me, "TerritoryDescription", esSystemType.String)
			End Get			
		End Property 
		
		Public ReadOnly Property RegionID As esQueryItem
			Get
				Return new esQueryItem(Me, "RegionID", esSystemType.Int32)
			End Get			
		End Property 
				
	
	End Class
	
End Namespace