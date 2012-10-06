
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQLCE
' Date Generated       : 9/23/2012 6:16:26 PM
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
	' Encapsulates the 'Customer' table
	' </summary>
	
	Partial Public Class Customer 
		Inherits esCustomer
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Customer()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal customerID As System.String, ByVal customerSub As System.String)
			Dim obj As New Customer()
			obj.CustomerID = customerID
			obj.CustomerSub = customerSub
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal customerID As System.String, ByVal customerSub As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Customer()
			obj.CustomerID = customerID
			obj.CustomerSub = customerSub
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class CustomerCollection
		Inherits esCustomerCollection
		Implements IEnumerable(Of Customer)
	
		Public Function FindByPrimaryKey(ByVal customerID As System.String, ByVal customerSub As System.String) As Customer
			Return MyBase.SingleOrDefault(Function(e) e.CustomerID = customerID And e.CustomerSub = customerSub)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class CustomerQuery 
		Inherits esCustomerQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CustomerQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esCustomer
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal customerID As System.String, ByVal customerSub As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerID, customerSub)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerID, customerSub)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal customerID As System.String, ByVal customerSub As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerID, customerSub)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerID, customerSub)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal customerID As System.String, ByVal customerSub As System.String) As Boolean
		
			Dim query As New CustomerQuery()
			query.Where(query.CustomerID = customerID And query.CustomerSub = customerSub)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal customerID As System.String, ByVal customerSub As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("CustomerID", customerID)
						parms.Add("CustomerSub", customerSub)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Customer.CustomerID
		' </summary>
		Public Overridable Property CustomerID As System.String
			Get
				Return MyBase.GetSystemString(CustomerMetadata.ColumnNames.CustomerID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerMetadata.ColumnNames.CustomerID, value) Then
					Me._UpToCustomerGroupByCustomerID = Nothing
					Me.OnPropertyChanged("UpToCustomerGroupByCustomerID")
					OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.CustomerSub
		' </summary>
		Public Overridable Property CustomerSub As System.String
			Get
				Return MyBase.GetSystemString(CustomerMetadata.ColumnNames.CustomerSub)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerMetadata.ColumnNames.CustomerSub, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerSub)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.CustomerName
		' </summary>
		Public Overridable Property CustomerName As System.String
			Get
				Return MyBase.GetSystemString(CustomerMetadata.ColumnNames.CustomerName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerMetadata.ColumnNames.CustomerName, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.CustomerName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.DateAdded
		' </summary>
		Public Overridable Property DateAdded As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(CustomerMetadata.ColumnNames.DateAdded)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(CustomerMetadata.ColumnNames.DateAdded, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.DateAdded)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.Active
		' </summary>
		Public Overridable Property Active As Nullable(Of System.Boolean)
			Get
				Return MyBase.GetSystemBoolean(CustomerMetadata.ColumnNames.Active)
			End Get
			
			Set(ByVal value As Nullable(Of System.Boolean))
				If MyBase.SetSystemBoolean(CustomerMetadata.ColumnNames.Active, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.Active)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.ConcurrencyCheck
		' </summary>
		Public Overridable Property ConcurrencyCheck As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(CustomerMetadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(CustomerMetadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.ConcurrencyCheck)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.Manager
		' </summary>
		Public Overridable Property Manager As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(CustomerMetadata.ColumnNames.Manager)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(CustomerMetadata.ColumnNames.Manager, value) Then
					Me._UpToEmployeeByManager = Nothing
					Me.OnPropertyChanged("UpToEmployeeByManager")
					OnPropertyChanged(CustomerMetadata.PropertyNames.Manager)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.StaffAssigned
		' </summary>
		Public Overridable Property StaffAssigned As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(CustomerMetadata.ColumnNames.StaffAssigned)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(CustomerMetadata.ColumnNames.StaffAssigned, value) Then
					Me._UpToEmployeeByStaffAssigned = Nothing
					Me.OnPropertyChanged("UpToEmployeeByStaffAssigned")
					OnPropertyChanged(CustomerMetadata.PropertyNames.StaffAssigned)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.UniqueID
		' </summary>
		Public Overridable Property UniqueID As Nullable(Of System.Guid)
			Get
				Return MyBase.GetSystemGuid(CustomerMetadata.ColumnNames.UniqueID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Guid))
				If MyBase.SetSystemGuid(CustomerMetadata.ColumnNames.UniqueID, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.UniqueID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.Notes
		' </summary>
		Public Overridable Property Notes As System.String
			Get
				Return MyBase.GetSystemString(CustomerMetadata.ColumnNames.Notes)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerMetadata.ColumnNames.Notes, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.Notes)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.CreditLimit
		' </summary>
		Public Overridable Property CreditLimit As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(CustomerMetadata.ColumnNames.CreditLimit)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(CustomerMetadata.ColumnNames.CreditLimit, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.CreditLimit)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.Discount
		' </summary>
		Public Overridable Property Discount As Nullable(Of System.Double)
			Get
				Return MyBase.GetSystemDouble(CustomerMetadata.ColumnNames.Discount)
			End Get
			
			Set(ByVal value As Nullable(Of System.Double))
				If MyBase.SetSystemDouble(CustomerMetadata.ColumnNames.Discount, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.Discount)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToCustomerGroupByCustomerID As CustomerGroup
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeByManager As Employee
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeByStaffAssigned As Employee
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CustomerQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CustomerQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CustomerQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As CustomerQuery

	End Class



	MustInherit Public Partial Class esCustomerCollection
		Inherits esEntityCollection(Of Customer)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CustomerCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As CustomerQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CustomerQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CustomerQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CustomerQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CustomerQuery))
		End Sub
		
		#End Region
						
		Private m_query As CustomerQuery
	End Class



	MustInherit Public Partial Class esCustomerQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CustomerMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "CustomerID" 
					Return Me.CustomerID
				Case "CustomerSub" 
					Return Me.CustomerSub
				Case "CustomerName" 
					Return Me.CustomerName
				Case "DateAdded" 
					Return Me.DateAdded
				Case "Active" 
					Return Me.Active
				Case "ConcurrencyCheck" 
					Return Me.ConcurrencyCheck
				Case "Manager" 
					Return Me.Manager
				Case "StaffAssigned" 
					Return Me.StaffAssigned
				Case "UniqueID" 
					Return Me.UniqueID
				Case "Notes" 
					Return Me.Notes
				Case "CreditLimit" 
					Return Me.CreditLimit
				Case "Discount" 
					Return Me.Discount
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property CustomerID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.CustomerID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CustomerSub As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.CustomerSub, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CustomerName As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.CustomerName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property DateAdded As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.DateAdded, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property Active As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.Active, esSystemType.Boolean)
			End Get
		End Property 
		
		Public ReadOnly Property ConcurrencyCheck As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Manager As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.Manager, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property StaffAssigned As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.StaffAssigned, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property UniqueID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.UniqueID, esSystemType.Guid)
			End Get
		End Property 
		
		Public ReadOnly Property Notes As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.Notes, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CreditLimit As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.CreditLimit, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property Discount As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.Discount, esSystemType.Double)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Customer 
		Inherits esCustomer
		
	
		#Region "UpToCustomerGroupByCustomerID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - CustomerGroupCustomer
		''' </summary>
		
		Public Property UpToCustomerGroupByCustomerID As CustomerGroup
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCustomerGroupByCustomerID Is Nothing _
						 AndAlso Not CustomerID.Equals(Nothing)  Then
						
					Me._UpToCustomerGroupByCustomerID = New CustomerGroup()
					Me._UpToCustomerGroupByCustomerID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCustomerGroupByCustomerID", Me._UpToCustomerGroupByCustomerID)
					Me._UpToCustomerGroupByCustomerID.Query.Where(Me._UpToCustomerGroupByCustomerID.Query.GroupID = Me.CustomerID)
					Me._UpToCustomerGroupByCustomerID.Query.Load()
				End If

				Return Me._UpToCustomerGroupByCustomerID
			End Get
			
            Set(ByVal value As CustomerGroup)
				Me.RemovePreSave("UpToCustomerGroupByCustomerID")
				
				Dim changed as Boolean = Me._UpToCustomerGroupByCustomerID IsNot value

				If value Is Nothing Then
				
					Me.CustomerID = Nothing
				
					Me._UpToCustomerGroupByCustomerID = Nothing
				Else
				
					Me.CustomerID = value.GroupID
					
					Me._UpToCustomerGroupByCustomerID = value
					Me.SetPreSave("UpToCustomerGroupByCustomerID", Me._UpToCustomerGroupByCustomerID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCustomerGroupByCustomerID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToEmployeeByManager - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - EmployeeCustomer
		''' </summary>
		
		Public Property UpToEmployeeByManager As Employee
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeeByManager Is Nothing _
						 AndAlso Not Manager.Equals(Nothing)  Then
						
					Me._UpToEmployeeByManager = New Employee()
					Me._UpToEmployeeByManager.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeeByManager", Me._UpToEmployeeByManager)
					Me._UpToEmployeeByManager.Query.Where(Me._UpToEmployeeByManager.Query.EmployeeID = Me.Manager)
					Me._UpToEmployeeByManager.Query.Load()
				End If

				Return Me._UpToEmployeeByManager
			End Get
			
            Set(ByVal value As Employee)
				Me.RemovePreSave("UpToEmployeeByManager")
				
				Dim changed as Boolean = Me._UpToEmployeeByManager IsNot value

				If value Is Nothing Then
				
					Me.Manager = Nothing
				
					Me._UpToEmployeeByManager = Nothing
				Else
				
					Me.Manager = value.EmployeeID
					
					Me._UpToEmployeeByManager = value
					Me.SetPreSave("UpToEmployeeByManager", Me._UpToEmployeeByManager)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeeByManager")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToEmployeeByStaffAssigned - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - EmployeeCustomer1
		''' </summary>
		
		Public Property UpToEmployeeByStaffAssigned As Employee
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeeByStaffAssigned Is Nothing _
						 AndAlso Not StaffAssigned.Equals(Nothing)  Then
						
					Me._UpToEmployeeByStaffAssigned = New Employee()
					Me._UpToEmployeeByStaffAssigned.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeeByStaffAssigned", Me._UpToEmployeeByStaffAssigned)
					Me._UpToEmployeeByStaffAssigned.Query.Where(Me._UpToEmployeeByStaffAssigned.Query.EmployeeID = Me.StaffAssigned)
					Me._UpToEmployeeByStaffAssigned.Query.Load()
				End If

				Return Me._UpToEmployeeByStaffAssigned
			End Get
			
            Set(ByVal value As Employee)
				Me.RemovePreSave("UpToEmployeeByStaffAssigned")
				
				Dim changed as Boolean = Me._UpToEmployeeByStaffAssigned IsNot value

				If value Is Nothing Then
				
					Me.StaffAssigned = Nothing
				
					Me._UpToEmployeeByStaffAssigned = Nothing
				Else
				
					Me.StaffAssigned = value.EmployeeID
					
					Me._UpToEmployeeByStaffAssigned = value
					Me.SetPreSave("UpToEmployeeByStaffAssigned", Me._UpToEmployeeByStaffAssigned)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeeByStaffAssigned")
				End If
			End Set	

		End Property
		#End Region

		#Region "OrderCollectionByCustID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrderCollectionByCustID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Customer.OrderCollectionByCustID_Delegate)
				map.PropertyName = "OrderCollectionByCustID"
				map.MyColumnName = "CustID,CustSub"
				map.ParentColumnName = "CustomerID,CustomerSub"
				map.IsMultiPartKey = true
				Return map
			End Get
		End Property

		Private Shared Sub OrderCollectionByCustID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New CustomerQuery(data.NextAlias())
			
			Dim mee As OrderQuery = If(data.You IsNot Nothing, TryCast(data.You, OrderQuery), New OrderQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.CustomerID = mee.CustID And parent.CustomerSub = mee.CustSub)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - CustomerOrder
		''' </summary>
 
		Public Property OrderCollectionByCustID As OrderCollection 
		
			Get
				If Me._OrderCollectionByCustID Is Nothing Then
					Me._OrderCollectionByCustID = New OrderCollection()
					Me._OrderCollectionByCustID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrderCollectionByCustID", Me._OrderCollectionByCustID)
				
					If Not Me.CustomerID.Equals(Nothing) AndAlso Not Me.CustomerSub.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrderCollectionByCustID.Query.Where(Me._OrderCollectionByCustID.Query.CustID = Me.CustomerID)
							Me._OrderCollectionByCustID.Query.Where(Me._OrderCollectionByCustID.Query.CustSub = Me.CustomerSub)
							Me._OrderCollectionByCustID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrderCollectionByCustID.fks.Add(OrderMetadata.ColumnNames.CustID, Me.CustomerID)
						Me._OrderCollectionByCustID.fks.Add(OrderMetadata.ColumnNames.CustSub, Me.CustomerSub)
					End If
				End If

				Return Me._OrderCollectionByCustID
			End Get
			
			Set(ByVal value As OrderCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrderCollectionByCustID Is Nothing Then

					Me.RemovePostSave("OrderCollectionByCustID")
					Me._OrderCollectionByCustID = Nothing
					Me.OnPropertyChanged("OrderCollectionByCustID")

				End If
			End Set				
			
		End Property
		

		private _OrderCollectionByCustID As OrderCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "OrderCollectionByCustID"
					coll = Me.OrderCollectionByCustID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "OrderCollectionByCustID", GetType(OrderCollection), New Order()))
			Return props
			
		End Function	
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByManager Is Nothing Then
				Me.Manager = Me._UpToEmployeeByManager.EmployeeID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByStaffAssigned Is Nothing Then
				Me.StaffAssigned = Me._UpToEmployeeByStaffAssigned.EmployeeID
			End If
			
		End Sub
	End Class
		



	Partial Public Class CustomerMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CustomerMetadata.ColumnNames.CustomerID, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerMetadata.PropertyNames.CustomerID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.CustomerSub, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerMetadata.PropertyNames.CustomerSub
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.CustomerName, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerMetadata.PropertyNames.CustomerName
			c.CharacterMaxLength = 25
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.DateAdded, 3, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = CustomerMetadata.PropertyNames.DateAdded
			c.NumericPrecision = 23
			c.NumericScale = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.Active, 4, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = CustomerMetadata.PropertyNames.Active
			c.NumericPrecision = 1
			c.HasDefault = True
			c.Default = "1"
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.ConcurrencyCheck, 5, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = CustomerMetadata.PropertyNames.ConcurrencyCheck
			c.NumericPrecision = 10
			c.HasDefault = True
			c.Default = "0"
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.Manager, 6, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = CustomerMetadata.PropertyNames.Manager
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.StaffAssigned, 7, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = CustomerMetadata.PropertyNames.StaffAssigned
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.UniqueID, 8, GetType(System.Guid), esSystemType.Guid)	
			c.PropertyName = CustomerMetadata.PropertyNames.UniqueID
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.Notes, 9, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerMetadata.PropertyNames.Notes
			c.CharacterMaxLength = 536870911
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.CreditLimit, 10, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = CustomerMetadata.PropertyNames.CreditLimit
			c.NumericPrecision = 19
			c.NumericScale = 4
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.Discount, 11, GetType(System.Double), esSystemType.Double)	
			c.PropertyName = CustomerMetadata.PropertyNames.Discount
			c.NumericPrecision = 53
			c.IsNullable = True
			m_columns.Add(c)
				
			m_columns.DateAdded = New esColumnMetadataCollection.SpecialDate()
			m_columns.DateAdded.ColumnName = "DateAdded"
			m_columns.DateAdded.IsEnabled = True
			m_columns.DateAdded.Type = DateType.ClientSide
			m_columns.DateAdded.ClientType = ClientType.Now

		End Sub
