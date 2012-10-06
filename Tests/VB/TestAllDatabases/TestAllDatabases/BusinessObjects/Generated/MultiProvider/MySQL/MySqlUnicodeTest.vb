
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:09 AM
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
	' Encapsulates the 'mysqlunicodetest' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(MySqlUnicodeTest))> _
	<XmlType("MySqlUnicodeTest")> _ 
	<Table(Name:="MySqlUnicodeTest")> _	
	Partial Public Class MySqlUnicodeTest 
		Inherits esMySqlUnicodeTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New MySqlUnicodeTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal typeID As System.UInt32)
			Dim obj As New MySqlUnicodeTest()
			obj.TypeID = typeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal typeID As System.UInt32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New MySqlUnicodeTest()
			obj.TypeID = typeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As MySqlUnicodeTest) As MySqlUnicodeTestProxyStub
			Return New MySqlUnicodeTestProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property TypeID As Nullable(Of System.UInt32)
			Get
				Return MyBase.TypeID
			End Get
			Set
				MyBase.TypeID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property VarCharType As System.String
			Get
				Return MyBase.VarCharType
			End Get
			Set
				MyBase.VarCharType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property TextType As System.String
			Get
				Return MyBase.TextType
			End Get
			Set
				MyBase.TextType = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("MySqlUnicodeTestCollection")> _
	Partial Public Class MySqlUnicodeTestCollection
		Inherits esMySqlUnicodeTestCollection
		Implements IEnumerable(Of MySqlUnicodeTest)
	
		Public Function FindByPrimaryKey(ByVal typeID As System.UInt32) As MySqlUnicodeTest
			Return MyBase.SingleOrDefault(Function(e) e.TypeID.HasValue AndAlso e.TypeID.Value = typeID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As MySqlUnicodeTestCollection) As MySqlUnicodeTestCollectionProxyStub
            Return New MySqlUnicodeTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(MySqlUnicodeTest))> _
		Public Class MySqlUnicodeTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of MySqlUnicodeTestCollection)
			
			Public Shared Widening Operator CType(packet As MySqlUnicodeTestCollectionWCFPacket) As MySqlUnicodeTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As MySqlUnicodeTestCollection) As MySqlUnicodeTestCollectionWCFPacket
				Return New MySqlUnicodeTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "MySqlUnicodeTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class MySqlUnicodeTestQuery 
		Inherits esMySqlUnicodeTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "MySqlUnicodeTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As MySqlUnicodeTestQuery) As String
			Return MySqlUnicodeTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As MySqlUnicodeTestQuery
			Return DirectCast(MySqlUnicodeTestQuery.SerializeHelper.FromXml(query, GetType(MySqlUnicodeTestQuery)), MySqlUnicodeTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esMySqlUnicodeTest
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal typeID As System.UInt32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(typeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(typeID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal typeID As System.UInt32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(typeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(typeID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal typeID As System.UInt32) As Boolean
		
			Dim query As New MySqlUnicodeTestQuery()
			query.Where(query.TypeID = typeID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal typeID As System.UInt32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("TypeID", typeID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to mysqlunicodetest.TypeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TypeID As Nullable(Of System.UInt32)
			Get
				Return MyBase.GetSystemUInt32(MySqlUnicodeTestMetadata.ColumnNames.TypeID)
			End Get
			
			Set(ByVal value As Nullable(Of System.UInt32))
				If MyBase.SetSystemUInt32(MySqlUnicodeTestMetadata.ColumnNames.TypeID, value) Then
					OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.TypeID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqlunicodetest.VarCharType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property VarCharType As System.String
			Get
				Return MyBase.GetSystemString(MySqlUnicodeTestMetadata.ColumnNames.VarCharType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(MySqlUnicodeTestMetadata.ColumnNames.VarCharType, value) Then
					OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.VarCharType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqlunicodetest.TextType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TextType As System.String
			Get
				Return MyBase.GetSystemString(MySqlUnicodeTestMetadata.ColumnNames.TextType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(MySqlUnicodeTestMetadata.ColumnNames.TextType, value) Then
					OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.TextType)
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
												
						Case "TypeID"
							Me.str().TypeID = CType(value, string)
												
						Case "VarCharType"
							Me.str().VarCharType = CType(value, string)
												
						Case "TextType"
							Me.str().TextType = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "TypeID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.UInt32" Then
								Me.TypeID = CType(value, Nullable(Of System.UInt32))
								OnPropertyChanged(MySqlUnicodeTestMetadata.PropertyNames.TypeID)
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
		
			Public Sub New(ByVal entity As esMySqlUnicodeTest)
				Me.entity = entity
			End Sub				
		
	
			Public Property TypeID As System.String 
				Get
					Dim data_ As Nullable(Of System.UInt32) = entity.TypeID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TypeID = Nothing
					Else
						entity.TypeID = Convert.ToUInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property VarCharType As System.String 
				Get
					Dim data_ As System.String = entity.VarCharType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.VarCharType = Nothing
					Else
						entity.VarCharType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property TextType As System.String 
				Get
					Dim data_ As System.String = entity.TextType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TextType = Nothing
					Else
						entity.TextType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esMySqlUnicodeTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return MySqlUnicodeTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As MySqlUnicodeTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New MySqlUnicodeTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As MySqlUnicodeTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As MySqlUnicodeTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As MySqlUnicodeTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esMySqlUnicodeTestCollection
		Inherits CollectionBase(Of MySqlUnicodeTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return MySqlUnicodeTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "MySqlUnicodeTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As MySqlUnicodeTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New MySqlUnicodeTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As MySqlUnicodeTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New MySqlUnicodeTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As MySqlUnicodeTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, MySqlUnicodeTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As MySqlUnicodeTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esMySqlUnicodeTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return MySqlUnicodeTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "TypeID" 
					Return Me.TypeID
				Case "VarCharType" 
					Return Me.VarCharType
				Case "TextType" 
					Return Me.TextType
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property TypeID As esQueryItem
			Get
				Return New esQueryItem(Me, MySqlUnicodeTestMetadata.ColumnNames.TypeID, esSystemType.UInt32)
			End Get
		End Property 
		
		Public ReadOnly Property VarCharType As esQueryItem
			Get
				Return New esQueryItem(Me, MySqlUnicodeTestMetadata.ColumnNames.VarCharType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TextType As esQueryItem
			Get
				Return New esQueryItem(Me, MySqlUnicodeTestMetadata.ColumnNames.TextType, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="MySqlUnicodeTest")> _
    <XmlType(TypeName:="MySqlUnicodeTestProxyStub")> _
    <Serializable> _
    Partial Public Class MySqlUnicodeTestProxyStub
	
		Public Sub New()
            Me._entity = New MySqlUnicodeTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As MySqlUnicodeTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As MySqlUnicodeTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As MySqlUnicodeTestProxyStub) As MySqlUnicodeTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(MySqlUnicodeTest)
        End Function
		

		<DataMember(Name:="TypeID", Order:=0, EmitDefaultValue:=False)> _		
        Public Property TypeID As Nullable(Of System.UInt32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(MySqlUnicodeTestMetadata.ColumnNames.TypeID)
					Return CType(o, Nullable(Of System.UInt32))
                Else
					Return Me.Entity.TypeID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.UInt32))
				Me.Entity.TypeID = value
			End Set
			
		End Property

		<DataMember(Name:="VarCharType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property VarCharType As System.String
        
            Get
                If Me.IncludeColumn(MySqlUnicodeTestMetadata.ColumnNames.VarCharType) Then
                    Return Me.Entity.VarCharType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.VarCharType = value
			End Set
			
		End Property

		<DataMember(Name:="TextType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property TextType As System.String
        
            Get
                If Me.IncludeColumn(MySqlUnicodeTestMetadata.ColumnNames.TextType) Then
                    Return Me.Entity.TextType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TextType = value
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
        Public Property Entity As MySqlUnicodeTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New MySqlUnicodeTest()
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
        Public _entity As MySqlUnicodeTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="MySqlUnicodeTestCollection")> _
    <XmlType(TypeName:="MySqlUnicodeTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class MySqlUnicodeTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of MySqlUnicodeTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of MySqlUnicodeTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As MySqlUnicodeTestCollectionProxyStub) As MySqlUnicodeTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(MySqlUnicodeTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of MySqlUnicodeTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As MySqlUnicodeTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New MySqlUnicodeTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New MySqlUnicodeTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As MySqlUnicodeTest In coll.es.DeletedEntities
                    Collection.Add(New MySqlUnicodeTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of MySqlUnicodeTestProxyStub)		

        Public Function GetCollection As MySqlUnicodeTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New MySqlUnicodeTestCollection()
					
		            Dim proxy As MySqlUnicodeTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As MySqlUnicodeTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class MySqlUnicodeTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(MySqlUnicodeTestMetadata.ColumnNames.TypeID, 0, GetType(System.UInt32), esSystemType.UInt32)	
			c.PropertyName = MySqlUnicodeTestMetadata.PropertyNames.TypeID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(MySqlUnicodeTestMetadata.ColumnNames.VarCharType, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = MySqlUnicodeTestMetadata.PropertyNames.VarCharType
			c.CharacterMaxLength = 1024
			m_columns.Add(c)
				
			c = New esColumnMetadata(MySqlUnicodeTestMetadata.ColumnNames.TextType, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = MySqlUnicodeTestMetadata.PropertyNames.TextType
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As MySqlUnicodeTestMetadata
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
			 Public Const TypeID As String = "TypeID"
			 Public Const VarCharType As String = "VarCharType"
			 Public Const TextType As String = "TextType"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const TypeID As String = "TypeID"
			 Public Const VarCharType As String = "VarCharType"
			 Public Const TextType As String = "TextType"
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
			SyncLock GetType(MySqlUnicodeTestMetadata)
			
				If MySqlUnicodeTestMetadata.mapDelegates Is Nothing Then
					MySqlUnicodeTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If MySqlUnicodeTestMetadata._meta Is Nothing Then
					MySqlUnicodeTestMetadata._meta = New MySqlUnicodeTestMetadata()
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
				


				meta.AddTypeMap("TypeID", new esTypeMap("INT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"))			
				meta.Catalog = "aggregatedb"
				
				 
				meta.Source = "mysqlunicodetest"
				meta.Destination = "mysqlunicodetest"
				
				meta.spInsert = "proc_mysqlunicodetestInsert"
				meta.spUpdate = "proc_mysqlunicodetestUpdate"
				meta.spDelete = "proc_mysqlunicodetestDelete"
				meta.spLoadAll = "proc_mysqlunicodetestLoadAll"
				meta.spLoadByPrimaryKey = "proc_mysqlunicodetestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As MySqlUnicodeTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
