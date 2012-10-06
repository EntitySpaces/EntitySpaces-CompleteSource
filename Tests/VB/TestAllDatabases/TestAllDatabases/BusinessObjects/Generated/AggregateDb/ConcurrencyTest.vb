
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
	' Encapsulates the 'ConcurrencyTest' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(ConcurrencyTest))> _
	<XmlType("ConcurrencyTest")> _ 
	<Table(Name:="ConcurrencyTest")> _	
	Partial Public Class ConcurrencyTest 
		Inherits esConcurrencyTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New ConcurrencyTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.String)
			Dim obj As New ConcurrencyTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New ConcurrencyTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ConcurrencyTest) As ConcurrencyTestProxyStub
			Return New ConcurrencyTestProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Id As System.String
			Get
				Return MyBase.Id
			End Get
			Set
				MyBase.Id = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Name As System.String
			Get
				Return MyBase.Name
			End Get
			Set
				MyBase.Name = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property ConcurrencyCheck As Nullable(Of System.Int64)
			Get
				Return MyBase.ConcurrencyCheck
			End Get
			Set
				MyBase.ConcurrencyCheck = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ConcurrencyTestCollection")> _
	Partial Public Class ConcurrencyTestCollection
		Inherits esConcurrencyTestCollection
		Implements IEnumerable(Of ConcurrencyTest)
	
		Public Function FindByPrimaryKey(ByVal id As System.String) As ConcurrencyTest
			Return MyBase.SingleOrDefault(Function(e) e.Id = id)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ConcurrencyTestCollection) As ConcurrencyTestCollectionProxyStub
            Return New ConcurrencyTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(ConcurrencyTest))> _
		Public Class ConcurrencyTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ConcurrencyTestCollection)
			
			Public Shared Widening Operator CType(packet As ConcurrencyTestCollectionWCFPacket) As ConcurrencyTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ConcurrencyTestCollection) As ConcurrencyTestCollectionWCFPacket
				Return New ConcurrencyTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ConcurrencyTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ConcurrencyTestQuery 
		Inherits esConcurrencyTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ConcurrencyTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ConcurrencyTestQuery) As String
			Return ConcurrencyTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ConcurrencyTestQuery
			Return DirectCast(ConcurrencyTestQuery.SerializeHelper.FromXml(query, GetType(ConcurrencyTestQuery)), ConcurrencyTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esConcurrencyTest
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal id As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal id As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal id As System.String) As Boolean
		
			Dim query As New ConcurrencyTestQuery()
			query.Where(query.Id = id)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal id As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("Id", id)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to ConcurrencyTest.Id
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Id As System.String
			Get
				Return MyBase.GetSystemString(ConcurrencyTestMetadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ConcurrencyTestMetadata.ColumnNames.Id, value) Then
					OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTest.Name
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Name As System.String
			Get
				Return MyBase.GetSystemString(ConcurrencyTestMetadata.ColumnNames.Name)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ConcurrencyTestMetadata.ColumnNames.Name, value) Then
					OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.Name)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTest.ConcurrencyCheck
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ConcurrencyCheck As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.ConcurrencyCheck)
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
												
						Case "Name"
							Me.str().Name = CType(value, string)
												
						Case "ConcurrencyCheck"
							Me.str().ConcurrencyCheck = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "ConcurrencyCheck"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.ConcurrencyCheck = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(ConcurrencyTestMetadata.PropertyNames.ConcurrencyCheck)
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
		
			Public Sub New(ByVal entity As esConcurrencyTest)
				Me.entity = entity
			End Sub				
		
	
			Public Property Id As System.String 
				Get
					Dim data_ As System.String = entity.Id
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Id = Nothing
					Else
						entity.Id = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Name As System.String 
				Get
					Dim data_ As System.String = entity.Name
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Name = Nothing
					Else
						entity.Name = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property ConcurrencyCheck As System.String 
				Get
					Dim data_ As Nullable(Of System.Int64) = entity.ConcurrencyCheck
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ConcurrencyCheck = Nothing
					Else
						entity.ConcurrencyCheck = Convert.ToInt64(Value)
					End If
				End Set
			End Property
		  

			Private entity As esConcurrencyTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ConcurrencyTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ConcurrencyTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ConcurrencyTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ConcurrencyTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ConcurrencyTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ConcurrencyTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esConcurrencyTestCollection
		Inherits CollectionBase(Of ConcurrencyTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ConcurrencyTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ConcurrencyTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ConcurrencyTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ConcurrencyTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ConcurrencyTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ConcurrencyTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ConcurrencyTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ConcurrencyTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As ConcurrencyTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esConcurrencyTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ConcurrencyTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "Name" 
					Return Me.Name
				Case "ConcurrencyCheck" 
					Return Me.ConcurrencyCheck
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestMetadata.ColumnNames.Id, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Name As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestMetadata.ColumnNames.Name, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ConcurrencyCheck As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int64)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="ConcurrencyTest")> _
    <XmlType(TypeName:="ConcurrencyTestProxyStub")> _
    <Serializable> _
    Partial Public Class ConcurrencyTestProxyStub
	
		Public Sub New()
            Me._entity = New ConcurrencyTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ConcurrencyTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ConcurrencyTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ConcurrencyTestProxyStub) As ConcurrencyTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(ConcurrencyTest)
        End Function
		

		<DataMember(Name:="Id", Order:=1, EmitDefaultValue:=False)> _		
        Public Property Id As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ConcurrencyTestMetadata.ColumnNames.Id)
					Return CType(o, System.String)
                Else
					Return Me.Entity.Id
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Id = value
			End Set
			
		End Property

		<DataMember(Name:="Name", Order:=2, EmitDefaultValue:=False)> _		
        Public Property Name As System.String
        
            Get
                If Me.IncludeColumn(ConcurrencyTestMetadata.ColumnNames.Name) Then
                    Return Me.Entity.Name
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Name = value
			End Set
			
		End Property

		<DataMember(Name:="ConcurrencyCheck", Order:=3, EmitDefaultValue:=False)> _		
        Public Property ConcurrencyCheck As Nullable(Of System.Int64)
        
            Get
                If Me.IncludeColumn(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck) Then
                    Return Me.Entity.ConcurrencyCheck
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.ConcurrencyCheck = value
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
        Public Property Entity As ConcurrencyTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New ConcurrencyTest()
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
        Public _entity As ConcurrencyTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ConcurrencyTestCollection")> _
    <XmlType(TypeName:="ConcurrencyTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ConcurrencyTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of ConcurrencyTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of ConcurrencyTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ConcurrencyTestCollectionProxyStub) As ConcurrencyTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(ConcurrencyTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of ConcurrencyTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As ConcurrencyTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ConcurrencyTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ConcurrencyTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As ConcurrencyTest In coll.es.DeletedEntities
                    Collection.Add(New ConcurrencyTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ConcurrencyTestProxyStub)		

        Public Function GetCollection As ConcurrencyTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ConcurrencyTestCollection()
					
		            Dim proxy As ConcurrencyTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ConcurrencyTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ConcurrencyTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ConcurrencyTestMetadata.ColumnNames.Id, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = ConcurrencyTestMetadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestMetadata.ColumnNames.Name, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = ConcurrencyTestMetadata.PropertyNames.Name
			c.CharacterMaxLength = 20
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestMetadata.ColumnNames.ConcurrencyCheck, 2, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = ConcurrencyTestMetadata.PropertyNames.ConcurrencyCheck
			c.NumericPrecision = 19
			c.IsEntitySpacesConcurrency = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ConcurrencyTestMetadata
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
			 Public Const Id As String = "Id"
			 Public Const Name As String = "Name"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const Name As String = "Name"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
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
			SyncLock GetType(ConcurrencyTestMetadata)
			
				If ConcurrencyTestMetadata.mapDelegates Is Nothing Then
					ConcurrencyTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ConcurrencyTestMetadata._meta Is Nothing Then
					ConcurrencyTestMetadata._meta = New ConcurrencyTestMetadata()
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
				


				meta.AddTypeMap("Id", new esTypeMap("char", "System.String"))
				meta.AddTypeMap("Name", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("bigint", "System.Int64"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "ConcurrencyTest"
				meta.Destination = "ConcurrencyTest"
				
				meta.spInsert = "proc_ConcurrencyTestInsert"
				meta.spUpdate = "proc_ConcurrencyTestUpdate"
				meta.spDelete = "proc_ConcurrencyTestDelete"
				meta.spLoadAll = "proc_ConcurrencyTestLoadAll"
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ConcurrencyTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
