
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
	' Encapsulates the 'Student' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Student))> _
	<XmlType("Student")> _ 
	<Table(Name:="Student")> _	
	Partial Public Class Student 
		Inherits esStudent
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Student()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal s1 As System.String, ByVal s2 As System.String)
			Dim obj As New Student()
			obj.S1 = s1
			obj.S2 = s2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal s1 As System.String, ByVal s2 As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Student()
			obj.S1 = s1
			obj.S2 = s2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Student) As StudentProxyStub
			Return New StudentProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property S1 As System.String
			Get
				Return MyBase.S1
			End Get
			Set
				MyBase.S1 = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property S2 As System.String
			Get
				Return MyBase.S2
			End Get
			Set
				MyBase.S2 = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property StudentName As System.String
			Get
				Return MyBase.StudentName
			End Get
			Set
				MyBase.StudentName = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("StudentCollection")> _
	Partial Public Class StudentCollection
		Inherits esStudentCollection
		Implements IEnumerable(Of Student)
	
		Public Function FindByPrimaryKey(ByVal s1 As System.String, ByVal s2 As System.String) As Student
			Return MyBase.SingleOrDefault(Function(e) e.S1 = s1 And e.S2 = s2)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As StudentCollection) As StudentCollectionProxyStub
            Return New StudentCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Student))> _
		Public Class StudentCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of StudentCollection)
			
			Public Shared Widening Operator CType(packet As StudentCollectionWCFPacket) As StudentCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As StudentCollection) As StudentCollectionWCFPacket
				Return New StudentCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "StudentQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class StudentQuery 
		Inherits esStudentQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "StudentQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As StudentQuery) As String
			Return StudentQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As StudentQuery
			Return DirectCast(StudentQuery.SerializeHelper.FromXml(query, GetType(StudentQuery)), StudentQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esStudent
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal s1 As System.String, ByVal s2 As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(s1, s2)
			Else
				Return LoadByPrimaryKeyStoredProcedure(s1, s2)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal s1 As System.String, ByVal s2 As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(s1, s2)
			Else
				Return LoadByPrimaryKeyStoredProcedure(s1, s2)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal s1 As System.String, ByVal s2 As System.String) As Boolean
		
			Dim query As New StudentQuery()
			query.Where(query.S1 = s1 And query.S2 = s2)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal s1 As System.String, ByVal s2 As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("S1", s1)
						parms.Add("S2", s2)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Student.S1
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property S1 As System.String
			Get
				Return MyBase.GetSystemString(StudentMetadata.ColumnNames.S1)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(StudentMetadata.ColumnNames.S1, value) Then
					OnPropertyChanged(StudentMetadata.PropertyNames.S1)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Student.S2
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property S2 As System.String
			Get
				Return MyBase.GetSystemString(StudentMetadata.ColumnNames.S2)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(StudentMetadata.ColumnNames.S2, value) Then
					OnPropertyChanged(StudentMetadata.PropertyNames.S2)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Student.StudentName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property StudentName As System.String
			Get
				Return MyBase.GetSystemString(StudentMetadata.ColumnNames.StudentName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(StudentMetadata.ColumnNames.StudentName, value) Then
					OnPropertyChanged(StudentMetadata.PropertyNames.StudentName)
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
												
						Case "S1"
							Me.str().S1 = CType(value, string)
												
						Case "S2"
							Me.str().S2 = CType(value, string)
												
						Case "StudentName"
							Me.str().StudentName = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
					
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
		
			Public Sub New(ByVal entity As esStudent)
				Me.entity = entity
			End Sub				
		
	
			Public Property S1 As System.String 
				Get
					Dim data_ As System.String = entity.S1
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.S1 = Nothing
					Else
						entity.S1 = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property S2 As System.String 
				Get
					Dim data_ As System.String = entity.S2
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.S2 = Nothing
					Else
						entity.S2 = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property StudentName As System.String 
				Get
					Dim data_ As System.String = entity.StudentName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.StudentName = Nothing
					Else
						entity.StudentName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esStudent
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return StudentMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As StudentQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New StudentQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As StudentQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As StudentQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As StudentQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esStudentCollection
		Inherits esEntityCollection(Of Student)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return StudentMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "StudentCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As StudentQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New StudentQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As StudentQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New StudentQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As StudentQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, StudentQuery))
		End Sub
		
		#End Region
						
		Private m_query As StudentQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esStudentQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return StudentMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "S1" 
					Return Me.S1
				Case "S2" 
					Return Me.S2
				Case "StudentName" 
					Return Me.StudentName
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property S1 As esQueryItem
			Get
				Return New esQueryItem(Me, StudentMetadata.ColumnNames.S1, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property S2 As esQueryItem
			Get
				Return New esQueryItem(Me, StudentMetadata.ColumnNames.S2, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property StudentName As esQueryItem
			Get
				Return New esQueryItem(Me, StudentMetadata.ColumnNames.StudentName, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Student 
		Inherits esStudent
		
	
		#Region "UpToCourseCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_StudentClass_Student
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToCourseCollection As CourseCollection
		
			Get
				If Me._UpToCourseCollection Is Nothing Then
					Me._UpToCourseCollection = New CourseCollection()
					Me._UpToCourseCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToCourseCollection", Me._UpToCourseCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.S1.Equals(Nothing) Then 
				
						Dim m As New CourseQuery("m")
						Dim j As New StudentClassQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.C1 = j.Cid1 And m.C2 = j.Cid2)
                        m.Where(j.Sid1 = Me.S1)
                        m.Where(j.Sid2 = Me.S2)

						Me._UpToCourseCollection.Load(m)

					End If
				End If

				Return Me._UpToCourseCollection
			End Get
			
			Set(ByVal value As CourseCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToCourseCollection Is Nothing Then

					Me.RemovePostSave("UpToCourseCollection")
					Me._UpToCourseCollection = Nothing
					Me.OnPropertyChanged("UpToCourseCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_StudentClass_Student
		''' </summary>
		Public Sub AssociateCourseCollection(entity As Course)
			If Me._StudentClassCollection Is Nothing Then
				Me._StudentClassCollection = New StudentClassCollection()
				Me._StudentClassCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("StudentClassCollection", Me._StudentClassCollection)
			End If
			
			Dim obj As StudentClass = Me._StudentClassCollection.AddNew()
			obj.Sid1 = Me.S1
			obj.Sid2 = Me.S2
			obj.Cid1 = entity.C1
			obj.Cid2 = entity.C2			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_StudentClass_Student
		''' </summary>
		Public Sub DissociateCourseCollection(entity As Course)
			If Me._StudentClassCollection Is Nothing Then
				Me._StudentClassCollection = new StudentClassCollection()
				Me._StudentClassCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("StudentClassCollection", Me._StudentClassCollection)
			End If

			Dim obj As StudentClass = Me._StudentClassCollection.AddNew()
			obj.Sid1 = Me.S1
			obj.Sid2 = Me.S2
            obj.Cid1 = entity.C1
            obj.Cid2 = entity.C2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToCourseCollection As CourseCollection
		Private _StudentClassCollection As StudentClassCollection
		#End Region

		#Region "StudentClassCollectionBySid1 - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_StudentClassCollectionBySid1() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Student.StudentClassCollectionBySid1_Delegate)
				map.PropertyName = "StudentClassCollectionBySid1"
				map.MyColumnName = "SID1,SID2"
				map.ParentColumnName = "S1,S2"
				map.IsMultiPartKey = true
				Return map
			End Get
		End Property

		Private Shared Sub StudentClassCollectionBySid1_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New StudentQuery(data.NextAlias())
			
			Dim mee As StudentClassQuery = If(data.You IsNot Nothing, TryCast(data.You, StudentClassQuery), New StudentClassQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.S1 = mee.Sid1 And parent.S2 = mee.Sid2)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_StudentClass_Student
		''' </summary>

		<XmlIgnore()> _ 
		Public Property StudentClassCollectionBySid1 As StudentClassCollection 
		
			Get
				If Me._StudentClassCollectionBySid1 Is Nothing Then
					Me._StudentClassCollectionBySid1 = New StudentClassCollection()
					Me._StudentClassCollectionBySid1.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("StudentClassCollectionBySid1", Me._StudentClassCollectionBySid1)
				
					If Not Me.S1.Equals(Nothing) AndAlso Not Me.S2.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._StudentClassCollectionBySid1.Query.Where(Me._StudentClassCollectionBySid1.Query.Sid1 = Me.S1)
							Me._StudentClassCollectionBySid1.Query.Where(Me._StudentClassCollectionBySid1.Query.Sid2 = Me.S2)
							Me._StudentClassCollectionBySid1.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._StudentClassCollectionBySid1.fks.Add(StudentClassMetadata.ColumnNames.Sid1, Me.S1)
						Me._StudentClassCollectionBySid1.fks.Add(StudentClassMetadata.ColumnNames.Sid2, Me.S2)
					End If
				End If

				Return Me._StudentClassCollectionBySid1
			End Get
			
			Set(ByVal value As StudentClassCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._StudentClassCollectionBySid1 Is Nothing Then

					Me.RemovePostSave("StudentClassCollectionBySid1")
					Me._StudentClassCollectionBySid1 = Nothing
					Me.OnPropertyChanged("StudentClassCollectionBySid1")

				End If
			End Set				
			
		End Property
		

		private _StudentClassCollectionBySid1 As StudentClassCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "StudentClassCollectionBySid1"
					coll = Me.StudentClassCollectionBySid1
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "StudentClassCollectionBySid1", GetType(StudentClassCollection), New StudentClass()))
			Return props
			
		End Function
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Student")> _
    <XmlType(TypeName:="StudentProxyStub")> _
    <Serializable> _
    Partial Public Class StudentProxyStub
	
		Public Sub New()
            Me._entity = New Student()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Student)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Student, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As StudentProxyStub) As Student
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Student)
        End Function
		

		<DataMember(Name:="S1", Order:=1, EmitDefaultValue:=False)> _		
        Public Property S1 As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(StudentMetadata.ColumnNames.S1)
					Return CType(o, System.String)
                Else
					Return Me.Entity.S1
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.S1 = value
			End Set
			
		End Property

		<DataMember(Name:="S2", Order:=2, EmitDefaultValue:=False)> _		
        Public Property S2 As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(StudentMetadata.ColumnNames.S2)
					Return CType(o, System.String)
                Else
					Return Me.Entity.S2
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.S2 = value
			End Set
			
		End Property

		<DataMember(Name:="StudentName", Order:=3, EmitDefaultValue:=False)> _		
        Public Property StudentName As System.String
        
            Get
                If Me.IncludeColumn(StudentMetadata.ColumnNames.StudentName) Then
                    Return Me.Entity.StudentName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.StudentName = value
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
        Public Property Entity As Student
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Student()
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
        Public _entity As Student
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="StudentCollection")> _
    <XmlType(TypeName:="StudentCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class StudentCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Student))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Student), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As StudentCollectionProxyStub) As StudentCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Student)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Student), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Student In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New StudentProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New StudentProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Student In coll.es.DeletedEntities
                    Collection.Add(New StudentProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of StudentProxyStub)		

        Public Function GetCollection As StudentCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New StudentCollection()
					
		            Dim proxy As StudentProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As StudentCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class StudentMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(StudentMetadata.ColumnNames.S1, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = StudentMetadata.PropertyNames.S1
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(StudentMetadata.ColumnNames.S2, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = StudentMetadata.PropertyNames.S2
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(StudentMetadata.ColumnNames.StudentName, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = StudentMetadata.PropertyNames.StudentName
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As StudentMetadata
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
			 Public Const S1 As String = "S1"
			 Public Const S2 As String = "S2"
			 Public Const StudentName As String = "StudentName"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const S1 As String = "S1"
			 Public Const S2 As String = "S2"
			 Public Const StudentName As String = "StudentName"
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
			SyncLock GetType(StudentMetadata)
			
				If StudentMetadata.mapDelegates Is Nothing Then
					StudentMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If StudentMetadata._meta Is Nothing Then
					StudentMetadata._meta = New StudentMetadata()
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
				


				meta.AddTypeMap("S1", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("S2", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("StudentName", new esTypeMap("varchar", "System.String"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "Student"
				meta.Destination = "Student"
				
				meta.spInsert = "proc_StudentInsert"
				meta.spUpdate = "proc_StudentUpdate"
				meta.spDelete = "proc_StudentDelete"
				meta.spLoadAll = "proc_StudentLoadAll"
				meta.spLoadByPrimaryKey = "proc_StudentLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As StudentMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
