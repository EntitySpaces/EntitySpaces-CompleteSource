
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
	' Encapsulates the 'TerritoryEx' table
	' </summary>
	
	Partial Public Class TerritoryEx 
		Inherits esTerritoryEx
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New TerritoryEx()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal territoryID As System.Int32)
			Dim obj As New TerritoryEx()
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal territoryID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New TerritoryEx()
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class TerritoryExCollection
		Inherits esTerritoryExCollection
		Implements IEnumerable(Of TerritoryEx)
	
		Public Function FindByPrimaryKey(ByVal territoryID As System.Int32) As TerritoryEx
			Return MyBase.SingleOrDefault(Function(e) e.TerritoryID.HasValue AndAlso e.TerritoryID.Value = territoryID)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class TerritoryExQuery 
		Inherits esTerritoryExQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "TerritoryExQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esTerritoryEx
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal territoryID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(territoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(territoryID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal territoryID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(territoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(territoryID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal territoryID As System.Int32) As Boolean
		
			Dim query As New TerritoryExQuery()
			query.Where(query.TerritoryID = territoryID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal territoryID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("TerritoryID", territoryID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to TerritoryEx.TerritoryID
		' </summary>
		Public Overridable Property TerritoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID, value) Then
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.TerritoryID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to TerritoryEx.Notes
		' </summary>
		Public Overridable Property Notes As System.String
			Get
				Return MyBase.GetSystemString(TerritoryExMetadata.ColumnNames.Notes)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(TerritoryExMetadata.ColumnNames.Notes, value) Then
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.Notes)
				End If
			End Set
		End Property	
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return TerritoryExMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As TerritoryExQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New TerritoryExQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As TerritoryExQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As TerritoryExQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As TerritoryExQuery

	End Class



	MustInherit Public Partial Class esTerritoryExCollection
		Inherits esEntityCollection(Of TerritoryEx)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return TerritoryExMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "TerritoryExCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As TerritoryExQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New TerritoryExQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As TerritoryExQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New TerritoryExQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As TerritoryExQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, TerritoryExQuery))
		End Sub
		
		#End Region
						
		Private m_query As TerritoryExQuery
	End Class



	MustInherit Public Partial Class esTerritoryExQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return TerritoryExMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "TerritoryID" 
					Return Me.TerritoryID
				Case "Notes" 
					Return Me.Notes
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property TerritoryID As esQueryItem
			Get
				Return New esQueryItem(Me, TerritoryExMetadata.ColumnNames.TerritoryID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Notes As esQueryItem
			Get
				Return New esQueryItem(Me, TerritoryExMetadata.ColumnNames.Notes, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class TerritoryEx 
		Inherits esTerritoryEx
		
	
		#Region "UpToTerritory - One To One"
		''' <summary>
		''' One to One
		''' Foreign Key Name - TerritoryTerritoryEx
		''' </summary>

		Public Property UpToTerritory As Territory
		
			Get
				If Me._UpToTerritory Is Nothing 	AndAlso Not TerritoryID.Equals(Nothing) Then
					Me._UpToTerritory = New Territory()
					Me._UpToTerritory.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToTerritory", Me._UpToTerritory)
					Me._UpToTerritory.Query.Where(Me._UpToTerritory.Query.TerritoryID = Me.TerritoryID)
					Me._UpToTerritory.Query.Load()
				End If

				Return Me._UpToTerritory
			End Get
			
            Set(ByVal value As Territory)
				Me.RemovePreSave("UpToTerritory")

				If value Is Nothing Then
					Me._UpToTerritory = Nothing
				Else 
					Me._UpToTerritory = value
					Me.SetPreSave("UpToTerritory", Me._UpToTerritory)
				End If
				
				Me.OnPropertyChanged("UpToTerritory")
			End Set	
			
		End Property
				

		Private _UpToTerritory As Territory
		#End Region

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToTerritory Is Nothing Then
				Me.TerritoryID = Me._UpToTerritory.TerritoryID
			End If
			
		End Sub
	End Class
		



	Partial Public Class TerritoryExMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(TerritoryExMetadata.ColumnNames.TerritoryID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = TerritoryExMetadata.PropertyNames.TerritoryID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(TerritoryExMetadata.ColumnNames.Notes, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = TerritoryExMetadata.PropertyNames.Notes
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As TerritoryExMetadata
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
			 Public Const TerritoryID As String = "TerritoryID"
			 Public Const Notes As String = "Notes"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const TerritoryID As String = "TerritoryID"
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
			SyncLock GetType(TerritoryExMetadata)
			
				If TerritoryExMetadata.mapDelegates Is Nothing Then
					TerritoryExMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If TerritoryExMetadata._meta Is Nothing Then
					TerritoryExMetadata._meta = New TerritoryExMetadata()
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
				


				meta.AddTypeMap("TerritoryID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("Notes", new esTypeMap("nvarchar", "System.String"))			
				
				
				 
				meta.Source = "TerritoryEx"
				meta.Destination = "TerritoryEx"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As TerritoryExMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
