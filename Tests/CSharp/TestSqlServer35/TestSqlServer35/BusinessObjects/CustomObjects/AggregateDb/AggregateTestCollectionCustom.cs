//======================================
// Copyright EntitySpaces, LLC 2005 - 2006 
//======================================

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;
using EntitySpaces.DynamicQuery;

namespace BusinessObjects
{
	#region Custom Collection Tests

	public partial class AggregateTestCollection : esAggregateTestCollection
	{
        public DataTable ExposeDataTable()
        {
            return null; // this.Table;
        }

        public AggregateTestCollection(string connectionName)
        {
            this.es.Connection.Name = connectionName;
        }

        public DataTable QueryTest()
        {
            string strSQL = "SELECT * FROM Query1";

            return base.FillDataTable(esQueryType.Text, strSQL);
        }

        // Obsolete as of 2007.1.1021.0
        //protected override void CreateExtendedProperties(esColumnMetadataCollection extendedProps)
        //{
        //    if (null == extendedProps["NewId"])
        //    {
        //        esColumnMetadata col = new esColumnMetadata("NewId", this.Meta.Columns.Count + 1, Type.GetType("System.Int32"));
        //        col.PropertyName = "NewId";
        //        extendedProps.Add(col);
        //    }

        //    if (null == extendedProps["OrderIndex"])
        //    {
        //        esColumnMetadata col = new esColumnMetadata("OrderIndex", this.Meta.Columns.Count + 1, Type.GetType("System.Int32"));
        //        col.PropertyName = "OrderIndex";
        //        extendedProps.Add(col);
        //    }
        //}

		//public void AddOrderIndexColumn()
		//{
		//    if (this.Table != null && this.Table.Columns.Contains("OrderIndex") == false)
		//    {
		//        this.Table.Columns.Add("OrderIndex", typeof(Int16));
		//    }
		//}

		//public DataTable GetTable()
		//{
		//    return this.Table;
		//}

        public static void CustomForEach()
        {
            AggregateTestCollection coll = new AggregateTestCollection();
            coll.LoadAll();

            foreach (AggregateTest entity in coll)
            {
                entity.LastName = "CustomForEach";
            }
        }

        #region ExecuteNonQuery

		public int CustomExecuteNonQueryNoParams()
		{
			if (this.es.Connection.ProviderMetadataKey == "esOracle")
			{
				esParameters esParams = new esParameters();
				esParams.Add("outCursor", "", esParameterDirection.Output, DbType.Object, 0);
				return this.ExecuteNonQuery(this.es.Schema, this.es.spLoadAll, esParams);
			}
			else
			{
				return this.ExecuteNonQuery(this.es.Schema, this.es.spLoadAll);
			}
		}

		public int CustomExecuteNonQueryNoParamsWithCatalog()
		{
			return this.ExecuteNonQuery(this.es.Catalog, this.es.Schema, this.es.spLoadAll);
		}

		public int CustomExecuteNonQueryEsParams()
		{
			esParameters esParams = new esParameters();
			esParams.Add("pID", 948);

			return this.ExecuteNonQuery(this.es.Schema, this.es.spLoadByPrimaryKey, esParams);
		}

		public int CustomExecuteNonQueryText(string newName)
		{
			string sqlText = "";

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "UPDATE \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "SET \"FirstName\" = {0} ";
					sqlText += "WHERE \"LastName\" = {1} ";
					sqlText += "AND \"Salary\" = {2}";

                    break;

                case "esPgsql":
                    sqlText = "UPDATE \"AggregateTest\" ";
                    sqlText += "SET \"FirstName\" = {0} ";
                    sqlText += "WHERE \"LastName\" = {1} ";
                    sqlText += "AND \"Salary\" = {2}";

                    break;

                case "esMySQL":
					sqlText = "UPDATE `AggregateTest` ";
					sqlText += "SET `FirstName` =  {0} ";
					sqlText += "WHERE `LastName` = {1} ";
					sqlText += "AND `Salary` = {2}";

                    break;

				default:
					sqlText = "UPDATE [AggregateTest] ";
					sqlText += "SET [FirstName] =  {0} ";
					sqlText += "WHERE [LastName] = {1} ";
					sqlText += "AND [Salary] = {2}";

                    break;
            }

