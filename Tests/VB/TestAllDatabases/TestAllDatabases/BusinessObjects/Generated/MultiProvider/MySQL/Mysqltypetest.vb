
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
	' Encapsulates the 'mysqltypetest' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Mysqltypetest))> _
	<XmlType("Mysqltypetest")> _ 
	<Table(Name:="Mysqltypetest")> _	
	Partial Public Class Mysqltypetest 
		Inherits esMysqltypetest
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Mysqltypetest()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal id As System.Int32)
			Dim obj As New Mysqltypetest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal id As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Mysqltypetest()
			obj.Id = id
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Mysqltypetest) As MysqltypetestProxyStub
			Return New MysqltypetestProxyStub(entity)
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
		Public Overrides Property IntType As Nullable(Of System.Int32)
			Get
				Return MyBase.IntType
			End Get
			Set
				MyBase.IntType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property MedIntType As Nullable(Of System.Int32)
			Get
				Return MyBase.MedIntType
			End Get
			Set
				MyBase.MedIntType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property SmallIntType As Nullable(Of System.Int16)
			Get
				Return MyBase.SmallIntType
			End Get
			Set
				MyBase.SmallIntType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TinyIntType As Nullable(Of System.SByte)
			Get
				Return MyBase.TinyIntType
			End Get
			Set
				MyBase.TinyIntType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property BigIntUType As Nullable(Of System.UInt64)
			Get
				Return MyBase.BigIntUType
			End Get
			Set
				MyBase.BigIntUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property IntUType As Nullable(Of System.UInt32)
			Get
				Return MyBase.IntUType
			End Get
			Set
				MyBase.IntUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property MedIntUType As Nullable(Of System.UInt32)
			Get
				Return MyBase.MedIntUType
			End Get
			Set
				MyBase.MedIntUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property SmallIntUType As Nullable(Of System.UInt16)
			Get
				Return MyBase.SmallIntUType
			End Get
			Set
				MyBase.SmallIntUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property TinyIntUType As Nullable(Of System.Byte)
			Get
				Return MyBase.TinyIntUType
			End Get
			Set
				MyBase.TinyIntUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property FloatType As Nullable(Of System.Single)
			Get
				Return MyBase.FloatType
			End Get
			Set
				MyBase.FloatType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property FloatUType As Nullable(Of System.Single)
			Get
				Return MyBase.FloatUType
			End Get
			Set
				MyBase.FloatUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DecType As Nullable(Of System.Decimal)
			Get
				Return MyBase.DecType
			End Get
			Set
				MyBase.DecType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DecUType As Nullable(Of System.Decimal)
			Get
				Return MyBase.DecUType
			End Get
			Set
				MyBase.DecUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property NumType As Nullable(Of System.Decimal)
			Get
				Return MyBase.NumType
			End Get
			Set
				MyBase.NumType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property NumUType As Nullable(Of System.Decimal)
			Get
				Return MyBase.NumUType
			End Get
			Set
				MyBase.NumUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DblType As Nullable(Of System.Double)
			Get
				Return MyBase.DblType
			End Get
			Set
				MyBase.DblType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property DblUType As Nullable(Of System.Double)
			Get
				Return MyBase.DblUType
			End Get
			Set
				MyBase.DblUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property RealType As Nullable(Of System.Double)
			Get
				Return MyBase.RealType
			End Get
			Set
				MyBase.RealType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property RealUType As Nullable(Of System.Double)
			Get
				Return MyBase.RealUType
			End Get
			Set
				MyBase.RealUType = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property BitType As Nullable(Of System.SByte)
			Get
				Return MyBase.BitType
			End Get
			Set
				MyBase.BitType = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("MysqltypetestCollection")> _
	Partial Public Class MysqltypetestCollection
		Inherits esMysqltypetestCollection
		Implements IEnumerable(Of Mysqltypetest)
	
		Public Function FindByPrimaryKey(ByVal id As System.Int32) As Mysqltypetest
			Return MyBase.SingleOrDefault(Function(e) e.Id.HasValue AndAlso e.Id.Value = id)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As MysqltypetestCollection) As MysqltypetestCollectionProxyStub
            Return New MysqltypetestCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Mysqltypetest))> _
		Public Class MysqltypetestCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of MysqltypetestCollection)
			
			Public Shared Widening Operator CType(packet As MysqltypetestCollectionWCFPacket) As MysqltypetestCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As MysqltypetestCollection) As MysqltypetestCollectionWCFPacket
				Return New MysqltypetestCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "MysqltypetestQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class MysqltypetestQuery 
		Inherits esMysqltypetestQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "MysqltypetestQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As MysqltypetestQuery) As String
			Return MysqltypetestQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As MysqltypetestQuery
			Return DirectCast(MysqltypetestQuery.SerializeHelper.FromXml(query, GetType(MysqltypetestQuery)), MysqltypetestQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esMysqltypetest
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
		
			Dim query As New MysqltypetestQuery()
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
		' Maps to mysqltypetest.ID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Id As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(MysqltypetestMetadata.ColumnNames.Id)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(MysqltypetestMetadata.ColumnNames.Id, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.Id)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.BigIntType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property BigIntType As Nullable(Of System.Int64)
			Get
				Return MyBase.GetSystemInt64(MysqltypetestMetadata.ColumnNames.BigIntType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int64))
				If MyBase.SetSystemInt64(MysqltypetestMetadata.ColumnNames.BigIntType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.IntType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property IntType As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(MysqltypetestMetadata.ColumnNames.IntType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(MysqltypetestMetadata.ColumnNames.IntType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.MedIntType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property MedIntType As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(MysqltypetestMetadata.ColumnNames.MedIntType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(MysqltypetestMetadata.ColumnNames.MedIntType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.SmallIntType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property SmallIntType As Nullable(Of System.Int16)
			Get
				Return MyBase.GetSystemInt16(MysqltypetestMetadata.ColumnNames.SmallIntType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int16))
				If MyBase.SetSystemInt16(MysqltypetestMetadata.ColumnNames.SmallIntType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.TinyIntType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TinyIntType As Nullable(Of System.SByte)
			Get
				Return MyBase.GetSystemSByte(MysqltypetestMetadata.ColumnNames.TinyIntType)
			End Get
			
			Set(ByVal value As Nullable(Of System.SByte))
				If MyBase.SetSystemSByte(MysqltypetestMetadata.ColumnNames.TinyIntType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.BigIntUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property BigIntUType As Nullable(Of System.UInt64)
			Get
				Return MyBase.GetSystemUInt64(MysqltypetestMetadata.ColumnNames.BigIntUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.UInt64))
				If MyBase.SetSystemUInt64(MysqltypetestMetadata.ColumnNames.BigIntUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.IntUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property IntUType As Nullable(Of System.UInt32)
			Get
				Return MyBase.GetSystemUInt32(MysqltypetestMetadata.ColumnNames.IntUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.UInt32))
				If MyBase.SetSystemUInt32(MysqltypetestMetadata.ColumnNames.IntUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.MedIntUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property MedIntUType As Nullable(Of System.UInt32)
			Get
				Return MyBase.GetSystemUInt32(MysqltypetestMetadata.ColumnNames.MedIntUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.UInt32))
				If MyBase.SetSystemUInt32(MysqltypetestMetadata.ColumnNames.MedIntUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.SmallIntUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property SmallIntUType As Nullable(Of System.UInt16)
			Get
				Return MyBase.GetSystemUInt16(MysqltypetestMetadata.ColumnNames.SmallIntUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.UInt16))
				If MyBase.SetSystemUInt16(MysqltypetestMetadata.ColumnNames.SmallIntUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.TinyIntUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TinyIntUType As Nullable(Of System.Byte)
			Get
				Return MyBase.GetSystemByte(MysqltypetestMetadata.ColumnNames.TinyIntUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Byte))
				If MyBase.SetSystemByte(MysqltypetestMetadata.ColumnNames.TinyIntUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.FloatType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property FloatType As Nullable(Of System.Single)
			Get
				Return MyBase.GetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Single))
				If MyBase.SetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.FloatUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property FloatUType As Nullable(Of System.Single)
			Get
				Return MyBase.GetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Single))
				If MyBase.SetSystemSingle(MysqltypetestMetadata.ColumnNames.FloatUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.DecType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DecType As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.DecUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DecUType As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.DecUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.NumType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property NumType As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.NumUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property NumUType As Nullable(Of System.Decimal)
			Get
				Return MyBase.GetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Decimal))
				If MyBase.SetSystemDecimal(MysqltypetestMetadata.ColumnNames.NumUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.DblType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DblType As Nullable(Of System.Double)
			Get
				Return MyBase.GetSystemDouble(MysqltypetestMetadata.ColumnNames.DblType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Double))
				If MyBase.SetSystemDouble(MysqltypetestMetadata.ColumnNames.DblType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.DblUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property DblUType As Nullable(Of System.Double)
			Get
				Return MyBase.GetSystemDouble(MysqltypetestMetadata.ColumnNames.DblUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Double))
				If MyBase.SetSystemDouble(MysqltypetestMetadata.ColumnNames.DblUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.RealType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property RealType As Nullable(Of System.Double)
			Get
				Return MyBase.GetSystemDouble(MysqltypetestMetadata.ColumnNames.RealType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Double))
				If MyBase.SetSystemDouble(MysqltypetestMetadata.ColumnNames.RealType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.RealUType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property RealUType As Nullable(Of System.Double)
			Get
				Return MyBase.GetSystemDouble(MysqltypetestMetadata.ColumnNames.RealUType)
			End Get
			
			Set(ByVal value As Nullable(Of System.Double))
				If MyBase.SetSystemDouble(MysqltypetestMetadata.ColumnNames.RealUType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealUType)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to mysqltypetest.BitType
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property BitType As Nullable(Of System.SByte)
			Get
				Return MyBase.GetSystemSByte(MysqltypetestMetadata.ColumnNames.BitType)
			End Get
			
			Set(ByVal value As Nullable(Of System.SByte))
				If MyBase.SetSystemSByte(MysqltypetestMetadata.ColumnNames.BitType, value) Then
					OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BitType)
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
												
						Case "BigIntType"
							Me.str().BigIntType = CType(value, string)
												
						Case "IntType"
							Me.str().IntType = CType(value, string)
												
						Case "MedIntType"
							Me.str().MedIntType = CType(value, string)
												
						Case "SmallIntType"
							Me.str().SmallIntType = CType(value, string)
												
						Case "TinyIntType"
							Me.str().TinyIntType = CType(value, string)
												
						Case "BigIntUType"
							Me.str().BigIntUType = CType(value, string)
												
						Case "IntUType"
							Me.str().IntUType = CType(value, string)
												
						Case "MedIntUType"
							Me.str().MedIntUType = CType(value, string)
												
						Case "SmallIntUType"
							Me.str().SmallIntUType = CType(value, string)
												
						Case "TinyIntUType"
							Me.str().TinyIntUType = CType(value, string)
												
						Case "FloatType"
							Me.str().FloatType = CType(value, string)
												
						Case "FloatUType"
							Me.str().FloatUType = CType(value, string)
												
						Case "DecType"
							Me.str().DecType = CType(value, string)
												
						Case "DecUType"
							Me.str().DecUType = CType(value, string)
												
						Case "NumType"
							Me.str().NumType = CType(value, string)
												
						Case "NumUType"
							Me.str().NumUType = CType(value, string)
												
						Case "DblType"
							Me.str().DblType = CType(value, string)
												
						Case "DblUType"
							Me.str().DblUType = CType(value, string)
												
						Case "RealType"
							Me.str().RealType = CType(value, string)
												
						Case "RealUType"
							Me.str().RealUType = CType(value, string)
												
						Case "BitType"
							Me.str().BitType = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "Id"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Id = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.Id)
							End If
						
						Case "BigIntType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int64" Then
								Me.BigIntType = CType(value, Nullable(Of System.Int64))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntType)
							End If
						
						Case "IntType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.IntType = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntType)
							End If
						
						Case "MedIntType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.MedIntType = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntType)
							End If
						
						Case "SmallIntType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int16" Then
								Me.SmallIntType = CType(value, Nullable(Of System.Int16))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntType)
							End If
						
						Case "TinyIntType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.SByte" Then
								Me.TinyIntType = CType(value, Nullable(Of System.SByte))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntType)
							End If
						
						Case "BigIntUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.UInt64" Then
								Me.BigIntUType = CType(value, Nullable(Of System.UInt64))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BigIntUType)
							End If
						
						Case "IntUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.UInt32" Then
								Me.IntUType = CType(value, Nullable(Of System.UInt32))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.IntUType)
							End If
						
						Case "MedIntUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.UInt32" Then
								Me.MedIntUType = CType(value, Nullable(Of System.UInt32))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.MedIntUType)
							End If
						
						Case "SmallIntUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.UInt16" Then
								Me.SmallIntUType = CType(value, Nullable(Of System.UInt16))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.SmallIntUType)
							End If
						
						Case "TinyIntUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Byte" Then
								Me.TinyIntUType = CType(value, Nullable(Of System.Byte))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.TinyIntUType)
							End If
						
						Case "FloatType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Single" Then
								Me.FloatType = CType(value, Nullable(Of System.Single))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatType)
							End If
						
						Case "FloatUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Single" Then
								Me.FloatUType = CType(value, Nullable(Of System.Single))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.FloatUType)
							End If
						
						Case "DecType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.DecType = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecType)
							End If
						
						Case "DecUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.DecUType = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DecUType)
							End If
						
						Case "NumType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.NumType = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumType)
							End If
						
						Case "NumUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Decimal" Then
								Me.NumUType = CType(value, Nullable(Of System.Decimal))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.NumUType)
							End If
						
						Case "DblType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Double" Then
								Me.DblType = CType(value, Nullable(Of System.Double))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblType)
							End If
						
						Case "DblUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Double" Then
								Me.DblUType = CType(value, Nullable(Of System.Double))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.DblUType)
							End If
						
						Case "RealType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Double" Then
								Me.RealType = CType(value, Nullable(Of System.Double))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealType)
							End If
						
						Case "RealUType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Double" Then
								Me.RealUType = CType(value, Nullable(Of System.Double))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.RealUType)
							End If
						
						Case "BitType"
						
							If value Is Nothing Or value.GetType().ToString() = "System.SByte" Then
								Me.BitType = CType(value, Nullable(Of System.SByte))
								OnPropertyChanged(MysqltypetestMetadata.PropertyNames.BitType)
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
		
			Public Sub New(ByVal entity As esMysqltypetest)
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
		  	
			Public Property IntType As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.IntType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.IntType = Nothing
					Else
						entity.IntType = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property MedIntType As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.MedIntType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.MedIntType = Nothing
					Else
						entity.MedIntType = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property SmallIntType As System.String 
				Get
					Dim data_ As Nullable(Of System.Int16) = entity.SmallIntType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.SmallIntType = Nothing
					Else
						entity.SmallIntType = Convert.ToInt16(Value)
					End If
				End Set
			End Property
		  	
			Public Property TinyIntType As System.String 
				Get
					Dim data_ As Nullable(Of System.SByte) = entity.TinyIntType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TinyIntType = Nothing
					Else
						entity.TinyIntType = Convert.ToSByte(Value)
					End If
				End Set
			End Property
		  	
			Public Property BigIntUType As System.String 
				Get
					Dim data_ As Nullable(Of System.UInt64) = entity.BigIntUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.BigIntUType = Nothing
					Else
						entity.BigIntUType = Convert.ToUInt64(Value)
					End If
				End Set
			End Property
		  	
			Public Property IntUType As System.String 
				Get
					Dim data_ As Nullable(Of System.UInt32) = entity.IntUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.IntUType = Nothing
					Else
						entity.IntUType = Convert.ToUInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property MedIntUType As System.String 
				Get
					Dim data_ As Nullable(Of System.UInt32) = entity.MedIntUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.MedIntUType = Nothing
					Else
						entity.MedIntUType = Convert.ToUInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property SmallIntUType As System.String 
				Get
					Dim data_ As Nullable(Of System.UInt16) = entity.SmallIntUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.SmallIntUType = Nothing
					Else
						entity.SmallIntUType = Convert.ToUInt16(Value)
					End If
				End Set
			End Property
		  	
			Public Property TinyIntUType As System.String 
				Get
					Dim data_ As Nullable(Of System.Byte) = entity.TinyIntUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TinyIntUType = Nothing
					Else
						entity.TinyIntUType = Convert.ToByte(Value)
					End If
				End Set
			End Property
		  	
			Public Property FloatType As System.String 
				Get
					Dim data_ As Nullable(Of System.Single) = entity.FloatType
					
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
						entity.FloatType = Convert.ToSingle(Value)
					End If
				End Set
			End Property
		  	
			Public Property FloatUType As System.String 
				Get
					Dim data_ As Nullable(Of System.Single) = entity.FloatUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.FloatUType = Nothing
					Else
						entity.FloatUType = Convert.ToSingle(Value)
					End If
				End Set
			End Property
		  	
			Public Property DecType As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.DecType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DecType = Nothing
					Else
						entity.DecType = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property DecUType As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.DecUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DecUType = Nothing
					Else
						entity.DecUType = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property NumType As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.NumType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.NumType = Nothing
					Else
						entity.NumType = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property NumUType As System.String 
				Get
					Dim data_ As Nullable(Of System.Decimal) = entity.NumUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.NumUType = Nothing
					Else
						entity.NumUType = Convert.ToDecimal(Value)
					End If
				End Set
			End Property
		  	
			Public Property DblType As System.String 
				Get
					Dim data_ As Nullable(Of System.Double) = entity.DblType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DblType = Nothing
					Else
						entity.DblType = Convert.ToDouble(Value)
					End If
				End Set
			End Property
		  	
			Public Property DblUType As System.String 
				Get
					Dim data_ As Nullable(Of System.Double) = entity.DblUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.DblUType = Nothing
					Else
						entity.DblUType = Convert.ToDouble(Value)
					End If
				End Set
			End Property
		  	
			Public Property RealType As System.String 
				Get
					Dim data_ As Nullable(Of System.Double) = entity.RealType
					
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
						entity.RealType = Convert.ToDouble(Value)
					End If
				End Set
			End Property
		  	
			Public Property RealUType As System.String 
				Get
					Dim data_ As Nullable(Of System.Double) = entity.RealUType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.RealUType = Nothing
					Else
						entity.RealUType = Convert.ToDouble(Value)
					End If
				End Set
			End Property
		  	
			Public Property BitType As System.String 
				Get
					Dim data_ As Nullable(Of System.SByte) = entity.BitType
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.BitType = Nothing
					Else
						entity.BitType = Convert.ToSByte(Value)
					End If
				End Set
			End Property
		  

			Private entity As esMysqltypetest
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return MysqltypetestMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As MysqltypetestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New MysqltypetestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As MysqltypetestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As MysqltypetestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As MysqltypetestQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esMysqltypetestCollection
		Inherits CollectionBase(Of Mysqltypetest)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return MysqltypetestMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "MysqltypetestCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As MysqltypetestQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New MysqltypetestQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As MysqltypetestQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New MysqltypetestQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As MysqltypetestQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, MysqltypetestQuery))
		End Sub
		
		#End Region
						
		Private m_query As MysqltypetestQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esMysqltypetestQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return MysqltypetestMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Id" 
					Return Me.Id
				Case "BigIntType" 
					Return Me.BigIntType
				Case "IntType" 
					Return Me.IntType
				Case "MedIntType" 
					Return Me.MedIntType
				Case "SmallIntType" 
					Return Me.SmallIntType
				Case "TinyIntType" 
					Return Me.TinyIntType
				Case "BigIntUType" 
					Return Me.BigIntUType
				Case "IntUType" 
					Return Me.IntUType
				Case "MedIntUType" 
					Return Me.MedIntUType
				Case "SmallIntUType" 
					Return Me.SmallIntUType
				Case "TinyIntUType" 
					Return Me.TinyIntUType
				Case "FloatType" 
					Return Me.FloatType
				Case "FloatUType" 
					Return Me.FloatUType
				Case "DecType" 
					Return Me.DecType
				Case "DecUType" 
					Return Me.DecUType
				Case "NumType" 
					Return Me.NumType
				Case "NumUType" 
					Return Me.NumUType
				Case "DblType" 
					Return Me.DblType
				Case "DblUType" 
					Return Me.DblUType
				Case "RealType" 
					Return Me.RealType
				Case "RealUType" 
					Return Me.RealUType
				Case "BitType" 
					Return Me.BitType
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Id As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.Id, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property BigIntType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.BigIntType, esSystemType.Int64)
			End Get
		End Property 
		
		Public ReadOnly Property IntType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.IntType, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property MedIntType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.MedIntType, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property SmallIntType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.SmallIntType, esSystemType.Int16)
			End Get
		End Property 
		
		Public ReadOnly Property TinyIntType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.TinyIntType, esSystemType.SByte)
			End Get
		End Property 
		
		Public ReadOnly Property BigIntUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.BigIntUType, esSystemType.UInt64)
			End Get
		End Property 
		
		Public ReadOnly Property IntUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.IntUType, esSystemType.UInt32)
			End Get
		End Property 
		
		Public ReadOnly Property MedIntUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.MedIntUType, esSystemType.UInt32)
			End Get
		End Property 
		
		Public ReadOnly Property SmallIntUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.SmallIntUType, esSystemType.UInt16)
			End Get
		End Property 
		
		Public ReadOnly Property TinyIntUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.TinyIntUType, esSystemType.Byte)
			End Get
		End Property 
		
		Public ReadOnly Property FloatType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.FloatType, esSystemType.Single)
			End Get
		End Property 
		
		Public ReadOnly Property FloatUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.FloatUType, esSystemType.Single)
			End Get
		End Property 
		
		Public ReadOnly Property DecType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.DecType, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property DecUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.DecUType, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property NumType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.NumType, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property NumUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.NumUType, esSystemType.Decimal)
			End Get
		End Property 
		
		Public ReadOnly Property DblType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.DblType, esSystemType.Double)
			End Get
		End Property 
		
		Public ReadOnly Property DblUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.DblUType, esSystemType.Double)
			End Get
		End Property 
		
		Public ReadOnly Property RealType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.RealType, esSystemType.Double)
			End Get
		End Property 
		
		Public ReadOnly Property RealUType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.RealUType, esSystemType.Double)
			End Get
		End Property 
		
		Public ReadOnly Property BitType As esQueryItem
			Get
				Return New esQueryItem(Me, MysqltypetestMetadata.ColumnNames.BitType, esSystemType.SByte)
			End Get
		End Property 
		
