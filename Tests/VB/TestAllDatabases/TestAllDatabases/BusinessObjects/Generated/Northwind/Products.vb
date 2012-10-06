
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
	' Encapsulates the 'Products' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Products))> _
	<XmlType("Products")> _ 
	<Table(Name:="Products")> _	
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
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Products) As ProductsProxyStub
			Return New ProductsProxyStub(entity)
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

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property SupplierID As Nullable(Of System.Int32)
			Get
				Return MyBase.SupplierID
			End Get
			Set
				MyBase.SupplierID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property CategoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.CategoryID
			End Get
			Set
				MyBase.CategoryID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property QuantityPerUnit As System.String
			Get
				Return MyBase.QuantityPerUnit
			End Get
			Set
				MyBase.QuantityPerUnit = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return MyBase.UnitPrice
			End Get
			Set
				MyBase.UnitPrice = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property UnitsInStock As Nullable(Of System.Int16)
			Get
				Return MyBase.UnitsInStock
			End Get
			Set
				MyBase.UnitsInStock = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property UnitsOnOrder As Nullable(Of System.Int16)
			Get
				Return MyBase.UnitsOnOrder
			End Get
			Set
				MyBase.UnitsOnOrder = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ReorderLevel As Nullable(Of System.Int16)
			Get
				Return MyBase.ReorderLevel
			End Get
			Set
				MyBase.ReorderLevel = value
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


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<DebuggerVisualizer(GetType(EntitySpaces.DebuggerVisualizer.esVisualizer))> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ProductsCollection")> _
	Partial Public Class ProductsCollection
		Inherits esProductsCollection
		Implements IEnumerable(Of Products)
	
		Public Function FindByPrimaryKey(ByVal productID As System.Int32) As Products
			Return MyBase.SingleOrDefault(Function(e) e.ProductID.HasValue AndAlso e.ProductID.Value = productID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ProductsCollection) As ProductsCollectionProxyStub
            Return New ProductsCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
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
		Inherits EntityBase
	
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
		Dim Friend Protected _UpToCategoriesByCategoryID As Categories
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToSuppliersBySupplierID As Suppliers
		
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
												
						Case "SupplierID"
							Me.str().SupplierID = CType(value, string)
												
						Case "CategoryID"
							Me.str().CategoryID = CType(value, string)
												
						Case "QuantityPerUnit"
							Me.str().QuantityPerUnit = CType(value, string)
												
						Case "UnitPrice"
							Me.str().UnitPrice = CType(value, string)
												
						Case "UnitsInStock"
							Me.str().UnitsInStock = CType(value, string)
												
						Case "UnitsOnOrder"
							Me.str().UnitsOnOrder = CType(value, string)
												
						Case "ReorderLevel"
							Me.str().ReorderLevel = CType(value, string)
												
						Case "Discontinued"
							Me.str().Discontinued = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "ProductID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ProductID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ProductsMetadata.PropertyNames.ProductID)
							End If
						
						Case "SupplierID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.SupplierID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ProductsMetadata.PropertyNames.SupplierID)
							End If
						
						Case "CategoryID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.CategoryID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ProductsMetadata.PropertyNames.CategoryID)
							End If
						
						Case "UnitPrice"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.UnitPrice = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(ProductsMetadata.PropertyNames.UnitPrice)
							End If
						
						Case "UnitsInStock"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int16" Then
								Me.UnitsInStock = CType(value, Nullable(Of System.Int16))
								OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsInStock)
							End If
						
						Case "UnitsOnOrder"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int16" Then
								Me.UnitsOnOrder = CType(value, Nullable(Of System.Int16))
								OnPropertyChanged(ProductsMetadata.PropertyNames.UnitsOnOrder)
							End If
						
						Case "ReorderLevel"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int16" Then
								Me.ReorderLevel = CType(value, Nullable(Of System.Int16))
								OnPropertyChanged(ProductsMetadata.PropertyNames.ReorderLevel)
							End If
						
						Case "Discontinued"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Boolean" Then
								Me.Discontinued = CType(value, Nullable(Of System.Boolean))
								OnPropertyChanged(ProductsMetadata.PropertyNames.Discontinued)
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
		
			Public Sub New(ByVal entity As esProducts)
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
		  	
			Public Property SupplierID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.SupplierID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.SupplierID = Nothing
					Else
						entity.SupplierID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
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
		  	
			Public Property QuantityPerUnit As System.String 
				Get
					Dim data_ As System.String = entity.QuantityPerUnit
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.QuantityPerUnit = Nothing
					Else
						entity.QuantityPerUnit = Convert.ToString(Value)
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
		  	
			Public Property UnitsInStock As System.String 
				Get
					Dim data_ As Nullable(Of System.Int16) = entity.UnitsInStock
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.UnitsInStock = Nothing
					Else
						entity.UnitsInStock = Convert.ToInt16(Value)
					End If
				End Set
			End Property
		  	
			Public Property UnitsOnOrder As System.String 
				Get
					Dim data_ As Nullable(Of System.Int16) = entity.UnitsOnOrder
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.UnitsOnOrder = Nothing
					Else
						entity.UnitsOnOrder = Convert.ToInt16(Value)
					End If
				End Set
			End Property
		  	
			Public Property ReorderLevel As System.String 
				Get
					Dim data_ As Nullable(Of System.Int16) = entity.ReorderLevel
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ReorderLevel = Nothing
					Else
						entity.ReorderLevel = Convert.ToInt16(Value)
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
		  

			Private entity As esProducts
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
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
		Inherits CollectionBase(Of Products)
		
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
		Inherits QueryBase 
	
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
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Products")> _
    <XmlType(TypeName:="ProductsProxyStub")> _
    <Serializable> _
    Partial Public Class ProductsProxyStub
	
		Public Sub New()
            Me._entity = New Products()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Products)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Products, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ProductsProxyStub) As Products
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Products)
        End Function
		

		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _		
        Public Property ProductID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ProductsMetadata.ColumnNames.ProductID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.ProductID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ProductID = value
			End Set
			
		End Property

		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ProductName As System.String
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.ProductName) Then
                    Return Me.Entity.ProductName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.ProductName = value
			End Set
			
		End Property

		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _		
        Public Property SupplierID As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.SupplierID) Then
                    Return Me.Entity.SupplierID
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.SupplierID = value
			End Set
			
		End Property

		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _		
        Public Property CategoryID As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.CategoryID) Then
                    Return Me.Entity.CategoryID
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.CategoryID = value
			End Set
			
		End Property

		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _		
        Public Property QuantityPerUnit As System.String
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.QuantityPerUnit) Then
                    Return Me.Entity.QuantityPerUnit
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.QuantityPerUnit = value
			End Set
			
		End Property

		<DataMember(Name:="a5", Order:=6, EmitDefaultValue:=False)> _		
        Public Property UnitPrice As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.UnitPrice) Then
                    Return Me.Entity.UnitPrice
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.UnitPrice = value
			End Set
			
		End Property

		<DataMember(Name:="a6", Order:=7, EmitDefaultValue:=False)> _		
        Public Property UnitsInStock As Nullable(Of System.Int16)
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.UnitsInStock) Then
                    Return Me.Entity.UnitsInStock
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int16))
				Me.Entity.UnitsInStock = value
			End Set
			
		End Property

		<DataMember(Name:="a7", Order:=8, EmitDefaultValue:=False)> _		
        Public Property UnitsOnOrder As Nullable(Of System.Int16)
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.UnitsOnOrder) Then
                    Return Me.Entity.UnitsOnOrder
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int16))
				Me.Entity.UnitsOnOrder = value
			End Set
			
		End Property

		<DataMember(Name:="a8", Order:=9, EmitDefaultValue:=False)> _		
        Public Property ReorderLevel As Nullable(Of System.Int16)
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.ReorderLevel) Then
                    Return Me.Entity.ReorderLevel
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int16))
				Me.Entity.ReorderLevel = value
			End Set
			
		End Property

		<DataMember(Name:="a9", Order:=10, EmitDefaultValue:=False)> _		
        Public Property Discontinued As Nullable(Of System.Boolean)
        
            Get
                If Me.IncludeColumn(ProductsMetadata.ColumnNames.Discontinued) Then
                    Return Me.Entity.Discontinued
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Boolean))
				Me.Entity.Discontinued = value
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
        Public Property Entity As Products
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Products()
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
        Public _entity As Products
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ProductsCollection")> _
    <XmlType(TypeName:="ProductsCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ProductsCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Products))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Products), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ProductsCollectionProxyStub) As ProductsCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Products)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Products), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Products In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ProductsProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ProductsProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Products In coll.es.DeletedEntities
                    Collection.Add(New ProductsProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ProductsProxyStub)		

        Public Function GetCollection As ProductsCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ProductsCollection()
					
		            Dim proxy As ProductsProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ProductsCollection
		
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
				meta.Catalog = "Northwind"
				meta.Schema = "dbo"
				 
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
