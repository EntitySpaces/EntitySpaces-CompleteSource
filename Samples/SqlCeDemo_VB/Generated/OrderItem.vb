
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQLCE
' Date Generated       : 9/23/2012 6:16:27 PM
'===============================================================================

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.ComponentModel


Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery



Namespace BusinessObjects

	' <summary>
	' Encapsulates the 'OrderItem' table
	' </summary>
	
	Partial Public Class OrderItem 
		Inherits esOrderItem
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New OrderItem()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal orderID As System.Int32, ByVal productID As System.Int32)
			Dim obj As New OrderItem()
			obj.OrderID = orderID
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal orderID As System.Int32, ByVal productID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New OrderItem()
			obj.OrderID = orderID
			obj.ProductID = productID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class OrderItemCollection
		Inherits esOrderItemCollection
		Implements IEnumerable(Of OrderItem)
	
		Public Function FindByPrimaryKey(ByVal orderID As System.Int32, ByVal productID As System.Int32) As OrderItem
			Return MyBase.SingleOrDefault(Function(e) e.OrderID.HasValue AndAlso e.OrderID.Value = orderID And e.ProductID.HasValue AndAlso e.ProductID.Value = productID)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class OrderItemQuery 
		Inherits esOrderItemQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "OrderItemQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esOrderItem
		Inherits esEntity
		Implements INotifyPropertyChanged
	
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
		
			Dim query As New OrderItemQuery()
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
		' Maps to OrderItem.OrderID
		' </summary>
		Public Overridable Property OrderID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrderItemMetadata.ColumnNames.OrderID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrderItemMetadata.ColumnNames.OrderID, value) Then
					Me._UpToOrderByOrderID = Nothing
					Me.OnPropertyChanged("UpToOrderByOrderID")
					OnPropertyChanged(OrderItemMetadata.PropertyNames.OrderID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to OrderItem.ProductID
		' </summary>
		Public Overridable Property ProductID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrderItemMetadata.ColumnNames.ProductID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrderItemMetadata.ColumnNames.ProductID, value) Then
					Me._UpToProductByProductID = Nothing
					Me.OnPropertyChanged("UpToProductByProductID")
					OnPropertyChanged(OrderItemMetadata.PropertyNames.ProductID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to OrderItem.UnitPrice
		' </summary>
		Public Overridable Property UnitPrice As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(OrderItemMetadata.ColumnNames.UnitPrice)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(OrderItemMetadata.ColumnNames.UnitPrice, value) Then
					OnPropertyChanged(OrderItemMetadata.PropertyNames.UnitPrice)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to OrderItem.Quantity
		' </summary>
		Public Overridable Property Quantity As Nullable(Of System.Int16)
			Get
				Return MyBase.GetSystemInt16(OrderItemMetadata.ColumnNames.Quantity)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int16))
				If MyBase.SetSystemInt16(OrderItemMetadata.ColumnNames.Quantity, value) Then
					OnPropertyChanged(OrderItemMetadata.PropertyNames.Quantity)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to OrderItem.Discount
		' </summary>
		Public Overridable Property Discount As Nullable(Of System.Single)
			Get
				Return MyBase.GetSystemSingle(OrderItemMetadata.ColumnNames.Discount)
			End Get
			
			Set(ByVal value As Nullable(Of System.Single))
				If MyBase.SetSystemSingle(OrderItemMetadata.ColumnNames.Discount, value) Then
					OnPropertyChanged(OrderItemMetadata.PropertyNames.Discount)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToOrderByOrderID As Order
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToProductByProductID As Product
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrderItemMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As OrderItemQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrderItemQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As OrderItemQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As OrderItemQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As OrderItemQuery

	End Class



	MustInherit Public Partial Class esOrderItemCollection
		Inherits esEntityCollection(Of OrderItem)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrderItemMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "OrderItemCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As OrderItemQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrderItemQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As OrderItemQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New OrderItemQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As OrderItemQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, OrderItemQuery))
		End Sub
		
		#End Region
						
		Private m_query As OrderItemQuery
	End Class



	MustInherit Public Partial Class esOrderItemQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return OrderItemMetadata.Meta()
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
				Return New esQueryItem(Me, OrderItemMetadata.ColumnNames.OrderID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ProductID As esQueryItem
			Get
				Return New esQueryItem(Me, OrderItemMetadata.ColumnNames.ProductID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property UnitPrice As esQueryItem
			Get
				Return New esQueryItem(Me, OrderItemMetadata.ColumnNames.UnitPrice, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property Quantity As esQueryItem
			Get
				Return New esQueryItem(Me, OrderItemMetadata.ColumnNames.Quantity, esSystemType.Int16)
			End Get
		End Property 
		
		Public ReadOnly Property Discount As esQueryItem
			Get
				Return New esQueryItem(Me, OrderItemMetadata.ColumnNames.Discount, esSystemType.Single)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class OrderItem 
		Inherits esOrderItem
		
	
		#Region "UpToOrderByOrderID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - OrderOrderItem
		''' </summary>
		
		Public Property UpToOrderByOrderID As Order
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToOrderByOrderID Is Nothing _
						 AndAlso Not OrderID.Equals(Nothing)  Then
						
					Me._UpToOrderByOrderID = New Order()
					Me._UpToOrderByOrderID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToOrderByOrderID", Me._UpToOrderByOrderID)
					Me._UpToOrderByOrderID.Query.Where(Me._UpToOrderByOrderID.Query.OrderID = Me.OrderID)
					Me._UpToOrderByOrderID.Query.Load()
				End If

				Return Me._UpToOrderByOrderID
			End Get
			
            Set(ByVal value As Order)
				Me.RemovePreSave("UpToOrderByOrderID")
				
				Dim changed as Boolean = Me._UpToOrderByOrderID IsNot value

				If value Is Nothing Then
				
					Me.OrderID = Nothing
				
					Me._UpToOrderByOrderID = Nothing
				Else
				
					Me.OrderID = value.OrderID
					
					Me._UpToOrderByOrderID = value
					Me.SetPreSave("UpToOrderByOrderID", Me._UpToOrderByOrderID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToOrderByOrderID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToProductByProductID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - ProductOrderItem
		''' </summary>
		
		Public Property UpToProductByProductID As Product
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToProductByProductID Is Nothing _
						 AndAlso Not ProductID.Equals(Nothing)  Then
						
					Me._UpToProductByProductID = New Product()
					Me._UpToProductByProductID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToProductByProductID", Me._UpToProductByProductID)
					Me._UpToProductByProductID.Query.Where(Me._UpToProductByProductID.Query.ProductID = Me.ProductID)
					Me._UpToProductByProductID.Query.Load()
				End If

				Return Me._UpToProductByProductID
			End Get
			
            Set(ByVal value As Product)
				Me.RemovePreSave("UpToProductByProductID")
				
				Dim changed as Boolean = Me._UpToProductByProductID IsNot value

				If value Is Nothing Then
				
					Me.ProductID = Nothing
				
					Me._UpToProductByProductID = Nothing
				Else
				
					Me.ProductID = value.ProductID
					
					Me._UpToProductByProductID = value
					Me.SetPreSave("UpToProductByProductID", Me._UpToProductByProductID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToProductByProductID")
				End If
			End Set	

		End Property
		#End Region

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToOrderByOrderID Is Nothing Then
				Me.OrderID = Me._UpToOrderByOrderID.OrderID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToProductByProductID Is Nothing Then
				Me.ProductID = Me._UpToProductByProductID.ProductID
			End If
			
		End Sub
	End Class
		



	Partial Public Class OrderItemMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(OrderItemMetadata.ColumnNames.OrderID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrderItemMetadata.PropertyNames.OrderID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderItemMetadata.ColumnNames.ProductID, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrderItemMetadata.PropertyNames.ProductID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderItemMetadata.ColumnNames.UnitPrice, 2, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = OrderItemMetadata.PropertyNames.UnitPrice
			c.NumericPrecision = 19
			c.NumericScale = 4
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderItemMetadata.ColumnNames.Quantity, 3, GetType(System.Int16), esSystemType.Int16)	
			c.PropertyName = OrderItemMetadata.PropertyNames.Quantity
			c.NumericPrecision = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderItemMetadata.ColumnNames.Discount, 4, GetType(System.Single), esSystemType.Single)	
			c.PropertyName = OrderItemMetadata.PropertyNames.Discount
			c.NumericPrecision = 24
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As OrderItemMetadata
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
			SyncLock GetType(OrderItemMetadata)
			
				If OrderItemMetadata.mapDelegates Is Nothing Then
					OrderItemMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If OrderItemMetadata._meta Is Nothing Then
					OrderItemMetadata._meta = New OrderItemMetadata()
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
				
				
				 
				meta.Source = "OrderItem"
				meta.Destination = "OrderItem"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As OrderItemMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