            return this.ExecuteNonQuery(esQueryType.Text, sqlText, newName, "Doe", 27.53);
        }

		public int CustomExecuteNonQueryTextEsParams(string newName)
		{
			string sqlText = "";
			esParameters esParams = new esParameters();
			esParams.Add("FirstName", newName);
			esParams.Add("LastName", "Doe");
			esParams.Add("Salary", 27.53);

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "UPDATE \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "SET \"FirstName\" = :FirstName ";
					sqlText += "WHERE \"LastName\" = :LastName ";
					sqlText += "AND \"Salary\" = :Salary";

                    break;

                case "esPgsql":
                    sqlText = "UPDATE \"AggregateTest\" ";
                    sqlText += "SET \"FirstName\" = :FirstName ";
                    sqlText += "WHERE \"LastName\" = :LastName ";
                    sqlText += "AND \"Salary\" = :Salary";

                    break;

                case "esMySQL":
					sqlText = "UPDATE `AggregateTest` ";
					sqlText += "SET `FirstName` =  ?FirstName ";
					sqlText += "WHERE `LastName` = ?LastName ";
					sqlText += "AND `Salary` = ?Salary";

                    break;

				default:
					sqlText = "UPDATE [AggregateTest] ";
					sqlText += "SET [FirstName] =  @FirstName ";
					sqlText += "WHERE [LastName] = @LastName ";
					sqlText += "AND [Salary] = @Salary";

                    break;
            }

