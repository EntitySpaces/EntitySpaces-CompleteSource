
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
	' Encapsulates the 'Shippers' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Shippers))> _
	<XmlType("Shippers")> _	
	Partial Public Class Shippers 
		Inherits esShippers
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Shippers()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal shipperID As System.Int32)
			Dim obj As New Shippers()
			obj.ShipperID = shipperID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal shipperID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Shippers()
			obj.ShipperID = shipperID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ShippersCollection")> _
	Partial Public Class ShippersCollection
		Inherits esShippersCollection
		Implements IEnumerable(Of Shippers)
	
		Public Function FindByPrimaryKey(ByVal shipperID As System.Int32) As Shippers
			Return MyBase.SingleOrDefault(Function(e) e.ShipperID.HasValue AndAlso e.ShipperID.Value = shipperID)
		End Function


				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Shippers))> _
		Public Class ShippersCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ShippersCollection)
			
			Public Shared Widening Operator CType(packet As ShippersCollectionWCFPacket) As ShippersCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ShippersCollection) As ShippersCollectionWCFPacket
				Return New ShippersCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "ShippersQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ShippersQuery 
		Inherits esShippersQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ShippersQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ShippersQuery) As String
			Return ShippersQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ShippersQuery
			Return DirectCast(ShippersQuery.SerializeHelper.FromXml(query, GetType(ShippersQuery)), ShippersQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esShippers
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal shipperID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(shipperID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(shipperID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal shipperID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(shipperID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(shipperID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal shipperID As System.Int32) As Boolean
		
			Dim query As New ShippersQuery()
			query.Where(query.ShipperID = shipperID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal shipperID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("ShipperID", shipperID)
			
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
		' Maps to Shippers.ShipperID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipperID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ShippersMetadata.ColumnNames.ShipperID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ShippersMetadata.ColumnNames.ShipperID, value) Then
					OnPropertyChanged(ShippersMetadata.PropertyNames.ShipperID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Shippers.CompanyName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CompanyName As System.String
			Get
				Return MyBase.GetSystemString(ShippersMetadata.ColumnNames.CompanyName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ShippersMetadata.ColumnNames.CompanyName, value) Then
					OnPropertyChanged(ShippersMetadata.PropertyNames.CompanyName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Shippers.Phone
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Phone As System.String
			Get
				Return MyBase.GetSystemString(ShippersMetadata.ColumnNames.Phone)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ShippersMetadata.ColumnNames.Phone, value) Then
					OnPropertyChanged(ShippersMetadata.PropertyNames.Phone)
				End If
			End Set
		End Property	
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ShippersMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ShippersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ShippersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ShippersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ShippersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ShippersQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esShippersCollection
		Inherits esEntityCollection(Of Shippers)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ShippersMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ShippersCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ShippersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ShippersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ShippersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ShippersQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ShippersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ShippersQuery))
		End Sub
		
		#End Region
						
		Private m_query As ShippersQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esShippersQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ShippersMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "ShipperID" 
					Return Me.ShipperID
				Case "CompanyName" 
					Return Me.CompanyName
				Case "Phone" 
					Return Me.Phone
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property ShipperID As esQueryItem
			Get
				Return New esQueryItem(Me, ShippersMetadata.ColumnNames.ShipperID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property CompanyName As esQueryItem
			Get
				Return New esQueryItem(Me, ShippersMetadata.ColumnNames.CompanyName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Phone As esQueryItem
			Get
				Return New esQueryItem(Me, ShippersMetadata.ColumnNames.Phone, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Shippers 
		Inherits esShippers
		
	
		#Region "OrdersCollectionByShipVia - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrdersCollectionByShipVia() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Shippers.OrdersCollectionByShipVia_Delegate)
				map.PropertyName = "OrdersCollectionByShipVia"
				map.MyColumnName = "ShipVia"
				map.ParentColumnName = "ShipperID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrdersCollectionByShipVia_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New ShippersQuery(data.NextAlias())
			
			Dim mee As OrdersQuery = If(data.You IsNot Nothing, TryCast(data.You, OrdersQuery), New OrdersQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.ShipperID = mee.ShipVia)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Orders_Shippers
		''' </summary>

		<XmlIgnore()> _		
		<Include()> _ 
		<System.ComponentModel.DataAnnotations.Association("Shippers.OrdersCollectionByShipVia", "ShipperID", "ShipVia")> _ 
		Public Property OrdersCollectionByShipVia As OrdersCollection 
		
			Get
				If Me._OrdersCollectionByShipVia Is Nothing Then
					Me._OrdersCollectionByShipVia = New OrdersCollection()
					Me._OrdersCollectionByShipVia.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrdersCollectionByShipVia", Me._OrdersCollectionByShipVia)
				
					If Not Me.ShipperID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrdersCollectionByShipVia.Query.Where(Me._OrdersCollectionByShipVia.Query.ShipVia = Me.ShipperID)
							Me._OrdersCollectionByShipVia.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrdersCollectionByShipVia.fks.Add(OrdersMetadata.ColumnNames.ShipVia, Me.ShipperID)
					End If
				End If

				Return Me._OrdersCollectionByShipVia
			End Get
			
			Set(ByVal value As OrdersCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrdersCollectionByShipVia Is Nothing Then

					Me.RemovePostSave("OrdersCollectionByShipVia")
					Me._OrdersCollectionByShipVia = Nothing
					Me.OnPropertyChanged("OrdersCollectionByShipVia")

				End If
			End Set				
			
		End Property
		

		private _OrdersCollectionByShipVia As OrdersCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "OrdersCollectionByShipVia"
					coll = Me.OrdersCollectionByShipVia
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "OrdersCollectionByShipVia", GetType(OrdersCollection), New Orders()))
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
		
			If Not Me._OrdersCollectionByShipVia Is Nothing Then
				Apply(Me._OrdersCollectionByShipVia, "ShipVia", Me.ShipperID)
			End If
			
		End Sub
	End Class
		



	<Serializable> _
	Partial Public Class ShippersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ShippersMetadata.ColumnNames.ShipperID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ShippersMetadata.PropertyNames.ShipperID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ShippersMetadata.ColumnNames.CompanyName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = ShippersMetadata.PropertyNames.CompanyName
			c.CharacterMaxLength = 40
			m_columns.Add(c)
				
			c = New esColumnMetadata(ShippersMetadata.ColumnNames.Phone, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = ShippersMetadata.PropertyNames.Phone
			c.CharacterMaxLength = 24
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ShippersMetadata
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
			 Public Const ShipperID As String = "ShipperID"
			 Public Const CompanyName As String = "CompanyName"
			 Public Const Phone As String = "Phone"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const ShipperID As String = "ShipperID"
			 Public Const CompanyName As String = "CompanyName"
			 Public Const Phone As String = "Phone"
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
			SyncLock GetType(ShippersMetadata)
			
				If ShippersMetadata.mapDelegates Is Nothing Then
					ShippersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ShippersMetadata._meta Is Nothing Then
					ShippersMetadata._meta = New ShippersMetadata()
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
				


				meta.AddTypeMap("ShipperID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("CompanyName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"))			
				
				
				 
				meta.Source = "Shippers"
				meta.Destination = "Shippers"
				
				meta.spInsert = "proc_ShippersInsert"
				meta.spUpdate = "proc_ShippersUpdate"
				meta.spDelete = "proc_ShippersDelete"
				meta.spLoadAll = "proc_ShippersLoadAll"
				meta.spLoadByPrimaryKey = "proc_ShippersLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ShippersMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
