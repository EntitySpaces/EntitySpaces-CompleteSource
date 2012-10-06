
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
	' Encapsulates the 'SqlServerTypeTest' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(SqlServerTypeTest))> _
	<XmlType("SqlServerTypeTest")> _ 
	<Table(Name:="SqlServerTypeTest")> _	
	Partial Public Class SqlServerTypeTest 
		Inherits esSqlServerTypeTest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New SqlServerTypeTest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.Int64)
			Dim obj As New SqlServerTypeTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.Int64, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New SqlServerTypeTest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As SqlServerTypeTest) As SqlServerTypeTestProxyStub
			Return New SqlServerTypeTestProxyStub(entity)
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
		Public Overrides Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.ConcurrencyCheck
			End Get
			Set
				MyBase.ConcurrencyCheck = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property NVarCharType As System.String
			Get
				Return MyBase.NVarCharType
			End Get
			Set
				MyBase.NVarCharType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property NumericType As Nullable(Of System.Decimal)
			Get
				Return MyBase.NumericType
			End Get
			Set
				MyBase.NumericType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property RealType As Nullable(Of System.Single)
			Get
				Return MyBase.RealType
			End Get
			Set
				MyBase.RealType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property FloatType As Nullable(Of System.Double)
			Get
				Return MyBase.FloatType
			End Get
			Set
				MyBase.FloatType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DecimalType As Nullable(Of System.Decimal)
			Get
				Return MyBase.DecimalType
			End Get
			Set
				MyBase.DecimalType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property VarCharMaxType As System.String
			Get
				Return MyBase.VarCharMaxType
			End Get
			Set
				MyBase.VarCharMaxType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property BigIntType As Nullable(Of System.Int64)
			Get
				Return MyBase.BigIntType
			End Get
			Set
				MyBase.BigIntType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property NCharType As Nullable(Of System.Char)
			Get
				Return MyBase.NCharType
			End Get
			Set
				MyBase.NCharType = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("SqlServerTypeTestCollection")> _
	Partial Public Class SqlServerTypeTestCollection
		Inherits esSqlServerTypeTestCollection
		Implements IEnumerable(Of SqlServerTypeTest)
	
		Public Function FindByPrimaryKey(ByVal id As System.Int64) As SqlServerTypeTest
			Return MyBase.SingleOrDefault(Function(e) e.Id.HasValue AndAlso e.Id.Value = id)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As SqlServerTypeTestCollection) As SqlServerTypeTestCollectionProxyStub
            Return New SqlServerTypeTestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(SqlServerTypeTest))> _
		Public Class SqlServerTypeTestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of SqlServerTypeTestCollection)
			
			Public Shared Widening Operator CType(packet As SqlServerTypeTestCollectionWCFPacket) As SqlServerTypeTestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As SqlServerTypeTestCollection) As SqlServerTypeTestCollectionWCFPacket
				Return New SqlServerTypeTestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "SqlServerTypeTestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class SqlServerTypeTestQuery 
		Inherits esSqlServerTypeTestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "SqlServerTypeTestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As SqlServerTypeTestQuery) As String
			Return SqlServerTypeTestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As SqlServerTypeTestQuery
			Return DirectCast(SqlServerTypeTestQuery.SerializeHelper.FromXml(query, GetType(SqlServerTypeTestQuery)), SqlServerTypeTestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esSqlServerTypeTest
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
		
			Dim query As New SqlServerTypeTestQuery()
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
		' Maps to SqlServerTypeTest.Id
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Id As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.Id, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.ConcurrencyCheck
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ConcurrencyCheck As System.Byte()
			Get
				Return MyBase.GetSystemByteArray(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck)
			End Get
			
			Set(ByVal value As System.Byte())
				If MyBase.SetSystemByteArray(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.ConcurrencyCheck)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.NVarCharType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property NVarCharType As System.String
			Get
				Return MyBase.GetSystemString(SqlServerTypeTestMetadata.ColumnNames.NVarCharType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SqlServerTypeTestMetadata.ColumnNames.NVarCharType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NVarCharType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.NumericType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property NumericType As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.NumericType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.NumericType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NumericType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.RealType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property RealType As Nullable(Of System.Single)
			Get
				Return MyBase.GetSystemSingle(SqlServerTypeTestMetadata.ColumnNames.RealType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Single))
				If MyBase.SetSystemSingle(SqlServerTypeTestMetadata.ColumnNames.RealType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.RealType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.FloatType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property FloatType As Nullable(Of System.Double)
			Get
				Return MyBase.GetSystemDouble(SqlServerTypeTestMetadata.ColumnNames.FloatType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Double))
				If MyBase.SetSystemDouble(SqlServerTypeTestMetadata.ColumnNames.FloatType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.FloatType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.DecimalType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DecimalType As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.DecimalType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(SqlServerTypeTestMetadata.ColumnNames.DecimalType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.DecimalType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.VarCharMaxType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property VarCharMaxType As System.String
			Get
				Return MyBase.GetSystemString(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.VarCharMaxType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.BigIntType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property BigIntType As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.BigIntType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(SqlServerTypeTestMetadata.ColumnNames.BigIntType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.BigIntType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to SqlServerTypeTest.NCharType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property NCharType As Nullable(Of System.Char)
			Get
				Return MyBase.GetSystemChar(SqlServerTypeTestMetadata.ColumnNames.NCharType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Char))
				If MyBase.SetSystemChar(SqlServerTypeTestMetadata.ColumnNames.NCharType, value) Then
					OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NCharType)
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
												
						Case "NVarCharType"
							Me.str().NVarCharType = CType(value, string)
												
						Case "NumericType"
							Me.str().NumericType = CType(value, string)
												
						Case "RealType"
							Me.str().RealType = CType(value, string)
												
						Case "FloatType"
							Me.str().FloatType = CType(value, string)
												
						Case "DecimalType"
							Me.str().DecimalType = CType(value, string)
												
						Case "VarCharMaxType"
							Me.str().VarCharMaxType = CType(value, string)
												
						Case "BigIntType"
							Me.str().BigIntType = CType(value, string)
												
						Case "NCharType"
							Me.str().NCharType = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "Id"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.Id = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.Id)
							End If
						
						Case "ConcurrencyCheck"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Byte()" Then
								Me.ConcurrencyCheck = CType(value, System.Byte())
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.ConcurrencyCheck)
							End If
						
						Case "NumericType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.NumericType = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NumericType)
							End If
						
						Case "RealType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Single" Then
								Me.RealType = CType(value, Nullable(Of System.Single))
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.RealType)
							End If
						
						Case "FloatType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Double" Then
								Me.FloatType = CType(value, Nullable(Of System.Double))
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.FloatType)
							End If
						
						Case "DecimalType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.DecimalType = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.DecimalType)
							End If
						
						Case "BigIntType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.BigIntType = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.BigIntType)
							End If
						
						Case "NCharType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Char" Then
								Me.NCharType = CType(value, Nullable(Of System.Char))
								OnPropertyChanged(SqlServerTypeTestMetadata.PropertyNames.NCharType)
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
		
			Public Sub New(ByVal entity As esSqlServerTypeTest)
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
		  	
			Public Property NVarCharType As System.String 
				Get
					Dim data_ As System.String = entity.NVarCharType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.NVarCharType = Nothing
					Else
						entity.NVarCharType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property NumericType As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.NumericType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.NumericType = Nothing
					Else
						entity.NumericType = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property RealType As System.String 
				Get
					Dim data_ As Nullable(Of System.Single) = entity.RealType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.RealType = Nothing
					Else
						entity.RealType = Convert.ToSingle(Value)
					End If
				End Set
			End Property
		  	
			Public Property FloatType As System.String 
				Get
					Dim data_ As Nullable(Of System.Double) = entity.FloatType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.FloatType = Nothing
					Else
						entity.FloatType = Convert.ToDouble(Value)
					End If
				End Set
			End Property
		  	
			Public Property DecimalType As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.DecimalType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DecimalType = Nothing
					Else
						entity.DecimalType = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property VarCharMaxType As System.String 
				Get
					Dim data_ As System.String = entity.VarCharMaxType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.VarCharMaxType = Nothing
					Else
						entity.VarCharMaxType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property BigIntType As System.String 
				Get
					Dim data_ As Nullable(Of System.Int64) = entity.BigIntType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.BigIntType = Nothing
					Else
						entity.BigIntType = Convert.ToInt64(Value)
					End If
				End Set
			End Property
		  	
			Public Property NCharType As System.String 
				Get
					Dim data_ As Nullable(Of System.Char) = entity.NCharType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.NCharType = Nothing
					Else
						entity.NCharType = Convert.ToChar(Value)
					End If
				End Set
			End Property
		  

			Private entity As esSqlServerTypeTest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return SqlServerTypeTestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As SqlServerTypeTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New SqlServerTypeTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As SqlServerTypeTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As SqlServerTypeTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As SqlServerTypeTestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esSqlServerTypeTestCollection
		Inherits CollectionBase(Of SqlServerTypeTest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return SqlServerTypeTestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "SqlServerTypeTestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As SqlServerTypeTestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New SqlServerTypeTestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As SqlServerTypeTestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New SqlServerTypeTestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As SqlServerTypeTestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, SqlServerTypeTestQuery))
		End Sub
		
		#End Region
						
		Private m_query As SqlServerTypeTestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esSqlServerTypeTestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return SqlServerTypeTestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "ConcurrencyCheck" 
					Return Me.ConcurrencyCheck
				Case "NVarCharType" 
					Return Me.NVarCharType
				Case "NumericType" 
					Return Me.NumericType
				Case "RealType" 
					Return Me.RealType
				Case "FloatType" 
					Return Me.FloatType
				Case "DecimalType" 
					Return Me.DecimalType
				Case "VarCharMaxType" 
					Return Me.VarCharMaxType
				Case "BigIntType" 
					Return Me.BigIntType
				Case "NCharType" 
					Return Me.NCharType
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.Id, esSystemType.Int64)
			End Get
		End Property 
		
		Public ReadOnly Property ConcurrencyCheck As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck, esSystemType.ByteArray)
			End Get
		End Property 
		
		Public ReadOnly Property NVarCharType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.NVarCharType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property NumericType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.NumericType, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property RealType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.RealType, esSystemType.Single)
			End Get
		End Property 
		
		Public ReadOnly Property FloatType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.FloatType, esSystemType.Double)
			End Get
		End Property 
		
		Public ReadOnly Property DecimalType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.DecimalType, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property VarCharMaxType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property BigIntType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.BigIntType, esSystemType.Int64)
			End Get
		End Property 
		
		Public ReadOnly Property NCharType As esQueryItem
			Get
				Return New esQueryItem(Me, SqlServerTypeTestMetadata.ColumnNames.NCharType, esSystemType.Char)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="SqlServerTypeTest")> _
    <XmlType(TypeName:="SqlServerTypeTestProxyStub")> _
    <Serializable> _
    Partial Public Class SqlServerTypeTestProxyStub
	
		Public Sub New()
            Me._entity = New SqlServerTypeTest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As SqlServerTypeTest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As SqlServerTypeTest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As SqlServerTypeTestProxyStub) As SqlServerTypeTest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(SqlServerTypeTest)
        End Function
		

		<DataMember(Name:="Id", Order:=1, EmitDefaultValue:=False)> _		
        Public Property Id As Nullable(Of System.Int64)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(SqlServerTypeTestMetadata.ColumnNames.Id)
					Return CType(o, Nullable(Of System.Int64))
                Else
					Return Me.Entity.Id
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.Id = value
			End Set
			
		End Property

		<DataMember(Name:="ConcurrencyCheck", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ConcurrencyCheck As System.Byte()
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck)
					Return CType(o, System.Byte())
                Else
					Return Me.Entity.ConcurrencyCheck
				End If				
			End Get
			
            Set(ByVal value As System.Byte())
				Me.Entity.ConcurrencyCheck = value
			End Set
			
		End Property

		<DataMember(Name:="NVarCharType", Order:=3, EmitDefaultValue:=False)> _		
        Public Property NVarCharType As System.String
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.NVarCharType) Then
                    Return Me.Entity.NVarCharType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.NVarCharType = value
			End Set
			
		End Property

		<DataMember(Name:="NumericType", Order:=4, EmitDefaultValue:=False)> _		
        Public Property NumericType As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.NumericType) Then
                    Return Me.Entity.NumericType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.NumericType = value
			End Set
			
		End Property

		<DataMember(Name:="RealType", Order:=5, EmitDefaultValue:=False)> _		
        Public Property RealType As Nullable(Of System.Single)
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.RealType) Then
                    Return Me.Entity.RealType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Single))
				Me.Entity.RealType = value
			End Set
			
		End Property

		<DataMember(Name:="FloatType", Order:=6, EmitDefaultValue:=False)> _		
        Public Property FloatType As Nullable(Of System.Double)
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.FloatType) Then
                    Return Me.Entity.FloatType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Double))
				Me.Entity.FloatType = value
			End Set
			
		End Property

		<DataMember(Name:="DecimalType", Order:=7, EmitDefaultValue:=False)> _		
        Public Property DecimalType As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.DecimalType) Then
                    Return Me.Entity.DecimalType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.DecimalType = value
			End Set
			
		End Property

		<DataMember(Name:="VarCharMaxType", Order:=8, EmitDefaultValue:=False)> _		
        Public Property VarCharMaxType As System.String
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType) Then
                    Return Me.Entity.VarCharMaxType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.VarCharMaxType = value
			End Set
			
		End Property

		<DataMember(Name:="BigIntType", Order:=9, EmitDefaultValue:=False)> _		
        Public Property BigIntType As Nullable(Of System.Int64)
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.BigIntType) Then
                    Return Me.Entity.BigIntType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.BigIntType = value
			End Set
			
		End Property

		<DataMember(Name:="NCharType", Order:=10, EmitDefaultValue:=False)> _		
        Public Property NCharType As Nullable(Of System.Char)
        
            Get
                If Me.IncludeColumn(SqlServerTypeTestMetadata.ColumnNames.NCharType) Then
                    Return Me.Entity.NCharType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Char))
				Me.Entity.NCharType = value
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
        Public Property Entity As SqlServerTypeTest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New SqlServerTypeTest()
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
        Public _entity As SqlServerTypeTest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="SqlServerTypeTestCollection")> _
    <XmlType(TypeName:="SqlServerTypeTestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class SqlServerTypeTestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of SqlServerTypeTest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of SqlServerTypeTest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As SqlServerTypeTestCollectionProxyStub) As SqlServerTypeTestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(SqlServerTypeTest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of SqlServerTypeTest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As SqlServerTypeTest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New SqlServerTypeTestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New SqlServerTypeTestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As SqlServerTypeTest In coll.es.DeletedEntities
                    Collection.Add(New SqlServerTypeTestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of SqlServerTypeTestProxyStub)		

        Public Function GetCollection As SqlServerTypeTestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New SqlServerTypeTestCollection()
					
		            Dim proxy As SqlServerTypeTestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As SqlServerTypeTestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class SqlServerTypeTestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.Id, 0, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 19
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.ConcurrencyCheck, 1, GetType(System.Byte()), esSystemType.ByteArray)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.ConcurrencyCheck
			c.CharacterMaxLength = 8
			c.IsComputed = True
			c.IsConcurrency = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.NVarCharType, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.NVarCharType
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.NumericType, 3, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.NumericType
			c.NumericPrecision = 18
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.RealType, 4, GetType(System.Single), esSystemType.Single)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.RealType
			c.NumericPrecision = 7
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.FloatType, 5, GetType(System.Double), esSystemType.Double)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.FloatType
			c.NumericPrecision = 15
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.DecimalType, 6, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.DecimalType
			c.NumericPrecision = 18
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.VarCharMaxType, 7, GetType(System.String), esSystemType.String)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.VarCharMaxType
			c.CharacterMaxLength = 2147483647
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.BigIntType, 8, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.BigIntType
			c.NumericPrecision = 19
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(SqlServerTypeTestMetadata.ColumnNames.NCharType, 9, GetType(System.Char), esSystemType.Char)	
			c.PropertyName = SqlServerTypeTestMetadata.PropertyNames.NCharType
			c.CharacterMaxLength = 1
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As SqlServerTypeTestMetadata
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
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const NVarCharType As String = "NVarCharType"
			 Public Const NumericType As String = "NumericType"
			 Public Const RealType As String = "RealType"
			 Public Const FloatType As String = "FloatType"
			 Public Const DecimalType As String = "DecimalType"
			 Public Const VarCharMaxType As String = "VarCharMaxType"
			 Public Const BigIntType As String = "BigIntType"
			 Public Const NCharType As String = "NCharType"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const ConcurrencyCheck As String = "ConcurrencyCheck"
			 Public Const NVarCharType As String = "NVarCharType"
			 Public Const NumericType As String = "NumericType"
			 Public Const RealType As String = "RealType"
			 Public Const FloatType As String = "FloatType"
			 Public Const DecimalType As String = "DecimalType"
			 Public Const VarCharMaxType As String = "VarCharMaxType"
			 Public Const BigIntType As String = "BigIntType"
			 Public Const NCharType As String = "NCharType"
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
			SyncLock GetType(SqlServerTypeTestMetadata)
			
				If SqlServerTypeTestMetadata.mapDelegates Is Nothing Then
					SqlServerTypeTestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If SqlServerTypeTestMetadata._meta Is Nothing Then
					SqlServerTypeTestMetadata._meta = New SqlServerTypeTestMetadata()
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
				meta.AddTypeMap("ConcurrencyCheck", new esTypeMap("timestamp", "System.Byte()"))
				meta.AddTypeMap("NVarCharType", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("NumericType", new esTypeMap("numeric", "System.Decimal"))
				meta.AddTypeMap("RealType", new esTypeMap("real", "System.Single"))
				meta.AddTypeMap("FloatType", new esTypeMap("float", "System.Double"))
				meta.AddTypeMap("DecimalType", new esTypeMap("decimal", "System.Decimal"))
				meta.AddTypeMap("VarCharMaxType", new esTypeMap("varchar", "System.String"))
				meta.AddTypeMap("BigIntType", new esTypeMap("bigint", "System.Int64"))
				meta.AddTypeMap("NCharType", new esTypeMap("nchar", "System.Char"))			
				meta.Catalog = "AggregateDb"
				meta.Schema = "dbo"
				 
				meta.Source = "SqlServerTypeTest"
				meta.Destination = "SqlServerTypeTest"
				
				meta.spInsert = "proc_SqlServerTypeTestInsert"
				meta.spUpdate = "proc_SqlServerTypeTestUpdate"
				meta.spDelete = "proc_SqlServerTypeTestDelete"
				meta.spLoadAll = "proc_SqlServerTypeTestLoadAll"
				meta.spLoadByPrimaryKey = "proc_SqlServerTypeTestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As SqlServerTypeTestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
