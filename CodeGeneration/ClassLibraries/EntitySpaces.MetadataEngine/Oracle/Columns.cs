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
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine.Oracle
{
	public class OracleColumns : Columns
	{
		public OracleColumns()
		{

		}

		internal DataColumn f_TypeName	= null;
//		internal DataColumn f_AutoKey	= null;

		internal override void LoadForTable()
		{
			DataTable metaData = this.LoadData(OleDbSchemaGuid.Columns, new Object[] {null, this.Table.Database.Name, this.Table.Name});

			PopulateArray(metaData);

			LoadExtraData(this.Table.Name, this.Table.Database.Name);
		}

		internal override void LoadForView()
		{
			DataTable metaData = this.LoadData(OleDbSchemaGuid.Columns, new Object[] {null, this.View.Database.Name, this.View.Name});

			PopulateArray(metaData);

			LoadExtraData(this.View.Name, this.View.Database.Name);
		}

		private void LoadExtraData(string name, string schema)
		{
			try
			{
				string select = "SELECT DATA_TYPE as TYPE_NAME, DATA_DEFAULT AS COLUMN_DEFAULT FROM ALL_TAB_COLUMNS " + 
					"WHERE TABLE_NAME = '" + name + "' AND OWNER = '" + schema + "' ORDER BY COLUMN_ID";

				OleDbDataAdapter adapter = new OleDbDataAdapter(select, this.dbRoot.ConnectionString);
				DataTable dataTable = new DataTable();

				adapter.Fill(dataTable);

				if(this._array.Count > 0)
				{
					Column col = this._array[0] as Column;

					f_TypeName = new DataColumn("TYPE_NAME", typeof(string));
					col._row.Table.Columns.Add(f_TypeName);

					string typeName = "";
					DataRowCollection rows = dataTable.Rows;

					int index = 0;

					foreach(Column c in this)
					{
						typeName = rows[index]["TYPE_NAME"] as string;

						if(typeName.StartsWith("TIMESTAMP") || typeName.StartsWith("INTERVAL"))
						{
							string tmp = "";
							foreach(char ch in typeName)
							{
								switch(ch)
								{
									case '0':
									case '1':
									case '2':
									case '3':
									case '4':
									case '5':
									case '6':
									case '7':
									case '8':
									case '9':
									case '(':
									case ')':
										break;

									default:
										tmp += ch;
										break;
								}
							}

							typeName = tmp.Replace("  ", "").Trim();
						}

						c._row["TYPE_NAME"] = typeName;
						c._row["COLUMN_DEFAULT"] = rows[index]["COLUMN_DEFAULT"];

						index++;
					}
				}
			}
			catch {}

			try
			{
				string select = "SELECT  DISTINCT C.COLUMN_NAME, C.COMMENTS AS DESCRIPTION FROM SYS.ALL_COL_COMMENTS C, SYS.ALL_TAB_COLUMNS T " +
					"WHERE T.TABLE_NAME = '" + name + "' AND T.OWNER = '" + schema + "' AND T.OWNER = C.OWNER AND T.TABLE_NAME = C.TABLE_NAME " +
					"AND T.COLUMN_NAME = C.COLUMN_NAME AND C.COMMENTS IS NOT NULL";

				OleDbDataAdapter adapter = new OleDbDataAdapter(select, this.dbRoot.ConnectionString);
				DataTable dataTable = new DataTable();

				adapter.Fill(dataTable);

				DataRowCollection rows = dataTable.Rows;

				if(rows.Count > 0)
				{
					Column c;
					foreach(DataRow row in rows)
					{
						c = this[row["COLUMN_NAME"]] as Column;
						c._row["DESCRIPTION"] = row["DESCRIPTION"];
					}
				}
			}
			catch {}
		}
	}
}
