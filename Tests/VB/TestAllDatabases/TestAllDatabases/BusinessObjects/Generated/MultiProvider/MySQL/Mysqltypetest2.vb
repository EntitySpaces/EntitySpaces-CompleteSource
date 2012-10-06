
'===============================================================================
'                   EntitySpaces Studio by EntitySpaces, LLC
'            Persistence Layer and Business Objects for Microsoft .NET
'            EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
'                         http://www.entityspaces.net
'===============================================================================
' EntitySpaces Version : 2012.1.0319.0
' EntitySpaces Driver  : MySql
' Date Generated       : 3/17/2012 4:52:09 AM
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
	' Encapsulates the 'mysqltypetest2' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Mysqltypetest2))> _
	<XmlType("Mysqltypetest2")> _ 
	<Table(Name:="Mysqltypetest2")> _	
	Partial Public Class Mysqltypetest2 
		Inherits esMysqltypetest2
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Mysqltypetest2()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.UInt32)
			Dim obj As New Mysqltypetest2()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.UInt32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Mysqltypetest2()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Mysqltypetest2) As Mysqltypetest2ProxyStub
			Return New Mysqltypetest2ProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Id As Nullable(Of System.UInt32)
			Get
				Return MyBase.Id
			End Get
			Set
				MyBase.Id = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property VarCharType As System.String
			Get
				Return MyBase.VarCharType
			End Get
			Set
				MyBase.VarCharType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property CharType As System.String
			Get
				Return MyBase.CharType
			End Get
			Set
				MyBase.CharType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property TimeStampType As Nullable(Of System.DateTime)
			Get
				Return MyBase.TimeStampType
			End Get
			Set
				MyBase.TimeStampType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DateType As Nullable(Of System.DateTime)
			Get
				Return MyBase.DateType
			End Get
			Set
				MyBase.DateType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DateTimeType As Nullable(Of System.DateTime)
			Get
				Return MyBase.DateTimeType
			End Get
			Set
				MyBase.DateTimeType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property BlobType As System.Byte()
			Get
				Return MyBase.BlobType
			End Get
			Set
				MyBase.BlobType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TextType As System.String
			Get
				Return MyBase.TextType
			End Get
			Set
				MyBase.TextType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TimeType As Nullable(Of System.TimeSpan)
			Get
				Return MyBase.TimeType
			End Get
			Set
				MyBase.TimeType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property LongTextType As System.String
			Get
				Return MyBase.LongTextType
			End Get
			Set
				MyBase.LongTextType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property BinaryType As System.String
			Get
				Return MyBase.BinaryType
			End Get
			Set
				MyBase.BinaryType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property VarBinaryType As System.String
			Get
				Return MyBase.VarBinaryType
			End Get
			Set
				MyBase.VarBinaryType = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("Mysqltypetest2Collection")> _
	Partial Public Class Mysqltypetest2Collection
		Inherits esMysqltypetest2Collection
		Implements IEnumerable(Of Mysqltypetest2)
	
		Public Function FindByPrimaryKey(ByVal id As System.UInt32) As Mysqltypetest2
			Return MyBase.SingleOrDefault(Function(e) e.Id.HasValue AndAlso e.Id.Value = id)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As Mysqltypetest2Collection) As Mysqltypetest2CollectionProxyStub
            Return New Mysqltypetest2CollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Mysqltypetest2))> _
		Public Class Mysqltypetest2CollectionWCFPacket
			Inherits esCollectionWCFPacket(Of Mysqltypetest2Collection)
			
			Public Shared Widening Operator CType(packet As Mysqltypetest2CollectionWCFPacket) As Mysqltypetest2Collection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As Mysqltypetest2Collection) As Mysqltypetest2CollectionWCFPacket
				Return New Mysqltypetest2CollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "Mysqltypetest2Query", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class Mysqltypetest2Query 
		Inherits esMysqltypetest2Query
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "Mysqltypetest2Query"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As Mysqltypetest2Query) As String
			Return Mysqltypetest2Query.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As Mysqltypetest2Query
			Return DirectCast(Mysqltypetest2Query.SerializeHelper.FromXml(query, GetType(Mysqltypetest2Query)), Mysqltypetest2Query)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esMysqltypetest2
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal id As System.UInt32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal id As System.UInt32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(id)
			Else
				Return LoadByPrimaryKeyStoredProcedure(id)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal id As System.UInt32) As Boolean
		
			Dim query As New Mysqltypetest2Query()
			query.Where(query.Id = id)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal id As System.UInt32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("Id", id)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to mysqltypetest2.ID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Id As Nullable(Of System.UInt32)
			Get
				Return MyBase.GetSystemUInt32(Mysqltypetest2Metadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As Nullable(Of System.UInt32))
				If MyBase.SetSystemUInt32(Mysqltypetest2Metadata.ColumnNames.Id, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.VarCharType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property VarCharType As System.String
			Get
				Return MyBase.GetSystemString(Mysqltypetest2Metadata.ColumnNames.VarCharType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(Mysqltypetest2Metadata.ColumnNames.VarCharType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.VarCharType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.CharType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CharType As System.String
			Get
				Return MyBase.GetSystemString(Mysqltypetest2Metadata.ColumnNames.CharType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(Mysqltypetest2Metadata.ColumnNames.CharType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.CharType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.TimeStampType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TimeStampType As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.TimeStampType)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.TimeStampType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeStampType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.DateType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DateType As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateType)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.DateTimeType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DateTimeType As Nullable(Of System.DateTime)
			Get
				Return MyBase.GetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateTimeType)
			End Get
			
			Set(ByVal value As Nullable(Of System.DateTime))
				If MyBase.SetSystemDateTime(Mysqltypetest2Metadata.ColumnNames.DateTimeType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateTimeType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.BlobType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property BlobType As System.Byte()
			Get
				Return MyBase.GetSystemByteArray(Mysqltypetest2Metadata.ColumnNames.BlobType)
			End Get
			
			Set(ByVal value As System.Byte())
				If MyBase.SetSystemByteArray(Mysqltypetest2Metadata.ColumnNames.BlobType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.BlobType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.TextType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TextType As System.String
			Get
				Return MyBase.GetSystemString(Mysqltypetest2Metadata.ColumnNames.TextType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(Mysqltypetest2Metadata.ColumnNames.TextType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TextType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.TimeType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TimeType As Nullable(Of System.TimeSpan)
			Get
				Return MyBase.GetSystemTimeSpan(Mysqltypetest2Metadata.ColumnNames.TimeType)
			End Get
			
			Set(ByVal value As Nullable(Of System.TimeSpan))
				If MyBase.SetSystemTimeSpan(Mysqltypetest2Metadata.ColumnNames.TimeType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.LongTextType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property LongTextType As System.String
			Get
				Return MyBase.GetSystemString(Mysqltypetest2Metadata.ColumnNames.LongTextType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(Mysqltypetest2Metadata.ColumnNames.LongTextType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.LongTextType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.BinaryType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property BinaryType As System.String
			Get
				Return MyBase.GetSystemString(Mysqltypetest2Metadata.ColumnNames.BinaryType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(Mysqltypetest2Metadata.ColumnNames.BinaryType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.BinaryType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest2.VarBinaryType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property VarBinaryType As System.String
			Get
				Return MyBase.GetSystemString(Mysqltypetest2Metadata.ColumnNames.VarBinaryType)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(Mysqltypetest2Metadata.ColumnNames.VarBinaryType, value) Then
					OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.VarBinaryType)
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
												
						Case "VarCharType"
							Me.str().VarCharType = CType(value, string)
												
						Case "CharType"
							Me.str().CharType = CType(value, string)
												
						Case "TimeStampType"
							Me.str().TimeStampType = CType(value, string)
												
						Case "DateType"
							Me.str().DateType = CType(value, string)
												
						Case "DateTimeType"
							Me.str().DateTimeType = CType(value, string)
												
						Case "TextType"
							Me.str().TextType = CType(value, string)
												
						Case "TimeType"
							Me.str().TimeType = CType(value, string)
												
						Case "LongTextType"
							Me.str().LongTextType = CType(value, string)
												
						Case "BinaryType"
							Me.str().BinaryType = CType(value, string)
												
						Case "VarBinaryType"
							Me.str().VarBinaryType = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "Id"
						
							If value Is Nothing Or value.GetType().ToString() = "System.UInt32" Then
								Me.Id = CType(value, Nullable(Of System.UInt32))
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.Id)
							End If
						
						Case "TimeStampType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.TimeStampType = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeStampType)
							End If
						
						Case "DateType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.DateType = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateType)
							End If
						
						Case "DateTimeType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.DateTime" Then
								Me.DateTimeType = CType(value, Nullable(Of System.DateTime))
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.DateTimeType)
							End If
						
						Case "BlobType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Byte()" Then
								Me.BlobType = CType(value, System.Byte())
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.BlobType)
							End If
						
						Case "TimeType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.TimeSpan" Then
								Me.TimeType = CType(value, Nullable(Of System.TimeSpan))
								OnPropertyChanged(Mysqltypetest2Metadata.PropertyNames.TimeType)
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
		
			Public Sub New(ByVal entity As esMysqltypetest2)
				Me.entity = entity
			End Sub				
		
	
			Public Property Id As System.String 
				Get
					Dim data_ As Nullable(Of System.UInt32) = entity.Id
					
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
						entity.Id = Convert.ToUInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property VarCharType As System.String 
				Get
					Dim data_ As System.String = entity.VarCharType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.VarCharType = Nothing
					Else
						entity.VarCharType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property CharType As System.String 
				Get
					Dim data_ As System.String = entity.CharType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CharType = Nothing
					Else
						entity.CharType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property TimeStampType As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.TimeStampType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TimeStampType = Nothing
					Else
						entity.TimeStampType = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property DateType As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.DateType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DateType = Nothing
					Else
						entity.DateType = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property DateTimeType As System.String 
				Get
					Dim data_ As Nullable(Of System.DateTime) = entity.DateTimeType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DateTimeType = Nothing
					Else
						entity.DateTimeType = Convert.ToDateTime(Value)
					End If
				End Set
			End Property
		  	
			Public Property TextType As System.String 
				Get
					Dim data_ As System.String = entity.TextType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TextType = Nothing
					Else
						entity.TextType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property TimeType As System.String 
				Get
					Dim data_ As Nullable(Of System.TimeSpan) = entity.TimeType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return data_.ToString()
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TimeType = Nothing
					Else
						entity.TimeType = TimeSpan.Parse(Value)
					End If
				End Set
			End Property
		  	
			Public Property LongTextType As System.String 
				Get
					Dim data_ As System.String = entity.LongTextType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.LongTextType = Nothing
					Else
						entity.LongTextType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property BinaryType As System.String 
				Get
					Dim data_ As System.String = entity.BinaryType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.BinaryType = Nothing
					Else
						entity.BinaryType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property VarBinaryType As System.String 
				Get
					Dim data_ As System.String = entity.VarBinaryType
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.VarBinaryType = Nothing
					Else
						entity.VarBinaryType = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esMysqltypetest2
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return Mysqltypetest2Metadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As Mysqltypetest2Query
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New Mysqltypetest2Query()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As Mysqltypetest2Query) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As Mysqltypetest2Query)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As Mysqltypetest2Query

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esMysqltypetest2Collection
		Inherits CollectionBase(Of Mysqltypetest2)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return Mysqltypetest2Metadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "Mysqltypetest2Collection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As Mysqltypetest2Query
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New Mysqltypetest2Query()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As Mysqltypetest2Query) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New Mysqltypetest2Query()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As Mysqltypetest2Query)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, Mysqltypetest2Query))
		End Sub
		
		#End Region
						
		Private m_query As Mysqltypetest2Query
	End Class



	<Serializable> _
	MustInherit Public Partial Class esMysqltypetest2Query 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return Mysqltypetest2Metadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "VarCharType" 
					Return Me.VarCharType
				Case "CharType" 
					Return Me.CharType
				Case "TimeStampType" 
					Return Me.TimeStampType
				Case "DateType" 
					Return Me.DateType
				Case "DateTimeType" 
					Return Me.DateTimeType
				Case "BlobType" 
					Return Me.BlobType
				Case "TextType" 
					Return Me.TextType
				Case "TimeType" 
					Return Me.TimeType
				Case "LongTextType" 
					Return Me.LongTextType
				Case "BinaryType" 
					Return Me.BinaryType
				Case "VarBinaryType" 
					Return Me.VarBinaryType
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.Id, esSystemType.UInt32)
			End Get
		End Property 
		
		Public ReadOnly Property VarCharType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.VarCharType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CharType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.CharType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TimeStampType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.TimeStampType, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property DateType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.DateType, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property DateTimeType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.DateTimeType, esSystemType.DateTime)
			End Get
		End Property 
		
		Public ReadOnly Property BlobType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.BlobType, esSystemType.ByteArray)
			End Get
		End Property 
		
		Public ReadOnly Property TextType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.TextType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property TimeType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.TimeType, esSystemType.TimeSpan)
			End Get
		End Property 
		
		Public ReadOnly Property LongTextType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.LongTextType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property BinaryType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.BinaryType, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property VarBinaryType As esQueryItem
			Get
				Return New esQueryItem(Me, Mysqltypetest2Metadata.ColumnNames.VarBinaryType, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="Mysqltypetest2")> _
    <XmlType(TypeName:="Mysqltypetest2ProxyStub")> _
    <Serializable> _
    Partial Public Class Mysqltypetest2ProxyStub
	
		Public Sub New()
            Me._entity = New Mysqltypetest2()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Mysqltypetest2)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Mysqltypetest2, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Mysqltypetest2ProxyStub) As Mysqltypetest2
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Mysqltypetest2)
        End Function
		

		<DataMember(Name:="Id", Order:=0, EmitDefaultValue:=False)> _		
        Public Property Id As Nullable(Of System.UInt32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(Mysqltypetest2Metadata.ColumnNames.Id)
					Return CType(o, Nullable(Of System.UInt32))
                Else
					Return Me.Entity.Id
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.UInt32))
				Me.Entity.Id = value
			End Set
			
		End Property

		<DataMember(Name:="VarCharType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property VarCharType As System.String
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.VarCharType) Then
                    Return Me.Entity.VarCharType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.VarCharType = value
			End Set
			
		End Property

		<DataMember(Name:="CharType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property CharType As System.String
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.CharType) Then
                    Return Me.Entity.CharType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CharType = value
			End Set
			
		End Property

		<DataMember(Name:="TimeStampType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property TimeStampType As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.TimeStampType) Then
                    Return Me.Entity.TimeStampType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.TimeStampType = value
			End Set
			
		End Property

		<DataMember(Name:="DateType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property DateType As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.DateType) Then
                    Return Me.Entity.DateType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.DateType = value
			End Set
			
		End Property

		<DataMember(Name:="DateTimeType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property DateTimeType As Nullable(Of System.DateTime)
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.DateTimeType) Then
                    Return Me.Entity.DateTimeType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.DateTime))
				Me.Entity.DateTimeType = value
			End Set
			
		End Property

		<DataMember(Name:="BlobType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property BlobType As System.Byte()
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.BlobType) Then
                    Return Me.Entity.BlobType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.Byte())
				Me.Entity.BlobType = value
			End Set
			
		End Property

		<DataMember(Name:="TextType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property TextType As System.String
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.TextType) Then
                    Return Me.Entity.TextType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.TextType = value
			End Set
			
		End Property

		<DataMember(Name:="TimeType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property TimeType As Nullable(Of System.TimeSpan)
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.TimeType) Then
                    Return Me.Entity.TimeType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.TimeSpan))
				Me.Entity.TimeType = value
			End Set
			
		End Property

		<DataMember(Name:="LongTextType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property LongTextType As System.String
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.LongTextType) Then
                    Return Me.Entity.LongTextType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.LongTextType = value
			End Set
			
		End Property

		<DataMember(Name:="BinaryType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property BinaryType As System.String
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.BinaryType) Then
                    Return Me.Entity.BinaryType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.BinaryType = value
			End Set
			
		End Property

		<DataMember(Name:="VarBinaryType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property VarBinaryType As System.String
        
            Get
                If Me.IncludeColumn(Mysqltypetest2Metadata.ColumnNames.VarBinaryType) Then
                    Return Me.Entity.VarBinaryType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.VarBinaryType = value
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
        Public Property Entity As Mysqltypetest2
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Mysqltypetest2()
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
        Public _entity As Mysqltypetest2
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="Mysqltypetest2Collection")> _
    <XmlType(TypeName:="Mysqltypetest2CollectionProxyStub")> _
    <Serializable> _
    Partial Public Class Mysqltypetest2CollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Mysqltypetest2))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Mysqltypetest2), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As Mysqltypetest2CollectionProxyStub) As Mysqltypetest2Collection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Mysqltypetest2)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Mysqltypetest2), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Mysqltypetest2 In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New Mysqltypetest2ProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New Mysqltypetest2ProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Mysqltypetest2 In coll.es.DeletedEntities
                    Collection.Add(New Mysqltypetest2ProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of Mysqltypetest2ProxyStub)		

        Public Function GetCollection As Mysqltypetest2Collection
			
                If Me._coll is Nothing Then
                    Me._coll = New Mysqltypetest2Collection()
					
		            Dim proxy As Mysqltypetest2ProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As Mysqltypetest2Collection
		
    End Class
	



	<Serializable> _
	Partial Public Class Mysqltypetest2Metadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.Id, 0, GetType(System.UInt32), esSystemType.UInt32)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.VarCharType, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.VarCharType
			c.CharacterMaxLength = 20
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.CharType, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.CharType
			c.CharacterMaxLength = 1
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.TimeStampType, 3, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.TimeStampType
			c.HasDefault = True
			c.Default = "CURRENT_TIMESTAMP"
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.DateType, 4, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.DateType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.DateTimeType, 5, GetType(System.DateTime), esSystemType.DateTime)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.DateTimeType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.BlobType, 6, GetType(System.Byte()), esSystemType.ByteArray)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.BlobType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.TextType, 7, GetType(System.String), esSystemType.String)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.TextType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.TimeType, 8, GetType(System.TimeSpan), esSystemType.TimeSpan)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.TimeType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.LongTextType, 9, GetType(System.String), esSystemType.String)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.LongTextType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.BinaryType, 10, GetType(System.String), esSystemType.String)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.BinaryType
			c.NumericPrecision = 50
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(Mysqltypetest2Metadata.ColumnNames.VarBinaryType, 11, GetType(System.String), esSystemType.String)	
			c.PropertyName = Mysqltypetest2Metadata.PropertyNames.VarBinaryType
			c.NumericPrecision = 50
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As Mysqltypetest2Metadata
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
			 Public Const VarCharType As String = "VarCharType"
			 Public Const CharType As String = "CharType"
			 Public Const TimeStampType As String = "TimeStampType"
			 Public Const DateType As String = "DateType"
			 Public Const DateTimeType As String = "DateTimeType"
			 Public Const BlobType As String = "BlobType"
			 Public Const TextType As String = "TextType"
			 Public Const TimeType As String = "TimeType"
			 Public Const LongTextType As String = "LongTextType"
			 Public Const BinaryType As String = "BinaryType"
			 Public Const VarBinaryType As String = "VarBinaryType"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const VarCharType As String = "VarCharType"
			 Public Const CharType As String = "CharType"
			 Public Const TimeStampType As String = "TimeStampType"
			 Public Const DateType As String = "DateType"
			 Public Const DateTimeType As String = "DateTimeType"
			 Public Const BlobType As String = "BlobType"
			 Public Const TextType As String = "TextType"
			 Public Const TimeType As String = "TimeType"
			 Public Const LongTextType As String = "LongTextType"
			 Public Const BinaryType As String = "BinaryType"
			 Public Const VarBinaryType As String = "VarBinaryType"
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
			SyncLock GetType(Mysqltypetest2Metadata)
			
				If Mysqltypetest2Metadata.mapDelegates Is Nothing Then
					Mysqltypetest2Metadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If Mysqltypetest2Metadata._meta Is Nothing Then
					Mysqltypetest2Metadata._meta = New Mysqltypetest2Metadata()
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
				


				meta.AddTypeMap("Id", new esTypeMap("INT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("VarCharType", new esTypeMap("VARCHAR", "System.String"))
				meta.AddTypeMap("CharType", new esTypeMap("CHAR", "System.String"))
				meta.AddTypeMap("TimeStampType", new esTypeMap("TIMESTAMP", "System.DateTime"))
				meta.AddTypeMap("DateType", new esTypeMap("DATE", "System.DateTime"))
				meta.AddTypeMap("DateTimeType", new esTypeMap("DATETIME", "System.DateTime"))
				meta.AddTypeMap("BlobType", new esTypeMap("BLOB", "System.Byte()"))
				meta.AddTypeMap("TextType", new esTypeMap("TEXT", "System.String"))
				meta.AddTypeMap("TimeType", new esTypeMap("TIME", "System.TimeSpan"))
				meta.AddTypeMap("LongTextType", new esTypeMap("LONGTEXT", "System.String"))
				meta.AddTypeMap("BinaryType", new esTypeMap("BINARY", "System.String"))
				meta.AddTypeMap("VarBinaryType", new esTypeMap("VARBINARY", "System.String"))			
				meta.Catalog = "aggregatedb"
				
				 
				meta.Source = "mysqltypetest2"
				meta.Destination = "mysqltypetest2"
				
				meta.spInsert = "proc_mysqltypetest2Insert"
				meta.spUpdate = "proc_mysqltypetest2Update"
				meta.spDelete = "proc_mysqltypetest2Delete"
				meta.spLoadAll = "proc_mysqltypetest2LoadAll"
				meta.spLoadByPrimaryKey = "proc_mysqltypetest2LoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As Mysqltypetest2Metadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
