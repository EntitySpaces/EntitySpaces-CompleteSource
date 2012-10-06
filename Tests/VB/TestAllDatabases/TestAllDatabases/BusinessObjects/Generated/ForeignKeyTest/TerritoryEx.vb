
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
	' Encapsulates the 'TerritoryEx' table
	' </summary>
 
	<Serializable> _
	<DataContract> _
	<KnownType(GetType(TerritoryEx))> _
	<XmlType("TerritoryEx")> _ 
	<Table(Name:="TerritoryEx")> _	
	Partial Public Class TerritoryEx 
		Inherits esTerritoryEx
		
		<DebuggerBrowsable(DebuggerBrowsableState.RootHidden Or DebuggerBrowsableState.Never)> _		
		Protected Overrides ReadOnly Property Debug() As esEntityDebuggerView()
			Get
				Return MyBase.Debug
			End Get
		End Property
		
		Public Overrides Function CreateInstance() as esEntity
			Return New TerritoryEx()
		End Function
		
		#Region "Static Quick Access Methods"
		Public Shared Sub Delete(ByVal territoryID As System.Int32)
			Dim obj As New TerritoryEx()
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save()
		End Sub

		Public Shared Sub Delete(ByVal territoryID As System.Int32, ByVal sqlAccessType As esSqlAccessType)
			Dim obj As New TerritoryEx()
			obj.TerritoryID = territoryID
			obj.AcceptChanges()
			obj.MarkAsDeleted()
			obj.Save(sqlAccessType)
		End Sub
		#End Region		
				
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As TerritoryEx) As TerritoryExProxyStub
			Return New TerritoryExProxyStub(entity)
		End Operator

		#End Region
		

		#Region "LINQtoSQL overrides (shame but we must do this)"

		<Column(IsPrimaryKey: = true, CanBeNull: = false)> _
		Public Overrides Property TerritoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.TerritoryID
			End Get
			Set
				MyBase.TerritoryID = value
			End Set
		End Property

		<Column(IsPrimaryKey: = false, CanBeNull: = true)> _
		Public Overrides Property Notes As System.String
			Get
				Return MyBase.Notes
			End Get
			Set
				MyBase.Notes = value
			End Set
		End Property
			
		#End Region
			
	End Class


 
	<Serializable> _
	<CollectionDataContract> _
	<XmlType("TerritoryExCollection")> _
	Partial Public Class TerritoryExCollection
		Inherits esTerritoryExCollection
		Implements IEnumerable(Of TerritoryEx)
	
		Public Function FindByPrimaryKey(ByVal territoryID As System.Int32) As TerritoryEx
			Return MyBase.SingleOrDefault(Function(e) e.TerritoryID.HasValue AndAlso e.TerritoryID.Value = territoryID)
		End Function

        #Region "Implicit Casts"
		
        Public Shared Widening Operator CType(ByVal coll As TerritoryExCollection) As TerritoryExCollectionProxyStub
            Return New TerritoryExCollectionProxyStub(coll)
        End Operator
        
		#End Region

				
		#Region "WCF Service Class"

		<DataContract> _
		<KnownType(GetType(TerritoryEx))> _
		Public Class TerritoryExCollectionWCFPacket
			Inherits esCollectionWCFPacket(Of TerritoryExCollection)
			
			Public Shared Widening Operator CType(packet As TerritoryExCollectionWCFPacket) As TerritoryExCollection
				Return packet.Collection
			End Operator

			Public Shared Widening Operator CType(collection As TerritoryExCollection) As TerritoryExCollectionWCFPacket
				Return New TerritoryExCollectionWCFPacket()  With {.Collection = collection}
			End Operator
			
		End Class

		#End Region
		
			
		
	End Class



 
	<Serializable> _ 
	<DataContract(Name := "TerritoryExQuery", [Namespace]:= "http://www.entityspaces.net")> _ 
	Partial Public Class TerritoryExQuery 
		Inherits esTerritoryExQuery
		
		Public Sub New(ByVal joinAlias As String)
			Me.es.JoinAlias = joinAlias
		End Sub	
		
		Protected Overrides Function GetQueryName() As String
			Return "TerritoryExQuery"
		End Function	
		
		#Region "Explicit Casts"

		Public Shared Narrowing Operator CType(ByVal query As TerritoryExQuery) As String
			Return TerritoryExQuery.SerializeHelper.ToXml(query)
		End Operator

		Public Shared Narrowing Operator CType(ByVal query As String) As TerritoryExQuery
			Return DirectCast(TerritoryExQuery.SerializeHelper.FromXml(query, GetType(TerritoryExQuery)), TerritoryExQuery)
		End Operator

		#End Region
			
	End Class

	
	<DataContract> _
	<Serializable()> _
	MustInherit Public Partial Class esTerritoryEx
		Inherits esEntity
		Implements INotifyPropertyChanged
	
		Public Sub New()
		
		End Sub
		
