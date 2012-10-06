
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:22 PM
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

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery



Namespace BusinessObjects

	' <summary>
	' Encapsulates the 'Products' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Products))> _
	<XmlType("Products")> _	
	Partial Public Class Products 
		Inherits esProducts
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Products()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal productID As System.Int32)
			Dim obj As New Products()
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal productID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Products()
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ProductsCollection")> _
	Partial Public Class ProductsCollection
		Inherits esProductsCollection
		Implements IEnumerable(Of Products)
	
		Public Function FindByPrimaryKey(ByVal productID As System.Int32) As Products
			Return MyBase.SingleOrDefault(Function(e) e.ProductID.HasValue AndAlso e.ProductID.Value = productID)
		End Function


				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Products))> _
		Public Class ProductsCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ProductsCollection)
			
			Public Shared Widening Operator CType(packet As ProductsCollectionWCFPacket) As ProductsCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ProductsCollection) As ProductsCollectionWCFPacket
				Return New ProductsCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "ProductsQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ProductsQuery 
		Inherits esProductsQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ProductsQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ProductsQuery) As String
			Return ProductsQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ProductsQuery
			Return DirectCast(ProductsQuery.SerializeHelper.FromXml(query, GetType(ProductsQuery)), ProductsQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esProducts
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal productID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(productID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(productID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal productID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(productID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(productID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal productID As System.Int32) As Boolean
		
			Dim query As New ProductsQuery()
			query.Where(query.ProductID = productID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal productID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("ProductID", productID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Products.ProductID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ProductID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ProductsMetadata.ColumnNames.ProductID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ProductsMetadata.ColumnNames.ProductID, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.ProductID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.ProductName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ProductName As System.String
			Get
				Return MyBase.GetSystemString(ProductsMetadata.ColumnNames.ProductName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ProductsMetadata.ColumnNames.ProductName, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.ProductName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.SupplierID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property SupplierID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ProductsMetadata.ColumnNames.SupplierID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ProductsMetadata.ColumnNames.SupplierID, value) Then
					Me._UpToSuppliersBySupplierID = Nothing
					Me.OnPropertyChanged("UpToSuppliersBySupplierID")
					OnPropertyChanged(ProductsMetadata.PropertyNames.SupplierID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.CategoryID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CategoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ProductsMetadata.ColumnNames.CategoryID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ProductsMetadata.ColumnNames.CategoryID, value) Then
					Me._UpToCategoriesByCategoryID = Nothing
					Me.OnPropertyChanged("UpToCategoriesByCategoryID")
					OnPropertyChanged(ProductsMetadata.PropertyNames.CategoryID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.QuantityPerUnit
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property QuantityPerUnit As System.String
			Get
				Return MyBase.GetSystemString(ProductsMetadata.ColumnNames.QuantityPerUnit)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ProductsMetadata.ColumnNames.QuantityPerUnit, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.QuantityPerUnit)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.UnitPrice
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(ProductsMetadata.ColumnNames.UnitPrice)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(ProductsMetadata.ColumnNames.UnitPrice, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.UnitPrice)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.UnitsInStock
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property UnitsInStock As Nullable(Of System.Int16)
			Get
				Return MyBase.GetSystemInt16(ProductsMetadata.ColumnNames.UnitsInStock)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int16))
				If MyBase.SetSystemInt16(ProductsMetadata.ColumnNames.UnitsInStock, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsInStock)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.UnitsOnOrder
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property UnitsOnOrder As Nullable(Of System.Int16)
			Get
				Return MyBase.GetSystemInt16(ProductsMetadata.ColumnNames.UnitsOnOrder)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int16))
				If MyBase.SetSystemInt16(ProductsMetadata.ColumnNames.UnitsOnOrder, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsOnOrder)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.ReorderLevel
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ReorderLevel As Nullable(Of System.Int16)
			Get
				Return MyBase.GetSystemInt16(ProductsMetadata.ColumnNames.ReorderLevel)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int16))
				If MyBase.SetSystemInt16(ProductsMetadata.ColumnNames.ReorderLevel, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.ReorderLevel)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Products.Discontinued
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Discontinued As Nullable(Of System.Boolean)
			Get
				Return MyBase.GetSystemBoolean(ProductsMetadata.ColumnNames.Discontinued)
			End Get
			
			Set(ByVal value As Nullable(Of System.Boolean))
				If MyBase.SetSystemBoolean(ProductsMetadata.ColumnNames.Discontinued, value) Then
					OnPropertyChanged(ProductsMetadata.PropertyNames.Discontinued)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToCategoriesByCategoryID As Categories
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToSuppliersBySupplierID As Suppliers
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ProductsMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ProductsQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ProductsQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ProductsQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ProductsQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ProductsQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esProductsCollection
		Inherits esEntityCollection(Of Products)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ProductsMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ProductsCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ProductsQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ProductsQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ProductsQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ProductsQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ProductsQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ProductsQuery))
		End Sub
		
		#End Region
						
		Private m_query As ProductsQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esProductsQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ProductsMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "ProductID" 
					Return Me.ProductID
				Case "ProductName" 
					Return Me.ProductName
				Case "SupplierID" 
					Return Me.SupplierID
				Case "CategoryID" 
					Return Me.CategoryID
				Case "QuantityPerUnit" 
					Return Me.QuantityPerUnit
				Case "UnitPrice" 
					Return Me.UnitPrice
				Case "UnitsInStock" 
					Return Me.UnitsInStock
				Case "UnitsOnOrder" 
					Return Me.UnitsOnOrder
				Case "ReorderLevel" 
					Return Me.ReorderLevel
				Case "Discontinued" 
					Return Me.Discontinued
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property ProductID As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.ProductID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ProductName As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.ProductName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property SupplierID As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.SupplierID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property CategoryID As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.CategoryID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property QuantityPerUnit As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.QuantityPerUnit, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property UnitPrice As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.UnitPrice, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property UnitsInStock As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.UnitsInStock, esSystemType.Int16)
			End Get
		End Property 
		
		Public ReadOnly Property UnitsOnOrder As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.UnitsOnOrder, esSystemType.Int16)
			End Get
		End Property 
		
		Public ReadOnly Property ReorderLevel As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.ReorderLevel, esSystemType.Int16)
			End Get
		End Property 
		
		Public ReadOnly Property Discontinued As esQueryItem
			Get
				Return New esQueryItem(Me, ProductsMetadata.ColumnNames.Discontinued, esSystemType.Boolean)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Products 
		Inherits esProducts
		
	
		#Region "UpToOrdersCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_Order_Details_Products
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToOrdersCollection As OrdersCollection
		
			Get
				If Me._UpToOrdersCollection Is Nothing Then
					Me._UpToOrdersCollection = New OrdersCollection()
					Me._UpToOrdersCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToOrdersCollection", Me._UpToOrdersCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.ProductID.Equals(Nothing) Then 
				
						Dim m As New OrdersQuery("m")
						Dim j As New OrderDetailsQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.OrderID = j.OrderID)
                        m.Where(j.ProductID = Me.ProductID)

						Me._UpToOrdersCollection.Load(m)

					End If
				End If

				Return Me._UpToOrdersCollection
			End Get
			
			Set(ByVal value As OrdersCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToOrdersCollection Is Nothing Then

					Me.RemovePostSave("UpToOrdersCollection")
					Me._UpToOrdersCollection = Nothing
					Me.OnPropertyChanged("UpToOrdersCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_Order_Details_Products
		''' </summary>
		Public Sub AssociateOrdersCollection(entity As Orders)
			If Me._OrderDetailsCollection Is Nothing Then
				Me._OrderDetailsCollection = New OrderDetailsCollection()
				Me._OrderDetailsCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderDetailsCollection", Me._OrderDetailsCollection)
			End If
			
			Dim obj As OrderDetails = Me._OrderDetailsCollection.AddNew()
			obj.ProductID = Me.ProductID
			obj.OrderID = entity.OrderID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_Order_Details_Products
		''' </summary>
		Public Sub DissociateOrdersCollection(entity As Orders)
			If Me._OrderDetailsCollection Is Nothing Then
				Me._OrderDetailsCollection = new OrderDetailsCollection()
				Me._OrderDetailsCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderDetailsCollection", Me._OrderDetailsCollection)
			End If

			Dim obj As OrderDetails = Me._OrderDetailsCollection.AddNew()
			obj.ProductID = Me.ProductID
            obj.OrderID = entity.OrderID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToOrdersCollection As OrdersCollection
		Private _OrderDetailsCollection As OrderDetailsCollection
		#End Region

		#Region "OrderDetailsCollectionByProductID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrderDetailsCollectionByProductID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Products.OrderDetailsCollectionByProductID_Delegate)
				map.PropertyName = "OrderDetailsCollectionByProductID"
				map.MyColumnName = "ProductID"
				map.ParentColumnName = "ProductID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrderDetailsCollectionByProductID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New ProductsQuery(data.NextAlias())
			
			Dim mee As OrderDetailsQuery = If(data.You IsNot Nothing, TryCast(data.You, OrderDetailsQuery), New OrderDetailsQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.ProductID = mee.ProductID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Order_Details_Products
		''' </summary>

		<XmlIgnore()> _ 
		Public Property OrderDetailsCollectionByProductID As OrderDetailsCollection 
		
			Get
				If Me._OrderDetailsCollectionByProductID Is Nothing Then
					Me._OrderDetailsCollectionByProductID = New OrderDetailsCollection()
					Me._OrderDetailsCollectionByProductID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrderDetailsCollectionByProductID", Me._OrderDetailsCollectionByProductID)
				
					If Not Me.ProductID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrderDetailsCollectionByProductID.Query.Where(Me._OrderDetailsCollectionByProductID.Query.ProductID = Me.ProductID)
							Me._OrderDetailsCollectionByProductID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrderDetailsCollectionByProductID.fks.Add(OrderDetailsMetadata.ColumnNames.ProductID, Me.ProductID)
					End If
				End If

				Return Me._OrderDetailsCollectionByProductID
			End Get
			
			Set(ByVal value As OrderDetailsCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrderDetailsCollectionByProductID Is Nothing Then

					Me.RemovePostSave("OrderDetailsCollectionByProductID")
					Me._OrderDetailsCollectionByProductID = Nothing
					Me.OnPropertyChanged("OrderDetailsCollectionByProductID")

				End If
			End Set				
			
		End Property
		
        ' For DataContract Serialization Only
        <DataMember(Name:="OrderDetailsCollectionByProductID", EmitDefaultValue:=False)> _
        Private Property __OrderDetailsCollectionByProductID As OrderDetailsCollection
            Get 
                If Not Me._OrderDetailsCollectionByProductID Is Nothing Then
                    Me._OrderDetailsCollectionByProductID.CombineDeletedEntities()
                End If
				
				Return Me._OrderDetailsCollectionByProductID
			End Get
			
			Set(ByVal value As OrderDetailsCollection)
                Me._OrderDetailsCollectionByProductID = Value
				Me._OrderDetailsCollectionByProductID.SeparateDeletedEntities()
				Me.SetPostSave("OrderDetailsCollectionByProductID", Me._OrderDetailsCollectionByProductID)
				
				If Not Me.ProductID.Equals(Nothing) Then
					' Auto-hookup Foreign Keys
					Me._OrderDetailsCollectionByProductID.fks.Add(OrderDetailsMetadata.ColumnNames.ProductID, Me.ProductID)
				End If
            End Set
        End Property

		private _OrderDetailsCollectionByProductID As OrderDetailsCollection
		#End Region

		#Region "UpToCategoriesByCategoryID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Products_Categories
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToCategoriesByCategoryID As Categories
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCategoriesByCategoryID Is Nothing _
						 AndAlso Not CategoryID.Equals(Nothing)  Then
						
					Me._UpToCategoriesByCategoryID = New Categories()
					Me._UpToCategoriesByCategoryID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCategoriesByCategoryID", Me._UpToCategoriesByCategoryID)
					Me._UpToCategoriesByCategoryID.Query.Where(Me._UpToCategoriesByCategoryID.Query.CategoryID = Me.CategoryID)
					Me._UpToCategoriesByCategoryID.Query.Load()
				End If

				Return Me._UpToCategoriesByCategoryID
			End Get
			
            Set(ByVal value As Categories)
				Me.RemovePreSave("UpToCategoriesByCategoryID")
				
				Dim changed as Boolean = Me._UpToCategoriesByCategoryID IsNot value

				If value Is Nothing Then
				
					Me.CategoryID = Nothing
				
					Me._UpToCategoriesByCategoryID = Nothing
				Else
				
					Me.CategoryID = value.CategoryID
					
					Me._UpToCategoriesByCategoryID = value
					Me.SetPreSave("UpToCategoriesByCategoryID", Me._UpToCategoriesByCategoryID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCategoriesByCategoryID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToSuppliersBySupplierID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Products_Suppliers
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToSuppliersBySupplierID As Suppliers
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToSuppliersBySupplierID Is Nothing _
						 AndAlso Not SupplierID.Equals(Nothing)  Then
						
					Me._UpToSuppliersBySupplierID = New Suppliers()
					Me._UpToSuppliersBySupplierID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToSuppliersBySupplierID", Me._UpToSuppliersBySupplierID)
					Me._UpToSuppliersBySupplierID.Query.Where(Me._UpToSuppliersBySupplierID.Query.SupplierID = Me.SupplierID)
					Me._UpToSuppliersBySupplierID.Query.Load()
				End If

				Return Me._UpToSuppliersBySupplierID
			End Get
			
            Set(ByVal value As Suppliers)
				Me.RemovePreSave("UpToSuppliersBySupplierID")
				
				Dim changed as Boolean = Me._UpToSuppliersBySupplierID IsNot value

				If value Is Nothing Then
				
					Me.SupplierID = Nothing
				
					Me._UpToSuppliersBySupplierID = Nothing
				Else
				
					Me.SupplierID = value.SupplierID
					
					Me._UpToSuppliersBySupplierID = value
					Me.SetPreSave("UpToSuppliersBySupplierID", Me._UpToSuppliersBySupplierID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToSuppliersBySupplierID")
				End If
			End Set	

		End Property
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "OrderDetailsCollectionByProductID"
					coll = Me.OrderDetailsCollectionByProductID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "OrderDetailsCollectionByProductID", GetType(OrderDetailsCollection), New OrderDetails()))
			Return props
			
		End Function	
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToCategoriesByCategoryID Is Nothing Then
				Me.CategoryID = Me._UpToCategoriesByCategoryID.CategoryID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToSuppliersBySupplierID Is Nothing Then
				Me.SupplierID = Me._UpToSuppliersBySupplierID.SupplierID
			End If
			
		End Sub
		
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
		
			If Not Me._OrderDetailsCollection Is Nothing Then
				Apply(Me._OrderDetailsCollection, "ProductID", Me.ProductID)
			End If
			
			If Not Me._OrderDetailsCollectionByProductID Is Nothing Then
				Apply(Me._OrderDetailsCollectionByProductID, "ProductID", Me.ProductID)
			End If
			
		End Sub
	End Class
	
	<KnownType(GetType(OrderDetails))> _
	<KnownType(GetType(Categories))> _
	<KnownType(GetType(Suppliers))> _	
	Public Partial Class Products
		Inherits esProducts
	
	End Class	



	<Serializable> _
	Partial Public Class ProductsMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ProductsMetadata.ColumnNames.ProductID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ProductsMetadata.PropertyNames.ProductID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.ProductName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = ProductsMetadata.PropertyNames.ProductName
			c.CharacterMaxLength = 40
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.SupplierID, 2, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ProductsMetadata.PropertyNames.SupplierID
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.CategoryID, 3, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ProductsMetadata.PropertyNames.CategoryID
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.QuantityPerUnit, 4, GetType(System.String), esSystemType.String)	
			c.PropertyName = ProductsMetadata.PropertyNames.QuantityPerUnit
			c.CharacterMaxLength = 20
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.UnitPrice, 5, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = ProductsMetadata.PropertyNames.UnitPrice
			c.NumericPrecision = 19
			c.HasDefault = True
			c.Default = "(0)"
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.UnitsInStock, 6, GetType(System.Int16), esSystemType.Int16)	
			c.PropertyName = ProductsMetadata.PropertyNames.UnitsInStock
			c.NumericPrecision = 5
			c.HasDefault = True
			c.Default = "(0)"
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.UnitsOnOrder, 7, GetType(System.Int16), esSystemType.Int16)	
			c.PropertyName = ProductsMetadata.PropertyNames.UnitsOnOrder
			c.NumericPrecision = 5
			c.HasDefault = True
			c.Default = "(0)"
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.ReorderLevel, 8, GetType(System.Int16), esSystemType.Int16)	
			c.PropertyName = ProductsMetadata.PropertyNames.ReorderLevel
			c.NumericPrecision = 5
			c.HasDefault = True
			c.Default = "(0)"
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductsMetadata.ColumnNames.Discontinued, 9, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = ProductsMetadata.PropertyNames.Discontinued
			c.HasDefault = True
			c.Default = "(0)"
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ProductsMetadata
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
			 Public Const ProductID As String = "ProductID"
			 Public Const ProductName As String = "ProductName"
			 Public Const SupplierID As String = "SupplierID"
			 Public Const CategoryID As String = "CategoryID"
			 Public Const QuantityPerUnit As String = "QuantityPerUnit"
			 Public Const UnitPrice As String = "UnitPrice"
			 Public Const UnitsInStock As String = "UnitsInStock"
			 Public Const UnitsOnOrder As String = "UnitsOnOrder"
			 Public Const ReorderLevel As String = "ReorderLevel"
			 Public Const Discontinued As String = "Discontinued"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const ProductID As String = "ProductID"
			 Public Const ProductName As String = "ProductName"
			 Public Const SupplierID As String = "SupplierID"
			 Public Const CategoryID As String = "CategoryID"
			 Public Const QuantityPerUnit As String = "QuantityPerUnit"
			 Public Const UnitPrice As String = "UnitPrice"
			 Public Const UnitsInStock As String = "UnitsInStock"
			 Public Const UnitsOnOrder As String = "UnitsOnOrder"
			 Public Const ReorderLevel As String = "ReorderLevel"
			 Public Const Discontinued As String = "Discontinued"
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
			SyncLock GetType(ProductsMetadata)
			
				If ProductsMetadata.mapDelegates Is Nothing Then
					ProductsMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ProductsMetadata._meta Is Nothing Then
					ProductsMetadata._meta = New ProductsMetadata()
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
				


				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ProductName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("SupplierID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("CategoryID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("QuantityPerUnit", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"))
				meta.AddTypeMap("UnitsInStock", new esTypeMap("smallint", "System.Int16"))
				meta.AddTypeMap("UnitsOnOrder", new esTypeMap("smallint", "System.Int16"))
				meta.AddTypeMap("ReorderLevel", new esTypeMap("smallint", "System.Int16"))
				meta.AddTypeMap("Discontinued", new esTypeMap("bit", "System.Boolean"))			
				
				
				 
				meta.Source = "Products"
				meta.Destination = "Products"
				
				meta.spInsert = "proc_ProductsInsert"
				meta.spUpdate = "proc_ProductsUpdate"
				meta.spDelete = "proc_ProductsDelete"
				meta.spLoadAll = "proc_ProductsLoadAll"
				meta.spLoadByPrimaryKey = "proc_ProductsLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ProductsMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
