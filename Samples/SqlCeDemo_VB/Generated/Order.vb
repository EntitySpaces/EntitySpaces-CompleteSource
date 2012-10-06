
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
	' Encapsulates the 'Order' table
	' </summary>
	
	Partial Public Class Order 
		Inherits esOrder
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Order()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal orderID As System.Int32)
			Dim obj As New Order()
			obj.OrderID = orderID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal orderID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Order()
			obj.OrderID = orderID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class OrderCollection
		Inherits esOrderCollection
		Implements IEnumerable(Of Order)
	
		Public Function FindByPrimaryKey(ByVal orderID As System.Int32) As Order
			Return MyBase.SingleOrDefault(Function(e) e.OrderID.HasValue AndAlso e.OrderID.Value = orderID)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class OrderQuery 
		Inherits esOrderQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "OrderQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esOrder
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal orderID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(orderID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(orderID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal orderID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(orderID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(orderID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal orderID As System.Int32) As Boolean
		
			Dim query As New OrderQuery()
			query.Where(query.OrderID = orderID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal orderID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("OrderID", orderID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Order.OrderID
		' </summary>
		Public Overridable Property OrderID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrderMetadata.ColumnNames.OrderID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrderMetadata.ColumnNames.OrderID, value) Then
					OnPropertyChanged(OrderMetadata.PropertyNames.OrderID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order.CustID
		' </summary>
		Public Overridable Property CustID As System.String
			Get
				Return MyBase.GetSystemString(OrderMetadata.ColumnNames.CustID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrderMetadata.ColumnNames.CustID, value) Then
					Me._UpToCustomerByCustID = Nothing
					Me.OnPropertyChanged("UpToCustomerByCustID")
					OnPropertyChanged(OrderMetadata.PropertyNames.CustID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order.CustSub
		' </summary>
		Public Overridable Property CustSub As System.String
			Get
				Return MyBase.GetSystemString(OrderMetadata.ColumnNames.CustSub)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrderMetadata.ColumnNames.CustSub, value) Then
					Me._UpToCustomerByCustID = Nothing
					Me.OnPropertyChanged("UpToCustomerByCustID")
					OnPropertyChanged(OrderMetadata.PropertyNames.CustSub)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order.PlacedBy
		' </summary>
		Public Overridable Property PlacedBy As System.String
			Get
				Return MyBase.GetSystemString(OrderMetadata.ColumnNames.PlacedBy)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrderMetadata.ColumnNames.PlacedBy, value) Then
					OnPropertyChanged(OrderMetadata.PropertyNames.PlacedBy)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order.OrderDate
		' </summary>
		Public Overridable Property OrderDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(OrderMetadata.ColumnNames.OrderDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(OrderMetadata.ColumnNames.OrderDate, value) Then
					OnPropertyChanged(OrderMetadata.PropertyNames.OrderDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order.ConcurrencyCheck
		' </summary>
		Public Overridable Property ConcurrencyCheck As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrderMetadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrderMetadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(OrderMetadata.PropertyNames.ConcurrencyCheck)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Order.EmployeeID
		' </summary>
		Public Overridable Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrderMetadata.ColumnNames.EmployeeID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrderMetadata.ColumnNames.EmployeeID, value) Then
					Me._UpToEmployeeByEmployeeID = Nothing
					Me.OnPropertyChanged("UpToEmployeeByEmployeeID")
					OnPropertyChanged(OrderMetadata.PropertyNames.EmployeeID)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToCustomerByCustID As Customer
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeByEmployeeID As Employee
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrderMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As OrderQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrderQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As OrderQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As OrderQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As OrderQuery

	End Class



	MustInherit Public Partial Class esOrderCollection
		Inherits esEntityCollection(Of Order)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrderMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "OrderCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As OrderQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrderQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As OrderQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New OrderQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As OrderQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, OrderQuery))
		End Sub
		
		#End Region
						
		Private m_query As OrderQuery
	End Class



	MustInherit Public Partial Class esOrderQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return OrderMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "OrderID" 
					Return Me.OrderID
				Case "CustID" 
					Return Me.CustID
				Case "CustSub" 
					Return Me.CustSub
				Case "PlacedBy" 
					Return Me.PlacedBy
				Case "OrderDate" 
					Return Me.OrderDate
				Case "ConcurrencyCheck" 
					Return Me.ConcurrencyCheck
				Case "EmployeeID" 
					Return Me.EmployeeID
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property OrderID As esQueryItem
			Get
				Return New esQueryItem(Me, OrderMetadata.ColumnNames.OrderID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property CustID As esQueryItem
			Get
				Return New esQueryItem(Me, OrderMetadata.ColumnNames.CustID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CustSub As esQueryItem
			Get
				Return New esQueryItem(Me, OrderMetadata.ColumnNames.CustSub, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property PlacedBy As esQueryItem
			Get
				Return New esQueryItem(Me, OrderMetadata.ColumnNames.PlacedBy, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property OrderDate As esQueryItem
			Get
				Return New esQueryItem(Me, OrderMetadata.ColumnNames.OrderDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property ConcurrencyCheck As esQueryItem
			Get
				Return New esQueryItem(Me, OrderMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return New esQueryItem(Me, OrderMetadata.ColumnNames.EmployeeID, esSystemType.Int32)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Order 
		Inherits esOrder
		
	
		#Region "UpToCustomerByCustID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - CustomerOrder
		''' </summary>
		
		Public Property UpToCustomerByCustID As Customer
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCustomerByCustID Is Nothing _
						 AndAlso Not CustID.Equals(Nothing)  AndAlso Not CustSub.Equals(Nothing)  Then
						
					Me._UpToCustomerByCustID = New Customer()
					Me._UpToCustomerByCustID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCustomerByCustID", Me._UpToCustomerByCustID)
					Me._UpToCustomerByCustID.Query.Where(Me._UpToCustomerByCustID.Query.CustomerID = Me.CustID)
					Me._UpToCustomerByCustID.Query.Where(Me._UpToCustomerByCustID.Query.CustomerSub = Me.CustSub)
					Me._UpToCustomerByCustID.Query.Load()
				End If

				Return Me._UpToCustomerByCustID
			End Get
			
            Set(ByVal value As Customer)
				Me.RemovePreSave("UpToCustomerByCustID")
				
				Dim changed as Boolean = Me._UpToCustomerByCustID IsNot value

				If value Is Nothing Then
				
					Me.CustID = Nothing
				
					Me.CustSub = Nothing
				
					Me._UpToCustomerByCustID = Nothing
				Else
				
					Me.CustID = value.CustomerID
					
					Me.CustSub = value.CustomerSub
					
					Me._UpToCustomerByCustID = value
					Me.SetPreSave("UpToCustomerByCustID", Me._UpToCustomerByCustID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCustomerByCustID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToEmployeeByEmployeeID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - EmployeeOrder
		''' </summary>
		
		Public Property UpToEmployeeByEmployeeID As Employee
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeeByEmployeeID Is Nothing _
						 AndAlso Not EmployeeID.Equals(Nothing)  Then
						
					Me._UpToEmployeeByEmployeeID = New Employee()
					Me._UpToEmployeeByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeeByEmployeeID", Me._UpToEmployeeByEmployeeID)
					Me._UpToEmployeeByEmployeeID.Query.Where(Me._UpToEmployeeByEmployeeID.Query.EmployeeID = Me.EmployeeID)
					Me._UpToEmployeeByEmployeeID.Query.Load()
				End If

				Return Me._UpToEmployeeByEmployeeID
			End Get
			
            Set(ByVal value As Employee)
				Me.RemovePreSave("UpToEmployeeByEmployeeID")
				
				Dim changed as Boolean = Me._UpToEmployeeByEmployeeID IsNot value

				If value Is Nothing Then
				
					Me.EmployeeID = Nothing
				
					Me._UpToEmployeeByEmployeeID = Nothing
				Else
				
					Me.EmployeeID = value.EmployeeID
					
					Me._UpToEmployeeByEmployeeID = value
					Me.SetPreSave("UpToEmployeeByEmployeeID", Me._UpToEmployeeByEmployeeID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeeByEmployeeID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToProductCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - OrderOrderItem
		''' </summary>

		Public Property UpToProductCollection As ProductCollection
		
			Get
				If Me._UpToProductCollection Is Nothing Then
					Me._UpToProductCollection = New ProductCollection()
					Me._UpToProductCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToProductCollection", Me._UpToProductCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.OrderID.Equals(Nothing) Then 
				
						Dim m As New ProductQuery("m")
						Dim j As New OrderItemQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.ProductID = j.ProductID)
                        m.Where(j.OrderID = Me.OrderID)

						Me._UpToProductCollection.Load(m)

					End If
				End If

				Return Me._UpToProductCollection
			End Get
			
			Set(ByVal value As ProductCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToProductCollection Is Nothing Then

					Me.RemovePostSave("UpToProductCollection")
					Me._UpToProductCollection = Nothing
					Me.OnPropertyChanged("UpToProductCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - OrderOrderItem
		''' </summary>
		Public Sub AssociateProductCollection(entity As Product)
			If Me._OrderItemCollection Is Nothing Then
				Me._OrderItemCollection = New OrderItemCollection()
				Me._OrderItemCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderItemCollection", Me._OrderItemCollection)
			End If
			
			Dim obj As OrderItem = Me._OrderItemCollection.AddNew()
			obj.OrderID = Me.OrderID
			obj.ProductID = entity.ProductID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - OrderOrderItem
		''' </summary>
		Public Sub DissociateProductCollection(entity As Product)
			If Me._OrderItemCollection Is Nothing Then
				Me._OrderItemCollection = new OrderItemCollection()
				Me._OrderItemCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderItemCollection", Me._OrderItemCollection)
			End If

			Dim obj As OrderItem = Me._OrderItemCollection.AddNew()
			obj.OrderID = Me.OrderID
            obj.ProductID = entity.ProductID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToProductCollection As ProductCollection
		Private _OrderItemCollection As OrderItemCollection
		#End Region

		#Region "OrderItemCollectionByOrderID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrderItemCollectionByOrderID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Order.OrderItemCollectionByOrderID_Delegate)
				map.PropertyName = "OrderItemCollectionByOrderID"
				map.MyColumnName = "OrderID"
				map.ParentColumnName = "OrderID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrderItemCollectionByOrderID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New OrderQuery(data.NextAlias())
			
			Dim mee As OrderItemQuery = If(data.You IsNot Nothing, TryCast(data.You, OrderItemQuery), New OrderItemQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.OrderID = mee.OrderID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - OrderOrderItem
		''' </summary>
 
		Public Property OrderItemCollectionByOrderID As OrderItemCollection 
		
			Get
				If Me._OrderItemCollectionByOrderID Is Nothing Then
					Me._OrderItemCollectionByOrderID = New OrderItemCollection()
					Me._OrderItemCollectionByOrderID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrderItemCollectionByOrderID", Me._OrderItemCollectionByOrderID)
				
					If Not Me.OrderID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrderItemCollectionByOrderID.Query.Where(Me._OrderItemCollectionByOrderID.Query.OrderID = Me.OrderID)
							Me._OrderItemCollectionByOrderID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrderItemCollectionByOrderID.fks.Add(OrderItemMetadata.ColumnNames.OrderID, Me.OrderID)
					End If
				End If

				Return Me._OrderItemCollectionByOrderID
			End Get
			
			Set(ByVal value As OrderItemCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrderItemCollectionByOrderID Is Nothing Then

					Me.RemovePostSave("OrderItemCollectionByOrderID")
					Me._OrderItemCollectionByOrderID = Nothing
					Me.OnPropertyChanged("OrderItemCollectionByOrderID")

				End If
			End Set				
			
		End Property
		

		private _OrderItemCollectionByOrderID As OrderItemCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "OrderItemCollectionByOrderID"
					coll = Me.OrderItemCollectionByOrderID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "OrderItemCollectionByOrderID", GetType(OrderItemCollection), New OrderItem()))
			Return props
			
		End Function	
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByEmployeeID Is Nothing Then
				Me.EmployeeID = Me._UpToEmployeeByEmployeeID.EmployeeID
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
		
			If Not Me._OrderItemCollection Is Nothing Then
				Apply(Me._OrderItemCollection, "OrderID", Me.OrderID)
			End If
			
			If Not Me._OrderItemCollectionByOrderID Is Nothing Then
				Apply(Me._OrderItemCollectionByOrderID, "OrderID", Me.OrderID)
			End If
			
		End Sub
	End Class
		



	Partial Public Class OrderMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(OrderMetadata.ColumnNames.OrderID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrderMetadata.PropertyNames.OrderID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderMetadata.ColumnNames.CustID, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrderMetadata.PropertyNames.CustID
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderMetadata.ColumnNames.CustSub, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrderMetadata.PropertyNames.CustSub
			c.CharacterMaxLength = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderMetadata.ColumnNames.PlacedBy, 3, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrderMetadata.PropertyNames.PlacedBy
			c.CharacterMaxLength = 25
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderMetadata.ColumnNames.OrderDate, 4, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = OrderMetadata.PropertyNames.OrderDate
			c.NumericPrecision = 23
			c.NumericScale = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderMetadata.ColumnNames.ConcurrencyCheck, 5, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrderMetadata.PropertyNames.ConcurrencyCheck
			c.NumericPrecision = 10
			c.HasDefault = True
			c.Default = "0"
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrderMetadata.ColumnNames.EmployeeID, 6, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrderMetadata.PropertyNames.EmployeeID
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As OrderMetadata
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
			 Public Const CustID As String = "CustID"
			 Public Const CustSub As String = "CustSub"
			 Public Const PlacedBy As String = "PlacedBy"
			 Public Const OrderDate As String = "OrderDate"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const EmployeeID As String = "EmployeeID"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const OrderID As String = "OrderID"
			 Public Const CustID As String = "CustID"
			 Public Const CustSub As String = "CustSub"
			 Public Const PlacedBy As String = "PlacedBy"
			 Public Const OrderDate As String = "OrderDate"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const EmployeeID As String = "EmployeeID"
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
			SyncLock GetType(OrderMetadata)
			
				If OrderMetadata.mapDelegates Is Nothing Then
					OrderMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If OrderMetadata._meta Is Nothing Then
					OrderMetadata._meta = New OrderMetadata()
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
				meta.AddTypeMap("CustID", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("CustSub", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("PlacedBy", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("OrderDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"))			
				
				
				 
				meta.Source = "Order"
				meta.Destination = "Order"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As OrderMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
