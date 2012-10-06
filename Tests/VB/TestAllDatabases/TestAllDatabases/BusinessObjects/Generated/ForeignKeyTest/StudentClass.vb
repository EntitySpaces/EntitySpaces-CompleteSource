
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
	' Encapsulates the 'StudentClass' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(StudentClass))> _
	<XmlType("StudentClass")> _ 
	<Table(Name:="StudentClass")> _	
	Partial Public Class StudentClass 
		Inherits esStudentClass
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New StudentClass()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal sid1 As System.String, ByVal sid2 As System.String, ByVal cid1 As System.Int32, ByVal cid2 As System.String)
			Dim obj As New StudentClass()
			obj.Sid1 = sid1
			obj.Sid2 = sid2
			obj.Cid1 = cid1
			obj.Cid2 = cid2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal sid1 As System.String, ByVal sid2 As System.String, ByVal cid1 As System.Int32, ByVal cid2 As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New StudentClass()
			obj.Sid1 = sid1
			obj.Sid2 = sid2
			obj.Cid1 = cid1
			obj.Cid2 = cid2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As StudentClass) As StudentClassProxyStub
			Return New StudentClassProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Sid1 As System.String
			Get
				Return MyBase.Sid1
			End Get
			Set
				MyBase.Sid1 = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Sid2 As System.String
			Get
				Return MyBase.Sid2
			End Get
			Set
				MyBase.Sid2 = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Cid1 As Nullable(Of System.Int32)
			Get
				Return MyBase.Cid1
			End Get
			Set
				MyBase.Cid1 = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property Cid2 As System.String
			Get
				Return MyBase.Cid2
			End Get
			Set
				MyBase.Cid2 = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("StudentClassCollection")> _
	Partial Public Class StudentClassCollection
		Inherits esStudentClassCollection
		Implements IEnumerable(Of StudentClass)
	
		Public Function FindByPrimaryKey(ByVal sid1 As System.String, ByVal sid2 As System.String, ByVal cid1 As System.Int32, ByVal cid2 As System.String) As StudentClass
			Return MyBase.SingleOrDefault(Function(e) e.Sid1 = sid1 And e.Sid2 = sid2 And e.Cid1.HasValue AndAlso e.Cid1.Value = cid1 And e.Cid2 = cid2)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As StudentClassCollection) As StudentClassCollectionProxyStub
            Return New StudentClassCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(StudentClass))> _
		Public Class StudentClassCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of StudentClassCollection)
			
			Public Shared Widening Operator CType(packet As StudentClassCollectionWCFPacket) As StudentClassCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As StudentClassCollection) As StudentClassCollectionWCFPacket
				Return New StudentClassCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "StudentClassQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class StudentClassQuery 
		Inherits esStudentClassQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "StudentClassQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As StudentClassQuery) As String
			Return StudentClassQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As StudentClassQuery
			Return DirectCast(StudentClassQuery.SerializeHelper.FromXml(query, GetType(StudentClassQuery)), StudentClassQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esStudentClass
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal sid1 As System.String, ByVal sid2 As System.String, ByVal cid1 As System.Int32, ByVal cid2 As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(sid1, sid2, cid1, cid2)
			Else
				Return LoadByPrimaryKeyStoredProcedure(sid1, sid2, cid1, cid2)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal sid1 As System.String, ByVal sid2 As System.String, ByVal cid1 As System.Int32, ByVal cid2 As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(sid1, sid2, cid1, cid2)
			Else
				Return LoadByPrimaryKeyStoredProcedure(sid1, sid2, cid1, cid2)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal sid1 As System.String, ByVal sid2 As System.String, ByVal cid1 As System.Int32, ByVal cid2 As System.String) As Boolean
		
			Dim query As New StudentClassQuery()
			query.Where(query.Sid1 = sid1 And query.Sid2 = sid2 And query.Cid1 = cid1 And query.Cid2 = cid2)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal sid1 As System.String, ByVal sid2 As System.String, ByVal cid1 As System.Int32, ByVal cid2 As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("Sid1", sid1)
						parms.Add("Sid2", sid2)
						parms.Add("Cid1", cid1)
						parms.Add("Cid2", cid2)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to StudentClass.SID1
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Sid1 As System.String
			Get
				Return MyBase.GetSystemString(StudentClassMetadata.ColumnNames.Sid1)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(StudentClassMetadata.ColumnNames.Sid1, value) Then
					Me._UpToStudentBySid1 = Nothing
					Me.OnPropertyChanged("UpToStudentBySid1")
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Sid1)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to StudentClass.SID2
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Sid2 As System.String
			Get
				Return MyBase.GetSystemString(StudentClassMetadata.ColumnNames.Sid2)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(StudentClassMetadata.ColumnNames.Sid2, value) Then
					Me._UpToStudentBySid1 = Nothing
					Me.OnPropertyChanged("UpToStudentBySid1")
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Sid2)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to StudentClass.CID1
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Cid1 As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(StudentClassMetadata.ColumnNames.Cid1)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(StudentClassMetadata.ColumnNames.Cid1, value) Then
					Me._UpToCourseByCid1 = Nothing
					Me.OnPropertyChanged("UpToCourseByCid1")
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Cid1)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to StudentClass.CID2
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Cid2 As System.String
			Get
				Return MyBase.GetSystemString(StudentClassMetadata.ColumnNames.Cid2)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(StudentClassMetadata.ColumnNames.Cid2, value) Then
					Me._UpToCourseByCid1 = Nothing
					Me.OnPropertyChanged("UpToCourseByCid1")
					OnPropertyChanged(StudentClassMetadata.PropertyNames.Cid2)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToCourseByCid1 As Course
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToStudentBySid1 As Student
		
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
												
						Case "Sid1"
							Me.str().Sid1 = CType(value, string)
												
						Case "Sid2"
							Me.str().Sid2 = CType(value, string)
												
						Case "Cid1"
							Me.str().Cid1 = CType(value, string)
												
						Case "Cid2"
							Me.str().Cid2 = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "Cid1"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.Cid1 = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(StudentClassMetadata.PropertyNames.Cid1)
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
		
			Public Sub New(ByVal entity As esStudentClass)
				Me.entity = entity
			End Sub				
		
	
			Public Property Sid1 As System.String 
				Get
					Dim data_ As System.String = entity.Sid1
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Sid1 = Nothing
					Else
						entity.Sid1 = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Sid2 As System.String 
				Get
					Dim data_ As System.String = entity.Sid2
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Sid2 = Nothing
					Else
						entity.Sid2 = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Cid1 As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.Cid1
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Cid1 = Nothing
					Else
						entity.Cid1 = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property Cid2 As System.String 
				Get
					Dim data_ As System.String = entity.Cid2
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Cid2 = Nothing
					Else
						entity.Cid2 = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esStudentClass
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return StudentClassMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As StudentClassQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New StudentClassQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As StudentClassQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As StudentClassQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As StudentClassQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esStudentClassCollection
		Inherits esEntityCollection(Of StudentClass)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return StudentClassMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "StudentClassCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As StudentClassQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New StudentClassQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As StudentClassQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New StudentClassQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As StudentClassQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, StudentClassQuery))
		End Sub
		
		#End Region
						
		Private m_query As StudentClassQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esStudentClassQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return StudentClassMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "Sid1" 
					Return Me.Sid1
				Case "Sid2" 
					Return Me.Sid2
				Case "Cid1" 
					Return Me.Cid1
				Case "Cid2" 
					Return Me.Cid2
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property Sid1 As esQueryItem
			Get
				Return New esQueryItem(Me, StudentClassMetadata.ColumnNames.Sid1, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Sid2 As esQueryItem
			Get
				Return New esQueryItem(Me, StudentClassMetadata.ColumnNames.Sid2, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Cid1 As esQueryItem
			Get
				Return New esQueryItem(Me, StudentClassMetadata.ColumnNames.Cid1, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Cid2 As esQueryItem
			Get
				Return New esQueryItem(Me, StudentClassMetadata.ColumnNames.Cid2, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class StudentClass 
		Inherits esStudentClass
		
	
		#Region "UpToCourseByCid1 - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_StudentClass_Class
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToCourseByCid1 As Course
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCourseByCid1 Is Nothing _
						 AndAlso Not Cid1.Equals(Nothing)  AndAlso Not Cid2.Equals(Nothing)  Then
						
					Me._UpToCourseByCid1 = New Course()
					Me._UpToCourseByCid1.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCourseByCid1", Me._UpToCourseByCid1)
					Me._UpToCourseByCid1.Query.Where(Me._UpToCourseByCid1.Query.C1 = Me.Cid1)
					Me._UpToCourseByCid1.Query.Where(Me._UpToCourseByCid1.Query.C2 = Me.Cid2)
					Me._UpToCourseByCid1.Query.Load()
				End If

				Return Me._UpToCourseByCid1
			End Get
			
            Set(ByVal value As Course)
				Me.RemovePreSave("UpToCourseByCid1")
				
				Dim changed as Boolean = Me._UpToCourseByCid1 IsNot value

				If value Is Nothing Then
				
					Me.Cid1 = Nothing
				
					Me.Cid2 = Nothing
				
					Me._UpToCourseByCid1 = Nothing
				Else
				
					Me.Cid1 = value.C1
					
					Me.Cid2 = value.C2
					
					Me._UpToCourseByCid1 = value
					Me.SetPreSave("UpToCourseByCid1", Me._UpToCourseByCid1)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCourseByCid1")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToStudentBySid1 - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_StudentClass_Student
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToStudentBySid1 As Student
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToStudentBySid1 Is Nothing _
						 AndAlso Not Sid1.Equals(Nothing)  AndAlso Not Sid2.Equals(Nothing)  Then
						
					Me._UpToStudentBySid1 = New Student()
					Me._UpToStudentBySid1.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToStudentBySid1", Me._UpToStudentBySid1)
					Me._UpToStudentBySid1.Query.Where(Me._UpToStudentBySid1.Query.S1 = Me.Sid1)
					Me._UpToStudentBySid1.Query.Where(Me._UpToStudentBySid1.Query.S2 = Me.Sid2)
					Me._UpToStudentBySid1.Query.Load()
				End If

				Return Me._UpToStudentBySid1
			End Get
			
            Set(ByVal value As Student)
				Me.RemovePreSave("UpToStudentBySid1")
				
				Dim changed as Boolean = Me._UpToStudentBySid1 IsNot value

				If value Is Nothing Then
				
					Me.Sid1 = Nothing
				
					Me.Sid2 = Nothing
				
					Me._UpToStudentBySid1 = Nothing
				Else
				
					Me.Sid1 = value.S1
					
					Me.Sid2 = value.S2
					
					Me._UpToStudentBySid1 = value
					Me.SetPreSave("UpToStudentBySid1", Me._UpToStudentBySid1)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToStudentBySid1")
				End If
			End Set	

		End Property
		#End Region

		
		
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="StudentClass")> _
    <XmlType(TypeName:="StudentClassProxyStub")> _
    <Serializable> _
    Partial Public Class StudentClassProxyStub
	
		Public Sub New()
            Me._entity = New StudentClass()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As StudentClass)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As StudentClass, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As StudentClassProxyStub) As StudentClass
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(StudentClass)
        End Function
		

		<DataMember(Name:="Sid1", Order:=1, EmitDefaultValue:=False)> _		
        Public Property Sid1 As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Sid1)
					Return CType(o, System.String)
                Else
					Return Me.Entity.Sid1
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Sid1 = value
			End Set
			
		End Property

		<DataMember(Name:="Sid2", Order:=2, EmitDefaultValue:=False)> _		
        Public Property Sid2 As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Sid2)
					Return CType(o, System.String)
                Else
					Return Me.Entity.Sid2
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Sid2 = value
			End Set
			
		End Property

		<DataMember(Name:="Cid1", Order:=3, EmitDefaultValue:=False)> _		
        Public Property Cid1 As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Cid1)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.Cid1
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.Cid1 = value
			End Set
			
		End Property

		<DataMember(Name:="Cid2", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Cid2 As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(StudentClassMetadata.ColumnNames.Cid2)
					Return CType(o, System.String)
                Else
					Return Me.Entity.Cid2
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Cid2 = value
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
        Public Property Entity As StudentClass
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New StudentClass()
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
        Public _entity As StudentClass
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="StudentClassCollection")> _
    <XmlType(TypeName:="StudentClassCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class StudentClassCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of StudentClass))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of StudentClass), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As StudentClassCollectionProxyStub) As StudentClassCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(StudentClass)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of StudentClass), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As StudentClass In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New StudentClassProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New StudentClassProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As StudentClass In coll.es.DeletedEntities
                    Collection.Add(New StudentClassProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of StudentClassProxyStub)		

        Public Function GetCollection As StudentClassCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New StudentClassCollection()
					
		            Dim proxy As StudentClassProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As StudentClassCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class StudentClassMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(StudentClassMetadata.ColumnNames.Sid1, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = StudentClassMetadata.PropertyNames.Sid1
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(StudentClassMetadata.ColumnNames.Sid2, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = StudentClassMetadata.PropertyNames.Sid2
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(StudentClassMetadata.ColumnNames.Cid1, 2, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = StudentClassMetadata.PropertyNames.Cid1
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(StudentClassMetadata.ColumnNames.Cid2, 3, GetType(System.String), esSystemType.String)	
			c.PropertyName = StudentClassMetadata.PropertyNames.Cid2
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 10
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As StudentClassMetadata
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
			 Public Const Sid1 As String = "SID1"
			 Public Const Sid2 As String = "SID2"
			 Public Const Cid1 As String = "CID1"
			 Public Const Cid2 As String = "CID2"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const Sid1 As String = "Sid1"
			 Public Const Sid2 As String = "Sid2"
			 Public Const Cid1 As String = "Cid1"
			 Public Const Cid2 As String = "Cid2"
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
			SyncLock GetType(StudentClassMetadata)
			
				If StudentClassMetadata.mapDelegates Is Nothing Then
					StudentClassMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If StudentClassMetadata._meta Is Nothing Then
					StudentClassMetadata._meta = New StudentClassMetadata()
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
				


				meta.AddTypeMap("Sid1", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("Sid2", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("Cid1", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("Cid2", new esTypeMap("nchar", "System.String"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "StudentClass"
				meta.Destination = "StudentClass"
				
				meta.spInsert = "proc_StudentClassInsert"
				meta.spUpdate = "proc_StudentClassUpdate"
				meta.spDelete = "proc_StudentClassDelete"
				meta.spLoadAll = "proc_StudentClassLoadAll"
				meta.spLoadByPrimaryKey = "proc_StudentClassLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As StudentClassMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
