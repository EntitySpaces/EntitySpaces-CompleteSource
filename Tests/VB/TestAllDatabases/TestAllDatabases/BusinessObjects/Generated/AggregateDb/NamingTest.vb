
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
	' Encapsulates the 'Naming.Test' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(NamingTest))> _
	<XmlType("NamingTest")> _ 
	<Table(Name:="NamingTest")> _	
	Partial Public Class NamingTest 
		Inherits esNamingTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New NamingTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal guidKeyAlias As System.Guid)
			Dim obj As New NamingTest()
			obj.GuidKeyAlias = guidKeyAlias
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal guidKeyAlias As System.Guid, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New NamingTest()
			obj.GuidKeyAlias = guidKeyAlias
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As NamingTest) As NamingTestProxyStub
			Return New NamingTestProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property GuidKeyAlias As Nullable(Of System.Guid)
			Get
				Return MyBase.GuidKeyAlias
			End Get
			Set
				MyBase.GuidKeyAlias = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TestAliasSpace As System.String
			Get
				Return MyBase.TestAliasSpace
			End Get
			Set
				MyBase.TestAliasSpace = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Test_Alias_Underscore As System.String
			Get
				Return MyBase.Test_Alias_Underscore
			End Get
			Set
				MyBase.Test_Alias_Underscore = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TestFieldSpace As System.String
			Get
				Return MyBase.TestFieldSpace
			End Get
			Set
				MyBase.TestFieldSpace = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TestFieldUnderscore As System.String
			Get
				Return MyBase.TestFieldUnderscore
			End Get
			Set
				MyBase.TestFieldUnderscore = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TestAlias As System.String
			Get
				Return MyBase.TestAlias
			End Get
			Set
				MyBase.TestAlias = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property GuidNonKey As Nullable(Of System.Guid)
			Get
				Return MyBase.GuidNonKey
			End Get
			Set
				MyBase.GuidNonKey = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TestFieldDot As System.String
			Get
				Return MyBase.TestFieldDot
			End Get
			Set
				MyBase.TestFieldDot = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("NamingTestCollection")> _
	Partial Public Class NamingTestCollection
		Inherits esNamingTestCollection
		Implements IEnumerable(Of NamingTest)
	
		Public Function FindByPrimaryKey(ByVal guidKeyAlias As System.Guid) As NamingTest
			Return MyBase.SingleOrDefault(Function(e) e.GuidKeyAlias.HasValue AndAlso e.GuidKeyAlias.Value = guidKeyAlias)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As NamingTestCollection) As NamingTestCollectionProxyStub
            Return New NamingTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(NamingTest))> _
		Public Class NamingTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of NamingTestCollection)
			
			Public Shared Widening Operator CType(packet As NamingTestCollectionWCFPacket) As NamingTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As NamingTestCollection) As NamingTestCollectionWCFPacket
				Return New NamingTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "NamingTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class NamingTestQuery 
		Inherits esNamingTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "NamingTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As NamingTestQuery) As String
			Return NamingTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As NamingTestQuery
			Return DirectCast(NamingTestQuery.SerializeHelper.FromXml(query, GetType(NamingTestQuery)), NamingTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esNamingTest
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal guidKeyAlias As System.Guid) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(guidKeyAlias)
			Else
				Return LoadByPrimaryKeyStoredProcedure(guidKeyAlias)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal guidKeyAlias As System.Guid) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(guidKeyAlias)
			Else
				Return LoadByPrimaryKeyStoredProcedure(guidKeyAlias)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal guidKeyAlias As System.Guid) As Boolean
		
			Dim query As New NamingTestQuery()
			query.Where(query.GuidKeyAlias = guidKeyAlias)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal guidKeyAlias As System.Guid) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("GuidKeyAlias", guidKeyAlias)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Naming.Test.GuidKey
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property GuidKeyAlias As Nullable(Of System.Guid)
			Get
				Return MyBase.GetSystemGuid(NamingTestMetadata.ColumnNames.GuidKeyAlias)
			End Get
			
			Set(ByVal value As Nullable(Of System.Guid))
				If MyBase.SetSystemGuid(NamingTestMetadata.ColumnNames.GuidKeyAlias, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidKeyAlias)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming.Test.Test AliasSpace
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TestAliasSpace As System.String
			Get
				Return MyBase.GetSystemString(NamingTestMetadata.ColumnNames.TestAliasSpace)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(NamingTestMetadata.ColumnNames.TestAliasSpace, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestAliasSpace)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming.Test.Test_AliasUnderscore
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Test_Alias_Underscore As System.String
			Get
				Return MyBase.GetSystemString(NamingTestMetadata.ColumnNames.Test_Alias_Underscore)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(NamingTestMetadata.ColumnNames.Test_Alias_Underscore, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.Test_Alias_Underscore)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming.Test.Test FieldSpace
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TestFieldSpace As System.String
			Get
				Return MyBase.GetSystemString(NamingTestMetadata.ColumnNames.TestFieldSpace)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(NamingTestMetadata.ColumnNames.TestFieldSpace, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestFieldSpace)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming.Test.test_field_underscore
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TestFieldUnderscore As System.String
			Get
				Return MyBase.GetSystemString(NamingTestMetadata.ColumnNames.TestFieldUnderscore)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(NamingTestMetadata.ColumnNames.TestFieldUnderscore, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestFieldUnderscore)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming.Test.TestAliasPascal
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TestAlias As System.String
			Get
				Return MyBase.GetSystemString(NamingTestMetadata.ColumnNames.TestAlias)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(NamingTestMetadata.ColumnNames.TestAlias, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestAlias)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming.Test.GuidNonKey
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property GuidNonKey As Nullable(Of System.Guid)
			Get
				Return MyBase.GetSystemGuid(NamingTestMetadata.ColumnNames.GuidNonKey)
			End Get
			
			Set(ByVal value As Nullable(Of System.Guid))
				If MyBase.SetSystemGuid(NamingTestMetadata.ColumnNames.GuidNonKey, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidNonKey)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Naming.Test.Test.FieldDot
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TestFieldDot As System.String
			Get
				Return MyBase.GetSystemString(NamingTestMetadata.ColumnNames.TestFieldDot)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(NamingTestMetadata.ColumnNames.TestFieldDot, value) Then
					OnPropertyChanged(NamingTestMetadata.PropertyNames.TestFieldDot)
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
												
						Case "GuidKeyAlias"
							Me.str().GuidKeyAlias = CType(value, string)
												
						Case "TestAliasSpace"
							Me.str().TestAliasSpace = CType(value, string)
												
						Case "Test_Alias_Underscore"
							Me.str().Test_Alias_Underscore = CType(value, string)
												
						Case "TestFieldSpace"
							Me.str().TestFieldSpace = CType(value, string)
												
						Case "TestFieldUnderscore"
							Me.str().TestFieldUnderscore = CType(value, string)
												
						Case "TestAlias"
							Me.str().TestAlias = CType(value, string)
												
						Case "GuidNonKey"
							Me.str().GuidNonKey = CType(value, string)
												
						Case "TestFieldDot"
							Me.str().TestFieldDot = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "GuidKeyAlias"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Guid" Then
								Me.GuidKeyAlias = CType(value, Nullable(Of System.Guid))
								OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidKeyAlias)
							End If
						
						Case "GuidNonKey"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Guid" Then
								Me.GuidNonKey = CType(value, Nullable(Of System.Guid))
								OnPropertyChanged(NamingTestMetadata.PropertyNames.GuidNonKey)
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
		
			Public Sub New(ByVal entity As esNamingTest)
				Me.entity = entity
			End Sub				
		
	
			Public Property GuidKeyAlias As System.String 
				Get
					Dim data_ As Nullable(Of System.Guid) = entity.GuidKeyAlias
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.GuidKeyAlias = Nothing
					Else
						entity.GuidKeyAlias = new Guid(Value)
					End If
				End Set
			End Property
		  	
			Public Property TestAliasSpace As System.String 
				Get
					Dim data_ As System.String = entity.TestAliasSpace
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TestAliasSpace = Nothing
					Else
						entity.TestAliasSpace = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Test_Alias_Underscore As System.String 
				Get
					Dim data_ As System.String = entity.Test_Alias_Underscore
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Test_Alias_Underscore = Nothing
					Else
						entity.Test_Alias_Underscore = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property TestFieldSpace As System.String 
				Get
					Dim data_ As System.String = entity.TestFieldSpace
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TestFieldSpace = Nothing
					Else
						entity.TestFieldSpace = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property TestFieldUnderscore As System.String 
				Get
					Dim data_ As System.String = entity.TestFieldUnderscore
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TestFieldUnderscore = Nothing
					Else
						entity.TestFieldUnderscore = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property TestAlias As System.String 
				Get
					Dim data_ As System.String = entity.TestAlias
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TestAlias = Nothing
					Else
						entity.TestAlias = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property GuidNonKey As System.String 
				Get
					Dim data_ As Nullable(Of System.Guid) = entity.GuidNonKey
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.GuidNonKey = Nothing
					Else
						entity.GuidNonKey = new Guid(Value)
					End If
				End Set
			End Property
		  	
			Public Property TestFieldDot As System.String 
				Get
					Dim data_ As System.String = entity.TestFieldDot
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TestFieldDot = Nothing
					Else
						entity.TestFieldDot = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esNamingTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return NamingTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As NamingTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New NamingTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As NamingTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As NamingTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As NamingTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esNamingTestCollection
		Inherits CollectionBase(Of NamingTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return NamingTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "NamingTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As NamingTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New NamingTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As NamingTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New NamingTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As NamingTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, NamingTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As NamingTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esNamingTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return NamingTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "GuidKeyAlias" 
					Return Me.GuidKeyAlias
				Case "TestAliasSpace" 
					Return Me.TestAliasSpace
				Case "Test_Alias_Underscore" 
					Return Me.Test_Alias_Underscore
				Case "TestFieldSpace" 
					Return Me.TestFieldSpace
				Case "TestFieldUnderscore" 
					Return Me.TestFieldUnderscore
				Case "TestAlias" 
					Return Me.TestAlias
				Case "GuidNonKey" 
					Return Me.GuidNonKey
				Case "TestFieldDot" 
					Return Me.TestFieldDot
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property GuidKeyAlias As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.GuidKeyAlias, esSystemType.Guid)
			End Get
		End Property 
		
		Public ReadOnly Property TestAliasSpace As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.TestAliasSpace, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Test_Alias_Underscore As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.Test_Alias_Underscore, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TestFieldSpace As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.TestFieldSpace, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TestFieldUnderscore As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.TestFieldUnderscore, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TestAlias As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.TestAlias, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property GuidNonKey As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.GuidNonKey, esSystemType.Guid)
			End Get
		End Property 
		
		Public ReadOnly Property TestFieldDot As esQueryItem
			Get
				Return New esQueryItem(Me, NamingTestMetadata.ColumnNames.TestFieldDot, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="NamingTest")> _
    <XmlType(TypeName:="NamingTestProxyStub")> _
    <Serializable> _
    Partial Public Class NamingTestProxyStub
	
		Public Sub New()
            Me._entity = New NamingTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As NamingTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As NamingTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As NamingTestProxyStub) As NamingTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(NamingTest)
        End Function
		

		<DataMember(Name:="GuidKeyAlias", Order:=1, EmitDefaultValue:=False)> _		
        Public Property GuidKeyAlias As Nullable(Of System.Guid)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(NamingTestMetadata.ColumnNames.GuidKeyAlias)
					Return CType(o, Nullable(Of System.Guid))
                Else
					Return Me.Entity.GuidKeyAlias
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Guid))
				Me.Entity.GuidKeyAlias = value
			End Set
			
		End Property

		<DataMember(Name:="TestAliasSpace", Order:=2, EmitDefaultValue:=False)> _		
        Public Property TestAliasSpace As System.String
        
            Get
                If Me.IncludeColumn(NamingTestMetadata.ColumnNames.TestAliasSpace) Then
                    Return Me.Entity.TestAliasSpace
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TestAliasSpace = value
			End Set
			
		End Property

		<DataMember(Name:="Test_Alias_Underscore", Order:=3, EmitDefaultValue:=False)> _		
        Public Property Test_Alias_Underscore As System.String
        
            Get
                If Me.IncludeColumn(NamingTestMetadata.ColumnNames.Test_Alias_Underscore) Then
                    Return Me.Entity.Test_Alias_Underscore
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Test_Alias_Underscore = value
			End Set
			
		End Property

		<DataMember(Name:="TestFieldSpace", Order:=4, EmitDefaultValue:=False)> _		
        Public Property TestFieldSpace As System.String
        
            Get
                If Me.IncludeColumn(NamingTestMetadata.ColumnNames.TestFieldSpace) Then
                    Return Me.Entity.TestFieldSpace
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TestFieldSpace = value
			End Set
			
		End Property

		<DataMember(Name:="TestFieldUnderscore", Order:=5, EmitDefaultValue:=False)> _		
        Public Property TestFieldUnderscore As System.String
        
            Get
                If Me.IncludeColumn(NamingTestMetadata.ColumnNames.TestFieldUnderscore) Then
                    Return Me.Entity.TestFieldUnderscore
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TestFieldUnderscore = value
			End Set
			
		End Property

		<DataMember(Name:="TestAlias", Order:=6, EmitDefaultValue:=False)> _		
        Public Property TestAlias As System.String
        
            Get
                If Me.IncludeColumn(NamingTestMetadata.ColumnNames.TestAlias) Then
                    Return Me.Entity.TestAlias
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TestAlias = value
			End Set
			
		End Property

		<DataMember(Name:="GuidNonKey", Order:=7, EmitDefaultValue:=False)> _		
        Public Property GuidNonKey As Nullable(Of System.Guid)
        
            Get
                If Me.IncludeColumn(NamingTestMetadata.ColumnNames.GuidNonKey) Then
                    Return Me.Entity.GuidNonKey
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Guid))
				Me.Entity.GuidNonKey = value
			End Set
			
		End Property

		<DataMember(Name:="TestFieldDot", Order:=8, EmitDefaultValue:=False)> _		
        Public Property TestFieldDot As System.String
        
            Get
                If Me.IncludeColumn(NamingTestMetadata.ColumnNames.TestFieldDot) Then
                    Return Me.Entity.TestFieldDot
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TestFieldDot = value
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
        Public Property Entity As NamingTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New NamingTest()
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
        Public _entity As NamingTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="NamingTestCollection")> _
    <XmlType(TypeName:="NamingTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class NamingTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of NamingTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of NamingTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As NamingTestCollectionProxyStub) As NamingTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(NamingTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of NamingTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As NamingTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New NamingTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New NamingTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As NamingTest In coll.es.DeletedEntities
                    Collection.Add(New NamingTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of NamingTestProxyStub)		

        Public Function GetCollection As NamingTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New NamingTestCollection()
					
		            Dim proxy As NamingTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As NamingTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class NamingTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.GuidKeyAlias, 0, GetType(System.Guid), esSystemType.Guid)	
			c.PropertyName = NamingTestMetadata.PropertyNames.GuidKeyAlias
			c.IsInPrimaryKey = True
			c.HasDefault = True
			c.Default = "(newid())"
			c.Alias = "GuidKeyAlias"
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.TestAliasSpace, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = NamingTestMetadata.PropertyNames.TestAliasSpace
			c.CharacterMaxLength = 10
			c.IsNullable = True
			c.Alias = "TestAliasSpace"
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.Test_Alias_Underscore, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = NamingTestMetadata.PropertyNames.Test_Alias_Underscore
			c.CharacterMaxLength = 10
			c.IsNullable = True
			c.Alias = "Test_Alias_Underscore"
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.TestFieldSpace, 3, GetType(System.String), esSystemType.String)	
			c.PropertyName = NamingTestMetadata.PropertyNames.TestFieldSpace
			c.CharacterMaxLength = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.TestFieldUnderscore, 4, GetType(System.String), esSystemType.String)	
			c.PropertyName = NamingTestMetadata.PropertyNames.TestFieldUnderscore
			c.CharacterMaxLength = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.TestAlias, 5, GetType(System.String), esSystemType.String)	
			c.PropertyName = NamingTestMetadata.PropertyNames.TestAlias
			c.CharacterMaxLength = 10
			c.IsNullable = True
			c.Alias = "TestAlias"
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.GuidNonKey, 6, GetType(System.Guid), esSystemType.Guid)	
			c.PropertyName = NamingTestMetadata.PropertyNames.GuidNonKey
			c.HasDefault = True
			c.Default = "(newid())"
			m_columns.Add(c)
				
			c = New esColumnMetadata(NamingTestMetadata.ColumnNames.TestFieldDot, 7, GetType(System.String), esSystemType.String)	
			c.PropertyName = NamingTestMetadata.PropertyNames.TestFieldDot
			c.CharacterMaxLength = 10
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As NamingTestMetadata
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
			 Public Const GuidKeyAlias As String = "GuidKey"
			 Public Const TestAliasSpace As String = "Test AliasSpace"
			 Public Const Test_Alias_Underscore As String = "Test_AliasUnderscore"
			 Public Const TestFieldSpace As String = "Test FieldSpace"
			 Public Const TestFieldUnderscore As String = "test_field_underscore"
			 Public Const TestAlias As String = "TestAliasPascal"
			 Public Const GuidNonKey As String = "GuidNonKey"
			 Public Const TestFieldDot As String = "Test.FieldDot"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const GuidKeyAlias As String = "GuidKeyAlias"
			 Public Const TestAliasSpace As String = "TestAliasSpace"
			 Public Const Test_Alias_Underscore As String = "Test_Alias_Underscore"
			 Public Const TestFieldSpace As String = "TestFieldSpace"
			 Public Const TestFieldUnderscore As String = "TestFieldUnderscore"
			 Public Const TestAlias As String = "TestAlias"
			 Public Const GuidNonKey As String = "GuidNonKey"
			 Public Const TestFieldDot As String = "TestFieldDot"
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
			SyncLock GetType(NamingTestMetadata)
			
				If NamingTestMetadata.mapDelegates Is Nothing Then
					NamingTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If NamingTestMetadata._meta Is Nothing Then
					NamingTestMetadata._meta = New NamingTestMetadata()
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
				


				meta.AddTypeMap("GuidKeyAlias", new esTypeMap("uniqueidentifier", "System.Guid"))
				meta.AddTypeMap("TestAliasSpace", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("Test_Alias_Underscore", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("TestFieldSpace", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("TestFieldUnderscore", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("TestAlias", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("GuidNonKey", new esTypeMap("uniqueidentifier", "System.Guid"))
				meta.AddTypeMap("TestFieldDot", new esTypeMap("nchar", "System.String"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "Naming.Test"
				meta.Destination = "Naming.Test"
				
				meta.spInsert = "proc_Naming.TestInsert"
				meta.spUpdate = "proc_Naming.TestUpdate"
				meta.spDelete = "proc_Naming.TestDelete"
				meta.spLoadAll = "proc_Naming.TestLoadAll"
				meta.spLoadByPrimaryKey = "proc_Naming.TestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As NamingTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
