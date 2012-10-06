
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
	' Encapsulates the 'DefaultTest' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(DefaultTest))> _
	<XmlType("DefaultTest")> _ 
	<Table(Name:="DefaultTest")> _	
	Partial Public Class DefaultTest 
		Inherits esDefaultTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New DefaultTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal testId As System.Int32)
			Dim obj As New DefaultTest()
			obj.TestId = testId
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal testId As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New DefaultTest()
			obj.TestId = testId
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As DefaultTest) As DefaultTestProxyStub
			Return New DefaultTestProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property TestId As Nullable(Of System.Int32)
			Get
				Return MyBase.TestId
			End Get
			Set
				MyBase.TestId = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DefaultNotNullInt As Nullable(Of System.Int32)
			Get
				Return MyBase.DefaultNotNullInt
			End Get
			Set
				MyBase.DefaultNotNullInt = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DefaultNotNullBool As Nullable(Of System.Boolean)
			Get
				Return MyBase.DefaultNotNullBool
			End Get
			Set
				MyBase.DefaultNotNullBool = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("DefaultTestCollection")> _
	Partial Public Class DefaultTestCollection
		Inherits esDefaultTestCollection
		Implements IEnumerable(Of DefaultTest)
	
		Public Function FindByPrimaryKey(ByVal testId As System.Int32) As DefaultTest
			Return MyBase.SingleOrDefault(Function(e) e.TestId.HasValue AndAlso e.TestId.Value = testId)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As DefaultTestCollection) As DefaultTestCollectionProxyStub
            Return New DefaultTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(DefaultTest))> _
		Public Class DefaultTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of DefaultTestCollection)
			
			Public Shared Widening Operator CType(packet As DefaultTestCollectionWCFPacket) As DefaultTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As DefaultTestCollection) As DefaultTestCollectionWCFPacket
				Return New DefaultTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "DefaultTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class DefaultTestQuery 
		Inherits esDefaultTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "DefaultTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As DefaultTestQuery) As String
			Return DefaultTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As DefaultTestQuery
			Return DirectCast(DefaultTestQuery.SerializeHelper.FromXml(query, GetType(DefaultTestQuery)), DefaultTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esDefaultTest
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal testId As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(testId)
			Else
				Return LoadByPrimaryKeyStoredProcedure(testId)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal testId As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(testId)
			Else
				Return LoadByPrimaryKeyStoredProcedure(testId)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal testId As System.Int32) As Boolean
		
			Dim query As New DefaultTestQuery()
			query.Where(query.TestId = testId)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal testId As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("TestId", testId)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to DefaultTest.TestId
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TestId As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(DefaultTestMetadata.ColumnNames.TestId)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(DefaultTestMetadata.ColumnNames.TestId, value) Then
					OnPropertyChanged(DefaultTestMetadata.PropertyNames.TestId)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to DefaultTest.DefaultNotNullInt
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DefaultNotNullInt As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(DefaultTestMetadata.ColumnNames.DefaultNotNullInt)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(DefaultTestMetadata.ColumnNames.DefaultNotNullInt, value) Then
					OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullInt)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to DefaultTest.DefaultNotNullBool
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DefaultNotNullBool As Nullable(Of System.Boolean)
			Get
				Return MyBase.GetSystemBoolean(DefaultTestMetadata.ColumnNames.DefaultNotNullBool)
			End Get
			
			Set(ByVal value As Nullable(Of System.Boolean))
				If MyBase.SetSystemBoolean(DefaultTestMetadata.ColumnNames.DefaultNotNullBool, value) Then
					OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullBool)
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
												
						Case "TestId"
							Me.str().TestId = CType(value, string)
												
						Case "DefaultNotNullInt"
							Me.str().DefaultNotNullInt = CType(value, string)
												
						Case "DefaultNotNullBool"
							Me.str().DefaultNotNullBool = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "TestId"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.TestId = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(DefaultTestMetadata.PropertyNames.TestId)
							End If
						
						Case "DefaultNotNullInt"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.DefaultNotNullInt = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullInt)
							End If
						
						Case "DefaultNotNullBool"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Boolean" Then
								Me.DefaultNotNullBool = CType(value, Nullable(Of System.Boolean))
								OnPropertyChanged(DefaultTestMetadata.PropertyNames.DefaultNotNullBool)
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
		
			Public Sub New(ByVal entity As esDefaultTest)
				Me.entity = entity
			End Sub				
		
	
			Public Property TestId As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.TestId
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TestId = Nothing
					Else
						entity.TestId = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property DefaultNotNullInt As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.DefaultNotNullInt
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DefaultNotNullInt = Nothing
					Else
						entity.DefaultNotNullInt = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property DefaultNotNullBool As System.String 
				Get
					Dim data_ As Nullable(Of System.Boolean) = entity.DefaultNotNullBool
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DefaultNotNullBool = Nothing
					Else
						entity.DefaultNotNullBool = Convert.ToBoolean(Value)
					End If
				End Set
			End Property
		  

			Private entity As esDefaultTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return DefaultTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As DefaultTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New DefaultTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As DefaultTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As DefaultTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As DefaultTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esDefaultTestCollection
		Inherits CollectionBase(Of DefaultTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return DefaultTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "DefaultTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As DefaultTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New DefaultTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As DefaultTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New DefaultTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As DefaultTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, DefaultTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As DefaultTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esDefaultTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return DefaultTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "TestId" 
					Return Me.TestId
				Case "DefaultNotNullInt" 
					Return Me.DefaultNotNullInt
				Case "DefaultNotNullBool" 
					Return Me.DefaultNotNullBool
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property TestId As esQueryItem
			Get
				Return New esQueryItem(Me, DefaultTestMetadata.ColumnNames.TestId, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property DefaultNotNullInt As esQueryItem
			Get
				Return New esQueryItem(Me, DefaultTestMetadata.ColumnNames.DefaultNotNullInt, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property DefaultNotNullBool As esQueryItem
			Get
				Return New esQueryItem(Me, DefaultTestMetadata.ColumnNames.DefaultNotNullBool, esSystemType.Boolean)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="DefaultTest")> _
    <XmlType(TypeName:="DefaultTestProxyStub")> _
    <Serializable> _
    Partial Public Class DefaultTestProxyStub
	
		Public Sub New()
            Me._entity = New DefaultTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As DefaultTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As DefaultTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As DefaultTestProxyStub) As DefaultTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(DefaultTest)
        End Function
		

		<DataMember(Name:="TestId", Order:=1, EmitDefaultValue:=False)> _		
        Public Property TestId As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(DefaultTestMetadata.ColumnNames.TestId)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.TestId
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.TestId = value
			End Set
			
		End Property

		<DataMember(Name:="DefaultNotNullInt", Order:=2, EmitDefaultValue:=False)> _		
        Public Property DefaultNotNullInt As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(DefaultTestMetadata.ColumnNames.DefaultNotNullInt) Then
                    Return Me.Entity.DefaultNotNullInt
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.DefaultNotNullInt = value
			End Set
			
		End Property

		<DataMember(Name:="DefaultNotNullBool", Order:=3, EmitDefaultValue:=False)> _		
        Public Property DefaultNotNullBool As Nullable(Of System.Boolean)
        
            Get
                If Me.IncludeColumn(DefaultTestMetadata.ColumnNames.DefaultNotNullBool) Then
                    Return Me.Entity.DefaultNotNullBool
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Boolean))
				Me.Entity.DefaultNotNullBool = value
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
        Public Property Entity As DefaultTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New DefaultTest()
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
        Public _entity As DefaultTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="DefaultTestCollection")> _
    <XmlType(TypeName:="DefaultTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class DefaultTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of DefaultTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of DefaultTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As DefaultTestCollectionProxyStub) As DefaultTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(DefaultTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of DefaultTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As DefaultTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New DefaultTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New DefaultTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As DefaultTest In coll.es.DeletedEntities
                    Collection.Add(New DefaultTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of DefaultTestProxyStub)		

        Public Function GetCollection As DefaultTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New DefaultTestCollection()
					
		            Dim proxy As DefaultTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As DefaultTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class DefaultTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(DefaultTestMetadata.ColumnNames.TestId, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = DefaultTestMetadata.PropertyNames.TestId
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(DefaultTestMetadata.ColumnNames.DefaultNotNullInt, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = DefaultTestMetadata.PropertyNames.DefaultNotNullInt
			c.NumericPrecision = 10
			c.HasDefault = True
			c.Default = "((0))"
			m_columns.Add(c)
				
			c = New esColumnMetadata(DefaultTestMetadata.ColumnNames.DefaultNotNullBool, 2, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = DefaultTestMetadata.PropertyNames.DefaultNotNullBool
			c.HasDefault = True
			c.Default = "((0))"
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As DefaultTestMetadata
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
			 Public Const TestId As String = "TestId"
			 Public Const DefaultNotNullInt As String = "DefaultNotNullInt"
			 Public Const DefaultNotNullBool As String = "DefaultNotNullBool"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const TestId As String = "TestId"
			 Public Const DefaultNotNullInt As String = "DefaultNotNullInt"
			 Public Const DefaultNotNullBool As String = "DefaultNotNullBool"
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
			SyncLock GetType(DefaultTestMetadata)
			
				If DefaultTestMetadata.mapDelegates Is Nothing Then
					DefaultTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If DefaultTestMetadata._meta Is Nothing Then
					DefaultTestMetadata._meta = New DefaultTestMetadata()
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
				


				meta.AddTypeMap("TestId", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("DefaultNotNullInt", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("DefaultNotNullBool", new esTypeMap("bit", "System.Boolean"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "DefaultTest"
				meta.Destination = "DefaultTest"
				
				meta.spInsert = "proc_DefaultTestInsert"
				meta.spUpdate = "proc_DefaultTestUpdate"
				meta.spDelete = "proc_DefaultTestDelete"
				meta.spLoadAll = "proc_DefaultTestLoadAll"
				meta.spLoadByPrimaryKey = "proc_DefaultTestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As DefaultTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
