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

	<DataContract(Namespace:="http://tempuri.org/", Name:="CustomersCollection")> _
	<XmlType(TypeName:="CustomersCollectionProxyStub")> _	
	Partial Public Class CustomersCollectionProxyStub 

		Public Sub New() 
		
		End Sub
		
		<DataMember(Name:="Collection", EmitDefaultValue:=False)> _
		Public Collection As New ObservableCollection (Of CustomersProxyStub)
		
		Public Function IsDirty() As Boolean
			For Each obj As CustomersProxyStub In Collection
				If obj.IsDirty() Then
					Return True
				End If
			Next
			Return False
		End Function
	

	End Class
	
	<DataContract(Namespace:="http://tempuri.org/", Name:="Customers")> _
	<XmlType(TypeName:="CustomersProxyStub")> _	
	Partial Public Class CustomersProxyStub
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
		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _
        Public Property CompanyName As System.String
			Get
				Return _CompanyName
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_CompanyName, value) = 0 Then
					_CompanyName = value
					SetDirty("CompanyName")
					RaisePropertyChanged("CompanyName")
				End If
			End Set
		End Property
		Private _CompanyName As System.String
		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _
        Public Property ContactName As System.String
			Get
				Return _ContactName
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ContactName, value) = 0 Then
					_ContactName = value
					SetDirty("ContactName")
					RaisePropertyChanged("ContactName")
				End If
			End Set
		End Property
		Private _ContactName As System.String
		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _
        Public Property ContactTitle As System.String
			Get
				Return _ContactTitle
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_ContactTitle, value) = 0 Then
					_ContactTitle = value
					SetDirty("ContactTitle")
					RaisePropertyChanged("ContactTitle")
				End If
			End Set
		End Property
		Private _ContactTitle As System.String
		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _
        Public Property Address As System.String
			Get
				Return _Address
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Address, value) = 0 Then
					_Address = value
					SetDirty("Address")
					RaisePropertyChanged("Address")
				End If
			End Set
		End Property
		Private _Address As System.String
		<DataMember(Name:="a5", Order:=6, EmitDefaultValue:=False)> _
        Public Property City As System.String
			Get
				Return _City
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_City, value) = 0 Then
					_City = value
					SetDirty("City")
					RaisePropertyChanged("City")
				End If
			End Set
		End Property
		Private _City As System.String
		<DataMember(Name:="a6", Order:=7, EmitDefaultValue:=False)> _
        Public Property Region As System.String
			Get
				Return _Region
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Region, value) = 0 Then
					_Region = value
					SetDirty("Region")
					RaisePropertyChanged("Region")
				End If
			End Set
		End Property
		Private _Region As System.String
		<DataMember(Name:="a7", Order:=8, EmitDefaultValue:=False)> _
        Public Property PostalCode As System.String
			Get
				Return _PostalCode
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_PostalCode, value) = 0 Then
					_PostalCode = value
					SetDirty("PostalCode")
					RaisePropertyChanged("PostalCode")
				End If
			End Set
		End Property
		Private _PostalCode As System.String
		<DataMember(Name:="a8", Order:=9, EmitDefaultValue:=False)> _
        Public Property Country As System.String
			Get
				Return _Country
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Country, value) = 0 Then
					_Country = value
					SetDirty("Country")
					RaisePropertyChanged("Country")
				End If
			End Set
		End Property
		Private _Country As System.String
		<DataMember(Name:="a9", Order:=10, EmitDefaultValue:=False)> _
        Public Property Phone As System.String
			Get
				Return _Phone
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Phone, value) = 0 Then
					_Phone = value
					SetDirty("Phone")
					RaisePropertyChanged("Phone")
				End If
			End Set
		End Property
		Private _Phone As System.String
		<DataMember(Name:="a10", Order:=11, EmitDefaultValue:=False)> _
        Public Property Fax As System.String
			Get
				Return _Fax
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Fax, value) = 0 Then
					_Fax = value
					SetDirty("Fax")
					RaisePropertyChanged("Fax")
				End If
			End Set
		End Property
		Private _Fax As System.String
		
		

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
	
	<XmlType(TypeName:="CustomersQueryProxyStub")> _	
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
			Return CustomersQueryProxyStub.SerializeHelper.ToXml(query)
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
