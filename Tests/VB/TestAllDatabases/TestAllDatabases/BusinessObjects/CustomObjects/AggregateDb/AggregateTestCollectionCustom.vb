'======================================
' Copyright EntitySpaces, LLC 2005 - 2006 
'======================================

Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Imports System.Data

Imports EntitySpaces.Interfaces
Imports EntitySpaces.Core
Imports EntitySpaces.DynamicQuery

Namespace BusinessObjects
	#Region "Custom Collection Tests"

	Public Partial Class AggregateTestCollection
		Inherits esAggregateTestCollection
		Public Function ExposeDataTable() As DataTable
			Return Nothing
			' this.Table;
		End Function

		Public Sub New(connectionName As String)
			Me.es.Connection.Name = connectionName
		End Sub

		Public Function QueryTest() As DataTable
			Dim strSQL As String = "SELECT * FROM Query1"

			Return MyBase.FillDataTable(esQueryType.Text, strSQL)
		End Function

		' Obsolete as of 2007.1.1021.0
		'protected override void CreateExtendedProperties(esColumnMetadataCollection extendedProps)
		'{
		'    if (null == extendedProps["NewId"])
		'    {
		'        esColumnMetadata col = new esColumnMetadata("NewId", this.Meta.Columns.Count + 1, Type.GetType("System.Int32"));
		'        col.PropertyName = "NewId";
		'        extendedProps.Add(col);
		'    }

		'    if (null == extendedProps["OrderIndex"])
		'    {
		'        esColumnMetadata col = new esColumnMetadata("OrderIndex", this.Meta.Columns.Count + 1, Type.GetType("System.Int32"));
		'        col.PropertyName = "OrderIndex";
		'        extendedProps.Add(col);
		'    }
		'}

		'public void AddOrderIndexColumn()
		'{
		'    if (this.Table != null && this.Table.Columns.Contains("OrderIndex") == false)
		'    {
		'        this.Table.Columns.Add("OrderIndex", typeof(Int16));
		'    }
		'}

		'public DataTable GetTable()
		'{
		'    return this.Table;
		'}

        Public Shared Sub CustomForEach()
            Dim coll As New AggregateTestCollection()
            coll.LoadAll()

            For Each entity As AggregateTest In coll
                entity.LastName = "CustomForEach"
            Next
        End Sub

