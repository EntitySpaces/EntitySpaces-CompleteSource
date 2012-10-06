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

	<DataContract(Namespace:="http://tempuri.org/", Name:="ProductsCollection")> _
	<XmlType(TypeName:="ProductsCollectionProxyStub")> _	
	Partial Public Class ProductsCollectionProxyStub 

		Public Sub New() 
		
		End Sub
		
		<DataMember(Name:="Collection", EmitDefaultValue:=False)> _
		Public Collection As New ObservableCollection (Of ProductsProxyStub)
		
		Public Function IsDirty() As Boolean
			For Each obj As ProductsProxyStub In Collection
				If obj.IsDirty() Then
					Return True
				End If
			Next
			Return False
		End Function
	

	End Class
	
	<DataContract(Namespace:="http://tempuri.org/", Name:="Products")> _
	<XmlType(TypeName:="ProductsProxyStub")> _	
	Partial Public Class ProductsProxyStub
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
		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _
        Public Property ProductName As System.String
			Get
				Return _ProductName
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ProductName, value) = 0 Then
					_ProductName = value
					SetDirty("ProductName")
					RaisePropertyChanged("ProductName")
				End If
			End Set
		End Property
		Private _ProductName As System.String
		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _
        Public Property SupplierID As Nullable(Of System.Int32)
			Get
				Return _SupplierID
			End Get
			Set(ByVal value As Nullable(Of System.Int32))
				If Not _SupplierID.Equals(value) Then
					_SupplierID = value
					SetDirty("SupplierID")
					RaisePropertyChanged("SupplierID")
				End If
			End Set
		End Property
		Private _SupplierID As Nullable(Of System.Int32)
		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _
        Public Property CategoryID As Nullable(Of System.Int32)
			Get
				Return _CategoryID
			End Get
			Set(ByVal value As Nullable(Of System.Int32))
				If Not _CategoryID.Equals(value) Then
					_CategoryID = value
					SetDirty("CategoryID")
					RaisePropertyChanged("CategoryID")
				End If
			End Set
		End Property
		Private _CategoryID As Nullable(Of System.Int32)
		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _
        Public Property QuantityPerUnit As System.String
			Get
				Return _QuantityPerUnit
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_QuantityPerUnit, value) = 0 Then
					_QuantityPerUnit = value
					SetDirty("QuantityPerUnit")
					RaisePropertyChanged("QuantityPerUnit")
				End If
			End Set
		End Property
		Private _QuantityPerUnit As System.String
		<DataMember(Name:="a5", Order:=6, EmitDefaultValue:=False)> _
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
		<DataMember(Name:="a6", Order:=7, EmitDefaultValue:=False)> _
        Public Property UnitsInStock As Nullable(Of System.Int16)
			Get
				Return _UnitsInStock
			End Get
			Set(ByVal value As Nullable(Of System.Int16))
				If Not _UnitsInStock.Equals(value) Then
					_UnitsInStock = value
					SetDirty("UnitsInStock")
					RaisePropertyChanged("UnitsInStock")
				End If
			End Set
		End Property
		Private _UnitsInStock As Nullable(Of System.Int16)
		<DataMember(Name:="a7", Order:=8, EmitDefaultValue:=False)> _
        Public Property UnitsOnOrder As Nullable(Of System.Int16)
			Get
				Return _UnitsOnOrder
			End Get
			Set(ByVal value As Nullable(Of System.Int16))
				If Not _UnitsOnOrder.Equals(value) Then
					_UnitsOnOrder = value
					SetDirty("UnitsOnOrder")
					RaisePropertyChanged("UnitsOnOrder")
				End If
			End Set
		End Property
		Private _UnitsOnOrder As Nullable(Of System.Int16)
		<DataMember(Name:="a8", Order:=9, EmitDefaultValue:=False)> _
        Public Property ReorderLevel As Nullable(Of System.Int16)
			Get
				Return _ReorderLevel
			End Get
			Set(ByVal value As Nullable(Of System.Int16))
				If Not _ReorderLevel.Equals(value) Then
					_ReorderLevel = value
					SetDirty("ReorderLevel")
					RaisePropertyChanged("ReorderLevel")
				End If
			End Set
		End Property
		Private _ReorderLevel As Nullable(Of System.Int16)
		<DataMember(Name:="a9", Order:=10, EmitDefaultValue:=False)> _
        Public Property Discontinued As Nullable(Of System.Boolean)
			Get
				Return _Discontinued
			End Get
			Set(ByVal value As Nullable(Of System.Boolean))
				If Not _Discontinued.Equals(value) Then
					_Discontinued = value
					SetDirty("Discontinued")
					RaisePropertyChanged("Discontinued")
				End If
			End Set
		End Property
		Private _Discontinued As Nullable(Of System.Boolean)
		
		

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
	
	<XmlType(TypeName:="ProductsQueryProxyStub")> _	
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
			Return ProductsQueryProxyStub.SerializeHelper.ToXml(query)
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
