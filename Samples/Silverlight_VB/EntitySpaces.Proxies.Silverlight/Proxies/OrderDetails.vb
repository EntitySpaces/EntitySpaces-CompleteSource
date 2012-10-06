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

	<DataContract(Namespace:="http://tempuri.org/", Name:="OrderDetailsCollection")> _
	<XmlType(TypeName:="OrderDetailsCollectionProxyStub")> _	
	Partial Public Class OrderDetailsCollectionProxyStub 

		Public Sub New() 
		
		End Sub
		
		<DataMember(Name:="Collection", EmitDefaultValue:=False)> _
		Public Collection As New ObservableCollection (Of OrderDetailsProxyStub)
		
		Public Function IsDirty() As Boolean
			For Each obj As OrderDetailsProxyStub In Collection
				If obj.IsDirty() Then
					Return True
				End If
			Next
			Return False
		End Function
	

	End Class
	
	<DataContract(Namespace:="http://tempuri.org/", Name:="OrderDetails")> _
	<XmlType(TypeName:="OrderDetailsProxyStub")> _	
	Partial Public Class OrderDetailsProxyStub
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
        Public Property ProductID As Nullable(Of System.Int32)
			Get
				Return _ProductID
			End Get
			Set(ByVal value As Nullable(Of System.Int32))
				If Not _ProductID.Equals(value) Then
					_ProductID = value
					SetDirty("ProductID")
					RaisePropertyChanged("ProductID")
				End If
			End Set
		End Property
		Private _ProductID As Nullable(Of System.Int32)
		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _
        Public Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return _UnitPrice
			End Get
			Set(ByVal value As Nullable(Of System.Decimal))
				If Not _UnitPrice.Equals(value) Then
					_UnitPrice = value
					SetDirty("UnitPrice")
					RaisePropertyChanged("UnitPrice")
				End If
			End Set
		End Property
		Private _UnitPrice As Nullable(Of System.Decimal)
		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _
        Public Property Quantity As Nullable(Of System.Int16)
			Get
				Return _Quantity
			End Get
			Set(ByVal value As Nullable(Of System.Int16))
				If Not _Quantity.Equals(value) Then
					_Quantity = value
					SetDirty("Quantity")
					RaisePropertyChanged("Quantity")
				End If
			End Set
		End Property
		Private _Quantity As Nullable(Of System.Int16)
		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _
        Public Property Discount As Nullable(Of System.Single)
			Get
				Return _Discount
			End Get
			Set(ByVal value As Nullable(Of System.Single))
				If Not _Discount.Equals(value) Then
					_Discount = value
					SetDirty("Discount")
					RaisePropertyChanged("Discount")
				End If
			End Set
		End Property
		Private _Discount As Nullable(Of System.Single)
		
		

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
	
	<XmlType(TypeName:="OrderDetailsQueryProxyStub")> _	
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
			Return OrderDetailsQueryProxyStub.SerializeHelper.ToXml(query)
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
