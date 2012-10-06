
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : SQL
' Date Generated       : 3/17/2012 4:51:50 AM
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
	' Test table description Multi-line test "C:\Test\"
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(AggregateTest))> _
	<XmlType("AggregateTest")> _ 
	<Table(Name:="AggregateTest")> _	
	Partial Public Class AggregateTest 
		Inherits esAggregateTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New AggregateTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.Int32)
			Dim obj As New AggregateTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New AggregateTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As AggregateTest) As AggregateTestProxyStub
			Return New AggregateTestProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Id As Nullable(Of System.Int32)
			Get
				Return MyBase.Id
			End Get
			Set
				MyBase.Id = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DepartmentID As Nullable(Of System.Int32)
			Get
				Return MyBase.DepartmentID
			End Get
			Set
				MyBase.DepartmentID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property FirstName As System.String
			Get
				Return MyBase.FirstName
			End Get
			Set
				MyBase.FirstName = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property LastName As System.String
			Get
				Return MyBase.LastName
			End Get
			Set
				MyBase.LastName = value
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

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property HireDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.HireDate
			End Get
			Set
				MyBase.HireDate = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Salary As Nullable(Of System.Decimal)
			Get
				Return MyBase.Salary
			End Get
			Set
				MyBase.Salary = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property IsActive As Nullable(Of System.Boolean)
			Get
				Return MyBase.IsActive
			End Get
			Set
				MyBase.IsActive = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("AggregateTestCollection")> _
	Partial Public Class AggregateTestCollection
		Inherits esAggregateTestCollection
		Implements IEnumerable(Of AggregateTest)
	
		Public Function FindByPrimaryKey(ByVal id As System.Int32) As AggregateTest
			Return MyBase.SingleOrDefault(Function(e) e.Id.HasValue AndAlso e.Id.Value = id)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As AggregateTestCollection) As AggregateTestCollectionProxyStub
            Return New AggregateTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(AggregateTest))> _
		Public Class AggregateTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of AggregateTestCollection)
			
			Public Shared Widening Operator CType(packet As AggregateTestCollectionWCFPacket) As AggregateTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As AggregateTestCollection) As AggregateTestCollectionWCFPacket
				Return New AggregateTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "AggregateTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class AggregateTestQuery 
		Inherits esAggregateTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "AggregateTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As AggregateTestQuery) As String
			Return AggregateTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As AggregateTestQuery
			Return DirectCast(AggregateTestQuery.SerializeHelper.FromXml(query, GetType(AggregateTestQuery)), AggregateTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esAggregateTest
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal id As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal id As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal id As System.Int32) As Boolean
		
			Dim query As New AggregateTestQuery()
			query.Where(query.Id = id)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal id As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("Id", id)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to AggregateTest.ID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Id As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(AggregateTestMetadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(AggregateTestMetadata.ColumnNames.Id, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to AggregateTest.DepartmentID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DepartmentID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(AggregateTestMetadata.ColumnNames.DepartmentID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(AggregateTestMetadata.ColumnNames.DepartmentID, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.DepartmentID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to AggregateTest.FirstName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property FirstName As System.String
			Get
				Return MyBase.GetSystemString(AggregateTestMetadata.ColumnNames.FirstName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(AggregateTestMetadata.ColumnNames.FirstName, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.FirstName)
				End If
			End Set
		End Property	
			
		' <summary>
		' LastName column Multi-line test. "C:\Test\"
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property LastName As System.String
			Get
				Return MyBase.GetSystemString(AggregateTestMetadata.ColumnNames.LastName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(AggregateTestMetadata.ColumnNames.LastName, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.LastName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to AggregateTest.Age
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Age As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(AggregateTestMetadata.ColumnNames.Age)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(AggregateTestMetadata.ColumnNames.Age, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.Age)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to AggregateTest.HireDate
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property HireDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(AggregateTestMetadata.ColumnNames.HireDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(AggregateTestMetadata.ColumnNames.HireDate, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.HireDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to AggregateTest.Salary
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Salary As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(AggregateTestMetadata.ColumnNames.Salary)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(AggregateTestMetadata.ColumnNames.Salary, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.Salary)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to AggregateTest.IsActive
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property IsActive As Nullable(Of System.Boolean)
			Get
				Return MyBase.GetSystemBoolean(AggregateTestMetadata.ColumnNames.IsActive)
			End Get
			
			Set(ByVal value As Nullable(Of System.Boolean))
				If MyBase.SetSystemBoolean(AggregateTestMetadata.ColumnNames.IsActive, value) Then
					OnPropertyChanged(AggregateTestMetadata.PropertyNames.IsActive)
				End If
			End Set
		End Property	
		
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
												
						Case "Id"
							Me.str().Id = CType(value, string)
												
						Case "DepartmentID"
							Me.str().DepartmentID = CType(value, string)
												
						Case "FirstName"
							Me.str().FirstName = CType(value, string)
												
						Case "LastName"
							Me.str().LastName = CType(value, string)
												
						Case "Age"
							Me.str().Age = CType(value, string)
												
						Case "HireDate"
							Me.str().HireDate = CType(value, string)
												
						Case "Salary"
							Me.str().Salary = CType(value, string)
												
						Case "IsActive"
							Me.str().IsActive = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "Id"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Id = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.Id)
							End If
						
						Case "DepartmentID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.DepartmentID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.DepartmentID)
							End If
						
						Case "Age"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Age = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.Age)
							End If
						
						Case "HireDate"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.HireDate = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.HireDate)
							End If
						
						Case "Salary"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.Salary = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.Salary)
							End If
						
						Case "IsActive"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Boolean" Then
								Me.IsActive = CType(value, Nullable(Of System.Boolean))
								OnPropertyChanged(AggregateTestMetadata.PropertyNames.IsActive)
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
		
			Public Sub New(ByVal entity As esAggregateTest)
				Me.entity = entity
			End Sub				
		
	
			Public Property Id As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.Id
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Id = Nothing
					Else
						entity.Id = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property DepartmentID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.DepartmentID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DepartmentID = Nothing
					Else
						entity.DepartmentID = Convert.ToInt32(Value)
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
		  	
			Public Property HireDate As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.HireDate
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.HireDate = Nothing
					Else
						entity.HireDate = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property Salary As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.Salary
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Salary = Nothing
					Else
						entity.Salary = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property IsActive As System.String 
				Get
					Dim data_ As Nullable(Of System.Boolean) = entity.IsActive
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.IsActive = Nothing
					Else
						entity.IsActive = Convert.ToBoolean(Value)
					End If
				End Set
			End Property
		  

			Private entity As esAggregateTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return AggregateTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As AggregateTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New AggregateTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As AggregateTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As AggregateTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As AggregateTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esAggregateTestCollection
		Inherits CollectionBase(Of AggregateTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return AggregateTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "AggregateTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As AggregateTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New AggregateTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As AggregateTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New AggregateTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As AggregateTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, AggregateTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As AggregateTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esAggregateTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return AggregateTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "DepartmentID" 
					Return Me.DepartmentID
				Case "FirstName" 
					Return Me.FirstName
				Case "LastName" 
					Return Me.LastName
				Case "Age" 
					Return Me.Age
				Case "HireDate" 
					Return Me.HireDate
				Case "Salary" 
					Return Me.Salary
				Case "IsActive" 
					Return Me.IsActive
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.Id, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property DepartmentID As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.DepartmentID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property FirstName As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.FirstName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property LastName As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.LastName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Age As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.Age, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property HireDate As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.HireDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property Salary As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.Salary, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property IsActive As esQueryItem
			Get
				Return New esQueryItem(Me, AggregateTestMetadata.ColumnNames.IsActive, esSystemType.Boolean)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="AggregateTest")> _
    <XmlType(TypeName:="AggregateTestProxyStub")> _
    <Serializable> _
    Partial Public Class AggregateTestProxyStub
	
		Public Sub New()
            Me._entity = New AggregateTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As AggregateTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As AggregateTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As AggregateTestProxyStub) As AggregateTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(AggregateTest)
        End Function
		

		<DataMember(Name:="Id", Order:=1, EmitDefaultValue:=False)> _		
        Public Property Id As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(AggregateTestMetadata.ColumnNames.Id)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.Id
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Id = value
			End Set
			
		End Property

		<DataMember(Name:="DepartmentID", Order:=2, EmitDefaultValue:=False)> _		
        Public Property DepartmentID As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(AggregateTestMetadata.ColumnNames.DepartmentID) Then
                    Return Me.Entity.DepartmentID
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.DepartmentID = value
			End Set
			
		End Property

		<DataMember(Name:="FirstName", Order:=3, EmitDefaultValue:=False)> _		
        Public Property FirstName As System.String
        
            Get
                If Me.IncludeColumn(AggregateTestMetadata.ColumnNames.FirstName) Then
                    Return Me.Entity.FirstName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.FirstName = value
			End Set
			
		End Property

		<DataMember(Name:="LastName", Order:=4, EmitDefaultValue:=False)> _		
        Public Property LastName As System.String
        
            Get
                If Me.IncludeColumn(AggregateTestMetadata.ColumnNames.LastName) Then
                    Return Me.Entity.LastName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.LastName = value
			End Set
			
		End Property

		<DataMember(Name:="Age", Order:=5, EmitDefaultValue:=False)> _		
        Public Property Age As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(AggregateTestMetadata.ColumnNames.Age) Then
                    Return Me.Entity.Age
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Age = value
			End Set
			
		End Property

		<DataMember(Name:="HireDate", Order:=6, EmitDefaultValue:=False)> _		
        Public Property HireDate As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(AggregateTestMetadata.ColumnNames.HireDate) Then
                    Return Me.Entity.HireDate
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.HireDate = value
			End Set
			
		End Property

		<DataMember(Name:="Salary", Order:=7, EmitDefaultValue:=False)> _		
        Public Property Salary As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(AggregateTestMetadata.ColumnNames.Salary) Then
                    Return Me.Entity.Salary
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.Salary = value
			End Set
			
		End Property

		<DataMember(Name:="IsActive", Order:=8, EmitDefaultValue:=False)> _		
        Public Property IsActive As Nullable(Of System.Boolean)
        
            Get
                If Me.IncludeColumn(AggregateTestMetadata.ColumnNames.IsActive) Then
                    Return Me.Entity.IsActive
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Boolean))
				Me.Entity.IsActive = value
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
        Public Property Entity As AggregateTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New AggregateTest()
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
        Public _entity As AggregateTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="AggregateTestCollection")> _
    <XmlType(TypeName:="AggregateTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class AggregateTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of AggregateTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of AggregateTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As AggregateTestCollectionProxyStub) As AggregateTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(AggregateTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of AggregateTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As AggregateTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New AggregateTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New AggregateTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As AggregateTest In coll.es.DeletedEntities
                    Collection.Add(New AggregateTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of AggregateTestProxyStub)		

        Public Function GetCollection As AggregateTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New AggregateTestCollection()
					
		            Dim proxy As AggregateTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As AggregateTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class AggregateTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.Id, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.DepartmentID, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.DepartmentID
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.FirstName, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.FirstName
			c.CharacterMaxLength = 25
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.LastName, 3, GetType(System.String), esSystemType.String)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.LastName
			c.CharacterMaxLength = 15
			c.Description = "LastName column Multi-line test. ""C:\Test\"""
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.Age, 4, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.Age
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.HireDate, 5, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.HireDate
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.Salary, 6, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.Salary
			c.NumericPrecision = 8
			c.NumericScale = 4
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(AggregateTestMetadata.ColumnNames.IsActive, 7, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = AggregateTestMetadata.PropertyNames.IsActive
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As AggregateTestMetadata
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
			 Public Const Id As String = "ID"
			 Public Const DepartmentID As String = "DepartmentID"
			 Public Const FirstName As String = "FirstName"
			 Public Const LastName As String = "LastName"
			 Public Const Age As String = "Age"
			 Public Const HireDate As String = "HireDate"
			 Public Const Salary As String = "Salary"
			 Public Const IsActive As String = "IsActive"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const DepartmentID As String = "DepartmentID"
			 Public Const FirstName As String = "FirstName"
			 Public Const LastName As String = "LastName"
			 Public Const Age As String = "Age"
			 Public Const HireDate As String = "HireDate"
			 Public Const Salary As String = "Salary"
			 Public Const IsActive As String = "IsActive"
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
			SyncLock GetType(AggregateTestMetadata)
			
				If AggregateTestMetadata.mapDelegates Is Nothing Then
					AggregateTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If AggregateTestMetadata._meta Is Nothing Then
					AggregateTestMetadata._meta = New AggregateTestMetadata()
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
				


				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("DepartmentID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("HireDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("Salary", new esTypeMap("numeric", "System.Decimal"))
				meta.AddTypeMap("IsActive", new esTypeMap("bit", "System.Boolean"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "AggregateTest"
				meta.Destination = "AggregateTest"
				
				meta.spInsert = "proc_AggregateTestInsert"
				meta.spUpdate = "proc_AggregateTestUpdate"
				meta.spDelete = "proc_AggregateTestDelete"
				meta.spLoadAll = "proc_AggregateTestLoadAll"
				meta.spLoadByPrimaryKey = "proc_AggregateTestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As AggregateTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
