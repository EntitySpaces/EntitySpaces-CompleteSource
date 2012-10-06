
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:23 PM
'===============================================================================

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery



Namespace BusinessObjects

	' <summary>
	' Encapsulates the 'Employees' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Employees))> _
	<XmlType("Employees")> _	
	Partial Public Class Employees 
		Inherits esEmployees
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Employees()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal employeeID As System.Int32)
			Dim obj As New Employees()
			obj.EmployeeID = employeeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal employeeID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Employees()
			obj.EmployeeID = employeeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Employees) As EmployeesProxyStub
			Return New EmployeesProxyStub(entity)
		End Operator

		#End Region
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("EmployeesCollection")> _
	Partial Public Class EmployeesCollection
		Inherits esEmployeesCollection
		Implements IEnumerable(Of Employees)
	
		Public Function FindByPrimaryKey(ByVal employeeID As System.Int32) As Employees
			Return MyBase.SingleOrDefault(Function(e) e.EmployeeID.HasValue AndAlso e.EmployeeID.Value = employeeID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As EmployeesCollection) As EmployeesCollectionProxyStub
            Return New EmployeesCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Employees))> _
		Public Class EmployeesCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of EmployeesCollection)
			
			Public Shared Widening Operator CType(packet As EmployeesCollectionWCFPacket) As EmployeesCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As EmployeesCollection) As EmployeesCollectionWCFPacket
				Return New EmployeesCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "EmployeesQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class EmployeesQuery 
		Inherits esEmployeesQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "EmployeesQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As EmployeesQuery) As String
			Return EmployeesQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As EmployeesQuery
			Return DirectCast(EmployeesQuery.SerializeHelper.FromXml(query, GetType(EmployeesQuery)), EmployeesQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esEmployees
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal employeeID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(employeeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(employeeID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal employeeID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(employeeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(employeeID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal employeeID As System.Int32) As Boolean
		
			Dim query As New EmployeesQuery()
			query.Where(query.EmployeeID = employeeID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal employeeID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("EmployeeID", employeeID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Employees.EmployeeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeesMetadata.ColumnNames.EmployeeID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeesMetadata.ColumnNames.EmployeeID, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.EmployeeID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.LastName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property LastName As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.LastName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.LastName, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.LastName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.FirstName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property FirstName As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.FirstName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.FirstName, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.FirstName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.Title
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Title As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.Title)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.Title, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.Title)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.TitleOfCourtesy
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TitleOfCourtesy As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.TitleOfCourtesy)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.TitleOfCourtesy, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.TitleOfCourtesy)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.BirthDate
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property BirthDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(EmployeesMetadata.ColumnNames.BirthDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(EmployeesMetadata.ColumnNames.BirthDate, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.BirthDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.HireDate
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property HireDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(EmployeesMetadata.ColumnNames.HireDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(EmployeesMetadata.ColumnNames.HireDate, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.HireDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.Address
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Address As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.Address)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.Address, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.Address)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.City
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property City As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.City)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.City, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.City)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.Region
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Region As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.Region)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.Region, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.Region)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.PostalCode
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property PostalCode As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.PostalCode)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.PostalCode, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.PostalCode)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.Country
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Country As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.Country)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.Country, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.Country)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.HomePhone
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property HomePhone As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.HomePhone)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.HomePhone, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.HomePhone)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.Extension
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Extension As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.Extension)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.Extension, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.Extension)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.Photo
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Photo As System.Byte()
			Get
				Return MyBase.GetSystemByteArray(EmployeesMetadata.ColumnNames.Photo)
			End Get
			
			Set(ByVal value As System.Byte())
				If MyBase.SetSystemByteArray(EmployeesMetadata.ColumnNames.Photo, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.Photo)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.Notes
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Notes As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.Notes)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.Notes, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.Notes)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.ReportsTo
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ReportsTo As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeesMetadata.ColumnNames.ReportsTo)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeesMetadata.ColumnNames.ReportsTo, value) Then
					Me._UpToEmployeesByReportsTo = Nothing
					Me.OnPropertyChanged("UpToEmployeesByReportsTo")
					OnPropertyChanged(EmployeesMetadata.PropertyNames.ReportsTo)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employees.PhotoPath
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property PhotoPath As System.String
			Get
				Return MyBase.GetSystemString(EmployeesMetadata.ColumnNames.PhotoPath)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeesMetadata.ColumnNames.PhotoPath, value) Then
					OnPropertyChanged(EmployeesMetadata.PropertyNames.PhotoPath)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeesByReportsTo As Employees
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeesMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As EmployeesQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeesQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As EmployeesQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As EmployeesQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As EmployeesQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esEmployeesCollection
		Inherits esEntityCollection(Of Employees)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeesMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "EmployeesCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As EmployeesQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeesQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As EmployeesQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New EmployeesQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As EmployeesQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, EmployeesQuery))
		End Sub
		
		#End Region
						
		Private m_query As EmployeesQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esEmployeesQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return EmployeesMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "EmployeeID" 
					Return Me.EmployeeID
				Case "LastName" 
					Return Me.LastName
				Case "FirstName" 
					Return Me.FirstName
				Case "Title" 
					Return Me.Title
				Case "TitleOfCourtesy" 
					Return Me.TitleOfCourtesy
				Case "BirthDate" 
					Return Me.BirthDate
				Case "HireDate" 
					Return Me.HireDate
				Case "Address" 
					Return Me.Address
				Case "City" 
					Return Me.City
				Case "Region" 
					Return Me.Region
				Case "PostalCode" 
					Return Me.PostalCode
				Case "Country" 
					Return Me.Country
				Case "HomePhone" 
					Return Me.HomePhone
				Case "Extension" 
					Return Me.Extension
				Case "Photo" 
					Return Me.Photo
				Case "Notes" 
					Return Me.Notes
				Case "ReportsTo" 
					Return Me.ReportsTo
				Case "PhotoPath" 
					Return Me.PhotoPath
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.EmployeeID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property LastName As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.LastName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property FirstName As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.FirstName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Title As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.Title, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TitleOfCourtesy As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.TitleOfCourtesy, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property BirthDate As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.BirthDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property HireDate As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.HireDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property Address As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.Address, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property City As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.City, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Region As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.Region, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property PostalCode As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.PostalCode, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Country As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.Country, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property HomePhone As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.HomePhone, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Extension As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.Extension, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Photo As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.Photo, esSystemType.ByteArray)
			End Get
		End Property 
		
		Public ReadOnly Property Notes As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.Notes, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ReportsTo As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.ReportsTo, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property PhotoPath As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeesMetadata.ColumnNames.PhotoPath, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Employees 
		Inherits esEmployees
		
	
		#Region "EmployeesCollectionByReportsTo - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_EmployeesCollectionByReportsTo() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employees.EmployeesCollectionByReportsTo_Delegate)
				map.PropertyName = "EmployeesCollectionByReportsTo"
				map.MyColumnName = "EmployeeID"
				map.ParentColumnName = "ReportsTo"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub EmployeesCollectionByReportsTo_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeesQuery(data.NextAlias())
			
			Dim mee As EmployeesQuery = If(data.You IsNot Nothing, TryCast(data.You, EmployeesQuery), New EmployeesQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.ReportsTo = mee.EmployeeID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Employees_Employees
		''' </summary>

		<XmlIgnore()> _ 
		Public Property EmployeesCollectionByReportsTo As EmployeesCollection 
		
			Get
				If Me._EmployeesCollectionByReportsTo Is Nothing Then
					Me._EmployeesCollectionByReportsTo = New EmployeesCollection()
					Me._EmployeesCollectionByReportsTo.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("EmployeesCollectionByReportsTo", Me._EmployeesCollectionByReportsTo)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._EmployeesCollectionByReportsTo.Query.Where(Me._EmployeesCollectionByReportsTo.Query.ReportsTo = Me.EmployeeID)
							Me._EmployeesCollectionByReportsTo.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._EmployeesCollectionByReportsTo.fks.Add(EmployeesMetadata.ColumnNames.ReportsTo, Me.EmployeeID)
					End If
				End If

				Return Me._EmployeesCollectionByReportsTo
			End Get
			
			Set(ByVal value As EmployeesCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._EmployeesCollectionByReportsTo Is Nothing Then

					Me.RemovePostSave("EmployeesCollectionByReportsTo")
					Me._EmployeesCollectionByReportsTo = Nothing
					Me.OnPropertyChanged("EmployeesCollectionByReportsTo")

				End If
			End Set				
			
		End Property
		

		private _EmployeesCollectionByReportsTo As EmployeesCollection
		#End Region

		#Region "UpToEmployeesByReportsTo - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Employees_Employees
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToEmployeesByReportsTo As Employees
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeesByReportsTo Is Nothing _
						 AndAlso Not ReportsTo.Equals(Nothing)  Then
						
					Me._UpToEmployeesByReportsTo = New Employees()
					Me._UpToEmployeesByReportsTo.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeesByReportsTo", Me._UpToEmployeesByReportsTo)
					Me._UpToEmployeesByReportsTo.Query.Where(Me._UpToEmployeesByReportsTo.Query.EmployeeID = Me.ReportsTo)
					Me._UpToEmployeesByReportsTo.Query.Load()
				End If

				Return Me._UpToEmployeesByReportsTo
			End Get
			
            Set(ByVal value As Employees)
				Me.RemovePreSave("UpToEmployeesByReportsTo")
				
				Dim changed as Boolean = Me._UpToEmployeesByReportsTo IsNot value

				If value Is Nothing Then
				
					Me.ReportsTo = Nothing
				
					Me._UpToEmployeesByReportsTo = Nothing
				Else
				
					Me.ReportsTo = value.EmployeeID
					
					Me._UpToEmployeesByReportsTo = value
					Me.SetPreSave("UpToEmployeesByReportsTo", Me._UpToEmployeesByReportsTo)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeesByReportsTo")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToTerritoriesCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_EmployeeTerritories_Employees
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToTerritoriesCollection As TerritoriesCollection
		
			Get
				If Me._UpToTerritoriesCollection Is Nothing Then
					Me._UpToTerritoriesCollection = New TerritoriesCollection()
					Me._UpToTerritoriesCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToTerritoriesCollection", Me._UpToTerritoriesCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.EmployeeID.Equals(Nothing) Then 
				
						Dim m As New TerritoriesQuery("m")
						Dim j As New EmployeeTerritoriesQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.TerritoryID = j.TerritoryID)
                        m.Where(j.EmployeeID = Me.EmployeeID)

						Me._UpToTerritoriesCollection.Load(m)

					End If
				End If

				Return Me._UpToTerritoriesCollection
			End Get
			
			Set(ByVal value As TerritoriesCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToTerritoriesCollection Is Nothing Then

					Me.RemovePostSave("UpToTerritoriesCollection")
					Me._UpToTerritoriesCollection = Nothing
					Me.OnPropertyChanged("UpToTerritoriesCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_EmployeeTerritories_Employees
		''' </summary>
		Public Sub AssociateTerritoriesCollection(entity As Territories)
			If Me._EmployeeTerritoriesCollection Is Nothing Then
				Me._EmployeeTerritoriesCollection = New EmployeeTerritoriesCollection()
				Me._EmployeeTerritoriesCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("EmployeeTerritoriesCollection", Me._EmployeeTerritoriesCollection)
			End If
			
			Dim obj As EmployeeTerritories = Me._EmployeeTerritoriesCollection.AddNew()
			obj.EmployeeID = Me.EmployeeID
			obj.TerritoryID = entity.TerritoryID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_EmployeeTerritories_Employees
		''' </summary>
		Public Sub DissociateTerritoriesCollection(entity As Territories)
			If Me._EmployeeTerritoriesCollection Is Nothing Then
				Me._EmployeeTerritoriesCollection = new EmployeeTerritoriesCollection()
				Me._EmployeeTerritoriesCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("EmployeeTerritoriesCollection", Me._EmployeeTerritoriesCollection)
			End If

			Dim obj As EmployeeTerritories = Me._EmployeeTerritoriesCollection.AddNew()
			obj.EmployeeID = Me.EmployeeID
            obj.TerritoryID = entity.TerritoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToTerritoriesCollection As TerritoriesCollection
		Private _EmployeeTerritoriesCollection As EmployeeTerritoriesCollection
		#End Region

		#Region "EmployeeTerritoriesCollectionByEmployeeID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_EmployeeTerritoriesCollectionByEmployeeID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employees.EmployeeTerritoriesCollectionByEmployeeID_Delegate)
				map.PropertyName = "EmployeeTerritoriesCollectionByEmployeeID"
				map.MyColumnName = "EmployeeID"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub EmployeeTerritoriesCollectionByEmployeeID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeesQuery(data.NextAlias())
			
			Dim mee As EmployeeTerritoriesQuery = If(data.You IsNot Nothing, TryCast(data.You, EmployeeTerritoriesQuery), New EmployeeTerritoriesQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.EmployeeID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_EmployeeTerritories_Employees
		''' </summary>

		<XmlIgnore()> _ 
		Public Property EmployeeTerritoriesCollectionByEmployeeID As EmployeeTerritoriesCollection 
		
			Get
				If Me._EmployeeTerritoriesCollectionByEmployeeID Is Nothing Then
					Me._EmployeeTerritoriesCollectionByEmployeeID = New EmployeeTerritoriesCollection()
					Me._EmployeeTerritoriesCollectionByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("EmployeeTerritoriesCollectionByEmployeeID", Me._EmployeeTerritoriesCollectionByEmployeeID)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._EmployeeTerritoriesCollectionByEmployeeID.Query.Where(Me._EmployeeTerritoriesCollectionByEmployeeID.Query.EmployeeID = Me.EmployeeID)
							Me._EmployeeTerritoriesCollectionByEmployeeID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._EmployeeTerritoriesCollectionByEmployeeID.fks.Add(EmployeeTerritoriesMetadata.ColumnNames.EmployeeID, Me.EmployeeID)
					End If
				End If

				Return Me._EmployeeTerritoriesCollectionByEmployeeID
			End Get
			
			Set(ByVal value As EmployeeTerritoriesCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._EmployeeTerritoriesCollectionByEmployeeID Is Nothing Then

					Me.RemovePostSave("EmployeeTerritoriesCollectionByEmployeeID")
					Me._EmployeeTerritoriesCollectionByEmployeeID = Nothing
					Me.OnPropertyChanged("EmployeeTerritoriesCollectionByEmployeeID")

				End If
			End Set				
			
		End Property
		

		private _EmployeeTerritoriesCollectionByEmployeeID As EmployeeTerritoriesCollection
		#End Region

		#Region "OrdersCollectionByEmployeeID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrdersCollectionByEmployeeID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employees.OrdersCollectionByEmployeeID_Delegate)
				map.PropertyName = "OrdersCollectionByEmployeeID"
				map.MyColumnName = "EmployeeID"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrdersCollectionByEmployeeID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeesQuery(data.NextAlias())
			
			Dim mee As OrdersQuery = If(data.You IsNot Nothing, TryCast(data.You, OrdersQuery), New OrdersQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.EmployeeID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Orders_Employees
		''' </summary>

		<XmlIgnore()> _ 
		Public Property OrdersCollectionByEmployeeID As OrdersCollection 
		
			Get
				If Me._OrdersCollectionByEmployeeID Is Nothing Then
					Me._OrdersCollectionByEmployeeID = New OrdersCollection()
					Me._OrdersCollectionByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrdersCollectionByEmployeeID", Me._OrdersCollectionByEmployeeID)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrdersCollectionByEmployeeID.Query.Where(Me._OrdersCollectionByEmployeeID.Query.EmployeeID = Me.EmployeeID)
							Me._OrdersCollectionByEmployeeID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrdersCollectionByEmployeeID.fks.Add(OrdersMetadata.ColumnNames.EmployeeID, Me.EmployeeID)
					End If
				End If

				Return Me._OrdersCollectionByEmployeeID
			End Get
			
			Set(ByVal value As OrdersCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrdersCollectionByEmployeeID Is Nothing Then

					Me.RemovePostSave("OrdersCollectionByEmployeeID")
					Me._OrdersCollectionByEmployeeID = Nothing
					Me.OnPropertyChanged("OrdersCollectionByEmployeeID")

				End If
			End Set				
			
		End Property
		

		private _OrdersCollectionByEmployeeID As OrdersCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "EmployeesCollectionByReportsTo"
					coll = Me.EmployeesCollectionByReportsTo
					Exit Select
				Case "EmployeeTerritoriesCollectionByEmployeeID"
					coll = Me.EmployeeTerritoriesCollectionByEmployeeID
					Exit Select
				Case "OrdersCollectionByEmployeeID"
					coll = Me.OrdersCollectionByEmployeeID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "EmployeesCollectionByReportsTo", GetType(EmployeesCollection), New Employees()))
			props.Add(new esPropertyDescriptor(Me, "EmployeeTerritoriesCollectionByEmployeeID", GetType(EmployeeTerritoriesCollection), New EmployeeTerritories()))
			props.Add(new esPropertyDescriptor(Me, "OrdersCollectionByEmployeeID", GetType(OrdersCollection), New Orders()))
			Return props
			
		End Function	
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeesByReportsTo Is Nothing Then
				Me.ReportsTo = Me._UpToEmployeesByReportsTo.EmployeeID
			End If
			
		End Sub
		
		''' <summary>
		''' Called by ApplyPostSaveKeys 
		''' </summary>
		''' <param name="coll">The collection to enumerate over</param>
		''' <param name="key">"The column name</param>
		''' <param name="value">The column value</param>
		Private Sub Apply(coll As esEntityCollectionBase, key As String, value As Object)
			For Each obj As esEntity In coll
				If obj.es.IsAdded Then
					obj.SetProperty(key, value)
				End If
			Next
		End Sub
		
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PostSave.
		''' </summary>
		Protected Overrides Sub ApplyPostSaveKeys()
		
			If Not Me._EmployeesCollectionByReportsTo Is Nothing Then
				Apply(Me._EmployeesCollectionByReportsTo, "ReportsTo", Me.EmployeeID)
			End If
			
			If Not Me._EmployeeTerritoriesCollection Is Nothing Then
				Apply(Me._EmployeeTerritoriesCollection, "EmployeeID", Me.EmployeeID)
			End If
			
			If Not Me._EmployeeTerritoriesCollectionByEmployeeID Is Nothing Then
				Apply(Me._EmployeeTerritoriesCollectionByEmployeeID, "EmployeeID", Me.EmployeeID)
			End If
			
			If Not Me._OrdersCollectionByEmployeeID Is Nothing Then
				Apply(Me._OrdersCollectionByEmployeeID, "EmployeeID", Me.EmployeeID)
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Employees")> _
    <XmlType(TypeName:="EmployeesProxyStub")> _
    <Serializable> _
    Partial Public Class EmployeesProxyStub
	
		Public Sub New()
            Me._entity = New Employees()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Employees)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Employees, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As EmployeesProxyStub) As Employees
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Employees)
        End Function
		

		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _		
        Public Property EmployeeID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(EmployeesMetadata.ColumnNames.EmployeeID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.EmployeeID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.EmployeeID = value
			End Set
			
		End Property

		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _		
        Public Property LastName As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.LastName) Then
                    Return Me.Entity.LastName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.LastName = value
			End Set
			
		End Property

		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _		
        Public Property FirstName As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.FirstName) Then
                    Return Me.Entity.FirstName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.FirstName = value
			End Set
			
		End Property

		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Title As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.Title) Then
                    Return Me.Entity.Title
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Title = value
			End Set
			
		End Property

		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _		
        Public Property TitleOfCourtesy As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.TitleOfCourtesy) Then
                    Return Me.Entity.TitleOfCourtesy
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TitleOfCourtesy = value
			End Set
			
		End Property

		<DataMember(Name:="a5", Order:=6, EmitDefaultValue:=False)> _		
        Public Property BirthDate As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.BirthDate) Then
                    Return Me.Entity.BirthDate
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.BirthDate = value
			End Set
			
		End Property

		<DataMember(Name:="a6", Order:=7, EmitDefaultValue:=False)> _		
        Public Property HireDate As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.HireDate) Then
                    Return Me.Entity.HireDate
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.HireDate = value
			End Set
			
		End Property

		<DataMember(Name:="a7", Order:=8, EmitDefaultValue:=False)> _		
        Public Property Address As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.Address) Then
                    Return Me.Entity.Address
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Address = value
			End Set
			
		End Property

		<DataMember(Name:="a8", Order:=9, EmitDefaultValue:=False)> _		
        Public Property City As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.City) Then
                    Return Me.Entity.City
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.City = value
			End Set
			
		End Property

		<DataMember(Name:="a9", Order:=10, EmitDefaultValue:=False)> _		
        Public Property Region As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.Region) Then
                    Return Me.Entity.Region
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Region = value
			End Set
			
		End Property

		<DataMember(Name:="a10", Order:=11, EmitDefaultValue:=False)> _		
        Public Property PostalCode As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.PostalCode) Then
                    Return Me.Entity.PostalCode
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.PostalCode = value
			End Set
			
		End Property

		<DataMember(Name:="a11", Order:=12, EmitDefaultValue:=False)> _		
        Public Property Country As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.Country) Then
                    Return Me.Entity.Country
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Country = value
			End Set
			
		End Property

		<DataMember(Name:="a12", Order:=13, EmitDefaultValue:=False)> _		
        Public Property HomePhone As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.HomePhone) Then
                    Return Me.Entity.HomePhone
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.HomePhone = value
			End Set
			
		End Property

		<DataMember(Name:="a13", Order:=14, EmitDefaultValue:=False)> _		
        Public Property Extension As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.Extension) Then
                    Return Me.Entity.Extension
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Extension = value
			End Set
			
		End Property

		<DataMember(Name:="a14", Order:=15, EmitDefaultValue:=False)> _		
        Public Property Photo As System.Byte()
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.Photo) Then
                    Return Me.Entity.Photo
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.Byte())
				Me.Entity.Photo = value
			End Set
			
		End Property

		<DataMember(Name:="a15", Order:=16, EmitDefaultValue:=False)> _		
        Public Property Notes As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.Notes) Then
                    Return Me.Entity.Notes
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Notes = value
			End Set
			
		End Property

		<DataMember(Name:="a16", Order:=17, EmitDefaultValue:=False)> _		
        Public Property ReportsTo As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.ReportsTo) Then
                    Return Me.Entity.ReportsTo
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ReportsTo = value
			End Set
			
		End Property

		<DataMember(Name:="a17", Order:=18, EmitDefaultValue:=False)> _		
        Public Property PhotoPath As System.String
        
            Get
                If Me.IncludeColumn(EmployeesMetadata.ColumnNames.PhotoPath) Then
                    Return Me.Entity.PhotoPath
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.PhotoPath = value
			End Set
			
		End Property


		<DataMember(Name := "a10000", Order := 10000)> _
        Public Property esRowState As String
            Get
				Return Me.TheRowState
            End Get

            Set 
				Me.TheRowState = value
            End Set
        End Property
		
		<DataMember(Name := "a10001", Order := 10001, EmitDefaultValue := False)> _
		Private Property ModifiedColumns() As List(Of String)
			Get
				Return Entity.es.ModifiedColumns
			End Get
			Set(ByVal value As List(Of String))
				Entity.es.ModifiedColumns.AddRange(value)
			End Set
		End Property		
		
		<DataMember(Name := "a10002", Order := 10002, EmitDefaultValue := False)> _
        <XmlIgnore> _		
		Public Property esExtraColumns() As Dictionary(Of String, Object)
			Get
				Return Entity.GetExtraColumns()
			End Get
			Set(ByVal value As Dictionary(Of String, Object))
				Entity.SetExtraColumns(value)
			End Set
		End Property
		
		<XmlArray("_x_ExtraColumns")> _
		<XmlArrayItem("_x_ExtraColumns", Type := GetType(DictionaryEntry))> _
		Public Property _x_ExtraColumns() As DictionaryEntry()
			Get
				Dim extra As Dictionary(Of String, Object) = Entity.GetExtraColumns()

				' Make an array of DictionaryEntries to return   
				Dim ret As DictionaryEntry() = New DictionaryEntry(extra.Count - 1) {}
				Dim i As Integer = 0
				Dim de As DictionaryEntry

				' Iterate through the extra columns to load items into the array.   
				For Each kv As KeyValuePair(Of String, Object) In extra
					de = New DictionaryEntry()
					de.Key = kv.Key
					de.Value = kv.Value
					ret(i) = de
					i += 1
				Next
				Return ret
			End Get
			Set
				Dim extra As New Dictionary(Of String, Object)()
				For i As Integer = 0 To value.Length - 1
					extra.Add(DirectCast(value(i).Key, String), CInt(value(i).Value))
				Next
				Entity.SetExtraColumns(extra)
			End Set
		End Property
		
        <XmlIgnore> _		
        Public Property Entity As Employees
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Employees()
					Me.theEntity = Me._entity					
                End If

                Return _entity
            End Get

            Set
                Me._entity = value
            End Set
        End Property
		
		Protected Property TheRowState() As String
			Get
				Return theEntity.es.RowState.ToString()
			End Get
			
			Set(ByVal value As String)
				Select Case value
					Case "Unchanged"
						theEntity.AcceptChanges()
						Exit Select
					
					Case "Added"
						theEntity.AcceptChanges()
						theEntity.es.RowState = esDataRowState.Added
						Exit Select
					
					Case "Modified"
						theEntity.AcceptChanges()
						theEntity.es.RowState = esDataRowState.Modified
						Exit Select
					
					Case "Deleted"
						theEntity.AcceptChanges()
						theEntity.MarkAsDeleted()
						Exit Select
				End Select
			End Set
		End Property	
		
		Protected Function IncludeColumn(ByVal columnName As String) As Boolean
			Dim include As Boolean = False
			
			If dirtyColumnsOnly Then
				If theEntity.es.ModifiedColumns IsNot Nothing AndAlso theEntity.es.ModifiedColumns.Contains(columnName) Then
					include = True
				End If
			ElseIf Not theEntity.es.IsDeleted Then
				include = True
			End If
			
			Return include
		End Function	

        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Public _entity As Employees
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="EmployeesCollection")> _
    <XmlType(TypeName:="EmployeesCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class EmployeesCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Employees))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Employees), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As EmployeesCollectionProxyStub) As EmployeesCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Employees)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Employees), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Employees In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New EmployeesProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New EmployeesProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Employees In coll.es.DeletedEntities
                    Collection.Add(New EmployeesProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of EmployeesProxyStub)		

        Public Function GetCollection As EmployeesCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New EmployeesCollection()
					
		            Dim proxy As EmployeesProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As EmployeesCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class EmployeesMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.EmployeeID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeesMetadata.PropertyNames.EmployeeID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.LastName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.LastName
			c.CharacterMaxLength = 20
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.FirstName, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.FirstName
			c.CharacterMaxLength = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.Title, 3, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.Title
			c.CharacterMaxLength = 30
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.TitleOfCourtesy, 4, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.TitleOfCourtesy
			c.CharacterMaxLength = 25
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.BirthDate, 5, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = EmployeesMetadata.PropertyNames.BirthDate
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.HireDate, 6, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = EmployeesMetadata.PropertyNames.HireDate
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.Address, 7, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.Address
			c.CharacterMaxLength = 60
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.City, 8, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.City
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.Region, 9, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.Region
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.PostalCode, 10, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.PostalCode
			c.CharacterMaxLength = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.Country, 11, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.Country
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.HomePhone, 12, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.HomePhone
			c.CharacterMaxLength = 24
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.Extension, 13, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.Extension
			c.CharacterMaxLength = 4
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.Photo, 14, GetType(System.Byte()), esSystemType.ByteArray)	
			c.PropertyName = EmployeesMetadata.PropertyNames.Photo
			c.CharacterMaxLength = 2147483647
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.Notes, 15, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.Notes
			c.CharacterMaxLength = 1073741823
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.ReportsTo, 16, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeesMetadata.PropertyNames.ReportsTo
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeesMetadata.ColumnNames.PhotoPath, 17, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeesMetadata.PropertyNames.PhotoPath
			c.CharacterMaxLength = 255
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As EmployeesMetadata
			Return _meta
		End Function
		
		Public ReadOnly Property DataID() As System.Guid Implements IMetadata.DataID
			Get
				Return MyBase.m_dataID
			End Get
		End Property

		Public ReadOnly Property MultiProviderMode() As Boolean Implements IMetadata.MultiProviderMode
			Get
				Return false
			End Get
		End Property

		Public ReadOnly Property Columns() As esColumnMetadataCollection Implements IMetadata.Columns
			Get
				Return MyBase.m_columns
			End Get
		End Property

