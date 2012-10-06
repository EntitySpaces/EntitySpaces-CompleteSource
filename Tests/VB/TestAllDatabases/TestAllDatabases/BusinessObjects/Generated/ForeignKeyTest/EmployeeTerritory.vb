
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : SQL
' Date Generated       : 3/17/2012 4:51:52 AM
'===============================================================================

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

Imports EntitySpaces.Core
Imports EntitySpaces.Interfaces
Imports EntitySpaces.DynamicQuery



Namespace BusinessObjects

	' <summary>
	' Encapsulates the 'EmployeeTerritory' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(EmployeeTerritory))> _
	<XmlType("EmployeeTerritory")> _ 
	<Table(Name:="EmployeeTerritory")> _	
	Partial Public Class EmployeeTerritory 
		Inherits esEmployeeTerritory
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
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
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As EmployeeTerritory) As EmployeeTerritoryProxyStub
			Return New EmployeeTerritoryProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property EmpID As Nullable(Of System.Int32)
			Get
				Return MyBase.EmpID
			End Get
			Set
				MyBase.EmpID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property TerrID As Nullable(Of System.Int32)
			Get
				Return MyBase.TerrID
			End Get
			Set
				MyBase.TerrID = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("EmployeeTerritoryCollection")> _
	Partial Public Class EmployeeTerritoryCollection
		Inherits esEmployeeTerritoryCollection
		Implements IEnumerable(Of EmployeeTerritory)
	
		Public Function FindByPrimaryKey(ByVal empID As System.Int32, ByVal terrID As System.Int32) As EmployeeTerritory
			Return MyBase.SingleOrDefault(Function(e) e.EmpID.HasValue AndAlso e.EmpID.Value = empID And e.TerrID.HasValue AndAlso e.TerrID.Value = terrID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As EmployeeTerritoryCollection) As EmployeeTerritoryCollectionProxyStub
            Return New EmployeeTerritoryCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(EmployeeTerritory))> _
		Public Class EmployeeTerritoryCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of EmployeeTerritoryCollection)
			
			Public Shared Widening Operator CType(packet As EmployeeTerritoryCollectionWCFPacket) As EmployeeTerritoryCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As EmployeeTerritoryCollection) As EmployeeTerritoryCollectionWCFPacket
				Return New EmployeeTerritoryCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "EmployeeTerritoryQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class EmployeeTerritoryQuery 
		Inherits esEmployeeTerritoryQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "EmployeeTerritoryQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As EmployeeTerritoryQuery) As String
			Return EmployeeTerritoryQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As EmployeeTerritoryQuery
			Return DirectCast(EmployeeTerritoryQuery.SerializeHelper.FromXml(query, GetType(EmployeeTerritoryQuery)), EmployeeTerritoryQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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

#Region ".str() Properties"

		Public Overrides Sub SetProperties(values as IDictionary)

		Dim propertyName As String
			For Each propertyName In values.Keys
				Me.SetProperty(propertyName, values(propertyName))
			Next

		End Sub

		Public Overrides Sub SetProperty(name as string, value as object)

			Dim col As esColumnMetadata = Me.Meta.Columns.FindByPropertyName(name)
			If Not col Is Nothing Then

				If value Is Nothing OrElse value.GetType().ToString() = "System.String" Then

					' Use the strongly typed property
					Select Case name
												
						Case "EmpID"
							Me.str().EmpID = CType(value, string)
												
						Case "TerrID"
							Me.str().TerrID = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "EmpID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.EmpID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.EmpID)
							End If
						
						Case "TerrID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.TerrID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(EmployeeTerritoryMetadata.PropertyNames.TerrID)
							End If
						
					
						Case Else
						
					End Select
				End If

			Else If Me.ContainsColumn(name) Then
				Me.SetColumn(name, value)
			Else
				throw New Exception("SetProperty Error: '" + name + "' not found")
			End If	

		End Sub

		Public Function str() As esStrings
		
			If _esstrings Is Nothing Then
				_esstrings = New esStrings(Me)
			End If
			Return _esstrings
			
		End Function

		NotInheritable Public Class esStrings
		
			Public Sub New(ByVal entity As esEmployeeTerritory)
				Me.entity = entity
			End Sub				
		
	
			Public Property EmpID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.EmpID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.EmpID = Nothing
					Else
						entity.EmpID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property TerrID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.TerrID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TerrID = Nothing
					Else
						entity.TerrID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  

			Private entity As esEmployeeTerritory
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
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

        <IgnoreDataMember> _
        Private m_query As EmployeeTerritoryQuery

	End Class



	<Serializable()> _
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
		

		<BrowsableAttribute(False)> _ 
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



	<Serializable> _
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
		''' Foreign Key Name - FK_EmployeeTerritory_Employee
		''' </summary>

		<XmlIgnore()> _		
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
		''' Foreign Key Name - FK_EmployeeTerritory_Territory
		''' </summary>

		<XmlIgnore()> _		
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
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="EmployeeTerritory")> _
    <XmlType(TypeName:="EmployeeTerritoryProxyStub")> _
    <Serializable> _
    Partial Public Class EmployeeTerritoryProxyStub
	
		Public Sub New()
            Me._entity = New EmployeeTerritory()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As EmployeeTerritory)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As EmployeeTerritory, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As EmployeeTerritoryProxyStub) As EmployeeTerritory
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(EmployeeTerritory)
        End Function
		

		<DataMember(Name:="EmpID", Order:=1, EmitDefaultValue:=False)> _		
        Public Property EmpID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(EmployeeTerritoryMetadata.ColumnNames.EmpID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.EmpID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.EmpID = value
			End Set
			
		End Property

		<DataMember(Name:="TerrID", Order:=2, EmitDefaultValue:=False)> _		
        Public Property TerrID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(EmployeeTerritoryMetadata.ColumnNames.TerrID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.TerrID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.TerrID = value
			End Set
			
		End Property


		<DataMember(Name := "esRowState", Order := 10000)> _
        Public Property esRowState As String
            Get
				Return Me.TheRowState
            End Get

            Set 
				Me.TheRowState = value
            End Set
        End Property
		
		<DataMember(Name := "ModifiedColumns", Order := 10001, EmitDefaultValue := False)> _
		Private Property ModifiedColumns() As List(Of String)
			Get
				Return Entity.es.ModifiedColumns
			End Get
			Set(ByVal value As List(Of String))
				Entity.es.ModifiedColumns.AddRange(value)
			End Set
		End Property		
		
		<DataMember(Name := "ExtraColumns", Order := 10002, EmitDefaultValue := False)> _
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
        Public Property Entity As EmployeeTerritory
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New EmployeeTerritory()
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
        Public _entity As EmployeeTerritory
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="EmployeeTerritoryCollection")> _
    <XmlType(TypeName:="EmployeeTerritoryCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class EmployeeTerritoryCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of EmployeeTerritory))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of EmployeeTerritory), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As EmployeeTerritoryCollectionProxyStub) As EmployeeTerritoryCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(EmployeeTerritory)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of EmployeeTerritory), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As EmployeeTerritory In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New EmployeeTerritoryProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New EmployeeTerritoryProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As EmployeeTerritory In coll.es.DeletedEntities
                    Collection.Add(New EmployeeTerritoryProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of EmployeeTerritoryProxyStub)		

        Public Function GetCollection As EmployeeTerritoryCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New EmployeeTerritoryCollection()
					
		            Dim proxy As EmployeeTerritoryProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As EmployeeTerritoryCollection
		
    End Class
	



	<Serializable> _
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
				Return true
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
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "EmployeeTerritory"
				meta.Destination = "EmployeeTerritory"
				
				meta.spInsert = "proc_EmployeeTerritoryInsert"
				meta.spUpdate = "proc_EmployeeTerritoryUpdate"
				meta.spDelete = "proc_EmployeeTerritoryDelete"
				meta.spLoadAll = "proc_EmployeeTerritoryLoadAll"
				meta.spLoadByPrimaryKey = "proc_EmployeeTerritoryLoadByPrimaryKey"
				
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
