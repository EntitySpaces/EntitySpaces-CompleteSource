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

	<DataContract(Namespace:="http://tempuri.org/", Name:="EmployeesCollection")> _
	<XmlType(TypeName:="EmployeesCollectionProxyStub")> _	
	Partial Public Class EmployeesCollectionProxyStub 

		Public Sub New() 
		
		End Sub
		
		<DataMember(Name:="Collection", EmitDefaultValue:=False)> _
		Public Collection As New ObservableCollection (Of EmployeesProxyStub)
		
		Public Function IsDirty() As Boolean
			For Each obj As EmployeesProxyStub In Collection
				If obj.IsDirty() Then
					Return True
				End If
			Next
			Return False
		End Function
	

	End Class
	
	<DataContract(Namespace:="http://tempuri.org/", Name:="Employees")> _
	<XmlType(TypeName:="EmployeesProxyStub")> _	
	Partial Public Class EmployeesProxyStub
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
		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _
        Public Property LastName As System.String
			Get
				Return _LastName
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_LastName, value) = 0 Then
					_LastName = value
					SetDirty("LastName")
					RaisePropertyChanged("LastName")
				End If
			End Set
		End Property
		Private _LastName As System.String
		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _
        Public Property FirstName As System.String
			Get
				Return _FirstName
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_FirstName, value) = 0 Then
					_FirstName = value
					SetDirty("FirstName")
					RaisePropertyChanged("FirstName")
				End If
			End Set
		End Property
		Private _FirstName As System.String
		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _
        Public Property Title As System.String
			Get
				Return _Title
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Title, value) = 0 Then
					_Title = value
					SetDirty("Title")
					RaisePropertyChanged("Title")
				End If
			End Set
		End Property
		Private _Title As System.String
		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _
        Public Property TitleOfCourtesy As System.String
			Get
				Return _TitleOfCourtesy
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_TitleOfCourtesy, value) = 0 Then
					_TitleOfCourtesy = value
					SetDirty("TitleOfCourtesy")
					RaisePropertyChanged("TitleOfCourtesy")
				End If
			End Set
		End Property
		Private _TitleOfCourtesy As System.String
		<DataMember(Name:="a5", Order:=6, EmitDefaultValue:=False)> _
        Public Property BirthDate As Nullable(Of System.DateTime)
			Get
				Return _BirthDate
			End Get
			Set(ByVal value As Nullable(Of System.DateTime))
				If Not _BirthDate.Equals(value) Then
					_BirthDate = value
					SetDirty("BirthDate")
					RaisePropertyChanged("BirthDate")
				End If
			End Set
		End Property
		Private _BirthDate As Nullable(Of System.DateTime)
		<DataMember(Name:="a6", Order:=7, EmitDefaultValue:=False)> _
        Public Property HireDate As Nullable(Of System.DateTime)
			Get
				Return _HireDate
			End Get
			Set(ByVal value As Nullable(Of System.DateTime))
				If Not _HireDate.Equals(value) Then
					_HireDate = value
					SetDirty("HireDate")
					RaisePropertyChanged("HireDate")
				End If
			End Set
		End Property
		Private _HireDate As Nullable(Of System.DateTime)
		<DataMember(Name:="a7", Order:=8, EmitDefaultValue:=False)> _
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
		<DataMember(Name:="a8", Order:=9, EmitDefaultValue:=False)> _
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
		<DataMember(Name:="a9", Order:=10, EmitDefaultValue:=False)> _
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
		<DataMember(Name:="a10", Order:=11, EmitDefaultValue:=False)> _
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
		<DataMember(Name:="a11", Order:=12, EmitDefaultValue:=False)> _
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
		<DataMember(Name:="a12", Order:=13, EmitDefaultValue:=False)> _
        Public Property HomePhone As System.String
			Get
				Return _HomePhone
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_HomePhone, value) = 0 Then
					_HomePhone = value
					SetDirty("HomePhone")
					RaisePropertyChanged("HomePhone")
				End If
			End Set
		End Property
		Private _HomePhone As System.String
		<DataMember(Name:="a13", Order:=14, EmitDefaultValue:=False)> _
        Public Property Extension As System.String
			Get
				Return _Extension
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Extension, value) = 0 Then
					_Extension = value
					SetDirty("Extension")
					RaisePropertyChanged("Extension")
				End If
			End Set
		End Property
		Private _Extension As System.String
		<DataMember(Name:="a14", Order:=15, EmitDefaultValue:=False)> _
        Public Property Photo As System.Byte()
			Get
				Return _Photo
			End Get
			Set(ByVal value As System.Byte())
				If _Photo Is value Then
					_Photo = value
					SetDirty("Photo")
					RaisePropertyChanged("Photo")
				End If
			End Set
		End Property
		Private _Photo As System.Byte()
		<DataMember(Name:="a15", Order:=16, EmitDefaultValue:=False)> _
        Public Property Notes As System.String
			Get
				Return _Notes
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_Notes, value) = 0 Then
					_Notes = value
					SetDirty("Notes")
					RaisePropertyChanged("Notes")
				End If
			End Set
		End Property
		Private _Notes As System.String
		<DataMember(Name:="a16", Order:=17, EmitDefaultValue:=False)> _
        Public Property ReportsTo As Nullable(Of System.Int32)
			Get
				Return _ReportsTo
			End Get
			Set(ByVal value As Nullable(Of System.Int32))
				If Not _ReportsTo.Equals(value) Then
					_ReportsTo = value
					SetDirty("ReportsTo")
					RaisePropertyChanged("ReportsTo")
				End If
			End Set
		End Property
		Private _ReportsTo As Nullable(Of System.Int32)
		<DataMember(Name:="a17", Order:=18, EmitDefaultValue:=False)> _
        Public Property PhotoPath As System.String
			Get
				Return _PhotoPath
			End Get
			Set(ByVal value As System.String)
				If Not String.Compare(_PhotoPath, value) = 0 Then
					_PhotoPath = value
					SetDirty("PhotoPath")
					RaisePropertyChanged("PhotoPath")
				End If
			End Set
		End Property
		Private _PhotoPath As System.String
		
		

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
	
	<XmlType(TypeName:="EmployeesQueryProxyStub")> _	
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
			Return EmployeesQueryProxyStub.SerializeHelper.ToXml(query)
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
