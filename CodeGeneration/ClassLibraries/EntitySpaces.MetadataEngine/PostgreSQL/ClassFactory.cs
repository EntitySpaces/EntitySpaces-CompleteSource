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

using EntitySpaces.MetadataEngine;

namespace EntitySpaces.MetadataEngine.PostgreSQL
{
	public class ClassFactory : IClassFactory
	{
        public ClassFactory()
		{

		}

		public ITables CreateTables()
		{
			return new PostgreSQL.PostgreSQLTables();
		}

		public ITable CreateTable()
		{
			return new PostgreSQL.PostgreSQLTable();
		}

		public IColumn CreateColumn()
		{
			return new PostgreSQL.PostgreSQLColumn();
		}

		public IColumns CreateColumns()
		{
			return new PostgreSQL.PostgreSQLColumns();
		}

		public IDatabase CreateDatabase()
		{
			return new PostgreSQL.PostgreSQLDatabase();
		}

		public IDatabases CreateDatabases()
		{
			return new PostgreSQL.PostgreSQLDatabases();
		}

		public IProcedure CreateProcedure()
		{
			return new PostgreSQL.PostgreSQLProcedure();
		}

		public IProcedures CreateProcedures()
		{
			return new PostgreSQL.PostgreSQLProcedures();
		}

		public IView CreateView()
		{
			return new PostgreSQL.PostgreSQLView();
		}

		public IViews CreateViews()
		{
			return new PostgreSQL.PostgreSQLViews();
		}

		public IParameter CreateParameter()
		{
			return new PostgreSQL.PostgreSQLParameter();
		}

		public IParameters CreateParameters()
		{
			return new PostgreSQL.PostgreSQLParameters();
		}

		public IForeignKey  CreateForeignKey()
		{
			return new PostgreSQL.PostgreSQLForeignKey();
		}

		public IForeignKeys CreateForeignKeys()
		{
			return new PostgreSQL.PostgreSQLForeignKeys();
		}

		public IIndex CreateIndex()
		{
			return new PostgreSQL.PostgreSQLIndex();
		}

		public IIndexes CreateIndexes()
		{
			return new PostgreSQL.PostgreSQLIndexes();
		}

		public IResultColumn CreateResultColumn()
		{
			return new PostgreSQL.PostgreSQLResultColumn();
		}

		public IResultColumns CreateResultColumns()
		{
			return new PostgreSQL.PostgreSQLResultColumns();
		}

		public IDomain CreateDomain()
		{
			return new PostgreSQLDomain();
		}

		public IDomains CreateDomains()
		{
			return new PostgreSQLDomains();
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
            return PostgreSQLDatabases.CreateConnection("");
        }
    }
}