#Region "LoadByPrimaryKey"		
		Public Overridable Function LoadByPrimaryKey(ByVal territoryID As System.Int32) As Boolean
		
			If Me.es.Connection.SqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(territoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(territoryID)
			End If
			
		End Function
	
		Public Overridable Function LoadByPrimaryKey(ByVal sqlAccessType As esSqlAccessType, ByVal territoryID As System.Int32) As Boolean
		
			If sqlAccessType = esSqlAccessType.DynamicSQL
				Return LoadByPrimaryKeyDynamic(territoryID)
			Else
				Return LoadByPrimaryKeyStoredProcedure(territoryID)
			End If
			
		End Function
	
		Private Function LoadByPrimaryKeyDynamic(ByVal territoryID As System.Int32) As Boolean
		
			Dim query As New TerritoryExQuery()
			query.Where(query.TerritoryID = territoryID)
			Return Me.Load(query)
			
		End Function
	
		Private Function LoadByPrimaryKeyStoredProcedure(ByVal territoryID As System.Int32) As Boolean
		
			Dim parms As esParameters = New esParameters()
			parms.Add("TerritoryID", territoryID)
			
			Return MyBase.Load(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, parms)
			
		End Function
#End Region
		
#Region "Properties"
		
		
			
		' <summary>
		' Maps to TerritoryEx.TerritoryID
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property TerritoryID As Nullable(Of System.Int32)
			Get
				Return MyBase.GetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID)
			End Get
			
			Set(ByVal value As Nullable(Of System.Int32))
				If MyBase.SetSystemInt32(TerritoryExMetadata.ColumnNames.TerritoryID, value) Then
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.TerritoryID)
				End If
			End Set
		End Property	
			
		' <summary>
		' Maps to TerritoryEx.Notes
		' </summary>
		<DataMember(EmitDefaultValue:=False)> _
		Public Overridable Property Notes As System.String
			Get
				Return MyBase.GetSystemString(TerritoryExMetadata.ColumnNames.Notes)
			End Get
			
			Set(ByVal value As System.String)
				If MyBase.SetSystemString(TerritoryExMetadata.ColumnNames.Notes, value) Then
					OnPropertyChanged(TerritoryExMetadata.PropertyNames.Notes)
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
												
						Case "TerritoryID"
							Me.str().TerritoryID = CType(value, string)
												
						Case "Notes"
							Me.str().Notes = CType(value, string)
					
					End Select
					
				Else
				
					Select Case name
						
						Case "TerritoryID"
						
							If value Is Nothing Or value.GetType().ToString() = "System.Int32" Then
								Me.TerritoryID = CType(value, Nullable(Of System.Int32))
								OnPropertyChanged(TerritoryExMetadata.PropertyNames.TerritoryID)
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
		
			Public Sub New(ByVal entity As esTerritoryEx)
				Me.entity = entity
			End Sub				
		
	
			Public Property TerritoryID As System.String 
				Get
					Dim data_ As Nullable(Of System.Int32) = entity.TerritoryID
					
					If Not data_.HasValue Then
					
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.TerritoryID = Nothing
					Else
						entity.TerritoryID = Convert.ToInt32(Value)
					End If
				End Set
			End Property
		  	
			Public Property Notes As System.String 
				Get
					Dim data_ As System.String = entity.Notes
					
					if data_ Is Nothing Then
						Return String.Empty
					Else
						Return Convert.ToString(data_)
					End If
				End Get

				Set(ByVal Value as System.String)
					If String.IsNullOrEmpty(value) Then
						entity.Notes = Nothing
					Else
						entity.Notes = Convert.ToString(Value)
					End If
				End Set
			End Property
		  

			Private entity As esTerritoryEx
		End Class
		

        <NonSerialized> _
        <IgnoreDataMember> _		
		Private _esstrings As esStrings
		
#End Region

#Region "Housekeeping methods"

		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return TerritoryExMetadata.Meta()
			End Get
		End Property

