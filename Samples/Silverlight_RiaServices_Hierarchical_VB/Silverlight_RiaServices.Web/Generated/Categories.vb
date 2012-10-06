
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:24 PM
'===============================================================================

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization
Imports System.ServiceModel.DomainServices.Server
Imports System.ComponentModel.DataAnnotations

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
	
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("CategoriesCollection")> _
	Partial Public Class CategoriesCollection
		Inherits esCategoriesCollection
		Implements IEnumerable(Of Categories)
	
		Public Function FindByPrimaryKey(ByVal categoryID As System.Int32) As Categories
			Return MyBase.SingleOrDefault(Function(e) e.CategoryID.HasValue AndAlso e.CategoryID.Value = categoryID)
		End Function


				
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
		Inherits esEntity
		Implements INotifyPropertyChanged
	
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
				
		' For Ria Services
		<DataMember(EmitDefaultValue:=False)> _
		<Display(AutoGenerateField:=False)> _
		Public Property esExtendedData() As String
			Get
				Return GetExtraColumnsSerialized()
			End Get
			
			Private Set
			End Set
		End Property
		
			
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
		Inherits esEntityCollection(Of Categories)
		
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
		Inherits esDynamicQuery 
	
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
		<Include()> _ 
		<System.ComponentModel.DataAnnotations.Association("Categories.ProductsCollectionByCategoryID", "CategoryID", "CategoryID")> _ 
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
				Return false
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
