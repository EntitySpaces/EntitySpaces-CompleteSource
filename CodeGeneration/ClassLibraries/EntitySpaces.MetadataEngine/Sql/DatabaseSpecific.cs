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
using System.Collections;

using ADODB;

namespace EntitySpaces.MetadataEngine.Sql
{
	/// <summary>
	/// Summary description for DatabaseSpecific.
	/// </summary>
	public class DatabaseSpecific
	{
		public const string EXTENDED_PROPERTIES = "ExtendedProperties";
		private const string QUERY = @"SELECT [name], [value] FROM ::fn_listextendedproperty (NULL, 'user', {0}, {1}, {2}, {3}, {4})";
	
		public DatabaseSpecific() {}
	
		public KeyValueCollection ExtendedProperties(IColumn column) 
		{
            if (column.Table != null)
            {
                return ExtendedProperties(column.Table.Database, column.Table.Schema, "table", column.Table.Name, column.Name);
            }
            else
            {
                return ExtendedProperties(column.View.Database, column.View.Schema, "view", column.View.Name, column.Name);
            }
		}
	
		public KeyValueCollection ExtendedProperties(ITable table) 
		{
			return ExtendedProperties(table.Database, table.Schema, "table", table.Name, null);
		}
	
		public KeyValueCollection ExtendedProperties(IProcedure proc) 
		{
			return ExtendedProperties(proc.Database, proc.Schema, "procedure", proc.Name, null);
		}
	
		public KeyValueCollection ExtendedProperties(IView view) 
		{
			return ExtendedProperties(view.Database, view.Schema, "view", view.Name, null);
		}
	
		private KeyValueCollection ExtendedProperties(IDatabase db, string schema, string entitytype, string entity, string column) 
		{
			KeyValueCollection hash = new KeyValueCollection();
			Recordset rs = db.ExecuteSql(
				String.Format(QUERY, 
				"'" + schema + "'",
				"'" + entitytype + "'",
				"'" + entity + "'", 
				((column == null) ? "null" : "'column'"), 
				((column == null) ? "null" : "'" + column + "'")
				)
				);
			
			if (rs != null) 
			{
				rs.MoveFirst();

				while (!rs.EOF && !rs.BOF)
				{
					hash.AddKeyValue( rs.Fields["name"].Value.ToString(), rs.Fields["value"].Value.ToString());
					rs.MoveNext();
				}
				rs.Close();
				rs = null;
			}
			return hash;
		}
	}
}
