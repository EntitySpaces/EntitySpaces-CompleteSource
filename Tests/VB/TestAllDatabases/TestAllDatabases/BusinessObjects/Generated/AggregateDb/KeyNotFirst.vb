
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
	' Encapsulates the 'KeyNotFirst' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(KeyNotFirst))> _
	<XmlType("KeyNotFirst")> _ 
	<Table(Name:="KeyNotFirst")> _	
	Partial Public Class KeyNotFirst 
		Inherits esKeyNotFirst
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New KeyNotFirst()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal theKey As System.Int32)
			Dim obj As New KeyNotFirst()
			obj.TheKey = theKey
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal theKey As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New KeyNotFirst()
			obj.TheKey = theKey
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As KeyNotFirst) As KeyNotFirstProxyStub
			Return New KeyNotFirstProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property SomeText As System.String
			Get
				Return MyBase.SomeText
			End Get
			Set
				MyBase.SomeText = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property TheKey As Nullable(Of System.Int32)
			Get
				Return MyBase.TheKey
			End Get
			Set
				MyBase.TheKey = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("KeyNotFirstCollection")> _
	Partial Public Class KeyNotFirstCollection
		Inherits esKeyNotFirstCollection
		Implements IEnumerable(Of KeyNotFirst)
	
		Public Function FindByPrimaryKey(ByVal theKey As System.Int32) As KeyNotFirst
			Return MyBase.SingleOrDefault(Function(e) e.TheKey.HasValue AndAlso e.TheKey.Value = theKey)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As KeyNotFirstCollection) As KeyNotFirstCollectionProxyStub
            Return New KeyNotFirstCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(KeyNotFirst))> _
		Public Class KeyNotFirstCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of KeyNotFirstCollection)
			
			Public Shared Widening Operator CType(packet As KeyNotFirstCollectionWCFPacket) As KeyNotFirstCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As KeyNotFirstCollection) As KeyNotFirstCollectionWCFPacket
				Return New KeyNotFirstCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "KeyNotFirstQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class KeyNotFirstQuery 
		Inherits esKeyNotFirstQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "KeyNotFirstQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As KeyNotFirstQuery) As String
			Return KeyNotFirstQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As KeyNotFirstQuery
			Return DirectCast(KeyNotFirstQuery.SerializeHelper.FromXml(query, GetType(KeyNotFirstQuery)), KeyNotFirstQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esKeyNotFirst
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal theKey As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(theKey)
			Else
				Return LoadByPrimaryKeyStoredProcedure(theKey)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal theKey As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(theKey)
			Else
				Return LoadByPrimaryKeyStoredProcedure(theKey)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal theKey As System.Int32) As Boolean
		
			Dim query As New KeyNotFirstQuery()
			query.Where(query.TheKey = theKey)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal theKey As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("TheKey", theKey)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to KeyNotFirst.SomeText
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property SomeText As System.String
			Get
				Return MyBase.GetSystemString(KeyNotFirstMetadata.ColumnNames.SomeText)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(KeyNotFirstMetadata.ColumnNames.SomeText, value) Then
					OnPropertyChanged(KeyNotFirstMetadata.PropertyNames.SomeText)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to KeyNotFirst.TheKey
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TheKey As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(KeyNotFirstMetadata.ColumnNames.TheKey)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(KeyNotFirstMetadata.ColumnNames.TheKey, value) Then
					OnPropertyChanged(KeyNotFirstMetadata.PropertyNames.TheKey)
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
												
						Case "SomeText"
							Me.str().SomeText = CType(value, string)
												
						Case "TheKey"
							Me.str().TheKey = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "TheKey"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.TheKey = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(KeyNotFirstMetadata.PropertyNames.TheKey)
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
		
			Public Sub New(ByVal entity As esKeyNotFirst)
				Me.entity = entity
			End Sub				
		
	
			Public Property SomeText As System.String 
				Get
					Dim data_ As System.String = entity.SomeText
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.SomeText = Nothing
					Else
						entity.SomeText = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property TheKey As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.TheKey
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TheKey = Nothing
					Else
						entity.TheKey = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  

			Private entity As esKeyNotFirst
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return KeyNotFirstMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As KeyNotFirstQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New KeyNotFirstQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As KeyNotFirstQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As KeyNotFirstQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As KeyNotFirstQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esKeyNotFirstCollection
		Inherits CollectionBase(Of KeyNotFirst)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return KeyNotFirstMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "KeyNotFirstCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As KeyNotFirstQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New KeyNotFirstQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As KeyNotFirstQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New KeyNotFirstQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As KeyNotFirstQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, KeyNotFirstQuery))
		End Sub
		
		#End Region
						
		Private m_query As KeyNotFirstQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esKeyNotFirstQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return KeyNotFirstMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "SomeText" 
					Return Me.SomeText
				Case "TheKey" 
					Return Me.TheKey
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property SomeText As esQueryItem
			Get
				Return New esQueryItem(Me, KeyNotFirstMetadata.ColumnNames.SomeText, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TheKey As esQueryItem
			Get
				Return New esQueryItem(Me, KeyNotFirstMetadata.ColumnNames.TheKey, esSystemType.Int32)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="KeyNotFirst")> _
    <XmlType(TypeName:="KeyNotFirstProxyStub")> _
    <Serializable> _
    Partial Public Class KeyNotFirstProxyStub
	
		Public Sub New()
            Me._entity = New KeyNotFirst()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As KeyNotFirst)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As KeyNotFirst, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As KeyNotFirstProxyStub) As KeyNotFirst
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(KeyNotFirst)
        End Function
		

		<DataMember(Name:="SomeText", Order:=1, EmitDefaultValue:=False)> _		
        Public Property SomeText As System.String
        
            Get
                If Me.IncludeColumn(KeyNotFirstMetadata.ColumnNames.SomeText) Then
                    Return Me.Entity.SomeText
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.SomeText = value
			End Set
			
		End Property

		<DataMember(Name:="TheKey", Order:=2, EmitDefaultValue:=False)> _		
        Public Property TheKey As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(KeyNotFirstMetadata.ColumnNames.TheKey)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.TheKey
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.TheKey = value
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
        Public Property Entity As KeyNotFirst
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New KeyNotFirst()
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
        Public _entity As KeyNotFirst
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="KeyNotFirstCollection")> _
    <XmlType(TypeName:="KeyNotFirstCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class KeyNotFirstCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of KeyNotFirst))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of KeyNotFirst), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As KeyNotFirstCollectionProxyStub) As KeyNotFirstCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(KeyNotFirst)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of KeyNotFirst), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As KeyNotFirst In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New KeyNotFirstProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New KeyNotFirstProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As KeyNotFirst In coll.es.DeletedEntities
                    Collection.Add(New KeyNotFirstProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of KeyNotFirstProxyStub)		

        Public Function GetCollection As KeyNotFirstCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New KeyNotFirstCollection()
					
		            Dim proxy As KeyNotFirstProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As KeyNotFirstCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class KeyNotFirstMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(KeyNotFirstMetadata.ColumnNames.SomeText, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = KeyNotFirstMetadata.PropertyNames.SomeText
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(KeyNotFirstMetadata.ColumnNames.TheKey, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = KeyNotFirstMetadata.PropertyNames.TheKey
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As KeyNotFirstMetadata
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
			 Public Const SomeText As String = "SomeText"
			 Public Const TheKey As String = "TheKey"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const SomeText As String = "SomeText"
			 Public Const TheKey As String = "TheKey"
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
			SyncLock GetType(KeyNotFirstMetadata)
			
				If KeyNotFirstMetadata.mapDelegates Is Nothing Then
					KeyNotFirstMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If KeyNotFirstMetadata._meta Is Nothing Then
					KeyNotFirstMetadata._meta = New KeyNotFirstMetadata()
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
				


				meta.AddTypeMap("SomeText", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("TheKey", new esTypeMap("int", "System.Int32"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "KeyNotFirst"
				meta.Destination = "KeyNotFirst"
				
				meta.spInsert = "proc_KeyNotFirstInsert"
				meta.spUpdate = "proc_KeyNotFirstUpdate"
				meta.spDelete = "proc_KeyNotFirstDelete"
				meta.spLoadAll = "proc_KeyNotFirstLoadAll"
				meta.spLoadByPrimaryKey = "proc_KeyNotFirstLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As KeyNotFirstMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