#End Region

#Region "Query Logic"

		Public ReadOnly Property Query() As TerritoryExQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New TerritoryExQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property

		Public Overloads Function Load(ByVal query As TerritoryExQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Me.Query.Load()
		End Function

		Protected Sub InitQuery(ByVal query As TerritoryExQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntity).Connection
			End If
		End Sub

#End Region

        <IgnoreDataMember> _
        Private m_query As TerritoryExQuery

	End Class



	<Serializable()> _
	MustInherit Public Partial Class esTerritoryExCollection
		Inherits esEntityCollection(Of TerritoryEx)
		
		#Region "Housekeeping methods"
		Protected Overloads Overrides ReadOnly Property Meta() As IMetadata
			Get
				Return TerritoryExMetadata.Meta()
			End Get
		End Property
		
		Protected Overloads Overrides Function GetCollectionName() As String
			Return "TerritoryExCollection"
		End Function
		
		#End Region
		
		#Region "Query Logic"
		

		<BrowsableAttribute(False)> _ 
		Public ReadOnly Property Query() As TerritoryExQuery
			Get
				If Me.m_query Is Nothing Then
					Me.m_query = New TerritoryExQuery()
					InitQuery(Me.m_query)
				End If
				
				Return Me.m_query
			End Get
		End Property
		
		Public Overloads Function Load(ByVal query As TerritoryExQuery) As Boolean
			Me.m_query = query
			InitQuery(Me.m_query)
			Return Query.Load()
		End Function
		
		Protected Overloads Overrides Function GetDynamicQuery() As esDynamicQuery
			If Me.m_query Is Nothing Then
				Me.m_query = New TerritoryExQuery()
				Me.InitQuery(m_query)
			End If
			Return Me.m_query
		End Function
		
		Protected Sub InitQuery(ByVal query As TerritoryExQuery)
			query.OnLoadDelegate = AddressOf OnQueryLoaded
			
			If Not query.es2.HasConnection Then
				query.es2.Connection = DirectCast(Me, IEntityCollection).Connection
			End If
		End Sub
		
		Protected Overloads Overrides Sub HookupQuery(ByVal query As esDynamicQuery)
			Me.InitQuery(DirectCast(query, TerritoryExQuery))
		End Sub
		
		#End Region
						
		Private m_query As TerritoryExQuery
	End Class



	<Serializable> _
	MustInherit Public Partial Class esTerritoryExQuery 
		Inherits esDynamicQuery 
	
		Protected ReadOnly Overrides Property Meta() As IMetadata
			Get
				Return TerritoryExMetadata.Meta()
			End Get
		End Property
		
#Region "QueryItemFromName"

        Protected Overrides Function QueryItemFromName(ByVal name As String) As esQueryItem
            Select Case name
				Case "TerritoryID" 
					Return Me.TerritoryID
				Case "Notes" 
					Return Me.Notes
                Case Else
                    Return Nothing
            End Select
        End Function

#End Region		
		
#Region "esQueryItems"


		Public ReadOnly Property TerritoryID As esQueryItem
			Get
				Return New esQueryItem(Me, TerritoryExMetadata.ColumnNames.TerritoryID, esSystemType.Int32)
			End Get
		End Property 
		
		Public ReadOnly Property Notes As esQueryItem
			Get
				Return New esQueryItem(Me, TerritoryExMetadata.ColumnNames.Notes, esSystemType.String)
			End Get
		End Property 
		
#End Region	
		
	End Class


	
	Partial Public Class TerritoryEx 
		Inherits esTerritoryEx
		
	
		#Region "UpToTerritory - One To One"
		''' <summary>
		''' One to One
		''' Foreign Key Name - FK_TerritoryEx_Territory
		''' </summary>

		<XmlIgnore()> _
		Public Property UpToTerritory As Territory
		
			Get
				If Me._UpToTerritory Is Nothing 	AndAlso Not TerritoryID.Equals(Nothing) Then
					Me._UpToTerritory = New Territory()
					Me._UpToTerritory.es.Connection.Name = Me.es.Connection.Name
					Me.SetPreSave("UpToTerritory", Me._UpToTerritory)
					Me._UpToTerritory.Query.Where(Me._UpToTerritory.Query.TerritoryID = Me.TerritoryID)
					Me._UpToTerritory.Query.Load()
				End If

				Return Me._UpToTerritory
			End Get
			
            Set(ByVal value As Territory)
				Me.RemovePreSave("UpToTerritory")

				If value Is Nothing Then
					Me._UpToTerritory = Nothing
				Else 
					Me._UpToTerritory = value
					Me.SetPreSave("UpToTerritory", Me._UpToTerritory)
				End If
				
				Me.OnPropertyChanged("UpToTerritory")
			End Set	
			
		End Property
				

		Private _UpToTerritory As Territory
		#End Region

		
			
		''' <summary>
		''' Used internally for retrieving AutoIncrementing keys
		''' during hierarchical PreSave.
		''' </summary>
		Protected Overrides Sub ApplyPreSaveKeys()
		
			If Not Me.es.IsDeleted And Not Me._UpToTerritory Is Nothing Then
				Me.TerritoryID = Me._UpToTerritory.TerritoryID
			End If
			
		End Sub
	End Class
		



    <DataContract(Namespace:="http://tempuri.org/", Name:="TerritoryEx")> _
    <XmlType(TypeName:="TerritoryExProxyStub")> _
    <Serializable> _
    Partial Public Class TerritoryExProxyStub
	
		Public Sub New()
            Me._entity = New TerritoryEx()
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As TerritoryEx)
            Me.Entity = obj
            Me.theEntity = Me._entity
		End Sub
		
		Public Sub New(ByVal obj As TerritoryEx, ByVal dirtyColumnsOnly As Boolean)
            Me.Entity = obj
            Me.theEntity = Me._entity
			Me.dirtyColumnsOnly = dirtyColumnsOnly
		End Sub	
		
			
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal entity As TerritoryExProxyStub) As TerritoryEx
			Return entity.Entity
		End Operator

		#End Region			

        Public Function GetEntityType() As Type
 	        Return GetType(TerritoryEx)
        End Function
		

		<DataMember(Name:="TerritoryID", Order:=1, EmitDefaultValue:=False)> _		
        Public Property TerritoryID As Nullable(Of System.Int32)
        
            Get
				If Me.Entity.es.IsDeleted Then
                    Dim o As Object = Me.Entity. _
                       GetOriginalColumnValue(TerritoryExMetadata.ColumnNames.TerritoryID)
					Return CType(o, Nullable(Of System.Int32))
                Else
					Return Me.Entity.TerritoryID
				End If				
			End Get
			
            Set(ByVal value As Nullable(Of System.Int32))
				Me.Entity.TerritoryID = value
			End Set
			
		End Property

		<DataMember(Name:="Notes", Order:=2, EmitDefaultValue:=False)> _		
        Public Property Notes As System.String
        
            Get
                If Me.IncludeColumn(TerritoryExMetadata.ColumnNames.Notes) Then
                    Return Me.Entity.Notes
                Else
                    Return Nothing
				End If				
			End Get
			
            Set(ByVal value As System.String)
				Me.Entity.Notes = value
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
        Public Property Entity As TerritoryEx
        
            Get
                If Me._entity Is Nothing Then
                    Me.entity = New TerritoryEx()
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
        Public _entity As TerritoryEx
		
        <NonSerialized(), XmlIgnore(), CLSCompliant(False)> _
        Protected theEntity As esEntity

        <NonSerialized(), XmlIgnore()> _
        Protected dirtyColumnsOnly As Boolean		

	End Class
	



    <DataContract(Namespace:="http://tempuri.org/", Name:="TerritoryExCollection")> _
    <XmlType(TypeName:="TerritoryExCollectionProxyStub")> _
    <Serializable> _
    Partial Public Class TerritoryExCollectionProxyStub
	
		Protected Sub New()
			
		End Sub	
		
		Public Sub New(ByVal coll As esEntityCollection(Of TerritoryEx))
			Me.New(coll, False, False)
		End Sub

		Public Sub New(ByVal coll As esEntityCollection(Of TerritoryEx), ByVal dirtyRowsOnly As Boolean)
			Me.New(coll, dirtyRowsOnly, False)
		End Sub
		
		#Region "Implicit Casts"

		Public Shared Widening Operator CType(ByVal proxyStubCollection As TerritoryExCollectionProxyStub) As TerritoryExCollection
			Return proxyStubCollection.GetCollection()
		End Operator

		#End Region	
		
        Public Function GetEntityType() As Type
 	        Return GetType(TerritoryEx)
        End Function
		
		Public Sub New(ByVal coll As esEntityCollection(Of TerritoryEx), ByVal dirtyRowsOnly As Boolean, ByVal dirtyColumnsOnly As Boolean)

            For Each entity As TerritoryEx In coll
                Select Case entity.RowState
                    Case esDataRowState.Added, esDataRowState.Modified

                        Collection.Add(New TerritoryExProxyStub(entity, dirtyColumnsOnly))
                        Exit Select

                    Case esDataRowState.Unchanged

                        If Not dirtyRowsOnly Then
                            Collection.Add(New TerritoryExProxyStub(entity, dirtyColumnsOnly))
                        End If
                        Exit Select
                End Select
            Next

            If coll.es.DeletedEntities IsNot Nothing Then
                For Each entity As TerritoryEx In coll.es.DeletedEntities
                    Collection.Add(New TerritoryExProxyStub(entity, dirtyColumnsOnly))
                Next
            End If

        End Sub		

        <DataMember(Name := "Collection", EmitDefaultValue := False)> _
		Public Collection As New List(Of TerritoryExProxyStub)		

        Public Function GetCollection As TerritoryExCollection
			
                If Me._coll is Nothing Then
                    Me._coll = New TerritoryExCollection()
					
		            Dim proxy As TerritoryExProxyStub

                    For Each proxy In Me.Collection
                        Me._coll.AttachEntity(proxy.Entity)
                    Next
                End If

                Return Me._coll

        End Function

        <NonSerialized> _
		<XmlIgnore> _
        Private _coll As TerritoryExCollection
		
    End Class
	



	<Serializable> _
	Partial Public Class TerritoryExMetadata 
		Inherits esMetadata
		Implements IMetadata
		
