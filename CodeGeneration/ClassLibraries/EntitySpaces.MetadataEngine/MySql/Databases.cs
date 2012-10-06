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
using System.Reflection;

namespace EntitySpaces.MetadataEngine.MySql
{
	public class MySqlDatabases : Databases
	{
		static internal string nameSpace = "MySql.Data.MySqlClient."; 
		static internal Assembly asm = null;
		static internal Module   mod = null;

		static internal ConstructorInfo IDbConnectionCtor = null;
		static internal ConstructorInfo IDbDataAdapterCtor = null;
        static internal ConstructorInfo IDbDataAdapterCtor2 = null;

		internal string Version = "";

		public MySqlDatabases()
		{
			MySqlDatabases.LoadAssembly();
		}

		static MySqlDatabases()
		{
			LoadAssembly();
		}

		static public void LoadAssembly()
		{
			try
			{
				if(asm == null)
				{
					try 
					{
						asm = Assembly.LoadWithPartialName("MySql.Data");
						Module[] mods = asm.GetModules(false);
						mod = mods[0];
					}
					catch 
					{
						throw new Exception("Make sure the MySql.Data.dll is registered in the Gac or is located in the MyGeneration folder.");
					}
				}
			}
			catch {}
		}

		internal override void LoadAll()
		{
			try
			{
				string name = "";

                // test


                // test

				// We add our one and only Database
				IDbConnection conn = MySqlDatabases.CreateConnection(this.dbRoot.ConnectionString);
				conn.Open();
				name = conn.Database;
				conn.Close();
				conn.Dispose();

				MySqlDatabase database = (MySqlDatabase)this.dbRoot.ClassFactory.CreateDatabase();
				database._name = name;
				database.dbRoot = this.dbRoot;
				database.Databases = this;
				this._array.Add(database);

				try
				{
					DataTable metaData = new DataTable();
					DbDataAdapter adapter = MySqlDatabases.CreateAdapter("SELECT VERSION()", this.dbRoot.ConnectionString);

					adapter.Fill(metaData);

					this.Version = metaData.Rows[0][0] as string;
				}
				catch {}
			}
			catch {}
		}

		static internal IDbConnection CreateConnection(string connStr)
		{
			if(IDbConnectionCtor == null)
			{
				Type type = mod.GetType(nameSpace + "MySqlConnection");

				IDbConnectionCtor = type.GetConstructor(new Type[]{typeof(string)});
			}

			object obj =  IDbConnectionCtor.Invoke(BindingFlags.CreateInstance | BindingFlags.OptionalParamBinding, 
				null, new object[] {connStr}, null);

			return obj as IDbConnection;
		}

		static internal DbDataAdapter CreateAdapter(string query, string connStr)
		{
			if(IDbDataAdapterCtor2 == null)
			{
				Type type = mod.GetType(nameSpace + "MySqlDataAdapter");

				IDbDataAdapterCtor2 = type.GetConstructor(new Type[] {typeof(string), typeof(string)} );
			}

			object obj =  IDbDataAdapterCtor2.Invoke
				(BindingFlags.CreateInstance | BindingFlags.OptionalParamBinding, null, 
				new object[] {query, connStr}, null);

			return obj as DbDataAdapter;
		}
	}
}
