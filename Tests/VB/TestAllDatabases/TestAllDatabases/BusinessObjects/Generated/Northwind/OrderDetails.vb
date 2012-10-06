
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
	' Encapsulates the 'Order Details' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(OrderDetails))> _
	<XmlType("OrderDetails")> _ 
	<Table(Name:="OrderDetails")> _	
	Partial Public Class OrderDetails 
		Inherits esOrderDetails
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New OrderDetails()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal orderID As System.Int32, ByVal productID As System.Int32)
			Dim obj As New OrderDetails()
			obj.OrderID = orderID
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal orderID As System.Int32, ByVal productID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New OrderDetails()
			obj.OrderID = orderID
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As OrderDetails) As OrderDetailsProxyStub
			Return New OrderDetailsProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property OrderID As Nullable(Of System.Int32)
			Get
				Return MyBase.OrderID
			End Get
			Set
				MyBase.OrderID = value
			End Set
		End Property

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
		Public Overrides Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return MyBase.UnitPrice
			End Get
			Set
				MyBase.UnitPrice = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property Quantity As Nullable(Of System.Int16)
			Get
				Return MyBase.Quantity
			End Get
			Set
				MyBase.Quantity = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property Discount As Nullable(Of System.Single)
			Get
				Return MyBase.Discount
			End Get
			Set
				MyBase.Discount = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<DebuggerVisualizer(GetType(EntitySpaces.DebuggerVisualizer.esVisualizer))> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("OrderDetailsCollection")> _
	Partial Public Class OrderDetailsCollection
		Inherits esOrderDetailsCollection
		Implements IEnumerable(Of OrderDetails)
	
		Public Function FindByPrimaryKey(ByVal orderID As System.Int32, ByVal productID As System.Int32) As OrderDetails
			Return MyBase.SingleOrDefault(Function(e) e.OrderID.HasValue AndAlso e.OrderID.Value = orderID And e.ProductID.HasValue AndAlso e.ProductID.Value = productID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As OrderDetailsCollection) As OrderDetailsCollectionProxyStub
            Return New OrderDetailsCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(OrderDetails))> _
		Public Class OrderDetailsCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of OrderDetailsCollection)
			
			Public Shared Widening Operator CType(packet As OrderDetailsCollectionWCFPacket) As OrderDetailsCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As OrderDetailsCollection) As OrderDetailsCollectionWCFPacket
				Return New OrderDetailsCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "OrderDetailsQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class OrderDetailsQuery 
		Inherits esOrderDetailsQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "OrderDetailsQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As OrderDetailsQuery) As String
			Return OrderDetailsQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As OrderDetailsQuery
			Return DirectCast(OrderDetailsQuery.SerializeHelper.FromXml(query, GetType(OrderDetailsQuery)), OrderDetailsQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esOrderDetails
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal orderID As System.Int32, ByVal productID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(orderID, productID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(orderID, productID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal orderID As System.Int32, ByVal productID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(orderID, productID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(orderID, productID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal orderID As System.Int32, ByVal productID As System.Int32) As Boolean
		
			Dim query As New OrderDetailsQuery()
			query.Where(query.OrderID = orderID And query.ProductID = productID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal orderID As System.Int32, ByVal productID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("OrderID", orderID)
						parms.Add("ProductID", productID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Order Details.OrderID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property OrderID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrderDetailsMetadata.ColumnNames.OrderID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrderDetailsMetadata.ColumnNames.OrderID, value) Then
					Me._UpToOrdersByOrderID = Nothing
					Me.OnPropertyChanged("UpToOrdersByOrderID")
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.OrderID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order Details.ProductID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ProductID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrderDetailsMetadata.ColumnNames.ProductID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrderDetailsMetadata.ColumnNames.ProductID, value) Then
					Me._UpToProductsByProductID = Nothing
					Me.OnPropertyChanged("UpToProductsByProductID")
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.ProductID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order Details.UnitPrice
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(OrderDetailsMetadata.ColumnNames.UnitPrice)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(OrderDetailsMetadata.ColumnNames.UnitPrice, value) Then
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.UnitPrice)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order Details.Quantity
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Quantity As Nullable(Of System.Int16)
			Get
				Return MyBase.GetSystemInt16(OrderDetailsMetadata.ColumnNames.Quantity)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int16))
				If MyBase.SetSystemInt16(OrderDetailsMetadata.ColumnNames.Quantity, value) Then
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Quantity)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order Details.Discount
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Discount As Nullable(Of System.Single)
			Get
				Return MyBase.GetSystemSingle(OrderDetailsMetadata.ColumnNames.Discount)
			End Get
			
			Set(ByVal value As Nullable(Of System.Single))
				If MyBase.SetSystemSingle(OrderDetailsMetadata.ColumnNames.Discount, value) Then
					OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Discount)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToOrdersByOrderID As Orders
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToProductsByProductID As Products
		
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
												
						Case "OrderID"
							Me.str().OrderID = CType(value, string)
												
						Case "ProductID"
							Me.str().ProductID = CType(value, string)
												
						Case "UnitPrice"
							Me.str().UnitPrice = CType(value, string)
												
						Case "Quantity"
							Me.str().Quantity = CType(value, string)
												
						Case "Discount"
							Me.str().Discount = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "OrderID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.OrderID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.OrderID)
							End If
						
						Case "ProductID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ProductID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.ProductID)
							End If
						
						Case "UnitPrice"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.UnitPrice = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.UnitPrice)
							End If
						
						Case "Quantity"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int16" Then
								Me.Quantity = CType(value, Nullable(Of System.Int16))
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Quantity)
							End If
						
						Case "Discount"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Single" Then
								Me.Discount = CType(value, Nullable(Of System.Single))
								OnPropertyChanged(OrderDetailsMetadata.PropertyNames.Discount)
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
		
			Public Sub New(ByVal entity As esOrderDetails)
				Me.entity = entity
			End Sub				
		
	
			Public Property OrderID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.OrderID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.OrderID = Nothing
					Else
						entity.OrderID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
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
		  	
			Public Property Quantity As System.String 
				Get
					Dim data_ As Nullable(Of System.Int16) = entity.Quantity
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Quantity = Nothing
					Else
						entity.Quantity = Convert.ToInt16(Value)
					End If
				End Set
			End Property
		  	
			Public Property Discount As System.String 
				Get
					Dim data_ As Nullable(Of System.Single) = entity.Discount
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Discount = Nothing
					Else
						entity.Discount = Convert.ToSingle(Value)
					End If
				End Set
			End Property
		  

			Private entity As esOrderDetails
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrderDetailsMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As OrderDetailsQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrderDetailsQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As OrderDetailsQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As OrderDetailsQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As OrderDetailsQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esOrderDetailsCollection
		Inherits CollectionBase(Of OrderDetails)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrderDetailsMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "OrderDetailsCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As OrderDetailsQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrderDetailsQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As OrderDetailsQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New OrderDetailsQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As OrderDetailsQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, OrderDetailsQuery))
		End Sub
		
		#End Region
						
		Private m_query As OrderDetailsQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esOrderDetailsQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return OrderDetailsMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "OrderID" 
					Return Me.OrderID
				Case "ProductID" 
					Return Me.ProductID
				Case "UnitPrice" 
					Return Me.UnitPrice
				Case "Quantity" 
					Return Me.Quantity
				Case "Discount" 
					Return Me.Discount
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property OrderID As esQueryItem
			Get
				Return New esQueryItem(Me, OrderDetailsMetadata.ColumnNames.OrderID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ProductID As esQueryItem
			Get
				Return New esQueryItem(Me, OrderDetailsMetadata.ColumnNames.ProductID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property UnitPrice As esQueryItem
			Get
				Return New esQueryItem(Me, OrderDetailsMetadata.ColumnNames.UnitPrice, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property Quantity As esQueryItem
			Get
				Return New esQueryItem(Me, OrderDetailsMetadata.ColumnNames.Quantity, esSystemType.Int16)
			End Get
		End Property 
		
		Public ReadOnly Property Discount As esQueryItem
			Get
				Return New esQueryItem(Me, OrderDetailsMetadata.ColumnNames.Discount, esSystemType.Single)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class OrderDetails 
		Inherits esOrderDetails
		
	
		#Region "UpToOrdersByOrderID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Order_Details_Orders
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToOrdersByOrderID As Orders
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToOrdersByOrderID Is Nothing _
						 AndAlso Not OrderID.Equals(Nothing)  Then
						
					Me._UpToOrdersByOrderID = New Orders()
					Me._UpToOrdersByOrderID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToOrdersByOrderID", Me._UpToOrdersByOrderID)
					Me._UpToOrdersByOrderID.Query.Where(Me._UpToOrdersByOrderID.Query.OrderID = Me.OrderID)
					Me._UpToOrdersByOrderID.Query.Load()
				End If

				Return Me._UpToOrdersByOrderID
			End Get
			
            Set(ByVal value As Orders)
				Me.RemovePreSave("UpToOrdersByOrderID")
				
				Dim changed as Boolean = Me._UpToOrdersByOrderID IsNot value

				If value Is Nothing Then
				
					Me.OrderID = Nothing
				
					Me._UpToOrdersByOrderID = Nothing
				Else
				
					Me.OrderID = value.OrderID
					
					Me._UpToOrdersByOrderID = value
					Me.SetPreSave("UpToOrdersByOrderID", Me._UpToOrdersByOrderID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToOrdersByOrderID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToProductsByProductID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Order_Details_Products
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToProductsByProductID As Products
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToProductsByProductID Is Nothing _
						 AndAlso Not ProductID.Equals(Nothing)  Then
						
					Me._UpToProductsByProductID = New Products()
					Me._UpToProductsByProductID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToProductsByProductID", Me._UpToProductsByProductID)
					Me._UpToProductsByProductID.Query.Where(Me._UpToProductsByProductID.Query.ProductID = Me.ProductID)
					Me._UpToProductsByProductID.Query.Load()
				End If

				Return Me._UpToProductsByProductID
			End Get
			
            Set(ByVal value As Products)
				Me.RemovePreSave("UpToProductsByProductID")
				
				Dim changed as Boolean = Me._UpToProductsByProductID IsNot value

				If value Is Nothing Then
				
					Me.ProductID = Nothing
				
					Me._UpToProductsByProductID = Nothing
				Else
				
					Me.ProductID = value.ProductID
					
					Me._UpToProductsByProductID = value
					Me.SetPreSave("UpToProductsByProductID", Me._UpToProductsByProductID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToProductsByProductID")
				End If
			End Set	

		End Property
		#End Region

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToOrdersByOrderID Is Nothing Then
				Me.OrderID = Me._UpToOrdersByOrderID.OrderID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToProductsByProductID Is Nothing Then
				Me.ProductID = Me._UpToProductsByProductID.ProductID
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="OrderDetails")> _
    <XmlType(TypeName:="OrderDetailsProxyStub")> _
    <Serializable> _
    Partial Public Class OrderDetailsProxyStub
	
		Public Sub New()
            Me._entity = New OrderDetails()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As OrderDetails)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As OrderDetails, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As OrderDetailsProxyStub) As OrderDetails
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(OrderDetails)
        End Function
		

		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _		
        Public Property OrderID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(OrderDetailsMetadata.ColumnNames.OrderID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.OrderID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.OrderID = value
			End Set
			
		End Property

		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ProductID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(OrderDetailsMetadata.ColumnNames.ProductID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.ProductID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ProductID = value
			End Set
			
		End Property

		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _		
        Public Property UnitPrice As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(OrderDetailsMetadata.ColumnNames.UnitPrice) Then
                    Return Me.Entity.UnitPrice
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.UnitPrice = value
			End Set
			
		End Property

		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Quantity As Nullable(Of System.Int16)
        
            Get
                If Me.IncludeColumn(OrderDetailsMetadata.ColumnNames.Quantity) Then
                    Return Me.Entity.Quantity
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int16))
				Me.Entity.Quantity = value
			End Set
			
		End Property

		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _		
        Public Property Discount As Nullable(Of System.Single)
        
            Get
                If Me.IncludeColumn(OrderDetailsMetadata.ColumnNames.Discount) Then
                    Return Me.Entity.Discount
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Single))
				Me.Entity.Discount = value
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
        Public Property Entity As OrderDetails
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New OrderDetails()
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
        Public _entity As OrderDetails
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="OrderDetailsCollection")> _
    <XmlType(TypeName:="OrderDetailsCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class OrderDetailsCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of OrderDetails))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of OrderDetails), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As OrderDetailsCollectionProxyStub) As OrderDetailsCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(OrderDetails)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of OrderDetails), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As OrderDetails In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New OrderDetailsProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New OrderDetailsProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As OrderDetails In coll.es.DeletedEntities
                    Collection.Add(New OrderDetailsProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of OrderDetailsProxyStub)		

        Public Function GetCollection As OrderDetailsCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New OrderDetailsCollection()
					
		            Dim proxy As OrderDetailsProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As OrderDetailsCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class OrderDetailsMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(OrderDetailsMetadata.ColumnNames.OrderID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrderDetailsMetadata.PropertyNames.OrderID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderDetailsMetadata.ColumnNames.ProductID, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrderDetailsMetadata.PropertyNames.ProductID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderDetailsMetadata.ColumnNames.UnitPrice, 2, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = OrderDetailsMetadata.PropertyNames.UnitPrice
			c.NumericPrecision = 19
			c.HasDefault = True
			c.Default = "(0)"
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderDetailsMetadata.ColumnNames.Quantity, 3, GetType(System.Int16), esSystemType.Int16)	
			c.PropertyName = OrderDetailsMetadata.PropertyNames.Quantity
			c.NumericPrecision = 5
			c.HasDefault = True
			c.Default = "(1)"
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderDetailsMetadata.ColumnNames.Discount, 4, GetType(System.Single), esSystemType.Single)	
			c.PropertyName = OrderDetailsMetadata.PropertyNames.Discount
			c.NumericPrecision = 7
			c.HasDefault = True
			c.Default = "(0)"
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As OrderDetailsMetadata
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
			 Public Const OrderID As String = "OrderID"
			 Public Const ProductID As String = "ProductID"
			 Public Const UnitPrice As String = "UnitPrice"
			 Public Const Quantity As String = "Quantity"
			 Public Const Discount As String = "Discount"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const OrderID As String = "OrderID"
			 Public Const ProductID As String = "ProductID"
			 Public Const UnitPrice As String = "UnitPrice"
			 Public Const Quantity As String = "Quantity"
			 Public Const Discount As String = "Discount"
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
			SyncLock GetType(OrderDetailsMetadata)
			
				If OrderDetailsMetadata.mapDelegates Is Nothing Then
					OrderDetailsMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If OrderDetailsMetadata._meta Is Nothing Then
					OrderDetailsMetadata._meta = New OrderDetailsMetadata()
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
				


				meta.AddTypeMap("OrderID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ProductID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("UnitPrice", new esTypeMap("money", "System.Decimal"))
				meta.AddTypeMap("Quantity", new esTypeMap("smallint", "System.Int16"))
				meta.AddTypeMap("Discount", new esTypeMap("real", "System.Single"))			
				meta.Catalog = "Northwind"
				meta.Schema = "dbo"
				 
				meta.Source = "Order Details"
				meta.Destination = "Order Details"
				
				meta.spInsert = "proc_Order DetailsInsert"
				meta.spUpdate = "proc_Order DetailsUpdate"
				meta.spDelete = "proc_Order DetailsDelete"
				meta.spLoadAll = "proc_Order DetailsLoadAll"
				meta.spLoadByPrimaryKey = "proc_Order DetailsLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As OrderDetailsMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
