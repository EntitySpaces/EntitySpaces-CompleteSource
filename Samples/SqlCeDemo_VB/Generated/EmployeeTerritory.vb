
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
	' Encapsulates the 'EmployeeTerritory' table
	' </summary>
	
	Partial Public Class EmployeeTerritory 
		Inherits esEmployeeTerritory
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New EmployeeTerritory()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal empID As System.Int32, ByVal terrID As System.Int32)
			Dim obj As New EmployeeTerritory()
			obj.EmpID = empID
			obj.TerrID = terrID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal empID As System.Int32, ByVal terrID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New EmployeeTerritory()
			obj.EmpID = empID
			obj.TerrID = terrID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class EmployeeTerritoryCollection
		Inherits esEmployeeTerritoryCollection
		Implements IEnumerable(Of EmployeeTerritory)
	
		Public Function FindByPrimaryKey(ByVal empID As System.Int32, ByVal terrID As System.Int32) As EmployeeTerritory
			Return MyBase.SingleOrDefault(Function(e) e.EmpID.HasValue AndAlso e.EmpID.Value = empID And e.TerrID.HasValue AndAlso e.TerrID.Value = terrID)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class EmployeeTerritoryQuery 
		Inherits esEmployeeTerritoryQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "EmployeeTerritoryQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esEmployeeTerritory
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal empID As System.Int32, ByVal terrID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(empID, terrID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(empID, terrID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal empID As System.Int32, ByVal terrID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(empID, terrID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(empID, terrID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal empID As System.Int32, ByVal terrID As System.Int32) As Boolean
		
			Dim query As New EmployeeTerritoryQuery()
			query.Where(query.EmpID = empID And query.TerrID = terrID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal empID As System.Int32, ByVal terrID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("EmpID", empID)
						parms.Add("TerrID", terrID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to EmployeeTerritory.EmpID
		' </summary>
		Public Overridable Property EmpID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.EmpID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.EmpID, value) Then
					Me._UpToEmployeeByEmpID = Nothing
					Me.OnPropertyChanged("UpToEmployeeByEmpID")
					OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.EmpID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to EmployeeTerritory.TerrID
		' </summary>
		Public Overridable Property TerrID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.TerrID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(EmployeeTerritoryMetadata.ColumnNames.TerrID, value) Then
					Me._UpToTerritoryByTerrID = Nothing
					Me.OnPropertyChanged("UpToTerritoryByTerrID")
					OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.TerrID)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeByEmpID As Employee
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToTerritoryByTerrID As Territory
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeeTerritoryMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As EmployeeTerritoryQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeeTerritoryQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As EmployeeTerritoryQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As EmployeeTerritoryQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As EmployeeTerritoryQuery

	End Class



	MustInherit Public Partial Class esEmployeeTerritoryCollection
		Inherits esEntityCollection(Of EmployeeTerritory)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return EmployeeTerritoryMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "EmployeeTerritoryCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As EmployeeTerritoryQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New EmployeeTerritoryQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As EmployeeTerritoryQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New EmployeeTerritoryQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As EmployeeTerritoryQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, EmployeeTerritoryQuery))
		End Sub
		
		#End Region
						
		Private m_query As EmployeeTerritoryQuery
	End Class



	MustInherit Public Partial Class esEmployeeTerritoryQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return EmployeeTerritoryMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "EmpID" 
					Return Me.EmpID
				Case "TerrID" 
					Return Me.TerrID
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property EmpID As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeTerritoryMetadata.ColumnNames.EmpID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property TerrID As esQueryItem
			Get
				Return New esQueryItem(Me, EmployeeTerritoryMetadata.ColumnNames.TerrID, esSystemType.Int32)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class EmployeeTerritory 
		Inherits esEmployeeTerritory
		
	
		#Region "UpToEmployeeByEmpID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - EmployeeEmployeeTerritory
		''' </summary>
		
		Public Property UpToEmployeeByEmpID As Employee
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeeByEmpID Is Nothing _
						 AndAlso Not EmpID.Equals(Nothing)  Then
						
					Me._UpToEmployeeByEmpID = New Employee()
					Me._UpToEmployeeByEmpID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeeByEmpID", Me._UpToEmployeeByEmpID)
					Me._UpToEmployeeByEmpID.Query.Where(Me._UpToEmployeeByEmpID.Query.EmployeeID = Me.EmpID)
					Me._UpToEmployeeByEmpID.Query.Load()
				End If

				Return Me._UpToEmployeeByEmpID
			End Get
			
            Set(ByVal value As Employee)
				Me.RemovePreSave("UpToEmployeeByEmpID")
				
				Dim changed as Boolean = Me._UpToEmployeeByEmpID IsNot value

				If value Is Nothing Then
				
					Me.EmpID = Nothing
				
					Me._UpToEmployeeByEmpID = Nothing
				Else
				
					Me.EmpID = value.EmployeeID
					
					Me._UpToEmployeeByEmpID = value
					Me.SetPreSave("UpToEmployeeByEmpID", Me._UpToEmployeeByEmpID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeeByEmpID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToTerritoryByTerrID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - TerritoryEmployeeTerritory
		''' </summary>
		
		Public Property UpToTerritoryByTerrID As Territory
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToTerritoryByTerrID Is Nothing _
						 AndAlso Not TerrID.Equals(Nothing)  Then
						
					Me._UpToTerritoryByTerrID = New Territory()
					Me._UpToTerritoryByTerrID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToTerritoryByTerrID", Me._UpToTerritoryByTerrID)
					Me._UpToTerritoryByTerrID.Query.Where(Me._UpToTerritoryByTerrID.Query.TerritoryID = Me.TerrID)
					Me._UpToTerritoryByTerrID.Query.Load()
				End If

				Return Me._UpToTerritoryByTerrID
			End Get
			
            Set(ByVal value As Territory)
				Me.RemovePreSave("UpToTerritoryByTerrID")
				
				Dim changed as Boolean = Me._UpToTerritoryByTerrID IsNot value

				If value Is Nothing Then
				
					Me.TerrID = Nothing
				
					Me._UpToTerritoryByTerrID = Nothing
				Else
				
					Me.TerrID = value.TerritoryID
					
					Me._UpToTerritoryByTerrID = value
					Me.SetPreSave("UpToTerritoryByTerrID", Me._UpToTerritoryByTerrID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToTerritoryByTerrID")
				End If
			End Set	

		End Property
		#End Region

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByEmpID Is Nothing Then
				Me.EmpID = Me._UpToEmployeeByEmpID.EmployeeID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToTerritoryByTerrID Is Nothing Then
				Me.TerrID = Me._UpToTerritoryByTerrID.TerritoryID
			End If
			
		End Sub
	End Class
		



	Partial Public Class EmployeeTerritoryMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(EmployeeTerritoryMetadata.ColumnNames.EmpID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeeTerritoryMetadata.PropertyNames.EmpID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(EmployeeTerritoryMetadata.ColumnNames.TerrID, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = EmployeeTerritoryMetadata.PropertyNames.TerrID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As EmployeeTerritoryMetadata
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
			 Public Const EmpID As String = "EmpID"
			 Public Const TerrID As String = "TerrID"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const EmpID As String = "EmpID"
			 Public Const TerrID As String = "TerrID"
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
			SyncLock GetType(EmployeeTerritoryMetadata)
			
				If EmployeeTerritoryMetadata.mapDelegates Is Nothing Then
					EmployeeTerritoryMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If EmployeeTerritoryMetadata._meta Is Nothing Then
					EmployeeTerritoryMetadata._meta = New EmployeeTerritoryMetadata()
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
				


				meta.AddTypeMap("EmpID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("TerrID", new esTypeMap("int", "System.Int32"))			
				
				
				 
				meta.Source = "EmployeeTerritory"
				meta.Destination = "EmployeeTerritory"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As EmployeeTerritoryMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