#End Region	
	
		Shared Public Function Meta() As CustomerMetadata
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
			 Public Const CustomerID As String = "CustomerID"
			 Public Const CustomerSub As String = "CustomerSub"
			 Public Const CustomerName As String = "CustomerName"
			 Public Const DateAdded As String = "DateAdded"
			 Public Const Active As String = "Active"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const Manager As String = "Manager"
			 Public Const StaffAssigned As String = "StaffAssigned"
			 Public Const UniqueID As String = "UniqueID"
			 Public Const Notes As String = "Notes"
			 Public Const CreditLimit As String = "CreditLimit"
			 Public Const Discount As String = "Discount"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const CustomerID As String = "CustomerID"
			 Public Const CustomerSub As String = "CustomerSub"
			 Public Const CustomerName As String = "CustomerName"
			 Public Const DateAdded As String = "DateAdded"
			 Public Const Active As String = "Active"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const Manager As String = "Manager"
			 Public Const StaffAssigned As String = "StaffAssigned"
			 Public Const UniqueID As String = "UniqueID"
			 Public Const Notes As String = "Notes"
			 Public Const CreditLimit As String = "CreditLimit"
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
			SyncLock GetType(CustomerMetadata)
			
				If CustomerMetadata.mapDelegates Is Nothing Then
					CustomerMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CustomerMetadata._meta Is Nothing Then
					CustomerMetadata._meta = New CustomerMetadata()
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
				


				meta.AddTypeMap("CustomerID", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("CustomerSub", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("CustomerName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("Active", new esTypeMap("bit", "System.Boolean"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("Manager", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("StaffAssigned", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("UniqueID", new esTypeMap("uniqueidentifier", "System.Guid"))
				meta.AddTypeMap("Notes", new esTypeMap("ntext", "System.String"))
				meta.AddTypeMap("CreditLimit", new esTypeMap("money", "System.Decimal"))
				meta.AddTypeMap("Discount", new esTypeMap("float", "System.Double"))			
				
				
				 
				meta.Source = "Customer"
				meta.Destination = "Customer"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CustomerMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
