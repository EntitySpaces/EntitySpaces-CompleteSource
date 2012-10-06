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
	public class PostgreSQLIndexes : Indexes
	{
		public PostgreSQLIndexes()
		{

		}

		override internal void LoadAll()
		{
			try
			{
				string select = @"SELECT current_database() as table_catalog, tab.relname AS table_name, " +
					"n.nspname as TABLE_NAMESPACE, cls.relname as INDEX_NAME, idx.indisunique as UNIQUE, " +
					"idx.indisclustered as CLUSTERED, a.amname as TYPE, indkey AS columns FROM pg_index idx " +
					"JOIN pg_class cls ON cls.oid=indexrelid " +
					"JOIN pg_class tab ON tab.oid=indrelid AND tab.relname = '" + this.Table.Name + "' " +
					"JOIN pg_namespace n ON n.oid=tab.relnamespace AND n.nspname = '" + this.Table.Schema + "' " +
					"JOIN pg_am a ON a.oid = cls.relam " +
					"LEFT JOIN pg_depend dep ON (dep.classid = cls.tableoid AND dep.objid = cls.oid AND dep.refobjsubid = '0') " +
					"LEFT OUTER JOIN pg_constraint con ON (con.tableoid = dep.refclassid AND con.oid = dep.refobjid) " +
					"WHERE con.conname IS NULL ORDER BY cls.relname;";

                IDbConnection cn = ConnectionHelper.CreateConnection(this.dbRoot, this.Table.Tables.Database.Name);

                DbDataAdapter adapter = PostgreSQLDatabases.CreateAdapter(select, cn);
				DataTable metaData = new DataTable();

				adapter.Fill(metaData);
				cn.Close();
		
				PopulateArrayNoHookup(metaData);

				for(int i = 0; i < this.Count; i++)
				{
					Index index = this[i] as Index;

					if(null != index)
					{
						string s = index._row["columns"] as string;
						string[] colIndexes = s.Split(' ');

						foreach(string colIndex in colIndexes)
						{
							if(colIndex != "0")
							{
								int id = Convert.ToInt32(colIndex);

								Column column  = this.Table.Columns[id-1] as Column;
								index.AddColumn(column.Name);
							}
						}
					}
				}
			}
			catch {}
		}
	}
}
