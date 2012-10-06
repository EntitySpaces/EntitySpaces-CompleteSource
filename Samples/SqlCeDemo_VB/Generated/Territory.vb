
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
	' Encapsulates the 'Territory' table
	' </summary>
	
	Partial Public Class Territory 
		Inherits esTerritory
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Territory()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal territoryID As System.Int32)
			Dim obj As New Territory()
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal territoryID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Territory()
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class TerritoryCollection
		Inherits esTerritoryCollection
		Implements IEnumerable(Of Territory)
	
		Public Function FindByPrimaryKey(ByVal territoryID As System.Int32) As Territory
			Return MyBase.SingleOrDefault(Function(e) e.TerritoryID.HasValue AndAlso e.TerritoryID.Value = territoryID)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class TerritoryQuery 
		Inherits esTerritoryQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "TerritoryQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esTerritory
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
		
			Dim query As New TerritoryQuery()
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
		' Maps to Territory.TerritoryID
		' </summary>
		Public Overridable Property TerritoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(TerritoryMetadata.ColumnNames.TerritoryID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(TerritoryMetadata.ColumnNames.TerritoryID, value) Then
					OnPropertyChanged(TerritoryMetadata.PropertyNames.TerritoryID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Territory.Description
		' </summary>
		Public Overridable Property Description As System.String
			Get
				Return MyBase.GetSystemString(TerritoryMetadata.ColumnNames.Description)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(TerritoryMetadata.ColumnNames.Description, value) Then
					OnPropertyChanged(TerritoryMetadata.PropertyNames.Description)
				End If
			End Set
		End Property	
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return TerritoryMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As TerritoryQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New TerritoryQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As TerritoryQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As TerritoryQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As TerritoryQuery

	End Class



	MustInherit Public Partial Class esTerritoryCollection
		Inherits esEntityCollection(Of Territory)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return TerritoryMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "TerritoryCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As TerritoryQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New TerritoryQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As TerritoryQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New TerritoryQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As TerritoryQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, TerritoryQuery))
		End Sub
		
		#End Region
						
		Private m_query As TerritoryQuery
	End Class



	MustInherit Public Partial Class esTerritoryQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return TerritoryMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "TerritoryID" 
					Return Me.TerritoryID
				Case "Description" 
					Return Me.Description
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property TerritoryID As esQueryItem
			Get
				Return New esQueryItem(Me, TerritoryMetadata.ColumnNames.TerritoryID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Description As esQueryItem
			Get
				Return New esQueryItem(Me, TerritoryMetadata.ColumnNames.Description, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Territory 
		Inherits esTerritory
		
	
		#Region "UpToEmployeeCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - TerritoryEmployeeTerritory
		''' </summary>

		Public Property UpToEmployeeCollection As EmployeeCollection
		
			Get
				If Me._UpToEmployeeCollection Is Nothing Then
					Me._UpToEmployeeCollection = New EmployeeCollection()
					Me._UpToEmployeeCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToEmployeeCollection", Me._UpToEmployeeCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.TerritoryID.Equals(Nothing) Then 
				
						Dim m As New EmployeeQuery("m")
						Dim j As New EmployeeTerritoryQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.EmployeeID = j.EmpID)
                        m.Where(j.TerrID = Me.TerritoryID)

						Me._UpToEmployeeCollection.Load(m)

					End If
				End If

				Return Me._UpToEmployeeCollection
			End Get
			
			Set(ByVal value As EmployeeCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToEmployeeCollection Is Nothing Then

					Me.RemovePostSave("UpToEmployeeCollection")
					Me._UpToEmployeeCollection = Nothing
					Me.OnPropertyChanged("UpToEmployeeCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - TerritoryEmployeeTerritory
		''' </summary>
		Public Sub AssociateEmployeeCollection(entity As Employee)
			If Me._EmployeeTerritoryCollection Is Nothing Then
				Me._EmployeeTerritoryCollection = New EmployeeTerritoryCollection()
				Me._EmployeeTerritoryCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("EmployeeTerritoryCollection", Me._EmployeeTerritoryCollection)
			End If
			
			Dim obj As EmployeeTerritory = Me._EmployeeTerritoryCollection.AddNew()
			obj.TerrID = Me.TerritoryID
			obj.EmpID = entity.EmployeeID			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - TerritoryEmployeeTerritory
		''' </summary>
		Public Sub DissociateEmployeeCollection(entity As Employee)
			If Me._EmployeeTerritoryCollection Is Nothing Then
				Me._EmployeeTerritoryCollection = new EmployeeTerritoryCollection()
				Me._EmployeeTerritoryCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("EmployeeTerritoryCollection", Me._EmployeeTerritoryCollection)
			End If

			Dim obj As EmployeeTerritory = Me._EmployeeTerritoryCollection.AddNew()
			obj.TerrID = Me.TerritoryID
            obj.EmpID = entity.EmployeeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToEmployeeCollection As EmployeeCollection
		Private _EmployeeTerritoryCollection As EmployeeTerritoryCollection
		#End Region

		#Region "EmployeeTerritoryCollectionByTerrID - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_EmployeeTerritoryCollectionByTerrID() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Territory.EmployeeTerritoryCollectionByTerrID_Delegate)
				map.PropertyName = "EmployeeTerritoryCollectionByTerrID"
				map.MyColumnName = "TerrID"
				map.ParentColumnName = "TerritoryID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub EmployeeTerritoryCollectionByTerrID_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New TerritoryQuery(data.NextAlias())
			
			Dim mee As EmployeeTerritoryQuery = If(data.You IsNot Nothing, TryCast(data.You, EmployeeTerritoryQuery), New EmployeeTerritoryQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.TerritoryID = mee.TerrID)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - TerritoryEmployeeTerritory
		''' </summary>
 
		Public Property EmployeeTerritoryCollectionByTerrID As EmployeeTerritoryCollection 
		
			Get
				If Me._EmployeeTerritoryCollectionByTerrID Is Nothing Then
					Me._EmployeeTerritoryCollectionByTerrID = New EmployeeTerritoryCollection()
					Me._EmployeeTerritoryCollectionByTerrID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("EmployeeTerritoryCollectionByTerrID", Me._EmployeeTerritoryCollectionByTerrID)
				
					If Not Me.TerritoryID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._EmployeeTerritoryCollectionByTerrID.Query.Where(Me._EmployeeTerritoryCollectionByTerrID.Query.TerrID = Me.TerritoryID)
							Me._EmployeeTerritoryCollectionByTerrID.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._EmployeeTerritoryCollectionByTerrID.fks.Add(EmployeeTerritoryMetadata.ColumnNames.TerrID, Me.TerritoryID)
					End If
				End If

				Return Me._EmployeeTerritoryCollectionByTerrID
			End Get
			
			Set(ByVal value As EmployeeTerritoryCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._EmployeeTerritoryCollectionByTerrID Is Nothing Then

					Me.RemovePostSave("EmployeeTerritoryCollectionByTerrID")
					Me._EmployeeTerritoryCollectionByTerrID = Nothing
					Me.OnPropertyChanged("EmployeeTerritoryCollectionByTerrID")

				End If
			End Set				
			
		End Property
		

		private _EmployeeTerritoryCollectionByTerrID As EmployeeTerritoryCollection
		#End Region

				
		#Region "TerritoryEx - One To One"
		''' <summary>
		''' One to One
		''' Foreign Key Name - TerritoryTerritoryEx
		''' </summary>

		Public Property TerritoryEx As TerritoryEx
		
			Get
				If Me._TerritoryEx Is Nothing Then
					Me._TerritoryEx = New TerritoryEx()
					Me._TerritoryEx.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostOneSave("TerritoryEx", Me._TerritoryEx)
				
					If Not Me.TerritoryID.Equals(Nothing) Then
						Me._TerritoryEx.Query.Where(Me._TerritoryEx.Query.TerritoryID = Me.TerritoryID)
						Me._TerritoryEx.Query.Load()
					End If
				End If

				Return Me._TerritoryEx
			End Get
			
			Set(ByVal value As TerritoryEx)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._TerritoryEx Is Nothing Then

					Me.RemovePostOneSave("TerritoryEx")
					Me._TerritoryEx = Nothing
					Me.OnPropertyChanged("TerritoryEx")

				End If
			End Set			
			
		End Property
				

		Private _TerritoryEx As TerritoryEx
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "EmployeeTerritoryCollectionByTerrID"
					coll = Me.EmployeeTerritoryCollectionByTerrID
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "EmployeeTerritoryCollectionByTerrID", GetType(EmployeeTerritoryCollection), New EmployeeTerritory()))
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
		
			If Not Me._EmployeeTerritoryCollection Is Nothing Then
				Apply(Me._EmployeeTerritoryCollection, "TerrID", Me.TerritoryID)
			End If
			
			If Not Me._EmployeeTerritoryCollectionByTerrID Is Nothing Then
				Apply(Me._EmployeeTerritoryCollectionByTerrID, "TerrID", Me.TerritoryID)
			End If
			
		End Sub
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PostOneSave.
		''' </summary>
		Protected Overrides Sub ApplyPostOneSaveKeys()
		
			If Not Me._TerritoryEx Is Nothing Then
			
				If Me._TerritoryEx.es.IsAdded Then
					Me._TerritoryEx.TerritoryID = Me.TerritoryID
				End If
			End If
			
		End Sub
	End Class
		



	Partial Public Class TerritoryMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(TerritoryMetadata.ColumnNames.TerritoryID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = TerritoryMetadata.PropertyNames.TerritoryID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(TerritoryMetadata.ColumnNames.Description, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = TerritoryMetadata.PropertyNames.Description
			c.CharacterMaxLength = 25
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As TerritoryMetadata
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
			 Public Const Description As String = "Description"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const TerritoryID As String = "TerritoryID"
			 Public Const Description As String = "Description"
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
			SyncLock GetType(TerritoryMetadata)
			
				If TerritoryMetadata.mapDelegates Is Nothing Then
					TerritoryMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If TerritoryMetadata._meta Is Nothing Then
					TerritoryMetadata._meta = New TerritoryMetadata()
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
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"))			
				
				
				 
				meta.Source = "Territory"
				meta.Destination = "Territory"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As TerritoryMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
