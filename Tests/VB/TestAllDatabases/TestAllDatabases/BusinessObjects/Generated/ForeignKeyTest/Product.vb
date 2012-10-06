
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
	' Encapsulates the 'Product' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Product))> _
	<XmlType("Product")> _ 
	<Table(Name:="Product")> _	
	Partial Public Class Product 
		Inherits esProduct
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Product()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal productID As System.Int32)
			Dim obj As New Product()
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal productID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Product()
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Product) As ProductProxyStub
			Return New ProductProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property ProductID As Nullable(Of System.Int32)
			Get
				Return MyBase.ProductID
			End Get
			Set
				MyBase.ProductID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property ProductName As System.String
			Get
				Return MyBase.ProductName
			End Get
			Set
				MyBase.ProductName = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return MyBase.UnitPrice
			End Get
			Set
				MyBase.UnitPrice = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property Discontinued As Nullable(Of System.Boolean)
			Get
				Return MyBase.Discontinued
			End Get
			Set
				MyBase.Discontinued = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ProductCollection")> _
	Partial Public Class ProductCollection
		Inherits esProductCollection
		Implements IEnumerable(Of Product)
	
		Public Function FindByPrimaryKey(ByVal productID As System.Int32) As Product
			Return MyBase.SingleOrDefault(Function(e) e.ProductID.HasValue AndAlso e.ProductID.Value = productID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ProductCollection) As ProductCollectionProxyStub
            Return New ProductCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Product))> _
		Public Class ProductCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ProductCollection)
			
			Public Shared Widening Operator CType(packet As ProductCollectionWCFPacket) As ProductCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ProductCollection) As ProductCollectionWCFPacket
				Return New ProductCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ProductQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ProductQuery 
		Inherits esProductQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ProductQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ProductQuery) As String
			Return ProductQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ProductQuery
			Return DirectCast(ProductQuery.SerializeHelper.FromXml(query, GetType(ProductQuery)), ProductQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esProduct
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
		
			Dim query As New ProductQuery()
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
		' Maps to Product.ProductID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ProductID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ProductMetadata.ColumnNames.ProductID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ProductMetadata.ColumnNames.ProductID, value) Then
					OnPropertyChanged(ProductMetadata.PropertyNames.ProductID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Product.ProductName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ProductName As System.String
			Get
				Return MyBase.GetSystemString(ProductMetadata.ColumnNames.ProductName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ProductMetadata.ColumnNames.ProductName, value) Then
					OnPropertyChanged(ProductMetadata.PropertyNames.ProductName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Product.UnitPrice
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(ProductMetadata.ColumnNames.UnitPrice)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(ProductMetadata.ColumnNames.UnitPrice, value) Then
					OnPropertyChanged(ProductMetadata.PropertyNames.UnitPrice)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Product.Discontinued
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Discontinued As Nullable(Of System.Boolean)
			Get
				Return MyBase.GetSystemBoolean(ProductMetadata.ColumnNames.Discontinued)
			End Get
			
			Set(ByVal value As Nullable(Of System.Boolean))
				If MyBase.SetSystemBoolean(ProductMetadata.ColumnNames.Discontinued, value) Then
					OnPropertyChanged(ProductMetadata.PropertyNames.Discontinued)
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
												
						Case "ProductID"
							Me.str().ProductID = CType(value, string)
												
						Case "ProductName"
							Me.str().ProductName = CType(value, string)
												
						Case "UnitPrice"
							Me.str().UnitPrice = CType(value, string)
												
						Case "Discontinued"
							Me.str().Discontinued = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "ProductID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ProductID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ProductMetadata.PropertyNames.ProductID)
							End If
						
						Case "UnitPrice"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.UnitPrice = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(ProductMetadata.PropertyNames.UnitPrice)
							End If
						
						Case "Discontinued"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Boolean" Then
								Me.Discontinued = CType(value, Nullable(Of System.Boolean))
								OnPropertyChanged(ProductMetadata.PropertyNames.Discontinued)
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
		
			Public Sub New(ByVal entity As esProduct)
				Me.entity = entity
			End Sub				
		
	
			Public Property ProductID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ProductID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ProductID = Nothing
					Else
						entity.ProductID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property ProductName As System.String 
				Get
					Dim data_ As System.String = entity.ProductName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ProductName = Nothing
					Else
						entity.ProductName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property UnitPrice As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.UnitPrice
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.UnitPrice = Nothing
					Else
						entity.UnitPrice = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property Discontinued As System.String 
				Get
					Dim data_ As Nullable(Of System.Boolean) = entity.Discontinued
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Discontinued = Nothing
					Else
						entity.Discontinued = Convert.ToBoolean(Value)
					End If
				End Set
			End Property
		  

			Private entity As esProduct
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ProductMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ProductQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ProductQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ProductQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ProductQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ProductQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esProductCollection
		Inherits esEntityCollection(Of Product)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ProductMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ProductCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ProductQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ProductQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ProductQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ProductQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ProductQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ProductQuery))
		End Sub
		
		#End Region
						
		Private m_query As ProductQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esProductQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ProductMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "ProductID" 
					Return Me.ProductID
				Case "ProductName" 
					Return Me.ProductName
				Case "UnitPrice" 
					Return Me.UnitPrice
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
				Return New esQueryItem(Me, ProductMetadata.ColumnNames.ProductID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ProductName As esQueryItem
			Get
				Return New esQueryItem(Me, ProductMetadata.ColumnNames.ProductName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property UnitPrice As esQueryItem
			Get
				Return New esQueryItem(Me, ProductMetadata.ColumnNames.UnitPrice, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property Discontinued As esQueryItem
			Get
				Return New esQueryItem(Me, ProductMetadata.ColumnNames.Discontinued, esSystemType.Boolean)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Product 
		Inherits esProduct
		
	
		#Region "UpToOrderCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_OrderItem_Product
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToOrderCollection As OrderCollection
		
			Get
				If Me._UpToOrderCollection Is Nothing Then
					Me._UpToOrderCollection = New OrderCollection()
					Me._UpToOrderCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToOrderCollection", Me._UpToOrderCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.ProductID.Equals(Nothing) Then 
				
						Dim m As New OrderQuery("m")
						Dim j As New OrderItemQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.OrderID = j.OrderID)
                        m.Where(j.ProductID = Me.ProductID)

						Me._UpToOrderCollection.Load(m)

					End If
				End If

				Return Me._UpToOrderCollection
			End Get
			
			Set(ByVal value As OrderCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToOrderCollection Is Nothing Then

					Me.RemovePostSave("UpToOrderCollection")
					Me._UpToOrderCollection = Nothing
					Me.OnPropertyChanged("UpToOrderCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_OrderItem_Product
		''' </summary>
		Public Sub AssociateOrderCollection(entity As Order)
			If Me._OrderItemCollection Is Nothing Then
				Me._OrderItemCollection = New OrderItemCollection()
				Me._OrderItemCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderItemCollection", Me._OrderItemCollection)
			End If
			
			Dim obj As OrderItem = Me._OrderItemCollection.AddNew()
			obj.ProductID = Me.ProductID
			obj.OrderID = entity.OrderID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_OrderItem_Product
		''' </summary>
		Public Sub DissociateOrderCollection(entity As Order)
			If Me._OrderItemCollection Is Nothing Then
				Me._OrderItemCollection = new OrderItemCollection()
				Me._OrderItemCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderItemCollection", Me._OrderItemCollection)
			End If

			Dim obj As OrderItem = Me._OrderItemCollection.AddNew()
			obj.ProductID = Me.ProductID
            obj.OrderID = entity.OrderID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToOrderCollection As OrderCollection
		Private _OrderItemCollection As OrderItemCollection
		#End Region

		#Region "OrderItemCollectionByProductID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrderItemCollectionByProductID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Product.OrderItemCollectionByProductID_Delegate)
				map.PropertyName = "OrderItemCollectionByProductID"
				map.MyColumnName = "ProductID"
				map.ParentColumnName = "ProductID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrderItemCollectionByProductID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New ProductQuery(data.NextAlias())
			
			Dim mee As OrderItemQuery = If(data.You IsNot Nothing, TryCast(data.You, OrderItemQuery), New OrderItemQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.ProductID = mee.ProductID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_OrderItem_Product
		''' </summary>

		<XmlIgnore()> _ 
		Public Property OrderItemCollectionByProductID As OrderItemCollection 
		
			Get
				If Me._OrderItemCollectionByProductID Is Nothing Then
					Me._OrderItemCollectionByProductID = New OrderItemCollection()
					Me._OrderItemCollectionByProductID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrderItemCollectionByProductID", Me._OrderItemCollectionByProductID)
				
					If Not Me.ProductID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrderItemCollectionByProductID.Query.Where(Me._OrderItemCollectionByProductID.Query.ProductID = Me.ProductID)
							Me._OrderItemCollectionByProductID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrderItemCollectionByProductID.fks.Add(OrderItemMetadata.ColumnNames.ProductID, Me.ProductID)
					End If
				End If

				Return Me._OrderItemCollectionByProductID
			End Get
			
			Set(ByVal value As OrderItemCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrderItemCollectionByProductID Is Nothing Then

					Me.RemovePostSave("OrderItemCollectionByProductID")
					Me._OrderItemCollectionByProductID = Nothing
					Me.OnPropertyChanged("OrderItemCollectionByProductID")

				End If
			End Set				
			
		End Property
		

		private _OrderItemCollectionByProductID As OrderItemCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "OrderItemCollectionByProductID"
					coll = Me.OrderItemCollectionByProductID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "OrderItemCollectionByProductID", GetType(OrderItemCollection), New OrderItem()))
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
		
			If Not Me._OrderItemCollection Is Nothing Then
				Apply(Me._OrderItemCollection, "ProductID", Me.ProductID)
			End If
			
			If Not Me._OrderItemCollectionByProductID Is Nothing Then
				Apply(Me._OrderItemCollectionByProductID, "ProductID", Me.ProductID)
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Product")> _
    <XmlType(TypeName:="ProductProxyStub")> _
    <Serializable> _
    Partial Public Class ProductProxyStub
	
		Public Sub New()
            Me._entity = New Product()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Product)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Product, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ProductProxyStub) As Product
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Product)
        End Function
		

		<DataMember(Name:="ProductID", Order:=1, EmitDefaultValue:=False)> _		
        Public Property ProductID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ProductMetadata.ColumnNames.ProductID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.ProductID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ProductID = value
			End Set
			
		End Property

		<DataMember(Name:="ProductName", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ProductName As System.String
        
            Get
                If Me.IncludeColumn(ProductMetadata.ColumnNames.ProductName) Then
                    Return Me.Entity.ProductName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.ProductName = value
			End Set
			
		End Property

		<DataMember(Name:="UnitPrice", Order:=3, EmitDefaultValue:=False)> _		
        Public Property UnitPrice As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(ProductMetadata.ColumnNames.UnitPrice) Then
                    Return Me.Entity.UnitPrice
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.UnitPrice = value
			End Set
			
		End Property

		<DataMember(Name:="Discontinued", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Discontinued As Nullable(Of System.Boolean)
        
            Get
                If Me.IncludeColumn(ProductMetadata.ColumnNames.Discontinued) Then
                    Return Me.Entity.Discontinued
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Boolean))
				Me.Entity.Discontinued = value
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
        Public Property Entity As Product
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Product()
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
        Public _entity As Product
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ProductCollection")> _
    <XmlType(TypeName:="ProductCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ProductCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Product))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Product), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ProductCollectionProxyStub) As ProductCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Product)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Product), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Product In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ProductProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ProductProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Product In coll.es.DeletedEntities
                    Collection.Add(New ProductProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ProductProxyStub)		

        Public Function GetCollection As ProductCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ProductCollection()
					
		            Dim proxy As ProductProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ProductCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ProductMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ProductMetadata.ColumnNames.ProductID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ProductMetadata.PropertyNames.ProductID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductMetadata.ColumnNames.ProductName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = ProductMetadata.PropertyNames.ProductName
			c.CharacterMaxLength = 50
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductMetadata.ColumnNames.UnitPrice, 2, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = ProductMetadata.PropertyNames.UnitPrice
			c.NumericPrecision = 19
			m_columns.Add(c)
				
			c = New esColumnMetadata(ProductMetadata.ColumnNames.Discontinued, 3, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = ProductMetadata.PropertyNames.Discontinued
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ProductMetadata
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
			 Public Const ProductID As String = "ProductID"
			 Public Const ProductName As String = "ProductName"
			 Public Const UnitPrice As String = "UnitPrice"
			 Public Const Discontinued As String = "Discontinued"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const ProductID As String = "ProductID"
			 Public Const ProductName As String = "ProductName"
			 Public Const UnitPrice As String = "UnitPrice"
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
			SyncLock GetType(ProductMetadata)
			
				If ProductMetadata.mapDelegates Is Nothing Then
					ProductMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ProductMetadata._meta Is Nothing Then
					ProductMetadata._meta = New ProductMetadata()
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
				meta.AddTypeMap("ProductName", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"))
				meta.AddTypeMap("Discontinued", new esTypeMap("bit", "System.Boolean"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "Product"
				meta.Destination = "Product"
				
				meta.spInsert = "proc_ProductInsert"
				meta.spUpdate = "proc_ProductUpdate"
				meta.spDelete = "proc_ProductDelete"
				meta.spLoadAll = "proc_ProductLoadAll"
				meta.spLoadByPrimaryKey = "proc_ProductLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ProductMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
