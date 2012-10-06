
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
	' Encapsulates the 'ConcurrencyTestChild' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(ConcurrencyTestChild))> _
	<XmlType("ConcurrencyTestChild")> _ 
	<Table(Name:="ConcurrencyTestChild")> _	
	Partial Public Class ConcurrencyTestChild 
		Inherits esConcurrencyTestChild
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New ConcurrencyTestChild()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.Int64)
			Dim obj As New ConcurrencyTestChild()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.Int64, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New ConcurrencyTestChild()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ConcurrencyTestChild) As ConcurrencyTestChildProxyStub
			Return New ConcurrencyTestChildProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Id As Nullable(Of System.Int64)
			Get
				Return MyBase.Id
			End Get
			Set
				MyBase.Id = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property Name As System.String
			Get
				Return MyBase.Name
			End Get
			Set
				MyBase.Name = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Parent As Nullable(Of System.Int64)
			Get
				Return MyBase.Parent
			End Get
			Set
				MyBase.Parent = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property ConcurrencyCheck As Nullable(Of System.Int64)
			Get
				Return MyBase.ConcurrencyCheck
			End Get
			Set
				MyBase.ConcurrencyCheck = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property DefaultTest As Nullable(Of System.DateTime)
			Get
				Return MyBase.DefaultTest
			End Get
			Set
				MyBase.DefaultTest = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ColumnA As Nullable(Of System.Int32)
			Get
				Return MyBase.ColumnA
			End Get
			Set
				MyBase.ColumnA = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ColumnB As Nullable(Of System.Int32)
			Get
				Return MyBase.ColumnB
			End Get
			Set
				MyBase.ColumnB = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ComputedAB As Nullable(Of System.Int32)
			Get
				Return MyBase.ComputedAB
			End Get
			Set
				MyBase.ComputedAB = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ConcurrencyTestChildCollection")> _
	Partial Public Class ConcurrencyTestChildCollection
		Inherits esConcurrencyTestChildCollection
		Implements IEnumerable(Of ConcurrencyTestChild)
	
		Public Function FindByPrimaryKey(ByVal id As System.Int64) As ConcurrencyTestChild
			Return MyBase.SingleOrDefault(Function(e) e.Id.HasValue AndAlso e.Id.Value = id)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ConcurrencyTestChildCollection) As ConcurrencyTestChildCollectionProxyStub
            Return New ConcurrencyTestChildCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(ConcurrencyTestChild))> _
		Public Class ConcurrencyTestChildCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ConcurrencyTestChildCollection)
			
			Public Shared Widening Operator CType(packet As ConcurrencyTestChildCollectionWCFPacket) As ConcurrencyTestChildCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ConcurrencyTestChildCollection) As ConcurrencyTestChildCollectionWCFPacket
				Return New ConcurrencyTestChildCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ConcurrencyTestChildQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ConcurrencyTestChildQuery 
		Inherits esConcurrencyTestChildQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ConcurrencyTestChildQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ConcurrencyTestChildQuery) As String
			Return ConcurrencyTestChildQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ConcurrencyTestChildQuery
			Return DirectCast(ConcurrencyTestChildQuery.SerializeHelper.FromXml(query, GetType(ConcurrencyTestChildQuery)), ConcurrencyTestChildQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esConcurrencyTestChild
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal id As System.Int64) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal id As System.Int64) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal id As System.Int64) As Boolean
		
			Dim query As New ConcurrencyTestChildQuery()
			query.Where(query.Id = id)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal id As System.Int64) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("Id", id)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to ConcurrencyTestChild.Id
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Id As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Id, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTestChild.Name
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Name As System.String
			Get
				Return MyBase.GetSystemString(ConcurrencyTestChildMetadata.ColumnNames.Name)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ConcurrencyTestChildMetadata.ColumnNames.Name, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Name)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTestChild.Parent
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Parent As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Parent)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.Parent, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Parent)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTestChild.ConcurrencyCheck
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ConcurrencyCheck As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ConcurrencyCheck)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTestChild.DefaultTest
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DefaultTest As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.DefaultTest)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTestChild.ColumnA
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ColumnA As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnA)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnA, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnA)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTestChild.ColumnB
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ColumnB As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnB)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ColumnB, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnB)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ConcurrencyTestChild.ComputedAB
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ComputedAB As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB, value) Then
					OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ComputedAB)
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
												
						Case "Name"
							Me.str().Name = CType(value, string)
												
						Case "Parent"
							Me.str().Parent = CType(value, string)
												
						Case "ConcurrencyCheck"
							Me.str().ConcurrencyCheck = CType(value, string)
												
						Case "DefaultTest"
							Me.str().DefaultTest = CType(value, string)
												
						Case "ColumnA"
							Me.str().ColumnA = CType(value, string)
												
						Case "ColumnB"
							Me.str().ColumnB = CType(value, string)
												
						Case "ComputedAB"
							Me.str().ComputedAB = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "Id"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.Id = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Id)
							End If
						
						Case "Parent"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.Parent = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.Parent)
							End If
						
						Case "ConcurrencyCheck"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.ConcurrencyCheck = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ConcurrencyCheck)
							End If
						
						Case "DefaultTest"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.DefaultTest = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.DefaultTest)
							End If
						
						Case "ColumnA"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ColumnA = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnA)
							End If
						
						Case "ColumnB"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ColumnB = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ColumnB)
							End If
						
						Case "ComputedAB"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ComputedAB = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ConcurrencyTestChildMetadata.PropertyNames.ComputedAB)
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
		
			Public Sub New(ByVal entity As esConcurrencyTestChild)
				Me.entity = entity
			End Sub				
		
	
			Public Property Id As System.String 
				Get
					Dim data_ As Nullable(Of System.Int64) = entity.Id
					
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
						entity.Id = Convert.ToInt64(Value)
					End If
				End Set
			End Property
		  	
			Public Property Name As System.String 
				Get
					Dim data_ As System.String = entity.Name
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Name = Nothing
					Else
						entity.Name = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Parent As System.String 
				Get
					Dim data_ As Nullable(Of System.Int64) = entity.Parent
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Parent = Nothing
					Else
						entity.Parent = Convert.ToInt64(Value)
					End If
				End Set
			End Property
		  	
			Public Property ConcurrencyCheck As System.String 
				Get
					Dim data_ As Nullable(Of System.Int64) = entity.ConcurrencyCheck
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ConcurrencyCheck = Nothing
					Else
						entity.ConcurrencyCheck = Convert.ToInt64(Value)
					End If
				End Set
			End Property
		  	
			Public Property DefaultTest As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.DefaultTest
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DefaultTest = Nothing
					Else
						entity.DefaultTest = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property ColumnA As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ColumnA
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ColumnA = Nothing
					Else
						entity.ColumnA = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property ColumnB As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ColumnB
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ColumnB = Nothing
					Else
						entity.ColumnB = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property ComputedAB As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ComputedAB
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ComputedAB = Nothing
					Else
						entity.ComputedAB = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  

			Private entity As esConcurrencyTestChild
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ConcurrencyTestChildMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ConcurrencyTestChildQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ConcurrencyTestChildQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ConcurrencyTestChildQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ConcurrencyTestChildQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ConcurrencyTestChildQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esConcurrencyTestChildCollection
		Inherits CollectionBase(Of ConcurrencyTestChild)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ConcurrencyTestChildMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ConcurrencyTestChildCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ConcurrencyTestChildQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ConcurrencyTestChildQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ConcurrencyTestChildQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ConcurrencyTestChildQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ConcurrencyTestChildQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ConcurrencyTestChildQuery))
		End Sub
		
		#End Region
						
		Private m_query As ConcurrencyTestChildQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esConcurrencyTestChildQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ConcurrencyTestChildMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "Name" 
					Return Me.Name
				Case "Parent" 
					Return Me.Parent
				Case "ConcurrencyCheck" 
					Return Me.ConcurrencyCheck
				Case "DefaultTest" 
					Return Me.DefaultTest
				Case "ColumnA" 
					Return Me.ColumnA
				Case "ColumnB" 
					Return Me.ColumnB
				Case "ComputedAB" 
					Return Me.ComputedAB
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.Id, esSystemType.Int64)
			End Get
		End Property 
		
		Public ReadOnly Property Name As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.Name, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Parent As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.Parent, esSystemType.Int64)
			End Get
		End Property 
		
		Public ReadOnly Property ConcurrencyCheck As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck, esSystemType.Int64)
			End Get
		End Property 
		
		Public ReadOnly Property DefaultTest As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.DefaultTest, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property ColumnA As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.ColumnA, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ColumnB As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.ColumnB, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ComputedAB As esQueryItem
			Get
				Return New esQueryItem(Me, ConcurrencyTestChildMetadata.ColumnNames.ComputedAB, esSystemType.Int32)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="ConcurrencyTestChild")> _
    <XmlType(TypeName:="ConcurrencyTestChildProxyStub")> _
    <Serializable> _
    Partial Public Class ConcurrencyTestChildProxyStub
	
		Public Sub New()
            Me._entity = New ConcurrencyTestChild()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ConcurrencyTestChild)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ConcurrencyTestChild, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ConcurrencyTestChildProxyStub) As ConcurrencyTestChild
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(ConcurrencyTestChild)
        End Function
		

		<DataMember(Name:="Id", Order:=1, EmitDefaultValue:=False)> _		
        Public Property Id As Nullable(Of System.Int64)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ConcurrencyTestChildMetadata.ColumnNames.Id)
					Return CType(o, Nullable(Of System.Int64))
                Else
					Return Me.Entity.Id
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.Id = value
			End Set
			
		End Property

		<DataMember(Name:="Name", Order:=2, EmitDefaultValue:=False)> _		
        Public Property Name As System.String
        
            Get
                If Me.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.Name) Then
                    Return Me.Entity.Name
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Name = value
			End Set
			
		End Property

		<DataMember(Name:="Parent", Order:=3, EmitDefaultValue:=False)> _		
        Public Property Parent As Nullable(Of System.Int64)
        
            Get
                If Me.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.Parent) Then
                    Return Me.Entity.Parent
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.Parent = value
			End Set
			
		End Property

		<DataMember(Name:="ConcurrencyCheck", Order:=4, EmitDefaultValue:=False)> _		
        Public Property ConcurrencyCheck As Nullable(Of System.Int64)
        
            Get
                If Me.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck) Then
                    Return Me.Entity.ConcurrencyCheck
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.ConcurrencyCheck = value
			End Set
			
		End Property

		<DataMember(Name:="DefaultTest", Order:=5, EmitDefaultValue:=False)> _		
        Public Property DefaultTest As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest) Then
                    Return Me.Entity.DefaultTest
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.DefaultTest = value
			End Set
			
		End Property

		<DataMember(Name:="ColumnA", Order:=6, EmitDefaultValue:=False)> _		
        Public Property ColumnA As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ColumnA) Then
                    Return Me.Entity.ColumnA
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ColumnA = value
			End Set
			
		End Property

		<DataMember(Name:="ColumnB", Order:=7, EmitDefaultValue:=False)> _		
        Public Property ColumnB As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ColumnB) Then
                    Return Me.Entity.ColumnB
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ColumnB = value
			End Set
			
		End Property

		<DataMember(Name:="ComputedAB", Order:=8, EmitDefaultValue:=False)> _		
        Public Property ComputedAB As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB) Then
                    Return Me.Entity.ComputedAB
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ComputedAB = value
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
        Public Property Entity As ConcurrencyTestChild
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New ConcurrencyTestChild()
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
        Public _entity As ConcurrencyTestChild
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ConcurrencyTestChildCollection")> _
    <XmlType(TypeName:="ConcurrencyTestChildCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ConcurrencyTestChildCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of ConcurrencyTestChild))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of ConcurrencyTestChild), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ConcurrencyTestChildCollectionProxyStub) As ConcurrencyTestChildCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(ConcurrencyTestChild)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of ConcurrencyTestChild), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As ConcurrencyTestChild In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ConcurrencyTestChildProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ConcurrencyTestChildProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As ConcurrencyTestChild In coll.es.DeletedEntities
                    Collection.Add(New ConcurrencyTestChildProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ConcurrencyTestChildProxyStub)		

        Public Function GetCollection As ConcurrencyTestChildCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ConcurrencyTestChildCollection()
					
		            Dim proxy As ConcurrencyTestChildProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ConcurrencyTestChildCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ConcurrencyTestChildMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.Id, 0, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 19
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.Name, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.Name
			c.CharacterMaxLength = 50
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.Parent, 2, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.Parent
			c.NumericPrecision = 19
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ConcurrencyCheck, 3, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ConcurrencyCheck
			c.NumericPrecision = 19
			c.IsEntitySpacesConcurrency = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.DefaultTest, 4, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.DefaultTest
			c.HasDefault = True
			c.Default = "(getdate())"
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ColumnA, 5, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ColumnA
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ColumnB, 6, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ColumnB
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(ConcurrencyTestChildMetadata.ColumnNames.ComputedAB, 7, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ConcurrencyTestChildMetadata.PropertyNames.ComputedAB
			c.NumericPrecision = 10
			c.IsNullable = True
			c.IsComputed = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ConcurrencyTestChildMetadata
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
			 Public Const Id As String = "Id"
			 Public Const Name As String = "Name"
			 Public Const Parent As String = "Parent"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const DefaultTest As String = "DefaultTest"
			 Public Const ColumnA As String = "ColumnA"
			 Public Const ColumnB As String = "ColumnB"
			 Public Const ComputedAB As String = "ComputedAB"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const Name As String = "Name"
			 Public Const Parent As String = "Parent"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const DefaultTest As String = "DefaultTest"
			 Public Const ColumnA As String = "ColumnA"
			 Public Const ColumnB As String = "ColumnB"
			 Public Const ComputedAB As String = "ComputedAB"
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
			SyncLock GetType(ConcurrencyTestChildMetadata)
			
				If ConcurrencyTestChildMetadata.mapDelegates Is Nothing Then
					ConcurrencyTestChildMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ConcurrencyTestChildMetadata._meta Is Nothing Then
					ConcurrencyTestChildMetadata._meta = New ConcurrencyTestChildMetadata()
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
				


				meta.AddTypeMap("Id", new esTypeMap("bigint", "System.Int64"))
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Parent", new esTypeMap("bigint", "System.Int64"))
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("bigint", "System.Int64"))
				meta.AddTypeMap("DefaultTest", new esTypeMap("datetime", "System.DateTime"))
				meta.AddTypeMap("ColumnA", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ColumnB", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ComputedAB", new esTypeMap("int", "System.Int32"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "ConcurrencyTestChild"
				meta.Destination = "ConcurrencyTestChild"
				
				meta.spInsert = "proc_ConcurrencyTestChildInsert"
				meta.spUpdate = "proc_ConcurrencyTestChildUpdate"
				meta.spDelete = "proc_ConcurrencyTestChildDelete"
				meta.spLoadAll = "proc_ConcurrencyTestChildLoadAll"
				meta.spLoadByPrimaryKey = "proc_ConcurrencyTestChildLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ConcurrencyTestChildMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
