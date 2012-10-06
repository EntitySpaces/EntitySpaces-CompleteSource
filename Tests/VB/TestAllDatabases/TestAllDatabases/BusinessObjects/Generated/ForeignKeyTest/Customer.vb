
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : SQL
' Date Generated       : 3/17/2012 4:51:52 AM
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
	' Encapsulates the 'Customer' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Customer))> _
	<XmlType("Customer")> _ 
	<Table(Name:="Customer")> _	
	Partial Public Class Customer 
		Inherits esCustomer
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
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
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Customer) As CustomerProxyStub
			Return New CustomerProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property CustomerID As System.String
			Get
				Return MyBase.CustomerID
			End Get
			Set
				MyBase.CustomerID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property CustomerSub As System.String
			Get
				Return MyBase.CustomerSub
			End Get
			Set
				MyBase.CustomerSub = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property CustomerName As System.String
			Get
				Return MyBase.CustomerName
			End Get
			Set
				MyBase.CustomerName = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DateAdded As Nullable(Of System.DateTime)
			Get
				Return MyBase.DateAdded
			End Get
			Set
				MyBase.DateAdded = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property Active As Nullable(Of System.Boolean)
			Get
				Return MyBase.Active
			End Get
			Set
				MyBase.Active = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.ConcurrencyCheck
			End Get
			Set
				MyBase.ConcurrencyCheck = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property Manager As Nullable(Of System.Int32)
			Get
				Return MyBase.Manager
			End Get
			Set
				MyBase.Manager = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property StaffAssigned As Nullable(Of System.Int32)
			Get
				Return MyBase.StaffAssigned
			End Get
			Set
				MyBase.StaffAssigned = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property UniqueID As Nullable(Of System.Guid)
			Get
				Return MyBase.UniqueID
			End Get
			Set
				MyBase.UniqueID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Notes As System.String
			Get
				Return MyBase.Notes
			End Get
			Set
				MyBase.Notes = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property CreditLimit As Nullable(Of System.Decimal)
			Get
				Return MyBase.CreditLimit
			End Get
			Set
				MyBase.CreditLimit = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Discount As Nullable(Of System.Decimal)
			Get
				Return MyBase.Discount
			End Get
			Set
				MyBase.Discount = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("CustomerCollection")> _
	Partial Public Class CustomerCollection
		Inherits esCustomerCollection
		Implements IEnumerable(Of Customer)
	
		Public Function FindByPrimaryKey(ByVal customerID As System.String, ByVal customerSub As System.String) As Customer
			Return MyBase.SingleOrDefault(Function(e) e.CustomerID = customerID And e.CustomerSub = customerSub)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As CustomerCollection) As CustomerCollectionProxyStub
            Return New CustomerCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Customer))> _
		Public Class CustomerCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of CustomerCollection)
			
			Public Shared Widening Operator CType(packet As CustomerCollectionWCFPacket) As CustomerCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As CustomerCollection) As CustomerCollectionWCFPacket
				Return New CustomerCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "CustomerQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class CustomerQuery 
		Inherits esCustomerQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CustomerQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As CustomerQuery) As String
			Return CustomerQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As CustomerQuery
			Return DirectCast(CustomerQuery.SerializeHelper.FromXml(query, GetType(CustomerQuery)), CustomerQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.GetSystemByteArray(CustomerMetadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As System.Byte())
				If MyBase.SetSystemByteArray(CustomerMetadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(CustomerMetadata.PropertyNames.ConcurrencyCheck)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Customer.Manager
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Discount As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(CustomerMetadata.ColumnNames.Discount)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(CustomerMetadata.ColumnNames.Discount, value) Then
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
												
						Case "CustomerID"
							Me.str().CustomerID = CType(value, string)
												
						Case "CustomerSub"
							Me.str().CustomerSub = CType(value, string)
												
						Case "CustomerName"
							Me.str().CustomerName = CType(value, string)
												
						Case "DateAdded"
							Me.str().DateAdded = CType(value, string)
												
						Case "Active"
							Me.str().Active = CType(value, string)
												
						Case "Manager"
							Me.str().Manager = CType(value, string)
												
						Case "StaffAssigned"
							Me.str().StaffAssigned = CType(value, string)
												
						Case "UniqueID"
							Me.str().UniqueID = CType(value, string)
												
						Case "Notes"
							Me.str().Notes = CType(value, string)
												
						Case "CreditLimit"
							Me.str().CreditLimit = CType(value, string)
												
						Case "Discount"
							Me.str().Discount = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "DateAdded"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.DateAdded = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(CustomerMetadata.PropertyNames.DateAdded)
							End If
						
						Case "Active"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Boolean" Then
								Me.Active = CType(value, Nullable(Of System.Boolean))
								OnPropertyChanged(CustomerMetadata.PropertyNames.Active)
							End If
						
						Case "ConcurrencyCheck"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Byte()" Then
								Me.ConcurrencyCheck = CType(value, System.Byte())
								OnPropertyChanged(CustomerMetadata.PropertyNames.ConcurrencyCheck)
							End If
						
						Case "Manager"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Manager = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(CustomerMetadata.PropertyNames.Manager)
							End If
						
						Case "StaffAssigned"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.StaffAssigned = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(CustomerMetadata.PropertyNames.StaffAssigned)
							End If
						
						Case "UniqueID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Guid" Then
								Me.UniqueID = CType(value, Nullable(Of System.Guid))
								OnPropertyChanged(CustomerMetadata.PropertyNames.UniqueID)
							End If
						
						Case "CreditLimit"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.CreditLimit = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(CustomerMetadata.PropertyNames.CreditLimit)
							End If
						
						Case "Discount"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.Discount = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(CustomerMetadata.PropertyNames.Discount)
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
		
			Public Sub New(ByVal entity As esCustomer)
				Me.entity = entity
			End Sub				
		
	
			Public Property CustomerID As System.String 
				Get
					Dim data_ As System.String = entity.CustomerID
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CustomerID = Nothing
					Else
						entity.CustomerID = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property CustomerSub As System.String 
				Get
					Dim data_ As System.String = entity.CustomerSub
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CustomerSub = Nothing
					Else
						entity.CustomerSub = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property CustomerName As System.String 
				Get
					Dim data_ As System.String = entity.CustomerName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CustomerName = Nothing
					Else
						entity.CustomerName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property DateAdded As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.DateAdded
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DateAdded = Nothing
					Else
						entity.DateAdded = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property Active As System.String 
				Get
					Dim data_ As Nullable(Of System.Boolean) = entity.Active
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Active = Nothing
					Else
						entity.Active = Convert.ToBoolean(Value)
					End If
				End Set
			End Property
		  	
			Public Property Manager As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.Manager
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Manager = Nothing
					Else
						entity.Manager = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property StaffAssigned As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.StaffAssigned
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.StaffAssigned = Nothing
					Else
						entity.StaffAssigned = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property UniqueID As System.String 
				Get
					Dim data_ As Nullable(Of System.Guid) = entity.UniqueID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.UniqueID = Nothing
					Else
						entity.UniqueID = new Guid(Value)
					End If
				End Set
			End Property
		  	
			Public Property Notes As System.String 
				Get
					Dim data_ As System.String = entity.Notes
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Notes = Nothing
					Else
						entity.Notes = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property CreditLimit As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.CreditLimit
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CreditLimit = Nothing
					Else
						entity.CreditLimit = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property Discount As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.Discount
					
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
						entity.Discount = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  

			Private entity As esCustomer
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
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

        <IgnoreDataMember> _
        Private m_query As CustomerQuery

	End Class



	<Serializable()> _
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
		

		<BrowsableAttribute(False)> _ 
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



	<Serializable> _
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
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray)
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
				Return New esQueryItem(Me, CustomerMetadata.ColumnNames.Discount, esSystemType.Decimal)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Customer 
		Inherits esCustomer
		
	
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
		''' Foreign Key Name - FK_Orders_Customers
		''' </summary>

		<XmlIgnore()> _ 
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

		#Region "UpToCustomerGroupByCustomerID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_Customer_CustomerGroup
		''' </summary>

		<XmlIgnore()> _		
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
		''' Foreign Key Name - FK_Customer_Manager
		''' </summary>

		<XmlIgnore()> _		
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
		''' Foreign Key Name - FK_Customer_StaffAssigned
		''' </summary>

		<XmlIgnore()> _		
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
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Customer")> _
    <XmlType(TypeName:="CustomerProxyStub")> _
    <Serializable> _
    Partial Public Class CustomerProxyStub
	
		Public Sub New()
            Me._entity = New Customer()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Customer)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Customer, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As CustomerProxyStub) As Customer
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Customer)
        End Function
		

		<DataMember(Name:="CustomerID", Order:=1, EmitDefaultValue:=False)> _		
        Public Property CustomerID As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CustomerMetadata.ColumnNames.CustomerID)
					Return CType(o, System.String)
                Else
					Return Me.Entity.CustomerID
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CustomerID = value
			End Set
			
		End Property

		<DataMember(Name:="CustomerSub", Order:=2, EmitDefaultValue:=False)> _		
        Public Property CustomerSub As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CustomerMetadata.ColumnNames.CustomerSub)
					Return CType(o, System.String)
                Else
					Return Me.Entity.CustomerSub
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CustomerSub = value
			End Set
			
		End Property

		<DataMember(Name:="CustomerName", Order:=3, EmitDefaultValue:=False)> _		
        Public Property CustomerName As System.String
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.CustomerName) Then
                    Return Me.Entity.CustomerName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CustomerName = value
			End Set
			
		End Property

		<DataMember(Name:="DateAdded", Order:=4, EmitDefaultValue:=False)> _		
        Public Property DateAdded As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.DateAdded) Then
                    Return Me.Entity.DateAdded
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.DateAdded = value
			End Set
			
		End Property

		<DataMember(Name:="Active", Order:=5, EmitDefaultValue:=False)> _		
        Public Property Active As Nullable(Of System.Boolean)
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.Active) Then
                    Return Me.Entity.Active
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Boolean))
				Me.Entity.Active = value
			End Set
			
		End Property

		<DataMember(Name:="ConcurrencyCheck", Order:=6, EmitDefaultValue:=False)> _		
        Public Property ConcurrencyCheck As System.Byte()
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.ConcurrencyCheck) Then
                    Return Me.Entity.ConcurrencyCheck
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.Byte())
				Me.Entity.ConcurrencyCheck = value
			End Set
			
		End Property

		<DataMember(Name:="Manager", Order:=7, EmitDefaultValue:=False)> _		
        Public Property Manager As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.Manager) Then
                    Return Me.Entity.Manager
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Manager = value
			End Set
			
		End Property

		<DataMember(Name:="StaffAssigned", Order:=8, EmitDefaultValue:=False)> _		
        Public Property StaffAssigned As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.StaffAssigned) Then
                    Return Me.Entity.StaffAssigned
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.StaffAssigned = value
			End Set
			
		End Property

		<DataMember(Name:="UniqueID", Order:=9, EmitDefaultValue:=False)> _		
        Public Property UniqueID As Nullable(Of System.Guid)
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.UniqueID) Then
                    Return Me.Entity.UniqueID
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Guid))
				Me.Entity.UniqueID = value
			End Set
			
		End Property

		<DataMember(Name:="Notes", Order:=10, EmitDefaultValue:=False)> _		
        Public Property Notes As System.String
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.Notes) Then
                    Return Me.Entity.Notes
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Notes = value
			End Set
			
		End Property

		<DataMember(Name:="CreditLimit", Order:=11, EmitDefaultValue:=False)> _		
        Public Property CreditLimit As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.CreditLimit) Then
                    Return Me.Entity.CreditLimit
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.CreditLimit = value
			End Set
			
		End Property

		<DataMember(Name:="Discount", Order:=12, EmitDefaultValue:=False)> _		
        Public Property Discount As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(CustomerMetadata.ColumnNames.Discount) Then
                    Return Me.Entity.Discount
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.Discount = value
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
        Public Property Entity As Customer
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Customer()
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
        Public _entity As Customer
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="CustomerCollection")> _
    <XmlType(TypeName:="CustomerCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class CustomerCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Customer))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Customer), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As CustomerCollectionProxyStub) As CustomerCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Customer)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Customer), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Customer In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New CustomerProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New CustomerProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Customer In coll.es.DeletedEntities
                    Collection.Add(New CustomerProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of CustomerProxyStub)		

        Public Function GetCollection As CustomerCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New CustomerCollection()
					
		            Dim proxy As CustomerProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As CustomerCollection
		
    End Class
	



	<Serializable> _
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
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.Active, 4, GetType(System.Boolean), esSystemType.Boolean)	
			c.PropertyName = CustomerMetadata.PropertyNames.Active
			c.HasDefault = True
			c.Default = "((1))"
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.ConcurrencyCheck, 5, GetType(System.Byte()), esSystemType.ByteArray)	
			c.PropertyName = CustomerMetadata.PropertyNames.ConcurrencyCheck
			c.CharacterMaxLength = 50
			c.IsNullable = True
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
			c.HasDefault = True
			c.Default = "(newid())"
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.Notes, 9, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerMetadata.PropertyNames.Notes
			c.CharacterMaxLength = 2147483647
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.CreditLimit, 10, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = CustomerMetadata.PropertyNames.CreditLimit
			c.NumericPrecision = 19
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerMetadata.ColumnNames.Discount, 11, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = CustomerMetadata.PropertyNames.Discount
			c.NumericPrecision = 18
			c.NumericScale = 4
			c.IsNullable = True
			m_columns.Add(c)
				
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
				


				meta.AddTypeMap("CustomerID", new esTypeMap("char", "System.String"))
				meta.AddTypeMap("CustomerSub", new esTypeMap("char", "System.String"))
				meta.AddTypeMap("CustomerName", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("Active", new esTypeMap("bit", "System.Boolean"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("varbinary", "System.Byte()"))
				meta.AddTypeMap("Manager", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("StaffAssigned", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("UniqueID", new esTypeMap("uniqueidentifier", "System.Guid"))
				meta.AddTypeMap("Notes", new esTypeMap("text", "System.String"))
				meta.AddTypeMap("CreditLimit", new esTypeMap("money", "System.Decimal"))
				meta.AddTypeMap("Discount", new esTypeMap("decimal", "System.Decimal"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "Customer"
				meta.Destination = "Customer"
				
				meta.spInsert = "proc_CustomerInsert"
				meta.spUpdate = "proc_CustomerUpdate"
				meta.spDelete = "proc_CustomerDelete"
				meta.spLoadAll = "proc_CustomerLoadAll"
				meta.spLoadByPrimaryKey = "proc_CustomerLoadByPrimaryKey"
				
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
