
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
	' Encapsulates the 'ConstructorTest' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(ConstructorTest))> _
	<XmlType("ConstructorTest")> _ 
	<Table(Name:="ConstructorTest")> _	
	Partial Public Class ConstructorTest 
		Inherits esConstructorTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New ConstructorTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal constructorTestId As System.Int64)
			Dim obj As New ConstructorTest()
			obj.ConstructorTestId = constructorTestId
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal constructorTestId As System.Int64, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New ConstructorTest()
			obj.ConstructorTestId = constructorTestId
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ConstructorTest) As ConstructorTestProxyStub
			Return New ConstructorTestProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property ConstructorTestId As Nullable(Of System.Int64)
			Get
				Return MyBase.ConstructorTestId
			End Get
			Set
				MyBase.ConstructorTestId = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DefaultInt As Nullable(Of System.Int32)
			Get
				Return MyBase.DefaultInt
			End Get
			Set
				MyBase.DefaultInt = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DefaultBool As Nullable(Of System.Boolean)
			Get
				Return MyBase.DefaultBool
			End Get
			Set
				MyBase.DefaultBool = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DefaultDateTime As Nullable(Of System.DateTime)
			Get
				Return MyBase.DefaultDateTime
			End Get
			Set
				MyBase.DefaultDateTime = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DefaultString As System.String
			Get
				Return MyBase.DefaultString
			End Get
			Set
				MyBase.DefaultString = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ConstructorTestCollection")> _
	Partial Public Class ConstructorTestCollection
		Inherits esConstructorTestCollection
		Implements IEnumerable(Of ConstructorTest)
	
		Public Function FindByPrimaryKey(ByVal constructorTestId As System.Int64) As ConstructorTest
			Return MyBase.SingleOrDefault(Function(e) e.ConstructorTestId.HasValue AndAlso e.ConstructorTestId.Value = constructorTestId)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ConstructorTestCollection) As ConstructorTestCollectionProxyStub
            Return New ConstructorTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(ConstructorTest))> _
		Public Class ConstructorTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ConstructorTestCollection)
			
			Public Shared Widening Operator CType(packet As ConstructorTestCollectionWCFPacket) As ConstructorTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ConstructorTestCollection) As ConstructorTestCollectionWCFPacket
				Return New ConstructorTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ConstructorTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ConstructorTestQuery 
		Inherits esConstructorTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ConstructorTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ConstructorTestQuery) As String
			Return ConstructorTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ConstructorTestQuery
			Return DirectCast(ConstructorTestQuery.SerializeHelper.FromXml(query, GetType(ConstructorTestQuery)), ConstructorTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esConstructorTest
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal constructorTestId As System.Int64) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(constructorTestId)
			Else
				Return LoadByPrimaryKeyStoredProcedure(constructorTestId)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal constructorTestId As System.Int64) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(constructorTestId)
			Else
				Return LoadByPrimaryKeyStoredProcedure(constructorTestId)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal constructorTestId As System.Int64) As Boolean
		
			Dim query As New ConstructorTestQuery()
			query.Where(query.ConstructorTestId = constructorTestId)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal constructorTestId As System.Int64) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("ConstructorTestId", constructorTestId)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to ConstructorTest.ConstructorTestId
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ConstructorTestId As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(ConstructorTestMetadata.ColumnNames.ConstructorTestId)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(ConstructorTestMetadata.ColumnNames.ConstructorTestId, value) Then
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.ConstructorTestId)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConstructorTest.DefaultInt
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DefaultInt As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ConstructorTestMetadata.ColumnNames.DefaultInt)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ConstructorTestMetadata.ColumnNames.DefaultInt, value) Then
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultInt)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConstructorTest.DefaultBool
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DefaultBool As Nullable(Of System.Boolean)
			Get
				Return MyBase.GetSystemBoolean(ConstructorTestMetadata.ColumnNames.DefaultBool)
			End Get
			
			Set(ByVal value As Nullable(Of System.Boolean))
				If MyBase.SetSystemBoolean(ConstructorTestMetadata.ColumnNames.DefaultBool, value) Then
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultBool)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConstructorTest.DefaultDateTime
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DefaultDateTime As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(ConstructorTestMetadata.ColumnNames.DefaultDateTime)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(ConstructorTestMetadata.ColumnNames.DefaultDateTime, value) Then
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultDateTime)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConstructorTest.DefaultString
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DefaultString As System.String
			Get
				Return MyBase.GetSystemString(ConstructorTestMetadata.ColumnNames.DefaultString)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ConstructorTestMetadata.ColumnNames.DefaultString, value) Then
					OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultString)
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
												
						Case "ConstructorTestId"
							Me.str().ConstructorTestId = CType(value, string)
												
						Case "DefaultInt"
							Me.str().DefaultInt = CType(value, string)
												
						Case "DefaultBool"
							Me.str().DefaultBool = CType(value, string)
												
						Case "DefaultDateTime"
							Me.str().DefaultDateTime = CType(value, string)
												
						Case "DefaultString"
							Me.str().DefaultString = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "ConstructorTestId"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.ConstructorTestId = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.ConstructorTestId)
							End If
						
						Case "DefaultInt"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.DefaultInt = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultInt)
							End If
						
						Case "DefaultBool"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Boolean" Then
								Me.DefaultBool = CType(value, Nullable(Of System.Boolean))
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultBool)
							End If
						
						Case "DefaultDateTime"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.DefaultDateTime = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(ConstructorTestMetadata.PropertyNames.DefaultDateTime)
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
		
			Public Sub New(ByVal entity As esConstructorTest)
				Me.entity = entity
			End Sub				
		
	
			Public Property ConstructorTestId As System.String 
				Get
					Dim data_ As Nullable(Of System.Int64) = entity.ConstructorTestId
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ConstructorTestId = Nothing
					Else
						entity.ConstructorTestId = Convert.ToInt64(Value)
					End If
				End Set
			End Property
		  	
			Public Property DefaultInt As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.DefaultInt
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DefaultInt = Nothing
					Else
						entity.DefaultInt = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property DefaultBool As System.String 
				Get
					Dim data_ As Nullable(Of System.Boolean) = entity.DefaultBool
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DefaultBool = Nothing
					Else
						entity.DefaultBool = Convert.ToBoolean(Value)
					End If
				End Set
			End Property
		  	
			Public Property DefaultDateTime As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.DefaultDateTime
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DefaultDateTime = Nothing
					Else
						entity.DefaultDateTime = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property DefaultString As System.String 
				Get
					Dim data_ As System.String = entity.DefaultString
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DefaultString = Nothing
					Else
						entity.DefaultString = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esConstructorTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ConstructorTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ConstructorTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ConstructorTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ConstructorTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ConstructorTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ConstructorTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esConstructorTestCollection
		Inherits CollectionBase(Of ConstructorTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ConstructorTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ConstructorTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ConstructorTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ConstructorTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ConstructorTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ConstructorTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ConstructorTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ConstructorTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As ConstructorTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esConstructorTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ConstructorTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "ConstructorTestId" 
					Return Me.ConstructorTestId
				Case "DefaultInt" 
					Return Me.DefaultInt
				Case "DefaultBool" 
					Return Me.DefaultBool
				Case "DefaultDateTime" 
					Return Me.DefaultDateTime
				Case "DefaultString" 
					Return Me.DefaultString
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property ConstructorTestId As esQueryItem
			Get
				Return New esQueryItem(Me, ConstructorTestMetadata.ColumnNames.ConstructorTestId, esSystemType.Int64)
			End Get
		End Property 
		
		Public ReadOnly Property DefaultInt As esQueryItem
			Get
				Return New esQueryItem(Me, ConstructorTestMetadata.ColumnNames.DefaultInt, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property DefaultBool As esQueryItem
			Get
				Return New esQueryItem(Me, ConstructorTestMetadata.ColumnNames.DefaultBool, esSystemType.Boolean)
			End Get
		End Property 
		
		Public ReadOnly Property DefaultDateTime As esQueryItem
			Get
				Return New esQueryItem(Me, ConstructorTestMetadata.ColumnNames.DefaultDateTime, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property DefaultString As esQueryItem
			Get
				Return New esQueryItem(Me, ConstructorTestMetadata.ColumnNames.DefaultString, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="ConstructorTest")> _
    <XmlType(TypeName:="ConstructorTestProxyStub")> _
    <Serializable> _
    Partial Public Class ConstructorTestProxyStub
	
		Public Sub New()
            Me._entity = New ConstructorTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ConstructorTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ConstructorTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ConstructorTestProxyStub) As ConstructorTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(ConstructorTest)
        End Function
		

		<DataMember(Name:="ConstructorTestId", Order:=1, EmitDefaultValue:=False)> _		
        Public Property ConstructorTestId As Nullable(Of System.Int64)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ConstructorTestMetadata.ColumnNames.ConstructorTestId)
					Return CType(o, Nullable(Of System.Int64))
                Else
					Return Me.Entity.ConstructorTestId
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.ConstructorTestId = value
			End Set
			
		End Property

		<DataMember(Name:="DefaultInt", Order:=2, EmitDefaultValue:=False)> _		
        Public Property DefaultInt As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultInt) Then
                    Return Me.Entity.DefaultInt
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.DefaultInt = value
			End Set
			
		End Property

		<DataMember(Name:="DefaultBool", Order:=3, EmitDefaultValue:=False)> _		
        Public Property DefaultBool As Nullable(Of System.Boolean)
        
            Get
                If Me.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultBool) Then
                    Return Me.Entity.DefaultBool
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Boolean))
				Me.Entity.DefaultBool = value
			End Set
			
		End Property

		<DataMember(Name:="DefaultDateTime", Order:=4, EmitDefaultValue:=False)> _		
        Public Property DefaultDateTime As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultDateTime) Then
                    Return Me.Entity.DefaultDateTime
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.DefaultDateTime = value
			End Set
			
		End Property

		<DataMember(Name:="DefaultString", Order:=5, EmitDefaultValue:=False)> _		
        Public Property DefaultString As System.String
        
            Get
                If Me.IncludeColumn(ConstructorTestMetadata.ColumnNames.DefaultString) Then
                    Return Me.Entity.DefaultString
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.DefaultString = value
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
        Public Property Entity As ConstructorTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New ConstructorTest()
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
        Public _entity As ConstructorTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ConstructorTestCollection")> _
    <XmlType(TypeName:="ConstructorTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ConstructorTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of ConstructorTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of ConstructorTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ConstructorTestCollectionProxyStub) As ConstructorTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(ConstructorTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of ConstructorTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As ConstructorTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ConstructorTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ConstructorTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As ConstructorTest In coll.es.DeletedEntities
                    Collection.Add(New ConstructorTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ConstructorTestProxyStub)		

        Public Function GetCollection As ConstructorTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ConstructorTestCollection()
					
		            Dim proxy As ConstructorTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ConstructorTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ConstructorTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ConstructorTestMetadata.ColumnNames.ConstructorTestId, 0, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = ConstructorTestMetadata.PropertyNames.ConstructorTestId
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 19
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultInt, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultInt
			c.NumericPrecision = 10
			c.HasDefault = True
			c.Default = "((0))"
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultBool, 2, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultBool
			c.HasDefault = True
			c.Default = "((0))"
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultDateTime, 3, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultDateTime
			c.HasDefault = True
			c.Default = "(getdate())"
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConstructorTestMetadata.ColumnNames.DefaultString, 4, GetType(System.String), esSystemType.String)	
			c.PropertyName = ConstructorTestMetadata.PropertyNames.DefaultString
			c.CharacterMaxLength = 10
			c.HasDefault = True
			c.Default = "('[new]')"
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ConstructorTestMetadata
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
			 Public Const ConstructorTestId As String = "ConstructorTestId"
			 Public Const DefaultInt As String = "DefaultInt"
			 Public Const DefaultBool As String = "DefaultBool"
			 Public Const DefaultDateTime As String = "DefaultDateTime"
			 Public Const DefaultString As String = "DefaultString"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const ConstructorTestId As String = "ConstructorTestId"
			 Public Const DefaultInt As String = "DefaultInt"
			 Public Const DefaultBool As String = "DefaultBool"
			 Public Const DefaultDateTime As String = "DefaultDateTime"
			 Public Const DefaultString As String = "DefaultString"
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
			SyncLock GetType(ConstructorTestMetadata)
			
				If ConstructorTestMetadata.mapDelegates Is Nothing Then
					ConstructorTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ConstructorTestMetadata._meta Is Nothing Then
					ConstructorTestMetadata._meta = New ConstructorTestMetadata()
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
				


				meta.AddTypeMap("ConstructorTestId", new esTypeMap("bigint", "System.Int64"))
				meta.AddTypeMap("DefaultInt", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("DefaultBool", new esTypeMap("bit", "System.Boolean"))
				meta.AddTypeMap("DefaultDateTime", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("DefaultString", new esTypeMap("varchar", "System.String"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "ConstructorTest"
				meta.Destination = "ConstructorTest"
				
				meta.spInsert = "proc_ConstructorTestInsert"
				meta.spUpdate = "proc_ConstructorTestUpdate"
				meta.spDelete = "proc_ConstructorTestDelete"
				meta.spLoadAll = "proc_ConstructorTestLoadAll"
				meta.spLoadByPrimaryKey = "proc_ConstructorTestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ConstructorTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
