
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
	' Encapsulates the 'ReferredEmployee' table
	' </summary>
	
	Partial Public Class ReferredEmployee 
		Inherits esReferredEmployee
			
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New ReferredEmployee()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal employeeID As System.Int32, ByVal referredID As System.Int32)
			Dim obj As New ReferredEmployee()
			obj.EmployeeID = employeeID
			obj.ReferredID = referredID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal employeeID As System.Int32, ByVal referredID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New ReferredEmployee()
			obj.EmployeeID = employeeID
			obj.ReferredID = referredID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
	
		
			
	End Class



	Partial Public Class ReferredEmployeeCollection
		Inherits esReferredEmployeeCollection
		Implements IEnumerable(Of ReferredEmployee)
	
		Public Function FindByPrimaryKey(ByVal employeeID As System.Int32, ByVal referredID As System.Int32) As ReferredEmployee
			Return MyBase.SingleOrDefault(Function(e) e.EmployeeID.HasValue AndAlso e.EmployeeID.Value = employeeID And e.ReferredID.HasValue AndAlso e.ReferredID.Value = referredID)
		End Function


		
		
			
		
	End Class



 
	Partial Public Class ReferredEmployeeQuery 
		Inherits esReferredEmployeeQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ReferredEmployeeQuery"
		End Function	
	
			
	End Class


	MustInherit Public Partial Class esReferredEmployee
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal employeeID As System.Int32, ByVal referredID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(employeeID, referredID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(employeeID, referredID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal employeeID As System.Int32, ByVal referredID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(employeeID, referredID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(employeeID, referredID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal employeeID As System.Int32, ByVal referredID As System.Int32) As Boolean
		
			Dim query As New ReferredEmployeeQuery()
			query.Where(query.EmployeeID = employeeID And query.ReferredID = referredID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal employeeID As System.Int32, ByVal referredID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("EmployeeID", employeeID)
						parms.Add("ReferredID", referredID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to ReferredEmployee.EmployeeID
		' </summary>
		Public Overridable Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ReferredEmployeeMetadata.ColumnNames.EmployeeID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ReferredEmployeeMetadata.ColumnNames.EmployeeID, value) Then
					Me._UpToEmployeeByEmployeeID = Nothing
					Me.OnPropertyChanged("UpToEmployeeByEmployeeID")
					OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.EmployeeID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ReferredEmployee.ReferredID
		' </summary>
		Public Overridable Property ReferredID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ReferredEmployeeMetadata.ColumnNames.ReferredID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ReferredEmployeeMetadata.ColumnNames.ReferredID, value) Then
					Me._UpToEmployeeByReferredID = Nothing
					Me.OnPropertyChanged("UpToEmployeeByReferredID")
					OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.ReferredID)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeByReferredID As Employee
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeByEmployeeID As Employee
		
#End Region	

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ReferredEmployeeMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ReferredEmployeeQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ReferredEmployeeQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ReferredEmployeeQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ReferredEmployeeQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        
        Private m_query As ReferredEmployeeQuery

	End Class



	MustInherit Public Partial Class esReferredEmployeeCollection
		Inherits esEntityCollection(Of ReferredEmployee)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ReferredEmployeeMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ReferredEmployeeCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		Public ReadOnly Property Query() As ReferredEmployeeQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ReferredEmployeeQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ReferredEmployeeQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ReferredEmployeeQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ReferredEmployeeQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ReferredEmployeeQuery))
		End Sub
		
		#End Region
						
		Private m_query As ReferredEmployeeQuery
	End Class



	MustInherit Public Partial Class esReferredEmployeeQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ReferredEmployeeMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "EmployeeID" 
					Return Me.EmployeeID
				Case "ReferredID" 
					Return Me.ReferredID
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property EmployeeID As esQueryItem
			Get
				Return New esQueryItem(Me, ReferredEmployeeMetadata.ColumnNames.EmployeeID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ReferredID As esQueryItem
			Get
				Return New esQueryItem(Me, ReferredEmployeeMetadata.ColumnNames.ReferredID, esSystemType.Int32)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class ReferredEmployee 
		Inherits esReferredEmployee
		
	
		#Region "UpToEmployeeByReferredID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - EmployeeReferredEmployee
		''' </summary>
		
		Public Property UpToEmployeeByReferredID As Employee
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeeByReferredID Is Nothing _
						 AndAlso Not ReferredID.Equals(Nothing)  Then
						
					Me._UpToEmployeeByReferredID = New Employee()
					Me._UpToEmployeeByReferredID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeeByReferredID", Me._UpToEmployeeByReferredID)
					Me._UpToEmployeeByReferredID.Query.Where(Me._UpToEmployeeByReferredID.Query.EmployeeID = Me.ReferredID)
					Me._UpToEmployeeByReferredID.Query.Load()
				End If

				Return Me._UpToEmployeeByReferredID
			End Get
			
            Set(ByVal value As Employee)
				Me.RemovePreSave("UpToEmployeeByReferredID")
				
				Dim changed as Boolean = Me._UpToEmployeeByReferredID IsNot value

				If value Is Nothing Then
				
					Me.ReferredID = Nothing
				
					Me._UpToEmployeeByReferredID = Nothing
				Else
				
					Me.ReferredID = value.EmployeeID
					
					Me._UpToEmployeeByReferredID = value
					Me.SetPreSave("UpToEmployeeByReferredID", Me._UpToEmployeeByReferredID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeeByReferredID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToEmployeeByEmployeeID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - EmployeeReferredEmployee1
		''' </summary>
		
		Public Property UpToEmployeeByEmployeeID As Employee
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToEmployeeByEmployeeID Is Nothing _
						 AndAlso Not EmployeeID.Equals(Nothing)  Then
						
					Me._UpToEmployeeByEmployeeID = New Employee()
					Me._UpToEmployeeByEmployeeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToEmployeeByEmployeeID", Me._UpToEmployeeByEmployeeID)
					Me._UpToEmployeeByEmployeeID.Query.Where(Me._UpToEmployeeByEmployeeID.Query.EmployeeID = Me.EmployeeID)
					Me._UpToEmployeeByEmployeeID.Query.Load()
				End If

				Return Me._UpToEmployeeByEmployeeID
			End Get
			
            Set(ByVal value As Employee)
				Me.RemovePreSave("UpToEmployeeByEmployeeID")
				
				Dim changed as Boolean = Me._UpToEmployeeByEmployeeID IsNot value

				If value Is Nothing Then
				
					Me.EmployeeID = Nothing
				
					Me._UpToEmployeeByEmployeeID = Nothing
				Else
				
					Me.EmployeeID = value.EmployeeID
					
					Me._UpToEmployeeByEmployeeID = value
					Me.SetPreSave("UpToEmployeeByEmployeeID", Me._UpToEmployeeByEmployeeID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToEmployeeByEmployeeID")
				End If
			End Set	

		End Property
		#End Region

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByReferredID Is Nothing Then
				Me.ReferredID = Me._UpToEmployeeByReferredID.EmployeeID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByEmployeeID Is Nothing Then
				Me.EmployeeID = Me._UpToEmployeeByEmployeeID.EmployeeID
			End If
			
		End Sub
	End Class
		



	Partial Public Class ReferredEmployeeMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ReferredEmployeeMetadata.ColumnNames.EmployeeID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ReferredEmployeeMetadata.PropertyNames.EmployeeID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ReferredEmployeeMetadata.ColumnNames.ReferredID, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ReferredEmployeeMetadata.PropertyNames.ReferredID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ReferredEmployeeMetadata
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
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const ReferredID As String = "ReferredID"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const EmployeeID As String = "EmployeeID"
			 Public Const ReferredID As String = "ReferredID"
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
			SyncLock GetType(ReferredEmployeeMetadata)
			
				If ReferredEmployeeMetadata.mapDelegates Is Nothing Then
					ReferredEmployeeMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ReferredEmployeeMetadata._meta Is Nothing Then
					ReferredEmployeeMetadata._meta = New ReferredEmployeeMetadata()
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
				


				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ReferredID", new esTypeMap("int", "System.Int32"))			
				
				
				 
				meta.Source = "ReferredEmployee"
				meta.Destination = "ReferredEmployee"
				
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ReferredEmployeeMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
