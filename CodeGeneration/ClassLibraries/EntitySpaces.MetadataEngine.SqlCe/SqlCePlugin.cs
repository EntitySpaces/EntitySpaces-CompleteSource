/*  New BSD License
-------------------------------------------------------------------------------
Copyright (c) 2006-2012, EntitySpaces, LLC
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the EntitySpaces, LLC nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL EntitySpaces, LLC BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
-------------------------------------------------------------------------------
*/



using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;

using EntitySpaces.MetadataEngine;

//using System.Data.SqlServerCe;

namespace MyMeta.Plugins
{
    public class SqlCePlugin : IPlugin
	{
        static private AppDomain _appDomain;

		#region IPlugin Interface

		private IContext context;

        bool IPlugin.OnLoad()
        {
            _appDomain = AppDomain.CreateDomain("EntitySpaces.MetadataEngine.SqlCe");
            return _appDomain != null;
        }

        void IPlugin.OnUnload()
        {
            if (_appDomain != null)
            {
                AppDomain.Unload(_appDomain);
                _appDomain = null;
            }
        }

        void IPlugin.Initialize(IContext context)
        {
            this.context = context;
        }

        string IPlugin.ProviderName
        {
            get { return @"Microsoft SQL CE"; }
        }

        string IPlugin.ProviderUniqueKey
        {
            get { return @"SQLCE"; }
        }

        string IPlugin.ProviderAuthorInfo
        {
            get { return @"Microsoft SQL CE Plugin"; }
        }

        Uri IPlugin.ProviderAuthorUri
        {
            get { return new Uri(@"http://www.entityspaces.net/"); }
        }

        bool IPlugin.StripTrailingNulls
        {
            get { return false; }
        }

        bool IPlugin.RequiredDatabaseName
        {
            get { return false; }
        }

        string IPlugin.SampleConnectionString
        {
            get { return @"Data Source=C:\Program Files\Microsoft SQL Server Compact Edition\v3.1\SDK\Samples\Northwind.sdf"; }
        }

        IDbConnection IPlugin.NewConnection
        {
            get
            {
                if (IsIntialized)
				{
                    IDbConnection cn =  SqlCePlugin.CreateConnection(this.context.ConnectionString);
                    cn.Open();
                    return cn;
				}
                else
                    return null;
            }
        }

        string IPlugin.DefaultDatabase
        {
            get
            {
				return this.GetDatabaseName();
            }
        }

        DataTable IPlugin.Databases
        {
            get
            {
				DataTable metaData = new DataTable();

				try
				{
					metaData = context.CreateDatabasesDataTable();

					DataRow row = metaData.NewRow();
					metaData.Rows.Add(row);

					row["CATALOG_NAME"] = GetDatabaseName();
                    //row["DESCRIPTION"]  = db.Description;
				}
				finally
				{

				}

				return metaData;
            }
        }

