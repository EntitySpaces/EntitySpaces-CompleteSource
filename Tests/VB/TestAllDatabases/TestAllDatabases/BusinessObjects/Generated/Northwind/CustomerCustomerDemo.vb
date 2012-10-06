
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
	' Encapsulates the 'CustomerCustomerDemo' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(CustomerCustomerDemo))> _
	<XmlType("CustomerCustomerDemo")> _ 
	<Table(Name:="CustomerCustomerDemo")> _	
	Partial Public Class CustomerCustomerDemo 
		Inherits esCustomerCustomerDemo
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New CustomerCustomerDemo()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal customerID As System.String, ByVal customerTypeID As System.String)
			Dim obj As New CustomerCustomerDemo()
			obj.CustomerID = customerID
			obj.CustomerTypeID = customerTypeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal customerID As System.String, ByVal customerTypeID As System.String, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New CustomerCustomerDemo()
			obj.CustomerID = customerID
			obj.CustomerTypeID = customerTypeID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As CustomerCustomerDemo) As CustomerCustomerDemoProxyStub
			Return New CustomerCustomerDemoProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property CustomerID As System.String
			Get
				Return MyBase.CustomerID
			End Get
			Set
				MyBase.CustomerID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property CustomerTypeID As System.String
			Get
				Return MyBase.CustomerTypeID
			End Get
			Set
				MyBase.CustomerTypeID = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<DebuggerVisualizer(GetType(EntitySpaces.DebuggerVisualizer.esVisualizer))> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("CustomerCustomerDemoCollection")> _
	Partial Public Class CustomerCustomerDemoCollection
		Inherits esCustomerCustomerDemoCollection
		Implements IEnumerable(Of CustomerCustomerDemo)
	
		Public Function FindByPrimaryKey(ByVal customerID As System.String, ByVal customerTypeID As System.String) As CustomerCustomerDemo
			Return MyBase.SingleOrDefault(Function(e) e.CustomerID = customerID And e.CustomerTypeID = customerTypeID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As CustomerCustomerDemoCollection) As CustomerCustomerDemoCollectionProxyStub
            Return New CustomerCustomerDemoCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(CustomerCustomerDemo))> _
		Public Class CustomerCustomerDemoCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of CustomerCustomerDemoCollection)
			
			Public Shared Widening Operator CType(packet As CustomerCustomerDemoCollectionWCFPacket) As CustomerCustomerDemoCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As CustomerCustomerDemoCollection) As CustomerCustomerDemoCollectionWCFPacket
				Return New CustomerCustomerDemoCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "CustomerCustomerDemoQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class CustomerCustomerDemoQuery 
		Inherits esCustomerCustomerDemoQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "CustomerCustomerDemoQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As CustomerCustomerDemoQuery) As String
			Return CustomerCustomerDemoQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As CustomerCustomerDemoQuery
			Return DirectCast(CustomerCustomerDemoQuery.SerializeHelper.FromXml(query, GetType(CustomerCustomerDemoQuery)), CustomerCustomerDemoQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esCustomerCustomerDemo
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerID, customerTypeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(customerID, customerTypeID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(customerID, customerTypeID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			Dim query As New CustomerCustomerDemoQuery()
			query.Where(query.CustomerID = customerID And query.CustomerTypeID = customerTypeID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal customerID As System.String, ByVal customerTypeID As System.String) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("CustomerID", customerID)
						parms.Add("CustomerTypeID", customerTypeID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to CustomerCustomerDemo.CustomerID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CustomerID As System.String
			Get
				Return MyBase.GetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerID, value) Then
					Me._UpToCustomersByCustomerID = Nothing
					Me.OnPropertyChanged("UpToCustomersByCustomerID")
					OnPropertyChanged(CustomerCustomerDemoMetadata.PropertyNames.CustomerID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to CustomerCustomerDemo.CustomerTypeID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CustomerTypeID As System.String
			Get
				Return MyBase.GetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, value) Then
					Me._UpToCustomerDemographicsByCustomerTypeID = Nothing
					Me.OnPropertyChanged("UpToCustomerDemographicsByCustomerTypeID")
					OnPropertyChanged(CustomerCustomerDemoMetadata.PropertyNames.CustomerTypeID)
				End If
			End Set
		End Property	
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToCustomerDemographicsByCustomerTypeID As CustomerDemographics
		
		<CLSCompliant(false)> _
		Dim Friend Protected _UpToCustomersByCustomerID As Customers
		
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
												
						Case "CustomerID"
							Me.str().CustomerID = CType(value, string)
												
						Case "CustomerTypeID"
							Me.str().CustomerTypeID = CType(value, string)
					
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
		
			Public Sub New(ByVal entity As esCustomerCustomerDemo)
				Me.entity = entity
			End Sub				
		
	
			Public Property CustomerID As System.String 
				Get
					Dim data_ As System.String = entity.CustomerID
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CustomerID = Nothing
					Else
						entity.CustomerID = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property CustomerTypeID As System.String 
				Get
					Dim data_ As System.String = entity.CustomerTypeID
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CustomerTypeID = Nothing
					Else
						entity.CustomerTypeID = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esCustomerCustomerDemo
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerCustomerDemoMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As CustomerCustomerDemoQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerCustomerDemoQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As CustomerCustomerDemoQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As CustomerCustomerDemoQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As CustomerCustomerDemoQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esCustomerCustomerDemoCollection
		Inherits CollectionBase(Of CustomerCustomerDemo)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return CustomerCustomerDemoMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "CustomerCustomerDemoCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As CustomerCustomerDemoQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New CustomerCustomerDemoQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As CustomerCustomerDemoQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New CustomerCustomerDemoQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As CustomerCustomerDemoQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, CustomerCustomerDemoQuery))
		End Sub
		
		#End Region
						
		Private m_query As CustomerCustomerDemoQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esCustomerCustomerDemoQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return CustomerCustomerDemoMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "CustomerID" 
					Return Me.CustomerID
				Case "CustomerTypeID" 
					Return Me.CustomerTypeID
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property CustomerID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerCustomerDemoMetadata.ColumnNames.CustomerID, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property CustomerTypeID As esQueryItem
			Get
				Return New esQueryItem(Me, CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class CustomerCustomerDemo 
		Inherits esCustomerCustomerDemo
		
	
		#Region "UpToCustomerDemographicsByCustomerTypeID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_CustomerCustomerDemo
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToCustomerDemographicsByCustomerTypeID As CustomerDemographics
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCustomerDemographicsByCustomerTypeID Is Nothing _
						 AndAlso Not CustomerTypeID.Equals(Nothing)  Then
						
					Me._UpToCustomerDemographicsByCustomerTypeID = New CustomerDemographics()
					Me._UpToCustomerDemographicsByCustomerTypeID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCustomerDemographicsByCustomerTypeID", Me._UpToCustomerDemographicsByCustomerTypeID)
					Me._UpToCustomerDemographicsByCustomerTypeID.Query.Where(Me._UpToCustomerDemographicsByCustomerTypeID.Query.CustomerTypeID = Me.CustomerTypeID)
					Me._UpToCustomerDemographicsByCustomerTypeID.Query.Load()
				End If

				Return Me._UpToCustomerDemographicsByCustomerTypeID
			End Get
			
            Set(ByVal value As CustomerDemographics)
				Me.RemovePreSave("UpToCustomerDemographicsByCustomerTypeID")
				
				Dim changed as Boolean = Me._UpToCustomerDemographicsByCustomerTypeID IsNot value

				If value Is Nothing Then
				
					Me.CustomerTypeID = Nothing
				
					Me._UpToCustomerDemographicsByCustomerTypeID = Nothing
				Else
				
					Me.CustomerTypeID = value.CustomerTypeID
					
					Me._UpToCustomerDemographicsByCustomerTypeID = value
					Me.SetPreSave("UpToCustomerDemographicsByCustomerTypeID", Me._UpToCustomerDemographicsByCustomerTypeID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCustomerDemographicsByCustomerTypeID")
				End If
			End Set	

		End Property
		#End Region

		#Region "UpToCustomersByCustomerID - Many To One"
		''' <summary>
		''' Many to One
		''' Foreign Key Name - FK_CustomerCustomerDemo_Customers
		''' </summary>

		<XmlIgnore()> _		
		Public Property UpToCustomersByCustomerID As Customers
		
			Get
				If Me.es.IsLazyLoadDisabled Then return Nothing
				
				If Me._UpToCustomersByCustomerID Is Nothing _
						 AndAlso Not CustomerID.Equals(Nothing)  Then
						
					Me._UpToCustomersByCustomerID = New Customers()
					Me._UpToCustomersByCustomerID.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToCustomersByCustomerID", Me._UpToCustomersByCustomerID)
					Me._UpToCustomersByCustomerID.Query.Where(Me._UpToCustomersByCustomerID.Query.CustomerID = Me.CustomerID)
					Me._UpToCustomersByCustomerID.Query.Load()
				End If

				Return Me._UpToCustomersByCustomerID
			End Get
			
            Set(ByVal value As Customers)
				Me.RemovePreSave("UpToCustomersByCustomerID")
				
				Dim changed as Boolean = Me._UpToCustomersByCustomerID IsNot value

				If value Is Nothing Then
				
					Me.CustomerID = Nothing
				
					Me._UpToCustomersByCustomerID = Nothing
				Else
				
					Me.CustomerID = value.CustomerID
					
					Me._UpToCustomersByCustomerID = value
					Me.SetPreSave("UpToCustomersByCustomerID", Me._UpToCustomersByCustomerID)
				End If
				
				If changed Then
					Me.OnPropertyChanged("UpToCustomersByCustomerID")
				End If
			End Set	

		End Property
		#End Region

		
		
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="CustomerCustomerDemo")> _
    <XmlType(TypeName:="CustomerCustomerDemoProxyStub")> _
    <Serializable> _
    Partial Public Class CustomerCustomerDemoProxyStub
	
		Public Sub New()
            Me._entity = New CustomerCustomerDemo()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As CustomerCustomerDemo)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As CustomerCustomerDemo, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As CustomerCustomerDemoProxyStub) As CustomerCustomerDemo
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(CustomerCustomerDemo)
        End Function
		

		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _		
        Public Property CustomerID As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CustomerCustomerDemoMetadata.ColumnNames.CustomerID)
					Return CType(o, System.String)
                Else
					Return Me.Entity.CustomerID
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CustomerID = value
			End Set
			
		End Property

		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _		
        Public Property CustomerTypeID As System.String
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID)
					Return CType(o, System.String)
                Else
					Return Me.Entity.CustomerTypeID
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CustomerTypeID = value
			End Set
			
		End Property


		<DataMember(Name := "a10000", Order := 10000)> _
        Public Property esRowState As String
            Get
				Return Me.TheRowState
            End Get

            Set 
				Me.TheRowState = value
            End Set
        End Property
		
		<DataMember(Name := "a10001", Order := 10001, EmitDefaultValue := False)> _
		Private Property ModifiedColumns() As List(Of String)
			Get
				Return Entity.es.ModifiedColumns
			End Get
			Set(ByVal value As List(Of String))
				Entity.es.ModifiedColumns.AddRange(value)
			End Set
		End Property		
		
		<DataMember(Name := "a10002", Order := 10002, EmitDefaultValue := False)> _
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
        Public Property Entity As CustomerCustomerDemo
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New CustomerCustomerDemo()
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
        Public _entity As CustomerCustomerDemo
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="CustomerCustomerDemoCollection")> _
    <XmlType(TypeName:="CustomerCustomerDemoCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class CustomerCustomerDemoCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of CustomerCustomerDemo))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of CustomerCustomerDemo), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As CustomerCustomerDemoCollectionProxyStub) As CustomerCustomerDemoCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(CustomerCustomerDemo)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of CustomerCustomerDemo), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As CustomerCustomerDemo In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New CustomerCustomerDemoProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New CustomerCustomerDemoProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As CustomerCustomerDemo In coll.es.DeletedEntities
                    Collection.Add(New CustomerCustomerDemoProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of CustomerCustomerDemoProxyStub)		

        Public Function GetCollection As CustomerCustomerDemoCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New CustomerCustomerDemoCollection()
					
		            Dim proxy As CustomerCustomerDemoProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As CustomerCustomerDemoCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class CustomerCustomerDemoMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(CustomerCustomerDemoMetadata.ColumnNames.CustomerID, 0, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerCustomerDemoMetadata.PropertyNames.CustomerID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 5
			m_columns.Add(c)
				
			c = New esColumnMetadata(CustomerCustomerDemoMetadata.ColumnNames.CustomerTypeID, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = CustomerCustomerDemoMetadata.PropertyNames.CustomerTypeID
			c.IsInPrimaryKey = True
			c.CharacterMaxLength = 10
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As CustomerCustomerDemoMetadata
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
			 Public Const CustomerID As String = "CustomerID"
			 Public Const CustomerTypeID As String = "CustomerTypeID"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const CustomerID As String = "CustomerID"
			 Public Const CustomerTypeID As String = "CustomerTypeID"
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
			SyncLock GetType(CustomerCustomerDemoMetadata)
			
				If CustomerCustomerDemoMetadata.mapDelegates Is Nothing Then
					CustomerCustomerDemoMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If CustomerCustomerDemoMetadata._meta Is Nothing Then
					CustomerCustomerDemoMetadata._meta = New CustomerCustomerDemoMetadata()
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
				


				meta.AddTypeMap("CustomerID", new esTypeMap("nchar", "System.String"))
				meta.AddTypeMap("CustomerTypeID", new esTypeMap("nchar", "System.String"))			
				meta.Catalog = "Northwind"
				meta.Schema = "dbo"
				 
				meta.Source = "CustomerCustomerDemo"
				meta.Destination = "CustomerCustomerDemo"
				
				meta.spInsert = "proc_CustomerCustomerDemoInsert"
				meta.spUpdate = "proc_CustomerCustomerDemoUpdate"
				meta.spDelete = "proc_CustomerCustomerDemoDelete"
				meta.spLoadAll = "proc_CustomerCustomerDemoLoadAll"
				meta.spLoadByPrimaryKey = "proc_CustomerCustomerDemoLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As CustomerCustomerDemoMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
