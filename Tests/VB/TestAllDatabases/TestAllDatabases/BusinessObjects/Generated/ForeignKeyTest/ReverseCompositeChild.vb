
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
	' Encapsulates the 'ReverseCompositeChild' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(ReverseCompositeChild))> _
	<XmlType("ReverseCompositeChild")> _ 
	<Table(Name:="ReverseCompositeChild")> _	
	Partial Public Class ReverseCompositeChild 
		Inherits esReverseCompositeChild
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New ReverseCompositeChild()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal childId As System.Int32, ByVal parentKeyId As System.Int32, ByVal parentKeySub As System.String)
			Dim obj As New ReverseCompositeChild()
			obj.ChildId = childId
			obj.ParentKeyId = parentKeyId
			obj.ParentKeySub = parentKeySub
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal childId As System.Int32, ByVal parentKeyId As System.Int32, ByVal parentKeySub As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New ReverseCompositeChild()
			obj.ChildId = childId
			obj.ParentKeyId = parentKeyId
			obj.ParentKeySub = parentKeySub
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ReverseCompositeChild) As ReverseCompositeChildProxyStub
			Return New ReverseCompositeChildProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property ChildId As Nullable(Of System.Int32)
			Get
				Return MyBase.ChildId
			End Get
			Set
				MyBase.ChildId = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property ParentKeyId As Nullable(Of System.Int32)
			Get
				Return MyBase.ParentKeyId
			End Get
			Set
				MyBase.ParentKeyId = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property ParentKeySub As System.String
			Get
				Return MyBase.ParentKeySub
			End Get
			Set
				MyBase.ParentKeySub = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Description As System.String
			Get
				Return MyBase.Description
			End Get
			Set
				MyBase.Description = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ReverseCompositeChildCollection")> _
	Partial Public Class ReverseCompositeChildCollection
		Inherits esReverseCompositeChildCollection
		Implements IEnumerable(Of ReverseCompositeChild)
	
		Public Function FindByPrimaryKey(ByVal childId As System.Int32, ByVal parentKeyId As System.Int32, ByVal parentKeySub As System.String) As ReverseCompositeChild
			Return MyBase.SingleOrDefault(Function(e) e.ChildId.HasValue AndAlso e.ChildId.Value = childId And e.ParentKeyId.HasValue AndAlso e.ParentKeyId.Value = parentKeyId And e.ParentKeySub = parentKeySub)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ReverseCompositeChildCollection) As ReverseCompositeChildCollectionProxyStub
            Return New ReverseCompositeChildCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(ReverseCompositeChild))> _
		Public Class ReverseCompositeChildCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ReverseCompositeChildCollection)
			
			Public Shared Widening Operator CType(packet As ReverseCompositeChildCollectionWCFPacket) As ReverseCompositeChildCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ReverseCompositeChildCollection) As ReverseCompositeChildCollectionWCFPacket
				Return New ReverseCompositeChildCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "ReverseCompositeChildQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ReverseCompositeChildQuery 
		Inherits esReverseCompositeChildQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ReverseCompositeChildQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ReverseCompositeChildQuery) As String
			Return ReverseCompositeChildQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ReverseCompositeChildQuery
			Return DirectCast(ReverseCompositeChildQuery.SerializeHelper.FromXml(query, GetType(ReverseCompositeChildQuery)), ReverseCompositeChildQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esReverseCompositeChild
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal childId As System.Int32, ByVal parentKeyId As System.Int32, ByVal parentKeySub As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(childId, parentKeyId, parentKeySub)
			Else
				Return LoadByPrimaryKeyStoredProcedure(childId, parentKeyId, parentKeySub)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal childId As System.Int32, ByVal parentKeyId As System.Int32, ByVal parentKeySub As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(childId, parentKeyId, parentKeySub)
			Else
				Return LoadByPrimaryKeyStoredProcedure(childId, parentKeyId, parentKeySub)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal childId As System.Int32, ByVal parentKeyId As System.Int32, ByVal parentKeySub As System.String) As Boolean
		
			Dim query As New ReverseCompositeChildQuery()
			query.Where(query.ChildId = childId And query.ParentKeyId = parentKeyId And query.ParentKeySub = parentKeySub)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal childId As System.Int32, ByVal parentKeyId As System.Int32, ByVal parentKeySub As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("ChildId", childId)
						parms.Add("ParentKeyId", parentKeyId)
						parms.Add("ParentKeySub", parentKeySub)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to ReverseCompositeChild.ChildId
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ChildId As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ChildId)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ChildId, value) Then
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ChildId)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ReverseCompositeChild.ParentKeyId
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ParentKeyId As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, value) Then
					Me._UpToReverseCompositeParentByParentKeyId = Nothing
					Me.OnPropertyChanged("UpToReverseCompositeParentByParentKeyId")
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ParentKeyId)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ReverseCompositeChild.ParentKeySub
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ParentKeySub As System.String
			Get
				Return MyBase.GetSystemString(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, value) Then
					Me._UpToReverseCompositeParentByParentKeyId = Nothing
					Me.OnPropertyChanged("UpToReverseCompositeParentByParentKeyId")
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ParentKeySub)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to ReverseCompositeChild.Description
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Description As System.String
			Get
				Return MyBase.GetSystemString(ReverseCompositeChildMetadata.ColumnNames.Description)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ReverseCompositeChildMetadata.ColumnNames.Description, value) Then
					OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.Description)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToReverseCompositeParentByParentKeyId As ReverseCompositeParent
		
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
												
						Case "ChildId"
							Me.str().ChildId = CType(value, string)
												
						Case "ParentKeyId"
							Me.str().ParentKeyId = CType(value, string)
												
						Case "ParentKeySub"
							Me.str().ParentKeySub = CType(value, string)
												
						Case "Description"
							Me.str().Description = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "ChildId"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ChildId = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ChildId)
							End If
						
						Case "ParentKeyId"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ParentKeyId = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ReverseCompositeChildMetadata.PropertyNames.ParentKeyId)
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
		
			Public Sub New(ByVal entity As esReverseCompositeChild)
				Me.entity = entity
			End Sub				
		
	
			Public Property ChildId As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ChildId
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ChildId = Nothing
					Else
						entity.ChildId = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property ParentKeyId As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ParentKeyId
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ParentKeyId = Nothing
					Else
						entity.ParentKeyId = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property ParentKeySub As System.String 
				Get
					Dim data_ As System.String = entity.ParentKeySub
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ParentKeySub = Nothing
					Else
						entity.ParentKeySub = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Description As System.String 
				Get
					Dim data_ As System.String = entity.Description
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Description = Nothing
					Else
						entity.Description = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esReverseCompositeChild
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ReverseCompositeChildMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ReverseCompositeChildQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ReverseCompositeChildQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ReverseCompositeChildQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ReverseCompositeChildQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ReverseCompositeChildQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esReverseCompositeChildCollection
		Inherits esEntityCollection(Of ReverseCompositeChild)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ReverseCompositeChildMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ReverseCompositeChildCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ReverseCompositeChildQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ReverseCompositeChildQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ReverseCompositeChildQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ReverseCompositeChildQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ReverseCompositeChildQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ReverseCompositeChildQuery))
		End Sub
		
		#End Region
						
		Private m_query As ReverseCompositeChildQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esReverseCompositeChildQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ReverseCompositeChildMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "ChildId" 
					Return Me.ChildId
				Case "ParentKeyId" 
					Return Me.ParentKeyId
				Case "ParentKeySub" 
					Return Me.ParentKeySub
				Case "Description" 
					Return Me.Description
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property ChildId As esQueryItem
			Get
				Return New esQueryItem(Me, ReverseCompositeChildMetadata.ColumnNames.ChildId, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ParentKeyId As esQueryItem
			Get
				Return New esQueryItem(Me, ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property ParentKeySub As esQueryItem
			Get
				Return New esQueryItem(Me, ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Description As esQueryItem
			Get
				Return New esQueryItem(Me, ReverseCompositeChildMetadata.ColumnNames.Description, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class ReverseCompositeChild 
		Inherits esReverseCompositeChild
		
	
		#Region "UpToReverseCompositeParentByParentKeyId - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_ReverseCompositeChild_ReverseCompositeParent
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToReverseCompositeParentByParentKeyId As ReverseCompositeParent
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToReverseCompositeParentByParentKeyId Is Nothing _
						 AndAlso Not ParentKeyId.Equals(Nothing)  AndAlso Not ParentKeySub.Equals(Nothing)  Then
						
					Me._UpToReverseCompositeParentByParentKeyId = New ReverseCompositeParent()
					Me._UpToReverseCompositeParentByParentKeyId.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToReverseCompositeParentByParentKeyId", Me._UpToReverseCompositeParentByParentKeyId)
					Me._UpToReverseCompositeParentByParentKeyId.Query.Where(Me._UpToReverseCompositeParentByParentKeyId.Query.KeyId = Me.ParentKeyId)
					Me._UpToReverseCompositeParentByParentKeyId.Query.Where(Me._UpToReverseCompositeParentByParentKeyId.Query.KeySub = Me.ParentKeySub)
					Me._UpToReverseCompositeParentByParentKeyId.Query.Load()
				End If

				Return Me._UpToReverseCompositeParentByParentKeyId
			End Get
			
            Set(ByVal value As ReverseCompositeParent)
				Me.RemovePreSave("UpToReverseCompositeParentByParentKeyId")
				
				Dim changed as Boolean = Me._UpToReverseCompositeParentByParentKeyId IsNot value

				If value Is Nothing Then
				
					Me.ParentKeyId = Nothing
				
					Me.ParentKeySub = Nothing
				
					Me._UpToReverseCompositeParentByParentKeyId = Nothing
				Else
				
					Me.ParentKeyId = value.KeyId
					
					Me.ParentKeySub = value.KeySub
					
					Me._UpToReverseCompositeParentByParentKeyId = value
					Me.SetPreSave("UpToReverseCompositeParentByParentKeyId", Me._UpToReverseCompositeParentByParentKeyId)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToReverseCompositeParentByParentKeyId")
				End If
			End Set	

		End Property
		#End Region

		
		
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="ReverseCompositeChild")> _
    <XmlType(TypeName:="ReverseCompositeChildProxyStub")> _
    <Serializable> _
    Partial Public Class ReverseCompositeChildProxyStub
	
		Public Sub New()
            Me._entity = New ReverseCompositeChild()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ReverseCompositeChild)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As ReverseCompositeChild, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ReverseCompositeChildProxyStub) As ReverseCompositeChild
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(ReverseCompositeChild)
        End Function
		

		<DataMember(Name:="ChildId", Order:=1, EmitDefaultValue:=False)> _		
        Public Property ChildId As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ReverseCompositeChildMetadata.ColumnNames.ChildId)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.ChildId
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ChildId = value
			End Set
			
		End Property

		<DataMember(Name:="ParentKeyId", Order:=2, EmitDefaultValue:=False)> _		
        Public Property ParentKeyId As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.ParentKeyId
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ParentKeyId = value
			End Set
			
		End Property

		<DataMember(Name:="ParentKeySub", Order:=3, EmitDefaultValue:=False)> _		
        Public Property ParentKeySub As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub)
					Return CType(o, System.String)
                Else
					Return Me.Entity.ParentKeySub
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.ParentKeySub = value
			End Set
			
		End Property

		<DataMember(Name:="Description", Order:=4, EmitDefaultValue:=False)> _		
        Public Property Description As System.String
        
            Get
                If Me.IncludeColumn(ReverseCompositeChildMetadata.ColumnNames.Description) Then
                    Return Me.Entity.Description
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Description = value
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
        Public Property Entity As ReverseCompositeChild
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New ReverseCompositeChild()
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
        Public _entity As ReverseCompositeChild
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ReverseCompositeChildCollection")> _
    <XmlType(TypeName:="ReverseCompositeChildCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ReverseCompositeChildCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of ReverseCompositeChild))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of ReverseCompositeChild), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ReverseCompositeChildCollectionProxyStub) As ReverseCompositeChildCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(ReverseCompositeChild)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of ReverseCompositeChild), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As ReverseCompositeChild In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ReverseCompositeChildProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ReverseCompositeChildProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As ReverseCompositeChild In coll.es.DeletedEntities
                    Collection.Add(New ReverseCompositeChildProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ReverseCompositeChildProxyStub)		

        Public Function GetCollection As ReverseCompositeChildCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ReverseCompositeChildCollection()
					
		            Dim proxy As ReverseCompositeChildProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ReverseCompositeChildCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ReverseCompositeChildMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.ChildId, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.ChildId
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.ParentKeyId, 1, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.ParentKeyId
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.ParentKeySub, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.ParentKeySub
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 3
			m_columns.Add(c)
				
			c = New esColumnMetadata(ReverseCompositeChildMetadata.ColumnNames.Description, 3, GetType(System.String), esSystemType.String)	
			c.PropertyName = ReverseCompositeChildMetadata.PropertyNames.Description
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ReverseCompositeChildMetadata
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
			 Public Const ChildId As String = "ChildId"
			 Public Const ParentKeyId As String = "ParentKeyId"
			 Public Const ParentKeySub As String = "ParentKeySub"
			 Public Const Description As String = "Description"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const ChildId As String = "ChildId"
			 Public Const ParentKeyId As String = "ParentKeyId"
			 Public Const ParentKeySub As String = "ParentKeySub"
			 Public Const Description As String = "Description"
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
			SyncLock GetType(ReverseCompositeChildMetadata)
			
				If ReverseCompositeChildMetadata.mapDelegates Is Nothing Then
					ReverseCompositeChildMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ReverseCompositeChildMetadata._meta Is Nothing Then
					ReverseCompositeChildMetadata._meta = New ReverseCompositeChildMetadata()
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
				


				meta.AddTypeMap("ChildId", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ParentKeyId", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("ParentKeySub", new esTypeMap("char", "System.String"))
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "ReverseCompositeChild"
				meta.Destination = "ReverseCompositeChild"
				
				meta.spInsert = "proc_ReverseCompositeChildInsert"
				meta.spUpdate = "proc_ReverseCompositeChildUpdate"
				meta.spDelete = "proc_ReverseCompositeChildDelete"
				meta.spLoadAll = "proc_ReverseCompositeChildLoadAll"
				meta.spLoadByPrimaryKey = "proc_ReverseCompositeChildLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ReverseCompositeChildMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