#Region "ExecuteNonQuery"

        Public Function CustomExecuteNonQueryNoParams() As Integer
            If Me.es.Connection.ProviderMetadataKey = "esOracle" Then
                Dim esParams As New esParameters()
                esParams.Add("outCursor", "", esParameterDirection.Output, DbType.[Object], 0)
                Return Me.ExecuteNonQuery(Me.es.Schema, Me.es.spLoadAll, esParams)
            Else
                Return Me.ExecuteNonQuery(Me.es.Schema, Me.es.spLoadAll)
            End If
        End Function

        Public Function CustomExecuteNonQueryNoParamsWithCatalog() As Integer
            Return Me.ExecuteNonQuery(Me.es.Catalog, Me.es.Schema, Me.es.spLoadAll)
        End Function

        Public Function CustomExecuteNonQueryEsParams() As Integer
            Dim esParams As New esParameters()
            esParams.Add("pID", 948)

            Return Me.ExecuteNonQuery(Me.es.Schema, Me.es.spLoadByPrimaryKey, esParams)
        End Function

        Public Function CustomExecuteNonQueryText(ByVal newName As String) As Integer
            Dim sqlText As String = ""

            Select Case Me.es.Connection.ProviderMetadataKey
                Case "esOracle"
                    sqlText = "UPDATE ""MYGENERATION"".""AggregateTest"" "
                    sqlText += "SET ""FirstName"" = {0} "
                    sqlText += "WHERE ""LastName"" = {1} "
                    sqlText += "AND ""Salary"" = {2}"

                    Exit Select

                Case "esPgsql"
                    sqlText = "UPDATE ""AggregateTest"" "
                    sqlText += "SET ""FirstName"" = {0} "
                    sqlText += "WHERE ""LastName"" = {1} "
                    sqlText += "AND ""Salary"" = {2}"

                    Exit Select

                Case "esMySQL"
                    sqlText = "UPDATE `AggregateTest` "
                    sqlText += "SET `FirstName` =  {0} "
                    sqlText += "WHERE `LastName` = {1} "
                    sqlText += "AND `Salary` = {2}"

                    Exit Select
                Case Else

                    sqlText = "UPDATE [AggregateTest] "
                    sqlText += "SET [FirstName] =  {0} "
                    sqlText += "WHERE [LastName] = {1} "
                    sqlText += "AND [Salary] = {2}"

                    Exit Select
            End Select

            Return Me.ExecuteNonQuery(esQueryType.Text, sqlText, newName, "Doe", 27.53)
        End Function

        Public Function CustomExecuteNonQueryTextEsParams(ByVal newName As String) As Integer
            Dim sqlText As String = ""
            Dim esParams As New esParameters()
            esParams.Add("FirstName", newName)
            esParams.Add("LastName", "Doe")
            esParams.Add("Salary", 27.53)

            Select Case Me.es.Connection.ProviderSignature.DataProviderName
                Case "EntitySpaces.OracleClientProvider"
                    sqlText = "UPDATE ""MYGENERATION"".""AggregateTest"" "
                    sqlText += "SET ""FirstName"" = :FirstName "
                    sqlText += "WHERE ""LastName"" = :LastName "
                    sqlText += "AND ""Salary"" = :Salary"

                    Exit Select

                Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
                    sqlText = "UPDATE ""AggregateTest"" "
                    sqlText += "SET ""FirstName"" = :FirstName "
                    sqlText += "WHERE ""LastName"" = :LastName "
                    sqlText += "AND ""Salary"" = :Salary"

                    Exit Select

                Case "EntitySpaces.MySqlClientProvider"
                    sqlText = "UPDATE `AggregateTest` "
                    sqlText += "SET `FirstName` =  ?FirstName "
                    sqlText += "WHERE `LastName` = ?LastName "
                    sqlText += "AND `Salary` = ?Salary"

                    Exit Select

                Case "EntitySpaces.SybaseSqlAnywhereProvider"
                    sqlText = "UPDATE [AggregateTest] "
                    sqlText += "SET [FirstName] =  :FirstName "
                    sqlText += "WHERE [LastName] = :LastName "
                    sqlText += "AND [Salary] = :Salary"

                    Exit Select
                Case Else

                    sqlText = "UPDATE [AggregateTest] "
                    sqlText += "SET [FirstName] =  @FirstName "
                    sqlText += "WHERE [LastName] = @LastName "
                    sqlText += "AND [Salary] = @Salary"

                    Exit Select
            End Select

            Return Me.ExecuteNonQuery(esQueryType.Text, sqlText, esParams)
        End Function

