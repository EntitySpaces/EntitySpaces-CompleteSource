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
using System.Data.Odbc;
using System.Data.OleDb;

namespace EntitySpaces.MetadataEngine.Access
{
	public class AccessColumns : Columns
	{
		public AccessColumns()
		{

		}

		internal DataColumn f_TypeName = null;

		override internal void LoadForTable()
		{
			DataTable metaData = this.LoadData(OleDbSchemaGuid.Columns, new Object[] {null, null, this.Table.Name});

			metaData.DefaultView.Sort = "ORDINAL_POSITION";

			PopulateArray(metaData);

			LoadExtraDataForTable();
		}

		override internal void LoadForView()
		{
			DataTable metaData = this.LoadData(OleDbSchemaGuid.Columns, new Object[] {null, null, this.View.Name});

			metaData.DefaultView.Sort = "ORDINAL_POSITION";

			PopulateArray(metaData);

			LoadExtraDataForView();
		}

		private void LoadExtraDataForTable()
		{
			try
			{
				if(this._array.Count > 0)
				{
					ADODB.Connection cnn = new ADODB.Connection();
					ADOX.Catalog cat = new ADOX.Catalog();
    
					// Open the Connection
					cnn.Open(dbRoot.ConnectionString, null, null, 0);
					cat.ActiveConnection = cnn;

					ADOX.Columns cols = null;
					cols = cat.Tables[this.Table.Name].Columns;

					Column col = this._array[0] as Column;

					f_TypeName = new DataColumn("TYPE_NAME", typeof(string));
					col._row.Table.Columns.Add(f_TypeName);

					f_IsAutoKey  = new DataColumn("AUTO_INCREMENT", typeof(Boolean));
					col._row.Table.Columns.Add(f_IsAutoKey);

					f_AutoKeySeed = new DataColumn("AUTO_KEY_SEED", typeof(System.Int32));
					col._row.Table.Columns.Add(f_AutoKeySeed);

					f_AutoKeyIncrement	= new DataColumn("AUTO_KEY_INCREMENT", typeof(System.Int32));
					col._row.Table.Columns.Add(f_AutoKeyIncrement);

					int count = this._array.Count;
					Column c = null;
					ADOX.Column cx = null;

					for( int index = 0; index < count; index++)
					{
						cx = cols[index];
						c  = (Column)this[cx.Name];

						string hyperlink = "False";

						try
						{
							hyperlink = cx.Properties["Jet OLEDB:Hyperlink"].Value.ToString();
						} 
						catch {}

						string name = cx.Name;

						Console.WriteLine("-----------------------------------------");
						foreach(ADOX.Property prop in cx.Properties)
						{
							Console.WriteLine(prop.Attributes.ToString());
							Console.WriteLine(prop.Name);
							if(null != prop.Value)
								Console.WriteLine(prop.Value.ToString());
						}

						c._row["TYPE_NAME"]      = hyperlink == "False" ? cx.Type.ToString() : "Hyperlink";

						try
						{
							if(c.Default == "GenGUID()")
							{
								c._row["AUTO_INCREMENT"] = Convert.ToBoolean(cx.Properties["Jet OLEDB:AutoGenerate"].Value);
							}
							else
							{
								c._row["AUTO_INCREMENT"] = Convert.ToBoolean(cx.Properties["Autoincrement"].Value);
								c._row["AUTO_KEY_SEED"]  = Convert.ToInt32(cx.Properties["Seed"].Value);
								c._row["AUTO_KEY_INCREMENT"]  = Convert.ToInt32(cx.Properties["Increment"].Value);
							}
						}
						catch {}
					}

					cnn.Close();
				}
			}
			catch {}
		}

		private void LoadExtraDataForView()
		{
			try
			{
				if(this._array.Count > 0)
				{
					ADODB.Connection cnn = new ADODB.Connection();
					ADODB.Recordset rs = new ADODB.Recordset();
					ADOX.Catalog cat = new ADOX.Catalog();
    
					// Open the Connection
					cnn.Open(dbRoot.ConnectionString, null, null, 0);
					cat.ActiveConnection = cnn;

					rs.Source = cat.Views[this.View.Name].Command;
					rs.Fields.Refresh();
					ADODB.Fields flds = rs.Fields;

					Column col = this._array[0] as Column;

					f_TypeName = new DataColumn("TYPE_NAME", typeof(string));
					col._row.Table.Columns.Add(f_TypeName);

					f_IsAutoKey  = new DataColumn("AUTO_INCREMENT", typeof(Boolean));
                    col._row.Table.Columns.Add(f_IsAutoKey);

					Column c = null;
					ADODB.Field fld = null;

					int count = this._array.Count;
					for( int index = 0; index < count; index++)
					{
						fld = flds[index];
						c   = (Column)this[fld.Name];

						c._row["TYPE_NAME"]      = fld.Type.ToString();
						c._row["AUTO_INCREMENT"] = false;
					}

					rs.Close();
					cnn.Close();
				}
			}
			catch {}
		}
	}
}
