'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:24 PM
'===============================================================================

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Imports EntitySpaces.DynamicQuery

Namespace Proxies

	<DataContract(Namespace:="http://tempuri.org/", Name:="OrdersCollection")> _
	<XmlType(TypeName:="OrdersCollectionProxyStub")> _	
	Partial Public Class OrdersCollectionProxyStub 

		Public Sub New() 
		
		End Sub
		
		<DataMember(Name:="Collection", EmitDefaultValue:=False)> _
		Public Collection As New ObservableCollection (Of OrdersProxyStub)
		
		Public Function IsDirty() As Boolean
			For Each obj As OrdersProxyStub In Collection
				If obj.IsDirty() Then
					Return True
				End If
			Next
			Return False
		End Function
	

	End Class
	
	<DataContract(Namespace:="http://tempuri.org/", Name:="Orders")> _
	<XmlType(TypeName:="OrdersProxyStub")> _	
	Partial Public Class OrdersProxyStub
		Implements System.ComponentModel.INotifyPropertyChanged
		
		Public Sub New()
			Me.esRowState = "Added"
		End Sub
		
		Public Function IsDirty() As Boolean
			Return If(esRowState <> "Unchanged", True, False)
		End Function
		
		Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
		
		Protected Sub RaisePropertyChanged(ByVal propertyName As String)
			Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
			If (Not (propertyChanged) Is Nothing) Then
				propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
			End If
		End Sub
		
		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _
        Public Property OrderID As Nullable(Of System.Int32)
			Get
				Return _OrderID
			End Get
			Set(ByVal value As Nullable(Of System.Int32))
				If Not _OrderID.Equals(value) Then
					_OrderID = value
					SetDirty("OrderID")
					RaisePropertyChanged("OrderID")
				End If
			End Set
		End Property
		Private _OrderID As Nullable(Of System.Int32)
		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _
        Public Property CustomerID As System.String
			Get
				Return _CustomerID
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_CustomerID, value) = 0 Then
					_CustomerID = value
					SetDirty("CustomerID")
					RaisePropertyChanged("CustomerID")
				End If
			End Set
		End Property
		Private _CustomerID As System.String
		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _
        Public Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return _EmployeeID
			End Get
			Set(ByVal value As Nullable(Of System.Int32))
				If Not _EmployeeID.Equals(value) Then
					_EmployeeID = value
					SetDirty("EmployeeID")
					RaisePropertyChanged("EmployeeID")
				End If
			End Set
		End Property
		Private _EmployeeID As Nullable(Of System.Int32)
		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _
        Public Property OrderDate As Nullable(Of System.DateTime)
			Get
				Return _OrderDate
			End Get
			Set(ByVal value As Nullable(Of System.DateTime))
				If Not _OrderDate.Equals(value) Then
					_OrderDate = value
					SetDirty("OrderDate")
					RaisePropertyChanged("OrderDate")
				End If
			End Set
		End Property
		Private _OrderDate As Nullable(Of System.DateTime)
		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _
        Public Property RequiredDate As Nullable(Of System.DateTime)
			Get
				Return _RequiredDate
			End Get
			Set(ByVal value As Nullable(Of System.DateTime))
				If Not _RequiredDate.Equals(value) Then
					_RequiredDate = value
					SetDirty("RequiredDate")
					RaisePropertyChanged("RequiredDate")
				End If
			End Set
		End Property
		Private _RequiredDate As Nullable(Of System.DateTime)
		<DataMember(Name:="a5", Order:=6, EmitDefaultValue:=False)> _
        Public Property ShippedDate As Nullable(Of System.DateTime)
			Get
				Return _ShippedDate
			End Get
			Set(ByVal value As Nullable(Of System.DateTime))
				If Not _ShippedDate.Equals(value) Then
					_ShippedDate = value
					SetDirty("ShippedDate")
					RaisePropertyChanged("ShippedDate")
				End If
			End Set
		End Property
		Private _ShippedDate As Nullable(Of System.DateTime)
		<DataMember(Name:="a6", Order:=7, EmitDefaultValue:=False)> _
        Public Property ShipVia As Nullable(Of System.Int32)
			Get
				Return _ShipVia
			End Get
			Set(ByVal value As Nullable(Of System.Int32))
				If Not _ShipVia.Equals(value) Then
					_ShipVia = value
					SetDirty("ShipVia")
					RaisePropertyChanged("ShipVia")
				End If
			End Set
		End Property
		Private _ShipVia As Nullable(Of System.Int32)
		<DataMember(Name:="a7", Order:=8, EmitDefaultValue:=False)> _
        Public Property Freight As Nullable(Of System.Decimal)
			Get
				Return _Freight
			End Get
			Set(ByVal value As Nullable(Of System.Decimal))
				If Not _Freight.Equals(value) Then
					_Freight = value
					SetDirty("Freight")
					RaisePropertyChanged("Freight")
				End If
			End Set
		End Property
		Private _Freight As Nullable(Of System.Decimal)
		<DataMember(Name:="a8", Order:=9, EmitDefaultValue:=False)> _
        Public Property ShipName As System.String
			Get
				Return _ShipName
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ShipName, value) = 0 Then
					_ShipName = value
					SetDirty("ShipName")
					RaisePropertyChanged("ShipName")
				End If
			End Set
		End Property
		Private _ShipName As System.String
		<DataMember(Name:="a9", Order:=10, EmitDefaultValue:=False)> _
        Public Property ShipAddress As System.String
			Get
				Return _ShipAddress
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ShipAddress, value) = 0 Then
					_ShipAddress = value
					SetDirty("ShipAddress")
					RaisePropertyChanged("ShipAddress")
				End If
			End Set
		End Property
		Private _ShipAddress As System.String
		<DataMember(Name:="a10", Order:=11, EmitDefaultValue:=False)> _
        Public Property ShipCity As System.String
			Get
				Return _ShipCity
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ShipCity, value) = 0 Then
					_ShipCity = value
					SetDirty("ShipCity")
					RaisePropertyChanged("ShipCity")
				End If
			End Set
		End Property
		Private _ShipCity As System.String
		<DataMember(Name:="a11", Order:=12, EmitDefaultValue:=False)> _
        Public Property ShipRegion As System.String
			Get
				Return _ShipRegion
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ShipRegion, value) = 0 Then
					_ShipRegion = value
					SetDirty("ShipRegion")
					RaisePropertyChanged("ShipRegion")
				End If
			End Set
		End Property
		Private _ShipRegion As System.String
		<DataMember(Name:="a12", Order:=13, EmitDefaultValue:=False)> _
        Public Property ShipPostalCode As System.String
			Get
				Return _ShipPostalCode
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ShipPostalCode, value) = 0 Then
					_ShipPostalCode = value
					SetDirty("ShipPostalCode")
					RaisePropertyChanged("ShipPostalCode")
				End If
			End Set
		End Property
		Private _ShipPostalCode As System.String
		<DataMember(Name:="a13", Order:=14, EmitDefaultValue:=False)> _
        Public Property ShipCountry As System.String
			Get
				Return _ShipCountry
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ShipCountry, value) = 0 Then
					_ShipCountry = value
					SetDirty("ShipCountry")
					RaisePropertyChanged("ShipCountry")
				End If
			End Set
		End Property
		Private _ShipCountry As System.String
		
		

		<DataMember(Name:="a10000", Order:=10000)> _
		Public Property esRowState As String
			Get
				Return Me._esRowState
			End Get
			Set
				If Not String.Compare(_esRowState, value) = 0 Then
					Me._esRowState = value
					RaisePropertyChanged("esRowState")
				End If
			End Set
		End Property
		Private _esRowState As String = "Unchanged"
		
		<DataMember(Name := "a10001", Order := 10001, EmitDefaultValue := False)> _		
		Public Property ModifiedColumns() As List(Of String)
			Get
				If _ModifiedColumns Is Nothing Then
					_ModifiedColumns = New List(Of String)()
				End If
				Return _ModifiedColumns
			End Get
			Set(ByVal value As List(Of String))
				_ModifiedColumns = New List(Of String)(value)
			End Set
		End Property
		Private _ModifiedColumns As List(Of String)

		<DataMember(Name := "a10002", Order := 10002, EmitDefaultValue := False)> _
		Public Property esExtraColumns() As Dictionary(Of String, Object)
			Get
				If _ExtraColumns Is Nothing Then
					_ExtraColumns = New Dictionary(Of String, Object)()
				End If
				Return _ExtraColumns
			End Get
			Set(ByVal value As Dictionary(Of String, Object))
				_ExtraColumns = New Dictionary(Of String, Object)(value)
			End Set
		End Property
		Private _ExtraColumns As Dictionary(Of String, Object)

		Public Sub MarkAsDeleted()
			Me.esRowState = "Deleted"
		End Sub

		Private Sub SetDirty(ByVal [property] As String)
			If Not ModifiedColumns.Contains([property]) Then
				ModifiedColumns.Add([property])
			End If
			
			If Me.esRowState = "Unchanged" Then
				Me.esRowState = "Modified"
			End If
		End Sub
		
	End Class
	
	<XmlType(TypeName:="OrdersQueryProxyStub")> _	
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
			Return OrdersQueryProxyStub.SerializeHelper.ToXml(query)
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
