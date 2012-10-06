
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
	' Encapsulates the 'Group' table
	' </summary>
	
	Partial Public Class Group 
		Inherits esGroup
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Group()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.String)
			Dim obj As New Group()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Group()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class GroupCollection
		Inherits esGroupCollection
		Implements IEnumerable(Of Group)
	
		Public Function FindByPrimaryKey(ByVal id As System.String) As Group
			Return MyBase.SingleOrDefault(Function(e) e.Id = id)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class GroupQuery 
		Inherits esGroupQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "GroupQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esGroup
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal id As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal id As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal id As System.String) As Boolean
		
			Dim query As New GroupQuery()
			query.Where(query.Id = id)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal id As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("Id", id)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Group.ID
		' </summary>
		Public Overridable Property Id As System.String
			Get
				Return MyBase.GetSystemString(GroupMetadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(GroupMetadata.ColumnNames.Id, value) Then
					OnPropertyChanged(GroupMetadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Group.Notes
		' </summary>
		Public Overridable Property Notes As System.String
			Get
				Return MyBase.GetSystemString(GroupMetadata.ColumnNames.Notes)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(GroupMetadata.ColumnNames.Notes, value) Then
					OnPropertyChanged(GroupMetadata.PropertyNames.Notes)
				End If
			End Set
		End Property	
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return GroupMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As GroupQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New GroupQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As GroupQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As GroupQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As GroupQuery

	End Class



	MustInherit Public Partial Class esGroupCollection
		Inherits esEntityCollection(Of Group)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return GroupMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "GroupCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As GroupQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New GroupQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As GroupQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New GroupQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As GroupQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, GroupQuery))
		End Sub
		
		#End Region
						
		Private m_query As GroupQuery
	End Class



	MustInherit Public Partial Class esGroupQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return GroupMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "Notes" 
					Return Me.Notes
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, GroupMetadata.ColumnNames.Id, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Notes As esQueryItem
			Get
				Return New esQueryItem(Me, GroupMetadata.ColumnNames.Notes, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Group 
		Inherits esGroup
		
	
		#Region "UpToCustomerGroup - One To One"
		''' <summary>
		''' One to One
		''' Foreign Key Name - CustomerGroupGroup
		''' </summary>

		Public Property UpToCustomerGroup As CustomerGroup
		
			Get
				If Me._UpToCustomerGroup Is Nothing 	AndAlso Not Id.Equals(Nothing) Then
					Me._UpToCustomerGroup = New CustomerGroup()
					Me._UpToCustomerGroup.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCustomerGroup", Me._UpToCustomerGroup)
					Me._UpToCustomerGroup.Query.Where(Me._UpToCustomerGroup.Query.GroupID = Me.Id)
					Me._UpToCustomerGroup.Query.Load()
				End If

				Return Me._UpToCustomerGroup
			End Get
			
            Set(ByVal value As CustomerGroup)
				Me.RemovePreSave("UpToCustomerGroup")

				If value Is Nothing Then
					Me._UpToCustomerGroup = Nothing
				Else 
					Me._UpToCustomerGroup = value
					Me.SetPreSave("UpToCustomerGroup", Me._UpToCustomerGroup)
				End If
				
				Me.OnPropertyChanged("UpToCustomerGroup")
			End Set	
			
		End Property
				

		Private _UpToCustomerGroup As CustomerGroup
		#End Region

		
		
	End Class
		



	Partial Public Class GroupMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(GroupMetadata.ColumnNames.Id, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = GroupMetadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(GroupMetadata.ColumnNames.Notes, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = GroupMetadata.PropertyNames.Notes
			c.CharacterMaxLength = 536870911
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As GroupMetadata
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
			 Public Const Id As String = "ID"
			 Public Const Notes As String = "Notes"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const Notes As String = "Notes"
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
			SyncLock GetType(GroupMetadata)
			
				If GroupMetadata.mapDelegates Is Nothing Then
					GroupMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If GroupMetadata._meta Is Nothing Then
					GroupMetadata._meta = New GroupMetadata()
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
				


				meta.AddTypeMap("Id", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Notes", new esTypeMap("ntext", "System.String"))			
				
				
				 
				meta.Source = "Group"
				meta.Destination = "Group"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As GroupMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
