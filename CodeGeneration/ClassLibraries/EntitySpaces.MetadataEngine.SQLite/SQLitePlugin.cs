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

using System.Data.SQLite;

namespace EntitySpaces.MetadataEngine.SQLite
{
    public class SQLitePlugin : IPlugin
    {
        static private AppDomain _appDomain;

        #region IPlugin Interface

        private IContext context;

        bool IPlugin.OnLoad()
        {
            return true;
            //_appDomain = AppDomain.CreateDomain("EntitySpaces.MetadataEngine.Sybase");
            //return _appDomain != null;
        }

        void IPlugin.OnUnload()
        {
            //if (_appDomain != null)
            //{
            //    AppDomain.Unload(_appDomain);
            //    _appDomain = null;
            //}
        }

        void IPlugin.Initialize(IContext context)
        {
            this.context = context;
        }

        string IPlugin.ProviderName
        {
            get { return @"SQLite"; }
        }

        string IPlugin.ProviderUniqueKey
        {
            get { return @"SQLITE"; }
        }

        string IPlugin.ProviderAuthorInfo
        {
            get { return @"SQLite Plugin"; }
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
                    SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString);
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
                SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString);
                return cn.Database;
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
            DataTable metaData = new DataTable();

            try
            {
                using (SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString))
                {
                    cn.Open();
                    DataTable dt = cn.GetSchema("Tables", new string[] { database, null, null });
                    cn.Close();

                    metaData = context.CreateTablesDataTable();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = metaData.NewRow();
                        metaData.Rows.Add(row);

                        DataRow dtRow = dt.Rows[i];

                        row["TABLE_CATALOG"] = cn.Database;
                        row["TABLE_SCHEMA"] = dtRow["TABLE_SCHEMA"];
                        row["TABLE_NAME"] = dtRow["TABLE_NAME"];
                    }
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }

            return metaData;
        }

        DataTable IPlugin.GetViews(string database)
        {
            DataTable metaData = new DataTable();

            try
            {
                using (SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString))
                {
                    cn.Open();
                    DataTable dt = cn.GetSchema("Views");//, new string[] { null, null, "VIEW" });
                    cn.Close();

                    metaData = context.CreateTablesDataTable();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = metaData.NewRow();
                        metaData.Rows.Add(row);

                        DataRow dtRow = dt.Rows[i];

                        row["TABLE_CATALOG"] = cn.Database;
                        row["TABLE_SCHEMA"] = dtRow["TABLE_SCHEMA"];
                        row["TABLE_NAME"] = dtRow["TABLE_NAME"];
                    }
                }
            }
            catch { }

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
            return ((IPlugin)this).GetTableColumns(database, view);
        }

        DataTable IPlugin.GetTableColumns(string database, string table)
        {
            DataTable metaData = new DataTable();

            try
            {
                using (SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString))
                {
                    cn.Open();
                    DataTable dt = cn.GetSchema("Columns", new string[] { database, null, table });
                    cn.Close();

                    metaData = context.CreateColumnsDataTable();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = metaData.NewRow();
                        metaData.Rows.Add(row);

                        DataRow dtRow = dt.Rows[i];

                        row["TABLE_CATALOG"] = cn.Database;
                        row["TABLE_SCHEMA"] = dtRow["TABLE_SCHEMA"];
                        row["TABLE_NAME"] = dtRow["TABLE_NAME"];
                        row["COLUMN_NAME"] = dtRow["COLUMN_NAME"];
                        row["ORDINAL_POSITION"] = dtRow["ORDINAL_POSITION"];

                        string typeName = (string)dtRow["DATA_TYPE"];
                        if (typeName != null)
                        {
                            typeName = typeName.Trim();
                        }
                        row["TYPE_NAME"] = typeName;

                        if (dtRow["IS_NULLABLE"] != DBNull.Value)
                        {
                            string isNullable = dtRow["IS_NULLABLE"].ToString().ToUpper();
                            row["IS_NULLABLE"] = (isNullable == "FALSE") ? false : true;
                        }

                        if (dtRow["COLUMN_DEFAULT"] != DBNull.Value)
                        {
                            row["COLUMN_HASDEFAULT"] = true;
                            row["COLUMN_DEFAULT"] = dtRow["COLUMN_DEFAULT"];
                        }
                        else
                        {
                            row["COLUMN_HASDEFAULT"] = false;
                        }

                        if (dtRow["AUTOINCREMENT"] != DBNull.Value)
                        {
                            bool autoKey = (bool)dtRow["AUTOINCREMENT"];

                            if (autoKey)
                            {
                                row["IS_AUTO_KEY"] = true;
                                row["AUTO_KEY_SEED"] = 0;
                                row["AUTO_KEY_INCREMENT"] = 1;
                            }
                        }

                        if (row["COLUMN_DEFAULT"] != DBNull.Value)
                        {
                            switch (row["COLUMN_DEFAULT"].ToString().ToLower())
                            {
                                case "current timestamp":

                                    row["IS_COMPUTED"] = true;
                                    break;

                                case "timestamp":

                                    row["IS_COMPUTED"] = true;
                                    row["IS_CONCURRENCY"] = true;
                                    break;
                            }
                        }

                        long charMax = 0;
                        int precision = 0;
                        short scale = 0;

                        if (dt.Columns.Contains("CHARACTER_MAXIMUM_LENGTH") && dtRow["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
                        {
                            charMax = Convert.ToInt64(dtRow["CHARACTER_MAXIMUM_LENGTH"]);
                        }

                        if (dt.Columns.Contains("NUMERIC_PRECISION") && dtRow["NUMERIC_PRECISION"] != DBNull.Value)
                        {
                            precision = Convert.ToInt32(dtRow["NUMERIC_PRECISION"]);
                        }

                        if (dt.Columns.Contains("NUMERIC_SCALE") && dtRow["NUMERIC_SCALE"] != DBNull.Value)
                        {
                            scale = Convert.ToInt16(dtRow["NUMERIC_SCALE"]);
                        }
                    }
                }
            }
            catch { }

            return metaData;
        }

        List<string> IPlugin.GetPrimaryKeyColumns(string database, string table)
        {
            IDataReader reader = null;
            List<string> primaryKeys = new List<string>();

            try
            {
                using (SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString))
                {
                    cn.Open();
                    DataTable metaData = cn.GetSchema("Columns", new string[] { database, null, table });
                    cn.Close();

                    for (int i = 0; i < metaData.Rows.Count; i++)
                    {
                        DataRow dtRow = metaData.Rows[i];

                        if (dtRow["PRIMARY_KEY"] != DBNull.Value)
                        {
                            bool pk = (bool)dtRow["PRIMARY_KEY"];

                            if (pk)
                            {
                                primaryKeys.Add((string)dtRow["COLUMN_NAME"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
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
            DataTable metaData = new DataTable();

            try
            {
                //using (SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString))
                //{
                //    cn.Open();
                //    DataTable dt = cn.GetSchema("Indexes", new string[] { database, null, table });
                //    cn.Close();

                //    metaData = context.CreateIndexesDataTable();

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        DataRow dtRow = dt.Rows[i];

                //        DumpRow(dtRow);

                //        DataRow row = metaData.NewRow();
                //        metaData.Rows.Add(row);

                //        row["TABLE_NAME"] = table;
                //        row["INDEX_NAME"] = dtRow["INDEX_NAME"];
                //        row["PRIMARY_KEY"] = Convert.ToBoolean(dtRow["PRIMARY_KEY"]);
                //        row["UNIQUE"] = Convert.ToBoolean(dtRow["UNIQUE"]);

                //        //string[] columnData = column.Split(' ');
                //        //row["COLUMN_NAME"] = columnData[0];

                //        //if (columnData[1] == "ASC")
                //        //{
                //        //    row["COLLATION"] = 1;
                //        //}
                //        //else
                //        //{
                //        //    row["COLLATION"] = 2;
                //        //}
                //    }
                //}
            }
            catch { }

            return metaData;
        }

        DataTable IPlugin.GetForeignKeys(string database, string table)
        {
            DataTable metaData = new DataTable();

            try
            {
                using (SQLiteConnection cn = new SQLiteConnection(this.context.ConnectionString))
                {
                    cn.Open();
                    DataTable dt = cn.GetSchema("ForeignKeys", new string[] { database, null, null }); //table });
                    cn.Close();

                    metaData = context.CreateForeignKeysDataTable();

                    foreach (DataRow dtRow in dt.Rows)
                    {
                        string pkTable = (string)dtRow["TABLE_NAME"];
                        string fkTable = (string)dtRow["FKEY_TO_TABLE"];

                        if (pkTable != table && fkTable != table) continue;

                        DataRow row = metaData.NewRow();
                        metaData.Rows.Add(row);

                        DumpRow(dtRow);

                        row["FK_NAME"] = dtRow["CONSTRAINT_NAME"];

                        row["PK_TABLE_CATALOG"] = dtRow["FKEY_TO_CATALOG"];
                        row["PK_TABLE_SCHEMA"] = dtRow["FKEY_TO_SCHEMA"];
                        row["PK_TABLE_NAME"] = dtRow["FKEY_TO_TABLE"];

                        row["FK_TABLE_CATALOG"] = dtRow["TABLE_CATALOG"];
                        row["FK_TABLE_SCHEMA"] = dtRow["TABLE_SCHEMA"];
                        row["FK_TABLE_NAME"] = dtRow["TABLE_NAME"];

                        row["FK_COLUMN_NAME"] = dtRow["FKEY_FROM_COLUMN"];
                        row["PK_COLUMN_NAME"] = dtRow["FKEY_TO_COLUMN"];

                        cn.Open();
                        DataTable colMetadata = cn.GetSchema("Columns", new string[] { database, null, (string)dtRow["TABLE_NAME"] });
                        cn.Close();

                        for (int i = 0; i < colMetadata.Rows.Count; i++)
                        {
                            DataRow colRow = colMetadata.Rows[i];

                            if (colRow["PRIMARY_KEY"] != DBNull.Value)
                            {
                                bool pk = (bool)colRow["PRIMARY_KEY"];

                                if (pk)
                                {
                                    row["PK_NAME"] = colRow["COLUMN_NAME"];
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return metaData;
        }

        public object GetDatabaseSpecificMetaData(object myMetaObject, string key)
        {
            return null;
        }

        public void DumpRow(DataRow row)
        {
            Console.WriteLine("====================================================");
            foreach (DataColumn col in row.Table.Columns)
            {
                object o = row[col.ColumnName];
                string value = (o != DBNull.Value) ? o.ToString() : "null";
                Console.WriteLine(col.ColumnName + " : " + value);
            }
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
            IDbConnection cn = SQLitePlugin.CreateConnection(context.ConnectionString);
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
            IDbConnection cn = SQLitePlugin.CreateConnection(context.ConnectionString);
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

        static internal string nameSpace = "iAnywhere.Data.SQLAnywhere.";

        #region Domain/Reflection

        static internal IDbConnection CreateConnection(string connStr)
        {
            return new SQLiteConnection(connStr);

            //Assembly asm = Assembly.LoadWithPartialName("iAnywhere.Data.SQLAnywhere");

            //IDbConnection cn = _appDomain.CreateInstanceAndUnwrap
            //(
            //    "iAnywhere.Data.SQLAnywhere," + GetAssemblyVersion(connStr),
            //    "iAnywhere.Data.SQLAnywhere.SQLiteConnection",
            //    false,
            //    BindingFlags.Default,
            //    null,
            //    new object[] { connStr }, //GetConnectionString(connStr) },
            //    null,
            //    null,
            //    null
            //) as IDbConnection;

            //return cn;
        }

        static internal DbDataAdapter CreateAdapter(string query, string connStr)
        {
            return new SQLiteDataAdapter(query, connStr);
            //DbDataAdapter adapter = _appDomain.CreateInstanceAndUnwrap
            //(
            //    "iAnywhere.Data.SQLAnywhere," + GetAssemblyVersion(connStr),
            //    "iAnywhere.Data.SQLAnywhere.SAAdapter",
            //    false,
            //    BindingFlags.OptionalParamBinding,
            //    null,
            //    new object[] { query, GetConnectionString(connStr) },
            //    null,
            //    null,
            //    null
            //) as DbDataAdapter;

            //return adapter;
        }

        static internal IDbCommand CreateCommand(string commandText, string connStr)
        {
            SQLiteConnection cn = new SQLiteConnection(connStr);
            return new SQLiteCommand(commandText, cn);

            //IDbCommand cmd = _appDomain.CreateInstanceAndUnwrap
            //(
            //    "iAnywhere.Data.SQLAnywhere," + GetAssemblyVersion(connStr),
            //    "iAnywhere.Data.SQLAnywhere.SQLiteCommand",
            //    false,
            //    BindingFlags.OptionalParamBinding,
            //    null,
            //    new object[] { commandText },
            //    null,
            //    null,
            //    null
            //) as IDbCommand;

            //IDbConnection cn = SybasePlugin.CreateConnection(connStr);

            //cmd.Connection = cn;
            //cn.Open();

            //return cmd;
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

            foreach (string entry in connInfo)
            {
                string[] parts = entry.Split('=');

                if (parts[0].ToLower() == "data source")
                {
                    connectionString = entry;
                    break;
                }
            }

            return connectionString;
        }

        #endregion
    }
}
