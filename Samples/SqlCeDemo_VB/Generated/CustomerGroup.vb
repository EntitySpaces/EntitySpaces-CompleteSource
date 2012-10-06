
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
	' Encapsulates the 'CustomerGroup' table
	' </summary>
	
	Partial Public Class CustomerGroup 
		Inherits esCustomerGroup
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New CustomerGroup()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal groupID As System.String)
			Dim obj As New CustomerGroup()
			obj.GroupID = groupID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal groupID As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New CustomerGroup()
			obj.GroupID = groupID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class CustomerGroupCollection
		Inherits esCustomerGroupCollection
		Implements IEnumerable(Of CustomerGroup)
	
		Public Function FindByPrimaryKey(ByVal groupID As System.String) As CustomerGroup
			Return MyBase.SingleOrDefault(Function(e) e.GroupID = groupID)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class CustomerGroupQuery 
		Inherits esCustomerGroupQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CustomerGroupQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esCustomerGroup
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal groupID As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(groupID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(groupID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal groupID As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(groupID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(groupID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal groupID As System.String) As Boolean
		
			Dim query As New CustomerGroupQuery()
			query.Where(query.GroupID = groupID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal groupID As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("GroupID", groupID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to CustomerGroup.GroupID
		' </summary>
		Public Overridable Property GroupID As System.String
			Get
				Return MyBase.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupID, value) Then
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to CustomerGroup.GroupName
		' </summary>
		Public Overridable Property GroupName As System.String
			Get
				Return MyBase.GetSystemString(CustomerGroupMetadata.ColumnNames.GroupName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerGroupMetadata.ColumnNames.GroupName, value) Then
					OnPropertyChanged(CustomerGroupMetadata.PropertyNames.GroupName)
				End If
			End Set
		End Property	
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerGroupMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CustomerGroupQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerGroupQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CustomerGroupQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CustomerGroupQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As CustomerGroupQuery

	End Class



	MustInherit Public Partial Class esCustomerGroupCollection
		Inherits esEntityCollection(Of CustomerGroup)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerGroupMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CustomerGroupCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As CustomerGroupQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerGroupQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CustomerGroupQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CustomerGroupQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CustomerGroupQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CustomerGroupQuery))
		End Sub
		
		#End Region
						
		Private m_query As CustomerGroupQuery
	End Class



	MustInherit Public Partial Class esCustomerGroupQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CustomerGroupMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "GroupID" 
					Return Me.GroupID
				Case "GroupName" 
					Return Me.GroupName
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property GroupID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerGroupMetadata.ColumnNames.GroupID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property GroupName As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerGroupMetadata.ColumnNames.GroupName, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class CustomerGroup 
		Inherits esCustomerGroup
		
	
		#Region "CustomerCollectionByCustomerID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_CustomerCollectionByCustomerID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.CustomerGroup.CustomerCollectionByCustomerID_Delegate)
				map.PropertyName = "CustomerCollectionByCustomerID"
				map.MyColumnName = "CustomerID"
				map.ParentColumnName = "GroupID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub CustomerCollectionByCustomerID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New CustomerGroupQuery(data.NextAlias())
			
			Dim mee As CustomerQuery = If(data.You IsNot Nothing, TryCast(data.You, CustomerQuery), New CustomerQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.GroupID = mee.CustomerID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - CustomerGroupCustomer
		''' </summary>
 
		Public Property CustomerCollectionByCustomerID As CustomerCollection 
		
			Get
				If Me._CustomerCollectionByCustomerID Is Nothing Then
					Me._CustomerCollectionByCustomerID = New CustomerCollection()
					Me._CustomerCollectionByCustomerID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("CustomerCollectionByCustomerID", Me._CustomerCollectionByCustomerID)
				
					If Not Me.GroupID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._CustomerCollectionByCustomerID.Query.Where(Me._CustomerCollectionByCustomerID.Query.CustomerID = Me.GroupID)
							Me._CustomerCollectionByCustomerID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._CustomerCollectionByCustomerID.fks.Add(CustomerMetadata.ColumnNames.CustomerID, Me.GroupID)
					End If
				End If

				Return Me._CustomerCollectionByCustomerID
			End Get
			
			Set(ByVal value As CustomerCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._CustomerCollectionByCustomerID Is Nothing Then

					Me.RemovePostSave("CustomerCollectionByCustomerID")
					Me._CustomerCollectionByCustomerID = Nothing
					Me.OnPropertyChanged("CustomerCollectionByCustomerID")

				End If
			End Set				
			
		End Property
		

		private _CustomerCollectionByCustomerID As CustomerCollection
		#End Region

				
		#Region "Group - One To One"
		''' <summary>
		''' One to One
		''' Foreign Key Name - CustomerGroupGroup
		''' </summary>

		Public Property Group As Group
		
			Get
				If Me._Group Is Nothing Then
					Me._Group = New Group()
					Me._Group.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostOneSave("Group", Me._Group)
				
					If Not Me.GroupID.Equals(Nothing) Then
						Me._Group.Query.Where(Me._Group.Query.Id = Me.GroupID)
						Me._Group.Query.Load()
					End If
				End If

				Return Me._Group
			End Get
			
			Set(ByVal value As Group)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._Group Is Nothing Then

					Me.RemovePostOneSave("Group")
					Me._Group = Nothing
					Me.OnPropertyChanged("Group")

				End If
			End Set			
			
		End Property
				

		Private _Group As Group
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "CustomerCollectionByCustomerID"
					coll = Me.CustomerCollectionByCustomerID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "CustomerCollectionByCustomerID", GetType(CustomerCollection), New Customer()))
			Return props
			
		End Function
	End Class
		



	Partial Public Class CustomerGroupMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupID, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerGroupMetadata.ColumnNames.GroupName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerGroupMetadata.PropertyNames.GroupName
			c.CharacterMaxLength = 25
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As CustomerGroupMetadata
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
			 Public Const GroupID As String = "GroupID"
			 Public Const GroupName As String = "GroupName"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const GroupID As String = "GroupID"
			 Public Const GroupName As String = "GroupName"
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
			SyncLock GetType(CustomerGroupMetadata)
			
				If CustomerGroupMetadata.mapDelegates Is Nothing Then
					CustomerGroupMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CustomerGroupMetadata._meta Is Nothing Then
					CustomerGroupMetadata._meta = New CustomerGroupMetadata()
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
				


				meta.AddTypeMap("GroupID", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("GroupName", new esTypeMap("nvarchar", "System.String"))			
				
				
				 
				meta.Source = "CustomerGroup"
				meta.Destination = "CustomerGroup"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CustomerGroupMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
