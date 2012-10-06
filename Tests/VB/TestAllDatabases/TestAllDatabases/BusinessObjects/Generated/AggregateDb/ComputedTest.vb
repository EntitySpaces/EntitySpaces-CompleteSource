
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
	' Multi-line table Description
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(ComputedTest))> _
	<XmlType("ComputedTest")> _ 
	<Table(Name:="ComputedTest")> _	
	Partial Public Class ComputedTest 
		Inherits esComputedTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New ComputedTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.Int32)
			Dim obj As New ComputedTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New ComputedTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ComputedTest) As ComputedTestProxyStub
			Return New ComputedTestProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Id As Nullable(Of System.Int32)
			Get
				Return MyBase.Id
			End Get
			Set
				MyBase.Id = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.ConcurrencyCheck
			End Get
			Set
				MyBase.ConcurrencyCheck = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DateLastUpdated As Nullable(Of System.DateTime)
			Get
				Return MyBase.DateLastUpdated
			End Get
			Set
				MyBase.DateLastUpdated = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DateAdded As Nullable(Of System.DateTime)
			Get
				Return MyBase.DateAdded
			End Get
			Set
				MyBase.DateAdded = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ComputedField As Nullable(Of System.Int32)
			Get
				Return MyBase.ComputedField
			End Get
			Set
				MyBase.ComputedField = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property SomeDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.SomeDate
			End Get
			Set
				MyBase.SomeDate = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ComputedTestCollection")> _
	Partial Public Class ComputedTestCollection
		Inherits esComputedTestCollection
		Implements IEnumerable(Of ComputedTest)
	
		Public Function FindByPrimaryKey(ByVal id As System.Int32) As ComputedTest
			Return MyBase.SingleOrDefault(Function(e) e.Id.HasValue AndAlso e.Id.Value = id)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ComputedTestCollection) As ComputedTestCollectionProxyStub
            Return New ComputedTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(ComputedTest))> _
		Public Class ComputedTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ComputedTestCollection)
			
			Public Shared Widening Operator CType(packet As ComputedTestCollectionWCFPacket) As ComputedTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ComputedTestCollection) As ComputedTestCollectionWCFPacket
				Return New ComputedTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ComputedTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ComputedTestQuery 
		Inherits esComputedTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ComputedTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ComputedTestQuery) As String
			Return ComputedTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ComputedTestQuery
			Return DirectCast(ComputedTestQuery.SerializeHelper.FromXml(query, GetType(ComputedTestQuery)), ComputedTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esComputedTest
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal id As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal id As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal id As System.Int32) As Boolean
		
			Dim query As New ComputedTestQuery()
			query.Where(query.Id = id)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal id As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("Id", id)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to ComputedTest.ID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Id As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ComputedTestMetadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ComputedTestMetadata.ColumnNames.Id, value) Then
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ComputedTest.ConcurrencyCheck
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.GetSystemByteArray(ComputedTestMetadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As System.Byte())
				If MyBase.SetSystemByteArray(ComputedTestMetadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.ConcurrencyCheck)
				End If
			End Set
		End Property	
			
		' <summary>
		' Multi-line Description
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DateLastUpdated As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(ComputedTestMetadata.ColumnNames.DateLastUpdated)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(ComputedTestMetadata.ColumnNames.DateLastUpdated, value) Then
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateLastUpdated)
				End If
			End Set
		End Property	
			
		' <summary>
		' See "this"
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DateAdded As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(ComputedTestMetadata.ColumnNames.DateAdded)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(ComputedTestMetadata.ColumnNames.DateAdded, value) Then
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateAdded)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ComputedTest.ComputedTest
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ComputedField As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ComputedTestMetadata.ColumnNames.ComputedField)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ComputedTestMetadata.ColumnNames.ComputedField, value) Then
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.ComputedField)
				End If
			End Set
		End Property	
			
		' <summary>
		' See C:\this
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property SomeDate As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(ComputedTestMetadata.ColumnNames.SomeDate)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(ComputedTestMetadata.ColumnNames.SomeDate, value) Then
					OnPropertyChanged(ComputedTestMetadata.PropertyNames.SomeDate)
				End If
			End Set
		End Property	
		
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
												
						Case "Id"
							Me.str().Id = CType(value, string)
												
						Case "DateLastUpdated"
							Me.str().DateLastUpdated = CType(value, string)
												
						Case "DateAdded"
							Me.str().DateAdded = CType(value, string)
												
						Case "ComputedField"
							Me.str().ComputedField = CType(value, string)
												
						Case "SomeDate"
							Me.str().SomeDate = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "Id"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Id = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.Id)
							End If
						
						Case "ConcurrencyCheck"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Byte()" Then
								Me.ConcurrencyCheck = CType(value, System.Byte())
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.ConcurrencyCheck)
							End If
						
						Case "DateLastUpdated"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.DateLastUpdated = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateLastUpdated)
							End If
						
						Case "DateAdded"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.DateAdded = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.DateAdded)
							End If
						
						Case "ComputedField"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ComputedField = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.ComputedField)
							End If
						
						Case "SomeDate"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.SomeDate = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(ComputedTestMetadata.PropertyNames.SomeDate)
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
		
			Public Sub New(ByVal entity As esComputedTest)
				Me.entity = entity
			End Sub				
		
	
			Public Property Id As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.Id
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Id = Nothing
					Else
						entity.Id = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property DateLastUpdated As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.DateLastUpdated
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DateLastUpdated = Nothing
					Else
						entity.DateLastUpdated = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property DateAdded As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.DateAdded
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DateAdded = Nothing
					Else
						entity.DateAdded = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property ComputedField As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ComputedField
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ComputedField = Nothing
					Else
						entity.ComputedField = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property SomeDate As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.SomeDate
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.SomeDate = Nothing
					Else
						entity.SomeDate = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  

			Private entity As esComputedTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ComputedTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ComputedTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ComputedTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ComputedTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ComputedTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ComputedTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esComputedTestCollection
		Inherits CollectionBase(Of ComputedTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ComputedTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ComputedTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ComputedTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ComputedTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ComputedTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ComputedTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ComputedTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ComputedTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As ComputedTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esComputedTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ComputedTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "ConcurrencyCheck" 
					Return Me.ConcurrencyCheck
				Case "DateLastUpdated" 
					Return Me.DateLastUpdated
				Case "DateAdded" 
					Return Me.DateAdded
				Case "ComputedField" 
					Return Me.ComputedField
				Case "SomeDate" 
					Return Me.SomeDate
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, ComputedTestMetadata.ColumnNames.Id, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ConcurrencyCheck As esQueryItem
			Get
				Return New esQueryItem(Me, ComputedTestMetadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray)
			End Get
		End Property 
		
		Public ReadOnly Property DateLastUpdated As esQueryItem
			Get
				Return New esQueryItem(Me, ComputedTestMetadata.ColumnNames.DateLastUpdated, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property DateAdded As esQueryItem
			Get
				Return New esQueryItem(Me, ComputedTestMetadata.ColumnNames.DateAdded, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property ComputedField As esQueryItem
			Get
				Return New esQueryItem(Me, ComputedTestMetadata.ColumnNames.ComputedField, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property SomeDate As esQueryItem
			Get
				Return New esQueryItem(Me, ComputedTestMetadata.ColumnNames.SomeDate, esSystemType.DateTime)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="ComputedTest")> _
    <XmlType(TypeName:="ComputedTestProxyStub")> _
    <Serializable> _
    Partial Public Class ComputedTestProxyStub
	
		Public Sub New()
            Me._entity = New ComputedTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ComputedTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ComputedTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ComputedTestProxyStub) As ComputedTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(ComputedTest)
        End Function
		

		<DataMember(Name:="Id", Order:=1, EmitDefaultValue:=False)> _		
        Public Property Id As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ComputedTestMetadata.ColumnNames.Id)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.Id
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Id = value
			End Set
			
		End Property

		<DataMember(Name:="ConcurrencyCheck", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ConcurrencyCheck As System.Byte()
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ComputedTestMetadata.ColumnNames.ConcurrencyCheck)
					Return CType(o, System.Byte())
                Else
					Return Me.Entity.ConcurrencyCheck
				End If				
			End Get
			
            Set(ByVal value As System.Byte())
				Me.Entity.ConcurrencyCheck = value
			End Set
			
		End Property

		<DataMember(Name:="DateLastUpdated", Order:=3, EmitDefaultValue:=False)> _		
        Public Property DateLastUpdated As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(ComputedTestMetadata.ColumnNames.DateLastUpdated) Then
                    Return Me.Entity.DateLastUpdated
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.DateLastUpdated = value
			End Set
			
		End Property

		<DataMember(Name:="DateAdded", Order:=4, EmitDefaultValue:=False)> _		
        Public Property DateAdded As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(ComputedTestMetadata.ColumnNames.DateAdded) Then
                    Return Me.Entity.DateAdded
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.DateAdded = value
			End Set
			
		End Property

		<DataMember(Name:="ComputedField", Order:=5, EmitDefaultValue:=False)> _		
        Public Property ComputedField As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(ComputedTestMetadata.ColumnNames.ComputedField) Then
                    Return Me.Entity.ComputedField
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ComputedField = value
			End Set
			
		End Property

		<DataMember(Name:="SomeDate", Order:=6, EmitDefaultValue:=False)> _		
        Public Property SomeDate As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(ComputedTestMetadata.ColumnNames.SomeDate) Then
                    Return Me.Entity.SomeDate
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.SomeDate = value
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
        Public Property Entity As ComputedTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New ComputedTest()
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
        Public _entity As ComputedTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ComputedTestCollection")> _
    <XmlType(TypeName:="ComputedTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ComputedTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of ComputedTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of ComputedTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ComputedTestCollectionProxyStub) As ComputedTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(ComputedTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of ComputedTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As ComputedTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ComputedTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ComputedTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As ComputedTest In coll.es.DeletedEntities
                    Collection.Add(New ComputedTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ComputedTestProxyStub)		

        Public Function GetCollection As ComputedTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ComputedTestCollection()
					
		            Dim proxy As ComputedTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ComputedTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ComputedTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ComputedTestMetadata.ColumnNames.Id, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ComputedTestMetadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ComputedTestMetadata.ColumnNames.ConcurrencyCheck, 1, GetType(System.Byte()), esSystemType.ByteArray)	
			c.PropertyName = ComputedTestMetadata.PropertyNames.ConcurrencyCheck
			c.CharacterMaxLength = 8
			c.IsComputed = True
			c.IsConcurrency = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ComputedTestMetadata.ColumnNames.DateLastUpdated, 2, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = ComputedTestMetadata.PropertyNames.DateLastUpdated
			c.HasDefault = True
			c.Default = "(getdate())"
			c.Description = "Multi-line Description"
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ComputedTestMetadata.ColumnNames.DateAdded, 3, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = ComputedTestMetadata.PropertyNames.DateAdded
			c.HasDefault = True
			c.Default = "(getdate())"
			c.Description = "See ""this"""
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ComputedTestMetadata.ColumnNames.ComputedField, 4, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ComputedTestMetadata.PropertyNames.ComputedField
			c.NumericPrecision = 10
			c.IsNullable = True
			c.IsComputed = True
			c.Alias = "ComputedField"
			m_columns.Add(c)
				
			c = New esColumnMetadata(ComputedTestMetadata.ColumnNames.SomeDate, 5, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = ComputedTestMetadata.PropertyNames.SomeDate
			c.Description = "See C:\this"
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ComputedTestMetadata
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
			 Public Const Id As String = "ID"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const DateLastUpdated As String = "DateLastUpdated"
			 Public Const DateAdded As String = "DateAdded"
			 Public Const ComputedField As String = "ComputedTest"
			 Public Const SomeDate As String = "SomeDate"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const DateLastUpdated As String = "DateLastUpdated"
			 Public Const DateAdded As String = "DateAdded"
			 Public Const ComputedField As String = "ComputedField"
			 Public Const SomeDate As String = "SomeDate"
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
			SyncLock GetType(ComputedTestMetadata)
			
				If ComputedTestMetadata.mapDelegates Is Nothing Then
					ComputedTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ComputedTestMetadata._meta Is Nothing Then
					ComputedTestMetadata._meta = New ComputedTestMetadata()
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
				


				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte()"))
				meta.AddTypeMap("DateLastUpdated", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("ComputedField", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("SomeDate", new esTypeMap("datetime", "System.DateTime"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "ComputedTest"
				meta.Destination = "ComputedTest"
				
				meta.spInsert = "proc_ComputedTestInsert"
				meta.spUpdate = "proc_ComputedTestUpdate"
				meta.spDelete = "proc_ComputedTestDelete"
				meta.spLoadAll = "proc_ComputedTestLoadAll"
				meta.spLoadByPrimaryKey = "proc_ComputedTestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ComputedTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
