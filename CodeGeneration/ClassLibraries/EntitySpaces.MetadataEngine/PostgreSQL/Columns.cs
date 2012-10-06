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
	public class PostgreSQLColumns : Columns
	{
		public PostgreSQLColumns()
		{

		}

		internal DataColumn f_TypeName = null;
		internal DataColumn f_TypeNameComplete	= null;

		override internal void LoadForTable()
		{
			IDbConnection cn = null;

			try
			{
				string query = 	"select * from information_schema.columns where table_catalog = '" + 
					this.Table.Database.Name + "' and table_schema = '" + this.Table.Schema + 
					"' and table_name = '" + this.Table.Name + "' order by ordinal_position";

				cn = ConnectionHelper.CreateConnection(this.dbRoot, this.Table.Database.Name);

				DataTable metaData = new DataTable();
                DbDataAdapter adapter = PostgreSQLDatabases.CreateAdapter(query, cn);

				adapter.Fill(metaData);

				metaData.Columns["udt_name"].ColumnName  = "TYPE_NAME";
				metaData.Columns["data_type"].ColumnName = "TYPE_NAMECOMPLETE";

				if(metaData.Columns.Contains("TYPE_NAME"))
					f_TypeName = metaData.Columns["TYPE_NAME"];

				if(metaData.Columns.Contains("TYPE_NAMECOMPLETE"))
					f_TypeNameComplete = metaData.Columns["TYPE_NAMECOMPLETE"];
		
				PopulateArray(metaData);

				// IsAutoKey logic
				query = @"SELECT a.attname AS column_name, substring(pg_get_expr(ad.adbin, c.oid) " +
					@"FROM '[\'""]+(.+?)[\'""]+') AS seq_name " +
					"FROM pg_class c, pg_namespace n, pg_attribute a, pg_attrdef ad " +
					"WHERE n.nspname = '" + this.Table.Schema + "' AND c.relname = '" + this.Table.Name + "' " +
					"AND c.relnamespace = n.oid " +
					"AND a.attrelid = c.oid  AND a.atthasdef = true " +
					"AND ad.adrelid = c.oid AND ad.adnum = a.attnum " +
					@"AND pg_get_expr(ad.adbin, c.oid) LIKE 'nextval(%'";

				DataTable seqData = new DataTable();
                adapter = PostgreSQLDatabases.CreateAdapter(query, cn);
				adapter.Fill(seqData);

				DataRowCollection rows = seqData.Rows;

				if(rows.Count > 0)
				{
					string colName;

					for(int i = 0; i < rows.Count; i++)
					{
						colName = rows[i]["column_name"] as string;

						PostgreSQLColumn col = this[colName] as PostgreSQLColumn;
						col._isAutoKey = true;

//                      col.AutoKeyText = col.Default.Replace("nextval", "currval").Replace("\"", "\"\"");

						query = "SELECT min_value, increment_by FROM \"" + rows[i]["seq_name"] + "\"";
                        adapter = PostgreSQLDatabases.CreateAdapter(query, cn);
						DataTable autokeyData = new DataTable();
						adapter.Fill(autokeyData);

						Int64 a;
						
						a = (Int64)autokeyData.Rows[0]["min_value"];
						col._autoInc  = Convert.ToInt32(a);

						a = (Int64)autokeyData.Rows[0]["increment_by"];
						col._autoSeed  = Convert.ToInt32(a);
					}
				}

				cn.Close();
			}
			catch
			{
				if(cn != null)
				{
					if(cn.State == ConnectionState.Open)
					{
						cn.Close();
					}
				}
			}
		}

		override internal void LoadForView()
		{
			try
			{
				string query = 	"select * from information_schema.columns where table_catalog = '" + 
					this.View.Database.Name + "' and table_schema = '" + this.View.Schema + 
					"' and table_name = '" + this.View.Name + "' order by ordinal_position";

				IDbConnection cn = ConnectionHelper.CreateConnection(this.dbRoot, this.View.Database.Name);

				DataTable metaData = new DataTable();
                DbDataAdapter adapter = PostgreSQLDatabases.CreateAdapter(query, cn);

				adapter.Fill(metaData);
				cn.Close();

				metaData.Columns["udt_name"].ColumnName  = "TYPE_NAME";
				metaData.Columns["data_type"].ColumnName = "TYPE_NAMECOMPLETE";

				if(metaData.Columns.Contains("TYPE_NAME"))
					f_TypeName = metaData.Columns["TYPE_NAME"];

				if(metaData.Columns.Contains("TYPE_NAMECOMPLETE"))
					f_TypeNameComplete = metaData.Columns["TYPE_NAMECOMPLETE"];
		
				PopulateArray(metaData);
			}
			catch {}
		}
	}
}
