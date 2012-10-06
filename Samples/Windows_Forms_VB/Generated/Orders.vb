
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
	' Encapsulates the 'Orders' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Orders))> _
	<XmlType("Orders")> _	
	Partial Public Class Orders 
		Inherits esOrders
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Orders()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal orderID As System.Int32)
			Dim obj As New Orders()
			obj.OrderID = orderID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal orderID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Orders()
			obj.OrderID = orderID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("OrdersCollection")> _
	Partial Public Class OrdersCollection
		Inherits esOrdersCollection
		Implements IEnumerable(Of Orders)
	
		Public Function FindByPrimaryKey(ByVal orderID As System.Int32) As Orders
			Return MyBase.SingleOrDefault(Function(e) e.OrderID.HasValue AndAlso e.OrderID.Value = orderID)
		End Function


				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Orders))> _
		Public Class OrdersCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of OrdersCollection)
			
			Public Shared Widening Operator CType(packet As OrdersCollectionWCFPacket) As OrdersCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As OrdersCollection) As OrdersCollectionWCFPacket
				Return New OrdersCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "OrdersQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class OrdersQuery 
		Inherits esOrdersQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "OrdersQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As OrdersQuery) As String
			Return OrdersQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As OrdersQuery
			Return DirectCast(OrdersQuery.SerializeHelper.FromXml(query, GetType(OrdersQuery)), OrdersQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esOrders
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
		
			Dim query As New OrdersQuery()
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
		' Maps to Orders.OrderID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property OrderID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrdersMetadata.ColumnNames.OrderID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrdersMetadata.ColumnNames.OrderID, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.OrderID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.CustomerID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CustomerID As System.String
			Get
				Return MyBase.GetSystemString(OrdersMetadata.ColumnNames.CustomerID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrdersMetadata.ColumnNames.CustomerID, value) Then
					Me._UpToCustomersByCustomerID = Nothing
					Me.OnPropertyChanged("UpToCustomersByCustomerID")
					OnPropertyChanged(OrdersMetadata.PropertyNames.CustomerID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.EmployeeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrdersMetadata.ColumnNames.EmployeeID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrdersMetadata.ColumnNames.EmployeeID, value) Then
					Me._UpToEmployeesByEmployeeID = Nothing
					Me.OnPropertyChanged("UpToEmployeesByEmployeeID")
					OnPropertyChanged(OrdersMetadata.PropertyNames.EmployeeID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.OrderDate
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property OrderDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(OrdersMetadata.ColumnNames.OrderDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(OrdersMetadata.ColumnNames.OrderDate, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.OrderDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.RequiredDate
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property RequiredDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(OrdersMetadata.ColumnNames.RequiredDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(OrdersMetadata.ColumnNames.RequiredDate, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.RequiredDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShippedDate
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShippedDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(OrdersMetadata.ColumnNames.ShippedDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(OrdersMetadata.ColumnNames.ShippedDate, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShippedDate)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShipVia
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipVia As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(OrdersMetadata.ColumnNames.ShipVia)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(OrdersMetadata.ColumnNames.ShipVia, value) Then
					Me._UpToShippersByShipVia = Nothing
					Me.OnPropertyChanged("UpToShippersByShipVia")
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipVia)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.Freight
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Freight As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(OrdersMetadata.ColumnNames.Freight)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(OrdersMetadata.ColumnNames.Freight, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.Freight)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShipName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipName As System.String
			Get
				Return MyBase.GetSystemString(OrdersMetadata.ColumnNames.ShipName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrdersMetadata.ColumnNames.ShipName, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShipAddress
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipAddress As System.String
			Get
				Return MyBase.GetSystemString(OrdersMetadata.ColumnNames.ShipAddress)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrdersMetadata.ColumnNames.ShipAddress, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipAddress)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShipCity
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipCity As System.String
			Get
				Return MyBase.GetSystemString(OrdersMetadata.ColumnNames.ShipCity)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrdersMetadata.ColumnNames.ShipCity, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipCity)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShipRegion
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipRegion As System.String
			Get
				Return MyBase.GetSystemString(OrdersMetadata.ColumnNames.ShipRegion)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrdersMetadata.ColumnNames.ShipRegion, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipRegion)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShipPostalCode
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipPostalCode As System.String
			Get
				Return MyBase.GetSystemString(OrdersMetadata.ColumnNames.ShipPostalCode)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrdersMetadata.ColumnNames.ShipPostalCode, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipPostalCode)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Orders.ShipCountry
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipCountry As System.String
			Get
				Return MyBase.GetSystemString(OrdersMetadata.ColumnNames.ShipCountry)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(OrdersMetadata.ColumnNames.ShipCountry, value) Then
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipCountry)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToCustomersByCustomerID As Customers
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToEmployeesByEmployeeID As Employees
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToShippersByShipVia As Shippers
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrdersMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As OrdersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrdersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As OrdersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As OrdersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As OrdersQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esOrdersCollection
		Inherits esEntityCollection(Of Orders)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return OrdersMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "OrdersCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As OrdersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New OrdersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As OrdersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New OrdersQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As OrdersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, OrdersQuery))
		End Sub
		
		#End Region
						
		Private m_query As OrdersQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esOrdersQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return OrdersMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "OrderID" 
					Return Me.OrderID
				Case "CustomerID" 
					Return Me.CustomerID
				Case "EmployeeID" 
					Return Me.EmployeeID
				Case "OrderDate" 
					Return Me.OrderDate
				Case "RequiredDate" 
					Return Me.RequiredDate
				Case "ShippedDate" 
					Return Me.ShippedDate
				Case "ShipVia" 
					Return Me.ShipVia
				Case "Freight" 
					Return Me.Freight
				Case "ShipName" 
					Return Me.ShipName
				Case "ShipAddress" 
					Return Me.ShipAddress
				Case "ShipCity" 
					Return Me.ShipCity
				Case "ShipRegion" 
					Return Me.ShipRegion
				Case "ShipPostalCode" 
					Return Me.ShipPostalCode
				Case "ShipCountry" 
					Return Me.ShipCountry
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property OrderID As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.OrderID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property CustomerID As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.CustomerID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.EmployeeID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property OrderDate As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.OrderDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property RequiredDate As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.RequiredDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property ShippedDate As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShippedDate, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property ShipVia As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShipVia, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Freight As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.Freight, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property ShipName As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShipName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ShipAddress As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShipAddress, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ShipCity As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShipCity, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ShipRegion As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShipRegion, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ShipPostalCode As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShipPostalCode, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ShipCountry As esQueryItem
			Get
				Return New esQueryItem(Me, OrdersMetadata.ColumnNames.ShipCountry, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Orders 
		Inherits esOrders
		
	
		#Region "UpToProductsCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_Order_Details_Orders
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToProductsCollection As ProductsCollection
		
			Get
				If Me._UpToProductsCollection Is Nothing Then
					Me._UpToProductsCollection = New ProductsCollection()
					Me._UpToProductsCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToProductsCollection", Me._UpToProductsCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.OrderID.Equals(Nothing) Then 
				
						Dim m As New ProductsQuery("m")
						Dim j As New OrderDetailsQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.ProductID = j.ProductID)
                        m.Where(j.OrderID = Me.OrderID)

						Me._UpToProductsCollection.Load(m)

					End If
				End If

				Return Me._UpToProductsCollection
			End Get
			
			Set(ByVal value As ProductsCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToProductsCollection Is Nothing Then

					Me.RemovePostSave("UpToProductsCollection")
					Me._UpToProductsCollection = Nothing
					Me.OnPropertyChanged("UpToProductsCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_Order_Details_Orders
		''' </summary>
		Public Sub AssociateProductsCollection(entity As Products)
			If Me._OrderDetailsCollection Is Nothing Then
				Me._OrderDetailsCollection = New OrderDetailsCollection()
				Me._OrderDetailsCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderDetailsCollection", Me._OrderDetailsCollection)
			End If
			
			Dim obj As OrderDetails = Me._OrderDetailsCollection.AddNew()
			obj.OrderID = Me.OrderID
			obj.ProductID = entity.ProductID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_Order_Details_Orders
		''' </summary>
		Public Sub DissociateProductsCollection(entity As Products)
			If Me._OrderDetailsCollection Is Nothing Then
				Me._OrderDetailsCollection = new OrderDetailsCollection()
				Me._OrderDetailsCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("OrderDetailsCollection", Me._OrderDetailsCollection)
			End If

			Dim obj As OrderDetails = Me._OrderDetailsCollection.AddNew()
			obj.OrderID = Me.OrderID
            obj.ProductID = entity.ProductID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToProductsCollection As ProductsCollection
		Private _OrderDetailsCollection As OrderDetailsCollection
		#End Region

		#Region "OrderDetailsCollectionByOrderID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrderDetailsCollectionByOrderID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Orders.OrderDetailsCollectionByOrderID_Delegate)
				map.PropertyName = "OrderDetailsCollectionByOrderID"
				map.MyColumnName = "OrderID"
				map.ParentColumnName = "OrderID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrderDetailsCollectionByOrderID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New OrdersQuery(data.NextAlias())
			
			Dim mee As OrderDetailsQuery = If(data.You IsNot Nothing, TryCast(data.You, OrderDetailsQuery), New OrderDetailsQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.OrderID = mee.OrderID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Order_Details_Orders
		''' </summary>

		<XmlIgnore()> _ 
		Public Property OrderDetailsCollectionByOrderID As OrderDetailsCollection 
		
			Get
				If Me._OrderDetailsCollectionByOrderID Is Nothing Then
					Me._OrderDetailsCollectionByOrderID = New OrderDetailsCollection()
					Me._OrderDetailsCollectionByOrderID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrderDetailsCollectionByOrderID", Me._OrderDetailsCollectionByOrderID)
				
					If Not Me.OrderID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrderDetailsCollectionByOrderID.Query.Where(Me._OrderDetailsCollectionByOrderID.Query.OrderID = Me.OrderID)
							Me._OrderDetailsCollectionByOrderID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrderDetailsCollectionByOrderID.fks.Add(OrderDetailsMetadata.ColumnNames.OrderID, Me.OrderID)
					End If
				End If

				Return Me._OrderDetailsCollectionByOrderID
			End Get
			
			Set(ByVal value As OrderDetailsCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrderDetailsCollectionByOrderID Is Nothing Then

					Me.RemovePostSave("OrderDetailsCollectionByOrderID")
					Me._OrderDetailsCollectionByOrderID = Nothing
					Me.OnPropertyChanged("OrderDetailsCollectionByOrderID")

				End If
			End Set				
			
		End Property
		
        ' For DataContract Serialization Only
        <DataMember(Name:="OrderDetailsCollectionByOrderID", EmitDefaultValue:=False)> _
        Private Property __OrderDetailsCollectionByOrderID As OrderDetailsCollection
            Get 
                If Not Me._OrderDetailsCollectionByOrderID Is Nothing Then
                    Me._OrderDetailsCollectionByOrderID.CombineDeletedEntities()
                End If
				
				Return Me._OrderDetailsCollectionByOrderID
			End Get
			
			Set(ByVal value As OrderDetailsCollection)
                Me._OrderDetailsCollectionByOrderID = Value
				Me._OrderDetailsCollectionByOrderID.SeparateDeletedEntities()
				Me.SetPostSave("OrderDetailsCollectionByOrderID", Me._OrderDetailsCollectionByOrderID)
				
				If Not Me.OrderID.Equals(Nothing) Then
					' Auto-hookup Foreign Keys
					Me._OrderDetailsCollectionByOrderID.fks.Add(OrderDetailsMetadata.ColumnNames.OrderID, Me.OrderID)
				End If
            End Set
        End Property

		private _OrderDetailsCollectionByOrderID As OrderDetailsCollection
		#End Region

		#Region "UpToCustomersByCustomerID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Orders_Customers
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToCustomersByCustomerID As Customers
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCustomersByCustomerID Is Nothing _
						 AndAlso Not CustomerID.Equals(Nothing)  Then
						
					Me._UpToCustomersByCustomerID = New Customers()
					Me._UpToCustomersByCustomerID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCustomersByCustomerID", Me._UpToCustomersByCustomerID)
					Me._UpToCustomersByCustomerID.Query.Where(Me._UpToCustomersByCustomerID.Query.CustomerID = Me.CustomerID)
					Me._UpToCustomersByCustomerID.Query.Load()
				End If

				Return Me._UpToCustomersByCustomerID
			End Get
			
            Set(ByVal value As Customers)
				Me.RemovePreSave("UpToCustomersByCustomerID")
				
				Dim changed as Boolean = Me._UpToCustomersByCustomerID IsNot value

				If value Is Nothing Then
				
					Me.CustomerID = Nothing
				
					Me._UpToCustomersByCustomerID = Nothing
				Else
				
					Me.CustomerID = value.CustomerID
					
					Me._UpToCustomersByCustomerID = value
					Me.SetPreSave("UpToCustomersByCustomerID", Me._UpToCustomersByCustomerID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCustomersByCustomerID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToEmployeesByEmployeeID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Orders_Employees
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToEmployeesByEmployeeID As Employees
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeesByEmployeeID Is Nothing _
						 AndAlso Not EmployeeID.Equals(Nothing)  Then
						
					Me._UpToEmployeesByEmployeeID = New Employees()
					Me._UpToEmployeesByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeesByEmployeeID", Me._UpToEmployeesByEmployeeID)
					Me._UpToEmployeesByEmployeeID.Query.Where(Me._UpToEmployeesByEmployeeID.Query.EmployeeID = Me.EmployeeID)
					Me._UpToEmployeesByEmployeeID.Query.Load()
				End If

				Return Me._UpToEmployeesByEmployeeID
			End Get
			
            Set(ByVal value As Employees)
				Me.RemovePreSave("UpToEmployeesByEmployeeID")
				
				Dim changed as Boolean = Me._UpToEmployeesByEmployeeID IsNot value

				If value Is Nothing Then
				
					Me.EmployeeID = Nothing
				
					Me._UpToEmployeesByEmployeeID = Nothing
				Else
				
					Me.EmployeeID = value.EmployeeID
					
					Me._UpToEmployeesByEmployeeID = value
					Me.SetPreSave("UpToEmployeesByEmployeeID", Me._UpToEmployeesByEmployeeID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeesByEmployeeID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToShippersByShipVia - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Orders_Shippers
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToShippersByShipVia As Shippers
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToShippersByShipVia Is Nothing _
						 AndAlso Not ShipVia.Equals(Nothing)  Then
						
					Me._UpToShippersByShipVia = New Shippers()
					Me._UpToShippersByShipVia.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToShippersByShipVia", Me._UpToShippersByShipVia)
					Me._UpToShippersByShipVia.Query.Where(Me._UpToShippersByShipVia.Query.ShipperID = Me.ShipVia)
					Me._UpToShippersByShipVia.Query.Load()
				End If

				Return Me._UpToShippersByShipVia
			End Get
			
            Set(ByVal value As Shippers)
				Me.RemovePreSave("UpToShippersByShipVia")
				
				Dim changed as Boolean = Me._UpToShippersByShipVia IsNot value

				If value Is Nothing Then
				
					Me.ShipVia = Nothing
				
					Me._UpToShippersByShipVia = Nothing
				Else
				
					Me.ShipVia = value.ShipperID
					
					Me._UpToShippersByShipVia = value
					Me.SetPreSave("UpToShippersByShipVia", Me._UpToShippersByShipVia)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToShippersByShipVia")
				End If
			End Set	

		End Property
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "OrderDetailsCollectionByOrderID"
					coll = Me.OrderDetailsCollectionByOrderID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "OrderDetailsCollectionByOrderID", GetType(OrderDetailsCollection), New OrderDetails()))
			Return props
			
		End Function	
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeesByEmployeeID Is Nothing Then
				Me.EmployeeID = Me._UpToEmployeesByEmployeeID.EmployeeID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToShippersByShipVia Is Nothing Then
				Me.ShipVia = Me._UpToShippersByShipVia.ShipperID
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
				Apply(Me._OrderDetailsCollection, "OrderID", Me.OrderID)
			End If
			
			If Not Me._OrderDetailsCollectionByOrderID Is Nothing Then
				Apply(Me._OrderDetailsCollectionByOrderID, "OrderID", Me.OrderID)
			End If
			
		End Sub
	End Class
	
	<KnownType(GetType(OrderDetails))> _
	<KnownType(GetType(Customers))> _
	<KnownType(GetType(Employees))> _
	<KnownType(GetType(Shippers))> _	
	Public Partial Class Orders
		Inherits esOrders
	
	End Class	



	<Serializable> _
	Partial Public Class OrdersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(OrdersMetadata.ColumnNames.OrderID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrdersMetadata.PropertyNames.OrderID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.CustomerID, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrdersMetadata.PropertyNames.CustomerID
			c.CharacterMaxLength = 5
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.EmployeeID, 2, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrdersMetadata.PropertyNames.EmployeeID
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.OrderDate, 3, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = OrdersMetadata.PropertyNames.OrderDate
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.RequiredDate, 4, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = OrdersMetadata.PropertyNames.RequiredDate
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShippedDate, 5, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShippedDate
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShipVia, 6, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShipVia
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.Freight, 7, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = OrdersMetadata.PropertyNames.Freight
			c.NumericPrecision = 19
			c.HasDefault = True
			c.Default = "(0)"
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShipName, 8, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShipName
			c.CharacterMaxLength = 40
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShipAddress, 9, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShipAddress
			c.CharacterMaxLength = 60
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShipCity, 10, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShipCity
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShipRegion, 11, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShipRegion
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShipPostalCode, 12, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShipPostalCode
			c.CharacterMaxLength = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(OrdersMetadata.ColumnNames.ShipCountry, 13, GetType(System.String), esSystemType.String)	
			c.PropertyName = OrdersMetadata.PropertyNames.ShipCountry
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As OrdersMetadata
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
			 Public Const CustomerID As String = "CustomerID"
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const OrderDate As String = "OrderDate"
			 Public Const RequiredDate As String = "RequiredDate"
			 Public Const ShippedDate As String = "ShippedDate"
			 Public Const ShipVia As String = "ShipVia"
			 Public Const Freight As String = "Freight"
			 Public Const ShipName As String = "ShipName"
			 Public Const ShipAddress As String = "ShipAddress"
			 Public Const ShipCity As String = "ShipCity"
			 Public Const ShipRegion As String = "ShipRegion"
			 Public Const ShipPostalCode As String = "ShipPostalCode"
			 Public Const ShipCountry As String = "ShipCountry"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const OrderID As String = "OrderID"
			 Public Const CustomerID As String = "CustomerID"
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const OrderDate As String = "OrderDate"
			 Public Const RequiredDate As String = "RequiredDate"
			 Public Const ShippedDate As String = "ShippedDate"
			 Public Const ShipVia As String = "ShipVia"
			 Public Const Freight As String = "Freight"
			 Public Const ShipName As String = "ShipName"
			 Public Const ShipAddress As String = "ShipAddress"
			 Public Const ShipCity As String = "ShipCity"
			 Public Const ShipRegion As String = "ShipRegion"
			 Public Const ShipPostalCode As String = "ShipPostalCode"
			 Public Const ShipCountry As String = "ShipCountry"
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
			SyncLock GetType(OrdersMetadata)
			
				If OrdersMetadata.mapDelegates Is Nothing Then
					OrdersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If OrdersMetadata._meta Is Nothing Then
					OrdersMetadata._meta = New OrdersMetadata()
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
				meta.AddTypeMap("CustomerID", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("OrderDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("RequiredDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("ShippedDate", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("ShipVia", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("Freight", new esTypeMap("money", "System.Decimal"))
				meta.AddTypeMap("ShipName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("ShipAddress", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("ShipCity", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("ShipRegion", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("ShipCountry", new esTypeMap("nvarchar", "System.String"))			
				
				
				 
				meta.Source = "Orders"
				meta.Destination = "Orders"
				
				meta.spInsert = "proc_OrdersInsert"
				meta.spUpdate = "proc_OrdersUpdate"
				meta.spDelete = "proc_OrdersDelete"
				meta.spLoadAll = "proc_OrdersLoadAll"
				meta.spLoadByPrimaryKey = "proc_OrdersLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As OrdersMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
