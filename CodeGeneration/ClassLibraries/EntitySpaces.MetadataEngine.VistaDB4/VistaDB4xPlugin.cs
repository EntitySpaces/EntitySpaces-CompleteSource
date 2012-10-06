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

using EntitySpaces.MetadataEngine;

using VistaDB;
using VistaDB.DDA;
using VistaDB.Provider;

namespace EntitySpaces.MetadataEngine.VistaDB4
{
    public class VistaDB4xPlugin : IPlugin
	{
        bool useOldForeignKeyWay = false;

		#region IPlugin Interface

		private IContext context;


        bool IPlugin.OnLoad()
        {
            return true;
        }

        void IPlugin.OnUnload()
        {

        }

        void IPlugin.Initialize(IContext context)
        {
            this.context = context;
        }

        string IPlugin.ProviderName
        {
            get { return @"VistaDB 4.x"; }
        }

        string IPlugin.ProviderUniqueKey
        {
            get { return @"VISTADB4"; }
        }

        string IPlugin.ProviderAuthorInfo
        {
            get { return @"VistaDB 3.x Plugin Written by EntitySpaces, LLC"; }
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
            get { return @"Data Source=C:\Program Files\VistaDB 3\Data\Northwind.vdb4;OpenMode=NonexclusiveReadOnly"; }
        }