            return this.ExecuteNonQuery(esQueryType.Text, sqlText, esParams);
        }

		#endregion

		#region ExecuteReader

		public IDataReader CustomExecuteReaderNoParams()
		{
			return this.ExecuteReader(this.es.Schema, this.es.spLoadAll);
		}

		public IDataReader CustomExecuteReaderTextEsParams()
		{
			string sqlText = "";
			esParameters esParams = new esParameters();
			esParams.Add("LastName", "Doe");

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT * ";
					sqlText += "FROM \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "WHERE \"LastName\" = :LastName";

                    break;

                case "esPgsql":
                    sqlText = "SELECT * ";
                    sqlText += "FROM \"AggregateTest\" ";
                    sqlText += "WHERE \"LastName\" = :LastName";

                    break;

                case "esMySQL":
					sqlText = "SELECT * ";
					sqlText += "FROM `AggregateTest` ";
					sqlText += "WHERE `LastName` = ?LastName";

                    break;

				default:
					sqlText = "SELECT * ";
					sqlText += "FROM [AggregateTest] ";
					sqlText += "WHERE [LastName] = @LastName";

                    break;
            }

            return this.ExecuteReader(esQueryType.Text, sqlText, esParams);
        }

		#endregion

		#region ExecuteScalar

		public string CustomExecuteScalarNoParams()
		{
			return this.ExecuteScalar(this.es.Schema, this.es.spLoadAll).ToString();
		}

        public int CustomExecuteScalarTextEsParams()
		{
			string sqlText = "";
			esParameters esParams = new esParameters();
			esParams.Add("LastName", "Doe");

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT COUNT(\"FirstName\")";
					sqlText += "FROM \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "WHERE \"LastName\" = :LastName";

                    break;

                case "esPgsql":
                    sqlText = "SELECT COUNT(\"FirstName\")";
                    sqlText += "FROM \"AggregateTest\" ";
                    sqlText += "WHERE \"LastName\" = :LastName";

                    break;

                case "esMySQL":
					sqlText = "SELECT COUNT(`FirstName`) ";
					sqlText += "FROM `AggregateTest` ";
					sqlText += "WHERE `LastName` = ?LastName";

                    break;

				default:
					sqlText = "SELECT COUNT([FirstName]) ";
					sqlText += "FROM [AggregateTest] ";
					sqlText += "WHERE [LastName] = @LastName";

                    break;
            }

            return Convert.ToInt32(this.ExecuteScalar(esQueryType.Text, sqlText, esParams));
        }

		#endregion

		#region FillDataSet

		public DataSet CustomFillDataSetNoParams()
		{
			DataSet dataSet = this.FillDataSet(this.es.Schema, this.es.spLoadAll);
			return dataSet;
		}

		public DataSet CustomFillDataSetText()
		{
			string sqlText = "";

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT * ";
					sqlText += "FROM \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "WHERE \"LastName\" = {0}";

                    break;

                case "esPgsql":
                    sqlText = "SELECT * ";
                    sqlText += "FROM \"AggregateTest\" ";
                    sqlText += "WHERE \"LastName\" = {0}";

                    break;

                case "esMySQL":
					sqlText = "SELECT * ";
					sqlText += "FROM `AggregateTest` ";
					sqlText += "WHERE `LastName` = {0}";

                    break;

				default:
					sqlText = "SELECT * ";
					sqlText += "FROM [AggregateTest] ";
					sqlText += "WHERE [LastName] = {0}";

                    break;
            }

            return this.FillDataSet(esQueryType.Text, sqlText, "Doe");
        }

		public DataSet CustomFillDataSetTextNoParams(string lastName)
		{
			string sqlText = "";

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT * ";
					sqlText += "FROM \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "WHERE \"LastName\" = '" + lastName + "'";

                    break;

                case "esPgsql":
                    sqlText = "SELECT * ";
                    sqlText += "FROM \"AggregateTest\" ";
                    sqlText += "WHERE \"LastName\" = '" + lastName + "'";

                    break;

                case "esMySQL":
					sqlText = "SELECT * ";
					sqlText += "FROM `AggregateTest` ";
					sqlText += "WHERE `LastName` = '" + lastName + "'";

                    break;

				default:
					sqlText = "SELECT * ";
					sqlText += "FROM [AggregateTest] ";
					sqlText += "WHERE [LastName] = '" + lastName + "'";

                    break;
            }

            return this.FillDataSet(esQueryType.Text, sqlText);
        }

        public DataSet CustomFillDataSetEsParams(int Id)
        {
            esParameters esParams = new esParameters();
            esParams.Add("ID", Id);

            DataSet dataSet =
                this.FillDataSet(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, esParams);
            return dataSet;
        }

        #endregion

		#region FillDataTable

		public DataTable CustomFillDataTableNoParams()
		{
			DataTable dataTable = this.FillDataTable(this.es.Schema, this.es.spLoadAll);
			return dataTable;
		}

        public DataTable CustomFillDataTableEsParams(int Id)
        {
            esParameters esParams = new esParameters();
            esParams.Add("ID", Id);

            DataTable dataTable = 
                this.FillDataTable(this.es.Schema, this.es.spLoadByPrimaryKey, esParams);
            return dataTable;
        }

        public DataTable CustomFillDataTableEsParams2(int Id)
        {
            esParameters esParams = new esParameters();
            esParams.Add("ID", Id);

            DataTable dataTable =
                this.FillDataTable(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, esParams);
            return dataTable;
        }

        public DataTable CustomFillDataTableText()
		{
			string sqlText = "";

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT * ";
					sqlText += "FROM \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "WHERE \"LastName\" = {0} ";
					sqlText += "OR \"LastName\" = {1} ";

                    break;

                case "esPgsql":
                    sqlText = "SELECT * ";
                    sqlText += "FROM \"AggregateTest\" ";
                    sqlText += "WHERE \"LastName\" = {0} ";
                    sqlText += "OR \"LastName\" = {1} ";

                    break;

                case "esMySQL":
					sqlText = "SELECT * ";
					sqlText += "FROM `AggregateTest` ";
					sqlText += "WHERE `LastName` = {0} ";
					sqlText += "OR `LastName` = {1}";

                    break;

				default:
					sqlText = "SELECT * ";
					sqlText += "FROM [AggregateTest] ";
					sqlText += "WHERE [LastName] = {0} ";
					sqlText += "OR [LastName] = {1}";

                    break;
            }

            return this.FillDataTable(esQueryType.Text, sqlText, "Doe", "Johnson");
        }

		#endregion

		#region Custom Load

		public bool CustomLoadText()
		{
			string sqlText = "";

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT \"LastName\", \"DepartmentID\", \"HireDate\" ";
					sqlText += "FROM \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "WHERE \"DepartmentID\" = {0} ";
					sqlText += "OR \"DepartmentID\" = {1} ";

                    break;

                case "esPgsql":
                    sqlText = "SELECT \"LastName\", \"DepartmentID\", \"HireDate\" ";
                    sqlText += "FROM \"AggregateTest\" ";
                    sqlText += "WHERE \"DepartmentID\" = {0} ";
                    sqlText += "OR \"DepartmentID\" = {1} ";

                    break;

                case "esMySQL":
					sqlText = "SELECT `LastName`, `DepartmentID`, `HireDate` ";
					sqlText += "FROM `AggregateTest` ";
					sqlText += "WHERE `DepartmentID` = {0} ";
					sqlText += "OR `DepartmentID` = {1}";

                    break;

				default:
					sqlText = "SELECT [LastName], [DepartmentID], [HireDate] ";
					sqlText += "FROM [AggregateTest] ";
					sqlText += "WHERE [DepartmentID] = {0} ";
					sqlText += "OR [DepartmentID] = {1}";

                    break;
            }

            return this.Load(esQueryType.Text, sqlText, 1, 2);
        }

		public bool CustomLoadTextEsParams(string lastName)
		{
			string sqlText = "";
			lastName = "%" + lastName + "%";
			esParameters esParams = new esParameters();
			esParams.Add("LastName", lastName);

			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					sqlText = "SELECT * ";
					sqlText += "FROM \"MYGENERATION\".\"AggregateTest\" ";
					sqlText += "WHERE \"LastName\" LIKE :LastName";

                    break;

                case "esPgsql":
                    sqlText = "SELECT * ";
                    sqlText += "FROM \"AggregateTest\" ";
                    sqlText += "WHERE \"LastName\" LIKE :LastName";

                    break;

                case "esMySQL":
					sqlText = "SELECT * ";
					sqlText += "FROM `AggregateTest` ";
					sqlText += "WHERE `LastName` LIKE ?LastName";

                    break;

				default:
					sqlText = "SELECT * ";
					sqlText += "FROM [AggregateTest] ";
					sqlText += "WHERE [LastName] LIKE @LastName";

                    break;
            }

            return this.Load(esQueryType.Text, sqlText, esParams);
        }

		#endregion

        public decimal GetTotalSalaries()
        {
            return (decimal)this.ExecuteScalar(esQueryType.StoredProcedure, "proc_GetTotalSalaries");
        }

        public string GetFullName(int ID)
		{
			esParameters parms = new esParameters();


			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esMySQL":
					parms.Add("pID", ID);
					parms.Add("FullName", esParameterDirection.Output, DbType.String, 40);
					break;
				case "esOracle":
					parms.Add("pID", ID);
					parms.Add("pFullName", esParameterDirection.Output, DbType.String, 40);
					break;
				default:
					parms.Add("ID", ID);
					parms.Add("FullName", esParameterDirection.Output, DbType.String, 40);
					break;
			}

			this.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_GetEmployeeFullName", parms);

			string returnValue = "";
			switch (this.es.Connection.ProviderMetadataKey)
			{
				case "esOracle":
					returnValue = parms["pFullName"].Value as string;
					break;
				default:
					returnValue = parms["FullName"].Value as string;
					break;
			}
			return returnValue;
		}

        //public int TestAssignPrimaryKeys()
        //{
        //    this.AssignPrimaryKeys();
        //    return this.Table.PrimaryKey.Length;
        //}

        //public int TestRemovePrimaryKeys()
        //{
        //    this.RemovePrimaryKeys();
        //    return this.Table.PrimaryKey.Length;
        //}

		public void TestParamsWithScale()
		{
			esParameter myParam = new esParameter("Salary", 12.34);
			myParam.DbType = DbType.Decimal;
			myParam.Precision = 18;
			myParam.Scale = 2;
			myParam.Direction = esParameterDirection.InputOutput;

			esParameters parms = new esParameters();
			parms.Add(myParam);
			parms.Add("DepartmentID", 1);
            //parms.Add("DepartmentID", null);
            parms.Add("FirstName", "Entity");
			parms.Add("LastName", "Spaces");
			parms.Add("Age", 100);
			parms.Add("HireDate", "2000-12-31 00:00:00");
			parms.Add("IsActive", false);
			this.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_esTestInsert", parms);
		}

        public void TestNullParams()
        {
            esParameters parms = new esParameters();
            parms.Add("DepartmentID", null);
            parms.Add("FirstName", null);
            parms.Add("LastName", "NullTest");
            parms.Add("Age", null);
            parms.Add("HireDate", null);
            parms.Add("Salary", null);
            parms.Add("IsActive", false);
            this.ExecuteNonQuery(esQueryType.StoredProcedure, "proc_esTestInsert", parms);
        }

        public void TestIdentityInsert()
        {
            AggregateTestCollection coll = new AggregateTestCollection();
            coll.LoadAll();

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET IDENTITY_INSERT [AggregateTest] ON");
            sql.AppendLine("SET NOCOUNT ON");

            for (int i = 1; i < coll.Count; i++)
            {
                sql.AppendLine("INSERT INTO [AggregateTest]([ID], [LastName])");
                sql.AppendLine("VALUES(" + i.ToString() + ", '" + coll[ i ].LastName + "')");
            }

            sql.AppendLine("SET IDENTITY_INSERT [AggregateTest] OFF");

            //esUtility u = new esUtility();
            //u.ExecuteNonQuery(esQueryType.Text, sql.ToString());
        }

        public void TestUpdateWithNullParams()
        {
            int test = 0;
            string sqlText = "";
            esParameters esParams = new esParameters();
            esParams.Add("DepartmentID", test);
            esParams.Add("FirstName", DBNull.Value);
            esParams.Add("LastName", "NullTest");

            sqlText = "UPDATE [AggregateTest] ";
            sqlText += "SET [DepartmentID] = @DepartmentID, ";
            sqlText += "[FirstName] =  @FirstName ";
            sqlText += "WHERE [LastName] = @LastName";

            this.ExecuteNonQuery(esQueryType.Text, sqlText, esParams);
        }

        //public override bool LoadAll()
        //{
        //    return base.LoadAll();
        //}

        public override void Save()
        {
            bool collectionValid = true;

            foreach (AggregateTest entity in this)
            {
                if (entity.es.IsDirty)
                {
                    if (!entity.Validate())
                    {
                        collectionValid = false;
                    }
                }
            }

            if (collectionValid)
            {
                base.Save();
            }
            else
            {
                // Do something
            }
        }

    }

    // Test combining DynamicQuery with custom selection criteria.
    //public bool Select()
    //{
    //    if (Query.Load())
    //    {
    //        for(int i = this.Count - 1; i >= 0; i--)
    //        {
    //            AggregateTest unit = (AggregateTest)this[i];
    //            if (unit.IsActive.HasValue && unit.IsActive.Value)
    //            {
    //                DetachEntity(unit);
    //            }
    //        }
    //        return Count > 0;
    //    }
    //    return false;
    //}

    #endregion
}
