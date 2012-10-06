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
using System.Collections;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlColumns : Columns
	{
		public MySqlColumns()
		{

		}

		override internal void LoadForTable()
		{
			string query = @"SHOW COLUMNS FROM `" + this.Table.Name + "`";

			DataTable metaData = new DataTable();
			DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, this.dbRoot.ConnectionString);

			adapter.Fill(metaData);

			metaData.Columns["Field"].ColumnName   = "COLUMN_NAME";
			metaData.Columns["Type"].ColumnName    = "DATA_TYPE";
			metaData.Columns["Null"].ColumnName    = "IS_NULLABLE";
			metaData.Columns["Default"].ColumnName = "COLUMN_DEFAULT";

            if (metaData.Columns.Contains("Extra"))
            {
                if (!metaData.Columns.Contains("IS_AUTO_KEY"))
                {
                    f_IsAutoKey = metaData.Columns.Add("IS_AUTO_KEY", typeof(bool));
                }

                foreach (DataRow row in metaData.Rows)
                {
                    string extra = (string)row["extra"];

                    if (extra != null && extra.Contains("autoincrement"))
                    {
                        row["IS_AUTO_KEY"] = true;
                    }
                    else
                    {
                        row["IS_AUTO_KEY"] = false;
                    }
                }
            }
			
			PopulateArray(metaData);

			LoadTableColumnDescriptions();
		}

		override internal void LoadForView()
		{
			MySqlDatabase db   = this.View.Database as MySqlDatabase;
			MySqlDatabases dbs = db.Databases as MySqlDatabases;
			if(dbs.Version.StartsWith("5"))
			{
				string query = @"SHOW COLUMNS FROM `" + this.View.Name + "`";

				DataTable metaData = new DataTable();
				DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, this.dbRoot.ConnectionString);

				adapter.Fill(metaData);

				metaData.Columns["Field"].ColumnName   = "COLUMN_NAME";
				metaData.Columns["Type"].ColumnName    = "DATA_TYPE";
				metaData.Columns["Null"].ColumnName    = "IS_NULLABLE";
				metaData.Columns["Default"].ColumnName = "COLUMN_DEFAULT";

                if (metaData.Columns.Contains("IS_AUTO_KEY")) f_IsAutoKey = metaData.Columns["IS_AUTO_KEY"];
			
				PopulateArray(metaData);
			}
		}

		private void LoadTableColumnDescriptions()
		{
			try
			{
				string query = @"SELECT TABLE_NAME, COLUMN_NAME, COLUMN_COMMENT FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = '" + 
					this.Table.Database.Name + "' AND TABLE_NAME ='" + this.Table.Name + "'";

				DataTable metaData = new DataTable();
				DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, this.dbRoot.ConnectionString);

				adapter.Fill(metaData);

				if(metaData.Rows.Count > 0)
				{
					foreach(DataRow row in metaData.Rows)
					{
						Column c = this[row["COLUMN_NAME"] as string] as Column;

						if(!c._row.Table.Columns.Contains("DESCRIPTION"))
						{
							c._row.Table.Columns.Add("DESCRIPTION", Type.GetType("System.String"));
							this.f_Description = c._row.Table.Columns["DESCRIPTION"];
						}

                        c._row["DESCRIPTION"] = row["COLUMN_COMMENT"] as string;

                        // We now set the AutoKey flag here ...
                        string extra = (string)c._row["Extra"];

                        if(extra != null && extra.Length > 0)
                        {
                            if (-1 != extra.IndexOf("auto_increment"))
                            {
                                c._row["IS_AUTO_KEY"] = true;
                            }
                        }
					}
				}
			}
			catch {}
		}
	}
}