        IDbConnection IPlugin.NewConnection
        {
            get
            {
                if (IsIntialized)
				{
                    VistaDBConnection cn = new VistaDBConnection(this.context.ConnectionString);
                    cn.Open();
					return cn as IDbConnection;
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
				IVistaDBDatabase db = null;

                try
                {
                    metaData = context.CreateDatabasesDataTable();

                    DataRow row = metaData.NewRow();
                    metaData.Rows.Add(row);

                    using (VistaDBConnection cn = new VistaDBConnection(context.ConnectionString))
                    {
                        db = DDA.OpenDatabase(this.GetFullDatabaseName(), VistaDBDatabaseOpenMode.NonexclusiveReadOnly, GetPassword(cn));
                    }

                    row["CATALOG_NAME"] = GetDatabaseName();
                    row["DESCRIPTION"] = db.Description;
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
				finally
				{
					if(db != null) db.Close();
				}

				return metaData;
            }
        }

        DataTable IPlugin.GetTables(string database)
        {
			DataTable metaData = new DataTable();
			IVistaDBDatabase db = null;

            try
            {
                metaData = context.CreateTablesDataTable();

                using (VistaDBConnection cn = new VistaDBConnection(context.ConnectionString))
                {
                    db = DDA.OpenDatabase(this.GetFullDatabaseName(), VistaDBDatabaseOpenMode.NonexclusiveReadOnly, GetPassword(cn));
                }

                IVistaDBTableNameCollection tables = db.GetTableNames();

                foreach (string table in tables)
                {
                    IVistaDBTableSchema tblStructure = db.TableSchema(table);

                    DataRow row = metaData.NewRow();
                    metaData.Rows.Add(row);

                    row["TABLE_NAME"] = tblStructure.Name;
                    row["DESCRIPTION"] = tblStructure.Description;
                }
            }
            finally
            {
                if (db != null) db.Close();
            }

			return metaData;
        }

		DataTable IPlugin.GetViews(string database)
		{
			DataTable metaData = new DataTable();

			try
			{
				metaData = context.CreateViewsDataTable();

                using (VistaDBConnection conn = new VistaDBConnection(context.ConnectionString))
				{
					using (VistaDBCommand cmd = new VistaDBCommand("SELECT * FROM GetViews()", conn))
					{
						using (VistaDBDataAdapter da = new VistaDBDataAdapter(cmd))
						{
							DataTable views = new DataTable();
							da.Fill(views);

							foreach(DataRow vistaRow in views.Rows)
							{
								DataRow row = metaData.NewRow();
								metaData.Rows.Add(row);

								row["TABLE_NAME"]   = vistaRow["VIEW_NAME"];
								row["DESCRIPTION"]  = vistaRow["DESCRIPTION"];
								row["VIEW_TEXT"]    = vistaRow["VIEW_DEFINITION"];
								row["IS_UPDATABLE"] = vistaRow["IS_UPDATABLE"];
							}
						}						 
					}
				}
			}
			catch{}

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

			try
			{
				metaData = context.CreateColumnsDataTable();

                using (VistaDBConnection conn = new VistaDBConnection(context.ConnectionString))
				{
					string sql = "SELECT * FROM GetViewColumns('" + view + "')";

					using (VistaDBCommand cmd = new VistaDBCommand(sql, conn))
					{
						using (VistaDBDataAdapter da = new VistaDBDataAdapter(cmd))
						{
							DataTable views = new DataTable();
							da.Fill(views);

							foreach(DataRow vistaRow in views.Rows)
							{
								DataRow row = metaData.NewRow();
								metaData.Rows.Add(row);

								int width		= Convert.ToInt32(vistaRow["COLUMN_SIZE"]);
								int dec			= 0; 
								int length      = 0;
								int octLength   = width;
								bool timestamp  = false;

								string type = vistaRow["DATA_TYPE_NAME"] as string;

								switch(type)
								{
									case "Char":
									case "NChar":
									case "NText":
									case "NVarchar":
									case "Text":
									case "Varchar":
										length = width;
										width  = 0;
										dec    = 0;
										break;

									case "Currency":
									case "Double":
									case "Decimal":
									case "Single":
										break;

									case "Timestamp":
										timestamp = true;
										break;

									default:
										width = 0;
										dec   = 0;
										break;
								}

								string def = Convert.ToString(vistaRow["DEFAULT_VALUE"]);

								row["TABLE_NAME"] = view;
								row["COLUMN_NAME"] = vistaRow["COLUMN_NAME"];
								row["ORDINAL_POSITION"] = vistaRow["COLUMN_ORDINAL"];
								row["IS_NULLABLE"] = vistaRow["ALLOW_NULL"];
								row["COLUMN_HASDEFAULT"] = def == string.Empty ? false : true;
								row["COLUMN_DEFAULT"] = def;
								row["IS_AUTO_KEY"] = vistaRow["IDENTITY_VALUE"];
								row["AUTO_KEY_SEED"] = vistaRow["IDENTITY_SEED"];
								row["AUTO_KEY_INCREMENT"] = vistaRow["IDENTITY_STEP"];
								row["TYPE_NAME"] = type;
								row["NUMERIC_PRECISION"] = width;
								row["NUMERIC_SCALE"] = dec;
								row["CHARACTER_MAXIMUM_LENGTH"] = length;
								row["CHARACTER_OCTET_LENGTH"] = octLength;
								row["DESCRIPTION"] = vistaRow["COLUMN_DESCRIPTION"];
                                row["TYPE_NAME_COMPLETE"] = this.GetDataTypeNameComplete(type, length, (short)width, (short)dec);

								if (timestamp)
								{
									row["IS_COMPUTED"] = true;
								}
							}
						}						 
					}
				}
			}
			catch{}

			return metaData;
        }

        DataTable IPlugin.GetTableColumns(string database, string table)
        {
			DataTable metaData = new DataTable();
			IVistaDBDatabase db = null;

			try
			{
				metaData = context.CreateColumnsDataTable();

                using (VistaDBConnection cn = new VistaDBConnection(context.ConnectionString))
                {
                    db = DDA.OpenDatabase(this.GetFullDatabaseName(), VistaDBDatabaseOpenMode.NonexclusiveReadOnly, GetPassword(cn));
                }

                IVistaDBTableNameCollection tables = db.GetTableNames();

				IVistaDBTableSchema tblStructure = db.TableSchema(table);

				foreach (IVistaDBColumnAttributes c in tblStructure) 
				{ 
					string colName = c.Name;

					string def = "";
                    if (tblStructure.DefaultValues[colName] != null)
					{
                        def = tblStructure.DefaultValues[colName].Expression;
					}
					int width		= c.MaxLength; //c.ColumnWidth;
					int dec			= 0; //c.ColumnDecimals;
					int length      = 0;
					int octLength   = width;

					IVistaDBIdentityInformation identity = null;
					if(tblStructure.Identities[colName] != null)
					{
						identity = tblStructure.Identities[colName];
					}

					string[] pks = null;
					if(tblStructure.Indexes["PrimaryKey"] != null)
					{
						pks = tblStructure.Indexes["PrimaryKey"].KeyExpression.Split(';');
					}
					else
					{
						foreach(IVistaDBIndexInformation pk in tblStructure.Indexes)
						{
							if(pk.Primary)
							{
								pks = pk.KeyExpression.Split(';');
								break;
							}
						}
					}

					System.Collections.Hashtable pkCols = null;
					if(pks != null)
					{
						pkCols = new Hashtable();
						foreach(string pkColName in pks)
						{
							pkCols[pkColName] = true;
						}
					}

					switch(c.Type)
					{
						case VistaDBType.Char:
						case VistaDBType.NChar:
						case VistaDBType.NText:
						case VistaDBType.NVarChar:
						case VistaDBType.Text:
						case VistaDBType.VarChar:
							length    = width;
							width     = 0;
							dec       = 0;
							break;

						case VistaDBType.Money:
						case VistaDBType.Float:
						case VistaDBType.Decimal:
						case VistaDBType.Real:
							break;

						default:
							width = 0;
							dec   = 0;
							break;
					}

					DataRow row = metaData.NewRow();
					metaData.Rows.Add(row);

					row["TABLE_NAME"] = tblStructure.Name;
					row["COLUMN_NAME"] = c.Name;
					row["ORDINAL_POSITION"] = c.RowIndex;
					row["IS_NULLABLE"] = c.AllowNull;
					row["COLUMN_HASDEFAULT"] = def == string.Empty ? false : true;
					row["COLUMN_DEFAULT"] = def;
					row["IS_AUTO_KEY"] = identity == null ? false : true;
					row["AUTO_KEY_SEED"] = 1;
					row["AUTO_KEY_INCREMENT"] = identity == null ? 0 : Convert.ToInt32(identity.StepExpression);
					row["TYPE_NAME"] = c.Type.ToString();
					row["NUMERIC_PRECISION"] = width;
					row["NUMERIC_SCALE"] = dec;
					row["CHARACTER_MAXIMUM_LENGTH"] = length;
					row["CHARACTER_OCTET_LENGTH"] = octLength;
					row["DESCRIPTION"] = c.Description;

                    string type = (string)row["TYPE_NAME"];
                    row["TYPE_NAME_COMPLETE"] = this.GetDataTypeNameComplete(type, length, (short)width, (short)dec);

					if (c.Type == VistaDBType.Timestamp)
					{
						row["IS_COMPUTED"] = true;
					}

                    row["IS_CONCURRENCY"] = type == "Timestamp" ? true : false; 
				} 

			}
			finally
			{
				if(db != null) db.Close();
			}

			return metaData;
        }

        List<string> IPlugin.GetPrimaryKeyColumns(string database, string table)
        {
			List<string> primaryKeys = new List<string>();
			IVistaDBDatabase db = null;

			try
			{
                using (VistaDBConnection cn = new VistaDBConnection(context.ConnectionString))
                {
                    db = DDA.OpenDatabase(this.GetFullDatabaseName(), VistaDBDatabaseOpenMode.NonexclusiveReadOnly, GetPassword(cn));
                }

				IVistaDBTableSchema tblStructure = db.TableSchema(table);

				string[] pks = null;
				if(tblStructure.Indexes["PrimaryKey"] != null)
				{
					pks = tblStructure.Indexes["PrimaryKey"].KeyExpression.Split(';');
				}
				else
				{
					foreach(IVistaDBIndexInformation pk in tblStructure.Indexes)
					{
						if(pk.Primary)
						{
							pks = pk.KeyExpression.Split(';');
							break;
						}
					}
				}

				if(pks != null)
				{
					foreach(string pkColName in pks)
					{
						primaryKeys.Add(pkColName);
					}
				}
			}
			finally
			{
				if(db != null) db.Close();
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
			IVistaDBDatabase db = null;

			try
			{
				metaData = context.CreateIndexesDataTable();

                using (VistaDBConnection cn = new VistaDBConnection(context.ConnectionString))
                {
                    db = DDA.OpenDatabase(this.GetFullDatabaseName(), VistaDBDatabaseOpenMode.NonexclusiveReadOnly, GetPassword(cn));
                }

                IVistaDBTableNameCollection tables = db.GetTableNames();

				IVistaDBTableSchema tblStructure = db.TableSchema(table);

				foreach (IVistaDBIndexInformation indexInfo in tblStructure.Indexes) 
				{ 
					string[] pks = indexInfo.KeyExpression.Split(';');

					int index = 0;
					foreach(string colName in pks)
					{
						DataRow row = metaData.NewRow();
						metaData.Rows.Add(row);

						row["TABLE_CATALOG"] = GetDatabaseName();
						row["TABLE_NAME"] = tblStructure.Name;
						row["INDEX_CATALOG"] = GetDatabaseName();
						row["INDEX_NAME"] = indexInfo.Name;
						row["UNIQUE"] = indexInfo.Unique;
						row["COLLATION"] = indexInfo.KeyStructure[index++].Descending ? 2 : 1;
						row["COLUMN_NAME"] = colName;
					}
				} 
			}
			finally
			{
				if(db != null) db.Close();
			}

			return metaData;
        }

        DataTable IPlugin.GetForeignKeys(string database, string tableName)
        {
			DataTable metaData = new DataTable();
			IVistaDBDatabase db = null;

			try
			{
				metaData = context.CreateForeignKeysDataTable();

                using (VistaDBConnection cn = new VistaDBConnection(context.ConnectionString))
                {
                    db = DDA.OpenDatabase(this.GetFullDatabaseName(), VistaDBDatabaseOpenMode.NonexclusiveReadOnly, GetPassword(cn));
                }

                IVistaDBTableNameCollection tables = db.GetTableNames();

				foreach (string table in tables) 
				{
					IVistaDBTableSchema tblStructure = db.TableSchema(table);

                    //==================================================================
                    // This works around a change that was made to the VistaDB 4 provider
                    // It's ugly, we know
                    //==================================================================
                    IEnumerator enumerator = null;

                    if (useOldForeignKeyWay)
                    {
                        enumerator = tblStructure.ForeignKeys.GetEnumerator();
                    }
                    else
                    {
                        try
                        {
                            enumerator = tblStructure.ForeignKeys.Values.GetEnumerator();
                        }
                        catch
                        {
                            enumerator = tblStructure.ForeignKeys.GetEnumerator();
                            useOldForeignKeyWay = true;
                        }
                    }

                    // Okay, now that the version issues are over we just use the 'enumerator'
                    while(enumerator.MoveNext())
                    {
                        IVistaDBRelationshipInformation relInfo = enumerator.Current as IVistaDBRelationshipInformation;

						if(relInfo.ForeignTable != tableName && relInfo.PrimaryTable != tableName)
							continue;

						string fCols = relInfo.ForeignKey; 
						string pCols = String.Empty; 

						string primaryTbl  = relInfo.PrimaryTable; 
						string pkName = "";

						using (IVistaDBTableSchema pkTableStruct = db.TableSchema(primaryTbl)) 
						{ 
							foreach (IVistaDBIndexInformation idxInfo in pkTableStruct.Indexes) 
							{ 
								if (!idxInfo.Primary) 
								continue; 
								        
								pkName = idxInfo.Name;
								pCols = idxInfo.KeyExpression; 
								break; 
							} 
						} 

						string [] fColumns = fCols.Split(';'); 
						string [] pColumns = pCols.Split(';'); 

						for(int i = 0; i < fColumns.GetLength(0); i++)
						{
							DataRow row = metaData.NewRow();
							metaData.Rows.Add(row);

							row["PK_TABLE_CATALOG"] = GetDatabaseName();
							row["PK_TABLE_SCHEMA"]  = DBNull.Value;
							row["FK_TABLE_CATALOG"] = DBNull.Value;
							row["FK_TABLE_SCHEMA"]  = DBNull.Value;
							row["FK_TABLE_NAME"]    = tblStructure.Name;
							row["PK_TABLE_NAME"]    = relInfo.PrimaryTable;
							row["ORDINAL"]          = 0;
							row["FK_NAME"]          = relInfo.Name;
							row["PK_NAME"]          = pkName;
							row["PK_COLUMN_NAME"]   = pColumns[i]; 
							row["FK_COLUMN_NAME"]   = fColumns[i];

							row["UPDATE_RULE"]		= relInfo.UpdateIntegrity;
							row["DELETE_RULE"]		= relInfo.DeleteIntegrity;
						}
					} 
				}
			}
			finally
			{
				if(db != null) db.Close();
			}

			return metaData;
        }

        public object GetDatabaseSpecificMetaData(object myMetaObject, string key)
        {
            return null;
        }

		#endregion

		#region Internal Methods
		private IVistaDBDDA DDA = VistaDBEngine.Connections.OpenDDA();

        private bool IsIntialized 
		{ 
			get 
			{ 
				return (context != null); 
			} 
		}

		public string GetDatabaseName()
		{
			VistaDBConnection cn = new VistaDBConnection(this.context.ConnectionString);

			string dbName = cn.DataSource;
			int index = dbName.LastIndexOfAny(new char[]{'\\'});
			if (index >= 0)
			{
				dbName = dbName.Substring(index + 1);
			}
			return dbName;
		}

		public string GetFullDatabaseName()
		{
			VistaDBConnection cn = new VistaDBConnection(this.context.ConnectionString);
			return cn.DataSource;
		}

        private string GetDataTypeNameComplete(string dataType, int charMax, short precision, short scale)
        {
            switch (dataType)
            {
                case "Char":
                case "NChar":
                case "Text":
                case "NText":
                case "VarChar":
                case "NVarChar":
                case "varbinary":
                    return dataType + "(" + charMax + ")";

                case "Decimal":
                case "Money":
                case "SmallMoney":
                    return dataType + "(" + precision + "," + scale + ")";

                default:
                    return dataType;
            }
        }

        private string GetPassword(VistaDBConnection conn)
        {
            string password = null;

            if (conn.Password != null && conn.Password.Length > 0)
            {
                password = conn.Password;
            }

            return password;
        }

		#endregion
	}
}