#Region "ColumnNames"
		Public Class ColumnNames
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const LastName As String = "LastName"
			 Public Const FirstName As String = "FirstName"
			 Public Const Title As String = "Title"
			 Public Const TitleOfCourtesy As String = "TitleOfCourtesy"
			 Public Const BirthDate As String = "BirthDate"
			 Public Const HireDate As String = "HireDate"
			 Public Const Address As String = "Address"
			 Public Const City As String = "City"
			 Public Const Region As String = "Region"
			 Public Const PostalCode As String = "PostalCode"
			 Public Const Country As String = "Country"
			 Public Const HomePhone As String = "HomePhone"
			 Public Const Extension As String = "Extension"
			 Public Const Photo As String = "Photo"
			 Public Const Notes As String = "Notes"
			 Public Const ReportsTo As String = "ReportsTo"
			 Public Const PhotoPath As String = "PhotoPath"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const LastName As String = "LastName"
			 Public Const FirstName As String = "FirstName"
			 Public Const Title As String = "Title"
			 Public Const TitleOfCourtesy As String = "TitleOfCourtesy"
			 Public Const BirthDate As String = "BirthDate"
			 Public Const HireDate As String = "HireDate"
			 Public Const Address As String = "Address"
			 Public Const City As String = "City"
			 Public Const Region As String = "Region"
			 Public Const PostalCode As String = "PostalCode"
			 Public Const Country As String = "Country"
			 Public Const HomePhone As String = "HomePhone"
			 Public Const Extension As String = "Extension"
			 Public Const Photo As String = "Photo"
			 Public Const Notes As String = "Notes"
			 Public Const ReportsTo As String = "ReportsTo"
			 Public Const PhotoPath As String = "PhotoPath"
		End Class
