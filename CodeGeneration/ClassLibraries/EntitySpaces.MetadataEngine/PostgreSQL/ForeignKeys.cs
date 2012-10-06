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
using System.Data;
using System.Data.Common;

namespace EntitySpaces.MetadataEngine.PostgreSQL
{
	public class PostgreSQLForeignKeys : ForeignKeys
	{
		static string _query = 
				"SELECT pfk.relname || '.' || ct.conname as FK_NAME, pn.nspname as PK_TABLE_SCHEMA, pfk.relname as PK_TABLE_NAME, " +
                "CAST(ct.confkey as character varying) as PK_COLS, fn.nspname as FK_TABLE_SCHEMA, ffk.relname as FK_TABLE_NAME, CAST(ct.conkey as character varying) as FK_COLS, d.DESCRIPTION, " +
				"CAST(CASE ct.confupdtype WHEN 'c' THEN 'CASCADE' " +
										 "WHEN 'n' THEN 'SET NULL' " +
										 "WHEN 'd' THEN 'SET DEFAULT' " +
										 "WHEN 'r' THEN 'RESTRICT' " +
										 "WHEN 'a' THEN 'NO ACTION' END " +
					"AS character varying) AS update_rule,  " +
				"CAST(CASE ct.confdeltype WHEN 'c' THEN 'CASCADE' " +
										 "WHEN 'n' THEN 'SET NULL' " +
										 "WHEN 'd' THEN 'SET DEFAULT' " +
										 "WHEN 'r' THEN 'RESTRICT' " +
										 "WHEN 'a' THEN 'NO ACTION' END " +
					"AS character varying) AS delete_rule " +
				"FROM pg_constraint ct " +
				"JOIN pg_class pfk on pfk.oid = confrelid " +
				"JOIN pg_class ffk on ffk.oid = ct.conrelid " +
				"JOIN pg_namespace pn ON pn.oid = pfk.relnamespace  " +
				"JOIN pg_namespace fn ON fn.oid = ffk.relnamespace  " +
				"LEFT OUTER JOIN pg_description d ON d.objoid = ct.oid " +
				"WHERE contype='f'";


		public PostgreSQLForeignKeys()
		{

		}

		override internal void LoadAll()
		{
			string query1 = _query +
				"AND pn.nspname = '" + this.Table.Schema + "' AND pfk.relname = '" + this.Table.Name + "' ORDER BY ct.conname";

			string query2 = _query +
				"AND fn.nspname = '" + this.Table.Schema + "' AND ffk.relname = '" + this.Table.Name + "' ORDER BY ct.conname";

			this._LoadAll(query1, query2);
		}

		private void _LoadAll(string query1, string query2)
		{
			IDbConnection cn = null;

            try
            {
                cn = ConnectionHelper.CreateConnection(this.dbRoot, this.Table.Database.Name);

                DataTable metaData1 = new DataTable();
                DataTable metaData2 = new DataTable();

                DbDataAdapter adapter = PostgreSQLDatabases.CreateAdapter(query1, cn);
                adapter.Fill(metaData1);

                adapter = PostgreSQLDatabases.CreateAdapter(query2, cn);
                adapter.Fill(metaData2);

                DataRowCollection rows = metaData2.Rows;
                int count = rows.Count;
                for (int i = 0; i < count; i++)
                {
                    metaData1.ImportRow(rows[i]);
                }

                PopulateArrayNoHookup(metaData1);

                if (metaData1.Rows.Count > 0)
                {
                    string catalog = this.Table.Database.Name;
                    string schema;
                    string table;
                    string[] cols = null;
                    string q;

                    string query =
                        "SELECT  c.conname AS constraint_name, " +
                             "t.relname AS table_name, " +
                             "array_to_string(c.conkey, ' ') AS constraint_key, " +
                             "t2.relname AS references_table, " +
                             "array_to_string(c.confkey, ' ') AS fk_constraint_key " +
                        "FROM pg_constraint c " +
                        "LEFT JOIN pg_class t  ON c.conrelid  = t.oid " +
                        "LEFT JOIN pg_class t2 ON c.confrelid = t2.oid " +
                        "WHERE c.contype = 'f' and c.conname = ";

                    foreach (ForeignKey key in this)
                    {
                        //------------------------------------------------
                        // Primary
                        //------------------------------------------------
                        schema = key._row["PK_TABLE_SCHEMA"] as string;
                        table  = key._row["PK_TABLE_NAME"] as string;

                        string keyName = string.Empty;

                        try
                        {
                            keyName = key.Name.Split('.')[1];
                        }
                        catch
                        {
                            keyName = key.Name;
                        }

                        q = query;
                        q += "'" + keyName + "'";

                        DataTable metaData = new DataTable();
                        adapter = PostgreSQLDatabases.CreateAdapter(q, cn);

                        adapter.Fill(metaData);

                        string[] ordinals = ((string)metaData.Rows[0][4]).Split(' ');

                        foreach (string ordinal in ordinals)
                        {
                            int c = key.PrimaryTable.Columns.Count;
                            string colName = key.PrimaryTable.Columns[Convert.ToInt32(ordinal) - 1].Name;
                            key.AddForeignColumn(catalog, "", table, colName, true);
                        }

                        //for (int i = 0; i < cols.GetLength(0); i++)
                        //{
                        //    key.AddForeignColumn(catalog, "", table, metaData.Rows[i]["COLUMN"] as string, true);
                        //}

                        //------------------------------------------------
                        // Foreign
                        //------------------------------------------------
                        schema = key._row["FK_TABLE_SCHEMA"] as string;
                        table  = key._row["FK_TABLE_NAME"] as string;

                        ordinals = ((string)metaData.Rows[0][2]).Split(' ');

                        foreach (string ordinal in ordinals)
                        {
                            int c = key.ForeignTable.Columns.Count;
                            string colName = key.ForeignTable.Columns[Convert.ToInt32(ordinal) - 1].Name;
                            key.AddForeignColumn(catalog, "", table, colName, false);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }

			cn.Close();
		}

		private string[] ParseColumns(string cols)
		{
			cols = cols.Replace("{", "");
			cols = cols.Replace("}", "");
			return cols.Split(',');
		}
	}
}
