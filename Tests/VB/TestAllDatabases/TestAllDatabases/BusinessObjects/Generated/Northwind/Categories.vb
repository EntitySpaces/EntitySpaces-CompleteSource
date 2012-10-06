
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
	' Encapsulates the 'Categories' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Categories))> _
	<XmlType("Categories")> _ 
	<Table(Name:="Categories")> _	
	Partial Public Class Categories 
		Inherits esCategories
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Categories()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal categoryID As System.Int32)
			Dim obj As New Categories()
			obj.CategoryID = categoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal categoryID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Categories()
			obj.CategoryID = categoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Categories) As CategoriesProxyStub
			Return New CategoriesProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property CategoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.CategoryID
			End Get
			Set
				MyBase.CategoryID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property CategoryName As System.String
			Get
				Return MyBase.CategoryName
			End Get
			Set
				MyBase.CategoryName = value
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

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Picture As System.Byte()
			Get
				Return MyBase.Picture
			End Get
			Set
				MyBase.Picture = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<DebuggerVisualizer(GetType(EntitySpaces.DebuggerVisualizer.esVisualizer))> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("CategoriesCollection")> _
	Partial Public Class CategoriesCollection
		Inherits esCategoriesCollection
		Implements IEnumerable(Of Categories)
	
		Public Function FindByPrimaryKey(ByVal categoryID As System.Int32) As Categories
			Return MyBase.SingleOrDefault(Function(e) e.CategoryID.HasValue AndAlso e.CategoryID.Value = categoryID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As CategoriesCollection) As CategoriesCollectionProxyStub
            Return New CategoriesCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Categories))> _
		Public Class CategoriesCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of CategoriesCollection)
			
			Public Shared Widening Operator CType(packet As CategoriesCollectionWCFPacket) As CategoriesCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As CategoriesCollection) As CategoriesCollectionWCFPacket
				Return New CategoriesCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "CategoriesQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class CategoriesQuery 
		Inherits esCategoriesQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CategoriesQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As CategoriesQuery) As String
			Return CategoriesQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As CategoriesQuery
			Return DirectCast(CategoriesQuery.SerializeHelper.FromXml(query, GetType(CategoriesQuery)), CategoriesQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esCategories
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal categoryID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(categoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(categoryID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal categoryID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(categoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(categoryID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal categoryID As System.Int32) As Boolean
		
			Dim query As New CategoriesQuery()
			query.Where(query.CategoryID = categoryID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal categoryID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("CategoryID", categoryID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Categories.CategoryID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CategoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(CategoriesMetadata.ColumnNames.CategoryID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(CategoriesMetadata.ColumnNames.CategoryID, value) Then
					OnPropertyChanged(CategoriesMetadata.PropertyNames.CategoryID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Categories.CategoryName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CategoryName As System.String
			Get
				Return MyBase.GetSystemString(CategoriesMetadata.ColumnNames.CategoryName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CategoriesMetadata.ColumnNames.CategoryName, value) Then
					OnPropertyChanged(CategoriesMetadata.PropertyNames.CategoryName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Categories.Description
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Description As System.String
			Get
				Return MyBase.GetSystemString(CategoriesMetadata.ColumnNames.Description)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CategoriesMetadata.ColumnNames.Description, value) Then
					OnPropertyChanged(CategoriesMetadata.PropertyNames.Description)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Categories.Picture
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Picture As System.Byte()
			Get
				Return MyBase.GetSystemByteArray(CategoriesMetadata.ColumnNames.Picture)
			End Get
			
			Set(ByVal value As System.Byte())
				If MyBase.SetSystemByteArray(CategoriesMetadata.ColumnNames.Picture, value) Then
					OnPropertyChanged(CategoriesMetadata.PropertyNames.Picture)
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
												
						Case "CategoryID"
							Me.str().CategoryID = CType(value, string)
												
						Case "CategoryName"
							Me.str().CategoryName = CType(value, string)
												
						Case "Description"
							Me.str().Description = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "CategoryID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.CategoryID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(CategoriesMetadata.PropertyNames.CategoryID)
							End If
						
						Case "Picture"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Byte()" Then
								Me.Picture = CType(value, System.Byte())
								OnPropertyChanged(CategoriesMetadata.PropertyNames.Picture)
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
		
			Public Sub New(ByVal entity As esCategories)
				Me.entity = entity
			End Sub				
		
	
			Public Property CategoryID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.CategoryID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CategoryID = Nothing
					Else
						entity.CategoryID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property CategoryName As System.String 
				Get
					Dim data_ As System.String = entity.CategoryName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CategoryName = Nothing
					Else
						entity.CategoryName = Convert.ToString(Value)
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
		  

			Private entity As esCategories
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CategoriesMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CategoriesQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CategoriesQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CategoriesQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CategoriesQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As CategoriesQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esCategoriesCollection
		Inherits CollectionBase(Of Categories)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CategoriesMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CategoriesCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As CategoriesQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CategoriesQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CategoriesQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CategoriesQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CategoriesQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CategoriesQuery))
		End Sub
		
		#End Region
						
		Private m_query As CategoriesQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esCategoriesQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CategoriesMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "CategoryID" 
					Return Me.CategoryID
				Case "CategoryName" 
					Return Me.CategoryName
				Case "Description" 
					Return Me.Description
				Case "Picture" 
					Return Me.Picture
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property CategoryID As esQueryItem
			Get
				Return New esQueryItem(Me, CategoriesMetadata.ColumnNames.CategoryID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property CategoryName As esQueryItem
			Get
				Return New esQueryItem(Me, CategoriesMetadata.ColumnNames.CategoryName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Description As esQueryItem
			Get
				Return New esQueryItem(Me, CategoriesMetadata.ColumnNames.Description, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Picture As esQueryItem
			Get
				Return New esQueryItem(Me, CategoriesMetadata.ColumnNames.Picture, esSystemType.ByteArray)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Categories 
		Inherits esCategories
		
	
		#Region "ProductsCollectionByCategoryID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_ProductsCollectionByCategoryID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Categories.ProductsCollectionByCategoryID_Delegate)
				map.PropertyName = "ProductsCollectionByCategoryID"
				map.MyColumnName = "CategoryID"
				map.ParentColumnName = "CategoryID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub ProductsCollectionByCategoryID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New CategoriesQuery(data.NextAlias())
			
			Dim mee As ProductsQuery = If(data.You IsNot Nothing, TryCast(data.You, ProductsQuery), New ProductsQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.CategoryID = mee.CategoryID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Products_Categories
		''' </summary>

		<XmlIgnore()> _ 
		Public Property ProductsCollectionByCategoryID As ProductsCollection 
		
			Get
				If Me._ProductsCollectionByCategoryID Is Nothing Then
					Me._ProductsCollectionByCategoryID = New ProductsCollection()
					Me._ProductsCollectionByCategoryID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("ProductsCollectionByCategoryID", Me._ProductsCollectionByCategoryID)
				
					If Not Me.CategoryID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._ProductsCollectionByCategoryID.Query.Where(Me._ProductsCollectionByCategoryID.Query.CategoryID = Me.CategoryID)
							Me._ProductsCollectionByCategoryID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._ProductsCollectionByCategoryID.fks.Add(ProductsMetadata.ColumnNames.CategoryID, Me.CategoryID)
					End If
				End If

				Return Me._ProductsCollectionByCategoryID
			End Get
			
			Set(ByVal value As ProductsCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._ProductsCollectionByCategoryID Is Nothing Then

					Me.RemovePostSave("ProductsCollectionByCategoryID")
					Me._ProductsCollectionByCategoryID = Nothing
					Me.OnPropertyChanged("ProductsCollectionByCategoryID")

				End If
			End Set				
			
		End Property
		

		private _ProductsCollectionByCategoryID As ProductsCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "ProductsCollectionByCategoryID"
					coll = Me.ProductsCollectionByCategoryID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "ProductsCollectionByCategoryID", GetType(ProductsCollection), New Products()))
			Return props
			
		End Function
		
		''' <summary>
		''' Called by ApplyPostSaveKeys 
		''' </summary>
		''' <param name="coll">The collection to enumerate over</param>
		''' <param name="key">"The column name</param>
		''' <param name="value">The column value</param>
		Private Sub Apply(coll As esEntityCollectionBase, key As String, value As Object)
			For Each obj As esEntity In coll
				If obj.es.IsAdded Then
					obj.SetProperty(key, value)
				End If
			Next
		End Sub
		
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PostSave.
		''' </summary>
		Protected Overrides Sub ApplyPostSaveKeys()
		
			If Not Me._ProductsCollectionByCategoryID Is Nothing Then
				Apply(Me._ProductsCollectionByCategoryID, "CategoryID", Me.CategoryID)
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Categories")> _
    <XmlType(TypeName:="CategoriesProxyStub")> _
    <Serializable> _
    Partial Public Class CategoriesProxyStub
	
		Public Sub New()
            Me._entity = New Categories()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Categories)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Categories, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As CategoriesProxyStub) As Categories
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Categories)
        End Function
		

		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _		
        Public Property CategoryID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CategoriesMetadata.ColumnNames.CategoryID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.CategoryID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.CategoryID = value
			End Set
			
		End Property

		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _		
        Public Property CategoryName As System.String
        
            Get
                If Me.IncludeColumn(CategoriesMetadata.ColumnNames.CategoryName) Then
                    Return Me.Entity.CategoryName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CategoryName = value
			End Set
			
		End Property

		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _		
        Public Property Description As System.String
        
            Get
                If Me.IncludeColumn(CategoriesMetadata.ColumnNames.Description) Then
                    Return Me.Entity.Description
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Description = value
			End Set
			
		End Property

		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Picture As System.Byte()
        
            Get
                If Me.IncludeColumn(CategoriesMetadata.ColumnNames.Picture) Then
                    Return Me.Entity.Picture
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.Byte())
				Me.Entity.Picture = value
			End Set
			
		End Property


		<DataMember(Name := "a10000", Order := 10000)> _
        Public Property esRowState As String
            Get
				Return Me.TheRowState
            End Get

            Set 
				Me.TheRowState = value
            End Set
        End Property
		
		<DataMember(Name := "a10001", Order := 10001, EmitDefaultValue := False)> _
		Private Property ModifiedColumns() As List(Of String)
			Get
				Return Entity.es.ModifiedColumns
			End Get
			Set(ByVal value As List(Of String))
				Entity.es.ModifiedColumns.AddRange(value)
			End Set
		End Property		
		
		<DataMember(Name := "a10002", Order := 10002, EmitDefaultValue := False)> _
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
        Public Property Entity As Categories
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Categories()
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
        Public _entity As Categories
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="CategoriesCollection")> _
    <XmlType(TypeName:="CategoriesCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class CategoriesCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Categories))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Categories), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As CategoriesCollectionProxyStub) As CategoriesCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Categories)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Categories), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Categories In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New CategoriesProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New CategoriesProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Categories In coll.es.DeletedEntities
                    Collection.Add(New CategoriesProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of CategoriesProxyStub)		

        Public Function GetCollection As CategoriesCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New CategoriesCollection()
					
		            Dim proxy As CategoriesProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As CategoriesCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class CategoriesMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CategoriesMetadata.ColumnNames.CategoryID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = CategoriesMetadata.PropertyNames.CategoryID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(CategoriesMetadata.ColumnNames.CategoryName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CategoriesMetadata.PropertyNames.CategoryName
			c.CharacterMaxLength = 15
			m_columns.Add(c)
				
			c = New esColumnMetadata(CategoriesMetadata.ColumnNames.Description, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = CategoriesMetadata.PropertyNames.Description
			c.CharacterMaxLength = 1073741823
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CategoriesMetadata.ColumnNames.Picture, 3, GetType(System.Byte()), esSystemType.ByteArray)	
			c.PropertyName = CategoriesMetadata.PropertyNames.Picture
			c.CharacterMaxLength = 2147483647
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As CategoriesMetadata
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
			 Public Const CategoryID As String = "CategoryID"
			 Public Const CategoryName As String = "CategoryName"
			 Public Const Description As String = "Description"
			 Public Const Picture As String = "Picture"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const CategoryID As String = "CategoryID"
			 Public Const CategoryName As String = "CategoryName"
			 Public Const Description As String = "Description"
			 Public Const Picture As String = "Picture"
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
			SyncLock GetType(CategoriesMetadata)
			
				If CategoriesMetadata.mapDelegates Is Nothing Then
					CategoriesMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CategoriesMetadata._meta Is Nothing Then
					CategoriesMetadata._meta = New CategoriesMetadata()
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
				


				meta.AddTypeMap("CategoryID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("CategoryName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Description", new esTypeMap("ntext", "System.String"))
				meta.AddTypeMap("Picture", new esTypeMap("image", "System.Byte()"))			
				meta.Catalog = "Northwind"
				meta.Schema = "dbo"
				 
				meta.Source = "Categories"
				meta.Destination = "Categories"
				
				meta.spInsert = "proc_CategoriesInsert"
				meta.spUpdate = "proc_CategoriesUpdate"
				meta.spDelete = "proc_CategoriesDelete"
				meta.spLoadAll = "proc_CategoriesLoadAll"
				meta.spLoadByPrimaryKey = "proc_CategoriesLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CategoriesMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