#Region "Protected Constructor"
		Protected Sub New()
			m_columns = New esColumnMetadataCollection()
			Dim c as esColumnMetadata

			c = New esColumnMetadata(TerritoryExMetadata.ColumnNames.TerritoryID, 0, GetType(System.Int32), esSystemType.Int32)	
			c.PropertyName = TerritoryExMetadata.PropertyNames.TerritoryID
			c.IsInPrimaryKey = True
			c.NumericPrecision = 10
			m_columns.Add(c)
				
			c = New esColumnMetadata(TerritoryExMetadata.ColumnNames.Notes, 1, GetType(System.String), esSystemType.String)	
			c.PropertyName = TerritoryExMetadata.PropertyNames.Notes
			c.CharacterMaxLength = 50
			c.IsNullable = True
			m_columns.Add(c)
				
		End Sub
#End Region	
	
		Shared Public Function Meta() As TerritoryExMetadata
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
			 Public Const TerritoryID As String = "TerritoryID"
			 Public Const Notes As String = "Notes"
		End Class
#End Region	
		
#Region "PropertyNames"
		Public Class  PropertyNames
			 Public Const TerritoryID As String = "TerritoryID"
			 Public Const Notes As String = "Notes"
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
			SyncLock GetType(TerritoryExMetadata)
			
				If TerritoryExMetadata.mapDelegates Is Nothing Then
					TerritoryExMetadata.mapDelegates = New Dictionary(Of String, MapToMeta)
				End If			

				If TerritoryExMetadata._meta Is Nothing Then
					TerritoryExMetadata._meta = New TerritoryExMetadata()
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
				


				meta.AddTypeMap("TerritoryID", new esTypeMap("int", "System.Int32"))
				meta.AddTypeMap("Notes", new esTypeMap("varchar", "System.String"))			
				meta.Catalog = "ForeignKeyTest"
				meta.Schema = "dbo"
				 
				meta.Source = "TerritoryEx"
				meta.Destination = "TerritoryEx"
				
				meta.spInsert = "proc_TerritoryExInsert"
				meta.spUpdate = "proc_TerritoryExUpdate"
				meta.spDelete = "proc_TerritoryExDelete"
				meta.spLoadAll = "proc_TerritoryExLoadAll"
				meta.spLoadByPrimaryKey = "proc_TerritoryExLoadByPrimaryKey"
				
				Me.m_providerMetadataMaps.Add("esDefault", meta)

			End If

			Return Me.m_providerMetadataMaps("esDefault")

		End Function
		
#End Region	
		
        Private Shared _meta As TerritoryExMetadata
        Protected Shared mapDelegates As Dictionary(Of String, MapToMeta)
		Private Shared _esDefault As Integer = RegisterDelegateesDefault()	
		
	End Class
	
End Namespace
