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


namespace EntitySpaces.MetadataEngine.MySql
{
	public class ClassFactory : IClassFactory
	{
		public ClassFactory()
		{

		}

		public ITables CreateTables()
		{
			return new MySql.MySqlTables();
		}

		public ITable CreateTable()
		{
			return new MySql.MySqlTable();
		}

		public IColumn CreateColumn()
		{
			return new MySql.MySqlColumn();
		}

		public IColumns CreateColumns()
		{
			return new MySql.MySqlColumns();
		}

		public IDatabase CreateDatabase()
		{
			return new MySql.MySqlDatabase();
		}

		public IDatabases CreateDatabases()
		{
			return new MySql.MySqlDatabases();
		}

		public IProcedure CreateProcedure()
		{
			return new MySql.MySqlProcedure();
		}

		public IProcedures CreateProcedures()
		{
			return new MySql.MySqlProcedures();
		}

		public IView CreateView()
		{
			return new MySql.MySqlView();
		}

		public IViews CreateViews()
		{
			return new MySql.MySqlViews();
		}

		public IParameter CreateParameter()
		{
			return new MySql.MySqlParameter();
		}

		public IParameters CreateParameters()
		{
			return new MySql.MySqlParameters();
		}

		public IForeignKey CreateForeignKey()
		{
			return new MySql.MySqlForeignKey();
		}

		public IForeignKeys CreateForeignKeys()
		{
			return new MySql.MySqlForeignKeys();
		}

		public IIndex CreateIndex()
		{
			return new MySql.MySqlIndex();
		}

		public IIndexes CreateIndexes()
		{
			return new MySql.MySqlIndexes();
		}

		public IResultColumn CreateResultColumn()
		{
			return new MySql.MySqlResultColumn();
		}

		public IResultColumns CreateResultColumns()
		{
			return new MySql.MySqlResultColumns();
		}

		public IDomain CreateDomain()
		{
			return new MySqlDomain();
		}

		public IDomains CreateDomains()
		{
			return new MySqlDomains();
		}

		public IProviderType CreateProviderType()
		{
			return new ProviderType();
		}

		public IProviderTypes CreateProviderTypes()
		{
			return new ProviderTypes();
		}

        public System.Data.IDbConnection CreateConnection()
        {
            return MySqlDatabases.CreateConnection("");
        }
	}
}
