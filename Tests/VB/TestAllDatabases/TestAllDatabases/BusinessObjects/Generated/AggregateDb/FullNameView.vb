
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
	' Multi-line View Description
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(FullNameView))> _
	<XmlType("FullNameView")> _ 
	<Table(Name:="FullNameView")> _	
	Partial Public Class FullNameView 
		Inherits esFullNameView
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New FullNameView()
		End Function
		
		#Region "Static Quick Access Methods"
		
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As FullNameView) As FullNameViewProxyStub
			Return New FullNameViewProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property FullName As System.String
			Get
				Return MyBase.FullName
			End Get
			Set
				MyBase.FullName = value
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
	<XmlType("FullNameViewCollection")> _
	Partial Public Class FullNameViewCollection
		Inherits esFullNameViewCollection
		Implements IEnumerable(Of FullNameView)
	

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As FullNameViewCollection) As FullNameViewCollectionProxyStub
            Return New FullNameViewCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(FullNameView))> _
		Public Class FullNameViewCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of FullNameViewCollection)
			
			Public Shared Widening Operator CType(packet As FullNameViewCollectionWCFPacket) As FullNameViewCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As FullNameViewCollection) As FullNameViewCollectionWCFPacket
				Return New FullNameViewCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "FullNameViewQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class FullNameViewQuery 
		Inherits esFullNameViewQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "FullNameViewQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As FullNameViewQuery) As String
			Return FullNameViewQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As FullNameViewQuery
			Return DirectCast(FullNameViewQuery.SerializeHelper.FromXml(query, GetType(FullNameViewQuery)), FullNameViewQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esFullNameView
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to FullNameView.FullName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property FullName As System.String
			Get
				Return MyBase.GetSystemString(FullNameViewMetadata.ColumnNames.FullName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(FullNameViewMetadata.ColumnNames.FullName, value) Then
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.FullName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to FullNameView.DepartmentID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DepartmentID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(FullNameViewMetadata.ColumnNames.DepartmentID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(FullNameViewMetadata.ColumnNames.DepartmentID, value) Then
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.DepartmentID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to FullNameView.HireDate
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property HireDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(FullNameViewMetadata.ColumnNames.HireDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(FullNameViewMetadata.ColumnNames.HireDate, value) Then
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.HireDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to FullNameView.Salary
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Salary As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(FullNameViewMetadata.ColumnNames.Salary)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(FullNameViewMetadata.ColumnNames.Salary, value) Then
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.Salary)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to FullNameView.IsActive
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property IsActive As Nullable(Of System.Boolean)
			Get
				Return MyBase.GetSystemBoolean(FullNameViewMetadata.ColumnNames.IsActive)
			End Get
			
			Set(ByVal value As Nullable(Of System.Boolean))
				If MyBase.SetSystemBoolean(FullNameViewMetadata.ColumnNames.IsActive, value) Then
					OnPropertyChanged(FullNameViewMetadata.PropertyNames.IsActive)
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
												
						Case "FullName"
							Me.str().FullName = CType(value, string)
												
						Case "DepartmentID"
							Me.str().DepartmentID = CType(value, string)
												
						Case "HireDate"
							Me.str().HireDate = CType(value, string)
												
						Case "Salary"
							Me.str().Salary = CType(value, string)
												
						Case "IsActive"
							Me.str().IsActive = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "DepartmentID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.DepartmentID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.DepartmentID)
							End If
						
						Case "HireDate"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.HireDate = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.HireDate)
							End If
						
						Case "Salary"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.Salary = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.Salary)
							End If
						
						Case "IsActive"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Boolean" Then
								Me.IsActive = CType(value, Nullable(Of System.Boolean))
								OnPropertyChanged(FullNameViewMetadata.PropertyNames.IsActive)
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
		
			Public Sub New(ByVal entity As esFullNameView)
				Me.entity = entity
			End Sub				
		
	
			Public Property FullName As System.String 
				Get
					Dim data_ As System.String = entity.FullName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.FullName = Nothing
					Else
						entity.FullName = Convert.ToString(Value)
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
		  

			Private entity As esFullNameView
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return FullNameViewMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As FullNameViewQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New FullNameViewQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As FullNameViewQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As FullNameViewQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As FullNameViewQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esFullNameViewCollection
		Inherits CollectionBase(Of FullNameView)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return FullNameViewMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "FullNameViewCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As FullNameViewQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New FullNameViewQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As FullNameViewQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New FullNameViewQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As FullNameViewQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, FullNameViewQuery))
		End Sub
		
		#End Region
						
		Private m_query As FullNameViewQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esFullNameViewQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return FullNameViewMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "FullName" 
					Return Me.FullName
				Case "DepartmentID" 
					Return Me.DepartmentID
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


		Public ReadOnly Property FullName As esQueryItem
			Get
				Return New esQueryItem(Me, FullNameViewMetadata.ColumnNames.FullName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property DepartmentID As esQueryItem
			Get
				Return New esQueryItem(Me, FullNameViewMetadata.ColumnNames.DepartmentID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property HireDate As esQueryItem
			Get
				Return New esQueryItem(Me, FullNameViewMetadata.ColumnNames.HireDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property Salary As esQueryItem
			Get
				Return New esQueryItem(Me, FullNameViewMetadata.ColumnNames.Salary, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property IsActive As esQueryItem
			Get
				Return New esQueryItem(Me, FullNameViewMetadata.ColumnNames.IsActive, esSystemType.Boolean)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="FullNameView")> _
    <XmlType(TypeName:="FullNameViewProxyStub")> _
    <Serializable> _
    Partial Public Class FullNameViewProxyStub
	
		Public Sub New()
            Me._entity = New FullNameView()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As FullNameView)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As FullNameView, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As FullNameViewProxyStub) As FullNameView
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(FullNameView)
        End Function
		

		<DataMember(Name:="FullName", Order:=1, EmitDefaultValue:=False)> _		
        Public Property FullName As System.String
        
            Get
                If Me.IncludeColumn(FullNameViewMetadata.ColumnNames.FullName) Then
                    Return Me.Entity.FullName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.FullName = value
			End Set
			
		End Property

		<DataMember(Name:="DepartmentID", Order:=2, EmitDefaultValue:=False)> _		
        Public Property DepartmentID As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(FullNameViewMetadata.ColumnNames.DepartmentID) Then
                    Return Me.Entity.DepartmentID
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.DepartmentID = value
			End Set
			
		End Property

		<DataMember(Name:="HireDate", Order:=3, EmitDefaultValue:=False)> _		
        Public Property HireDate As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(FullNameViewMetadata.ColumnNames.HireDate) Then
                    Return Me.Entity.HireDate
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.HireDate = value
			End Set
			
		End Property

		<DataMember(Name:="Salary", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Salary As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(FullNameViewMetadata.ColumnNames.Salary) Then
                    Return Me.Entity.Salary
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.Salary = value
			End Set
			
		End Property

		<DataMember(Name:="IsActive", Order:=5, EmitDefaultValue:=False)> _		
        Public Property IsActive As Nullable(Of System.Boolean)
        
            Get
                If Me.IncludeColumn(FullNameViewMetadata.ColumnNames.IsActive) Then
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
        Public Property Entity As FullNameView
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New FullNameView()
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
        Public _entity As FullNameView
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="FullNameViewCollection")> _
    <XmlType(TypeName:="FullNameViewCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class FullNameViewCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of FullNameView))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of FullNameView), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As FullNameViewCollectionProxyStub) As FullNameViewCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(FullNameView)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of FullNameView), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As FullNameView In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New FullNameViewProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New FullNameViewProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As FullNameView In coll.es.DeletedEntities
                    Collection.Add(New FullNameViewProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of FullNameViewProxyStub)		

        Public Function GetCollection As FullNameViewCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New FullNameViewCollection()
					
		            Dim proxy As FullNameViewProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As FullNameViewCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class FullNameViewMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(FullNameViewMetadata.ColumnNames.FullName, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = FullNameViewMetadata.PropertyNames.FullName
			c.CharacterMaxLength = 42
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(FullNameViewMetadata.ColumnNames.DepartmentID, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = FullNameViewMetadata.PropertyNames.DepartmentID
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(FullNameViewMetadata.ColumnNames.HireDate, 2, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = FullNameViewMetadata.PropertyNames.HireDate
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(FullNameViewMetadata.ColumnNames.Salary, 3, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = FullNameViewMetadata.PropertyNames.Salary
			c.NumericPrecision = 8
			c.NumericScale = 4
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(FullNameViewMetadata.ColumnNames.IsActive, 4, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = FullNameViewMetadata.PropertyNames.IsActive
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As FullNameViewMetadata
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
			 Public Const FullName As String = "FullName"
			 Public Const DepartmentID As String = "DepartmentID"
			 Public Const HireDate As String = "HireDate"
			 Public Const Salary As String = "Salary"
			 Public Const IsActive As String = "IsActive"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const FullName As String = "FullName"
			 Public Const DepartmentID As String = "DepartmentID"
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
			SyncLock GetType(FullNameViewMetadata)
			
				If FullNameViewMetadata.mapDelegates Is Nothing Then
					FullNameViewMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If FullNameViewMetadata._meta Is Nothing Then
					FullNameViewMetadata._meta = New FullNameViewMetadata()
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
				


				meta.AddTypeMap("FullName", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("DepartmentID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("HireDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("Salary", new esTypeMap("numeric", "System.Decimal"))
				meta.AddTypeMap("IsActive", new esTypeMap("bit", "System.Boolean"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "FullNameView"
				meta.Destination = "FullNameView"
				
				meta.spInsert = "proc_FullNameViewInsert"
				meta.spUpdate = "proc_FullNameViewUpdate"
				meta.spDelete = "proc_FullNameViewDelete"
				meta.spLoadAll = "proc_FullNameViewLoadAll"
				meta.spLoadByPrimaryKey = "proc_FullNameViewLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As FullNameViewMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