        DataTable IPlugin.GetTables(string database)
        {
            IDataReader reader = null;
            DataTable metaData = new DataTable();

            try
            {
                metaData = context.CreateTablesDataTable();

                string query = "SELECT TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='TABLE'";
                IDbCommand cmd = SqlCePlugin.CreateCommand(query, this.context.ConnectionString);

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    DataRow row = metaData.NewRow();
                    metaData.Rows.Add(row);

                    row["TABLE_CATALOG"] = reader.GetValue(0);
                    row["TABLE_SCHEMA"] = reader.GetValue(1);
                    row["TABLE_NAME"] = reader.GetValue(2);
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
			finally
			{
                if (reader != null)
                {
                    reader.Close();
                }
			}

			return metaData;
        }

		DataTable IPlugin.GetViews(string database)
		{
			DataTable metaData = new DataTable();
            return metaData;
		}

        DataTable IPlugin.GetProcedures(string database)
        {
            return new DataTable();
        }

        DataTable IPlugin.GetDomains(string database)
        {
            return new DataTable();
        }

        DataTable IPlugin.GetProcedureParameters(string database, string procedure)
        {
            return new DataTable();
        }

        DataTable IPlugin.GetProcedureResultColumns(string database, string procedure)
        {
            return new DataTable();
        }

        DataTable IPlugin.GetViewColumns(string database, string view)
        {
            DataTable metaData = new DataTable();
            return metaData;
        }

        DataTable IPlugin.GetTableColumns(string database, string table)
        {
            IDataReader reader = null;
            DataTable metaData = new DataTable();

            try
            {
                metaData = context.CreateColumnsDataTable();

                string query = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + table + "'";
                IDbCommand cmd = SqlCePlugin.CreateCommand(query, this.context.ConnectionString);

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    DataRow row = metaData.NewRow();
                    metaData.Rows.Add(row);

                    row["TABLE_CATALOG"] = reader["TABLE_CATALOG"];
                    row["TABLE_SCHEMA"] = reader["TABLE_SCHEMA"];
                    row["TABLE_NAME"] = reader["TABLE_NAME"];
                    row["COLUMN_NAME"] = reader["COLUMN_NAME"];
                    row["ORDINAL_POSITION"] = reader["ORDINAL_POSITION"];
                    row["DESCRIPTION"] = reader["DESCRIPTION"];

                    if (reader["IS_NULLABLE"] != DBNull.Value)
                    {
                        string isNullable = reader.GetString(reader.GetOrdinal("IS_NULLABLE"));
                        isNullable = isNullable.ToUpper();
                        row["IS_NULLABLE"] = (isNullable == "NO") ? false : true;
                    }

                    if (reader.GetBoolean(reader.GetOrdinal("COLUMN_HASDEFAULT")))
                    {
                        row["COLUMN_HASDEFAULT"] = true;
                        row["COLUMN_DEFAULT"] = reader["COLUMN_DEFAULT"];
                    }

                    if (reader["AUTOINC_INCREMENT"] != DBNull.Value)
                    {
                        row["IS_AUTO_KEY"] = true;
                        row["AUTO_KEY_SEED"] = Convert.ToInt32(reader["AUTOINC_SEED"]);
                        row["AUTO_KEY_INCREMENT"] = Convert.ToInt32(reader["AUTOINC_INCREMENT"]);
                    }

                    string type = (string)reader["DATA_TYPE"];
                    int charMax = 0;
                    short precision = 0;
                    short scale = 0;

                    if (reader["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                    {
                        charMax = (int)reader["CHARACTER_MAXIMUM_LENGTH"];
                    }

                    if (reader["NUMERIC_PRECISION"] != DBNull.Value)
                    {
                        precision = (short)reader["NUMERIC_PRECISION"];
                    }

                    if (reader["NUMERIC_SCALE"] != DBNull.Value)
                    {
                        scale = (short)reader["NUMERIC_SCALE"];
                    }

                    row["TYPE_NAME"] = type;
                    row["TYPE_NAME_COMPLETE"] = this.GetDataTypeNameComplete(type, charMax, precision, scale);

                    row["NUMERIC_PRECISION"] = precision;
                    row["NUMERIC_SCALE"] = scale;

                    row["CHARACTER_MAXIMUM_LENGTH"] = charMax;

                    row["IS_COMPUTED"] = (type == "timestamp") ? true : false;

                    row["IS_CONCURRENCY"] = (type == "rowversion" || type == "timestamp") ? true : false;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return metaData;
        }

        List<string> IPlugin.GetPrimaryKeyColumns(string database, string table)
        {
            IDataReader reader = null;
			List<string> primaryKeys = new List<string>();

            try
            {
                string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.INDEXES where Table_Name='" + table + "' AND PRIMARY_KEY=1";
                IDbCommand cmd = SqlCePlugin.CreateCommand(query, this.context.ConnectionString);

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    primaryKeys.Add(reader.GetString(0));
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

			return primaryKeys;
        }

        List<string> IPlugin.GetViewSubViews(string database, string view)
        {
            return new List<string>();
        }

        List<string> IPlugin.GetViewSubTables(string database, string view)
        {
            return new List<string>();
        }

        DataTable IPlugin.GetTableIndexes(string database, string table)
        {
            IDataReader reader = null;
			DataTable metaData = new DataTable();

            try
            {
                metaData = context.CreateIndexesDataTable();

                string query = "SELECT * FROM INFORMATION_SCHEMA.INDEXES WHERE TABLE_NAME='" + table + "'";
                IDbCommand cmd = SqlCePlugin.CreateCommand(query, this.context.ConnectionString);

                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    DataRow row = metaData.NewRow();
                    metaData.Rows.Add(row);

                    row["TABLE_NAME"] = reader["TABLE_NAME"];
                    row["INDEX_NAME"] = reader["INDEX_NAME"];
                    row["UNIQUE"] = reader["UNIQUE"];
                    row["CLUSTERED"] = reader["CLUSTERED"];
                    row["AUTO_UPDATE"] = reader["AUTO_UPDATE"];
                    row["SORT_BOOKMARKS"] = reader["SORT_BOOKMARKS"];
                    row["FILTER_CONDITION"] = reader["FILTER_CONDITION"];
                    row["NULL_COLLATION"] = reader["NULL_COLLATION"];
                    row["INITIAL_SIZE"] = reader["INITIAL_SIZE"];
                    row["CARDINALITY"] = Convert.ToDecimal(reader["CARDINALITY"]);
                    row["COLLATION"] = reader["COLLATION"];
                    row["COLUMN_NAME"] = reader["COLUMN_NAME"];
                    row["FILL_FACTOR"] = reader["FILL_FACTOR"];
                    row["AUTO_UPDATE"] = reader["AUTO_UPDATE"];
                    row["PRIMARY_KEY"] = reader["PRIMARY_KEY"];
                    row["NULLS"] = reader["NULLS"];
                    row["ORDINAL_POSITION"] = reader["ORDINAL_POSITION"];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

			return metaData;
        }

        DataTable IPlugin.GetForeignKeys(string database, string table)
        {
			DataTable metaData = new DataTable();

            try
            {
                metaData = context.CreateForeignKeysDataTable();

                LoadForeignKeysPartOne(metaData, table);
                LoadForeignKeysPartTwo(metaData, table);
            }
            catch { }

			return metaData;
        }

        private void LoadForeignKeysPartOne(DataTable metaData, string table)
        {
            IDataReader fk = null;
            IDataReader pCols = null;
            IDataReader fCols = null;

            try
            {
                string query =
    "SELECT tc.*, rc.UPDATE_RULE, rc.DELETE_RULE, rc.UNIQUE_CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc " +
    "JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc ON tc.CONSTRAINT_NAME = rc.CONSTRAINT_NAME " +
    "WHERE tc.CONSTRAINT_TYPE='FOREIGN KEY' AND tc.TABLE_NAME = '" + table + "'";

                fk = SqlCePlugin.CreateCommand(query, this.context.ConnectionString).ExecuteReader(CommandBehavior.CloseConnection);

                while (fk.Read())
                {
                    //---------------------------------------
                    // Get the Primary Key and Columns
                    //---------------------------------------
                    query = "SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_NAME='" + fk["UNIQUE_CONSTRAINT_NAME"] + "'";
                    pCols = SqlCePlugin.CreateCommand(query, this.context.ConnectionString).ExecuteReader(CommandBehavior.CloseConnection);

                    //---------------------------------------
                    // Get the Foreign Key Columns
                    //---------------------------------------
                    query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_NAME = '" + fk["CONSTRAINT_NAME"] + "'";
                    fCols = SqlCePlugin.CreateCommand(query, this.context.ConnectionString).ExecuteReader(CommandBehavior.CloseConnection);

                    while (pCols.Read() && fCols.Read())
                    {
                        DataRow row = metaData.NewRow();
                        metaData.Rows.Add(row);

                        // The main Information ...
                        row["PK_TABLE_CATALOG"] = DBNull.Value;
                        row["PK_TABLE_SCHEMA"] = DBNull.Value;
                        row["FK_TABLE_CATALOG"] = DBNull.Value;
                        row["FK_TABLE_SCHEMA"] = DBNull.Value;
                        row["FK_TABLE_NAME"] = fk["TABLE_NAME"];
                        row["PK_TABLE_NAME"] = pCols["TABLE_NAME"];
                        row["ORDINAL"] = 0;
                        row["FK_NAME"] = fk["CONSTRAINT_NAME"];
                        row["UPDATE_RULE"] = fk["UPDATE_RULE"];
                        row["DELETE_RULE"] = fk["DELETE_RULE"];

                        bool isDeferrable = (bool)fk["IS_DEFERRABLE"];
                        bool initiallyDeferred = (bool)fk["INITIALLY_DEFERRED"];

                        if (isDeferrable)
                        {
                            row["DEFERRABILITY"] = initiallyDeferred ? 1 : 2;
                        }
                        else
                        {
                            row["DEFERRABILITY"] = 3;
                        }

                        row["PK_NAME"] = pCols["CONSTRAINT_NAME"];
                        row["PK_COLUMN_NAME"] = pCols["COLUMN_NAME"];
                        row["FK_COLUMN_NAME"] = fCols["COLUMN_NAME"];
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally
            {
                if (fk != null)    fk.Close();
                if (pCols != null) pCols.Close();
                if (fCols != null) fCols.Close();
            }
        }

        private void LoadForeignKeysPartTwo(DataTable metaData, string table)
        {
            IDataReader fk = null;
            IDataReader pCols = null;
            IDataReader fCols = null;

            try
            {
                string query = "SELECT INDEX_NAME FROM INFORMATION_SCHEMA.INDEXES WHERE TABLE_NAME='" + table + "' AND PRIMARY_KEY=1";
                fk = SqlCePlugin.CreateCommand(query, this.context.ConnectionString).ExecuteReader(CommandBehavior.CloseConnection);

                string pkName = "";

                // Get primary key name
                if (fk.Read())
                {
                    pkName = (string)fk.GetValue(0);
                    fk.Close();
                }
                else return;

                // Got it
                query =
    "SELECT tc.*, rc.UPDATE_RULE, rc.DELETE_RULE, rc.UNIQUE_CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc " +
    "JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc ON tc.CONSTRAINT_NAME = rc.CONSTRAINT_NAME " +
    "WHERE tc.CONSTRAINT_TYPE='FOREIGN KEY' AND rc.UNIQUE_CONSTRAINT_NAME = '" + pkName + "'";

                fk = SqlCePlugin.CreateCommand(query, this.context.ConnectionString).ExecuteReader(CommandBehavior.CloseConnection);

                while (fk.Read())
                {
                    //---------------------------------------
                    // Get the Primary Key and Columns
                    //---------------------------------------
                    query = "SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_NAME='" + fk["UNIQUE_CONSTRAINT_NAME"] + "'";
                    pCols = SqlCePlugin.CreateCommand(query, this.context.ConnectionString).ExecuteReader(CommandBehavior.CloseConnection);

                    //---------------------------------------
                    // Get the Foreign Key Columns
                    //---------------------------------------
                    query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_NAME = '" + fk["CONSTRAINT_NAME"] + "'";
                    fCols = SqlCePlugin.CreateCommand(query, this.context.ConnectionString).ExecuteReader(CommandBehavior.CloseConnection);

                    while (pCols.Read() && fCols.Read())
                    {
                        DataRow row = metaData.NewRow();
                        metaData.Rows.Add(row);

                        // The main Information ...
                        row["PK_TABLE_CATALOG"] = DBNull.Value;
                        row["PK_TABLE_SCHEMA"] = DBNull.Value;
                        row["FK_TABLE_CATALOG"] = DBNull.Value;
                        row["FK_TABLE_SCHEMA"] = DBNull.Value;
                        row["FK_TABLE_NAME"] = fk["TABLE_NAME"];
                        row["PK_TABLE_NAME"] = pCols["TABLE_NAME"];
                        row["ORDINAL"] = 0;
                        row["FK_NAME"] = fk["CONSTRAINT_NAME"];
                        row["UPDATE_RULE"] = fk["UPDATE_RULE"];
                        row["DELETE_RULE"] = fk["DELETE_RULE"];

                        bool isDeferrable = (bool)fk["IS_DEFERRABLE"];
                        bool initiallyDeferred = (bool)fk["INITIALLY_DEFERRED"];

                        if (isDeferrable)
                        {
                            row["DEFERRABILITY"] = initiallyDeferred ? 1 : 2;
                        }
                        else
                        {
                            row["DEFERRABILITY"] = 3;
                        }

                        row["PK_NAME"] = pCols["CONSTRAINT_NAME"];
                        row["PK_COLUMN_NAME"] = pCols["COLUMN_NAME"];
                        row["FK_COLUMN_NAME"] = fCols["COLUMN_NAME"];
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally
            {
                if (fk != null) fk.Close();
                if (pCols != null) pCols.Close();
                if (fCols != null) fCols.Close();
            }
        }

        public object GetDatabaseSpecificMetaData(object myMetaObject, string key)
        {
            return null;
        }

		#endregion

		#region Internal Methods

        private bool IsIntialized 
		{ 
			get 
			{ 
				return (context != null); 
			} 
		}

		public string GetDatabaseName()
		{
            IDbConnection cn = SqlCePlugin.CreateConnection(context.ConnectionString);
            string dbName = cn.Database;

            int index = dbName.LastIndexOfAny(new char[] { '\\' });
            if (index >= 0)
            {
                dbName = dbName.Substring(index + 1);
            }

			return dbName;
		}

		public string GetFullDatabaseName()
		{
            IDbConnection cn = SqlCePlugin.CreateConnection(context.ConnectionString);
            return cn.Database;
		}

		#endregion

        #region Other Methods

        private string GetDataTypeNameComplete(string dataType, int charMax, short precision, short scale)
        {
            switch (dataType)
            {
                case "binary":
                case "char":
                case "nchar":
                case "nvarchar":
                case "varchar":
                case "varbinary":
                    return dataType + "(" + charMax + ")";

                case "decimal":
                case "numeric":
                    return dataType + "(" + precision + "," + scale + ")";

                default:
                    return dataType;
            }
        }

        #endregion

        static internal string nameSpace = "System.Data.SqlServerCe.";

        #region Domain/Reflection

        static internal IDbConnection CreateConnection(string connStr)
        {
            IDbConnection cn = _appDomain.CreateInstanceAndUnwrap
            (
                "System.Data.SqlServerCe," + GetAssemblyVersion(connStr),
                "System.Data.SqlServerCe.SqlCeConnection",
                false,
                BindingFlags.Default,
                null,
                new object[] { GetConnectionString(connStr) }, 
                null, 
                null, 
                null
            ) as IDbConnection;

            return cn;
        }

        static internal DbDataAdapter CreateAdapter(string query, string connStr)
        {
            DbDataAdapter adapter = _appDomain.CreateInstanceAndUnwrap
            (
                "System.Data.SqlServerCe," + GetAssemblyVersion(connStr),
                "System.Data.SqlServerCe.SqlCeDataAdapter",
                false,
                BindingFlags.OptionalParamBinding,
                null,
                new object[] { query, GetConnectionString(connStr) },
                null,
                null,
                null
            ) as DbDataAdapter;

            return adapter;
        }

        static internal IDbCommand CreateCommand(string commandText, string connStr)
        {
            IDbCommand cmd = _appDomain.CreateInstanceAndUnwrap
            (
                "System.Data.SqlServerCe," + GetAssemblyVersion(connStr),
                "System.Data.SqlServerCe.SqlCeCommand",
                false,
                BindingFlags.OptionalParamBinding,
                null,
                new object[] { commandText },
                null,
                null,
                null
            ) as IDbCommand;

            IDbConnection cn = SqlCePlugin.CreateConnection(connStr);

            cmd.Connection = cn;
            cn.Open();

            return cmd;
        }

        // "System.Data.SqlServerCe, Version=3.5.1.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91",
        static public string GetAssemblyVersion(string connection)
        {
            try
            {
                string[] connInfo = connection.Split(';');

                foreach (string entry in connInfo)
                {
                    string[] parts = entry.Split('=');

                    if (parts[0].ToLower() == "version")
                    {
                        return entry;
                    }
                }
            }
            catch { }

            return "";
        }

        static internal string GetConnectionString(string connectionString)
        {
            string[] connInfo = connectionString.Split(';');

            string trueConnectionString = String.Empty;

            foreach (string entry in connInfo)
            {
                if (entry == String.Empty) break;

                string[] parts = entry.Split('=');

                if (parts[0].ToLower() != "version")
                {
                    trueConnectionString += entry + ";";
                }
            }

            return trueConnectionString;
        }

        #endregion
    }
}