
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : SQL
' Date Generated       : 3/17/2012 4:51:52 AM
'===============================================================================

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery



Namespace BusinessObjects

	' <summary>
	' Encapsulates the 'Employee' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Employee))> _
	<XmlType("Employee")> _ 
	<Table(Name:="Employee")> _	
	Partial Public Class Employee 
		Inherits esEmployee
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Employee()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal employeeID As System.Int32)
			Dim obj As New Employee()
			obj.EmployeeID = employeeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal employeeID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Employee()
			obj.EmployeeID = employeeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Employee) As EmployeeProxyStub
			Return New EmployeeProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.EmployeeID
			End Get
			Set
				MyBase.EmployeeID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property LastName As System.String
			Get
				Return MyBase.LastName
			End Get
			Set
				MyBase.LastName = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property FirstName As System.String
			Get
				Return MyBase.FirstName
			End Get
			Set
				MyBase.FirstName = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Supervisor As Nullable(Of System.Int32)
			Get
				Return MyBase.Supervisor
			End Get
			Set
				MyBase.Supervisor = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Age As Nullable(Of System.Int32)
			Get
				Return MyBase.Age
			End Get
			Set
				MyBase.Age = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("EmployeeCollection")> _
	Partial Public Class EmployeeCollection
		Inherits esEmployeeCollection
		Implements IEnumerable(Of Employee)
	
		Public Function FindByPrimaryKey(ByVal employeeID As System.Int32) As Employee
			Return MyBase.SingleOrDefault(Function(e) e.EmployeeID.HasValue AndAlso e.EmployeeID.Value = employeeID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As EmployeeCollection) As EmployeeCollectionProxyStub
            Return New EmployeeCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Employee))> _
		Public Class EmployeeCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of EmployeeCollection)
			
			Public Shared Widening Operator CType(packet As EmployeeCollectionWCFPacket) As EmployeeCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As EmployeeCollection) As EmployeeCollectionWCFPacket
				Return New EmployeeCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "EmployeeQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class EmployeeQuery 
		Inherits esEmployeeQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "EmployeeQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As EmployeeQuery) As String
			Return EmployeeQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As EmployeeQuery
			Return DirectCast(EmployeeQuery.SerializeHelper.FromXml(query, GetType(EmployeeQuery)), EmployeeQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esEmployee
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
		
			Dim query As New EmployeeQuery()
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
		' Maps to Employee.EmployeeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeeMetadata.ColumnNames.EmployeeID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeeMetadata.ColumnNames.EmployeeID, value) Then
					OnPropertyChanged(EmployeeMetadata.PropertyNames.EmployeeID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employee.LastName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property LastName As System.String
			Get
				Return MyBase.GetSystemString(EmployeeMetadata.ColumnNames.LastName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeeMetadata.ColumnNames.LastName, value) Then
					OnPropertyChanged(EmployeeMetadata.PropertyNames.LastName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employee.FirstName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property FirstName As System.String
			Get
				Return MyBase.GetSystemString(EmployeeMetadata.ColumnNames.FirstName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(EmployeeMetadata.ColumnNames.FirstName, value) Then
					OnPropertyChanged(EmployeeMetadata.PropertyNames.FirstName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employee.Supervisor
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Supervisor As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeeMetadata.ColumnNames.Supervisor)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeeMetadata.ColumnNames.Supervisor, value) Then
					Me._UpToEmployeeBySupervisor = Nothing
					Me.OnPropertyChanged("UpToEmployeeBySupervisor")
					OnPropertyChanged(EmployeeMetadata.PropertyNames.Supervisor)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Employee.Age
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Age As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeeMetadata.ColumnNames.Age)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeeMetadata.ColumnNames.Age, value) Then
					OnPropertyChanged(EmployeeMetadata.PropertyNames.Age)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeBySupervisor As Employee
		
#End Region	

#Region ".str() Properties"

		Public Overrides Sub SetProperties(values as IDictionary)

		Dim propertyName As String
			For Each propertyName In values.Keys
				Me.SetProperty(propertyName, values(propertyName))
			Next

		End Sub

		Public Overrides Sub SetProperty(name as string, value as object)

			Dim col As esColumnMetadata = Me.Meta.Columns.FindByPropertyName(name)
			If Not col Is Nothing Then

				If value Is Nothing OrElse value.GetType().ToString() = "System.String" Then

					' Use the strongly typed property
					Select Case name
												
						Case "EmployeeID"
							Me.str().EmployeeID = CType(value, string)
												
						Case "LastName"
							Me.str().LastName = CType(value, string)
												
						Case "FirstName"
							Me.str().FirstName = CType(value, string)
												
						Case "Supervisor"
							Me.str().Supervisor = CType(value, string)
												
						Case "Age"
							Me.str().Age = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "EmployeeID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.EmployeeID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(EmployeeMetadata.PropertyNames.EmployeeID)
							End If
						
						Case "Supervisor"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Supervisor = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(EmployeeMetadata.PropertyNames.Supervisor)
							End If
						
						Case "Age"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Age = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(EmployeeMetadata.PropertyNames.Age)
							End If
						
					
						Case Else
						
					End Select
				End If

			Else If Me.ContainsColumn(name) Then
				Me.SetColumn(name, value)
			Else
				throw New Exception("SetProperty Error: '" + name + "' not found")
			End If	

		End Sub

		Public Function str() As esStrings
		
			If _esstrings Is Nothing Then
				_esstrings = New esStrings(Me)
			End If
			Return _esstrings
			
		End Function

		NotInheritable Public Class esStrings
		
			Public Sub New(ByVal entity As esEmployee)
				Me.entity = entity
			End Sub				
		
	
			Public Property EmployeeID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.EmployeeID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.EmployeeID = Nothing
					Else
						entity.EmployeeID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property LastName As System.String 
				Get
					Dim data_ As System.String = entity.LastName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.LastName = Nothing
					Else
						entity.LastName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property FirstName As System.String 
				Get
					Dim data_ As System.String = entity.FirstName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.FirstName = Nothing
					Else
						entity.FirstName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Supervisor As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.Supervisor
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Supervisor = Nothing
					Else
						entity.Supervisor = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property Age As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.Age
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Age = Nothing
					Else
						entity.Age = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  

			Private entity As esEmployee
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeeMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As EmployeeQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeeQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As EmployeeQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As EmployeeQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As EmployeeQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esEmployeeCollection
		Inherits esEntityCollection(Of Employee)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeeMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "EmployeeCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As EmployeeQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeeQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As EmployeeQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New EmployeeQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As EmployeeQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, EmployeeQuery))
		End Sub
		
		#End Region
						
		Private m_query As EmployeeQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esEmployeeQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return EmployeeMetadata.Meta()
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
				Case "Supervisor" 
					Return Me.Supervisor
				Case "Age" 
					Return Me.Age
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeMetadata.ColumnNames.EmployeeID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property LastName As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeMetadata.ColumnNames.LastName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property FirstName As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeMetadata.ColumnNames.FirstName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Supervisor As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeMetadata.ColumnNames.Supervisor, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Age As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeMetadata.ColumnNames.Age, esSystemType.Int32)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Employee 
		Inherits esEmployee
		
	
		#Region "CustomerCollectionByManager - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_CustomerCollectionByManager() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employee.CustomerCollectionByManager_Delegate)
				map.PropertyName = "CustomerCollectionByManager"
				map.MyColumnName = "Manager"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub CustomerCollectionByManager_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeeQuery(data.NextAlias())
			
			Dim mee As CustomerQuery = If(data.You IsNot Nothing, TryCast(data.You, CustomerQuery), New CustomerQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.Manager)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Customer_Manager
		''' </summary>

		<XmlIgnore()> _ 
		Public Property CustomerCollectionByManager As CustomerCollection 
		
			Get
				If Me._CustomerCollectionByManager Is Nothing Then
					Me._CustomerCollectionByManager = New CustomerCollection()
					Me._CustomerCollectionByManager.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("CustomerCollectionByManager", Me._CustomerCollectionByManager)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._CustomerCollectionByManager.Query.Where(Me._CustomerCollectionByManager.Query.Manager = Me.EmployeeID)
							Me._CustomerCollectionByManager.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._CustomerCollectionByManager.fks.Add(CustomerMetadata.ColumnNames.Manager, Me.EmployeeID)
					End If
				End If

				Return Me._CustomerCollectionByManager
			End Get
			
			Set(ByVal value As CustomerCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._CustomerCollectionByManager Is Nothing Then

					Me.RemovePostSave("CustomerCollectionByManager")
					Me._CustomerCollectionByManager = Nothing
					Me.OnPropertyChanged("CustomerCollectionByManager")

				End If
			End Set				
			
		End Property
		

		private _CustomerCollectionByManager As CustomerCollection
		#End Region

		#Region "CustomerCollectionByStaffAssigned - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_CustomerCollectionByStaffAssigned() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employee.CustomerCollectionByStaffAssigned_Delegate)
				map.PropertyName = "CustomerCollectionByStaffAssigned"
				map.MyColumnName = "StaffAssigned"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub CustomerCollectionByStaffAssigned_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeeQuery(data.NextAlias())
			
			Dim mee As CustomerQuery = If(data.You IsNot Nothing, TryCast(data.You, CustomerQuery), New CustomerQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.StaffAssigned)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Customer_StaffAssigned
		''' </summary>

		<XmlIgnore()> _ 
		Public Property CustomerCollectionByStaffAssigned As CustomerCollection 
		
			Get
				If Me._CustomerCollectionByStaffAssigned Is Nothing Then
					Me._CustomerCollectionByStaffAssigned = New CustomerCollection()
					Me._CustomerCollectionByStaffAssigned.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("CustomerCollectionByStaffAssigned", Me._CustomerCollectionByStaffAssigned)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._CustomerCollectionByStaffAssigned.Query.Where(Me._CustomerCollectionByStaffAssigned.Query.StaffAssigned = Me.EmployeeID)
							Me._CustomerCollectionByStaffAssigned.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._CustomerCollectionByStaffAssigned.fks.Add(CustomerMetadata.ColumnNames.StaffAssigned, Me.EmployeeID)
					End If
				End If

				Return Me._CustomerCollectionByStaffAssigned
			End Get
			
			Set(ByVal value As CustomerCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._CustomerCollectionByStaffAssigned Is Nothing Then

					Me.RemovePostSave("CustomerCollectionByStaffAssigned")
					Me._CustomerCollectionByStaffAssigned = Nothing
					Me.OnPropertyChanged("CustomerCollectionByStaffAssigned")

				End If
			End Set				
			
		End Property
		

		private _CustomerCollectionByStaffAssigned As CustomerCollection
		#End Region

		#Region "EmployeeCollectionBySupervisor - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_EmployeeCollectionBySupervisor() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employee.EmployeeCollectionBySupervisor_Delegate)
				map.PropertyName = "EmployeeCollectionBySupervisor"
				map.MyColumnName = "EmployeeID"
				map.ParentColumnName = "Supervisor"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub EmployeeCollectionBySupervisor_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeeQuery(data.NextAlias())
			
			Dim mee As EmployeeQuery = If(data.You IsNot Nothing, TryCast(data.You, EmployeeQuery), New EmployeeQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.Supervisor = mee.EmployeeID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_EmpSupervisor
		''' </summary>

		<XmlIgnore()> _ 
		Public Property EmployeeCollectionBySupervisor As EmployeeCollection 
		
			Get
				If Me._EmployeeCollectionBySupervisor Is Nothing Then
					Me._EmployeeCollectionBySupervisor = New EmployeeCollection()
					Me._EmployeeCollectionBySupervisor.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("EmployeeCollectionBySupervisor", Me._EmployeeCollectionBySupervisor)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._EmployeeCollectionBySupervisor.Query.Where(Me._EmployeeCollectionBySupervisor.Query.Supervisor = Me.EmployeeID)
							Me._EmployeeCollectionBySupervisor.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._EmployeeCollectionBySupervisor.fks.Add(EmployeeMetadata.ColumnNames.Supervisor, Me.EmployeeID)
					End If
				End If

				Return Me._EmployeeCollectionBySupervisor
			End Get
			
			Set(ByVal value As EmployeeCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._EmployeeCollectionBySupervisor Is Nothing Then

					Me.RemovePostSave("EmployeeCollectionBySupervisor")
					Me._EmployeeCollectionBySupervisor = Nothing
					Me.OnPropertyChanged("EmployeeCollectionBySupervisor")

				End If
			End Set				
			
		End Property
		

		private _EmployeeCollectionBySupervisor As EmployeeCollection
		#End Region

		#Region "UpToEmployeeBySupervisor - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_EmpSupervisor
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToEmployeeBySupervisor As Employee
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeeBySupervisor Is Nothing _
						 AndAlso Not Supervisor.Equals(Nothing)  Then
						
					Me._UpToEmployeeBySupervisor = New Employee()
					Me._UpToEmployeeBySupervisor.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeeBySupervisor", Me._UpToEmployeeBySupervisor)
					Me._UpToEmployeeBySupervisor.Query.Where(Me._UpToEmployeeBySupervisor.Query.EmployeeID = Me.Supervisor)
					Me._UpToEmployeeBySupervisor.Query.Load()
				End If

				Return Me._UpToEmployeeBySupervisor
			End Get
			
            Set(ByVal value As Employee)
				Me.RemovePreSave("UpToEmployeeBySupervisor")
				
				Dim changed as Boolean = Me._UpToEmployeeBySupervisor IsNot value

				If value Is Nothing Then
				
					Me.Supervisor = Nothing
				
					Me._UpToEmployeeBySupervisor = Nothing
				Else
				
					Me.Supervisor = value.EmployeeID
					
					Me._UpToEmployeeBySupervisor = value
					Me.SetPreSave("UpToEmployeeBySupervisor", Me._UpToEmployeeBySupervisor)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeeBySupervisor")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToTerritoryCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_EmployeeTerritory_Employee
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToTerritoryCollection As TerritoryCollection
		
			Get
				If Me._UpToTerritoryCollection Is Nothing Then
					Me._UpToTerritoryCollection = New TerritoryCollection()
					Me._UpToTerritoryCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToTerritoryCollection", Me._UpToTerritoryCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.EmployeeID.Equals(Nothing) Then 
				
						Dim m As New TerritoryQuery("m")
						Dim j As New EmployeeTerritoryQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.TerritoryID = j.TerrID)
                        m.Where(j.EmpID = Me.EmployeeID)

						Me._UpToTerritoryCollection.Load(m)

					End If
				End If

				Return Me._UpToTerritoryCollection
			End Get
			
			Set(ByVal value As TerritoryCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToTerritoryCollection Is Nothing Then

					Me.RemovePostSave("UpToTerritoryCollection")
					Me._UpToTerritoryCollection = Nothing
					Me.OnPropertyChanged("UpToTerritoryCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_EmployeeTerritory_Employee
		''' </summary>
		Public Sub AssociateTerritoryCollection(entity As Territory)
			If Me._EmployeeTerritoryCollection Is Nothing Then
				Me._EmployeeTerritoryCollection = New EmployeeTerritoryCollection()
				Me._EmployeeTerritoryCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("EmployeeTerritoryCollection", Me._EmployeeTerritoryCollection)
			End If
			
			Dim obj As EmployeeTerritory = Me._EmployeeTerritoryCollection.AddNew()
			obj.EmpID = Me.EmployeeID
			obj.TerrID = entity.TerritoryID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_EmployeeTerritory_Employee
		''' </summary>
		Public Sub DissociateTerritoryCollection(entity As Territory)
			If Me._EmployeeTerritoryCollection Is Nothing Then
				Me._EmployeeTerritoryCollection = new EmployeeTerritoryCollection()
				Me._EmployeeTerritoryCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("EmployeeTerritoryCollection", Me._EmployeeTerritoryCollection)
			End If

			Dim obj As EmployeeTerritory = Me._EmployeeTerritoryCollection.AddNew()
			obj.EmpID = Me.EmployeeID
            obj.TerrID = entity.TerritoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToTerritoryCollection As TerritoryCollection
		Private _EmployeeTerritoryCollection As EmployeeTerritoryCollection
		#End Region

		#Region "EmployeeTerritoryCollectionByEmpID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_EmployeeTerritoryCollectionByEmpID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employee.EmployeeTerritoryCollectionByEmpID_Delegate)
				map.PropertyName = "EmployeeTerritoryCollectionByEmpID"
				map.MyColumnName = "EmpID"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub EmployeeTerritoryCollectionByEmpID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeeQuery(data.NextAlias())
			
			Dim mee As EmployeeTerritoryQuery = If(data.You IsNot Nothing, TryCast(data.You, EmployeeTerritoryQuery), New EmployeeTerritoryQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.EmpID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_EmployeeTerritory_Employee
		''' </summary>

		<XmlIgnore()> _ 
		Public Property EmployeeTerritoryCollectionByEmpID As EmployeeTerritoryCollection 
		
			Get
				If Me._EmployeeTerritoryCollectionByEmpID Is Nothing Then
					Me._EmployeeTerritoryCollectionByEmpID = New EmployeeTerritoryCollection()
					Me._EmployeeTerritoryCollectionByEmpID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("EmployeeTerritoryCollectionByEmpID", Me._EmployeeTerritoryCollectionByEmpID)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._EmployeeTerritoryCollectionByEmpID.Query.Where(Me._EmployeeTerritoryCollectionByEmpID.Query.EmpID = Me.EmployeeID)
							Me._EmployeeTerritoryCollectionByEmpID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._EmployeeTerritoryCollectionByEmpID.fks.Add(EmployeeTerritoryMetadata.ColumnNames.EmpID, Me.EmployeeID)
					End If
				End If

				Return Me._EmployeeTerritoryCollectionByEmpID
			End Get
			
			Set(ByVal value As EmployeeTerritoryCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._EmployeeTerritoryCollectionByEmpID Is Nothing Then

					Me.RemovePostSave("EmployeeTerritoryCollectionByEmpID")
					Me._EmployeeTerritoryCollectionByEmpID = Nothing
					Me.OnPropertyChanged("EmployeeTerritoryCollectionByEmpID")

				End If
			End Set				
			
		End Property
		

		private _EmployeeTerritoryCollectionByEmpID As EmployeeTerritoryCollection
		#End Region

		#Region "OrderCollectionByEmployeeID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrderCollectionByEmployeeID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employee.OrderCollectionByEmployeeID_Delegate)
				map.PropertyName = "OrderCollectionByEmployeeID"
				map.MyColumnName = "EmployeeID"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrderCollectionByEmployeeID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeeQuery(data.NextAlias())
			
			Dim mee As OrderQuery = If(data.You IsNot Nothing, TryCast(data.You, OrderQuery), New OrderQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.EmployeeID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Order_Employee
		''' </summary>

		<XmlIgnore()> _ 
		Public Property OrderCollectionByEmployeeID As OrderCollection 
		
			Get
				If Me._OrderCollectionByEmployeeID Is Nothing Then
					Me._OrderCollectionByEmployeeID = New OrderCollection()
					Me._OrderCollectionByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrderCollectionByEmployeeID", Me._OrderCollectionByEmployeeID)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrderCollectionByEmployeeID.Query.Where(Me._OrderCollectionByEmployeeID.Query.EmployeeID = Me.EmployeeID)
							Me._OrderCollectionByEmployeeID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrderCollectionByEmployeeID.fks.Add(OrderMetadata.ColumnNames.EmployeeID, Me.EmployeeID)
					End If
				End If

				Return Me._OrderCollectionByEmployeeID
			End Get
			
			Set(ByVal value As OrderCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrderCollectionByEmployeeID Is Nothing Then

					Me.RemovePostSave("OrderCollectionByEmployeeID")
					Me._OrderCollectionByEmployeeID = Nothing
					Me.OnPropertyChanged("OrderCollectionByEmployeeID")

				End If
			End Set				
			
		End Property
		

		private _OrderCollectionByEmployeeID As OrderCollection
		#End Region

		#Region "ReferredEmployeeCollectionByEmployeeID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_ReferredEmployeeCollectionByEmployeeID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employee.ReferredEmployeeCollectionByEmployeeID_Delegate)
				map.PropertyName = "ReferredEmployeeCollectionByEmployeeID"
				map.MyColumnName = "EmployeeID"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub ReferredEmployeeCollectionByEmployeeID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeeQuery(data.NextAlias())
			
			Dim mee As ReferredEmployeeQuery = If(data.You IsNot Nothing, TryCast(data.You, ReferredEmployeeQuery), New ReferredEmployeeQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.EmployeeID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_ReferredEmployee_Employee1
		''' </summary>

		<XmlIgnore()> _ 
		Public Property ReferredEmployeeCollectionByEmployeeID As ReferredEmployeeCollection 
		
			Get
				If Me._ReferredEmployeeCollectionByEmployeeID Is Nothing Then
					Me._ReferredEmployeeCollectionByEmployeeID = New ReferredEmployeeCollection()
					Me._ReferredEmployeeCollectionByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("ReferredEmployeeCollectionByEmployeeID", Me._ReferredEmployeeCollectionByEmployeeID)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._ReferredEmployeeCollectionByEmployeeID.Query.Where(Me._ReferredEmployeeCollectionByEmployeeID.Query.EmployeeID = Me.EmployeeID)
							Me._ReferredEmployeeCollectionByEmployeeID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._ReferredEmployeeCollectionByEmployeeID.fks.Add(ReferredEmployeeMetadata.ColumnNames.EmployeeID, Me.EmployeeID)
					End If
				End If

				Return Me._ReferredEmployeeCollectionByEmployeeID
			End Get
			
			Set(ByVal value As ReferredEmployeeCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._ReferredEmployeeCollectionByEmployeeID Is Nothing Then

					Me.RemovePostSave("ReferredEmployeeCollectionByEmployeeID")
					Me._ReferredEmployeeCollectionByEmployeeID = Nothing
					Me.OnPropertyChanged("ReferredEmployeeCollectionByEmployeeID")

				End If
			End Set				
			
		End Property
		

		private _ReferredEmployeeCollectionByEmployeeID As ReferredEmployeeCollection
		#End Region

		#Region "ReferredEmployeeCollectionByReferredID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_ReferredEmployeeCollectionByReferredID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Employee.ReferredEmployeeCollectionByReferredID_Delegate)
				map.PropertyName = "ReferredEmployeeCollectionByReferredID"
				map.MyColumnName = "ReferredID"
				map.ParentColumnName = "EmployeeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub ReferredEmployeeCollectionByReferredID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New EmployeeQuery(data.NextAlias())
			
			Dim mee As ReferredEmployeeQuery = If(data.You IsNot Nothing, TryCast(data.You, ReferredEmployeeQuery), New ReferredEmployeeQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.EmployeeID = mee.ReferredID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_ReferredEmployee_Employee2
		''' </summary>

		<XmlIgnore()> _ 
		Public Property ReferredEmployeeCollectionByReferredID As ReferredEmployeeCollection 
		
			Get
				If Me._ReferredEmployeeCollectionByReferredID Is Nothing Then
					Me._ReferredEmployeeCollectionByReferredID = New ReferredEmployeeCollection()
					Me._ReferredEmployeeCollectionByReferredID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("ReferredEmployeeCollectionByReferredID", Me._ReferredEmployeeCollectionByReferredID)
				
					If Not Me.EmployeeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._ReferredEmployeeCollectionByReferredID.Query.Where(Me._ReferredEmployeeCollectionByReferredID.Query.ReferredID = Me.EmployeeID)
							Me._ReferredEmployeeCollectionByReferredID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._ReferredEmployeeCollectionByReferredID.fks.Add(ReferredEmployeeMetadata.ColumnNames.ReferredID, Me.EmployeeID)
					End If
				End If

				Return Me._ReferredEmployeeCollectionByReferredID
			End Get
			
			Set(ByVal value As ReferredEmployeeCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._ReferredEmployeeCollectionByReferredID Is Nothing Then

					Me.RemovePostSave("ReferredEmployeeCollectionByReferredID")
					Me._ReferredEmployeeCollectionByReferredID = Nothing
					Me.OnPropertyChanged("ReferredEmployeeCollectionByReferredID")

				End If
			End Set				
			
		End Property
		

		private _ReferredEmployeeCollectionByReferredID As ReferredEmployeeCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "CustomerCollectionByManager"
					coll = Me.CustomerCollectionByManager
					Exit Select
				Case "CustomerCollectionByStaffAssigned"
					coll = Me.CustomerCollectionByStaffAssigned
					Exit Select
				Case "EmployeeCollectionBySupervisor"
					coll = Me.EmployeeCollectionBySupervisor
					Exit Select
				Case "EmployeeTerritoryCollectionByEmpID"
					coll = Me.EmployeeTerritoryCollectionByEmpID
					Exit Select
				Case "OrderCollectionByEmployeeID"
					coll = Me.OrderCollectionByEmployeeID
					Exit Select
				Case "ReferredEmployeeCollectionByEmployeeID"
					coll = Me.ReferredEmployeeCollectionByEmployeeID
					Exit Select
				Case "ReferredEmployeeCollectionByReferredID"
					coll = Me.ReferredEmployeeCollectionByReferredID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "CustomerCollectionByManager", GetType(CustomerCollection), New Customer()))
			props.Add(new esPropertyDescriptor(Me, "CustomerCollectionByStaffAssigned", GetType(CustomerCollection), New Customer()))
			props.Add(new esPropertyDescriptor(Me, "EmployeeCollectionBySupervisor", GetType(EmployeeCollection), New Employee()))
			props.Add(new esPropertyDescriptor(Me, "EmployeeTerritoryCollectionByEmpID", GetType(EmployeeTerritoryCollection), New EmployeeTerritory()))
			props.Add(new esPropertyDescriptor(Me, "OrderCollectionByEmployeeID", GetType(OrderCollection), New Order()))
			props.Add(new esPropertyDescriptor(Me, "ReferredEmployeeCollectionByEmployeeID", GetType(ReferredEmployeeCollection), New ReferredEmployee()))
			props.Add(new esPropertyDescriptor(Me, "ReferredEmployeeCollectionByReferredID", GetType(ReferredEmployeeCollection), New ReferredEmployee()))
			Return props
			
		End Function	
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeBySupervisor Is Nothing Then
				Me.Supervisor = Me._UpToEmployeeBySupervisor.EmployeeID
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
		
			If Not Me._CustomerCollectionByManager Is Nothing Then
				Apply(Me._CustomerCollectionByManager, "Manager", Me.EmployeeID)
			End If
			
			If Not Me._CustomerCollectionByStaffAssigned Is Nothing Then
				Apply(Me._CustomerCollectionByStaffAssigned, "StaffAssigned", Me.EmployeeID)
			End If
			
			If Not Me._EmployeeCollectionBySupervisor Is Nothing Then
				Apply(Me._EmployeeCollectionBySupervisor, "Supervisor", Me.EmployeeID)
			End If
			
			If Not Me._EmployeeTerritoryCollection Is Nothing Then
				Apply(Me._EmployeeTerritoryCollection, "EmpID", Me.EmployeeID)
			End If
			
			If Not Me._EmployeeTerritoryCollectionByEmpID Is Nothing Then
				Apply(Me._EmployeeTerritoryCollectionByEmpID, "EmpID", Me.EmployeeID)
			End If
			
			If Not Me._OrderCollectionByEmployeeID Is Nothing Then
				Apply(Me._OrderCollectionByEmployeeID, "EmployeeID", Me.EmployeeID)
			End If
			
			If Not Me._ReferredEmployeeCollectionByEmployeeID Is Nothing Then
				Apply(Me._ReferredEmployeeCollectionByEmployeeID, "EmployeeID", Me.EmployeeID)
			End If
			
			If Not Me._ReferredEmployeeCollectionByReferredID Is Nothing Then
				Apply(Me._ReferredEmployeeCollectionByReferredID, "ReferredID", Me.EmployeeID)
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Employee")> _
    <XmlType(TypeName:="EmployeeProxyStub")> _
    <Serializable> _
    Partial Public Class EmployeeProxyStub
	
		Public Sub New()
            Me._entity = New Employee()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Employee)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Employee, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As EmployeeProxyStub) As Employee
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Employee)
        End Function
		

		<DataMember(Name:="EmployeeID", Order:=1, EmitDefaultValue:=False)> _		
        Public Property EmployeeID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(EmployeeMetadata.ColumnNames.EmployeeID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.EmployeeID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.EmployeeID = value
			End Set
			
		End Property

		<DataMember(Name:="LastName", Order:=2, EmitDefaultValue:=False)> _		
        Public Property LastName As System.String
        
            Get
                If Me.IncludeColumn(EmployeeMetadata.ColumnNames.LastName) Then
                    Return Me.Entity.LastName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.LastName = value
			End Set
			
		End Property

		<DataMember(Name:="FirstName", Order:=3, EmitDefaultValue:=False)> _		
        Public Property FirstName As System.String
        
            Get
                If Me.IncludeColumn(EmployeeMetadata.ColumnNames.FirstName) Then
                    Return Me.Entity.FirstName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.FirstName = value
			End Set
			
		End Property

		<DataMember(Name:="Supervisor", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Supervisor As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(EmployeeMetadata.ColumnNames.Supervisor) Then
                    Return Me.Entity.Supervisor
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Supervisor = value
			End Set
			
		End Property

		<DataMember(Name:="Age", Order:=5, EmitDefaultValue:=False)> _		
        Public Property Age As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(EmployeeMetadata.ColumnNames.Age) Then
                    Return Me.Entity.Age
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Age = value
			End Set
			
		End Property


		<DataMember(Name := "esRowState", Order := 10000)> _
        Public Property esRowState As String
            Get
				Return Me.TheRowState
            End Get

            Set 
				Me.TheRowState = value
            End Set
        End Property
		
		<DataMember(Name := "ModifiedColumns", Order := 10001, EmitDefaultValue := False)> _
		Private Property ModifiedColumns() As List(Of String)
			Get
				Return Entity.es.ModifiedColumns
			End Get
			Set(ByVal value As List(Of String))
				Entity.es.ModifiedColumns.AddRange(value)
			End Set
		End Property		
		
		<DataMember(Name := "ExtraColumns", Order := 10002, EmitDefaultValue := False)> _
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
        Public Property Entity As Employee
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Employee()
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
        Public _entity As Employee
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="EmployeeCollection")> _
    <XmlType(TypeName:="EmployeeCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class EmployeeCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Employee))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Employee), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As EmployeeCollectionProxyStub) As EmployeeCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Employee)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Employee), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Employee In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New EmployeeProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New EmployeeProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Employee In coll.es.DeletedEntities
                    Collection.Add(New EmployeeProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of EmployeeProxyStub)		

        Public Function GetCollection As EmployeeCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New EmployeeCollection()
					
		            Dim proxy As EmployeeProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As EmployeeCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class EmployeeMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(EmployeeMetadata.ColumnNames.EmployeeID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeeMetadata.PropertyNames.EmployeeID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeeMetadata.ColumnNames.LastName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeeMetadata.PropertyNames.LastName
			c.CharacterMaxLength = 25
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeeMetadata.ColumnNames.FirstName, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = EmployeeMetadata.PropertyNames.FirstName
			c.CharacterMaxLength = 25
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeeMetadata.ColumnNames.Supervisor, 3, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeeMetadata.PropertyNames.Supervisor
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeeMetadata.ColumnNames.Age, 4, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeeMetadata.PropertyNames.Age
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As EmployeeMetadata
			Return _meta
		End Function
		
		Public ReadOnly Property DataID() As System.Guid Implements IMetadata.DataID
			Get
				Return MyBase.m_dataID
			End Get
		End Property

		Public ReadOnly Property MultiProviderMode() As Boolean Implements IMetadata.MultiProviderMode
			Get
				Return true
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
			 Public Const Supervisor As String = "Supervisor"
			 Public Const Age As String = "Age"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const LastName As String = "LastName"
			 Public Const FirstName As String = "FirstName"
			 Public Const Supervisor As String = "Supervisor"
			 Public Const Age As String = "Age"
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
			SyncLock GetType(EmployeeMetadata)
			
				If EmployeeMetadata.mapDelegates Is Nothing Then
					EmployeeMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If EmployeeMetadata._meta Is Nothing Then
					EmployeeMetadata._meta = New EmployeeMetadata()
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
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("Supervisor", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "Employee"
				meta.Destination = "Employee"
				
				meta.spInsert = "proc_EmployeeInsert"
				meta.spUpdate = "proc_EmployeeUpdate"
				meta.spDelete = "proc_EmployeeDelete"
				meta.spLoadAll = "proc_EmployeeLoadAll"
				meta.spLoadByPrimaryKey = "proc_EmployeeLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As EmployeeMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
