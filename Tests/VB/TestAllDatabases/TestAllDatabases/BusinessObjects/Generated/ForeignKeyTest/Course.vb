
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
	' Encapsulates the 'Class' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Course))> _
	<XmlType("Course")> _ 
	<Table(Name:="Course")> _	
	Partial Public Class Course 
		Inherits esCourse
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Course()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal c1 As System.Int32, ByVal c2 As System.String)
			Dim obj As New Course()
			obj.C1 = c1
			obj.C2 = c2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal c1 As System.Int32, ByVal c2 As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Course()
			obj.C1 = c1
			obj.C2 = c2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Course) As CourseProxyStub
			Return New CourseProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property C1 As Nullable(Of System.Int32)
			Get
				Return MyBase.C1
			End Get
			Set
				MyBase.C1 = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property C2 As System.String
			Get
				Return MyBase.C2
			End Get
			Set
				MyBase.C2 = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property ClassName As System.String
			Get
				Return MyBase.ClassName
			End Get
			Set
				MyBase.ClassName = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("CourseCollection")> _
	Partial Public Class CourseCollection
		Inherits esCourseCollection
		Implements IEnumerable(Of Course)
	
		Public Function FindByPrimaryKey(ByVal c1 As System.Int32, ByVal c2 As System.String) As Course
			Return MyBase.SingleOrDefault(Function(e) e.C1.HasValue AndAlso e.C1.Value = c1 And e.C2 = c2)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As CourseCollection) As CourseCollectionProxyStub
            Return New CourseCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Course))> _
		Public Class CourseCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of CourseCollection)
			
			Public Shared Widening Operator CType(packet As CourseCollectionWCFPacket) As CourseCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As CourseCollection) As CourseCollectionWCFPacket
				Return New CourseCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "CourseQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class CourseQuery 
		Inherits esCourseQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CourseQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As CourseQuery) As String
			Return CourseQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As CourseQuery
			Return DirectCast(CourseQuery.SerializeHelper.FromXml(query, GetType(CourseQuery)), CourseQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esCourse
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal c1 As System.Int32, ByVal c2 As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(c1, c2)
			Else
				Return LoadByPrimaryKeyStoredProcedure(c1, c2)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal c1 As System.Int32, ByVal c2 As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(c1, c2)
			Else
				Return LoadByPrimaryKeyStoredProcedure(c1, c2)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal c1 As System.Int32, ByVal c2 As System.String) As Boolean
		
			Dim query As New CourseQuery()
			query.Where(query.C1 = c1 And query.C2 = c2)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal c1 As System.Int32, ByVal c2 As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("C1", c1)
						parms.Add("C2", c2)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Class.C1
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property C1 As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(CourseMetadata.ColumnNames.C1)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(CourseMetadata.ColumnNames.C1, value) Then
					OnPropertyChanged(CourseMetadata.PropertyNames.C1)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Class.C2
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property C2 As System.String
			Get
				Return MyBase.GetSystemString(CourseMetadata.ColumnNames.C2)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CourseMetadata.ColumnNames.C2, value) Then
					OnPropertyChanged(CourseMetadata.PropertyNames.C2)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Class.ClassName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ClassName As System.String
			Get
				Return MyBase.GetSystemString(CourseMetadata.ColumnNames.ClassName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CourseMetadata.ColumnNames.ClassName, value) Then
					OnPropertyChanged(CourseMetadata.PropertyNames.ClassName)
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
												
						Case "C1"
							Me.str().C1 = CType(value, string)
												
						Case "C2"
							Me.str().C2 = CType(value, string)
												
						Case "ClassName"
							Me.str().ClassName = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "C1"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.C1 = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(CourseMetadata.PropertyNames.C1)
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
		
			Public Sub New(ByVal entity As esCourse)
				Me.entity = entity
			End Sub				
		
	
			Public Property C1 As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.C1
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.C1 = Nothing
					Else
						entity.C1 = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property C2 As System.String 
				Get
					Dim data_ As System.String = entity.C2
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.C2 = Nothing
					Else
						entity.C2 = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property ClassName As System.String 
				Get
					Dim data_ As System.String = entity.ClassName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ClassName = Nothing
					Else
						entity.ClassName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esCourse
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CourseMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CourseQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CourseQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CourseQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CourseQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As CourseQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esCourseCollection
		Inherits esEntityCollection(Of Course)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CourseMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CourseCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As CourseQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CourseQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CourseQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CourseQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CourseQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CourseQuery))
		End Sub
		
		#End Region
						
		Private m_query As CourseQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esCourseQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CourseMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "C1" 
					Return Me.C1
				Case "C2" 
					Return Me.C2
				Case "ClassName" 
					Return Me.ClassName
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property C1 As esQueryItem
			Get
				Return New esQueryItem(Me, CourseMetadata.ColumnNames.C1, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property C2 As esQueryItem
			Get
				Return New esQueryItem(Me, CourseMetadata.ColumnNames.C2, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property ClassName As esQueryItem
			Get
				Return New esQueryItem(Me, CourseMetadata.ColumnNames.ClassName, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Course 
		Inherits esCourse
		
	
		#Region "UpToStudentCollection - Many To Many"
		''' <summary>
		''' Many to Many
		''' Foreign Key Name - FK_StudentClass_Class
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToStudentCollection As StudentCollection
		
			Get
				If Me._UpToStudentCollection Is Nothing Then
					Me._UpToStudentCollection = New StudentCollection()
					Me._UpToStudentCollection.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("UpToStudentCollection", Me._UpToStudentCollection)
					If Not Me.es.IsLazyLoadDisabled And Not Me.C1.Equals(Nothing) Then 
				
						Dim m As New StudentQuery("m")
						Dim j As New StudentClassQuery("j")
						m.Select(m)
						m.InnerJoin(j).On(m.S1 = j.Sid1 And m.S2 = j.Sid2)
                        m.Where(j.Cid1 = Me.C1)
                        m.Where(j.Cid2 = Me.C2)

						Me._UpToStudentCollection.Load(m)

					End If
				End If

				Return Me._UpToStudentCollection
			End Get
			
			Set(ByVal value As StudentCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._UpToStudentCollection Is Nothing Then

					Me.RemovePostSave("UpToStudentCollection")
					Me._UpToStudentCollection = Nothing
					Me.OnPropertyChanged("UpToStudentCollection")

				End If
			End Set	
			
		End Property

		''' <summary>
		''' Many to Many Associate
		''' Foreign Key Name - FK_StudentClass_Class
		''' </summary>
		Public Sub AssociateStudentCollection(entity As Student)
			If Me._StudentClassCollection Is Nothing Then
				Me._StudentClassCollection = New StudentClassCollection()
				Me._StudentClassCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("StudentClassCollection", Me._StudentClassCollection)
			End If
			
			Dim obj As StudentClass = Me._StudentClassCollection.AddNew()
			obj.Cid1 = Me.C1
			obj.Cid2 = Me.C2
			obj.Sid1 = entity.S1
			obj.Sid2 = entity.S2			
			
		End Sub

		''' <summary>
		''' Many to Many Dissociate
		''' Foreign Key Name - FK_StudentClass_Class
		''' </summary>
		Public Sub DissociateStudentCollection(entity As Student)
			If Me._StudentClassCollection Is Nothing Then
				Me._StudentClassCollection = new StudentClassCollection()
				Me._StudentClassCollection.es.Connection.Name = Me.es.Connection.Name
				Me.SetPostSave("StudentClassCollection", Me._StudentClassCollection)
			End If

			Dim obj As StudentClass = Me._StudentClassCollection.AddNew()
			obj.Cid1 = Me.C1
			obj.Cid2 = Me.C2
            obj.Sid1 = entity.S1
            obj.Sid2 = entity.S2
			obj.AcceptChanges()
			obj.MarkAsDeleted()
		End Sub

		Private _UpToStudentCollection As StudentCollection
		Private _StudentClassCollection As StudentClassCollection
		#End Region

		#Region "StudentClassCollectionByCid1 - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_StudentClassCollectionByCid1() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Course.StudentClassCollectionByCid1_Delegate)
				map.PropertyName = "StudentClassCollectionByCid1"
				map.MyColumnName = "CID1,CID2"
				map.ParentColumnName = "C1,C2"
				map.IsMultiPartKey = true
				Return map
			End Get
		End Property

		Private Shared Sub StudentClassCollectionByCid1_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New CourseQuery(data.NextAlias())
			
			Dim mee As StudentClassQuery = If(data.You IsNot Nothing, TryCast(data.You, StudentClassQuery), New StudentClassQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.C1 = mee.Cid1 And parent.C2 = mee.Cid2)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_StudentClass_Class
		''' </summary>

		<XmlIgnore()> _ 
		Public Property StudentClassCollectionByCid1 As StudentClassCollection 
		
			Get
				If Me._StudentClassCollectionByCid1 Is Nothing Then
					Me._StudentClassCollectionByCid1 = New StudentClassCollection()
					Me._StudentClassCollectionByCid1.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("StudentClassCollectionByCid1", Me._StudentClassCollectionByCid1)
				
					If Not Me.C1.Equals(Nothing) AndAlso Not Me.C2.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._StudentClassCollectionByCid1.Query.Where(Me._StudentClassCollectionByCid1.Query.Cid1 = Me.C1)
							Me._StudentClassCollectionByCid1.Query.Where(Me._StudentClassCollectionByCid1.Query.Cid2 = Me.C2)
							Me._StudentClassCollectionByCid1.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._StudentClassCollectionByCid1.fks.Add(StudentClassMetadata.ColumnNames.Cid1, Me.C1)
						Me._StudentClassCollectionByCid1.fks.Add(StudentClassMetadata.ColumnNames.Cid2, Me.C2)
					End If
				End If

				Return Me._StudentClassCollectionByCid1
			End Get
			
			Set(ByVal value As StudentClassCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._StudentClassCollectionByCid1 Is Nothing Then

					Me.RemovePostSave("StudentClassCollectionByCid1")
					Me._StudentClassCollectionByCid1 = Nothing
					Me.OnPropertyChanged("StudentClassCollectionByCid1")

				End If
			End Set				
			
		End Property
		

		private _StudentClassCollectionByCid1 As StudentClassCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "StudentClassCollectionByCid1"
					coll = Me.StudentClassCollectionByCid1
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "StudentClassCollectionByCid1", GetType(StudentClassCollection), New StudentClass()))
			Return props
			
		End Function
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Course")> _
    <XmlType(TypeName:="CourseProxyStub")> _
    <Serializable> _
    Partial Public Class CourseProxyStub
	
		Public Sub New()
            Me._entity = New Course()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Course)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Course, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As CourseProxyStub) As Course
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Course)
        End Function
		

		<DataMember(Name:="C1", Order:=1, EmitDefaultValue:=False)> _		
        Public Property C1 As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CourseMetadata.ColumnNames.C1)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.C1
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.C1 = value
			End Set
			
		End Property

		<DataMember(Name:="C2", Order:=2, EmitDefaultValue:=False)> _		
        Public Property C2 As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CourseMetadata.ColumnNames.C2)
					Return CType(o, System.String)
                Else
					Return Me.Entity.C2
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.C2 = value
			End Set
			
		End Property

		<DataMember(Name:="ClassName", Order:=3, EmitDefaultValue:=False)> _		
        Public Property ClassName As System.String
        
            Get
                If Me.IncludeColumn(CourseMetadata.ColumnNames.ClassName) Then
                    Return Me.Entity.ClassName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.ClassName = value
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
        Public Property Entity As Course
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Course()
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
        Public _entity As Course
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="CourseCollection")> _
    <XmlType(TypeName:="CourseCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class CourseCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Course))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Course), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As CourseCollectionProxyStub) As CourseCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Course)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Course), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Course In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New CourseProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New CourseProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Course In coll.es.DeletedEntities
                    Collection.Add(New CourseProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of CourseProxyStub)		

        Public Function GetCollection As CourseCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New CourseCollection()
					
		            Dim proxy As CourseProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As CourseCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class CourseMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CourseMetadata.ColumnNames.C1, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = CourseMetadata.PropertyNames.C1
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(CourseMetadata.ColumnNames.C2, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CourseMetadata.PropertyNames.C2
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(CourseMetadata.ColumnNames.ClassName, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = CourseMetadata.PropertyNames.ClassName
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As CourseMetadata
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
			 Public Const C1 As String = "C1"
			 Public Const C2 As String = "C2"
			 Public Const ClassName As String = "ClassName"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const C1 As String = "C1"
			 Public Const C2 As String = "C2"
			 Public Const ClassName As String = "ClassName"
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
			SyncLock GetType(CourseMetadata)
			
				If CourseMetadata.mapDelegates Is Nothing Then
					CourseMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CourseMetadata._meta Is Nothing Then
					CourseMetadata._meta = New CourseMetadata()
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
				


				meta.AddTypeMap("C1", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("C2", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("ClassName", new esTypeMap("varchar", "System.String"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "Class"
				meta.Destination = "Class"
				
				meta.spInsert = "proc_ClassInsert"
				meta.spUpdate = "proc_ClassUpdate"
				meta.spDelete = "proc_ClassDelete"
				meta.spLoadAll = "proc_ClassLoadAll"
				meta.spLoadByPrimaryKey = "proc_ClassLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CourseMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