#End Region

		#Region "ExecuteReader"

		Public Function CustomExecuteReaderNoParams() As IDataReader
			Return Me.ExecuteReader(Me.es.Schema, Me.es.spLoadAll)
		End Function

		Public Function CustomExecuteReaderTextEsParams() As IDataReader
			Dim sqlText As String = ""
			Dim esParams As New esParameters()
			esParams.Add("LastName", "Doe")

			Select Case Me.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					sqlText = "SELECT * "
					sqlText += "FROM ""MYGENERATION"".""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = :LastName"

					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					sqlText = "SELECT * "
					sqlText += "FROM ""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = :LastName"

					Exit Select

				Case "EntitySpaces.MySqlClientProvider"
					sqlText = "SELECT * "
					sqlText += "FROM `AggregateTest` "
					sqlText += "WHERE `LastName` = ?LastName"

					Exit Select

				Case "EntitySpaces.SybaseSqlAnywhereProvider"
					sqlText = "SELECT * "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] = :LastName"

					Exit Select
				Case Else

					sqlText = "SELECT * "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] = @LastName"

					Exit Select
			End Select

			Return Me.ExecuteReader(esQueryType.Text, sqlText, esParams)
		End Function

		#End Region

		#Region "ExecuteScalar"

		Public Function CustomExecuteScalarNoParams() As String
			Return Me.ExecuteScalar(Me.es.Schema, Me.es.spLoadAll).ToString()
		End Function

		Public Function CustomExecuteScalarTextEsParams() As Integer
			Dim sqlText As String = ""
			Dim esParams As New esParameters()
			esParams.Add("LastName", "Doe")

			Select Case Me.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					sqlText = "SELECT COUNT(""FirstName"")"
					sqlText += "FROM ""MYGENERATION"".""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = :LastName"

					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					sqlText = "SELECT COUNT(""FirstName"")"
					sqlText += "FROM ""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = :LastName"

					Exit Select

				Case "EntitySpaces.MySqlClientProvider"
					sqlText = "SELECT COUNT(`FirstName`) "
					sqlText += "FROM `AggregateTest` "
					sqlText += "WHERE `LastName` = ?LastName"

					Exit Select

				Case "EntitySpaces.SybaseSqlAnywhereProvider"
					sqlText = "SELECT COUNT([FirstName]) "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] = :LastName"

					Exit Select
				Case Else

					sqlText = "SELECT COUNT([FirstName]) "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] = @LastName"

					Exit Select
			End Select

			Return Convert.ToInt32(Me.ExecuteScalar(esQueryType.Text, sqlText, esParams))
		End Function

		#End Region

		#Region "FillDataSet"

		Public Function CustomFillDataSetNoParams() As DataSet
			Dim dataSet As DataSet = Me.FillDataSet(Me.es.Schema, Me.es.spLoadAll)
			Return dataSet
		End Function

		Public Function CustomFillDataSetText() As DataSet
			Dim sqlText As String = ""

			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esOracle"
					sqlText = "SELECT * "
					sqlText += "FROM ""MYGENERATION"".""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = {0}"

					Exit Select

				Case "esPgsql"
					sqlText = "SELECT * "
					sqlText += "FROM ""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = {0}"

					Exit Select

				Case "esMySQL"
					sqlText = "SELECT * "
					sqlText += "FROM `AggregateTest` "
					sqlText += "WHERE `LastName` = {0}"

					Exit Select
				Case Else

					sqlText = "SELECT * "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] = {0}"

					Exit Select
			End Select

			Return Me.FillDataSet(esQueryType.Text, sqlText, "Doe")
		End Function

		Public Function CustomFillDataSetTextNoParams(lastName As String) As DataSet
			Dim sqlText As String = ""

			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esOracle"
					sqlText = "SELECT * "
					sqlText += "FROM ""MYGENERATION"".""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = '" & lastName & "'"

					Exit Select

				Case "esPgsql"
					sqlText = "SELECT * "
					sqlText += "FROM ""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = '" & lastName & "'"

					Exit Select

				Case "esMySQL"
					sqlText = "SELECT * "
					sqlText += "FROM `AggregateTest` "
					sqlText += "WHERE `LastName` = '" & lastName & "'"

					Exit Select
				Case Else

					sqlText = "SELECT * "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] = '" & lastName & "'"

					Exit Select
			End Select

			Return Me.FillDataSet(esQueryType.Text, sqlText)
		End Function

		Public Function CustomFillDataSetEsParams(Id As Integer) As DataSet
			Dim esParams As New esParameters()
			esParams.Add("ID", Id)

			Dim dataSet As DataSet = Me.FillDataSet(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, esParams)
			Return dataSet
		End Function

		#End Region

		#Region "FillDataTable"

		Public Function CustomFillDataTableNoParams() As DataTable
			Dim dataTable As DataTable = Me.FillDataTable(Me.es.Schema, Me.es.spLoadAll)
			Return dataTable
		End Function

		Public Function CustomFillDataTableEsParams(Id As Integer) As DataTable
			Dim esParams As New esParameters()
			esParams.Add("ID", Id)

			Dim dataTable As DataTable = Me.FillDataTable(Me.es.Schema, Me.es.spLoadByPrimaryKey, esParams)
			Return dataTable
		End Function

		Public Function CustomFillDataTableEsParams2(Id As Integer) As DataTable
			Dim esParams As New esParameters()
			esParams.Add("ID", Id)

			Dim dataTable As DataTable = Me.FillDataTable(esQueryType.StoredProcedure, Me.es.spLoadByPrimaryKey, esParams)
			Return dataTable
		End Function

		Public Function CustomFillDataTableText() As DataTable
			Dim sqlText As String = ""

			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esOracle"
					sqlText = "SELECT * "
					sqlText += "FROM ""MYGENERATION"".""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = {0} "
					sqlText += "OR ""LastName"" = {1} "

					Exit Select

				Case "esPgsql"
					sqlText = "SELECT * "
					sqlText += "FROM ""AggregateTest"" "
					sqlText += "WHERE ""LastName"" = {0} "
					sqlText += "OR ""LastName"" = {1} "

					Exit Select

				Case "esMySQL"
					sqlText = "SELECT * "
					sqlText += "FROM `AggregateTest` "
					sqlText += "WHERE `LastName` = {0} "
					sqlText += "OR `LastName` = {1}"

					Exit Select
				Case Else

					sqlText = "SELECT * "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] = {0} "
					sqlText += "OR [LastName] = {1}"

					Exit Select
			End Select

			Return Me.FillDataTable(esQueryType.Text, sqlText, "Doe", "Johnson")
		End Function

		#End Region

		#Region "Custom Load"

		Public Function CustomLoadText() As Boolean
			Dim sqlText As String = ""

			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esOracle"
					sqlText = "SELECT ""LastName"", ""DepartmentID"", ""HireDate"" "
					sqlText += "FROM ""MYGENERATION"".""AggregateTest"" "
					sqlText += "WHERE ""DepartmentID"" = {0} "
					sqlText += "OR ""DepartmentID"" = {1} "

					Exit Select

				Case "esPgsql"
					sqlText = "SELECT ""LastName"", ""DepartmentID"", ""HireDate"" "
					sqlText += "FROM ""AggregateTest"" "
					sqlText += "WHERE ""DepartmentID"" = {0} "
					sqlText += "OR ""DepartmentID"" = {1} "

					Exit Select

				Case "esMySQL"
					sqlText = "SELECT `LastName`, `DepartmentID`, `HireDate` "
					sqlText += "FROM `AggregateTest` "
					sqlText += "WHERE `DepartmentID` = {0} "
					sqlText += "OR `DepartmentID` = {1}"

					Exit Select
				Case Else

					sqlText = "SELECT [LastName], [DepartmentID], [HireDate] "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [DepartmentID] = {0} "
					sqlText += "OR [DepartmentID] = {1}"

					Exit Select
			End Select

			Return Me.Load(esQueryType.Text, sqlText, 1, 2)
		End Function

		Public Function CustomLoadTextEsParams(lastName As String) As Boolean
			Dim sqlText As String = ""
			lastName = "%" & lastName & "%"
			Dim esParams As New esParameters()
			esParams.Add("LastName", lastName)

			Select Case Me.es.Connection.ProviderSignature.DataProviderName
				Case "EntitySpaces.OracleClientProvider"
					sqlText = "SELECT * "
					sqlText += "FROM ""MYGENERATION"".""AggregateTest"" "
					sqlText += "WHERE ""LastName"" LIKE :LastName"

					Exit Select

				Case "EntitySpaces.NpgsqlProvider", "EntitySpaces.Npgsql2Provider"
					sqlText = "SELECT * "
					sqlText += "FROM ""AggregateTest"" "
					sqlText += "WHERE ""LastName"" LIKE :LastName"

					Exit Select

				Case "EntitySpaces.MySqlClientProvider"
					sqlText = "SELECT * "
					sqlText += "FROM `AggregateTest` "
					sqlText += "WHERE `LastName` LIKE ?LastName"

					Exit Select

				Case "EntitySpaces.SybaseSqlAnywhereProvider"
					sqlText = "SELECT * "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] LIKE :LastName"

					Exit Select
				Case Else

					sqlText = "SELECT * "
					sqlText += "FROM [AggregateTest] "
					sqlText += "WHERE [LastName] LIKE @LastName"

					Exit Select
			End Select

			Return Me.Load(esQueryType.Text, sqlText, esParams)
		End Function

		#End Region

		Public Function GetTotalSalaries() As Decimal
			Return CDec(Me.ExecuteScalar(esQueryType.StoredProcedure, "proc_GetTotalSalaries"))
		End Function

		Public Function GetFullName(ID As Integer) As String
			Dim parms As New esParameters()


			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esMySQL"
					parms.Add("pID", ID)
					parms.Add("FullName", esParameterDirection.Output, DbType.[String], 40)
					Exit Select
				Case "esOracle"
					parms.Add("pID", ID)
					parms.Add("pFullName", esParameterDirection.Output, DbType.[String], 40)
					Exit Select
				Case Else
					parms.Add("ID", ID)
					parms.Add("FullName", esParameterDirection.Output, DbType.[String], 40)
					Exit Select
			End Select

			Me.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_GetEmployeeFullName", parms)

			Dim returnValue As String = ""
			Select Case Me.es.Connection.ProviderMetadataKey
				Case "esOracle"
					returnValue = TryCast(parms("pFullName").Value, String)
					Exit Select
				Case Else
					returnValue = TryCast(parms("FullName").Value, String)
					Exit Select
			End Select
			Return returnValue
		End Function

		'public int TestAssignPrimaryKeys()
		'{
		'    this.AssignPrimaryKeys();
		'    return this.Table.PrimaryKey.Length;
		'}

		'public int TestRemovePrimaryKeys()
		'{
		'    this.RemovePrimaryKeys();
		'    return this.Table.PrimaryKey.Length;
		'}

		Public Sub TestParamsWithScale()
			Dim myParam As New esParameter("Salary", 12.34)
			myParam.DbType = DbType.[Decimal]
			myParam.Precision = 18
			myParam.Scale = 2
			myParam.Direction = esParameterDirection.InputOutput

			Dim parms As New esParameters()
			parms.Add(myParam)
			parms.Add("DepartmentID", 1)
			'parms.Add("DepartmentID", null);
			parms.Add("FirstName", "Entity")
			parms.Add("LastName", "Spaces")
			parms.Add("Age", 100)
			parms.Add("HireDate", "2000-12-31 00:00:00")
			parms.Add("IsActive", False)
			Me.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_esTestInsert", parms)
		End Sub

		Public Sub TestNullParams()
			Dim parms As New esParameters()
			parms.Add("DepartmentID", Nothing)
			parms.Add("FirstName", Nothing)
			parms.Add("LastName", "NullTest")
			parms.Add("Age", Nothing)
			parms.Add("HireDate", Nothing)
			parms.Add("Salary", Nothing)
			parms.Add("IsActive", False)
			Me.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_esTestInsert", parms)
		End Sub

		Public Sub TestIdentityInsert()
			Dim coll As New AggregateTestCollection()
			coll.LoadAll()

			Dim sql As New StringBuilder()
			sql.AppendLine("SET IDENTITY_INSERT [AggregateTest] ON")
			sql.AppendLine("SET NOCOUNT ON")

			For i As Integer = 1 To coll.Count - 1
				sql.AppendLine("INSERT INTO [AggregateTest]([ID], [LastName])")
				sql.AppendLine(("VALUES(" & i.ToString() & ", '") + coll(i).LastName & "')")
			Next

			sql.AppendLine("SET IDENTITY_INSERT [AggregateTest] OFF")

			'esUtility u = new esUtility();
			'u.ExecuteNonQuery(esQueryType.Text, sql.ToString());
		End Sub

		Public Sub TestUpdateWithNullParams()
			Dim test As Integer = 0
			Dim sqlText As String = ""
			Dim esParams As New esParameters()
			esParams.Add("DepartmentID", test)
			esParams.Add("FirstName", DBNull.Value)
			esParams.Add("LastName", "NullTest")

			sqlText = "UPDATE [AggregateTest] "
			sqlText += "SET [DepartmentID] = @DepartmentID, "
			sqlText += "[FirstName] =  @FirstName "
			sqlText += "WHERE [LastName] = @LastName"

			Me.ExecuteNonQuery(esQueryType.Text, sqlText, esParams)
		End Sub

		'public override bool LoadAll()
		'{
		'    return base.LoadAll();
		'}

		'public override void Save()
		'{
		'    foreach (AggregateTest entity in this)
		'    {
		'        if (entity.es.IsDirty)
		'        {
		'            entity.OnSave(entity);
		'        }
		'    }
		'    base.Save();
		'}

	End Class

	' Test combining DynamicQuery with custom selection criteria.
	'public bool Select()
	'{
	'    if (Query.Load())
	'    {
	'        for(int i = this.Count - 1; i >= 0; i--)
	'        {
	'            AggregateTest unit = (AggregateTest)this[i];
	'            if (unit.IsActive.HasValue && unit.IsActive.Value)
	'            {
	'                DetachEntity(unit);
	'            }
	'        }
	'        return Count > 0;
	'    }
	'    return false;
	'}

	#End Region
End Namespace
