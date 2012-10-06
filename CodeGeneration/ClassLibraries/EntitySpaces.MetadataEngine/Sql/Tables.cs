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

namespace EntitySpaces.MetadataEngine.Sql
{
	public class SqlTables : Tables
	{
		public SqlTables()
		{

		}

		override internal void LoadAll()
		{
			try
			{
				string type = this.dbRoot.ShowSystemData ? "SYSTEM TABLE" : "TABLE";
				DataTable metaData = this.LoadData(OleDbSchemaGuid.Tables, new Object[] {this.Database.Name, null, null, type});

                foreach(DataRow row in metaData.Rows)
                {
                    object o = row["TABLE_NAME"];
                    if (o != null)
                    {
                        string name = (string)o;

                        if (name.ToLower() == "sysdiagrams")
                        {
                            row.Delete();
                            break;
                        }
                    }
                }

				PopulateArray(metaData);

				LoadDescriptions();
			}
			catch {}
		}

		private void LoadDescriptions()
		{
			try
			{
				string select = @"SELECT objName, value FROM ::fn_listextendedproperty ('MS_Description', 'user', 'dbo', 'table', null, null, null)";

                DataTable dataTable = new DataTable();
                using (OleDbConnection cn = new OleDbConnection(dbRoot.ConnectionString))
                {
                    cn.Open();
                    cn.ChangeDatabase("[" + this.Database.Name + "]");

                    OleDbDataAdapter adapter = new OleDbDataAdapter(select, cn);
                    adapter.Fill(dataTable);
                }

				Table t;

				foreach(DataRow row in dataTable.Rows)
				{
					t = this[row["objName"] as string] as Table;

					if(null != t)
					{
						t._row["DESCRIPTION"] = row["value"] as string;
					}
				}
			}
			catch
			{
			
			}
		}
	}
}
