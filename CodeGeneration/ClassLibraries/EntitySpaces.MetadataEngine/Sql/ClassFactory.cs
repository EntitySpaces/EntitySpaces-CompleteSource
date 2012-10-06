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

namespace EntitySpaces.MetadataEngine.Sql
{
	public class ClassFactory : IClassFactory
	{
		public ClassFactory()
		{

		}

		public ITables CreateTables()
		{
			return new Sql.SqlTables();
		}

		public ITable CreateTable()
		{
			return new Sql.SqlTable();
		}

		public IColumn CreateColumn()
		{
			return new Sql.SqlColumn();
		}

		public IColumns CreateColumns()
		{
			return new Sql.SqlColumns();
		}

		public IDatabase CreateDatabase()
		{
			return new Sql.SqlDatabase();
		}

		public IDatabases CreateDatabases()
		{
			return new Sql.SqlDatabases();
		}

		public IProcedure CreateProcedure()
		{
			return new Sql.SqlProcedure();
		}

		public IProcedures CreateProcedures()
		{
			return new Sql.SqlProcedures();
		}

		public IView CreateView()
		{
			return new Sql.SqlView();
		}

		public IViews CreateViews()
		{
			return new Sql.SqlViews();
		}

		public IParameter CreateParameter()
		{
			return new Sql.SqlParameter();
		}

		public IParameters CreateParameters()
		{
			return new Sql.SqlParameters();
		}

		public IForeignKey  CreateForeignKey()
		{
			return new Sql.SqlForeignKey();
		}

		public IForeignKeys CreateForeignKeys()
		{
			return new Sql.SqlForeignKeys();
		}

		public IIndex CreateIndex()
		{
			return new Sql.SqlIndex();
		}

		public IIndexes CreateIndexes()
		{
			return new Sql.SqlIndexes();
		}

		public IResultColumn CreateResultColumn()
		{
			return new Sql.SqlResultColumn();
		}

		public IResultColumns CreateResultColumns()
		{
			return new Sql.SqlResultColumns();
		}

		public IDomain CreateDomain()
		{
			return new Sql.SqlDomain();
		}

		public IDomains CreateDomains()
		{
			return new Sql.SqlDomains();
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
            return new System.Data.OleDb.OleDbConnection();
        }
    }
}
