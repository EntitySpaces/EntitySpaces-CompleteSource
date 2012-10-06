
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
	' Encapsulates the 'CustomerGroup' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(CustomerGroup))> _
	<XmlType("CustomerGroup")> _ 
	<Table(Name:="CustomerGroup")> _	
	Partial Public Class CustomerGroup 
		Inherits esCustomerGroup
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New CustomerGroup()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal groupID As System.String)
			Dim obj As New CustomerGroup()
			obj.GroupID = groupID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal groupID As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New CustomerGroup()
			obj.GroupID = groupID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As CustomerGroup) As CustomerGroupProxyStub
			Return New CustomerGroupProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property GroupID As System.String
			Get
				Return MyBase.GroupID
			End Get
			Set
				MyBase.GroupID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property GroupName As System.String
			Get
				Return MyBase.GroupName
			End Get
			Set
				MyBase.GroupName = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("CustomerGroupCollection")> _
	Partial Public Class CustomerGroupCollection
		Inherits esCustomerGroupCollection
		Implements IEnumerable(Of CustomerGroup)
	
		Public Function FindByPrimaryKey(ByVal groupID As System.String) As CustomerGroup
			Return MyBase.SingleOrDefault(Function(e) e.GroupID = groupID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As CustomerGroupCollection) As CustomerGroupCollectionProxyStub
            Return New CustomerGroupCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(CustomerGroup))> _
		Public Class CustomerGroupCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of CustomerGroupCollection)
			
			Public Shared Widening Operator CType(packet As CustomerGroupCollectionWCFPacket) As CustomerGroupCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As CustomerGroupCollection) As CustomerGroupCollectionWCFPacket
				Return New CustomerGroupCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "CustomerGroupQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class CustomerGroupQuery 
		Inherits esCustomerGroupQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CustomerGroupQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As CustomerGroupQuery) As String
			Return CustomerGroupQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As CustomerGroupQuery
			Return DirectCast(CustomerGroupQuery.SerializeHelper.FromXml(query, GetType(CustomerGroupQuery)), CustomerGroupQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esCustomerGroup
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal groupID As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(groupID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(groupID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal groupID As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(groupID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(groupID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal groupID As System.String) As Boolean
		
			Dim query As New CustomerGroupQuery()
			query.Where(query.GroupID = groupID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal groupID As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("GroupID", groupID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to CustomerGroup.GroupID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property GroupID As System.String
			Get
				Return MyBase.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupID, value) Then
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to CustomerGroup.GroupName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property GroupName As System.String
			Get
				Return MyBase.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupName, value) Then
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupName)
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
												
						Case "GroupID"
							Me.str().GroupID = CType(value, string)
												
						Case "GroupName"
							Me.str().GroupName = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
					
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
		
			Public Sub New(ByVal entity As esCustomerGroup)
				Me.entity = entity
			End Sub				
		
	
			Public Property GroupID As System.String 
				Get
					Dim data_ As System.String = entity.GroupID
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.GroupID = Nothing
					Else
						entity.GroupID = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property GroupName As System.String 
				Get
					Dim data_ As System.String = entity.GroupName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.GroupName = Nothing
					Else
						entity.GroupName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esCustomerGroup
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerGroupMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CustomerGroupQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerGroupQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CustomerGroupQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CustomerGroupQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As CustomerGroupQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esCustomerGroupCollection
		Inherits esEntityCollection(Of CustomerGroup)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerGroupMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CustomerGroupCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As CustomerGroupQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerGroupQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CustomerGroupQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CustomerGroupQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CustomerGroupQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CustomerGroupQuery))
		End Sub
		
		#End Region
						
		Private m_query As CustomerGroupQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esCustomerGroupQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CustomerGroupMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "GroupID" 
					Return Me.GroupID
				Case "GroupName" 
					Return Me.GroupName
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property GroupID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerGroupMetadata.ColumnNames.GroupID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property GroupName As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerGroupMetadata.ColumnNames.GroupName, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class CustomerGroup 
		Inherits esCustomerGroup
		
	
		#Region "CustomerCollectionByCustomerID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_CustomerCollectionByCustomerID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.CustomerGroup.CustomerCollectionByCustomerID_Delegate)
				map.PropertyName = "CustomerCollectionByCustomerID"
				map.MyColumnName = "CustomerID"
				map.ParentColumnName = "GroupID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub CustomerCollectionByCustomerID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New CustomerGroupQuery(data.NextAlias())
			
			Dim mee As CustomerQuery = If(data.You IsNot Nothing, TryCast(data.You, CustomerQuery), New CustomerQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.GroupID = mee.CustomerID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Customer_CustomerGroup
		''' </summary>

		<XmlIgnore()> _ 
		Public Property CustomerCollectionByCustomerID As CustomerCollection 
		
			Get
				If Me._CustomerCollectionByCustomerID Is Nothing Then
					Me._CustomerCollectionByCustomerID = New CustomerCollection()
					Me._CustomerCollectionByCustomerID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("CustomerCollectionByCustomerID", Me._CustomerCollectionByCustomerID)
				
					If Not Me.GroupID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._CustomerCollectionByCustomerID.Query.Where(Me._CustomerCollectionByCustomerID.Query.CustomerID = Me.GroupID)
							Me._CustomerCollectionByCustomerID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._CustomerCollectionByCustomerID.fks.Add(CustomerMetadata.ColumnNames.CustomerID, Me.GroupID)
					End If
				End If

				Return Me._CustomerCollectionByCustomerID
			End Get
			
			Set(ByVal value As CustomerCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._CustomerCollectionByCustomerID Is Nothing Then

					Me.RemovePostSave("CustomerCollectionByCustomerID")
					Me._CustomerCollectionByCustomerID = Nothing
					Me.OnPropertyChanged("CustomerCollectionByCustomerID")

				End If
			End Set				
			
		End Property
		

		private _CustomerCollectionByCustomerID As CustomerCollection
		#End Region

				
		#Region "Group - One To One"
		''' <summary>
		''' One to One
		''' Foreign Key Name - FK_Group_CustGroup
		''' </summary>

		<XmlIgnore()> _
		Public Property Group As Group
		
			Get
				If Me._Group Is Nothing Then
					Me._Group = New Group()
					Me._Group.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostOneSave("Group", Me._Group)
				
					If Not Me.GroupID.Equals(Nothing) Then
						Me._Group.Query.Where(Me._Group.Query.Id = Me.GroupID)
						Me._Group.Query.Load()
					End If
				End If

				Return Me._Group
			End Get
			
			Set(ByVal value As Group)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._Group Is Nothing Then

					Me.RemovePostOneSave("Group")
					Me._Group = Nothing
					Me.OnPropertyChanged("Group")

				End If
			End Set			
			
		End Property
				

		Private _Group As Group
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "CustomerCollectionByCustomerID"
					coll = Me.CustomerCollectionByCustomerID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "CustomerCollectionByCustomerID", GetType(CustomerCollection), New Customer()))
			Return props
			
		End Function
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="CustomerGroup")> _
    <XmlType(TypeName:="CustomerGroupProxyStub")> _
    <Serializable> _
    Partial Public Class CustomerGroupProxyStub
	
		Public Sub New()
            Me._entity = New CustomerGroup()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As CustomerGroup)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As CustomerGroup, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As CustomerGroupProxyStub) As CustomerGroup
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(CustomerGroup)
        End Function
		

		<DataMember(Name:="GroupID", Order:=1, EmitDefaultValue:=False)> _		
        Public Property GroupID As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CustomerGroupMetadata.ColumnNames.GroupID)
					Return CType(o, System.String)
                Else
					Return Me.Entity.GroupID
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.GroupID = value
			End Set
			
		End Property

		<DataMember(Name:="GroupName", Order:=2, EmitDefaultValue:=False)> _		
        Public Property GroupName As System.String
        
            Get
                If Me.IncludeColumn(CustomerGroupMetadata.ColumnNames.GroupName) Then
                    Return Me.Entity.GroupName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.GroupName = value
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
        Public Property Entity As CustomerGroup
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New CustomerGroup()
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
        Public _entity As CustomerGroup
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="CustomerGroupCollection")> _
    <XmlType(TypeName:="CustomerGroupCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class CustomerGroupCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of CustomerGroup))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of CustomerGroup), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As CustomerGroupCollectionProxyStub) As CustomerGroupCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(CustomerGroup)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of CustomerGroup), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As CustomerGroup In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New CustomerGroupProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New CustomerGroupProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As CustomerGroup In coll.es.DeletedEntities
                    Collection.Add(New CustomerGroupProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of CustomerGroupProxyStub)		

        Public Function GetCollection As CustomerGroupCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New CustomerGroupCollection()
					
		            Dim proxy As CustomerGroupProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As CustomerGroupCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class CustomerGroupMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupID, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupName
			c.CharacterMaxLength = 25
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As CustomerGroupMetadata
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
			 Public Const GroupID As String = "GroupID"
			 Public Const GroupName As String = "GroupName"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const GroupID As String = "GroupID"
			 Public Const GroupName As String = "GroupName"
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
			SyncLock GetType(CustomerGroupMetadata)
			
				If CustomerGroupMetadata.mapDelegates Is Nothing Then
					CustomerGroupMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CustomerGroupMetadata._meta Is Nothing Then
					CustomerGroupMetadata._meta = New CustomerGroupMetadata()
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
				


				meta.AddTypeMap("GroupID", new esTypeMap("char", "System.String"))
				meta.AddTypeMap("GroupName", new esTypeMap("varchar", "System.String"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "CustomerGroup"
				meta.Destination = "CustomerGroup"
				
				meta.spInsert = "proc_CustomerGroupInsert"
				meta.spUpdate = "proc_CustomerGroupUpdate"
				meta.spDelete = "proc_CustomerGroupDelete"
				meta.spLoadAll = "proc_CustomerGroupLoadAll"
				meta.spLoadByPrimaryKey = "proc_CustomerGroupLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CustomerGroupMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
