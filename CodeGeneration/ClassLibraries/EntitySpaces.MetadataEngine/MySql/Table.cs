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
	public class MySqlTable : Table
	{
		public MySqlTable()
		{

		}

		public override IColumns PrimaryKeys
		{
			get
			{
				if(null == _primaryKeys)
				{
					_primaryKeys = (Columns)this.dbRoot.ClassFactory.CreateColumns();
					_primaryKeys.Table = this;
					_primaryKeys.dbRoot = this.dbRoot;

					string query = @"SHOW INDEX FROM `" + this.Name + "`";

					DataTable metaData = new DataTable();
					DbDataAdapter adapter = MySqlDatabases.CreateAdapter(query, this.dbRoot.ConnectionString);

					adapter.Fill(metaData);

					DataRowCollection rows = metaData.Rows;

					string s = "";
					for(int i = 0; i < rows.Count; i++)
					{
						s = rows[i]["Key_Name"] as string;

						if(s == "PRIMARY")
						{
							s = metaData.Rows[i]["Column_name"] as string;
							_primaryKeys.AddColumn((Column)this.Columns[s]);
						}
					}
				}

				return _primaryKeys;
			}
		}

//		public override IColumns PrimaryKeys
//		{
//			get
//			{
//				if(null == _primaryKeys)
//				{
//					OleDbConnection cn = new OleDbConnection(this.dbRoot.ConnectionString); 
//					cn.Open(); 
//					DataTable metaData = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, 
//						new Object[] {null, this.Tables.Database.Name, this.Name});
//					cn.Close();
//
//					_primaryKeys = (Columns)this.dbRoot.ClassFactory.CreateColumns();
//
//					Columns cols = (Columns)this.Columns;
//
//					string colName = "";
//
//					int count = metaData.Rows.Count;
//					for(int i = 0; i < count; i++)
//					{
//						colName = metaData.Rows[i]["COLUMN_NAME"] as string;
//						_primaryKeys.AddColumn((Column)cols[colName]);
//					}
//				}
//
//				return _primaryKeys;
//			}
//		}
	}
}

