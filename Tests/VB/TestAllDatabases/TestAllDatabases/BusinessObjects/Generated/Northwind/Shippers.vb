
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
	' Encapsulates the 'Shippers' table
	' </summary>

	<System.Diagnostics.DebuggerDisplay("Data = {Debug}")> _ 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(Shippers))> _
	<XmlType("Shippers")> _ 
	<Table(Name:="Shippers")> _	
	Partial Public Class Shippers 
		Inherits esShippers
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New Shippers()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal shipperID As System.Int32)
			Dim obj As New Shippers()
			obj.ShipperID = shipperID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal shipperID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New Shippers()
			obj.ShipperID = shipperID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As Shippers) As ShippersProxyStub
			Return New ShippersProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property ShipperID As Nullable(Of System.Int32)
			Get
				Return MyBase.ShipperID
			End Get
			Set
				MyBase.ShipperID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = false)> _
		Public Overrides Property CompanyName As System.String
			Get
				Return MyBase.CompanyName
			End Get
			Set
				MyBase.CompanyName = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Phone As System.String
			Get
				Return MyBase.Phone
			End Get
			Set
				MyBase.Phone = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<DebuggerDisplay("Count = {Count}")> _ 
	<DebuggerVisualizer(GetType(EntitySpaces.DebuggerVisualizer.esVisualizer))> _ 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("ShippersCollection")> _
	Partial Public Class ShippersCollection
		Inherits esShippersCollection
		Implements IEnumerable(Of Shippers)
	
		Public Function FindByPrimaryKey(ByVal shipperID As System.Int32) As Shippers
			Return MyBase.SingleOrDefault(Function(e) e.ShipperID.HasValue AndAlso e.ShipperID.Value = shipperID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As ShippersCollection) As ShippersCollectionProxyStub
            Return New ShippersCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(Shippers))> _
		Public Class ShippersCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of ShippersCollection)
			
			Public Shared Widening Operator CType(packet As ShippersCollectionWCFPacket) As ShippersCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As ShippersCollection) As ShippersCollectionWCFPacket
				Return New ShippersCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class




	<DebuggerDisplay("Query = {Parse()}")> _ 
	<Serializable> _ 
	<DataContract(Name := "ShippersQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class ShippersQuery 
		Inherits esShippersQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "ShippersQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As ShippersQuery) As String
			Return ShippersQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As ShippersQuery
			Return DirectCast(ShippersQuery.SerializeHelper.FromXml(query, GetType(ShippersQuery)), ShippersQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esShippers
		Inherits EntityBase
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal shipperID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(shipperID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(shipperID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal shipperID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(shipperID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(shipperID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal shipperID As System.Int32) As Boolean
		
			Dim query As New ShippersQuery()
			query.Where(query.ShipperID = shipperID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal shipperID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("ShipperID", shipperID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to Shippers.ShipperID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property ShipperID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(ShippersMetadata.ColumnNames.ShipperID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(ShippersMetadata.ColumnNames.ShipperID, value) Then
					OnPropertyChanged(ShippersMetadata.PropertyNames.ShipperID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Shippers.CompanyName
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property CompanyName As System.String
			Get
				Return MyBase.GetSystemString(ShippersMetadata.ColumnNames.CompanyName)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ShippersMetadata.ColumnNames.CompanyName, value) Then
					OnPropertyChanged(ShippersMetadata.PropertyNames.CompanyName)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to Shippers.Phone
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Phone As System.String
			Get
				Return MyBase.GetSystemString(ShippersMetadata.ColumnNames.Phone)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(ShippersMetadata.ColumnNames.Phone, value) Then
					OnPropertyChanged(ShippersMetadata.PropertyNames.Phone)
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
												
						Case "ShipperID"
							Me.str().ShipperID = CType(value, string)
												
						Case "CompanyName"
							Me.str().CompanyName = CType(value, string)
												
						Case "Phone"
							Me.str().Phone = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "ShipperID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.ShipperID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(ShippersMetadata.PropertyNames.ShipperID)
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
		
			Public Sub New(ByVal entity As esShippers)
				Me.entity = entity
			End Sub				
		
	
			Public Property ShipperID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.ShipperID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.ShipperID = Nothing
					Else
						entity.ShipperID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property CompanyName As System.String 
				Get
					Dim data_ As System.String = entity.CompanyName
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.CompanyName = Nothing
					Else
						entity.CompanyName = Convert.ToString(Value)
					End If
				End Set
			End Property
		  	
			Public Property Phone As System.String 
				Get
					Dim data_ As System.String = entity.Phone
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Phone = Nothing
					Else
						entity.Phone = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esShippers
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ShippersMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As ShippersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ShippersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As ShippersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As ShippersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As ShippersQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esShippersCollection
		Inherits CollectionBase(Of Shippers)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return ShippersMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "ShippersCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As ShippersQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New ShippersQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As ShippersQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New ShippersQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As ShippersQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, ShippersQuery))
		End Sub
		
		#End Region
						
		Private m_query As ShippersQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esShippersQuery 
		Inherits QueryBase 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return ShippersMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "ShipperID" 
					Return Me.ShipperID
				Case "CompanyName" 
					Return Me.CompanyName
				Case "Phone" 
					Return Me.Phone
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property ShipperID As esQueryItem
			Get
				Return New esQueryItem(Me, ShippersMetadata.ColumnNames.ShipperID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property CompanyName As esQueryItem
			Get
				Return New esQueryItem(Me, ShippersMetadata.ColumnNames.CompanyName, esSystemType.String)
			End Get
		End Property 
		
		Public ReadOnly Property Phone As esQueryItem
			Get
				Return New esQueryItem(Me, ShippersMetadata.ColumnNames.Phone, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class Shippers 
		Inherits esShippers
		
	
		#Region "OrdersCollectionByShipVia - Zero To Many"
		
		Public Shared ReadOnly Property Prefetch_OrdersCollectionByShipVia() As esPrefetchMap
			Get
				Dim map As New esPrefetchMap()
				map.PrefetchDelegate = New esPrefetchDelegate(AddressOf BusinessObjects.Shippers.OrdersCollectionByShipVia_Delegate)
				map.PropertyName = "OrdersCollectionByShipVia"
				map.MyColumnName = "ShipVia"
				map.ParentColumnName = "ShipperID"
				map.IsMultiPartKey = false
				Return map
			End Get
		End Property

		Private Shared Sub OrdersCollectionByShipVia_Delegate(ByVal data As esPrefetchParameters)
		
			Dim parent As New ShippersQuery(data.NextAlias())
			
			Dim mee As OrdersQuery = If(data.You IsNot Nothing, TryCast(data.You, OrdersQuery), New OrdersQuery(data.NextAlias()))

			If data.Root Is Nothing Then
				data.Root = mee
			End If
			
			data.Root.InnerJoin(parent).On(parent.ShipperID = mee.ShipVia)

			data.You = parent
			
		End Sub		

		''' <summary>
		''' Zero to Many
		''' Foreign Key Name - FK_Orders_Shippers
		''' </summary>

		<XmlIgnore()> _ 
		Public Property OrdersCollectionByShipVia As OrdersCollection 
		
			Get
				If Me._OrdersCollectionByShipVia Is Nothing Then
					Me._OrdersCollectionByShipVia = New OrdersCollection()
					Me._OrdersCollectionByShipVia.es.Connection.Name = Me.es.Connection.Name
					Me.SetPostSave("OrdersCollectionByShipVia", Me._OrdersCollectionByShipVia)
				
					If Not Me.ShipperID.Equals(Nothing) Then
					
						If Not Me.es.IsLazyLoadDisabled Then
						
							Me._OrdersCollectionByShipVia.Query.Where(Me._OrdersCollectionByShipVia.Query.ShipVia = Me.ShipperID)
							Me._OrdersCollectionByShipVia.Query.Load()
						End If

						' Auto-hookup Foreign Keys
						Me._OrdersCollectionByShipVia.fks.Add(OrdersMetadata.ColumnNames.ShipVia, Me.ShipperID)
					End If
				End If

				Return Me._OrdersCollectionByShipVia
			End Get
			
			Set(ByVal value As OrdersCollection)
				If Not value Is Nothing Then Throw New Exception("'value' Must be null")

				If Not Me._OrdersCollectionByShipVia Is Nothing Then

					Me.RemovePostSave("OrdersCollectionByShipVia")
					Me._OrdersCollectionByShipVia = Nothing
					Me.OnPropertyChanged("OrdersCollectionByShipVia")

				End If
			End Set				
			
		End Property
		

		private _OrdersCollectionByShipVia As OrdersCollection
		#End Region

		
		
		
		Protected Overrides Function CreateCollectionForPrefetch(name As String) As esEntityCollectionBase
			Dim coll As esEntityCollectionBase = Nothing

			Select Case name
			
				Case "OrdersCollectionByShipVia"
					coll = Me.OrdersCollectionByShipVia
					Exit Select	
			End Select

			Return coll
		End Function
					
		''' <summary>
		''' Used internally by the entity's hierarchical properties.
		''' </summary>
		Protected Overrides Function GetHierarchicalProperties() As List(Of esPropertyDescriptor)
		
			Dim props As New List(Of esPropertyDescriptor)
			props.Add(new esPropertyDescriptor(Me, "OrdersCollectionByShipVia", GetType(OrdersCollection), New Orders()))
			Return props
			
		End Function
		
		''' <summary>
		''' Called by ApplyPostSaveKeys 
		''' </summary>
		''' <param name="coll">The collection to enumerate over</param>
		''' <param name="key">"The column name</param>
		''' <param name="value">The column value</param>
		Private Sub Apply(coll As esEntityCollectionBase, key As String, value As Object)
			For Each obj As esEntity In coll
				If obj.es.IsAdded Then
					obj.SetProperty(key, value)
				End If
			Next
		End Sub
		
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PostSave.
		''' </summary>
		Protected Overrides Sub ApplyPostSaveKeys()
		
			If Not Me._OrdersCollectionByShipVia Is Nothing Then
				Apply(Me._OrdersCollectionByShipVia, "ShipVia", Me.ShipperID)
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="Shippers")> _
    <XmlType(TypeName:="ShippersProxyStub")> _
    <Serializable> _
    Partial Public Class ShippersProxyStub
	
		Public Sub New()
            Me._entity = New Shippers()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Shippers)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As Shippers, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As ShippersProxyStub) As Shippers
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(Shippers)
        End Function
		

		<DataMember(Name:="a0", Order:=1, EmitDefaultValue:=False)> _		
        Public Property ShipperID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(ShippersMetadata.ColumnNames.ShipperID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.ShipperID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.ShipperID = value
			End Set
			
		End Property

		<DataMember(Name:="a1", Order:=2, EmitDefaultValue:=False)> _		
        Public Property CompanyName As System.String
        
            Get
                If Me.IncludeColumn(ShippersMetadata.ColumnNames.CompanyName) Then
                    Return Me.Entity.CompanyName
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.CompanyName = value
			End Set
			
		End Property

		<DataMember(Name:="a2", Order:=3, EmitDefaultValue:=False)> _		
        Public Property Phone As System.String
        
            Get
                If Me.IncludeColumn(ShippersMetadata.ColumnNames.Phone) Then
                    Return Me.Entity.Phone
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Phone = value
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
        Public Property Entity As Shippers
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New Shippers()
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
        Public _entity As Shippers
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="ShippersCollection")> _
    <XmlType(TypeName:="ShippersCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class ShippersCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of Shippers))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of Shippers), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As ShippersCollectionProxyStub) As ShippersCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(Shippers)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of Shippers), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As Shippers In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New ShippersProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New ShippersProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As Shippers In coll.es.DeletedEntities
                    Collection.Add(New ShippersProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of ShippersProxyStub)		

        Public Function GetCollection As ShippersCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New ShippersCollection()
					
		            Dim proxy As ShippersProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As ShippersCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class ShippersMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(ShippersMetadata.ColumnNames.ShipperID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = ShippersMetadata.PropertyNames.ShipperID
			c.IsInPrimaryKey = True
			c.IsAutoIncrement = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(ShippersMetadata.ColumnNames.CompanyName, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = ShippersMetadata.PropertyNames.CompanyName
			c.CharacterMaxLength = 40
			m_columns.Add(c)
				
			c = New esColumnMetadata(ShippersMetadata.ColumnNames.Phone, 2, GetType(System.String), esSystemType.String)	
			c.PropertyName = ShippersMetadata.PropertyNames.Phone
			c.CharacterMaxLength = 24
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As ShippersMetadata
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
			 Public Const ShipperID As String = "ShipperID"
			 Public Const CompanyName As String = "CompanyName"
			 Public Const Phone As String = "Phone"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const ShipperID As String = "ShipperID"
			 Public Const CompanyName As String = "CompanyName"
			 Public Const Phone As String = "Phone"
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
			SyncLock GetType(ShippersMetadata)
			
				If ShippersMetadata.mapDelegates Is Nothing Then
					ShippersMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If ShippersMetadata._meta Is Nothing Then
					ShippersMetadata._meta = New ShippersMetadata()
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
				


				meta.AddTypeMap("ShipperID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("CompanyName", new esTypeMap("nvarchar", "System.String"))
				meta.AddTypeMap("Phone", new esTypeMap("nvarchar", "System.String"))			
				meta.Catalog = "Northwind"
				meta.Schema = "dbo"
				 
				meta.Source = "Shippers"
				meta.Destination = "Shippers"
				
				meta.spInsert = "proc_ShippersInsert"
				meta.spUpdate = "proc_ShippersUpdate"
				meta.spDelete = "proc_ShippersDelete"
				meta.spLoadAll = "proc_ShippersLoadAll"
				meta.spLoadByPrimaryKey = "proc_ShippersLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As ShippersMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
