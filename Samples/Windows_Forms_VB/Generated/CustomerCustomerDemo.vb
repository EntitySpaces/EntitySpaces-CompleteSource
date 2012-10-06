
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
	' Encapsulates the 'CustomerCustomerDemo' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(CustomerCustomerDemo))> _
	<XmlType("CustomerCustomerDemo")> _	
	Partial Public Class CustomerCustomerDemo 
		Inherits esCustomerCustomerDemo
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New CustomerCustomerDemo()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal customerID As System.String, ByVal customerTypeID As System.String)
			Dim obj As New CustomerCustomerDemo()
			obj.CustomerID = customerID
			obj.CustomerTypeID = customerTypeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal customerID As System.String, ByVal customerTypeID As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New CustomerCustomerDemo()
			obj.CustomerID = customerID
			obj.CustomerTypeID = customerTypeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("CustomerCustomerDemoCollection")> _
	Partial Public Class CustomerCustomerDemoCollection
		Inherits esCustomerCustomerDemoCollection
		Implements IEnumerable(Of CustomerCustomerDemo)
	
		Public Function FindByPrimaryKey(ByVal customerID As System.String, ByVal customerTypeID As System.String) As CustomerCustomerDemo
			Return MyBase.SingleOrDefault(Function(e) e.CustomerID = customerID And e.CustomerTypeID = customerTypeID)
		End Function


				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(CustomerCustomerDemo))> _
		Public Class CustomerCustomerDemoCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of CustomerCustomerDemoCollection)
			
			Public Shared Widening Operator CType(packet As CustomerCustomerDemoCollectionWCFPacket) As CustomerCustomerDemoCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As CustomerCustomerDemoCollection) As CustomerCustomerDemoCollectionWCFPacket
				Return New CustomerCustomerDemoCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "CustomerCustomerDemoQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class CustomerCustomerDemoQuery 
		Inherits esCustomerCustomerDemoQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CustomerCustomerDemoQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As CustomerCustomerDemoQuery) As String
			Return CustomerCustomerDemoQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As CustomerCustomerDemoQuery
			Return DirectCast(CustomerCustomerDemoQuery.SerializeHelper.FromXml(query, GetType(CustomerCustomerDemoQuery)), CustomerCustomerDemoQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esCustomerCustomerDemo
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerID, customerTypeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerID, customerTypeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			Dim query As New CustomerCustomerDemoQuery()
			query.Where(query.CustomerID = customerID And query.CustomerTypeID = customerTypeID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("CustomerID", customerID)
						parms.Add("CustomerTypeID", customerTypeID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to CustomerCustomerDemo.CustomerID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CustomerID As System.String
			Get
				Return MyBase.GetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerID, value) Then
					Me._UpToCustomersByCustomerID = Nothing
					Me.OnPropertyChanged("UpToCustomersByCustomerID")
					OnPropertyChanged(CustomerCustomerDemoMetadata.PropertyNames.CustomerID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to CustomerCustomerDemo.CustomerTypeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CustomerTypeID As System.String
			Get
				Return MyBase.GetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, value) Then
					Me._UpToCustomerDemographicsByCustomerTypeID = Nothing
					Me.OnPropertyChanged("UpToCustomerDemographicsByCustomerTypeID")
					OnPropertyChanged(CustomerCustomerDemoMetadata.PropertyNames.CustomerTypeID)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToCustomerDemographicsByCustomerTypeID As CustomerDemographics
		
		<CLSCompliant(false)> _
		<DataMember(EmitDefaultValue:=False)> _
		Dim Friend Protected _UpToCustomersByCustomerID As Customers
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerCustomerDemoMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CustomerCustomerDemoQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerCustomerDemoQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CustomerCustomerDemoQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CustomerCustomerDemoQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As CustomerCustomerDemoQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esCustomerCustomerDemoCollection
		Inherits esEntityCollection(Of CustomerCustomerDemo)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerCustomerDemoMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CustomerCustomerDemoCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As CustomerCustomerDemoQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerCustomerDemoQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CustomerCustomerDemoQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CustomerCustomerDemoQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CustomerCustomerDemoQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CustomerCustomerDemoQuery))
		End Sub
		
		#End Region
						
		Private m_query As CustomerCustomerDemoQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esCustomerCustomerDemoQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CustomerCustomerDemoMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "CustomerID" 
					Return Me.CustomerID
				Case "CustomerTypeID" 
					Return Me.CustomerTypeID
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property CustomerID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerCustomerDemoMetadata.ColumnNames.CustomerID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CustomerTypeID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class CustomerCustomerDemo 
		Inherits esCustomerCustomerDemo
		
	
		#Region "UpToCustomerDemographicsByCustomerTypeID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_CustomerCustomerDemo
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToCustomerDemographicsByCustomerTypeID As CustomerDemographics
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCustomerDemographicsByCustomerTypeID Is Nothing _
						 AndAlso Not CustomerTypeID.Equals(Nothing)  Then
						
					Me._UpToCustomerDemographicsByCustomerTypeID = New CustomerDemographics()
					Me._UpToCustomerDemographicsByCustomerTypeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCustomerDemographicsByCustomerTypeID", Me._UpToCustomerDemographicsByCustomerTypeID)
					Me._UpToCustomerDemographicsByCustomerTypeID.Query.Where(Me._UpToCustomerDemographicsByCustomerTypeID.Query.CustomerTypeID = Me.CustomerTypeID)
					Me._UpToCustomerDemographicsByCustomerTypeID.Query.Load()
				End If

				Return Me._UpToCustomerDemographicsByCustomerTypeID
			End Get
			
            Set(ByVal value As CustomerDemographics)
				Me.RemovePreSave("UpToCustomerDemographicsByCustomerTypeID")
				
				Dim changed as Boolean = Me._UpToCustomerDemographicsByCustomerTypeID IsNot value

				If value Is Nothing Then
				
					Me.CustomerTypeID = Nothing
				
					Me._UpToCustomerDemographicsByCustomerTypeID = Nothing
				Else
				
					Me.CustomerTypeID = value.CustomerTypeID
					
					Me._UpToCustomerDemographicsByCustomerTypeID = value
					Me.SetPreSave("UpToCustomerDemographicsByCustomerTypeID", Me._UpToCustomerDemographicsByCustomerTypeID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCustomerDemographicsByCustomerTypeID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToCustomersByCustomerID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_CustomerCustomerDemo_Customers
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

		
		
	End Class
	
	<KnownType(GetType(CustomerDemographics))> _
	<KnownType(GetType(Customers))> _	
	Public Partial Class CustomerCustomerDemo
		Inherits esCustomerCustomerDemo
	
	End Class	



	<Serializable> _
	Partial Public Class CustomerCustomerDemoMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CustomerCustomerDemoMetadata.ColumnNames.CustomerID, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerCustomerDemoMetadata.PropertyNames.CustomerID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerCustomerDemoMetadata.PropertyNames.CustomerTypeID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 10
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As CustomerCustomerDemoMetadata
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
			 Public Const CustomerTypeID As String = "CustomerTypeID"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const CustomerID As String = "CustomerID"
			 Public Const CustomerTypeID As String = "CustomerTypeID"
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
			SyncLock GetType(CustomerCustomerDemoMetadata)
			
				If CustomerCustomerDemoMetadata.mapDelegates Is Nothing Then
					CustomerCustomerDemoMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CustomerCustomerDemoMetadata._meta Is Nothing Then
					CustomerCustomerDemoMetadata._meta = New CustomerCustomerDemoMetadata()
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
				


				meta.AddTypeMap("CustomerID", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("CustomerTypeID", new esTypeMap("nchar", "System.String"))			
				
				
				 
				meta.Source = "CustomerCustomerDemo"
				meta.Destination = "CustomerCustomerDemo"
				
				meta.spInsert = "proc_CustomerCustomerDemoInsert"
				meta.spUpdate = "proc_CustomerCustomerDemoUpdate"
				meta.spDelete = "proc_CustomerCustomerDemoDelete"
				meta.spLoadAll = "proc_CustomerCustomerDemoLoadAll"
				meta.spLoadByPrimaryKey = "proc_CustomerCustomerDemoLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CustomerCustomerDemoMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
