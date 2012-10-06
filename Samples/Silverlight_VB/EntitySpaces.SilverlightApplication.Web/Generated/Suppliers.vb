
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:23 PM
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
	' Encapsulates the 'Suppliers' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Suppliers))> _
	<XmlType("Suppliers")> _	
	Partial Public Class Suppliers 
		Inherits esSuppliers
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Suppliers()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal supplierID As System.Int32)
			Dim obj As New Suppliers()
			obj.SupplierID = supplierID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal supplierID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Suppliers()
			obj.SupplierID = supplierID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Suppliers) As SuppliersProxyStub
			Return New SuppliersProxyStub(entity)
		End Operator

		#End Region
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("SuppliersCollection")> _
	Partial Public Class SuppliersCollection
		Inherits esSuppliersCollection
		Implements IEnumerable(Of Suppliers)
	
		Public Function FindByPrimaryKey(ByVal supplierID As System.Int32) As Suppliers
			Return MyBase.SingleOrDefault(Function(e) e.SupplierID.HasValue AndAlso e.SupplierID.Value = supplierID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As SuppliersCollection) As SuppliersCollectionProxyStub
            Return New SuppliersCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Suppliers))> _
		Public Class SuppliersCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of SuppliersCollection)
			
			Public Shared Widening Operator CType(packet As SuppliersCollectionWCFPacket) As SuppliersCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As SuppliersCollection) As SuppliersCollectionWCFPacket
				Return New SuppliersCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "SuppliersQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class SuppliersQuery 
		Inherits esSuppliersQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "SuppliersQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As SuppliersQuery) As String
			Return SuppliersQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As SuppliersQuery
			Return DirectCast(SuppliersQuery.SerializeHelper.FromXml(query, GetType(SuppliersQuery)), SuppliersQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esSuppliers
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal supplierID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(supplierID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(supplierID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal supplierID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(supplierID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(supplierID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal supplierID As System.Int32) As Boolean
		
			Dim query As New SuppliersQuery()
			query.Where(query.SupplierID = supplierID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal supplierID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("SupplierID", supplierID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Suppliers.SupplierID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property SupplierID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(SuppliersMetadata.ColumnNames.SupplierID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(SuppliersMetadata.ColumnNames.SupplierID, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.SupplierID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.CompanyName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CompanyName As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.CompanyName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.CompanyName, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.CompanyName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.ContactName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ContactName As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.ContactName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.ContactName, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.ContactName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.ContactTitle
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ContactTitle As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.ContactTitle)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.ContactTitle, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.ContactTitle)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.Address
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Address As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.Address)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.Address, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.Address)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.City
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property City As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.City)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.City, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.City)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.Region
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Region As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.Region)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.Region, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.Region)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.PostalCode
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property PostalCode As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.PostalCode)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.PostalCode, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.PostalCode)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.Country
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Country As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.Country)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.Country, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.Country)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.Phone
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Phone As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.Phone)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.Phone, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.Phone)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.Fax
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Fax As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.Fax)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.Fax, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.Fax)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Suppliers.HomePage
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property HomePage As System.String
			Get
				Return MyBase.GetSystemString(SuppliersMetadata.ColumnNames.HomePage)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SuppliersMetadata.ColumnNames.HomePage, value) Then
					OnPropertyChanged(SuppliersMetadata.PropertyNames.HomePage)
				End If
			End Set
		End Property	
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return SuppliersMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As SuppliersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New SuppliersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As SuppliersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As SuppliersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As SuppliersQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esSuppliersCollection
		Inherits esEntityCollection(Of Suppliers)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return SuppliersMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "SuppliersCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As SuppliersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New SuppliersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As SuppliersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New SuppliersQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As SuppliersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, SuppliersQuery))
		End Sub
		
		#End Region
						
		Private m_query As SuppliersQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esSuppliersQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return SuppliersMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "SupplierID" 
					Return Me.SupplierID
				Case "CompanyName" 
					Return Me.CompanyName
				Case "ContactName" 
					Return Me.ContactName
				Case "ContactTitle" 
					Return Me.ContactTitle
				Case "Address" 
					Return Me.Address
				Case "City" 
					Return Me.City
				Case "Region" 
					Return Me.Region
				Case "PostalCode" 
					Return Me.PostalCode
				Case "Country" 
					Return Me.Country
				Case "Phone" 
					Return Me.Phone
				Case "Fax" 
					Return Me.Fax
				Case "HomePage" 
					Return Me.HomePage
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property SupplierID As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.SupplierID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property CompanyName As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.CompanyName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ContactName As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.ContactName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ContactTitle As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.ContactTitle, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Address As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.Address, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property City As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.City, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Region As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.Region, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property PostalCode As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.PostalCode, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Country As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.Country, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Phone As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.Phone, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Fax As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.Fax, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property HomePage As esQueryItem
			Get
				Return New esQueryItem(Me, SuppliersMetadata.ColumnNames.HomePage, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Suppliers 
		Inherits esSuppliers
		
	
		#Region "ProductsCollectionBySupplierID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_ProductsCollectionBySupplierID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Suppliers.ProductsCollectionBySupplierID_Delegate)
				map.PropertyName = "ProductsCollectionBySupplierID"
				map.MyColumnName = "SupplierID"
				map.ParentColumnName = "SupplierID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub ProductsCollectionBySupplierID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New SuppliersQuery(data.NextAlias())
			
			Dim mee As ProductsQuery = If(data.You IsNot Nothing, TryCast(data.You, ProductsQuery), New ProductsQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.SupplierID = mee.SupplierID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Products_Suppliers
		''' </summary>

		<XmlIgnore()> _ 
		Public Property ProductsCollectionBySupplierID As ProductsCollection 
		
			Get
				If Me._ProductsCollectionBySupplierID Is Nothing Then
					Me._ProductsCollectionBySupplierID = New ProductsCollection()
					Me._ProductsCollectionBySupplierID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("ProductsCollectionBySupplierID", Me._ProductsCollectionBySupplierID)
				
					If Not Me.SupplierID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._ProductsCollectionBySupplierID.Query.Where(Me._ProductsCollectionBySupplierID.Query.SupplierID = Me.SupplierID)
							Me._ProductsCollectionBySupplierID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._ProductsCollectionBySupplierID.fks.Add(ProductsMetadata.ColumnNames.SupplierID, Me.SupplierID)
					End If
				End If

				Return Me._ProductsCollectionBySupplierID
			End Get
			
			Set(ByVal value As ProductsCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._ProductsCollectionBySupplierID Is Nothing Then

					Me.RemovePostSave("ProductsCollectionBySupplierID")
					Me._ProductsCollectionBySupplierID = Nothing
					Me.OnPropertyChanged("ProductsCollectionBySupplierID")

				End If
			End Set				
			
		End Property
		

		private _ProductsCollectionBySupplierID As ProductsCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "ProductsCollectionBySupplierID"
					coll = Me.ProductsCollectionBySupplierID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "ProductsCollectionBySupplierID", GetType(ProductsCollection), New Products()))
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
		
			If Not Me._ProductsCollectionBySupplierID Is Nothing Then
				Apply(Me._ProductsCollectionBySupplierID, "SupplierID", Me.SupplierID)
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Suppliers")> _
    <XmlType(TypeName:="SuppliersProxyStub")> _
    <Serializable> _
    Partial Public Class SuppliersProxyStub
	
		Public Sub New()
            Me._entity = New Suppliers()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Suppliers)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Suppliers, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As SuppliersProxyStub) As Suppliers
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Suppliers)
        End Function
		

		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _		
        Public Property SupplierID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(SuppliersMetadata.ColumnNames.SupplierID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.SupplierID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.SupplierID = value
			End Set
			
		End Property

		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _		
        Public Property CompanyName As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.CompanyName) Then
                    Return Me.Entity.CompanyName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CompanyName = value
			End Set
			
		End Property

		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _		
        Public Property ContactName As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.ContactName) Then
                    Return Me.Entity.ContactName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.ContactName = value
			End Set
			
		End Property

		<DataMember(Name:="a3", Order:=4, EmitDefaultValue:=False)> _		
        Public Property ContactTitle As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.ContactTitle) Then
                    Return Me.Entity.ContactTitle
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.ContactTitle = value
			End Set
			
		End Property

		<DataMember(Name:="a4", Order:=5, EmitDefaultValue:=False)> _		
        Public Property Address As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.Address) Then
                    Return Me.Entity.Address
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Address = value
			End Set
			
		End Property

		<DataMember(Name:="a5", Order:=6, EmitDefaultValue:=False)> _		
        Public Property City As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.City) Then
                    Return Me.Entity.City
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.City = value
			End Set
			
		End Property

		<DataMember(Name:="a6", Order:=7, EmitDefaultValue:=False)> _		
        Public Property Region As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.Region) Then
                    Return Me.Entity.Region
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Region = value
			End Set
			
		End Property

		<DataMember(Name:="a7", Order:=8, EmitDefaultValue:=False)> _		
        Public Property PostalCode As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.PostalCode) Then
                    Return Me.Entity.PostalCode
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.PostalCode = value
			End Set
			
		End Property

		<DataMember(Name:="a8", Order:=9, EmitDefaultValue:=False)> _		
        Public Property Country As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.Country) Then
                    Return Me.Entity.Country
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Country = value
			End Set
			
		End Property

		<DataMember(Name:="a9", Order:=10, EmitDefaultValue:=False)> _		
        Public Property Phone As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.Phone) Then
                    Return Me.Entity.Phone
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Phone = value
			End Set
			
		End Property

		<DataMember(Name:="a10", Order:=11, EmitDefaultValue:=False)> _		
        Public Property Fax As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.Fax) Then
                    Return Me.Entity.Fax
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Fax = value
			End Set
			
		End Property

		<DataMember(Name:="a11", Order:=12, EmitDefaultValue:=False)> _		
        Public Property HomePage As System.String
        
            Get
                If Me.IncludeColumn(SuppliersMetadata.ColumnNames.HomePage) Then
                    Return Me.Entity.HomePage
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.HomePage = value
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
        Public Property Entity As Suppliers
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Suppliers()
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
        Public _entity As Suppliers
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="SuppliersCollection")> _
    <XmlType(TypeName:="SuppliersCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class SuppliersCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Suppliers))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Suppliers), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As SuppliersCollectionProxyStub) As SuppliersCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Suppliers)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Suppliers), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Suppliers In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New SuppliersProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New SuppliersProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Suppliers In coll.es.DeletedEntities
                    Collection.Add(New SuppliersProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of SuppliersProxyStub)		

        Public Function GetCollection As SuppliersCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New SuppliersCollection()
					
		            Dim proxy As SuppliersProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As SuppliersCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class SuppliersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.SupplierID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = SuppliersMetadata.PropertyNames.SupplierID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.CompanyName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.CompanyName
			c.CharacterMaxLength = 40
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.ContactName, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.ContactName
			c.CharacterMaxLength = 30
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.ContactTitle, 3, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.ContactTitle
			c.CharacterMaxLength = 30
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.Address, 4, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.Address
			c.CharacterMaxLength = 60
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.City, 5, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.City
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.Region, 6, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.Region
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.PostalCode, 7, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.PostalCode
			c.CharacterMaxLength = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.Country, 8, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.Country
			c.CharacterMaxLength = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.Phone, 9, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.Phone
			c.CharacterMaxLength = 24
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.Fax, 10, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.Fax
			c.CharacterMaxLength = 24
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SuppliersMetadata.ColumnNames.HomePage, 11, GetType(System.String), esSystemType.String)	
			c.PropertyName = SuppliersMetadata.PropertyNames.HomePage
			c.CharacterMaxLength = 1073741823
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As SuppliersMetadata
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
			 Public Const SupplierID As String = "SupplierID"
			 Public Const CompanyName As String = "CompanyName"
			 Public Const ContactName As String = "ContactName"
			 Public Const ContactTitle As String = "ContactTitle"
			 Public Const Address As String = "Address"
			 Public Const City As String = "City"
			 Public Const Region As String = "Region"
			 Public Const PostalCode As String = "PostalCode"
			 Public Const Country As String = "Country"
			 Public Const Phone As String = "Phone"
			 Public Const Fax As String = "Fax"
			 Public Const HomePage As String = "HomePage"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const SupplierID As String = "SupplierID"
			 Public Const CompanyName As String = "CompanyName"
			 Public Const ContactName As String = "ContactName"
			 Public Const ContactTitle As String = "ContactTitle"
			 Public Const Address As String = "Address"
			 Public Const City As String = "City"
			 Public Const Region As String = "Region"
			 Public Const PostalCode As String = "PostalCode"
			 Public Const Country As String = "Country"
			 Public Const Phone As String = "Phone"
			 Public Const Fax As String = "Fax"
			 Public Const HomePage As String = "HomePage"
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
			SyncLock GetType(SuppliersMetadata)
			
				If SuppliersMetadata.mapDelegates Is Nothing Then
					SuppliersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If SuppliersMetadata._meta Is Nothing Then
					SuppliersMetadata._meta = New SuppliersMetadata()
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
				


				meta.AddTypeMap("SupplierID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("CompanyName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("ContactName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("ContactTitle", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Address", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("City", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Region", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("PostalCode", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Country", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Fax", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("HomePage", new esTypeMap("ntext", "System.String"))			
				
				
				 
				meta.Source = "Suppliers"
				meta.Destination = "Suppliers"
				
				meta.spInsert = "proc_SuppliersInsert"
				meta.spUpdate = "proc_SuppliersUpdate"
				meta.spDelete = "proc_SuppliersDelete"
				meta.spLoadAll = "proc_SuppliersLoadAll"
				meta.spLoadByPrimaryKey = "proc_SuppliersLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As SuppliersMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