#End Region	
		
	End Class



    <DataContract(Namespace:="http://tempuri.org/", Name:="Mysqltypetest")> _
    <XmlType(TypeName:="MysqltypetestProxyStub")> _
    <Serializable> _
    Partial Public Class MysqltypetestProxyStub
	
		Public Sub New()
            Me._entity = New Mysqltypetest()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Mysqltypetest)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Mysqltypetest, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As MysqltypetestProxyStub) As Mysqltypetest
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Mysqltypetest)
        End Function
		

		<DataMember(Name:="Id", Order:=0, EmitDefaultValue:=False)> _		
        Public Property Id As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(MysqltypetestMetadata.ColumnNames.Id)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.Id
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Id = value
			End Set
			
		End Property

		<DataMember(Name:="BigIntType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property BigIntType As Nullable(Of System.Int64)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.BigIntType) Then
                    Return Me.Entity.BigIntType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int64))
				Me.Entity.BigIntType = value
			End Set
			
		End Property

		<DataMember(Name:="IntType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property IntType As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.IntType) Then
                    Return Me.Entity.IntType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.IntType = value
			End Set
			
		End Property

		<DataMember(Name:="MedIntType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property MedIntType As Nullable(Of System.Int32)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.MedIntType) Then
                    Return Me.Entity.MedIntType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.MedIntType = value
			End Set
			
		End Property

		<DataMember(Name:="SmallIntType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property SmallIntType As Nullable(Of System.Int16)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.SmallIntType) Then
                    Return Me.Entity.SmallIntType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int16))
				Me.Entity.SmallIntType = value
			End Set
			
		End Property

		<DataMember(Name:="TinyIntType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property TinyIntType As Nullable(Of System.SByte)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.TinyIntType) Then
                    Return Me.Entity.TinyIntType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.SByte))
				Me.Entity.TinyIntType = value
			End Set
			
		End Property

		<DataMember(Name:="BigIntUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property BigIntUType As Nullable(Of System.UInt64)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.BigIntUType) Then
                    Return Me.Entity.BigIntUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.UInt64))
				Me.Entity.BigIntUType = value
			End Set
			
		End Property

		<DataMember(Name:="IntUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property IntUType As Nullable(Of System.UInt32)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.IntUType) Then
                    Return Me.Entity.IntUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.UInt32))
				Me.Entity.IntUType = value
			End Set
			
		End Property

		<DataMember(Name:="MedIntUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property MedIntUType As Nullable(Of System.UInt32)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.MedIntUType) Then
                    Return Me.Entity.MedIntUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.UInt32))
				Me.Entity.MedIntUType = value
			End Set
			
		End Property

		<DataMember(Name:="SmallIntUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property SmallIntUType As Nullable(Of System.UInt16)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.SmallIntUType) Then
                    Return Me.Entity.SmallIntUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.UInt16))
				Me.Entity.SmallIntUType = value
			End Set
			
		End Property

		<DataMember(Name:="TinyIntUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property TinyIntUType As Nullable(Of System.Byte)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.TinyIntUType) Then
                    Return Me.Entity.TinyIntUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Byte))
				Me.Entity.TinyIntUType = value
			End Set
			
		End Property

		<DataMember(Name:="FloatType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property FloatType As Nullable(Of System.Single)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.FloatType) Then
                    Return Me.Entity.FloatType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Single))
				Me.Entity.FloatType = value
			End Set
			
		End Property

		<DataMember(Name:="FloatUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property FloatUType As Nullable(Of System.Single)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.FloatUType) Then
                    Return Me.Entity.FloatUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Single))
				Me.Entity.FloatUType = value
			End Set
			
		End Property

		<DataMember(Name:="DecType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property DecType As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.DecType) Then
                    Return Me.Entity.DecType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.DecType = value
			End Set
			
		End Property

		<DataMember(Name:="DecUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property DecUType As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.DecUType) Then
                    Return Me.Entity.DecUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.DecUType = value
			End Set
			
		End Property

		<DataMember(Name:="NumType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property NumType As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.NumType) Then
                    Return Me.Entity.NumType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.NumType = value
			End Set
			
		End Property

		<DataMember(Name:="NumUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property NumUType As Nullable(Of System.Decimal)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.NumUType) Then
                    Return Me.Entity.NumUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Decimal))
				Me.Entity.NumUType = value
			End Set
			
		End Property

		<DataMember(Name:="DblType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property DblType As Nullable(Of System.Double)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.DblType) Then
                    Return Me.Entity.DblType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Double))
				Me.Entity.DblType = value
			End Set
			
		End Property

		<DataMember(Name:="DblUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property DblUType As Nullable(Of System.Double)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.DblUType) Then
                    Return Me.Entity.DblUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Double))
				Me.Entity.DblUType = value
			End Set
			
		End Property

		<DataMember(Name:="RealType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property RealType As Nullable(Of System.Double)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.RealType) Then
                    Return Me.Entity.RealType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Double))
				Me.Entity.RealType = value
			End Set
			
		End Property

		<DataMember(Name:="RealUType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property RealUType As Nullable(Of System.Double)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.RealUType) Then
                    Return Me.Entity.RealUType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Double))
				Me.Entity.RealUType = value
			End Set
			
		End Property

		<DataMember(Name:="BitType", Order:=0, EmitDefaultValue:=False)> _		
        Public Property BitType As Nullable(Of System.SByte)
        
            Get
                If Me.IncludeColumn(MysqltypetestMetadata.ColumnNames.BitType) Then
                    Return Me.Entity.BitType
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.SByte))
				Me.Entity.BitType = value
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
        Public Property Entity As Mysqltypetest
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Mysqltypetest()
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
        Public _entity As Mysqltypetest
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="MysqltypetestCollection")> _
    <XmlType(TypeName:="MysqltypetestCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class MysqltypetestCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Mysqltypetest))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Mysqltypetest), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As MysqltypetestCollectionProxyStub) As MysqltypetestCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Mysqltypetest)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Mysqltypetest), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Mysqltypetest In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New MysqltypetestProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New MysqltypetestProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Mysqltypetest In coll.es.DeletedEntities
                    Collection.Add(New MysqltypetestProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of MysqltypetestProxyStub)		

        Public Function GetCollection As MysqltypetestCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New MysqltypetestCollection()
					
		            Dim proxy As MysqltypetestProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As MysqltypetestCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class MysqltypetestMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.Id, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.Id
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 11
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.BigIntType, 1, GetType(System.Int64), esSystemType.Int64)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.BigIntType
			c.NumericPrecision = 20
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.IntType, 2, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.IntType
			c.NumericPrecision = 11
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.MedIntType, 3, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.MedIntType
			c.NumericPrecision = 9
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.SmallIntType, 4, GetType(System.Int16), esSystemType.Int16)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.SmallIntType
			c.NumericPrecision = 6
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.TinyIntType, 5, GetType(System.SByte), esSystemType.SByte)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.TinyIntType
			c.NumericPrecision = 4
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.BigIntUType, 6, GetType(System.UInt64), esSystemType.UInt64)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.BigIntUType
			c.NumericPrecision = 20
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.IntUType, 7, GetType(System.UInt32), esSystemType.UInt32)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.IntUType
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.MedIntUType, 8, GetType(System.UInt32), esSystemType.UInt32)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.MedIntUType
			c.NumericPrecision = 8
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.SmallIntUType, 9, GetType(System.UInt16), esSystemType.UInt16)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.SmallIntUType
			c.NumericPrecision = 5
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.TinyIntUType, 10, GetType(System.Byte), esSystemType.Byte)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.TinyIntUType
			c.NumericPrecision = 3
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.FloatType, 11, GetType(System.Single), esSystemType.Single)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.FloatType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.FloatUType, 12, GetType(System.Single), esSystemType.Single)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.FloatUType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.DecType, 13, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DecType
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.DecUType, 14, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DecUType
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.NumType, 15, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.NumType
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.NumUType, 16, GetType(System.Decimal), esSystemType.Decimal)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.NumUType
			c.NumericPrecision = 10
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.DblType, 17, GetType(System.Double), esSystemType.Double)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DblType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.DblUType, 18, GetType(System.Double), esSystemType.Double)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.DblUType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.RealType, 19, GetType(System.Double), esSystemType.Double)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.RealType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.RealUType, 20, GetType(System.Double), esSystemType.Double)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.RealUType
			c.IsNullable = True
			m_columns.Add(c)
				
			c = New esColumnMetadata(MysqltypetestMetadata.ColumnNames.BitType, 21, GetType(System.SByte), esSystemType.SByte)	
			c.PropertyName = MysqltypetestMetadata.PropertyNames.BitType
			c.NumericPrecision = 1
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As MysqltypetestMetadata
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
			 Public Const BigIntType As String = "BigIntType"
			 Public Const IntType As String = "IntType"
			 Public Const MedIntType As String = "MedIntType"
			 Public Const SmallIntType As String = "SmallIntType"
			 Public Const TinyIntType As String = "TinyIntType"
			 Public Const BigIntUType As String = "BigIntUType"
			 Public Const IntUType As String = "IntUType"
			 Public Const MedIntUType As String = "MedIntUType"
			 Public Const SmallIntUType As String = "SmallIntUType"
			 Public Const TinyIntUType As String = "TinyIntUType"
			 Public Const FloatType As String = "FloatType"
			 Public Const FloatUType As String = "FloatUType"
			 Public Const DecType As String = "DecType"
			 Public Const DecUType As String = "DecUType"
			 Public Const NumType As String = "NumType"
			 Public Const NumUType As String = "NumUType"
			 Public Const DblType As String = "DblType"
			 Public Const DblUType As String = "DblUType"
			 Public Const RealType As String = "RealType"
			 Public Const RealUType As String = "RealUType"
			 Public Const BitType As String = "BitType"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Id As String = "Id"
			 Public Const BigIntType As String = "BigIntType"
			 Public Const IntType As String = "IntType"
			 Public Const MedIntType As String = "MedIntType"
			 Public Const SmallIntType As String = "SmallIntType"
			 Public Const TinyIntType As String = "TinyIntType"
			 Public Const BigIntUType As String = "BigIntUType"
			 Public Const IntUType As String = "IntUType"
			 Public Const MedIntUType As String = "MedIntUType"
			 Public Const SmallIntUType As String = "SmallIntUType"
			 Public Const TinyIntUType As String = "TinyIntUType"
			 Public Const FloatType As String = "FloatType"
			 Public Const FloatUType As String = "FloatUType"
			 Public Const DecType As String = "DecType"
			 Public Const DecUType As String = "DecUType"
			 Public Const NumType As String = "NumType"
			 Public Const NumUType As String = "NumUType"
			 Public Const DblType As String = "DblType"
			 Public Const DblUType As String = "DblUType"
			 Public Const RealType As String = "RealType"
			 Public Const RealUType As String = "RealUType"
			 Public Const BitType As String = "BitType"
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
			SyncLock GetType(MysqltypetestMetadata)
			
				If MysqltypetestMetadata.mapDelegates Is Nothing Then
					MysqltypetestMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If MysqltypetestMetadata._meta Is Nothing Then
					MysqltypetestMetadata._meta = New MysqltypetestMetadata()
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
				


				meta.AddTypeMap("Id", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("BigIntType", new esTypeMap("BIGINT", "System.Int64"))
				meta.AddTypeMap("IntType", new esTypeMap("INT", "System.Int32"))
				meta.AddTypeMap("MedIntType", new esTypeMap("MEDIUMINT", "System.Int32"))
				meta.AddTypeMap("SmallIntType", new esTypeMap("SMALLINT", "System.Int16"))
				meta.AddTypeMap("TinyIntType", new esTypeMap("TINYINT", "System.SByte"))
				meta.AddTypeMap("BigIntUType", new esTypeMap("BIGINT UNSIGNED", "System.UInt64"))
				meta.AddTypeMap("IntUType", new esTypeMap("INT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("MedIntUType", new esTypeMap("MEDIUMINT UNSIGNED", "System.UInt32"))
				meta.AddTypeMap("SmallIntUType", new esTypeMap("SMALLINT UNSIGNED", "System.UInt16"))
				meta.AddTypeMap("TinyIntUType", new esTypeMap("TINYINT UNSIGNED", "System.Byte"))
				meta.AddTypeMap("FloatType", new esTypeMap("FLOAT", "System.Single"))
				meta.AddTypeMap("FloatUType", new esTypeMap("FLOAT UNSIGNED", "System.Single"))
				meta.AddTypeMap("DecType", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("DecUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"))
				meta.AddTypeMap("NumType", new esTypeMap("DECIMAL", "System.Decimal"))
				meta.AddTypeMap("NumUType", new esTypeMap("DECIMAL UNSIGNED", "System.Decimal"))
				meta.AddTypeMap("DblType", new esTypeMap("DOUBLE", "System.Double"))
				meta.AddTypeMap("DblUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"))
				meta.AddTypeMap("RealType", new esTypeMap("DOUBLE", "System.Double"))
				meta.AddTypeMap("RealUType", new esTypeMap("DOUBLE UNSIGNED", "System.Double"))
				meta.AddTypeMap("BitType", new esTypeMap("BIT", "System.SByte"))			
				meta.Catalog = "aggregatedb"
				
				 
				meta.Source = "mysqltypetest"
				meta.Destination = "mysqltypetest"
				
				meta.spInsert = "proc_mysqltypetestInsert"
				meta.spUpdate = "proc_mysqltypetestUpdate"
				meta.spDelete = "proc_mysqltypetestDelete"
				meta.spLoadAll = "proc_mysqltypetestLoadAll"
				meta.spLoadByPrimaryKey = "proc_mysqltypetestLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As MysqltypetestMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
