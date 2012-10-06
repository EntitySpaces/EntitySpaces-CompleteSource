
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
	' Encapsulates the 'Naming Test2' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(NamingTest2))> _
	<XmlType("NamingTest2")> _ 
	<Table(Name:="NamingTest2")> _	
	Partial Public Class NamingTest2 
		Inherits esNamingTest2
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New NamingTest2()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal identityKey As System.Int32)
			Dim obj As New NamingTest2()
			obj.IdentityKey = identityKey
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal identityKey As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New NamingTest2()
			obj.IdentityKey = identityKey
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As NamingTest2) As NamingTest2ProxyStub
			Return New NamingTest2ProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property IdentityKey As Nullable(Of System.Int32)
			Get
				Return MyBase.IdentityKey
			End Get
			Set
				MyBase.IdentityKey = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ItemDescription As System.String
			Get
				Return MyBase.ItemDescription
			End Get
			Set
				MyBase.ItemDescription = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.ConcurrencyCheck
			End Get
			Set
				MyBase.ConcurrencyCheck = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property GuidNewid As Nullable(Of System.Guid)
			Get
				Return MyBase.GuidNewid
			End Get
			Set
				MyBase.GuidNewid = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("NamingTest2Collection")> _
	Partial Public Class NamingTest2Collection
		Inherits esNamingTest2Collection
		Implements IEnumerable(Of NamingTest2)
	
		Public Function FindByPrimaryKey(ByVal identityKey As System.Int32) As NamingTest2
			Return MyBase.SingleOrDefault(Function(e) e.IdentityKey.HasValue AndAlso e.IdentityKey.Value = identityKey)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As NamingTest2Collection) As NamingTest2CollectionProxyStub
            Return New NamingTest2CollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(NamingTest2))> _
		Public Class NamingTest2CollectionWCFPacket
			Inherits esCollectionWCFPacket(Of NamingTest2Collection)
			
			Public Shared Widening Operator CType(packet As NamingTest2CollectionWCFPacket) As NamingTest2Collection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As NamingTest2Collection) As NamingTest2CollectionWCFPacket
				Return New NamingTest2CollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "NamingTest2Query", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class NamingTest2Query 
		Inherits esNamingTest2Query
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "NamingTest2Query"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As NamingTest2Query) As String
			Return NamingTest2Query.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As NamingTest2Query
			Return DirectCast(NamingTest2Query.SerializeHelper.FromXml(query, GetType(NamingTest2Query)), NamingTest2Query)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esNamingTest2
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal identityKey As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(identityKey)
			Else
				Return LoadByPrimaryKeyStoredProcedure(identityKey)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal identityKey As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(identityKey)
			Else
				Return LoadByPrimaryKeyStoredProcedure(identityKey)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal identityKey As System.Int32) As Boolean
		
			Dim query As New NamingTest2Query()
			query.Where(query.IdentityKey = identityKey)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal identityKey As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("IdentityKey", identityKey)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Naming Test2.Identity.Key
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property IdentityKey As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(NamingTest2Metadata.ColumnNames.IdentityKey)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(NamingTest2Metadata.ColumnNames.IdentityKey, value) Then
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.IdentityKey)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming Test2.Item.Description
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ItemDescription As System.String
			Get
				Return MyBase.GetSystemString(NamingTest2Metadata.ColumnNames.ItemDescription)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(NamingTest2Metadata.ColumnNames.ItemDescription, value) Then
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.ItemDescription)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming Test2.Concurrency.Check
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.GetSystemByteArray(NamingTest2Metadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As System.Byte())
				If MyBase.SetSystemByteArray(NamingTest2Metadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.ConcurrencyCheck)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming Test2.Guid.Newid
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property GuidNewid As Nullable(Of System.Guid)
			Get
				Return MyBase.GetSystemGuid(NamingTest2Metadata.ColumnNames.GuidNewid)
			End Get
			
			Set(ByVal value As Nullable(Of System.Guid))
				If MyBase.SetSystemGuid(NamingTest2Metadata.ColumnNames.GuidNewid, value) Then
					OnPropertyChanged(NamingTest2Metadata.PropertyNames.GuidNewid)
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
												
						Case "IdentityKey"
							Me.str().IdentityKey = CType(value, string)
												
						Case "ItemDescription"
							Me.str().ItemDescription = CType(value, string)
												
						Case "GuidNewid"
							Me.str().GuidNewid = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "IdentityKey"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.IdentityKey = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(NamingTest2Metadata.PropertyNames.IdentityKey)
							End If
						
						Case "ConcurrencyCheck"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Byte()" Then
								Me.ConcurrencyCheck = CType(value, System.Byte())
								OnPropertyChanged(NamingTest2Metadata.PropertyNames.ConcurrencyCheck)
							End If
						
						Case "GuidNewid"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Guid" Then
								Me.GuidNewid = CType(value, Nullable(Of System.Guid))
								OnPropertyChanged(NamingTest2Metadata.PropertyNames.GuidNewid)
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
		
			Public Sub New(ByVal entity As esNamingTest2)
				Me.entity = entity
			End Sub				
		
	
			Public Property IdentityKey As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.IdentityKey
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.IdentityKey = Nothing
					Else
						entity.IdentityKey = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property ItemDescription As System.String 
				Get
					Dim data_ As System.String = entity.ItemDescription
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ItemDescription = Nothing
					Else
						entity.ItemDescription = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property GuidNewid As System.String 
				Get
					Dim data_ As Nullable(Of System.Guid) = entity.GuidNewid
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.GuidNewid = Nothing
					Else
						entity.GuidNewid = new Guid(Value)
					End If
				End Set
			End Property
		  

			Private entity As esNamingTest2
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return NamingTest2Metadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As NamingTest2Query
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New NamingTest2Query()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As NamingTest2Query) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As NamingTest2Query)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As NamingTest2Query

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esNamingTest2Collection
		Inherits CollectionBase(Of NamingTest2)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return NamingTest2Metadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "NamingTest2Collection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As NamingTest2Query
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New NamingTest2Query()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As NamingTest2Query) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New NamingTest2Query()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As NamingTest2Query)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, NamingTest2Query))
		End Sub
		
		#End Region
						
		Private m_query As NamingTest2Query
	End Class



	<Serializable> _
	MustInherit Public Partial Class esNamingTest2Query 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return NamingTest2Metadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "IdentityKey" 
					Return Me.IdentityKey
				Case "ItemDescription" 
					Return Me.ItemDescription
				Case "ConcurrencyCheck" 
					Return Me.ConcurrencyCheck
				Case "GuidNewid" 
					Return Me.GuidNewid
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property IdentityKey As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTest2Metadata.ColumnNames.IdentityKey, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ItemDescription As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTest2Metadata.ColumnNames.ItemDescription, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ConcurrencyCheck As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTest2Metadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray)
			End Get
		End Property 
		
		Public ReadOnly Property GuidNewid As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTest2Metadata.ColumnNames.GuidNewid, esSystemType.Guid)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="NamingTest2")> _
    <XmlType(TypeName:="NamingTest2ProxyStub")> _
    <Serializable> _
    Partial Public Class NamingTest2ProxyStub
	
		Public Sub New()
            Me._entity = New NamingTest2()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As NamingTest2)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As NamingTest2, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As NamingTest2ProxyStub) As NamingTest2
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(NamingTest2)
        End Function
		

		<DataMember(Name:="IdentityKey", Order:=1, EmitDefaultValue:=False)> _		
        Public Property IdentityKey As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(NamingTest2Metadata.ColumnNames.IdentityKey)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.IdentityKey
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.IdentityKey = value
			End Set
			
		End Property

		<DataMember(Name:="ItemDescription", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ItemDescription As System.String
        
            Get
                If Me.IncludeColumn(NamingTest2Metadata.ColumnNames.ItemDescription) Then
                    Return Me.Entity.ItemDescription
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.ItemDescription = value
			End Set
			
		End Property

		<DataMember(Name:="ConcurrencyCheck", Order:=3, EmitDefaultValue:=False)> _		
        Public Property ConcurrencyCheck As System.Byte()
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(NamingTest2Metadata.ColumnNames.ConcurrencyCheck)
					Return CType(o, System.Byte())
                Else
					Return Me.Entity.ConcurrencyCheck
				End If				
			End Get
			
            Set(ByVal value As System.Byte())
				Me.Entity.ConcurrencyCheck = value
			End Set
			
		End Property

		<DataMember(Name:="GuidNewid", Order:=4, EmitDefaultValue:=False)> _		
        Public Property GuidNewid As Nullable(Of System.Guid)
        
            Get
                If Me.IncludeColumn(NamingTest2Metadata.ColumnNames.GuidNewid) Then
                    Return Me.Entity.GuidNewid
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Guid))
				Me.Entity.GuidNewid = value
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
        Public Property Entity As NamingTest2
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New NamingTest2()
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
        Public _entity As NamingTest2
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="NamingTest2Collection")> _
    <XmlType(TypeName:="NamingTest2CollectionProxyStub")> _
    <Serializable> _
    Partial Public Class NamingTest2CollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of NamingTest2))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of NamingTest2), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As NamingTest2CollectionProxyStub) As NamingTest2Collection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(NamingTest2)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of NamingTest2), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As NamingTest2 In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New NamingTest2ProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New NamingTest2ProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As NamingTest2 In coll.es.DeletedEntities
                    Collection.Add(New NamingTest2ProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of NamingTest2ProxyStub)		

        Public Function GetCollection As NamingTest2Collection
			
                If Me._coll is Nothing Then
                    Me._coll = New NamingTest2Collection()
					
		            Dim proxy As NamingTest2ProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As NamingTest2Collection
		
    End Class
	



	<Serializable> _
	Partial Public Class NamingTest2Metadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(NamingTest2Metadata.ColumnNames.IdentityKey, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = NamingTest2Metadata.PropertyNames.IdentityKey
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTest2Metadata.ColumnNames.ItemDescription, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = NamingTest2Metadata.PropertyNames.ItemDescription
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTest2Metadata.ColumnNames.ConcurrencyCheck, 2, GetType(System.Byte()), esSystemType.ByteArray)	
			c.PropertyName = NamingTest2Metadata.PropertyNames.ConcurrencyCheck
			c.CharacterMaxLength = 8
			c.IsComputed = True
			c.IsConcurrency = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTest2Metadata.ColumnNames.GuidNewid, 3, GetType(System.Guid), esSystemType.Guid)	
			c.PropertyName = NamingTest2Metadata.PropertyNames.GuidNewid
			c.HasDefault = True
			c.Default = "(newid())"
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As NamingTest2Metadata
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
			 Public Const IdentityKey As String = "Identity.Key"
			 Public Const ItemDescription As String = "Item.Description"
			 Public Const ConcurrencyCheck As String = "Concurrency.Check"
			 Public Const GuidNewid As String = "Guid.Newid"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const IdentityKey As String = "IdentityKey"
			 Public Const ItemDescription As String = "ItemDescription"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const GuidNewid As String = "GuidNewid"
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
			SyncLock GetType(NamingTest2Metadata)
			
				If NamingTest2Metadata.mapDelegates Is Nothing Then
					NamingTest2Metadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If NamingTest2Metadata._meta Is Nothing Then
					NamingTest2Metadata._meta = New NamingTest2Metadata()
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
				


				meta.AddTypeMap("IdentityKey", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ItemDescription", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte()"))
				meta.AddTypeMap("GuidNewid", new esTypeMap("uniqueidentifier", "System.Guid"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "Naming Test2"
				meta.Destination = "Naming Test2"
				
				meta.spInsert = "proc_Naming Test2Insert"
				meta.spUpdate = "proc_Naming Test2Update"
				meta.spDelete = "proc_Naming Test2Delete"
				meta.spLoadAll = "proc_Naming Test2LoadAll"
				meta.spLoadByPrimaryKey = "proc_Naming Test2LoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As NamingTest2Metadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
