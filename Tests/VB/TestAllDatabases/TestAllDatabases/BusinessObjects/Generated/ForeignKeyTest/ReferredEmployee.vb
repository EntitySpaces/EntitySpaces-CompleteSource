
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : SQL
' Date Generated       : 3/17/2012 4:51:53 AM
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
	' Encapsulates the 'ReferredEmployee' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(ReferredEmployee))> _
	<XmlType("ReferredEmployee")> _ 
	<Table(Name:="ReferredEmployee")> _	
	Partial Public Class ReferredEmployee 
		Inherits esReferredEmployee
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
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
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ReferredEmployee) As ReferredEmployeeProxyStub
			Return New ReferredEmployeeProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property EmployeeID As Nullable(Of System.Int32)
			Get
				Return MyBase.EmployeeID
			End Get
			Set
				MyBase.EmployeeID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property ReferredID As Nullable(Of System.Int32)
			Get
				Return MyBase.ReferredID
			End Get
			Set
				MyBase.ReferredID = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ReferredEmployeeCollection")> _
	Partial Public Class ReferredEmployeeCollection
		Inherits esReferredEmployeeCollection
		Implements IEnumerable(Of ReferredEmployee)
	
		Public Function FindByPrimaryKey(ByVal employeeID As System.Int32, ByVal referredID As System.Int32) As ReferredEmployee
			Return MyBase.SingleOrDefault(Function(e) e.EmployeeID.HasValue AndAlso e.EmployeeID.Value = employeeID And e.ReferredID.HasValue AndAlso e.ReferredID.Value = referredID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ReferredEmployeeCollection) As ReferredEmployeeCollectionProxyStub
            Return New ReferredEmployeeCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(ReferredEmployee))> _
		Public Class ReferredEmployeeCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ReferredEmployeeCollection)
			
			Public Shared Widening Operator CType(packet As ReferredEmployeeCollectionWCFPacket) As ReferredEmployeeCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ReferredEmployeeCollection) As ReferredEmployeeCollectionWCFPacket
				Return New ReferredEmployeeCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ReferredEmployeeQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ReferredEmployeeQuery 
		Inherits esReferredEmployeeQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ReferredEmployeeQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ReferredEmployeeQuery) As String
			Return ReferredEmployeeQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ReferredEmployeeQuery
			Return DirectCast(ReferredEmployeeQuery.SerializeHelper.FromXml(query, GetType(ReferredEmployeeQuery)), ReferredEmployeeQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		<DataMember(EmitDefaultValue:=False)> _
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
		Dim Friend Protected _UpToEmployeeByEmployeeID As Employee
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToEmployeeByReferredID As Employee
		
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
												
						Case "EmployeeID"
							Me.str().EmployeeID = CType(value, string)
												
						Case "ReferredID"
							Me.str().ReferredID = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "EmployeeID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.EmployeeID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.EmployeeID)
							End If
						
						Case "ReferredID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ReferredID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ReferredEmployeeMetadata.PropertyNames.ReferredID)
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
		
			Public Sub New(ByVal entity As esReferredEmployee)
				Me.entity = entity
			End Sub				
		
	
			Public Property EmployeeID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.EmployeeID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.EmployeeID = Nothing
					Else
						entity.EmployeeID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property ReferredID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ReferredID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ReferredID = Nothing
					Else
						entity.ReferredID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  

			Private entity As esReferredEmployee
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
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

        <IgnoreDataMember> _
        Private m_query As ReferredEmployeeQuery

	End Class



	<Serializable()> _
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
		

		<BrowsableAttribute(False)> _ 
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



	<Serializable> _
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
		
	
		#Region "UpToEmployeeByEmployeeID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_ReferredEmployee_Employee1
		''' </summary>

		<XmlIgnore()> _		
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

		#Region "UpToEmployeeByReferredID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_ReferredEmployee_Employee2
		''' </summary>

		<XmlIgnore()> _		
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

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByEmployeeID Is Nothing Then
				Me.EmployeeID = Me._UpToEmployeeByEmployeeID.EmployeeID
			End If
			
			If Not Me.es.IsDeleted And Not Me._UpToEmployeeByReferredID Is Nothing Then
				Me.ReferredID = Me._UpToEmployeeByReferredID.EmployeeID
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="ReferredEmployee")> _
    <XmlType(TypeName:="ReferredEmployeeProxyStub")> _
    <Serializable> _
    Partial Public Class ReferredEmployeeProxyStub
	
		Public Sub New()
            Me._entity = New ReferredEmployee()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ReferredEmployee)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ReferredEmployee, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ReferredEmployeeProxyStub) As ReferredEmployee
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(ReferredEmployee)
        End Function
		

		<DataMember(Name:="EmployeeID", Order:=1, EmitDefaultValue:=False)> _		
        Public Property EmployeeID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ReferredEmployeeMetadata.ColumnNames.EmployeeID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.EmployeeID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.EmployeeID = value
			End Set
			
		End Property

		<DataMember(Name:="ReferredID", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ReferredID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ReferredEmployeeMetadata.ColumnNames.ReferredID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.ReferredID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ReferredID = value
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
        Public Property Entity As ReferredEmployee
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New ReferredEmployee()
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
        Public _entity As ReferredEmployee
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ReferredEmployeeCollection")> _
    <XmlType(TypeName:="ReferredEmployeeCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ReferredEmployeeCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of ReferredEmployee))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of ReferredEmployee), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ReferredEmployeeCollectionProxyStub) As ReferredEmployeeCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(ReferredEmployee)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of ReferredEmployee), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As ReferredEmployee In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ReferredEmployeeProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ReferredEmployeeProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As ReferredEmployee In coll.es.DeletedEntities
                    Collection.Add(New ReferredEmployeeProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ReferredEmployeeProxyStub)		

        Public Function GetCollection As ReferredEmployeeCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ReferredEmployeeCollection()
					
		            Dim proxy As ReferredEmployeeProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ReferredEmployeeCollection
		
    End Class
	



	<Serializable> _
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
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "ReferredEmployee"
				meta.Destination = "ReferredEmployee"
				
				meta.spInsert = "proc_ReferredEmployeeInsert"
				meta.spUpdate = "proc_ReferredEmployeeUpdate"
				meta.spDelete = "proc_ReferredEmployeeDelete"
				meta.spLoadAll = "proc_ReferredEmployeeLoadAll"
				meta.spLoadByPrimaryKey = "proc_ReferredEmployeeLoadByPrimaryKey"
				
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
