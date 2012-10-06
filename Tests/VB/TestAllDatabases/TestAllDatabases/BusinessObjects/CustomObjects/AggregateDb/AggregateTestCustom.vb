'
'===============================================================================
'                     EntitySpaces(TM) by EntitySpaces, LLC
'                 A New 2.0 Architecture for the .NET Framework
'                          http://www.entityspaces.net
'===============================================================================
'                       EntitySpaces Version # 2007.0.0730.0
'                       MyGeneration Version # 1.2.0.7
'                           7/30/2007 5:51:12 PM
'-------------------------------------------------------------------------------
'



Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core
Imports EntitySpaces.DynamicQuery

Namespace BusinessObjects
	Public Partial Class AggregateTest
		Inherits esAggregateTest
#Region "Custom Entity Tests"

        Public Sub New(ByVal connectionName As String)
            Me.es.Connection.Name = connectionName
        End Sub

        Public Function ExposeDataTable() As DataTable
            Return Nothing
            ' this.Table;
        End Function

        Public Sub SaveUpdateOrInsert(ByVal id As Integer, ByVal lName As String)
            Me.Query.Where(Me.Query.Id = id)
            Me.Query.Load()

            Me.LastName = lName
            Me.Save()
        End Sub

        'public Int32? NewId
        '{
        '    get
        '    {
        '        return base.GetSystemInt32("NewId");
        '    }
        '    set
        '    {
        '        base.SetSystemInt32("NewId", value);
        '    }
        '}

        'public int? OrderIndex
        '{
        '    get
        '    {
        '        return base.GetSystemInt32("OrderIndex");
        '    }
        '    set
        '    {
        '        if (this.RowState == esDataRowState.Unchanged)
        '        {
        '            base.SetSystemInt32("OrderIndex", value);
        '            this.AcceptChanges();
        '        }
        '        else
        '        {
        '            base.SetSystemInt32("OrderIndex", value);
        '        }
        '    }
        '}

        Public Function CustomLoadSP(ByVal aggId As Integer) As Boolean
            Dim esParams As New esParameters()
            esParams.Add("pId", aggId)
            Return Me.Load(esQueryType.StoredProcedure, "ESAGGREGATETESTLOADBYPK", esParams)
        End Function

        Public Function GetAutoKey() As Boolean
            If Me.Meta.Columns("ID").IsAutoIncrement Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub ToggleAutoKey()
            If Me.Meta.Columns("ID").IsAutoIncrement Then
                Me.Meta.Columns("ID").IsAutoIncrement = False
            Else
                Me.Meta.Columns("ID").IsAutoIncrement = True
            End If
        End Sub

        Public Sub WriteMetadata()
            Dim spec As esProviderSpecificMetadata = Me.Meta.GetProviderMetadata("esDefault")

            For Each col As esColumnMetadata In Me.Meta.Columns
                Console.WriteLine("PropertyName: " + col.PropertyName)
                Console.WriteLine("ColumnName : " + col.Name)
                Console.WriteLine("CharLength : " + col.CharacterMaxLength.ToString())

                Dim map As esTypeMap = spec.GetTypeMap(col.Name)

                Console.WriteLine("Native Type : " + map.NativeType)
                Console.WriteLine("System Type : " + map.SystemType)
                Console.WriteLine("---------------------------------")
            Next
        End Sub

        Public Sub SetSchema(ByVal schemaName As String)
            Dim spec As esProviderSpecificMetadata = Me.Meta.GetProviderMetadata("esDefault")
            spec.Schema = schemaName
        End Sub

        Public Function AllColumnsAreDirty(ByVal state As esDataRowState) As Boolean
            If Me.es.ModifiedColumns.Count = 8 AndAlso Me.RowState = state Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function AllColumnsAreNotDirty() As Boolean
            If Me.es.ModifiedColumns.Count = 0 AndAlso Me.RowState = esDataRowState.Unchanged Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub EntityInsert(ByVal useES As Boolean)
            Dim esParams As New esParameters()
            esParams.Add("ID", Me.Id, esParameterDirection.Output, DbType.Int32, 0)
            esParams.Add("DepartmentID", Me.DepartmentID)
            esParams.Add("LastName", Me.LastName)
            esParams.Add("FirstName", Me.FirstName)
            esParams.Add("Age", Me.Age)
            esParams.Add("HireDate", Me.HireDate)
            esParams.Add("Salary", Me.Salary)
            esParams.Add("IsActive", Me.IsActive)

            If useES Then
                Me.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_AggregateTestInsert", esParams)
            Else
                Me.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_AggregateTestEntityInsert", esParams)
            End If
        End Sub

        'public class MaxLength
        '{
        '    static public long LastName
        '    {
        '        get
        '        {
        '            AggregateTest _entity = new AggregateTest();
        '            return _entity.Meta.Columns["LastName"].CharacterMaxLength;
        '        }
        '    }

        '    static public long FirstName
        '    {
        '        get
        '        {
        '            AggregateTest _entity = new AggregateTest();
        '            return _entity.Meta.Columns["FirstName"].CharacterMaxLength;
        '        }
        '    }
        '}

        'public override void Save()
        '{
        '    if (this.es.IsDirty)
        '    {
        '        this.OnSave(this);
        '    }
        '    base.Save();
        '}

        'public void OnSave(AggregateTest entity)
        '{
        '    if (entity.es.IsDeleted)
        '    {
        '        // Do something
        '        bool didWeReachthis = true;
        '    }

        '    //if (entity.Row.RowState == esDataRowState.Added)
        '    //{
        '    //    if (entity.Age >= 18)
        '    //    {
        '    //        entity.IsActive = true;
        '    //    }
        '    //    else
        '    //    {
        '    //        entity.IsActive = false;
        '    //    }

        '    //    //if (entity.Salary.HasValue)
        '    //    //{
        '    //    //    AggregateTestCollection collection = new AggregateTestCollection();
        '    //    //    collection.Query.Where(collection.Query.Salary.Equal(entity.Salary.Value));
        '    //    //    collection.Query.Load();
        '    //    //    if (collection.Count > 0)
        '    //    //    {
        '    //    //        throw new Exception("Sorry, that salary has been taken.");
        '    //    //    }
        '    //    //}
        '    //}
        '}

        'public override System.Decimal? Salary 
        '{
        '    get { return base.Salary; } 
        '    set 
        '    {
        '        if (value.HasValue)
        '        {
        '            AggregateTestCollection collection = new AggregateTestCollection();
        '            collection.Query.Where(collection.Query.Salary.Equal(value.Value));
        '            collection.Query.Load();
        '            if (collection.Count > 0)
        '            {
        '                throw new Exception("Sorry, that salary has been taken.");
        '            }
        '        }
        '        base.Salary = value;
        '    } 
        '}

        'public override string LastName
        '{
        '    get
        '    {
        '        return base.LastName;
        '    }
        '    set
        '    {
        '        long len = this.Meta.Columns["LastName"].CharacterMaxLength;
        '        if (value == null || value.Length <= len)
        '        {
        '            base.LastName = value;
        '        }
        '        else
        '        {
        '            // Too much data
        '            base.LastName = value.Substring(0, (int)len);
        '        }
        '    }
        '}

        'public override void AddNew()
        '{
        '    base.AddNew();
        '}
#End Region
    End Class


	#Region "Test read-only property template"
	'public new System.Int32? Id
	'{
	'    get
	'    {
	'        return base.Id;
	'    }
	'}
	'public new System.Int32? DepartmentID
	'{
	'    get
	'    {
	'        return base.DepartmentID;
	'    }
	'}
	'public new System.String FirstName
	'{
	'    get
	'    {
	'        return base.FirstName;
	'    }
	'}
	'public new System.String LastName
	'{
	'    get
	'    {
	'        return base.LastName;
	'    }
	'}
	'public new System.Int32? Age
	'{
	'    get
	'    {
	'        return base.Age;
	'    }
	'}
	'public new System.DateTime? HireDate
	'{
	'    get
	'    {
	'        return base.HireDate;
	'    }
	'}
	'public new System.Decimal? Salary
	'{
	'    get
	'    {
	'        return base.Salary;
	'    }
	'}
	'public new System.Boolean? IsActive
	'{
	'    get
	'    {
	'        return base.IsActive;
	'    }
	'}

	#End Region
End Namespace
