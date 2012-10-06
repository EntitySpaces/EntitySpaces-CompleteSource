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
	public class OracleTables : Tables
	{
		public OracleTables()
		{

		}

		override internal void LoadAll()
		{
			try
			{
				string type = this.dbRoot.ShowSystemData ? "SYSTEM TABLE" : "TABLE";
				DataTable metaData = this.LoadData(OleDbSchemaGuid.Tables, new Object[] {null, this.Database.Name, null, null, type});

				// Oracle returns VIEWS in Addition to when you ask for TABLES, however, if you just ask for VIEWS that works fine
				metaData.DefaultView.RowFilter = "TABLE_TYPE = '" + type + "'";

				base.PopulateArray(metaData);

				LoadExtraData(this.Database.SchemaName);
			}
			catch {}
		}

		private void LoadExtraData(string schema)
		{
			try
			{
				string select = "SELECT DISTINCT C.TABLE_NAME, C.COMMENTS AS DESCRIPTION FROM SYS.ALL_TAB_COMMENTS C, SYS.ALL_TABLES T " +
					"WHERE T.OWNER = '" + schema + "' AND T.OWNER = C.OWNER	AND T.TABLE_NAME = C.TABLE_NAME	AND C.COMMENTS IS NOT NULL";

				OleDbDataAdapter adapter = new OleDbDataAdapter(select, this.dbRoot.ConnectionString);
				DataTable dataTable = new DataTable();

				adapter.Fill(dataTable);

				DataRowCollection rows = dataTable.Rows;

				if(rows.Count > 0)
				{
					Table t;
					foreach(DataRow row in rows)
					{
						t = this[row["TABLE_NAME"]] as Table;
						t._row["DESCRIPTION"] = row["DESCRIPTION"];
					}
				}
			}
			catch {}
		}
	}
}
