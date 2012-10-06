
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0930.0
' EntitySpaces Driver  : SQL
' Date Generated       : 9/23/2012 6:16:24 PM
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
Imports System.ServiceModel.DomainServices.Server
Imports System.ComponentModel.DataAnnotations

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery



Namespace BusinessObjects

	' <summary>
	' Encapsulates the 'CustomerDemographics' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(CustomerDemographics))> _
	<XmlType("CustomerDemographics")> _	
	Partial Public Class CustomerDemographics 
		Inherits esCustomerDemographics
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New CustomerDemographics()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal customerTypeID As System.String)
			Dim obj As New CustomerDemographics()
			obj.CustomerTypeID = customerTypeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal customerTypeID As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New CustomerDemographics()
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
	<XmlType("CustomerDemographicsCollection")> _
	Partial Public Class CustomerDemographicsCollection
		Inherits esCustomerDemographicsCollection
		Implements IEnumerable(Of CustomerDemographics)
	
		Public Function FindByPrimaryKey(ByVal customerTypeID As System.String) As CustomerDemographics
			Return MyBase.SingleOrDefault(Function(e) e.CustomerTypeID = customerTypeID)
		End Function


				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(CustomerDemographics))> _
		Public Class CustomerDemographicsCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of CustomerDemographicsCollection)
			
			Public Shared Widening Operator CType(packet As CustomerDemographicsCollectionWCFPacket) As CustomerDemographicsCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As CustomerDemographicsCollection) As CustomerDemographicsCollectionWCFPacket
				Return New CustomerDemographicsCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "CustomerDemographicsQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class CustomerDemographicsQuery 
		Inherits esCustomerDemographicsQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CustomerDemographicsQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As CustomerDemographicsQuery) As String
			Return CustomerDemographicsQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As CustomerDemographicsQuery
			Return DirectCast(CustomerDemographicsQuery.SerializeHelper.FromXml(query, GetType(CustomerDemographicsQuery)), CustomerDemographicsQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esCustomerDemographics
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal customerTypeID As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerTypeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerTypeID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal customerTypeID As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerTypeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerTypeID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal customerTypeID As System.String) As Boolean
		
			Dim query As New CustomerDemographicsQuery()
			query.Where(query.CustomerTypeID = customerTypeID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal customerTypeID As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("CustomerTypeID", customerTypeID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
				
		' For Ria Services
		<DataMember(EmitDefaultValue:=False)> _
		<Display(AutoGenerateField:=False)> _
		Public Property esExtendedData() As String
			Get
				Return GetExtraColumnsSerialized()
			End Get
			
			Private Set
			End Set
		End Property
		
			
		' <summary>
		' Maps to CustomerDemographics.CustomerTypeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CustomerTypeID As System.String
			Get
				Return MyBase.GetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerTypeID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerTypeID, value) Then
					OnPropertyChanged(CustomerDemographicsMetadata.PropertyNames.CustomerTypeID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to CustomerDemographics.CustomerDesc
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CustomerDesc As System.String
			Get
				Return MyBase.GetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerDesc)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerDemographicsMetadata.ColumnNames.CustomerDesc, value) Then
					OnPropertyChanged(CustomerDemographicsMetadata.PropertyNames.CustomerDesc)
				End If
			End Set
		End Property	
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerDemographicsMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CustomerDemographicsQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerDemographicsQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CustomerDemographicsQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CustomerDemographicsQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As CustomerDemographicsQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esCustomerDemographicsCollection
		Inherits esEntityCollection(Of CustomerDemographics)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerDemographicsMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CustomerDemographicsCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As CustomerDemographicsQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerDemographicsQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CustomerDemographicsQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CustomerDemographicsQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CustomerDemographicsQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CustomerDemographicsQuery))
		End Sub
		
		#End Region
						
		Private m_query As CustomerDemographicsQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esCustomerDemographicsQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CustomerDemographicsMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "CustomerTypeID" 
					Return Me.CustomerTypeID
				Case "CustomerDesc" 
					Return Me.CustomerDesc
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property CustomerTypeID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerDemographicsMetadata.ColumnNames.CustomerTypeID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CustomerDesc As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerDemographicsMetadata.ColumnNames.CustomerDesc, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class CustomerDemographics 
		Inherits esCustomerDemographics
		
	
		#Region "UpToCustomersCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_CustomerCustomerDemo
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToCustomersCollection As CustomersCollection
		
			Get
				If Me._UpToCustomersCollection Is Nothing Then
					Me._UpToCustomersCollection = New CustomersCollection()
					Me._UpToCustomersCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToCustomersCollection", Me._UpToCustomersCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.CustomerTypeID.Equals(Nothing) Then 
				
						Dim m As New CustomersQuery("m")
						Dim j As New CustomerCustomerDemoQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.CustomerID = j.CustomerID)
                        m.Where(j.CustomerTypeID = Me.CustomerTypeID)

						Me._UpToCustomersCollection.Load(m)

					End If
				End If

				Return Me._UpToCustomersCollection
			End Get
			
			Set(ByVal value As CustomersCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToCustomersCollection Is Nothing Then

					Me.RemovePostSave("UpToCustomersCollection")
					Me._UpToCustomersCollection = Nothing
					Me.OnPropertyChanged("UpToCustomersCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_CustomerCustomerDemo
		''' </summary>
		Public Sub AssociateCustomersCollection(entity As Customers)
			If Me._CustomerCustomerDemoCollection Is Nothing Then
				Me._CustomerCustomerDemoCollection = New CustomerCustomerDemoCollection()
				Me._CustomerCustomerDemoCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("CustomerCustomerDemoCollection", Me._CustomerCustomerDemoCollection)
			End If
			
			Dim obj As CustomerCustomerDemo = Me._CustomerCustomerDemoCollection.AddNew()
			obj.CustomerTypeID = Me.CustomerTypeID
			obj.CustomerID = entity.CustomerID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_CustomerCustomerDemo
		''' </summary>
		Public Sub DissociateCustomersCollection(entity As Customers)
			If Me._CustomerCustomerDemoCollection Is Nothing Then
				Me._CustomerCustomerDemoCollection = new CustomerCustomerDemoCollection()
				Me._CustomerCustomerDemoCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("CustomerCustomerDemoCollection", Me._CustomerCustomerDemoCollection)
			End If

			Dim obj As CustomerCustomerDemo = Me._CustomerCustomerDemoCollection.AddNew()
			obj.CustomerTypeID = Me.CustomerTypeID
            obj.CustomerID = entity.CustomerID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToCustomersCollection As CustomersCollection
		Private _CustomerCustomerDemoCollection As CustomerCustomerDemoCollection
		#End Region

		#Region "CustomerCustomerDemoCollectionByCustomerTypeID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_CustomerCustomerDemoCollectionByCustomerTypeID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.CustomerDemographics.CustomerCustomerDemoCollectionByCustomerTypeID_Delegate)
				map.PropertyName = "CustomerCustomerDemoCollectionByCustomerTypeID"
				map.MyColumnName = "CustomerTypeID"
				map.ParentColumnName = "CustomerTypeID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub CustomerCustomerDemoCollectionByCustomerTypeID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New CustomerDemographicsQuery(data.NextAlias())
			
			Dim mee As CustomerCustomerDemoQuery = If(data.You IsNot Nothing, TryCast(data.You, CustomerCustomerDemoQuery), New CustomerCustomerDemoQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.CustomerTypeID = mee.CustomerTypeID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_CustomerCustomerDemo
		''' </summary>

		<XmlIgnore()> _		
		<Include()> _ 
		<System.ComponentModel.DataAnnotations.Association("CustomerDemographics.CustomerCustomerDemoCollectionByCustomerTypeID", "CustomerTypeID", "CustomerTypeID")> _ 
		Public Property CustomerCustomerDemoCollectionByCustomerTypeID As CustomerCustomerDemoCollection 
		
			Get
				If Me._CustomerCustomerDemoCollectionByCustomerTypeID Is Nothing Then
					Me._CustomerCustomerDemoCollectionByCustomerTypeID = New CustomerCustomerDemoCollection()
					Me._CustomerCustomerDemoCollectionByCustomerTypeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("CustomerCustomerDemoCollectionByCustomerTypeID", Me._CustomerCustomerDemoCollectionByCustomerTypeID)
				
					If Not Me.CustomerTypeID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._CustomerCustomerDemoCollectionByCustomerTypeID.Query.Where(Me._CustomerCustomerDemoCollectionByCustomerTypeID.Query.CustomerTypeID = Me.CustomerTypeID)
							Me._CustomerCustomerDemoCollectionByCustomerTypeID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._CustomerCustomerDemoCollectionByCustomerTypeID.fks.Add(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, Me.CustomerTypeID)
					End If
				End If

				Return Me._CustomerCustomerDemoCollectionByCustomerTypeID
			End Get
			
			Set(ByVal value As CustomerCustomerDemoCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._CustomerCustomerDemoCollectionByCustomerTypeID Is Nothing Then

					Me.RemovePostSave("CustomerCustomerDemoCollectionByCustomerTypeID")
					Me._CustomerCustomerDemoCollectionByCustomerTypeID = Nothing
					Me.OnPropertyChanged("CustomerCustomerDemoCollectionByCustomerTypeID")

				End If
			End Set				
			
		End Property
		

		private _CustomerCustomerDemoCollectionByCustomerTypeID As CustomerCustomerDemoCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "CustomerCustomerDemoCollectionByCustomerTypeID"
					coll = Me.CustomerCustomerDemoCollectionByCustomerTypeID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "CustomerCustomerDemoCollectionByCustomerTypeID", GetType(CustomerCustomerDemoCollection), New CustomerCustomerDemo()))
			Return props
			
		End Function
	End Class
		



	<Serializable> _
	Partial Public Class CustomerDemographicsMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CustomerDemographicsMetadata.ColumnNames.CustomerTypeID, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerDemographicsMetadata.PropertyNames.CustomerTypeID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerDemographicsMetadata.ColumnNames.CustomerDesc, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerDemographicsMetadata.PropertyNames.CustomerDesc
			c.CharacterMaxLength = 1073741823
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As CustomerDemographicsMetadata
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
			 Public Const CustomerTypeID As String = "CustomerTypeID"
			 Public Const CustomerDesc As String = "CustomerDesc"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const CustomerTypeID As String = "CustomerTypeID"
			 Public Const CustomerDesc As String = "CustomerDesc"
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
			SyncLock GetType(CustomerDemographicsMetadata)
			
				If CustomerDemographicsMetadata.mapDelegates Is Nothing Then
					CustomerDemographicsMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CustomerDemographicsMetadata._meta Is Nothing Then
					CustomerDemographicsMetadata._meta = New CustomerDemographicsMetadata()
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
				


				meta.AddTypeMap("CustomerTypeID", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("CustomerDesc", new esTypeMap("ntext", "System.String"))			
				
				
				 
				meta.Source = "CustomerDemographics"
				meta.Destination = "CustomerDemographics"
				
				meta.spInsert = "proc_CustomerDemographicsInsert"
				meta.spUpdate = "proc_CustomerDemographicsUpdate"
				meta.spDelete = "proc_CustomerDemographicsDelete"
				meta.spLoadAll = "proc_CustomerDemographicsLoadAll"
				meta.spLoadByPrimaryKey = "proc_CustomerDemographicsLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CustomerDemographicsMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
