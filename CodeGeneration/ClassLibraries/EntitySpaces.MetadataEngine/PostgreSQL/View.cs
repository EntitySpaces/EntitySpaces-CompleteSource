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

namespace EntitySpaces.MetadataEngine.PostgreSQL
{
	public class PostgreSQLView : View
	{
		public PostgreSQLView()
		{

		}

		override public IViews SubViews 
		{ 
			get
			{
				if(!_subViewInfoLoaded)
				{
					LoadSubViewInfo();
				}
				return _views;				
			}
		}

		override public ITables SubTables
		{ 
			get
			{
				if(!_subViewInfoLoaded)
				{
					LoadSubViewInfo();
				}
				return _tables;
			}
		}

		private void LoadSubViewInfo()
		{
			_views  = (Views)this.dbRoot.ClassFactory.CreateViews();
			_tables = (Tables)this.dbRoot.ClassFactory.CreateTables();

			try
			{
				string select = "SELECT * FROM INFORMATION_SCHEMA.VIEW_TABLE_USAGE WHERE VIEW_NAME = '" 
					+ this.Name + "' AND VIEW_SCHEMA = '" + this.Schema + "';";
	
				OleDbConnection cn = new OleDbConnection(dbRoot.ConnectionString);
				cn.Open();
				cn.ChangeDatabase(this.Database.Name);

				OleDbDataAdapter adapter = new OleDbDataAdapter(select, cn);
				DataTable dataTable = new DataTable();

				adapter.Fill(dataTable);

				cn.Close();

				string entity = "";

				Table table;
				View view;

				foreach(DataRow row in dataTable.Rows)
				{
					entity = row["TABLE_NAME"] as string;

					// It might be a table or a view
					table = this.Database.Tables[entity] as Table;

					if(null != table)
					{
						// It's a table
						_tables.AddTable(table);
					}
					else
					{
						// Check for View
						view = this.Database.Views[entity] as View;

						if(null != view)
						{
							// It's a table
							_views.AddView(view);
						}
					}
				}
			}
			catch {}
		}
	}
}