#End Region	

		Public Function GetProviderMetadata(ByVal mapName As String) As esProviderSpecificMetadata _
			Implements IMetadata.GetProviderMetadata

			Dim mapMethod As MapToMeta = mapDelegates(mapName)

			If (Not mapMethod = Nothing) Then
				Return mapMethod(mapName)
			Else
				Return Nothing
			End If

		End Function
		
#Region "MAP esDefault"

		Private Shared Function RegisterDelegateesDefault() As Integer
		
			' This is only executed once per the life of the application
			SyncLock GetType(EmployeesMetadata)
			
				If EmployeesMetadata.mapDelegates Is Nothing Then
					EmployeesMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If EmployeesMetadata._meta Is Nothing Then
					EmployeesMetadata._meta = New EmployeesMetadata()
				End If

				Dim mapMethod As New MapToMeta(AddressOf _meta.esDefault)
				mapDelegates.Add("esDefault", mapMethod)
				mapMethod("esDefault")
				Return 0

			End SyncLock
			
		End Function

		Private Function esDefault(ByVal mapName As String) As esProviderSpecificMetadata

			If (Not m_providerMetadataMaps.ContainsKey(mapName)) Then
			
				Dim meta As esProviderSpecificMetadata = New esProviderSpecificMetadata()
				


				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("LastName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("FirstName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Title", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("TitleOfCourtesy", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("BirthDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("HireDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Region", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Country", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("HomePhone", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Extension", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Photo", new esTypeMap("image", "System.Byte()"))
				meta.AddTypeMap("Notes", new esTypeMap("ntext", "System.String"))
				meta.AddTypeMap("ReportsTo", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("PhotoPath", new esTypeMap("nvarchar", "System.String"))			
				
				
				 
				meta.Source = "Employees"
				meta.Destination = "Employees"
				
				meta.spInsert = "proc_EmployeesInsert"
				meta.spUpdate = "proc_EmployeesUpdate"
				meta.spDelete = "proc_EmployeesDelete"
				meta.spLoadAll = "proc_EmployeesLoadAll"
				meta.spLoadByPrimaryKey = "proc_EmployeesLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As EmployeesMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
