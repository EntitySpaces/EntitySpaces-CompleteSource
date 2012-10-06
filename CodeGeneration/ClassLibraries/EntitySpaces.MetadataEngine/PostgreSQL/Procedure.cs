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
	public class PostgreSQLProcedure : Procedure
	{
		internal string _specific_name = "";

		public PostgreSQLProcedure()
		{

		}

		public override IParameters Parameters
		{
			get
			{
				if(null == _parameters)
				{
					_parameters = (PostgreSQLParameters)this.dbRoot.ClassFactory.CreateParameters();
					_parameters.Procedure = this;
					_parameters.dbRoot = this.dbRoot;

					string query = "select * from information_schema.parameters where specific_schema = '" +
						this.Database.SchemaName + "' and specific_name = '" + (string)this._row["specific_name"] + "'";

					IDbConnection cn = ConnectionHelper.CreateConnection(this.dbRoot, this.Database.Name);

					DataTable metaData = new DataTable();
                    DbDataAdapter adapter = PostgreSQLDatabases.CreateAdapter(query, cn);

					adapter.Fill(metaData);
					cn.Close();

					metaData.Columns["udt_name"].ColumnName = "TYPE_NAME";
					metaData.Columns["data_type"].ColumnName = "TYPE_NAMECOMPLETE";

					if(metaData.Columns.Contains("TYPE_NAME"))
						_parameters.f_TypeName = metaData.Columns["TYPE_NAME"];

					if(metaData.Columns.Contains("TYPE_NAMECOMPLETE"))
						_parameters.f_TypeNameComplete = metaData.Columns["TYPE_NAMECOMPLETE"];
		
					_parameters.PopulateArray(metaData);

				}
				return _parameters;
			}
		}

		private PostgreSQLParameters _parameters = null;
	}
}
