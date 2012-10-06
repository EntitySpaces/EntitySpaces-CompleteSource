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

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlTables : Tables
	{
		public MySqlTables()
		{

		}

		override internal void LoadAll()
		{
			try
			{
				MySqlDatabases db = this.Database.Databases as MySqlDatabases;

				string query = "SHOW TABLES";
				if(db.Version.StartsWith("5"))
				{
					query = @"SHOW FULL TABLES WHERE Table_type = 'BASE TABLE'";
				}

				DataTable metaData = new DataTable();
				DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, this.dbRoot.ConnectionString);

				adapter.Fill(metaData);

				metaData.Columns[0].ColumnName = "TABLE_NAME";

				PopulateArray(metaData);

				if(db.Version.StartsWith("5"))
				{
					LoadTableDescriptions();
				}
			}
			catch {	}
		}

		private void LoadTableDescriptions()
		{
			try
			{
				//string query = @"SELECT TABLE_NAME, TABLE_COMMENT, CREATE_TIME, UPDATE_TIME FROM information_schema.TABLES WHERE TABLE_SCHEMA = '" + this.Database.Name + "'";
                string query = @"SELECT TABLE_NAME, TABLE_COMMENT, CREATE_TIME, UPDATE_TIME FROM information_schema.TABLES WHERE TABLE_SCHEMA = '" + this.Database.Name + "' AND Table_type = 'BASE TABLE'";

				DataTable metaData = new DataTable();
				DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, this.dbRoot.ConnectionString);

				adapter.Fill(metaData);

				if(this.Database.Tables.Count > 0)
				{
					Table t = this.Database.Tables[0] as Table;

					if(!t._row.Table.Columns.Contains("DESCRIPTION"))
					{
						t._row.Table.Columns.Add("DESCRIPTION", Type.GetType("System.String"));
						this.f_Description = t._row.Table.Columns["DESCRIPTION"];
					}

					if(!t._row.Table.Columns.Contains("TABLE_SCHEMA"))
					{
						t._row.Table.Columns.Add("TABLE_SCHEMA", Type.GetType("System.String"));
						this.f_Schema = t._row.Table.Columns["TABLE_SCHEMA"];
					}

					if(!t._row.Table.Columns.Contains("DATE_CREATED"))
					{
						t._row.Table.Columns.Add("DATE_CREATED", Type.GetType("System.DateTime"));
						this.f_DateCreated = t._row.Table.Columns["DATE_CREATED"];
					}

					if(!t._row.Table.Columns.Contains("DATE_MODIFIED"))
					{
						t._row.Table.Columns.Add("DATE_MODIFIED", Type.GetType("System.DateTime"));
						this.f_DateModified = t._row.Table.Columns["DATE_MODIFIED"];
					}
				}

				if(metaData.Rows.Count > 0)
				{
					foreach(DataRow row in metaData.Rows)
					{
						Table t = this[row["TABLE_NAME"] as string] as Table;

						t._row["DESCRIPTION"] = row["TABLE_COMMENT"] as string;
						//t._row["TABLE_SCHEMA"] = this.Database.Name;

						if(row["CREATE_TIME"] != DBNull.Value)
						{
							t._row["DATE_CREATED"] = (DateTime)row["CREATE_TIME"];
						}

						if(row["UPDATE_TIME"] != DBNull.Value)
						{
							t._row["DATE_MODIFIED"] = (DateTime)row["UPDATE_TIME"];
						}
					}
				}
			}
			catch {}
		}
	}
}
