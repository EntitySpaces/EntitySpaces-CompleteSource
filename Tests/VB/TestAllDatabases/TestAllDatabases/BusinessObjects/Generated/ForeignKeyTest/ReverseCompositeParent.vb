
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : SQL
' Date Generated       : 3/17/2012 4:51:53 AM
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
	' Encapsulates the 'ReverseCompositeParent' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(ReverseCompositeParent))> _
	<XmlType("ReverseCompositeParent")> _ 
	<Table(Name:="ReverseCompositeParent")> _	
	Partial Public Class ReverseCompositeParent 
		Inherits esReverseCompositeParent
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New ReverseCompositeParent()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal keySub As System.String, ByVal keyId As System.Int32)
			Dim obj As New ReverseCompositeParent()
			obj.KeySub = keySub
			obj.KeyId = keyId
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal keySub As System.String, ByVal keyId As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New ReverseCompositeParent()
			obj.KeySub = keySub
			obj.KeyId = keyId
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ReverseCompositeParent) As ReverseCompositeParentProxyStub
			Return New ReverseCompositeParentProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property KeySub As System.String
			Get
				Return MyBase.KeySub
			End Get
			Set
				MyBase.KeySub = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property KeyId As Nullable(Of System.Int32)
			Get
				Return MyBase.KeyId
			End Get
			Set
				MyBase.KeyId = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Description As System.String
			Get
				Return MyBase.Description
			End Get
			Set
				MyBase.Description = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ReverseCompositeParentCollection")> _
	Partial Public Class ReverseCompositeParentCollection
		Inherits esReverseCompositeParentCollection
		Implements IEnumerable(Of ReverseCompositeParent)
	
		Public Function FindByPrimaryKey(ByVal keySub As System.String, ByVal keyId As System.Int32) As ReverseCompositeParent
			Return MyBase.SingleOrDefault(Function(e) e.KeySub = keySub And e.KeyId.HasValue AndAlso e.KeyId.Value = keyId)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ReverseCompositeParentCollection) As ReverseCompositeParentCollectionProxyStub
            Return New ReverseCompositeParentCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(ReverseCompositeParent))> _
		Public Class ReverseCompositeParentCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ReverseCompositeParentCollection)
			
			Public Shared Widening Operator CType(packet As ReverseCompositeParentCollectionWCFPacket) As ReverseCompositeParentCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ReverseCompositeParentCollection) As ReverseCompositeParentCollectionWCFPacket
				Return New ReverseCompositeParentCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ReverseCompositeParentQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ReverseCompositeParentQuery 
		Inherits esReverseCompositeParentQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ReverseCompositeParentQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ReverseCompositeParentQuery) As String
			Return ReverseCompositeParentQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ReverseCompositeParentQuery
			Return DirectCast(ReverseCompositeParentQuery.SerializeHelper.FromXml(query, GetType(ReverseCompositeParentQuery)), ReverseCompositeParentQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esReverseCompositeParent
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal keySub As System.String, ByVal keyId As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(keySub, keyId)
			Else
				Return LoadByPrimaryKeyStoredProcedure(keySub, keyId)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal keySub As System.String, ByVal keyId As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(keySub, keyId)
			Else
				Return LoadByPrimaryKeyStoredProcedure(keySub, keyId)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal keySub As System.String, ByVal keyId As System.Int32) As Boolean
		
			Dim query As New ReverseCompositeParentQuery()
			query.Where(query.KeySub = keySub And query.KeyId = keyId)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal keySub As System.String, ByVal keyId As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("KeySub", keySub)
						parms.Add("KeyId", keyId)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to ReverseCompositeParent.KeySub
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property KeySub As System.String
			Get
				Return MyBase.GetSystemString(ReverseCompositeParentMetadata.ColumnNames.KeySub)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ReverseCompositeParentMetadata.ColumnNames.KeySub, value) Then
					OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.KeySub)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ReverseCompositeParent.KeyId
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property KeyId As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ReverseCompositeParentMetadata.ColumnNames.KeyId)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ReverseCompositeParentMetadata.ColumnNames.KeyId, value) Then
					OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.KeyId)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ReverseCompositeParent.Description
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Description As System.String
			Get
				Return MyBase.GetSystemString(ReverseCompositeParentMetadata.ColumnNames.Description)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ReverseCompositeParentMetadata.ColumnNames.Description, value) Then
					OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.Description)
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
												
						Case "KeySub"
							Me.str().KeySub = CType(value, string)
												
						Case "KeyId"
							Me.str().KeyId = CType(value, string)
												
						Case "Description"
							Me.str().Description = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "KeyId"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.KeyId = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ReverseCompositeParentMetadata.PropertyNames.KeyId)
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
		
			Public Sub New(ByVal entity As esReverseCompositeParent)
				Me.entity = entity
			End Sub				
		
	
			Public Property KeySub As System.String 
				Get
					Dim data_ As System.String = entity.KeySub
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.KeySub = Nothing
					Else
						entity.KeySub = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property KeyId As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.KeyId
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.KeyId = Nothing
					Else
						entity.KeyId = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property Description As System.String 
				Get
					Dim data_ As System.String = entity.Description
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Description = Nothing
					Else
						entity.Description = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esReverseCompositeParent
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ReverseCompositeParentMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ReverseCompositeParentQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ReverseCompositeParentQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ReverseCompositeParentQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ReverseCompositeParentQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ReverseCompositeParentQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esReverseCompositeParentCollection
		Inherits esEntityCollection(Of ReverseCompositeParent)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ReverseCompositeParentMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ReverseCompositeParentCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ReverseCompositeParentQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ReverseCompositeParentQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ReverseCompositeParentQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ReverseCompositeParentQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ReverseCompositeParentQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ReverseCompositeParentQuery))
		End Sub
		
		#End Region
						
		Private m_query As ReverseCompositeParentQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esReverseCompositeParentQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ReverseCompositeParentMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "KeySub" 
					Return Me.KeySub
				Case "KeyId" 
					Return Me.KeyId
				Case "Description" 
					Return Me.Description
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property KeySub As esQueryItem
			Get
				Return New esQueryItem(Me, ReverseCompositeParentMetadata.ColumnNames.KeySub, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property KeyId As esQueryItem
			Get
				Return New esQueryItem(Me, ReverseCompositeParentMetadata.ColumnNames.KeyId, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Description As esQueryItem
			Get
				Return New esQueryItem(Me, ReverseCompositeParentMetadata.ColumnNames.Description, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class ReverseCompositeParent 
		Inherits esReverseCompositeParent
		
	
		#Region "ReverseCompositeChildCollectionByParentKeyId - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_ReverseCompositeChildCollectionByParentKeyId() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.ReverseCompositeParent.ReverseCompositeChildCollectionByParentKeyId_Delegate)
				map.PropertyName = "ReverseCompositeChildCollectionByParentKeyId"
				map.MyColumnName = "ParentKeyId,ParentKeySub"
				map.ParentColumnName = "KeyId,KeySub"
				map.IsMultiPartKey = true
				Return map
			End Get
		End Property

		Private Shared Sub ReverseCompositeChildCollectionByParentKeyId_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New ReverseCompositeParentQuery(data.NextAlias())
			
			Dim mee As ReverseCompositeChildQuery = If(data.You IsNot Nothing, TryCast(data.You, ReverseCompositeChildQuery), New ReverseCompositeChildQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.KeyId = mee.ParentKeyId And parent.KeySub = mee.ParentKeySub)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_ReverseCompositeChild_ReverseCompositeParent
		''' </summary>

		<XmlIgnore()> _ 
		Public Property ReverseCompositeChildCollectionByParentKeyId As ReverseCompositeChildCollection 
		
			Get
				If Me._ReverseCompositeChildCollectionByParentKeyId Is Nothing Then
					Me._ReverseCompositeChildCollectionByParentKeyId = New ReverseCompositeChildCollection()
					Me._ReverseCompositeChildCollectionByParentKeyId.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("ReverseCompositeChildCollectionByParentKeyId", Me._ReverseCompositeChildCollectionByParentKeyId)
				
					If Not Me.KeyId.Equals(Nothing) AndAlso Not Me.KeySub.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._ReverseCompositeChildCollectionByParentKeyId.Query.Where(Me._ReverseCompositeChildCollectionByParentKeyId.Query.ParentKeyId = Me.KeyId)
							Me._ReverseCompositeChildCollectionByParentKeyId.Query.Where(Me._ReverseCompositeChildCollectionByParentKeyId.Query.ParentKeySub = Me.KeySub)
							Me._ReverseCompositeChildCollectionByParentKeyId.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._ReverseCompositeChildCollectionByParentKeyId.fks.Add(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, Me.KeyId)
						Me._ReverseCompositeChildCollectionByParentKeyId.fks.Add(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, Me.KeySub)
					End If
				End If

				Return Me._ReverseCompositeChildCollectionByParentKeyId
			End Get
			
			Set(ByVal value As ReverseCompositeChildCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._ReverseCompositeChildCollectionByParentKeyId Is Nothing Then

					Me.RemovePostSave("ReverseCompositeChildCollectionByParentKeyId")
					Me._ReverseCompositeChildCollectionByParentKeyId = Nothing
					Me.OnPropertyChanged("ReverseCompositeChildCollectionByParentKeyId")

				End If
			End Set				
			
		End Property
		

		private _ReverseCompositeChildCollectionByParentKeyId As ReverseCompositeChildCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "ReverseCompositeChildCollectionByParentKeyId"
					coll = Me.ReverseCompositeChildCollectionByParentKeyId
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "ReverseCompositeChildCollectionByParentKeyId", GetType(ReverseCompositeChildCollection), New ReverseCompositeChild()))
			Return props
			
		End Function
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="ReverseCompositeParent")> _
    <XmlType(TypeName:="ReverseCompositeParentProxyStub")> _
    <Serializable> _
    Partial Public Class ReverseCompositeParentProxyStub
	
		Public Sub New()
            Me._entity = New ReverseCompositeParent()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ReverseCompositeParent)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ReverseCompositeParent, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ReverseCompositeParentProxyStub) As ReverseCompositeParent
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(ReverseCompositeParent)
        End Function
		

		<DataMember(Name:="KeySub", Order:=1, EmitDefaultValue:=False)> _		
        Public Property KeySub As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ReverseCompositeParentMetadata.ColumnNames.KeySub)
					Return CType(o, System.String)
                Else
					Return Me.Entity.KeySub
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.KeySub = value
			End Set
			
		End Property

		<DataMember(Name:="KeyId", Order:=2, EmitDefaultValue:=False)> _		
        Public Property KeyId As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ReverseCompositeParentMetadata.ColumnNames.KeyId)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.KeyId
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.KeyId = value
			End Set
			
		End Property

		<DataMember(Name:="Description", Order:=3, EmitDefaultValue:=False)> _		
        Public Property Description As System.String
        
            Get
                If Me.IncludeColumn(ReverseCompositeParentMetadata.ColumnNames.Description) Then
                    Return Me.Entity.Description
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Description = value
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
        Public Property Entity As ReverseCompositeParent
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New ReverseCompositeParent()
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
        Public _entity As ReverseCompositeParent
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ReverseCompositeParentCollection")> _
    <XmlType(TypeName:="ReverseCompositeParentCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ReverseCompositeParentCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of ReverseCompositeParent))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of ReverseCompositeParent), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ReverseCompositeParentCollectionProxyStub) As ReverseCompositeParentCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(ReverseCompositeParent)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of ReverseCompositeParent), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As ReverseCompositeParent In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ReverseCompositeParentProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ReverseCompositeParentProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As ReverseCompositeParent In coll.es.DeletedEntities
                    Collection.Add(New ReverseCompositeParentProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ReverseCompositeParentProxyStub)		

        Public Function GetCollection As ReverseCompositeParentCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ReverseCompositeParentCollection()
					
		            Dim proxy As ReverseCompositeParentProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ReverseCompositeParentCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ReverseCompositeParentMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ReverseCompositeParentMetadata.ColumnNames.KeySub, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = ReverseCompositeParentMetadata.PropertyNames.KeySub
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(ReverseCompositeParentMetadata.ColumnNames.KeyId, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ReverseCompositeParentMetadata.PropertyNames.KeyId
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ReverseCompositeParentMetadata.ColumnNames.Description, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = ReverseCompositeParentMetadata.PropertyNames.Description
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ReverseCompositeParentMetadata
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
			 Public Const KeySub As String = "KeySub"
			 Public Const KeyId As String = "KeyId"
			 Public Const Description As String = "Description"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const KeySub As String = "KeySub"
			 Public Const KeyId As String = "KeyId"
			 Public Const Description As String = "Description"
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
			SyncLock GetType(ReverseCompositeParentMetadata)
			
				If ReverseCompositeParentMetadata.mapDelegates Is Nothing Then
					ReverseCompositeParentMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ReverseCompositeParentMetadata._meta Is Nothing Then
					ReverseCompositeParentMetadata._meta = New ReverseCompositeParentMetadata()
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
				


				meta.AddTypeMap("KeySub", new esTypeMap("char", "System.String"))
				meta.AddTypeMap("KeyId", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "ReverseCompositeParent"
				meta.Destination = "ReverseCompositeParent"
				
				meta.spInsert = "proc_ReverseCompositeParentInsert"
				meta.spUpdate = "proc_ReverseCompositeParentUpdate"
				meta.spDelete = "proc_ReverseCompositeParentDelete"
				meta.spLoadAll = "proc_ReverseCompositeParentLoadAll"
				meta.spLoadByPrimaryKey = "proc_ReverseCompositeParentLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ReverseCompositeParentMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
